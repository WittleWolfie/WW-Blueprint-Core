using BlueprintCore.Actions.Patches;
using BlueprintCore.Utils;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Mechanics;

namespace BlueprintCore.Actions.New
{
  /**
   * Updates the context target to the target of a Demoralize action. Should only be used after
   * a successful IsDemoralizeAction check. This is useful because triggering on Demoralize relies
   * on the skill check but the skill check caster and target is the character using Demoralize.
   */
  public class SwitchToDemoralizeTarget : GameAction
  {
    private readonly static LogWrapper Logger = LogWrapper.GetInternal("SwitchToDemoralizeTarget");

    public override string GetCaption()
    {
      return "Switch to demoralize target action";
    }

    public override void RunAction()
    {
      Logger.Verbose(
          "Switching from"
          + $" {ContextData<MechanicsContext.Data>.Current.CurrentTarget.Unit.CharacterName}"
          + $" to {DemoralizePatch.DemoralizeTarget.Unit.CharacterName}");
      ContextData<MechanicsContext.Data>.Current.CurrentTarget = DemoralizePatch.DemoralizeTarget;
    }
  }
}