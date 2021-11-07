using BlueprintCoreGen.CodeGen;
using HarmonyLib;
using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BlueprintCoreGen.CodeGen
{
  /// <summary>
  /// Processes *.cs files in the Templates folder and converts them into classes for use in BlueprintCore.
  /// </summary>
  /// 
  /// <remarks>
  /// <para>
  /// Attributes are used to convert template classes with additional logic to customize the output.
  /// </para>
  /// <list type="bullet">
  /// <listheader>Attributes</listheader>
  /// <item>
  ///   <term><see cref="ImplementsAttribute"/></term>
  ///   <description>
  ///   Use on methods that implement a game type such as a <see cref="Kingmaker.ElementsSystem.GameAction"/> or
  ///   <see cref="Kingmaker.ElementsSystem.Condition"/>. This is used to determine which types need automatically
  ///   generated methods. e.g. <c>[Implements(typeof(Conditional))]</c>
  ///   </description>
  /// </item>
  /// <item>
  ///   <term>Replace</term>
  ///   <description>
  ///   A simple tag instructing the processor to run <see cref="string.Replace(string, string?)"/> on the next line.
  ///   Implemented using a comment because attributes in C# cannot be applied to arbitrary lines of code. e.g.
  ///   <c>// [Replace("Original", "Replacement")]</c> would replace occurrences of the text Original on the next line
  ///   with Replacement.
  ///   </description>
  /// </item>
  /// <item>
  ///   <term>Generate</term>
  ///   <description>
  ///   Generate tags indicate where in the template to insert generated types.
  ///   e.g. <c>// [Generate(typeof(Conditional))]</c> is automatically replaced a method for the Conditional action.
  ///   </description>
  /// </item>
  /// </list>
  /// </remarks>
  public static class TemplateProcessor
  {
    private static readonly Regex Replace = new(@"^\s*// \[Replace\(""(.*)"", ""(.*)""\)\]", RegexOptions.Compiled);
    private static readonly Regex Import = new(@"^using [\w\.]+;", RegexOptions.Compiled);
    private static readonly Regex Namespace = new(@"^namespace [\w\.]+", RegexOptions.Compiled);
    private static readonly Regex Generate = new(@"^\s*// \[Generate\((.*)\)\]", RegexOptions.Compiled);
    private static readonly Regex MethodAttribute =
        new(@"^\s+\[Implements\(typeof\((\w+)\)\)\]", RegexOptions.Compiled);

    public static readonly List<Template> ActionTemplates = new();
    public static readonly List<Template> ConditionTemplates = new();
    public static readonly List<Template> ConfiguratorTemplates = new();

    public static void Run(Type[] gameTypes)
    {
      var templatesRoot = Path.Combine(Directory.GetCurrentDirectory(), "Templates");

      var actionsBuilderRoot = Path.Combine(templatesRoot, "ActionsBuilder");
      foreach (string file in Directory.GetFiles(actionsBuilderRoot, "*.cs", SearchOption.AllDirectories))
      {
        ActionTemplates.Add(ProcessBuilderTemplate(file, Path.GetRelativePath(templatesRoot, file)));
      }

      var conditionsBuilderRoot = Path.Combine(templatesRoot, "ConditionsBuilder");
      foreach (string file in Directory.GetFiles(conditionsBuilderRoot, "*.cs", SearchOption.AllDirectories))
      {
        ConditionTemplates.Add(ProcessBuilderTemplate(file, Path.GetRelativePath(templatesRoot, file)));
      }

      ProcessBlueprintTemplates(templatesRoot, gameTypes);
    }

    public static List<Type> GetMissingTypes(Type baseType, ICollection<Type> implementedTypes, Type[] gameTypes)
    {
      List<Type> missingTypes = new();
      foreach (Type type in gameTypes.Where(t => t.IsSubclassOf(baseType)))
      {
        if (!type.IsAbstract && !implementedTypes.Contains(type))
        {
          missingTypes.Add(type);
        }
      }
      return missingTypes;
    }

    private static Template ProcessBuilderTemplate(string file, string relativePath)
    {
      var template = new Template(relativePath);

      string currentLine;
      (string Old, string New)? replacement = null;
      foreach (var line in File.ReadAllLines(file))
      {
        currentLine = line;
        if (Replace.IsMatch(currentLine))
        {
          Match match = Replace.Match(currentLine);
          replacement = (match.Groups[1].Value, match.Groups[2].Value);
          continue;
        }

        if (replacement != null)
        {
          currentLine = currentLine.Replace(replacement?.Old, replacement?.New);
          replacement = null;
        }

        if (Import.IsMatch(currentLine))
        {
          template.AddImport(currentLine);
          continue;
        }

        if (Namespace.IsMatch(currentLine))
        {
          // Convert the namespace for BlueprintCore
          template.AddLine(currentLine.Replace("BlueprintCoreGen", "BlueprintCore"));
          continue;
        }

        if (Generate.IsMatch(currentLine))
        {
          var type = AccessTools.TypeByName(Generate.Match(currentLine).Groups[1].Value);
          template.AddMethod(CodeGenerator.CreateMethod(type));
          template.AddType(type);
          continue;
        }
         
        if (MethodAttribute.IsMatch(currentLine))
        {
          template.AddType(AccessTools.TypeByName(MethodAttribute.Match(currentLine).Groups[1].Value));
        }
        template.AddLine(currentLine);
      }
      return template;
    }

    private static void ProcessBlueprintTemplates(string templatesRoot, Type[] gameTypes)
    {
      var componentsRoot = Path.Combine(templatesRoot, "BlueprintComponents");

      // Construct a dictionary from component type to implementing methods
      Dictionary<Type, List<Method>> methodsByComponentType = new();
      foreach (string file in Directory.GetFiles(componentsRoot, "*.cs", SearchOption.AllDirectories))
      {
        var componentTemplate = ProcessBlueprintComponentTemplate(file);
        componentTemplate.Keys.ToList().ForEach(
            key =>
            {
              if (!methodsByComponentType.ContainsKey(key))
              {
                methodsByComponentType.Add(key, new());
              }
              methodsByComponentType[key].AddRange(componentTemplate[key]);
            });
      }

      // Generate methods for any component types not found in templates
      GetMissingTypes(typeof(BlueprintComponent), methodsByComponentType.Keys, gameTypes).ForEach(
         type =>
         {
           methodsByComponentType.Add(type, new() { CodeGenerator.CreateMethod(type) });
         });

      // Iterate through component types and construct a dictionary from blueprint type to supported component methods
      List<Method> univeralMethods = new();
      Dictionary<Type, List<Method>> methodsByBlueprintType = new();
      foreach (var componentType in methodsByComponentType.Keys)
      {
        Attribute[] attrs = Attribute.GetCustomAttributes(componentType);
        List<AllowedOnAttribute> allowedOn =
            attrs.Where(attr => attr is AllowedOnAttribute).Select(attr => attr as AllowedOnAttribute).ToList();

        if (allowedOn.Count == 0)
        {
          // This should work on all blueprint types
          univeralMethods.AddRange(methodsByComponentType[componentType]);
          continue;
        }

        // Keep only the strictest subset of allowed types. i.e. If BlueprintFeature and BlueprintUnitFact are allowed,
        // keep only BlueprintFeature. The assumption is that the more specific type overrides the less specific type.
        // This ensures the API only exposes supported components although it may not expose all of them.
        List<AllowedOnAttribute> filter = new();
        allowedOn.ForEach(
            allowed =>
            {
              if (allowedOn.Exists(attr => attr.Type.IsSubclassOf(allowed.Type)))
              {
                filter.Add(allowed);
              }
            });
        allowedOn = allowedOn.Except(filter).ToList();

        // Use allowedOn to add methods for this component to each supported blueprint type.
        foreach (var allowed in allowedOn)
        {
          if (!methodsByBlueprintType.ContainsKey(allowed.Type))
          {
            methodsByBlueprintType.Add(allowed.Type, new());
          }
          methodsByBlueprintType[allowed.Type].AddRange(methodsByComponentType[componentType]);
        }
      }

      // TODO: Create configurator classes
    }

    private static Dictionary<Type, List<Method>> ProcessBlueprintComponentTemplate(string file)
    {
      return new();
    }
  }
}
