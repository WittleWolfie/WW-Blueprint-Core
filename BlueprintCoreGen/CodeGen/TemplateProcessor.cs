using BlueprintCoreGen.CodeGen.Builders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BlueprintCoreGen.CodeGen
{
  /// <summary>
  /// Processes *.cs files in the Templates folder and converts them into classes for use in BlueprintCore.
  /// </summary>
  public static class TemplateProcessor
  {
    public static readonly List<IClassFile> ActionClasses = new();
    public static readonly List<IClassFile> ConditionClasses = new();
    public static readonly List<IClassFile> ConfiguratorClasses = new();

    public static void Run(Type[] gameTypes)
    {
      var templatesRoot = Path.Combine(Directory.GetCurrentDirectory(), "Templates");

      ActionClasses.AddRange(
          BuilderExtensions.Get(BuilderType.Action).Select(
              extension => ClassFactory.CreateBuilderExtension(extension)));

      ConditionClasses.AddRange(
          BuilderExtensions.Get(BuilderType.Condition).Select(
              extension => ClassFactory.CreateBuilderExtension(extension)));

      //ProcessBlueprintTemplates(templatesRoot, gameTypes);
    }

    public static List<Type> GetUnhandledTypes(
        Type baseType, ICollection<Type> handledTypes, Type[] gameTypes, bool includeAbstractTypes = false)
    {
      List<Type> unhandledTypes = new();
      foreach (Type type in gameTypes.Where(t => t.IsSubclassOf(baseType)))
      {
        if (!handledTypes.Contains(type) && (!type.IsAbstract || includeAbstractTypes))
        {
          unhandledTypes.Add(type);
        }
      }
      return unhandledTypes;
    }

    //private static void ProcessBlueprintTemplates(string templatesRoot, Type[] gameTypes)
    //{
    //  Dictionary<Type, List<IMethod>> methodsByBlueprintType =
    //      GetComponentMethodsByBlueprintType(templatesRoot, gameTypes);

    //  var configuratorRoot = Path.Combine(templatesRoot, "BlueprintConfigurators");
    //  List<Type> blueprintConfigurators = new();
    //  foreach (string file in Directory.GetFiles(configuratorRoot, "*.cs", SearchOption.AllDirectories))
    //  {
    //    var template =
    //        ClassFactory.CreateFromConfiguratorTemplate(
    //            file, Path.GetRelativePath(templatesRoot, file), methodsByBlueprintType);
    //    ConfiguratorClasses.Add(template);
    //    blueprintConfigurators.Add(template.BlueprintType);
    //  }

    //  var missingBlueprintTypes =
    //      GetMissingTypes(
    //          typeof(BlueprintScriptableObject), blueprintConfigurators, gameTypes, includeAbstractTypes: true);
    //  foreach (var blueprintType in missingBlueprintTypes)
    //  {
    //    ConfiguratorClasses.Add(
    //        ClassFactory.CreateConfigurator(
    //            blueprintType,
    //            methodsByBlueprintType.ContainsKey(blueprintType)
    //                ? methodsByBlueprintType[blueprintType]
    //                : new(),
    //            gameTypes));
    //  }
    //}

    //private static Dictionary<Type, List<IMethod>> GetComponentMethodsByBlueprintType(
    //    string templatesRoot, Type[] gameTypes)
    //{
    //  var componentsRoot = Path.Combine(templatesRoot, "BlueprintComponents");

    //  // Construct a dictionary from component type to implementing methods
    //  Dictionary<Type, List<IMethod>> methodsByComponentType = new();
    //  foreach (string file in Directory.GetFiles(componentsRoot, "*.cs", SearchOption.AllDirectories))
    //  {
    //    var componentTemplate = ProcessBlueprintComponentTemplate(file);
    //    componentTemplate.Keys.ToList().ForEach(
    //        key =>
    //        {
    //          if (!methodsByComponentType.ContainsKey(key))
    //          {
    //            methodsByComponentType.Add(key, new());
    //          }
    //          methodsByComponentType[key].AddRange(componentTemplate[key]);
    //        });
    //  }

    //  // Generate methods for any component types not found in templates
    //  GetMissingTypes(typeof(BlueprintComponent), methodsByComponentType.Keys, gameTypes)
    //    .Where(type => !Overrides.IgnoredComponentTypes.Contains(type))
    //    .ToList()
    //    .ForEach(
    //        type =>
    //        {
    //          methodsByComponentType.Add(type, new() { MethodFactory.CreateForBlueprintComponent(type) });
    //        });

    //  // Iterate through component types and construct a dictionary from blueprint type to supported component methods
    //  Dictionary<Type, List<IMethod>> methodsByBlueprintType = new();
    //  foreach (var componentType in methodsByComponentType.Keys)
    //  {
    //    List<Type> allowedOn = GetAllowedBlueprintTypes(componentType);

    //    // Use allowedOn to add methods for this component to each supported blueprint type.
    //    foreach (var type in allowedOn)
    //    {
    //      if (!methodsByBlueprintType.ContainsKey(type))
    //      {
    //        methodsByBlueprintType.Add(type, new());
    //      }
    //      methodsByBlueprintType[type].AddRange(methodsByComponentType[componentType]);
    //    }
    //  }
    //  return methodsByBlueprintType;
    //}

    //private static readonly Regex Import = new(@"^using [\w\.]+;", RegexOptions.Compiled);
    //private static readonly Regex Namespace = new(@"^namespace [\w\.]+", RegexOptions.Compiled);
    //private static readonly Regex MethodAttribute =
    //    new(@"^\s+\[Implements\(typeof\((\w+)\)\)\]", RegexOptions.Compiled);
    //private static readonly Regex DocComment = new(@"^\s+///", RegexOptions.Compiled);

    //private static Dictionary<Type, List<IMethod>> ProcessBlueprintComponentTemplate(string file)
    //{
    //  Dictionary<Type, List<IMethod>> methods = new();
    //  string[] lines = File.ReadAllLines(file);

    //  int i = 0;
    //  List<string> imports = new();
    //  for (; i < lines.Length; i++)
    //  {
    //    if (Import.IsMatch(lines[i])) { imports.Add(lines[i].Replace("BlueprintCoreGen", "BlueprintCore")); }
    //    else if (Namespace.IsMatch(lines[i])) { break; }
    //  }

    //  for (; i < lines.Length; i++)
    //  {
    //    if (DocComment.IsMatch(lines[i]) || MethodAttribute.IsMatch(lines[i]))
    //    {
    //      // Start of a method
    //      var method = new RawMethod(imports);
    //      for (; i < lines.Length; i++)
    //      {
    //        if (MethodAttribute.IsMatch(lines[i]))
    //        {
    //          var type = TypeTool.TypeByName(MethodAttribute.Match(lines[i]).Groups[1].Value);
    //          if (!methods.ContainsKey(type)) { methods.Add(type, new()); }
    //          methods[type].Add(method);
    //          break;
    //        }
    //        method.AddLine(lines[i]);
    //      }

    //      // Look for the opening brace
    //      for (; i < lines.Length; i++)
    //      {
    //        if (lines[i].Equals("    {")) { break; }
    //        method.AddLine(lines[i]);
    //      }

    //      // Look for the closing brace
    //      int blockDepth = 0;
    //      for (; i < lines.Length; i++)
    //      {
    //        method.AddLine(lines[i]);

    //        blockDepth += lines[i].Count(c => c == '{');
    //        blockDepth -= lines[i].Count(c => c == '}');

    //        // Method is done!
    //        if (blockDepth == 0) { break; }
    //      }
    //    }
    //  }

    //  return methods;
    //}

    //private static List<Type> GetAllowedBlueprintTypes(Type componentType)
    //{
    //  if (componentType == typeof(AddFacts))
    //  {
    //    var name = componentType.Name;
    //  }
    //  if (Overrides.AllowedBlueprintTypesOverride.ContainsKey(componentType))
    //  {
    //    return Overrides.AllowedBlueprintTypesOverride[componentType];
    //  }

    //  // Take the youngest descendant's types only, essentially overriding inheritance. This is counter to the
    //  // documentation but I haven't found counterexamples.
    //  List<Type> allowedOn = new();
    //  Type current = componentType;

    //  if (componentType == typeof(ContextCalculateAbilityParams))
    //  {
    //    var name = componentType.Name;
    //  }
    //  while (current != typeof(BlueprintComponent))
    //  {
    //    Attribute[] attrs = Attribute.GetCustomAttributes(current, inherit: false);
    //    allowedOn.AddRange(
    //        attrs
    //            .Where(attr => attr is AllowedOnAttribute)
    //            .Select(attr => attr as AllowedOnAttribute)
    //            .Select(attr => attr.Type));
    //    if (allowedOn.Any()) { break; }
    //    current = current.BaseType;
    //  }

    //  if (!allowedOn.Any())
    //  {
    //    // This should work on all blueprint types
    //    allowedOn.Add(typeof(BlueprintScriptableObject));
    //    return allowedOn;
    //  }

    //  // Ensure there are no duplicate methods defined. Some components will declare both a parent and child type, even
    //  // though the parent declaration is sufficient.
    //  allowedOn.RemoveAll(type => allowedOn.Exists(parent => type.IsSubclassOf(parent)));
    //  return allowedOn;
    //}
  }
}
