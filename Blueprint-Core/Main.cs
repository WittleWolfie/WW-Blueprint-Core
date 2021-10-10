using HarmonyLib;
using UnityModManagerNet;

namespace BlueprintCore
{
  static class Main
  {
    static bool Load(UnityModManager.ModEntry modEntry)
    {
      var harmony = new Harmony(modEntry.Info.Id);
      harmony.PatchAll();
      return true;
    }

    static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
    {
      return true;
    }
  }
}
