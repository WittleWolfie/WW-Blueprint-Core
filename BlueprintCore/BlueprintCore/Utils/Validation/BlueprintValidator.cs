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
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using System;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Properties;

namespace BlueprintCore.Utils.Validation
{
  /// <summary>
  /// Validates blueprint objects
  /// </summary>
  internal class BlueprintValidator
  {
    public static void Check(BlueprintScriptableObject blueprint, ValidationContext context)
    {
      CheckComponents(blueprint, context);

      if (blueprint is BlueprintAbility ability)
      {
        Check(ability, context);
      }
      else if (blueprint is BlueprintBuff buff)
      {
        Check(buff, context);
      }
      else if (blueprint is BlueprintFeature feature)
      {
        Check(feature, context);
      }
    }

    private static HashSet<Type> AllowMultipleComponents = new() { typeof(RecalculateOnStatChange) };
    private static void CheckComponents(BlueprintScriptableObject blueprint, ValidationContext context)
    {
      HashSet<Type> componentTypes = new();
      foreach (var component in blueprint.Components)
      {
        var componentType = component.GetType();
        var attrs = componentType.GetCustomAttributes(/* inherit= */ true);

        if (componentTypes.Contains(componentType)
          && !attrs.Where(attr => attr is AllowMultipleComponentsAttribute).Any()
          && !AllowMultipleComponents.Contains(componentType))
        {
          context.AddError("Multiple {0} present but only one is allowed.", component);
        }
        else
        {
          componentTypes.Add(componentType);
        }

        bool componentAllowed = false;
        var allowedOn = attrs.Where(attr => attr is AllowedOnAttribute).Cast<AllowedOnAttribute>().ToList();
        var blueprintType = blueprint.GetType();
        foreach (AllowedOnAttribute attr in allowedOn)
        {
          var allowedType = attr.Type;
          // Need .NET 5.0 for IsAssignableTo()
          if (blueprintType == allowedType || blueprintType.IsSubclassOf(allowedType))
          {
            componentAllowed = true;
            break;
          }
        }

        if (allowedOn.Count > 0 && !componentAllowed)
        {
          context.AddError("{0} not allowed on {1}", component, blueprintType.Name);
        }
      }

      // Make sure there are no conflicting ContextRankConfigs
      var duplicateRankTypes =
          blueprint.GetComponents<ContextRankConfig>()
              .Select(config => config.m_Type)
              .GroupBy(type => type)
              .Where(group => group.Count() > 1)
              .Select(group => group.Key);
      if (duplicateRankTypes.Any())
      {
        context.AddError(
            "Duplicate ContextRankConfig.m_Type values found, only one of each type is used: {0}",
            string.Join(",", duplicateRankTypes));
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
    /// <summary>
    /// Custom validation for BlueprintAbility.
    /// </summary>
    private static void Check(BlueprintAbility ability, ValidationContext context)
    {
      if (ability.CustomRange > ZeroFeet && !ability.IsRangeCustom)
      {
        context.AddError("A custom range value is set without AbilityRange.Custom. It is ignored.");
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
          context.AddError("AbilityEffectMiss is the first AbilityApplyEffect. It always triggers.");
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

    /// <summary>
    /// Custom validation for BlueprintBuff.
    /// </summary>
    private static void Check(BlueprintBuff buff, ValidationContext context)
    {
      CheckSingleComponent<SpellDescriptorComponent>(buff, context);

      if (!buff.HasRanks && buff.Ranks > 0)
      {
        context.AddError("Ranks are specified without StackingType.Rank. Ranks is ignored.");
      }
    }

    /// <summary>
    /// Custom validation for BlueprintFeature.
    /// </summary>
    private static void Check(BlueprintFeature feature, ValidationContext context)
    {
      CheckSingleComponent<FeatureTagsComponent>(feature, context);
    }

    /// <summary>
    /// Custom validation for BlueprintUnitProperty.
    /// </summary>
    private static void Check(BlueprintUnitProperty unitProperty, ValidationContext context)
    {
      if (unitProperty.BaseValue == 0
        && unitProperty.OperationOnComponents == BlueprintUnitProperty.MathOperation.Multiply)
      {
        context.AddError("BaseValue is 0 with MathOperation.Multiply. Resulting value will always be 0.");
      }

      if (unitProperty.GetComponent<PropertyValueGetter>() is null)
      {
        context.AddError(
          $"No properties specified. Resulting value will always be {unitProperty.BaseValue} (BaseValue).");
      }
    }
  }
}
