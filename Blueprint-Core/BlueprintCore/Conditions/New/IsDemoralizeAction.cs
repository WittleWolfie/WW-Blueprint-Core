using BlueprintCore.Actions.Patches;
using BlueprintCore.Utils;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic;

namespace BlueprintCore.Conditions.New
{
  /// <summary>
  /// Checks to determine if a <see cref="Kingmaker.UnitLogic.Mechanics.Actions.Demoralize">Demoralize</see> is being
  /// executed.
  /// </summary>
  /// 
  /// <remarks>
  /// <para>
  /// There is no explicit trigger for demoralize. To trigger behavior when demoralize is used, use
  /// <see cref="Kingmaker.UnitLogic.Mechanics.Components.AddInitiatorSkillRollTrigger">AddInitiatorSkillRollTrigger</see>
  /// with <see cref="Kingmaker.EntitySystem.Stats.StatType.CheckIntimidate">StatType.CheckIntimidate</see> and this
  /// condition.
  /// </para>
  /// 
  /// <para>
  /// Note that this will return false if the target is immune to <see cref="UnitCondition.Shaken"/>, implying immunity
  /// to demoralize. However, shaken is implemented as both a <see cref="UnitCondition"/> and as a
  /// <see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/>, so it's possible the target is immune to the
  /// buff and thus immune to demoralize.
  /// </para>
  /// 
  /// <para>
  /// This may be deprecated in the future if a better patch for
  /// <see cref="Kingmaker.UnitLogic.Mechanics.Actions.Demoralize">Demoralize</see> can expose a cleaner trigger API.
  /// </para>
  /// </remarks>
  public class IsDemoralizeAction : Condition
  {
    private static readonly LogWrapper Logger = LogWrapper.GetInternal("IsDemoralizeAction");

    public override string GetConditionCaption()
    {
      return "Demoralize condition";
    }

    public override bool CheckCondition()
    {
      // Units immune to shaken cannot be demoralized. The target may still be immune because of
      // spell descriptors; this should not be taken as a guarantee the target is affected.
      var result =
          DemoralizePatch.DemoralizeActive
          && !DemoralizePatch.DemoralizeTarget.Unit.State.HasConditionImmunity(
              UnitCondition.Shaken);

      if (!result)
      {
        Logger.Verbose("Intimidate check was not for demoralize");
      }
      return result;
    }
  }
}