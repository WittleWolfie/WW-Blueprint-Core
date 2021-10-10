using System.Collections.Generic;
using System.Linq;
using BlueprintCore.Utils;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;

namespace BlueprintCore.Tests
{
  public static class BlueprintPatch
  {
    private static readonly Dictionary<BlueprintGuid, SimpleBlueprint> Blueprints = new();

    public static void Add(params SimpleBlueprint[] blueprint)
    {
      blueprint.ToList().ForEach(blueprint => Blueprints.Add(blueprint.AssetGuid, blueprint));
    }

    public static void Clear()
    {
      Blueprints.Clear();
    }

    [HarmonyPatch(typeof(BlueprintsCache), "Load")]
    static class BlueprintsCache_Load_Patch
    {
      [HarmonyPriority(Priority.First)]
      static bool Prefix(BlueprintGuid guid, ref SimpleBlueprint __result)
      {
        __result = Blueprints[guid];
        return false;
      }
    }

    [HarmonyPatch(typeof(Guids), "Get")]
    static class Guids_Get_Patch
    {
      [HarmonyPriority(Priority.First)]
      static bool Prefix(string name, ref string __result)
      {
        __result = name;
        return false;
      }
    }
  }
}