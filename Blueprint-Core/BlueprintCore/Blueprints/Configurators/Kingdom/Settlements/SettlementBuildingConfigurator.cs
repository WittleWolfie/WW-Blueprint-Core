using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Armies.Components;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Kingdom.Buffs;
using Kingmaker.Kingdom.Flags;
using Kingmaker.Kingdom.Settlements;
using Kingmaker.Kingdom.Settlements.BuildingComponents;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Alignments;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom.Settlements
{
  /// <summary>Configurator for <see cref="BlueprintSettlementBuilding"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintSettlementBuilding))]
  public class SettlementBuildingConfigurator : BaseFactConfigurator<BlueprintSettlementBuilding, SettlementBuildingConfigurator>
  {
     private SettlementBuildingConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SettlementBuildingConfigurator For(string name)
    {
      return new SettlementBuildingConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static SettlementBuildingConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintSettlementBuilding>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SettlementBuildingConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintSettlementBuilding>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="LocationRadiusBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(LocationRadiusBuff))]
    public SettlementBuildingConfigurator AddLocationRadiusBuff(
        float Radius,
        string m_Buff)
    {
      
      var component =  new LocationRadiusBuff();
      component.Radius = Radius;
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AdjacencyRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="Buildings"><see cref="BlueprintSettlementBuilding"/></param>
    [Generated]
    [Implements(typeof(AdjacencyRestriction))]
    public SettlementBuildingConfigurator AddAdjacencyRestriction(
        bool Invert,
        string[] Buildings)
    {
      
      var component =  new AdjacencyRestriction();
      component.Invert = Invert;
      component.Buildings = Buildings.Select(bp => BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(bp)).ToList();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AlignmentRestriction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AlignmentRestriction))]
    public SettlementBuildingConfigurator AddAlignmentRestriction(
        AlignmentMaskType Allowed)
    {
      ValidateParam(Allowed);
      
      var component =  new AlignmentRestriction();
      component.Allowed = Allowed;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArtisanRestriction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArtisanRestriction))]
    public SettlementBuildingConfigurator AddArtisanRestriction()
    {
      return AddComponent(new ArtisanRestriction());
    }

    /// <summary>
    /// Adds <see cref="Aviary"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Aviary))]
    public SettlementBuildingConfigurator AddAviary()
    {
      return AddComponent(new Aviary());
    }

    /// <summary>
    /// Adds <see cref="BuildingAdjacencyBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="Buildings"><see cref="BlueprintSettlementBuilding"/></param>
    [Generated]
    [Implements(typeof(BuildingAdjacencyBonus))]
    public SettlementBuildingConfigurator AddBuildingAdjacencyBonus(
        bool NoSuchBuildings,
        BuildingAdjacencyBonus.DistanceRequirementType Distance,
        BuildingAdjacencyBonus.CalculationType Calculation,
        KingdomStats.Changes Stats,
        bool AnyBuilding,
        string[] Buildings)
    {
      ValidateParam(Distance);
      ValidateParam(Calculation);
      ValidateParam(Stats);
      
      var component =  new BuildingAdjacencyBonus();
      component.NoSuchBuildings = NoSuchBuildings;
      component.Distance = Distance;
      component.Calculation = Calculation;
      component.Stats = Stats;
      component.AnyBuilding = AnyBuilding;
      component.Buildings = Buildings.Select(bp => BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(bp)).ToList();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingAdjacentGrowthIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuildingAdjacentGrowthIncrease))]
    public SettlementBuildingConfigurator AddBuildingAdjacentGrowthIncrease(
        bool AllUnits,
        ArmyProperties Properties,
        BuildingAdjacencyBonus.DistanceRequirementType Distance,
        int BonusPercent)
    {
      ValidateParam(Properties);
      ValidateParam(Distance);
      
      var component =  new BuildingAdjacentGrowthIncrease();
      component.AllUnits = AllUnits;
      component.Properties = Properties;
      component.Distance = Distance;
      component.BonusPercent = BonusPercent;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingAdjacentResourceIncrease"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_SpecificBuilding"><see cref="BlueprintSettlementBuilding"/></param>
    [Generated]
    [Implements(typeof(BuildingAdjacentResourceIncrease))]
    public SettlementBuildingConfigurator AddBuildingAdjacentResourceIncrease(
        int FinanceModifier,
        int BasicsModifier,
        int FavorsModifier,
        string m_SpecificBuilding,
        BuildingAdjacencyBonus.DistanceRequirementType Distance,
        int BonusPercent)
    {
      ValidateParam(Distance);
      
      var component =  new BuildingAdjacentResourceIncrease();
      component.FinanceModifier = FinanceModifier;
      component.BasicsModifier = BasicsModifier;
      component.FavorsModifier = FavorsModifier;
      component.m_SpecificBuilding = BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(m_SpecificBuilding);
      component.Distance = Distance;
      component.BonusPercent = BonusPercent;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingAttachedBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintKingdomBuff"/></param>
    [Generated]
    [Implements(typeof(BuildingAttachedBuff))]
    public SettlementBuildingConfigurator AddBuildingAttachedBuff(
        string m_Buff,
        bool m_OnlyInRegion)
    {
      
      var component =  new BuildingAttachedBuff();
      component.m_Buff = BlueprintTool.GetRef<BlueprintKingdomBuffReference>(m_Buff);
      component.m_OnlyInRegion = m_OnlyInRegion;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingCountsAs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="Buildings"><see cref="BlueprintSettlementBuilding"/></param>
    [Generated]
    [Implements(typeof(BuildingCountsAs))]
    public SettlementBuildingConfigurator AddBuildingCountsAs(
        string[] Buildings)
    {
      
      var component =  new BuildingCountsAs();
      component.Buildings = Buildings.Select(bp => BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(bp)).ToList();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingGlobalGrowthIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuildingGlobalGrowthIncrease))]
    public SettlementBuildingConfigurator AddBuildingGlobalGrowthIncrease(
        bool AllUnits,
        ArmyProperties Properties,
        int BonusPercent)
    {
      ValidateParam(Properties);
      
      var component =  new BuildingGlobalGrowthIncrease();
      component.AllUnits = AllUnits;
      component.Properties = Properties;
      component.BonusPercent = BonusPercent;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingLoneSlotBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuildingLoneSlotBonus))]
    public SettlementBuildingConfigurator AddBuildingLoneSlotBonus(
        KingdomStats.Changes Stats)
    {
      ValidateParam(Stats);
      
      var component =  new BuildingLoneSlotBonus();
      component.Stats = Stats;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingMoraleChangeBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuildingMoraleChangeBonus))]
    public SettlementBuildingConfigurator AddBuildingMoraleChangeBonus(
        bool Negative,
        bool Positive,
        int PercentBonus,
        int FlatBonus)
    {
      
      var component =  new BuildingMoraleChangeBonus();
      component.Negative = Negative;
      component.Positive = Positive;
      component.PercentBonus = PercentBonus;
      component.FlatBonus = FlatBonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingPartOfQuestObjective"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buildings"><see cref="BlueprintSettlementBuilding"/></param>
    /// <param name="m_Objective"><see cref="BlueprintQuestObjective"/></param>
    [Generated]
    [Implements(typeof(BuildingPartOfQuestObjective))]
    public SettlementBuildingConfigurator AddBuildingPartOfQuestObjective(
        string[] m_Buildings,
        string m_Objective)
    {
      
      var component =  new BuildingPartOfQuestObjective();
      component.m_Buildings = m_Buildings.Select(bp => BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(bp)).ToArray();
      component.m_Objective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(m_Objective);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingResourceGrowthGlobalIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuildingResourceGrowthGlobalIncrease))]
    public SettlementBuildingConfigurator AddBuildingResourceGrowthGlobalIncrease(
        int Modifier,
        int FinanceModifier,
        int BasicsModifier,
        int FavorsModifier)
    {
      
      var component =  new BuildingResourceGrowthGlobalIncrease();
      component.Modifier = Modifier;
      component.FinanceModifier = FinanceModifier;
      component.BasicsModifier = BasicsModifier;
      component.FavorsModifier = FavorsModifier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingResourceGrowthIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuildingResourceGrowthIncrease))]
    public SettlementBuildingConfigurator AddBuildingResourceGrowthIncrease(
        KingdomResourcesAmount ResourcesAmount)
    {
      ValidateParam(ResourcesAmount);
      
      var component =  new BuildingResourceGrowthIncrease();
      component.ResourcesAmount = ResourcesAmount;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingSiegeDurationIncrease"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_AffectedFlags"><see cref="BlueprintKingdomMoraleFlag"/></param>
    [Generated]
    [Implements(typeof(BuildingSiegeDurationIncrease))]
    public SettlementBuildingConfigurator AddBuildingSiegeDurationIncrease(
        int DurationDeltaInDays,
        string[] m_AffectedFlags)
    {
      
      var component =  new BuildingSiegeDurationIncrease();
      component.DurationDeltaInDays = DurationDeltaInDays;
      component.m_AffectedFlags = m_AffectedFlags.Select(bp => BlueprintTool.GetRef<BlueprintKingdomMoraleFlag.Reference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingTacticalUnitFactBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Features"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(BuildingTacticalUnitFactBonus))]
    public SettlementBuildingConfigurator AddBuildingTacticalUnitFactBonus(
        BuildingTacticalUnitFactBonus.DistanceType m_Distance,
        string[] m_Features,
        bool m_OnlyForCurrentRegion)
    {
      ValidateParam(m_Distance);
      
      var component =  new BuildingTacticalUnitFactBonus();
      component.m_Distance = m_Distance;
      component.m_Features = m_Features.Select(bp => BlueprintTool.GetRef<BlueprintFeatureReference>(bp)).ToArray();
      component.m_OnlyForCurrentRegion = m_OnlyForCurrentRegion;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingUnitGrowthIncrease"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Unit"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(BuildingUnitGrowthIncrease))]
    public SettlementBuildingConfigurator AddBuildingUnitGrowthIncrease(
        string m_Unit,
        int Count)
    {
      
      var component =  new BuildingUnitGrowthIncrease();
      component.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(m_Unit);
      component.Count = Count;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingUpgradeBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_UpgradeProject"><see cref="BlueprintKingdomUpgrade"/></param>
    [Generated]
    [Implements(typeof(BuildingUpgradeBonus))]
    public SettlementBuildingConfigurator AddBuildingUpgradeBonus(
        KingdomStats.Changes Stats,
        string m_UpgradeProject,
        BuildingUpgradeBonus.RegionApplicabilityType Region)
    {
      ValidateParam(Stats);
      ValidateParam(Region);
      
      var component =  new BuildingUpgradeBonus();
      component.Stats = Stats;
      component.m_UpgradeProject = BlueprintTool.GetRef<BlueprintKingdomUpgradeReference>(m_UpgradeProject);
      component.Region = Region;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CaptalLevelRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Settlement"><see cref="BlueprintSettlement"/></param>
    [Generated]
    [Implements(typeof(CaptalLevelRestriction))]
    public SettlementBuildingConfigurator AddCaptalLevelRestriction(
        string m_Settlement,
        SettlementState.LevelType Level)
    {
      ValidateParam(Level);
      
      var component =  new CaptalLevelRestriction();
      component.m_Settlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(m_Settlement);
      component.Level = Level;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DLCRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_DlcReward"><see cref="BlueprintDlcReward"/></param>
    [Generated]
    [Implements(typeof(DLCRestriction))]
    public SettlementBuildingConfigurator AddDLCRestriction(
        string m_DlcReward)
    {
      
      var component =  new DLCRestriction();
      component.m_DlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(m_DlcReward);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LoneSlotRestriction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LoneSlotRestriction))]
    public SettlementBuildingConfigurator AddLoneSlotRestriction()
    {
      return AddComponent(new LoneSlotRestriction());
    }

    /// <summary>
    /// Adds <see cref="OncePerSettlementRestriction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OncePerSettlementRestriction))]
    public SettlementBuildingConfigurator AddOncePerSettlementRestriction()
    {
      return AddComponent(new OncePerSettlementRestriction());
    }

    /// <summary>
    /// Adds <see cref="OtherBuildingRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="Buildings"><see cref="BlueprintSettlementBuilding"/></param>
    [Generated]
    [Implements(typeof(OtherBuildingRestriction))]
    public SettlementBuildingConfigurator AddOtherBuildingRestriction(
        bool Invert,
        bool RequireAll,
        string[] Buildings)
    {
      
      var component =  new OtherBuildingRestriction();
      component.Invert = Invert;
      component.RequireAll = RequireAll;
      component.Buildings = Buildings.Select(bp => BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(bp)).ToList();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ProjectRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Projects"><see cref="BlueprintKingdomProject"/></param>
    [Generated]
    [Implements(typeof(ProjectRestriction))]
    public SettlementBuildingConfigurator AddProjectRestriction(
        string[] m_Projects)
    {
      
      var component =  new ProjectRestriction();
      component.m_Projects = m_Projects.Select(bp => BlueprintTool.GetRef<BlueprintKingdomProjectReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpecificSettlementRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Settlement"><see cref="BlueprintSettlement"/></param>
    [Generated]
    [Implements(typeof(SpecificSettlementRestriction))]
    public SettlementBuildingConfigurator AddSpecificSettlementRestriction(
        string m_Settlement,
        bool m_Not)
    {
      
      var component =  new SpecificSettlementRestriction();
      component.m_Settlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(m_Settlement);
      component.m_Not = m_Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="StatRankRestriction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(StatRankRestriction))]
    public SettlementBuildingConfigurator AddStatRankRestriction(
        KingdomStats.Type Stat,
        int Rank,
        bool AtMost)
    {
      ValidateParam(Stat);
      
      var component =  new StatRankRestriction();
      component.Stat = Stat;
      component.Rank = Rank;
      component.AtMost = AtMost;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TeleportationCircle"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TeleportationCircle))]
    public SettlementBuildingConfigurator AddTeleportationCircle()
    {
      return AddComponent(new TeleportationCircle());
    }

    /// <summary>
    /// Adds <see cref="UnlockRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Flag"><see cref="BlueprintUnlockableFlag"/></param>
    [Generated]
    [Implements(typeof(UnlockRestriction))]
    public SettlementBuildingConfigurator AddUnlockRestriction(
        string m_Flag,
        bool MustBeLocked)
    {
      
      var component =  new UnlockRestriction();
      component.m_Flag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(m_Flag);
      component.MustBeLocked = MustBeLocked;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BirthdayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BirthdayTrigger))]
    public SettlementBuildingConfigurator AddBirthdayTrigger(
        ConditionsBuilder Condition,
        ActionsBuilder Actions)
    {
      
      var component =  new BirthdayTrigger();
      component.Condition = Condition.Build();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EventResolutonTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_OnlySpecificLeader"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(EventResolutonTrigger))]
    public SettlementBuildingConfigurator AddEventResolutonTrigger(
        bool ApplyToProblems,
        bool ApplyToOpportunities,
        bool OnlyInRegion,
        EventResult.MarginType OnMargin,
        BlueprintKingdomEvent.TagList RequiredTags,
        LeaderType OnlyLeader,
        string m_OnlySpecificLeader,
        ConditionsBuilder Condition,
        ActionsBuilder Action)
    {
      ValidateParam(OnMargin);
      foreach (var item in RequiredTags)
      {
        ValidateParam(item);
      }
      ValidateParam(OnlyLeader);
      
      var component =  new EventResolutonTrigger();
      component.ApplyToProblems = ApplyToProblems;
      component.ApplyToOpportunities = ApplyToOpportunities;
      component.OnlyInRegion = OnlyInRegion;
      component.OnMargin = OnMargin;
      component.RequiredTags = RequiredTags;
      component.OnlyLeader = OnlyLeader;
      component.m_OnlySpecificLeader = BlueprintTool.GetRef<BlueprintUnitReference>(m_OnlySpecificLeader);
      component.Condition = Condition.Build();
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EventStartTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EventStartTrigger))]
    public SettlementBuildingConfigurator AddEventStartTrigger(
        bool ApplyToProblems,
        bool ApplyToOpportunities,
        BlueprintKingdomEvent.TagList RequiredTags,
        ConditionsBuilder Condition,
        ActionsBuilder Action)
    {
      foreach (var item in RequiredTags)
      {
        ValidateParam(item);
      }
      
      var component =  new EventStartTrigger();
      component.ApplyToProblems = ApplyToProblems;
      component.ApplyToOpportunities = ApplyToOpportunities;
      component.RequiredTags = RequiredTags;
      component.Condition = Condition.Build();
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryDayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EveryDayTrigger))]
    public SettlementBuildingConfigurator AddEveryDayTrigger(
        ConditionsBuilder Condition,
        ActionsBuilder Actions,
        int SkipDays)
    {
      
      var component =  new EveryDayTrigger();
      component.Condition = Condition.Build();
      component.Actions = Actions.Build();
      component.SkipDays = SkipDays;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryWeekTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EveryWeekTrigger))]
    public SettlementBuildingConfigurator AddEveryWeekTrigger(
        ConditionsBuilder Condition,
        ActionsBuilder Actions,
        int SkipWeeks)
    {
      
      var component =  new EveryWeekTrigger();
      component.Condition = Condition.Build();
      component.Actions = Actions.Build();
      component.SkipWeeks = SkipWeeks;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomAddMercenaryReroll"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomAddMercenaryReroll))]
    public SettlementBuildingConfigurator AddKingdomAddMercenaryReroll(
        int m_FreeRerollsToAdd)
    {
      
      var component =  new KingdomAddMercenaryReroll();
      component.m_FreeRerollsToAdd = m_FreeRerollsToAdd;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomAddMercenarySlot"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomAddMercenarySlot))]
    public SettlementBuildingConfigurator AddKingdomAddMercenarySlot(
        int m_SlotsToAdd)
    {
      
      var component =  new KingdomAddMercenarySlot();
      component.m_SlotsToAdd = m_SlotsToAdd;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomConditionalStatChange"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomConditionalStatChange))]
    public SettlementBuildingConfigurator AddKingdomConditionalStatChange(
        ConditionsBuilder Condition,
        KingdomStats.Changes Stats)
    {
      ValidateParam(Stats);
      
      var component =  new KingdomConditionalStatChange();
      component.Condition = Condition.Build();
      component.Stats = Stats;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomEventFixedBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomEventFixedBonus))]
    public SettlementBuildingConfigurator AddKingdomEventFixedBonus(
        LeaderType Leader,
        int LeaderBonus)
    {
      ValidateParam(Leader);
      
      var component =  new KingdomEventFixedBonus();
      component.Leader = Leader;
      component.LeaderBonus = LeaderBonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomEventModifier"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_OnlySpecificLeader"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(KingdomEventModifier))]
    public SettlementBuildingConfigurator AddKingdomEventModifier(
        bool ApplyToProblems,
        bool ApplyToOpportunities,
        bool OnlyInRegion,
        bool IncludeAdjacent,
        BlueprintKingdomEvent.TagList RequiredTags,
        LeaderType OnlyLeader,
        string m_OnlySpecificLeader,
        ConditionsBuilder Condition,
        bool IsRoll,
        int Value,
        DiceFormula Dice,
        bool OnlyPositive,
        bool OnlyNegative,
        bool AddReroll,
        bool AddDisadvantage)
    {
      foreach (var item in RequiredTags)
      {
        ValidateParam(item);
      }
      ValidateParam(OnlyLeader);
      ValidateParam(Dice);
      
      var component =  new KingdomEventModifier();
      component.ApplyToProblems = ApplyToProblems;
      component.ApplyToOpportunities = ApplyToOpportunities;
      component.OnlyInRegion = OnlyInRegion;
      component.IncludeAdjacent = IncludeAdjacent;
      component.RequiredTags = RequiredTags;
      component.OnlyLeader = OnlyLeader;
      component.m_OnlySpecificLeader = BlueprintTool.GetRef<BlueprintUnitReference>(m_OnlySpecificLeader);
      component.Condition = Condition.Build();
      component.IsRoll = IsRoll;
      component.Value = Value;
      component.Dice = Dice;
      component.OnlyPositive = OnlyPositive;
      component.OnlyNegative = OnlyNegative;
      component.AddReroll = AddReroll;
      component.AddDisadvantage = AddDisadvantage;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomUnrestChangeTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomUnrestChangeTrigger))]
    public SettlementBuildingConfigurator AddKingdomUnrestChangeTrigger(
        ConditionsBuilder Condition,
        ActionsBuilder Action)
    {
      
      var component =  new KingdomUnrestChangeTrigger();
      component.Condition = Condition.Build();
      component.Action = Action.Build();
      return AddComponent(component);
    }
  }
}
