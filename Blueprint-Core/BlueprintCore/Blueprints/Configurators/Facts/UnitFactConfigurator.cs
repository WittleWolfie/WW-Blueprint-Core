using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Formations.Facts;
using Kingmaker.Kingdom;
using Kingmaker.Localization;
using Kingmaker.Settings;
using Kingmaker.UI.MVVM._VM.ServiceWindows.LocalMap.Utils;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Parts;
using System;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Facts
{
  /// <summary>
  /// Implements common fields and component support for blueprints inheriting from <see cref="BlueprintUnitFact"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnitFact))]
  public abstract class BaseUnitFactConfigurator<T, TBuilder> : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintUnitFact
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
    protected BaseUnitFactConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintUnitFact.m_DisplayName"/>
    /// </summary>
    public TBuilder SetDisplayName(LocalizedString name)
    {
      OnConfigureInternal(blueprint => blueprint.m_DisplayName = name);
      return Self;
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnitFact.m_Description"/>
    /// </summary>
    public TBuilder SetDescription(LocalizedString description)
    {
      OnConfigureInternal(blueprint => blueprint.m_Description = description);
      return Self;
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnitFact.m_DescriptionShort"/>
    /// </summary>
    public TBuilder SetDescriptionShort(LocalizedString description)
    {
      OnConfigureInternal(blueprint => blueprint.m_DescriptionShort = description);
      return Self;
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnitFact.m_Icon"/>
    /// </summary>
    public TBuilder SetIcon(Sprite icon)
    {
      OnConfigureInternal(blueprint => blueprint.m_Icon = icon);
      return Self;
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.UnitLogic.FactLogic.AddFacts">AddFacts</see>
    /// </summary>
    /// 
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    public TBuilder AddFacts(
        string[] facts,
        int casterLevel = 0,
        bool hasDifficultyRequirements = false,
        bool invertDifficultyRequirements = false,
        GameDifficultyOption minDifficulty = GameDifficultyOption.Story)
    {
      var addFacts = new AddFacts
      {
        m_Facts =
            facts.Select(fact => BlueprintTool.GetRef<BlueprintUnitFactReference>(fact)).ToArray(),
        CasterLevel = casterLevel,
        HasDifficultyRequirements = hasDifficultyRequirements,
        InvertDifficultyRequirements = invertDifficultyRequirements,
        MinDifficulty = minDifficulty
      };
      return AddComponent(addFacts);
    }

    /// <summary>
    /// Adds <see cref="AddInitiatorSkillRollTrigger"/>
    /// </summary>
    public TBuilder OnSkillCheck(
        StatType skill, ActionsBuilder actions, bool onlySuccess = true)
    {
      var trigger = new AddInitiatorSkillRollTrigger
      {
        OnlySuccess = onlySuccess,
        Skill = skill,
        Action = actions.Build()
      };
      return AddComponent(trigger);
    }


    /// <summary>
    /// Adds <see cref="FormationACBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Property"><see cref="BlueprintUnitProperty"/></param>
    /// <param name="m_IgnoreIfHasAnyFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(FormationACBonus))]
    public TBuilder AddFormationACBonus(
        bool UnitProperty,
        int Bonus,
        string m_Property,
        string[] m_IgnoreIfHasAnyFact)
    {
      
      var component =  new FormationACBonus();
      component.UnitProperty = UnitProperty;
      component.Bonus = Bonus;
      component.m_Property = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(m_Property);
      component.m_IgnoreIfHasAnyFact = m_IgnoreIfHasAnyFact.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildBalanceRadarChart"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuildBalanceRadarChart))]
    public TBuilder AddBuildBalanceRadarChart(
        int Melee,
        int Ranged,
        int Magic,
        int Defense,
        int Support,
        int Control)
    {
      
      var component =  new BuildBalanceRadarChart();
      component.Melee = Melee;
      component.Ranged = Ranged;
      component.Magic = Magic;
      component.Defense = Defense;
      component.Support = Support;
      component.Control = Control;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="StatsDistributionPreset"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(StatsDistributionPreset))]
    public TBuilder AddStatsDistributionPreset(
        int TargetPoints,
        int Strength,
        int Dexterity,
        int Constitution,
        int Intelligence,
        int Wisdom,
        int Charisma)
    {
      
      var component =  new StatsDistributionPreset();
      component.TargetPoints = TargetPoints;
      component.Strength = Strength;
      component.Dexterity = Dexterity;
      component.Constitution = Constitution;
      component.Intelligence = Intelligence;
      component.Wisdom = Wisdom;
      component.Charisma = Charisma;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAttackerSpellFailureChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddAttackerSpellFailureChance))]
    public TBuilder AddAddAttackerSpellFailureChance(
        int Chance,
        GameObject FailFx,
        ConditionsBuilder Conditions)
    {
      ValidateParam(FailFx);
      
      var component =  new AddAttackerSpellFailureChance();
      component.Chance = Chance;
      component.FailFx = FailFx;
      component.Conditions = Conditions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddLocalMapMarker"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddLocalMapMarker))]
    public TBuilder AddAddLocalMapMarker(
        LocalMapMarkType Type,
        bool ShowIfNotRevealed)
    {
      ValidateParam(Type);
      
      var component =  new AddLocalMapMarker();
      component.Type = Type;
      component.ShowIfNotRevealed = ShowIfNotRevealed;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddUndetectableAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddUndetectableAlignment))]
    public TBuilder AddAddUndetectableAlignment()
    {
      return AddComponent(new AddUndetectableAlignment());
    }

    /// <summary>
    /// Adds <see cref="SetChargeWeapon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Weapon"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(SetChargeWeapon))]
    public TBuilder AddSetChargeWeapon(
        string m_Weapon)
    {
      
      var component =  new SetChargeWeapon();
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(m_Weapon);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SetFleeOrApproachLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetFleeOrApproachLogic))]
    public TBuilder AddSetFleeOrApproachLogic(
        UnitPartFleeOrApproach.CommandType CommandType)
    {
      ValidateParam(CommandType);
      
      var component =  new SetFleeOrApproachLogic();
      component.CommandType = CommandType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BlinkAoEDamageResistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BlinkAoEDamageResistance))]
    public TBuilder AddBlinkAoEDamageResistance()
    {
      return AddComponent(new BlinkAoEDamageResistance());
    }

    /// <summary>
    /// Adds <see cref="SetAttackerMissChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetAttackerMissChance))]
    public TBuilder AddSetAttackerMissChance(
        SetAttackerMissChance.Type m_Type,
        ContextValue Value,
        ConditionsBuilder Conditions)
    {
      ValidateParam(m_Type);
      ValidateParam(Value);
      
      var component =  new SetAttackerMissChance();
      component.m_Type = m_Type;
      component.Value = Value;
      component.Conditions = Conditions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SetFactOwnerMissChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetFactOwnerMissChance))]
    public TBuilder AddSetFactOwnerMissChance(
        SetFactOwnerMissChance.Type m_Type,
        ContextValue Value,
        ConditionsBuilder Conditions)
    {
      ValidateParam(m_Type);
      ValidateParam(Value);
      
      var component =  new SetFactOwnerMissChance();
      component.m_Type = m_Type;
      component.Value = Value;
      component.Conditions = Conditions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityResourceOverride"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_AbilityResource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(AbilityResourceOverride))]
    public TBuilder AddAbilityResourceOverride(
        string m_AbilityResource,
        ContextValue m_LevelMultiplier,
        ContextValue m_AdditionalCost,
        bool m_SaveSpellSlot)
    {
      ValidateParam(m_LevelMultiplier);
      ValidateParam(m_AdditionalCost);
      
      var component =  new AbilityResourceOverride();
      component.m_AbilityResource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(m_AbilityResource);
      component.m_LevelMultiplier = m_LevelMultiplier;
      component.m_AdditionalCost = m_AdditionalCost;
      component.m_SaveSpellSlot = m_SaveSpellSlot;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyLeaderAddResourcesOnBattleEnd"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyLeaderAddResourcesOnBattleEnd))]
    public TBuilder AddArmyLeaderAddResourcesOnBattleEnd(
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
    /// Adds <see cref="CritAutoconfirmAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CritAutoconfirmAgainstAlignment))]
    public TBuilder AddCritAutoconfirmAgainstAlignment(
        AlignmentComponent EnemyAlignment)
    {
      ValidateParam(EnemyAlignment);
      
      var component =  new CritAutoconfirmAgainstAlignment();
      component.EnemyAlignment = EnemyAlignment;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DoubleDamageDiceOnAttack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_WeaponType"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(DoubleDamageDiceOnAttack))]
    public TBuilder AddDoubleDamageDiceOnAttack(
        bool OnlyOnFullAttack,
        bool OnlyOnFirstAttack,
        bool CriticalHit,
        string m_WeaponType)
    {
      
      var component =  new DoubleDamageDiceOnAttack();
      component.OnlyOnFullAttack = OnlyOnFullAttack;
      component.OnlyOnFirstAttack = OnlyOnFirstAttack;
      component.CriticalHit = CriticalHit;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(m_WeaponType);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreDamageGrowthByDifficulty"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreDamageGrowthByDifficulty))]
    public TBuilder AddIgnoreDamageGrowthByDifficulty()
    {
      return AddComponent(new IgnoreDamageGrowthByDifficulty());
    }

    /// <summary>
    /// Adds <see cref="IgnoreDamageReductionOnAttack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_WeaponType"><see cref="BlueprintWeaponType"/></param>
    /// <param name="m_CheckedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(IgnoreDamageReductionOnAttack))]
    public TBuilder AddIgnoreDamageReductionOnAttack(
        bool OnlyOnFullAttack,
        bool OnlyOnFirstAttack,
        bool CriticalHit,
        string m_WeaponType,
        bool CheckEnemyFact,
        string m_CheckedFact,
        bool OnlyNaturalAttacks)
    {
      
      var component =  new IgnoreDamageReductionOnAttack();
      component.OnlyOnFullAttack = OnlyOnFullAttack;
      component.OnlyOnFirstAttack = OnlyOnFirstAttack;
      component.CriticalHit = CriticalHit;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(m_WeaponType);
      component.CheckEnemyFact = CheckEnemyFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CheckedFact);
      component.OnlyNaturalAttacks = OnlyNaturalAttacks;
      return AddComponent(component);
    }

    protected override void ConfigureInternal() { }

    protected override void ValidateInternal() { }
  }
}
