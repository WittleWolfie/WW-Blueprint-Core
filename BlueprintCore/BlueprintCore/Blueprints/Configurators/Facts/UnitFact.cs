using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Armies.Components;
using Kingmaker.Armies.TacticalCombat.Brain;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Assets.Armies.TacticalCombat.Components;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Blueprints.Root.Fx;
using Kingmaker.Controllers.Rest;
using Kingmaker.Controllers.Rest.State;
using Kingmaker.Corruption;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Designers.Mechanics.Facts.Behavior;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.Formations.Facts;
using Kingmaker.Kingdom;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.Settings;
using Kingmaker.UI.MVVM._VM.ServiceWindows.LocalMap.Utils;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.AreaEffects;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Parts;
using Kingmaker.Utility;
using Owlcat.Runtime.Visual.Effects.WeatherSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Facts
{
  /// <summary>
  /// Implements common fields and component support for blueprints inheriting from <see cref="BlueprintUnitFact"/>.
  /// </summary>
  /// <inheritdoc/>
  
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
    /// <param name="property"><see cref="Kingmaker.UnitLogic.Mechanics.Properties.BlueprintUnitProperty"/></param>
    /// <param name="ignoreIfHasAnyFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddFormationACBonus(
        bool unitProperty = default,
        int bonus = default,
        string? property = null,
        string[]? ignoreIfHasAnyFact = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new FormationACBonus();
      component.UnitProperty = unitProperty;
      component.Bonus = bonus;
      component.m_Property = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(property);
      component.m_IgnoreIfHasAnyFact = ignoreIfHasAnyFact.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="CorruptionProtection"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddCorruptionProtection(
        bool removeRankAfterRest = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new CorruptionProtection();
      component.m_RemoveRankAfterRest = removeRankAfterRest;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RestRoleBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddRestRoleBonus(
        CampingRoleType roleType = default,
        ModifierDescriptor descriptor = default,
        ContextValue? value = null)
    {
      ValidateParam(value);

      var component = new RestRoleBonus();
      component.m_RoleType = roleType;
      component.m_Descriptor = descriptor;
      component.m_Value = value ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceUnitPrefab"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddReplaceUnitPrefab(
        PrefabLink? prefab = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(prefab);

      var component = new ReplaceUnitPrefab();
      component.m_Prefab = prefab ?? Constants.Empty.PrefabLink;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="PretendUnit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unit"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    
    
    public TBuilder AddPretendUnit(
        string? unit = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new PretendUnit();
      component.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(unit);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddClassLevels"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="archetypes"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype"/></param>
    /// <param name="selectSpells"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    /// <param name="memorizeSpells"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddClassLevels(
        string? characterClass = null,
        string[]? archetypes = null,
        int levels = default,
        StatType raceStat = default,
        StatType levelsStat = default,
        StatType[]? skills = null,
        string[]? selectSpells = null,
        string[]? memorizeSpells = null,
        SelectionEntry[]? selections = null,
        bool doNotApplyAutomatically = default)
    {
      ValidateParam(selections);

      var component = new AddClassLevels();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_Archetypes = archetypes.Select(name => BlueprintTool.GetRef<BlueprintArchetypeReference>(name)).ToArray();
      component.Levels = levels;
      component.RaceStat = raceStat;
      component.LevelsStat = levelsStat;
      component.Skills = skills;
      component.m_SelectSpells = selectSpells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_MemorizeSpells = memorizeSpells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.Selections = selections;
      component.DoNotApplyAutomatically = doNotApplyAutomatically;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildBalanceRadarChart"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBuildBalanceRadarChart(
        int melee = default,
        int ranged = default,
        int magic = default,
        int defense = default,
        int support = default,
        int control = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new BuildBalanceRadarChart();
      component.Melee = melee;
      component.Ranged = ranged;
      component.Magic = magic;
      component.Defense = defense;
      component.Support = support;
      component.Control = control;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="StatsDistributionPreset"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddStatsDistributionPreset(
        int targetPoints = default,
        int strength = default,
        int dexterity = default,
        int constitution = default,
        int intelligence = default,
        int wisdom = default,
        int charisma = default)
    {
      var component = new StatsDistributionPreset();
      component.TargetPoints = targetPoints;
      component.Strength = strength;
      component.Dexterity = dexterity;
      component.Constitution = constitution;
      component.Intelligence = intelligence;
      component.Wisdom = wisdom;
      component.Charisma = charisma;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SuppressSpellSchool"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSuppressSpellSchool(
        SuppressSpellSchool.Logic componentLogic = default,
        SpellSchool[]? school = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SuppressSpellSchool();
      component.m_ComponentLogic = componentLogic;
      component.m_School = school;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AzataFavorableMagic"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAzataFavorableMagic(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AzataFavorableMagic();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DemonSocothbenothAspect"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDemonSocothbenothAspect(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DemonSocothbenothAspect();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityUsagesCountTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAbilityUsagesCountTrigger(
        ContextValue? triggerCount = null,
        ActionsBuilder? action = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(triggerCount);

      var component = new AbilityUsagesCountTrigger();
      component.m_TriggerCount = triggerCount ?? ContextValues.Constant(0);
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AccomplishedSneakAttacker"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAccomplishedSneakAttacker(
        int value = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AccomplishedSneakAttacker();
      component.Value = value;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AcrobaticMovement"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAcrobaticMovement()
    {
      return AddComponent(new AcrobaticMovement());
    }

    /// <summary>
    /// Adds <see cref="AddACBonusWithDistanceToMasterCondition"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddACBonusWithDistanceToMasterCondition(
        Feet distance,
        ContextValue? value = null,
        ModifierDescriptor descriptor = default,
        CompareOperation.Type compareType = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new AddACBonusWithDistanceToMasterCondition();
      component.Value = value ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      component.CompareType = compareType;
      component.Distance = distance;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddAbilityResourceTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="Kingmaker.Blueprints.BlueprintAbilityResource"/></param>
    
    
    public TBuilder AddAbilityResourceTrigger(
        string? resource = null,
        ActionsBuilder? action = null)
    {
      var component = new AddAbilityResourceTrigger();
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAbilityUseTargetTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbooks"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellbook"/></param>
    /// <param name="spells"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddAbilityUseTargetTrigger(
        SpellDescriptorWrapper spellDescriptor,
        ActionsBuilder? action = null,
        bool afterCast = default,
        bool fromSpellbook = default,
        AbilityType type = default,
        bool dontCheckType = default,
        bool toCaster = default,
        string[]? spellbooks = null,
        bool spellList = default,
        string[]? spells = null,
        bool checkDescriptor = default)
    {
      var component = new AddAbilityUseTargetTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.AfterCast = afterCast;
      component.FromSpellbook = fromSpellbook;
      component.Type = type;
      component.DontCheckType = dontCheckType;
      component.ToCaster = toCaster;
      component.m_Spellbooks = spellbooks.Select(name => BlueprintTool.GetRef<BlueprintSpellbookReference>(name)).ToArray();
      component.SpellList = spellList;
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.CheckDescriptor = checkDescriptor;
      component.SpellDescriptor = spellDescriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAbilityUseTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbooks"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellbook"/></param>
    /// <param name="ability"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    /// <param name="abilities"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddAbilityUseTrigger(
        SpellDescriptorWrapper spellDescriptor,
        ActionsBuilder? action = null,
        bool actionsOnAllTargets = default,
        bool afterCast = default,
        bool actionsOnTarget = default,
        bool fromSpellbook = default,
        string[]? spellbooks = null,
        bool forOneSpell = default,
        string? ability = null,
        bool forMultipleSpells = default,
        string[]? abilities = null,
        bool minSpellLevel = default,
        int minSpellLevelLimit = default,
        bool exactSpellLevel = default,
        int exactSpellLevelLimit = default,
        bool checkAbilityType = default,
        AbilityType type = default,
        bool checkDescriptor = default,
        bool checkRange = default,
        AbilityRange range = default)
    {
      var component = new AddAbilityUseTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.ActionsOnAllTargets = actionsOnAllTargets;
      component.AfterCast = afterCast;
      component.ActionsOnTarget = actionsOnTarget;
      component.FromSpellbook = fromSpellbook;
      component.m_Spellbooks = spellbooks.Select(name => BlueprintTool.GetRef<BlueprintSpellbookReference>(name)).ToArray();
      component.ForOneSpell = forOneSpell;
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.ForMultipleSpells = forMultipleSpells;
      component.Abilities = abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToList();
      component.MinSpellLevel = minSpellLevel;
      component.MinSpellLevelLimit = minSpellLevelLimit;
      component.ExactSpellLevel = exactSpellLevel;
      component.ExactSpellLevelLimit = exactSpellLevelLimit;
      component.CheckAbilityType = checkAbilityType;
      component.Type = type;
      component.CheckDescriptor = checkDescriptor;
      component.SpellDescriptor = spellDescriptor;
      component.CheckRange = checkRange;
      component.Range = range;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAdditionalLimb"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weapon"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintItemWeapon"/></param>
    
    
    public TBuilder AddAdditionalLimb(
        string? weapon = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddAdditionalLimb();
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weapon);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddAttackerSpellFailureChance"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAttackerSpellFailureChance(
        GameObject failFx,
        int chance = default,
        ConditionsBuilder? conditions = null)
    {
      ValidateParam(failFx);

      var component = new AddAttackerSpellFailureChance();
      component.Chance = chance;
      component.FailFx = failFx;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBackgroundArmorProficiency"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBackgroundArmorProficiency(
        ArmorProficiencyGroup proficiency = default,
        ContextValue? stackBonus = null)
    {
      ValidateParam(stackBonus);

      var component = new AddBackgroundArmorProficiency();
      component.Proficiency = proficiency;
      component.StackBonus = stackBonus ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBackgroundClassSkill"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBackgroundClassSkill(
        StatType skill = default)
    {
      var component = new AddBackgroundClassSkill();
      component.Skill = skill;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBackgroundWeaponProficiency"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBackgroundWeaponProficiency(
        WeaponCategory proficiency = default,
        ModifierDescriptor stackBonusType = default,
        ContextValue? stackBonus = null)
    {
      ValidateParam(stackBonus);

      var component = new AddBackgroundWeaponProficiency();
      component.Proficiency = proficiency;
      component.StackBonusType = stackBonusType;
      component.StackBonus = stackBonus ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBondProperty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchant"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/></param>
    
    
    public TBuilder AddBondProperty(
        EnchantPoolType enchantPool = default,
        string? enchant = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddBondProperty();
      component.EnchantPool = enchantPool;
      component.m_Enchant = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(enchant);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddBuffInBadWeather"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddBuffInBadWeather(
        string? buff = null,
        InclemencyType weather = default,
        bool whenCalmer = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddBuffInBadWeather();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.Weather = weather;
      component.WhenCalmer = whenCalmer;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddBuffOnApplyingSpell"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBuffOnApplyingSpell(
        bool onEffectApplied = default,
        bool onResistSpell = default,
        AddBuffOnApplyingSpell.SpellConditionAndBuff[]? buffs = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(buffs);

      var component = new AddBuffOnApplyingSpell();
      component.OnEffectApplied = onEffectApplied;
      component.OnResistSpell = onResistSpell;
      component.Buffs = buffs;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddCasterSpellFailureChance"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddCasterSpellFailureChance(
        GameObject failFx,
        int chance = default,
        ConditionsBuilder? conditions = null)
    {
      ValidateParam(failFx);

      var component = new AddCasterSpellFailureChance();
      component.Chance = chance;
      component.FailFx = failFx;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddClassSkill"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddClassSkill(
        StatType skill = default)
    {
      var component = new AddClassSkill();
      component.Skill = skill;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddClusteredAttack"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddClusteredAttack(
        AddClusteredAttack.Type attackType = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddClusteredAttack();
      component.AttackType = attackType;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddConcealment"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddConcealment(
        Feet distanceGreater,
        ConcealmentDescriptor descriptor = default,
        Concealment concealment = default,
        bool checkWeaponRangeType = default,
        WeaponRangeType rangeType = default,
        bool checkDistance = default,
        bool onlyForAttacks = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddConcealment();
      component.Descriptor = descriptor;
      component.Concealment = concealment;
      component.CheckWeaponRangeType = checkWeaponRangeType;
      component.RangeType = rangeType;
      component.CheckDistance = checkDistance;
      component.DistanceGreater = distanceGreater;
      component.OnlyForAttacks = onlyForAttacks;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddCondition"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddCondition(
        UnitCondition condition = default)
    {
      var component = new AddCondition();
      component.Condition = condition;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddConditionImmunity"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddConditionImmunity(
        UnitCondition condition = default)
    {
      var component = new AddConditionImmunity();
      component.Condition = condition;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddConditionTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddConditionTrigger(
        AddConditionTrigger.TriggerType triggerType = default,
        UnitCondition[]? conditions = null,
        ActionsBuilder? action = null)
    {
      var component = new AddConditionTrigger();
      component.m_TriggerType = triggerType;
      component.Conditions = conditions;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCumulativeDamageBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddCumulativeDamageBonus(
        bool onlyNaturalAttacks = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddCumulativeDamageBonus();
      component.OnlyNaturalAttacks = onlyNaturalAttacks;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddCumulativeDamageBonusX3"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddCumulativeDamageBonusX3(
        bool onlyNaturalAttacks = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddCumulativeDamageBonusX3();
      component.OnlyNaturalAttacks = onlyNaturalAttacks;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddDamageResistanceEnergy"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDamageResistanceEnergy(
        DamageEnergyType type = default,
        bool useValueMultiplier = default,
        ContextValue? valueMultiplier = null,
        ContextValue? value = null,
        bool usePool = default,
        ContextValue? pool = null)
    {
      ValidateParam(valueMultiplier);
      ValidateParam(value);
      ValidateParam(pool);

      var component = new AddDamageResistanceEnergy();
      component.Type = type;
      component.UseValueMultiplier = useValueMultiplier;
      component.ValueMultiplier = valueMultiplier ?? ContextValues.Constant(0);
      component.Value = value ?? ContextValues.Constant(0);
      component.UsePool = usePool;
      component.Pool = pool ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddDamageResistanceForce"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDamageResistanceForce(
        DamageEnergyType type = default,
        bool useValueMultiplier = default,
        ContextValue? valueMultiplier = null,
        ContextValue? value = null,
        bool usePool = default,
        ContextValue? pool = null)
    {
      ValidateParam(valueMultiplier);
      ValidateParam(value);
      ValidateParam(pool);

      var component = new AddDamageResistanceForce();
      component.Type = type;
      component.UseValueMultiplier = useValueMultiplier;
      component.ValueMultiplier = valueMultiplier ?? ContextValues.Constant(0);
      component.Value = value ?? ContextValues.Constant(0);
      component.UsePool = usePool;
      component.Pool = pool ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddDamageResistancePhysical"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintWeaponType"/></param>
    /// <param name="checkedFactMythic"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddDamageResistancePhysical(
        bool or = default,
        bool bypassedByMaterial = default,
        PhysicalDamageMaterial material = default,
        bool bypassedByForm = default,
        PhysicalDamageForm form = default,
        bool bypassedByMagic = default,
        int minEnhancementBonus = default,
        bool bypassedByAlignment = default,
        DamageAlignment alignment = default,
        bool bypassedByReality = default,
        DamageRealityType reality = default,
        bool bypassedByWeaponType = default,
        string? weaponType = null,
        bool bypassedByMeleeWeapon = default,
        bool bypassedByEpic = default,
        string? checkedFactMythic = null,
        ContextValue? value = null,
        bool usePool = default,
        ContextValue? pool = null)
    {
      ValidateParam(value);
      ValidateParam(pool);

      var component = new AddDamageResistancePhysical();
      component.Or = or;
      component.BypassedByMaterial = bypassedByMaterial;
      component.Material = material;
      component.BypassedByForm = bypassedByForm;
      component.Form = form;
      component.BypassedByMagic = bypassedByMagic;
      component.MinEnhancementBonus = minEnhancementBonus;
      component.BypassedByAlignment = bypassedByAlignment;
      component.Alignment = alignment;
      component.BypassedByReality = bypassedByReality;
      component.Reality = reality;
      component.BypassedByWeaponType = bypassedByWeaponType;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.BypassedByMeleeWeapon = bypassedByMeleeWeapon;
      component.BypassedByEpic = bypassedByEpic;
      component.m_CheckedFactMythic = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFactMythic);
      component.Value = value ?? ContextValues.Constant(0);
      component.UsePool = usePool;
      component.Pool = pool ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddDamageTypeVulnerability"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDamageTypeVulnerability(
        bool physcicalForm = default,
        PhysicalDamageForm formType = default,
        bool physcicalAlignment = default,
        DamageAlignment damageAlignmentType = default,
        bool physcicalMaterial = default,
        PhysicalDamageMaterial materialType = default)
    {
      var component = new AddDamageTypeVulnerability();
      component.PhyscicalForm = physcicalForm;
      component.FormType = formType;
      component.PhyscicalAlignment = physcicalAlignment;
      component.DamageAlignmentType = damageAlignmentType;
      component.PhyscicalMaterial = physcicalMaterial;
      component.MaterialType = materialType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEnergyDamageDivisor"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddEnergyDamageDivisor(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddEnergyDamageDivisor();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddEnergyDamageImmunity"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddEnergyDamageImmunity(
        DamageEnergyType energyType = default,
        bool healOnDamage = default,
        AddEnergyDamageImmunity.HealingRate healRate = default)
    {
      var component = new AddEnergyDamageImmunity();
      component.EnergyType = energyType;
      component.HealOnDamage = healOnDamage;
      component.m_HealRate = healRate;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEnergyImmunity"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddEnergyImmunity(
        DamageEnergyType type = default)
    {
      var component = new AddEnergyImmunity();
      component.Type = type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEnergyVulnerability"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddEnergyVulnerability(
        DamageEnergyType type = default)
    {
      var component = new AddEnergyVulnerability();
      component.Type = type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEquipmentEntity"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddEquipmentEntity(
        EquipmentEntityLink equipmentEntity,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(equipmentEntity);

      var component = new AddEquipmentEntity();
      component.EquipmentEntity = equipmentEntity;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddFactsFromCaster"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    /// <param name="selection"><see cref="Kingmaker.Blueprints.Classes.Selection.BlueprintFeatureSelection"/></param>
    
    
    public TBuilder AddFactsFromCaster(
        string[]? facts = null,
        bool featureFromSelection = default,
        string? selection = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddFactsFromCaster();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.FeatureFromSelection = featureFromSelection;
      component.m_Selection = BlueprintTool.GetRef<BlueprintFeatureSelectionReference>(selection);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddFactsToMount"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddFactsToMount(
        string[]? facts = null,
        int casterLevel = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddFactsToMount();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.CasterLevel = casterLevel;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddFallProneTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddFallProneTrigger(
        ActionsBuilder? action = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddFallProneTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddFamiliar"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddFamiliar(
        FamiliarLink prefabLink,
        bool hideInCapital = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(prefabLink);

      var component = new AddFamiliar();
      component.PrefabLink = prefabLink;
      component.HideInCapital = hideInCapital;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddFortification"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddFortification(
        bool useContextValue = default,
        int bonus = default,
        ContextValue? value = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new AddFortification();
      component.UseContextValue = useContextValue;
      component.Bonus = bonus;
      component.Value = value ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddFortificationObsolete"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddFortificationObsolete(
        int chance = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddFortificationObsolete();
      component.Chance = chance;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddHealTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddHealTrigger(
        ActionsBuilder? action = null,
        ActionsBuilder? healerAction = null,
        bool onHealDamage = default,
        bool onHealStatDamage = default,
        bool onHealEnergyDrain = default,
        bool allowZeroHealDamage = default,
        bool allowZeroHealStatDamage = default,
        bool allowZeroHealEnergyDrain = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddHealTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.HealerAction = healerAction?.Build() ?? Constants.Empty.Actions;
      component.OnHealDamage = onHealDamage;
      component.OnHealStatDamage = onHealStatDamage;
      component.OnHealEnergyDrain = onHealEnergyDrain;
      component.AllowZeroHealDamage = allowZeroHealDamage;
      component.AllowZeroHealStatDamage = allowZeroHealStatDamage;
      component.AllowZeroHealEnergyDrain = allowZeroHealEnergyDrain;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddIdentifyBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddIdentifyBonus(
        bool allowUsingUntrainedSkill = default,
        ContextValue? bonus = null,
        ContextValue? spellBonus = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(bonus);
      ValidateParam(spellBonus);

      var component = new AddIdentifyBonus();
      component.AllowUsingUntrainedSkill = allowUsingUntrainedSkill;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.SpellBonus = spellBonus ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddImmortality"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddImmortality(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddImmortality();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddImmunityFirebrand"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddImmunityFirebrand(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddImmunityFirebrand();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddImmunityToAbilityScoreDamage"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddImmunityToAbilityScoreDamage(
        bool drain = default,
        StatType[]? statTypes = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddImmunityToAbilityScoreDamage();
      component.Drain = drain;
      component.StatTypes = statTypes;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddImmunityToCriticalHits"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddImmunityToCriticalHits(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddImmunityToCriticalHits();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddImmunityToEnergyDrain"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddImmunityToEnergyDrain(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddImmunityToEnergyDrain();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddImmunityToPrecisionDamage"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddImmunityToPrecisionDamage(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddImmunityToPrecisionDamage();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddIncomingDamageWeaponProperty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintWeaponType"/></param>
    
    
    public TBuilder AddIncomingDamageWeaponProperty(
        bool addMagic = default,
        bool addMaterial = default,
        PhysicalDamageMaterial material = default,
        bool addForm = default,
        PhysicalDamageForm form = default,
        bool addAlignment = default,
        DamageAlignment alignment = default,
        bool addReality = default,
        DamageRealityType reality = default,
        bool checkWeaponType = default,
        string? weaponType = null,
        bool checkRange = default,
        bool isRanged = default)
    {
      var component = new AddIncomingDamageWeaponProperty();
      component.AddMagic = addMagic;
      component.AddMaterial = addMaterial;
      component.Material = material;
      component.AddForm = addForm;
      component.Form = form;
      component.AddAlignment = addAlignment;
      component.Alignment = alignment;
      component.AddReality = addReality;
      component.Reality = reality;
      component.CheckWeaponType = checkWeaponType;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.CheckRange = checkRange;
      component.IsRanged = isRanged;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddIncorporealDamageDivisor"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddIncorporealDamageDivisor(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddIncorporealDamageDivisor();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddInitiatorHealTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddInitiatorHealTrigger(
        ActionsBuilder? action = null,
        ActionsBuilder? healerAction = null,
        bool onHealDamage = default,
        bool onHealStatDamage = default,
        bool onHealEnergyDrain = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddInitiatorHealTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.HealerAction = healerAction?.Build() ?? Constants.Empty.Actions;
      component.OnHealDamage = onHealDamage;
      component.OnHealStatDamage = onHealStatDamage;
      component.OnHealEnergyDrain = onHealEnergyDrain;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddItemCasterLevelBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddItemCasterLevelBonus(
        int bonus = default,
        UsableItemType itemType = default)
    {
      var component = new AddItemCasterLevelBonus();
      component.Bonus = bonus;
      component.ItemType = itemType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKnownSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="spell"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    /// <param name="archetype"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype"/></param>
    
    
    public TBuilder AddKnownSpell(
        string? characterClass = null,
        int spellLevel = default,
        string? spell = null,
        string? archetype = null)
    {
      var component = new AddKnownSpell();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.SpellLevel = spellLevel;
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(spell);
      component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddLocalMapMarker"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddLocalMapMarker(
        LocalMapMarkType type = default,
        bool showIfNotRevealed = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddLocalMapMarker();
      component.Type = type;
      component.ShowIfNotRevealed = showIfNotRevealed;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddMechanicsFeature"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddMechanicsFeature(
        AddMechanicsFeature.MechanicsFeatureType feature = default)
    {
      var component = new AddMechanicsFeature();
      component.m_Feature = feature;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddMetamagicFeat"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddMetamagicFeat(
        Metamagic metamagic = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddMetamagicFeat();
      component.Metamagic = metamagic;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddMythicEnemyHitPointsBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddMythicEnemyHitPointsBonus(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddMythicEnemyHitPointsBonus();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddNimbusDamageDivisor"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddNimbusDamageDivisor(
        AddNimbusDamageDivisor.NimbusType type = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddNimbusDamageDivisor();
      component.m_Type = type;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddOffensiveActionTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddOffensiveActionTrigger(
        ActionsBuilder? action = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddOffensiveActionTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddOppositionDescriptor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    
    
    public TBuilder AddOppositionDescriptor(
        SpellDescriptorWrapper descriptor,
        string? characterClass = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddOppositionDescriptor();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddOppositionSchool"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    
    
    public TBuilder AddOppositionSchool(
        string? characterClass = null,
        SpellSchool school = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddOppositionSchool();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.School = school;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddOutgoingDamageBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddOutgoingDamageBonus(
        DamageTypeDescription damageType,
        SpellDescriptorWrapper checkedDescriptor,
        DamageIncreaseCondition condition = default,
        DamageIncreaseReason reason = default,
        float originalDamageFactor = default,
        string? checkedFact = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(damageType);

      var component = new AddOutgoingDamageBonus();
      component.DamageType = damageType;
      component.Condition = condition;
      component.Reason = reason;
      component.OriginalDamageFactor = originalDamageFactor;
      component.CheckedDescriptor = checkedDescriptor;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddOutgoingPhysicalDamageProperty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintWeaponType"/></param>
    /// <param name="unitFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddOutgoingPhysicalDamageProperty(
        bool affectAnyPhysicalDamage = default,
        bool naturalAttacks = default,
        bool addMagic = default,
        bool addMaterial = default,
        PhysicalDamageMaterial material = default,
        bool addForm = default,
        PhysicalDamageForm form = default,
        bool addAlignment = default,
        DamageAlignment alignment = default,
        bool myAlignment = default,
        bool addReality = default,
        DamageRealityType reality = default,
        bool checkWeaponType = default,
        string? weaponType = null,
        bool checkRange = default,
        bool isRanged = default,
        bool againstFactOwner = default,
        string? unitFact = null)
    {
      var component = new AddOutgoingPhysicalDamageProperty();
      component.AffectAnyPhysicalDamage = affectAnyPhysicalDamage;
      component.NaturalAttacks = naturalAttacks;
      component.AddMagic = addMagic;
      component.AddMaterial = addMaterial;
      component.Material = material;
      component.AddForm = addForm;
      component.Form = form;
      component.AddAlignment = addAlignment;
      component.Alignment = alignment;
      component.MyAlignment = myAlignment;
      component.AddReality = addReality;
      component.Reality = reality;
      component.CheckWeaponType = checkWeaponType;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.CheckRange = checkRange;
      component.IsRanged = isRanged;
      component.AgainstFactOwner = againstFactOwner;
      component.m_UnitFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(unitFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddOverHealTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddOverHealTrigger(
        ActionsBuilder? actionOnTarget = null,
        AbilitySharedValue sharedValue = default,
        bool limitMaximum = default,
        ContextValue? maxValue = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(maxValue);

      var component = new AddOverHealTrigger();
      component.ActionOnTarget = actionOnTarget?.Build() ?? Constants.Empty.Actions;
      component.SharedValue = sharedValue;
      component.LimitMaximum = limitMaximum;
      component.MaxValue = maxValue ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddParametrizedFeatures"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddParametrizedFeatures(
        AddParametrizedFeatures.FeatureData[]? features = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(features);

      var component = new AddParametrizedFeatures();
      component.m_Features = features;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddPartyEncumbrance"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddPartyEncumbrance(
        int value = default)
    {
      var component = new AddPartyEncumbrance();
      component.Value = value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddPet"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="pet"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    /// <param name="levelRank"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    /// <param name="upgradeFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    
    
    public TBuilder AddPet(
        PetType type = default,
        PetProgressionType progressionType = default,
        string? pet = null,
        bool useContextValueLevel = default,
        string? levelRank = null,
        ContextValue? levelContextValue = null,
        bool forceAutoLevelup = default,
        string? upgradeFeature = null,
        bool destroyPetOnDeactivate = default,
        int upgradeLevel = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(levelContextValue);

      var component = new AddPet();
      component.Type = type;
      component.ProgressionType = progressionType;
      component.m_Pet = BlueprintTool.GetRef<BlueprintUnitReference>(pet);
      component.m_UseContextValueLevel = useContextValueLevel;
      component.m_LevelRank = BlueprintTool.GetRef<BlueprintFeatureReference>(levelRank);
      component.m_LevelContextValue = levelContextValue ?? ContextValues.Constant(0);
      component.m_ForceAutoLevelup = forceAutoLevelup;
      component.m_UpgradeFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(upgradeFeature);
      component.m_DestroyPetOnDeactivate = destroyPetOnDeactivate;
      component.UpgradeLevel = upgradeLevel;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddPhysicalImmunity"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddPhysicalImmunity(
        PhysicalDamageForm physicalDamageForms = default)
    {
      var component = new AddPhysicalImmunity();
      component.m_PhysicalDamageForms = physicalDamageForms;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddProficiencies"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="raceRestriction"><see cref="Kingmaker.Blueprints.Classes.BlueprintRace"/></param>
    
    
    public TBuilder AddProficiencies(
        string? raceRestriction = null,
        ArmorProficiencyGroup[]? armorProficiencies = null,
        WeaponCategory[]? weaponProficiencies = null)
    {
      var component = new AddProficiencies();
      component.m_RaceRestriction = BlueprintTool.GetRef<BlueprintRaceReference>(raceRestriction);
      component.ArmorProficiencies = armorProficiencies;
      component.WeaponProficiencies = weaponProficiencies;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddREVendorItem"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddREVendorItem(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddREVendorItem();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddResurrectOnRest"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddResurrectOnRest(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddResurrectOnRest();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddSecondaryAttacks"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weapon"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintItemWeapon"/></param>
    
    
    public TBuilder AddSecondaryAttacks(
        string[]? weapon = null)
    {
      var component = new AddSecondaryAttacks();
      component.m_Weapon = weapon.Select(name => BlueprintTool.GetRef<BlueprintItemWeaponReference>(name)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSkillPointPerCharacterLevel"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSkillPointPerCharacterLevel(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddSkillPointPerCharacterLevel();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddSpecialSpellList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="spellList"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellList"/></param>
    /// <param name="archetype"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype"/></param>
    
    
    public TBuilder AddSpecialSpellList(
        string? characterClass = null,
        string? spellList = null,
        bool forArchetypeOnly = default,
        string? archetype = null)
    {
      var component = new AddSpecialSpellList();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(spellList);
      component.ForArchetypeOnly = forArchetypeOnly;
      component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpecialSpellListForArchetype"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="spellList"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellList"/></param>
    /// <param name="archetype"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype"/></param>
    
    
    public TBuilder AddSpecialSpellListForArchetype(
        string? characterClass = null,
        string? spellList = null,
        string? archetype = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddSpecialSpellListForArchetype();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(spellList);
      component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddSpellFailureChance"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSpellFailureChance(
        GameObject failFx,
        int chance = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(failFx);

      var component = new AddSpellFailureChance();
      component.Chance = chance;
      component.FailFx = failFx;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddSpellImmunity"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="exceptions"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    /// <param name="casterIgnoreImmunityFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddSpellImmunity(
        SpellDescriptorWrapper spellDescriptor,
        SpellImmunityType type = default,
        string[]? exceptions = null,
        string? casterIgnoreImmunityFact = null,
        bool invertedDescriptors = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddSpellImmunity();
      component.Type = type;
      component.m_Exceptions = exceptions.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.SpellDescriptor = spellDescriptor;
      component.m_CasterIgnoreImmunityFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(casterIgnoreImmunityFact);
      component.InvertedDescriptors = invertedDescriptors;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddSpellKnownTemporary"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="spell"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddSpellKnownTemporary(
        string? characterClass = null,
        string? spell = null,
        int level = default,
        bool onlySpontaneous = default)
    {
      var component = new AddSpellKnownTemporary();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(spell);
      component.Level = level;
      component.OnlySpontaneous = onlySpontaneous;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellLevelLimit"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSpellLevelLimit(
        int forMaxLevel9 = default,
        int forMaxLevel6 = default,
        int forMaxLevel4 = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddSpellLevelLimit();
      component.ForMaxLevel9 = forMaxLevel9;
      component.ForMaxLevel6 = forMaxLevel6;
      component.ForMaxLevel4 = forMaxLevel4;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddSpellResistance"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSpellResistance(
        bool addCR = default,
        ContextValue? value = null,
        bool allSpellResistancePenaltyDoNotUse = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new AddSpellResistance();
      component.AddCR = addCR;
      component.Value = value ?? ContextValues.Constant(0);
      component.AllSpellResistancePenaltyDoNotUse = allSpellResistancePenaltyDoNotUse;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddSpellTypeFailureChance"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSpellTypeFailureChance(
        GameObject failFx,
        int chance = default,
        bool arcane = default,
        bool divine = default,
        bool alchemist = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(failFx);

      var component = new AddSpellTypeFailureChance();
      component.Chance = chance;
      component.FailFx = failFx;
      component.Arcane = arcane;
      component.Divine = divine;
      component.Alchemist = alchemist;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddStartingEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="basicItems"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    /// <param name="customCategoryDefaults"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintCategoryDefaults"/></param>
    /// <param name="restrictedByClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    
    
    public TBuilder AddStartingEquipment(
        string[]? basicItems = null,
        WeaponCategory[]? categoryItems = null,
        bool parametrizedCategory = default,
        string? customCategoryDefaults = null,
        string[]? restrictedByClass = null)
    {
      var component = new AddStartingEquipment();
      component.m_BasicItems = basicItems.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name)).ToArray();
      component.CategoryItems = categoryItems;
      component.ParametrizedCategory = parametrizedCategory;
      component.m_CustomCategoryDefaults = BlueprintTool.GetRef<BlueprintCategoryDefaultsReference>(customCategoryDefaults);
      component.m_RestrictedByClass = restrictedByClass.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddStatBonus(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int value = default,
        bool scaleByBasicAttackBonus = default)
    {
      var component = new AddStatBonus();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.ScaleByBasicAttackBonus = scaleByBasicAttackBonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatModifier"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddStatModifier(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        ContextValue? modifierPercents = null,
        bool useBaseValue = default,
        bool updateIfStatChanged = default)
    {
      ValidateParam(modifierPercents);

      var component = new AddStatModifier();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.ModifierPercents = modifierPercents ?? ContextValues.Constant(0);
      component.UseBaseValue = useBaseValue;
      component.UpdateIfStatChanged = updateIfStatChanged;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddUndetectableAlignment"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddUndetectableAlignment(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddUndetectableAlignment();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddUnitScale"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddUnitScale(
        float scaleIncreaseCoefficient = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddUnitScale();
      component.ScaleIncreaseCoefficient = scaleIncreaseCoefficient;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddUnlimitedSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilities"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddUnlimitedSpell(
        string[]? abilities = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddUnlimitedSpell();
      component.m_Abilities = abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AdditionalDamageOnSneakAttack"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AdditionalDamageOnSneakAttack(
        int value = default,
        bool onlyRanged = default)
    {
      var component = new AdditionalDamageOnSneakAttack();
      component.Value = value;
      component.OnlyRanged = onlyRanged;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AeonSavedStateFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="rank"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    /// <param name="resource"><see cref="Kingmaker.Blueprints.BlueprintAbilityResource"/></param>
    /// <param name="invulnerabilityBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddAeonSavedStateFeature(
        string? rank = null,
        string? resource = null,
        PrefabLink? disappearFx = null,
        PrefabLink? appearFx = null,
        float delaySeconds = default,
        string? invulnerabilityBuff = null,
        float invulnerabilitySeconds = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(disappearFx);
      ValidateParam(appearFx);

      var component = new AeonSavedStateFeature();
      component.m_Rank = BlueprintTool.GetRef<BlueprintFeatureReference>(rank);
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      component.DisappearFx = disappearFx ?? Constants.Empty.PrefabLink;
      component.AppearFx = appearFx ?? Constants.Empty.PrefabLink;
      component.DelaySeconds = delaySeconds;
      component.m_InvulnerabilityBuff = BlueprintTool.GetRef<BlueprintBuffReference>(invulnerabilityBuff);
      component.InvulnerabilitySeconds = invulnerabilitySeconds;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AlchemistInfusionFeat"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAlchemistInfusionFeat(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AlchemistInfusionFeat();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AllowDyingCondition"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAllowDyingCondition(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AllowDyingCondition();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ApplyClassProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="clazz"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="selectSpells"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    /// <param name="memorizeSpells"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    /// <param name="features"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    
    
    public TBuilder AddApplyClassProgression(
        int level = default,
        string? clazz = null,
        string[]? selectSpells = null,
        string[]? memorizeSpells = null,
        string[]? features = null,
        ParameterizedFeatureEntry[]? parameterizedFeatures = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(parameterizedFeatures);

      var component = new ApplyClassProgression();
      component.Level = level;
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      component.m_SelectSpells = selectSpells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_MemorizeSpells = memorizeSpells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Features = features.Select(name => BlueprintTool.GetRef<BlueprintFeatureReference>(name)).ToArray();
      component.ParameterizedFeatures = parameterizedFeatures;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AreaEffectImmunity"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="areaEffects"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbilityAreaEffect"/></param>
    
    
    public TBuilder AddAreaEffectImmunity(
        Kingmaker.UnitLogic.Abilities.Components.TargetType casterType = default,
        bool specificAreaEffects = default,
        string[]? areaEffects = null)
    {
      var component = new AreaEffectImmunity();
      component.m_CasterType = casterType;
      component.m_SpecificAreaEffects = specificAreaEffects;
      component.m_AreaEffects = areaEffects.Select(name => BlueprintTool.GetRef<BlueprintAbilityAreaEffectReference>(name)).ToList();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackStatReplacement"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponTypes"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintWeaponType"/></param>
    
    
    public TBuilder AddAttackStatReplacement(
        StatType replacementStat = default,
        WeaponSubCategory subCategory = default,
        bool checkWeaponTypes = default,
        string[]? weaponTypes = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AttackStatReplacement();
      component.ReplacementStat = replacementStat;
      component.SubCategory = subCategory;
      component.CheckWeaponTypes = checkWeaponTypes;
      component.m_WeaponTypes = weaponTypes.Select(name => BlueprintTool.GetRef<BlueprintWeaponTypeReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AutoFailCastingDefensively"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAutoFailCastingDefensively(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AutoFailCastingDefensively();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BookOfDreamsSummonUnitsCountLogic"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBookOfDreamsSummonUnitsCountLogic(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new BookOfDreamsSummonUnitsCountLogic();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BuffDescriptorImmunity"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ignoreFeature"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    /// <param name="factToCheck"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddBuffDescriptorImmunity(
        SpellDescriptorWrapper descriptor,
        string? ignoreFeature = null,
        bool checkFact = default,
        string? factToCheck = null)
    {
      var component = new BuffDescriptorImmunity();
      component.Descriptor = descriptor;
      component.m_IgnoreFeature = BlueprintTool.GetRef<BlueprintUnitFactReference>(ignoreFeature);
      component.CheckFact = checkFact;
      component.m_FactToCheck = BlueprintTool.GetRef<BlueprintUnitFactReference>(factToCheck);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeFaction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="faction"><see cref="Kingmaker.Blueprints.BlueprintFaction"/></param>
    
    
    public TBuilder AddChangeFaction(
        ChangeFaction.ChangeType type = default,
        string? faction = null,
        bool allowDirectControl = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ChangeFaction();
      component.m_Type = type;
      component.m_Faction = BlueprintTool.GetRef<BlueprintFactionReference>(faction);
      component.m_AllowDirectControl = allowDirectControl;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ChangeImpatience"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddChangeImpatience(
        int delta = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ChangeImpatience();
      component.Delta = delta;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ChangeIncomingDamageType"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddChangeIncomingDamageType(
        DamageTypeDescription type,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(type);

      var component = new ChangeIncomingDamageType();
      component.Type = type;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ChangeOutgoingDamageType"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddChangeOutgoingDamageType(
        DamageTypeDescription type,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(type);

      var component = new ChangeOutgoingDamageType();
      component.Type = type;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ChangeSpellCommandType"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddChangeSpellCommandType(
        Kingmaker.AI.Blueprints.TargetType spellTargetType = default,
        bool specificAbilityType = default,
        AbilityType abilityType = default,
        bool specificSpellCommandType = default,
        UnitCommand.CommandType spellCommandType = default,
        UnitCommand.CommandType newCommandType = default,
        bool requireFullRound = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ChangeSpellCommandType();
      component.m_SpellTargetType = spellTargetType;
      component.m_SpecificAbilityType = specificAbilityType;
      component.m_AbilityType = abilityType;
      component.m_SpecificSpellCommandType = specificSpellCommandType;
      component.m_SpellCommandType = spellCommandType;
      component.m_NewCommandType = newCommandType;
      component.m_RequireFullRound = requireFullRound;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="CombatManeuverOnCriticalHit"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddCombatManeuverOnCriticalHit(
        CombatManeuver maneuver = default,
        ActionsBuilder? onSuccess = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new CombatManeuverOnCriticalHit();
      component.Maneuver = maneuver;
      component.OnSuccess = onSuccess?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="CompanionImmortality"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddCompanionImmortality(
        float disappearDelay = default,
        PrefabLink? disappearFx = null,
        ActionsBuilder? actions = null,
        LocalizedString? fakeDeathMessage = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(disappearFx);
      ValidateParam(fakeDeathMessage);

      var component = new CompanionImmortality();
      component.DisappearDelay = disappearDelay;
      component.DisappearFx = disappearFx ?? Constants.Empty.PrefabLink;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.FakeDeathMessage = fakeDeathMessage ?? Constants.Empty.String;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="CompleteDamageImmunity"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddCompleteDamageImmunity()
    {
      return AddComponent(new CompleteDamageImmunity());
    }

    /// <summary>
    /// Adds <see cref="ConduitSurge"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddConduitSurge(
        string? buff = null,
        ContextValue? value = null)
    {
      ValidateParam(value);

      var component = new ConduitSurge();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.Value = value ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConfusionRollTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddConfusionRollTrigger(
        ConfusionState state = default,
        ActionsBuilder? action = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ConfusionRollTrigger();
      component.m_State = state;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DeflectArrows"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDeflectArrows(
        DeflectArrows.RestrictionType restriction = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DeflectArrows();
      component.m_Restriction = restriction;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DisableAttackType"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDisableAttackType(
        AttackTypeFlag attackType = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DisableAttackType();
      component.m_AttackType = attackType;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DisableClassAdditionalVisualSettings"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDisableClassAdditionalVisualSettings(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DisableClassAdditionalVisualSettings();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DisableDeathFXs"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDisableDeathFXs(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DisableDeathFXs();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DisableEquipmentSlot"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDisableEquipmentSlot(
        DisableEquipmentSlot.SlotType slotType = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DisableEquipmentSlot();
      component.m_SlotType = slotType;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DuelistParry"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cloakFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddDuelistParry(
        string? cloakFact = null,
        DuelistParry.TargetType target = default,
        ConditionsBuilder? attackerCondition = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DuelistParry();
      component.m_CloakFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(cloakFact);
      component.m_Target = target;
      component.AttackerCondition = attackerCondition?.Build() ?? Constants.Empty.Conditions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DweomerLeapLogic"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddDweomerLeapLogic(
        string? ability = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DweomerLeapLogic();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="EnhancePotion"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="classes"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="archetypes"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype"/></param>
    
    
    public TBuilder AddEnhancePotion(
        string[]? classes = null,
        string[]? archetypes = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new EnhancePotion();
      component.m_Classes = classes.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray();
      component.m_Archetypes = archetypes.Select(name => BlueprintTool.GetRef<BlueprintArchetypeReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="FastBombs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilities"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddFastBombs(
        string[]? abilities = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new FastBombs();
      component.m_Abilities = abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="FavoredEnemy"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddFavoredEnemy(
        string[]? checkedFacts = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new FavoredEnemy();
      component.m_CheckedFacts = checkedFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="FavoredTerrain"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddFavoredTerrain(
        AreaSetting setting = default)
    {
      var component = new FavoredTerrain();
      component.Setting = setting;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FavoredTerrainExpertise"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddFavoredTerrainExpertise(
        AreaSetting setting = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new FavoredTerrainExpertise();
      component.Setting = setting;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ForbidRotation"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddForbidRotation(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ForbidRotation();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ForbidSpecificSpellsCast"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddForbidSpecificSpellsCast(
        SpellDescriptorWrapper spellDescriptor,
        string[]? spells = null,
        bool useSpellDescriptor = default,
        ActionsBuilder? onForbiddenCastAttempt = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ForbidSpecificSpellsCast();
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.UseSpellDescriptor = useSpellDescriptor;
      component.SpellDescriptor = spellDescriptor;
      component.OnForbiddenCastAttempt = onForbiddenCastAttempt?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ForbidSpellCasting"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ignoreFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    
    
    public TBuilder AddForbidSpellCasting(
        bool forbidMagicItems = default,
        string? ignoreFeature = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ForbidSpellCasting();
      component.ForbidMagicItems = forbidMagicItems;
      component.m_IgnoreFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(ignoreFeature);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ForbidSpellbook"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbook"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellbook"/></param>
    
    
    public TBuilder AddForbidSpellbook(
        string? spellbook = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ForbidSpellbook();
      component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(spellbook);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ForbidSpellbookOnAlignmentDeviation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbooks"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellbook"/></param>
    /// <param name="ignoreFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddForbidSpellbookOnAlignmentDeviation(
        string[]? spellbooks = null,
        AlignmentMaskType alignment = default,
        string? ignoreFact = null)
    {
      var component = new ForbidSpellbookOnAlignmentDeviation();
      component.m_Spellbooks = spellbooks.Select(name => BlueprintTool.GetRef<BlueprintSpellbookReference>(name)).ToArray();
      component.Alignment = alignment;
      component.m_IgnoreFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(ignoreFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ForbidSpellbookOnArmorEquip"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbooks"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellbook"/></param>
    
    
    public TBuilder AddForbidSpellbookOnArmorEquip(
        string[]? spellbooks = null)
    {
      var component = new ForbidSpellbookOnArmorEquip();
      component.m_Spellbooks = spellbooks.Select(name => BlueprintTool.GetRef<BlueprintSpellbookReference>(name)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FreeActionSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddFreeActionSpell(
        string? ability = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new FreeActionSpell();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="GentlePersuasionConditioning"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="punishmentBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="rewardBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddGentlePersuasionConditioning(
        string? punishmentBuff = null,
        string? rewardBuff = null)
    {
      var component = new GentlePersuasionConditioning();
      component.m_PunishmentBuff = BlueprintTool.GetRef<BlueprintBuffReference>(punishmentBuff);
      component.m_RewardBuff = BlueprintTool.GetRef<BlueprintBuffReference>(rewardBuff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="GhostCriticalAndPrecisionImmunity"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddGhostCriticalAndPrecisionImmunity(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new GhostCriticalAndPrecisionImmunity();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="GreaterCombatMeneuver"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddGreaterCombatMeneuver(
        CombatManeuver maneuver = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new GreaterCombatMeneuver();
      component.Maneuver = maneuver;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="HalveIncomingAreaDamage"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddHalveIncomingAreaDamage(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new HalveIncomingAreaDamage();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="HideFactsWhileEtudePlaying"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="etude"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    /// <param name="replaceRace"><see cref="Kingmaker.Blueprints.Classes.BlueprintRace"/></param>
    /// <param name="facts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddHideFactsWhileEtudePlaying(
        string? etude = null,
        string? replaceRace = null,
        string[]? facts = null,
        HashSet<BlueprintUnitFact>? cachedFacts = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(cachedFacts);

      var component = new HideFactsWhileEtudePlaying();
      component.m_Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      component.m_ReplaceRace = BlueprintTool.GetRef<BlueprintRaceReference>(replaceRace);
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_CachedFacts = cachedFacts;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="HigherMythicsReplace"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddHigherMythicsReplace()
    {
      return AddComponent(new HigherMythicsReplace());
    }

    /// <summary>
    /// Adds <see cref="IgnoreIncommingDamage"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddIgnoreIncommingDamage()
    {
      return AddComponent(new IgnoreIncommingDamage());
    }

    /// <summary>
    /// Adds <see cref="IgnoreSpellImmunity"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddIgnoreSpellImmunity(
        SpellDescriptorWrapper spellDescriptor,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IgnoreSpellImmunity();
      component.SpellDescriptor = spellDescriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IncorporealACBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddIncorporealACBonus()
    {
      return AddComponent(new IncorporealACBonus());
    }

    /// <summary>
    /// Adds <see cref="IncreaseActivatableAbilityGroupSize"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddIncreaseActivatableAbilityGroupSize(
        ActivatableAbilityGroup group = default)
    {
      var component = new IncreaseActivatableAbilityGroupSize();
      component.Group = group;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseResourceAmount"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="Kingmaker.Blueprints.BlueprintAbilityResource"/></param>
    
    
    public TBuilder AddIncreaseResourceAmount(
        string? resource = null,
        int value = default)
    {
      var component = new IncreaseResourceAmount();
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      component.Value = value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseResourceAmountBySharedValue"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="Kingmaker.Blueprints.BlueprintAbilityResource"/></param>
    
    
    public TBuilder AddIncreaseResourceAmountBySharedValue(
        string? resource = null,
        ContextValue? value = null,
        bool decrease = default)
    {
      ValidateParam(value);

      var component = new IncreaseResourceAmountBySharedValue();
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      component.Value = value ?? ContextValues.Constant(0);
      component.Decrease = decrease;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseResourcesByClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="Kingmaker.Blueprints.BlueprintAbilityResource"/></param>
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="archetype"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype"/></param>
    
    
    public TBuilder AddIncreaseResourcesByClass(
        string? resource = null,
        string? characterClass = null,
        string? archetype = null,
        StatType stat = default,
        int baseValue = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IncreaseResourcesByClass();
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      component.Stat = stat;
      component.BaseValue = baseValue;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="InitiatorDisarmTrapTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddInitiatorDisarmTrapTrigger(
        ActionsBuilder? onDisarmSuccess = null,
        ActionsBuilder? onDisarmFail = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new InitiatorDisarmTrapTrigger();
      component.OnDisarmSuccess = onDisarmSuccess?.Build() ?? Constants.Empty.Actions;
      component.OnDisarmFail = onDisarmFail?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="InitiatorSavingThrowTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddInitiatorSavingThrowTrigger(
        ActionsBuilder? onSuccessfulSave = null,
        ActionsBuilder? onFailedSave = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new InitiatorSavingThrowTrigger();
      component.OnSuccessfulSave = onSuccessfulSave?.Build() ?? Constants.Empty.Actions;
      component.OnFailedSave = onFailedSave?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="KeepAlliesAlive"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="walkingDeadBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddKeepAlliesAlive(
        ContextValue? maxAttacksCount = null,
        string? walkingDeadBuff = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(maxAttacksCount);

      var component = new KeepAlliesAlive();
      component.m_MaxAttacksCount = maxAttacksCount ?? ContextValues.Constant(0);
      component.WalkingDeadBuff = BlueprintTool.GetRef<BlueprintBuffReference>(walkingDeadBuff);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="LearnSpellList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="spellList"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellList"/></param>
    /// <param name="archetype"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype"/></param>
    
    
    public TBuilder AddLearnSpellList(
        string? characterClass = null,
        string? spellList = null,
        string? archetype = null)
    {
      var component = new LearnSpellList();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(spellList);
      component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LearnSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="spells"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddLearnSpells(
        string? characterClass = null,
        string[]? spells = null)
    {
      var component = new LearnSpells();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LockEquipmentSlot"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddLockEquipmentSlot(
        LockEquipmentSlot.SlotType slotType = default,
        bool deactivate = default)
    {
      var component = new LockEquipmentSlot();
      component.m_SlotType = slotType;
      component.m_Deactivate = deactivate;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MarkPassive"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddMarkPassive(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new MarkPassive();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="MayBanterOnRest"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddMayBanterOnRest(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new MayBanterOnRest();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="MovementDistanceTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddMovementDistanceTrigger(
        ActionsBuilder? action = null,
        ContextValue? distanceInFeet = null,
        bool limitTiggerCountInOneRound = default,
        int tiggerCountMaximumInOneRound = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(distanceInFeet);

      var component = new MovementDistanceTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.DistanceInFeet = distanceInFeet ?? ContextValues.Constant(0);
      component.LimitTiggerCountInOneRound = limitTiggerCountInOneRound;
      component.TiggerCountMaximumInOneRound = tiggerCountMaximumInOneRound;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="NenioSpecialPolymorphWhileEtudePlaying"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="etude"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    /// <param name="standardPolymorphAbility"><see cref="Kingmaker.UnitLogic.ActivatableAbilities.BlueprintActivatableAbility"/></param>
    /// <param name="specialPolymorphBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddNenioSpecialPolymorphWhileEtudePlaying(
        AbilityExecutionContext abilityExecutionContext,
        string? etude = null,
        string? standardPolymorphAbility = null,
        string? specialPolymorphBuff = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(abilityExecutionContext);

      var component = new NenioSpecialPolymorphWhileEtudePlaying();
      component.abilityExecutionContext = abilityExecutionContext;
      component.m_Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      component.m_StandardPolymorphAbility = BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(standardPolymorphAbility);
      component.m_SpecialPolymorphBuff = BlueprintTool.GetRef<BlueprintBuffReference>(specialPolymorphBuff);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="OverrideVisionRange"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddOverrideVisionRange(
        int visionRangeInMeters = default,
        bool alsoInCombat = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new OverrideVisionRange();
      component.VisionRangeInMeters = visionRangeInMeters;
      component.AlsoInCombat = alsoInCombat;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="PreventHealing"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddPreventHealing(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new PreventHealing();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="PriorityTarget"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="priorityFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddPriorityTarget(
        string? priorityFact = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new PriorityTarget();
      component.PriorityFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(priorityFact);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RaiseBAB"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddRaiseBAB(
        ContextValue? targetValue = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(targetValue);

      var component = new RaiseBAB();
      component.TargetValue = targetValue ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RaiseStatToMinimum"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddRaiseStatToMinimum(
        ContextValue? targetValue = null,
        StatType stat = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(targetValue);

      var component = new RaiseStatToMinimum();
      component.TargetValue = targetValue ?? ContextValues.Constant(0);
      component.Stat = stat;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RangedCleave"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddRangedCleave(
        Feet range,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RangedCleave();
      component.Range = range;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RecalculateOnOwnerFactUpdated"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="fact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddRecalculateOnOwnerFactUpdated(
        string? fact = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RecalculateOnOwnerFactUpdated();
      component.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(fact);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RedirectDamageToPet"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddRedirectDamageToPet(
        int percentRedirected = default,
        PetType petType = default)
    {
      var component = new RedirectDamageToPet();
      component.m_PercentRedirected = percentRedirected;
      component.m_PetType = petType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceStatBaseAttribute"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddReplaceStatBaseAttribute(
        StatType targetStat = default,
        StatType baseAttributeReplacement = default)
    {
      var component = new ReplaceStatBaseAttribute();
      component.TargetStat = targetStat;
      component.BaseAttributeReplacement = baseAttributeReplacement;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Revolt"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddRevolt(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new Revolt();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ScrollSpecialization"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="specializedClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    
    
    public TBuilder AddScrollSpecialization(
        string? specializedClass = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ScrollSpecialization();
      component.m_SpecializedClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(specializedClass);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SetChargeWeapon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weapon"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintItemWeapon"/></param>
    
    
    public TBuilder AddSetChargeWeapon(
        string? weapon = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SetChargeWeapon();
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weapon);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SetFleeOrApproachLogic"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSetFleeOrApproachLogic(
        UnitPartFleeOrApproach.CommandType commandType = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SetFleeOrApproachLogic();
      component.CommandType = commandType;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SetRunBackLogic"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSetRunBackLogic(
        float triggerDistance = default,
        float runBackDistance = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SetRunBackLogic();
      component.TriggerDistance = triggerDistance;
      component.RunBackDistance = runBackDistance;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SpecificBuffImmunity"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddSpecificBuffImmunity(
        string? buff = null)
    {
      var component = new SpecificBuffImmunity();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellImmunityToSpellDescriptor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="casterIgnoreImmunityFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddSpellImmunityToSpellDescriptor(
        SpellDescriptorWrapper descriptor,
        string? casterIgnoreImmunityFact = null)
    {
      var component = new SpellImmunityToSpellDescriptor();
      component.Descriptor = descriptor;
      component.m_CasterIgnoreImmunityFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(casterIgnoreImmunityFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellLinkEvocation"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSpellLinkEvocation(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SpellLinkEvocation();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SpellResistanceAgainstAlignment"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSpellResistanceAgainstAlignment(
        ContextValue? value = null,
        AlignmentComponent alignment = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new SpellResistanceAgainstAlignment();
      component.Value = value ?? ContextValues.Constant(0);
      component.Alignment = alignment;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SpellResistanceAgainstSpellDescriptor"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSpellResistanceAgainstSpellDescriptor(
        SpellDescriptorWrapper spellDescriptor,
        ContextValue? value = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new SpellResistanceAgainstSpellDescriptor();
      component.Value = value ?? ContextValues.Constant(0);
      component.SpellDescriptor = spellDescriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SpontaneousSpellConversion"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="spellsByLevel"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddSpontaneousSpellConversion(
        string? characterClass = null,
        string[]? spellsByLevel = null)
    {
      var component = new SpontaneousSpellConversion();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_SpellsByLevel = spellsByLevel.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SufferFromHealing"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSufferFromHealing(
        DamageTypeDescription damageDescription,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(damageDescription);

      var component = new SufferFromHealing();
      component.DamageDescription = damageDescription;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SuppressBuffs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buffs"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddSuppressBuffs(
        SpellDescriptorWrapper descriptor,
        string[]? buffs = null,
        SpellSchool[]? schools = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SuppressBuffs();
      component.m_Buffs = buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
      component.Schools = schools;
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SuppressDismember"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSuppressDismember(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SuppressDismember();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SwarmAoeVulnerability"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSwarmAoeVulnerability(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SwarmAoeVulnerability();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SwarmDamageResistance"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSwarmDamageResistance(
        bool diminutiveOrLower = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SwarmDamageResistance();
      component.DiminutiveOrLower = diminutiveOrLower;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TricksterParry"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTricksterParry(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TricksterParry();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="UnearthlyGrace"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddUnearthlyGrace()
    {
      return AddComponent(new UnearthlyGrace());
    }

    /// <summary>
    /// Adds <see cref="UnfailingBeacon"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddUnfailingBeacon(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new UnfailingBeacon();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="UnholyGrace"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddUnholyGrace()
    {
      return AddComponent(new UnholyGrace());
    }

    /// <summary>
    /// Adds <see cref="UnitHealthGuard"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddUnitHealthGuard(
        int healthPercent = default)
    {
      var component = new UnitHealthGuard();
      component.HealthPercent = healthPercent;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Untargetable"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddUntargetable(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new Untargetable();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponTraining"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddWeaponTraining(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponTraining();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponTrainingAttackStatReplacement"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddWeaponTrainingAttackStatReplacement(
        StatType replacementStat = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponTrainingAttackStatReplacement();
      component.ReplacementStat = replacementStat;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistAcceptBurnTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddKineticistAcceptBurnTrigger(
        ActionsBuilder? action = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddKineticistAcceptBurnTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistBurnModifier"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="appliableTo"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddKineticistBurnModifier(
        KineticistBurnType burnType = default,
        int value = default,
        bool removeBuffOnAcceptBurn = default,
        bool useContextValue = default,
        ContextValue? burnValue = null,
        string[]? appliableTo = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(burnValue);

      var component = new AddKineticistBurnModifier();
      component.BurnType = burnType;
      component.Value = value;
      component.RemoveBuffOnAcceptBurn = removeBuffOnAcceptBurn;
      component.UseContextValue = useContextValue;
      component.BurnValue = burnValue ?? ContextValues.Constant(0);
      component.m_AppliableTo = appliableTo.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistBurnValueChangedTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddKineticistBurnValueChangedTrigger(
        ActionsBuilder? action = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddKineticistBurnValueChangedTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistElementalOverflow"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="firesFury"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddKineticistElementalOverflow(
        ContextValue? bonus = null,
        bool ignoreBurn = default,
        bool elementalEngine = default,
        string? firesFury = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(bonus);

      var component = new AddKineticistElementalOverflow();
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.IgnoreBurn = ignoreBurn;
      component.ElementalEngine = elementalEngine;
      component.m_FiresFury = BlueprintTool.GetRef<BlueprintUnitFactReference>(firesFury);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistPart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="clazz"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="maxBurn"><see cref="Kingmaker.Blueprints.BlueprintAbilityResource"/></param>
    /// <param name="maxBurnPerRound"><see cref="Kingmaker.Blueprints.BlueprintAbilityResource"/></param>
    /// <param name="gatherPowerAbility"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    /// <param name="gatherPowerIncreaseFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    /// <param name="gatherPowerBuff1"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="gatherPowerBuff2"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="gatherPowerBuff3"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="blasts"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    /// <param name="bladeActivatedBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="canGatherPowerWithShieldBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddKineticistPart(
        string? clazz = null,
        StatType mainStat = default,
        string? maxBurn = null,
        string? maxBurnPerRound = null,
        string? gatherPowerAbility = null,
        string? gatherPowerIncreaseFeature = null,
        string? gatherPowerBuff1 = null,
        string? gatherPowerBuff2 = null,
        string? gatherPowerBuff3 = null,
        string[]? blasts = null,
        string? bladeActivatedBuff = null,
        string? canGatherPowerWithShieldBuff = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddKineticistPart();
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      component.MainStat = mainStat;
      component.m_MaxBurn = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(maxBurn);
      component.m_MaxBurnPerRound = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(maxBurnPerRound);
      component.m_GatherPowerAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(gatherPowerAbility);
      component.m_GatherPowerIncreaseFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(gatherPowerIncreaseFeature);
      component.m_GatherPowerBuff1 = BlueprintTool.GetRef<BlueprintBuffReference>(gatherPowerBuff1);
      component.m_GatherPowerBuff2 = BlueprintTool.GetRef<BlueprintBuffReference>(gatherPowerBuff2);
      component.m_GatherPowerBuff3 = BlueprintTool.GetRef<BlueprintBuffReference>(gatherPowerBuff3);
      component.m_Blasts = blasts.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_BladeActivatedBuff = BlueprintTool.GetRef<BlueprintBuffReference>(bladeActivatedBuff);
      component.m_CanGatherPowerWithShieldBuff = BlueprintTool.GetRef<BlueprintBuffReference>(canGatherPowerWithShieldBuff);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SetKineticistGatherPowerMode"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSetKineticistGatherPowerMode(
        KineticistGatherPowerMode mode = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SetKineticistGatherPowerMode();
      component.Mode = mode;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ChangeHitDie"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddChangeHitDie(
        DiceType hitDie = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ChangeHitDie();
      component.m_HitDie = hitDie;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddEnergyDamageTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddEnergyDamageTrigger(
        DamageEnergyType damageType = default,
        bool spellsOnly = default,
        ActionsBuilder? actions = null)
    {
      var component = new AddEnergyDamageTrigger();
      component.DamageType = damageType;
      component.SpellsOnly = spellsOnly;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddIncomingDamageTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddIncomingDamageTrigger(
        ActionsBuilder? actions = null,
        bool triggerOnStatDamageOrEnergyDrain = default,
        bool ignoreDamageFromThisFact = default,
        bool reduceBelowZero = default,
        bool checkDamageDealt = default,
        CompareOperation.Type compareType = default,
        ContextValue? targetValue = null,
        bool checkWeaponAttackType = default,
        AttackTypeFlag attackType = default,
        bool checkEnergyDamageType = default,
        DamageEnergyType energyType = default,
        bool checkDamagePhysicalTypeNot = default,
        PhysicalDamageForm damagePhysicalTypeNot = default)
    {
      ValidateParam(targetValue);

      var component = new AddIncomingDamageTrigger();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.TriggerOnStatDamageOrEnergyDrain = triggerOnStatDamageOrEnergyDrain;
      component.IgnoreDamageFromThisFact = ignoreDamageFromThisFact;
      component.ReduceBelowZero = reduceBelowZero;
      component.CheckDamageDealt = checkDamageDealt;
      component.CompareType = compareType;
      component.TargetValue = targetValue ?? ContextValues.Constant(0);
      component.CheckWeaponAttackType = checkWeaponAttackType;
      component.AttackType = attackType;
      component.CheckEnergyDamageType = checkEnergyDamageType;
      component.EnergyType = energyType;
      component.CheckDamagePhysicalTypeNot = checkDamagePhysicalTypeNot;
      component.DamagePhysicalTypeNot = damagePhysicalTypeNot;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddInitiatorPartySkillRollTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddInitiatorPartySkillRollTrigger(
        bool onlySuccess = default,
        StatType skill = default,
        ActionsBuilder? action = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddInitiatorPartySkillRollTrigger();
      component.OnlySuccess = onlySuccess;
      component.Skill = skill;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddInitiatorSavingThrowTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddInitiatorSavingThrowTrigger(
        bool onlyPass = default,
        bool onlyFail = default,
        ActionsBuilder? action = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddInitiatorSavingThrowTrigger();
      component.OnlyPass = onlyPass;
      component.OnlyFail = onlyFail;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistInfusionDamageTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintWeaponType"/></param>
    /// <param name="abilityList"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddKineticistInfusionDamageTrigger(
        SpellDescriptorWrapper spellDescriptorsList,
        TimeSpan lastFrameTime,
        ActionsBuilder? actions = null,
        bool triggerOnStatDamageOrEnergyDrain = default,
        bool checkWeaponType = default,
        bool checkSpellDescriptor = default,
        bool checkSpellParent = default,
        bool triggerOnDirectDamage = default,
        string? weaponType = null,
        string[]? abilityList = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddKineticistInfusionDamageTrigger();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.TriggerOnStatDamageOrEnergyDrain = triggerOnStatDamageOrEnergyDrain;
      component.CheckWeaponType = checkWeaponType;
      component.CheckSpellDescriptor = checkSpellDescriptor;
      component.CheckSpellParent = checkSpellParent;
      component.TriggerOnDirectDamage = triggerOnDirectDamage;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.m_AbilityList = abilityList.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.SpellDescriptorsList = spellDescriptorsList;
      component.m_LastFrameTime = lastFrameTime;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddOutgoingDamageTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintWeaponType"/></param>
    /// <param name="abilityList"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddOutgoingDamageTrigger(
        SpellDescriptorWrapper spellDescriptorsList,
        ActionsBuilder? actions = null,
        bool triggerOnStatDamageOrEnergyDrain = default,
        bool checkWeaponType = default,
        bool checkAbilityType = default,
        AbilityType abilityType = default,
        bool checkSpellDescriptor = default,
        bool checkSpellParent = default,
        bool notZeroDamage = default,
        bool checkDamageDealt = default,
        CompareOperation.Type compareType = default,
        ContextValue? targetValue = null,
        bool checkEnergyDamageType = default,
        DamageEnergyType energyType = default,
        bool applyToAreaEffectDamage = default,
        bool targetKilledByThisDamage = default,
        bool ignoreDamageFromThisFact = default,
        string? weaponType = null,
        string[]? abilityList = null)
    {
      ValidateParam(targetValue);

      var component = new AddOutgoingDamageTrigger();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.TriggerOnStatDamageOrEnergyDrain = triggerOnStatDamageOrEnergyDrain;
      component.CheckWeaponType = checkWeaponType;
      component.CheckAbilityType = checkAbilityType;
      component.m_AbilityType = abilityType;
      component.CheckSpellDescriptor = checkSpellDescriptor;
      component.CheckSpellParent = checkSpellParent;
      component.NotZeroDamage = notZeroDamage;
      component.CheckDamageDealt = checkDamageDealt;
      component.CompareType = compareType;
      component.TargetValue = targetValue ?? ContextValues.Constant(0);
      component.CheckEnergyDamageType = checkEnergyDamageType;
      component.EnergyType = energyType;
      component.ApplyToAreaEffectDamage = applyToAreaEffectDamage;
      component.TargetKilledByThisDamage = targetKilledByThisDamage;
      component.IgnoreDamageFromThisFact = ignoreDamageFromThisFact;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.m_AbilityList = abilityList.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.SpellDescriptorsList = spellDescriptorsList;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellDiceBonusTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSpellDiceBonusTrigger(
        SpellDescriptorWrapper spellDescriptorsList,
        bool checkSpellDescriptor = default,
        ContextDiceValue[]? diceValues = null,
        int[]? diceBonuses = null)
    {
      ValidateParam(diceValues);

      var component = new AddSpellDiceBonusTrigger();
      component.CheckSpellDescriptor = checkSpellDescriptor;
      component.SpellDescriptorsList = spellDescriptorsList;
      component.DiceValues = diceValues;
      component.DiceBonuses = diceBonuses;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTargetAttackWithWeaponTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTargetAttackWithWeaponTrigger(
        bool waitForAttackResolve = default,
        bool onlyHit = default,
        bool criticalHit = default,
        bool onlyOnFirstAttack = default,
        bool onAttackOfOpportunity = default,
        bool onlyMelee = default,
        bool onlyRanged = default,
        bool notReach = default,
        bool onlySneakAttack = default,
        bool notSneakAttack = default,
        bool checkCategory = default,
        bool doNotPassAttackRoll = default,
        bool not = default,
        WeaponCategory[]? categories = null,
        ActionsBuilder? actionsOnAttacker = null,
        ActionsBuilder? actionOnSelf = null)
    {
      var component = new AddTargetAttackWithWeaponTrigger();
      component.WaitForAttackResolve = waitForAttackResolve;
      component.OnlyHit = onlyHit;
      component.CriticalHit = criticalHit;
      component.OnlyOnFirstAttack = onlyOnFirstAttack;
      component.OnAttackOfOpportunity = onAttackOfOpportunity;
      component.OnlyMelee = onlyMelee;
      component.OnlyRanged = onlyRanged;
      component.NotReach = notReach;
      component.OnlySneakAttack = onlySneakAttack;
      component.NotSneakAttack = notSneakAttack;
      component.CheckCategory = checkCategory;
      component.DoNotPassAttackRoll = doNotPassAttackRoll;
      component.Not = not;
      component.Categories = categories;
      component.ActionsOnAttacker = actionsOnAttacker?.Build() ?? Constants.Empty.Actions;
      component.ActionOnSelf = actionOnSelf?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTargetSavingThrowTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTargetSavingThrowTrigger(
        bool onlyPass = default,
        bool onlyFail = default,
        ActionsBuilder? action = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddTargetSavingThrowTrigger();
      component.OnlyPass = onlyPass;
      component.OnlyFail = onlyFail;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddTargetSpellResistanceCheckTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTargetSpellResistanceCheckTrigger(
        bool onlyPass = default,
        bool onlyFail = default,
        ActionsBuilder? action = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddTargetSpellResistanceCheckTrigger();
      component.OnlyPass = onlyPass;
      component.OnlyFail = onlyFail;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BlinkAoEDamageResistance"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBlinkAoEDamageResistance(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new BlinkAoEDamageResistance();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ChangeSpellElementalDamage"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddChangeSpellElementalDamage(
        DamageEnergyType element = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ChangeSpellElementalDamage();
      component.Element = element;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ChangeSpellElementalDamageHalfUntyped"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddChangeSpellElementalDamageHalfUntyped(
        DamageEnergyType element = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ChangeSpellElementalDamageHalfUntyped();
      component.Element = element;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DeathActions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="Kingmaker.Blueprints.BlueprintAbilityResource"/></param>
    
    
    public TBuilder AddDeathActions(
        ActionsBuilder? actions = null,
        bool checkResource = default,
        bool onlyOnParty = default,
        string? resource = null)
    {
      var component = new DeathActions();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.CheckResource = checkResource;
      component.OnlyOnParty = onlyOnParty;
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeskariAspect"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDeskariAspect(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DeskariAspect();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="FlamewardenBurningRenewal"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="Kingmaker.Blueprints.BlueprintAbilityResource"/></param>
    
    
    public TBuilder AddFlamewardenBurningRenewal(
        ActionsBuilder? actions = null,
        string? resource = null)
    {
      var component = new FlamewardenBurningRenewal();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="InitiatorRuleDealDamageTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddInitiatorRuleDealDamageTrigger(
        ActionsBuilder? actionOnSource = null,
        AbilitySharedValue sharedValue = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new InitiatorRuleDealDamageTrigger();
      component.m_ActionOnSource = actionOnSource?.Build() ?? Constants.Empty.Actions;
      component.m_SharedValue = sharedValue;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ModifyAttackerMissChance"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddModifyAttackerMissChance(
        ContextValue? value = null)
    {
      ValidateParam(value);

      var component = new ModifyAttackerMissChance();
      component.Value = value ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OutcomingDamageAndHealingModifier"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddOutcomingDamageAndHealingModifier(
        ContextValue? modifierPercents = null,
        OutcomingDamageAndHealingModifier.ModifyingType type = default,
        OutcomingDamageAndHealingModifier.WeaponType damageWeaponType = default,
        bool overrideOtherModifierPercents = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(modifierPercents);

      var component = new OutcomingDamageAndHealingModifier();
      component.ModifierPercents = modifierPercents ?? ContextValues.Constant(0);
      component.Type = type;
      component.m_DamageWeaponType = damageWeaponType;
      component.m_OverrideOtherModifierPercents = overrideOtherModifierPercents;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SacredWeaponDamageOverride"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.Selection.BlueprintParametrizedFeature"/></param>
    
    
    public TBuilder AddSacredWeaponDamageOverride(
        DiceFormula formula,
        string? feature = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SacredWeaponDamageOverride();
      component.Formula = formula;
      component.m_Feature = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(feature);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SacredWeaponFavoriteDamageOverride"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="deaitySacredWeaponFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    /// <param name="buff1d6"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="buff1d8"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="buff1d10"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="buff2d6"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="buff2d8"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddSacredWeaponFavoriteDamageOverride(
        WeaponCategory category = default,
        string? deaitySacredWeaponFeature = null,
        string? buff1d6 = null,
        string? buff1d8 = null,
        string? buff1d10 = null,
        string? buff2d6 = null,
        string? buff2d8 = null)
    {
      var component = new SacredWeaponFavoriteDamageOverride();
      component.Category = category;
      component.m_DeaitySacredWeaponFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(deaitySacredWeaponFeature);
      component.m_Buff1d6 = BlueprintTool.GetRef<BlueprintBuffReference>(buff1d6);
      component.m_Buff1d8 = BlueprintTool.GetRef<BlueprintBuffReference>(buff1d8);
      component.m_Buff1d10 = BlueprintTool.GetRef<BlueprintBuffReference>(buff1d10);
      component.m_Buff2d6 = BlueprintTool.GetRef<BlueprintBuffReference>(buff2d6);
      component.m_Buff2d8 = BlueprintTool.GetRef<BlueprintBuffReference>(buff2d8);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SetAttackerMissChance"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSetAttackerMissChance(
        SetAttackerMissChance.Type type = default,
        ContextValue? value = null,
        ConditionsBuilder? conditions = null)
    {
      ValidateParam(value);

      var component = new SetAttackerMissChance();
      component.m_Type = type;
      component.Value = value ?? ContextValues.Constant(0);
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SetFactOwnerMissChance"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSetFactOwnerMissChance(
        SetFactOwnerMissChance.Type type = default,
        ContextValue? value = null,
        ConditionsBuilder? conditions = null)
    {
      ValidateParam(value);

      var component = new SetFactOwnerMissChance();
      component.m_Type = type;
      component.Value = value ?? ContextValues.Constant(0);
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageOverride"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponTypes"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintWeaponType"/></param>
    
    
    public TBuilder AddWeaponDamageOverride(
        DiceFormula formula,
        string[]? weaponTypes = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponDamageOverride();
      component.Formula = formula;
      component.m_WeaponTypes = weaponTypes.Select(name => BlueprintTool.GetRef<BlueprintWeaponTypeReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DublicateSpellComponent"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDublicateSpellComponent(
        int feetsRaiuds = default,
        DublicateSpellComponent.AOEType aOECheck = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DublicateSpellComponent();
      component.m_FeetsRaiuds = feetsRaiuds;
      component.m_AOECheck = aOECheck;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityResourceOverride"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilityResource"><see cref="Kingmaker.Blueprints.BlueprintAbilityResource"/></param>
    
    
    public TBuilder AddAbilityResourceOverride(
        string? abilityResource = null,
        ContextValue? levelMultiplier = null,
        ContextValue? additionalCost = null,
        bool saveSpellSlot = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(levelMultiplier);
      ValidateParam(additionalCost);

      var component = new AbilityResourceOverride();
      component.m_AbilityResource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(abilityResource);
      component.m_LevelMultiplier = levelMultiplier ?? ContextValues.Constant(0);
      component.m_AdditionalCost = additionalCost ?? ContextValues.Constant(0);
      component.m_SaveSpellSlot = saveSpellSlot;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IgnoreAttacksOfOpportunityForSpellList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilities"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddIgnoreAttacksOfOpportunityForSpellList(
        SpellDescriptorWrapper spellDescriptor,
        string[]? abilities = null,
        bool checkSchool = default,
        SpellSchool school = default,
        bool checkDescriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IgnoreAttacksOfOpportunityForSpellList();
      component.m_Abilities = abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToList();
      component.CheckSchool = checkSchool;
      component.School = school;
      component.CheckDescriptor = checkDescriptor;
      component.SpellDescriptor = spellDescriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ArmyAlternativeMovement"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="deliverAbility"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddArmyAlternativeMovement(
        bool ignoreObstacles = default,
        string? deliverAbility = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ArmyAlternativeMovement();
      component.m_IgnoreObstacles = ignoreObstacles;
      component.m_DeliverAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(deliverAbility);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ArmyChangeInitiative"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddArmyChangeInitiative(
        ModifierDescriptor descriptor = default,
        ContextValue? value = null)
    {
      ValidateParam(value);

      var component = new ArmyChangeInitiative();
      component.m_Descriptor = descriptor;
      component.m_Value = value ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyForceMelee"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddArmyForceMelee(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ArmyForceMelee();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ArmyFullAttackEndTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddArmyFullAttackEndTrigger(
        bool shouldBeInitiator = default,
        bool checkAllAttacks = default,
        bool onlyHit = default,
        bool criticalHit = default,
        bool onlyMelee = default,
        bool onlyRanged = default,
        bool notReach = default,
        bool onlySneakAttack = default,
        bool notSneakAttack = default,
        bool checkCategory = default,
        bool not = default,
        WeaponCategory[]? categories = null,
        ActionsBuilder? actionsOnInitiator = null,
        ActionsBuilder? actionOnTarget = null)
    {
      var component = new ArmyFullAttackEndTrigger();
      component.ShouldBeInitiator = shouldBeInitiator;
      component.CheckAllAttacks = checkAllAttacks;
      component.OnlyHit = onlyHit;
      component.CriticalHit = criticalHit;
      component.OnlyMelee = onlyMelee;
      component.OnlyRanged = onlyRanged;
      component.NotReach = notReach;
      component.OnlySneakAttack = onlySneakAttack;
      component.NotSneakAttack = notSneakAttack;
      component.CheckCategory = checkCategory;
      component.Not = not;
      component.Categories = categories;
      component.ActionsOnInitiator = actionsOnInitiator?.Build() ?? Constants.Empty.Actions;
      component.ActionOnTarget = actionOnTarget?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyLeaderAddResourcesOnBattleEnd"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddArmyLeaderAddResourcesOnBattleEnd(
        KingdomResourcesAmount resourcesAmount,
        bool onlyOnVictory = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ArmyLeaderAddResourcesOnBattleEnd();
      component.m_ResourcesAmount = resourcesAmount;
      component.OnlyOnVictory = onlyOnVictory;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ChangeLeaderSkillPowerOnAbilityUse"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddChangeLeaderSkillPowerOnAbilityUse(
        SpellDescriptorWrapper spellDescriptor,
        bool checkDescriptor = default,
        int modifier = default)
    {
      var component = new ChangeLeaderSkillPowerOnAbilityUse();
      component.m_CheckDescriptor = checkDescriptor;
      component.m_SpellDescriptor = spellDescriptor;
      component.m_Modifier = modifier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RandomLeaderSpellReplacement"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddRandomLeaderSpellReplacement(
        float chanceToReplace = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RandomLeaderSpellReplacement();
      component.m_ChanceToReplace = chanceToReplace;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RunActionOnTurnStart"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddRunActionOnTurnStart(
        float chanceCoefficient = default,
        ActionsBuilder? actions = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RunActionOnTurnStart();
      component.m_ChanceCoefficient = chanceCoefficient;
      component.m_Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TacticalBattleEndTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTacticalBattleEndTrigger(
        bool onlyOnVictory = default,
        ActionsBuilder? onBattleEnd = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TacticalBattleEndTrigger();
      component.OnlyOnVictory = onlyOnVictory;
      component.m_OnBattleEnd = onBattleEnd?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TacticalCellReachTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTacticalCellReachTrigger(
        int x = default,
        int y = default,
        bool anyX = default,
        bool anyY = default,
        ActionsBuilder? onReach = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TacticalCellReachTrigger();
      component.m_X = x;
      component.m_Y = y;
      component.m_AnyX = anyX;
      component.m_AnyY = anyY;
      component.m_OnReach = onReach?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatChangeFaction"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTacticalCombatChangeFaction(
        TacticalCombatChangeFaction.ChangeType type = default,
        ArmyFaction faction = default,
        bool allowDirectControl = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TacticalCombatChangeFaction();
      component.m_Type = type;
      component.m_Faction = faction;
      component.m_AllowDirectControl = allowDirectControl;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatEndMovementTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTacticalCombatEndMovementTrigger(
        ActionsBuilder? actions = null,
        bool allowOnlyMoveCommands = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TacticalCombatEndMovementTrigger();
      component.m_Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_AllowOnlyMoveCommands = allowOnlyMoveCommands;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatPercentDamageBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTacticalCombatPercentDamageBonus(
        int bonusPercent = default)
    {
      var component = new TacticalCombatPercentDamageBonus();
      component.BonusPercent = bonusPercent;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatProvocation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="aiAction"><see cref="Kingmaker.Armies.TacticalCombat.Brain.BlueprintTacticalCombatAiAction"/></param>
    
    
    public TBuilder AddTacticalCombatProvocation(
        string? aiAction = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TacticalCombatProvocation();
      component.m_AiAction = BlueprintTool.GetRef<BlueprintTacticalCombatAiActionReference>(aiAction);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatResurrection"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTacticalCombatResurrection(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TacticalCombatResurrection();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatRider"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="mount"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    
    
    public TBuilder AddTacticalCombatRider(
        string? mount = null,
        bool applyRiderScaleToHorse = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TacticalCombatRider();
      component.m_Mount = BlueprintTool.GetRef<BlueprintUnitReference>(mount);
      component.m_ApplyRiderScaleToHorse = applyRiderScaleToHorse;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatRoundTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTacticalCombatRoundTrigger(
        ActionsBuilder? newRoundActions = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TacticalCombatRoundTrigger();
      component.NewRoundActions = newRoundActions?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatVisibleFeature"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTacticalCombatVisibleFeature(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TacticalCombatVisibleFeature();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TacticalSquadDeathTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="armyFactOnOwnerDeath"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    /// <param name="armyFactOnOthersDeath"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddTacticalSquadDeathTrigger(
        string? armyFactOnOwnerDeath = null,
        string? armyFactOnOthersDeath = null,
        bool removeFactOnAnyDeath = default,
        ArmyFaction factDestinationFaction = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TacticalSquadDeathTrigger();
      component.m_ArmyFactOnOwnerDeath = BlueprintTool.GetRef<BlueprintUnitFactReference>(armyFactOnOwnerDeath);
      component.m_ArmyFactOnOthersDeath = BlueprintTool.GetRef<BlueprintUnitFactReference>(armyFactOnOthersDeath);
      component.m_RemoveFactOnAnyDeath = removeFactOnAnyDeath;
      component.m_FactDestinationFaction = factDestinationFaction;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ArmyDamageAfterMovementBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddArmyDamageAfterMovementBonus(
        float bonus = default,
        bool accumulateBonusPerCell = default,
        ActionsBuilder? onDamageDeal = null)
    {
      var component = new ArmyDamageAfterMovementBonus();
      component.m_Bonus = bonus;
      component.m_AccumulateBonusPerCell = accumulateBonusPerCell;
      component.OnDamageDeal = onDamageDeal?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyStandingDamageBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddArmyStandingDamageBonus(
        int bonus = default,
        ActionsBuilder? onDamageDeal = null)
    {
      var component = new ArmyStandingDamageBonus();
      component.m_Bonus = bonus;
      component.OnDamageDeal = onDamageDeal?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstAttackOfOpportunity"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddACBonusAgainstAttackOfOpportunity(
        bool notAttackOfOpportunity = default,
        ContextValue? bonus = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(bonus);

      var component = new ACBonusAgainstAttackOfOpportunity();
      component.NotAttackOfOpportunity = notAttackOfOpportunity;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstAttacks"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddACBonusAgainstAttacks(
        bool againstMeleeOnly = default,
        bool againstRangedOnly = default,
        bool onlySneakAttack = default,
        bool notTouch = default,
        bool isTouch = default,
        bool onlyAttacksOfOpportunity = default,
        ContextValue? value = null,
        int armorClassBonus = default,
        ModifierDescriptor descriptor = default,
        bool checkArmorCategory = default,
        ArmorProficiencyGroup[]? notArmorCategory = null,
        bool noShield = default)
    {
      ValidateParam(value);

      var component = new ACBonusAgainstAttacks();
      component.AgainstMeleeOnly = againstMeleeOnly;
      component.AgainstRangedOnly = againstRangedOnly;
      component.OnlySneakAttack = onlySneakAttack;
      component.NotTouch = notTouch;
      component.IsTouch = isTouch;
      component.OnlyAttacksOfOpportunity = onlyAttacksOfOpportunity;
      component.Value = value ?? ContextValues.Constant(0);
      component.ArmorClassBonus = armorClassBonus;
      component.Descriptor = descriptor;
      component.CheckArmorCategory = checkArmorCategory;
      component.NotArmorCategory = notArmorCategory;
      component.NoShield = noShield;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstBuffOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddACBonusAgainstBuffOwner(
        string? checkedBuff = null,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        bool checkAlignment = default,
        AlignmentComponent alignment = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ACBonusAgainstBuffOwner();
      component.m_CheckedBuff = BlueprintTool.GetRef<BlueprintBuffReference>(checkedBuff);
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.CheckAlignment = checkAlignment;
      component.Alignment = alignment;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddACBonusAgainstFactOwner(
        string? checkedFact = null,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        AlignmentComponent alignment = default,
        bool noFact = default)
    {
      var component = new ACBonusAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.Alignment = alignment;
      component.NoFact = noFact;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstFactOwnerMultiple"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddACBonusAgainstFactOwnerMultiple(
        string[]? facts = null,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        AlignmentComponent alignment = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ACBonusAgainstFactOwnerMultiple();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.Alignment = alignment;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstSize"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddACBonusAgainstSize(
        ModifierDescriptor descriptor = default,
        ContextValue? value = null,
        Size size = default)
    {
      ValidateParam(value);

      var component = new ACBonusAgainstSize();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.Size = size;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstSpellsWithDescriptor"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddACBonusAgainstSpellsWithDescriptor(
        SpellDescriptorWrapper spellDescriptor,
        int armorClassBonus = default,
        ModifierDescriptor descriptor = default)
    {
      var component = new ACBonusAgainstSpellsWithDescriptor();
      component.ArmorClassBonus = armorClassBonus;
      component.SpellDescriptor = spellDescriptor;
      component.Descriptor = descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstWeaponCategory"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddACBonusAgainstWeaponCategory(
        int armorClassBonus = default,
        WeaponCategory category = default,
        ModifierDescriptor descriptor = default)
    {
      var component = new ACBonusAgainstWeaponCategory();
      component.ArmorClassBonus = armorClassBonus;
      component.Category = category;
      component.Descriptor = descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstWeaponGroup"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddACBonusAgainstWeaponGroup(
        int armorClassBonus = default,
        WeaponFighterGroup fighterGroup = default,
        ModifierDescriptor descriptor = default)
    {
      var component = new ACBonusAgainstWeaponGroup();
      component.ArmorClassBonus = armorClassBonus;
      component.FighterGroup = fighterGroup;
      component.Descriptor = descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstWeaponSubcategory"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddACBonusAgainstWeaponSubcategory(
        int armorClassBonus = default,
        WeaponSubCategory subCategory = default,
        ModifierDescriptor descriptor = default)
    {
      var component = new ACBonusAgainstWeaponSubcategory();
      component.ArmorClassBonus = armorClassBonus;
      component.SubCategory = subCategory;
      component.Descriptor = descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstWeaponType"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="type"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintWeaponType"/></param>
    
    
    public TBuilder AddACBonusAgainstWeaponType(
        int armorClassBonus = default,
        string? type = null,
        ModifierDescriptor descriptor = default)
    {
      var component = new ACBonusAgainstWeaponType();
      component.ArmorClassBonus = armorClassBonus;
      component.m_Type = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(type);
      component.Descriptor = descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusUnlessFactMultiple"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddACBonusUnlessFactMultiple(
        string[]? facts = null,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        AlignmentComponent alignment = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ACBonusUnlessFactMultiple();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.Alignment = alignment;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ACContextBonusAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddACContextBonusAgainstFactOwner(
        string? checkedFact = null,
        ContextValue? bonus = null,
        ModifierDescriptor descriptor = default,
        AlignmentComponent alignment = default,
        bool noFact = default)
    {
      ValidateParam(bonus);

      var component = new ACContextBonusAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      component.Alignment = alignment;
      component.NoFact = noFact;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACContextBonusAgainstWeaponSubcategory"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddACContextBonusAgainstWeaponSubcategory(
        ContextValue? value = null,
        WeaponSubCategory subCategory = default,
        ModifierDescriptor descriptor = default)
    {
      ValidateParam(value);

      var component = new ACContextBonusAgainstWeaponSubcategory();
      component.Value = value ?? ContextValues.Constant(0);
      component.SubCategory = subCategory;
      component.Descriptor = descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityMythicParams"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilites"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddAbilityMythicParams(
        string[]? abilites = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityMythicParams();
      component.m_Abilites = abilites.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityScoreCheckBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAbilityScoreCheckBonus(
        ModifierDescriptor descriptor = default,
        ContextValue? bonus = null,
        StatType stat = default)
    {
      ValidateParam(bonus);

      var component = new AbilityScoreCheckBonus();
      component.Descriptor = descriptor;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.Stat = stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ActionsOnBuffApply"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="gainedFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddActionsOnBuffApply(
        string? gainedFact = null,
        ActionsBuilder? actions = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ActionsOnBuffApply();
      component.m_GainedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(gainedFact);
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddAbilityResources"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="Kingmaker.Blueprints.BlueprintAbilityResource"/></param>
    
    
    public TBuilder AddAbilityResources(
        bool useThisAsResource = default,
        string? resource = null,
        int amount = default,
        bool restoreAmount = default,
        bool restoreOnLevelUp = default)
    {
      var component = new AddAbilityResources();
      component.UseThisAsResource = useThisAsResource;
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      component.Amount = amount;
      component.RestoreAmount = restoreAmount;
      component.RestoreOnLevelUp = restoreOnLevelUp;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBuffOnCombatStart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddBuffOnCombatStart(
        bool checkParty = default,
        string? feature = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddBuffOnCombatStart();
      component.CheckParty = checkParty;
      component.m_Feature = BlueprintTool.GetRef<BlueprintBuffReference>(feature);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddCalculatedWeapon"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddCalculatedWeapon(
        CalculatedWeapon weapon,
        bool scaleDamageByRank = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(weapon);

      var component = new AddCalculatedWeapon();
      component.Weapon = weapon;
      component.ScaleDamageByRank = scaleDamageByRank;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddCasterLevel"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddCasterLevel(
        int bonus = default,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddCasterLevel();
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddCasterLevelForAbility"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spell"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddCasterLevelForAbility(
        string? spell = null,
        int bonus = default,
        ModifierDescriptor descriptor = default)
    {
      var component = new AddCasterLevelForAbility();
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(spell);
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCasterLevelForSpellbook"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbooks"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellbook"/></param>
    
    
    public TBuilder AddCasterLevelForSpellbook(
        int bonus = default,
        ModifierDescriptor descriptor = default,
        string[]? spellbooks = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddCasterLevelForSpellbook();
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Spellbooks = spellbooks.Select(name => BlueprintTool.GetRef<BlueprintSpellbookReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddClassLevelToSummonDuration"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    
    
    public TBuilder AddClassLevelToSummonDuration(
        string? characterClass = null,
        bool half = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddClassLevelToSummonDuration();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.Half = half;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddFactIfArchetype"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="archetype"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype"/></param>
    
    
    public TBuilder AddFactIfArchetype(
        string? feature = null,
        string? characterClass = null,
        string? archetype = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddFactIfArchetype();
      component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(feature);
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureIfHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddFeatureIfHasFact(
        string? checkedFact = null,
        string? feature = null,
        bool not = default)
    {
      var component = new AddFeatureIfHasFact();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(feature);
      component.Not = not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureOnAlignment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddFeatureOnAlignment(
        AlignmentComponent alignment = default,
        string[]? facts = null)
    {
      var component = new AddFeatureOnAlignment();
      component.Alignment = alignment;
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureOnApply"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    
    
    public TBuilder AddFeatureOnApply(
        string? feature = null)
    {
      var component = new AddFeatureOnApply();
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureOnClassLevel"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="clazz"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    /// <param name="additionalClasses"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="archetypes"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype"/></param>
    
    
    public TBuilder AddFeatureOnClassLevel(
        string? clazz = null,
        int level = default,
        string? feature = null,
        bool beforeThisLevel = default,
        string[]? additionalClasses = null,
        string[]? archetypes = null)
    {
      var component = new AddFeatureOnClassLevel();
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      component.Level = level;
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      component.BeforeThisLevel = beforeThisLevel;
      component.m_AdditionalClasses = additionalClasses.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray();
      component.m_Archetypes = archetypes.Select(name => BlueprintTool.GetRef<BlueprintArchetypeReference>(name)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureOnSkill"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddFeatureOnSkill(
        StatType statType = default,
        int minimalStat = default,
        string[]? facts = null)
    {
      var component = new AddFeatureOnSkill();
      component.StatType = statType;
      component.MinimalStat = minimalStat;
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureToNPC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    
    
    public TBuilder AddFeatureToNPC(
        bool checkParty = default,
        string? feature = null,
        bool checkSummoned = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddFeatureToNPC();
      component.CheckParty = checkParty;
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      component.CheckSummoned = checkSummoned;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureToPet"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    
    
    public TBuilder AddFeatureToPet(
        PetType petType = default,
        string? feature = null)
    {
      var component = new AddFeatureToPet();
      component.m_PetType = petType;
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellListAsAbilities"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resourcePerSpellLevel"><see cref="Kingmaker.Blueprints.BlueprintAbilityResource"/></param>
    
    
    public TBuilder AddSpellListAsAbilities(
        bool searchInAddFeatureComponents = default,
        string[]? resourcePerSpellLevel = null)
    {
      var component = new AddSpellListAsAbilities();
      component.m_SearchInAddFeatureComponents = searchInAddFeatureComponents;
      component.m_ResourcePerSpellLevel = resourcePerSpellLevel.Select(name => BlueprintTool.GetRef<BlueprintAbilityResourceReference>(name)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellbook"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbook"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellbook"/></param>
    
    
    public TBuilder AddSpellbook(
        string? spellbook = null,
        ContextValue? casterLevel = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(casterLevel);

      var component = new AddSpellbook();
      component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(spellbook);
      component.m_CasterLevel = casterLevel ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddWearinessHours"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddWearinessHours(
        int hours = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddWearinessHours();
      component.Hours = hours;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AdditionalDamageOnHit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weapon"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintItemWeapon"/></param>
    
    
    public TBuilder AdditionalDamageOnHit(
        DiceFormula energyDamageDice,
        DamageEnergyType element = default,
        bool specificWeapon = default,
        string? weapon = null,
        bool onlyNaturalAndUnarmed = default,
        bool onlyMelee = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AdditionalDamageOnHit();
      component.EnergyDamageDice = energyDamageDice;
      component.Element = element;
      component.SpecificWeapon = specificWeapon;
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weapon);
      component.OnlyNaturalAndUnarmed = onlyNaturalAndUnarmed;
      component.OnlyMelee = onlyMelee;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AdditionalSneakDamageOnHit"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AdditionalSneakDamageOnHit(
        DiceFormula physicalDamageDice,
        AdditionalSneakDamageOnHit.WeaponType weapon = default,
        bool onlyNoDexToAC = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AdditionalSneakDamageOnHit();
      component.m_Weapon = weapon;
      component.PhysicalDamageDice = physicalDamageDice;
      component.OnlyNoDexToAC = onlyNoDexToAC;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AllSpellsParamsOverride"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAllSpellsParamsOverride(
        ContextValue? casterLevel = null,
        ContextValue? dC = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(casterLevel);
      ValidateParam(dC);

      var component = new AllSpellsParamsOverride();
      component.CasterLevel = casterLevel ?? ContextValues.Constant(0);
      component.DC = dC ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AlliedSpellcaster"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="alliedSpellcasterFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddAlliedSpellcaster(
        string? alliedSpellcasterFact = null,
        int radius = default)
    {
      var component = new AlliedSpellcaster();
      component.m_AlliedSpellcasterFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(alliedSpellcasterFact);
      component.Radius = radius;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AngelSwordAdditionalDamageAndHeal"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="maximizeFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    /// <param name="cloakFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddAngelSwordAdditionalDamageAndHeal(
        string? maximizeFact = null,
        string? cloakFact = null,
        PrefabLink? healingPrefab = null,
        PrefabLink? damagePrefab = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(healingPrefab);
      ValidateParam(damagePrefab);

      var component = new AngelSwordAdditionalDamageAndHeal();
      component.m_MaximizeFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(maximizeFact);
      component.m_CloakFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(cloakFact);
      component.HealingPrefab = healingPrefab ?? Constants.Empty.PrefabLink;
      component.DamagePrefab = damagePrefab ?? Constants.Empty.PrefabLink;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AngelSwordAntiDescriptor"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAngelSwordAntiDescriptor(
        SpellDescriptorWrapper checkedDescriptor,
        bool healStatDamageAndDrain = default,
        bool healEnergyDrain = default,
        EnergyDrainHealType temporaryNegativeLevelsHeal = default,
        EnergyDrainHealType permanentNegativeLevelsHeal = default)
    {
      var component = new AngelSwordAntiDescriptor();
      component.CheckedDescriptor = checkedDescriptor;
      component.HealStatDamageAndDrain = healStatDamageAndDrain;
      component.HealEnergyDrain = healEnergyDrain;
      component.TemporaryNegativeLevelsHeal = temporaryNegativeLevelsHeal;
      component.PermanentNegativeLevelsHeal = permanentNegativeLevelsHeal;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AnyWeaponDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAnyWeaponDamageStatReplacement(
        StatType stat = default,
        bool onlyMelee = default)
    {
      var component = new AnyWeaponDamageStatReplacement();
      component.Stat = stat;
      component.OnlyMelee = onlyMelee;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArcaneArmorProficiency"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddArcaneArmorProficiency(
        ArmorProficiencyGroup[]? armor = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ArcaneArmorProficiency();
      component.Armor = armor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ArcaneBloodlineArcana"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddArcaneBloodlineArcana(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ArcaneBloodlineArcana();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ArcaneSpellFailureIncrease"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddArcaneSpellFailureIncrease(
        int bonus = default,
        bool toShield = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ArcaneSpellFailureIncrease();
      component.Bonus = bonus;
      component.ToShield = toShield;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AreaEffectEnterTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="areaEffects"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbilityAreaEffect"/></param>
    
    
    public TBuilder AddAreaEffectEnterTrigger(
        Kingmaker.UnitLogic.Abilities.Components.TargetType casterType = default,
        bool specificAreaEffects = default,
        string[]? areaEffects = null,
        ActionsBuilder? actionsOnOwner = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AreaEffectEnterTrigger();
      component.m_CasterType = casterType;
      component.m_SpecificAreaEffects = specificAreaEffects;
      component.m_AreaEffects = areaEffects.Select(name => BlueprintTool.GetRef<BlueprintAbilityAreaEffectReference>(name)).ToArray();
      component.m_ActionsOnOwner = actionsOnOwner?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ArmorCheckPenaltyIncrease"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddArmorCheckPenaltyIncrease(
        ContextValue? bonus = null,
        int bonesPerRank = default,
        bool checkCategory = default,
        ArmorProficiencyGroup category = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(bonus);

      var component = new ArmorCheckPenaltyIncrease();
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.BonesPerRank = bonesPerRank;
      component.CheckCategory = checkCategory;
      component.Category = category;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ArmorClassBonusAgainstAlignment"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddArmorClassBonusAgainstAlignment(
        AlignmentComponent alignment = default,
        ModifierDescriptor descriptor = default,
        int value = default,
        ContextValue? bonus = null)
    {
      ValidateParam(bonus);

      var component = new ArmorClassBonusAgainstAlignment();
      component.alignment = alignment;
      component.Descriptor = descriptor;
      component.Value = value;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AscendantElement"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAscendantElement(
        DamageEnergyType element = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AscendantElement();
      component.Element = element;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstAlignment"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAttackBonusAgainstAlignment(
        AlignmentComponent alignment = default,
        bool onlyMelee = default,
        int damageBonus = default,
        ContextValue? bonus = null,
        ModifierDescriptor descriptor = default)
    {
      ValidateParam(bonus);

      var component = new AttackBonusAgainstAlignment();
      component.Alignment = alignment;
      component.OnlyMelee = onlyMelee;
      component.DamageBonus = damageBonus;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstArmyProperty"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAttackBonusAgainstArmyProperty(
        ModifierDescriptor descriptor = default,
        ContextValue? value = null,
        ArmyProperties armyProperties = default)
    {
      ValidateParam(value);

      var component = new AttackBonusAgainstArmyProperty();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.ArmyProperties = armyProperties;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddAttackBonusAgainstFactOwner(
        string? checkedFact = null,
        int attackBonus = default,
        ContextValue? bonus = null,
        ModifierDescriptor descriptor = default,
        bool not = default)
    {
      ValidateParam(bonus);

      var component = new AttackBonusAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.AttackBonus = attackBonus;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      component.Not = not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstFriendly"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAttackBonusAgainstFriendly(
        int attackBonus = default,
        ModifierDescriptor descriptor = default)
    {
      var component = new AttackBonusAgainstFriendly();
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstSize"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="targetFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddAttackBonusAgainstSize(
        ModifierDescriptor descriptor = default,
        ContextValue? value = null,
        Size size = default,
        bool onlyForRanged = default,
        bool onlyForMelee = default,
        bool sizeMoreThan = default,
        bool checkTargetFact = default,
        string? targetFact = null)
    {
      ValidateParam(value);

      var component = new AttackBonusAgainstSize();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.Size = size;
      component.OnlyForRanged = onlyForRanged;
      component.OnlyForMelee = onlyForMelee;
      component.SizeMoreThan = sizeMoreThan;
      component.CheckTargetFact = checkTargetFact;
      component.m_TargetFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(targetFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusConditional"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAttackBonusConditional(
        bool checkWielder = default,
        ModifierDescriptor descriptor = default,
        ContextValue? bonus = null,
        ConditionsBuilder? conditions = null)
    {
      ValidateParam(bonus);

      var component = new AttackBonusConditional();
      component.CheckWielder = checkWielder;
      component.Descriptor = descriptor;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackDiceBonusOnce"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAttackDiceBonusOnce(
        int bonus = default,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AttackDiceBonusOnce();
      component.bonus = bonus;
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AttackOfOpportunityAttackBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAttackOfOpportunityAttackBonus(
        bool notAttackOfOpportunity = default,
        ModifierDescriptor descriptor = default,
        ContextValue? bonus = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(bonus);

      var component = new AttackOfOpportunityAttackBonus();
      component.NotAttackOfOpportunity = notAttackOfOpportunity;
      component.Descriptor = descriptor;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AttackOfOpportunityAttackBonusAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddAttackOfOpportunityAttackBonusAgainstFactOwner(
        string? checkedFact = null,
        ContextValue? bonus = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(bonus);

      var component = new AttackOfOpportunityAttackBonusAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.Bonus = bonus ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AttackOfOpportunityCriticalConfirmationBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAttackOfOpportunityCriticalConfirmationBonus(
        ContextValue? bonus = null,
        bool checkWeaponRangeType = default,
        WeaponRangeType type = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(bonus);

      var component = new AttackOfOpportunityCriticalConfirmationBonus();
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.CheckWeaponRangeType = checkWeaponRangeType;
      component.Type = type;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AttackOfOpportunityDamageBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAttackOfOpportunityDamageBonus(
        ContextValue? damageBonus = null,
        bool checkWeaponRangeType = default,
        WeaponRangeType weaponType = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(damageBonus);

      var component = new AttackOfOpportunityDamageBonus();
      component.DamageBonus = damageBonus ?? ContextValues.Constant(0);
      component.CheckWeaponRangeType = checkWeaponRangeType;
      component.WeaponType = weaponType;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AttackTypeAttackBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="requiredFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddAttackTypeAttackBonus(
        WeaponRangeType type = default,
        bool allTypesExcept = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        ContextValue? value = null,
        bool checkFact = default,
        string? requiredFact = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new AttackTypeAttackBonus();
      component.Type = type;
      component.AllTypesExcept = allTypesExcept;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.CheckFact = checkFact;
      component.m_RequiredFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(requiredFact);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AttackTypeChange"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAttackTypeChange(
        bool needsWeapon = default,
        bool changeAllTypes = default,
        AttackType originalType = default,
        AttackType newType = default)
    {
      var component = new AttackTypeChange();
      component.NeedsWeapon = needsWeapon;
      component.ChangeAllTypes = changeAllTypes;
      component.OriginalType = originalType;
      component.NewType = newType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackTypeCriticalMultiplierIncrease"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAttackTypeCriticalMultiplierIncrease(
        WeaponRangeType type = default,
        int additionalMultiplier = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AttackTypeCriticalMultiplierIncrease();
      component.Type = type;
      component.AdditionalMultiplier = additionalMultiplier;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AuraFeatureComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddAuraFeatureComponent(
        string? buff = null)
    {
      var component = new AuraFeatureComponent();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AutoConfirmCritAgainstFlanked"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAutoConfirmCritAgainstFlanked(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AutoConfirmCritAgainstFlanked();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AutoDetectStealth"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddAutoDetectStealth()
    {
      return AddComponent(new AutoDetectStealth());
    }

    /// <summary>
    /// Adds <see cref="AutoMetamagic"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilities"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    /// <param name="spellbook"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellbook"/></param>
    
    
    public TBuilder AddAutoMetamagic(
        SpellDescriptorWrapper descriptor,
        AutoMetamagic.AllowedType allowedAbilities = default,
        Metamagic metamagic = default,
        string[]? abilities = null,
        bool once = default,
        int maxSpellLevel = default,
        SpellSchool school = default,
        bool checkSpellbook = default,
        string? spellbook = null)
    {
      var component = new AutoMetamagic();
      component.m_AllowedAbilities = allowedAbilities;
      component.Metamagic = metamagic;
      component.Abilities = abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToList();
      component.Descriptor = descriptor;
      component.Once = once;
      component.MaxSpellLevel = maxSpellLevel;
      component.School = school;
      component.CheckSpellbook = checkSpellbook;
      component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(spellbook);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BackToBack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="backToBackFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddBackToBack(
        string? backToBackFact = null,
        int radius = default)
    {
      var component = new BackToBack();
      component.m_BackToBackFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(backToBackFact);
      component.Radius = radius;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BackToBackBetter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="backToBackBetterFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddBackToBackBetter(
        string? backToBackBetterFact = null,
        int radius = default)
    {
      var component = new BackToBackBetter();
      component.m_BackToBackBetterFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(backToBackBetterFact);
      component.Radius = radius;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BindAbilitiesToClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilites"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="additionalClasses"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="archetypes"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype"/></param>
    
    
    public TBuilder AddBindAbilitiesToClass(
        string[]? abilites = null,
        bool cantrip = default,
        string? characterClass = null,
        StatType stat = default,
        string[]? additionalClasses = null,
        string[]? archetypes = null,
        int levelStep = default,
        bool odd = default,
        bool fullCasterChecks = default)
    {
      var component = new BindAbilitiesToClass();
      component.m_Abilites = abilites.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.Cantrip = cantrip;
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.Stat = stat;
      component.m_AdditionalClasses = additionalClasses.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray();
      component.m_Archetypes = archetypes.Select(name => BlueprintTool.GetRef<BlueprintArchetypeReference>(name)).ToArray();
      component.LevelStep = levelStep;
      component.Odd = odd;
      component.FullCasterChecks = fullCasterChecks;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BindAbilitiesToHighest"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilities"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddBindAbilitiesToHighest(
        string[]? abilities = null)
    {
      var component = new BindAbilitiesToHighest();
      component.m_Abilities = abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BlindnessACCompensation"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBlindnessACCompensation(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new BlindnessACCompensation();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BuffSubstitutionOnApply"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="gainedFact"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="substituteBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddBuffSubstitutionOnApply(
        SpellDescriptorWrapper spellDescriptor,
        string? gainedFact = null,
        string? substituteBuff = null,
        bool checkDescriptor = default)
    {
      var component = new BuffSubstitutionOnApply();
      component.m_GainedFact = BlueprintTool.GetRef<BlueprintBuffReference>(gainedFact);
      component.m_SubstituteBuff = BlueprintTool.GetRef<BlueprintBuffReference>(substituteBuff);
      component.CheckDescriptor = checkDescriptor;
      component.SpellDescriptor = spellDescriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CMBBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddCMBBonus(
        ModifierDescriptor descriptor = default,
        ContextValue? value = null,
        bool checkFact = default,
        string? checkedFact = null)
    {
      ValidateParam(value);

      var component = new CMBBonus();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.CheckFact = checkFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CMBBonusAgainstSize"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddCMBBonusAgainstSize(
        ModifierDescriptor descriptor = default,
        ContextValue? value = null,
        Size size = default,
        bool checkFact = default,
        string? checkedFact = null)
    {
      ValidateParam(value);

      var component = new CMBBonusAgainstSize();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.Size = size;
      component.CheckFact = checkFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CMBBonusForManeuver"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddCMBBonusForManeuver(
        ModifierDescriptor descriptor = default,
        ContextValue? value = null,
        bool checkFact = default,
        string? checkedFact = null,
        CombatManeuver[]? maneuvers = null)
    {
      ValidateParam(value);

      var component = new CMBBonusForManeuver();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.CheckFact = checkFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.Maneuvers = maneuvers;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CMDBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddCMDBonus(
        ModifierDescriptor descriptor = default,
        ContextValue? value = null,
        bool checkFact = default,
        string? checkedFact = null,
        bool onCaster = default)
    {
      ValidateParam(value);

      var component = new CMDBonus();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.CheckFact = checkFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.OnCaster = onCaster;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CMDBonusAgainstManeuvers"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddCMDBonusAgainstManeuvers(
        ModifierDescriptor descriptor = default,
        ContextValue? value = null,
        CombatManeuver[]? maneuvers = null)
    {
      ValidateParam(value);

      var component = new CMDBonusAgainstManeuvers();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.Maneuvers = maneuvers;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CMDBonusAgainstSize"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddCMDBonusAgainstSize(
        ModifierDescriptor descriptor = default,
        ContextValue? value = null,
        Size size = default,
        bool checkFact = default,
        string? checkedFact = null,
        bool onCaster = default)
    {
      ValidateParam(value);

      var component = new CMDBonusAgainstSize();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.Size = size;
      component.CheckFact = checkFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.OnCaster = onCaster;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CannyDefense"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="chosenWeaponBlueprint"><see cref="Kingmaker.Blueprints.Classes.Selection.BlueprintParametrizedFeature"/></param>
    
    
    public TBuilder AddCannyDefense(
        string? characterClass = null,
        bool requiresKensai = default,
        string? chosenWeaponBlueprint = null)
    {
      var component = new CannyDefense();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.RequiresKensai = requiresKensai;
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(chosenWeaponBlueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CavalierMountedMastery"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddCavalierMountedMastery(
        ModifierDescriptor descriptor = default)
    {
      var component = new CavalierMountedMastery();
      component.Descriptor = descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CavalierRetribution"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddCavalierRetribution(
        string? buff = null)
    {
      var component = new CavalierRetribution();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CavalierStandAgainstDarkness"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddCavalierStandAgainstDarkness(
        string? checkedFact = null)
    {
      var component = new CavalierStandAgainstDarkness();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CavalierStealGlory"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddCavalierStealGlory()
    {
      return AddComponent(new CavalierStealGlory());
    }

    /// <summary>
    /// Adds <see cref="ChargeAttackBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddChargeAttackBonus(
        bool checkWielder = default,
        ModifierDescriptor descriptor = default,
        ContextValue? bonus = null)
    {
      ValidateParam(bonus);

      var component = new ChargeAttackBonus();
      component.CheckWielder = checkWielder;
      component.Descriptor = descriptor;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChargeImprovedCritical"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddChargeImprovedCritical()
    {
      return AddComponent(new ChargeImprovedCritical());
    }

    /// <summary>
    /// Adds <see cref="ClassLevelsForPrerequisites"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="fakeClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="actualClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    
    
    public TBuilder AddClassLevelsForPrerequisites(
        string? fakeClass = null,
        string? actualClass = null,
        double modifier = default,
        int summand = default)
    {
      var component = new ClassLevelsForPrerequisites();
      component.m_FakeClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(fakeClass);
      component.m_ActualClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(actualClass);
      component.Modifier = modifier;
      component.Summand = summand;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CombatAgainstMeTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddCombatAgainstMeTrigger(
        ActionsBuilder? combatStartActions = null,
        ActionsBuilder? combatEndActions = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new CombatAgainstMeTrigger();
      component.CombatStartActions = combatStartActions?.Build() ?? Constants.Empty.Actions;
      component.CombatEndActions = combatEndActions?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="CombatStateTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddCombatStateTrigger(
        ActionsBuilder? combatStartActions = null,
        ActionsBuilder? combatEndActions = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new CombatStateTrigger();
      component.CombatStartActions = combatStartActions?.Build() ?? Constants.Empty.Actions;
      component.CombatEndActions = combatEndActions?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="CompanionBoon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="rankFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    
    
    public TBuilder AddCompanionBoon(
        string? rankFeature = null,
        int bonus = default)
    {
      var component = new CompanionBoon();
      component.m_RankFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(rankFeature);
      component.Bonus = bonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConcentrationBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="requiredFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddConcentrationBonus(
        ContextValue? value = null,
        bool checkFact = default,
        string? requiredFact = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new ConcentrationBonus();
      component.Value = value ?? ContextValues.Constant(0);
      component.CheckFact = checkFact;
      component.m_RequiredFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(requiredFact);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ConcentrationBonusOnArmorType"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddConcentrationBonusOnArmorType(
        ContextValue? value = null,
        ArmorProficiencyGroup armorCategory = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new ConcentrationBonusOnArmorType();
      component.Value = value ?? ContextValues.Constant(0);
      component.ArmorCategory = armorCategory;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ConstructHealth"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddConstructHealth(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ConstructHealth();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ContextRendFeature"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddContextRendFeature(
        DamageTypeDescription rendType,
        ContextDiceValue? value = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);
      ValidateParam(rendType);

      var component = new ContextRendFeature();
      component.Value = value ?? Constants.Empty.DiceValue;
      component.RendType = rendType;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="CoordinatedDefense"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="coordinatedDefenseFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddCoordinatedDefense(
        string? coordinatedDefenseFact = null,
        int radius = default)
    {
      var component = new CoordinatedDefense();
      component.m_CoordinatedDefenseFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(coordinatedDefenseFact);
      component.Radius = radius;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CoordinatedManeuvers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="coordinatedManeuversFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddCoordinatedManeuvers(
        string? coordinatedManeuversFact = null,
        int radius = default)
    {
      var component = new CoordinatedManeuvers();
      component.m_CoordinatedManeuversFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(coordinatedManeuversFact);
      component.Radius = radius;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CraftBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddCraftBonus(
        UsableItemType bonusFor = default,
        ContextValue? value = null)
    {
      ValidateParam(value);

      var component = new CraftBonus();
      component.m_BonusFor = bonusFor;
      component.m_Value = value ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CritAutoconfirmAgainstAlignment"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddCritAutoconfirmAgainstAlignment(
        AlignmentComponent enemyAlignment = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new CritAutoconfirmAgainstAlignment();
      component.EnemyAlignment = enemyAlignment;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="CriticalConfirmationACBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddCriticalConfirmationACBonus(
        ContextValue? value = null,
        int bonus = default,
        bool onlyPositiveValue = default,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new CriticalConfirmationACBonus();
      component.Value = value ?? ContextValues.Constant(0);
      component.Bonus = bonus;
      component.OnlyPositiveValue = onlyPositiveValue;
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="CriticalConfirmationACBonusAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddCriticalConfirmationACBonusAgainstFactOwner(
        string? checkedFact = null,
        ContextValue? value = null,
        int bonus = default,
        bool onlyPositiveValue = default,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new CriticalConfirmationACBonusAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.Value = value ?? ContextValues.Constant(0);
      component.Bonus = bonus;
      component.OnlyPositiveValue = onlyPositiveValue;
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="CriticalConfirmationACBonusInHeavyArmor"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddCriticalConfirmationACBonusInHeavyArmor(
        int bonus = default,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new CriticalConfirmationACBonusInHeavyArmor();
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="CriticalConfirmationBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddCriticalConfirmationBonus(
        ContextValue? value = null,
        int bonus = default,
        bool onlyPositiveValue = default,
        bool checkWeaponRangeType = default,
        WeaponRangeType type = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new CriticalConfirmationBonus();
      component.Value = value ?? ContextValues.Constant(0);
      component.Bonus = bonus;
      component.OnlyPositiveValue = onlyPositiveValue;
      component.CheckWeaponRangeType = checkWeaponRangeType;
      component.Type = type;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DRWithPool"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddDRWithPool(
        int drPoolPerRank = default,
        int reduction = default,
        int maxPool = default,
        string? buff = null)
    {
      var component = new DRWithPool();
      component.m_drPoolPerRank = drPoolPerRank;
      component.m_reduction = reduction;
      component.m_maxPool = maxPool;
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstAlignment"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDamageBonusAgainstAlignment(
        AlignmentComponent alignment = default,
        bool onlyMelee = default,
        int damageBonus = default,
        ContextValue? bonus = null,
        ModifierDescriptor descriptor = default)
    {
      ValidateParam(bonus);

      var component = new DamageBonusAgainstAlignment();
      component.Alignment = alignment;
      component.OnlyMelee = onlyMelee;
      component.DamageBonus = damageBonus;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddDamageBonusAgainstFactOwner(
        string? checkedFact = null,
        int damageBonus = default,
        ContextValue? bonus = null,
        ModifierDescriptor descriptor = default)
    {
      ValidateParam(bonus);

      var component = new DamageBonusAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.DamageBonus = damageBonus;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstSize"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddDamageBonusAgainstSize(
        ContextValue? damageValue = null,
        Size size = default,
        bool biggerOrEqualSize = default,
        bool onlyForMelee = default,
        ModifierDescriptor descriptor = default,
        string? checkedFact = null)
    {
      ValidateParam(damageValue);

      var component = new DamageBonusAgainstSize();
      component.DamageValue = damageValue ?? ContextValues.Constant(0);
      component.size = size;
      component.BiggerOrEqualSize = biggerOrEqualSize;
      component.OnlyForMelee = onlyForMelee;
      component.Descriptor = descriptor;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusOrderOfCockatrice"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddDamageBonusOrderOfCockatrice(
        string? checkedFact = null,
        ContextValue? bonus = null,
        ModifierDescriptor descriptor = default)
    {
      ValidateParam(bonus);

      var component = new DamageBonusOrderOfCockatrice();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageGrace"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDamageGrace()
    {
      return AddComponent(new DamageGrace());
    }

    /// <summary>
    /// Adds <see cref="DamageReductionAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddDamageReductionAgainstFactOwner(
        string? checkedFact = null,
        int reduction = default)
    {
      var component = new DamageReductionAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.Reduction = reduction;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageReductionAgainstRangedWeapons"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="type"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintWeaponType"/></param>
    
    
    public TBuilder AddDamageReductionAgainstRangedWeapons(
        string? type = null,
        int reductionTrue = default,
        int reductionFalse = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DamageReductionAgainstRangedWeapons();
      component.m_Type = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(type);
      component.ReductionTrue = reductionTrue;
      component.ReductionFalse = reductionFalse;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DamageReductionAgainstSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddDamageReductionAgainstSpells(
        string[]? spells = null,
        int reduction = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DamageReductionAgainstSpells();
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.Reduction = reduction;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DamageReductionBelowZero"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDamageReductionBelowZero(
        int reduction = default,
        bool epicBypass = default)
    {
      var component = new DamageReductionBelowZero();
      component.Reduction = reduction;
      component.EpicBypass = epicBypass;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeathOnLevelStacks"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDeathOnLevelStacks(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DeathOnLevelStacks();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DefaultSourceBone"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDefaultSourceBone()
    {
      return AddComponent(new DefaultSourceBone());
    }

    /// <summary>
    /// Adds <see cref="DefensiveCombatTraining"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDefensiveCombatTraining(
        bool mythic = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DefensiveCombatTraining();
      component.Mythic = mythic;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DerivativeStatBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDerivativeStatBonus(
        StatType baseStat = default,
        StatType derivativeStat = default,
        ModifierDescriptor descriptor = default)
    {
      var component = new DerivativeStatBonus();
      component.BaseStat = baseStat;
      component.DerivativeStat = derivativeStat;
      component.Descriptor = descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DetachBuffOnNearMiss"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDetachBuffOnNearMiss(
        bool meleeOnly = default,
        bool rangedOnly = default,
        int hitAndArmorDifference = default,
        ActionsBuilder? action = null,
        bool onAttacker = default)
    {
      var component = new DetachBuffOnNearMiss();
      component.MeleeOnly = meleeOnly;
      component.RangedOnly = rangedOnly;
      component.HitAndArmorDifference = hitAndArmorDifference;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.OnAttacker = onAttacker;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DiceDamageBonusOnSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddDiceDamageBonusOnSpell(
        string[]? spells = null,
        bool useContextBonus = default,
        ContextValue? value = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new DiceDamageBonusOnSpell();
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.UseContextBonus = useContextBonus;
      component.Value = value ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DisableIntelligence"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDisableIntelligence(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DisableIntelligence();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DisableRegenerationOnCriticalHit"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDisableRegenerationOnCriticalHit(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DisableRegenerationOnCriticalHit();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DispelBonusOnDescriptor"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDispelBonusOnDescriptor(
        SpellDescriptorWrapper descriptor,
        int bonus = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DispelBonusOnDescriptor();
      component.Descriptor = descriptor;
      component.Bonus = bonus;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DispelCasterLevelCheckBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDispelCasterLevelCheckBonus(
        ContextValue? value = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new DispelCasterLevelCheckBonus();
      component.Value = value ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DistanceAttackBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDistanceAttackBonus(
        Feet range,
        int attackBonus = default,
        ModifierDescriptor descriptor = default)
    {
      var component = new DistanceAttackBonus();
      component.Range = range;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DistanceDamageBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDistanceDamageBonus(
        Feet range,
        int damageBonus = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DistanceDamageBonus();
      component.Range = range;
      component.DamageBonus = damageBonus;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DoNotBenefitFromConcealment"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDoNotBenefitFromConcealment(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DoNotBenefitFromConcealment();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DoubleDamageDiceOnAttack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintWeaponType"/></param>
    
    
    public TBuilder AddDoubleDamageDiceOnAttack(
        bool onlyOnFullAttack = default,
        bool onlyOnFirstAttack = default,
        bool criticalHit = default,
        string? weaponType = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DoubleDamageDiceOnAttack();
      component.OnlyOnFullAttack = onlyOnFullAttack;
      component.OnlyOnFirstAttack = onlyOnFirstAttack;
      component.CriticalHit = criticalHit;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DraconicBloodlineArcana"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDraconicBloodlineArcana(
        SpellDescriptorWrapper spellDescriptor,
        bool spellsOnly = default,
        bool useContextBonus = default,
        ContextValue? value = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new DraconicBloodlineArcana();
      component.SpellDescriptor = spellDescriptor;
      component.SpellsOnly = spellsOnly;
      component.UseContextBonus = useContextBonus;
      component.Value = value ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DuelistPreciseStrike"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="duelist"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="cloakDuelistFact"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="cloakNonDuelistFact"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddDuelistPreciseStrike(
        string? duelist = null,
        string? cloakDuelistFact = null,
        string? cloakNonDuelistFact = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DuelistPreciseStrike();
      component.m_Duelist = BlueprintTool.GetRef<BlueprintCharacterClassReference>(duelist);
      component.m_CloakDuelistFact = BlueprintTool.GetRef<BlueprintBuffReference>(cloakDuelistFact);
      component.m_CloakNonDuelistFact = BlueprintTool.GetRef<BlueprintBuffReference>(cloakNonDuelistFact);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DungeonClassRestrictedBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddDungeonClassRestrictedBuff(
        string? buff = null)
    {
      var component = new DungeonClassRestrictedBuff();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EnduringSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="greater"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddEnduringSpells(
        string? greater = null)
    {
      var component = new EnduringSpells();
      component.m_Greater = BlueprintTool.GetRef<BlueprintUnitFactReference>(greater);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Evasion"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddEvasion(
        SavingThrowType savingThrow = default)
    {
      var component = new Evasion();
      component.SavingThrow = savingThrow;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EvasionAgainstDescriptor"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddEvasionAgainstDescriptor(
        SpellDescriptorWrapper spellDescriptor,
        SavingThrowType savingThrow = default)
    {
      var component = new EvasionAgainstDescriptor();
      component.SpellDescriptor = spellDescriptor;
      component.SavingThrow = savingThrow;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EvasionWithTowerShield"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddEvasionWithTowerShield(
        bool improved = default)
    {
      var component = new EvasionWithTowerShield();
      component.Improved = improved;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FactSinglify"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="oldFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    /// <param name="newFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddFactSinglify(
        string[]? oldFacts = null,
        string[]? newFacts = null)
    {
      var component = new FactSinglify();
      component.m_OldFacts = oldFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_NewFacts = newFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FactsChangeTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddFactsChangeTrigger(
        string[]? checkedFacts = null,
        ActionsBuilder? onFactGainedActions = null,
        ActionsBuilder? onFactLostActions = null)
    {
      var component = new FactsChangeTrigger();
      component.m_CheckedFacts = checkedFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.OnFactGainedActions = onFactGainedActions?.Build() ?? Constants.Empty.Actions;
      component.OnFactLostActions = onFactLostActions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FlankedAttackBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddFlankedAttackBonus(
        int attackBonus = default,
        ModifierDescriptor descriptor = default)
    {
      var component = new FlankedAttackBonus();
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FlatFootedIgnore"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddFlatFootedIgnore(
        FlatFootedIgnoreType type = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new FlatFootedIgnore();
      component.Type = type;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="FullSpeedInStealth"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddFullSpeedInStealth(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new FullSpeedInStealth();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="Hardy"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="steelSoul"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    
    
    public TBuilder AddHardy(
        string? steelSoul = null)
    {
      var component = new Hardy();
      component.m_SteelSoul = BlueprintTool.GetRef<BlueprintFeatureReference>(steelSoul);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreConcealment"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddIgnoreConcealment(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IgnoreConcealment();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IgnoreCritImmunity"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddIgnoreCritImmunity(
        bool checkFact = default,
        string? checkedFact = null,
        bool not = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IgnoreCritImmunity();
      component.CheckFact = checkFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.Not = not;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IgnoreDamageGrowthByDifficulty"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddIgnoreDamageGrowthByDifficulty(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IgnoreDamageGrowthByDifficulty();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IgnoreDamageReductionOnAttack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintWeaponType"/></param>
    /// <param name="checkedFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddIgnoreDamageReductionOnAttack(
        bool onlyOnFullAttack = default,
        bool onlyOnFirstAttack = default,
        bool criticalHit = default,
        string? weaponType = null,
        bool checkEnemyFact = default,
        string? checkedFact = null,
        bool onlyNaturalAttacks = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IgnoreDamageReductionOnAttack();
      component.OnlyOnFullAttack = onlyOnFullAttack;
      component.OnlyOnFirstAttack = onlyOnFirstAttack;
      component.CriticalHit = criticalHit;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.CheckEnemyFact = checkEnemyFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.OnlyNaturalAttacks = onlyNaturalAttacks;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IgnoreDamageReductionOnCriticalHit"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddIgnoreDamageReductionOnCriticalHit(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IgnoreDamageReductionOnCriticalHit();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IgnoreDamageReductionOnTarget"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddIgnoreDamageReductionOnTarget(
        bool checkTargetAlignment = default,
        AlignmentComponent alignment = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IgnoreDamageReductionOnTarget();
      component.CheckTargetAlignment = checkTargetAlignment;
      component.Alignment = alignment;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IgnorePartialConcealmentOnRangedAttacks"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddIgnorePartialConcealmentOnRangedAttacks(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IgnorePartialConcealmentOnRangedAttacks();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IgnoreSpellResistanceForSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilityList"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddIgnoreSpellResistanceForSpells(
        string[]? abilityList = null,
        bool allSpells = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IgnoreSpellResistanceForSpells();
      component.m_AbilityList = abilityList.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.AllSpells = allSpells;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ImpromptuSneakAttack"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddImpromptuSneakAttack(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ImpromptuSneakAttack();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ImprovedEvasion"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddImprovedEvasion(
        SavingThrowType savingThrow = default)
    {
      var component = new ImprovedEvasion();
      component.SavingThrow = savingThrow;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseAllSpellsDC"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddIncreaseAllSpellsDC(
        ContextValue? value = null,
        ModifierDescriptor descriptor = default,
        bool spellsOnly = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new IncreaseAllSpellsDC();
      component.Value = value ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      component.SpellsOnly = spellsOnly;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IncreaseCasterLevel"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddIncreaseCasterLevel(
        ContextValue? value = null,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new IncreaseCasterLevel();
      component.Value = value ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IncreaseCastersSavingThrowTypeDC"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddIncreaseCastersSavingThrowTypeDC(
        SavingThrowType type = default,
        int bonusDC = default)
    {
      var component = new IncreaseCastersSavingThrowTypeDC();
      component.Type = type;
      component.BonusDC = bonusDC;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseFeatRankByGroup"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddIncreaseFeatRankByGroup(
        FeatureGroup group = default)
    {
      var component = new IncreaseFeatRankByGroup();
      component.Group = group;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellContextDescriptorDC"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddIncreaseSpellContextDescriptorDC(
        SpellDescriptorWrapper descriptor,
        ContextValue? value = null,
        ModifierDescriptor modifierDescriptor = default,
        bool spellsOnly = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new IncreaseSpellContextDescriptorDC();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.ModifierDescriptor = modifierDescriptor;
      component.SpellsOnly = spellsOnly;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellDC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spell"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddIncreaseSpellDC(
        string? spell = null,
        bool halfMythicRank = default,
        bool useContextBonus = default,
        ContextValue? value = null,
        int bonusDC = default,
        ModifierDescriptor descriptor = default,
        bool spellsOnly = default)
    {
      ValidateParam(value);

      var component = new IncreaseSpellDC();
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(spell);
      component.HalfMythicRank = halfMythicRank;
      component.UseContextBonus = useContextBonus;
      component.Value = value ?? ContextValues.Constant(0);
      component.BonusDC = bonusDC;
      component.Descriptor = descriptor;
      component.SpellsOnly = spellsOnly;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellDescriptorCasterLevel"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddIncreaseSpellDescriptorCasterLevel(
        SpellDescriptorWrapper descriptor,
        int bonusCasterLevel = default,
        ModifierDescriptor modifierDescriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IncreaseSpellDescriptorCasterLevel();
      component.Descriptor = descriptor;
      component.BonusCasterLevel = bonusCasterLevel;
      component.ModifierDescriptor = modifierDescriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellDescriptorDC"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddIncreaseSpellDescriptorDC(
        SpellDescriptorWrapper descriptor,
        int bonusDC = default,
        ModifierDescriptor modifierDescriptor = default,
        bool spellsOnly = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IncreaseSpellDescriptorDC();
      component.Descriptor = descriptor;
      component.BonusDC = bonusDC;
      component.ModifierDescriptor = modifierDescriptor;
      component.SpellsOnly = spellsOnly;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellHealing"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddIncreaseSpellHealing(
        SpellSchool school = default,
        ContextValue? healBonus = null)
    {
      ValidateParam(healBonus);

      var component = new IncreaseSpellHealing();
      component.School = school;
      component.HealBonus = healBonus ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellSchoolCasterLevel"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddIncreaseSpellSchoolCasterLevel(
        SpellSchool school = default,
        int bonusLevel = default,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IncreaseSpellSchoolCasterLevel();
      component.School = school;
      component.BonusLevel = bonusLevel;
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellSchoolDC"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddIncreaseSpellSchoolDC(
        SpellSchool school = default,
        int bonusDC = default,
        ModifierDescriptor descriptor = default)
    {
      var component = new IncreaseSpellSchoolDC();
      component.School = school;
      component.BonusDC = bonusDC;
      component.Descriptor = descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellSchoolDamage"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddIncreaseSpellSchoolDamage(
        SpellSchool school = default,
        ContextValue? damageBonus = null)
    {
      ValidateParam(damageBonus);

      var component = new IncreaseSpellSchoolDamage();
      component.School = school;
      component.DamageBonus = damageBonus ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellSpellbookDC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbooks"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellbook"/></param>
    
    
    public TBuilder AddIncreaseSpellSpellbookDC(
        string[]? spellbooks = null,
        int bonusDC = default,
        ModifierDescriptor descriptor = default)
    {
      var component = new IncreaseSpellSpellbookDC();
      component.m_Spellbooks = spellbooks.Select(name => BlueprintTool.GetRef<BlueprintSpellbookReference>(name)).ToArray();
      component.BonusDC = bonusDC;
      component.Descriptor = descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="InitiatorCritAutoconfirm"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddInitiatorCritAutoconfirm(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new InitiatorCritAutoconfirm();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="KensaiCriticalPerfection"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="magusBlueprint"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="chosenWeaponBlueprint"><see cref="Kingmaker.Blueprints.Classes.Selection.BlueprintParametrizedFeature"/></param>
    
    
    public TBuilder AddKensaiCriticalPerfection(
        string? magusBlueprint = null,
        string? chosenWeaponBlueprint = null)
    {
      var component = new KensaiCriticalPerfection();
      component.m_MagusBlueprint = BlueprintTool.GetRef<BlueprintCharacterClassReference>(magusBlueprint);
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(chosenWeaponBlueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KensaiIaijutsuFocus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="magusBlueprint"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="chosenWeaponBlueprint"><see cref="Kingmaker.Blueprints.Classes.Selection.BlueprintParametrizedFeature"/></param>
    
    
    public TBuilder AddKensaiIaijutsuFocus(
        string? magusBlueprint = null,
        string? chosenWeaponBlueprint = null)
    {
      var component = new KensaiIaijutsuFocus();
      component.m_MagusBlueprint = BlueprintTool.GetRef<BlueprintCharacterClassReference>(magusBlueprint);
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(chosenWeaponBlueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KensaiPerfectStrike"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="magusBlueprint"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="chosenWeaponBlueprint"><see cref="Kingmaker.Blueprints.Classes.Selection.BlueprintParametrizedFeature"/></param>
    
    
    public TBuilder AddKensaiPerfectStrike(
        string? magusBlueprint = null,
        string? chosenWeaponBlueprint = null)
    {
      var component = new KensaiPerfectStrike();
      component.m_MagusBlueprint = BlueprintTool.GetRef<BlueprintCharacterClassReference>(magusBlueprint);
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(chosenWeaponBlueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KensaiPowerfulCrit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="magusBlueprint"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="chosenWeaponBlueprint"><see cref="Kingmaker.Blueprints.Classes.Selection.BlueprintParametrizedFeature"/></param>
    
    
    public TBuilder AddKensaiPowerfulCrit(
        string? magusBlueprint = null,
        string? chosenWeaponBlueprint = null)
    {
      var component = new KensaiPowerfulCrit();
      component.m_MagusBlueprint = BlueprintTool.GetRef<BlueprintCharacterClassReference>(magusBlueprint);
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(chosenWeaponBlueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KensaiWeaponMastery"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="magusBlueprint"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="chosenWeaponBlueprint"><see cref="Kingmaker.Blueprints.Classes.Selection.BlueprintParametrizedFeature"/></param>
    
    
    public TBuilder AddKensaiWeaponMastery(
        string? magusBlueprint = null,
        string? chosenWeaponBlueprint = null)
    {
      var component = new KensaiWeaponMastery();
      component.m_MagusBlueprint = BlueprintTool.GetRef<BlueprintCharacterClassReference>(magusBlueprint);
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(chosenWeaponBlueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MadDogPackTactics"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddMadDogPackTactics()
    {
      return AddComponent(new MadDogPackTactics());
    }

    /// <summary>
    /// Adds <see cref="ManeuverBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddManeuverBonus(
        CombatManeuver type = default,
        bool mythic = default,
        int bonus = default,
        ModifierDescriptor descriptor = default)
    {
      var component = new ManeuverBonus();
      component.Type = type;
      component.Mythic = mythic;
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverBonusFromStat"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddManeuverBonusFromStat(
        CombatManeuver type = default,
        StatType stat = default,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ManeuverBonusFromStat();
      component.Type = type;
      component.Stat = stat;
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ManeuverDefenceBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddManeuverDefenceBonus(
        CombatManeuver type = default,
        int bonus = default,
        ModifierDescriptor descriptor = default)
    {
      var component = new ManeuverDefenceBonus();
      component.Type = type;
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverImmunity"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddManeuverImmunity(
        CombatManeuver type = default)
    {
      var component = new ManeuverImmunity();
      component.Type = type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverIncreaseDuration"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddManeuverIncreaseDuration(
        CombatManeuver type = default)
    {
      var component = new ManeuverIncreaseDuration();
      component.Type = type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverOnAttack"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddManeuverOnAttack(
        WeaponCategory category = default,
        CombatManeuver maneuver = default)
    {
      var component = new ManeuverOnAttack();
      component.Category = category;
      component.Maneuver = maneuver;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverProvokeAttack"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddManeuverProvokeAttack(
        CombatManeuver maneuverType = default)
    {
      var component = new ManeuverProvokeAttack();
      component.ManeuverType = maneuverType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddManeuverTrigger(
        CombatManeuver maneuverType = default,
        bool onlySuccess = default,
        ActionsBuilder? action = null)
    {
      var component = new ManeuverTrigger();
      component.ManeuverType = maneuverType;
      component.OnlySuccess = onlySuccess;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MaxDexBonusIncrease"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddMaxDexBonusIncrease(
        int bonus = default,
        int bonesPerRank = default,
        bool checkCategory = default,
        ArmorProficiencyGroup category = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new MaxDexBonusIncrease();
      component.Bonus = bonus;
      component.BonesPerRank = bonesPerRank;
      component.CheckCategory = checkCategory;
      component.Category = category;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="MeleeWeaponSizeChange"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddMeleeWeaponSizeChange(
        int sizeCategoryChange = default)
    {
      var component = new MeleeWeaponSizeChange();
      component.SizeCategoryChange = sizeCategoryChange;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MinimizeAttacksOfOpportunityCount"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddMinimizeAttacksOfOpportunityCount(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new MinimizeAttacksOfOpportunityCount();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ModifyD20"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="tandemTripFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    
    
    public TBuilder AddModifyD20(
        SpellDescriptorWrapper spellDescriptor,
        RuleType rule = default,
        RuleDispelMagic.CheckType dispellMagicCheckType = default,
        bool replace = default,
        int rollsAmount = default,
        bool takeBest = default,
        ContextValue? rollResult = null,
        bool addBonus = default,
        ContextValue? bonus = null,
        ModifierDescriptor bonusDescriptor = default,
        bool withChance = default,
        ContextValue? chance = null,
        bool rerollOnlyIfFailed = default,
        bool rerollOnlyIfSuccess = default,
        ModifyD20.RollConditionType rollCondition = default,
        ContextValue? valueToCompareRoll = null,
        bool dispellOnRerollFinished = default,
        bool dispellOn20 = default,
        bool againstAlignment = default,
        AlignmentComponent alignment = default,
        bool targetAlignment = default,
        bool specificSkill = default,
        StatType[]? skill = null,
        ModifyD20.InnerSavingThrowType savingThrowType = default,
        bool specificDescriptor = default,
        bool addSavingThrowBonus = default,
        ModifierDescriptor modifierDescriptor = default,
        ContextValue? value = null,
        bool tandemTrip = default,
        string? tandemTripFeature = null)
    {
      ValidateParam(rollResult);
      ValidateParam(bonus);
      ValidateParam(chance);
      ValidateParam(valueToCompareRoll);
      ValidateParam(value);

      var component = new ModifyD20();
      component.Rule = rule;
      component.DispellMagicCheckType = dispellMagicCheckType;
      component.Replace = replace;
      component.RollsAmount = rollsAmount;
      component.TakeBest = takeBest;
      component.RollResult = rollResult ?? ContextValues.Constant(0);
      component.AddBonus = addBonus;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.BonusDescriptor = bonusDescriptor;
      component.WithChance = withChance;
      component.Chance = chance ?? ContextValues.Constant(0);
      component.RerollOnlyIfFailed = rerollOnlyIfFailed;
      component.RerollOnlyIfSuccess = rerollOnlyIfSuccess;
      component.RollCondition = rollCondition;
      component.ValueToCompareRoll = valueToCompareRoll ?? ContextValues.Constant(0);
      component.DispellOnRerollFinished = dispellOnRerollFinished;
      component.DispellOn20 = dispellOn20;
      component.AgainstAlignment = againstAlignment;
      component.Alignment = alignment;
      component.TargetAlignment = targetAlignment;
      component.SpecificSkill = specificSkill;
      component.Skill = skill;
      component.m_SavingThrowType = savingThrowType;
      component.SpecificDescriptor = specificDescriptor;
      component.SpellDescriptor = spellDescriptor;
      component.AddSavingThrowBonus = addSavingThrowBonus;
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.TandemTrip = tandemTrip;
      component.m_TandemTripFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(tandemTripFeature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MonkReplaceAbilityDC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    /// <param name="scaledFist"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype"/></param>
    /// <param name="monk"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    
    
    public TBuilder AddMonkReplaceAbilityDC(
        string? ability = null,
        string? scaledFist = null,
        string? monk = null)
    {
      var component = new MonkReplaceAbilityDC();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.m_ScaledFist = BlueprintTool.GetRef<BlueprintArchetypeReference>(scaledFist);
      component.m_Monk = BlueprintTool.GetRef<BlueprintCharacterClassReference>(monk);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MythicUnarmedStrike"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddMythicUnarmedStrike()
    {
      return AddComponent(new MythicUnarmedStrike());
    }

    /// <summary>
    /// Adds <see cref="NewRoundTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddNewRoundTrigger(
        ActionsBuilder? newRoundActions = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new NewRoundTrigger();
      component.NewRoundActions = newRoundActions?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="OnSpawnBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ifHaveFact"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    /// <param name="ifSummonHaveFact"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddOnSpawnBuff(
        SpellDescriptorWrapper spellDescriptor,
        Rounds duration,
        string? ifHaveFact = null,
        bool checkSummonedUnitFact = default,
        string? ifSummonHaveFact = null,
        bool checkSummonedUnitAlignment = default,
        AlignmentComponent summonedAlignment = default,
        string? buff = null,
        bool checkDescriptor = default,
        bool isInfinity = default)
    {
      var component = new OnSpawnBuff();
      component.m_IfHaveFact = BlueprintTool.GetRef<BlueprintFeatureReference>(ifHaveFact);
      component.CheckSummonedUnitFact = checkSummonedUnitFact;
      component.m_IfSummonHaveFact = BlueprintTool.GetRef<BlueprintFeatureReference>(ifSummonHaveFact);
      component.CheckSummonedUnitAlignment = checkSummonedUnitAlignment;
      component.SummonedAlignment = summonedAlignment;
      component.m_buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.CheckDescriptor = checkDescriptor;
      component.SpellDescriptor = spellDescriptor;
      component.IsInfinity = isInfinity;
      component.duration = duration;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Opportunist"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddOpportunist()
    {
      return AddComponent(new Opportunist());
    }

    /// <summary>
    /// Adds <see cref="OutflankAttackBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="outflankFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddOutflankAttackBonus(
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        string? outflankFact = null)
    {
      var component = new OutflankAttackBonus();
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.m_OutflankFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(outflankFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OutflankDamageBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="outflankFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddOutflankDamageBonus(
        int damageBonus = default,
        int increasedDamageBonus = default,
        string? outflankFact = null)
    {
      var component = new OutflankDamageBonus();
      component.DamageBonus = damageBonus;
      component.IncreasedDamageBonus = increasedDamageBonus;
      component.m_OutflankFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(outflankFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OutflankProvokeAttack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="outflankFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddOutflankProvokeAttack(
        string? outflankFact = null)
    {
      var component = new OutflankProvokeAttack();
      component.m_OutflankFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(outflankFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PartialDRIgnore"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddPartialDRIgnore(
        int reductionReduction = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new PartialDRIgnore();
      component.ReductionReduction = reductionReduction;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="PenetratingStrike"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddPenetratingStrike(
        int reductionReduction = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new PenetratingStrike();
      component.ReductionReduction = reductionReduction;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="PetManeuverProvokeAttack"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddPetManeuverProvokeAttack(
        CombatManeuver[]? maneuver = null)
    {
      var component = new PetManeuverProvokeAttack();
      component.Maneuver = maneuver;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PointBlankMaster"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddPointBlankMaster(
        WeaponCategory category = default)
    {
      var component = new PointBlankMaster();
      component.Category = category;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PointBlankMasterParametrized"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddPointBlankMasterParametrized()
    {
      return AddComponent(new PointBlankMasterParametrized());
    }

    /// <summary>
    /// Adds <see cref="PowerAttackWatcher"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="powerAttackBlueprint"><see cref="Kingmaker.UnitLogic.ActivatableAbilities.BlueprintActivatableAbility"/></param>
    
    
    public TBuilder AddPowerAttackWatcher(
        string? powerAttackBlueprint = null)
    {
      var component = new PowerAttackWatcher();
      component.m_PowerAttackBlueprint = BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(powerAttackBlueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PreciseShot"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddPreciseShot(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new PreciseShot();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="PreciseShotDivineHunterTarget"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddPreciseShotDivineHunterTarget(
        string? buff = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new PreciseShotDivineHunterTarget();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="PreciseStrike"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="preciseStrikeFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddPreciseStrike(
        DamageDescription damage,
        string? preciseStrikeFact = null)
    {
      ValidateParam(damage);

      var component = new PreciseStrike();
      component.Damage = damage;
      component.m_PreciseStrikeFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(preciseStrikeFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RangedWeaponSizeChange"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponTypes"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintWeaponType"/></param>
    
    
    public TBuilder AddRangedWeaponSizeChange(
        int sizeCategoryChange = default,
        string[]? weaponTypes = null)
    {
      var component = new RangedWeaponSizeChange();
      component.SizeCategoryChange = sizeCategoryChange;
      component.WeaponTypes = weaponTypes.Select(name => BlueprintTool.GetRef<BlueprintWeaponTypeReference>(name)).ToList();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecalculateConcealment"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddRecalculateConcealment(
        bool ignorePartial = default,
        bool treatTotalAsPartial = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RecalculateConcealment();
      component.IgnorePartial = ignorePartial;
      component.TreatTotalAsPartial = treatTotalAsPartial;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RecalculateOnFactsChange"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddRecalculateOnFactsChange(
        string[]? checkedFacts = null)
    {
      var component = new RecalculateOnFactsChange();
      component.m_CheckedFacts = checkedFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecalculateOnLocustSwarmChange"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddRecalculateOnLocustSwarmChange(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RecalculateOnLocustSwarmChange();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RecalculateOnStatChange"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddRecalculateOnStatChange(
        bool useKineticistMainStat = default,
        StatType stat = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RecalculateOnStatChange();
      component.UseKineticistMainStat = useKineticistMainStat;
      component.Stat = stat;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RecommendedClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="favoriteClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    
    
    public TBuilder AddRecommendedClass(
        string? favoriteClass = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RecommendedClass();
      component.m_FavoriteClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(favoriteClass);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RemoveAfterCast"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilities"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddRemoveAfterCast(
        string[]? abilities = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RemoveAfterCast();
      component.Abilities = abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToList();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffOnAttack"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddRemoveBuffOnAttack(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RemoveBuffOnAttack();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RemoveFeatureOnApply"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddRemoveFeatureOnApply(
        string? feature = null)
    {
      var component = new RemoveFeatureOnApply();
      component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(feature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RendFeature"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddRendFeature(
        DiceFormula rendDamage,
        DamageTypeDescription rendType,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(rendType);

      var component = new RendFeature();
      component.RendDamage = rendDamage;
      component.RendType = rendType;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ReplaceAbilitiesStat"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddReplaceAbilitiesStat(
        string[]? ability = null,
        StatType stat = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ReplaceAbilitiesStat();
      component.m_Ability = ability.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.Stat = stat;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ReplaceAbilityDC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddReplaceAbilityDC(
        string? ability = null,
        StatType stat = default)
    {
      var component = new ReplaceAbilityDC();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.Stat = stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceAbilityParamsWithContext"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddReplaceAbilityParamsWithContext(
        string? ability = null)
    {
      var component = new ReplaceAbilityParamsWithContext();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceCMDDexterityStat"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddReplaceCMDDexterityStat(
        StatType newStat = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ReplaceCMDDexterityStat();
      component.NewStat = newStat;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ReplaceCastSource"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddReplaceCastSource(
        CastSource castSource = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ReplaceCastSource();
      component.CastSource = castSource;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ReplaceCasterLevelOfAbility"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spell"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    /// <param name="clazz"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="additionalClasses"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="archetypes"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype"/></param>
    
    
    public TBuilder AddReplaceCasterLevelOfAbility(
        string? spell = null,
        string? clazz = null,
        string[]? additionalClasses = null,
        string[]? archetypes = null)
    {
      var component = new ReplaceCasterLevelOfAbility();
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(spell);
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      component.m_AdditionalClasses = additionalClasses.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray();
      component.m_Archetypes = archetypes.Select(name => BlueprintTool.GetRef<BlueprintArchetypeReference>(name)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceCasterLevelOfFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    /// <param name="clazz"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    
    
    public TBuilder AddReplaceCasterLevelOfFeature(
        string? feature = null,
        string? clazz = null)
    {
      var component = new ReplaceCasterLevelOfFeature();
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceCombatManeuverStat"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddReplaceCombatManeuverStat(
        StatType statType = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ReplaceCombatManeuverStat();
      component.StatType = statType;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ReplaceSingleCombatManeuverStat"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddReplaceSingleCombatManeuverStat(
        CombatManeuver type = default,
        StatType statType = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ReplaceSingleCombatManeuverStat();
      component.Type = type;
      component.StatType = statType;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ReplaceSourceBone"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddReplaceSourceBone(
        string sourceBone)
    {
      var component = new ReplaceSourceBone();
      component.SourceBone = sourceBone;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceStatForPrerequisites"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    
    
    public TBuilder AddReplaceStatForPrerequisites(
        StatType oldStat = default,
        ReplaceStatForPrerequisites.StatReplacementPolicy policy = default,
        StatType newStat = default,
        string? characterClass = null,
        int specificNumber = default)
    {
      var component = new ReplaceStatForPrerequisites();
      component.OldStat = oldStat;
      component.Policy = policy;
      component.NewStat = newStat;
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.SpecificNumber = specificNumber;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RerollConcealment"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddRerollConcealment(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RerollConcealment();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RideAnimalCompanion"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddRideAnimalCompanion(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RideAnimalCompanion();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SaturationAuraComponent"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSaturationAuraComponent(
        SaturationAuraType saturationAuraType = default,
        float radius = default,
        float distanceToCamera = default)
    {
      var component = new SaturationAuraComponent();
      component.m_SaturationAuraType = saturationAuraType;
      component.m_Radius = radius;
      component.m_DistanceToCamera = distanceToCamera;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavesFixedRecalculateThievery"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSavesFixedRecalculateThievery(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SavesFixedRecalculateThievery();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SavesFixerFactReplacer"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="oldFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    /// <param name="newFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddSavesFixerFactReplacer(
        string[]? oldFacts = null,
        string[]? newFacts = null)
    {
      var component = new SavesFixerFactReplacer();
      component.m_OldFacts = oldFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_NewFacts = newFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavesFixerReplaceInProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="oldFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    /// <param name="newFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    
    
    public TBuilder AddSavesFixerReplaceInProgression(
        string? oldFeature = null,
        string? newFeature = null)
    {
      var component = new SavesFixerReplaceInProgression();
      component.m_OldFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(oldFeature);
      component.m_NewFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(newFeature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingSlash"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSavingSlash(
        bool useContextValue = default,
        int bonus = default,
        ContextValue? value = null,
        WeaponCategory weapon = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new SavingSlash();
      component.UseContextValue = useContextValue;
      component.Bonus = bonus;
      component.Value = value ?? ContextValues.Constant(0);
      component.Weapon = weapon;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstAbilityType"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSavingThrowBonusAgainstAbilityType(
        AbilityType abilityType = default,
        ModifierDescriptor modifierDescriptor = default,
        int value = default,
        ContextValue? bonus = null,
        bool onlyPositiveValue = default)
    {
      ValidateParam(bonus);

      var component = new SavingThrowBonusAgainstAbilityType();
      component.AbilityType = abilityType;
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.OnlyPositiveValue = onlyPositiveValue;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstAlignment"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSavingThrowBonusAgainstAlignment(
        AlignmentComponent alignment = default,
        ModifierDescriptor descriptor = default,
        int value = default,
        ContextValue? bonus = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(bonus);

      var component = new SavingThrowBonusAgainstAlignment();
      component.Alignment = alignment;
      component.Descriptor = descriptor;
      component.Value = value;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstAlignmentDifference"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSavingThrowBonusAgainstAlignmentDifference(
        ModifierDescriptor descriptor = default,
        int value = default,
        int alignmentDifference = default,
        SavingThrowType savingThrow = default)
    {
      var component = new SavingThrowBonusAgainstAlignmentDifference();
      component.Descriptor = descriptor;
      component.Value = value;
      component.AlignmentDifference = alignmentDifference;
      component.SavingThrow = savingThrow;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstAllies"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="disablingFeature"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddSavingThrowBonusAgainstAllies(
        ModifierDescriptor modifierDescriptor = default,
        int value = default,
        ContextValue? bonus = null,
        bool onlyPositiveValue = default,
        string? disablingFeature = null)
    {
      ValidateParam(bonus);

      var component = new SavingThrowBonusAgainstAllies();
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.OnlyPositiveValue = onlyPositiveValue;
      component.m_DisablingFeature = BlueprintTool.GetRef<BlueprintUnitFactReference>(disablingFeature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstDescriptor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="disablingFeature"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddSavingThrowBonusAgainstDescriptor(
        SpellDescriptorWrapper spellDescriptor,
        ModifierDescriptor modifierDescriptor = default,
        int value = default,
        ContextValue? bonus = null,
        bool onlyPositiveValue = default,
        string? disablingFeature = null)
    {
      ValidateParam(bonus);

      var component = new SavingThrowBonusAgainstDescriptor();
      component.SpellDescriptor = spellDescriptor;
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.OnlyPositiveValue = onlyPositiveValue;
      component.m_DisablingFeature = BlueprintTool.GetRef<BlueprintUnitFactReference>(disablingFeature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    
    
    public TBuilder AddSavingThrowBonusAgainstFact(
        string? checkedFact = null,
        ModifierDescriptor descriptor = default,
        int value = default,
        AlignmentComponent alignment = default)
    {
      var component = new SavingThrowBonusAgainstFact();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintFeatureReference>(checkedFact);
      component.Descriptor = descriptor;
      component.Value = value;
      component.Alignment = alignment;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstFactMultiple"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddSavingThrowBonusAgainstFactMultiple(
        string[]? facts = null,
        ModifierDescriptor descriptor = default,
        int value = default,
        AlignmentComponent alignment = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SavingThrowBonusAgainstFactMultiple();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.Descriptor = descriptor;
      component.Value = value;
      component.Alignment = alignment;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstSchool"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSavingThrowBonusAgainstSchool(
        SpellSchool school = default,
        ModifierDescriptor modifierDescriptor = default,
        int value = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SavingThrowBonusAgainstSchool();
      component.School = school;
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstSchoolAbilityValue"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSavingThrowBonusAgainstSchoolAbilityValue(
        SpellSchool school = default,
        ModifierDescriptor modifierDescriptor = default,
        int value = default,
        ContextValue? bonus = null)
    {
      ValidateParam(bonus);

      var component = new SavingThrowBonusAgainstSchoolAbilityValue();
      component.School = school;
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstSpecificSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    /// <param name="bypassFeatures"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddSavingThrowBonusAgainstSpecificSpells(
        string[]? spells = null,
        ModifierDescriptor modifierDescriptor = default,
        int value = default,
        string[]? bypassFeatures = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SavingThrowBonusAgainstSpecificSpells();
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value;
      component.m_BypassFeatures = bypassFeatures.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstSpellType"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSavingThrowBonusAgainstSpellType(
        bool againstArcaneSpells = default,
        ModifierDescriptor modifierDescriptor = default,
        int value = default,
        ContextValue? bonus = null,
        bool onlyPositiveValue = default)
    {
      ValidateParam(bonus);

      var component = new SavingThrowBonusAgainstSpellType();
      component.AgainstArcaneSpells = againstArcaneSpells;
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.OnlyPositiveValue = onlyPositiveValue;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusUnlessFactMultiple"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddSavingThrowBonusUnlessFactMultiple(
        string[]? facts = null,
        ModifierDescriptor descriptor = default,
        AlignmentComponent alignment = default,
        SavingThrowType type = default,
        int value = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SavingThrowBonusUnlessFactMultiple();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.Descriptor = descriptor;
      component.Alignment = alignment;
      component.Type = type;
      component.Value = value;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowContextBonusAgainstDescriptor"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSavingThrowContextBonusAgainstDescriptor(
        SpellDescriptorWrapper spellDescriptor,
        ModifierDescriptor modifierDescriptor = default,
        ContextValue? value = null)
    {
      ValidateParam(value);

      var component = new SavingThrowContextBonusAgainstDescriptor();
      component.SpellDescriptor = spellDescriptor;
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShakeItOff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="shakeItOffFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddShakeItOff(
        string? shakeItOffFact = null,
        int radius = default)
    {
      var component = new ShakeItOff();
      component.m_ShakeItOffFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(shakeItOffFact);
      component.Radius = radius;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShareBuffsWithPet"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buffs"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddShareBuffsWithPet(
        PetType type = default,
        string[]? buffs = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ShareBuffsWithPet();
      component.Type = type;
      component.m_Buffs = buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ShareFavoredEnemies"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddShareFavoredEnemies(
        bool half = default,
        bool toPet = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ShareFavoredEnemies();
      component.Half = half;
      component.ToPet = toPet;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ShareFeaturesWithPet"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="features"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    
    
    public TBuilder AddShareFeaturesWithPet(
        PetType type = default,
        string[]? features = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ShareFeaturesWithPet();
      component.Type = type;
      component.m_Features = features.Select(name => BlueprintTool.GetRef<BlueprintFeatureReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ShatterConfidence"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="confoundingDuelistFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    
    
    public TBuilder AddShatterConfidence(
        string? confoundingDuelistFeature = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ShatterConfidence();
      component.m_ConfoundingDuelistFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(confoundingDuelistFeature);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ShieldWall"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="shieldWallFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddShieldWall(
        string? shieldWallFact = null,
        int radius = default)
    {
      var component = new ShieldWall();
      component.m_ShieldWallFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(shieldWallFact);
      component.Radius = radius;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShieldedCaster"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="shieldedCasterFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddShieldedCaster(
        string? shieldedCasterFact = null,
        int radius = default)
    {
      var component = new ShieldedCaster();
      component.m_ShieldedCasterFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(shieldedCasterFact);
      component.Radius = radius;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SiezeTheMoment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="siezeTheMomentFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddSiezeTheMoment(
        string? siezeTheMomentFact = null)
    {
      var component = new SiezeTheMoment();
      component.m_SiezeTheMomentFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(siezeTheMomentFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellFixedCL"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddSpellFixedCL(
        string? ability = null,
        int cL = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SpellFixedCL();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.CL = cL;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SpellFixedDC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddSpellFixedDC(
        string? ability = null,
        int dC = default)
    {
      var component = new SpellFixedDC();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.DC = dC;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellLevelByClassLevel"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    /// <param name="clazz"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    
    
    public TBuilder AddSpellLevelByClassLevel(
        string? ability = null,
        string? clazz = null)
    {
      var component = new SpellLevelByClassLevel();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellLevelByRank"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddSpellLevelByRank(
        string? ability = null)
    {
      var component = new SpellLevelByRank();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellPenetrationBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="requiredFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddSpellPenetrationBonus(
        ContextValue? value = null,
        ModifierDescriptor descriptor = default,
        bool checkFact = default,
        string? requiredFact = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new SpellPenetrationBonus();
      component.Value = value ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      component.CheckFact = checkFact;
      component.m_RequiredFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(requiredFact);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SpellPenetrationMythicBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="greater"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddSpellPenetrationMythicBonus(
        string? greater = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SpellPenetrationMythicBonus();
      component.m_Greater = BlueprintTool.GetRef<BlueprintUnitFactReference>(greater);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SpendChargesOnSpellCast"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spell"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    /// <param name="spendSpellCharges"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddSpendChargesOnSpellCast(
        string? spell = null,
        string? spendSpellCharges = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SpendChargesOnSpellCast();
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(spell);
      component.m_SpendSpellCharges = BlueprintTool.GetRef<BlueprintAbilityReference>(spendSpellCharges);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SurpriseSpells"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSurpriseSpells(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SurpriseSpells();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="Take10ForSuccess"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTake10ForSuccess(
        StatType skill = default,
        bool anyType = default,
        UsableItemType magicDeviceType = default)
    {
      var component = new Take10ForSuccess();
      component.Skill = skill;
      component.AnyType = anyType;
      component.MagicDeviceType = magicDeviceType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TargetChangedDuringRound"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTargetChangedDuringRound(
        ActionsBuilder? actions = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TargetChangedDuringRound();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TargetCritAutoconfirm"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTargetCritAutoconfirm(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TargetCritAutoconfirm();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TargetCritAutoconfirmFromCaster"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTargetCritAutoconfirmFromCaster(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TargetCritAutoconfirmFromCaster();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TellingBlow"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="immunityFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddTellingBlow(
        int reductionReduction = default,
        string? buff = null,
        string? immunityFact = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TellingBlow();
      component.ReductionReduction = reductionReduction;
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.m_ImmunityFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(immunityFact);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ToughnessLogic"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddToughnessLogic(
        bool checkMythicLevel = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ToughnessLogic();
      component.CheckMythicLevel = checkMythicLevel;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TransferDescriptorBonusToSavingThrow"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTransferDescriptorBonusToSavingThrow(
        ModifierDescriptor descriptor = default,
        int maxBonus = default,
        bool checkArmorCategory = default,
        ArmorProficiencyGroup category = default,
        SavingThrowType type = default)
    {
      var component = new TransferDescriptorBonusToSavingThrow();
      component.Descriptor = descriptor;
      component.MaxBonus = maxBonus;
      component.CheckArmorCategory = checkArmorCategory;
      component.Category = category;
      component.Type = type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TransferDescriptorBonusToTouchAC"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTransferDescriptorBonusToTouchAC(
        ModifierDescriptor descriptor = default,
        int maxBonus = default,
        bool checkArmorCategory = default,
        ArmorProficiencyGroup category = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TransferDescriptorBonusToTouchAC();
      component.Descriptor = descriptor;
      component.MaxBonus = maxBonus;
      component.CheckArmorCategory = checkArmorCategory;
      component.Category = category;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TrapPerceptionBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTrapPerceptionBonus(
        ModifierDescriptor descriptor = default,
        ContextValue? value = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new TrapPerceptionBonus();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TricksterArcanaAdditionalEnchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="commonEnchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/></param>
    /// <param name="weaponEnchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintWeaponEnchantment"/></param>
    /// <param name="armorEnchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintArmorEnchantment"/></param>
    
    
    public TBuilder AddTricksterArcanaAdditionalEnchantments(
        string[]? commonEnchantments = null,
        string[]? weaponEnchantments = null,
        string[]? armorEnchantments = null,
        bool onlyWeaponsShieldsAndArmor = default)
    {
      var component = new TricksterArcanaAdditionalEnchantments();
      component.CommonEnchantments = commonEnchantments.Select(name => BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(name)).ToArray();
      component.WeaponEnchantments = weaponEnchantments.Select(name => BlueprintTool.GetRef<BlueprintWeaponEnchantmentReference>(name)).ToArray();
      component.ArmorEnchantments = armorEnchantments.Select(name => BlueprintTool.GetRef<BlueprintArmorEnchantmentReference>(name)).ToArray();
      component.OnlyWeaponsShieldsAndArmor = onlyWeaponsShieldsAndArmor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TricksterArcanaBetterEnhancements"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enhancementEnchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/></param>
    /// <param name="bestEnchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/></param>
    
    
    public TBuilder AddTricksterArcanaBetterEnhancements(
        string[]? enhancementEnchantments = null,
        string[]? bestEnchantments = null)
    {
      var component = new TricksterArcanaBetterEnhancements();
      component.EnhancementEnchantments = enhancementEnchantments.Select(name => BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(name)).ToArray();
      component.BestEnchantments = bestEnchantments.Select(name => BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(name)).ToList();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TricksterKnowledgeWorldD20"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTricksterKnowledgeWorldD20()
    {
      return AddComponent(new TricksterKnowledgeWorldD20());
    }

    /// <summary>
    /// Adds <see cref="TricksterKnowledgeWorldSkillBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTricksterKnowledgeWorldSkillBonus()
    {
      return AddComponent(new TricksterKnowledgeWorldSkillBonus());
    }

    /// <summary>
    /// Adds <see cref="TricksterLoreNatureRestTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="tier1Buffs"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="tier2Buffs"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="tier3Buffs"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="tier2Feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    /// <param name="tier3Feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    
    
    public TBuilder AddTricksterLoreNatureRestTrigger(
        string[]? tier1Buffs = null,
        string[]? tier2Buffs = null,
        string[]? tier3Buffs = null,
        string? tier2Feature = null,
        string? tier3Feature = null)
    {
      var component = new TricksterLoreNatureRestTrigger();
      component.Tier1Buffs = tier1Buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
      component.Tier2Buffs = tier2Buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
      component.Tier3Buffs = tier3Buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
      component.m_Tier2Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(tier2Feature);
      component.m_Tier3Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(tier3Feature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TwoWeaponDefense"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTwoWeaponDefense()
    {
      return AddComponent(new TwoWeaponDefense());
    }

    /// <summary>
    /// Adds <see cref="TwoWeaponFightingAttackPenalty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="mythicBlueprint"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    
    
    public TBuilder AddTwoWeaponFightingAttackPenalty(
        string? mythicBlueprint = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TwoWeaponFightingAttackPenalty();
      component.m_MythicBlueprint = BlueprintTool.GetRef<BlueprintFeatureReference>(mythicBlueprint);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TwoWeaponFightingAttacks"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTwoWeaponFightingAttacks(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TwoWeaponFightingAttacks();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TwoWeaponFightingDamagePenalty"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTwoWeaponFightingDamagePenalty(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TwoWeaponFightingDamagePenalty();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="UndeadHealth"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddUndeadHealth(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new UndeadHealth();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="UnitDeathTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddUnitDeathTrigger(
        ContextValue? radiusInMeters = null,
        UnitDeathTrigger.FactionType faction = default,
        ActionsBuilder? actions = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(radiusInMeters);

      var component = new UnitDeathTrigger();
      component.RadiusInMeters = radiusInMeters ?? ContextValues.Constant(0);
      component.Faction = faction;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="VolleyFireAttackBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddVolleyFireAttackBonus()
    {
      return AddComponent(new VolleyFireAttackBonus());
    }

    /// <summary>
    /// Adds <see cref="WeaponCategoryAttackBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddWeaponCategoryAttackBonus(
        WeaponCategory category = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponCategoryAttackBonus();
      component.Category = category;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponFocus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintWeaponType"/></param>
    
    
    public TBuilder AddWeaponFocus(
        string? weaponType = null,
        int attackBonus = default,
        ModifierDescriptor descriptor = default)
    {
      var component = new WeaponFocus();
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupAttackBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddWeaponGroupAttackBonus(
        WeaponFighterGroup weaponGroup = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        bool multiplyByContext = default,
        ContextValue? contextMultiplier = null)
    {
      ValidateParam(contextMultiplier);

      var component = new WeaponGroupAttackBonus();
      component.WeaponGroup = weaponGroup;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.multiplyByContext = multiplyByContext;
      component.contextMultiplier = contextMultiplier ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupDamageBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddWeaponGroupDamageBonus(
        WeaponFighterGroup weaponGroup = default,
        int damageBonus = default,
        ContextValue? additionalValue = null,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(additionalValue);

      var component = new WeaponGroupDamageBonus();
      component.WeaponGroup = weaponGroup;
      component.DamageBonus = damageBonus;
      component.AdditionalValue = additionalValue ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupEnchant"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddWeaponGroupEnchant(
        WeaponFighterGroup weaponGroup = default,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponGroupEnchant();
      component.WeaponGroup = weaponGroup;
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponMultipleCategoriesAttackBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddWeaponMultipleCategoriesAttackBonus(
        WeaponCategory[]? categories = null,
        int attackBonus = default,
        bool exceptForCategories = default,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponMultipleCategoriesAttackBonus();
      component.Categories = categories;
      component.AttackBonus = attackBonus;
      component.ExceptForCategories = exceptForCategories;
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponParametersAttackBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="fightersFinesse"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    /// <param name="multiplierFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddWeaponParametersAttackBonus(
        bool onlyFinessable = default,
        bool canBeUsedWithFightersFinesse = default,
        string? fightersFinesse = null,
        bool ranged = default,
        bool onlyTwoHanded = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        bool scaleByBasicAttackBonus = default,
        bool onlyForFullAttack = default,
        string? multiplierFact = null,
        int multiplier = default)
    {
      var component = new WeaponParametersAttackBonus();
      component.OnlyFinessable = onlyFinessable;
      component.CanBeUsedWithFightersFinesse = canBeUsedWithFightersFinesse;
      component.m_FightersFinesse = BlueprintTool.GetRef<BlueprintFeatureReference>(fightersFinesse);
      component.Ranged = ranged;
      component.OnlyTwoHanded = onlyTwoHanded;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.ScaleByBasicAttackBonus = scaleByBasicAttackBonus;
      component.OnlyForFullAttack = onlyForFullAttack;
      component.m_MultiplierFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(multiplierFact);
      component.Multiplier = multiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponParametersCriticalEdgeIncrease"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddWeaponParametersCriticalEdgeIncrease(
        bool light = default,
        bool ranged = default,
        bool twoHanded = default)
    {
      var component = new WeaponParametersCriticalEdgeIncrease();
      component.Light = light;
      component.Ranged = ranged;
      component.TwoHanded = twoHanded;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponParametersCriticalMultiplierIncrease"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddWeaponParametersCriticalMultiplierIncrease(
        bool light = default,
        bool ranged = default,
        bool twoHanded = default,
        int additionalMultiplier = default)
    {
      var component = new WeaponParametersCriticalMultiplierIncrease();
      component.Light = light;
      component.Ranged = ranged;
      component.TwoHanded = twoHanded;
      component.AdditionalMultiplier = additionalMultiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponParametersDamageBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="fightersFinesse"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    /// <param name="greaterPowerAttackBlueprint"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    /// <param name="mythicBlueprint"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    /// <param name="weaponBlueprint"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintItemWeapon"/></param>
    
    
    public TBuilder AddWeaponParametersDamageBonus(
        bool onlyFinessable = default,
        bool canBeUsedWithFightersFinesse = default,
        string? fightersFinesse = null,
        bool ranged = default,
        bool onlyTwoHanded = default,
        int damageBonus = default,
        bool scaleByBasicAttackBonus = default,
        bool powerAttackScaling = default,
        bool dualWielding = default,
        bool onlyToOffHandBonus = default,
        bool onlySpecificItemBlueprint = default,
        string? greaterPowerAttackBlueprint = null,
        string? mythicBlueprint = null,
        string? weaponBlueprint = null)
    {
      var component = new WeaponParametersDamageBonus();
      component.OnlyFinessable = onlyFinessable;
      component.CanBeUsedWithFightersFinesse = canBeUsedWithFightersFinesse;
      component.m_FightersFinesse = BlueprintTool.GetRef<BlueprintFeatureReference>(fightersFinesse);
      component.Ranged = ranged;
      component.OnlyTwoHanded = onlyTwoHanded;
      component.DamageBonus = damageBonus;
      component.ScaleByBasicAttackBonus = scaleByBasicAttackBonus;
      component.PowerAttackScaling = powerAttackScaling;
      component.DualWielding = dualWielding;
      component.OnlyToOffHandBonus = onlyToOffHandBonus;
      component.OnlySpecificItemBlueprint = onlySpecificItemBlueprint;
      component.m_GreaterPowerAttackBlueprint = BlueprintTool.GetRef<BlueprintFeatureReference>(greaterPowerAttackBlueprint);
      component.m_MythicBlueprint = BlueprintTool.GetRef<BlueprintFeatureReference>(mythicBlueprint);
      component.m_WeaponBlueprint = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weaponBlueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponSizeChange"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddWeaponSizeChange(
        int sizeCategoryChange = default,
        bool checkWeaponCategory = default,
        WeaponCategory category = default)
    {
      var component = new WeaponSizeChange();
      component.SizeCategoryChange = sizeCategoryChange;
      component.CheckWeaponCategory = checkWeaponCategory;
      component.Category = category;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeCriticalEdgeIncrease"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintWeaponType"/></param>
    
    
    public TBuilder AddWeaponTypeCriticalEdgeIncrease(
        string? weaponType = null)
    {
      var component = new WeaponTypeCriticalEdgeIncrease();
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeCriticalEdgeIncreaseStackable"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddWeaponTypeCriticalEdgeIncreaseStackable(
        bool anyCategory = default,
        WeaponCategory category = default)
    {
      var component = new WeaponTypeCriticalEdgeIncreaseStackable();
      component.AnyCategory = anyCategory;
      component.Category = category;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeCriticalMultiplierIncrease"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintWeaponType"/></param>
    
    
    public TBuilder AddWeaponTypeCriticalMultiplierIncrease(
        string? weaponType = null,
        int additionalMultiplier = default)
    {
      var component = new WeaponTypeCriticalMultiplierIncrease();
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.AdditionalMultiplier = additionalMultiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeDamageBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintWeaponType"/></param>
    
    
    public TBuilder AddWeaponTypeDamageBonus(
        string? weaponType = null,
        int damageBonus = default)
    {
      var component = new WeaponTypeDamageBonus();
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.DamageBonus = damageBonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddWeaponTypeDamageStatReplacement(
        StatType stat = default,
        WeaponCategory category = default,
        bool onlyOneHanded = default,
        bool twoHandedBonus = default)
    {
      var component = new WeaponTypeDamageStatReplacement();
      component.Stat = stat;
      component.Category = category;
      component.OnlyOneHanded = onlyOneHanded;
      component.TwoHandedBonus = twoHandedBonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ImpatienceCalmingPart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="impatience"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="targetedImpatience"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="patience"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddImpatienceCalmingPart(
        string? impatience = null,
        string? targetedImpatience = null,
        string? patience = null)
    {
      var component = new ImpatienceCalmingPart();
      component.m_Impatience = BlueprintTool.GetRef<BlueprintBuffReference>(impatience);
      component.m_TargetedImpatience = BlueprintTool.GetRef<BlueprintBuffReference>(targetedImpatience);
      component.m_Patience = BlueprintTool.GetRef<BlueprintBuffReference>(patience);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ImpatienceWatcherTickingResolve"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="impatience"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="targetedImpatience"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="patience"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddImpatienceWatcherTickingResolve(
        string? impatience = null,
        string? targetedImpatience = null,
        string? patience = null,
        int[]? resolveChances = null,
        int[]? resolveChancesForLowInt = null,
        int[]? resolveChancesForHighInt = null)
    {
      var component = new ImpatienceWatcherTickingResolve();
      component.m_Impatience = BlueprintTool.GetRef<BlueprintBuffReference>(impatience);
      component.m_TargetedImpatience = BlueprintTool.GetRef<BlueprintBuffReference>(targetedImpatience);
      component.m_Patience = BlueprintTool.GetRef<BlueprintBuffReference>(patience);
      component.ResolveChances = resolveChances;
      component.ResolveChancesForLowInt = resolveChancesForLowInt;
      component.ResolveChancesForHighInt = resolveChancesForHighInt;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Afterbuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="afterBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddAfterbuff(
        string? afterBuff = null,
        int durationMultiplier = default)
    {
      var component = new Afterbuff();
      component.m_AfterBuff = BlueprintTool.GetRef<BlueprintBuffReference>(afterBuff);
      component.DurationMultiplier = durationMultiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AfterbuffIfHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="featureToCheck"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    /// <param name="afterBuffFalse"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="afterBuffTrue"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddAfterbuffIfHasFact(
        string? featureToCheck = null,
        string? afterBuffFalse = null,
        string? afterBuffTrue = null,
        int durationMultiplier = default)
    {
      var component = new AfterbuffIfHasFact();
      component.m_FeatureToCheck = BlueprintTool.GetRef<BlueprintFeatureReference>(featureToCheck);
      component.m_AfterBuffFalse = BlueprintTool.GetRef<BlueprintBuffReference>(afterBuffFalse);
      component.m_AfterBuffTrue = BlueprintTool.GetRef<BlueprintBuffReference>(afterBuffTrue);
      component.DurationMultiplier = durationMultiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmagsBladeEnrage"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddArmagsBladeEnrage(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ArmagsBladeEnrage();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ArmorFocus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddArmorFocus(
        ArmorProficiencyGroup armorCategory = default)
    {
      var component = new ArmorFocus();
      component.ArmorCategory = armorCategory;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffAbilityRollsBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBuffAbilityRollsBonus(
        int value = default,
        ModifierDescriptor descriptor = default,
        bool affectAllStats = default,
        bool onlyHighesStats = default,
        ContextValue? multiplier = null,
        StatType stat = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(multiplier);

      var component = new BuffAbilityRollsBonus();
      component.Value = value;
      component.Descriptor = descriptor;
      component.AffectAllStats = affectAllStats;
      component.OnlyHighesStats = onlyHighesStats;
      component.Multiplier = multiplier ?? ContextValues.Constant(0);
      component.Stat = stat;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BuffAllSavesBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBuffAllSavesBonus(
        ModifierDescriptor descriptor = default,
        int value = default)
    {
      var component = new BuffAllSavesBonus();
      component.Descriptor = descriptor;
      component.Value = value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffAllSkillsBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBuffAllSkillsBonus(
        ModifierDescriptor descriptor = default,
        int value = default,
        ContextValue? multiplier = null)
    {
      ValidateParam(multiplier);

      var component = new BuffAllSkillsBonus();
      component.Descriptor = descriptor;
      component.Value = value;
      component.Multiplier = multiplier ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffAllSkillsBonusAbilityValue"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBuffAllSkillsBonusAbilityValue(
        ModifierDescriptor descriptor = default,
        ContextValue? value = null)
    {
      ValidateParam(value);

      var component = new BuffAllSkillsBonusAbilityValue();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffAllSkillsBonusRankDependent"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBuffAllSkillsBonusRankDependent(
        ModifierDescriptor descriptor = default,
        int value = default,
        int minimalRank = default)
    {
      var component = new BuffAllSkillsBonusRankDependent();
      component.Descriptor = descriptor;
      component.Value = value;
      component.MinimalRank = minimalRank;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffDamageEachRound"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBuffDamageEachRound(
        DiceFormula energyDamageDice,
        int baseRounds = default,
        float additionalRoundsPerCasterLevel = default,
        DamageEnergyType element = default)
    {
      var component = new BuffDamageEachRound();
      component.baseRounds = baseRounds;
      component.AdditionalRoundsPerCasterLevel = additionalRoundsPerCasterLevel;
      component.EnergyDamageDice = energyDamageDice;
      component.Element = element;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffExtraAttack"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBuffExtraAttack(
        int number = default,
        bool haste = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new BuffExtraAttack();
      component.Number = number;
      component.Haste = haste;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BuffExtraAttackWeaponSpecific"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBuffExtraAttackWeaponSpecific(
        WeaponRangeType rangeType = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new BuffExtraAttackWeaponSpecific();
      component.RangeType = rangeType;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BuffIncomingDamageIncrease"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBuffIncomingDamageIncrease(
        ContextValue? value = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new BuffIncomingDamageIncrease();
      component.Value = value ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BuffMiraculousHealing"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBuffMiraculousHealing(
        float empowerMiraculousModifier = default,
        float savedModifier = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new BuffMiraculousHealing();
      component.EmpowerMiraculousModifier = empowerMiraculousModifier;
      component.m_SavedModifier = savedModifier;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BuffMovementSpeed"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBuffMovementSpeed(
        ModifierDescriptor descriptor = default,
        int value = default,
        ContextValue? contextBonus = null,
        bool cappedOnMultiplier = default,
        float multiplierCap = default,
        bool cappedMinimum = default,
        int minimumCap = default)
    {
      ValidateParam(contextBonus);

      var component = new BuffMovementSpeed();
      component.Descriptor = descriptor;
      component.Value = value;
      component.ContextBonus = contextBonus ?? ContextValues.Constant(0);
      component.CappedOnMultiplier = cappedOnMultiplier;
      component.MultiplierCap = multiplierCap;
      component.CappedMinimum = cappedMinimum;
      component.MinimumCap = minimumCap;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffOnArmor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddBuffOnArmor(
        string? buff = null)
    {
      var component = new BuffOnArmor();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffOnHealthTickingTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="triggeredBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddBuffOnHealthTickingTrigger(
        string? triggeredBuff = null,
        float healthPercent = default)
    {
      var component = new BuffOnHealthTickingTrigger();
      component.m_TriggeredBuff = BlueprintTool.GetRef<BlueprintBuffReference>(triggeredBuff);
      component.HealthPercent = healthPercent;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffOnLightOrNoArmor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddBuffOnLightOrNoArmor(
        string? buff = null)
    {
      var component = new BuffOnLightOrNoArmor();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffParticleEffectPlay"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBuffParticleEffectPlay(
        bool playOnActivate = default,
        PrefabLink? activateFx = null,
        bool playOnDeactivate = default,
        PrefabLink? deactivateFx = null,
        bool playEachRound = default,
        PrefabLink? eachRoundFx = null)
    {
      ValidateParam(activateFx);
      ValidateParam(deactivateFx);
      ValidateParam(eachRoundFx);

      var component = new BuffParticleEffectPlay();
      component.PlayOnActivate = playOnActivate;
      component.ActivateFx = activateFx ?? Constants.Empty.PrefabLink;
      component.PlayOnDeactivate = playOnDeactivate;
      component.DeactivateFx = deactivateFx ?? Constants.Empty.PrefabLink;
      component.PlayEachRound = playEachRound;
      component.EachRoundFx = eachRoundFx ?? Constants.Empty.PrefabLink;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffPerceptionBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBuffPerceptionBonus(
        ModifierDescriptor descriptor = default)
    {
      var component = new BuffPerceptionBonus();
      component.Descriptor = descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSaveEachRound"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBuffSaveEachRound(
        SavingThrowType saveType = default,
        int saveDC = default,
        int increaseDC = default,
        ActionsBuilder? actionsOnPass = null,
        ActionsBuilder? actionsOnFail = null)
    {
      var component = new BuffSaveEachRound();
      component.SaveType = saveType;
      component.SaveDC = saveDC;
      component.IncreaseDC = increaseDC;
      component.ActionsOnPass = actionsOnPass?.Build() ?? Constants.Empty.Actions;
      component.ActionsOnFail = actionsOnFail?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSaveOrDieEachRound"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBuffSaveOrDieEachRound(
        GameObject effectOnDeath,
        UnitCondition condition = default,
        SavingThrowType saveType = default,
        int saveDC = default,
        int increaseDC = default)
    {
      ValidateParam(effectOnDeath);

      var component = new BuffSaveOrDieEachRound();
      component.Condition = condition;
      component.SaveType = saveType;
      component.SaveDC = saveDC;
      component.IncreaseDC = increaseDC;
      component.EffectOnDeath = effectOnDeath;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSkillBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBuffSkillBonus(
        StatType stat = default,
        ModifierDescriptor descriptor = default,
        int value = default)
    {
      var component = new BuffSkillBonus();
      component.Stat = stat;
      component.Descriptor = descriptor;
      component.Value = value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSkillLoreNatureBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBuffSkillLoreNatureBonus(
        ModifierDescriptor descriptor = default,
        int value = default)
    {
      var component = new BuffSkillLoreNatureBonus();
      component.Descriptor = descriptor;
      component.Value = value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSkillStealthBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBuffSkillStealthBonus(
        ModifierDescriptor descriptor = default,
        int value = default)
    {
      var component = new BuffSkillStealthBonus();
      component.Descriptor = descriptor;
      component.Value = value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffStatPenaltyDice"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBuffStatPenaltyDice(
        DiceFormula value,
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int bonus = default,
        SavingThrowType saveType = default)
    {
      var component = new BuffStatPenaltyDice();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.Bonus = bonus;
      component.SaveType = saveType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffStatusCondition"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBuffStatusCondition(
        bool saveEachRound = default,
        UnitCondition condition = default,
        SavingThrowType saveType = default)
    {
      var component = new BuffStatusCondition();
      component.SaveEachRound = saveEachRound;
      component.Condition = condition;
      component.SaveType = saveType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffStrengthSkillsBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBuffStrengthSkillsBonus(
        BuffScaling scaling,
        ModifierDescriptor descriptor = default,
        int value = default)
    {
      ValidateParam(scaling);

      var component = new BuffStrengthSkillsBonus();
      component.Descriptor = descriptor;
      component.Value = value;
      component.Scaling = scaling;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BurstBarrier"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBurstBarrier()
    {
      return AddComponent(new BurstBarrier());
    }

    /// <summary>
    /// Adds <see cref="CannyDefensePermanent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="chosenWeaponBlueprint"><see cref="Kingmaker.Blueprints.Classes.Selection.BlueprintParametrizedFeature"/></param>
    
    
    public TBuilder AddCannyDefensePermanent(
        string? characterClass = null,
        bool requiresKensai = default,
        string? chosenWeaponBlueprint = null)
    {
      var component = new CannyDefensePermanent();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.RequiresKensai = requiresKensai;
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(chosenWeaponBlueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeUnitSize"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddChangeUnitSize(
        ChangeUnitSize.ChangeType type = default,
        int sizeDelta = default,
        Size size = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ChangeUnitSize();
      component.m_Type = type;
      component.SizeDelta = sizeDelta;
      component.Size = size;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusConditional"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDamageBonusConditional(
        bool checkWielder = default,
        bool onlyWeaponDamage = default,
        ModifierDescriptor descriptor = default,
        ContextValue? bonus = null,
        ConditionsBuilder? conditions = null)
    {
      ValidateParam(bonus);

      var component = new DamageBonusConditional();
      component.CheckWielder = checkWielder;
      component.OnlyWeaponDamage = onlyWeaponDamage;
      component.Descriptor = descriptor;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageOnRemove"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDamageOnRemove(
        DiceFormula damage,
        DamageEnergyType energyType = default)
    {
      var component = new DamageOnRemove();
      component.Damage = damage;
      component.EnergyType = energyType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageOverTime"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDamageOverTime(
        DiceFormula damage,
        DamageEnergyType energyType = default,
        bool instantStartTick = default)
    {
      var component = new DamageOverTime();
      component.Damage = damage;
      component.EnergyType = energyType;
      component.InstantStartTick = instantStartTick;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageWithDescriptorRecievedTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDamageWithDescriptorRecievedTrigger(
        SpellDescriptorWrapper descriptor,
        DamageEnergyType energyType = default,
        ActionsBuilder? actions = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DamageWithDescriptorRecievedTrigger();
      component.Descriptor = descriptor;
      component.EnergyType = energyType;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DevilReflectAbility"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDevilReflectAbility(
        SpellSchool[]? reflectSchools = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DevilReflectAbility();
      component.m_ReflectSchools = reflectSchools;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DifficultyStatAdvancement"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddDifficultyStatAdvancement(
        int basicStatBonus = default,
        int derivativeStatBonus = default)
    {
      var component = new DifficultyStatAdvancement();
      component.BasicStatBonus = basicStatBonus;
      component.DerivativeStatBonus = derivativeStatBonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EchoesOfStoneTerrainBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddEchoesOfStoneTerrainBonus(
        AreaSetting setting = default)
    {
      var component = new EchoesOfStoneTerrainBonus();
      component.Setting = setting;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EmptyHandWeaponOverride"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weapon"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintItemWeapon"/></param>
    
    
    public TBuilder AddEmptyHandWeaponOverride(
        string? weapon = null,
        bool isPermanent = default,
        bool isMonkUnarmedStrike = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new EmptyHandWeaponOverride();
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weapon);
      component.IsPermanent = isPermanent;
      component.IsMonkUnarmedStrike = isMonkUnarmedStrike;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="HasArmorFeatureUnlock"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="newFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddHasArmorFeatureUnlock(
        string? newFact = null)
    {
      var component = new HasArmorFeatureUnlock();
      component.m_NewFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(newFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HealOverTime"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddHealOverTime(
        int heal = default,
        bool instantStartTick = default)
    {
      var component = new HealOverTime();
      component.Heal = heal;
      component.InstantStartTick = instantStartTick;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HealOverTimeIfHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    
    
    public TBuilder AddHealOverTimeIfHasFact(
        BuffScaling scaling,
        int heal = default,
        bool instantStartTick = default,
        string? checkedFact = null,
        bool scale = default)
    {
      ValidateParam(scaling);

      var component = new HealOverTimeIfHasFact();
      component.Heal = heal;
      component.InstantStartTick = instantStartTick;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintFeatureReference>(checkedFact);
      component.Scale = scale;
      component.Scaling = scaling;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellDamageByClassLevel"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="additionalClasses"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="archetypes"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype"/></param>
    
    
    public TBuilder AddIncreaseSpellDamageByClassLevel(
        string[]? spells = null,
        string? characterClass = null,
        string[]? additionalClasses = null,
        string[]? archetypes = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IncreaseSpellDamageByClassLevel();
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_AdditionalClasses = additionalClasses.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray();
      component.m_Archetypes = archetypes.Select(name => BlueprintTool.GetRef<BlueprintArchetypeReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IntenseSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="wizard"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    
    
    public TBuilder AddIntenseSpells(
        string? wizard = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IntenseSpells();
      component.m_Wizard = BlueprintTool.GetRef<BlueprintCharacterClassReference>(wizard);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="LiquidateTowerShieldPenalty"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddLiquidateTowerShieldPenalty()
    {
      return AddComponent(new LiquidateTowerShieldPenalty());
    }

    /// <summary>
    /// Adds <see cref="MakeUnitFollowUnit"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddMakeUnitFollowUnit(
        UnitEvaluator leader,
        bool alwaysRun = default,
        bool canBeSlowerThanLeader = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(leader);

      var component = new MakeUnitFollowUnit();
      component.AlwaysRun = alwaysRun;
      component.CanBeSlowerThanLeader = canBeSlowerThanLeader;
      component.Leader = leader;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ModifySpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddModifySpell(
        SpellModificationType modificationType = default,
        string[]? spells = null)
    {
      var component = new ModifySpell();
      component.ModificationType = modificationType;
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MonkNoArmorAndMonkWeaponFeatureUnlock"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="newFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    /// <param name="bowWeaponTypes"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintWeaponType"/></param>
    /// <param name="rapidshotBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public TBuilder AddMonkNoArmorAndMonkWeaponFeatureUnlock(
        string? newFact = null,
        bool isZenArcher = default,
        string[]? bowWeaponTypes = null,
        string? rapidshotBuff = null,
        bool isSohei = default)
    {
      var component = new MonkNoArmorAndMonkWeaponFeatureUnlock();
      component.m_NewFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(newFact);
      component.IsZenArcher = isZenArcher;
      component.m_BowWeaponTypes = bowWeaponTypes.Select(name => BlueprintTool.GetRef<BlueprintWeaponTypeReference>(name)).ToArray();
      component.m_RapidshotBuff = BlueprintTool.GetRef<BlueprintBuffReference>(rapidshotBuff);
      component.IsSohei = isSohei;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MonkNoArmorFeatureUnlock"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="newFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public TBuilder AddMonkNoArmorFeatureUnlock(
        string? newFact = null)
    {
      var component = new MonkNoArmorFeatureUnlock();
      component.m_NewFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(newFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MysticTheurgeCombinedSpells"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddMysticTheurgeCombinedSpells(
        int spellLevel = default)
    {
      var component = new MysticTheurgeCombinedSpells();
      component.SpellLevel = spellLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MysticTheurgeSpellbook"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="mysticTheurge"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    
    
    public TBuilder AddMysticTheurgeSpellbook(
        string? characterClass = null,
        string? mysticTheurge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new MysticTheurgeSpellbook();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_MysticTheurge = BlueprintTool.GetRef<BlueprintCharacterClassReference>(mysticTheurge);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="PowerfulCharge"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddPowerfulCharge(
        bool useContextBonus = default,
        ContextValue? value = null,
        int additionalDiceRolls = default)
    {
      ValidateParam(value);

      var component = new PowerfulCharge();
      component.UseContextBonus = useContextBonus;
      component.Value = value ?? ContextValues.Constant(0);
      component.AdditionalDiceRolls = additionalDiceRolls;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ProtectionFromEnergy"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddProtectionFromEnergy(
        DamageEnergyType type = default,
        bool useValueMultiplier = default,
        ContextValue? valueMultiplier = null,
        ContextValue? value = null,
        bool usePool = default,
        ContextValue? pool = null)
    {
      ValidateParam(valueMultiplier);
      ValidateParam(value);
      ValidateParam(pool);

      var component = new ProtectionFromEnergy();
      component.Type = type;
      component.UseValueMultiplier = useValueMultiplier;
      component.ValueMultiplier = valueMultiplier ?? ContextValues.Constant(0);
      component.Value = value ?? ContextValues.Constant(0);
      component.UsePool = usePool;
      component.Pool = pool ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PummelingCharge"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddPummelingCharge(
        WeaponCategory unarmedCategory = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new PummelingCharge();
      component.UnarmedCategory = unarmedCategory;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ReduceDamageReduction"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddReduceDamageReduction(
        int multiplier = default,
        ContextValue? value = null)
    {
      ValidateParam(value);

      var component = new ReduceDamageReduction();
      component.Multiplier = multiplier;
      component.Value = value ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceAsksList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="asks"><see cref="Kingmaker.Visual.Sound.BlueprintUnitAsksList"/></param>
    
    
    public TBuilder AddReplaceAsksList(
        string? asks = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ReplaceAsksList();
      component.m_Asks = BlueprintTool.GetRef<BlueprintUnitAsksListReference>(asks);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ResistEnergy"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddResistEnergy(
        DamageEnergyType type = default,
        bool useValueMultiplier = default,
        ContextValue? valueMultiplier = null,
        ContextValue? value = null,
        bool usePool = default,
        ContextValue? pool = null)
    {
      ValidateParam(valueMultiplier);
      ValidateParam(value);
      ValidateParam(pool);

      var component = new ResistEnergy();
      component.Type = type;
      component.UseValueMultiplier = useValueMultiplier;
      component.ValueMultiplier = valueMultiplier ?? ContextValues.Constant(0);
      component.Value = value ?? ContextValues.Constant(0);
      component.UsePool = usePool;
      component.Pool = pool ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ResistEnergyContext"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddResistEnergyContext(
        DamageEnergyType type = default,
        bool useValueMultiplier = default,
        ContextValue? valueMultiplier = null,
        ContextValue? value = null,
        bool usePool = default,
        ContextValue? pool = null)
    {
      ValidateParam(valueMultiplier);
      ValidateParam(value);
      ValidateParam(pool);

      var component = new ResistEnergyContext();
      component.Type = type;
      component.UseValueMultiplier = useValueMultiplier;
      component.ValueMultiplier = valueMultiplier ?? ContextValues.Constant(0);
      component.Value = value ?? ContextValues.Constant(0);
      component.UsePool = usePool;
      component.Pool = pool ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SaveSuccessIfBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSaveSuccessIfBonus(
        ContextValue? value = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new SaveSuccessIfBonus();
      component.Value = value ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ShieldFocus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddShieldFocus()
    {
      return AddComponent(new ShieldFocus());
    }

    /// <summary>
    /// Adds <see cref="SkillSuccessIfBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSkillSuccessIfBonus(
        ContextValue? value = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new SkillSuccessIfBonus();
      component.Value = value ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SpeedBonusInArmorCategory"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddSpeedBonusInArmorCategory(
        ArmorProficiencyGroup[]? category = null,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        bool noArmor = default)
    {
      var component = new SpeedBonusInArmorCategory();
      component.Category = category;
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.NoArmor = noArmor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellTurning"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="specificSpellsOnly"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    
    public TBuilder AddSpellTurning(
        SpellDescriptorWrapper spellDescriptorOnly,
        bool spellResistanceOnly = default,
        string[]? specificSpellsOnly = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SpellTurning();
      component.m_SpellResistanceOnly = spellResistanceOnly;
      component.m_SpellDescriptorOnly = spellDescriptorOnly;
      component.m_SpecificSpellsOnly = specificSpellsOnly.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="StatBonusWeaponRestriction"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddStatBonusWeaponRestriction(
        StatType stat = default,
        int value = default,
        ModifierDescriptor descriptor = default,
        bool checkCategory = default,
        WeaponCategory category = default,
        bool oneHandedOnly = default,
        bool duelistWeapon = default)
    {
      var component = new StatBonusWeaponRestriction();
      component.Stat = stat;
      component.Value = value;
      component.Descriptor = descriptor;
      component.CheckCategory = checkCategory;
      component.Category = category;
      component.OneHandedOnly = oneHandedOnly;
      component.DuelistWeapon = duelistWeapon;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="StonyStepTerrainBonus"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddStonyStepTerrainBonus(
        AreaSetting setting = default)
    {
      var component = new StonyStepTerrainBonus();
      component.Setting = setting;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsConstitutionBased"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTemporaryHitPointsConstitutionBased(
        ContextValue? value = null,
        int bonusMultiplier = default,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new TemporaryHitPointsConstitutionBased();
      component.Value = value ?? ContextValues.Constant(0);
      component.BonusMultiplier = bonusMultiplier;
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsEqualCasterLevel"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTemporaryHitPointsEqualCasterLevel(
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TemporaryHitPointsEqualCasterLevel();
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsFromAbilityValue"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTemporaryHitPointsFromAbilityValue(
        ModifierDescriptor descriptor = default,
        ContextValue? value = null,
        bool removeWhenHitPointsEnd = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new TemporaryHitPointsFromAbilityValue();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.RemoveWhenHitPointsEnd = removeWhenHitPointsEnd;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsPerLevel"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="limitlessRageBlueprint"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    /// <param name="limitlessRageResource"><see cref="Kingmaker.Blueprints.BlueprintAbilityResource"/></param>
    
    
    public TBuilder AddTemporaryHitPointsPerLevel(
        ModifierDescriptor descriptor = default,
        int hitPointsPerLevel = default,
        ContextValue? value = null,
        bool removeWhenHitPointsEnd = default,
        bool limitlessRage = default,
        string? limitlessRageBlueprint = null,
        string? limitlessRageResource = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new TemporaryHitPointsPerLevel();
      component.Descriptor = descriptor;
      component.HitPointsPerLevel = hitPointsPerLevel;
      component.Value = value ?? ContextValues.Constant(0);
      component.RemoveWhenHitPointsEnd = removeWhenHitPointsEnd;
      component.LimitlessRage = limitlessRage;
      component.m_LimitlessRageBlueprint = BlueprintTool.GetRef<BlueprintUnitFactReference>(limitlessRageBlueprint);
      component.m_LimitlessRageResource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(limitlessRageResource);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsRandom"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTemporaryHitPointsRandom(
        DiceFormula dice,
        ModifierDescriptor descriptor = default,
        ContextValue? bonus = null,
        bool scaleBonusByCasterLevel = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(bonus);

      var component = new TemporaryHitPointsRandom();
      component.Descriptor = descriptor;
      component.Dice = dice;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.ScaleBonusByCasterLevel = scaleBonusByCasterLevel;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TowerShieldSpecialistTotalCover"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddTowerShieldSpecialistTotalCover()
    {
      return AddComponent(new TowerShieldSpecialistTotalCover());
    }

    /// <summary>
    /// Adds <see cref="WeaponTrainingBonuses"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddWeaponTrainingBonuses(
        ModifierDescriptor descriptor = default,
        StatType stat = default)
    {
      var component = new WeaponTrainingBonuses();
      component.Descriptor = descriptor;
      component.Stat = stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WizardAbjurationResistance"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="wizard"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    
    
    public TBuilder AddWizardAbjurationResistance(
        string? wizard = null,
        DamageEnergyType type = default,
        bool useValueMultiplier = default,
        ContextValue? valueMultiplier = null,
        ContextValue? value = null,
        bool usePool = default,
        ContextValue? pool = null)
    {
      ValidateParam(valueMultiplier);
      ValidateParam(value);
      ValidateParam(pool);

      var component = new WizardAbjurationResistance();
      component.m_Wizard = BlueprintTool.GetRef<BlueprintCharacterClassReference>(wizard);
      component.Type = type;
      component.UseValueMultiplier = useValueMultiplier;
      component.ValueMultiplier = valueMultiplier ?? ContextValues.Constant(0);
      component.Value = value ?? ContextValues.Constant(0);
      component.UsePool = usePool;
      component.Pool = pool ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WizardEnergyAbsorption"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="Kingmaker.Blueprints.BlueprintAbilityResource"/></param>
    
    
    public TBuilder AddWizardEnergyAbsorption(
        string? resource = null,
        DamageEnergyType type = default,
        bool useValueMultiplier = default,
        ContextValue? valueMultiplier = null,
        ContextValue? value = null,
        bool usePool = default,
        ContextValue? pool = null)
    {
      ValidateParam(valueMultiplier);
      ValidateParam(value);
      ValidateParam(pool);

      var component = new WizardEnergyAbsorption();
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      component.Type = type;
      component.UseValueMultiplier = useValueMultiplier;
      component.ValueMultiplier = valueMultiplier ?? ContextValues.Constant(0);
      component.Value = value ?? ContextValues.Constant(0);
      component.UsePool = usePool;
      component.Pool = pool ?? ContextValues.Constant(0);
      return AddComponent(component);
    }
  }
}
