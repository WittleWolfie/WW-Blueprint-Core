using System;
using System.Collections.Generic;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints
{
  /** Utility for operating on Blueprint types. */
  public static class BlueprintTool
  {
    public static T Create<T>(string name) where T : SimpleBlueprint, new()
    {
      if (!Guid.TryParse(name, out Guid assetId)) { assetId = Guid.Parse(Guids.Get(name)); }

      return Create<T>(name, assetId);
    }

    public static T Create<T>(string name, string assetId) where T : SimpleBlueprint, new()
    {
      return Create<T>(name, Guid.Parse(assetId));
    }

    private static T Create<T>(string name, Guid assetId) where T : SimpleBlueprint, new()
    {
      var guid = new BlueprintGuid(assetId);
      var existingAsset = ResourcesLibrary.TryGetBlueprint(guid);
      if (existingAsset != null)
      {
        throw new InvalidOperationException(
            $"Blueprint creation failed: {name} - {assetId}.\n"
            + $"Already in use by: {existingAsset.name}.");
      }

      T asset = new()
      {
        name = name,
        AssetGuid = new BlueprintGuid(assetId)
      };
      ResourcesLibrary.BlueprintsCache.AddCachedBlueprint(guid, asset);
      return asset;
    }

    public static T Get<T>(string name) where T : SimpleBlueprint
    {
      if (!Guid.TryParse(name, out Guid assetId)) { assetId = Guid.Parse(Guids.Get(name)); }

      SimpleBlueprint asset = ResourcesLibrary.TryGetBlueprint(new BlueprintGuid(assetId));
      if (asset is T result)
      {
        return result;
      }
      else
      {
        throw new InvalidOperationException(
            $"Failed to fetch blueprint: {name} - {assetId}.\n"
            + $"Is the type correct? {typeof(T)}");
      }
    }

    public static TRef GetRef<TRef>(string name)
        where TRef : BlueprintReferenceBase, new()
    {
      if (string.IsNullOrEmpty(name))
      {
        return BlueprintReferenceBase.CreateTyped<TRef>(null);
      }

      if (!Guid.TryParse(name, out Guid assetId)) { assetId = Guid.Parse(Guids.Get(name)); }

      // Copied from BlueprintReferenceBase to allow creating a reference w/o fetching a blueprint.
      // This allows referencing a blueprint before it is added to the cache.
      var reference = Activator.CreateInstance<TRef>();
      reference.deserializedGuid = new BlueprintGuid(assetId);
      return reference;
    }
  }

  /** Useful extension methods for Blueprints. */
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