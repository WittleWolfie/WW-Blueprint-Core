using System;
using System.Collections.Generic;
using System.Linq;
using BlueprintCore.Blueprints;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;

namespace BlueprintCore.Tests
{
  public static class BlueprintPatch
  {
    private static readonly Dictionary<BlueprintGuid, SimpleBlueprint> Blueprints = new();
    public static bool Enabled = true;

    public static void Add(params SimpleBlueprint[] blueprint)
    {
      blueprint.ToList().ForEach(blueprint => Blueprints.Add(blueprint.AssetGuid, blueprint));
    }

    public static T Create<T>(string assetId) where T : SimpleBlueprint, new()
    {
      var blueprint = Util.Create<T>(assetId);
      Add(blueprint);
      return blueprint;
    }

    public static void Clear()
    {
      Blueprints.Clear();
      AccessTools
          .StaticFieldRefAccess<Dictionary<string, Guid>>(typeof(BlueprintTool), "GuidsByName")
          .Clear();
    }

    [HarmonyPatch(typeof(BlueprintsCache), "Load")]
    static class BlueprintsCache_Load_Patch
    {
      [HarmonyPriority(Priority.First)]
      static bool Prefix(BlueprintGuid guid, ref SimpleBlueprint __result)
      {
        if (!Blueprints.ContainsKey(guid)) { __result = null; }
        else { __result = Blueprints[guid]; }
        return false;
      }
    }

    [HarmonyPatch(typeof(BlueprintsCache), "AddCachedBlueprint")]
    static class BlueprintsCache_AddCachedBlueprint_Patch
    {
      [HarmonyPriority(Priority.First)]
      static bool Prefix(BlueprintGuid guid, SimpleBlueprint bp)
      {
        Blueprints[guid] = bp;
        return false;
      }
    }
  }
}