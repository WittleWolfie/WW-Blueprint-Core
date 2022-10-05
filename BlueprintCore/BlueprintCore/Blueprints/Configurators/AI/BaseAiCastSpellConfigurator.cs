//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
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
    protected BaseAiCastSpellConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintAiCastSpell>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_MinCasterSqrDistanceToLocator = copyFrom.m_MinCasterSqrDistanceToLocator;
          bp.m_MinPartySqrDistanceToLocator = copyFrom.m_MinPartySqrDistanceToLocator;
          bp.m_MaxPartySqrDistanceToLocator = copyFrom.m_MaxPartySqrDistanceToLocator;
          bp.m_AffectedByImpatience = copyFrom.m_AffectedByImpatience;
          bp.m_Ability = copyFrom.m_Ability;
          bp.m_ForceTargetSelf = copyFrom.m_ForceTargetSelf;
          bp.m_ForceTargetEnemy = copyFrom.m_ForceTargetEnemy;
          bp.m_TargetPointUnderTarget = copyFrom.m_TargetPointUnderTarget;
          bp.m_DeadTargetType = copyFrom.m_DeadTargetType;
          bp.m_RandomVariant = copyFrom.m_RandomVariant;
          bp.m_Variant = copyFrom.m_Variant;
          bp.m_VariantsSet = copyFrom.m_VariantsSet;
          bp.Locators = copyFrom.Locators;
          bp.CheckCasterDistance = copyFrom.CheckCasterDistance;
          bp.MinCasterDistanceToLocator = copyFrom.MinCasterDistanceToLocator;
          bp.CheckPartyDistance = copyFrom.CheckPartyDistance;
          bp.MinPartyDistanceToLocator = copyFrom.MinPartyDistanceToLocator;
          bp.MaxPartyDistanceToLocator = copyFrom.MaxPartyDistanceToLocator;
        });
    }

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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAbility(Blueprint<BlueprintAbilityReference> ability)
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
    /// Sets the value of <see cref="BlueprintAiCastSpell.m_TargetPointUnderTarget"/>
    /// </summary>
    public TBuilder SetTargetPointUnderTarget(bool targetPointUnderTarget = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TargetPointUnderTarget = targetPointUnderTarget;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiCastSpell.m_DeadTargetType"/>
    /// </summary>
    public TBuilder SetDeadTargetType(DeadTargetType deadTargetType)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DeadTargetType = deadTargetType;
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetVariant(Blueprint<BlueprintAbilityReference> variant)
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetVariantsSet(params Blueprint<BlueprintAbilityReference>[] variantsSet)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_VariantsSet = variantsSet.Select(bp => bp.Reference).ToArray();
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToVariantsSet(params Blueprint<BlueprintAbilityReference>[] variantsSet)
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromVariantsSet(params Blueprint<BlueprintAbilityReference>[] variantsSet)
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
    public TBuilder RemoveFromVariantsSet(Func<BlueprintAbilityReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_VariantsSet is null) { return; }
          bp.m_VariantsSet = bp.m_VariantsSet.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAiCastSpell.m_VariantsSet"/>
    /// </summary>
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
    public TBuilder SetLocators(params EntityReference[] locators)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(locators);
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
    public TBuilder RemoveFromLocators(Func<EntityReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Locators is null) { return; }
          bp.Locators = bp.Locators.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAiCastSpell.Locators"/>
    /// </summary>
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

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Ability is null)
      {
        Blueprint.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      if (Blueprint.m_Variant is null)
      {
        Blueprint.m_Variant = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      if (Blueprint.m_VariantsSet is null)
      {
        Blueprint.m_VariantsSet = new BlueprintAbilityReference[0];
      }
      if (Blueprint.Locators is null)
      {
        Blueprint.Locators = new EntityReference[0];
      }
    }
  }
}
