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
    /// Adds <see cref="Kingmaker.UnitLogic.FactLogic.AddFacts">AddFacts</see>
    /// </summary>
    /// 
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Implements(typeof(AddFacts))]
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
    [Implements(typeof(AddInitiatorSkillRollTrigger))]
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
    /// Adds <see cref="CorruptionProtection"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CorruptionProtection))]
    public TBuilder AddCorruptionProtection(
        bool removeRankAfterRest = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CorruptionProtection();
      component.m_RemoveRankAfterRest = removeRankAfterRest;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestRoleBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RestRoleBonus))]
    public TBuilder AddRestRoleBonus(
        CampingRoleType roleType = default,
        ModifierDescriptor descriptor = default,
        ContextValue value = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new RestRoleBonus();
      component.m_RoleType = roleType;
      component.m_Descriptor = descriptor;
      component.m_Value = value ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceUnitPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReplaceUnitPrefab))]
    public TBuilder AddReplaceUnitPrefab(
        PrefabLink prefab = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(prefab);
    
      var component = new ReplaceUnitPrefab();
      component.m_Prefab = prefab ?? Constants.Empty.PrefabLink;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PretendUnit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unit"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(PretendUnit))]
    public TBuilder AddPretendUnit(
        string unit = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new PretendUnit();
      component.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(unit);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddClassLevels"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="archetypes"><see cref="BlueprintArchetype"/></param>
    /// <param name="selectSpells"><see cref="BlueprintAbility"/></param>
    /// <param name="memorizeSpells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddClassLevels))]
    public TBuilder AddClassLevels(
        string characterClass = null,
        string[] archetypes = null,
        int levels = default,
        StatType raceStat = default,
        StatType levelsStat = default,
        StatType[] skills = null,
        string[] selectSpells = null,
        string[] memorizeSpells = null,
        SelectionEntry[] selections = null,
        bool doNotApplyAutomatically = default,
        BlueprintComponent.Flags flags = default)
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
    /// Adds <see cref="SuppressSpellSchool"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SuppressSpellSchool))]
    public TBuilder AddSuppressSpellSchool(
        SuppressSpellSchool.Logic componentLogic = default,
        SpellSchool[] school = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SuppressSpellSchool();
      component.m_ComponentLogic = componentLogic;
      component.m_School = school;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AzataFavorableMagic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AzataFavorableMagic))]
    public TBuilder AddAzataFavorableMagic(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AzataFavorableMagic();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DemonSocothbenothAspect"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DemonSocothbenothAspect))]
    public TBuilder AddDemonSocothbenothAspect(
        BlueprintComponent.Flags flags = default)
    {
      var component = new DemonSocothbenothAspect();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityUsagesCountTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityUsagesCountTrigger))]
    public TBuilder AddAbilityUsagesCountTrigger(
        ContextValue triggerCount = null,
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(triggerCount);
    
      var component = new AbilityUsagesCountTrigger();
      component.m_TriggerCount = triggerCount ?? ContextValues.Constant(0);
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AccomplishedSneakAttacker"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AccomplishedSneakAttacker))]
    public TBuilder AddAccomplishedSneakAttacker(
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AccomplishedSneakAttacker();
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AcrobaticMovement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AcrobaticMovement))]
    public TBuilder AddAcrobaticMovement(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AcrobaticMovement();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddACBonusWithDistanceToMasterCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddACBonusWithDistanceToMasterCondition))]
    public TBuilder AddACBonusWithDistanceToMasterCondition(
        Feet distance,
        ContextValue value = null,
        ModifierDescriptor descriptor = default,
        CompareOperation.Type compareType = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new AddACBonusWithDistanceToMasterCondition();
      component.Value = value ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      component.CompareType = compareType;
      component.Distance = distance;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAbilityResourceTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(AddAbilityResourceTrigger))]
    public TBuilder AddAbilityResourceTrigger(
        string resource = null,
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddAbilityResourceTrigger();
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAbilityUseTargetTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbooks"><see cref="BlueprintSpellbook"/></param>
    /// <param name="spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddAbilityUseTargetTrigger))]
    public TBuilder AddAbilityUseTargetTrigger(
        SpellDescriptorWrapper spellDescriptor,
        ActionsBuilder action = null,
        bool afterCast = default,
        bool fromSpellbook = default,
        AbilityType type = default,
        bool toCaster = default,
        string[] spellbooks = null,
        bool spellList = default,
        string[] spells = null,
        bool checkDescriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddAbilityUseTargetTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.AfterCast = afterCast;
      component.FromSpellbook = fromSpellbook;
      component.Type = type;
      component.ToCaster = toCaster;
      component.m_Spellbooks = spellbooks.Select(name => BlueprintTool.GetRef<BlueprintSpellbookReference>(name)).ToArray();
      component.SpellList = spellList;
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.CheckDescriptor = checkDescriptor;
      component.SpellDescriptor = spellDescriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAbilityUseTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbooks"><see cref="BlueprintSpellbook"/></param>
    /// <param name="ability"><see cref="BlueprintAbility"/></param>
    /// <param name="abilities"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddAbilityUseTrigger))]
    public TBuilder AddAbilityUseTrigger(
        SpellDescriptorWrapper spellDescriptor,
        ActionsBuilder action = null,
        bool actionsOnAllTargets = default,
        bool afterCast = default,
        bool actionsOnTarget = default,
        bool fromSpellbook = default,
        string[] spellbooks = null,
        bool forOneSpell = default,
        string ability = null,
        bool forMultipleSpells = default,
        string[] abilities = null,
        bool minSpellLevel = default,
        int minSpellLevelLimit = default,
        bool exactSpellLevel = default,
        int exactSpellLevelLimit = default,
        bool checkAbilityType = default,
        AbilityType type = default,
        bool checkDescriptor = default,
        bool checkRange = default,
        AbilityRange range = default,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAdditionalLimb"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weapon"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(AddAdditionalLimb))]
    public TBuilder AddAdditionalLimb(
        string weapon = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddAdditionalLimb();
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weapon);
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
    /// Adds <see cref="AddBackgroundArmorProficiency"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddBackgroundArmorProficiency))]
    public TBuilder AddBackgroundArmorProficiency(
        ArmorProficiencyGroup proficiency = default,
        ContextValue stackBonus = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(stackBonus);
    
      var component = new AddBackgroundArmorProficiency();
      component.Proficiency = proficiency;
      component.StackBonus = stackBonus ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBackgroundClassSkill"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddBackgroundClassSkill))]
    public TBuilder AddBackgroundClassSkill(
        StatType skill = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddBackgroundClassSkill();
      component.Skill = skill;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBackgroundWeaponProficiency"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddBackgroundWeaponProficiency))]
    public TBuilder AddBackgroundWeaponProficiency(
        WeaponCategory proficiency = default,
        ModifierDescriptor stackBonusType = default,
        ContextValue stackBonus = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(stackBonus);
    
      var component = new AddBackgroundWeaponProficiency();
      component.Proficiency = proficiency;
      component.StackBonusType = stackBonusType;
      component.StackBonus = stackBonus ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBondProperty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchant"><see cref="BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(AddBondProperty))]
    public TBuilder AddBondProperty(
        EnchantPoolType enchantPool = default,
        string enchant = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddBondProperty();
      component.EnchantPool = enchantPool;
      component.m_Enchant = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(enchant);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBuffInBadWeather"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AddBuffInBadWeather))]
    public TBuilder AddBuffInBadWeather(
        string buff = null,
        InclemencyType weather = default,
        bool whenCalmer = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddBuffInBadWeather();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.Weather = weather;
      component.WhenCalmer = whenCalmer;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBuffOnApplyingSpell"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddBuffOnApplyingSpell))]
    public TBuilder AddBuffOnApplyingSpell(
        bool onEffectApplied = default,
        bool onResistSpell = default,
        AddBuffOnApplyingSpell.SpellConditionAndBuff[] buffs = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(buffs);
    
      var component = new AddBuffOnApplyingSpell();
      component.OnEffectApplied = onEffectApplied;
      component.OnResistSpell = onResistSpell;
      component.Buffs = buffs;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddClassSkill"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddClassSkill))]
    public TBuilder AddClassSkill(
        StatType skill = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddClassSkill();
      component.Skill = skill;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddClusteredAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddClusteredAttack))]
    public TBuilder AddClusteredAttack(
        AddClusteredAttack.Type attackType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddClusteredAttack();
      component.AttackType = attackType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddConcealment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddConcealment))]
    public TBuilder AddConcealment(
        Feet distanceGreater,
        ConcealmentDescriptor descriptor = default,
        Concealment concealment = default,
        bool checkWeaponRangeType = default,
        WeaponRangeType rangeType = default,
        bool checkDistance = default,
        bool onlyForAttacks = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddConcealment();
      component.Descriptor = descriptor;
      component.Concealment = concealment;
      component.CheckWeaponRangeType = checkWeaponRangeType;
      component.RangeType = rangeType;
      component.CheckDistance = checkDistance;
      component.DistanceGreater = distanceGreater;
      component.OnlyForAttacks = onlyForAttacks;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddCondition))]
    public TBuilder AddCondition(
        UnitCondition condition = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddCondition();
      component.Condition = condition;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddConditionImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddConditionImmunity))]
    public TBuilder AddConditionImmunity(
        UnitCondition condition = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddConditionImmunity();
      component.Condition = condition;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddConditionTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddConditionTrigger))]
    public TBuilder AddConditionTrigger(
        AddConditionTrigger.TriggerType triggerType = default,
        UnitCondition[] conditions = null,
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddConditionTrigger();
      component.m_TriggerType = triggerType;
      component.Conditions = conditions;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCumulativeDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddCumulativeDamageBonus))]
    public TBuilder AddCumulativeDamageBonus(
        bool onlyNaturalAttacks = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddCumulativeDamageBonus();
      component.OnlyNaturalAttacks = onlyNaturalAttacks;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCumulativeDamageBonusX3"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddCumulativeDamageBonusX3))]
    public TBuilder AddCumulativeDamageBonusX3(
        bool onlyNaturalAttacks = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddCumulativeDamageBonusX3();
      component.OnlyNaturalAttacks = onlyNaturalAttacks;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddDamageResistanceEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddDamageResistanceEnergy))]
    public TBuilder AddDamageResistanceEnergy(
        DamageEnergyType type = default,
        bool useValueMultiplier = default,
        ContextValue valueMultiplier = null,
        ContextValue value = null,
        bool usePool = default,
        ContextValue pool = null,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddDamageResistanceForce"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddDamageResistanceForce))]
    public TBuilder AddDamageResistanceForce(
        DamageEnergyType type = default,
        bool useValueMultiplier = default,
        ContextValue valueMultiplier = null,
        ContextValue value = null,
        bool usePool = default,
        ContextValue pool = null,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddDamageResistancePhysical"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="BlueprintWeaponType"/></param>
    /// <param name="checkedFactMythic"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddDamageResistancePhysical))]
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
        string weaponType = null,
        bool bypassedByMeleeWeapon = default,
        bool bypassedByEpic = default,
        string checkedFactMythic = null,
        ContextValue value = null,
        bool usePool = default,
        ContextValue pool = null,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddDamageTypeVulnerability"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddDamageTypeVulnerability))]
    public TBuilder AddDamageTypeVulnerability(
        bool physcicalForm = default,
        PhysicalDamageForm formType = default,
        bool physcicalAlignment = default,
        DamageAlignment damageAlignmentType = default,
        bool physcicalMaterial = default,
        PhysicalDamageMaterial materialType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddDamageTypeVulnerability();
      component.PhyscicalForm = physcicalForm;
      component.FormType = formType;
      component.PhyscicalAlignment = physcicalAlignment;
      component.DamageAlignmentType = damageAlignmentType;
      component.PhyscicalMaterial = physcicalMaterial;
      component.MaterialType = materialType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEnergyDamageDivisor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEnergyDamageDivisor))]
    public TBuilder AddEnergyDamageDivisor(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddEnergyDamageDivisor();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEnergyDamageImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEnergyDamageImmunity))]
    public TBuilder AddEnergyDamageImmunity(
        DamageEnergyType energyType = default,
        bool healOnDamage = default,
        AddEnergyDamageImmunity.HealingRate healRate = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddEnergyDamageImmunity();
      component.EnergyType = energyType;
      component.HealOnDamage = healOnDamage;
      component.m_HealRate = healRate;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEnergyImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEnergyImmunity))]
    public TBuilder AddEnergyImmunity(
        DamageEnergyType type = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddEnergyImmunity();
      component.Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEnergyVulnerability"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEnergyVulnerability))]
    public TBuilder AddEnergyVulnerability(
        DamageEnergyType type = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddEnergyVulnerability();
      component.Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEquipmentEntity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEquipmentEntity))]
    public TBuilder AddEquipmentEntity(
        EquipmentEntityLink equipmentEntity,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(equipmentEntity);
    
      var component = new AddEquipmentEntity();
      component.EquipmentEntity = equipmentEntity;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFactsFromCaster"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    /// <param name="selection"><see cref="BlueprintFeatureSelection"/></param>
    [Generated]
    [Implements(typeof(AddFactsFromCaster))]
    public TBuilder AddFactsFromCaster(
        string[] facts = null,
        bool featureFromSelection = default,
        string selection = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFactsFromCaster();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.FeatureFromSelection = featureFromSelection;
      component.m_Selection = BlueprintTool.GetRef<BlueprintFeatureSelectionReference>(selection);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFactsToMount"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddFactsToMount))]
    public TBuilder AddFactsToMount(
        string[] facts = null,
        int casterLevel = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFactsToMount();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.CasterLevel = casterLevel;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFallProneTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddFallProneTrigger))]
    public TBuilder AddFallProneTrigger(
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFallProneTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFamiliar"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddFamiliar))]
    public TBuilder AddFamiliar(
        FamiliarLink prefabLink,
        bool hideInCapital = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(prefabLink);
    
      var component = new AddFamiliar();
      component.PrefabLink = prefabLink;
      component.HideInCapital = hideInCapital;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFortification"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddFortification))]
    public TBuilder AddFortification(
        bool useContextValue = default,
        int bonus = default,
        ContextValue value = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new AddFortification();
      component.UseContextValue = useContextValue;
      component.Bonus = bonus;
      component.Value = value ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFortificationObsolete"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddFortificationObsolete))]
    public TBuilder AddFortificationObsolete(
        int chance = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFortificationObsolete();
      component.Chance = chance;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddHealTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddHealTrigger))]
    public TBuilder AddHealTrigger(
        ActionsBuilder action = null,
        ActionsBuilder healerAction = null,
        bool onHealDamage = default,
        bool onHealStatDamage = default,
        bool onHealEnergyDrain = default,
        bool allowZeroHealDamage = default,
        bool allowZeroHealStatDamage = default,
        bool allowZeroHealEnergyDrain = default,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddIdentifyBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddIdentifyBonus))]
    public TBuilder AddIdentifyBonus(
        bool allowUsingUntrainedSkill = default,
        ContextValue bonus = null,
        ContextValue spellBonus = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
      ValidateParam(spellBonus);
    
      var component = new AddIdentifyBonus();
      component.AllowUsingUntrainedSkill = allowUsingUntrainedSkill;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.SpellBonus = spellBonus ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddImmortality"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddImmortality))]
    public TBuilder AddImmortality(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddImmortality();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddImmunityFirebrand"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddImmunityFirebrand))]
    public TBuilder AddImmunityFirebrand(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddImmunityFirebrand();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddImmunityToAbilityScoreDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddImmunityToAbilityScoreDamage))]
    public TBuilder AddImmunityToAbilityScoreDamage(
        bool drain = default,
        StatType[] statTypes = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddImmunityToAbilityScoreDamage();
      component.Drain = drain;
      component.StatTypes = statTypes;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddImmunityToCriticalHits"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddImmunityToCriticalHits))]
    public TBuilder AddImmunityToCriticalHits(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddImmunityToCriticalHits();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddImmunityToEnergyDrain"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddImmunityToEnergyDrain))]
    public TBuilder AddImmunityToEnergyDrain(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddImmunityToEnergyDrain();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddImmunityToPrecisionDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddImmunityToPrecisionDamage))]
    public TBuilder AddImmunityToPrecisionDamage(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddImmunityToPrecisionDamage();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddIncomingDamageWeaponProperty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(AddIncomingDamageWeaponProperty))]
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
        string weaponType = null,
        bool checkRange = default,
        bool isRanged = default,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddIncorporealDamageDivisor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddIncorporealDamageDivisor))]
    public TBuilder AddIncorporealDamageDivisor(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddIncorporealDamageDivisor();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddInitiatorHealTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddInitiatorHealTrigger))]
    public TBuilder AddInitiatorHealTrigger(
        ActionsBuilder action = null,
        ActionsBuilder healerAction = null,
        bool onHealDamage = default,
        bool onHealStatDamage = default,
        bool onHealEnergyDrain = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddInitiatorHealTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.HealerAction = healerAction?.Build() ?? Constants.Empty.Actions;
      component.OnHealDamage = onHealDamage;
      component.OnHealStatDamage = onHealStatDamage;
      component.OnHealEnergyDrain = onHealEnergyDrain;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddItemCasterLevelBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddItemCasterLevelBonus))]
    public TBuilder AddItemCasterLevelBonus(
        int bonus = default,
        UsableItemType itemType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddItemCasterLevelBonus();
      component.Bonus = bonus;
      component.ItemType = itemType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKnownSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="spell"><see cref="BlueprintAbility"/></param>
    /// <param name="archetype"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(AddKnownSpell))]
    public TBuilder AddKnownSpell(
        string characterClass = null,
        int spellLevel = default,
        string spell = null,
        string archetype = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddKnownSpell();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.SpellLevel = spellLevel;
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(spell);
      component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
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
    /// Adds <see cref="AddMechanicsFeature"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddMechanicsFeature))]
    public TBuilder AddMechanicsFeature(
        AddMechanicsFeature.MechanicsFeatureType feature = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddMechanicsFeature();
      component.m_Feature = feature;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddMetamagicFeat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddMetamagicFeat))]
    public TBuilder AddMetamagicFeat(
        Metamagic metamagic = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddMetamagicFeat();
      component.Metamagic = metamagic;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddMythicEnemyHitPointsBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddMythicEnemyHitPointsBonus))]
    public TBuilder AddMythicEnemyHitPointsBonus(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddMythicEnemyHitPointsBonus();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddNimbusDamageDivisor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddNimbusDamageDivisor))]
    public TBuilder AddNimbusDamageDivisor(
        AddNimbusDamageDivisor.NimbusType type = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddNimbusDamageDivisor();
      component.m_Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddOffensiveActionTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddOffensiveActionTrigger))]
    public TBuilder AddOffensiveActionTrigger(
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddOffensiveActionTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddOppositionDescriptor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(AddOppositionDescriptor))]
    public TBuilder AddOppositionDescriptor(
        SpellDescriptorWrapper descriptor,
        string characterClass = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddOppositionDescriptor();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddOppositionSchool"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(AddOppositionSchool))]
    public TBuilder AddOppositionSchool(
        string characterClass = null,
        SpellSchool school = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddOppositionSchool();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.School = school;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddOutgoingDamageBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddOutgoingDamageBonus))]
    public TBuilder AddOutgoingDamageBonus(
        DamageTypeDescription damageType,
        SpellDescriptorWrapper checkedDescriptor,
        DamageIncreaseCondition condition = default,
        DamageIncreaseReason reason = default,
        float originalDamageFactor = default,
        string checkedFact = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(damageType);
    
      var component = new AddOutgoingDamageBonus();
      component.DamageType = damageType;
      component.Condition = condition;
      component.Reason = reason;
      component.OriginalDamageFactor = originalDamageFactor;
      component.CheckedDescriptor = checkedDescriptor;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddOutgoingPhysicalDamageProperty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="BlueprintWeaponType"/></param>
    /// <param name="unitFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddOutgoingPhysicalDamageProperty))]
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
        string weaponType = null,
        bool checkRange = default,
        bool isRanged = default,
        bool againstFactOwner = default,
        string unitFact = null,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddOverHealTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddOverHealTrigger))]
    public TBuilder AddOverHealTrigger(
        ActionsBuilder actionOnTarget = null,
        AbilitySharedValue sharedValue = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddOverHealTrigger();
      component.ActionOnTarget = actionOnTarget?.Build() ?? Constants.Empty.Actions;
      component.SharedValue = sharedValue;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddParametrizedFeatures"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddParametrizedFeatures))]
    public TBuilder AddParametrizedFeatures(
        AddParametrizedFeatures.FeatureData[] features = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(features);
    
      var component = new AddParametrizedFeatures();
      component.m_Features = features;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddPartyEncumbrance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddPartyEncumbrance))]
    public TBuilder AddPartyEncumbrance(
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddPartyEncumbrance();
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddPet"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="pet"><see cref="BlueprintUnit"/></param>
    /// <param name="levelRank"><see cref="BlueprintFeature"/></param>
    /// <param name="upgradeFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddPet))]
    public TBuilder AddPet(
        PetType type = default,
        PetProgressionType progressionType = default,
        string pet = null,
        bool useContextValueLevel = default,
        string levelRank = null,
        ContextValue levelContextValue = null,
        bool forceAutoLevelup = default,
        string upgradeFeature = null,
        bool destroyPetOnDeactivate = default,
        int upgradeLevel = default,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddPhysicalImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddPhysicalImmunity))]
    public TBuilder AddPhysicalImmunity(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddPhysicalImmunity();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddProficiencies"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="raceRestriction"><see cref="BlueprintRace"/></param>
    [Generated]
    [Implements(typeof(AddProficiencies))]
    public TBuilder AddProficiencies(
        string raceRestriction = null,
        ArmorProficiencyGroup[] armorProficiencies = null,
        WeaponCategory[] weaponProficiencies = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddProficiencies();
      component.m_RaceRestriction = BlueprintTool.GetRef<BlueprintRaceReference>(raceRestriction);
      component.ArmorProficiencies = armorProficiencies;
      component.WeaponProficiencies = weaponProficiencies;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddREVendorItem"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddREVendorItem))]
    public TBuilder AddREVendorItem(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddREVendorItem();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddResurrectOnRest"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddResurrectOnRest))]
    public TBuilder AddResurrectOnRest(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddResurrectOnRest();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSecondaryAttacks"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weapon"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(AddSecondaryAttacks))]
    public TBuilder AddSecondaryAttacks(
        string[] weapon = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSecondaryAttacks();
      component.m_Weapon = weapon.Select(name => BlueprintTool.GetRef<BlueprintItemWeaponReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSkillPointPerCharacterLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSkillPointPerCharacterLevel))]
    public TBuilder AddSkillPointPerCharacterLevel(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSkillPointPerCharacterLevel();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpecialSpellList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="spellList"><see cref="BlueprintSpellList"/></param>
    /// <param name="archetype"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(AddSpecialSpellList))]
    public TBuilder AddSpecialSpellList(
        string characterClass = null,
        string spellList = null,
        bool forArchetypeOnly = default,
        string archetype = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSpecialSpellList();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(spellList);
      component.ForArchetypeOnly = forArchetypeOnly;
      component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpecialSpellListForArchetype"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="spellList"><see cref="BlueprintSpellList"/></param>
    /// <param name="archetype"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(AddSpecialSpellListForArchetype))]
    public TBuilder AddSpecialSpellListForArchetype(
        string characterClass = null,
        string spellList = null,
        string archetype = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSpecialSpellListForArchetype();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(spellList);
      component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellFailureChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSpellFailureChance))]
    public TBuilder AddSpellFailureChance(
        GameObject failFx,
        int chance = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(failFx);
    
      var component = new AddSpellFailureChance();
      component.Chance = chance;
      component.FailFx = failFx;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellImmunity"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="exceptions"><see cref="BlueprintAbility"/></param>
    /// <param name="casterIgnoreImmunityFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddSpellImmunity))]
    public TBuilder AddSpellImmunity(
        SpellDescriptorWrapper spellDescriptor,
        SpellImmunityType type = default,
        string[] exceptions = null,
        string casterIgnoreImmunityFact = null,
        bool invertedDescriptors = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSpellImmunity();
      component.Type = type;
      component.m_Exceptions = exceptions.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.SpellDescriptor = spellDescriptor;
      component.m_CasterIgnoreImmunityFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(casterIgnoreImmunityFact);
      component.InvertedDescriptors = invertedDescriptors;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellKnownTemporary"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="spell"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddSpellKnownTemporary))]
    public TBuilder AddSpellKnownTemporary(
        string characterClass = null,
        string spell = null,
        int level = default,
        bool onlySpontaneous = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSpellKnownTemporary();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(spell);
      component.Level = level;
      component.OnlySpontaneous = onlySpontaneous;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellLevelLimit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSpellLevelLimit))]
    public TBuilder AddSpellLevelLimit(
        int forMaxLevel9 = default,
        int forMaxLevel6 = default,
        int forMaxLevel4 = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSpellLevelLimit();
      component.ForMaxLevel9 = forMaxLevel9;
      component.ForMaxLevel6 = forMaxLevel6;
      component.ForMaxLevel4 = forMaxLevel4;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellResistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSpellResistance))]
    public TBuilder AddSpellResistance(
        bool addCR = default,
        ContextValue value = null,
        bool allSpellResistancePenaltyDoNotUse = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new AddSpellResistance();
      component.AddCR = addCR;
      component.Value = value ?? ContextValues.Constant(0);
      component.AllSpellResistancePenaltyDoNotUse = allSpellResistancePenaltyDoNotUse;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellTypeFailureChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSpellTypeFailureChance))]
    public TBuilder AddSpellTypeFailureChance(
        GameObject failFx,
        int chance = default,
        bool arcane = default,
        bool divine = default,
        bool alchemist = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(failFx);
    
      var component = new AddSpellTypeFailureChance();
      component.Chance = chance;
      component.FailFx = failFx;
      component.Arcane = arcane;
      component.Divine = divine;
      component.Alchemist = alchemist;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStartingEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="basicItems"><see cref="BlueprintItem"/></param>
    /// <param name="customCategoryDefaults"><see cref="BlueprintCategoryDefaults"/></param>
    /// <param name="restrictedByClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(AddStartingEquipment))]
    public TBuilder AddStartingEquipment(
        string[] basicItems = null,
        WeaponCategory[] categoryItems = null,
        bool parametrizedCategory = default,
        string customCategoryDefaults = null,
        string[] restrictedByClass = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddStartingEquipment();
      component.m_BasicItems = basicItems.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name)).ToArray();
      component.CategoryItems = categoryItems;
      component.ParametrizedCategory = parametrizedCategory;
      component.m_CustomCategoryDefaults = BlueprintTool.GetRef<BlueprintCategoryDefaultsReference>(customCategoryDefaults);
      component.m_RestrictedByClass = restrictedByClass.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddStatBonus))]
    public TBuilder AddStatBonus(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int value = default,
        bool scaleByBasicAttackBonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddStatBonus();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.ScaleByBasicAttackBonus = scaleByBasicAttackBonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddStatModifier))]
    public TBuilder AddStatModifier(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        ContextValue modifierPercents = null,
        bool useBaseValue = default,
        bool updateIfStatChanged = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(modifierPercents);
    
      var component = new AddStatModifier();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.ModifierPercents = modifierPercents ?? ContextValues.Constant(0);
      component.UseBaseValue = useBaseValue;
      component.UpdateIfStatChanged = updateIfStatChanged;
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
    /// Adds <see cref="AddUnitScale"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddUnitScale))]
    public TBuilder AddUnitScale(
        float scaleIncreaseCoefficient = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddUnitScale();
      component.ScaleIncreaseCoefficient = scaleIncreaseCoefficient;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddUnlimitedSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilities"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddUnlimitedSpell))]
    public TBuilder AddUnlimitedSpell(
        string[] abilities = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddUnlimitedSpell();
      component.m_Abilities = abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AdditionalDamageOnSneakAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AdditionalDamageOnSneakAttack))]
    public TBuilder AdditionalDamageOnSneakAttack(
        int value = default,
        bool onlyRanged = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AdditionalDamageOnSneakAttack();
      component.Value = value;
      component.OnlyRanged = onlyRanged;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AeonSavedStateFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="rank"><see cref="BlueprintFeature"/></param>
    /// <param name="resource"><see cref="BlueprintAbilityResource"/></param>
    /// <param name="invulnerabilityBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AeonSavedStateFeature))]
    public TBuilder AddAeonSavedStateFeature(
        string rank = null,
        string resource = null,
        PrefabLink disappearFx = null,
        PrefabLink appearFx = null,
        float delaySeconds = default,
        string invulnerabilityBuff = null,
        float invulnerabilitySeconds = default,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AlchemistInfusionFeat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AlchemistInfusionFeat))]
    public TBuilder AddAlchemistInfusionFeat(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AlchemistInfusionFeat();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AllowDyingCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AllowDyingCondition))]
    public TBuilder AddAllowDyingCondition(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AllowDyingCondition();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ApplyClassProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="clazz"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="selectSpells"><see cref="BlueprintAbility"/></param>
    /// <param name="memorizeSpells"><see cref="BlueprintAbility"/></param>
    /// <param name="features"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ApplyClassProgression))]
    public TBuilder AddApplyClassProgression(
        int level = default,
        string clazz = null,
        string[] selectSpells = null,
        string[] memorizeSpells = null,
        string[] features = null,
        ParameterizedFeatureEntry[] parameterizedFeatures = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(parameterizedFeatures);
    
      var component = new ApplyClassProgression();
      component.Level = level;
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      component.m_SelectSpells = selectSpells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_MemorizeSpells = memorizeSpells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Features = features.Select(name => BlueprintTool.GetRef<BlueprintFeatureReference>(name)).ToArray();
      component.ParameterizedFeatures = parameterizedFeatures;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackStatReplacement"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponTypes"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(AttackStatReplacement))]
    public TBuilder AddAttackStatReplacement(
        StatType replacementStat = default,
        WeaponSubCategory subCategory = default,
        bool checkWeaponTypes = default,
        string[] weaponTypes = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AttackStatReplacement();
      component.ReplacementStat = replacementStat;
      component.SubCategory = subCategory;
      component.CheckWeaponTypes = checkWeaponTypes;
      component.m_WeaponTypes = weaponTypes.Select(name => BlueprintTool.GetRef<BlueprintWeaponTypeReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AutoFailCastingDefensively"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AutoFailCastingDefensively))]
    public TBuilder AddAutoFailCastingDefensively(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AutoFailCastingDefensively();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BookOfDreamsSummonUnitsCountLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BookOfDreamsSummonUnitsCountLogic))]
    public TBuilder AddBookOfDreamsSummonUnitsCountLogic(
        BlueprintComponent.Flags flags = default)
    {
      var component = new BookOfDreamsSummonUnitsCountLogic();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffDescriptorImmunity"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ignoreFeature"><see cref="BlueprintUnitFact"/></param>
    /// <param name="factToCheck"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(BuffDescriptorImmunity))]
    public TBuilder AddBuffDescriptorImmunity(
        SpellDescriptorWrapper descriptor,
        string ignoreFeature = null,
        bool checkFact = default,
        string factToCheck = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffDescriptorImmunity();
      component.Descriptor = descriptor;
      component.m_IgnoreFeature = BlueprintTool.GetRef<BlueprintUnitFactReference>(ignoreFeature);
      component.CheckFact = checkFact;
      component.m_FactToCheck = BlueprintTool.GetRef<BlueprintUnitFactReference>(factToCheck);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeFaction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="faction"><see cref="BlueprintFaction"/></param>
    [Generated]
    [Implements(typeof(ChangeFaction))]
    public TBuilder AddChangeFaction(
        ChangeFaction.ChangeType type = default,
        string faction = null,
        bool allowDirectControl = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ChangeFaction();
      component.m_Type = type;
      component.m_Faction = BlueprintTool.GetRef<BlueprintFactionReference>(faction);
      component.m_AllowDirectControl = allowDirectControl;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeImpatience"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeImpatience))]
    public TBuilder AddChangeImpatience(
        int delta = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ChangeImpatience();
      component.Delta = delta;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeIncomingDamageType"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeIncomingDamageType))]
    public TBuilder AddChangeIncomingDamageType(
        DamageTypeDescription type,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(type);
    
      var component = new ChangeIncomingDamageType();
      component.Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeOutgoingDamageType"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeOutgoingDamageType))]
    public TBuilder AddChangeOutgoingDamageType(
        DamageTypeDescription type,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(type);
    
      var component = new ChangeOutgoingDamageType();
      component.Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CombatManeuverOnCriticalHit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CombatManeuverOnCriticalHit))]
    public TBuilder AddCombatManeuverOnCriticalHit(
        CombatManeuver maneuver = default,
        ActionsBuilder onSuccess = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CombatManeuverOnCriticalHit();
      component.Maneuver = maneuver;
      component.OnSuccess = onSuccess?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CompanionImmortality"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CompanionImmortality))]
    public TBuilder AddCompanionImmortality(
        GameObject disappearFx,
        float disappearDelay = default,
        ActionsBuilder actions = null,
        LocalizedString fakeDeathMessage = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(disappearFx);
      ValidateParam(fakeDeathMessage);
    
      var component = new CompanionImmortality();
      component.DisappearDelay = disappearDelay;
      component.DisappearFx = disappearFx;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.FakeDeathMessage = fakeDeathMessage ?? Constants.Empty.String;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CompleteDamageImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CompleteDamageImmunity))]
    public TBuilder AddCompleteDamageImmunity(
        BlueprintComponent.Flags flags = default)
    {
      var component = new CompleteDamageImmunity();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConduitSurge"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ConduitSurge))]
    public TBuilder AddConduitSurge(
        string buff = null,
        ContextValue value = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new ConduitSurge();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.Value = value ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConfusionRollTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ConfusionRollTrigger))]
    public TBuilder AddConfusionRollTrigger(
        ConfusionState state = default,
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ConfusionRollTrigger();
      component.m_State = state;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeflectArrows"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DeflectArrows))]
    public TBuilder AddDeflectArrows(
        DeflectArrows.RestrictionType restriction = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DeflectArrows();
      component.m_Restriction = restriction;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DisableAttackType"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableAttackType))]
    public TBuilder AddDisableAttackType(
        AttackTypeFlag attackType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DisableAttackType();
      component.m_AttackType = attackType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DisableClassAdditionalVisualSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableClassAdditionalVisualSettings))]
    public TBuilder AddDisableClassAdditionalVisualSettings(
        BlueprintComponent.Flags flags = default)
    {
      var component = new DisableClassAdditionalVisualSettings();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DisableDeathFXs"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableDeathFXs))]
    public TBuilder AddDisableDeathFXs(
        BlueprintComponent.Flags flags = default)
    {
      var component = new DisableDeathFXs();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DisableEquipmentSlot"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableEquipmentSlot))]
    public TBuilder AddDisableEquipmentSlot(
        DisableEquipmentSlot.SlotType slotType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DisableEquipmentSlot();
      component.m_SlotType = slotType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DuelistParry"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cloakFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(DuelistParry))]
    public TBuilder AddDuelistParry(
        string cloakFact = null,
        DuelistParry.TargetType target = default,
        ConditionsBuilder attackerCondition = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DuelistParry();
      component.m_CloakFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(cloakFact);
      component.m_Target = target;
      component.AttackerCondition = attackerCondition?.Build() ?? Constants.Empty.Conditions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DweomerLeapLogic"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(DweomerLeapLogic))]
    public TBuilder AddDweomerLeapLogic(
        string ability = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DweomerLeapLogic();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EnhancePotion"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="classes"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="archetypes"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(EnhancePotion))]
    public TBuilder AddEnhancePotion(
        string[] classes = null,
        string[] archetypes = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EnhancePotion();
      component.m_Classes = classes.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray();
      component.m_Archetypes = archetypes.Select(name => BlueprintTool.GetRef<BlueprintArchetypeReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FastBombs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilities"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(FastBombs))]
    public TBuilder AddFastBombs(
        string[] abilities = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new FastBombs();
      component.m_Abilities = abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FavoredEnemy"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(FavoredEnemy))]
    public TBuilder AddFavoredEnemy(
        string[] checkedFacts = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new FavoredEnemy();
      component.m_CheckedFacts = checkedFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FavoredTerrain"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(FavoredTerrain))]
    public TBuilder AddFavoredTerrain(
        AreaSetting setting = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new FavoredTerrain();
      component.Setting = setting;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FavoredTerrainExpertise"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(FavoredTerrainExpertise))]
    public TBuilder AddFavoredTerrainExpertise(
        AreaSetting setting = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new FavoredTerrainExpertise();
      component.Setting = setting;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ForbidRotation"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ForbidRotation))]
    public TBuilder AddForbidRotation(
        BlueprintComponent.Flags flags = default)
    {
      var component = new ForbidRotation();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ForbidSpecificSpellsCast"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(ForbidSpecificSpellsCast))]
    public TBuilder AddForbidSpecificSpellsCast(
        SpellDescriptorWrapper spellDescriptor,
        string[] spells = null,
        bool useSpellDescriptor = default,
        ActionsBuilder onForbiddenCastAttempt = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ForbidSpecificSpellsCast();
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.UseSpellDescriptor = useSpellDescriptor;
      component.SpellDescriptor = spellDescriptor;
      component.OnForbiddenCastAttempt = onForbiddenCastAttempt?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ForbidSpellCasting"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ignoreFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ForbidSpellCasting))]
    public TBuilder AddForbidSpellCasting(
        bool forbidMagicItems = default,
        string ignoreFeature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ForbidSpellCasting();
      component.ForbidMagicItems = forbidMagicItems;
      component.m_IgnoreFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(ignoreFeature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ForbidSpellbook"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbook"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(ForbidSpellbook))]
    public TBuilder AddForbidSpellbook(
        string spellbook = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ForbidSpellbook();
      component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(spellbook);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ForbidSpellbookOnAlignmentDeviation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbooks"><see cref="BlueprintSpellbook"/></param>
    /// <param name="ignoreFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ForbidSpellbookOnAlignmentDeviation))]
    public TBuilder AddForbidSpellbookOnAlignmentDeviation(
        string[] spellbooks = null,
        AlignmentMaskType alignment = default,
        string ignoreFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ForbidSpellbookOnAlignmentDeviation();
      component.m_Spellbooks = spellbooks.Select(name => BlueprintTool.GetRef<BlueprintSpellbookReference>(name)).ToArray();
      component.Alignment = alignment;
      component.m_IgnoreFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(ignoreFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ForbidSpellbookOnArmorEquip"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbooks"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(ForbidSpellbookOnArmorEquip))]
    public TBuilder AddForbidSpellbookOnArmorEquip(
        string[] spellbooks = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ForbidSpellbookOnArmorEquip();
      component.m_Spellbooks = spellbooks.Select(name => BlueprintTool.GetRef<BlueprintSpellbookReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FreeActionSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(FreeActionSpell))]
    public TBuilder AddFreeActionSpell(
        string ability = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new FreeActionSpell();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="GentlePersuasionConditioning"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="punishmentBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="rewardBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(GentlePersuasionConditioning))]
    public TBuilder AddGentlePersuasionConditioning(
        string punishmentBuff = null,
        string rewardBuff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new GentlePersuasionConditioning();
      component.m_PunishmentBuff = BlueprintTool.GetRef<BlueprintBuffReference>(punishmentBuff);
      component.m_RewardBuff = BlueprintTool.GetRef<BlueprintBuffReference>(rewardBuff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="GhostCriticalAndPrecisionImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GhostCriticalAndPrecisionImmunity))]
    public TBuilder AddGhostCriticalAndPrecisionImmunity(
        BlueprintComponent.Flags flags = default)
    {
      var component = new GhostCriticalAndPrecisionImmunity();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="GreaterCombatMeneuver"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GreaterCombatMeneuver))]
    public TBuilder AddGreaterCombatMeneuver(
        CombatManeuver maneuver = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new GreaterCombatMeneuver();
      component.Maneuver = maneuver;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HalveIncomingAreaDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HalveIncomingAreaDamage))]
    public TBuilder AddHalveIncomingAreaDamage(
        BlueprintComponent.Flags flags = default)
    {
      var component = new HalveIncomingAreaDamage();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HideFactsWhileEtudePlaying"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="etude"><see cref="BlueprintEtude"/></param>
    /// <param name="replaceRace"><see cref="BlueprintRace"/></param>
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(HideFactsWhileEtudePlaying))]
    public TBuilder AddHideFactsWhileEtudePlaying(
        string etude = null,
        string replaceRace = null,
        string[] facts = null,
        HashSet<BlueprintUnitFact> cachedFacts = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(cachedFacts);
    
      var component = new HideFactsWhileEtudePlaying();
      component.m_Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      component.m_ReplaceRace = BlueprintTool.GetRef<BlueprintRaceReference>(replaceRace);
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_CachedFacts = cachedFacts;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HigherMythicsReplace"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HigherMythicsReplace))]
    public TBuilder AddHigherMythicsReplace(
        BlueprintComponent.Flags flags = default)
    {
      var component = new HigherMythicsReplace();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreIncommingDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreIncommingDamage))]
    public TBuilder AddIgnoreIncommingDamage(
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreIncommingDamage();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreSpellImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreSpellImmunity))]
    public TBuilder AddIgnoreSpellImmunity(
        SpellDescriptorWrapper spellDescriptor,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreSpellImmunity();
      component.SpellDescriptor = spellDescriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncorporealACBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncorporealACBonus))]
    public TBuilder AddIncorporealACBonus(
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncorporealACBonus();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseActivatableAbilityGroupSize"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseActivatableAbilityGroupSize))]
    public TBuilder AddIncreaseActivatableAbilityGroupSize(
        ActivatableAbilityGroup group = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseActivatableAbilityGroupSize();
      component.Group = group;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseResourceAmount"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(IncreaseResourceAmount))]
    public TBuilder AddIncreaseResourceAmount(
        string resource = null,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseResourceAmount();
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseResourceAmountBySharedValue"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(IncreaseResourceAmountBySharedValue))]
    public TBuilder AddIncreaseResourceAmountBySharedValue(
        string resource = null,
        ContextValue value = null,
        bool decrease = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new IncreaseResourceAmountBySharedValue();
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      component.Value = value ?? ContextValues.Constant(0);
      component.Decrease = decrease;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseResourcesByClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="BlueprintAbilityResource"/></param>
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="archetype"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(IncreaseResourcesByClass))]
    public TBuilder AddIncreaseResourcesByClass(
        string resource = null,
        string characterClass = null,
        string archetype = null,
        StatType stat = default,
        int baseValue = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseResourcesByClass();
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      component.Stat = stat;
      component.BaseValue = baseValue;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="InitiatorDisarmTrapTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(InitiatorDisarmTrapTrigger))]
    public TBuilder AddInitiatorDisarmTrapTrigger(
        ActionsBuilder onDisarmSuccess = null,
        ActionsBuilder onDisarmFail = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new InitiatorDisarmTrapTrigger();
      component.OnDisarmSuccess = onDisarmSuccess?.Build() ?? Constants.Empty.Actions;
      component.OnDisarmFail = onDisarmFail?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="InitiatorSavingThrowTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(InitiatorSavingThrowTrigger))]
    public TBuilder AddInitiatorSavingThrowTrigger(
        ActionsBuilder onSuccessfulSave = null,
        ActionsBuilder onFailedSave = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new InitiatorSavingThrowTrigger();
      component.OnSuccessfulSave = onSuccessfulSave?.Build() ?? Constants.Empty.Actions;
      component.OnFailedSave = onFailedSave?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KeepAlliesAlive"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="walkingDeadBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(KeepAlliesAlive))]
    public TBuilder AddKeepAlliesAlive(
        ContextValue maxAttacksCount = null,
        string walkingDeadBuff = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(maxAttacksCount);
    
      var component = new KeepAlliesAlive();
      component.m_MaxAttacksCount = maxAttacksCount ?? ContextValues.Constant(0);
      component.WalkingDeadBuff = BlueprintTool.GetRef<BlueprintBuffReference>(walkingDeadBuff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LearnSpellList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="spellList"><see cref="BlueprintSpellList"/></param>
    /// <param name="archetype"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(LearnSpellList))]
    public TBuilder AddLearnSpellList(
        string characterClass = null,
        string spellList = null,
        string archetype = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new LearnSpellList();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(spellList);
      component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LearnSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(LearnSpells))]
    public TBuilder AddLearnSpells(
        string characterClass = null,
        string[] spells = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new LearnSpells();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LockEquipmentSlot"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LockEquipmentSlot))]
    public TBuilder AddLockEquipmentSlot(
        LockEquipmentSlot.SlotType slotType = default,
        bool deactivate = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new LockEquipmentSlot();
      component.m_SlotType = slotType;
      component.m_Deactivate = deactivate;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MarkPassive"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MarkPassive))]
    public TBuilder AddMarkPassive(
        BlueprintComponent.Flags flags = default)
    {
      var component = new MarkPassive();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MayBanterOnRest"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MayBanterOnRest))]
    public TBuilder AddMayBanterOnRest(
        BlueprintComponent.Flags flags = default)
    {
      var component = new MayBanterOnRest();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MovementDistanceTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MovementDistanceTrigger))]
    public TBuilder AddMovementDistanceTrigger(
        ActionsBuilder action = null,
        ContextValue distanceInFeet = null,
        bool limitTiggerCountInOneRound = default,
        int tiggerCountMaximumInOneRound = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(distanceInFeet);
    
      var component = new MovementDistanceTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.DistanceInFeet = distanceInFeet ?? ContextValues.Constant(0);
      component.LimitTiggerCountInOneRound = limitTiggerCountInOneRound;
      component.TiggerCountMaximumInOneRound = tiggerCountMaximumInOneRound;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NenioSpecialPolymorphWhileEtudePlaying"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="etude"><see cref="BlueprintEtude"/></param>
    /// <param name="standardPolymorphAbility"><see cref="BlueprintActivatableAbility"/></param>
    /// <param name="specialPolymorphBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(NenioSpecialPolymorphWhileEtudePlaying))]
    public TBuilder AddNenioSpecialPolymorphWhileEtudePlaying(
        string etude = null,
        string standardPolymorphAbility = null,
        string specialPolymorphBuff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new NenioSpecialPolymorphWhileEtudePlaying();
      component.m_Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      component.m_StandardPolymorphAbility = BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(standardPolymorphAbility);
      component.m_SpecialPolymorphBuff = BlueprintTool.GetRef<BlueprintBuffReference>(specialPolymorphBuff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OverrideVisionRange"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OverrideVisionRange))]
    public TBuilder AddOverrideVisionRange(
        int visionRangeInMeters = default,
        bool alsoInCombat = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new OverrideVisionRange();
      component.VisionRangeInMeters = visionRangeInMeters;
      component.AlsoInCombat = alsoInCombat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PreventHealing"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PreventHealing))]
    public TBuilder AddPreventHealing(
        BlueprintComponent.Flags flags = default)
    {
      var component = new PreventHealing();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PriorityTarget"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="priorityFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(PriorityTarget))]
    public TBuilder AddPriorityTarget(
        string priorityFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new PriorityTarget();
      component.PriorityFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(priorityFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RaiseBAB"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RaiseBAB))]
    public TBuilder AddRaiseBAB(
        ContextValue targetValue = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(targetValue);
    
      var component = new RaiseBAB();
      component.TargetValue = targetValue ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RaiseStatToMinimum"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RaiseStatToMinimum))]
    public TBuilder AddRaiseStatToMinimum(
        ContextValue targetValue = null,
        StatType stat = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(targetValue);
    
      var component = new RaiseStatToMinimum();
      component.TargetValue = targetValue ?? ContextValues.Constant(0);
      component.Stat = stat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RangedCleave"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RangedCleave))]
    public TBuilder AddRangedCleave(
        Feet range,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RangedCleave();
      component.Range = range;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RedirectDamageToPet"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RedirectDamageToPet))]
    public TBuilder AddRedirectDamageToPet(
        int percentRedirected = default,
        PetType petType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RedirectDamageToPet();
      component.m_PercentRedirected = percentRedirected;
      component.m_PetType = petType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceStatBaseAttribute"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReplaceStatBaseAttribute))]
    public TBuilder AddReplaceStatBaseAttribute(
        StatType targetStat = default,
        StatType baseAttributeReplacement = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceStatBaseAttribute();
      component.TargetStat = targetStat;
      component.BaseAttributeReplacement = baseAttributeReplacement;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Revolt"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Revolt))]
    public TBuilder AddRevolt(
        BlueprintComponent.Flags flags = default)
    {
      var component = new Revolt();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ScrollSpecialization"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="specializedClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(ScrollSpecialization))]
    public TBuilder AddScrollSpecialization(
        string specializedClass = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ScrollSpecialization();
      component.m_SpecializedClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(specializedClass);
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
    /// Adds <see cref="SetRunBackLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetRunBackLogic))]
    public TBuilder AddSetRunBackLogic(
        float triggerDistance = default,
        float runBackDistance = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SetRunBackLogic();
      component.TriggerDistance = triggerDistance;
      component.RunBackDistance = runBackDistance;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpecificBuffImmunity"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(SpecificBuffImmunity))]
    public TBuilder AddSpecificBuffImmunity(
        string buff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpecificBuffImmunity();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellImmunityToSpellDescriptor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="casterIgnoreImmunityFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SpellImmunityToSpellDescriptor))]
    public TBuilder AddSpellImmunityToSpellDescriptor(
        SpellDescriptorWrapper descriptor,
        string casterIgnoreImmunityFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpellImmunityToSpellDescriptor();
      component.Descriptor = descriptor;
      component.m_CasterIgnoreImmunityFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(casterIgnoreImmunityFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellLinkEvocation"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpellLinkEvocation))]
    public TBuilder AddSpellLinkEvocation(
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpellLinkEvocation();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellResistanceAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpellResistanceAgainstAlignment))]
    public TBuilder AddSpellResistanceAgainstAlignment(
        ContextValue value = null,
        AlignmentComponent alignment = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new SpellResistanceAgainstAlignment();
      component.Value = value ?? ContextValues.Constant(0);
      component.Alignment = alignment;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellResistanceAgainstSpellDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpellResistanceAgainstSpellDescriptor))]
    public TBuilder AddSpellResistanceAgainstSpellDescriptor(
        SpellDescriptorWrapper spellDescriptor,
        ContextValue value = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new SpellResistanceAgainstSpellDescriptor();
      component.Value = value ?? ContextValues.Constant(0);
      component.SpellDescriptor = spellDescriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpontaneousSpellConversion"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="spellsByLevel"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(SpontaneousSpellConversion))]
    public TBuilder AddSpontaneousSpellConversion(
        string characterClass = null,
        string[] spellsByLevel = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpontaneousSpellConversion();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_SpellsByLevel = spellsByLevel.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SufferFromHealing"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SufferFromHealing))]
    public TBuilder AddSufferFromHealing(
        DamageTypeDescription damageDescription,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(damageDescription);
    
      var component = new SufferFromHealing();
      component.DamageDescription = damageDescription;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SuppressBuffs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buffs"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(SuppressBuffs))]
    public TBuilder AddSuppressBuffs(
        SpellDescriptorWrapper descriptor,
        string[] buffs = null,
        SpellSchool[] schools = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SuppressBuffs();
      component.m_Buffs = buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
      component.Schools = schools;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SuppressDismember"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SuppressDismember))]
    public TBuilder AddSuppressDismember(
        BlueprintComponent.Flags flags = default)
    {
      var component = new SuppressDismember();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SwarmAoeVulnerability"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SwarmAoeVulnerability))]
    public TBuilder AddSwarmAoeVulnerability(
        BlueprintComponent.Flags flags = default)
    {
      var component = new SwarmAoeVulnerability();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SwarmDamageResistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SwarmDamageResistance))]
    public TBuilder AddSwarmDamageResistance(
        bool diminutiveOrLower = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SwarmDamageResistance();
      component.DiminutiveOrLower = diminutiveOrLower;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TricksterParry"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TricksterParry))]
    public TBuilder AddTricksterParry(
        TricksterParry.TargetType target = default,
        ConditionsBuilder attackerCondition = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TricksterParry();
      component.m_Target = target;
      component.AttackerCondition = attackerCondition?.Build() ?? Constants.Empty.Conditions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnearthlyGrace"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnearthlyGrace))]
    public TBuilder AddUnearthlyGrace(
        BlueprintComponent.Flags flags = default)
    {
      var component = new UnearthlyGrace();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnfailingBeacon"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnfailingBeacon))]
    public TBuilder AddUnfailingBeacon(
        BlueprintComponent.Flags flags = default)
    {
      var component = new UnfailingBeacon();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnholyGrace"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnholyGrace))]
    public TBuilder AddUnholyGrace(
        BlueprintComponent.Flags flags = default)
    {
      var component = new UnholyGrace();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnitHealthGuard"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitHealthGuard))]
    public TBuilder AddUnitHealthGuard(
        int healthPercent = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new UnitHealthGuard();
      component.HealthPercent = healthPercent;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Untargetable"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Untargetable))]
    public TBuilder AddUntargetable(
        BlueprintComponent.Flags flags = default)
    {
      var component = new Untargetable();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTraining"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponTraining))]
    public TBuilder AddWeaponTraining(
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponTraining();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTrainingAttackStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponTrainingAttackStatReplacement))]
    public TBuilder AddWeaponTrainingAttackStatReplacement(
        StatType replacementStat = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponTrainingAttackStatReplacement();
      component.ReplacementStat = replacementStat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistAcceptBurnTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddKineticistAcceptBurnTrigger))]
    public TBuilder AddKineticistAcceptBurnTrigger(
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddKineticistAcceptBurnTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistBurnModifier"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="appliableTo"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddKineticistBurnModifier))]
    public TBuilder AddKineticistBurnModifier(
        KineticistBurnType burnType = default,
        int value = default,
        bool removeBuffOnAcceptBurn = default,
        bool useContextValue = default,
        ContextValue burnValue = null,
        string[] appliableTo = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(burnValue);
    
      var component = new AddKineticistBurnModifier();
      component.BurnType = burnType;
      component.Value = value;
      component.RemoveBuffOnAcceptBurn = removeBuffOnAcceptBurn;
      component.UseContextValue = useContextValue;
      component.BurnValue = burnValue ?? ContextValues.Constant(0);
      component.m_AppliableTo = appliableTo.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistBurnValueChangedTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddKineticistBurnValueChangedTrigger))]
    public TBuilder AddKineticistBurnValueChangedTrigger(
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddKineticistBurnValueChangedTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistElementalOverflow"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="firesFury"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddKineticistElementalOverflow))]
    public TBuilder AddKineticistElementalOverflow(
        ContextValue bonus = null,
        bool ignoreBurn = default,
        bool elementalEngine = default,
        string firesFury = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new AddKineticistElementalOverflow();
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.IgnoreBurn = ignoreBurn;
      component.ElementalEngine = elementalEngine;
      component.m_FiresFury = BlueprintTool.GetRef<BlueprintUnitFactReference>(firesFury);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistPart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="clazz"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="maxBurn"><see cref="BlueprintAbilityResource"/></param>
    /// <param name="maxBurnPerRound"><see cref="BlueprintAbilityResource"/></param>
    /// <param name="gatherPowerAbility"><see cref="BlueprintAbility"/></param>
    /// <param name="gatherPowerIncreaseFeature"><see cref="BlueprintFeature"/></param>
    /// <param name="gatherPowerBuff1"><see cref="BlueprintBuff"/></param>
    /// <param name="gatherPowerBuff2"><see cref="BlueprintBuff"/></param>
    /// <param name="gatherPowerBuff3"><see cref="BlueprintBuff"/></param>
    /// <param name="blasts"><see cref="BlueprintAbility"/></param>
    /// <param name="bladeActivatedBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="canGatherPowerWithShieldBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AddKineticistPart))]
    public TBuilder AddKineticistPart(
        string clazz = null,
        StatType mainStat = default,
        string maxBurn = null,
        string maxBurnPerRound = null,
        string gatherPowerAbility = null,
        string gatherPowerIncreaseFeature = null,
        string gatherPowerBuff1 = null,
        string gatherPowerBuff2 = null,
        string gatherPowerBuff3 = null,
        string[] blasts = null,
        string bladeActivatedBuff = null,
        string canGatherPowerWithShieldBuff = null,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SetKineticistGatherPowerMode"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetKineticistGatherPowerMode))]
    public TBuilder AddSetKineticistGatherPowerMode(
        KineticistGatherPowerMode mode = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SetKineticistGatherPowerMode();
      component.Mode = mode;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeHitDie"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeHitDie))]
    public TBuilder AddChangeHitDie(
        DiceType hitDie = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ChangeHitDie();
      component.m_HitDie = hitDie;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEnergyDamageTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEnergyDamageTrigger))]
    public TBuilder AddEnergyDamageTrigger(
        DamageEnergyType damageType = default,
        bool spellsOnly = default,
        ActionsBuilder actions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddEnergyDamageTrigger();
      component.DamageType = damageType;
      component.SpellsOnly = spellsOnly;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddIncomingDamageTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddIncomingDamageTrigger))]
    public TBuilder AddIncomingDamageTrigger(
        ActionsBuilder actions = null,
        bool triggerOnStatDamageOrEnergyDrain = default,
        bool ignoreDamageFromThisFact = default,
        bool reduceBelowZero = default,
        bool checkDamageDealt = default,
        CompareOperation.Type compareType = default,
        ContextValue targetValue = null,
        bool checkWeaponAttackType = default,
        AttackTypeFlag attackType = default,
        bool checkEnergyDamageType = default,
        DamageEnergyType energyType = default,
        bool checkDamagePhysicalTypeNot = default,
        PhysicalDamageForm damagePhysicalTypeNot = default,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddInitiatorPartySkillRollTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddInitiatorPartySkillRollTrigger))]
    public TBuilder AddInitiatorPartySkillRollTrigger(
        bool onlySuccess = default,
        StatType skill = default,
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddInitiatorPartySkillRollTrigger();
      component.OnlySuccess = onlySuccess;
      component.Skill = skill;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddInitiatorSavingThrowTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddInitiatorSavingThrowTrigger))]
    public TBuilder AddInitiatorSavingThrowTrigger(
        bool onlyPass = default,
        bool onlyFail = default,
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddInitiatorSavingThrowTrigger();
      component.OnlyPass = onlyPass;
      component.OnlyFail = onlyFail;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistInfusionDamageTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="BlueprintWeaponType"/></param>
    /// <param name="abilityList"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddKineticistInfusionDamageTrigger))]
    public TBuilder AddKineticistInfusionDamageTrigger(
        SpellDescriptorWrapper spellDescriptorsList,
        TimeSpan lastFrameTime,
        ActionsBuilder actions = null,
        bool triggerOnStatDamageOrEnergyDrain = default,
        bool checkWeaponType = default,
        bool checkSpellDescriptor = default,
        bool checkSpellParent = default,
        bool triggerOnDirectDamage = default,
        string weaponType = null,
        string[] abilityList = null,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddOutgoingDamageTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="BlueprintWeaponType"/></param>
    /// <param name="abilityList"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddOutgoingDamageTrigger))]
    public TBuilder AddOutgoingDamageTrigger(
        SpellDescriptorWrapper spellDescriptorsList,
        ActionsBuilder actions = null,
        bool triggerOnStatDamageOrEnergyDrain = default,
        bool checkWeaponType = default,
        bool checkAbilityType = default,
        AbilityType abilityType = default,
        bool checkSpellDescriptor = default,
        bool checkSpellParent = default,
        bool notZeroDamage = default,
        bool checkDamageDealt = default,
        CompareOperation.Type compareType = default,
        ContextValue targetValue = null,
        bool checkEnergyDamageType = default,
        DamageEnergyType energyType = default,
        bool applyToAreaEffectDamage = default,
        bool targetKilledByThisDamage = default,
        string weaponType = null,
        string[] abilityList = null,
        BlueprintComponent.Flags flags = default)
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
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.m_AbilityList = abilityList.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.SpellDescriptorsList = spellDescriptorsList;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellDiceBonusTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSpellDiceBonusTrigger))]
    public TBuilder AddSpellDiceBonusTrigger(
        SpellDescriptorWrapper spellDescriptorsList,
        bool checkSpellDescriptor = default,
        ContextDiceValue[] diceValues = null,
        int[] diceBonuses = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(diceValues);
    
      var component = new AddSpellDiceBonusTrigger();
      component.CheckSpellDescriptor = checkSpellDescriptor;
      component.SpellDescriptorsList = spellDescriptorsList;
      component.DiceValues = diceValues;
      component.DiceBonuses = diceBonuses;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTargetAttackWithWeaponTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddTargetAttackWithWeaponTrigger))]
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
        WeaponCategory[] categories = null,
        ActionsBuilder actionsOnAttacker = null,
        ActionsBuilder actionOnSelf = null,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTargetSavingThrowTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddTargetSavingThrowTrigger))]
    public TBuilder AddTargetSavingThrowTrigger(
        bool onlyPass = default,
        bool onlyFail = default,
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddTargetSavingThrowTrigger();
      component.OnlyPass = onlyPass;
      component.OnlyFail = onlyFail;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTargetSpellResistanceCheckTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddTargetSpellResistanceCheckTrigger))]
    public TBuilder AddTargetSpellResistanceCheckTrigger(
        bool onlyPass = default,
        bool onlyFail = default,
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddTargetSpellResistanceCheckTrigger();
      component.OnlyPass = onlyPass;
      component.OnlyFail = onlyFail;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
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
    /// Adds <see cref="ChangeSpellElementalDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeSpellElementalDamage))]
    public TBuilder AddChangeSpellElementalDamage(
        DamageEnergyType element = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ChangeSpellElementalDamage();
      component.Element = element;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeSpellElementalDamageHalfUntyped"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeSpellElementalDamageHalfUntyped))]
    public TBuilder AddChangeSpellElementalDamageHalfUntyped(
        DamageEnergyType element = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ChangeSpellElementalDamageHalfUntyped();
      component.Element = element;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeathActions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(DeathActions))]
    public TBuilder AddDeathActions(
        ActionsBuilder actions = null,
        bool checkResource = default,
        bool onlyOnParty = default,
        string resource = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DeathActions();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.CheckResource = checkResource;
      component.OnlyOnParty = onlyOnParty;
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeskariAspect"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DeskariAspect))]
    public TBuilder AddDeskariAspect(
        BlueprintComponent.Flags flags = default)
    {
      var component = new DeskariAspect();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FlamewardenBurningRenewal"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(FlamewardenBurningRenewal))]
    public TBuilder AddFlamewardenBurningRenewal(
        ActionsBuilder actions = null,
        string resource = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new FlamewardenBurningRenewal();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="InitiatorRuleDealDamageTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(InitiatorRuleDealDamageTrigger))]
    public TBuilder AddInitiatorRuleDealDamageTrigger(
        ActionsBuilder actionOnSource = null,
        AbilitySharedValue sharedValue = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new InitiatorRuleDealDamageTrigger();
      component.m_ActionOnSource = actionOnSource?.Build() ?? Constants.Empty.Actions;
      component.m_SharedValue = sharedValue;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OutcomingDamageAndHealingModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OutcomingDamageAndHealingModifier))]
    public TBuilder AddOutcomingDamageAndHealingModifier(
        ContextValue modifierPercents = null,
        OutcomingDamageAndHealingModifier.ModifyingType type = default,
        OutcomingDamageAndHealingModifier.WeaponType damageWeaponType = default,
        bool overrideOtherModifierPercents = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(modifierPercents);
    
      var component = new OutcomingDamageAndHealingModifier();
      component.ModifierPercents = modifierPercents ?? ContextValues.Constant(0);
      component.Type = type;
      component.m_DamageWeaponType = damageWeaponType;
      component.m_OverrideOtherModifierPercents = overrideOtherModifierPercents;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SacredWeaponDamageOverride"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(SacredWeaponDamageOverride))]
    public TBuilder AddSacredWeaponDamageOverride(
        DiceFormula formula,
        string feature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SacredWeaponDamageOverride();
      component.Formula = formula;
      component.m_Feature = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(feature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SacredWeaponFavoriteDamageOverride"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="deaitySacredWeaponFeature"><see cref="BlueprintFeature"/></param>
    /// <param name="buff1d6"><see cref="BlueprintBuff"/></param>
    /// <param name="buff1d8"><see cref="BlueprintBuff"/></param>
    /// <param name="buff1d10"><see cref="BlueprintBuff"/></param>
    /// <param name="buff2d6"><see cref="BlueprintBuff"/></param>
    /// <param name="buff2d8"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(SacredWeaponFavoriteDamageOverride))]
    public TBuilder AddSacredWeaponFavoriteDamageOverride(
        WeaponCategory category = default,
        string deaitySacredWeaponFeature = null,
        string buff1d6 = null,
        string buff1d8 = null,
        string buff1d10 = null,
        string buff2d6 = null,
        string buff2d8 = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SacredWeaponFavoriteDamageOverride();
      component.Category = category;
      component.m_DeaitySacredWeaponFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(deaitySacredWeaponFeature);
      component.m_Buff1d6 = BlueprintTool.GetRef<BlueprintBuffReference>(buff1d6);
      component.m_Buff1d8 = BlueprintTool.GetRef<BlueprintBuffReference>(buff1d8);
      component.m_Buff1d10 = BlueprintTool.GetRef<BlueprintBuffReference>(buff1d10);
      component.m_Buff2d6 = BlueprintTool.GetRef<BlueprintBuffReference>(buff2d6);
      component.m_Buff2d8 = BlueprintTool.GetRef<BlueprintBuffReference>(buff2d8);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SetAttackerMissChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetAttackerMissChance))]
    public TBuilder AddSetAttackerMissChance(
        SetAttackerMissChance.Type type = default,
        ContextValue value = null,
        ConditionsBuilder conditions = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new SetAttackerMissChance();
      component.m_Type = type;
      component.Value = value ?? ContextValues.Constant(0);
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
        SetFactOwnerMissChance.Type type = default,
        ContextValue value = null,
        ConditionsBuilder conditions = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new SetFactOwnerMissChance();
      component.m_Type = type;
      component.Value = value ?? ContextValues.Constant(0);
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageOverride"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponTypes"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(WeaponDamageOverride))]
    public TBuilder AddWeaponDamageOverride(
        DiceFormula formula,
        string[] weaponTypes = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponDamageOverride();
      component.Formula = formula;
      component.m_WeaponTypes = weaponTypes.Select(name => BlueprintTool.GetRef<BlueprintWeaponTypeReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DublicateSpellComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DublicateSpellComponent))]
    public TBuilder AddDublicateSpellComponent(
        int feetsRaiuds = default,
        DublicateSpellComponent.AOEType aOECheck = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DublicateSpellComponent();
      component.m_FeetsRaiuds = feetsRaiuds;
      component.m_AOECheck = aOECheck;
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
        string abilityResource = null,
        ContextValue levelMultiplier = null,
        ContextValue additionalCost = null,
        bool saveSpellSlot = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(levelMultiplier);
      ValidateParam(additionalCost);
    
      var component = new AbilityResourceOverride();
      component.m_AbilityResource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(abilityResource);
      component.m_LevelMultiplier = levelMultiplier ?? ContextValues.Constant(0);
      component.m_AdditionalCost = additionalCost ?? ContextValues.Constant(0);
      component.m_SaveSpellSlot = saveSpellSlot;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreAttacksOfOpportunityForSpellList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilities"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(IgnoreAttacksOfOpportunityForSpellList))]
    public TBuilder AddIgnoreAttacksOfOpportunityForSpellList(
        SpellDescriptorWrapper spellDescriptor,
        string[] abilities = null,
        bool checkSchool = default,
        SpellSchool school = default,
        bool checkDescriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreAttacksOfOpportunityForSpellList();
      component.m_Abilities = abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToList();
      component.CheckSchool = checkSchool;
      component.School = school;
      component.CheckDescriptor = checkDescriptor;
      component.SpellDescriptor = spellDescriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyAlternativeMovement"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="deliverAbility"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(ArmyAlternativeMovement))]
    public TBuilder AddArmyAlternativeMovement(
        bool ignoreObstacles = default,
        string deliverAbility = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArmyAlternativeMovement();
      component.m_IgnoreObstacles = ignoreObstacles;
      component.m_DeliverAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(deliverAbility);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyChangeInitiative"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyChangeInitiative))]
    public TBuilder AddArmyChangeInitiative(
        ModifierDescriptor descriptor = default,
        ContextValue value = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new ArmyChangeInitiative();
      component.m_Descriptor = descriptor;
      component.m_Value = value ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyForceMelee"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyForceMelee))]
    public TBuilder AddArmyForceMelee(
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArmyForceMelee();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyFullAttackEndTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyFullAttackEndTrigger))]
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
        WeaponCategory[] categories = null,
        ActionsBuilder actionsOnInitiator = null,
        ActionsBuilder actionOnTarget = null,
        BlueprintComponent.Flags flags = default)
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
    /// Adds <see cref="ChangeLeaderSkillPowerOnAbilityUse"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeLeaderSkillPowerOnAbilityUse))]
    public TBuilder AddChangeLeaderSkillPowerOnAbilityUse(
        SpellDescriptorWrapper spellDescriptor,
        bool checkDescriptor = default,
        int modifier = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ChangeLeaderSkillPowerOnAbilityUse();
      component.m_CheckDescriptor = checkDescriptor;
      component.m_SpellDescriptor = spellDescriptor;
      component.m_Modifier = modifier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RandomLeaderSpellReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RandomLeaderSpellReplacement))]
    public TBuilder AddRandomLeaderSpellReplacement(
        float chanceToReplace = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RandomLeaderSpellReplacement();
      component.m_ChanceToReplace = chanceToReplace;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RunActionOnTurnStart"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RunActionOnTurnStart))]
    public TBuilder AddRunActionOnTurnStart(
        float chanceCoefficient = default,
        ActionsBuilder actions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RunActionOnTurnStart();
      component.m_ChanceCoefficient = chanceCoefficient;
      component.m_Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalBattleEndTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalBattleEndTrigger))]
    public TBuilder AddTacticalBattleEndTrigger(
        bool onlyOnVictory = default,
        ActionsBuilder onBattleEnd = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TacticalBattleEndTrigger();
      component.OnlyOnVictory = onlyOnVictory;
      component.m_OnBattleEnd = onBattleEnd?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCellReachTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCellReachTrigger))]
    public TBuilder AddTacticalCellReachTrigger(
        int x = default,
        int y = default,
        bool anyX = default,
        bool anyY = default,
        ActionsBuilder onReach = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TacticalCellReachTrigger();
      component.m_X = x;
      component.m_Y = y;
      component.m_AnyX = anyX;
      component.m_AnyY = anyY;
      component.m_OnReach = onReach?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatChangeFaction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCombatChangeFaction))]
    public TBuilder AddTacticalCombatChangeFaction(
        TacticalCombatChangeFaction.ChangeType type = default,
        ArmyFaction faction = default,
        bool allowDirectControl = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TacticalCombatChangeFaction();
      component.m_Type = type;
      component.m_Faction = faction;
      component.m_AllowDirectControl = allowDirectControl;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatEndMovementTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCombatEndMovementTrigger))]
    public TBuilder AddTacticalCombatEndMovementTrigger(
        ActionsBuilder actions = null,
        bool allowOnlyMoveCommands = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TacticalCombatEndMovementTrigger();
      component.m_Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_AllowOnlyMoveCommands = allowOnlyMoveCommands;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatPercentDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCombatPercentDamageBonus))]
    public TBuilder AddTacticalCombatPercentDamageBonus(
        int bonusPercent = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TacticalCombatPercentDamageBonus();
      component.BonusPercent = bonusPercent;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatProvocation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="aiAction"><see cref="BlueprintTacticalCombatAiAction"/></param>
    [Generated]
    [Implements(typeof(TacticalCombatProvocation))]
    public TBuilder AddTacticalCombatProvocation(
        string aiAction = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TacticalCombatProvocation();
      component.m_AiAction = BlueprintTool.GetRef<BlueprintTacticalCombatAiActionReference>(aiAction);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatRider"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="mount"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(TacticalCombatRider))]
    public TBuilder AddTacticalCombatRider(
        string mount = null,
        bool applyRiderScaleToHorse = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TacticalCombatRider();
      component.m_Mount = BlueprintTool.GetRef<BlueprintUnitReference>(mount);
      component.m_ApplyRiderScaleToHorse = applyRiderScaleToHorse;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatRoundTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCombatRoundTrigger))]
    public TBuilder AddTacticalCombatRoundTrigger(
        ActionsBuilder newRoundActions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TacticalCombatRoundTrigger();
      component.NewRoundActions = newRoundActions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalSquadDeathTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="armyFactOnOwnerDeath"><see cref="BlueprintUnitFact"/></param>
    /// <param name="armyFactOnOthersDeath"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(TacticalSquadDeathTrigger))]
    public TBuilder AddTacticalSquadDeathTrigger(
        string armyFactOnOwnerDeath = null,
        string armyFactOnOthersDeath = null,
        bool removeFactOnAnyDeath = default,
        ArmyFaction factDestinationFaction = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TacticalSquadDeathTrigger();
      component.m_ArmyFactOnOwnerDeath = BlueprintTool.GetRef<BlueprintUnitFactReference>(armyFactOnOwnerDeath);
      component.m_ArmyFactOnOthersDeath = BlueprintTool.GetRef<BlueprintUnitFactReference>(armyFactOnOthersDeath);
      component.m_RemoveFactOnAnyDeath = removeFactOnAnyDeath;
      component.m_FactDestinationFaction = factDestinationFaction;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyDamageAfterMovementBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyDamageAfterMovementBonus))]
    public TBuilder AddArmyDamageAfterMovementBonus(
        float bonus = default,
        bool accumulateBonusPerCell = default,
        ActionsBuilder onDamageDeal = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArmyDamageAfterMovementBonus();
      component.m_Bonus = bonus;
      component.m_AccumulateBonusPerCell = accumulateBonusPerCell;
      component.OnDamageDeal = onDamageDeal?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyStandingDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyStandingDamageBonus))]
    public TBuilder AddArmyStandingDamageBonus(
        int bonus = default,
        ActionsBuilder onDamageDeal = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArmyStandingDamageBonus();
      component.m_Bonus = bonus;
      component.OnDamageDeal = onDamageDeal?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstAttackOfOpportunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstAttackOfOpportunity))]
    public TBuilder AddACBonusAgainstAttackOfOpportunity(
        bool notAttackOfOpportunity = default,
        ContextValue bonus = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new ACBonusAgainstAttackOfOpportunity();
      component.NotAttackOfOpportunity = notAttackOfOpportunity;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstAttacks"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstAttacks))]
    public TBuilder AddACBonusAgainstAttacks(
        bool againstMeleeOnly = default,
        bool againstRangedOnly = default,
        bool onlySneakAttack = default,
        bool notTouch = default,
        bool isTouch = default,
        bool onlyAttacksOfOpportunity = default,
        ContextValue value = null,
        int armorClassBonus = default,
        ModifierDescriptor descriptor = default,
        bool checkArmorCategory = default,
        ArmorProficiencyGroup[] notArmorCategory = null,
        bool noShield = default,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstBuffOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ACBonusAgainstBuffOwner))]
    public TBuilder AddACBonusAgainstBuffOwner(
        string checkedBuff = null,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        bool checkAlignment = default,
        AlignmentComponent alignment = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ACBonusAgainstBuffOwner();
      component.m_CheckedBuff = BlueprintTool.GetRef<BlueprintBuffReference>(checkedBuff);
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.CheckAlignment = checkAlignment;
      component.Alignment = alignment;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ACBonusAgainstFactOwner))]
    public TBuilder AddACBonusAgainstFactOwner(
        string checkedFact = null,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        AlignmentComponent alignment = default,
        bool noFact = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ACBonusAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.Alignment = alignment;
      component.NoFact = noFact;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstFactOwnerMultiple"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ACBonusAgainstFactOwnerMultiple))]
    public TBuilder AddACBonusAgainstFactOwnerMultiple(
        string[] facts = null,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        AlignmentComponent alignment = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ACBonusAgainstFactOwnerMultiple();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.Alignment = alignment;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstSize"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstSize))]
    public TBuilder AddACBonusAgainstSize(
        ModifierDescriptor descriptor = default,
        ContextValue value = null,
        Size size = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new ACBonusAgainstSize();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.Size = size;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstSpellsWithDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstSpellsWithDescriptor))]
    public TBuilder AddACBonusAgainstSpellsWithDescriptor(
        SpellDescriptorWrapper spellDescriptor,
        int armorClassBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ACBonusAgainstSpellsWithDescriptor();
      component.ArmorClassBonus = armorClassBonus;
      component.SpellDescriptor = spellDescriptor;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstWeaponCategory"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstWeaponCategory))]
    public TBuilder AddACBonusAgainstWeaponCategory(
        int armorClassBonus = default,
        WeaponCategory category = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ACBonusAgainstWeaponCategory();
      component.ArmorClassBonus = armorClassBonus;
      component.Category = category;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstWeaponGroup"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstWeaponGroup))]
    public TBuilder AddACBonusAgainstWeaponGroup(
        int armorClassBonus = default,
        WeaponFighterGroup fighterGroup = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ACBonusAgainstWeaponGroup();
      component.ArmorClassBonus = armorClassBonus;
      component.FighterGroup = fighterGroup;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstWeaponSubcategory"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstWeaponSubcategory))]
    public TBuilder AddACBonusAgainstWeaponSubcategory(
        int armorClassBonus = default,
        WeaponSubCategory subCategory = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ACBonusAgainstWeaponSubcategory();
      component.ArmorClassBonus = armorClassBonus;
      component.SubCategory = subCategory;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstWeaponType"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="type"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(ACBonusAgainstWeaponType))]
    public TBuilder AddACBonusAgainstWeaponType(
        int armorClassBonus = default,
        string type = null,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ACBonusAgainstWeaponType();
      component.ArmorClassBonus = armorClassBonus;
      component.m_Type = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(type);
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusUnlessFactMultiple"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ACBonusUnlessFactMultiple))]
    public TBuilder AddACBonusUnlessFactMultiple(
        string[] facts = null,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        AlignmentComponent alignment = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ACBonusUnlessFactMultiple();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.Alignment = alignment;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACContextBonusAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ACContextBonusAgainstFactOwner))]
    public TBuilder AddACContextBonusAgainstFactOwner(
        string checkedFact = null,
        ContextValue bonus = null,
        ModifierDescriptor descriptor = default,
        AlignmentComponent alignment = default,
        bool noFact = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new ACContextBonusAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      component.Alignment = alignment;
      component.NoFact = noFact;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACContextBonusAgainstWeaponSubcategory"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACContextBonusAgainstWeaponSubcategory))]
    public TBuilder AddACContextBonusAgainstWeaponSubcategory(
        ContextValue value = null,
        WeaponSubCategory subCategory = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new ACContextBonusAgainstWeaponSubcategory();
      component.Value = value ?? ContextValues.Constant(0);
      component.SubCategory = subCategory;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityMythicParams"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilites"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AbilityMythicParams))]
    public TBuilder AddAbilityMythicParams(
        string[] abilites = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AbilityMythicParams();
      component.m_Abilites = abilites.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityScoreCheckBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityScoreCheckBonus))]
    public TBuilder AddAbilityScoreCheckBonus(
        ModifierDescriptor descriptor = default,
        ContextValue bonus = null,
        StatType stat = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new AbilityScoreCheckBonus();
      component.Descriptor = descriptor;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.Stat = stat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ActionsOnBuffApply"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="gainedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ActionsOnBuffApply))]
    public TBuilder AddActionsOnBuffApply(
        string gainedFact = null,
        ActionsBuilder actions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ActionsOnBuffApply();
      component.m_GainedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(gainedFact);
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAbilityResources"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(AddAbilityResources))]
    public TBuilder AddAbilityResources(
        bool useThisAsResource = default,
        string resource = null,
        int amount = default,
        bool restoreAmount = default,
        bool restoreOnLevelUp = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddAbilityResources();
      component.UseThisAsResource = useThisAsResource;
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      component.Amount = amount;
      component.RestoreAmount = restoreAmount;
      component.RestoreOnLevelUp = restoreOnLevelUp;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBuffOnCombatStart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AddBuffOnCombatStart))]
    public TBuilder AddBuffOnCombatStart(
        bool checkParty = default,
        string feature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddBuffOnCombatStart();
      component.CheckParty = checkParty;
      component.m_Feature = BlueprintTool.GetRef<BlueprintBuffReference>(feature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCalculatedWeapon"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddCalculatedWeapon))]
    public TBuilder AddCalculatedWeapon(
        CalculatedWeapon weapon,
        bool scaleDamageByRank = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(weapon);
    
      var component = new AddCalculatedWeapon();
      component.Weapon = weapon;
      component.ScaleDamageByRank = scaleDamageByRank;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCasterLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddCasterLevel))]
    public TBuilder AddCasterLevel(
        int bonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddCasterLevel();
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCasterLevelForAbility"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spell"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddCasterLevelForAbility))]
    public TBuilder AddCasterLevelForAbility(
        string spell = null,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddCasterLevelForAbility();
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(spell);
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCasterLevelForSpellbook"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbooks"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(AddCasterLevelForSpellbook))]
    public TBuilder AddCasterLevelForSpellbook(
        int bonus = default,
        ModifierDescriptor descriptor = default,
        string[] spellbooks = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddCasterLevelForSpellbook();
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Spellbooks = spellbooks.Select(name => BlueprintTool.GetRef<BlueprintSpellbookReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddClassLevelToSummonDuration"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(AddClassLevelToSummonDuration))]
    public TBuilder AddClassLevelToSummonDuration(
        string characterClass = null,
        bool half = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddClassLevelToSummonDuration();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.Half = half;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFactIfArchetype"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="BlueprintUnitFact"/></param>
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="archetype"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(AddFactIfArchetype))]
    public TBuilder AddFactIfArchetype(
        string feature = null,
        string characterClass = null,
        string archetype = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFactIfArchetype();
      component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(feature);
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureIfHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    /// <param name="feature"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddFeatureIfHasFact))]
    public TBuilder AddFeatureIfHasFact(
        string checkedFact = null,
        string feature = null,
        bool not = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFeatureIfHasFact();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(feature);
      component.Not = not;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureOnAlignment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddFeatureOnAlignment))]
    public TBuilder AddFeatureOnAlignment(
        AlignmentComponent alignment = default,
        string[] facts = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFeatureOnAlignment();
      component.Alignment = alignment;
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureOnApply"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddFeatureOnApply))]
    public TBuilder AddFeatureOnApply(
        string feature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFeatureOnApply();
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureOnClassLevel"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="clazz"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="feature"><see cref="BlueprintFeature"/></param>
    /// <param name="additionalClasses"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="archetypes"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(AddFeatureOnClassLevel))]
    public TBuilder AddFeatureOnClassLevel(
        string clazz = null,
        int level = default,
        string feature = null,
        bool beforeThisLevel = default,
        string[] additionalClasses = null,
        string[] archetypes = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFeatureOnClassLevel();
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      component.Level = level;
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      component.BeforeThisLevel = beforeThisLevel;
      component.m_AdditionalClasses = additionalClasses.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray();
      component.m_Archetypes = archetypes.Select(name => BlueprintTool.GetRef<BlueprintArchetypeReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureOnSkill"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddFeatureOnSkill))]
    public TBuilder AddFeatureOnSkill(
        StatType statType = default,
        int minimalStat = default,
        string[] facts = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFeatureOnSkill();
      component.StatType = statType;
      component.MinimalStat = minimalStat;
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureToNPC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddFeatureToNPC))]
    public TBuilder AddFeatureToNPC(
        bool checkParty = default,
        string feature = null,
        bool checkSummoned = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFeatureToNPC();
      component.CheckParty = checkParty;
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      component.CheckSummoned = checkSummoned;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureToPet"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddFeatureToPet))]
    public TBuilder AddFeatureToPet(
        PetType petType = default,
        string feature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFeatureToPet();
      component.m_PetType = petType;
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellListAsAbilities"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resourcePerSpellLevel"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(AddSpellListAsAbilities))]
    public TBuilder AddSpellListAsAbilities(
        string[] resourcePerSpellLevel = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSpellListAsAbilities();
      component.m_ResourcePerSpellLevel = resourcePerSpellLevel.Select(name => BlueprintTool.GetRef<BlueprintAbilityResourceReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellbook"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbook"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(AddSpellbook))]
    public TBuilder AddSpellbook(
        string spellbook = null,
        ContextValue casterLevel = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(casterLevel);
    
      var component = new AddSpellbook();
      component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(spellbook);
      component.m_CasterLevel = casterLevel ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddWearinessHours"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddWearinessHours))]
    public TBuilder AddWearinessHours(
        int hours = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddWearinessHours();
      component.Hours = hours;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AdditionalDamageOnHit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weapon"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(AdditionalDamageOnHit))]
    public TBuilder AdditionalDamageOnHit(
        DiceFormula energyDamageDice,
        DamageEnergyType element = default,
        bool specificWeapon = default,
        string weapon = null,
        bool onlyNaturalAndUnarmed = default,
        bool onlyMelee = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AdditionalDamageOnHit();
      component.EnergyDamageDice = energyDamageDice;
      component.Element = element;
      component.SpecificWeapon = specificWeapon;
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weapon);
      component.OnlyNaturalAndUnarmed = onlyNaturalAndUnarmed;
      component.OnlyMelee = onlyMelee;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AdditionalSneakDamageOnHit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AdditionalSneakDamageOnHit))]
    public TBuilder AdditionalSneakDamageOnHit(
        DiceFormula physicalDamageDice,
        AdditionalSneakDamageOnHit.WeaponType weapon = default,
        bool onlyNoDexToAC = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AdditionalSneakDamageOnHit();
      component.m_Weapon = weapon;
      component.PhysicalDamageDice = physicalDamageDice;
      component.OnlyNoDexToAC = onlyNoDexToAC;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AllSpellsParamsOverride"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AllSpellsParamsOverride))]
    public TBuilder AddAllSpellsParamsOverride(
        ContextValue casterLevel = null,
        ContextValue dC = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(casterLevel);
      ValidateParam(dC);
    
      var component = new AllSpellsParamsOverride();
      component.CasterLevel = casterLevel ?? ContextValues.Constant(0);
      component.DC = dC ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AlliedSpellcaster"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="alliedSpellcasterFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AlliedSpellcaster))]
    public TBuilder AddAlliedSpellcaster(
        string alliedSpellcasterFact = null,
        int radius = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AlliedSpellcaster();
      component.m_AlliedSpellcasterFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(alliedSpellcasterFact);
      component.Radius = radius;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AngelSwordAdditionalDamageAndHeal"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="maximizeFact"><see cref="BlueprintUnitFact"/></param>
    /// <param name="cloakFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AngelSwordAdditionalDamageAndHeal))]
    public TBuilder AddAngelSwordAdditionalDamageAndHeal(
        string maximizeFact = null,
        string cloakFact = null,
        PrefabLink healingPrefab = null,
        PrefabLink damagePrefab = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(healingPrefab);
      ValidateParam(damagePrefab);
    
      var component = new AngelSwordAdditionalDamageAndHeal();
      component.m_MaximizeFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(maximizeFact);
      component.m_CloakFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(cloakFact);
      component.HealingPrefab = healingPrefab ?? Constants.Empty.PrefabLink;
      component.DamagePrefab = damagePrefab ?? Constants.Empty.PrefabLink;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AngelSwordAntiDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AngelSwordAntiDescriptor))]
    public TBuilder AddAngelSwordAntiDescriptor(
        SpellDescriptorWrapper checkedDescriptor,
        bool healStatDamageAndDrain = default,
        bool healEnergyDrain = default,
        EnergyDrainHealType temporaryNegativeLevelsHeal = default,
        EnergyDrainHealType permanentNegativeLevelsHeal = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AngelSwordAntiDescriptor();
      component.CheckedDescriptor = checkedDescriptor;
      component.HealStatDamageAndDrain = healStatDamageAndDrain;
      component.HealEnergyDrain = healEnergyDrain;
      component.TemporaryNegativeLevelsHeal = temporaryNegativeLevelsHeal;
      component.PermanentNegativeLevelsHeal = permanentNegativeLevelsHeal;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AnyWeaponDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AnyWeaponDamageStatReplacement))]
    public TBuilder AddAnyWeaponDamageStatReplacement(
        StatType stat = default,
        bool onlyMelee = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AnyWeaponDamageStatReplacement();
      component.Stat = stat;
      component.OnlyMelee = onlyMelee;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArcaneArmorProficiency"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArcaneArmorProficiency))]
    public TBuilder AddArcaneArmorProficiency(
        ArmorProficiencyGroup[] armor = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArcaneArmorProficiency();
      component.Armor = armor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArcaneBloodlineArcana"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArcaneBloodlineArcana))]
    public TBuilder AddArcaneBloodlineArcana(
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArcaneBloodlineArcana();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArcaneSpellFailureIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArcaneSpellFailureIncrease))]
    public TBuilder AddArcaneSpellFailureIncrease(
        int bonus = default,
        bool toShield = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArcaneSpellFailureIncrease();
      component.Bonus = bonus;
      component.ToShield = toShield;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmorCheckPenaltyIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmorCheckPenaltyIncrease))]
    public TBuilder AddArmorCheckPenaltyIncrease(
        ContextValue bonus = null,
        int bonesPerRank = default,
        bool checkCategory = default,
        ArmorProficiencyGroup category = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new ArmorCheckPenaltyIncrease();
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.BonesPerRank = bonesPerRank;
      component.CheckCategory = checkCategory;
      component.Category = category;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmorClassBonusAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmorClassBonusAgainstAlignment))]
    public TBuilder AddArmorClassBonusAgainstAlignment(
        AlignmentComponent alignment = default,
        ModifierDescriptor descriptor = default,
        int value = default,
        ContextValue bonus = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new ArmorClassBonusAgainstAlignment();
      component.alignment = alignment;
      component.Descriptor = descriptor;
      component.Value = value;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AscendantElement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AscendantElement))]
    public TBuilder AddAscendantElement(
        DamageEnergyType element = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AscendantElement();
      component.Element = element;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstAlignment))]
    public TBuilder AddAttackBonusAgainstAlignment(
        AlignmentComponent alignment = default,
        bool onlyMelee = default,
        int damageBonus = default,
        ContextValue bonus = null,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new AttackBonusAgainstAlignment();
      component.Alignment = alignment;
      component.OnlyMelee = onlyMelee;
      component.DamageBonus = damageBonus;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstArmyProperty"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstArmyProperty))]
    public TBuilder AddAttackBonusAgainstArmyProperty(
        ModifierDescriptor descriptor = default,
        ContextValue value = null,
        ArmyProperties armyProperties = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new AttackBonusAgainstArmyProperty();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.ArmyProperties = armyProperties;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AttackBonusAgainstFactOwner))]
    public TBuilder AddAttackBonusAgainstFactOwner(
        string checkedFact = null,
        int attackBonus = default,
        ContextValue bonus = null,
        ModifierDescriptor descriptor = default,
        bool not = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new AttackBonusAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.AttackBonus = attackBonus;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      component.Not = not;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstFriendly"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstFriendly))]
    public TBuilder AddAttackBonusAgainstFriendly(
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AttackBonusAgainstFriendly();
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstSize"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="targetFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AttackBonusAgainstSize))]
    public TBuilder AddAttackBonusAgainstSize(
        ModifierDescriptor descriptor = default,
        ContextValue value = null,
        Size size = default,
        bool onlyForRanged = default,
        bool onlyForMelee = default,
        bool sizeMoreThan = default,
        bool checkTargetFact = default,
        string targetFact = null,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusConditional"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusConditional))]
    public TBuilder AddAttackBonusConditional(
        bool checkWielder = default,
        ModifierDescriptor descriptor = default,
        ContextValue bonus = null,
        ConditionsBuilder conditions = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new AttackBonusConditional();
      component.CheckWielder = checkWielder;
      component.Descriptor = descriptor;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackDiceBonusOnce"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackDiceBonusOnce))]
    public TBuilder AddAttackDiceBonusOnce(
        int bonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AttackDiceBonusOnce();
      component.bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackOfOpportunityAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackOfOpportunityAttackBonus))]
    public TBuilder AddAttackOfOpportunityAttackBonus(
        bool notAttackOfOpportunity = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        ContextValue bonus = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new AttackOfOpportunityAttackBonus();
      component.NotAttackOfOpportunity = notAttackOfOpportunity;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackOfOpportunityAttackBonusAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AttackOfOpportunityAttackBonusAgainstFactOwner))]
    public TBuilder AddAttackOfOpportunityAttackBonusAgainstFactOwner(
        string checkedFact = null,
        ContextValue bonus = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new AttackOfOpportunityAttackBonusAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackOfOpportunityCriticalConfirmationBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackOfOpportunityCriticalConfirmationBonus))]
    public TBuilder AddAttackOfOpportunityCriticalConfirmationBonus(
        ContextValue bonus = null,
        bool checkWeaponRangeType = default,
        WeaponRangeType type = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new AttackOfOpportunityCriticalConfirmationBonus();
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.CheckWeaponRangeType = checkWeaponRangeType;
      component.Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackOfOpportunityDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackOfOpportunityDamageBonus))]
    public TBuilder AddAttackOfOpportunityDamageBonus(
        ContextValue damageBonus = null,
        bool checkWeaponRangeType = default,
        WeaponRangeType weaponType = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(damageBonus);
    
      var component = new AttackOfOpportunityDamageBonus();
      component.DamageBonus = damageBonus ?? ContextValues.Constant(0);
      component.CheckWeaponRangeType = checkWeaponRangeType;
      component.WeaponType = weaponType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackTypeAttackBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="requiredFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AttackTypeAttackBonus))]
    public TBuilder AddAttackTypeAttackBonus(
        WeaponRangeType type = default,
        bool allTypesExcept = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        ContextValue value = null,
        bool checkFact = default,
        string requiredFact = null,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackTypeChange"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackTypeChange))]
    public TBuilder AddAttackTypeChange(
        bool needsWeapon = default,
        bool changeAllTypes = default,
        AttackType originalType = default,
        AttackType newType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AttackTypeChange();
      component.NeedsWeapon = needsWeapon;
      component.ChangeAllTypes = changeAllTypes;
      component.OriginalType = originalType;
      component.NewType = newType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackTypeCriticalMultiplierIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackTypeCriticalMultiplierIncrease))]
    public TBuilder AddAttackTypeCriticalMultiplierIncrease(
        WeaponRangeType type = default,
        int additionalMultiplier = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AttackTypeCriticalMultiplierIncrease();
      component.Type = type;
      component.AdditionalMultiplier = additionalMultiplier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AuraFeatureComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AuraFeatureComponent))]
    public TBuilder AddAuraFeatureComponent(
        string buff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AuraFeatureComponent();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AutoConfirmCritAgainstFlanked"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AutoConfirmCritAgainstFlanked))]
    public TBuilder AddAutoConfirmCritAgainstFlanked(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AutoConfirmCritAgainstFlanked();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AutoDetectStealth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AutoDetectStealth))]
    public TBuilder AddAutoDetectStealth(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AutoDetectStealth();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AutoMetamagic"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilities"><see cref="BlueprintAbility"/></param>
    /// <param name="spellbook"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(AutoMetamagic))]
    public TBuilder AddAutoMetamagic(
        SpellDescriptorWrapper descriptor,
        AutoMetamagic.AllowedType allowedAbilities = default,
        Metamagic metamagic = default,
        string[] abilities = null,
        bool once = default,
        int maxSpellLevel = default,
        SpellSchool school = default,
        bool checkSpellbook = default,
        string spellbook = null,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BackToBack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="backToBackFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(BackToBack))]
    public TBuilder AddBackToBack(
        string backToBackFact = null,
        int radius = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BackToBack();
      component.m_BackToBackFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(backToBackFact);
      component.Radius = radius;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BackToBackBetter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="backToBackBetterFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(BackToBackBetter))]
    public TBuilder AddBackToBackBetter(
        string backToBackBetterFact = null,
        int radius = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BackToBackBetter();
      component.m_BackToBackBetterFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(backToBackBetterFact);
      component.Radius = radius;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BindAbilitiesToClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilites"><see cref="BlueprintAbility"/></param>
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="additionalClasses"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="archetypes"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(BindAbilitiesToClass))]
    public TBuilder AddBindAbilitiesToClass(
        string[] abilites = null,
        bool cantrip = default,
        string characterClass = null,
        StatType stat = default,
        string[] additionalClasses = null,
        string[] archetypes = null,
        int levelStep = default,
        bool odd = default,
        bool fullCasterChecks = default,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BindAbilitiesToHighest"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilities"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(BindAbilitiesToHighest))]
    public TBuilder AddBindAbilitiesToHighest(
        string[] abilities = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BindAbilitiesToHighest();
      component.m_Abilities = abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BlindnessACCompensation"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BlindnessACCompensation))]
    public TBuilder AddBlindnessACCompensation(
        BlueprintComponent.Flags flags = default)
    {
      var component = new BlindnessACCompensation();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Blindsense"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="exceptionFacts"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(Blindsense))]
    public TBuilder AddBlindsense(
        Feet range,
        bool blindsight = default,
        bool hasExceptions = default,
        string[] exceptionFacts = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new Blindsense();
      component.Range = range;
      component.Blindsight = blindsight;
      component.HasExceptions = hasExceptions;
      component.m_ExceptionFacts = exceptionFacts.Select(name => BlueprintTool.GetRef<BlueprintFeatureReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSubstitutionOnApply"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="gainedFact"><see cref="BlueprintBuff"/></param>
    /// <param name="substituteBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(BuffSubstitutionOnApply))]
    public TBuilder AddBuffSubstitutionOnApply(
        SpellDescriptorWrapper spellDescriptor,
        string gainedFact = null,
        string substituteBuff = null,
        bool checkDescriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffSubstitutionOnApply();
      component.m_GainedFact = BlueprintTool.GetRef<BlueprintBuffReference>(gainedFact);
      component.m_SubstituteBuff = BlueprintTool.GetRef<BlueprintBuffReference>(substituteBuff);
      component.CheckDescriptor = checkDescriptor;
      component.SpellDescriptor = spellDescriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CMBBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CMBBonus))]
    public TBuilder AddCMBBonus(
        ModifierDescriptor descriptor = default,
        ContextValue value = null,
        bool checkFact = default,
        string checkedFact = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new CMBBonus();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.CheckFact = checkFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CMBBonusAgainstSize"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CMBBonusAgainstSize))]
    public TBuilder AddCMBBonusAgainstSize(
        ModifierDescriptor descriptor = default,
        ContextValue value = null,
        Size size = default,
        bool checkFact = default,
        string checkedFact = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new CMBBonusAgainstSize();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.Size = size;
      component.CheckFact = checkFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CMBBonusForManeuver"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CMBBonusForManeuver))]
    public TBuilder AddCMBBonusForManeuver(
        ModifierDescriptor descriptor = default,
        ContextValue value = null,
        bool checkFact = default,
        string checkedFact = null,
        CombatManeuver[] maneuvers = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new CMBBonusForManeuver();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.CheckFact = checkFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.Maneuvers = maneuvers;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CMDBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CMDBonus))]
    public TBuilder AddCMDBonus(
        ModifierDescriptor descriptor = default,
        ContextValue value = null,
        bool checkFact = default,
        string checkedFact = null,
        bool onCaster = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new CMDBonus();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.CheckFact = checkFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.OnCaster = onCaster;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CMDBonusAgainstManeuvers"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CMDBonusAgainstManeuvers))]
    public TBuilder AddCMDBonusAgainstManeuvers(
        ModifierDescriptor descriptor = default,
        ContextValue value = null,
        CombatManeuver[] maneuvers = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new CMDBonusAgainstManeuvers();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.Maneuvers = maneuvers;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CMDBonusAgainstSize"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CMDBonusAgainstSize))]
    public TBuilder AddCMDBonusAgainstSize(
        ModifierDescriptor descriptor = default,
        ContextValue value = null,
        Size size = default,
        bool checkFact = default,
        string checkedFact = null,
        bool onCaster = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new CMDBonusAgainstSize();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.Size = size;
      component.CheckFact = checkFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.OnCaster = onCaster;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CannyDefense"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="chosenWeaponBlueprint"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(CannyDefense))]
    public TBuilder AddCannyDefense(
        string characterClass = null,
        bool requiresKensai = default,
        string chosenWeaponBlueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CannyDefense();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.RequiresKensai = requiresKensai;
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(chosenWeaponBlueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CavalierMountedMastery"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CavalierMountedMastery))]
    public TBuilder AddCavalierMountedMastery(
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CavalierMountedMastery();
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CavalierRetribution"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(CavalierRetribution))]
    public TBuilder AddCavalierRetribution(
        string buff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CavalierRetribution();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CavalierStandAgainstDarkness"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CavalierStandAgainstDarkness))]
    public TBuilder AddCavalierStandAgainstDarkness(
        string checkedFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CavalierStandAgainstDarkness();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CavalierStealGlory"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CavalierStealGlory))]
    public TBuilder AddCavalierStealGlory(
        BlueprintComponent.Flags flags = default)
    {
      var component = new CavalierStealGlory();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChargeAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChargeAttackBonus))]
    public TBuilder AddChargeAttackBonus(
        bool checkWielder = default,
        ModifierDescriptor descriptor = default,
        ContextValue bonus = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new ChargeAttackBonus();
      component.CheckWielder = checkWielder;
      component.Descriptor = descriptor;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChargeImprovedCritical"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChargeImprovedCritical))]
    public TBuilder AddChargeImprovedCritical(
        BlueprintComponent.Flags flags = default)
    {
      var component = new ChargeImprovedCritical();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ClassLevelsForPrerequisites"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="fakeClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="actualClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(ClassLevelsForPrerequisites))]
    public TBuilder AddClassLevelsForPrerequisites(
        string fakeClass = null,
        string actualClass = null,
        double modifier = default,
        int summand = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ClassLevelsForPrerequisites();
      component.m_FakeClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(fakeClass);
      component.m_ActualClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(actualClass);
      component.Modifier = modifier;
      component.Summand = summand;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CombatAgainstMeTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CombatAgainstMeTrigger))]
    public TBuilder AddCombatAgainstMeTrigger(
        ActionsBuilder combatStartActions = null,
        ActionsBuilder combatEndActions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CombatAgainstMeTrigger();
      component.CombatStartActions = combatStartActions?.Build() ?? Constants.Empty.Actions;
      component.CombatEndActions = combatEndActions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CombatStateTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CombatStateTrigger))]
    public TBuilder AddCombatStateTrigger(
        ActionsBuilder combatStartActions = null,
        ActionsBuilder combatEndActions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CombatStateTrigger();
      component.CombatStartActions = combatStartActions?.Build() ?? Constants.Empty.Actions;
      component.CombatEndActions = combatEndActions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CompanionBoon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="rankFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(CompanionBoon))]
    public TBuilder AddCompanionBoon(
        string rankFeature = null,
        int bonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CompanionBoon();
      component.m_RankFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(rankFeature);
      component.Bonus = bonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConcentrationBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="requiredFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ConcentrationBonus))]
    public TBuilder AddConcentrationBonus(
        ContextValue value = null,
        bool checkFact = default,
        string requiredFact = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new ConcentrationBonus();
      component.Value = value ?? ContextValues.Constant(0);
      component.CheckFact = checkFact;
      component.m_RequiredFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(requiredFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConcentrationBonusOnArmorType"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ConcentrationBonusOnArmorType))]
    public TBuilder AddConcentrationBonusOnArmorType(
        ContextValue value = null,
        ArmorProficiencyGroup armorCategory = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new ConcentrationBonusOnArmorType();
      component.Value = value ?? ContextValues.Constant(0);
      component.ArmorCategory = armorCategory;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConstructHealth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ConstructHealth))]
    public TBuilder AddConstructHealth(
        BlueprintComponent.Flags flags = default)
    {
      var component = new ConstructHealth();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextRendFeature"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextRendFeature))]
    public TBuilder AddContextRendFeature(
        DamageTypeDescription rendType,
        ContextDiceValue value = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
      ValidateParam(rendType);
    
      var component = new ContextRendFeature();
      component.Value = value ?? Constants.Empty.DiceValue;
      component.RendType = rendType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CoordinatedDefense"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="coordinatedDefenseFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CoordinatedDefense))]
    public TBuilder AddCoordinatedDefense(
        string coordinatedDefenseFact = null,
        int radius = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CoordinatedDefense();
      component.m_CoordinatedDefenseFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(coordinatedDefenseFact);
      component.Radius = radius;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CoordinatedManeuvers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="coordinatedManeuversFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CoordinatedManeuvers))]
    public TBuilder AddCoordinatedManeuvers(
        string coordinatedManeuversFact = null,
        int radius = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CoordinatedManeuvers();
      component.m_CoordinatedManeuversFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(coordinatedManeuversFact);
      component.Radius = radius;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CraftBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CraftBonus))]
    public TBuilder AddCraftBonus(
        UsableItemType bonusFor = default,
        ContextValue value = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new CraftBonus();
      component.m_BonusFor = bonusFor;
      component.m_Value = value ?? ContextValues.Constant(0);
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
    /// Adds <see cref="CriticalConfirmationACBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CriticalConfirmationACBonus))]
    public TBuilder AddCriticalConfirmationACBonus(
        ContextValue value = null,
        int bonus = default,
        bool onlyPositiveValue = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new CriticalConfirmationACBonus();
      component.Value = value ?? ContextValues.Constant(0);
      component.Bonus = bonus;
      component.OnlyPositiveValue = onlyPositiveValue;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CriticalConfirmationACBonusAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CriticalConfirmationACBonusAgainstFactOwner))]
    public TBuilder AddCriticalConfirmationACBonusAgainstFactOwner(
        string checkedFact = null,
        ContextValue value = null,
        int bonus = default,
        bool onlyPositiveValue = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new CriticalConfirmationACBonusAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.Value = value ?? ContextValues.Constant(0);
      component.Bonus = bonus;
      component.OnlyPositiveValue = onlyPositiveValue;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CriticalConfirmationACBonusInHeavyArmor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CriticalConfirmationACBonusInHeavyArmor))]
    public TBuilder AddCriticalConfirmationACBonusInHeavyArmor(
        int bonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CriticalConfirmationACBonusInHeavyArmor();
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CriticalConfirmationBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CriticalConfirmationBonus))]
    public TBuilder AddCriticalConfirmationBonus(
        ContextValue value = null,
        int bonus = default,
        bool onlyPositiveValue = default,
        bool checkWeaponRangeType = default,
        WeaponRangeType type = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new CriticalConfirmationBonus();
      component.Value = value ?? ContextValues.Constant(0);
      component.Bonus = bonus;
      component.OnlyPositiveValue = onlyPositiveValue;
      component.CheckWeaponRangeType = checkWeaponRangeType;
      component.Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DRWithPool"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(DRWithPool))]
    public TBuilder AddDRWithPool(
        int drPoolPerRank = default,
        int reduction = default,
        int maxPool = default,
        string buff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DRWithPool();
      component.m_drPoolPerRank = drPoolPerRank;
      component.m_reduction = reduction;
      component.m_maxPool = maxPool;
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageBonusAgainstAlignment))]
    public TBuilder AddDamageBonusAgainstAlignment(
        AlignmentComponent alignment = default,
        bool onlyMelee = default,
        int damageBonus = default,
        ContextValue bonus = null,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new DamageBonusAgainstAlignment();
      component.Alignment = alignment;
      component.OnlyMelee = onlyMelee;
      component.DamageBonus = damageBonus;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(DamageBonusAgainstFactOwner))]
    public TBuilder AddDamageBonusAgainstFactOwner(
        string checkedFact = null,
        int damageBonus = default,
        ContextValue bonus = null,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new DamageBonusAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.DamageBonus = damageBonus;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstSize"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(DamageBonusAgainstSize))]
    public TBuilder AddDamageBonusAgainstSize(
        ContextValue damageValue = null,
        Size size = default,
        bool biggerOrEqualSize = default,
        bool onlyForMelee = default,
        ModifierDescriptor descriptor = default,
        string checkedFact = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(damageValue);
    
      var component = new DamageBonusAgainstSize();
      component.DamageValue = damageValue ?? ContextValues.Constant(0);
      component.size = size;
      component.BiggerOrEqualSize = biggerOrEqualSize;
      component.OnlyForMelee = onlyForMelee;
      component.Descriptor = descriptor;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusOrderOfCockatrice"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(DamageBonusOrderOfCockatrice))]
    public TBuilder AddDamageBonusOrderOfCockatrice(
        string checkedFact = null,
        ContextValue bonus = null,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new DamageBonusOrderOfCockatrice();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageGrace"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageGrace))]
    public TBuilder AddDamageGrace(
        BlueprintComponent.Flags flags = default)
    {
      var component = new DamageGrace();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageReductionAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(DamageReductionAgainstFactOwner))]
    public TBuilder AddDamageReductionAgainstFactOwner(
        string checkedFact = null,
        int reduction = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DamageReductionAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.Reduction = reduction;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageReductionAgainstRangedWeapons"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="type"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(DamageReductionAgainstRangedWeapons))]
    public TBuilder AddDamageReductionAgainstRangedWeapons(
        string type = null,
        int reductionTrue = default,
        int reductionFalse = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DamageReductionAgainstRangedWeapons();
      component.m_Type = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(type);
      component.ReductionTrue = reductionTrue;
      component.ReductionFalse = reductionFalse;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageReductionAgainstSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(DamageReductionAgainstSpells))]
    public TBuilder AddDamageReductionAgainstSpells(
        string[] spells = null,
        int reduction = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DamageReductionAgainstSpells();
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.Reduction = reduction;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageReductionBelowZero"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageReductionBelowZero))]
    public TBuilder AddDamageReductionBelowZero(
        int reduction = default,
        bool epicBypass = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DamageReductionBelowZero();
      component.Reduction = reduction;
      component.EpicBypass = epicBypass;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeathOnLevelStacks"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DeathOnLevelStacks))]
    public TBuilder AddDeathOnLevelStacks(
        BlueprintComponent.Flags flags = default)
    {
      var component = new DeathOnLevelStacks();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DefaultSourceBone"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DefaultSourceBone))]
    public TBuilder AddDefaultSourceBone(
        BlueprintComponent.Flags flags = default)
    {
      var component = new DefaultSourceBone();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DefensiveCombatTraining"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DefensiveCombatTraining))]
    public TBuilder AddDefensiveCombatTraining(
        bool mythic = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DefensiveCombatTraining();
      component.Mythic = mythic;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DerivativeStatBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DerivativeStatBonus))]
    public TBuilder AddDerivativeStatBonus(
        StatType baseStat = default,
        StatType derivativeStat = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DerivativeStatBonus();
      component.BaseStat = baseStat;
      component.DerivativeStat = derivativeStat;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DetachBuffOnNearMiss"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DetachBuffOnNearMiss))]
    public TBuilder AddDetachBuffOnNearMiss(
        bool meleeOnly = default,
        bool rangedOnly = default,
        int hitAndArmorDifference = default,
        ActionsBuilder action = null,
        bool onAttacker = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DetachBuffOnNearMiss();
      component.MeleeOnly = meleeOnly;
      component.RangedOnly = rangedOnly;
      component.HitAndArmorDifference = hitAndArmorDifference;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.OnAttacker = onAttacker;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DiceDamageBonusOnSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(DiceDamageBonusOnSpell))]
    public TBuilder AddDiceDamageBonusOnSpell(
        string[] spells = null,
        bool useContextBonus = default,
        ContextValue value = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new DiceDamageBonusOnSpell();
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.UseContextBonus = useContextBonus;
      component.Value = value ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DisableIntelligence"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableIntelligence))]
    public TBuilder AddDisableIntelligence(
        BlueprintComponent.Flags flags = default)
    {
      var component = new DisableIntelligence();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DisableRegenerationOnCriticalHit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableRegenerationOnCriticalHit))]
    public TBuilder AddDisableRegenerationOnCriticalHit(
        BlueprintComponent.Flags flags = default)
    {
      var component = new DisableRegenerationOnCriticalHit();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DispelBonusOnDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DispelBonusOnDescriptor))]
    public TBuilder AddDispelBonusOnDescriptor(
        SpellDescriptorWrapper descriptor,
        int bonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DispelBonusOnDescriptor();
      component.Descriptor = descriptor;
      component.Bonus = bonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DispelCasterLevelCheckBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DispelCasterLevelCheckBonus))]
    public TBuilder AddDispelCasterLevelCheckBonus(
        ContextValue value = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new DispelCasterLevelCheckBonus();
      component.Value = value ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DistanceAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DistanceAttackBonus))]
    public TBuilder AddDistanceAttackBonus(
        Feet range,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DistanceAttackBonus();
      component.Range = range;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DistanceDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DistanceDamageBonus))]
    public TBuilder AddDistanceDamageBonus(
        Feet range,
        int damageBonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DistanceDamageBonus();
      component.Range = range;
      component.DamageBonus = damageBonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DoNotBenefitFromConcealment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DoNotBenefitFromConcealment))]
    public TBuilder AddDoNotBenefitFromConcealment(
        BlueprintComponent.Flags flags = default)
    {
      var component = new DoNotBenefitFromConcealment();
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
    /// Adds <see cref="DraconicBloodlineArcana"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DraconicBloodlineArcana))]
    public TBuilder AddDraconicBloodlineArcana(
        SpellDescriptorWrapper spellDescriptor,
        bool spellsOnly = default,
        bool useContextBonus = default,
        ContextValue value = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new DraconicBloodlineArcana();
      component.SpellDescriptor = spellDescriptor;
      component.SpellsOnly = spellsOnly;
      component.UseContextBonus = useContextBonus;
      component.Value = value ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DuelistPreciseStrike"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="duelist"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="cloakDuelistFact"><see cref="BlueprintBuff"/></param>
    /// <param name="cloakNonDuelistFact"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(DuelistPreciseStrike))]
    public TBuilder AddDuelistPreciseStrike(
        string duelist = null,
        string cloakDuelistFact = null,
        string cloakNonDuelistFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DuelistPreciseStrike();
      component.m_Duelist = BlueprintTool.GetRef<BlueprintCharacterClassReference>(duelist);
      component.m_CloakDuelistFact = BlueprintTool.GetRef<BlueprintBuffReference>(cloakDuelistFact);
      component.m_CloakNonDuelistFact = BlueprintTool.GetRef<BlueprintBuffReference>(cloakNonDuelistFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DungeonClassRestrictedBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(DungeonClassRestrictedBuff))]
    public TBuilder AddDungeonClassRestrictedBuff(
        string buff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DungeonClassRestrictedBuff();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EnduringSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="greater"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(EnduringSpells))]
    public TBuilder AddEnduringSpells(
        string greater = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EnduringSpells();
      component.m_Greater = BlueprintTool.GetRef<BlueprintUnitFactReference>(greater);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Evasion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Evasion))]
    public TBuilder AddEvasion(
        SavingThrowType savingThrow = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new Evasion();
      component.SavingThrow = savingThrow;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EvasionAgainstDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EvasionAgainstDescriptor))]
    public TBuilder AddEvasionAgainstDescriptor(
        SpellDescriptorWrapper spellDescriptor,
        SavingThrowType savingThrow = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EvasionAgainstDescriptor();
      component.SpellDescriptor = spellDescriptor;
      component.SavingThrow = savingThrow;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EvasionWithTowerShield"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EvasionWithTowerShield))]
    public TBuilder AddEvasionWithTowerShield(
        bool improved = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EvasionWithTowerShield();
      component.Improved = improved;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FactSinglify"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="oldFacts"><see cref="BlueprintUnitFact"/></param>
    /// <param name="newFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(FactSinglify))]
    public TBuilder AddFactSinglify(
        string[] oldFacts = null,
        string[] newFacts = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new FactSinglify();
      component.m_OldFacts = oldFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_NewFacts = newFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FactsChangeTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(FactsChangeTrigger))]
    public TBuilder AddFactsChangeTrigger(
        string[] checkedFacts = null,
        ActionsBuilder onFactGainedActions = null,
        ActionsBuilder onFactLostActions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new FactsChangeTrigger();
      component.m_CheckedFacts = checkedFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.OnFactGainedActions = onFactGainedActions?.Build() ?? Constants.Empty.Actions;
      component.OnFactLostActions = onFactLostActions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FlankedAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(FlankedAttackBonus))]
    public TBuilder AddFlankedAttackBonus(
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new FlankedAttackBonus();
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FlatFootedIgnore"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(FlatFootedIgnore))]
    public TBuilder AddFlatFootedIgnore(
        FlatFootedIgnoreType type = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new FlatFootedIgnore();
      component.Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FullSpeedInStealth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(FullSpeedInStealth))]
    public TBuilder AddFullSpeedInStealth(
        BlueprintComponent.Flags flags = default)
    {
      var component = new FullSpeedInStealth();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Hardy"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="steelSoul"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(Hardy))]
    public TBuilder AddHardy(
        string steelSoul = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new Hardy();
      component.m_SteelSoul = BlueprintTool.GetRef<BlueprintFeatureReference>(steelSoul);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreConcealment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreConcealment))]
    public TBuilder AddIgnoreConcealment(
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreConcealment();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreCritImmunity"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(IgnoreCritImmunity))]
    public TBuilder AddIgnoreCritImmunity(
        bool checkFact = default,
        string checkedFact = null,
        bool not = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreCritImmunity();
      component.CheckFact = checkFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.Not = not;
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

    /// <summary>
    /// Adds <see cref="IgnoreDamageReductionOnCriticalHit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreDamageReductionOnCriticalHit))]
    public TBuilder AddIgnoreDamageReductionOnCriticalHit(
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreDamageReductionOnCriticalHit();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreDamageReductionOnTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreDamageReductionOnTarget))]
    public TBuilder AddIgnoreDamageReductionOnTarget(
        bool checkTargetAlignment = default,
        AlignmentComponent alignment = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreDamageReductionOnTarget();
      component.CheckTargetAlignment = checkTargetAlignment;
      component.Alignment = alignment;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnorePartialConcealmentOnRangedAttacks"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnorePartialConcealmentOnRangedAttacks))]
    public TBuilder AddIgnorePartialConcealmentOnRangedAttacks(
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnorePartialConcealmentOnRangedAttacks();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreSpellResistanceForSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilityList"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(IgnoreSpellResistanceForSpells))]
    public TBuilder AddIgnoreSpellResistanceForSpells(
        string[] abilityList = null,
        bool allSpells = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreSpellResistanceForSpells();
      component.m_AbilityList = abilityList.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.AllSpells = allSpells;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ImpromptuSneakAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ImpromptuSneakAttack))]
    public TBuilder AddImpromptuSneakAttack(
        BlueprintComponent.Flags flags = default)
    {
      var component = new ImpromptuSneakAttack();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ImprovedEvasion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ImprovedEvasion))]
    public TBuilder AddImprovedEvasion(
        SavingThrowType savingThrow = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ImprovedEvasion();
      component.SavingThrow = savingThrow;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseAllSpellsDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseAllSpellsDC))]
    public TBuilder AddIncreaseAllSpellsDC(
        ContextValue value = null,
        ModifierDescriptor descriptor = default,
        bool spellsOnly = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new IncreaseAllSpellsDC();
      component.Value = value ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      component.SpellsOnly = spellsOnly;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseCasterLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseCasterLevel))]
    public TBuilder AddIncreaseCasterLevel(
        ContextValue value = null,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new IncreaseCasterLevel();
      component.Value = value ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseCastersSavingThrowTypeDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseCastersSavingThrowTypeDC))]
    public TBuilder AddIncreaseCastersSavingThrowTypeDC(
        SavingThrowType type = default,
        int bonusDC = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseCastersSavingThrowTypeDC();
      component.Type = type;
      component.BonusDC = bonusDC;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseFeatRankByGroup"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseFeatRankByGroup))]
    public TBuilder AddIncreaseFeatRankByGroup(
        FeatureGroup group = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseFeatRankByGroup();
      component.Group = group;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellContextDescriptorDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseSpellContextDescriptorDC))]
    public TBuilder AddIncreaseSpellContextDescriptorDC(
        SpellDescriptorWrapper descriptor,
        ContextValue value = null,
        ModifierDescriptor modifierDescriptor = default,
        bool spellsOnly = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new IncreaseSpellContextDescriptorDC();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.ModifierDescriptor = modifierDescriptor;
      component.SpellsOnly = spellsOnly;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellDC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spell"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(IncreaseSpellDC))]
    public TBuilder AddIncreaseSpellDC(
        string spell = null,
        bool halfMythicRank = default,
        bool useContextBonus = default,
        ContextValue value = null,
        int bonusDC = default,
        ModifierDescriptor descriptor = default,
        bool spellsOnly = default,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellDescriptorCasterLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseSpellDescriptorCasterLevel))]
    public TBuilder AddIncreaseSpellDescriptorCasterLevel(
        SpellDescriptorWrapper descriptor,
        int bonusCasterLevel = default,
        ModifierDescriptor modifierDescriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseSpellDescriptorCasterLevel();
      component.Descriptor = descriptor;
      component.BonusCasterLevel = bonusCasterLevel;
      component.ModifierDescriptor = modifierDescriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellDescriptorDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseSpellDescriptorDC))]
    public TBuilder AddIncreaseSpellDescriptorDC(
        SpellDescriptorWrapper descriptor,
        int bonusDC = default,
        ModifierDescriptor modifierDescriptor = default,
        bool spellsOnly = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseSpellDescriptorDC();
      component.Descriptor = descriptor;
      component.BonusDC = bonusDC;
      component.ModifierDescriptor = modifierDescriptor;
      component.SpellsOnly = spellsOnly;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellSchoolCasterLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseSpellSchoolCasterLevel))]
    public TBuilder AddIncreaseSpellSchoolCasterLevel(
        SpellSchool school = default,
        int bonusLevel = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseSpellSchoolCasterLevel();
      component.School = school;
      component.BonusLevel = bonusLevel;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellSchoolDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseSpellSchoolDC))]
    public TBuilder AddIncreaseSpellSchoolDC(
        SpellSchool school = default,
        int bonusDC = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseSpellSchoolDC();
      component.School = school;
      component.BonusDC = bonusDC;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellSchoolDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseSpellSchoolDamage))]
    public TBuilder AddIncreaseSpellSchoolDamage(
        SpellSchool school = default,
        ContextValue damageBonus = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(damageBonus);
    
      var component = new IncreaseSpellSchoolDamage();
      component.School = school;
      component.DamageBonus = damageBonus ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellSpellbookDC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbooks"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(IncreaseSpellSpellbookDC))]
    public TBuilder AddIncreaseSpellSpellbookDC(
        string[] spellbooks = null,
        int bonusDC = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseSpellSpellbookDC();
      component.m_Spellbooks = spellbooks.Select(name => BlueprintTool.GetRef<BlueprintSpellbookReference>(name)).ToArray();
      component.BonusDC = bonusDC;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="InitiatorCritAutoconfirm"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(InitiatorCritAutoconfirm))]
    public TBuilder AddInitiatorCritAutoconfirm(
        BlueprintComponent.Flags flags = default)
    {
      var component = new InitiatorCritAutoconfirm();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KensaiCriticalPerfection"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="magusBlueprint"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="chosenWeaponBlueprint"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(KensaiCriticalPerfection))]
    public TBuilder AddKensaiCriticalPerfection(
        string magusBlueprint = null,
        string chosenWeaponBlueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new KensaiCriticalPerfection();
      component.m_MagusBlueprint = BlueprintTool.GetRef<BlueprintCharacterClassReference>(magusBlueprint);
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(chosenWeaponBlueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KensaiIaijutsuFocus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="magusBlueprint"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="chosenWeaponBlueprint"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(KensaiIaijutsuFocus))]
    public TBuilder AddKensaiIaijutsuFocus(
        string magusBlueprint = null,
        string chosenWeaponBlueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new KensaiIaijutsuFocus();
      component.m_MagusBlueprint = BlueprintTool.GetRef<BlueprintCharacterClassReference>(magusBlueprint);
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(chosenWeaponBlueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KensaiPerfectStrike"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="magusBlueprint"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="chosenWeaponBlueprint"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(KensaiPerfectStrike))]
    public TBuilder AddKensaiPerfectStrike(
        string magusBlueprint = null,
        string chosenWeaponBlueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new KensaiPerfectStrike();
      component.m_MagusBlueprint = BlueprintTool.GetRef<BlueprintCharacterClassReference>(magusBlueprint);
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(chosenWeaponBlueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KensaiPowerfulCrit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="magusBlueprint"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="chosenWeaponBlueprint"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(KensaiPowerfulCrit))]
    public TBuilder AddKensaiPowerfulCrit(
        string magusBlueprint = null,
        string chosenWeaponBlueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new KensaiPowerfulCrit();
      component.m_MagusBlueprint = BlueprintTool.GetRef<BlueprintCharacterClassReference>(magusBlueprint);
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(chosenWeaponBlueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KensaiWeaponMastery"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="magusBlueprint"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="chosenWeaponBlueprint"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(KensaiWeaponMastery))]
    public TBuilder AddKensaiWeaponMastery(
        string magusBlueprint = null,
        string chosenWeaponBlueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new KensaiWeaponMastery();
      component.m_MagusBlueprint = BlueprintTool.GetRef<BlueprintCharacterClassReference>(magusBlueprint);
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(chosenWeaponBlueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MadDogPackTactics"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MadDogPackTactics))]
    public TBuilder AddMadDogPackTactics(
        BlueprintComponent.Flags flags = default)
    {
      var component = new MadDogPackTactics();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ManeuverBonus))]
    public TBuilder AddManeuverBonus(
        CombatManeuver type = default,
        bool mythic = default,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ManeuverBonus();
      component.Type = type;
      component.Mythic = mythic;
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverBonusFromStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ManeuverBonusFromStat))]
    public TBuilder AddManeuverBonusFromStat(
        CombatManeuver type = default,
        StatType stat = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ManeuverBonusFromStat();
      component.Type = type;
      component.Stat = stat;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverDefenceBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ManeuverDefenceBonus))]
    public TBuilder AddManeuverDefenceBonus(
        CombatManeuver type = default,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ManeuverDefenceBonus();
      component.Type = type;
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ManeuverImmunity))]
    public TBuilder AddManeuverImmunity(
        CombatManeuver type = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ManeuverImmunity();
      component.Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverIncreaseDuration"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ManeuverIncreaseDuration))]
    public TBuilder AddManeuverIncreaseDuration(
        CombatManeuver type = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ManeuverIncreaseDuration();
      component.Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverOnAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ManeuverOnAttack))]
    public TBuilder AddManeuverOnAttack(
        WeaponCategory category = default,
        CombatManeuver maneuver = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ManeuverOnAttack();
      component.Category = category;
      component.Maneuver = maneuver;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverProvokeAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ManeuverProvokeAttack))]
    public TBuilder AddManeuverProvokeAttack(
        CombatManeuver maneuverType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ManeuverProvokeAttack();
      component.ManeuverType = maneuverType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ManeuverTrigger))]
    public TBuilder AddManeuverTrigger(
        CombatManeuver maneuverType = default,
        bool onlySuccess = default,
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ManeuverTrigger();
      component.ManeuverType = maneuverType;
      component.OnlySuccess = onlySuccess;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MaxDexBonusIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MaxDexBonusIncrease))]
    public TBuilder AddMaxDexBonusIncrease(
        int bonus = default,
        int bonesPerRank = default,
        bool checkCategory = default,
        ArmorProficiencyGroup category = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MaxDexBonusIncrease();
      component.Bonus = bonus;
      component.BonesPerRank = bonesPerRank;
      component.CheckCategory = checkCategory;
      component.Category = category;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MeleeWeaponSizeChange"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MeleeWeaponSizeChange))]
    public TBuilder AddMeleeWeaponSizeChange(
        int sizeCategoryChange = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MeleeWeaponSizeChange();
      component.SizeCategoryChange = sizeCategoryChange;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ModifyD20"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="tandemTripFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ModifyD20))]
    public TBuilder AddModifyD20(
        SpellDescriptorWrapper spellDescriptor,
        RuleType rule = default,
        RuleDispelMagic.CheckType dispellMagicCheckType = default,
        bool replace = default,
        int rollsAmount = default,
        bool takeBest = default,
        int roll = default,
        bool addBonus = default,
        ContextValue bonus = null,
        ModifierDescriptor bonusDescriptor = default,
        bool withChance = default,
        ContextValue chance = null,
        bool rerollOnlyIfFailed = default,
        bool dispellOnRerollFinished = default,
        bool dispellOn20 = default,
        bool againstAlignment = default,
        AlignmentComponent alignment = default,
        bool targetAlignment = default,
        bool specificSkill = default,
        StatType[] skill = null,
        ModifyD20.InnerSavingThrowType savingThrowType = default,
        bool specificDescriptor = default,
        bool addSavingThrowBonus = default,
        ModifierDescriptor modifierDescriptor = default,
        ContextValue value = null,
        bool tandemTrip = default,
        string tandemTripFeature = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
      ValidateParam(chance);
      ValidateParam(value);
    
      var component = new ModifyD20();
      component.Rule = rule;
      component.DispellMagicCheckType = dispellMagicCheckType;
      component.Replace = replace;
      component.RollsAmount = rollsAmount;
      component.TakeBest = takeBest;
      component.Roll = roll;
      component.AddBonus = addBonus;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.BonusDescriptor = bonusDescriptor;
      component.WithChance = withChance;
      component.Chance = chance ?? ContextValues.Constant(0);
      component.RerollOnlyIfFailed = rerollOnlyIfFailed;
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MonkReplaceAbilityDC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="BlueprintAbility"/></param>
    /// <param name="scaledFist"><see cref="BlueprintArchetype"/></param>
    /// <param name="monk"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(MonkReplaceAbilityDC))]
    public TBuilder AddMonkReplaceAbilityDC(
        string ability = null,
        string scaledFist = null,
        string monk = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MonkReplaceAbilityDC();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.m_ScaledFist = BlueprintTool.GetRef<BlueprintArchetypeReference>(scaledFist);
      component.m_Monk = BlueprintTool.GetRef<BlueprintCharacterClassReference>(monk);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MythicUnarmedStrike"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MythicUnarmedStrike))]
    public TBuilder AddMythicUnarmedStrike(
        BlueprintComponent.Flags flags = default)
    {
      var component = new MythicUnarmedStrike();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NewRoundTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NewRoundTrigger))]
    public TBuilder AddNewRoundTrigger(
        ActionsBuilder newRoundActions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new NewRoundTrigger();
      component.NewRoundActions = newRoundActions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OnSpawnBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ifHaveFact"><see cref="BlueprintFeature"/></param>
    /// <param name="ifSummonHaveFact"><see cref="BlueprintFeature"/></param>
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(OnSpawnBuff))]
    public TBuilder AddOnSpawnBuff(
        SpellDescriptorWrapper spellDescriptor,
        Rounds duration,
        string ifHaveFact = null,
        bool checkSummonedUnitFact = default,
        string ifSummonHaveFact = null,
        bool checkSummonedUnitAlignment = default,
        AlignmentComponent summonedAlignment = default,
        string buff = null,
        bool checkDescriptor = default,
        bool isInfinity = default,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Opportunist"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Opportunist))]
    public TBuilder AddOpportunist(
        BlueprintComponent.Flags flags = default)
    {
      var component = new Opportunist();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OutflankAttackBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="outflankFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(OutflankAttackBonus))]
    public TBuilder AddOutflankAttackBonus(
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        string outflankFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new OutflankAttackBonus();
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.m_OutflankFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(outflankFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OutflankDamageBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="outflankFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(OutflankDamageBonus))]
    public TBuilder AddOutflankDamageBonus(
        int damageBonus = default,
        int increasedDamageBonus = default,
        string outflankFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new OutflankDamageBonus();
      component.DamageBonus = damageBonus;
      component.IncreasedDamageBonus = increasedDamageBonus;
      component.m_OutflankFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(outflankFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OutflankProvokeAttack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="outflankFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(OutflankProvokeAttack))]
    public TBuilder AddOutflankProvokeAttack(
        string outflankFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new OutflankProvokeAttack();
      component.m_OutflankFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(outflankFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PartialDRIgnore"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PartialDRIgnore))]
    public TBuilder AddPartialDRIgnore(
        int reductionReduction = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new PartialDRIgnore();
      component.ReductionReduction = reductionReduction;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PenetratingStrike"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PenetratingStrike))]
    public TBuilder AddPenetratingStrike(
        int reductionReduction = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new PenetratingStrike();
      component.ReductionReduction = reductionReduction;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PetManeuverProvokeAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PetManeuverProvokeAttack))]
    public TBuilder AddPetManeuverProvokeAttack(
        CombatManeuver[] maneuver = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new PetManeuverProvokeAttack();
      component.Maneuver = maneuver;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PointBlankMaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PointBlankMaster))]
    public TBuilder AddPointBlankMaster(
        WeaponCategory category = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new PointBlankMaster();
      component.Category = category;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PointBlankMasterParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PointBlankMasterParametrized))]
    public TBuilder AddPointBlankMasterParametrized(
        BlueprintComponent.Flags flags = default)
    {
      var component = new PointBlankMasterParametrized();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PowerAttackWatcher"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="powerAttackBlueprint"><see cref="BlueprintActivatableAbility"/></param>
    [Generated]
    [Implements(typeof(PowerAttackWatcher))]
    public TBuilder AddPowerAttackWatcher(
        string powerAttackBlueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new PowerAttackWatcher();
      component.m_PowerAttackBlueprint = BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(powerAttackBlueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PreciseShot"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PreciseShot))]
    public TBuilder AddPreciseShot(
        BlueprintComponent.Flags flags = default)
    {
      var component = new PreciseShot();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PreciseShotDivineHunterTarget"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(PreciseShotDivineHunterTarget))]
    public TBuilder AddPreciseShotDivineHunterTarget(
        string buff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new PreciseShotDivineHunterTarget();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PreciseStrike"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="preciseStrikeFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(PreciseStrike))]
    public TBuilder AddPreciseStrike(
        DamageDescription damage,
        string preciseStrikeFact = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(damage);
    
      var component = new PreciseStrike();
      component.Damage = damage;
      component.m_PreciseStrikeFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(preciseStrikeFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RangedWeaponSizeChange"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponTypes"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(RangedWeaponSizeChange))]
    public TBuilder AddRangedWeaponSizeChange(
        int sizeCategoryChange = default,
        string[] weaponTypes = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RangedWeaponSizeChange();
      component.SizeCategoryChange = sizeCategoryChange;
      component.WeaponTypes = weaponTypes.Select(name => BlueprintTool.GetRef<BlueprintWeaponTypeReference>(name)).ToList();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecalculateConcealment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecalculateConcealment))]
    public TBuilder AddRecalculateConcealment(
        bool ignorePartial = default,
        bool treatTotalAsPartial = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RecalculateConcealment();
      component.IgnorePartial = ignorePartial;
      component.TreatTotalAsPartial = treatTotalAsPartial;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecalculateOnFactsChange"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(RecalculateOnFactsChange))]
    public TBuilder AddRecalculateOnFactsChange(
        string[] checkedFacts = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RecalculateOnFactsChange();
      component.m_CheckedFacts = checkedFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecalculateOnLocustSwarmChange"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecalculateOnLocustSwarmChange))]
    public TBuilder AddRecalculateOnLocustSwarmChange(
        BlueprintComponent.Flags flags = default)
    {
      var component = new RecalculateOnLocustSwarmChange();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecalculateOnStatChange"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecalculateOnStatChange))]
    public TBuilder AddRecalculateOnStatChange(
        bool useKineticistMainStat = default,
        StatType stat = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RecalculateOnStatChange();
      component.UseKineticistMainStat = useKineticistMainStat;
      component.Stat = stat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendedClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="favoriteClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(RecommendedClass))]
    public TBuilder AddRecommendedClass(
        string favoriteClass = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RecommendedClass();
      component.m_FavoriteClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(favoriteClass);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemoveAfterCast"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilities"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(RemoveAfterCast))]
    public TBuilder AddRemoveAfterCast(
        string[] abilities = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RemoveAfterCast();
      component.Abilities = abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToList();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffOnAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveBuffOnAttack))]
    public TBuilder AddRemoveBuffOnAttack(
        BlueprintComponent.Flags flags = default)
    {
      var component = new RemoveBuffOnAttack();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemoveFeatureOnApply"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(RemoveFeatureOnApply))]
    public TBuilder AddRemoveFeatureOnApply(
        string feature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RemoveFeatureOnApply();
      component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(feature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RendFeature"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RendFeature))]
    public TBuilder AddRendFeature(
        DiceFormula rendDamage,
        DamageTypeDescription rendType,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(rendType);
    
      var component = new RendFeature();
      component.RendDamage = rendDamage;
      component.RendType = rendType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceAbilitiesStat"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(ReplaceAbilitiesStat))]
    public TBuilder AddReplaceAbilitiesStat(
        string[] ability = null,
        StatType stat = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceAbilitiesStat();
      component.m_Ability = ability.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.Stat = stat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceAbilityDC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(ReplaceAbilityDC))]
    public TBuilder AddReplaceAbilityDC(
        string ability = null,
        StatType stat = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceAbilityDC();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.Stat = stat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceAbilityParamsWithContext"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(ReplaceAbilityParamsWithContext))]
    public TBuilder AddReplaceAbilityParamsWithContext(
        string ability = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceAbilityParamsWithContext();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceCMDDexterityStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReplaceCMDDexterityStat))]
    public TBuilder AddReplaceCMDDexterityStat(
        StatType newStat = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceCMDDexterityStat();
      component.NewStat = newStat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceCastSource"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReplaceCastSource))]
    public TBuilder AddReplaceCastSource(
        CastSource castSource = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceCastSource();
      component.CastSource = castSource;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceCasterLevelOfAbility"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spell"><see cref="BlueprintAbility"/></param>
    /// <param name="clazz"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="additionalClasses"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="archetypes"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(ReplaceCasterLevelOfAbility))]
    public TBuilder AddReplaceCasterLevelOfAbility(
        string spell = null,
        string clazz = null,
        string[] additionalClasses = null,
        string[] archetypes = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceCasterLevelOfAbility();
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(spell);
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      component.m_AdditionalClasses = additionalClasses.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray();
      component.m_Archetypes = archetypes.Select(name => BlueprintTool.GetRef<BlueprintArchetypeReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceCasterLevelOfFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="BlueprintFeature"/></param>
    /// <param name="clazz"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(ReplaceCasterLevelOfFeature))]
    public TBuilder AddReplaceCasterLevelOfFeature(
        string feature = null,
        string clazz = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceCasterLevelOfFeature();
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceCombatManeuverStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReplaceCombatManeuverStat))]
    public TBuilder AddReplaceCombatManeuverStat(
        StatType statType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceCombatManeuverStat();
      component.StatType = statType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceSingleCombatManeuverStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReplaceSingleCombatManeuverStat))]
    public TBuilder AddReplaceSingleCombatManeuverStat(
        CombatManeuver type = default,
        StatType statType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceSingleCombatManeuverStat();
      component.Type = type;
      component.StatType = statType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceSourceBone"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReplaceSourceBone))]
    public TBuilder AddReplaceSourceBone(
        string sourceBone,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceSourceBone();
      component.SourceBone = sourceBone;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceStatForPrerequisites"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(ReplaceStatForPrerequisites))]
    public TBuilder AddReplaceStatForPrerequisites(
        StatType oldStat = default,
        ReplaceStatForPrerequisites.StatReplacementPolicy policy = default,
        StatType newStat = default,
        string characterClass = null,
        int specificNumber = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceStatForPrerequisites();
      component.OldStat = oldStat;
      component.Policy = policy;
      component.NewStat = newStat;
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.SpecificNumber = specificNumber;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RerollConcealment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RerollConcealment))]
    public TBuilder AddRerollConcealment(
        BlueprintComponent.Flags flags = default)
    {
      var component = new RerollConcealment();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RideAnimalCompanion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RideAnimalCompanion))]
    public TBuilder AddRideAnimalCompanion(
        BlueprintComponent.Flags flags = default)
    {
      var component = new RideAnimalCompanion();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SaturationAuraComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SaturationAuraComponent))]
    public TBuilder AddSaturationAuraComponent(
        SaturationAuraType saturationAuraType = default,
        float radius = default,
        float distanceToCamera = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SaturationAuraComponent();
      component.m_SaturationAuraType = saturationAuraType;
      component.m_Radius = radius;
      component.m_DistanceToCamera = distanceToCamera;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavesFixedRecalculateThievery"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavesFixedRecalculateThievery))]
    public TBuilder AddSavesFixedRecalculateThievery(
        BlueprintComponent.Flags flags = default)
    {
      var component = new SavesFixedRecalculateThievery();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavesFixerFactReplacer"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="oldFacts"><see cref="BlueprintUnitFact"/></param>
    /// <param name="newFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SavesFixerFactReplacer))]
    public TBuilder AddSavesFixerFactReplacer(
        string[] oldFacts = null,
        string[] newFacts = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SavesFixerFactReplacer();
      component.m_OldFacts = oldFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_NewFacts = newFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavesFixerReplaceInProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="oldFeature"><see cref="BlueprintFeature"/></param>
    /// <param name="newFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(SavesFixerReplaceInProgression))]
    public TBuilder AddSavesFixerReplaceInProgression(
        string oldFeature = null,
        string newFeature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SavesFixerReplaceInProgression();
      component.m_OldFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(oldFeature);
      component.m_NewFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(newFeature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingSlash"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavingSlash))]
    public TBuilder AddSavingSlash(
        bool useContextValue = default,
        int bonus = default,
        ContextValue value = null,
        WeaponCategory weapon = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new SavingSlash();
      component.UseContextValue = useContextValue;
      component.Bonus = bonus;
      component.Value = value ?? ContextValues.Constant(0);
      component.Weapon = weapon;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstAbilityType"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstAbilityType))]
    public TBuilder AddSavingThrowBonusAgainstAbilityType(
        AbilityType abilityType = default,
        ModifierDescriptor modifierDescriptor = default,
        int value = default,
        ContextValue bonus = null,
        bool onlyPositiveValue = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new SavingThrowBonusAgainstAbilityType();
      component.AbilityType = abilityType;
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.OnlyPositiveValue = onlyPositiveValue;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstAlignment))]
    public TBuilder AddSavingThrowBonusAgainstAlignment(
        AlignmentComponent alignment = default,
        ModifierDescriptor descriptor = default,
        int value = default,
        ContextValue bonus = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new SavingThrowBonusAgainstAlignment();
      component.Alignment = alignment;
      component.Descriptor = descriptor;
      component.Value = value;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstAlignmentDifference"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstAlignmentDifference))]
    public TBuilder AddSavingThrowBonusAgainstAlignmentDifference(
        ModifierDescriptor descriptor = default,
        int value = default,
        int alignmentDifference = default,
        SavingThrowType savingThrow = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SavingThrowBonusAgainstAlignmentDifference();
      component.Descriptor = descriptor;
      component.Value = value;
      component.AlignmentDifference = alignmentDifference;
      component.SavingThrow = savingThrow;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstAllies"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="disablingFeature"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstAllies))]
    public TBuilder AddSavingThrowBonusAgainstAllies(
        ModifierDescriptor modifierDescriptor = default,
        int value = default,
        ContextValue bonus = null,
        bool onlyPositiveValue = default,
        string disablingFeature = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new SavingThrowBonusAgainstAllies();
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.OnlyPositiveValue = onlyPositiveValue;
      component.m_DisablingFeature = BlueprintTool.GetRef<BlueprintUnitFactReference>(disablingFeature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstDescriptor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="disablingFeature"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstDescriptor))]
    public TBuilder AddSavingThrowBonusAgainstDescriptor(
        SpellDescriptorWrapper spellDescriptor,
        ModifierDescriptor modifierDescriptor = default,
        int value = default,
        ContextValue bonus = null,
        bool onlyPositiveValue = default,
        string disablingFeature = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new SavingThrowBonusAgainstDescriptor();
      component.SpellDescriptor = spellDescriptor;
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.OnlyPositiveValue = onlyPositiveValue;
      component.m_DisablingFeature = BlueprintTool.GetRef<BlueprintUnitFactReference>(disablingFeature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstFact))]
    public TBuilder AddSavingThrowBonusAgainstFact(
        string checkedFact = null,
        ModifierDescriptor descriptor = default,
        int value = default,
        AlignmentComponent alignment = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SavingThrowBonusAgainstFact();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintFeatureReference>(checkedFact);
      component.Descriptor = descriptor;
      component.Value = value;
      component.Alignment = alignment;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstFactMultiple"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstFactMultiple))]
    public TBuilder AddSavingThrowBonusAgainstFactMultiple(
        string[] facts = null,
        ModifierDescriptor descriptor = default,
        int value = default,
        AlignmentComponent alignment = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SavingThrowBonusAgainstFactMultiple();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.Descriptor = descriptor;
      component.Value = value;
      component.Alignment = alignment;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstSchool"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstSchool))]
    public TBuilder AddSavingThrowBonusAgainstSchool(
        SpellSchool school = default,
        ModifierDescriptor modifierDescriptor = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SavingThrowBonusAgainstSchool();
      component.School = school;
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstSchoolAbilityValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstSchoolAbilityValue))]
    public TBuilder AddSavingThrowBonusAgainstSchoolAbilityValue(
        SpellSchool school = default,
        ModifierDescriptor modifierDescriptor = default,
        int value = default,
        ContextValue bonus = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new SavingThrowBonusAgainstSchoolAbilityValue();
      component.School = school;
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstSpecificSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="BlueprintAbility"/></param>
    /// <param name="bypassFeatures"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstSpecificSpells))]
    public TBuilder AddSavingThrowBonusAgainstSpecificSpells(
        string[] spells = null,
        ModifierDescriptor modifierDescriptor = default,
        int value = default,
        string[] bypassFeatures = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SavingThrowBonusAgainstSpecificSpells();
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value;
      component.m_BypassFeatures = bypassFeatures.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstSpellType"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstSpellType))]
    public TBuilder AddSavingThrowBonusAgainstSpellType(
        bool againstArcaneSpells = default,
        ModifierDescriptor modifierDescriptor = default,
        int value = default,
        ContextValue bonus = null,
        bool onlyPositiveValue = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new SavingThrowBonusAgainstSpellType();
      component.AgainstArcaneSpells = againstArcaneSpells;
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.OnlyPositiveValue = onlyPositiveValue;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusUnlessFactMultiple"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SavingThrowBonusUnlessFactMultiple))]
    public TBuilder AddSavingThrowBonusUnlessFactMultiple(
        string[] facts = null,
        ModifierDescriptor descriptor = default,
        AlignmentComponent alignment = default,
        SavingThrowType type = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SavingThrowBonusUnlessFactMultiple();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.Descriptor = descriptor;
      component.Alignment = alignment;
      component.Type = type;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowContextBonusAgainstDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavingThrowContextBonusAgainstDescriptor))]
    public TBuilder AddSavingThrowContextBonusAgainstDescriptor(
        SpellDescriptorWrapper spellDescriptor,
        ModifierDescriptor modifierDescriptor = default,
        ContextValue value = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new SavingThrowContextBonusAgainstDescriptor();
      component.SpellDescriptor = spellDescriptor;
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShakeItOff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="shakeItOffFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ShakeItOff))]
    public TBuilder AddShakeItOff(
        string shakeItOffFact = null,
        int radius = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ShakeItOff();
      component.m_ShakeItOffFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(shakeItOffFact);
      component.Radius = radius;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShareBuffsWithPet"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buffs"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ShareBuffsWithPet))]
    public TBuilder AddShareBuffsWithPet(
        PetType type = default,
        string[] buffs = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ShareBuffsWithPet();
      component.Type = type;
      component.m_Buffs = buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShareFavoredEnemies"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ShareFavoredEnemies))]
    public TBuilder AddShareFavoredEnemies(
        bool half = default,
        bool toPet = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ShareFavoredEnemies();
      component.Half = half;
      component.ToPet = toPet;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShareFeaturesWithPet"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="features"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ShareFeaturesWithPet))]
    public TBuilder AddShareFeaturesWithPet(
        PetType type = default,
        string[] features = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ShareFeaturesWithPet();
      component.Type = type;
      component.m_Features = features.Select(name => BlueprintTool.GetRef<BlueprintFeatureReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShatterConfidence"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="confoundingDuelistFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ShatterConfidence))]
    public TBuilder AddShatterConfidence(
        string confoundingDuelistFeature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ShatterConfidence();
      component.m_ConfoundingDuelistFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(confoundingDuelistFeature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShieldWall"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="shieldWallFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ShieldWall))]
    public TBuilder AddShieldWall(
        string shieldWallFact = null,
        int radius = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ShieldWall();
      component.m_ShieldWallFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(shieldWallFact);
      component.Radius = radius;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShieldedCaster"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="shieldedCasterFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ShieldedCaster))]
    public TBuilder AddShieldedCaster(
        string shieldedCasterFact = null,
        int radius = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ShieldedCaster();
      component.m_ShieldedCasterFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(shieldedCasterFact);
      component.Radius = radius;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SiezeTheMoment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="siezeTheMomentFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SiezeTheMoment))]
    public TBuilder AddSiezeTheMoment(
        string siezeTheMomentFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SiezeTheMoment();
      component.m_SiezeTheMomentFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(siezeTheMomentFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellFixedCL"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(SpellFixedCL))]
    public TBuilder AddSpellFixedCL(
        string ability = null,
        int cL = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpellFixedCL();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.CL = cL;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellFixedDC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(SpellFixedDC))]
    public TBuilder AddSpellFixedDC(
        string ability = null,
        int dC = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpellFixedDC();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.DC = dC;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellLevelByClassLevel"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="BlueprintAbility"/></param>
    /// <param name="clazz"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(SpellLevelByClassLevel))]
    public TBuilder AddSpellLevelByClassLevel(
        string ability = null,
        string clazz = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpellLevelByClassLevel();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellLevelByRank"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(SpellLevelByRank))]
    public TBuilder AddSpellLevelByRank(
        string ability = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpellLevelByRank();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellPenetrationBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="requiredFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SpellPenetrationBonus))]
    public TBuilder AddSpellPenetrationBonus(
        ContextValue value = null,
        ModifierDescriptor descriptor = default,
        bool checkFact = default,
        string requiredFact = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new SpellPenetrationBonus();
      component.Value = value ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      component.CheckFact = checkFact;
      component.m_RequiredFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(requiredFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellPenetrationMythicBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="greater"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SpellPenetrationMythicBonus))]
    public TBuilder AddSpellPenetrationMythicBonus(
        string greater = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpellPenetrationMythicBonus();
      component.m_Greater = BlueprintTool.GetRef<BlueprintUnitFactReference>(greater);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpendChargesOnSpellCast"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spell"><see cref="BlueprintAbility"/></param>
    /// <param name="spendSpellCharges"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(SpendChargesOnSpellCast))]
    public TBuilder AddSpendChargesOnSpellCast(
        string spell = null,
        string spendSpellCharges = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpendChargesOnSpellCast();
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(spell);
      component.m_SpendSpellCharges = BlueprintTool.GetRef<BlueprintAbilityReference>(spendSpellCharges);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SurpriseSpells"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SurpriseSpells))]
    public TBuilder AddSurpriseSpells(
        BlueprintComponent.Flags flags = default)
    {
      var component = new SurpriseSpells();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Take10ForSuccess"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Take10ForSuccess))]
    public TBuilder AddTake10ForSuccess(
        StatType skill = default,
        bool anyType = default,
        UsableItemType magicDeviceType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new Take10ForSuccess();
      component.Skill = skill;
      component.AnyType = anyType;
      component.MagicDeviceType = magicDeviceType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TargetChangedDuringRound"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TargetChangedDuringRound))]
    public TBuilder AddTargetChangedDuringRound(
        ActionsBuilder actions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TargetChangedDuringRound();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TargetCritAutoconfirm"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TargetCritAutoconfirm))]
    public TBuilder AddTargetCritAutoconfirm(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TargetCritAutoconfirm();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TargetCritAutoconfirmFromCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TargetCritAutoconfirmFromCaster))]
    public TBuilder AddTargetCritAutoconfirmFromCaster(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TargetCritAutoconfirmFromCaster();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TellingBlow"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    /// <param name="immunityFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(TellingBlow))]
    public TBuilder AddTellingBlow(
        int reductionReduction = default,
        string buff = null,
        string immunityFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TellingBlow();
      component.ReductionReduction = reductionReduction;
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.m_ImmunityFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(immunityFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ToughnessLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ToughnessLogic))]
    public TBuilder AddToughnessLogic(
        bool checkMythicLevel = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ToughnessLogic();
      component.CheckMythicLevel = checkMythicLevel;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TransferDescriptorBonusToSavingThrow"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TransferDescriptorBonusToSavingThrow))]
    public TBuilder AddTransferDescriptorBonusToSavingThrow(
        ModifierDescriptor descriptor = default,
        int maxBonus = default,
        bool checkArmorCategory = default,
        ArmorProficiencyGroup category = default,
        SavingThrowType type = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TransferDescriptorBonusToSavingThrow();
      component.Descriptor = descriptor;
      component.MaxBonus = maxBonus;
      component.CheckArmorCategory = checkArmorCategory;
      component.Category = category;
      component.Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TransferDescriptorBonusToTouchAC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TransferDescriptorBonusToTouchAC))]
    public TBuilder AddTransferDescriptorBonusToTouchAC(
        ModifierDescriptor descriptor = default,
        int maxBonus = default,
        bool checkArmorCategory = default,
        ArmorProficiencyGroup category = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TransferDescriptorBonusToTouchAC();
      component.Descriptor = descriptor;
      component.MaxBonus = maxBonus;
      component.CheckArmorCategory = checkArmorCategory;
      component.Category = category;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TrapPerceptionBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TrapPerceptionBonus))]
    public TBuilder AddTrapPerceptionBonus(
        ModifierDescriptor descriptor = default,
        ContextValue value = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new TrapPerceptionBonus();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TricksterArcanaAdditionalEnchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="commonEnchantments"><see cref="BlueprintItemEnchantment"/></param>
    /// <param name="weaponEnchantments"><see cref="BlueprintWeaponEnchantment"/></param>
    /// <param name="armorEnchantments"><see cref="BlueprintArmorEnchantment"/></param>
    [Generated]
    [Implements(typeof(TricksterArcanaAdditionalEnchantments))]
    public TBuilder AddTricksterArcanaAdditionalEnchantments(
        string[] commonEnchantments = null,
        string[] weaponEnchantments = null,
        string[] armorEnchantments = null,
        bool onlyWeaponsShieldsAndArmor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TricksterArcanaAdditionalEnchantments();
      component.CommonEnchantments = commonEnchantments.Select(name => BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(name)).ToArray();
      component.WeaponEnchantments = weaponEnchantments.Select(name => BlueprintTool.GetRef<BlueprintWeaponEnchantmentReference>(name)).ToArray();
      component.ArmorEnchantments = armorEnchantments.Select(name => BlueprintTool.GetRef<BlueprintArmorEnchantmentReference>(name)).ToArray();
      component.OnlyWeaponsShieldsAndArmor = onlyWeaponsShieldsAndArmor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TricksterArcanaBetterEnhancements"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enhancementEnchantments"><see cref="BlueprintItemEnchantment"/></param>
    /// <param name="bestEnchantments"><see cref="BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(TricksterArcanaBetterEnhancements))]
    public TBuilder AddTricksterArcanaBetterEnhancements(
        string[] enhancementEnchantments = null,
        string[] bestEnchantments = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TricksterArcanaBetterEnhancements();
      component.EnhancementEnchantments = enhancementEnchantments.Select(name => BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(name)).ToArray();
      component.BestEnchantments = bestEnchantments.Select(name => BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(name)).ToList();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TricksterKnowledgeWorldD20"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TricksterKnowledgeWorldD20))]
    public TBuilder AddTricksterKnowledgeWorldD20(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TricksterKnowledgeWorldD20();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TricksterKnowledgeWorldSkillBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TricksterKnowledgeWorldSkillBonus))]
    public TBuilder AddTricksterKnowledgeWorldSkillBonus(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TricksterKnowledgeWorldSkillBonus();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TricksterLoreNatureRestTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="tier1Buffs"><see cref="BlueprintBuff"/></param>
    /// <param name="tier2Buffs"><see cref="BlueprintBuff"/></param>
    /// <param name="tier3Buffs"><see cref="BlueprintBuff"/></param>
    /// <param name="tier2Feature"><see cref="BlueprintFeature"/></param>
    /// <param name="tier3Feature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(TricksterLoreNatureRestTrigger))]
    public TBuilder AddTricksterLoreNatureRestTrigger(
        string[] tier1Buffs = null,
        string[] tier2Buffs = null,
        string[] tier3Buffs = null,
        string tier2Feature = null,
        string tier3Feature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TricksterLoreNatureRestTrigger();
      component.Tier1Buffs = tier1Buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
      component.Tier2Buffs = tier2Buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
      component.Tier3Buffs = tier3Buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
      component.m_Tier2Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(tier2Feature);
      component.m_Tier3Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(tier3Feature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TwoWeaponDefense"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TwoWeaponDefense))]
    public TBuilder AddTwoWeaponDefense(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TwoWeaponDefense();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TwoWeaponFightingAttackPenalty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="mythicBlueprint"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(TwoWeaponFightingAttackPenalty))]
    public TBuilder AddTwoWeaponFightingAttackPenalty(
        string mythicBlueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TwoWeaponFightingAttackPenalty();
      component.m_MythicBlueprint = BlueprintTool.GetRef<BlueprintFeatureReference>(mythicBlueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TwoWeaponFightingAttacks"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TwoWeaponFightingAttacks))]
    public TBuilder AddTwoWeaponFightingAttacks(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TwoWeaponFightingAttacks();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TwoWeaponFightingDamagePenalty"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TwoWeaponFightingDamagePenalty))]
    public TBuilder AddTwoWeaponFightingDamagePenalty(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TwoWeaponFightingDamagePenalty();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UndeadHealth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UndeadHealth))]
    public TBuilder AddUndeadHealth(
        BlueprintComponent.Flags flags = default)
    {
      var component = new UndeadHealth();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnitDeathTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitDeathTrigger))]
    public TBuilder AddUnitDeathTrigger(
        ContextValue radiusInMeters = null,
        UnitDeathTrigger.FactionType faction = default,
        ActionsBuilder actions = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(radiusInMeters);
    
      var component = new UnitDeathTrigger();
      component.RadiusInMeters = radiusInMeters ?? ContextValues.Constant(0);
      component.Faction = faction;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="VolleyFireAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(VolleyFireAttackBonus))]
    public TBuilder AddVolleyFireAttackBonus(
        BlueprintComponent.Flags flags = default)
    {
      var component = new VolleyFireAttackBonus();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCategoryAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCategoryAttackBonus))]
    public TBuilder AddWeaponCategoryAttackBonus(
        WeaponCategory category = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponCategoryAttackBonus();
      component.Category = category;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponFocus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(WeaponFocus))]
    public TBuilder AddWeaponFocus(
        string weaponType = null,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponFocus();
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponGroupAttackBonus))]
    public TBuilder AddWeaponGroupAttackBonus(
        WeaponFighterGroup weaponGroup = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        bool multiplyByContext = default,
        ContextValue contextMultiplier = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(contextMultiplier);
    
      var component = new WeaponGroupAttackBonus();
      component.WeaponGroup = weaponGroup;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.multiplyByContext = multiplyByContext;
      component.contextMultiplier = contextMultiplier ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponGroupDamageBonus))]
    public TBuilder AddWeaponGroupDamageBonus(
        WeaponFighterGroup weaponGroup = default,
        int damageBonus = default,
        ContextValue additionalValue = null,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(additionalValue);
    
      var component = new WeaponGroupDamageBonus();
      component.WeaponGroup = weaponGroup;
      component.DamageBonus = damageBonus;
      component.AdditionalValue = additionalValue ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupEnchant"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponGroupEnchant))]
    public TBuilder AddWeaponGroupEnchant(
        WeaponFighterGroup weaponGroup = default,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponGroupEnchant();
      component.WeaponGroup = weaponGroup;
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponMultipleCategoriesAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponMultipleCategoriesAttackBonus))]
    public TBuilder AddWeaponMultipleCategoriesAttackBonus(
        WeaponCategory[] categories = null,
        int attackBonus = default,
        bool exceptForCategories = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponMultipleCategoriesAttackBonus();
      component.Categories = categories;
      component.AttackBonus = attackBonus;
      component.ExceptForCategories = exceptForCategories;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponParametersAttackBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="fightersFinesse"><see cref="BlueprintFeature"/></param>
    /// <param name="multiplierFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(WeaponParametersAttackBonus))]
    public TBuilder AddWeaponParametersAttackBonus(
        bool onlyFinessable = default,
        bool canBeUsedWithFightersFinesse = default,
        string fightersFinesse = null,
        bool ranged = default,
        bool onlyTwoHanded = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        bool scaleByBasicAttackBonus = default,
        bool onlyForFullAttack = default,
        string multiplierFact = null,
        int multiplier = default,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponParametersCriticalEdgeIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponParametersCriticalEdgeIncrease))]
    public TBuilder AddWeaponParametersCriticalEdgeIncrease(
        bool light = default,
        bool ranged = default,
        bool twoHanded = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponParametersCriticalEdgeIncrease();
      component.Light = light;
      component.Ranged = ranged;
      component.TwoHanded = twoHanded;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponParametersCriticalMultiplierIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponParametersCriticalMultiplierIncrease))]
    public TBuilder AddWeaponParametersCriticalMultiplierIncrease(
        bool light = default,
        bool ranged = default,
        bool twoHanded = default,
        int additionalMultiplier = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponParametersCriticalMultiplierIncrease();
      component.Light = light;
      component.Ranged = ranged;
      component.TwoHanded = twoHanded;
      component.AdditionalMultiplier = additionalMultiplier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponParametersDamageBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="fightersFinesse"><see cref="BlueprintFeature"/></param>
    /// <param name="greaterPowerAttackBlueprint"><see cref="BlueprintFeature"/></param>
    /// <param name="mythicBlueprint"><see cref="BlueprintFeature"/></param>
    /// <param name="weaponBlueprint"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(WeaponParametersDamageBonus))]
    public TBuilder AddWeaponParametersDamageBonus(
        bool onlyFinessable = default,
        bool canBeUsedWithFightersFinesse = default,
        string fightersFinesse = null,
        bool ranged = default,
        bool onlyTwoHanded = default,
        int damageBonus = default,
        bool scaleByBasicAttackBonus = default,
        bool powerAttackScaling = default,
        bool dualWielding = default,
        bool onlyToOffHandBonus = default,
        bool onlySpecificItemBlueprint = default,
        string greaterPowerAttackBlueprint = null,
        string mythicBlueprint = null,
        string weaponBlueprint = null,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponSizeChange"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponSizeChange))]
    public TBuilder AddWeaponSizeChange(
        int sizeCategoryChange = default,
        bool checkWeaponCategory = default,
        WeaponCategory category = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponSizeChange();
      component.SizeCategoryChange = sizeCategoryChange;
      component.CheckWeaponCategory = checkWeaponCategory;
      component.Category = category;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeCriticalEdgeIncrease"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(WeaponTypeCriticalEdgeIncrease))]
    public TBuilder AddWeaponTypeCriticalEdgeIncrease(
        string weaponType = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponTypeCriticalEdgeIncrease();
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeCriticalEdgeIncreaseStackable"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponTypeCriticalEdgeIncreaseStackable))]
    public TBuilder AddWeaponTypeCriticalEdgeIncreaseStackable(
        bool anyCategory = default,
        WeaponCategory category = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponTypeCriticalEdgeIncreaseStackable();
      component.AnyCategory = anyCategory;
      component.Category = category;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeCriticalMultiplierIncrease"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(WeaponTypeCriticalMultiplierIncrease))]
    public TBuilder AddWeaponTypeCriticalMultiplierIncrease(
        string weaponType = null,
        int additionalMultiplier = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponTypeCriticalMultiplierIncrease();
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.AdditionalMultiplier = additionalMultiplier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeDamageBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(WeaponTypeDamageBonus))]
    public TBuilder AddWeaponTypeDamageBonus(
        string weaponType = null,
        int damageBonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponTypeDamageBonus();
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.DamageBonus = damageBonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponTypeDamageStatReplacement))]
    public TBuilder AddWeaponTypeDamageStatReplacement(
        StatType stat = default,
        WeaponCategory category = default,
        bool onlyOneHanded = default,
        bool twoHandedBonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponTypeDamageStatReplacement();
      component.Stat = stat;
      component.Category = category;
      component.OnlyOneHanded = onlyOneHanded;
      component.TwoHandedBonus = twoHandedBonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ImpatienceCalmingPart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="impatience"><see cref="BlueprintBuff"/></param>
    /// <param name="targetedImpatience"><see cref="BlueprintBuff"/></param>
    /// <param name="patience"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ImpatienceCalmingPart))]
    public TBuilder AddImpatienceCalmingPart(
        string impatience = null,
        string targetedImpatience = null,
        string patience = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ImpatienceCalmingPart();
      component.m_Impatience = BlueprintTool.GetRef<BlueprintBuffReference>(impatience);
      component.m_TargetedImpatience = BlueprintTool.GetRef<BlueprintBuffReference>(targetedImpatience);
      component.m_Patience = BlueprintTool.GetRef<BlueprintBuffReference>(patience);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ImpatienceWatcherTickingResolve"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="impatience"><see cref="BlueprintBuff"/></param>
    /// <param name="targetedImpatience"><see cref="BlueprintBuff"/></param>
    /// <param name="patience"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ImpatienceWatcherTickingResolve))]
    public TBuilder AddImpatienceWatcherTickingResolve(
        string impatience = null,
        string targetedImpatience = null,
        string patience = null,
        int[] resolveChances = null,
        int[] resolveChancesForLowInt = null,
        int[] resolveChancesForHighInt = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ImpatienceWatcherTickingResolve();
      component.m_Impatience = BlueprintTool.GetRef<BlueprintBuffReference>(impatience);
      component.m_TargetedImpatience = BlueprintTool.GetRef<BlueprintBuffReference>(targetedImpatience);
      component.m_Patience = BlueprintTool.GetRef<BlueprintBuffReference>(patience);
      component.ResolveChances = resolveChances;
      component.ResolveChancesForLowInt = resolveChancesForLowInt;
      component.ResolveChancesForHighInt = resolveChancesForHighInt;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Afterbuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="afterBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(Afterbuff))]
    public TBuilder AddAfterbuff(
        string afterBuff = null,
        int durationMultiplier = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new Afterbuff();
      component.m_AfterBuff = BlueprintTool.GetRef<BlueprintBuffReference>(afterBuff);
      component.DurationMultiplier = durationMultiplier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AfterbuffIfHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="featureToCheck"><see cref="BlueprintFeature"/></param>
    /// <param name="afterBuffFalse"><see cref="BlueprintBuff"/></param>
    /// <param name="afterBuffTrue"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AfterbuffIfHasFact))]
    public TBuilder AddAfterbuffIfHasFact(
        string featureToCheck = null,
        string afterBuffFalse = null,
        string afterBuffTrue = null,
        int durationMultiplier = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AfterbuffIfHasFact();
      component.m_FeatureToCheck = BlueprintTool.GetRef<BlueprintFeatureReference>(featureToCheck);
      component.m_AfterBuffFalse = BlueprintTool.GetRef<BlueprintBuffReference>(afterBuffFalse);
      component.m_AfterBuffTrue = BlueprintTool.GetRef<BlueprintBuffReference>(afterBuffTrue);
      component.DurationMultiplier = durationMultiplier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmagsBladeEnrage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmagsBladeEnrage))]
    public TBuilder AddArmagsBladeEnrage(
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArmagsBladeEnrage();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmorFocus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmorFocus))]
    public TBuilder AddArmorFocus(
        ArmorProficiencyGroup armorCategory = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArmorFocus();
      component.ArmorCategory = armorCategory;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffAbilityRollsBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffAbilityRollsBonus))]
    public TBuilder AddBuffAbilityRollsBonus(
        int value = default,
        ModifierDescriptor descriptor = default,
        bool affectAllStats = default,
        bool onlyHighesStats = default,
        ContextValue multiplier = null,
        StatType stat = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(multiplier);
    
      var component = new BuffAbilityRollsBonus();
      component.Value = value;
      component.Descriptor = descriptor;
      component.AffectAllStats = affectAllStats;
      component.OnlyHighesStats = onlyHighesStats;
      component.Multiplier = multiplier ?? ContextValues.Constant(0);
      component.Stat = stat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffAllSavesBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffAllSavesBonus))]
    public TBuilder AddBuffAllSavesBonus(
        ModifierDescriptor descriptor = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffAllSavesBonus();
      component.Descriptor = descriptor;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffAllSkillsBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffAllSkillsBonus))]
    public TBuilder AddBuffAllSkillsBonus(
        ModifierDescriptor descriptor = default,
        int value = default,
        ContextValue multiplier = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(multiplier);
    
      var component = new BuffAllSkillsBonus();
      component.Descriptor = descriptor;
      component.Value = value;
      component.Multiplier = multiplier ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffAllSkillsBonusAbilityValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffAllSkillsBonusAbilityValue))]
    public TBuilder AddBuffAllSkillsBonusAbilityValue(
        ModifierDescriptor descriptor = default,
        ContextValue value = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new BuffAllSkillsBonusAbilityValue();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffAllSkillsBonusRankDependent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffAllSkillsBonusRankDependent))]
    public TBuilder AddBuffAllSkillsBonusRankDependent(
        ModifierDescriptor descriptor = default,
        int value = default,
        int minimalRank = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffAllSkillsBonusRankDependent();
      component.Descriptor = descriptor;
      component.Value = value;
      component.MinimalRank = minimalRank;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffDamageEachRound"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffDamageEachRound))]
    public TBuilder AddBuffDamageEachRound(
        DiceFormula energyDamageDice,
        int baseRounds = default,
        float additionalRoundsPerCasterLevel = default,
        DamageEnergyType element = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffDamageEachRound();
      component.baseRounds = baseRounds;
      component.AdditionalRoundsPerCasterLevel = additionalRoundsPerCasterLevel;
      component.EnergyDamageDice = energyDamageDice;
      component.Element = element;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffExtraAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffExtraAttack))]
    public TBuilder AddBuffExtraAttack(
        int number = default,
        bool haste = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffExtraAttack();
      component.Number = number;
      component.Haste = haste;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffExtraAttackWeaponSpecific"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffExtraAttackWeaponSpecific))]
    public TBuilder AddBuffExtraAttackWeaponSpecific(
        WeaponRangeType rangeType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffExtraAttackWeaponSpecific();
      component.RangeType = rangeType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffIncomingDamageIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffIncomingDamageIncrease))]
    public TBuilder AddBuffIncomingDamageIncrease(
        ContextValue value = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new BuffIncomingDamageIncrease();
      component.Value = value ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffMiraculousHealing"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffMiraculousHealing))]
    public TBuilder AddBuffMiraculousHealing(
        float empowerMiraculousModifier = default,
        float savedModifier = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffMiraculousHealing();
      component.EmpowerMiraculousModifier = empowerMiraculousModifier;
      component.m_SavedModifier = savedModifier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffMovementSpeed"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffMovementSpeed))]
    public TBuilder AddBuffMovementSpeed(
        ModifierDescriptor descriptor = default,
        int value = default,
        ContextValue contextBonus = null,
        bool cappedOnMultiplier = default,
        float multiplierCap = default,
        bool cappedMinimum = default,
        int minimumCap = default,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffOnArmor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(BuffOnArmor))]
    public TBuilder AddBuffOnArmor(
        string buff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffOnArmor();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffOnHealthTickingTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="triggeredBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(BuffOnHealthTickingTrigger))]
    public TBuilder AddBuffOnHealthTickingTrigger(
        string triggeredBuff = null,
        float healthPercent = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffOnHealthTickingTrigger();
      component.m_TriggeredBuff = BlueprintTool.GetRef<BlueprintBuffReference>(triggeredBuff);
      component.HealthPercent = healthPercent;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffOnLightOrNoArmor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(BuffOnLightOrNoArmor))]
    public TBuilder AddBuffOnLightOrNoArmor(
        string buff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffOnLightOrNoArmor();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffParticleEffectPlay"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffParticleEffectPlay))]
    public TBuilder AddBuffParticleEffectPlay(
        bool playOnActivate = default,
        PrefabLink activateFx = null,
        bool playOnDeactivate = default,
        PrefabLink deactivateFx = null,
        bool playEachRound = default,
        PrefabLink eachRoundFx = null,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffPerceptionBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffPerceptionBonus))]
    public TBuilder AddBuffPerceptionBonus(
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffPerceptionBonus();
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSaveEachRound"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffSaveEachRound))]
    public TBuilder AddBuffSaveEachRound(
        SavingThrowType saveType = default,
        int saveDC = default,
        int increaseDC = default,
        ActionsBuilder actionsOnPass = null,
        ActionsBuilder actionsOnFail = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffSaveEachRound();
      component.SaveType = saveType;
      component.SaveDC = saveDC;
      component.IncreaseDC = increaseDC;
      component.ActionsOnPass = actionsOnPass?.Build() ?? Constants.Empty.Actions;
      component.ActionsOnFail = actionsOnFail?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSaveOrDieEachRound"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffSaveOrDieEachRound))]
    public TBuilder AddBuffSaveOrDieEachRound(
        GameObject effectOnDeath,
        UnitCondition condition = default,
        SavingThrowType saveType = default,
        int saveDC = default,
        int increaseDC = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(effectOnDeath);
    
      var component = new BuffSaveOrDieEachRound();
      component.Condition = condition;
      component.SaveType = saveType;
      component.SaveDC = saveDC;
      component.IncreaseDC = increaseDC;
      component.EffectOnDeath = effectOnDeath;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSkillBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffSkillBonus))]
    public TBuilder AddBuffSkillBonus(
        StatType stat = default,
        ModifierDescriptor descriptor = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffSkillBonus();
      component.Stat = stat;
      component.Descriptor = descriptor;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSkillLoreNatureBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffSkillLoreNatureBonus))]
    public TBuilder AddBuffSkillLoreNatureBonus(
        ModifierDescriptor descriptor = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffSkillLoreNatureBonus();
      component.Descriptor = descriptor;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSkillStealthBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffSkillStealthBonus))]
    public TBuilder AddBuffSkillStealthBonus(
        ModifierDescriptor descriptor = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffSkillStealthBonus();
      component.Descriptor = descriptor;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffStatPenaltyDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffStatPenaltyDice))]
    public TBuilder AddBuffStatPenaltyDice(
        DiceFormula value,
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int bonus = default,
        SavingThrowType saveType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffStatPenaltyDice();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.Bonus = bonus;
      component.SaveType = saveType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffStatusCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffStatusCondition))]
    public TBuilder AddBuffStatusCondition(
        bool saveEachRound = default,
        UnitCondition condition = default,
        SavingThrowType saveType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffStatusCondition();
      component.SaveEachRound = saveEachRound;
      component.Condition = condition;
      component.SaveType = saveType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffStrengthSkillsBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffStrengthSkillsBonus))]
    public TBuilder AddBuffStrengthSkillsBonus(
        BuffScaling scaling,
        ModifierDescriptor descriptor = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(scaling);
    
      var component = new BuffStrengthSkillsBonus();
      component.Descriptor = descriptor;
      component.Value = value;
      component.Scaling = scaling;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BurstBarrier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BurstBarrier))]
    public TBuilder AddBurstBarrier(
        BlueprintComponent.Flags flags = default)
    {
      var component = new BurstBarrier();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CannyDefensePermanent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="chosenWeaponBlueprint"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(CannyDefensePermanent))]
    public TBuilder AddCannyDefensePermanent(
        string characterClass = null,
        bool requiresKensai = default,
        string chosenWeaponBlueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CannyDefensePermanent();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.RequiresKensai = requiresKensai;
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(chosenWeaponBlueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeUnitSize"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeUnitSize))]
    public TBuilder AddChangeUnitSize(
        ChangeUnitSize.ChangeType type = default,
        int sizeDelta = default,
        Size size = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ChangeUnitSize();
      component.m_Type = type;
      component.SizeDelta = sizeDelta;
      component.Size = size;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusConditional"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageBonusConditional))]
    public TBuilder AddDamageBonusConditional(
        bool checkWielder = default,
        bool onlyWeaponDamage = default,
        ModifierDescriptor descriptor = default,
        ContextValue bonus = null,
        ConditionsBuilder conditions = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new DamageBonusConditional();
      component.CheckWielder = checkWielder;
      component.OnlyWeaponDamage = onlyWeaponDamage;
      component.Descriptor = descriptor;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageOnRemove"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageOnRemove))]
    public TBuilder AddDamageOnRemove(
        DiceFormula damage,
        DamageEnergyType energyType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DamageOnRemove();
      component.Damage = damage;
      component.EnergyType = energyType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageOverTime"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageOverTime))]
    public TBuilder AddDamageOverTime(
        DiceFormula damage,
        DamageEnergyType energyType = default,
        bool instantStartTick = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DamageOverTime();
      component.Damage = damage;
      component.EnergyType = energyType;
      component.InstantStartTick = instantStartTick;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageWithDescriptorRecievedTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageWithDescriptorRecievedTrigger))]
    public TBuilder AddDamageWithDescriptorRecievedTrigger(
        SpellDescriptorWrapper descriptor,
        DamageEnergyType energyType = default,
        ActionsBuilder actions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DamageWithDescriptorRecievedTrigger();
      component.Descriptor = descriptor;
      component.EnergyType = energyType;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DevilReflectAbility"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DevilReflectAbility))]
    public TBuilder AddDevilReflectAbility(
        SpellSchool[] reflectSchools = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DevilReflectAbility();
      component.m_ReflectSchools = reflectSchools;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DifficultyStatAdvancement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DifficultyStatAdvancement))]
    public TBuilder AddDifficultyStatAdvancement(
        int basicStatBonus = default,
        int derivativeStatBonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DifficultyStatAdvancement();
      component.BasicStatBonus = basicStatBonus;
      component.DerivativeStatBonus = derivativeStatBonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EchoesOfStoneTerrainBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EchoesOfStoneTerrainBonus))]
    public TBuilder AddEchoesOfStoneTerrainBonus(
        AreaSetting setting = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EchoesOfStoneTerrainBonus();
      component.Setting = setting;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EmptyHandWeaponOverride"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weapon"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(EmptyHandWeaponOverride))]
    public TBuilder AddEmptyHandWeaponOverride(
        string weapon = null,
        bool isPermanent = default,
        bool isMonkUnarmedStrike = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EmptyHandWeaponOverride();
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weapon);
      component.IsPermanent = isPermanent;
      component.IsMonkUnarmedStrike = isMonkUnarmedStrike;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HasArmorFeatureUnlock"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="newFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(HasArmorFeatureUnlock))]
    public TBuilder AddHasArmorFeatureUnlock(
        string newFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new HasArmorFeatureUnlock();
      component.m_NewFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(newFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HealOverTime"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HealOverTime))]
    public TBuilder AddHealOverTime(
        int heal = default,
        bool instantStartTick = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new HealOverTime();
      component.Heal = heal;
      component.InstantStartTick = instantStartTick;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HealOverTimeIfHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(HealOverTimeIfHasFact))]
    public TBuilder AddHealOverTimeIfHasFact(
        BuffScaling scaling,
        int heal = default,
        bool instantStartTick = default,
        string checkedFact = null,
        bool scale = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(scaling);
    
      var component = new HealOverTimeIfHasFact();
      component.Heal = heal;
      component.InstantStartTick = instantStartTick;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintFeatureReference>(checkedFact);
      component.Scale = scale;
      component.Scaling = scaling;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellDamageByClassLevel"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="BlueprintAbility"/></param>
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="additionalClasses"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="archetypes"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(IncreaseSpellDamageByClassLevel))]
    public TBuilder AddIncreaseSpellDamageByClassLevel(
        string[] spells = null,
        string characterClass = null,
        string[] additionalClasses = null,
        string[] archetypes = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseSpellDamageByClassLevel();
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_AdditionalClasses = additionalClasses.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray();
      component.m_Archetypes = archetypes.Select(name => BlueprintTool.GetRef<BlueprintArchetypeReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IntenseSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="wizard"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(IntenseSpells))]
    public TBuilder AddIntenseSpells(
        string wizard = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IntenseSpells();
      component.m_Wizard = BlueprintTool.GetRef<BlueprintCharacterClassReference>(wizard);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LiquidateTowerShieldPenalty"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LiquidateTowerShieldPenalty))]
    public TBuilder AddLiquidateTowerShieldPenalty(
        BlueprintComponent.Flags flags = default)
    {
      var component = new LiquidateTowerShieldPenalty();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MakeUnitFollowUnit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MakeUnitFollowUnit))]
    public TBuilder AddMakeUnitFollowUnit(
        UnitEvaluator leader,
        bool alwaysRun = default,
        bool canBeSlowerThanLeader = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(leader);
    
      var component = new MakeUnitFollowUnit();
      component.AlwaysRun = alwaysRun;
      component.CanBeSlowerThanLeader = canBeSlowerThanLeader;
      component.Leader = leader;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ModifySpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(ModifySpell))]
    public TBuilder AddModifySpell(
        SpellModificationType modificationType = default,
        string[] spells = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ModifySpell();
      component.ModificationType = modificationType;
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MonkNoArmorAndMonkWeaponFeatureUnlock"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="newFact"><see cref="BlueprintUnitFact"/></param>
    /// <param name="bowWeaponTypes"><see cref="BlueprintWeaponType"/></param>
    /// <param name="rapidshotBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(MonkNoArmorAndMonkWeaponFeatureUnlock))]
    public TBuilder AddMonkNoArmorAndMonkWeaponFeatureUnlock(
        string newFact = null,
        bool isZenArcher = default,
        string[] bowWeaponTypes = null,
        string rapidshotBuff = null,
        bool isSohei = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MonkNoArmorAndMonkWeaponFeatureUnlock();
      component.m_NewFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(newFact);
      component.IsZenArcher = isZenArcher;
      component.m_BowWeaponTypes = bowWeaponTypes.Select(name => BlueprintTool.GetRef<BlueprintWeaponTypeReference>(name)).ToArray();
      component.m_RapidshotBuff = BlueprintTool.GetRef<BlueprintBuffReference>(rapidshotBuff);
      component.IsSohei = isSohei;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MonkNoArmorFeatureUnlock"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="newFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(MonkNoArmorFeatureUnlock))]
    public TBuilder AddMonkNoArmorFeatureUnlock(
        string newFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MonkNoArmorFeatureUnlock();
      component.m_NewFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(newFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MysticTheurgeCombinedSpells"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MysticTheurgeCombinedSpells))]
    public TBuilder AddMysticTheurgeCombinedSpells(
        int spellLevel = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MysticTheurgeCombinedSpells();
      component.SpellLevel = spellLevel;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MysticTheurgeSpellbook"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="mysticTheurge"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(MysticTheurgeSpellbook))]
    public TBuilder AddMysticTheurgeSpellbook(
        string characterClass = null,
        string mysticTheurge = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MysticTheurgeSpellbook();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_MysticTheurge = BlueprintTool.GetRef<BlueprintCharacterClassReference>(mysticTheurge);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PowerfulCharge"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PowerfulCharge))]
    public TBuilder AddPowerfulCharge(
        bool useContextBonus = default,
        ContextValue value = null,
        int additionalDiceRolls = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new PowerfulCharge();
      component.UseContextBonus = useContextBonus;
      component.Value = value ?? ContextValues.Constant(0);
      component.AdditionalDiceRolls = additionalDiceRolls;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ProtectionFromEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ProtectionFromEnergy))]
    public TBuilder AddProtectionFromEnergy(
        DamageEnergyType type = default,
        bool useValueMultiplier = default,
        ContextValue valueMultiplier = null,
        ContextValue value = null,
        bool usePool = default,
        ContextValue pool = null,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PummelingCharge"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PummelingCharge))]
    public TBuilder AddPummelingCharge(
        WeaponCategory unarmedCategory = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new PummelingCharge();
      component.UnarmedCategory = unarmedCategory;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReduceDamageReduction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReduceDamageReduction))]
    public TBuilder AddReduceDamageReduction(
        int multiplier = default,
        ContextValue value = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new ReduceDamageReduction();
      component.Multiplier = multiplier;
      component.Value = value ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceAsksList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="asks"><see cref="BlueprintUnitAsksList"/></param>
    [Generated]
    [Implements(typeof(ReplaceAsksList))]
    public TBuilder AddReplaceAsksList(
        string asks = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceAsksList();
      component.m_Asks = BlueprintTool.GetRef<BlueprintUnitAsksListReference>(asks);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ResistEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ResistEnergy))]
    public TBuilder AddResistEnergy(
        DamageEnergyType type = default,
        bool useValueMultiplier = default,
        ContextValue valueMultiplier = null,
        ContextValue value = null,
        bool usePool = default,
        ContextValue pool = null,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ResistEnergyContext"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ResistEnergyContext))]
    public TBuilder AddResistEnergyContext(
        DamageEnergyType type = default,
        bool useValueMultiplier = default,
        ContextValue valueMultiplier = null,
        ContextValue value = null,
        bool usePool = default,
        ContextValue pool = null,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SaveSuccessIfBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SaveSuccessIfBonus))]
    public TBuilder AddSaveSuccessIfBonus(
        ContextValue value = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new SaveSuccessIfBonus();
      component.Value = value ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShieldFocus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ShieldFocus))]
    public TBuilder AddShieldFocus(
        BlueprintComponent.Flags flags = default)
    {
      var component = new ShieldFocus();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SkillSuccessIfBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SkillSuccessIfBonus))]
    public TBuilder AddSkillSuccessIfBonus(
        ContextValue value = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new SkillSuccessIfBonus();
      component.Value = value ?? ContextValues.Constant(0);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpeedBonusInArmorCategory"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpeedBonusInArmorCategory))]
    public TBuilder AddSpeedBonusInArmorCategory(
        ArmorProficiencyGroup[] category = null,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        bool noArmor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpeedBonusInArmorCategory();
      component.Category = category;
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.NoArmor = noArmor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="StatBonusWeaponRestriction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(StatBonusWeaponRestriction))]
    public TBuilder AddStatBonusWeaponRestriction(
        StatType stat = default,
        int value = default,
        ModifierDescriptor descriptor = default,
        bool checkCategory = default,
        WeaponCategory category = default,
        bool oneHandedOnly = default,
        bool duelistWeapon = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new StatBonusWeaponRestriction();
      component.Stat = stat;
      component.Value = value;
      component.Descriptor = descriptor;
      component.CheckCategory = checkCategory;
      component.Category = category;
      component.OneHandedOnly = oneHandedOnly;
      component.DuelistWeapon = duelistWeapon;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="StonyStepTerrainBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(StonyStepTerrainBonus))]
    public TBuilder AddStonyStepTerrainBonus(
        AreaSetting setting = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new StonyStepTerrainBonus();
      component.Setting = setting;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsConstitutionBased"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TemporaryHitPointsConstitutionBased))]
    public TBuilder AddTemporaryHitPointsConstitutionBased(
        ContextValue value = null,
        int bonusMultiplier = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new TemporaryHitPointsConstitutionBased();
      component.Value = value ?? ContextValues.Constant(0);
      component.BonusMultiplier = bonusMultiplier;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsEqualCasterLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TemporaryHitPointsEqualCasterLevel))]
    public TBuilder AddTemporaryHitPointsEqualCasterLevel(
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TemporaryHitPointsEqualCasterLevel();
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsFromAbilityValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TemporaryHitPointsFromAbilityValue))]
    public TBuilder AddTemporaryHitPointsFromAbilityValue(
        ModifierDescriptor descriptor = default,
        ContextValue value = null,
        bool removeWhenHitPointsEnd = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new TemporaryHitPointsFromAbilityValue();
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      component.RemoveWhenHitPointsEnd = removeWhenHitPointsEnd;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsPerLevel"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="limitlessRageBlueprint"><see cref="BlueprintUnitFact"/></param>
    /// <param name="limitlessRageResource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(TemporaryHitPointsPerLevel))]
    public TBuilder AddTemporaryHitPointsPerLevel(
        ModifierDescriptor descriptor = default,
        int hitPointsPerLevel = default,
        ContextValue value = null,
        bool removeWhenHitPointsEnd = default,
        bool limitlessRage = default,
        string limitlessRageBlueprint = null,
        string limitlessRageResource = null,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsRandom"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TemporaryHitPointsRandom))]
    public TBuilder AddTemporaryHitPointsRandom(
        DiceFormula dice,
        ModifierDescriptor descriptor = default,
        ContextValue bonus = null,
        bool scaleBonusByCasterLevel = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new TemporaryHitPointsRandom();
      component.Descriptor = descriptor;
      component.Dice = dice;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.ScaleBonusByCasterLevel = scaleBonusByCasterLevel;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TowerShieldSpecialistTotalCover"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TowerShieldSpecialistTotalCover))]
    public TBuilder AddTowerShieldSpecialistTotalCover(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TowerShieldSpecialistTotalCover();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTrainingBonuses"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponTrainingBonuses))]
    public TBuilder AddWeaponTrainingBonuses(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponTrainingBonuses();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WizardAbjurationResistance"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="wizard"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(WizardAbjurationResistance))]
    public TBuilder AddWizardAbjurationResistance(
        string wizard = null,
        DamageEnergyType type = default,
        bool useValueMultiplier = default,
        ContextValue valueMultiplier = null,
        ContextValue value = null,
        bool usePool = default,
        ContextValue pool = null,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WizardEnergyAbsorption"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(WizardEnergyAbsorption))]
    public TBuilder AddWizardEnergyAbsorption(
        string resource = null,
        DamageEnergyType type = default,
        bool useValueMultiplier = default,
        ContextValue valueMultiplier = null,
        ContextValue value = null,
        bool usePool = default,
        ContextValue pool = null,
        BlueprintComponent.Flags flags = default)
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
      component.m_Flags = flags;
      return AddComponent(component);
    }
  }
}
