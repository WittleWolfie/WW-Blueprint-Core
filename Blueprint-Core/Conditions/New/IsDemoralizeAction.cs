using BlueprintCore.Actions.Patches;
using BlueprintCore.Utils;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic;

namespace BlueprintCore.Conditions.New
{
  /**
   * Validates whether the game is currently resolving a Demoralize action. Returns false if the
   * target is immune.
   */
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