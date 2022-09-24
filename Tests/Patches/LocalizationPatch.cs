using BlueprintCore.Utils;
using BlueprintCore.Utils.Localization;
using HarmonyLib;
using Kingmaker.Localization;

namespace BlueprintCore.Test.Patches
{
  public static class LocalizationPatch
  {
    [HarmonyPatch(typeof(LocalizationTool))]
    static class LocalizationTool_Patch
    {
      [HarmonyPriority(Priority.First)]
      [HarmonyPatch(nameof(LocalizationTool.LoadLocalizationPack)), HarmonyPrefix]

      static bool LoadLocalizationPack()
      {
        AccessTools.StaticFieldRefAccess<LocalizationTool, MultiLocalizationPack>("localizationPack") = new();
        return false;
      }

      [HarmonyPriority(Priority.First)]
      [HarmonyPatch(nameof(LocalizationTool.CreateString)), HarmonyPrefix]

      static bool CreateString(string key, ref LocalizedString __result)
      {
        __result = new LocalizedString() { m_Key = key };
        return false;
      }
    }
  }
}
