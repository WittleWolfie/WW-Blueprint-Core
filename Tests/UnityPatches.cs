using HarmonyLib;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.DLC;
using UnityEngine;

namespace BlueprintCore.Test
{
  /** Patches calls which require Unity Engine and cannot be called in unit tests. */
  public static class UnityPatches
  {
    [HarmonyPatch(typeof(ContextActionAddRandomTrashItem), "Validate")]
    static class ContextActionAddRandomTrashItem_Validate_Patch
    {
      [HarmonyPriority(Priority.First)]
      static bool Prefix() { return false; }
    }

    [HarmonyPatch(typeof(AnimationCurve), "Linear")]
    static class AnimationCurve_Linear_Patch
    {
      [HarmonyPriority(Priority.First)]
      static bool Prefix() { return false; }
    }

    [HarmonyPatch(typeof(DlcCondition), "ApplyValidation")]
    static class DlcCondition_ApplyValidation_Patch
    {
      [HarmonyPriority(Priority.First)]
      static bool Prefix() { return false; }
    }
  }
}