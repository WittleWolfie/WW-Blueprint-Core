using BlueprintCore.Utils;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Test.Patches
{
  public static class BlueprintPatch
  {
    private static Dictionary<BlueprintGuid, SimpleBlueprint> BlueprintCache;
    public static bool Enabled = true;

    public static void Init()
    {
      BlueprintCache = new();
      AccessTools.StaticFieldRefAccess<Dictionary<string, Guid>>(typeof(BlueprintTool), "GuidsByName") = new();
    }

    public static void Add(params SimpleBlueprint[] blueprint)
    {
      blueprint.ToList().ForEach(blueprint => BlueprintCache.Add(blueprint.AssetGuid, blueprint));
    }

    public static T Create<T>(string assetId) where T : SimpleBlueprint, new()
    {
      var blueprint = Util.Create<T>(assetId);
      Add(blueprint);
      return blueprint;
    }

    [HarmonyPatch(typeof(BlueprintsCache))]
    static class BlueprintsCache_Patch
    {
      [HarmonyPriority(Priority.First)]
      [HarmonyPatch(nameof(BlueprintsCache.Load)), HarmonyPrefix]
      static bool Prefix(BlueprintGuid guid, ref SimpleBlueprint __result)
      {
        if (!BlueprintCache.ContainsKey(guid)) { __result = null; }
        else { __result = BlueprintCache[guid]; }
        return false;
      }

      [HarmonyPriority(Priority.First)]
      [HarmonyPatch(nameof(BlueprintsCache.AddCachedBlueprint)), HarmonyPrefix]
      static bool Prefix(BlueprintGuid guid, SimpleBlueprint bp)
      {
        BlueprintCache[guid] = bp;
        return false;
      }
    }
  }
}