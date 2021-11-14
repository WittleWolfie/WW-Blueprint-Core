using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.RandomEncounters.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
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
  ///   <term><see cref="ConfiguresAttribute"/></term>
  ///   <description>
  ///   Use on configurators that implement a blueprint type such as
  ///   <see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/>. This is used to determine which blueprint types
  ///   need automatically generated configurators. e.g. <c>[Configures(typeof(BlueprintFeature))]</c>
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
  /// <item>
  ///   <term>GenerateComponents</term>
  ///   <description>
  ///   GenerateComponents tags indicate where in the template to insert generated blueprint component methods.
  ///   e.g. <c>// [GenerateComponents]</c>
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

    // For configurators
    private static readonly Regex Configures = new(@"^\s+\[Configures\(typeof\((\w+)\)\)\]", RegexOptions.Compiled);
    private static readonly Regex GenerateComponents = new(@"^\s*// \[GenerateComponents\]", RegexOptions.Compiled);

    public static readonly List<ClassTemplate> ActionTemplates = new();
    public static readonly List<ClassTemplate> ConditionTemplates = new();
    public static readonly List<ConfiguratorTemplate> ConfiguratorTemplates = new();

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

    public static List<Type> GetMissingTypes(
        Type baseType, ICollection<Type> implementedTypes, Type[] gameTypes, bool includeAbstractTypes = false)
    {
      List<Type> missingTypes = new();
      foreach (Type type in gameTypes.Where(t => t.IsSubclassOf(baseType)))
      {
        if (!implementedTypes.Contains(type) && (!type.IsAbstract || includeAbstractTypes))
        {
          missingTypes.Add(type);
        }
      }
      return missingTypes;
    }

    private static ClassTemplate ProcessBuilderTemplate(string file, string relativePath)
    {
      var template = new ClassTemplate(relativePath);

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
          // Convert the namespace for BlueprintCore
          template.AddImport(currentLine.Replace("BlueprintCoreGen", "BlueprintCore"));
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
      Dictionary<Type, List<IMethod>> methodsByBlueprintType =
          GetComponentMethodsByBlueprintType(templatesRoot, gameTypes);

      var configuratorRoot = Path.Combine(templatesRoot, "BlueprintConfigurators");
      List<Type> blueprintConfigurators = new();
      foreach (string file in Directory.GetFiles(configuratorRoot, "*.cs", SearchOption.AllDirectories))
      {
        var template =
            ProcessConfiguratorTemplate(file, Path.GetRelativePath(templatesRoot, file), methodsByBlueprintType);
        ConfiguratorTemplates.Add(template);
        blueprintConfigurators.Add(template.BlueprintType);
      }

      var missingBlueprintTypes =
          GetMissingTypes(
              typeof(BlueprintScriptableObject), blueprintConfigurators, gameTypes, includeAbstractTypes: true);
      foreach (var blueprintType in missingBlueprintTypes)
      {
        ConfiguratorTemplates.Add(
            CodeGenerator.CreateConfiguratorClass(
                blueprintType,
                methodsByBlueprintType.ContainsKey(blueprintType)
                    ? methodsByBlueprintType[blueprintType]
                    : new(),
                gameTypes));
      }
    }

    private static ConfiguratorTemplate ProcessConfiguratorTemplate(
        string file, string relativePath, Dictionary<Type, List<IMethod>> methodsByBlueprintType)
    {
      var template = new ConfiguratorTemplate(relativePath);

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
          // Convert the namespace for BlueprintCore
          template.AddImport(currentLine.Replace("BlueprintCoreGen", "BlueprintCore"));
          continue;
        }

        if (Namespace.IsMatch(currentLine))
        {
          // Convert the namespace for BlueprintCore
          template.AddLine(currentLine.Replace("BlueprintCoreGen", "BlueprintCore"));
          continue;
        }

        if (Configures.IsMatch(currentLine))
        {
          template.BlueprintType = AccessTools.TypeByName(Configures.Match(currentLine).Groups[1].Value);
        }

        if (GenerateComponents.IsMatch(currentLine))
        {
          if (template.BlueprintType == null)
          {
            throw new InvalidOperationException("Cannot generate components before the Configures attribute.");
          }
          if (methodsByBlueprintType.ContainsKey(template.BlueprintType))
          {
            methodsByBlueprintType[template.BlueprintType].ForEach(method => template.AddMethod(method));
          }
          continue;
        }

        template.AddLine(currentLine);
      }
      return template;
    }

    private static Dictionary<Type, List<IMethod>> GetComponentMethodsByBlueprintType(
        string templatesRoot, Type[] gameTypes)
    {
      var componentsRoot = Path.Combine(templatesRoot, "BlueprintComponents");

      // Construct a dictionary from component type to implementing methods
      Dictionary<Type, List<IMethod>> methodsByComponentType = new();
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
      Dictionary<Type, List<IMethod>> methodsByBlueprintType = new();
      methodsByBlueprintType.Add(typeof(BlueprintScriptableObject), new());
      foreach (var componentType in methodsByComponentType.Keys)
      {
        List<Type> allowedOn = GetAllowedBlueprintTypes(componentType);

        // Use allowedOn to add methods for this component to each supported blueprint type.
        foreach (var type in allowedOn)
        {
          if (!methodsByBlueprintType.ContainsKey(type))
          {
            methodsByBlueprintType.Add(type, new());
          }
          methodsByBlueprintType[type].AddRange(methodsByComponentType[componentType]);
        }
      }
      return methodsByBlueprintType;
    }

    private static readonly Regex DocComment = new(@"^\s+///", RegexOptions.Compiled);

    private static Dictionary<Type, List<IMethod>> ProcessBlueprintComponentTemplate(string file)
    {
      Dictionary<Type, List<IMethod>> templates = new();
      string[] lines = File.ReadAllLines(file);

      int i = 0;
      List<string> imports = new();
      for (; i < lines.Length; i++)
      {
        if (Import.IsMatch(lines[i])) { imports.Add(lines[i].Replace("BlueprintCoreGen", "BlueprintCore")); }
        else if (Namespace.IsMatch(lines[i])) { break; }
      }

      for (; i < lines.Length; i++)
      {
        if (DocComment.IsMatch(lines[i]) || MethodAttribute.IsMatch(lines[i]))
        {
          // Start of a method
          RawMethodTemplate method = new(imports);
          for (; i < lines.Length; i++)
          {
            if (MethodAttribute.IsMatch(lines[i]))
            {
              var type = AccessTools.TypeByName(MethodAttribute.Match(lines[i]).Groups[1].Value);
              if (!templates.ContainsKey(type)) { templates.Add(type, new()); }
              templates[type].Add(method);
              break;
            }
            method.AddLine(lines[i]);
          }

          // Look for the opening brace
          for (; i < lines.Length; i++)
          {
            if (lines[i].Equals("    {")) { break; }
            method.AddLine(lines[i]);
          }

          // Look for the closing brace
          int blockDepth = 0;
          for (; i < lines.Length; i++)
          {
            method.AddLine(lines[i]);

            blockDepth += lines[i].Count(c => c == '{');
            blockDepth -= lines[i].Count(c => c == '}');

            // Method is done!
            if (blockDepth == 0) { break; }
          }
        }
      }

      return templates;
    }

    private static List<Type> GetAllowedBlueprintTypes(Type componentType)
    {
      if (AllowedBlueprintTypesOverride.ContainsKey(componentType))
      {
        return AllowedBlueprintTypesOverride[componentType];
      }

      Attribute[] attrs = Attribute.GetCustomAttributes(componentType);
      List<AllowedOnAttribute> allowedOn =
          attrs.Where(attr => attr is AllowedOnAttribute).Select(attr => attr as AllowedOnAttribute).ToList();

      List<Type> allowedBlueprintTypes = new();
      if (!allowedOn.Any())
      {
        // This should work on all blueprint types
        allowedBlueprintTypes.Add(typeof(BlueprintScriptableObject));
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
      allowedOn = allowedOn.Except(filter).Distinct(AttrComparer).ToList();

      return allowedBlueprintTypes;
    }

    private static readonly Dictionary<Type, List<Type>> AllowedBlueprintTypesOverride =
        new()
        {
          { typeof(CombatRandomEncounterAreaSettings), new() { typeof(BlueprintArea) } }
        };

    private static readonly AllowedOnAttributeEqualityComparer AttrComparer = new();

    private class AllowedOnAttributeEqualityComparer : IEqualityComparer<AllowedOnAttribute>
    {
      public bool Equals(AllowedOnAttribute x, AllowedOnAttribute y)
      {
        return x.Type == y.Type;
      }

      public int GetHashCode([DisallowNull] AllowedOnAttribute obj)
      {
        return obj.Type.GetHashCode();
      }
    }
  }
}
