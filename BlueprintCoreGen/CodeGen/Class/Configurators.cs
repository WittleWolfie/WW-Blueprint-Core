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
    /// Class summary comment.
    /// </summary>
    public string Summary { get; }

    /// <summary>
    /// List of constructor methods for available blueprint components.
    /// </summary>
    public List<ConstructorMethod> ComponentMethods { get; }

    // TODO: Field methods
  }

  public static class Configurators
  {
    private static readonly Type BlueprintTypeRoot = typeof(BlueprintScriptableObject);

    public static IConfigurator Get(Type[] gameTypes)
    {
      // Create an initial list of supported blueprint configurator types
      var blueprintTypes =
        gameTypes.Where(
          t =>
            !Ignored.ShouldIgnore(t)
            && (t.Equals(BlueprintTypeRoot) || t.IsSubclassOf(BlueprintTypeRoot)));

      Dictionary<Type, List<ConstructorMethod>> componentMethodsByBlueprintType = new();
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

      return null;
    }

    private static Dictionary<Type, ConstructorMethod> GetComponentMethodsByType(Type[] gameTypes)
    {
      // TODO: Overrides
      Dictionary<Type, ConstructorMethod> componentMethodsByType = new();
      gameTypes.Where(t => t.IsSubclassOf(typeof(BlueprintComponent)))
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

    private class ConfiguratorImpl : IConfigurator
    {
      public string FilePath { get; }

      public string Namespace { get; }

      public string ClassName { get; }

      public string Summary { get; }

      public List<ConstructorMethod> ComponentMethods { get; }

      public ConfiguratorImpl()
      {

      }
    }
  }
}
