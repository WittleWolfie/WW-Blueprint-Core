using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.Utility;
using Owlcat.QA.Validation;
using System.Collections.Generic;
using System.Linq;
using Kingmaker.Blueprints.TurnBasedModifiers;
using Kingmaker.UnitLogic.Class.Kineticist;

namespace BlueprintCore.BlueprintCore.Validation
{
  /// <summary>
  /// Validates blueprint objects
  /// </summary>
  internal class BlueprintValidator
  {
    public static void Check(BlueprintScriptableObject blueprint, ValidationContext context)
    {
      if (blueprint is BlueprintAbility ability)
      {
        Check(ability, context);
      }
    }

    /// <summary>
    /// Validates there is only a single instance of the specified component type.
    /// </summary>
    private static void CheckSingleComponent<T>(BlueprintScriptableObject blueprint, ValidationContext context)
      where T : BlueprintComponent
    {
      if (blueprint.GetComponents<T>().Count() > 1)
      {
        context.AddError("Multiple {0} components present. Only the first is used.", typeof(T).Name);
      }
    }

    private static readonly Feet ZeroFeet = new(0);
    private static void Check(BlueprintAbility ability, ValidationContext context)
    {
      if (ability.CustomRange > ZeroFeet && !ability.IsRangeCustom)
      {
        context.AddError("A custom range value is set without AbilityRange.Custom. It will be ignored.");
      }

      CheckSingleComponent<SpellComponent>(ability, context);
      CheckSingleComponent<AbilityIsFullRoundInTurnBased>(ability, context);
      CheckSingleComponent<AbilityEffectStickyTouch>(ability, context);
      CheckSingleComponent<AbilityVariants>(ability, context);
      CheckSingleComponent<AbilityShadowSpell>(ability, context);
      CheckSingleComponent<AbilityKineticist>(ability, context);
      CheckSingleComponent<CantripComponent>(ability, context);
      CheckSingleComponent<SpellDescriptorComponent>(ability, context);

      // Ability effect logic

      CheckSingleComponent<AbilityDeliverEffect>(ability, context);
      CheckSingleComponent<AbilityTargetsAroundOnGrid>(ability, context);
      CheckSingleComponent<AbilityAffectLineOnGrid>(ability, context);
      CheckSingleComponent<AbilityTargetsAround>(ability, context);
      CheckSingleComponent<AbilityEffectRunActionOnClickedTarget>(ability, context);
      CheckSingleComponent<AbilityEffectMiss>(ability, context);

      if (ability.GetComponent<AbilityTargetsAroundOnGrid>() != null
        && ability.GetComponent<AbilityAffectLineOnGrid>() != null)
      {
        context.AddError(
          "AbilityTargetsAroundOnGrid and AbilityAffectLineOnGrid present. AbilityAffectLineOnGrid is ignored.");
      }

      List<AbilityApplyEffect> applyEffects = ability.GetComponents<AbilityApplyEffect>().ToList();
      if (applyEffects.Count > 0)
      {
        if (applyEffects[0] is AbilityEffectMiss)
        {
          context.AddError("AbilityEffectMiss is the first AbilityApplyEffect. It will always trigger.");
        }

        if ((applyEffects.Count == 2 && applyEffects[1] is not AbilityEffectMiss) || applyEffects.Count > 2)
        {
          context.AddError("Too many AbilityApplyEffect components. Only {0} applies.", applyEffects[0]);
        }
      }

      if (ability.GetComponent<AbilityEffectMiss>() is not null)
      {
        var deliverEffect = ability.GetComponent<AbilityDeliverEffect>();
        if (deliverEffect is null)
        {
          context.AddError(
            "AbilityEffectMiss requires an AbilityDeliverEffect. " +
            "Use AbilityDeliveredbyWeapon, " +
            "AbilityDeliverClashingRocks, " +
            "AbilityDeliverProjectile, " +
            "or AbilityDeliverTouch");
        }
        else if (deliverEffect is not AbilityDeliveredByWeapon
          && deliverEffect is not AbilityDeliverClashingRocks
          && deliverEffect is not AbilityDeliverProjectile
          && deliverEffect is not AbilityDeliverTouch)
        {
          context.AddError(
            "AbilityEffectMiss is not compatible with {0}. " +
            "Use AbilityDeliveredbyWeapon, " +
            "AbilityDeliverClashingRocks, " +
            "AbilityDeliverProjectile, " +
            "or AbilityDeliverTouch", deliverEffect);
        }
      }
    }
  }
}
