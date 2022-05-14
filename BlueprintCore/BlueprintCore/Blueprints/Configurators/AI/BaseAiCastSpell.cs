//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAiCastSpell"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAiCastSpellConfigurator<T, TBuilder>
    : BaseAiActionConfigurator<T, TBuilder>
    where T : BlueprintAiCastSpell
    where TBuilder : BaseAiCastSpellConfigurator<T, TBuilder>
  {
    protected BaseAiCastSpellConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiCastSpell.m_MinCasterSqrDistanceToLocator"/>
    /// </summary>
    public TBuilder SetMinCasterSqrDistanceToLocator(float minCasterSqrDistanceToLocator)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MinCasterSqrDistanceToLocator = minCasterSqrDistanceToLocator;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiCastSpell.m_MinCasterSqrDistanceToLocator"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMinCasterSqrDistanceToLocator(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_MinCasterSqrDistanceToLocator);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiCastSpell.m_MinPartySqrDistanceToLocator"/>
    /// </summary>
    public TBuilder SetMinPartySqrDistanceToLocator(float minPartySqrDistanceToLocator)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MinPartySqrDistanceToLocator = minPartySqrDistanceToLocator;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiCastSpell.m_MinPartySqrDistanceToLocator"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMinPartySqrDistanceToLocator(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_MinPartySqrDistanceToLocator);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiCastSpell.m_MaxPartySqrDistanceToLocator"/>
    /// </summary>
    public TBuilder SetMaxPartySqrDistanceToLocator(float maxPartySqrDistanceToLocator)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MaxPartySqrDistanceToLocator = maxPartySqrDistanceToLocator;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiCastSpell.m_MaxPartySqrDistanceToLocator"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMaxPartySqrDistanceToLocator(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_MaxPartySqrDistanceToLocator);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiCastSpell.m_AffectedByImpatience"/>
    /// </summary>
    public TBuilder SetAffectedByImpatience(bool affectedByImpatience = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AffectedByImpatience = affectedByImpatience;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiCastSpell.m_AffectedByImpatience"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAffectedByImpatience(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_AffectedByImpatience);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiCastSpell.m_Ability"/>
    /// </summary>
    ///
    /// <param name="ability">
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAbility(Blueprint<BlueprintAbility, BlueprintAbilityReference> ability)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Ability = ability?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiCastSpell.m_Ability"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="ability">
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyAbility(Action<BlueprintAbilityReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Ability is null) { return; }
          action.Invoke(bp.m_Ability);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiCastSpell.m_ForceTargetSelf"/>
    /// </summary>
    public TBuilder SetForceTargetSelf(bool forceTargetSelf = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ForceTargetSelf = forceTargetSelf;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiCastSpell.m_ForceTargetSelf"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyForceTargetSelf(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_ForceTargetSelf);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiCastSpell.m_ForceTargetEnemy"/>
    /// </summary>
    public TBuilder SetForceTargetEnemy(bool forceTargetEnemy = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ForceTargetEnemy = forceTargetEnemy;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiCastSpell.m_ForceTargetEnemy"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyForceTargetEnemy(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_ForceTargetEnemy);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiCastSpell.m_RandomVariant"/>
    /// </summary>
    public TBuilder SetRandomVariant(bool randomVariant = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_RandomVariant = randomVariant;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiCastSpell.m_RandomVariant"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRandomVariant(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_RandomVariant);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiCastSpell.m_Variant"/>
    /// </summary>
    ///
    /// <param name="variant">
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetVariant(Blueprint<BlueprintAbility, BlueprintAbilityReference> variant)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Variant = variant?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiCastSpell.m_Variant"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="variant">
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyVariant(Action<BlueprintAbilityReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Variant is null) { return; }
          action.Invoke(bp.m_Variant);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiCastSpell.m_VariantsSet"/>
    /// </summary>
    ///
    /// <param name="variantsSet">
    /// <para>
    /// InfoBox: In case of empty list, variant will be picked from all variants for specified ability
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetVariantsSet(List<Blueprint<BlueprintAbility, BlueprintAbilityReference>> variantsSet)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_VariantsSet = variantsSet?.Select(bp => bp.Reference)?.ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAiCastSpell.m_VariantsSet"/>
    /// </summary>
    ///
    /// <param name="variantsSet">
    /// <para>
    /// InfoBox: In case of empty list, variant will be picked from all variants for specified ability
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToVariantsSet(params Blueprint<BlueprintAbility, BlueprintAbilityReference>[] variantsSet)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_VariantsSet = bp.m_VariantsSet ?? new BlueprintAbilityReference[0];
          bp.m_VariantsSet = CommonTool.Append(bp.m_VariantsSet, variantsSet.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAiCastSpell.m_VariantsSet"/>
    /// </summary>
    ///
    /// <param name="variantsSet">
    /// <para>
    /// InfoBox: In case of empty list, variant will be picked from all variants for specified ability
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromVariantsSet(params Blueprint<BlueprintAbility, BlueprintAbilityReference>[] variantsSet)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_VariantsSet is null) { return; }
          bp.m_VariantsSet = bp.m_VariantsSet.Where(val => !variantsSet.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAiCastSpell.m_VariantsSet"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="variantsSet">
    /// <para>
    /// InfoBox: In case of empty list, variant will be picked from all variants for specified ability
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromVariantsSet(Func<BlueprintAbilityReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_VariantsSet is null) { return; }
          bp.m_VariantsSet = bp.m_VariantsSet.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAiCastSpell.m_VariantsSet"/>
    /// </summary>
    ///
    /// <param name="variantsSet">
    /// <para>
    /// InfoBox: In case of empty list, variant will be picked from all variants for specified ability
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearVariantsSet()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_VariantsSet = new BlueprintAbilityReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiCastSpell.m_VariantsSet"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="variantsSet">
    /// <para>
    /// InfoBox: In case of empty list, variant will be picked from all variants for specified ability
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyVariantsSet(Action<BlueprintAbilityReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_VariantsSet is null) { return; }
          bp.m_VariantsSet.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiCastSpell.Locators"/>
    /// </summary>
    ///
    /// <param name="locators">
    /// <para>
    /// InfoBox: To use locators make sure you selected CheckCasterDistance or CheckPartyDistance.
    /// </para>
    /// </param>
    public TBuilder SetLocators(EntityReference[] locators)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in locators) { Validate(item); }
          bp.Locators = locators;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAiCastSpell.Locators"/>
    /// </summary>
    ///
    /// <param name="locators">
    /// <para>
    /// InfoBox: To use locators make sure you selected CheckCasterDistance or CheckPartyDistance.
    /// </para>
    /// </param>
    public TBuilder AddToLocators(params EntityReference[] locators)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Locators = bp.Locators ?? new EntityReference[0];
          bp.Locators = CommonTool.Append(bp.Locators, locators);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAiCastSpell.Locators"/>
    /// </summary>
    ///
    /// <param name="locators">
    /// <para>
    /// InfoBox: To use locators make sure you selected CheckCasterDistance or CheckPartyDistance.
    /// </para>
    /// </param>
    public TBuilder RemoveFromLocators(params EntityReference[] locators)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Locators is null) { return; }
          bp.Locators = bp.Locators.Where(val => !locators.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAiCastSpell.Locators"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="locators">
    /// <para>
    /// InfoBox: To use locators make sure you selected CheckCasterDistance or CheckPartyDistance.
    /// </para>
    /// </param>
    public TBuilder RemoveFromLocators(Func<EntityReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Locators is null) { return; }
          bp.Locators = bp.Locators.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAiCastSpell.Locators"/>
    /// </summary>
    ///
    /// <param name="locators">
    /// <para>
    /// InfoBox: To use locators make sure you selected CheckCasterDistance or CheckPartyDistance.
    /// </para>
    /// </param>
    public TBuilder ClearLocators()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Locators = new EntityReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiCastSpell.Locators"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="locators">
    /// <para>
    /// InfoBox: To use locators make sure you selected CheckCasterDistance or CheckPartyDistance.
    /// </para>
    /// </param>
    public TBuilder ModifyLocators(Action<EntityReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Locators is null) { return; }
          bp.Locators.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiCastSpell.CheckCasterDistance"/>
    /// </summary>
    public TBuilder SetCheckCasterDistance(bool checkCasterDistance = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CheckCasterDistance = checkCasterDistance;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiCastSpell.CheckCasterDistance"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCheckCasterDistance(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CheckCasterDistance);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiCastSpell.MinCasterDistanceToLocator"/>
    /// </summary>
    ///
    /// <param name="minCasterDistanceToLocator">
    /// <para>
    /// InfoBox: Selects target point from locators which is distant from caster by at least MinCasterDistanceToLocator meters (0 means no limit)
    /// </para>
    /// </param>
    public TBuilder SetMinCasterDistanceToLocator(float minCasterDistanceToLocator)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinCasterDistanceToLocator = minCasterDistanceToLocator;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiCastSpell.MinCasterDistanceToLocator"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="minCasterDistanceToLocator">
    /// <para>
    /// InfoBox: Selects target point from locators which is distant from caster by at least MinCasterDistanceToLocator meters (0 means no limit)
    /// </para>
    /// </param>
    public TBuilder ModifyMinCasterDistanceToLocator(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MinCasterDistanceToLocator);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiCastSpell.CheckPartyDistance"/>
    /// </summary>
    public TBuilder SetCheckPartyDistance(bool checkPartyDistance = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CheckPartyDistance = checkPartyDistance;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiCastSpell.CheckPartyDistance"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCheckPartyDistance(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CheckPartyDistance);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiCastSpell.MinPartyDistanceToLocator"/>
    /// </summary>
    ///
    /// <param name="minPartyDistanceToLocator">
    /// <para>
    /// InfoBox: Selects target point from locators which is distant from all party members by at least MinPartyDistanceToLocator meters (0 or less means no limit)
    /// </para>
    /// </param>
    public TBuilder SetMinPartyDistanceToLocator(float minPartyDistanceToLocator)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinPartyDistanceToLocator = minPartyDistanceToLocator;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiCastSpell.MinPartyDistanceToLocator"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="minPartyDistanceToLocator">
    /// <para>
    /// InfoBox: Selects target point from locators which is distant from all party members by at least MinPartyDistanceToLocator meters (0 or less means no limit)
    /// </para>
    /// </param>
    public TBuilder ModifyMinPartyDistanceToLocator(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MinPartyDistanceToLocator);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiCastSpell.MaxPartyDistanceToLocator"/>
    /// </summary>
    ///
    /// <param name="maxPartyDistanceToLocator">
    /// <para>
    /// InfoBox: Selects target point from locators which is distant from at least one party member less than MaxPartyDistanceToLocator meters (0 or less means no limit)
    /// </para>
    /// </param>
    public TBuilder SetMaxPartyDistanceToLocator(float maxPartyDistanceToLocator)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaxPartyDistanceToLocator = maxPartyDistanceToLocator;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiCastSpell.MaxPartyDistanceToLocator"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="maxPartyDistanceToLocator">
    /// <para>
    /// InfoBox: Selects target point from locators which is distant from at least one party member less than MaxPartyDistanceToLocator meters (0 or less means no limit)
    /// </para>
    /// </param>
    public TBuilder ModifyMaxPartyDistanceToLocator(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MaxPartyDistanceToLocator);
        });
    }
  }
}
