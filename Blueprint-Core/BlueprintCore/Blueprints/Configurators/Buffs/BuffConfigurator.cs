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
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Armors;
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
    /// Adds <see cref="CorruptionProtection"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CorruptionProtection))]
    public BuffConfigurator AddCorruptionProtection(
        bool m_RemoveRankAfterRest)
    {
      
      var component =  new CorruptionProtection();
      component.m_RemoveRankAfterRest = m_RemoveRankAfterRest;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="GlobalMapSpeedModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GlobalMapSpeedModifier))]
    public BuffConfigurator AddGlobalMapSpeedModifier(
        float SpeedModifier)
    {
      
      var component =  new GlobalMapSpeedModifier();
      component.SpeedModifier = SpeedModifier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBuffInBadWeather"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AddBuffInBadWeather))]
    public BuffConfigurator AddAddBuffInBadWeather(
        string m_Buff,
        InclemencyType Weather,
        bool WhenCalmer)
    {
      ValidateParam(Weather);
      
      var component =  new AddBuffInBadWeather();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      component.Weather = Weather;
      component.WhenCalmer = WhenCalmer;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBuffOnApplyingSpell"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddBuffOnApplyingSpell))]
    public BuffConfigurator AddAddBuffOnApplyingSpell(
        bool OnEffectApplied,
        bool OnResistSpell,
        AddBuffOnApplyingSpell.SpellConditionAndBuff[] Buffs)
    {
      foreach (var item in Buffs)
      {
        ValidateParam(item);
      }
      
      var component =  new AddBuffOnApplyingSpell();
      component.OnEffectApplied = OnEffectApplied;
      component.OnResistSpell = OnResistSpell;
      component.Buffs = Buffs;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddClusteredAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddClusteredAttack))]
    public BuffConfigurator AddAddClusteredAttack(
        AddClusteredAttack.Type AttackType)
    {
      ValidateParam(AttackType);
      
      var component =  new AddClusteredAttack();
      component.AttackType = AttackType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddContextStatBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddContextStatBonus))]
    public BuffConfigurator AddAddContextStatBonus(
        ModifierDescriptor Descriptor,
        StatType Stat,
        int Multiplier,
        ContextValue Value,
        bool HasMinimal,
        int Minimal)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      ValidateParam(Value);
      
      var component =  new AddContextStatBonus();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.Multiplier = Multiplier;
      component.Value = Value;
      component.HasMinimal = HasMinimal;
      component.Minimal = Minimal;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCumulativeDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddCumulativeDamageBonus))]
    public BuffConfigurator AddAddCumulativeDamageBonus(
        bool OnlyNaturalAttacks)
    {
      
      var component =  new AddCumulativeDamageBonus();
      component.OnlyNaturalAttacks = OnlyNaturalAttacks;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCumulativeDamageBonusX3"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddCumulativeDamageBonusX3))]
    public BuffConfigurator AddAddCumulativeDamageBonusX3(
        bool OnlyNaturalAttacks)
    {
      
      var component =  new AddCumulativeDamageBonusX3();
      component.OnlyNaturalAttacks = OnlyNaturalAttacks;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddDamageTypeVulnerability"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddDamageTypeVulnerability))]
    public BuffConfigurator AddAddDamageTypeVulnerability(
        bool PhyscicalForm,
        PhysicalDamageForm FormType,
        bool PhyscicalAlignment,
        DamageAlignment DamageAlignmentType,
        bool PhyscicalMaterial,
        PhysicalDamageMaterial MaterialType)
    {
      ValidateParam(FormType);
      ValidateParam(DamageAlignmentType);
      ValidateParam(MaterialType);
      
      var component =  new AddDamageTypeVulnerability();
      component.PhyscicalForm = PhyscicalForm;
      component.FormType = FormType;
      component.PhyscicalAlignment = PhyscicalAlignment;
      component.DamageAlignmentType = DamageAlignmentType;
      component.PhyscicalMaterial = PhyscicalMaterial;
      component.MaterialType = MaterialType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEnergyDamageImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEnergyDamageImmunity))]
    public BuffConfigurator AddAddEnergyDamageImmunity(
        DamageEnergyType EnergyType,
        bool HealOnDamage,
        AddEnergyDamageImmunity.HealingRate m_HealRate)
    {
      ValidateParam(EnergyType);
      ValidateParam(m_HealRate);
      
      var component =  new AddEnergyDamageImmunity();
      component.EnergyType = EnergyType;
      component.HealOnDamage = HealOnDamage;
      component.m_HealRate = m_HealRate;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEnergyImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEnergyImmunity))]
    public BuffConfigurator AddAddEnergyImmunity(
        DamageEnergyType Type)
    {
      ValidateParam(Type);
      
      var component =  new AddEnergyImmunity();
      component.Type = Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEnergyVulnerability"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEnergyVulnerability))]
    public BuffConfigurator AddAddEnergyVulnerability(
        DamageEnergyType Type)
    {
      ValidateParam(Type);
      
      var component =  new AddEnergyVulnerability();
      component.Type = Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFactsFromCaster"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Facts"><see cref="BlueprintUnitFact"/></param>
    /// <param name="m_Selection"><see cref="BlueprintFeatureSelection"/></param>
    [Generated]
    [Implements(typeof(AddFactsFromCaster))]
    public BuffConfigurator AddAddFactsFromCaster(
        string[] m_Facts,
        bool FeatureFromSelection,
        string m_Selection)
    {
      
      var component =  new AddFactsFromCaster();
      component.m_Facts = m_Facts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.FeatureFromSelection = FeatureFromSelection;
      component.m_Selection = BlueprintTool.GetRef<BlueprintFeatureSelectionReference>(m_Selection);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddForceMove"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddForceMove))]
    public BuffConfigurator AddAddForceMove(
        ContextValue FeetPerRound)
    {
      ValidateParam(FeetPerRound);
      
      var component =  new AddForceMove();
      component.FeetPerRound = FeetPerRound;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddGoldenDragonSkillBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddGoldenDragonSkillBonus))]
    public BuffConfigurator AddAddGoldenDragonSkillBonus(
        ModifierDescriptor Descriptor,
        StatType Stat)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      
      var component =  new AddGoldenDragonSkillBonus();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddIncomingDamageWeaponProperty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_WeaponType"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(AddIncomingDamageWeaponProperty))]
    public BuffConfigurator AddAddIncomingDamageWeaponProperty(
        bool AddMagic,
        bool AddMaterial,
        PhysicalDamageMaterial Material,
        bool AddForm,
        PhysicalDamageForm Form,
        bool AddAlignment,
        DamageAlignment Alignment,
        bool AddReality,
        DamageRealityType Reality,
        bool CheckWeaponType,
        string m_WeaponType,
        bool CheckRange,
        bool IsRanged)
    {
      ValidateParam(Material);
      ValidateParam(Form);
      ValidateParam(Alignment);
      ValidateParam(Reality);
      
      var component =  new AddIncomingDamageWeaponProperty();
      component.AddMagic = AddMagic;
      component.AddMaterial = AddMaterial;
      component.Material = Material;
      component.AddForm = AddForm;
      component.Form = Form;
      component.AddAlignment = AddAlignment;
      component.Alignment = Alignment;
      component.AddReality = AddReality;
      component.Reality = Reality;
      component.CheckWeaponType = CheckWeaponType;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(m_WeaponType);
      component.CheckRange = CheckRange;
      component.IsRanged = IsRanged;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddNocticulaBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddNocticulaBonus))]
    public BuffConfigurator AddAddNocticulaBonus(
        ModifierDescriptor Descriptor,
        ContextValue HighestStatBonus,
        StatType m_HighestStat,
        ContextValue SecondHighestStatBonus,
        StatType m_SecondHighestStat)
    {
      ValidateParam(Descriptor);
      ValidateParam(HighestStatBonus);
      ValidateParam(m_HighestStat);
      ValidateParam(SecondHighestStatBonus);
      ValidateParam(m_SecondHighestStat);
      
      var component =  new AddNocticulaBonus();
      component.Descriptor = Descriptor;
      component.HighestStatBonus = HighestStatBonus;
      component.m_HighestStat = m_HighestStat;
      component.SecondHighestStatBonus = SecondHighestStatBonus;
      component.m_SecondHighestStat = m_SecondHighestStat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddOutgoingPhysicalDamageProperty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_WeaponType"><see cref="BlueprintWeaponType"/></param>
    /// <param name="m_UnitFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddOutgoingPhysicalDamageProperty))]
    public BuffConfigurator AddAddOutgoingPhysicalDamageProperty(
        bool AffectAnyPhysicalDamage,
        bool NaturalAttacks,
        bool AddMagic,
        bool AddMaterial,
        PhysicalDamageMaterial Material,
        bool AddForm,
        PhysicalDamageForm Form,
        bool AddAlignment,
        DamageAlignment Alignment,
        bool MyAlignment,
        bool AddReality,
        DamageRealityType Reality,
        bool CheckWeaponType,
        string m_WeaponType,
        bool CheckRange,
        bool IsRanged,
        bool AgainstFactOwner,
        string m_UnitFact)
    {
      ValidateParam(Material);
      ValidateParam(Form);
      ValidateParam(Alignment);
      ValidateParam(Reality);
      
      var component =  new AddOutgoingPhysicalDamageProperty();
      component.AffectAnyPhysicalDamage = AffectAnyPhysicalDamage;
      component.NaturalAttacks = NaturalAttacks;
      component.AddMagic = AddMagic;
      component.AddMaterial = AddMaterial;
      component.Material = Material;
      component.AddForm = AddForm;
      component.Form = Form;
      component.AddAlignment = AddAlignment;
      component.Alignment = Alignment;
      component.MyAlignment = MyAlignment;
      component.AddReality = AddReality;
      component.Reality = Reality;
      component.CheckWeaponType = CheckWeaponType;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(m_WeaponType);
      component.CheckRange = CheckRange;
      component.IsRanged = IsRanged;
      component.AgainstFactOwner = AgainstFactOwner;
      component.m_UnitFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_UnitFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddPhysicalImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddPhysicalImmunity))]
    public BuffConfigurator AddAddPhysicalImmunity()
    {
      return AddComponent(new AddPhysicalImmunity());
    }

    /// <summary>
    /// Adds <see cref="AddRestTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddRestTrigger))]
    public BuffConfigurator AddAddRestTrigger(
        ActionsBuilder Action)
    {
      
      var component =  new AddRestTrigger();
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddRunwayLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddRunwayLogic))]
    public BuffConfigurator AddAddRunwayLogic()
    {
      return AddComponent(new AddRunwayLogic());
    }

    /// <summary>
    /// Adds <see cref="AddTemporaryFeat"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Feat"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddTemporaryFeat))]
    public BuffConfigurator AddAddTemporaryFeat(
        string m_Feat)
    {
      
      var component =  new AddTemporaryFeat();
      component.m_Feat = BlueprintTool.GetRef<BlueprintFeatureReference>(m_Feat);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTricksterAthleticBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddTricksterAthleticBonus))]
    public BuffConfigurator AddAddTricksterAthleticBonus(
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Descriptor);
      
      var component =  new AddTricksterAthleticBonus();
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddWeaponEnhancementBonusToStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddWeaponEnhancementBonusToStat))]
    public BuffConfigurator AddAddWeaponEnhancementBonusToStat(
        ModifierDescriptor Descriptor,
        StatType Stat,
        int Multiplier)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      
      var component =  new AddWeaponEnhancementBonusToStat();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.Multiplier = Multiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffEnchantAnyWeapon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_EnchantmentBlueprint"><see cref="BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(BuffEnchantAnyWeapon))]
    public BuffConfigurator AddBuffEnchantAnyWeapon(
        string m_EnchantmentBlueprint,
        EquipSlotBase.SlotType Slot)
    {
      ValidateParam(Slot);
      
      var component =  new BuffEnchantAnyWeapon();
      component.m_EnchantmentBlueprint = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(m_EnchantmentBlueprint);
      component.Slot = Slot;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffEnchantSpecificWeaponWorn"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_EnchantmentBlueprint"><see cref="BlueprintItemEnchantment"/></param>
    /// <param name="m_WeaponBlueprint"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(BuffEnchantSpecificWeaponWorn))]
    public BuffConfigurator AddBuffEnchantSpecificWeaponWorn(
        string m_EnchantmentBlueprint,
        string m_WeaponBlueprint)
    {
      
      var component =  new BuffEnchantSpecificWeaponWorn();
      component.m_EnchantmentBlueprint = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(m_EnchantmentBlueprint);
      component.m_WeaponBlueprint = BlueprintTool.GetRef<BlueprintItemWeaponReference>(m_WeaponBlueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffEnchantWornItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_EnchantmentBlueprint"><see cref="BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(BuffEnchantWornItem))]
    public BuffConfigurator AddBuffEnchantWornItem(
        string m_EnchantmentBlueprint,
        bool AllWeapons,
        EquipSlotBase.SlotType Slot)
    {
      ValidateParam(Slot);
      
      var component =  new BuffEnchantWornItem();
      component.m_EnchantmentBlueprint = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(m_EnchantmentBlueprint);
      component.AllWeapons = AllWeapons;
      component.Slot = Slot;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Bugurt"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Bugurt))]
    public BuffConfigurator AddBugurt()
    {
      return AddComponent(new Bugurt());
    }

    /// <summary>
    /// Adds <see cref="CompleteDamageImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CompleteDamageImmunity))]
    public BuffConfigurator AddCompleteDamageImmunity()
    {
      return AddComponent(new CompleteDamageImmunity());
    }

    /// <summary>
    /// Adds <see cref="DropLootAndDestroyOnDeactivate"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DropLootAndDestroyOnDeactivate))]
    public BuffConfigurator AddDropLootAndDestroyOnDeactivate(
        IDisposable m_Coroutine)
    {
      ValidateParam(m_Coroutine);
      
      var component =  new DropLootAndDestroyOnDeactivate();
      component.m_Coroutine = m_Coroutine;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreIncommingDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreIncommingDamage))]
    public BuffConfigurator AddIgnoreIncommingDamage()
    {
      return AddComponent(new IgnoreIncommingDamage());
    }

    /// <summary>
    /// Adds <see cref="LimbsApartDismembermentRestricted"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LimbsApartDismembermentRestricted))]
    public BuffConfigurator AddLimbsApartDismembermentRestricted()
    {
      return AddComponent(new LimbsApartDismembermentRestricted());
    }

    /// <summary>
    /// Adds <see cref="MountedShield"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MountedShield))]
    public BuffConfigurator AddMountedShield(
        ModifierDescriptor Descriptor,
        StatType Stat)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      
      var component =  new MountedShield();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RedirectDamageToPet"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RedirectDamageToPet))]
    public BuffConfigurator AddRedirectDamageToPet(
        int m_PercentRedirected,
        PetType m_PetType)
    {
      ValidateParam(m_PetType);
      
      var component =  new RedirectDamageToPet();
      component.m_PercentRedirected = m_PercentRedirected;
      component.m_PetType = m_PetType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffIfPartyNotInCombat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveBuffIfPartyNotInCombat))]
    public BuffConfigurator AddRemoveBuffIfPartyNotInCombat()
    {
      return AddComponent(new RemoveBuffIfPartyNotInCombat());
    }

    /// <summary>
    /// Adds <see cref="SetMagusFeatureActive"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetMagusFeatureActive))]
    public BuffConfigurator AddSetMagusFeatureActive(
        SetMagusFeatureActive.FeatureType m_Feature)
    {
      ValidateParam(m_Feature);
      
      var component =  new SetMagusFeatureActive();
      component.m_Feature = m_Feature;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShroudOfWater"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_UpgradeFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ShroudOfWater))]
    public BuffConfigurator AddShroudOfWater(
        ModifierDescriptor Descriptor,
        StatType Stat,
        ContextValue BaseValue,
        string m_UpgradeFeature)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      ValidateParam(BaseValue);
      
      var component =  new ShroudOfWater();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.BaseValue = BaseValue;
      component.m_UpgradeFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_UpgradeFeature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellResistanceAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpellResistanceAgainstAlignment))]
    public BuffConfigurator AddSpellResistanceAgainstAlignment(
        ContextValue Value,
        AlignmentComponent Alignment)
    {
      ValidateParam(Value);
      ValidateParam(Alignment);
      
      var component =  new SpellResistanceAgainstAlignment();
      component.Value = Value;
      component.Alignment = Alignment;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellResistanceAgainstSpellDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpellResistanceAgainstSpellDescriptor))]
    public BuffConfigurator AddSpellResistanceAgainstSpellDescriptor(
        ContextValue Value,
        SpellDescriptorWrapper SpellDescriptor)
    {
      ValidateParam(Value);
      ValidateParam(SpellDescriptor);
      
      var component =  new SpellResistanceAgainstSpellDescriptor();
      component.Value = Value;
      component.SpellDescriptor = SpellDescriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UniqueBuff"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UniqueBuff))]
    public BuffConfigurator AddUniqueBuff()
    {
      return AddComponent(new UniqueBuff());
    }

    /// <summary>
    /// Adds <see cref="AddKineticistBlade"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Blade"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(AddKineticistBlade))]
    public BuffConfigurator AddAddKineticistBlade(
        string m_Blade)
    {
      
      var component =  new AddKineticistBlade();
      component.m_Blade = BlueprintTool.GetRef<BlueprintItemWeaponReference>(m_Blade);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Polymorph"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_ReplaceUnitForInspection"><see cref="BlueprintUnit"/></param>
    /// <param name="m_Portrait"><see cref="BlueprintPortrait"/></param>
    /// <param name="m_MainHand"><see cref="BlueprintItemWeapon"/></param>
    /// <param name="m_OffHand"><see cref="BlueprintItemWeapon"/></param>
    /// <param name="m_AdditionalLimbs"><see cref="BlueprintItemWeapon"/></param>
    /// <param name="m_SecondaryAdditionalLimbs"><see cref="BlueprintItemWeapon"/></param>
    /// <param name="m_Facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(Polymorph))]
    public BuffConfigurator AddPolymorph(
        UnitViewLink m_Prefab,
        UnitViewLink m_PrefabFemale,
        SpecialDollType m_SpecialDollType,
        string m_ReplaceUnitForInspection,
        string m_Portrait,
        bool m_KeepSlots,
        Size Size,
        int StrengthBonus,
        int DexterityBonus,
        int ConstitutionBonus,
        int NaturalArmor,
        string m_MainHand,
        string m_OffHand,
        string[] m_AdditionalLimbs,
        string[] m_SecondaryAdditionalLimbs,
        string[] m_Facts,
        Polymorph.VisualTransitionSettings m_EnterTransition,
        Polymorph.VisualTransitionSettings m_ExitTransition,
        PolymorphTransitionSettings m_TransitionExternal,
        bool m_SilentCaster)
    {
      ValidateParam(m_Prefab);
      ValidateParam(m_PrefabFemale);
      ValidateParam(m_SpecialDollType);
      ValidateParam(Size);
      ValidateParam(m_EnterTransition);
      ValidateParam(m_ExitTransition);
      ValidateParam(m_TransitionExternal);
      
      var component =  new Polymorph();
      component.m_Prefab = m_Prefab;
      component.m_PrefabFemale = m_PrefabFemale;
      component.m_SpecialDollType = m_SpecialDollType;
      component.m_ReplaceUnitForInspection = BlueprintTool.GetRef<BlueprintUnitReference>(m_ReplaceUnitForInspection);
      component.m_Portrait = BlueprintTool.GetRef<BlueprintPortraitReference>(m_Portrait);
      component.m_KeepSlots = m_KeepSlots;
      component.Size = Size;
      component.StrengthBonus = StrengthBonus;
      component.DexterityBonus = DexterityBonus;
      component.ConstitutionBonus = ConstitutionBonus;
      component.NaturalArmor = NaturalArmor;
      component.m_MainHand = BlueprintTool.GetRef<BlueprintItemWeaponReference>(m_MainHand);
      component.m_OffHand = BlueprintTool.GetRef<BlueprintItemWeaponReference>(m_OffHand);
      component.m_AdditionalLimbs = m_AdditionalLimbs.Select(bp => BlueprintTool.GetRef<BlueprintItemWeaponReference>(bp)).ToArray();
      component.m_SecondaryAdditionalLimbs = m_SecondaryAdditionalLimbs.Select(bp => BlueprintTool.GetRef<BlueprintItemWeaponReference>(bp)).ToArray();
      component.m_Facts = m_Facts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.m_EnterTransition = m_EnterTransition;
      component.m_ExitTransition = m_ExitTransition;
      component.m_TransitionExternal = m_TransitionExternal;
      component.m_SilentCaster = m_SilentCaster;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffOnLoad"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveBuffOnLoad))]
    public BuffConfigurator AddRemoveBuffOnLoad(
        bool OnlyFromParty)
    {
      
      var component =  new RemoveBuffOnLoad();
      component.OnlyFromParty = OnlyFromParty;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffOnTurnOn"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveBuffOnTurnOn))]
    public BuffConfigurator AddRemoveBuffOnTurnOn(
        bool OnlyFromParty)
    {
      
      var component =  new RemoveBuffOnTurnOn();
      component.OnlyFromParty = OnlyFromParty;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAreaEffect"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_AreaEffect"><see cref="BlueprintAbilityAreaEffect"/></param>
    [Generated]
    [Implements(typeof(AddAreaEffect))]
    public BuffConfigurator AddAddAreaEffect(
        string m_AreaEffect)
    {
      
      var component =  new AddAreaEffect();
      component.m_AreaEffect = BlueprintTool.GetRef<BlueprintAbilityAreaEffectReference>(m_AreaEffect);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddAttackBonus))]
    public BuffConfigurator AddAddAttackBonus(
        int Bonus)
    {
      
      var component =  new AddAttackBonus();
      component.Bonus = Bonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCheatDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddCheatDamageBonus))]
    public BuffConfigurator AddAddCheatDamageBonus(
        int Bonus)
    {
      
      var component =  new AddCheatDamageBonus();
      component.Bonus = Bonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddDispelMagicFailedTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddDispelMagicFailedTrigger))]
    public BuffConfigurator AddAddDispelMagicFailedTrigger(
        ActionsBuilder ActionOnOwner,
        ActionsBuilder ActionOnCaster)
    {
      
      var component =  new AddDispelMagicFailedTrigger();
      component.ActionOnOwner = ActionOnOwner.Build();
      component.ActionOnCaster = ActionOnCaster.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEffectContextFastHealing"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEffectContextFastHealing))]
    public BuffConfigurator AddAddEffectContextFastHealing(
        ContextValue Bonus)
    {
      ValidateParam(Bonus);
      
      var component =  new AddEffectContextFastHealing();
      component.Bonus = Bonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEffectProtectionFromElement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEffectProtectionFromElement))]
    public BuffConfigurator AddAddEffectProtectionFromElement(
        string Element,
        int ShieldCapacity)
    {
      
      var component =  new AddEffectProtectionFromElement();
      component.Element = Element;
      component.ShieldCapacity = ShieldCapacity;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEffectRegeneration"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEffectRegeneration))]
    public BuffConfigurator AddAddEffectRegeneration(
        int Heal,
        bool Unremovable,
        bool CancelByMagicWeapon,
        DamageEnergyType[] CancelDamageEnergyTypes,
        DamageAlignment[] CancelDamageAlignmentTypes,
        PhysicalDamageMaterial[] CancelDamageMaterials)
    {
      foreach (var item in CancelDamageEnergyTypes)
      {
        ValidateParam(item);
      }
      foreach (var item in CancelDamageAlignmentTypes)
      {
        ValidateParam(item);
      }
      foreach (var item in CancelDamageMaterials)
      {
        ValidateParam(item);
      }
      
      var component =  new AddEffectRegeneration();
      component.Heal = Heal;
      component.Unremovable = Unremovable;
      component.CancelByMagicWeapon = CancelByMagicWeapon;
      component.CancelDamageEnergyTypes = CancelDamageEnergyTypes;
      component.CancelDamageAlignmentTypes = CancelDamageAlignmentTypes;
      component.CancelDamageMaterials = CancelDamageMaterials;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddGenericStatBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddGenericStatBonus))]
    public BuffConfigurator AddAddGenericStatBonus(
        ModifierDescriptor Descriptor,
        StatType Stat,
        int Value)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      
      var component =  new AddGenericStatBonus();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddMirrorImage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddMirrorImage))]
    public BuffConfigurator AddAddMirrorImage(
        ContextDiceValue Count,
        int MaxCount)
    {
      ValidateParam(Count);
      
      var component =  new AddMirrorImage();
      component.Count = Count;
      component.MaxCount = MaxCount;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellSchool"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSpellSchool))]
    public BuffConfigurator AddAddSpellSchool(
        SpellSchool School)
    {
      ValidateParam(School);
      
      var component =  new AddSpellSchool();
      component.School = School;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IsPositiveEffect"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsPositiveEffect))]
    public BuffConfigurator AddIsPositiveEffect()
    {
      return AddComponent(new IsPositiveEffect());
    }

    /// <summary>
    /// Adds <see cref="NegativeLevelComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NegativeLevelComponent))]
    public BuffConfigurator AddNegativeLevelComponent()
    {
      return AddComponent(new NegativeLevelComponent());
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffIfCasterIsMissing"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveBuffIfCasterIsMissing))]
    public BuffConfigurator AddRemoveBuffIfCasterIsMissing(
        bool RemoveOnCasterDeath)
    {
      
      var component =  new RemoveBuffIfCasterIsMissing();
      component.RemoveOnCasterDeath = RemoveOnCasterDeath;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ResurrectionLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ResurrectionLogic))]
    public BuffConfigurator AddResurrectionLogic(
        GameObject FirstFx,
        float FirstFxDelay,
        GameObject SecondFx,
        float SecondFxDelay)
    {
      ValidateParam(FirstFx);
      ValidateParam(SecondFx);
      
      var component =  new ResurrectionLogic();
      component.FirstFx = FirstFx;
      component.FirstFxDelay = FirstFxDelay;
      component.SecondFx = SecondFx;
      component.SecondFxDelay = SecondFxDelay;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SetBuffOnsetDelay"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetBuffOnsetDelay))]
    public BuffConfigurator AddSetBuffOnsetDelay(
        ContextDurationValue Delay,
        ActionsBuilder OnStart)
    {
      ValidateParam(Delay);
      
      var component =  new SetBuffOnsetDelay();
      component.Delay = Delay;
      component.OnStart = OnStart.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpecialAnimationState"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpecialAnimationState))]
    public BuffConfigurator AddSpecialAnimationState(
        UnitAnimationActionBuffState Animation)
    {
      ValidateParam(Animation);
      
      var component =  new SpecialAnimationState();
      component.Animation = Animation;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SummonedUnitBuff"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SummonedUnitBuff))]
    public BuffConfigurator AddSummonedUnitBuff()
    {
      return AddComponent(new SummonedUnitBuff());
    }

    /// <summary>
    /// Adds <see cref="WeaponAttackTypeDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponAttackTypeDamageBonus))]
    public BuffConfigurator AddWeaponAttackTypeDamageBonus(
        WeaponRangeType Type,
        int AttackBonus,
        ModifierDescriptor Descriptor,
        ContextValue Value)
    {
      ValidateParam(Type);
      ValidateParam(Descriptor);
      ValidateParam(Value);
      
      var component =  new WeaponAttackTypeDamageBonus();
      component.Type = Type;
      component.AttackBonus = AttackBonus;
      component.Descriptor = Descriptor;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParams"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CustomProperty"><see cref="BlueprintUnitProperty"/></param>
    [Generated]
    [Implements(typeof(ContextCalculateAbilityParams))]
    public BuffConfigurator AddContextCalculateAbilityParams(
        bool UseKineticistMainStat,
        StatType StatType,
        bool StatTypeFromCustomProperty,
        string m_CustomProperty,
        bool ReplaceCasterLevel,
        ContextValue CasterLevel,
        bool ReplaceSpellLevel,
        ContextValue SpellLevel)
    {
      ValidateParam(StatType);
      ValidateParam(CasterLevel);
      ValidateParam(SpellLevel);
      
      var component =  new ContextCalculateAbilityParams();
      component.UseKineticistMainStat = UseKineticistMainStat;
      component.StatType = StatType;
      component.StatTypeFromCustomProperty = StatTypeFromCustomProperty;
      component.m_CustomProperty = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(m_CustomProperty);
      component.ReplaceCasterLevel = ReplaceCasterLevel;
      component.CasterLevel = CasterLevel;
      component.ReplaceSpellLevel = ReplaceSpellLevel;
      component.SpellLevel = SpellLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParamsBasedOnClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(ContextCalculateAbilityParamsBasedOnClass))]
    public BuffConfigurator AddContextCalculateAbilityParamsBasedOnClass(
        bool UseKineticistMainStat,
        StatType StatType,
        string m_CharacterClass)
    {
      ValidateParam(StatType);
      
      var component =  new ContextCalculateAbilityParamsBasedOnClass();
      component.UseKineticistMainStat = UseKineticistMainStat;
      component.StatType = StatType;
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateSharedValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextCalculateSharedValue))]
    public BuffConfigurator AddContextCalculateSharedValue(
        AbilitySharedValue ValueType,
        ContextDiceValue Value,
        double Modifier)
    {
      ValidateParam(ValueType);
      ValidateParam(Value);
      
      var component =  new ContextCalculateSharedValue();
      component.ValueType = ValueType;
      component.Value = Value;
      component.Modifier = Modifier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextSetAbilityParams"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextSetAbilityParams))]
    public BuffConfigurator AddContextSetAbilityParams(
        bool Add10ToDC,
        ContextValue DC,
        ContextValue CasterLevel,
        ContextValue Concentration,
        ContextValue SpellLevel)
    {
      ValidateParam(DC);
      ValidateParam(CasterLevel);
      ValidateParam(Concentration);
      ValidateParam(SpellLevel);
      
      var component =  new ContextSetAbilityParams();
      component.Add10ToDC = Add10ToDC;
      component.DC = DC;
      component.CasterLevel = CasterLevel;
      component.Concentration = Concentration;
      component.SpellLevel = SpellLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityDifficultyLimitDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityDifficultyLimitDC))]
    public BuffConfigurator AddAbilityDifficultyLimitDC()
    {
      return AddComponent(new AbilityDifficultyLimitDC());
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstTacticalOwner"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstTacticalOwner))]
    public BuffConfigurator AddAttackBonusAgainstTacticalOwner(
        TargetFilter m_TargetFilter,
        ContextValue m_Value,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(m_TargetFilter);
      ValidateParam(m_Value);
      ValidateParam(Descriptor);
      
      var component =  new AttackBonusAgainstTacticalOwner();
      component.m_TargetFilter = m_TargetFilter;
      component.m_Value = m_Value;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstTacticalTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstTacticalTarget))]
    public BuffConfigurator AddAttackBonusAgainstTacticalTarget(
        TargetFilter m_TargetFilter,
        ContextValue m_Value,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(m_TargetFilter);
      ValidateParam(m_Value);
      ValidateParam(Descriptor);
      
      var component =  new AttackBonusAgainstTacticalTarget();
      component.m_TargetFilter = m_TargetFilter;
      component.m_Value = m_Value;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstTacticalOwner"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageBonusAgainstTacticalOwner))]
    public BuffConfigurator AddDamageBonusAgainstTacticalOwner(
        TargetFilter m_TargetFilter,
        Kingmaker.UnitLogic.Mechanics.ValueType _valueType,
        ContextValue m_Value,
        int m_BonusPercentValue)
    {
      ValidateParam(m_TargetFilter);
      ValidateParam(_valueType);
      ValidateParam(m_Value);
      
      var component =  new DamageBonusAgainstTacticalOwner();
      component.m_TargetFilter = m_TargetFilter;
      component._valueType = _valueType;
      component.m_Value = m_Value;
      component.m_BonusPercentValue = m_BonusPercentValue;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstTacticalTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageBonusAgainstTacticalTarget))]
    public BuffConfigurator AddDamageBonusAgainstTacticalTarget(
        TargetFilter m_TargetFilter,
        Kingmaker.UnitLogic.Mechanics.ValueType _valueType,
        ContextValue m_Value,
        int m_BonusPercentValue)
    {
      ValidateParam(m_TargetFilter);
      ValidateParam(_valueType);
      ValidateParam(m_Value);
      
      var component =  new DamageBonusAgainstTacticalTarget();
      component.m_TargetFilter = m_TargetFilter;
      component._valueType = _valueType;
      component.m_Value = m_Value;
      component.m_BonusPercentValue = m_BonusPercentValue;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceSquadAbilities"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_NewAbilities"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(ReplaceSquadAbilities))]
    public BuffConfigurator AddReplaceSquadAbilities(
        string[] m_NewAbilities,
        bool m_ForOneTurn)
    {
      
      var component =  new ReplaceSquadAbilities();
      component.m_NewAbilities = m_NewAbilities.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToList();
      component.m_ForOneTurn = m_ForOneTurn;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatConfusion"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_AiAttackNearestAction"><see cref="BlueprintTacticalCombatAiAction"/></param>
    [Generated]
    [Implements(typeof(TacticalCombatConfusion))]
    public BuffConfigurator AddTacticalCombatConfusion(
        string m_AiAttackNearestAction,
        ActionsBuilder m_HarmSelfAction)
    {
      
      var component =  new TacticalCombatConfusion();
      component.m_AiAttackNearestAction = BlueprintTool.GetRef<BlueprintTacticalCombatAiActionReference>(m_AiAttackNearestAction);
      component.m_HarmSelfAction = m_HarmSelfAction.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalMoraleChanceModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalMoraleChanceModifier))]
    public BuffConfigurator AddTacticalMoraleChanceModifier(
        bool m_ChangePositiveMorale,
        ContextValue m_PositiveMoraleChancePercentDelta,
        bool m_ChangeNegativeMorale,
        ContextValue m_NegativeMoraleChancePercentDelta)
    {
      ValidateParam(m_PositiveMoraleChancePercentDelta);
      ValidateParam(m_NegativeMoraleChancePercentDelta);
      
      var component =  new TacticalMoraleChanceModifier();
      component.m_ChangePositiveMorale = m_ChangePositiveMorale;
      component.m_PositiveMoraleChancePercentDelta = m_PositiveMoraleChancePercentDelta;
      component.m_ChangeNegativeMorale = m_ChangeNegativeMorale;
      component.m_NegativeMoraleChancePercentDelta = m_NegativeMoraleChancePercentDelta;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TargetingBlind"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TargetingBlind))]
    public BuffConfigurator AddTargetingBlind()
    {
      return AddComponent(new TargetingBlind());
    }

    /// <summary>
    /// Adds <see cref="ActionsOnBuffApply"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_GainedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ActionsOnBuffApply))]
    public BuffConfigurator AddActionsOnBuffApply(
        string m_GainedFact,
        ActionsBuilder Actions)
    {
      
      var component =  new ActionsOnBuffApply();
      component.m_GainedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_GainedFact);
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BodyguardACBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(BodyguardACBonus))]
    public BuffConfigurator AddBodyguardACBonus(
        string m_CheckBuff,
        ModifierDescriptor Descriptor,
        ContextValue Value)
    {
      ValidateParam(Descriptor);
      ValidateParam(Value);
      
      var component =  new BodyguardACBonus();
      component.m_CheckBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_CheckBuff);
      component.Descriptor = Descriptor;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffExtraEffects"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="m_ExtraEffectBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="m_ExceptionFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(BuffExtraEffects))]
    public BuffConfigurator AddBuffExtraEffects(
        string m_CheckedBuff,
        string m_ExtraEffectBuff,
        string m_ExceptionFact)
    {
      
      var component =  new BuffExtraEffects();
      component.m_CheckedBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_CheckedBuff);
      component.m_ExtraEffectBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_ExtraEffectBuff);
      component.m_ExceptionFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_ExceptionFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeathOnLevelStacks"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DeathOnLevelStacks))]
    public BuffConfigurator AddDeathOnLevelStacks()
    {
      return AddComponent(new DeathOnLevelStacks());
    }

    /// <summary>
    /// Adds <see cref="InHarmsWay"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="m_CooldownBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(InHarmsWay))]
    public BuffConfigurator AddInHarmsWay(
        string m_CheckBuff,
        string m_CooldownBuff)
    {
      
      var component =  new InHarmsWay();
      component.m_CheckBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_CheckBuff);
      component.m_CooldownBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_CooldownBuff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IndomitableMount"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CooldownBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(IndomitableMount))]
    public BuffConfigurator AddIndomitableMount(
        string m_CooldownBuff)
    {
      
      var component =  new IndomitableMount();
      component.m_CooldownBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_CooldownBuff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MetamagicOnNextSpell"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MetamagicOnNextSpell))]
    public BuffConfigurator AddMetamagicOnNextSpell(
        Metamagic Metamagic,
        bool DoNotRemove,
        bool SourcerousReflex)
    {
      ValidateParam(Metamagic);
      
      var component =  new MetamagicOnNextSpell();
      component.Metamagic = Metamagic;
      component.DoNotRemove = DoNotRemove;
      component.SourcerousReflex = SourcerousReflex;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MetamagicRodMechanics"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_RodAbility"><see cref="BlueprintActivatableAbility"/></param>
    /// <param name="m_AbilitiesWhiteList"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(MetamagicRodMechanics))]
    public BuffConfigurator AddMetamagicRodMechanics(
        Metamagic Metamagic,
        int MaxSpellLevel,
        string m_RodAbility,
        string[] m_AbilitiesWhiteList)
    {
      ValidateParam(Metamagic);
      
      var component =  new MetamagicRodMechanics();
      component.Metamagic = Metamagic;
      component.MaxSpellLevel = MaxSpellLevel;
      component.m_RodAbility = BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(m_RodAbility);
      component.m_AbilitiesWhiteList = m_AbilitiesWhiteList.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MountedCombat"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CooldownBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(MountedCombat))]
    public BuffConfigurator AddMountedCombat(
        string m_CooldownBuff)
    {
      
      var component =  new MountedCombat();
      component.m_CooldownBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_CooldownBuff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NeutralToFaction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Faction"><see cref="BlueprintFaction"/></param>
    [Generated]
    [Implements(typeof(NeutralToFaction))]
    public BuffConfigurator AddNeutralToFaction(
        string m_Faction)
    {
      
      var component =  new NeutralToFaction();
      component.m_Faction = BlueprintTool.GetRef<BlueprintFactionReference>(m_Faction);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpecificSpellDamageBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spell"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(SpecificSpellDamageBonus))]
    public BuffConfigurator AddSpecificSpellDamageBonus(
        string[] m_Spell,
        int Bonus)
    {
      
      var component =  new SpecificSpellDamageBonus();
      component.m_Spell = m_Spell.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.Bonus = Bonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnwillingShield"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_MasterAbility"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(UnwillingShield))]
    public BuffConfigurator AddUnwillingShield(
        string m_MasterAbility)
    {
      
      var component =  new UnwillingShield();
      component.m_MasterAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(m_MasterAbility);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnwillingShieldTarget"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_MasterAbility"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(UnwillingShieldTarget))]
    public BuffConfigurator AddUnwillingShieldTarget(
        string m_MasterAbility)
    {
      
      var component =  new UnwillingShieldTarget();
      component.m_MasterAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(m_MasterAbility);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ImpatienceWatcherTickingResolve"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Impatience"><see cref="BlueprintBuff"/></param>
    /// <param name="m_TargetedImpatience"><see cref="BlueprintBuff"/></param>
    /// <param name="m_Patience"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ImpatienceWatcherTickingResolve))]
    public BuffConfigurator AddImpatienceWatcherTickingResolve(
        string m_Impatience,
        string m_TargetedImpatience,
        string m_Patience,
        int[] ResolveChances,
        int[] ResolveChancesForLowInt,
        int[] ResolveChancesForHighInt)
    {
      
      var component =  new ImpatienceWatcherTickingResolve();
      component.m_Impatience = BlueprintTool.GetRef<BlueprintBuffReference>(m_Impatience);
      component.m_TargetedImpatience = BlueprintTool.GetRef<BlueprintBuffReference>(m_TargetedImpatience);
      component.m_Patience = BlueprintTool.GetRef<BlueprintBuffReference>(m_Patience);
      component.ResolveChances = ResolveChances;
      component.ResolveChancesForLowInt = ResolveChancesForLowInt;
      component.ResolveChancesForHighInt = ResolveChancesForHighInt;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstCaster))]
    public BuffConfigurator AddACBonusAgainstCaster(
        ContextValue Value,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Value);
      ValidateParam(Descriptor);
      
      var component =  new ACBonusAgainstCaster();
      component.Value = Value;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstTarget))]
    public BuffConfigurator AddACBonusAgainstTarget(
        ContextValue Value,
        bool CheckCaster,
        bool CheckCasterFriend,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Value);
      ValidateParam(Descriptor);
      
      var component =  new ACBonusAgainstTarget();
      component.Value = Value;
      component.CheckCaster = CheckCaster;
      component.CheckCasterFriend = CheckCasterFriend;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAdditionalLimbIfHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Weapon"><see cref="BlueprintItemWeapon"/></param>
    /// <param name="m_CheckedFact"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddAdditionalLimbIfHasFact))]
    public BuffConfigurator AddAddAdditionalLimbIfHasFact(
        string m_Weapon,
        string m_CheckedFact)
    {
      
      var component =  new AddAdditionalLimbIfHasFact();
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(m_Weapon);
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintFeatureReference>(m_CheckedFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusAbilityValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddStatBonusAbilityValue))]
    public BuffConfigurator AddAddStatBonusAbilityValue(
        ModifierDescriptor Descriptor,
        StatType Stat,
        ContextValue Value)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      ValidateParam(Value);
      
      var component =  new AddStatBonusAbilityValue();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusIfHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddStatBonusIfHasFact))]
    public BuffConfigurator AddAddStatBonusIfHasFact(
        ModifierDescriptor Descriptor,
        StatType Stat,
        ContextValue Value,
        bool InvertCondition,
        bool RequireAllFacts,
        string[] m_CheckedFacts)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      ValidateParam(Value);
      
      var component =  new AddStatBonusIfHasFact();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.Value = Value;
      component.InvertCondition = InvertCondition;
      component.RequireAllFacts = RequireAllFacts;
      component.m_CheckedFacts = m_CheckedFacts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusIfHasSkill"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddStatBonusIfHasSkill))]
    public BuffConfigurator AddAddStatBonusIfHasSkill(
        ModifierDescriptor Descriptor,
        StatType Stat,
        int ValueTrue,
        int ValueFalse,
        StatType CheckedSkill,
        int SkillValue)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      ValidateParam(CheckedSkill);
      
      var component =  new AddStatBonusIfHasSkill();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.ValueTrue = ValueTrue;
      component.ValueFalse = ValueFalse;
      component.CheckedSkill = CheckedSkill;
      component.SkillValue = SkillValue;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusScaled"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddStatBonusScaled))]
    public BuffConfigurator AddAddStatBonusScaled(
        ModifierDescriptor Descriptor,
        StatType Stat,
        int Value,
        BuffScaling Scaling)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      ValidateParam(Scaling);
      
      var component =  new AddStatBonusScaled();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.Value = Value;
      component.Scaling = Scaling;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Afterbuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_AfterBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(Afterbuff))]
    public BuffConfigurator AddAfterbuff(
        string m_AfterBuff,
        int DurationMultiplier)
    {
      
      var component =  new Afterbuff();
      component.m_AfterBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_AfterBuff);
      component.DurationMultiplier = DurationMultiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AfterbuffIfHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_FeatureToCheck"><see cref="BlueprintFeature"/></param>
    /// <param name="m_AfterBuffFalse"><see cref="BlueprintBuff"/></param>
    /// <param name="m_AfterBuffTrue"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AfterbuffIfHasFact))]
    public BuffConfigurator AddAfterbuffIfHasFact(
        string m_FeatureToCheck,
        string m_AfterBuffFalse,
        string m_AfterBuffTrue,
        int DurationMultiplier)
    {
      
      var component =  new AfterbuffIfHasFact();
      component.m_FeatureToCheck = BlueprintTool.GetRef<BlueprintFeatureReference>(m_FeatureToCheck);
      component.m_AfterBuffFalse = BlueprintTool.GetRef<BlueprintBuffReference>(m_AfterBuffFalse);
      component.m_AfterBuffTrue = BlueprintTool.GetRef<BlueprintBuffReference>(m_AfterBuffTrue);
      component.DurationMultiplier = DurationMultiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ApplyBuffOnHit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ApplyBuffOnHit))]
    public BuffConfigurator AddApplyBuffOnHit(
        string m_buff,
        Rounds time)
    {
      ValidateParam(time);
      
      var component =  new ApplyBuffOnHit();
      component.m_buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_buff);
      component.time = time;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmagsBladeEnrage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmagsBladeEnrage))]
    public BuffConfigurator AddArmagsBladeEnrage()
    {
      return AddComponent(new ArmagsBladeEnrage());
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstCaster))]
    public BuffConfigurator AddAttackBonusAgainstCaster(
        ContextValue Value,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Value);
      ValidateParam(Descriptor);
      
      var component =  new AttackBonusAgainstCaster();
      component.Value = Value;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstTarget))]
    public BuffConfigurator AddAttackBonusAgainstTarget(
        ContextValue Value,
        ModifierDescriptor Descriptor,
        bool CheckCaster,
        bool CheckCasterFriend,
        bool CheckRangeType,
        WeaponRangeType RangeType)
    {
      ValidateParam(Value);
      ValidateParam(Descriptor);
      ValidateParam(RangeType);
      
      var component =  new AttackBonusAgainstTarget();
      component.Value = Value;
      component.Descriptor = Descriptor;
      component.CheckCaster = CheckCaster;
      component.CheckCasterFriend = CheckCasterFriend;
      component.CheckRangeType = CheckRangeType;
      component.RangeType = RangeType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffAllSkillsBonusAbilityValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffAllSkillsBonusAbilityValue))]
    public BuffConfigurator AddBuffAllSkillsBonusAbilityValue(
        ModifierDescriptor Descriptor,
        ContextValue Value)
    {
      ValidateParam(Descriptor);
      ValidateParam(Value);
      
      var component =  new BuffAllSkillsBonusAbilityValue();
      component.Descriptor = Descriptor;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffDamageEachRound"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffDamageEachRound))]
    public BuffConfigurator AddBuffDamageEachRound(
        int baseRounds,
        float AdditionalRoundsPerCasterLevel,
        DiceFormula EnergyDamageDice,
        DamageEnergyType Element)
    {
      ValidateParam(EnergyDamageDice);
      ValidateParam(Element);
      
      var component =  new BuffDamageEachRound();
      component.baseRounds = baseRounds;
      component.AdditionalRoundsPerCasterLevel = AdditionalRoundsPerCasterLevel;
      component.EnergyDamageDice = EnergyDamageDice;
      component.Element = Element;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffIncomingDamageIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffIncomingDamageIncrease))]
    public BuffConfigurator AddBuffIncomingDamageIncrease(
        ContextValue Value)
    {
      ValidateParam(Value);
      
      var component =  new BuffIncomingDamageIncrease();
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffInvisibility"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffInvisibility))]
    public BuffConfigurator AddBuffInvisibility(
        bool NotDispellAfterOffensiveAction,
        int m_StealthBonus,
        bool DispelWithAChance,
        ContextValue Chance)
    {
      ValidateParam(Chance);
      
      var component =  new BuffInvisibility();
      component.NotDispellAfterOffensiveAction = NotDispellAfterOffensiveAction;
      component.m_StealthBonus = m_StealthBonus;
      component.DispelWithAChance = DispelWithAChance;
      component.Chance = Chance;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffParticleEffectPlay"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffParticleEffectPlay))]
    public BuffConfigurator AddBuffParticleEffectPlay(
        bool PlayOnActivate,
        PrefabLink ActivateFx,
        bool PlayOnDeactivate,
        PrefabLink DeactivateFx,
        bool PlayEachRound,
        PrefabLink EachRoundFx)
    {
      ValidateParam(ActivateFx);
      ValidateParam(DeactivateFx);
      ValidateParam(EachRoundFx);
      
      var component =  new BuffParticleEffectPlay();
      component.PlayOnActivate = PlayOnActivate;
      component.ActivateFx = ActivateFx;
      component.PlayOnDeactivate = PlayOnDeactivate;
      component.DeactivateFx = DeactivateFx;
      component.PlayEachRound = PlayEachRound;
      component.EachRoundFx = EachRoundFx;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffPerceptionBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffPerceptionBonus))]
    public BuffConfigurator AddBuffPerceptionBonus(
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Descriptor);
      
      var component =  new BuffPerceptionBonus();
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffPoisonStatDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffPoisonStatDamage))]
    public BuffConfigurator AddBuffPoisonStatDamage(
        ModifierDescriptor Descriptor,
        StatType Stat,
        DiceFormula Value,
        int Bonus,
        int Ticks,
        int SuccesfullSaves,
        SavingThrowType SaveType,
        bool NoEffectOnFirstTick)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      ValidateParam(Value);
      ValidateParam(SaveType);
      
      var component =  new BuffPoisonStatDamage();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.Value = Value;
      component.Bonus = Bonus;
      component.Ticks = Ticks;
      component.SuccesfullSaves = SuccesfullSaves;
      component.SaveType = SaveType;
      component.NoEffectOnFirstTick = NoEffectOnFirstTick;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffPoisonStatDamageContext"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffPoisonStatDamageContext))]
    public BuffConfigurator AddBuffPoisonStatDamageContext(
        ModifierDescriptor Descriptor,
        StatType Stat,
        ContextDiceValue Value,
        ContextValue Bonus,
        ContextValue Ticks,
        ContextValue SuccesfullSaves,
        SavingThrowType SaveType,
        bool NoEffectOnFirstTick)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      ValidateParam(Value);
      ValidateParam(Bonus);
      ValidateParam(Ticks);
      ValidateParam(SuccesfullSaves);
      ValidateParam(SaveType);
      
      var component =  new BuffPoisonStatDamageContext();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.Value = Value;
      component.Bonus = Bonus;
      component.Ticks = Ticks;
      component.SuccesfullSaves = SuccesfullSaves;
      component.SaveType = SaveType;
      component.NoEffectOnFirstTick = NoEffectOnFirstTick;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSaveEachRound"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffSaveEachRound))]
    public BuffConfigurator AddBuffSaveEachRound(
        SavingThrowType SaveType,
        int SaveDC,
        int IncreaseDC,
        ActionsBuilder ActionsOnPass,
        ActionsBuilder ActionsOnFail)
    {
      ValidateParam(SaveType);
      
      var component =  new BuffSaveEachRound();
      component.SaveType = SaveType;
      component.SaveDC = SaveDC;
      component.IncreaseDC = IncreaseDC;
      component.ActionsOnPass = ActionsOnPass.Build();
      component.ActionsOnFail = ActionsOnFail.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSaveOrDieEachRound"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffSaveOrDieEachRound))]
    public BuffConfigurator AddBuffSaveOrDieEachRound(
        UnitCondition Condition,
        SavingThrowType SaveType,
        int SaveDC,
        int IncreaseDC,
        GameObject EffectOnDeath)
    {
      ValidateParam(Condition);
      ValidateParam(SaveType);
      ValidateParam(EffectOnDeath);
      
      var component =  new BuffSaveOrDieEachRound();
      component.Condition = Condition;
      component.SaveType = SaveType;
      component.SaveDC = SaveDC;
      component.IncreaseDC = IncreaseDC;
      component.EffectOnDeath = EffectOnDeath;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffStatPenaltyDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffStatPenaltyDice))]
    public BuffConfigurator AddBuffStatPenaltyDice(
        ModifierDescriptor Descriptor,
        StatType Stat,
        DiceFormula Value,
        int Bonus,
        SavingThrowType SaveType)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      ValidateParam(Value);
      ValidateParam(SaveType);
      
      var component =  new BuffStatPenaltyDice();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.Value = Value;
      component.Bonus = Bonus;
      component.SaveType = SaveType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffStatusCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffStatusCondition))]
    public BuffConfigurator AddBuffStatusCondition(
        bool SaveEachRound,
        UnitCondition Condition,
        SavingThrowType SaveType)
    {
      ValidateParam(Condition);
      ValidateParam(SaveType);
      
      var component =  new BuffStatusCondition();
      component.SaveEachRound = SaveEachRound;
      component.Condition = Condition;
      component.SaveType = SaveType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ControlledProjectileHolder"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ControlledProjectileHolder))]
    public BuffConfigurator AddControlledProjectileHolder()
    {
      return AddComponent(new ControlledProjectileHolder());
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageBonusAgainstTarget))]
    public BuffConfigurator AddDamageBonusAgainstTarget(
        ContextValue Value,
        bool CheckCaster,
        bool CheckCasterFriend,
        bool ApplyToSpellDamage)
    {
      ValidateParam(Value);
      
      var component =  new DamageBonusAgainstTarget();
      component.Value = Value;
      component.CheckCaster = CheckCaster;
      component.CheckCasterFriend = CheckCasterFriend;
      component.ApplyToSpellDamage = ApplyToSpellDamage;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageOnRemove"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageOnRemove))]
    public BuffConfigurator AddDamageOnRemove(
        DiceFormula Damage,
        DamageEnergyType EnergyType)
    {
      ValidateParam(Damage);
      ValidateParam(EnergyType);
      
      var component =  new DamageOnRemove();
      component.Damage = Damage;
      component.EnergyType = EnergyType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageOverTime"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageOverTime))]
    public BuffConfigurator AddDamageOverTime(
        DiceFormula Damage,
        DamageEnergyType EnergyType,
        bool InstantStartTick)
    {
      ValidateParam(Damage);
      ValidateParam(EnergyType);
      
      var component =  new DamageOverTime();
      component.Damage = Damage;
      component.EnergyType = EnergyType;
      component.InstantStartTick = InstantStartTick;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EqualForce"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EqualForce))]
    public BuffConfigurator AddEqualForce()
    {
      return AddComponent(new EqualForce());
    }

    /// <summary>
    /// Adds <see cref="GreaterSnapShotBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GreaterSnapShotBonus))]
    public BuffConfigurator AddGreaterSnapShotBonus(
        ContextValue Value,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Value);
      ValidateParam(Descriptor);
      
      var component =  new GreaterSnapShotBonus();
      component.Value = Value;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HealOverTime"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HealOverTime))]
    public BuffConfigurator AddHealOverTime(
        int Heal,
        bool InstantStartTick)
    {
      
      var component =  new HealOverTime();
      component.Heal = Heal;
      component.InstantStartTick = InstantStartTick;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HealOverTimeIfHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(HealOverTimeIfHasFact))]
    public BuffConfigurator AddHealOverTimeIfHasFact(
        int Heal,
        bool InstantStartTick,
        string m_CheckedFact,
        bool Scale,
        BuffScaling Scaling)
    {
      ValidateParam(Scaling);
      
      var component =  new HealOverTimeIfHasFact();
      component.Heal = Heal;
      component.InstantStartTick = InstantStartTick;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintFeatureReference>(m_CheckedFact);
      component.Scale = Scale;
      component.Scaling = Scaling;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreTargetDR"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreTargetDR))]
    public BuffConfigurator AddIgnoreTargetDR(
        bool CheckCaster,
        bool CheckCasterFriend)
    {
      
      var component =  new IgnoreTargetDR();
      component.CheckCaster = CheckCaster;
      component.CheckCasterFriend = CheckCasterFriend;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OverrideLocoMotion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OverrideLocoMotion))]
    public BuffConfigurator AddOverrideLocoMotion(
        UnitAnimationActionLocoMotion LocoMotion)
    {
      ValidateParam(LocoMotion);
      
      var component =  new OverrideLocoMotion();
      component.LocoMotion = LocoMotion;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ProtectionFromEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ProtectionFromEnergy))]
    public BuffConfigurator AddProtectionFromEnergy(
        DamageEnergyType Type,
        bool UseValueMultiplier,
        ContextValue ValueMultiplier,
        ContextValue Value,
        bool UsePool,
        ContextValue Pool)
    {
      ValidateParam(Type);
      ValidateParam(ValueMultiplier);
      ValidateParam(Value);
      ValidateParam(Pool);
      
      var component =  new ProtectionFromEnergy();
      component.Type = Type;
      component.UseValueMultiplier = UseValueMultiplier;
      component.ValueMultiplier = ValueMultiplier;
      component.Value = Value;
      component.UsePool = UsePool;
      component.Pool = Pool;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemovedByHeal"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemovedByHeal))]
    public BuffConfigurator AddRemovedByHeal()
    {
      return AddComponent(new RemovedByHeal());
    }

    /// <summary>
    /// Adds <see cref="ResistEnergyContext"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ResistEnergyContext))]
    public BuffConfigurator AddResistEnergyContext(
        DamageEnergyType Type,
        bool UseValueMultiplier,
        ContextValue ValueMultiplier,
        ContextValue Value,
        bool UsePool,
        ContextValue Pool)
    {
      ValidateParam(Type);
      ValidateParam(ValueMultiplier);
      ValidateParam(Value);
      ValidateParam(Pool);
      
      var component =  new ResistEnergyContext();
      component.Type = Type;
      component.UseValueMultiplier = UseValueMultiplier;
      component.ValueMultiplier = ValueMultiplier;
      component.Value = Value;
      component.UsePool = UsePool;
      component.Pool = Pool;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SaveSuccessIfBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SaveSuccessIfBonus))]
    public BuffConfigurator AddSaveSuccessIfBonus(
        ContextValue Value)
    {
      ValidateParam(Value);
      
      var component =  new SaveSuccessIfBonus();
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SkillSuccessIfBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SkillSuccessIfBonus))]
    public BuffConfigurator AddSkillSuccessIfBonus(
        ContextValue Value)
    {
      ValidateParam(Value);
      
      var component =  new SkillSuccessIfBonus();
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsConstitutionBased"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TemporaryHitPointsConstitutionBased))]
    public BuffConfigurator AddTemporaryHitPointsConstitutionBased(
        ContextValue Value,
        int BonusMultiplier,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Value);
      ValidateParam(Descriptor);
      
      var component =  new TemporaryHitPointsConstitutionBased();
      component.Value = Value;
      component.BonusMultiplier = BonusMultiplier;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsEqualCasterLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TemporaryHitPointsEqualCasterLevel))]
    public BuffConfigurator AddTemporaryHitPointsEqualCasterLevel(
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Descriptor);
      
      var component =  new TemporaryHitPointsEqualCasterLevel();
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsFromAbilityValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TemporaryHitPointsFromAbilityValue))]
    public BuffConfigurator AddTemporaryHitPointsFromAbilityValue(
        ModifierDescriptor Descriptor,
        ContextValue Value,
        bool RemoveWhenHitPointsEnd)
    {
      ValidateParam(Descriptor);
      ValidateParam(Value);
      
      var component =  new TemporaryHitPointsFromAbilityValue();
      component.Descriptor = Descriptor;
      component.Value = Value;
      component.RemoveWhenHitPointsEnd = RemoveWhenHitPointsEnd;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsRandom"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TemporaryHitPointsRandom))]
    public BuffConfigurator AddTemporaryHitPointsRandom(
        ModifierDescriptor Descriptor,
        DiceFormula Dice,
        ContextValue Bonus,
        bool ScaleBonusByCasterLevel)
    {
      ValidateParam(Descriptor);
      ValidateParam(Dice);
      ValidateParam(Bonus);
      
      var component =  new TemporaryHitPointsRandom();
      component.Descriptor = Descriptor;
      component.Dice = Dice;
      component.Bonus = Bonus;
      component.ScaleBonusByCasterLevel = ScaleBonusByCasterLevel;
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
