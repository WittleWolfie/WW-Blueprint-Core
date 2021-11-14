using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Designers.Mechanics.EquipmentEnchants;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Designers.Mechanics.WeaponEnchants;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BlueprintCore.Blueprints.Configurators.Items.Ecnchantments
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemEnchantment"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEnchantment))]
  public abstract class BaseItemEnchantmentConfigurator<T, TBuilder>
      : BaseFactConfigurator<T, TBuilder>
      where T : BlueprintItemEnchantment
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseItemEnchantmentConfigurator(string name) : base(name) { }

    /// <summary>
    /// Adds <see cref="Kingmaker.UnitLogic.Mechanics.Components.ContextRankConfig">ContextRankConfig</see>
    /// </summary>
    /// 
    /// <remarks>Use <see cref="Components.ContextRankConfigs">ContextRankConfigs</see> to create the config</remarks>
    [Implements(typeof(ContextRankConfig))]
    public TBuilder ContextRankConfig(ContextRankConfig rankConfig)
    {
      return AddComponent(rankConfig);
    }


    /// <summary>
    /// Adds <see cref="ArmorEnhancementBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmorEnhancementBonus))]
    public TBuilder AddArmorEnhancementBonus(
        int EnhancementValue)
    {
      
      var component =  new ArmorEnhancementBonus();
      component.EnhancementValue = EnhancementValue;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ItemEnchantmentEnableWhileEtudePlaying"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Etude"><see cref="BlueprintEtude"/></param>
    [Generated]
    [Implements(typeof(ItemEnchantmentEnableWhileEtudePlaying))]
    public TBuilder AddItemEnchantmentEnableWhileEtudePlaying(
        string m_Etude)
    {
      
      var component =  new ItemEnchantmentEnableWhileEtudePlaying();
      component.m_Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(m_Etude);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageReroll"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponDamageReroll))]
    public TBuilder AddWeaponDamageReroll()
    {
      return AddComponent(new WeaponDamageReroll());
    }

    /// <summary>
    /// Adds <see cref="TwoWeaponCriticalAdditionalAttackEnchant"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TwoWeaponCriticalAdditionalAttackEnchant))]
    public TBuilder AddTwoWeaponCriticalAdditionalAttackEnchant()
    {
      return AddComponent(new TwoWeaponCriticalAdditionalAttackEnchant());
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParams"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CustomProperty"><see cref="BlueprintUnitProperty"/></param>
    [Generated]
    [Implements(typeof(ContextCalculateAbilityParams))]
    public TBuilder AddContextCalculateAbilityParams(
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
    public TBuilder AddContextCalculateAbilityParamsBasedOnClass(
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
    public TBuilder AddContextCalculateSharedValue(
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
    public TBuilder AddContextSetAbilityParams(
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
    public TBuilder AddAbilityDifficultyLimitDC()
    {
      return AddComponent(new AbilityDifficultyLimitDC());
    }

    /// <summary>
    /// Adds <see cref="SuppressBane"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SuppressBane))]
    public TBuilder AddSuppressBane()
    {
      return AddComponent(new SuppressBane());
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalConfirmationBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCriticalConfirmationBonus))]
    public TBuilder AddWeaponCriticalConfirmationBonus(
        ContextValue Value,
        int AdditionalBonus)
    {
      ValidateParam(Value);
      
      var component =  new WeaponCriticalConfirmationBonus();
      component.Value = Value;
      component.AdditionalBonus = AdditionalBonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalEdgeIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCriticalEdgeIncrease))]
    public TBuilder AddWeaponCriticalEdgeIncrease()
    {
      return AddComponent(new WeaponCriticalEdgeIncrease());
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalEdgeStackable"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCriticalEdgeStackable))]
    public TBuilder AddWeaponCriticalEdgeStackable(
        int Bonus)
    {
      
      var component =  new WeaponCriticalEdgeStackable();
      component.Bonus = Bonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalMultiplierIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCriticalMultiplierIncrease))]
    public TBuilder AddWeaponCriticalMultiplierIncrease(
        int AdditionalMultiplier)
    {
      
      var component =  new WeaponCriticalMultiplierIncrease();
      component.AdditionalMultiplier = AdditionalMultiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageMultiplierStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponDamageMultiplierStatReplacement))]
    public TBuilder AddWeaponDamageMultiplierStatReplacement(
        StatType Stat,
        float Multiplier)
    {
      ValidateParam(Stat);
      
      var component =  new WeaponDamageMultiplierStatReplacement();
      component.Stat = Stat;
      component.Multiplier = Multiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponDamageStatReplacement))]
    public TBuilder AddWeaponDamageStatReplacement(
        StatType Stat,
        bool RequiresFinesse)
    {
      ValidateParam(Stat);
      
      var component =  new WeaponDamageStatReplacement();
      component.Stat = Stat;
      component.RequiresFinesse = RequiresFinesse;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponOversized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponOversized))]
    public TBuilder AddWeaponOversized()
    {
      return AddComponent(new WeaponOversized());
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstFactOwnerEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ACBonusAgainstFactOwnerEquipment))]
    public TBuilder AddACBonusAgainstFactOwnerEquipment(
        string m_CheckedFact,
        int Bonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Descriptor);
      
      var component =  new ACBonusAgainstFactOwnerEquipment();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintFeatureReference>(m_CheckedFact);
      component.Bonus = Bonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCasterLevelEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spell"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddCasterLevelEquipment))]
    public TBuilder AddAddCasterLevelEquipment(
        string m_Spell,
        int Bonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Descriptor);
      
      var component =  new AddCasterLevelEquipment();
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(m_Spell);
      component.Bonus = Bonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddConditionImmunityEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddConditionImmunityEquipment))]
    public TBuilder AddAddConditionImmunityEquipment(
        UnitCondition Condition)
    {
      ValidateParam(Condition);
      
      var component =  new AddConditionImmunityEquipment();
      component.Condition = Condition;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSavesFixerArmorRecalculator"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Feature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddSavesFixerArmorRecalculator))]
    public TBuilder AddAddSavesFixerArmorRecalculator(
        string m_Feature)
    {
      
      var component =  new AddSavesFixerArmorRecalculator();
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_Feature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellbookEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spellbook"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(AddSpellbookEquipment))]
    public TBuilder AddAddSpellbookEquipment(
        string m_Spellbook,
        int CasterLevel)
    {
      
      var component =  new AddSpellbookEquipment();
      component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(m_Spellbook);
      component.CasterLevel = CasterLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddStatBonusEquipment))]
    public TBuilder AddAddStatBonusEquipment(
        ModifierDescriptor Descriptor,
        StatType Stat,
        int Value)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      
      var component =  new AddStatBonusEquipment();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusEquipmentUnlessEnchant"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedEnchantment"><see cref="BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(AddStatBonusEquipmentUnlessEnchant))]
    public TBuilder AddAddStatBonusEquipmentUnlessEnchant(
        ModifierDescriptor Descriptor,
        StatType Stat,
        int Value,
        string m_CheckedEnchantment)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      
      var component =  new AddStatBonusEquipmentUnlessEnchant();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.Value = Value;
      component.m_CheckedEnchantment = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(m_CheckedEnchantment);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddUnitFactEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Blueprint"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddUnitFactEquipment))]
    public TBuilder AddAddUnitFactEquipment(
        string m_Blueprint)
    {
      
      var component =  new AddUnitFactEquipment();
      component.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_Blueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddUnitFeatureEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Feature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddUnitFeatureEquipment))]
    public TBuilder AddAddUnitFeatureEquipment(
        string m_Feature)
    {
      
      var component =  new AddUnitFeatureEquipment();
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_Feature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AllSavesBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AllSavesBonusEquipment))]
    public TBuilder AddAllSavesBonusEquipment(
        ModifierDescriptor Descriptor,
        int Value)
    {
      ValidateParam(Descriptor);
      
      var component =  new AllSavesBonusEquipment();
      component.Descriptor = Descriptor;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstFactOwnerEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AttackBonusAgainstFactOwnerEquipment))]
    public TBuilder AddAttackBonusAgainstFactOwnerEquipment(
        string m_CheckedFact,
        int AttackBonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Descriptor);
      
      var component =  new AttackBonusAgainstFactOwnerEquipment();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintFeatureReference>(m_CheckedFact);
      component.AttackBonus = AttackBonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstFactOwnerEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(DamageBonusAgainstFactOwnerEquipment))]
    public TBuilder AddDamageBonusAgainstFactOwnerEquipment(
        string m_CheckedFact,
        int DamageBonus)
    {
      
      var component =  new DamageBonusAgainstFactOwnerEquipment();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CheckedFact);
      component.DamageBonus = DamageBonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EnchantmentAddBuffWhileInStealth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EnchantmentAddBuffWhileInStealth))]
    public TBuilder AddEnchantmentAddBuffWhileInStealth(
        EnchantmentAddBuffWhileInStealth.BuffAndDeactivateDuration[] Buffs)
    {
      foreach (var item in Buffs)
      {
        ValidateParam(item);
      }
      
      var component =  new EnchantmentAddBuffWhileInStealth();
      component.Buffs = Buffs;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EquipmentWeaponTypeDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EquipmentWeaponTypeDamageStatReplacement))]
    public TBuilder AddEquipmentWeaponTypeDamageStatReplacement(
        StatType Stat,
        bool AllNaturalAndUnarmed,
        WeaponCategory Category,
        bool RequiresFinesse)
    {
      ValidateParam(Stat);
      ValidateParam(Category);
      
      var component =  new EquipmentWeaponTypeDamageStatReplacement();
      component.Stat = Stat;
      component.AllNaturalAndUnarmed = AllNaturalAndUnarmed;
      component.Category = Category;
      component.RequiresFinesse = RequiresFinesse;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EquipmentWeaponTypeEnhancement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EquipmentWeaponTypeEnhancement))]
    public TBuilder AddEquipmentWeaponTypeEnhancement(
        int Enhancement,
        bool AllNaturalAndUnarmed,
        WeaponCategory Category)
    {
      ValidateParam(Category);
      
      var component =  new EquipmentWeaponTypeEnhancement();
      component.Enhancement = Enhancement;
      component.AllNaturalAndUnarmed = AllNaturalAndUnarmed;
      component.Category = Category;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreConcealmentAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(IgnoreConcealmentAgainstFactOwner))]
    public TBuilder AddIgnoreConcealmentAgainstFactOwner(
        string[] m_Facts,
        bool Not)
    {
      
      var component =  new IgnoreConcealmentAgainstFactOwner();
      component.m_Facts = m_Facts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.Not = Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreResistanceForDamageFromEnchantment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreResistanceForDamageFromEnchantment))]
    public TBuilder AddIgnoreResistanceForDamageFromEnchantment(
        IgnoreResistanceForDamageFromEnchantment.IgnoreType m_Type)
    {
      ValidateParam(m_Type);
      
      var component =  new IgnoreResistanceForDamageFromEnchantment();
      component.m_Type = m_Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreTargetDREnchantment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreTargetDREnchantment))]
    public TBuilder AddIgnoreTargetDREnchantment()
    {
      return AddComponent(new IgnoreTargetDREnchantment());
    }

    /// <summary>
    /// Adds <see cref="ImproveEnhancmentIfHasEnchantment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Enchantments"><see cref="BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(ImproveEnhancmentIfHasEnchantment))]
    public TBuilder AddImproveEnhancmentIfHasEnchantment(
        string[] m_Enchantments)
    {
      
      var component =  new ImproveEnhancmentIfHasEnchantment();
      component.m_Enchantments = m_Enchantments.Select(bp => BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseMaxStatEnchantment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseMaxStatEnchantment))]
    public TBuilder AddIncreaseMaxStatEnchantment(
        int Value)
    {
      
      var component =  new IncreaseMaxStatEnchantment();
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseStatEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseStatEquipment))]
    public TBuilder AddIncreaseStatEquipment(
        ModifierDescriptor Descriptor,
        StatType Stat,
        int Value)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      
      var component =  new IncreaseStatEquipment();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MithralEnchantment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MithralEnchantment))]
    public TBuilder AddMithralEnchantment()
    {
      return AddComponent(new MithralEnchantment());
    }

    /// <summary>
    /// Adds <see cref="ModifyWeaponStatsConditional"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ModifyWeaponStatsConditional))]
    public TBuilder AddModifyWeaponStatsConditional(
        ModifyWeaponStatsConditional.ModificationType m_Type,
        DamageAlignment Alignment,
        ContextValue BonusDamage,
        AlignmentComponent WielderAlignmentRestriction,
        AlignmentComponent TargetAlignmentRestriction)
    {
      ValidateParam(m_Type);
      ValidateParam(Alignment);
      ValidateParam(BonusDamage);
      ValidateParam(WielderAlignmentRestriction);
      ValidateParam(TargetAlignmentRestriction);
      
      var component =  new ModifyWeaponStatsConditional();
      component.m_Type = m_Type;
      component.Alignment = Alignment;
      component.BonusDamage = BonusDamage;
      component.WielderAlignmentRestriction = WielderAlignmentRestriction;
      component.TargetAlignmentRestriction = TargetAlignmentRestriction;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NaturalDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NaturalDamageStatReplacement))]
    public TBuilder AddNaturalDamageStatReplacement(
        StatType Stat)
    {
      ValidateParam(Stat);
      
      var component =  new NaturalDamageStatReplacement();
      component.Stat = Stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupAttackBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponGroupAttackBonusEquipment))]
    public TBuilder AddWeaponGroupAttackBonusEquipment(
        WeaponFighterGroup WeaponGroup,
        int AttackBonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(WeaponGroup);
      ValidateParam(Descriptor);
      
      var component =  new WeaponGroupAttackBonusEquipment();
      component.WeaponGroup = WeaponGroup;
      component.AttackBonus = AttackBonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupDamageBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponGroupDamageBonusEquipment))]
    public TBuilder AddWeaponGroupDamageBonusEquipment(
        WeaponFighterGroup WeaponGroup,
        int AttackBonus)
    {
      ValidateParam(WeaponGroup);
      
      var component =  new WeaponGroupDamageBonusEquipment();
      component.WeaponGroup = WeaponGroup;
      component.AttackBonus = AttackBonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponRangeTypeAttackBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponRangeTypeAttackBonusEquipment))]
    public TBuilder AddWeaponRangeTypeAttackBonusEquipment(
        WeaponRangeType RangeType,
        int AttackBonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(RangeType);
      ValidateParam(Descriptor);
      
      var component =  new WeaponRangeTypeAttackBonusEquipment();
      component.RangeType = RangeType;
      component.AttackBonus = AttackBonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PreventAbilityInterruption"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Abilities"><see cref="BlueprintActivatableAbility"/></param>
    [Generated]
    [Implements(typeof(PreventAbilityInterruption))]
    public TBuilder AddPreventAbilityInterruption(
        string[] m_Abilities)
    {
      
      var component =  new PreventAbilityInterruption();
      component.m_Abilities = m_Abilities.Select(bp => BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(bp)).ToList();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AdvanceArmorStats"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AdvanceArmorStats))]
    public TBuilder AddAdvanceArmorStats(
        int MaxDexBonusShift,
        int ArmorCheckPenaltyShift,
        int ArcaneSpellFailureShift)
    {
      
      var component =  new AdvanceArmorStats();
      component.MaxDexBonusShift = MaxDexBonusShift;
      component.ArmorCheckPenaltyShift = ArmorCheckPenaltyShift;
      component.ArcaneSpellFailureShift = ArcaneSpellFailureShift;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BrilliantEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BrilliantEnergy))]
    public TBuilder AddBrilliantEnergy()
    {
      return AddComponent(new BrilliantEnergy());
    }

    /// <summary>
    /// Adds <see cref="IncreaseWeaponDamageByBuffStack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(IncreaseWeaponDamageByBuffStack))]
    public TBuilder AddIncreaseWeaponDamageByBuffStack(
        int BonusPerStack,
        string m_CheckedBuff)
    {
      
      var component =  new IncreaseWeaponDamageByBuffStack();
      component.BonusPerStack = BonusPerStack;
      component.m_CheckedBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_CheckedBuff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseWeaponEnhancementBonusOnTargetFocus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseWeaponEnhancementBonusOnTargetFocus))]
    public TBuilder AddIncreaseWeaponEnhancementBonusOnTargetFocus(
        ContextValue BonusIncrementValue,
        ContextValue MaximumTotalEnhancementBonus,
        int m_CurrentEnhancementBonus,
        UnitReference m_FocusingTarget)
    {
      ValidateParam(BonusIncrementValue);
      ValidateParam(MaximumTotalEnhancementBonus);
      ValidateParam(m_FocusingTarget);
      
      var component =  new IncreaseWeaponEnhancementBonusOnTargetFocus();
      component.BonusIncrementValue = BonusIncrementValue;
      component.MaximumTotalEnhancementBonus = MaximumTotalEnhancementBonus;
      component.m_CurrentEnhancementBonus = m_CurrentEnhancementBonus;
      component.m_FocusingTarget = m_FocusingTarget;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MissAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(MissAgainstFactOwner))]
    public TBuilder AddMissAgainstFactOwner(
        string[] m_Facts)
    {
      
      var component =  new MissAgainstFactOwner();
      component.m_Facts = m_Facts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponAlignment))]
    public TBuilder AddWeaponAlignment(
        DamageAlignment Alignment)
    {
      ValidateParam(Alignment);
      
      var component =  new WeaponAlignment();
      component.Alignment = Alignment;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponAngelDamageDice"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_MaximizeFeature"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(WeaponAngelDamageDice))]
    public TBuilder AddWeaponAngelDamageDice(
        DiceFormula EnergyDamageDice,
        DamageEnergyType Element,
        string m_MaximizeFeature)
    {
      ValidateParam(EnergyDamageDice);
      ValidateParam(Element);
      
      var component =  new WeaponAngelDamageDice();
      component.EnergyDamageDice = EnergyDamageDice;
      component.Element = Element;
      component.m_MaximizeFeature = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_MaximizeFeature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponBuffOnAttack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(WeaponBuffOnAttack))]
    public TBuilder AddWeaponBuffOnAttack(
        string m_Buff,
        Rounds Duration,
        PrefabLink Fx)
    {
      ValidateParam(Duration);
      ValidateParam(Fx);
      
      var component =  new WeaponBuffOnAttack();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      component.Duration = Duration;
      component.Fx = Fx;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponBuffOnConfirmedCrit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(WeaponBuffOnConfirmedCrit))]
    public TBuilder AddWeaponBuffOnConfirmedCrit(
        string m_Buff,
        Rounds Duration,
        PrefabLink Fx,
        bool OnlyNatural20)
    {
      ValidateParam(Duration);
      ValidateParam(Fx);
      
      var component =  new WeaponBuffOnConfirmedCrit();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      component.Duration = Duration;
      component.Fx = Fx;
      component.OnlyNatural20 = OnlyNatural20;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponConditionalDamageDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponConditionalDamageDice))]
    public TBuilder AddWeaponConditionalDamageDice(
        DamageDescription Damage,
        bool CheckWielder,
        bool IsBane,
        ConditionsBuilder Conditions)
    {
      ValidateParam(Damage);
      
      var component =  new WeaponConditionalDamageDice();
      component.Damage = Damage;
      component.CheckWielder = CheckWielder;
      component.IsBane = IsBane;
      component.Conditions = Conditions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponConditionalEnhancementBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponConditionalEnhancementBonus))]
    public TBuilder AddWeaponConditionalEnhancementBonus(
        int EnhancementBonus,
        bool CheckWielder,
        bool IsBane,
        ConditionsBuilder Conditions)
    {
      
      var component =  new WeaponConditionalEnhancementBonus();
      component.EnhancementBonus = EnhancementBonus;
      component.CheckWielder = CheckWielder;
      component.IsBane = IsBane;
      component.Conditions = Conditions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCritAutoconfirmAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCritAutoconfirmAgainstAlignment))]
    public TBuilder AddWeaponCritAutoconfirmAgainstAlignment(
        AlignmentComponent EnemyAlignment)
    {
      ValidateParam(EnemyAlignment);
      
      var component =  new WeaponCritAutoconfirmAgainstAlignment();
      component.EnemyAlignment = EnemyAlignment;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCritAutoconfirmAgainstSize"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCritAutoconfirmAgainstSize))]
    public TBuilder AddWeaponCritAutoconfirmAgainstSize(
        Size Size)
    {
      ValidateParam(Size);
      
      var component =  new WeaponCritAutoconfirmAgainstSize();
      component.Size = Size;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponDamageAgainstAlignment))]
    public TBuilder AddWeaponDamageAgainstAlignment(
        AlignmentComponent EnemyAlignment,
        DamageAlignment WeaponAlignment,
        ContextDiceValue Value,
        DamageEnergyType DamageType)
    {
      ValidateParam(EnemyAlignment);
      ValidateParam(WeaponAlignment);
      ValidateParam(Value);
      ValidateParam(DamageType);
      
      var component =  new WeaponDamageAgainstAlignment();
      component.EnemyAlignment = EnemyAlignment;
      component.WeaponAlignment = WeaponAlignment;
      component.Value = Value;
      component.DamageType = DamageType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponDebuffOnAttack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(WeaponDebuffOnAttack))]
    public TBuilder AddWeaponDebuffOnAttack(
        string m_Buff,
        Rounds Duration,
        SavingThrowType SaveType,
        int DC,
        PrefabLink Fx)
    {
      ValidateParam(Duration);
      ValidateParam(SaveType);
      ValidateParam(Fx);
      
      var component =  new WeaponDebuffOnAttack();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      component.Duration = Duration;
      component.SaveType = SaveType;
      component.DC = DC;
      component.Fx = Fx;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponEnergyBurst"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponEnergyBurst))]
    public TBuilder AddWeaponEnergyBurst(
        DamageEnergyType Element,
        DiceType Dice)
    {
      ValidateParam(Element);
      ValidateParam(Dice);
      
      var component =  new WeaponEnergyBurst();
      component.Element = Element;
      component.Dice = Dice;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponEnergyDamageDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponEnergyDamageDice))]
    public TBuilder AddWeaponEnergyDamageDice(
        DiceFormula EnergyDamageDice,
        DamageEnergyType Element)
    {
      ValidateParam(EnergyDamageDice);
      ValidateParam(Element);
      
      var component =  new WeaponEnergyDamageDice();
      component.EnergyDamageDice = EnergyDamageDice;
      component.Element = Element;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponEnhancementBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponEnhancementBonus))]
    public TBuilder AddWeaponEnhancementBonus(
        int EnhancementBonus,
        bool Stack)
    {
      
      var component =  new WeaponEnhancementBonus();
      component.EnhancementBonus = EnhancementBonus;
      component.Stack = Stack;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponExtraAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponExtraAttack))]
    public TBuilder AddWeaponExtraAttack(
        int Number,
        bool Haste)
    {
      
      var component =  new WeaponExtraAttack();
      component.Number = Number;
      component.Haste = Haste;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponImprovised"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponImprovised))]
    public TBuilder AddWeaponImprovised()
    {
      return AddComponent(new WeaponImprovised());
    }

    /// <summary>
    /// Adds <see cref="WeaponMagic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponMagic))]
    public TBuilder AddWeaponMagic()
    {
      return AddComponent(new WeaponMagic());
    }

    /// <summary>
    /// Adds <see cref="WeaponMasterwork"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponMasterwork))]
    public TBuilder AddWeaponMasterwork()
    {
      return AddComponent(new WeaponMasterwork());
    }

    /// <summary>
    /// Adds <see cref="WeaponMaterial"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponMaterial))]
    public TBuilder AddWeaponMaterial(
        PhysicalDamageMaterial Material)
    {
      ValidateParam(Material);
      
      var component =  new WeaponMaterial();
      component.Material = Material;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponReality"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponReality))]
    public TBuilder AddWeaponReality(
        DamageRealityType Reality)
    {
      ValidateParam(Reality);
      
      var component =  new WeaponReality();
      component.Reality = Reality;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeAttackEnchant"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Type"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(WeaponTypeAttackEnchant))]
    public TBuilder AddWeaponTypeAttackEnchant(
        string m_Type,
        int Bonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Descriptor);
      
      var component =  new WeaponTypeAttackEnchant();
      component.m_Type = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(m_Type);
      component.Bonus = Bonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }
  }
}
