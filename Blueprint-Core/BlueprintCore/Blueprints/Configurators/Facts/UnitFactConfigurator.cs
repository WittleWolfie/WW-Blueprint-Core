using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Formations.Facts;
using Kingmaker.Kingdom;
using Kingmaker.Localization;
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
  public abstract class BaseUnitFactConfigurator<T, TBuilder> : BaseFactConfigurator<T, TBuilder>
      where T : BlueprintUnitFact
      where TBuilder : BaseUnitFactConfigurator<T, TBuilder>
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
    /// Adds <see cref="FormationACBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="property"><see cref="BlueprintUnitProperty"/></param>
    /// <param name="ignoreIfHasAnyFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(FormationACBonus))]
    public TBuilder AddFormationACBonus(
        bool unitProperty = default,
        int bonus = default,
        string property = null,
        string[] ignoreIfHasAnyFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new FormationACBonus();
      component.UnitProperty = unitProperty;
      component.Bonus = bonus;
      component.m_Property = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(property);
      component.m_IgnoreIfHasAnyFact = ignoreIfHasAnyFact.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildBalanceRadarChart"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuildBalanceRadarChart))]
    public TBuilder AddBuildBalanceRadarChart(
        int melee = default,
        int ranged = default,
        int magic = default,
        int defense = default,
        int support = default,
        int control = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuildBalanceRadarChart();
      component.Melee = melee;
      component.Ranged = ranged;
      component.Magic = magic;
      component.Defense = defense;
      component.Support = support;
      component.Control = control;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="StatsDistributionPreset"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(StatsDistributionPreset))]
    public TBuilder AddStatsDistributionPreset(
        int targetPoints = default,
        int strength = default,
        int dexterity = default,
        int constitution = default,
        int intelligence = default,
        int wisdom = default,
        int charisma = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new StatsDistributionPreset();
      component.TargetPoints = targetPoints;
      component.Strength = strength;
      component.Dexterity = dexterity;
      component.Constitution = constitution;
      component.Intelligence = intelligence;
      component.Wisdom = wisdom;
      component.Charisma = charisma;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAttackerSpellFailureChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddAttackerSpellFailureChance))]
    public TBuilder AddAttackerSpellFailureChance(
        GameObject failFx,
        int chance = default,
        ConditionsBuilder conditions = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(failFx);
    
      var component = new AddAttackerSpellFailureChance();
      component.Chance = chance;
      component.FailFx = failFx;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddLocalMapMarker"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddLocalMapMarker))]
    public TBuilder AddLocalMapMarker(
        LocalMapMarkType type = default,
        bool showIfNotRevealed = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddLocalMapMarker();
      component.Type = type;
      component.ShowIfNotRevealed = showIfNotRevealed;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddUndetectableAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddUndetectableAlignment))]
    public TBuilder AddUndetectableAlignment(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddUndetectableAlignment();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SetChargeWeapon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weapon"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(SetChargeWeapon))]
    public TBuilder AddSetChargeWeapon(
        string weapon = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SetChargeWeapon();
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weapon);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SetFleeOrApproachLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetFleeOrApproachLogic))]
    public TBuilder AddSetFleeOrApproachLogic(
        UnitPartFleeOrApproach.CommandType commandType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SetFleeOrApproachLogic();
      component.CommandType = commandType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BlinkAoEDamageResistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BlinkAoEDamageResistance))]
    public TBuilder AddBlinkAoEDamageResistance(
        BlueprintComponent.Flags flags = default)
    {
      var component = new BlinkAoEDamageResistance();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SetAttackerMissChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetAttackerMissChance))]
    public TBuilder AddSetAttackerMissChance(
        ContextValue value,
        SetAttackerMissChance.Type type = default,
        ConditionsBuilder conditions = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new SetAttackerMissChance();
      component.m_Type = type;
      component.Value = value;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SetFactOwnerMissChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetFactOwnerMissChance))]
    public TBuilder AddSetFactOwnerMissChance(
        ContextValue value,
        SetFactOwnerMissChance.Type type = default,
        ConditionsBuilder conditions = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new SetFactOwnerMissChance();
      component.m_Type = type;
      component.Value = value;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityResourceOverride"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilityResource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(AbilityResourceOverride))]
    public TBuilder AddAbilityResourceOverride(
        ContextValue levelMultiplier,
        ContextValue additionalCost,
        string abilityResource = null,
        bool saveSpellSlot = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(levelMultiplier);
      ValidateParam(additionalCost);
    
      var component = new AbilityResourceOverride();
      component.m_AbilityResource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(abilityResource);
      component.m_LevelMultiplier = levelMultiplier;
      component.m_AdditionalCost = additionalCost;
      component.m_SaveSpellSlot = saveSpellSlot;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyLeaderAddResourcesOnBattleEnd"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyLeaderAddResourcesOnBattleEnd))]
    public TBuilder AddArmyLeaderAddResourcesOnBattleEnd(
        KingdomResourcesAmount resourcesAmount,
        bool onlyOnVictory = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArmyLeaderAddResourcesOnBattleEnd();
      component.m_ResourcesAmount = resourcesAmount;
      component.OnlyOnVictory = onlyOnVictory;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CritAutoconfirmAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CritAutoconfirmAgainstAlignment))]
    public TBuilder AddCritAutoconfirmAgainstAlignment(
        AlignmentComponent enemyAlignment = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CritAutoconfirmAgainstAlignment();
      component.EnemyAlignment = enemyAlignment;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DoubleDamageDiceOnAttack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(DoubleDamageDiceOnAttack))]
    public TBuilder AddDoubleDamageDiceOnAttack(
        bool onlyOnFullAttack = default,
        bool onlyOnFirstAttack = default,
        bool criticalHit = default,
        string weaponType = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DoubleDamageDiceOnAttack();
      component.OnlyOnFullAttack = onlyOnFullAttack;
      component.OnlyOnFirstAttack = onlyOnFirstAttack;
      component.CriticalHit = criticalHit;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreDamageGrowthByDifficulty"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreDamageGrowthByDifficulty))]
    public TBuilder AddIgnoreDamageGrowthByDifficulty(
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreDamageGrowthByDifficulty();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreDamageReductionOnAttack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="BlueprintWeaponType"/></param>
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(IgnoreDamageReductionOnAttack))]
    public TBuilder AddIgnoreDamageReductionOnAttack(
        bool onlyOnFullAttack = default,
        bool onlyOnFirstAttack = default,
        bool criticalHit = default,
        string weaponType = null,
        bool checkEnemyFact = default,
        string checkedFact = null,
        bool onlyNaturalAttacks = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreDamageReductionOnAttack();
      component.OnlyOnFullAttack = onlyOnFullAttack;
      component.OnlyOnFirstAttack = onlyOnFirstAttack;
      component.CriticalHit = criticalHit;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.CheckEnemyFact = checkEnemyFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.OnlyNaturalAttacks = onlyNaturalAttacks;
      component.m_Flags = flags;
      return AddComponent(component);
    }
  }
}
