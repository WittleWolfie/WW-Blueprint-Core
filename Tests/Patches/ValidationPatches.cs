using BlueprintCore.Utils;
using HarmonyLib;

namespace BlueprintCore.Test.Patches
{
  public static class ValidationPatches
  {
    [HarmonyPatch(typeof(Validator))]
    static class Validator_Patch
    {
      [HarmonyPriority(Priority.First)]
      [HarmonyPatch(nameof(Validator.Check)), HarmonyPrefix]

      static bool Check()
      {
        return false;
      }
    }
  }
}
