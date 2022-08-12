using BlueprintCore.Utils;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic.Mechanics;

namespace BlueprintCore.Conditions.New
{
  /// <summary>
  /// Checks if the caster has the specified actions available.
  /// </summary>
  [TypeId("3299aa43-95f5-4d1d-a504-668a83b06ed3")]
  public class HasActionsAvailable : Condition
  {
    private static readonly LogWrapper Logger = LogWrapper.GetInternal("HasActionsAvailable");

    public bool RequireSwift = false;
    public bool RequireMove = false;
    public bool RequireStandard = false;
    public bool RequireFullRound = false;

    public override bool CheckCondition()
    {
      UnitEntityData caster = ContextData<MechanicsContext.Data>.Current.Context.MaybeCaster;
      if (caster == null)
      {
        Logger.Warn("No caster");
        return false;
      }

      if (RequireSwift && !caster.HasSwiftAction())
      {
        Logger.Verbose($"Swift action unavailable.");
        return false;
      }

      if (RequireMove && !caster.HasMoveAction())
      {
        Logger.Verbose($"Move action unavailable.");
        return false;
      }

      if (RequireStandard && !caster.HasStandardAction())
      {
        Logger.Verbose($"Standard action unavailable.");
        return false;
      }

      if (RequireFullRound && !caster.HasFullRoundAction())
      {
        Logger.Verbose($"Full round action unavailable.");
        return false;
      }

      return true;
    }

    public override string GetConditionCaption()
    {
      return "Caster has specified actions available";
    }
  }
}
