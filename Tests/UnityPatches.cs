using HarmonyLib;
using Kingmaker.Blueprints.Validation;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
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

    [HarmonyPatch(typeof(ValidationContext), "ValidateFieldAttributes")]
    static class ValidationContext_ValidateFieldAttributes_Patch
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
  }
}