using BlueprintCore.Utils;
using HarmonyLib;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Utility;

namespace BlueprintCore.Actions.Patches
{
  /// <summary>
  /// Patch for <see cref="Demoralize"/> used by <see cref="Conditions.New.IsDemoralizeAction">IsDemoralizeAction</see>
  /// and <see cref="New.SwitchToDemoralizeTarget">SwitchToDemoralizeTarget</see>.
  /// </summary>
  public static class DemoralizePatch
  {
    private readonly static LogWrapper Logger = LogWrapper.GetInternal("DemoralizePatch");

    /// <summary>
    /// Returns whether a <see cref="Demoralize"/> action is currently executing.
    /// </summary>
    public static bool DemoralizeActive { get; private set; }

    /// <summary>
    /// Returns the target of the <see cref="Demoralize"/> action while it is executing.
    /// </summary>
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