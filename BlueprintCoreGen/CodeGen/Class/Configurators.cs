using BlueprintCoreGen.CodeGen.Methods;
using BlueprintCoreGen.CodeGen.Overrides.Ignored;
using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCoreGen.CodeGen.Class
{
  /// <summary>
  /// Contains basic information needed to generate a configurator class.
  /// </summary>
  public interface IConfigurator
  {
    /// <summary>
    /// Relative file path of the class, e.g. Blueprints/Configurators/Abilities/Ability.cs.
    /// </summary>
    public string FilePath { get; }

    /// <summary>
    /// Namespace for the configurator class, e.g. BlueprintCore.Blueprints.Configurators.Abilities
    /// </summary>
    public string Namespace { get; }

    /// <summary>
    /// Name of the configurator, e.g. AbilityConfigurator
    /// </summary>
    public string ClassName { get; }

    /// <summary>
    /// Name of the parent configurator, e.g. BaseFeatureConfigurator
    /// </summary>
    public string ParentClassName { get; }

    /// <summary>
    /// Name of the blueprint type supported, e.g. BlueprintFeature
    /// </summary>
    public string TypeName { get; }

    /// <summary>
    /// Type of blueprint, e.g. BlueprintFeature
    /// </summary>
    public Type BlueprintType { get; }

    /// <summary>
    /// Indicates whether the configurator is abstract.
    /// </summary>
    public bool IsAbstract { get; }

    /// <summary>
    /// List of constructor methods for available blueprint components.
    /// </summary>
    public List<ConstructorMethod> ComponentMethods { get; }

    /// <summary>
    /// List of field methods for the blueprint.
    /// </summary>
    public List<FieldMethod> FieldMethods { get; }

    /// <summary>
    /// True for the root configurator, i.e. BlueprintConfigurator
    /// </summary>
    public bool IsRoot { get; }
  }

  public static class Configurators
  {
    private static readonly Type BlueprintTypeRoot = typeof(BlueprintScriptableObject);

    public static List<IConfigurator> Get(Type[] gameTypes)
    {
      // Create an initial list of supported blueprint configurator types
      var blueprintTypes =
        gameTypes.Where(
          t =>
            !Ignored.ShouldIgnore(t)
            && (t.Equals(BlueprintTypeRoot) || t.IsSubclassOf(BlueprintTypeRoot)));

      Dictionary<Type, HashSet<ConstructorMethod>> componentMethodsByBlueprintType = new();
      foreach (Type blueprintType in blueprintTypes)
      {
        componentMethodsByBlueprintType.Add(blueprintType, new());
      }

      var componentMethodsByType = GetComponentMethodsByType(gameTypes);
      foreach (Type componentType in componentMethodsByType.Keys)
      {
        GetAllowedBlueprintTypes(componentType).ForEach(
          blueprintType =>
          {
            if (componentMethodsByBlueprintType.ContainsKey(blueprintType))
            {
              componentMethodsByBlueprintType[blueprintType].Add(componentMethodsByType[componentType]);
            }
          });
      }

      List<IConfigurator> configurators = new();
      foreach (var blueprintType in blueprintTypes)
      {
        var isRoot = blueprintType == BlueprintTypeRoot;
        var relativeNamespace =
          string.Join('.', blueprintType.Namespace!.Split('.').Where(pkg => !IgnoredNamespacePackages.Contains(pkg)));
        var nameSpace = GetNamespace(relativeNamespace);
        var className = GetClassName(blueprintType);
        var parentClassName = isRoot ? "RootConfigurator" : $"Base{GetClassName(blueprintType.BaseType!)}";
        var abstractClassName = $"Base{className}";
        var typeName = TypeTool.GetName(blueprintType);

        List<FieldMethod> fieldMethods = new();
        // TODO: Add ignored field handling
        blueprintType.GetFields().ToList().ForEach(field => fieldMethods.Add(new(field.Name)));

        if (blueprintType.IsAbstract)
        {
          var configuratorImpl =
            new ConfiguratorImpl(
              GetFilePath(relativeNamespace, abstractClassName),
              nameSpace,
              abstractClassName,
              parentClassName,
              typeName,
              blueprintType,
              /* isAbstract= */ true,
              componentMethodsByBlueprintType[blueprintType],
              fieldMethods);
          configuratorImpl.IsRoot = isRoot;
          configurators.Add(configuratorImpl);
          continue;
        }

        configurators.Add(
        new ConfiguratorImpl(
          GetFilePath(relativeNamespace, abstractClassName),
          nameSpace,
          abstractClassName,
          parentClassName,
          typeName,
          blueprintType,
          /* isAbstract= */ true,
          componentMethodsByBlueprintType[blueprintType],
          fieldMethods));
        configurators.Add(
          new ConfiguratorImpl(
            GetFilePath(relativeNamespace, className),
            nameSpace,
            className,
            abstractClassName,
            typeName,
            blueprintType,
            /* isAbstract= */ false,
            new(), // All the methods are in the base class
            new()));
      }

      return configurators;
    }

    private static Dictionary<Type, ConstructorMethod> GetComponentMethodsByType(Type[] gameTypes)
    {
      // TODO: Overrides
      Dictionary<Type, ConstructorMethod> componentMethodsByType = new();
      gameTypes.Where(t => t.IsSubclassOf(typeof(BlueprintComponent)) && !t.IsAbstract)
        .ToList()
        .ForEach(t => componentMethodsByType.Add(t, new ConstructorMethod(t.Name)));
      return componentMethodsByType;
    }

    private static List<Type> GetAllowedBlueprintTypes(Type componentType)
    {
      // TODO: Overrides
      List<Type> allowedOn = new();
      Type current = componentType;
      while (current != typeof(BlueprintComponent))
      {
        var allowedOnAttrs =
          Attribute.GetCustomAttributes(current, typeof(AllowedOnAttribute), inherit: false)
            .Cast<AllowedOnAttribute>();
        allowedOn.AddRange(allowedOnAttrs.Select(attr => attr.Type));

        if (allowedOn.Any())
        {
          // Technically the attribute is inherited unless it's Override field is true. In practice it seems like the
          // safest implementation is to take the youngest descendant's attributes.
          break;
        }
        current = current.BaseType!;
      }

      if (!allowedOn.Any())
      {
        // Works on all blueprint types
        allowedOn.Add(typeof(BlueprintScriptableObject));
        return allowedOn;
      }

      // Some components declare the attribute for both a parent and child type. Remove child class declarations for
      // simplicity.
      allowedOn.RemoveAll(child => allowedOn.Exists(parent => child.IsSubclassOf(parent)));
      return allowedOn;
    }

    private static readonly List<string> IgnoredNamespacePackages =
        new()
        {
          "Kingmaker",
          "Blueprints",
          "TacticalCombat",
          "Considerations",
          "Controllers",
          "Rest",
          "GlobalMagic",
          "Designers",
          "Mechanics",
          "Persistence",
          "Versioning",
          "Arbiter",
          "Clockwork",
          "Settings",
          "CharacterSystem",
          "HitSystem",
          "LightSelector",
          "Sound"
        };
    private static string GetNamespace(string relativeNamespace)
    {
      if (string.IsNullOrEmpty(relativeNamespace))
      {
        return "BlueprintCore.Blueprints.Configurators";
      }
      return $"BlueprintCore.Blueprints.Configurators.{relativeNamespace}";
    }

    private static string GetClassName(Type blueprintType)
    {
      if (blueprintType == BlueprintTypeRoot)
      {
        return "BlueprintConfigurator";
      }
      return $"{TypeTool.GetName(blueprintType).Replace("Blueprint", "")}Configurator";
    }

    private static string GetFilePath(string relativeNamespace, string className)
    {
      return
        $"BlueprintConfigurators/{relativeNamespace.Replace('.', '/')}/{className.Replace("Configurator", "")}.cs";
    }

    private class ConfiguratorImpl : IConfigurator
    {
      public string FilePath { get; }

      public string Namespace { get; }

      public string ClassName { get; }

      public string ParentClassName { get; }

      public string TypeName { get; }

      public Type BlueprintType { get; }
      public bool IsAbstract { get; }

      public List<ConstructorMethod> ComponentMethods { get; }

      public List<FieldMethod> FieldMethods { get; }

      public bool IsRoot { get; set; } = false;

      public ConfiguratorImpl(
        string filePath,
        string nameSpace,
        string className,
        string parentClassName,
        string typeName,
        Type blueprintType,
        bool isAbstract,
        HashSet<ConstructorMethod> componentMethods,
        List<FieldMethod> fieldMethods)
      {
        FilePath = filePath;
        Namespace = nameSpace;
        ClassName = className;
        ParentClassName = parentClassName;
        TypeName = typeName;
        BlueprintType = blueprintType;
        IsAbstract = isAbstract;
        ComponentMethods = componentMethods.ToList();
        FieldMethods = fieldMethods;
      }
    }
  }
}
