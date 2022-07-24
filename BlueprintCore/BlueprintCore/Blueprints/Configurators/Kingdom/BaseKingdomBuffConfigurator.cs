//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Armies;
using Kingmaker.Armies.Components;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Armies;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Kingdom.Buffs;
using Kingmaker.Kingdom.Settlements.BuildingComponents;
using Kingmaker.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintKingdomBuff"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseKingdomBuffConfigurator<T, TBuilder>
    : BaseFactConfigurator<T, TBuilder>
    where T : BlueprintKingdomBuff
    where TBuilder : BaseKingdomBuffConfigurator<T, TBuilder>
  {
    protected BaseKingdomBuffConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomBuff.DisplayName"/>
    /// </summary>
    ///
    /// <param name="displayName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetDisplayName(LocalString displayName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DisplayName = displayName?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomBuff.DisplayName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDisplayName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DisplayName is null) { return; }
          action.Invoke(bp.DisplayName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomBuff.Description"/>
    /// </summary>
    ///
    /// <param name="description">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetDescription(LocalString description)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Description = description?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomBuff.Description"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDescription(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Description is null) { return; }
          action.Invoke(bp.Description);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomBuff.Icon"/>
    /// </summary>
    ///
    /// <param name="icon">
    /// <para>
    /// InfoBox: Set to null to hide in UI
    /// </para>
    /// You can pass in the animation using a Sprite or it's AssetId.
    /// </param>
    public TBuilder SetIcon(Asset<Sprite> icon)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Icon = icon?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomBuff.Icon"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIcon(Action<Sprite> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Icon is null) { return; }
          action.Invoke(bp.Icon);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomBuff.DurationDays"/>
    /// </summary>
    public TBuilder SetDurationDays(int durationDays)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DurationDays = durationDays;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomBuff.StatChanges"/>
    /// </summary>
    public TBuilder SetStatChanges(KingdomStats.Changes statChanges)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(statChanges);
          bp.StatChanges = statChanges;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomBuff.StatChanges"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyStatChanges(Action<KingdomStats.Changes> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.StatChanges is null) { return; }
          action.Invoke(bp.StatChanges);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomBuff.OnApply"/>
    /// </summary>
    public TBuilder SetOnApply(ActionsBuilder onApply)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OnApply = onApply?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomBuff.OnApply"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOnApply(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OnApply is null) { return; }
          action.Invoke(bp.OnApply);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomBuff.OnRemove"/>
    /// </summary>
    public TBuilder SetOnRemove(ActionsBuilder onRemove)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OnRemove = onRemove?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomBuff.OnRemove"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOnRemove(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OnRemove is null) { return; }
          action.Invoke(bp.OnRemove);
        });
    }

    /// <summary>
    /// Adds <see cref="KingdomUnitsGrowthIncrease"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyAgitators</term><description>ac36380a86564c65b461be02855d9a01</description></item>
    /// <item><term>Event38ArmyFutureHeroes</term><description>3dcf5fd8287447a78436870ef73fb201</description></item>
    /// <item><term>Leadership2MoraleForRecruitsEffect</term><description>4dba6a6f7c904dccbc6390d3f3889a7f</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="bonusPercent">
    /// <para>
    /// InfoBox: Negative means growth reduce
    /// </para>
    /// </param>
    /// <param name="properties">
    /// <para>
    /// InfoBox: Works as OR. Unit should have Any of listed property to be processed. None - means any unit
    /// </para>
    /// </param>
    /// <param name="units">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddKingdomUnitsGrowthIncrease(
        bool? allUnits = null,
        int? bonusPercent = null,
        KingdomUnitsGrowthIncrease.UnitListOperation? operation = null,
        ArmyProperties? properties = null,
        List<Blueprint<BlueprintUnitReference>>? units = null)
    {
      var component = new KingdomUnitsGrowthIncrease();
      component.AllUnits = allUnits ?? component.AllUnits;
      component.BonusPercent = bonusPercent ?? component.BonusPercent;
      component.Operation = operation ?? component.Operation;
      component.Properties = properties ?? component.Properties;
      component.Units = units?.Select(bp => bp.Reference)?.ToList() ?? component.Units;
      if (component.Units is null)
      {
        component.Units = new();
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingCostModifier"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BuildingEngineersWorkshop</term><description>f3f6c1e6708341968e439018f5f63e01</description></item>
    /// <item><term>FlagDiplomacy8BuildingsDiscount</term><description>d6758d76c4cb4bb797246e01ad9d12d9</description></item>
    /// <item><term>FlagLegend1CostDecrease</term><description>c346f489c159453b9f4ca912630715d4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buildings">
    /// <para>
    /// Blueprint of type BlueprintSettlementBuilding. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="modifier">
    /// <para>
    /// InfoBox: (This coefficient - 1) will be added to resultModifier. Formula: resultCont = baseCost * resultModifier
    /// </para>
    /// </param>
    public TBuilder AddBuildingCostModifier(
        List<Blueprint<BlueprintSettlementBuildingReference>>? buildings = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        float? modifier = null)
    {
      var component = new BuildingCostModifier();
      component.Buildings = buildings?.Select(bp => bp.Reference)?.ToList() ?? component.Buildings;
      if (component.Buildings is null)
      {
        component.Buildings = new();
      }
      component.Modifier = modifier ?? component.Modifier;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ChangeKingdomMoraleMinimum"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CrusadeStoryMode</term><description>cd708fd765d74299a32c5438ed67d642</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="minValueDelta">
    /// <para>
    /// InfoBox: Can be negative. MinMorale = Max (KingdomRoot.MinMorale, MinMorale + MinValueDelta)
    /// </para>
    /// </param>
    public TBuilder AddChangeKingdomMoraleMinimum(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        int? minValueDelta = null)
    {
      var component = new ChangeKingdomMoraleMinimum();
      component.m_MinValueDelta = minValueDelta ?? component.m_MinValueDelta;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="EveryDayTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AutoKingdomProjectsControllerCh3</term><description>b31b96dd34f8415382c8ec26787364d3</description></item>
    /// <item><term>FlagTrickster3Economy</term><description>4b833c6fcdfa47918927d80edf7ef9ae</description></item>
    /// <item><term>SettlementsTracker_buff</term><description>71dd611cd70443fcb04f0dce3bda76ef</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEveryDayTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? condition = null,
        int? skipDays = null)
    {
      var component = new EveryDayTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.Condition = condition?.Build() ?? component.Condition;
      if (component.Condition is null)
      {
        component.Condition = Utils.Constants.Empty.Conditions;
      }
      component.SkipDays = skipDays ?? component.SkipDays;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryWeekTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FlagTrickster1Money</term><description>6c97784129e5492fa08496f2d4139f22</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEveryWeekTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? condition = null,
        int? skipWeeks = null)
    {
      var component = new EveryWeekTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.Condition = condition?.Build() ?? component.Condition;
      if (component.Condition is null)
      {
        component.Condition = Utils.Constants.Empty.Conditions;
      }
      component.SkipWeeks = skipWeeks ?? component.SkipWeeks;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="GlobalArmiesMoraleModifier"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BuildingSaboteursHeadquarters</term><description>ccdf2781aafc49bd9197d3388e4bc29f</description></item>
    /// <item><term>BuildingScoutsHeadquarters</term><description>b8a2e915f3f04708919e41f9f1996ffa</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddGlobalArmiesMoraleModifier(
        ArmyFaction? faction = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        int? moraleModifier = null)
    {
      var component = new GlobalArmiesMoraleModifier();
      component.m_Faction = faction ?? component.m_Faction;
      component.m_MoraleModifier = moraleModifier ?? component.m_MoraleModifier;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="KingdomAddMercenaryReroll"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyGloryAmongTheMercenaries</term><description>888fd9cff8cb4fe7a3194c2453ae508f</description></item>
    /// <item><term>CrusadeCasualMode</term><description>32bc842045574f8abdbbe4a4bcf4cb3d</description></item>
    /// <item><term>CrusadeStoryMode</term><description>cd708fd765d74299a32c5438ed67d642</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddKingdomAddMercenaryReroll(
        int? freeRerollsToAdd = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new KingdomAddMercenaryReroll();
      component.m_FreeRerollsToAdd = freeRerollsToAdd ?? component.m_FreeRerollsToAdd;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="KingdomAddMercenarySlot"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyDisgruntledMercenaries</term><description>254bcff0302341a4841bf282d852886e</description></item>
    /// <item><term>FlagLegend3ArmyIncome</term><description>837f273349124973bcf0dd2aa2cb2f0a</description></item>
    /// <item><term>MercenaryGuild</term><description>d615938461996b945810e3fbc989c460</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddKingdomAddMercenarySlot(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        int? slotsToAdd = null)
    {
      var component = new KingdomAddMercenarySlot();
      component.m_SlotsToAdd = slotsToAdd ?? component.m_SlotsToAdd;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="KingdomIncomeModifier"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CrusadeCasualMode</term><description>32bc842045574f8abdbbe4a4bcf4cb3d</description></item>
    /// <item><term>Diplomacy2ResourcesEffect</term><description>514fb79269ef4a30b1e58f56838ac3a1</description></item>
    /// <item><term>GrowthResourceShortage</term><description>0fcf7e30aca04da5a535759b8fe6ad3d</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddKingdomIncomeModifier(
        int? basicsModifier = null,
        int? favorsModifier = null,
        int? financeModifier = null,
        int? modifier = null)
    {
      var component = new KingdomIncomeModifier();
      component.BasicsModifier = basicsModifier ?? component.BasicsModifier;
      component.FavorsModifier = favorsModifier ?? component.FavorsModifier;
      component.FinanceModifier = financeModifier ?? component.FinanceModifier;
      component.Modifier = modifier ?? component.Modifier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomMoraleEffectMultiplier"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FlagAngel1FInances</term><description>e0eb9e98a36944f5b03f9ba4436ea453</description></item>
    /// <item><term>FlagAngel1Resources</term><description>3afad12a450e4619b25d8b9545d3cd70</description></item>
    /// <item><term>FlagLogistics5MoraleForResources</term><description>2a34993f8beb4f019037f49396a54618</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="incomeMultiplier">
    /// <para>
    /// InfoBox: Multiplies morale modifier for income growth
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="unitMultiplier">
    /// <para>
    /// InfoBox: Multiplies morale modifier for unit growth
    /// </para>
    /// </param>
    public TBuilder AddKingdomMoraleEffectMultiplier(
        float? incomeMultiplier = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        float? unitMultiplier = null)
    {
      var component = new KingdomMoraleEffectMultiplier();
      component.IncomeMultiplier = incomeMultiplier ?? component.IncomeMultiplier;
      component.UnitMultiplier = unitMultiplier ?? component.UnitMultiplier;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="KingdomMoraleForArmies"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FlagAngel2Morale</term><description>d3331c4431c44d97a3daeccbd9791f41</description></item>
    /// <item><term>KingdomMoraleForArmies</term><description>4789870c0669c0348b56d05ed67f8781</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddKingdomMoraleForArmies(
        ArmyFaction? faction = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        float? multiplier = null)
    {
      var component = new KingdomMoraleForArmies();
      component.m_Faction = faction ?? component.m_Faction;
      component.m_Multiplier = multiplier ?? component.m_Multiplier;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="KingdomTacticalArmyFeature"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyUnitsBestIngredients</term><description>596531fba07848c3959d6e7df0e0a3a4</description></item>
    /// <item><term>FlagLich1BoneShield</term><description>49dfbfd138cd4ba3848c35234b3381ae</description></item>
    /// <item><term>ZiforianSupport_buff</term><description>3735e202e116466898a0e7fd54607d22</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="armyUnits">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="features">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddKingdomTacticalArmyFeature(
        ArmyProperties? armyTag = null,
        List<Blueprint<BlueprintUnitReference>>? armyUnits = null,
        bool? byTag = null,
        bool? byUnits = null,
        ArmyFaction? faction = null,
        List<Blueprint<BlueprintFeatureReference>>? features = null,
        MercenariesIncludeOption? mercenariesFilter = null)
    {
      var component = new KingdomTacticalArmyFeature();
      component.m_ArmyTag = armyTag ?? component.m_ArmyTag;
      component.m_ArmyUnits = armyUnits?.Select(bp => bp.Reference)?.ToArray() ?? component.m_ArmyUnits;
      if (component.m_ArmyUnits is null)
      {
        component.m_ArmyUnits = new BlueprintUnitReference[0];
      }
      component.m_ByTag = byTag ?? component.m_ByTag;
      component.m_ByUnits = byUnits ?? component.m_ByUnits;
      component.m_Faction = faction ?? component.m_Faction;
      component.m_Features = features?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Features;
      if (component.m_Features is null)
      {
        component.m_Features = new BlueprintFeatureReference[0];
      }
      component.m_MercenariesFilter = mercenariesFilter ?? component.m_MercenariesFilter;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecruitCostModifier"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyCheapMercenaries</term><description>370e722e8d7d4819b5671c0db96732f9</description></item>
    /// <item><term>FlagDiplomacy8RecruitsIncrease</term><description>489949bbf18b4bc68cf9c9531cdd4556</description></item>
    /// <item><term>MercenaryCostIncreaseCh5_90</term><description>9fd19c907020493ca0973e439f888819</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="modifier">
    /// <para>
    /// InfoBox: (This coefficient - 1) will be added to resultModifier. Formula: resultCont = baseCost * resultModifier
    /// </para>
    /// </param>
    /// <param name="properties">
    /// <para>
    /// InfoBox: Works as OR. Unit should have Any of listed property to be processed. None - means any unit
    /// </para>
    /// </param>
    /// <param name="units">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddRecruitCostModifier(
        bool? allUnits = null,
        MercenariesIncludeOption? mercenariesFilter = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        float? modifier = null,
        KingdomUnitsGrowthIncrease.UnitListOperation? operation = null,
        ArmyProperties? properties = null,
        List<Blueprint<BlueprintUnitReference>>? units = null)
    {
      var component = new RecruitCostModifier();
      component.AllUnits = allUnits ?? component.AllUnits;
      component.MercenariesFilter = mercenariesFilter ?? component.MercenariesFilter;
      component.Modifier = modifier ?? component.Modifier;
      component.Operation = operation ?? component.Operation;
      component.Properties = properties ?? component.Properties;
      component.Units = units?.Select(bp => bp.Reference)?.ToList() ?? component.Units;
      if (component.Units is null)
      {
        component.Units = new();
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RecruitDisable"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FlagDiplomacy7ForbidHirement</term><description>fefd66a0c7494f169a2474baf55657b0</description></item>
    /// <item><term>FlagLocust</term><description>328fc139938f4582a605917a729169f3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRecruitDisable(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new RecruitDisable();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="KingdomStatFromCrusadeResources"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DefaultKingdomStatsBuff</term><description>bfedbe8f63af41b4c87ad1c6f214217d</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddKingdomStatFromCrusadeResources(
        KingdomStats.Type? stat = null,
        float? statPerFavors = null,
        float? statPerFinances = null,
        float? statPerMaterials = null)
    {
      var component = new KingdomStatFromCrusadeResources();
      component.m_Stat = stat ?? component.m_Stat;
      component.m_StatPerFavors = statPerFavors ?? component.m_StatPerFavors;
      component.m_StatPerFinances = statPerFinances ?? component.m_StatPerFinances;
      component.m_StatPerMaterials = statPerMaterials ?? component.m_StatPerMaterials;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomStatFromLeaderExperience"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DefaultKingdomStatsBuff</term><description>bfedbe8f63af41b4c87ad1c6f214217d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddKingdomStatFromLeaderExperience(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        KingdomStats.Type? stat = null,
        float? statPerLeaderExperience = null)
    {
      var component = new KingdomStatFromLeaderExperience();
      component.m_Stat = stat ?? component.m_Stat;
      component.m_StatPerLeaderExperience = statPerLeaderExperience ?? component.m_StatPerLeaderExperience;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="KingdomStatFromRecruitment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DefaultKingdomStatsBuff</term><description>bfedbe8f63af41b4c87ad1c6f214217d</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddKingdomStatFromRecruitment(
        KingdomStats.Type? stat = null,
        float? statPerExp = null)
    {
      var component = new KingdomStatFromRecruitment();
      component.m_Stat = stat ?? component.m_Stat;
      component.m_StatPerExp = statPerExp ?? component.m_StatPerExp;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomGainSkillToLeaders"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyLeaderPetDrake</term><description>3b33a686ce224e6d9fb0f634267e4784</description></item>
    /// <item><term>FlagLeadership3Morale</term><description>87cc231b38d843edab15031e7db25b39</description></item>
    /// <item><term>QuatermasterMaps_buff</term><description>cc4249f904c246c4a7f3eeab976116d4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="skill">
    /// <para>
    /// Blueprint of type BlueprintLeaderSkill. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="skillsList">
    /// <para>
    /// InfoBox: Will gain leader first unknown skill starting from 0 element
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintLeaderSkill. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddKingdomGainSkillToLeaders(
        int? minLevel = null,
        Blueprint<BlueprintLeaderSkillReference>? skill = null,
        List<Blueprint<BlueprintLeaderSkillReference>>? skillsList = null,
        ArmyFaction? targetFactions = null,
        bool? useSkillsList = null)
    {
      var component = new KingdomGainSkillToLeaders();
      component.m_MinLevel = minLevel ?? component.m_MinLevel;
      component.m_Skill = skill?.Reference ?? component.m_Skill;
      if (component.m_Skill is null)
      {
        component.m_Skill = BlueprintTool.GetRef<BlueprintLeaderSkillReference>(null);
      }
      component.m_SkillsList = skillsList?.Select(bp => bp.Reference)?.ToArray() ?? component.m_SkillsList;
      if (component.m_SkillsList is null)
      {
        component.m_SkillsList = new BlueprintLeaderSkillReference[0];
      }
      component.m_TargetFactions = targetFactions ?? component.m_TargetFactions;
      component.m_UseSkillsList = useSkillsList ?? component.m_UseSkillsList;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyGlobalMapMovementBonus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon1SpeedStats</term><description>62fcd9d0cdb54b59930c9b9bbb30a870</description></item>
    /// <item><term>Logistics4MovementPoints</term><description>177c84d3733a4ef2865694736714f2d7</description></item>
    /// <item><term>QuartermasterMaps</term><description>8830aeff4cc742f4a9f43fb152d8bfdb</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddArmyGlobalMapMovementBonus(
        int? dailyMovementPoints = null,
        int? maxMovementPoints = null)
    {
      var component = new ArmyGlobalMapMovementBonus();
      component.DailyMovementPoints = dailyMovementPoints ?? component.DailyMovementPoints;
      component.MaxMovementPoints = maxMovementPoints ?? component.MaxMovementPoints;
      return AddComponent(component);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.DisplayName is null)
      {
        Blueprint.DisplayName = Utils.Constants.Empty.String;
      }
      if (Blueprint.Description is null)
      {
        Blueprint.Description = Utils.Constants.Empty.String;
      }
      if (Blueprint.OnApply is null)
      {
        Blueprint.OnApply = Utils.Constants.Empty.Actions;
      }
      if (Blueprint.OnRemove is null)
      {
        Blueprint.OnRemove = Utils.Constants.Empty.Actions;
      }
    }
  }
}
