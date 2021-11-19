using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Armies.TacticalCombat.LeaderSkills;
using Kingmaker.Armies.TacticalCombat.LeaderSkills.UnitBuffComponents;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Controllers.Units;
using Kingmaker.Corruption;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Designers.Mechanics.Facts.Behavior;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.Settings;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Parts;
using Kingmaker.Utility;
using Kingmaker.Visual;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using Owlcat.Runtime.Visual.Effects.WeatherSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Buffs
{
  /// <summary>Configurator for <see cref="BlueprintBuff"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintBuff))]
  public class BuffConfigurator : BaseUnitFactConfigurator<BlueprintBuff, BuffConfigurator>
  {
    private BlueprintBuff.Flags EnableFlags;
    private BlueprintBuff.Flags DisableFlags;

    private BuffConfigurator(string name) : base(name) { }

    /// <summary>Returns a configurator for the given blueprint.</summary>
    /// 
    /// <remarks>
    /// Use this function if the blueprint exists in the game library. If you're using
    /// <see href="https://github.com/OwlcatOpenSource/WrathModificationTemplate">WrathModifiationTemplate</see> your
    /// JSON blueprints should already exist.
    /// </remarks>
    public static BuffConfigurator For(string name)
    {
      return new BuffConfigurator(name);
    }

    /// <summary>Creates a blueprint and returns its configurator.</summary>
    /// 
    /// <remarks>
    /// Use this function to create a new blueprint if you provided a mapping with
    /// <see cref="BlueprintTool.AddGuidsByName"/>. Otherwise use <see cref="New(string, string)"/>.
    /// </remarks>
    public static BuffConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintBuff>(name);
      return For(name);
    }

    /// <summary>Creates a blueprint and returns its configurator.</summary>
    public static BuffConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintBuff>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.IsClassFeature"/>
    /// </summary>
    public BuffConfigurator SetIsClassFeature(bool isClassFeature = true)
    {
      return OnConfigureInternal(blueprint => blueprint.IsClassFeature = isClassFeature);
    }

    /// <summary>
    /// Adds to <see cref="BlueprintBuff.m_Flags"/>
    /// </summary>
    public BuffConfigurator AddFlags(params BlueprintBuff.Flags[] flags)
    {
      foreach (BlueprintBuff.Flags flag in flags)
      {
        EnableFlags |= flag;
      }
      return this;
    }

    /// <summary>
    /// Removes from <see cref="BlueprintBuff.m_Flags"/>
    /// </summary>
    public BuffConfigurator RemoveFlags(params BlueprintBuff.Flags[] flags)
    {
      foreach (BlueprintBuff.Flags flag in flags)
      {
        DisableFlags |= flag;
      }
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.Stacking"/>
    /// </summary>
    /// 
    /// <remarks>Use <see cref="SetRanks(int)"/> for <see cref="StackingType.Rank"/></remarks>
    public BuffConfigurator SetStackingType(StackingType type)
    {
      if (type == StackingType.Rank)
      {
        throw new InvalidOperationException("Use SetRanks() for StackingType.Rank.");
      }

      return OnConfigureInternal(blueprint => blueprint.Stacking = type);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.Ranks"/>
    /// </summary>
    ///
    /// <remarks>Also sets <see cref="BlueprintBuff.Stacking"/> to <see cref="StackingType.Rank"/></remarks>
    public BuffConfigurator SetRanks(int ranks)
    {
      return OnConfigureInternal(
          blueprint =>
          {
            blueprint.Stacking = StackingType.Rank;
            blueprint.Ranks = ranks;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.TickEachSecond"/>
    /// </summary>
    public BuffConfigurator SetTickEachSecond(bool tickEachSecond = true)
    {
      return OnConfigureInternal(blueprint => blueprint.TickEachSecond = tickEachSecond);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.Frequency"/>
    /// </summary>
    public BuffConfigurator SetFrequency(DurationRate rate)
    {
      return OnConfigureInternal(blueprint => blueprint.Frequency = rate);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.FxOnStart"/>
    /// </summary>
    public BuffConfigurator SetFxOnStart(PrefabLink prefab)
    {
      return OnConfigureInternal(blueprint => blueprint.FxOnStart = prefab);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.FxOnRemove"/>
    /// </summary>
    public BuffConfigurator SetFxOnRemove(PrefabLink prefab)
    {
      return OnConfigureInternal(blueprint => blueprint.FxOnRemove = prefab);
    }


        /// <summary>
        /// Adds <see cref="AddEffectFastHealing"/>
        /// </summary>
        [Implements(typeof(AddEffectFastHealing))]
        public BuffConfigurator FastHealing(int baseValue, ContextValue bonusValue = null)
        {
          var fastHealing = new AddEffectFastHealing
          {
            Heal = baseValue,
            Bonus = bonusValue ?? 0
          };
          return AddComponent(fastHealing);
        }

        /// <summary>
        /// Adds <see cref="RemoveWhenCombatEnded"/>
        /// </summary>
        [Implements(typeof(RemoveWhenCombatEnded))]
        public BuffConfigurator RemoveWhenCombatEnds()
        {
          return AddUniqueComponent(new RemoveWhenCombatEnded(), ComponentMerge.Skip);
        }

        /// <summary>
        /// Adds <see cref="Kingmaker.Designers.Mechanics.Buffs.BuffSleeping">BuffSleeping</see>
        /// </summary>
        [Implements(typeof(BuffSleeping))]
        public BuffConfigurator BuffSleeping(
            int? wakeupPerceptionDC = null,
            ComponentMerge mergeBehavior = ComponentMerge.Replace,
            Action<BlueprintComponent, BlueprintComponent> merge = null)
        {
          var sleeping = new BuffSleeping();
          if (wakeupPerceptionDC is not null) { sleeping.WakeupPerceptionDC = wakeupPerceptionDC.Value; }
          return AddUniqueComponent(sleeping, mergeBehavior, merge);
        }

        /// <summary>
        /// Adds <see cref="Kingmaker.UnitLogic.Mechanics.Components.ContextRankConfig">ContextRankConfig</see>
        /// </summary>
        /// 
        /// <remarks>Use <see cref="Components.ContextRankConfigs">ContextRankConfigs</see> to create the config</remarks>
        [Implements(typeof(ContextRankConfig))]
        public BuffConfigurator ContextRankConfig(ContextRankConfig rankConfig)
        {
          return AddComponent(rankConfig);
        }

        /// <summary>
        /// Adds or modifies <see cref="SpellDescriptorComponent"/>
        /// </summary>
        [Implements(typeof(SpellDescriptorComponent))]
        public BuffConfigurator AddSpellDescriptors(params SpellDescriptor[] descriptors)
        {
          foreach (SpellDescriptor descriptor in descriptors)
          {
            EnableSpellDescriptors |= (long)descriptor;
          }
          return Self;
        }

        /// <summary>
        /// Modifies <see cref="SpellDescriptorComponent"/>
        /// </summary>
        [Implements(typeof(SpellDescriptorComponent))]
        public BuffConfigurator RemoveSpellDescriptors(params SpellDescriptor[] descriptors)
        {
          foreach (SpellDescriptor descriptor in descriptors)
          {
            DisableSpellDescriptors |= (long)descriptor;
          }
          return Self;
        }

    /// <summary>
    /// Adds <see cref="CorruptionProtection"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CorruptionProtection))]
    public BuffConfigurator AddCorruptionProtection(
        bool removeRankAfterRest = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CorruptionProtection();
      component.m_RemoveRankAfterRest = removeRankAfterRest;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="GlobalMapSpeedModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GlobalMapSpeedModifier))]
    public BuffConfigurator AddGlobalMapSpeedModifier(
        float speedModifier = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new GlobalMapSpeedModifier();
      component.SpeedModifier = speedModifier;
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
    public BuffConfigurator AddBuffInBadWeather(
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
    public BuffConfigurator AddBuffOnApplyingSpell(
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
    /// Adds <see cref="AddClusteredAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddClusteredAttack))]
    public BuffConfigurator AddClusteredAttack(
        AddClusteredAttack.Type attackType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddClusteredAttack();
      component.AttackType = attackType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddContextStatBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddContextStatBonus))]
    public BuffConfigurator AddContextStatBonus(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int multiplier = default,
        bool hasMinimal = default,
        int minimal = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new AddContextStatBonus();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Multiplier = multiplier;
      component.Value = value;
      component.HasMinimal = hasMinimal;
      component.Minimal = minimal;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCumulativeDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddCumulativeDamageBonus))]
    public BuffConfigurator AddCumulativeDamageBonus(
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
    public BuffConfigurator AddCumulativeDamageBonusX3(
        bool onlyNaturalAttacks = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddCumulativeDamageBonusX3();
      component.OnlyNaturalAttacks = onlyNaturalAttacks;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddDamageTypeVulnerability"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddDamageTypeVulnerability))]
    public BuffConfigurator AddDamageTypeVulnerability(
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
    /// Adds <see cref="AddEnergyDamageImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEnergyDamageImmunity))]
    public BuffConfigurator AddEnergyDamageImmunity(
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
    public BuffConfigurator AddEnergyImmunity(
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
    public BuffConfigurator AddEnergyVulnerability(
        DamageEnergyType type = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddEnergyVulnerability();
      component.Type = type;
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
    public BuffConfigurator AddFactsFromCaster(
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
    /// Adds <see cref="AddForceMove"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddForceMove))]
    public BuffConfigurator AddForceMove(
        ContextValue feetPerRound,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(feetPerRound);
    
      var component = new AddForceMove();
      component.FeetPerRound = feetPerRound;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddGoldenDragonSkillBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddGoldenDragonSkillBonus))]
    public BuffConfigurator AddGoldenDragonSkillBonus(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddGoldenDragonSkillBonus();
      component.Descriptor = descriptor;
      component.Stat = stat;
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
    public BuffConfigurator AddIncomingDamageWeaponProperty(
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
    /// Adds <see cref="AddNocticulaBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddNocticulaBonus))]
    public BuffConfigurator AddNocticulaBonus(
        ContextValue highestStatBonus,
        ContextValue secondHighestStatBonus,
        ModifierDescriptor descriptor = default,
        StatType highestStat = default,
        StatType secondHighestStat = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(highestStatBonus);
      ValidateParam(secondHighestStatBonus);
    
      var component = new AddNocticulaBonus();
      component.Descriptor = descriptor;
      component.HighestStatBonus = highestStatBonus;
      component.m_HighestStat = highestStat;
      component.SecondHighestStatBonus = secondHighestStatBonus;
      component.m_SecondHighestStat = secondHighestStat;
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
    public BuffConfigurator AddOutgoingPhysicalDamageProperty(
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
    /// Adds <see cref="AddPhysicalImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddPhysicalImmunity))]
    public BuffConfigurator AddPhysicalImmunity(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddPhysicalImmunity();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddRestTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddRestTrigger))]
    public BuffConfigurator AddRestTrigger(
        ActionList action,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(action);
    
      var component = new AddRestTrigger();
      component.Action = action;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddRunwayLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddRunwayLogic))]
    public BuffConfigurator AddRunwayLogic(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddRunwayLogic();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTemporaryFeat"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feat"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddTemporaryFeat))]
    public BuffConfigurator AddTemporaryFeat(
        string feat = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddTemporaryFeat();
      component.m_Feat = BlueprintTool.GetRef<BlueprintFeatureReference>(feat);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTricksterAthleticBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddTricksterAthleticBonus))]
    public BuffConfigurator AddTricksterAthleticBonus(
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddTricksterAthleticBonus();
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddWeaponEnhancementBonusToStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddWeaponEnhancementBonusToStat))]
    public BuffConfigurator AddWeaponEnhancementBonusToStat(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int multiplier = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddWeaponEnhancementBonusToStat();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Multiplier = multiplier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffEnchantAnyWeapon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantmentBlueprint"><see cref="BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(BuffEnchantAnyWeapon))]
    public BuffConfigurator AddBuffEnchantAnyWeapon(
        string enchantmentBlueprint = null,
        EquipSlotBase.SlotType slot = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffEnchantAnyWeapon();
      component.m_EnchantmentBlueprint = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(enchantmentBlueprint);
      component.Slot = slot;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffEnchantSpecificWeaponWorn"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantmentBlueprint"><see cref="BlueprintItemEnchantment"/></param>
    /// <param name="weaponBlueprint"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(BuffEnchantSpecificWeaponWorn))]
    public BuffConfigurator AddBuffEnchantSpecificWeaponWorn(
        string enchantmentBlueprint = null,
        string weaponBlueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffEnchantSpecificWeaponWorn();
      component.m_EnchantmentBlueprint = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(enchantmentBlueprint);
      component.m_WeaponBlueprint = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weaponBlueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffEnchantWornItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantmentBlueprint"><see cref="BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(BuffEnchantWornItem))]
    public BuffConfigurator AddBuffEnchantWornItem(
        string enchantmentBlueprint = null,
        bool allWeapons = default,
        EquipSlotBase.SlotType slot = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffEnchantWornItem();
      component.m_EnchantmentBlueprint = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(enchantmentBlueprint);
      component.AllWeapons = allWeapons;
      component.Slot = slot;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Bugurt"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Bugurt))]
    public BuffConfigurator AddBugurt(
        BlueprintComponent.Flags flags = default)
    {
      var component = new Bugurt();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CompleteDamageImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CompleteDamageImmunity))]
    public BuffConfigurator AddCompleteDamageImmunity(
        BlueprintComponent.Flags flags = default)
    {
      var component = new CompleteDamageImmunity();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DropLootAndDestroyOnDeactivate"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DropLootAndDestroyOnDeactivate))]
    public BuffConfigurator AddDropLootAndDestroyOnDeactivate(
        IDisposable coroutine,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(coroutine);
    
      var component = new DropLootAndDestroyOnDeactivate();
      component.m_Coroutine = coroutine;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreIncommingDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreIncommingDamage))]
    public BuffConfigurator AddIgnoreIncommingDamage(
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreIncommingDamage();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LimbsApartDismembermentRestricted"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LimbsApartDismembermentRestricted))]
    public BuffConfigurator AddLimbsApartDismembermentRestricted(
        BlueprintComponent.Flags flags = default)
    {
      var component = new LimbsApartDismembermentRestricted();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MountedShield"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MountedShield))]
    public BuffConfigurator AddMountedShield(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MountedShield();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RedirectDamageToPet"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RedirectDamageToPet))]
    public BuffConfigurator AddRedirectDamageToPet(
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
    /// Adds <see cref="RemoveBuffIfPartyNotInCombat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveBuffIfPartyNotInCombat))]
    public BuffConfigurator AddRemoveBuffIfPartyNotInCombat(
        BlueprintComponent.Flags flags = default)
    {
      var component = new RemoveBuffIfPartyNotInCombat();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SetMagusFeatureActive"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetMagusFeatureActive))]
    public BuffConfigurator AddSetMagusFeatureActive(
        SetMagusFeatureActive.FeatureType feature = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SetMagusFeatureActive();
      component.m_Feature = feature;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShroudOfWater"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="upgradeFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ShroudOfWater))]
    public BuffConfigurator AddShroudOfWater(
        ContextValue baseValue,
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        string upgradeFeature = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(baseValue);
    
      var component = new ShroudOfWater();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.BaseValue = baseValue;
      component.m_UpgradeFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(upgradeFeature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellResistanceAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpellResistanceAgainstAlignment))]
    public BuffConfigurator AddSpellResistanceAgainstAlignment(
        ContextValue value,
        AlignmentComponent alignment = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new SpellResistanceAgainstAlignment();
      component.Value = value;
      component.Alignment = alignment;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellResistanceAgainstSpellDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpellResistanceAgainstSpellDescriptor))]
    public BuffConfigurator AddSpellResistanceAgainstSpellDescriptor(
        ContextValue value,
        SpellDescriptorWrapper spellDescriptor,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new SpellResistanceAgainstSpellDescriptor();
      component.Value = value;
      component.SpellDescriptor = spellDescriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UniqueBuff"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UniqueBuff))]
    public BuffConfigurator AddUniqueBuff(
        BlueprintComponent.Flags flags = default)
    {
      var component = new UniqueBuff();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistBlade"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blade"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(AddKineticistBlade))]
    public BuffConfigurator AddKineticistBlade(
        string blade = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddKineticistBlade();
      component.m_Blade = BlueprintTool.GetRef<BlueprintItemWeaponReference>(blade);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Polymorph"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="replaceUnitForInspection"><see cref="BlueprintUnit"/></param>
    /// <param name="portrait"><see cref="BlueprintPortrait"/></param>
    /// <param name="mainHand"><see cref="BlueprintItemWeapon"/></param>
    /// <param name="offHand"><see cref="BlueprintItemWeapon"/></param>
    /// <param name="additionalLimbs"><see cref="BlueprintItemWeapon"/></param>
    /// <param name="secondaryAdditionalLimbs"><see cref="BlueprintItemWeapon"/></param>
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(Polymorph))]
    public BuffConfigurator AddPolymorph(
        UnitViewLink prefab,
        UnitViewLink prefabFemale,
        Polymorph.VisualTransitionSettings enterTransition,
        Polymorph.VisualTransitionSettings exitTransition,
        PolymorphTransitionSettings transitionExternal,
        SpecialDollType specialDollType = default,
        string replaceUnitForInspection = null,
        string portrait = null,
        bool keepSlots = default,
        Size size = default,
        int strengthBonus = default,
        int dexterityBonus = default,
        int constitutionBonus = default,
        int naturalArmor = default,
        string mainHand = null,
        string offHand = null,
        string[] additionalLimbs = null,
        string[] secondaryAdditionalLimbs = null,
        string[] facts = null,
        bool silentCaster = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(prefab);
      ValidateParam(prefabFemale);
      ValidateParam(enterTransition);
      ValidateParam(exitTransition);
      ValidateParam(transitionExternal);
    
      var component = new Polymorph();
      component.m_Prefab = prefab;
      component.m_PrefabFemale = prefabFemale;
      component.m_SpecialDollType = specialDollType;
      component.m_ReplaceUnitForInspection = BlueprintTool.GetRef<BlueprintUnitReference>(replaceUnitForInspection);
      component.m_Portrait = BlueprintTool.GetRef<BlueprintPortraitReference>(portrait);
      component.m_KeepSlots = keepSlots;
      component.Size = size;
      component.StrengthBonus = strengthBonus;
      component.DexterityBonus = dexterityBonus;
      component.ConstitutionBonus = constitutionBonus;
      component.NaturalArmor = naturalArmor;
      component.m_MainHand = BlueprintTool.GetRef<BlueprintItemWeaponReference>(mainHand);
      component.m_OffHand = BlueprintTool.GetRef<BlueprintItemWeaponReference>(offHand);
      component.m_AdditionalLimbs = additionalLimbs.Select(name => BlueprintTool.GetRef<BlueprintItemWeaponReference>(name)).ToArray();
      component.m_SecondaryAdditionalLimbs = secondaryAdditionalLimbs.Select(name => BlueprintTool.GetRef<BlueprintItemWeaponReference>(name)).ToArray();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_EnterTransition = enterTransition;
      component.m_ExitTransition = exitTransition;
      component.m_TransitionExternal = transitionExternal;
      component.m_SilentCaster = silentCaster;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffOnLoad"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveBuffOnLoad))]
    public BuffConfigurator AddRemoveBuffOnLoad(
        bool onlyFromParty = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RemoveBuffOnLoad();
      component.OnlyFromParty = onlyFromParty;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffOnTurnOn"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveBuffOnTurnOn))]
    public BuffConfigurator AddRemoveBuffOnTurnOn(
        bool onlyFromParty = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RemoveBuffOnTurnOn();
      component.OnlyFromParty = onlyFromParty;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAreaEffect"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="areaEffect"><see cref="BlueprintAbilityAreaEffect"/></param>
    [Generated]
    [Implements(typeof(AddAreaEffect))]
    public BuffConfigurator AddAreaEffect(
        string areaEffect = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddAreaEffect();
      component.m_AreaEffect = BlueprintTool.GetRef<BlueprintAbilityAreaEffectReference>(areaEffect);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddAttackBonus))]
    public BuffConfigurator AddAttackBonus(
        int bonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddAttackBonus();
      component.Bonus = bonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCheatDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddCheatDamageBonus))]
    public BuffConfigurator AddCheatDamageBonus(
        int bonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddCheatDamageBonus();
      component.Bonus = bonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddDispelMagicFailedTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddDispelMagicFailedTrigger))]
    public BuffConfigurator AddDispelMagicFailedTrigger(
        ActionList actionOnOwner,
        ActionList actionOnCaster,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(actionOnOwner);
      ValidateParam(actionOnCaster);
    
      var component = new AddDispelMagicFailedTrigger();
      component.ActionOnOwner = actionOnOwner;
      component.ActionOnCaster = actionOnCaster;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEffectContextFastHealing"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEffectContextFastHealing))]
    public BuffConfigurator AddEffectContextFastHealing(
        ContextValue bonus,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new AddEffectContextFastHealing();
      component.Bonus = bonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEffectProtectionFromElement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEffectProtectionFromElement))]
    public BuffConfigurator AddEffectProtectionFromElement(
        string element,
        int shieldCapacity = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddEffectProtectionFromElement();
      component.Element = element;
      component.ShieldCapacity = shieldCapacity;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEffectRegeneration"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEffectRegeneration))]
    public BuffConfigurator AddEffectRegeneration(
        int heal = default,
        bool unremovable = default,
        bool cancelByMagicWeapon = default,
        DamageEnergyType[] cancelDamageEnergyTypes = null,
        DamageAlignment[] cancelDamageAlignmentTypes = null,
        PhysicalDamageMaterial[] cancelDamageMaterials = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddEffectRegeneration();
      component.Heal = heal;
      component.Unremovable = unremovable;
      component.CancelByMagicWeapon = cancelByMagicWeapon;
      component.CancelDamageEnergyTypes = cancelDamageEnergyTypes;
      component.CancelDamageAlignmentTypes = cancelDamageAlignmentTypes;
      component.CancelDamageMaterials = cancelDamageMaterials;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddGenericStatBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddGenericStatBonus))]
    public BuffConfigurator AddGenericStatBonus(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddGenericStatBonus();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddMirrorImage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddMirrorImage))]
    public BuffConfigurator AddMirrorImage(
        ContextDiceValue count,
        int maxCount = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(count);
    
      var component = new AddMirrorImage();
      component.Count = count;
      component.MaxCount = maxCount;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellSchool"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSpellSchool))]
    public BuffConfigurator AddSpellSchool(
        SpellSchool school = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSpellSchool();
      component.School = school;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IsPositiveEffect"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsPositiveEffect))]
    public BuffConfigurator AddIsPositiveEffect(
        BlueprintComponent.Flags flags = default)
    {
      var component = new IsPositiveEffect();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NegativeLevelComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NegativeLevelComponent))]
    public BuffConfigurator AddNegativeLevelComponent(
        BlueprintComponent.Flags flags = default)
    {
      var component = new NegativeLevelComponent();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffIfCasterIsMissing"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveBuffIfCasterIsMissing))]
    public BuffConfigurator AddRemoveBuffIfCasterIsMissing(
        bool removeOnCasterDeath = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RemoveBuffIfCasterIsMissing();
      component.RemoveOnCasterDeath = removeOnCasterDeath;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ResurrectionLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ResurrectionLogic))]
    public BuffConfigurator AddResurrectionLogic(
        GameObject firstFx,
        GameObject secondFx,
        float firstFxDelay = default,
        float secondFxDelay = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(firstFx);
      ValidateParam(secondFx);
    
      var component = new ResurrectionLogic();
      component.FirstFx = firstFx;
      component.FirstFxDelay = firstFxDelay;
      component.SecondFx = secondFx;
      component.SecondFxDelay = secondFxDelay;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SetBuffOnsetDelay"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetBuffOnsetDelay))]
    public BuffConfigurator AddSetBuffOnsetDelay(
        ContextDurationValue delay,
        ActionList onStart,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(delay);
      ValidateParam(onStart);
    
      var component = new SetBuffOnsetDelay();
      component.Delay = delay;
      component.OnStart = onStart;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpecialAnimationState"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpecialAnimationState))]
    public BuffConfigurator AddSpecialAnimationState(
        UnitAnimationActionBuffState animation,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(animation);
    
      var component = new SpecialAnimationState();
      component.Animation = animation;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SummonedUnitBuff"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SummonedUnitBuff))]
    public BuffConfigurator AddSummonedUnitBuff(
        BlueprintComponent.Flags flags = default)
    {
      var component = new SummonedUnitBuff();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponAttackTypeDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponAttackTypeDamageBonus))]
    public BuffConfigurator AddWeaponAttackTypeDamageBonus(
        ContextValue value,
        WeaponRangeType type = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new WeaponAttackTypeDamageBonus();
      component.Type = type;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParams"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="customProperty"><see cref="BlueprintUnitProperty"/></param>
    [Generated]
    [Implements(typeof(ContextCalculateAbilityParams))]
    public BuffConfigurator AddContextCalculateAbilityParams(
        ContextValue casterLevel,
        ContextValue spellLevel,
        bool useKineticistMainStat = default,
        StatType statType = default,
        bool statTypeFromCustomProperty = default,
        string customProperty = null,
        bool replaceCasterLevel = default,
        bool replaceSpellLevel = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(casterLevel);
      ValidateParam(spellLevel);
    
      var component = new ContextCalculateAbilityParams();
      component.UseKineticistMainStat = useKineticistMainStat;
      component.StatType = statType;
      component.StatTypeFromCustomProperty = statTypeFromCustomProperty;
      component.m_CustomProperty = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(customProperty);
      component.ReplaceCasterLevel = replaceCasterLevel;
      component.CasterLevel = casterLevel;
      component.ReplaceSpellLevel = replaceSpellLevel;
      component.SpellLevel = spellLevel;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParamsBasedOnClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(ContextCalculateAbilityParamsBasedOnClass))]
    public BuffConfigurator AddContextCalculateAbilityParamsBasedOnClass(
        bool useKineticistMainStat = default,
        StatType statType = default,
        string characterClass = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ContextCalculateAbilityParamsBasedOnClass();
      component.UseKineticistMainStat = useKineticistMainStat;
      component.StatType = statType;
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateSharedValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextCalculateSharedValue))]
    public BuffConfigurator AddContextCalculateSharedValue(
        ContextDiceValue value,
        AbilitySharedValue valueType = default,
        double modifier = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new ContextCalculateSharedValue();
      component.ValueType = valueType;
      component.Value = value;
      component.Modifier = modifier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextSetAbilityParams"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextSetAbilityParams))]
    public BuffConfigurator AddContextSetAbilityParams(
        ContextValue dC,
        ContextValue casterLevel,
        ContextValue concentration,
        ContextValue spellLevel,
        bool add10ToDC = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(dC);
      ValidateParam(casterLevel);
      ValidateParam(concentration);
      ValidateParam(spellLevel);
    
      var component = new ContextSetAbilityParams();
      component.Add10ToDC = add10ToDC;
      component.DC = dC;
      component.CasterLevel = casterLevel;
      component.Concentration = concentration;
      component.SpellLevel = spellLevel;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityDifficultyLimitDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityDifficultyLimitDC))]
    public BuffConfigurator AddAbilityDifficultyLimitDC(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AbilityDifficultyLimitDC();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstTacticalOwner"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstTacticalOwner))]
    public BuffConfigurator AddAttackBonusAgainstTacticalOwner(
        TargetFilter targetFilter,
        ContextValue value,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(targetFilter);
      ValidateParam(value);
    
      var component = new AttackBonusAgainstTacticalOwner();
      component.m_TargetFilter = targetFilter;
      component.m_Value = value;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstTacticalTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstTacticalTarget))]
    public BuffConfigurator AddAttackBonusAgainstTacticalTarget(
        TargetFilter targetFilter,
        ContextValue value,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(targetFilter);
      ValidateParam(value);
    
      var component = new AttackBonusAgainstTacticalTarget();
      component.m_TargetFilter = targetFilter;
      component.m_Value = value;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstTacticalOwner"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageBonusAgainstTacticalOwner))]
    public BuffConfigurator AddDamageBonusAgainstTacticalOwner(
        TargetFilter targetFilter,
        ContextValue value,
        Kingmaker.UnitLogic.Mechanics.ValueType _valueType = default,
        int bonusPercentValue = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(targetFilter);
      ValidateParam(value);
    
      var component = new DamageBonusAgainstTacticalOwner();
      component.m_TargetFilter = targetFilter;
      component._valueType = _valueType;
      component.m_Value = value;
      component.m_BonusPercentValue = bonusPercentValue;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstTacticalTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageBonusAgainstTacticalTarget))]
    public BuffConfigurator AddDamageBonusAgainstTacticalTarget(
        TargetFilter targetFilter,
        ContextValue value,
        Kingmaker.UnitLogic.Mechanics.ValueType _valueType = default,
        int bonusPercentValue = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(targetFilter);
      ValidateParam(value);
    
      var component = new DamageBonusAgainstTacticalTarget();
      component.m_TargetFilter = targetFilter;
      component._valueType = _valueType;
      component.m_Value = value;
      component.m_BonusPercentValue = bonusPercentValue;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceSquadAbilities"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="newAbilities"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(ReplaceSquadAbilities))]
    public BuffConfigurator AddReplaceSquadAbilities(
        string[] newAbilities = null,
        bool forOneTurn = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceSquadAbilities();
      component.m_NewAbilities = newAbilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToList();
      component.m_ForOneTurn = forOneTurn;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatConfusion"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="aiAttackNearestAction"><see cref="BlueprintTacticalCombatAiAction"/></param>
    [Generated]
    [Implements(typeof(TacticalCombatConfusion))]
    public BuffConfigurator AddTacticalCombatConfusion(
        ActionList harmSelfAction,
        string aiAttackNearestAction = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(harmSelfAction);
    
      var component = new TacticalCombatConfusion();
      component.m_AiAttackNearestAction = BlueprintTool.GetRef<BlueprintTacticalCombatAiActionReference>(aiAttackNearestAction);
      component.m_HarmSelfAction = harmSelfAction;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalMoraleChanceModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalMoraleChanceModifier))]
    public BuffConfigurator AddTacticalMoraleChanceModifier(
        ContextValue positiveMoraleChancePercentDelta,
        ContextValue negativeMoraleChancePercentDelta,
        bool changePositiveMorale = default,
        bool changeNegativeMorale = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(positiveMoraleChancePercentDelta);
      ValidateParam(negativeMoraleChancePercentDelta);
    
      var component = new TacticalMoraleChanceModifier();
      component.m_ChangePositiveMorale = changePositiveMorale;
      component.m_PositiveMoraleChancePercentDelta = positiveMoraleChancePercentDelta;
      component.m_ChangeNegativeMorale = changeNegativeMorale;
      component.m_NegativeMoraleChancePercentDelta = negativeMoraleChancePercentDelta;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TargetingBlind"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TargetingBlind))]
    public BuffConfigurator AddTargetingBlind(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TargetingBlind();
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
    public BuffConfigurator AddActionsOnBuffApply(
        ActionList actions,
        string gainedFact = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(actions);
    
      var component = new ActionsOnBuffApply();
      component.m_GainedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(gainedFact);
      component.Actions = actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BodyguardACBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(BodyguardACBonus))]
    public BuffConfigurator AddBodyguardACBonus(
        ContextValue value,
        string checkBuff = null,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new BodyguardACBonus();
      component.m_CheckBuff = BlueprintTool.GetRef<BlueprintBuffReference>(checkBuff);
      component.Descriptor = descriptor;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffExtraEffects"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="extraEffectBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="exceptionFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(BuffExtraEffects))]
    public BuffConfigurator AddBuffExtraEffects(
        string checkedBuff = null,
        string extraEffectBuff = null,
        string exceptionFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffExtraEffects();
      component.m_CheckedBuff = BlueprintTool.GetRef<BlueprintBuffReference>(checkedBuff);
      component.m_ExtraEffectBuff = BlueprintTool.GetRef<BlueprintBuffReference>(extraEffectBuff);
      component.m_ExceptionFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(exceptionFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeathOnLevelStacks"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DeathOnLevelStacks))]
    public BuffConfigurator AddDeathOnLevelStacks(
        BlueprintComponent.Flags flags = default)
    {
      var component = new DeathOnLevelStacks();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="InHarmsWay"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="cooldownBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(InHarmsWay))]
    public BuffConfigurator AddInHarmsWay(
        string checkBuff = null,
        string cooldownBuff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new InHarmsWay();
      component.m_CheckBuff = BlueprintTool.GetRef<BlueprintBuffReference>(checkBuff);
      component.m_CooldownBuff = BlueprintTool.GetRef<BlueprintBuffReference>(cooldownBuff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IndomitableMount"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cooldownBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(IndomitableMount))]
    public BuffConfigurator AddIndomitableMount(
        string cooldownBuff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IndomitableMount();
      component.m_CooldownBuff = BlueprintTool.GetRef<BlueprintBuffReference>(cooldownBuff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MetamagicOnNextSpell"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MetamagicOnNextSpell))]
    public BuffConfigurator AddMetamagicOnNextSpell(
        Metamagic metamagic = default,
        bool doNotRemove = default,
        bool sourcerousReflex = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MetamagicOnNextSpell();
      component.Metamagic = metamagic;
      component.DoNotRemove = doNotRemove;
      component.SourcerousReflex = sourcerousReflex;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MetamagicRodMechanics"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="rodAbility"><see cref="BlueprintActivatableAbility"/></param>
    /// <param name="abilitiesWhiteList"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(MetamagicRodMechanics))]
    public BuffConfigurator AddMetamagicRodMechanics(
        Metamagic metamagic = default,
        int maxSpellLevel = default,
        string rodAbility = null,
        string[] abilitiesWhiteList = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MetamagicRodMechanics();
      component.Metamagic = metamagic;
      component.MaxSpellLevel = maxSpellLevel;
      component.m_RodAbility = BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(rodAbility);
      component.m_AbilitiesWhiteList = abilitiesWhiteList.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MountedCombat"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cooldownBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(MountedCombat))]
    public BuffConfigurator AddMountedCombat(
        string cooldownBuff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MountedCombat();
      component.m_CooldownBuff = BlueprintTool.GetRef<BlueprintBuffReference>(cooldownBuff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NeutralToFaction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="faction"><see cref="BlueprintFaction"/></param>
    [Generated]
    [Implements(typeof(NeutralToFaction))]
    public BuffConfigurator AddNeutralToFaction(
        string faction = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new NeutralToFaction();
      component.m_Faction = BlueprintTool.GetRef<BlueprintFactionReference>(faction);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpecificSpellDamageBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spell"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(SpecificSpellDamageBonus))]
    public BuffConfigurator AddSpecificSpellDamageBonus(
        string[] spell = null,
        int bonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpecificSpellDamageBonus();
      component.m_Spell = spell.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.Bonus = bonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnwillingShield"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="masterAbility"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(UnwillingShield))]
    public BuffConfigurator AddUnwillingShield(
        string masterAbility = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new UnwillingShield();
      component.m_MasterAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(masterAbility);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnwillingShieldTarget"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="masterAbility"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(UnwillingShieldTarget))]
    public BuffConfigurator AddUnwillingShieldTarget(
        string masterAbility = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new UnwillingShieldTarget();
      component.m_MasterAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(masterAbility);
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
    public BuffConfigurator AddImpatienceWatcherTickingResolve(
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
    /// Adds <see cref="ACBonusAgainstCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstCaster))]
    public BuffConfigurator AddACBonusAgainstCaster(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new ACBonusAgainstCaster();
      component.Value = value;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstTarget))]
    public BuffConfigurator AddACBonusAgainstTarget(
        ContextValue value,
        bool checkCaster = default,
        bool checkCasterFriend = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new ACBonusAgainstTarget();
      component.Value = value;
      component.CheckCaster = checkCaster;
      component.CheckCasterFriend = checkCasterFriend;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAdditionalLimbIfHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weapon"><see cref="BlueprintItemWeapon"/></param>
    /// <param name="checkedFact"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddAdditionalLimbIfHasFact))]
    public BuffConfigurator AddAdditionalLimbIfHasFact(
        string weapon = null,
        string checkedFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddAdditionalLimbIfHasFact();
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weapon);
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintFeatureReference>(checkedFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusAbilityValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddStatBonusAbilityValue))]
    public BuffConfigurator AddStatBonusAbilityValue(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new AddStatBonusAbilityValue();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusIfHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddStatBonusIfHasFact))]
    public BuffConfigurator AddStatBonusIfHasFact(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        bool invertCondition = default,
        bool requireAllFacts = default,
        string[] checkedFacts = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new AddStatBonusIfHasFact();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.InvertCondition = invertCondition;
      component.RequireAllFacts = requireAllFacts;
      component.m_CheckedFacts = checkedFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusIfHasSkill"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddStatBonusIfHasSkill))]
    public BuffConfigurator AddStatBonusIfHasSkill(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int valueTrue = default,
        int valueFalse = default,
        StatType checkedSkill = default,
        int skillValue = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddStatBonusIfHasSkill();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.ValueTrue = valueTrue;
      component.ValueFalse = valueFalse;
      component.CheckedSkill = checkedSkill;
      component.SkillValue = skillValue;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusScaled"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddStatBonusScaled))]
    public BuffConfigurator AddStatBonusScaled(
        BuffScaling scaling,
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(scaling);
    
      var component = new AddStatBonusScaled();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.Scaling = scaling;
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
    public BuffConfigurator AddAfterbuff(
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
    public BuffConfigurator AddAfterbuffIfHasFact(
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
    /// Adds <see cref="ApplyBuffOnHit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ApplyBuffOnHit))]
    public BuffConfigurator AddApplyBuffOnHit(
        Rounds time,
        string buff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ApplyBuffOnHit();
      component.m_buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.time = time;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmagsBladeEnrage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmagsBladeEnrage))]
    public BuffConfigurator AddArmagsBladeEnrage(
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArmagsBladeEnrage();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstCaster))]
    public BuffConfigurator AddAttackBonusAgainstCaster(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new AttackBonusAgainstCaster();
      component.Value = value;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstTarget))]
    public BuffConfigurator AddAttackBonusAgainstTarget(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        bool checkCaster = default,
        bool checkCasterFriend = default,
        bool checkRangeType = default,
        WeaponRangeType rangeType = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new AttackBonusAgainstTarget();
      component.Value = value;
      component.Descriptor = descriptor;
      component.CheckCaster = checkCaster;
      component.CheckCasterFriend = checkCasterFriend;
      component.CheckRangeType = checkRangeType;
      component.RangeType = rangeType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffAllSkillsBonusAbilityValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffAllSkillsBonusAbilityValue))]
    public BuffConfigurator AddBuffAllSkillsBonusAbilityValue(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new BuffAllSkillsBonusAbilityValue();
      component.Descriptor = descriptor;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffDamageEachRound"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffDamageEachRound))]
    public BuffConfigurator AddBuffDamageEachRound(
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
    /// Adds <see cref="BuffIncomingDamageIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffIncomingDamageIncrease))]
    public BuffConfigurator AddBuffIncomingDamageIncrease(
        ContextValue value,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new BuffIncomingDamageIncrease();
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffInvisibility"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffInvisibility))]
    public BuffConfigurator AddBuffInvisibility(
        ContextValue chance,
        bool notDispellAfterOffensiveAction = default,
        int stealthBonus = default,
        bool dispelWithAChance = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(chance);
    
      var component = new BuffInvisibility();
      component.NotDispellAfterOffensiveAction = notDispellAfterOffensiveAction;
      component.m_StealthBonus = stealthBonus;
      component.DispelWithAChance = dispelWithAChance;
      component.Chance = chance;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffParticleEffectPlay"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffParticleEffectPlay))]
    public BuffConfigurator AddBuffParticleEffectPlay(
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
    public BuffConfigurator AddBuffPerceptionBonus(
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffPerceptionBonus();
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffPoisonStatDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffPoisonStatDamage))]
    public BuffConfigurator AddBuffPoisonStatDamage(
        DiceFormula value,
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int bonus = default,
        int ticks = default,
        int succesfullSaves = default,
        SavingThrowType saveType = default,
        bool noEffectOnFirstTick = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffPoisonStatDamage();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.Bonus = bonus;
      component.Ticks = ticks;
      component.SuccesfullSaves = succesfullSaves;
      component.SaveType = saveType;
      component.NoEffectOnFirstTick = noEffectOnFirstTick;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffPoisonStatDamageContext"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffPoisonStatDamageContext))]
    public BuffConfigurator AddBuffPoisonStatDamageContext(
        ContextDiceValue value,
        ContextValue bonus,
        ContextValue ticks,
        ContextValue succesfullSaves,
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        SavingThrowType saveType = default,
        bool noEffectOnFirstTick = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
      ValidateParam(bonus);
      ValidateParam(ticks);
      ValidateParam(succesfullSaves);
    
      var component = new BuffPoisonStatDamageContext();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.Bonus = bonus;
      component.Ticks = ticks;
      component.SuccesfullSaves = succesfullSaves;
      component.SaveType = saveType;
      component.NoEffectOnFirstTick = noEffectOnFirstTick;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSaveEachRound"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffSaveEachRound))]
    public BuffConfigurator AddBuffSaveEachRound(
        ActionList actionsOnPass,
        ActionList actionsOnFail,
        SavingThrowType saveType = default,
        int saveDC = default,
        int increaseDC = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(actionsOnPass);
      ValidateParam(actionsOnFail);
    
      var component = new BuffSaveEachRound();
      component.SaveType = saveType;
      component.SaveDC = saveDC;
      component.IncreaseDC = increaseDC;
      component.ActionsOnPass = actionsOnPass;
      component.ActionsOnFail = actionsOnFail;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSaveOrDieEachRound"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffSaveOrDieEachRound))]
    public BuffConfigurator AddBuffSaveOrDieEachRound(
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
    /// Adds <see cref="BuffStatPenaltyDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffStatPenaltyDice))]
    public BuffConfigurator AddBuffStatPenaltyDice(
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
    public BuffConfigurator AddBuffStatusCondition(
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
    /// Adds <see cref="ControlledProjectileHolder"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ControlledProjectileHolder))]
    public BuffConfigurator AddControlledProjectileHolder(
        BlueprintComponent.Flags flags = default)
    {
      var component = new ControlledProjectileHolder();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageBonusAgainstTarget))]
    public BuffConfigurator AddDamageBonusAgainstTarget(
        ContextValue value,
        bool checkCaster = default,
        bool checkCasterFriend = default,
        bool applyToSpellDamage = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new DamageBonusAgainstTarget();
      component.Value = value;
      component.CheckCaster = checkCaster;
      component.CheckCasterFriend = checkCasterFriend;
      component.ApplyToSpellDamage = applyToSpellDamage;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageOnRemove"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageOnRemove))]
    public BuffConfigurator AddDamageOnRemove(
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
    public BuffConfigurator AddDamageOverTime(
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
    /// Adds <see cref="EqualForce"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EqualForce))]
    public BuffConfigurator AddEqualForce(
        BlueprintComponent.Flags flags = default)
    {
      var component = new EqualForce();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="GreaterSnapShotBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GreaterSnapShotBonus))]
    public BuffConfigurator AddGreaterSnapShotBonus(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new GreaterSnapShotBonus();
      component.Value = value;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HealOverTime"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HealOverTime))]
    public BuffConfigurator AddHealOverTime(
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
    public BuffConfigurator AddHealOverTimeIfHasFact(
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
    /// Adds <see cref="IgnoreTargetDR"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreTargetDR))]
    public BuffConfigurator AddIgnoreTargetDR(
        bool checkCaster = default,
        bool checkCasterFriend = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreTargetDR();
      component.CheckCaster = checkCaster;
      component.CheckCasterFriend = checkCasterFriend;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OverrideLocoMotion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OverrideLocoMotion))]
    public BuffConfigurator AddOverrideLocoMotion(
        UnitAnimationActionLocoMotion locoMotion,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(locoMotion);
    
      var component = new OverrideLocoMotion();
      component.LocoMotion = locoMotion;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ProtectionFromEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ProtectionFromEnergy))]
    public BuffConfigurator AddProtectionFromEnergy(
        ContextValue valueMultiplier,
        ContextValue value,
        ContextValue pool,
        DamageEnergyType type = default,
        bool useValueMultiplier = default,
        bool usePool = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(valueMultiplier);
      ValidateParam(value);
      ValidateParam(pool);
    
      var component = new ProtectionFromEnergy();
      component.Type = type;
      component.UseValueMultiplier = useValueMultiplier;
      component.ValueMultiplier = valueMultiplier;
      component.Value = value;
      component.UsePool = usePool;
      component.Pool = pool;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemovedByHeal"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemovedByHeal))]
    public BuffConfigurator AddRemovedByHeal(
        BlueprintComponent.Flags flags = default)
    {
      var component = new RemovedByHeal();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ResistEnergyContext"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ResistEnergyContext))]
    public BuffConfigurator AddResistEnergyContext(
        ContextValue valueMultiplier,
        ContextValue value,
        ContextValue pool,
        DamageEnergyType type = default,
        bool useValueMultiplier = default,
        bool usePool = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(valueMultiplier);
      ValidateParam(value);
      ValidateParam(pool);
    
      var component = new ResistEnergyContext();
      component.Type = type;
      component.UseValueMultiplier = useValueMultiplier;
      component.ValueMultiplier = valueMultiplier;
      component.Value = value;
      component.UsePool = usePool;
      component.Pool = pool;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SaveSuccessIfBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SaveSuccessIfBonus))]
    public BuffConfigurator AddSaveSuccessIfBonus(
        ContextValue value,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new SaveSuccessIfBonus();
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SkillSuccessIfBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SkillSuccessIfBonus))]
    public BuffConfigurator AddSkillSuccessIfBonus(
        ContextValue value,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new SkillSuccessIfBonus();
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsConstitutionBased"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TemporaryHitPointsConstitutionBased))]
    public BuffConfigurator AddTemporaryHitPointsConstitutionBased(
        ContextValue value,
        int bonusMultiplier = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new TemporaryHitPointsConstitutionBased();
      component.Value = value;
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
    public BuffConfigurator AddTemporaryHitPointsEqualCasterLevel(
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
    public BuffConfigurator AddTemporaryHitPointsFromAbilityValue(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        bool removeWhenHitPointsEnd = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new TemporaryHitPointsFromAbilityValue();
      component.Descriptor = descriptor;
      component.Value = value;
      component.RemoveWhenHitPointsEnd = removeWhenHitPointsEnd;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsRandom"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TemporaryHitPointsRandom))]
    public BuffConfigurator AddTemporaryHitPointsRandom(
        DiceFormula dice,
        ContextValue bonus,
        ModifierDescriptor descriptor = default,
        bool scaleBonusByCasterLevel = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new TemporaryHitPointsRandom();
      component.Descriptor = descriptor;
      component.Dice = dice;
      component.Bonus = bonus;
      component.ScaleBonusByCasterLevel = scaleBonusByCasterLevel;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    protected override void ConfigureInternal()
    {
      base.ConfigureInternal();

      if (EnableFlags > 0) { Blueprint.m_Flags |= EnableFlags; }
      if (DisableFlags > 0) { Blueprint.m_Flags &= ~DisableFlags; }
    }

    protected override void ValidateInternal()
    {
      base.ValidateInternal();

      if (Blueprint.GetComponent<ITickEachRound>() == null)
      {
        AddValidationWarning($"ITickEachRound component is missing. Frequency and TickEachSecond will be ignored.");
      }
    }
  }
}
