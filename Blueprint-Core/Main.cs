using System;
using HarmonyLib;
using UnityModManagerNet;

namespace BlueprintCore
{
  public static class Main
  {
    /**
     * Returns the current version of the mod. You can check this to determine if specific feature
     * support is available.
     */
    public static Version Version { get; private set; }

    static bool Load(UnityModManager.ModEntry modEntry)
    {
      Version = modEntry.Version;
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
