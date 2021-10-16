using System;
using System.Collections.Generic;
using System.Linq;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints
{
  /** Utility for operating on Blueprint types. */
  public static class BlueprintTool
  {
    private static readonly LogWrapper Logger = LogWrapper.GetInternal("BlueprintTool");
    private static readonly Dictionary<string, Guid> GuidsByName = new();

    /**
     * Creates a mapping from Name (key) to Guid (value). Once called, configurators and builders
     * accept the given Name whenever a reference to the Blueprint with the given Guid is required.
     */
    public static void AddGuidsByName(Dictionary<string, string> guidsByName)
    {
      AddGuidsByName(guidsByName.Select(entry => (entry.Key, entry.Value)).ToArray());
    }

    /**
     * Creates a mapping from Name to Guid. Once called, configurators and builders accept the given
     * Name whenever a reference to the Blueprint with the given Guid is required.
     */
    public static void AddGuidsByName(params (string name, string guid)[] guidsByName)
    {
      guidsByName
          .ToList()
          .ForEach(entry =>
              {
                if (GuidsByName.TryGetValue(entry.name, out Guid guid))
                {
                  if (guid.ToString() == entry.guid)
                  {
                    // Duplicate name to guid mapping, ignore
                    return;
                  }
                  else
                  {
                    throw new InvalidOperationException(
                        $"Duplicate GuidByName. {entry.name} - {entry.guid} requested, but"
                        + $" {entry.name} already maps to {guid}.\n"
                        + $"This indicates an error in single mod or an incompatibility between two"
                        + $" mods. ");
                  }
                }

                Logger.Verbose($"Adding GuidByName: {entry.name} - {entry.guid}");
                guid = Guid.Parse(entry.guid);
                GuidsByName.Add(entry.name, guid);
              });
    }

    /**
     * Creates a new Blueprint. The given Name must be mapped to a Guid first using
     * AddGuidsByName().
     */
    public static T Create<T>(string name) where T : SimpleBlueprint, new()
    {
      return Create<T>(name, GuidsByName[name]);
    }

    /** Creates a new Blueprint with the specified Name and AssetId (Guid). */
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

    /**
     * Returns the Blueprint from the game library with the specified nameOrId.
     *
     * @param nameOrId Use the name if you have specified a mapping with AddGuidsByName; use the
     *   AssetId / Guid otherwise.
     */
    public static T Get<T>(string nameOrId) where T : SimpleBlueprint
    {
      if (!GuidsByName.TryGetValue(nameOrId, out Guid assetId))
      {
        assetId = Guid.Parse(nameOrId);
      }

      SimpleBlueprint asset = ResourcesLibrary.TryGetBlueprint(new BlueprintGuid(assetId));
      if (asset is T result)
      {
        return result;
      }
      else
      {
        throw new InvalidOperationException(
            $"Failed to fetch blueprint: {nameOrId} - {assetId}.\n"
            + $"Is the type correct? {typeof(T)}");
      }
    }

    /**
     * Returns a reference to the Blueprint with the specified nameOrId. The referenced Blueprint
     * does not have to be in the game library, but it will throw an exception if the reference is
     * used before the Blueprint has been added.
     *
     * If nameOrId is null, it will return a typed reference with a null Guid.
     *
     * @param nameOrId Use the name if you have specified a mapping with AddGuidsByName; use the
     *   AssetId / Guid otherwise.
     */
    public static TRef GetRef<TRef>(string nameOrId)
        where TRef : BlueprintReferenceBase, new()
    {
      if (string.IsNullOrEmpty(nameOrId))
      {
        return BlueprintReferenceBase.CreateTyped<TRef>(null);
      }

      if (!GuidsByName.TryGetValue(nameOrId, out Guid assetId))
      {
        assetId = Guid.Parse(nameOrId);
      }

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

    // Modified from https://github.com/Vek17/WrathMods-TabletopTweaks ExtensionMethods
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
    }
  }
}