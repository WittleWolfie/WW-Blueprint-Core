using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Armies.Components;
using Kingmaker.Blueprints;
using Kingmaker.Crusade.GlobalMagic;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Armies;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Kingdom.Buffs;
using Kingmaker.Kingdom.Settlements.BuildingComponents;
using Kingmaker.RuleSystem;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>Configurator for <see cref="BlueprintKingdomBuff"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomBuff))]
  public class KingdomBuffConfigurator : BaseFactConfigurator<BlueprintKingdomBuff, KingdomBuffConfigurator>
  {
     private KingdomBuffConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomBuffConfigurator For(string name)
    {
      return new KingdomBuffConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static KingdomBuffConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintKingdomBuff>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomBuffConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintKingdomBuff>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="ChangeGlobalMagicPower"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeGlobalMagicPower))]
    public KingdomBuffConfigurator AddChangeGlobalMagicPower(
        GlobalMagicValue m_ChangeValue)
    {
      ValidateParam(m_ChangeValue);
      
      var component =  new ChangeGlobalMagicPower();
      component.m_ChangeValue = m_ChangeValue;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomUnitsGrowthIncrease"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="Units"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(KingdomUnitsGrowthIncrease))]
    public KingdomBuffConfigurator AddKingdomUnitsGrowthIncrease(
        bool AllUnits,
        ArmyProperties Properties,
        KingdomUnitsGrowthIncrease.UnitListOperation Operation,
        string[] Units,
        int BonusPercent)
    {
      ValidateParam(Properties);
      ValidateParam(Operation);
      
      var component =  new KingdomUnitsGrowthIncrease();
      component.AllUnits = AllUnits;
      component.Properties = Properties;
      component.Operation = Operation;
      component.Units = Units.Select(bp => BlueprintTool.GetRef<BlueprintUnitReference>(bp)).ToList();
      component.BonusPercent = BonusPercent;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BirthdayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BirthdayTrigger))]
    public KingdomBuffConfigurator AddBirthdayTrigger(
        ConditionsBuilder Condition,
        ActionsBuilder Actions)
    {
      
      var component =  new BirthdayTrigger();
      component.Condition = Condition.Build();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingCostModifier"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="Buildings"><see cref="BlueprintSettlementBuilding"/></param>
    [Generated]
    [Implements(typeof(BuildingCostModifier))]
    public KingdomBuffConfigurator AddBuildingCostModifier(
        float Modifier,
        string[] Buildings)
    {
      
      var component =  new BuildingCostModifier();
      component.Modifier = Modifier;
      component.Buildings = Buildings.Select(bp => BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(bp)).ToList();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingSequenceCostMultiplierReduce"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="Buildings"><see cref="BlueprintSettlementBuilding"/></param>
    [Generated]
    [Implements(typeof(BuildingSequenceCostMultiplierReduce))]
    public KingdomBuffConfigurator AddBuildingSequenceCostMultiplierReduce(
        float ReduceMultiplierBy,
        string[] Buildings)
    {
      
      var component =  new BuildingSequenceCostMultiplierReduce();
      component.ReduceMultiplierBy = ReduceMultiplierBy;
      component.Buildings = Buildings.Select(bp => BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(bp)).ToList();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_SpecificSettlement"><see cref="BlueprintRegion"/></param>
    /// <param name="m_SpecificBuilding"><see cref="BlueprintSettlementBuilding"/></param>
    [Generated]
    [Implements(typeof(BuildingTrigger))]
    public KingdomBuffConfigurator AddBuildingTrigger(
        string m_SpecificSettlement,
        string m_SpecificBuilding,
        int AtLeastThisManyBuildings,
        ConditionsBuilder Condition,
        ActionsBuilder Actions)
    {
      
      var component =  new BuildingTrigger();
      component.m_SpecificSettlement = BlueprintTool.GetRef<BlueprintRegionReference>(m_SpecificSettlement);
      component.m_SpecificBuilding = BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(m_SpecificBuilding);
      component.AtLeastThisManyBuildings = AtLeastThisManyBuildings;
      component.Condition = Condition.Build();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeKingdomMoraleMinimum"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeKingdomMoraleMinimum))]
    public KingdomBuffConfigurator AddChangeKingdomMoraleMinimum(
        int m_MinValueDelta)
    {
      
      var component =  new ChangeKingdomMoraleMinimum();
      component.m_MinValueDelta = m_MinValueDelta;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EventResolutonTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_OnlySpecificLeader"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(EventResolutonTrigger))]
    public KingdomBuffConfigurator AddEventResolutonTrigger(
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
    public KingdomBuffConfigurator AddEventStartTrigger(
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
    public KingdomBuffConfigurator AddEveryDayTrigger(
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
    public KingdomBuffConfigurator AddEveryWeekTrigger(
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
    /// Adds <see cref="GlobalArmiesMoraleModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GlobalArmiesMoraleModifier))]
    public KingdomBuffConfigurator AddGlobalArmiesMoraleModifier(
        ArmyFaction m_Faction,
        int m_MoraleModifier)
    {
      ValidateParam(m_Faction);
      
      var component =  new GlobalArmiesMoraleModifier();
      component.m_Faction = m_Faction;
      component.m_MoraleModifier = m_MoraleModifier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomAddMercenaryReroll"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomAddMercenaryReroll))]
    public KingdomBuffConfigurator AddKingdomAddMercenaryReroll(
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
    public KingdomBuffConfigurator AddKingdomAddMercenarySlot(
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
    public KingdomBuffConfigurator AddKingdomConditionalStatChange(
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
    public KingdomBuffConfigurator AddKingdomEventFixedBonus(
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
    public KingdomBuffConfigurator AddKingdomEventModifier(
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
    /// Adds <see cref="KingdomIncomeModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomIncomeModifier))]
    public KingdomBuffConfigurator AddKingdomIncomeModifier(
        int Modifier,
        int FinanceModifier,
        int BasicsModifier,
        int FavorsModifier)
    {
      
      var component =  new KingdomIncomeModifier();
      component.Modifier = Modifier;
      component.FinanceModifier = FinanceModifier;
      component.BasicsModifier = BasicsModifier;
      component.FavorsModifier = FavorsModifier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomIncomePerSettlement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomIncomePerSettlement))]
    public KingdomBuffConfigurator AddKingdomIncomePerSettlement(
        KingdomResourcesAmount ResourcesPerVillage,
        KingdomResourcesAmount ResourcesPerTown,
        KingdomResourcesAmount ResourcesPerCity)
    {
      ValidateParam(ResourcesPerVillage);
      ValidateParam(ResourcesPerTown);
      ValidateParam(ResourcesPerCity);
      
      var component =  new KingdomIncomePerSettlement();
      component.ResourcesPerVillage = ResourcesPerVillage;
      component.ResourcesPerTown = ResourcesPerTown;
      component.ResourcesPerCity = ResourcesPerCity;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomIncomePerStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomIncomePerStat))]
    public KingdomBuffConfigurator AddKingdomIncomePerStat(
        KingdomResourcesAmount ResourcesPerRank,
        KingdomStats.Type Stat)
    {
      ValidateParam(ResourcesPerRank);
      ValidateParam(Stat);
      
      var component =  new KingdomIncomePerStat();
      component.ResourcesPerRank = ResourcesPerRank;
      component.Stat = Stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomIncomePerUnrest"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomIncomePerUnrest))]
    public KingdomBuffConfigurator AddKingdomIncomePerUnrest(
        KingdomResourcesAmount ResourcesPerUnrest)
    {
      ValidateParam(ResourcesPerUnrest);
      
      var component =  new KingdomIncomePerUnrest();
      component.ResourcesPerUnrest = ResourcesPerUnrest;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomMoraleEffectMultiplier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomMoraleEffectMultiplier))]
    public KingdomBuffConfigurator AddKingdomMoraleEffectMultiplier(
        float IncomeMultiplier,
        float UnitMultiplier)
    {
      
      var component =  new KingdomMoraleEffectMultiplier();
      component.IncomeMultiplier = IncomeMultiplier;
      component.UnitMultiplier = UnitMultiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomMoraleForArmies"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomMoraleForArmies))]
    public KingdomBuffConfigurator AddKingdomMoraleForArmies(
        ArmyFaction m_Faction,
        float m_Multiplier)
    {
      ValidateParam(m_Faction);
      
      var component =  new KingdomMoraleForArmies();
      component.m_Faction = m_Faction;
      component.m_Multiplier = m_Multiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomTacticalArmyFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_ArmyUnits"><see cref="BlueprintUnit"/></param>
    /// <param name="m_Features"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(KingdomTacticalArmyFeature))]
    public KingdomBuffConfigurator AddKingdomTacticalArmyFeature(
        MercenariesIncludeOption m_MercenariesFilter,
        bool m_ByTag,
        ArmyProperties m_ArmyTag,
        bool m_ByUnits,
        string[] m_ArmyUnits,
        string[] m_Features,
        ArmyFaction m_Faction)
    {
      ValidateParam(m_MercenariesFilter);
      ValidateParam(m_ArmyTag);
      ValidateParam(m_Faction);
      
      var component =  new KingdomTacticalArmyFeature();
      component.m_MercenariesFilter = m_MercenariesFilter;
      component.m_ByTag = m_ByTag;
      component.m_ArmyTag = m_ArmyTag;
      component.m_ByUnits = m_ByUnits;
      component.m_ArmyUnits = m_ArmyUnits.Select(bp => BlueprintTool.GetRef<BlueprintUnitReference>(bp)).ToArray();
      component.m_Features = m_Features.Select(bp => BlueprintTool.GetRef<BlueprintFeatureReference>(bp)).ToArray();
      component.m_Faction = m_Faction;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomUnrestChangeTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomUnrestChangeTrigger))]
    public KingdomBuffConfigurator AddKingdomUnrestChangeTrigger(
        ConditionsBuilder Condition,
        ActionsBuilder Action)
    {
      
      var component =  new KingdomUnrestChangeTrigger();
      component.Condition = Condition.Build();
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MaxArmySquadsBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MaxArmySquadsBonus))]
    public KingdomBuffConfigurator AddMaxArmySquadsBonus(
        int m_Bonus)
    {
      
      var component =  new MaxArmySquadsBonus();
      component.m_Bonus = m_Bonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecruitCostModifier"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="Units"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(RecruitCostModifier))]
    public KingdomBuffConfigurator AddRecruitCostModifier(
        float Modifier,
        bool AllUnits,
        MercenariesIncludeOption MercenariesFilter,
        ArmyProperties Properties,
        KingdomUnitsGrowthIncrease.UnitListOperation Operation,
        string[] Units)
    {
      ValidateParam(MercenariesFilter);
      ValidateParam(Properties);
      ValidateParam(Operation);
      
      var component =  new RecruitCostModifier();
      component.Modifier = Modifier;
      component.AllUnits = AllUnits;
      component.MercenariesFilter = MercenariesFilter;
      component.Properties = Properties;
      component.Operation = Operation;
      component.Units = Units.Select(bp => BlueprintTool.GetRef<BlueprintUnitReference>(bp)).ToList();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecruitDisable"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecruitDisable))]
    public KingdomBuffConfigurator AddRecruitDisable()
    {
      return AddComponent(new RecruitDisable());
    }

    /// <summary>
    /// Adds <see cref="RegionBasedPartyBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(RegionBasedPartyBuff))]
    public KingdomBuffConfigurator AddRegionBasedPartyBuff(
        RegionBasedPartyBuff.TargetType Target,
        string m_Buff)
    {
      ValidateParam(Target);
      
      var component =  new RegionBasedPartyBuff();
      component.Target = Target;
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SettlementTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_SpecificSettlement"><see cref="BlueprintSettlement"/></param>
    [Generated]
    [Implements(typeof(SettlementTrigger))]
    public KingdomBuffConfigurator AddSettlementTrigger(
        string m_SpecificSettlement,
        ConditionsBuilder Condition,
        ActionsBuilder Actions)
    {
      
      var component =  new SettlementTrigger();
      component.m_SpecificSettlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(m_SpecificSettlement);
      component.Condition = Condition.Build();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomStatFromCrusadeResources"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomStatFromCrusadeResources))]
    public KingdomBuffConfigurator AddKingdomStatFromCrusadeResources(
        KingdomStats.Type m_Stat,
        float m_StatPerFinances,
        float m_StatPerMaterials,
        float m_StatPerFavors)
    {
      ValidateParam(m_Stat);
      
      var component =  new KingdomStatFromCrusadeResources();
      component.m_Stat = m_Stat;
      component.m_StatPerFinances = m_StatPerFinances;
      component.m_StatPerMaterials = m_StatPerMaterials;
      component.m_StatPerFavors = m_StatPerFavors;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomStatFromLeaderExperience"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomStatFromLeaderExperience))]
    public KingdomBuffConfigurator AddKingdomStatFromLeaderExperience(
        KingdomStats.Type m_Stat,
        float m_StatPerLeaderExperience)
    {
      ValidateParam(m_Stat);
      
      var component =  new KingdomStatFromLeaderExperience();
      component.m_Stat = m_Stat;
      component.m_StatPerLeaderExperience = m_StatPerLeaderExperience;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomStatFromRecruitment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomStatFromRecruitment))]
    public KingdomBuffConfigurator AddKingdomStatFromRecruitment(
        KingdomStats.Type m_Stat,
        float m_StatPerExp)
    {
      ValidateParam(m_Stat);
      
      var component =  new KingdomStatFromRecruitment();
      component.m_Stat = m_Stat;
      component.m_StatPerExp = m_StatPerExp;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomGainSkillToLeaders"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Skill"><see cref="BlueprintLeaderSkill"/></param>
    /// <param name="m_SkillsList"><see cref="BlueprintLeaderSkill"/></param>
    [Generated]
    [Implements(typeof(KingdomGainSkillToLeaders))]
    public KingdomBuffConfigurator AddKingdomGainSkillToLeaders(
        ArmyFaction m_TargetFactions,
        int m_MinLevel,
        string m_Skill,
        bool m_UseSkillsList,
        string[] m_SkillsList)
    {
      ValidateParam(m_TargetFactions);
      
      var component =  new KingdomGainSkillToLeaders();
      component.m_TargetFactions = m_TargetFactions;
      component.m_MinLevel = m_MinLevel;
      component.m_Skill = BlueprintTool.GetRef<BlueprintLeaderSkillReference>(m_Skill);
      component.m_UseSkillsList = m_UseSkillsList;
      component.m_SkillsList = m_SkillsList.Select(bp => BlueprintTool.GetRef<BlueprintLeaderSkillReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyGlobalMapMovementBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyGlobalMapMovementBonus))]
    public KingdomBuffConfigurator AddArmyGlobalMapMovementBonus(
        int DailyMovementPoints,
        int MaxMovementPoints)
    {
      
      var component =  new ArmyGlobalMapMovementBonus();
      component.DailyMovementPoints = DailyMovementPoints;
      component.MaxMovementPoints = MaxMovementPoints;
      return AddComponent(component);
    }
  }
}
