using BlueprintCore.Utils;
using HarmonyLib;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Utility;

namespace BlueprintCore.Actions.Patches
{
  /** Tracks the use of Demoralize to distinguish from other uses of Initimidate skill checks. */
  public static class DemoralizePatch
  {
    private readonly static LogWrapper Logger = LogWrapper.Get("DemoralizePatch");

    /** Returns whether the  game is processing a Demoralize action. */
    public static bool DemoralizeActive { get; private set; }

    /**
     * Returns the target of the active Demoralize action, which differs from the intimidate skill
     * check target.
     */
    public static TargetWrapper DemoralizeTarget { get; private set; }

    [HarmonyPatch(typeof(Demoralize), "RunAction")]
    static class Demoralize_RunAction_Patch
    {
      [HarmonyPriority(Priority.First)]
      static void Prefix(Demoralize __instance)
      {
        Logger.Verbose(
            $"Demoralize triggered targeting {__instance.Context.MainTarget.Unit.CharacterName}");
        DemoralizeActive = true;
        DemoralizeTarget = __instance.Context.MainTarget;
      }

      [HarmonyPriority(Priority.First)]
      static void Postfix()
      {
        DemoralizeActive = false;
        DemoralizeTarget = null;
      }
    }
  }
}