using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Armies.Components;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Armies.TacticalCombat.LeaderSkills;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Kingdom;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>Configurator for <see cref="BlueprintLeaderSkill"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintLeaderSkill))]
  public class LeaderSkillConfigurator : BaseBlueprintConfigurator<BlueprintLeaderSkill, LeaderSkillConfigurator>
  {
     private LeaderSkillConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static LeaderSkillConfigurator For(string name)
    {
      return new LeaderSkillConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static LeaderSkillConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintLeaderSkill>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static LeaderSkillConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintLeaderSkill>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="AddFactOnLeaderUnit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddFactOnLeaderUnit))]
    public LeaderSkillConfigurator AddAddFactOnLeaderUnit(
        string[] m_Facts)
    {
      
      var component =  new AddFactOnLeaderUnit();
      component.m_Facts = m_Facts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFactOnTacticalUnit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddFactOnTacticalUnit))]
    public LeaderSkillConfigurator AddAddFactOnTacticalUnit(
        string[] m_Facts,
        TargetFilter m_TargetController)
    {
      ValidateParam(m_TargetController);
      
      var component =  new AddFactOnTacticalUnit();
      component.m_Facts = m_Facts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.m_TargetController = m_TargetController;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CastOnTacticalCombatStart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_SpellToCast"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(CastOnTacticalCombatStart))]
    public LeaderSkillConfigurator AddCastOnTacticalCombatStart(
        string m_SpellToCast,
        bool m_TargetCell,
        List<int> m_AllowedColumns)
    {
      
      var component =  new CastOnTacticalCombatStart();
      component.m_SpellToCast = BlueprintTool.GetRef<BlueprintAbilityReference>(m_SpellToCast);
      component.m_TargetCell = m_TargetCell;
      component.m_AllowedColumns = m_AllowedColumns;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LeaderExpBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_BonusSkills"><see cref="BlueprintLeaderSkillsList"/></param>
    [Generated]
    [Implements(typeof(LeaderExpBonus))]
    public LeaderSkillConfigurator AddLeaderExpBonus(
        int m_BonusPercent,
        int m_LevelForBonusSkills,
        string m_BonusSkills)
    {
      
      var component =  new LeaderExpBonus();
      component.m_BonusPercent = m_BonusPercent;
      component.m_LevelForBonusSkills = m_LevelForBonusSkills;
      component.m_BonusSkills = BlueprintTool.GetRef<BlueprintLeaderSkillsList.Reference>(m_BonusSkills);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LeaderPercentAttributeBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LeaderPercentAttributeBonus))]
    public LeaderSkillConfigurator AddLeaderPercentAttributeBonus(
        LeaderAttributes m_PercentBonuses)
    {
      ValidateParam(m_PercentBonuses);
      
      var component =  new LeaderPercentAttributeBonus();
      component.m_PercentBonuses = m_PercentBonuses;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MaxArmySquadsBonusLeaderComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MaxArmySquadsBonusLeaderComponent))]
    public LeaderSkillConfigurator AddMaxArmySquadsBonusLeaderComponent(
        int m_ArmySizeBonus)
    {
      
      var component =  new MaxArmySquadsBonusLeaderComponent();
      component.m_ArmySizeBonus = m_ArmySizeBonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PlaceLeaderTrapOnCombatStart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_PossibleTrapSkills"><see cref="BlueprintLeaderSkill"/></param>
    [Generated]
    [Implements(typeof(PlaceLeaderTrapOnCombatStart))]
    public LeaderSkillConfigurator AddPlaceLeaderTrapOnCombatStart(
        string[] m_PossibleTrapSkills,
        List<int> m_AllowedColumns)
    {
      
      var component =  new PlaceLeaderTrapOnCombatStart();
      component.m_PossibleTrapSkills = m_PossibleTrapSkills.Select(bp => BlueprintTool.GetRef<BlueprintLeaderSkillReference>(bp)).ToArray();
      component.m_AllowedColumns = m_AllowedColumns;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemoveFactFromTacticalUnit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(RemoveFactFromTacticalUnit))]
    public LeaderSkillConfigurator AddRemoveFactFromTacticalUnit(
        string[] m_Facts,
        TargetFilter m_TargetController)
    {
      ValidateParam(m_TargetController);
      
      var component =  new RemoveFactFromTacticalUnit();
      component.m_Facts = m_Facts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.m_TargetController = m_TargetController;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SquadsActionOnTacticalCombatStart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_BannedFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SquadsActionOnTacticalCombatStart))]
    public LeaderSkillConfigurator AddSquadsActionOnTacticalCombatStart(
        TargetFilter m_Filter,
        string[] m_BannedFacts,
        int m_MaxSquadsCount,
        ActionsBuilder m_Actions)
    {
      ValidateParam(m_Filter);
      
      var component =  new SquadsActionOnTacticalCombatStart();
      component.m_Filter = m_Filter;
      component.m_BannedFacts = m_BannedFacts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToList();
      component.m_MaxSquadsCount = m_MaxSquadsCount;
      component.m_Actions = m_Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalLeaderRitualComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(TacticalLeaderRitualComponent))]
    public LeaderSkillConfigurator AddTacticalLeaderRitualComponent(
        string m_Ability)
    {
      
      var component =  new TacticalLeaderRitualComponent();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(m_Ability);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyLeaderAddResourcesOnBattleEnd"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyLeaderAddResourcesOnBattleEnd))]
    public LeaderSkillConfigurator AddArmyLeaderAddResourcesOnBattleEnd(
        KingdomResourcesAmount m_ResourcesAmount,
        bool OnlyOnVictory)
    {
      ValidateParam(m_ResourcesAmount);
      
      var component =  new ArmyLeaderAddResourcesOnBattleEnd();
      component.m_ResourcesAmount = m_ResourcesAmount;
      component.OnlyOnVictory = OnlyOnVictory;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalMoraleModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalMoraleModifier))]
    public LeaderSkillConfigurator AddTacticalMoraleModifier(
        TargetFilter m_TargetFilter,
        TacticalMoraleModifier.FactionTarget m_FactionTarget,
        int m_ModValue)
    {
      ValidateParam(m_TargetFilter);
      ValidateParam(m_FactionTarget);
      
      var component =  new TacticalMoraleModifier();
      component.m_TargetFilter = m_TargetFilter;
      component.m_FactionTarget = m_FactionTarget;
      component.m_ModValue = m_ModValue;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyGlobalMapMovementBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyGlobalMapMovementBonus))]
    public LeaderSkillConfigurator AddArmyGlobalMapMovementBonus(
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
