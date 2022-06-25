//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Buffs;
using Kingmaker.Kingdom.Flags;
using Kingmaker.Kingdom.Settlements;
using Kingmaker.Kingdom.Settlements.BuildingComponents;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom.Settlements
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintSettlementBuilding"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseSettlementBuildingConfigurator<T, TBuilder>
    : BaseFactConfigurator<T, TBuilder>
    where T : BlueprintSettlementBuilding
    where TBuilder : BaseSettlementBuildingConfigurator<T, TBuilder>
  {
    protected BaseSettlementBuildingConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSettlementBuilding.Name"/>
    /// </summary>
    ///
    /// <param name="name">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetName(LocalString name)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Name = name?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSettlementBuilding.Name"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Name is null) { return; }
          action.Invoke(bp.Name);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSettlementBuilding.Description"/>
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
    /// Modifies <see cref="BlueprintSettlementBuilding.Description"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintSettlementBuilding.MechanicalDescription"/>
    /// </summary>
    ///
    /// <param name="mechanicalDescription">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetMechanicalDescription(LocalString mechanicalDescription)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MechanicalDescription = mechanicalDescription?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSettlementBuilding.MechanicalDescription"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMechanicalDescription(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.MechanicalDescription is null) { return; }
          action.Invoke(bp.MechanicalDescription);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSettlementBuilding.CompletedPrefab"/>
    /// </summary>
    public TBuilder SetCompletedPrefab(PrefabLink completedPrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CompletedPrefab = completedPrefab;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSettlementBuilding.CompletedPrefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCompletedPrefab(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CompletedPrefab is null) { return; }
          action.Invoke(bp.CompletedPrefab);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSettlementBuilding.UnfinishedPrefab"/>
    /// </summary>
    public TBuilder SetUnfinishedPrefab(PrefabLink unfinishedPrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UnfinishedPrefab = unfinishedPrefab;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSettlementBuilding.UnfinishedPrefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUnfinishedPrefab(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UnfinishedPrefab is null) { return; }
          action.Invoke(bp.UnfinishedPrefab);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSettlementBuilding.BuildCost"/>
    /// </summary>
    public TBuilder SetBuildCost(KingdomResourcesAmount buildCost)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BuildCost = buildCost;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSettlementBuilding.BuildCost"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBuildCost(Action<KingdomResourcesAmount> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.BuildCost);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSettlementBuilding.StatChanges"/>
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
    /// Modifies <see cref="BlueprintSettlementBuilding.StatChanges"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintSettlementBuilding.MinLevel"/>
    /// </summary>
    public TBuilder SetMinLevel(SettlementState.LevelType minLevel)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinLevel = minLevel;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSettlementBuilding.MinLevel"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMinLevel(Action<SettlementState.LevelType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MinLevel);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSettlementBuilding.SlotSizeX"/>
    /// </summary>
    public TBuilder SetSlotSizeX(int slotSizeX)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SlotSizeX = slotSizeX;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSettlementBuilding.SlotSizeX"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySlotSizeX(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.SlotSizeX);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSettlementBuilding.SlotSizeY"/>
    /// </summary>
    public TBuilder SetSlotSizeY(int slotSizeY)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SlotSizeY = slotSizeY;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSettlementBuilding.SlotSizeY"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySlotSizeY(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.SlotSizeY);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSettlementBuilding.BuildTime"/>
    /// </summary>
    public TBuilder SetBuildTime(int buildTime)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BuildTime = buildTime;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSettlementBuilding.BuildTime"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBuildTime(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.BuildTime);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSettlementBuilding.SpecialSlot"/>
    /// </summary>
    public TBuilder SetSpecialSlot(SettlementState.SpecialSlotType specialSlot)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SpecialSlot = specialSlot;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSettlementBuilding.SpecialSlot"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpecialSlot(Action<SettlementState.SpecialSlotType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.SpecialSlot);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSettlementBuilding.m_UpgradesTo"/>
    /// </summary>
    ///
    /// <param name="upgradesTo">
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
    public TBuilder SetUpgradesTo(Blueprint<BlueprintSettlementBuildingReference> upgradesTo)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_UpgradesTo = upgradesTo?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSettlementBuilding.m_UpgradesTo"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUpgradesTo(Action<BlueprintSettlementBuildingReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_UpgradesTo is null) { return; }
          action.Invoke(bp.m_UpgradesTo);
        });
    }

    /// <summary>
    /// Adds <see cref="LocationRadiusBuff"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Asylum</term><description>0fd24a67f41f4f63adb6e19bb526fb1f</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
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
    public TBuilder AddLocationRadiusBuff(
        Blueprint<BlueprintBuffReference>? buff = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        float? radius = null)
    {
      var component = new LocationRadiusBuff();
      component.m_Buff = buff?.Reference ?? component.m_Buff;
      if (component.m_Buff is null)
      {
        component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.Radius = radius ?? component.Radius;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="BuildingAdjacencyBonus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Warehouse</term><description>ab509bc1202e3044ab58653230d66c1f</description></item>
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
    /// <param name="noSuchBuildings">
    /// <para>
    /// InfoBox: If true, looking for opposite: there should be no building in distance to get bonus
    /// </para>
    /// </param>
    public TBuilder AddBuildingAdjacencyBonus(
        bool? anyBuilding = null,
        List<Blueprint<BlueprintSettlementBuildingReference>>? buildings = null,
        BuildingAdjacencyBonus.CalculationType? calculation = null,
        BuildingAdjacencyBonus.DistanceRequirementType? distance = null,
        bool? noSuchBuildings = null,
        KingdomStats.Changes? stats = null)
    {
      var component = new BuildingAdjacencyBonus();
      component.AnyBuilding = anyBuilding ?? component.AnyBuilding;
      component.Buildings = buildings?.Select(bp => bp.Reference)?.ToList() ?? component.Buildings;
      if (component.Buildings is null)
      {
        component.Buildings = new();
      }
      component.Calculation = calculation ?? component.Calculation;
      component.Distance = distance ?? component.Distance;
      component.NoSuchBuildings = noSuchBuildings ?? component.NoSuchBuildings;
      Validate(stats);
      component.Stats = stats ?? component.Stats;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingAttachedBuff"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AlchemistLaboratory</term><description>6ecb3570375b4ff899731851bc6eb676</description></item>
    /// <item><term>InfernalForgeImproved</term><description>49c4fef73ed44efab4fdde89b81bf31c</description></item>
    /// <item><term>Watchtower</term><description>6cd75d70e2024eb699ad44fa2b7c942b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buff">
    /// <para>
    /// Blueprint of type BlueprintKingdomBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddBuildingAttachedBuff(
        Blueprint<BlueprintKingdomBuffReference>? buff = null,
        bool? onlyInRegion = null)
    {
      var component = new BuildingAttachedBuff();
      component.m_Buff = buff?.Reference ?? component.m_Buff;
      if (component.m_Buff is null)
      {
        component.m_Buff = BlueprintTool.GetRef<BlueprintKingdomBuffReference>(null);
      }
      component.m_OnlyInRegion = onlyInRegion ?? component.m_OnlyInRegion;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingPartOfQuestObjective"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>StablesMain</term><description>c9a942637a18f3f4abd9d8cf320c1120</description></item>
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
    /// <param name="objective">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddBuildingPartOfQuestObjective(
        List<Blueprint<BlueprintSettlementBuildingReference>>? buildings = null,
        Blueprint<BlueprintQuestObjectiveReference>? objective = null)
    {
      var component = new BuildingPartOfQuestObjective();
      component.m_Buildings = buildings?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Buildings;
      if (component.m_Buildings is null)
      {
        component.m_Buildings = new BlueprintSettlementBuildingReference[0];
      }
      component.m_Objective = objective?.Reference ?? component.m_Objective;
      if (component.m_Objective is null)
      {
        component.m_Objective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingResourceGrowthGlobalIncrease"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Palace</term><description>4ed3e1448ec844b9832ecb8705bb7ccf</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddBuildingResourceGrowthGlobalIncrease(
        int? basicsModifier = null,
        int? favorsModifier = null,
        int? financeModifier = null,
        int? modifier = null)
    {
      var component = new BuildingResourceGrowthGlobalIncrease();
      component.BasicsModifier = basicsModifier ?? component.BasicsModifier;
      component.FavorsModifier = favorsModifier ?? component.FavorsModifier;
      component.FinanceModifier = financeModifier ?? component.FinanceModifier;
      component.Modifier = modifier ?? component.Modifier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingResourceGrowthIncrease"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BlackMarket</term><description>df78001e89d3b2448baab7cd38c03a43</description></item>
    /// <item><term>Inn</term><description>e036ddec60aa6c044a5830f2e1528329</description></item>
    /// <item><term>Shrine</term><description>c48d088575c044b991564d338d21205c</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddBuildingResourceGrowthIncrease(
        KingdomResourcesAmount? resourcesAmount = null)
    {
      var component = new BuildingResourceGrowthIncrease();
      component.ResourcesAmount = resourcesAmount ?? component.ResourcesAmount;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingSiegeDurationIncrease"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Citadel</term><description>9007ead8312c428e8cb0aa174dcae500</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="affectedFlags">
    /// <para>
    /// Blueprint of type BlueprintKingdomMoraleFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="durationDeltaInDays">
    /// <para>
    /// InfoBox: Also increases morale flag neutral state duration
    /// </para>
    /// </param>
    public TBuilder AddBuildingSiegeDurationIncrease(
        List<Blueprint<BlueprintKingdomMoraleFlag.Reference>>? affectedFlags = null,
        int? durationDeltaInDays = null)
    {
      var component = new BuildingSiegeDurationIncrease();
      component.m_AffectedFlags = affectedFlags?.Select(bp => bp.Reference)?.ToArray() ?? component.m_AffectedFlags;
      if (component.m_AffectedFlags is null)
      {
        component.m_AffectedFlags = new BlueprintKingdomMoraleFlag.Reference[0];
      }
      component.DurationDeltaInDays = durationDeltaInDays ?? component.DurationDeltaInDays;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingTacticalUnitFactBonus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Apothecary</term><description>ca05fbbbd02e4b1bae94446d60cbc739</description></item>
    /// <item><term>FightersPitCapital</term><description>ad999a88f4bf459b8e144d9fc3f54f65</description></item>
    /// <item><term>TrainingGroundsCapital</term><description>74e53dc8c8824430af8921967a5f1e4f</description></item>
    /// </list>
    /// </remarks>
    ///
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
    public TBuilder AddBuildingTacticalUnitFactBonus(
        BuildingTacticalUnitFactBonus.DistanceType? distance = null,
        List<Blueprint<BlueprintFeatureReference>>? features = null,
        bool? onlyForCurrentRegion = null)
    {
      var component = new BuildingTacticalUnitFactBonus();
      component.m_Distance = distance ?? component.m_Distance;
      component.m_Features = features?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Features;
      if (component.m_Features is null)
      {
        component.m_Features = new BlueprintFeatureReference[0];
      }
      component.m_OnlyForCurrentRegion = onlyForCurrentRegion ?? component.m_OnlyForCurrentRegion;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingUnitGrowthIncrease"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcheryRangeGarrison</term><description>39fbb3d3476040a68477167bb907a423</description></item>
    /// <item><term>HallOfChampionsMain</term><description>72048521c14e4cdc8a82d94f99a056c7</description></item>
    /// <item><term>StablesMain</term><description>c9a942637a18f3f4abd9d8cf320c1120</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="unit">
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
    public TBuilder AddBuildingUnitGrowthIncrease(
        int? count = null,
        Blueprint<BlueprintUnitReference>? unit = null)
    {
      var component = new BuildingUnitGrowthIncrease();
      component.Count = count ?? component.Count;
      component.m_Unit = unit?.Reference ?? component.m_Unit;
      if (component.m_Unit is null)
      {
        component.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OncePerSettlementRestriction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Apothecary</term><description>ca05fbbbd02e4b1bae94446d60cbc739</description></item>
    /// <item><term>InfernalForgeImproved</term><description>49c4fef73ed44efab4fdde89b81bf31c</description></item>
    /// <item><term>Warehouse</term><description>ab509bc1202e3044ab58653230d66c1f</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddOncePerSettlementRestriction()
    {
      return AddComponent(new OncePerSettlementRestriction());
    }

    /// <summary>
    /// Adds <see cref="OtherBuildingRestriction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Inn</term><description>e036ddec60aa6c044a5830f2e1528329</description></item>
    /// <item><term>InnImproved</term><description>52df2fd2dad04409b68696edc5548a53</description></item>
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
    public TBuilder AddOtherBuildingRestriction(
        List<Blueprint<BlueprintSettlementBuildingReference>>? buildings = null,
        bool? invert = null,
        bool? requireAll = null)
    {
      var component = new OtherBuildingRestriction();
      component.Buildings = buildings?.Select(bp => bp.Reference)?.ToList() ?? component.Buildings;
      if (component.Buildings is null)
      {
        component.Buildings = new();
      }
      component.Invert = invert ?? component.Invert;
      component.RequireAll = requireAll ?? component.RequireAll;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpecificSettlementRestriction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Apothecary</term><description>ca05fbbbd02e4b1bae94446d60cbc739</description></item>
    /// <item><term>HallOfChampionsMain</term><description>72048521c14e4cdc8a82d94f99a056c7</description></item>
    /// <item><term>TrainingGroundsCapital</term><description>74e53dc8c8824430af8921967a5f1e4f</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="not">
    /// <para>
    /// InfoBox: If true, allows to build in any settlement except specified
    /// </para>
    /// </param>
    /// <param name="settlement">
    /// <para>
    /// Blueprint of type BlueprintSettlement. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddSpecificSettlementRestriction(
        bool? not = null,
        Blueprint<BlueprintSettlement.Reference>? settlement = null)
    {
      var component = new SpecificSettlementRestriction();
      component.m_Not = not ?? component.m_Not;
      component.m_Settlement = settlement?.Reference ?? component.m_Settlement;
      if (component.m_Settlement is null)
      {
        component.m_Settlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TeleportationCircle"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>TeleportationCircle</term><description>ea277e5efe3d4f459e74ea83d7a73d2f</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTeleportationCircle(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TeleportationCircle();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="UnlockRestriction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BlackMarket</term><description>df78001e89d3b2448baab7cd38c03a43</description></item>
    /// <item><term>Monument</term><description>50c8379f5a187374bbb9911a1fcaa198</description></item>
    /// <item><term>Warehouse</term><description>ab509bc1202e3044ab58653230d66c1f</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="flag">
    /// <para>
    /// Blueprint of type BlueprintUnlockableFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddUnlockRestriction(
        Blueprint<BlueprintUnlockableFlagReference>? flag = null,
        bool? mustBeLocked = null)
    {
      var component = new UnlockRestriction();
      component.m_Flag = flag?.Reference ?? component.m_Flag;
      if (component.m_Flag is null)
      {
        component.m_Flag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(null);
      }
      component.MustBeLocked = mustBeLocked ?? component.MustBeLocked;
      return AddComponent(component);
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

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Name is null)
      {
        Blueprint.Name = Utils.Constants.Empty.String;
      }
      if (Blueprint.Description is null)
      {
        Blueprint.Description = Utils.Constants.Empty.String;
      }
      if (Blueprint.MechanicalDescription is null)
      {
        Blueprint.MechanicalDescription = Utils.Constants.Empty.String;
      }
      if (Blueprint.CompletedPrefab is null)
      {
        Blueprint.CompletedPrefab = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.UnfinishedPrefab is null)
      {
        Blueprint.UnfinishedPrefab = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.m_UpgradesTo is null)
      {
        Blueprint.m_UpgradesTo = BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(null);
      }
    }
  }
}
