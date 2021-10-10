using System;
using System.Collections.Generic;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints
{
  public static class BlueprintTool
  {
    private static readonly LogWrapper Logger = LogWrapper.Get("BlueprintTool");

    public static T Get<T>(string name) where T : SimpleBlueprint
    {
      Guid assetId;
      if (!Guid.TryParse(name, out assetId)) { assetId = Guid.Parse(Guids.Get(name)); }

      SimpleBlueprint asset = ResourcesLibrary.TryGetBlueprint(new BlueprintGuid(assetId));
      T result = asset as T;
      if (result == null)
      {
        Logger.Error(
            $"Failed to fetch blueprint: {name} - {assetId}.\n"
            + $"Is the type correct? {typeof(T)}");
      }
      return result;
    }

    public static TRef GetRef<T, TRef>(string name)
        where T : SimpleBlueprint
        where TRef : BlueprintReference<T>, new()
    {
      if (name == null) { return BlueprintReferenceBase.CreateTyped<TRef>(null); }
      return Get<T>(name).ToReference<TRef>();
    }
  }

  public static class BlueprintExtensions
  {
    public static BlueprintComponent GetComponentMatchingType(
        this BlueprintScriptableObject obj, BlueprintComponent component)
    {
      foreach (BlueprintComponent current in obj.ComponentsArray)
      {
        if (current.GetType() == component.GetType())
        {
          return current;
        }
      }
      return null;
    }

    public static void AddComponents(
        this BlueprintScriptableObject obj, params BlueprintComponent[] components)
    {
      if (components == null) { return; }
      obj.SetComponents(components.AppendToArray(obj.Components));
    }

    // Copied from https://github.com/Vek17/WrathMods-TabletopTweaks ExtensionMethods
    public static void SetComponents(
        this BlueprintScriptableObject obj, params BlueprintComponent[] components)
    {
      // Fix names of components. Generally this doesn't matter, but if they have serialization
      // state, then their name needs to be unique.
      var names = new HashSet<string>();
      foreach (var c in components)
      {
        if (string.IsNullOrEmpty(c.name))
        {
          c.name = $"${c.GetType().Name}";
        }
        if (!names.Add(c.name))
        {
          string name;
          for (int i = 0; !names.Add(name = $"{c.name}${i}"); i++) ;
          c.name = name;
        }
      }
      obj.Components = components;
      obj.OnEnable(); // To make sure components are fully initialized
    }
  }
}