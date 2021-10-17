using BlueprintCore.Actions.Patches;
using BlueprintCore.Utils;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;

namespace BlueprintCore.Actions.New
{
  /// <summary>
  /// Updates the current context target to match the target of the last Demoralize action.
  /// </summary>
  ///
  /// <remarks>
  /// This is useful as part of an
  /// <see cref="Kingmaker.UnitLogic.Mechanics.Components.AddInitiatorSkillRollTrigger">AddInitiatorSkillRollTrigger</see>
  /// with <see cref="Kingmaker.EntitySystem.Stats.StatType.CheckIntimidate">StatType.CheckIntimidate</see> and
  /// <see cref="Conditions.New.IsDemoralizeAction">IsDemoralizeAction</see> to apply additional effects
  /// to the Demoralize target. If this not used then the context target will be the character using Demoralize.
  /// </remarks>
  public class SwitchToDemoralizeTarget : ContextAction
  {
    private readonly static LogWrapper Logger = LogWrapper.GetInternal("SwitchToDemoralizeTarget");

    public override string GetCaption()
    {
      return "Switch to demoralize target action";
    }

    public override void RunAction()
    {
      Logger.Verbose(
          "Switching from {Target.Unit.CharacterName} to {DemoralizePatch.DemoralizeTarget.Unit.CharacterName}");
      ContextData<MechanicsContext.Data>.Current.CurrentTarget = DemoralizePatch.DemoralizeTarget;
    }
  }
}