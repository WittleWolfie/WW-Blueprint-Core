using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.BundlesLoading;
using Kingmaker.ResourceLinks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace BlueprintCore.Utils.Assets
{
  public class AssetTool
  {
    private static readonly LogWrapper Logger = LogWrapper.GetInternal(nameof(AssetTool));
    private static readonly string AssemblyName = Assembly.GetAssembly(typeof(AssetTool)).GetName().Name.ToLower();
    private static readonly string BundleName =
      Path.Combine(Path.GetDirectoryName(Assembly.GetAssembly(typeof(AssetTool)).Location), $"{AssemblyName}_assets");

    private static readonly HashSet<string> AllAssetIds = new();

    private static readonly Dictionary<string, (PrefabLink source, Action<GameObject> init)> DynamicPrefabLinks =
      new();
    /// <summary>
    /// Registers <paramref name="assetId"/> as an asset. When the asset is requested for load,
    /// <paramref name="source"/> is loaded and copied, <paramref name="init"/> is called on the copy, and the copy is
    /// returned.
    /// </summary>
    /// 
    /// <remarks>
    /// Use this to create a new asset based on a base game asset dynamically. You configure the <c>GameObject</c> in
    /// <paramref name="init"/> and it will be used whenever an asset with <paramref name="assetId"/> is requested.
    /// 
    /// <example>
    /// <code>
    /// var assetId = "0a2f44a9-0650-452f-8ff6-24fd4e61c7ef"; // New GUID identifying your prefab
    /// var sourceAssetId = "fd21d914e9f6f5e4faa77365549ad0a7"; // A 20-ft ground ice effect from the base game
    /// 
    /// // When assetId is requested: load sourceAssetId, copy it, then set its scale to 50%
    /// RegisterDynamicPrefabLink(assetId, sourceAssetId, prefab => prefab.transform.localScale = new(0.5f, 0.5f));
    /// 
    /// // Creates an AOE using the new asset
    /// AbilityAreaEffectConfigurator.New(AreaEffectName, AreaEffectGuid).SetFx(assetId).Configure();
    /// </code>
    /// </example>
    /// </remarks>
    /// <param name="assetId">Unique identifier used to load the asset</param>
    /// <param name="source">The base game prefab copied to create your prefab.</param>
    /// <param name="init">Function called passing in a copy of the source prefab. Use this to configure your prefab.</param>
    /// <exception cref="ArgumentException">If <paramref name="assetId"/> is already in use</exception>
    public static void RegisterDynamicPrefabLink(string assetId, AssetLink<PrefabLink> source, Action<GameObject> init)
    {
      if (DynamicPrefabLinks.ContainsKey(assetId) || AllAssetIds.Contains(assetId))
        throw new ArgumentException($"{assetId} is already in use!");

      DynamicPrefabLinks[assetId] = (source.Get(), init);
      AllAssetIds.Add(assetId);
    }

    private static readonly Dictionary<string, (GameObject source, Action<GameObject> init)> DynamicPrefabs = new();
    /// <summary>
    /// Registers <paramref name="assetId"/> as an asset. When the asset is requested for load,
    /// <paramref name="source"/> is loaded and copied, <paramref name="init"/> is called on the copy, and the copy is
    /// returned.
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    /// This is equivalent to <see cref="RegisterDynamicPrefabLink(string, AssetLink{PrefabLink}, Action{GameObject})"/>,
    /// but for prefabs that are already loaded, e.g. <c>BlueprintProjectile.StuckArrowPrefab</c>.
    /// </para>
    /// 
    /// <para>
    /// You must call this <b>before</b> you reference <paramref name="assetId"/>.
    /// </para>
    /// 
    /// <example>
    /// <code>
    /// var assetId = "0a2f44a9-0650-452f-8ff6-24fd4e61c7ef"; // New GUID identifying your prefab
    /// var sourceAsset = ProjectileRefs.Arrow.Reference.Get().StuckArrowPrefab;
    /// 
    /// // When assetId is requested: load sourceAsset, copy it, then set its scale to 150%
    /// RegisterDynamicPrefab(assetId, sourceAsset, prefab => prefab.transform.localScale = new(1.5f, 1.5f));
    /// 
    /// // Creates an AOE using the new asset
    /// ProjectilConfigurator.New(ProjectileName, ProjectileGuid).SetStuckArrowPrefab(assetId).Configure();
    /// </code>
    /// </example>
    /// </remarks>
    /// <param name="assetId">Unique identifier used to load the asset</param>
    /// <param name="source">The base game prefab copied to create your prefab.</param>
    /// <param name="init">Function called passing in a copy of the source prefab. Use this to configure your prefab.</param>
    /// <exception cref="ArgumentException">If <paramref name="assetId"/> is already in use</exception>
    public static void RegisterDynamicPrefab(string assetId, Asset<GameObject> source, Action<GameObject> init)
    {
      if (DynamicPrefabs.ContainsKey(assetId) || AllAssetIds.Contains(assetId))
        throw new ArgumentException($"{assetId} is already in use!");

      DynamicPrefabs[assetId] = (source.Get(), init);
      AllAssetIds.Add(assetId);
    }

    private static readonly HashSet<string> AssetIds = new();
    private static void LoadAssets(string assetFile)
    {
      if (!File.Exists(assetFile))
      {
        Logger.Warn($"No asset bundle found at {assetFile}");
        return;
      }

      var bundle = BundlesLoadService.Instance.RequestBundle(assetFile);
      foreach (var assetId in bundle.GetAllAssetNames())
      {
        AllAssetIds.Add(assetId);
        if (!AssetIds.Add(assetId))
        {
          Logger.Warn($"Duplicate asset found: {assetId}");
        }
        else
        {
          Logger.Verbose($"Loaded asset: {assetId}");
        }
      }
    }

    [HarmonyPatch(typeof(ResourcesLibrary))]
    static class ResourcesLibrary_Patch
    {
      [HarmonyPatch(nameof(ResourcesLibrary.LoadResource)), HarmonyPrefix]
      static bool Prefix(string assetId, ResourcesLibrary.LoadedResource loaded)
      {
        try
        {
          if (DynamicPrefabLinks.ContainsKey(assetId))
          {
            (var source, var init) = DynamicPrefabLinks[assetId];
            Create(source.Loaded ?? ResourcesLibrary.TryGetResource<GameObject>(source.AssetId), init);
            loaded.AssetId = assetId;
            return false;
          }

          if (DynamicPrefabs.ContainsKey(assetId))
          {
            (var source, var init) = DynamicPrefabs[assetId];
            Create(source, init);
            loaded.AssetId = assetId;
            return false;
          }
        }
        catch (Exception e)
        {
          Logger.Error($"Failed to load dynamic prefab: {assetId}.", e);
        }
        return true;
      }

      private static void Create(GameObject sourceObject, Action<GameObject> init)
      {
        var copyObj = UnityEngine.Object.Instantiate(sourceObject);
        UnityEngine.Object.DontDestroyOnLoad(copyObj);
        init(copyObj);
      }
    }

    [HarmonyPatch(typeof(BundlesLoadService))]
    static class BundlesLoadService_Patch
    {
      [HarmonyPatch(nameof(BundlesLoadService.GetBundleNameForAsset)), HarmonyPrefix]
      static bool Prefix(string assetId, ref string __result)
      {
        try
        {
          if (AssetIds.Contains(assetId))
          {
            __result = BundleName;
            return false;
          }
        }
        catch (Exception e)
        {
          Logger.Error($"Failed to fetch bundle name for {assetId}.", e);
        }
        return true;
      }
    }

    [HarmonyPatch(typeof(BlueprintsCache))]
    static class BlueprintsCaches_Patch
    {
      private static bool Initialized = false;

      [HarmonyPriority(Priority.First)]
      [HarmonyPatch(nameof(BlueprintsCache.Init)), HarmonyPrefix]
      static void Prefix()
      {
        try
        {
          if (Initialized)
          {
            Logger.Info("Already initialized assets.");
            return;
          }
          Initialized = true;

          LoadAssets(BundleName);
        }
        catch (Exception e)
        {
          Logger.Error("Failed to load assets.", e);
        }
      }
    }
  }

  /// <summary>
  /// Wrapper for flexible reference of WeakResourceLink types.
  /// </summary>
  public class AssetLink<TLink> where TLink : WeakResourceLink, new()
  {
    private readonly TLink Link;

    private AssetLink(string assetId)
    {
      Link = new() { AssetId = assetId };
    }

    private AssetLink(TLink link)
    {
      Link = link;
    }

    public TLink Get()
    {
      return Link;
    }

    public static implicit operator AssetLink<TLink>(TLink link)
    {
      return new(link);
    }

    public static implicit operator AssetLink<TLink>(string assetId)
    {
      return new(assetId);
    }
  }

  /// <summary>
  /// Wrapper for flexible reference of asset types.
  /// </summary>
  public class Asset<T> where T : UnityEngine.Object
  {
    private readonly T? Value;
    private readonly string AssetId;

    private Asset(string assetId)
    {
      AssetId = assetId;
      Value = ResourcesLibrary.TryGetResource<T>(assetId);
    }

    private Asset(T asset)
    {
      AssetId = asset.name;
      Value = asset;
    }

    public T Get()
    {
      if (Value is null)
      {
        throw new InvalidOperationException($"Unable to fetch asset w/ ID {AssetId}");
      }
      return Value;
    }

    public static implicit operator Asset<T>(T asset)
    {
      return asset is null ? null : new(asset);
    }

    public static implicit operator Asset<T>(string assetId)
    {
      return new(assetId);
    }
  }
}
