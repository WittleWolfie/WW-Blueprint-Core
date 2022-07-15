using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace BlueprintCore.Utils
{
  /// <summary>
  /// Tool for operations on blueprints.
  /// </summary>
  public static class BlueprintTool
  {
    private static readonly LogWrapper Logger = LogWrapper.GetInternal("BlueprintTool");
    private static readonly Dictionary<string, Guid> GuidsByName = new();

    /// <summary>
    /// Returns the stored mapping of blueprint name to Guid.
    /// </summary>
    /// 
    /// <remarks>
    /// Useful if you want to debug or use this for configuration settings. At a minimum this will contain all
    /// blueprints created by your mod, plus any existing blueprints you register a mapping for.
    /// </remarks>
    /// 
    /// <remarks>
    /// This is a copy of the internal mapping so any changes you make will not be reflected.
    /// </remarks>
    public static Dictionary<string, string> GetGuidsByName()
    {
      Dictionary<string, string> result = new();
      GuidsByName.ToList().ForEach(pair => result.Add(pair.Key, pair.Value.ToString()));
      return result;
    }

    /// <summary>Adds the provided mapping from Name (key) to Guid (value).</summary>
    /// 
    /// <remarks>
    /// <para>
    /// After calling this function you can reference blueprints by Name in BlueprintCore APIs.
    /// </para>
    /// 
    /// <example>
    /// Add a mapping for the Power Attack feat and check to see if the caster has it in a
    /// <see cref="Conditions.Builder.ConditionsBuilder">ConditionsBuilder</see>:
    /// <code>
    ///   BlueprintTool.AddGuidsByName(
    ///       new Dictionary&lt;string, string> { { "PowerAttackFeat", "9972f33f977fc724c838e59641b2fca5" } });
    ///   var conditionsChecker = ConditionsBuilder.New().CasterHasFact("PowerAttackFeat").Build();
    /// </code>
    /// </example>
    /// </remarks>
    public static void AddGuidsByName(Dictionary<string, string> guidsByName)
    {
      AddGuidsByName(guidsByName.Select(entry => (entry.Key, entry.Value)).ToArray());
    }

    /// <summary>Adds the provided mapping from Name to Guid.</summary>
    /// 
    /// <remarks>
    /// <para>
    /// After calling this function you can reference blueprints by Name in BlueprintCore APIs.
    /// </para>
    /// 
    /// <example>
    /// Add a mapping for the Power Attack feat and check to see if the caster has it in a
    /// <see cref="Conditions.Builder.ConditionsBuilder">ConditionsBuilder</see>:
    /// <code>
    ///   BlueprintTool.AddGuidsByName(("PowerAttackFeat", "9972f33f977fc724c838e59641b2fca5"));
    ///   var conditionsChecker = ConditionsBuilder.New().CasterHasFact("PowerAttackFeat").Build();
    /// </code>
    /// </example>
    /// </remarks>
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
                        + $" {entry.name} already maps to {guid}.\n");
                  }
                }

                Logger.Verbose($"Adding GuidByName: {entry.name} - {entry.guid}");
                guid = Guid.Parse(entry.guid.ToLower());
                GuidsByName.Add(entry.name, guid);
              });
    }

    /// <summary>Creates a new Blueprint of type T.</summary>
    /// 
    /// <remarks>
    /// The Name must be registered using <see cref="AddGuidsByName"/> before calling this. If you prefer
    /// using guid references directly use <see cref="Create{T}(string, string)"/> instead.
    /// </remarks>
    public static T Create<T>(string name) where T : SimpleBlueprint, new()
    {
      return Create<T>(name, GuidsByName[name]);
    }

    /// <summary>Creates a new Blueprint of type T with the given Name and Guid.</summary>
    /// 
    /// <remarks>
    /// If you have already registered the Name and Guid using <see cref="AddGuidsByName"/> you can use
    /// <see cref="Create{T}(string)"/> instead. If you have not this will register the name and associate it with the
    /// Guid.
    /// </remarks>
    public static T Create<T>(string name, string guid) where T : SimpleBlueprint, new()
    {
      AddGuidsByName((name, guid.ToString()));
      return Create<T>(name, Guid.Parse(guid.ToLower()));
    }

    private static T Create<T>(string name, Guid assetId) where T : SimpleBlueprint, new()
    {
      var guid = new BlueprintGuid(assetId);
      var existingAsset = ResourcesLibrary.TryGetBlueprint(guid);
      if (existingAsset != null)
      {
        throw new InvalidOperationException(
            $"Blueprint creation failed: {name} - {assetId}.\nAlready in use by: {existingAsset.name}.");
      }

      T asset = new()
      {
        name = name,
        AssetGuid = new BlueprintGuid(assetId)
      };
      ResourcesLibrary.BlueprintsCache.AddCachedBlueprint(guid, asset);
      return asset;
    }

    /// <summary>Returns the blueprint with the specified Name or Guid.</summary>
    /// 
    /// <param name="nameOrGuid">Use Name if you have registered it using <see cref="AddGuidsByName"/> or Guid otherwise.</param>
    public static T Get<T>(string nameOrGuid) where T : SimpleBlueprint
    {
      if (!GuidsByName.TryGetValue(nameOrGuid, out Guid assetId)) { assetId = Guid.Parse(nameOrGuid.ToLower()); }

      SimpleBlueprint asset = ResourcesLibrary.TryGetBlueprint(new BlueprintGuid(assetId));
      if (asset is T result) { return result; }
      else
      {
        throw new InvalidOperationException(
            $"Failed to fetch blueprint: {nameOrGuid} - {assetId}.\nIs the type correct? {typeof(T)}");
      }
    }

    /// <summary>Returns a blueprint reference for the specified Name or Guid</summary>
    /// 
    /// <remarks>
    /// This is based on <see cref="BlueprintReferenceBase.CreateTyped{TRef}(SimpleBlueprint)"/> but does not require
    /// fetching the blueprint. This allows referencing a blueprint that has not been created yet. However, if that
    /// blueprint is not created before the reference is used it may fail in unpredictable ways.
    /// </remarks>
    /// 
    /// <param name="nameOrGuid">Use Name if you have registered it using <see cref="AddGuidsByName"/> or Guid otherwise.</param>
    /// <returns>A blueprint reference of type T. If nameOrGuid it returns a non-null, empty reference.</returns>
    public static TRef GetRef<TRef>(string? nameOrGuid) where TRef : BlueprintReferenceBase
    {
      if (string.IsNullOrEmpty(nameOrGuid)) { return GetRef<TRef>(BlueprintGuid.Empty); }

      if (!GuidsByName.TryGetValue(nameOrGuid!, out Guid assetId)) { assetId = Guid.Parse(nameOrGuid!.ToLower()); }

      return GetRef<TRef>(new BlueprintGuid(assetId));
    }

    internal static TRef GetRef<TRef>(BlueprintGuid guid) where TRef : BlueprintReferenceBase
    {
      // Copied from BlueprintReferenceBase to allow creating a reference w/o fetching a blueprint.This allows
      // referencing a blueprint before it is added to the cache.
      var reference = Activator.CreateInstance<TRef>();
      reference.deserializedGuid = guid;
      return reference;
    }
  }

  /// <summary>
  /// Wrapper for easy referencing of blueprints.
  /// </summary>
  /// 
  /// <remarks>
  /// Provides implicit constructors mapping different types to a blueprint. This is used in the library to provide
  /// flexibility when passing in blueprint as method parameters.
  /// </remarks>
  public class Blueprint<TRef> where TRef : BlueprintReferenceBase
  {
    public readonly TRef Reference;

    private Blueprint(TRef blueprintReference)
    {
      Reference = blueprintReference;
    }

    public Blueprint<T> Cast<T>() where T : BlueprintReferenceBase
    {
      return new Blueprint<T>(BlueprintTool.GetRef<T>(Reference.deserializedGuid));
    }

    public static implicit operator Blueprint<TRef>(SimpleBlueprint blueprint)
    {
      return new Blueprint<TRef>(BlueprintTool.GetRef<TRef>(blueprint.AssetGuid));
    }

    public static implicit operator Blueprint<TRef>(TRef blueprintReference)
    {
      return new Blueprint<TRef>(blueprintReference);
    }

    public static implicit operator Blueprint<TRef>(string nameOrGuid)
    {
      return new Blueprint<TRef>(BlueprintTool.GetRef<TRef>(nameOrGuid));
    }

    public static implicit operator Blueprint<TRef>(Guid guid)
    {
      return new Blueprint<TRef>(BlueprintTool.GetRef<TRef>(guid.ToString()));
    }

    public static implicit operator Blueprint<TRef>(BlueprintGuid guid)
    {
      return new Blueprint<TRef>(BlueprintTool.GetRef<TRef>(guid.ToString()));
    }

    public override string ToString()
    {
      return Reference.deserializedGuid.ToString();
    }
  }
}