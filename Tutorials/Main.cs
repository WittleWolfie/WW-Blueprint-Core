using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using UnityModManagerNet;

namespace Tutorials
{
  public static class Main
  {
    public static bool Enabled;

    public static bool Load(UnityModManager.ModEntry modEntry)
    {
      modEntry.OnToggle = OnToggle;
      return true;
    }

    public static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
    {
      Enabled = value;
      return true;
    }

    [HarmonyPatch(typeof(BlueprintsCache), "Init")]
    public static class BlueprintsCache_Init_Patch
    {
      public static void PostFix()
      {

      }
    }
  }
}
