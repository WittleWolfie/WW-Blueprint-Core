using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Components;
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
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Items
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItem"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItem))]
  public abstract class BaseItemConfigurator<T, TBuilder>
      : BaseFactConfigurator<T, TBuilder>
      where T : BlueprintItem
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseItemConfigurator(string name) : base(name) { }

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
    /// Adds <see cref="AddItemShowInfoCallback"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddItemShowInfoCallback))]
    public TBuilder AddAddItemShowInfoCallback(
        bool Once,
        ActionsBuilder Action)
    {
      
      var component =  new AddItemShowInfoCallback();
      component.Once = Once;
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildPointsReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuildPointsReplacement))]
    public TBuilder AddBuildPointsReplacement(
        int Cost)
    {
      
      var component =  new BuildPointsReplacement();
      component.Cost = Cost;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConsumableEventBonusReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ConsumableEventBonusReplacement))]
    public TBuilder AddConsumableEventBonusReplacement(
        int Cost)
    {
      
      var component =  new ConsumableEventBonusReplacement();
      component.Cost = Cost;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CopyRecipe"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Recipe"><see cref="BlueprintCookingRecipe"/></param>
    [Generated]
    [Implements(typeof(CopyRecipe))]
    public TBuilder AddCopyRecipe(
        string m_Recipe)
    {
      
      var component =  new CopyRecipe();
      component.m_Recipe = BlueprintTool.GetRef<BlueprintCookingRecipeReference>(m_Recipe);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CopyScroll"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CustomSpell"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(CopyScroll))]
    public TBuilder AddCopyScroll(
        string m_CustomSpell)
    {
      
      var component =  new CopyScroll();
      component.m_CustomSpell = BlueprintTool.GetRef<BlueprintAbilityReference>(m_CustomSpell);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IdentifySkillReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IdentifySkillReplacement))]
    public TBuilder AddIdentifySkillReplacement(
        IdentifySkillReplacement.SkillType m_SkillType)
    {
      ValidateParam(m_SkillType);
      
      var component =  new IdentifySkillReplacement();
      component.m_SkillType = m_SkillType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ItemDialog"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_DialogReference"><see cref="BlueprintDialog"/></param>
    [Generated]
    [Implements(typeof(ItemDialog))]
    public TBuilder AddItemDialog(
        ConditionsBuilder m_Conditions,
        LocalizedString m_ItemName,
        string m_DialogReference)
    {
      ValidateParam(m_ItemName);
      
      var component =  new ItemDialog();
      component.m_Conditions = m_Conditions.Build();
      component.m_ItemName = m_ItemName;
      component.m_DialogReference = BlueprintTool.GetRef<BlueprintDialogReference>(m_DialogReference);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ItemDlcRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_DlcReward"><see cref="BlueprintDlcReward"/></param>
    /// <param name="m_ChangeTo"><see cref="BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(ItemDlcRestriction))]
    public TBuilder AddItemDlcRestriction(
        string m_DlcReward,
        string m_ChangeTo,
        bool HideInVendors)
    {
      
      var component =  new ItemDlcRestriction();
      component.m_DlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(m_DlcReward);
      component.m_ChangeTo = BlueprintTool.GetRef<BlueprintItemReference>(m_ChangeTo);
      component.HideInVendors = HideInVendors;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ItemPolymorph"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_FlagToCheck"><see cref="BlueprintUnlockableFlag"/></param>
    /// <param name="m_PolymorphItems"><see cref="BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(ItemPolymorph))]
    public TBuilder AddItemPolymorph(
        string m_FlagToCheck,
        string[] m_PolymorphItems)
    {
      
      var component =  new ItemPolymorph();
      component.m_FlagToCheck = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(m_FlagToCheck);
      component.m_PolymorphItems = m_PolymorphItems.Select(bp => BlueprintTool.GetRef<BlueprintItemReference>(bp)).ToList();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MoneyReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MoneyReplacement))]
    public TBuilder AddMoneyReplacement(
        long Cost)
    {
      
      var component =  new MoneyReplacement();
      component.Cost = Cost;
      return AddComponent(component);
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

  /// <summary>Configurator for <see cref="BlueprintItem"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItem))]
  public class ItemConfigurator : BaseFactConfigurator<BlueprintItem, ItemConfigurator>
  {
     private ItemConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemConfigurator For(string name)
    {
      return new ItemConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ItemConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintItem>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintItem>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="ArmorEnhancementBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmorEnhancementBonus))]
    public ItemConfigurator AddArmorEnhancementBonus(
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
    public ItemConfigurator AddItemEnchantmentEnableWhileEtudePlaying(
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
    public ItemConfigurator AddWeaponDamageReroll()
    {
      return AddComponent(new WeaponDamageReroll());
    }

    /// <summary>
    /// Adds <see cref="AddItemShowInfoCallback"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddItemShowInfoCallback))]
    public ItemConfigurator AddAddItemShowInfoCallback(
        bool Once,
        ActionsBuilder Action)
    {
      
      var component =  new AddItemShowInfoCallback();
      component.Once = Once;
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildPointsReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuildPointsReplacement))]
    public ItemConfigurator AddBuildPointsReplacement(
        int Cost)
    {
      
      var component =  new BuildPointsReplacement();
      component.Cost = Cost;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConsumableEventBonusReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ConsumableEventBonusReplacement))]
    public ItemConfigurator AddConsumableEventBonusReplacement(
        int Cost)
    {
      
      var component =  new ConsumableEventBonusReplacement();
      component.Cost = Cost;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CopyRecipe"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Recipe"><see cref="BlueprintCookingRecipe"/></param>
    [Generated]
    [Implements(typeof(CopyRecipe))]
    public ItemConfigurator AddCopyRecipe(
        string m_Recipe)
    {
      
      var component =  new CopyRecipe();
      component.m_Recipe = BlueprintTool.GetRef<BlueprintCookingRecipeReference>(m_Recipe);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CopyScroll"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CustomSpell"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(CopyScroll))]
    public ItemConfigurator AddCopyScroll(
        string m_CustomSpell)
    {
      
      var component =  new CopyScroll();
      component.m_CustomSpell = BlueprintTool.GetRef<BlueprintAbilityReference>(m_CustomSpell);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IdentifySkillReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IdentifySkillReplacement))]
    public ItemConfigurator AddIdentifySkillReplacement(
        IdentifySkillReplacement.SkillType m_SkillType)
    {
      ValidateParam(m_SkillType);
      
      var component =  new IdentifySkillReplacement();
      component.m_SkillType = m_SkillType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ItemDialog"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_DialogReference"><see cref="BlueprintDialog"/></param>
    [Generated]
    [Implements(typeof(ItemDialog))]
    public ItemConfigurator AddItemDialog(
        ConditionsBuilder m_Conditions,
        LocalizedString m_ItemName,
        string m_DialogReference)
    {
      ValidateParam(m_ItemName);
      
      var component =  new ItemDialog();
      component.m_Conditions = m_Conditions.Build();
      component.m_ItemName = m_ItemName;
      component.m_DialogReference = BlueprintTool.GetRef<BlueprintDialogReference>(m_DialogReference);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ItemDlcRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_DlcReward"><see cref="BlueprintDlcReward"/></param>
    /// <param name="m_ChangeTo"><see cref="BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(ItemDlcRestriction))]
    public ItemConfigurator AddItemDlcRestriction(
        string m_DlcReward,
        string m_ChangeTo,
        bool HideInVendors)
    {
      
      var component =  new ItemDlcRestriction();
      component.m_DlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(m_DlcReward);
      component.m_ChangeTo = BlueprintTool.GetRef<BlueprintItemReference>(m_ChangeTo);
      component.HideInVendors = HideInVendors;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ItemPolymorph"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_FlagToCheck"><see cref="BlueprintUnlockableFlag"/></param>
    /// <param name="m_PolymorphItems"><see cref="BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(ItemPolymorph))]
    public ItemConfigurator AddItemPolymorph(
        string m_FlagToCheck,
        string[] m_PolymorphItems)
    {
      
      var component =  new ItemPolymorph();
      component.m_FlagToCheck = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(m_FlagToCheck);
      component.m_PolymorphItems = m_PolymorphItems.Select(bp => BlueprintTool.GetRef<BlueprintItemReference>(bp)).ToList();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MoneyReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MoneyReplacement))]
    public ItemConfigurator AddMoneyReplacement(
        long Cost)
    {
      
      var component =  new MoneyReplacement();
      component.Cost = Cost;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TwoWeaponCriticalAdditionalAttackEnchant"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TwoWeaponCriticalAdditionalAttackEnchant))]
    public ItemConfigurator AddTwoWeaponCriticalAdditionalAttackEnchant()
    {
      return AddComponent(new TwoWeaponCriticalAdditionalAttackEnchant());
    }

    /// <summary>
    /// Adds <see cref="SuppressBane"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SuppressBane))]
    public ItemConfigurator AddSuppressBane()
    {
      return AddComponent(new SuppressBane());
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalConfirmationBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCriticalConfirmationBonus))]
    public ItemConfigurator AddWeaponCriticalConfirmationBonus(
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
    public ItemConfigurator AddWeaponCriticalEdgeIncrease()
    {
      return AddComponent(new WeaponCriticalEdgeIncrease());
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalEdgeStackable"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCriticalEdgeStackable))]
    public ItemConfigurator AddWeaponCriticalEdgeStackable(
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
    public ItemConfigurator AddWeaponCriticalMultiplierIncrease(
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
    public ItemConfigurator AddWeaponDamageMultiplierStatReplacement(
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
    public ItemConfigurator AddWeaponDamageStatReplacement(
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
    public ItemConfigurator AddWeaponOversized()
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
    public ItemConfigurator AddACBonusAgainstFactOwnerEquipment(
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
    public ItemConfigurator AddAddCasterLevelEquipment(
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
    public ItemConfigurator AddAddConditionImmunityEquipment(
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
    public ItemConfigurator AddAddSavesFixerArmorRecalculator(
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
    public ItemConfigurator AddAddSpellbookEquipment(
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
    public ItemConfigurator AddAddStatBonusEquipment(
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
    public ItemConfigurator AddAddStatBonusEquipmentUnlessEnchant(
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
    public ItemConfigurator AddAddUnitFactEquipment(
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
    public ItemConfigurator AddAddUnitFeatureEquipment(
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
    public ItemConfigurator AddAllSavesBonusEquipment(
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
    public ItemConfigurator AddAttackBonusAgainstFactOwnerEquipment(
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
    public ItemConfigurator AddDamageBonusAgainstFactOwnerEquipment(
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
    public ItemConfigurator AddEnchantmentAddBuffWhileInStealth(
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
    public ItemConfigurator AddEquipmentWeaponTypeDamageStatReplacement(
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
    public ItemConfigurator AddEquipmentWeaponTypeEnhancement(
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
    public ItemConfigurator AddIgnoreConcealmentAgainstFactOwner(
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
    public ItemConfigurator AddIgnoreResistanceForDamageFromEnchantment(
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
    public ItemConfigurator AddIgnoreTargetDREnchantment()
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
    public ItemConfigurator AddImproveEnhancmentIfHasEnchantment(
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
    public ItemConfigurator AddIncreaseMaxStatEnchantment(
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
    public ItemConfigurator AddIncreaseStatEquipment(
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
    public ItemConfigurator AddMithralEnchantment()
    {
      return AddComponent(new MithralEnchantment());
    }

    /// <summary>
    /// Adds <see cref="ModifyWeaponStatsConditional"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ModifyWeaponStatsConditional))]
    public ItemConfigurator AddModifyWeaponStatsConditional(
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
    public ItemConfigurator AddNaturalDamageStatReplacement(
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
    public ItemConfigurator AddWeaponGroupAttackBonusEquipment(
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
    public ItemConfigurator AddWeaponGroupDamageBonusEquipment(
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
    public ItemConfigurator AddWeaponRangeTypeAttackBonusEquipment(
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
    public ItemConfigurator AddPreventAbilityInterruption(
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
    public ItemConfigurator AddAdvanceArmorStats(
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
    public ItemConfigurator AddBrilliantEnergy()
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
    public ItemConfigurator AddIncreaseWeaponDamageByBuffStack(
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
    public ItemConfigurator AddIncreaseWeaponEnhancementBonusOnTargetFocus(
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
    public ItemConfigurator AddMissAgainstFactOwner(
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
    public ItemConfigurator AddWeaponAlignment(
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
    public ItemConfigurator AddWeaponAngelDamageDice(
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
    public ItemConfigurator AddWeaponBuffOnAttack(
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
    public ItemConfigurator AddWeaponBuffOnConfirmedCrit(
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
    public ItemConfigurator AddWeaponConditionalDamageDice(
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
    public ItemConfigurator AddWeaponConditionalEnhancementBonus(
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
    public ItemConfigurator AddWeaponCritAutoconfirmAgainstAlignment(
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
    public ItemConfigurator AddWeaponCritAutoconfirmAgainstSize(
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
    public ItemConfigurator AddWeaponDamageAgainstAlignment(
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
    public ItemConfigurator AddWeaponDebuffOnAttack(
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
    public ItemConfigurator AddWeaponEnergyBurst(
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
    public ItemConfigurator AddWeaponEnergyDamageDice(
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
    public ItemConfigurator AddWeaponEnhancementBonus(
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
    public ItemConfigurator AddWeaponExtraAttack(
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
    public ItemConfigurator AddWeaponImprovised()
    {
      return AddComponent(new WeaponImprovised());
    }

    /// <summary>
    /// Adds <see cref="WeaponMagic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponMagic))]
    public ItemConfigurator AddWeaponMagic()
    {
      return AddComponent(new WeaponMagic());
    }

    /// <summary>
    /// Adds <see cref="WeaponMasterwork"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponMasterwork))]
    public ItemConfigurator AddWeaponMasterwork()
    {
      return AddComponent(new WeaponMasterwork());
    }

    /// <summary>
    /// Adds <see cref="WeaponMaterial"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponMaterial))]
    public ItemConfigurator AddWeaponMaterial(
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
    public ItemConfigurator AddWeaponReality(
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
    public ItemConfigurator AddWeaponTypeAttackEnchant(
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
