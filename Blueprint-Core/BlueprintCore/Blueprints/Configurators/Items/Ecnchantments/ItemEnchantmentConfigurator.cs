using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Designers.Mechanics.EquipmentEnchants;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
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
