﻿using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.BundlesLoading;
using Kingmaker.ResourceLinks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace BlueprintCore.Utils.Assets
{
  public class AssetTool
  {
    private static readonly LogWrapper Logger = LogWrapper.GetInternal("AssetLoader");

    private static readonly string BundleName =
      Path.Combine(Path.GetDirectoryName(Assembly.GetAssembly(typeof(AssetTool)).Location), "assets");

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
      return new(asset);
    }

    public static implicit operator Asset<T>(string assetId)
    {
      return new(assetId);
    }
  }
}