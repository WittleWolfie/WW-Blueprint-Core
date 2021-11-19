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
using UnityEngine;
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
    /// Sets <see cref="BlueprintItem.m_DisplayNameText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDisplayNameText(LocalizedString displayNameText)
    {
      ValidateParam(displayNameText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DisplayNameText = displayNameText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_DescriptionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDescriptionText(LocalizedString descriptionText)
    {
      ValidateParam(descriptionText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DescriptionText = descriptionText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_FlavorText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetFlavorText(LocalizedString flavorText)
    {
      ValidateParam(flavorText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_FlavorText = flavorText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_NonIdentifiedNameText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetNonIdentifiedNameText(LocalizedString nonIdentifiedNameText)
    {
      ValidateParam(nonIdentifiedNameText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_NonIdentifiedNameText = nonIdentifiedNameText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_NonIdentifiedDescriptionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetNonIdentifiedDescriptionText(LocalizedString nonIdentifiedDescriptionText)
    {
      ValidateParam(nonIdentifiedDescriptionText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_NonIdentifiedDescriptionText = nonIdentifiedDescriptionText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_Icon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIcon(Sprite icon)
    {
      ValidateParam(icon);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Icon = icon;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_Cost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCost(int cost)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Cost = cost;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_Weight"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetWeight(float weight)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Weight = weight;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_IsNotable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIsNotable(bool isNotable)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IsNotable = isNotable;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_ForceStackable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetForceStackable(bool forceStackable)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ForceStackable = forceStackable;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_Destructible"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDestructible(bool destructible)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Destructible = destructible;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_ShardItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="shardItem"><see cref="BlueprintItem"/></param>
    [Generated]
    public TBuilder SetShardItem(string shardItem)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ShardItem = BlueprintTool.GetRef<BlueprintItemReference>(shardItem);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_MiscellaneousType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetMiscellaneousType(BlueprintItem.MiscellaneousItemType miscellaneousType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MiscellaneousType = miscellaneousType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_InventoryPutSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetInventoryPutSound(string inventoryPutSound)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_InventoryPutSound = inventoryPutSound;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_InventoryTakeSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetInventoryTakeSound(string inventoryTakeSound)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_InventoryTakeSound = inventoryTakeSound;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.NeedSkinningForCollect"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetNeedSkinningForCollect(bool needSkinningForCollect)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NeedSkinningForCollect = needSkinningForCollect;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.TrashLootTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetTrashLootTypes(TrashLootType[] trashLootTypes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TrashLootTypes = trashLootTypes;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintItem.TrashLootTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder AddToTrashLootTypes(params TrashLootType[] trashLootTypes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TrashLootTypes = CommonTool.Append(bp.TrashLootTypes, trashLootTypes ?? new TrashLootType[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintItem.TrashLootTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder RemoveFromTrashLootTypes(params TrashLootType[] trashLootTypes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TrashLootTypes = bp.TrashLootTypes.Where(item => !trashLootTypes.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_CachedEnchantments"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCachedEnchantments(List<BlueprintItemEnchantment> cachedEnchantments)
    {
      ValidateParam(cachedEnchantments);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedEnchantments = cachedEnchantments;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintItem.m_CachedEnchantments"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder AddToCachedEnchantments(params BlueprintItemEnchantment[] cachedEnchantments)
    {
      ValidateParam(cachedEnchantments);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedEnchantments.AddRange(cachedEnchantments.ToList() ?? new List<BlueprintItemEnchantment>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintItem.m_CachedEnchantments"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder RemoveFromCachedEnchantments(params BlueprintItemEnchantment[] cachedEnchantments)
    {
      ValidateParam(cachedEnchantments);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedEnchantments = bp.m_CachedEnchantments.Where(item => !cachedEnchantments.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Adds <see cref="ArmorEnhancementBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmorEnhancementBonus))]
    public TBuilder AddArmorEnhancementBonus(
        int enhancementValue = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArmorEnhancementBonus();
      component.EnhancementValue = enhancementValue;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ItemEnchantmentEnableWhileEtudePlaying"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="etude"><see cref="BlueprintEtude"/></param>
    [Generated]
    [Implements(typeof(ItemEnchantmentEnableWhileEtudePlaying))]
    public TBuilder AddItemEnchantmentEnableWhileEtudePlaying(
        string etude = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ItemEnchantmentEnableWhileEtudePlaying();
      component.m_Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageReroll"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponDamageReroll))]
    public TBuilder AddWeaponDamageReroll(
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponDamageReroll();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddItemShowInfoCallback"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddItemShowInfoCallback))]
    public TBuilder AddItemShowInfoCallback(
        ActionList action,
        bool once = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(action);
    
      var component = new AddItemShowInfoCallback();
      component.Once = once;
      component.Action = action;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildPointsReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuildPointsReplacement))]
    public TBuilder AddBuildPointsReplacement(
        int cost = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuildPointsReplacement();
      component.Cost = cost;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConsumableEventBonusReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ConsumableEventBonusReplacement))]
    public TBuilder AddConsumableEventBonusReplacement(
        int cost = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ConsumableEventBonusReplacement();
      component.Cost = cost;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CopyRecipe"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="recipe"><see cref="BlueprintCookingRecipe"/></param>
    [Generated]
    [Implements(typeof(CopyRecipe))]
    public TBuilder AddCopyRecipe(
        string recipe = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CopyRecipe();
      component.m_Recipe = BlueprintTool.GetRef<BlueprintCookingRecipeReference>(recipe);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CopyScroll"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="customSpell"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(CopyScroll))]
    public TBuilder AddCopyScroll(
        string customSpell = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CopyScroll();
      component.m_CustomSpell = BlueprintTool.GetRef<BlueprintAbilityReference>(customSpell);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IdentifySkillReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IdentifySkillReplacement))]
    public TBuilder AddIdentifySkillReplacement(
        IdentifySkillReplacement.SkillType skillType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IdentifySkillReplacement();
      component.m_SkillType = skillType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ItemDialog"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="dialogReference"><see cref="BlueprintDialog"/></param>
    [Generated]
    [Implements(typeof(ItemDialog))]
    public TBuilder AddItemDialog(
        ConditionsBuilder conditions = null,
        LocalizedString itemName = null,
        string dialogReference = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(itemName);
    
      var component = new ItemDialog();
      component.m_Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.m_ItemName = itemName ?? Constants.Empty.String;
      component.m_DialogReference = BlueprintTool.GetRef<BlueprintDialogReference>(dialogReference);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ItemDlcRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="dlcReward"><see cref="BlueprintDlcReward"/></param>
    /// <param name="changeTo"><see cref="BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(ItemDlcRestriction))]
    public TBuilder AddItemDlcRestriction(
        string dlcReward = null,
        string changeTo = null,
        bool hideInVendors = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ItemDlcRestriction();
      component.m_DlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(dlcReward);
      component.m_ChangeTo = BlueprintTool.GetRef<BlueprintItemReference>(changeTo);
      component.HideInVendors = hideInVendors;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ItemPolymorph"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="flagToCheck"><see cref="BlueprintUnlockableFlag"/></param>
    /// <param name="polymorphItems"><see cref="BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(ItemPolymorph))]
    public TBuilder AddItemPolymorph(
        string flagToCheck = null,
        string[] polymorphItems = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ItemPolymorph();
      component.m_FlagToCheck = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(flagToCheck);
      component.m_PolymorphItems = polymorphItems.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name)).ToList();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MoneyReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MoneyReplacement))]
    public TBuilder AddMoneyReplacement(
        long cost = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MoneyReplacement();
      component.Cost = cost;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TwoWeaponCriticalAdditionalAttackEnchant"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TwoWeaponCriticalAdditionalAttackEnchant))]
    public TBuilder AddTwoWeaponCriticalAdditionalAttackEnchant(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TwoWeaponCriticalAdditionalAttackEnchant();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SuppressBane"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SuppressBane))]
    public TBuilder AddSuppressBane(
        BlueprintComponent.Flags flags = default)
    {
      var component = new SuppressBane();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalConfirmationBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCriticalConfirmationBonus))]
    public TBuilder AddWeaponCriticalConfirmationBonus(
        ContextValue value,
        int additionalBonus = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new WeaponCriticalConfirmationBonus();
      component.Value = value;
      component.AdditionalBonus = additionalBonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalEdgeIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCriticalEdgeIncrease))]
    public TBuilder AddWeaponCriticalEdgeIncrease(
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponCriticalEdgeIncrease();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalEdgeStackable"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCriticalEdgeStackable))]
    public TBuilder AddWeaponCriticalEdgeStackable(
        int bonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponCriticalEdgeStackable();
      component.Bonus = bonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalMultiplierIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCriticalMultiplierIncrease))]
    public TBuilder AddWeaponCriticalMultiplierIncrease(
        int additionalMultiplier = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponCriticalMultiplierIncrease();
      component.AdditionalMultiplier = additionalMultiplier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageMultiplierStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponDamageMultiplierStatReplacement))]
    public TBuilder AddWeaponDamageMultiplierStatReplacement(
        StatType stat = default,
        float multiplier = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponDamageMultiplierStatReplacement();
      component.Stat = stat;
      component.Multiplier = multiplier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponDamageStatReplacement))]
    public TBuilder AddWeaponDamageStatReplacement(
        StatType stat = default,
        bool requiresFinesse = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponDamageStatReplacement();
      component.Stat = stat;
      component.RequiresFinesse = requiresFinesse;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponOversized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponOversized))]
    public TBuilder AddWeaponOversized(
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponOversized();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstFactOwnerEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ACBonusAgainstFactOwnerEquipment))]
    public TBuilder AddACBonusAgainstFactOwnerEquipment(
        string checkedFact = null,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ACBonusAgainstFactOwnerEquipment();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintFeatureReference>(checkedFact);
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCasterLevelEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spell"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddCasterLevelEquipment))]
    public TBuilder AddCasterLevelEquipment(
        string spell = null,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddCasterLevelEquipment();
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(spell);
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddConditionImmunityEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddConditionImmunityEquipment))]
    public TBuilder AddConditionImmunityEquipment(
        UnitCondition condition = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddConditionImmunityEquipment();
      component.Condition = condition;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSavesFixerArmorRecalculator"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddSavesFixerArmorRecalculator))]
    public TBuilder AddSavesFixerArmorRecalculator(
        string feature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSavesFixerArmorRecalculator();
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellbookEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbook"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(AddSpellbookEquipment))]
    public TBuilder AddSpellbookEquipment(
        string spellbook = null,
        int casterLevel = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSpellbookEquipment();
      component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(spellbook);
      component.CasterLevel = casterLevel;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddStatBonusEquipment))]
    public TBuilder AddStatBonusEquipment(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddStatBonusEquipment();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusEquipmentUnlessEnchant"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedEnchantment"><see cref="BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(AddStatBonusEquipmentUnlessEnchant))]
    public TBuilder AddStatBonusEquipmentUnlessEnchant(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int value = default,
        string checkedEnchantment = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddStatBonusEquipmentUnlessEnchant();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.m_CheckedEnchantment = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(checkedEnchantment);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddUnitFactEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blueprint"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddUnitFactEquipment))]
    public TBuilder AddUnitFactEquipment(
        string blueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddUnitFactEquipment();
      component.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitFactReference>(blueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddUnitFeatureEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddUnitFeatureEquipment))]
    public TBuilder AddUnitFeatureEquipment(
        string feature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddUnitFeatureEquipment();
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AllSavesBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AllSavesBonusEquipment))]
    public TBuilder AddAllSavesBonusEquipment(
        ModifierDescriptor descriptor = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AllSavesBonusEquipment();
      component.Descriptor = descriptor;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstFactOwnerEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AttackBonusAgainstFactOwnerEquipment))]
    public TBuilder AddAttackBonusAgainstFactOwnerEquipment(
        string checkedFact = null,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AttackBonusAgainstFactOwnerEquipment();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintFeatureReference>(checkedFact);
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstFactOwnerEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(DamageBonusAgainstFactOwnerEquipment))]
    public TBuilder AddDamageBonusAgainstFactOwnerEquipment(
        string checkedFact = null,
        int damageBonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DamageBonusAgainstFactOwnerEquipment();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.DamageBonus = damageBonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EnchantmentAddBuffWhileInStealth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EnchantmentAddBuffWhileInStealth))]
    public TBuilder AddEnchantmentAddBuffWhileInStealth(
        EnchantmentAddBuffWhileInStealth.BuffAndDeactivateDuration[] buffs = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(buffs);
    
      var component = new EnchantmentAddBuffWhileInStealth();
      component.Buffs = buffs;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EquipmentWeaponTypeDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EquipmentWeaponTypeDamageStatReplacement))]
    public TBuilder AddEquipmentWeaponTypeDamageStatReplacement(
        StatType stat = default,
        bool allNaturalAndUnarmed = default,
        WeaponCategory category = default,
        bool requiresFinesse = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EquipmentWeaponTypeDamageStatReplacement();
      component.Stat = stat;
      component.AllNaturalAndUnarmed = allNaturalAndUnarmed;
      component.Category = category;
      component.RequiresFinesse = requiresFinesse;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EquipmentWeaponTypeEnhancement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EquipmentWeaponTypeEnhancement))]
    public TBuilder AddEquipmentWeaponTypeEnhancement(
        int enhancement = default,
        bool allNaturalAndUnarmed = default,
        WeaponCategory category = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EquipmentWeaponTypeEnhancement();
      component.Enhancement = enhancement;
      component.AllNaturalAndUnarmed = allNaturalAndUnarmed;
      component.Category = category;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreConcealmentAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(IgnoreConcealmentAgainstFactOwner))]
    public TBuilder AddIgnoreConcealmentAgainstFactOwner(
        string[] facts = null,
        bool not = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreConcealmentAgainstFactOwner();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.Not = not;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreResistanceForDamageFromEnchantment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreResistanceForDamageFromEnchantment))]
    public TBuilder AddIgnoreResistanceForDamageFromEnchantment(
        IgnoreResistanceForDamageFromEnchantment.IgnoreType type = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreResistanceForDamageFromEnchantment();
      component.m_Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreTargetDREnchantment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreTargetDREnchantment))]
    public TBuilder AddIgnoreTargetDREnchantment(
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreTargetDREnchantment();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ImproveEnhancmentIfHasEnchantment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(ImproveEnhancmentIfHasEnchantment))]
    public TBuilder AddImproveEnhancmentIfHasEnchantment(
        string[] enchantments = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ImproveEnhancmentIfHasEnchantment();
      component.m_Enchantments = enchantments.Select(name => BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseMaxStatEnchantment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseMaxStatEnchantment))]
    public TBuilder AddIncreaseMaxStatEnchantment(
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseMaxStatEnchantment();
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseStatEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseStatEquipment))]
    public TBuilder AddIncreaseStatEquipment(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseStatEquipment();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MithralEnchantment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MithralEnchantment))]
    public TBuilder AddMithralEnchantment(
        BlueprintComponent.Flags flags = default)
    {
      var component = new MithralEnchantment();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ModifyWeaponStatsConditional"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ModifyWeaponStatsConditional))]
    public TBuilder AddModifyWeaponStatsConditional(
        ContextValue bonusDamage,
        ModifyWeaponStatsConditional.ModificationType type = default,
        DamageAlignment alignment = default,
        AlignmentComponent wielderAlignmentRestriction = default,
        AlignmentComponent targetAlignmentRestriction = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonusDamage);
    
      var component = new ModifyWeaponStatsConditional();
      component.m_Type = type;
      component.Alignment = alignment;
      component.BonusDamage = bonusDamage;
      component.WielderAlignmentRestriction = wielderAlignmentRestriction;
      component.TargetAlignmentRestriction = targetAlignmentRestriction;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NaturalDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NaturalDamageStatReplacement))]
    public TBuilder AddNaturalDamageStatReplacement(
        StatType stat = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new NaturalDamageStatReplacement();
      component.Stat = stat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupAttackBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponGroupAttackBonusEquipment))]
    public TBuilder AddWeaponGroupAttackBonusEquipment(
        WeaponFighterGroup weaponGroup = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponGroupAttackBonusEquipment();
      component.WeaponGroup = weaponGroup;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupDamageBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponGroupDamageBonusEquipment))]
    public TBuilder AddWeaponGroupDamageBonusEquipment(
        WeaponFighterGroup weaponGroup = default,
        int attackBonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponGroupDamageBonusEquipment();
      component.WeaponGroup = weaponGroup;
      component.AttackBonus = attackBonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponRangeTypeAttackBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponRangeTypeAttackBonusEquipment))]
    public TBuilder AddWeaponRangeTypeAttackBonusEquipment(
        WeaponRangeType rangeType = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponRangeTypeAttackBonusEquipment();
      component.RangeType = rangeType;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PreventAbilityInterruption"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilities"><see cref="BlueprintActivatableAbility"/></param>
    [Generated]
    [Implements(typeof(PreventAbilityInterruption))]
    public TBuilder AddPreventAbilityInterruption(
        string[] abilities = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new PreventAbilityInterruption();
      component.m_Abilities = abilities.Select(name => BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(name)).ToList();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AdvanceArmorStats"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AdvanceArmorStats))]
    public TBuilder AddAdvanceArmorStats(
        int maxDexBonusShift = default,
        int armorCheckPenaltyShift = default,
        int arcaneSpellFailureShift = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AdvanceArmorStats();
      component.MaxDexBonusShift = maxDexBonusShift;
      component.ArmorCheckPenaltyShift = armorCheckPenaltyShift;
      component.ArcaneSpellFailureShift = arcaneSpellFailureShift;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BrilliantEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BrilliantEnergy))]
    public TBuilder AddBrilliantEnergy(
        BlueprintComponent.Flags flags = default)
    {
      var component = new BrilliantEnergy();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseWeaponDamageByBuffStack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(IncreaseWeaponDamageByBuffStack))]
    public TBuilder AddIncreaseWeaponDamageByBuffStack(
        int bonusPerStack = default,
        string checkedBuff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseWeaponDamageByBuffStack();
      component.BonusPerStack = bonusPerStack;
      component.m_CheckedBuff = BlueprintTool.GetRef<BlueprintBuffReference>(checkedBuff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseWeaponEnhancementBonusOnTargetFocus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseWeaponEnhancementBonusOnTargetFocus))]
    public TBuilder AddIncreaseWeaponEnhancementBonusOnTargetFocus(
        ContextValue bonusIncrementValue,
        ContextValue maximumTotalEnhancementBonus,
        UnitReference focusingTarget,
        int currentEnhancementBonus = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonusIncrementValue);
      ValidateParam(maximumTotalEnhancementBonus);
    
      var component = new IncreaseWeaponEnhancementBonusOnTargetFocus();
      component.BonusIncrementValue = bonusIncrementValue;
      component.MaximumTotalEnhancementBonus = maximumTotalEnhancementBonus;
      component.m_CurrentEnhancementBonus = currentEnhancementBonus;
      component.m_FocusingTarget = focusingTarget;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MissAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(MissAgainstFactOwner))]
    public TBuilder AddMissAgainstFactOwner(
        string[] facts = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MissAgainstFactOwner();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponAlignment))]
    public TBuilder AddWeaponAlignment(
        DamageAlignment alignment = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponAlignment();
      component.Alignment = alignment;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponAngelDamageDice"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="maximizeFeature"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(WeaponAngelDamageDice))]
    public TBuilder AddWeaponAngelDamageDice(
        DiceFormula energyDamageDice,
        DamageEnergyType element = default,
        string maximizeFeature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponAngelDamageDice();
      component.EnergyDamageDice = energyDamageDice;
      component.Element = element;
      component.m_MaximizeFeature = BlueprintTool.GetRef<BlueprintUnitFactReference>(maximizeFeature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponBuffOnAttack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(WeaponBuffOnAttack))]
    public TBuilder AddWeaponBuffOnAttack(
        Rounds duration,
        string buff = null,
        PrefabLink fx = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(fx);
    
      var component = new WeaponBuffOnAttack();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.Duration = duration;
      component.Fx = fx ?? Constants.Empty.PrefabLink;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponBuffOnConfirmedCrit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(WeaponBuffOnConfirmedCrit))]
    public TBuilder AddWeaponBuffOnConfirmedCrit(
        Rounds duration,
        string buff = null,
        PrefabLink fx = null,
        bool onlyNatural20 = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(fx);
    
      var component = new WeaponBuffOnConfirmedCrit();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.Duration = duration;
      component.Fx = fx ?? Constants.Empty.PrefabLink;
      component.OnlyNatural20 = onlyNatural20;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponConditionalDamageDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponConditionalDamageDice))]
    public TBuilder AddWeaponConditionalDamageDice(
        DamageDescription damage,
        bool checkWielder = default,
        bool isBane = default,
        ConditionsBuilder conditions = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(damage);
    
      var component = new WeaponConditionalDamageDice();
      component.Damage = damage;
      component.CheckWielder = checkWielder;
      component.IsBane = isBane;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponConditionalEnhancementBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponConditionalEnhancementBonus))]
    public TBuilder AddWeaponConditionalEnhancementBonus(
        int enhancementBonus = default,
        bool checkWielder = default,
        bool isBane = default,
        ConditionsBuilder conditions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponConditionalEnhancementBonus();
      component.EnhancementBonus = enhancementBonus;
      component.CheckWielder = checkWielder;
      component.IsBane = isBane;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCritAutoconfirmAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCritAutoconfirmAgainstAlignment))]
    public TBuilder AddWeaponCritAutoconfirmAgainstAlignment(
        AlignmentComponent enemyAlignment = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponCritAutoconfirmAgainstAlignment();
      component.EnemyAlignment = enemyAlignment;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCritAutoconfirmAgainstSize"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCritAutoconfirmAgainstSize))]
    public TBuilder AddWeaponCritAutoconfirmAgainstSize(
        Size size = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponCritAutoconfirmAgainstSize();
      component.Size = size;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponDamageAgainstAlignment))]
    public TBuilder AddWeaponDamageAgainstAlignment(
        ContextDiceValue value,
        AlignmentComponent enemyAlignment = default,
        DamageAlignment weaponAlignment = default,
        DamageEnergyType damageType = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new WeaponDamageAgainstAlignment();
      component.EnemyAlignment = enemyAlignment;
      component.WeaponAlignment = weaponAlignment;
      component.Value = value;
      component.DamageType = damageType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponDebuffOnAttack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(WeaponDebuffOnAttack))]
    public TBuilder AddWeaponDebuffOnAttack(
        Rounds duration,
        string buff = null,
        SavingThrowType saveType = default,
        int dC = default,
        PrefabLink fx = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(fx);
    
      var component = new WeaponDebuffOnAttack();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.Duration = duration;
      component.SaveType = saveType;
      component.DC = dC;
      component.Fx = fx ?? Constants.Empty.PrefabLink;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponEnergyBurst"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponEnergyBurst))]
    public TBuilder AddWeaponEnergyBurst(
        DamageEnergyType element = default,
        DiceType dice = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponEnergyBurst();
      component.Element = element;
      component.Dice = dice;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponEnergyDamageDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponEnergyDamageDice))]
    public TBuilder AddWeaponEnergyDamageDice(
        DiceFormula energyDamageDice,
        DamageEnergyType element = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponEnergyDamageDice();
      component.EnergyDamageDice = energyDamageDice;
      component.Element = element;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponEnhancementBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponEnhancementBonus))]
    public TBuilder AddWeaponEnhancementBonus(
        int enhancementBonus = default,
        bool stack = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponEnhancementBonus();
      component.EnhancementBonus = enhancementBonus;
      component.Stack = stack;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponExtraAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponExtraAttack))]
    public TBuilder AddWeaponExtraAttack(
        int number = default,
        bool haste = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponExtraAttack();
      component.Number = number;
      component.Haste = haste;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponImprovised"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponImprovised))]
    public TBuilder AddWeaponImprovised(
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponImprovised();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponMagic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponMagic))]
    public TBuilder AddWeaponMagic(
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponMagic();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponMasterwork"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponMasterwork))]
    public TBuilder AddWeaponMasterwork(
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponMasterwork();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponMaterial"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponMaterial))]
    public TBuilder AddWeaponMaterial(
        PhysicalDamageMaterial material = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponMaterial();
      component.Material = material;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponReality"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponReality))]
    public TBuilder AddWeaponReality(
        DamageRealityType reality = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponReality();
      component.Reality = reality;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeAttackEnchant"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="type"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(WeaponTypeAttackEnchant))]
    public TBuilder AddWeaponTypeAttackEnchant(
        string type = null,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponTypeAttackEnchant();
      component.m_Type = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(type);
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }
  }

  /// <summary>
  /// Configurator for <see cref="BlueprintItem"/>.
  /// </summary>
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
    public static ItemConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintItem>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_DisplayNameText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetDisplayNameText(LocalizedString displayNameText)
    {
      ValidateParam(displayNameText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DisplayNameText = displayNameText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_DescriptionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetDescriptionText(LocalizedString descriptionText)
    {
      ValidateParam(descriptionText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DescriptionText = descriptionText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_FlavorText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetFlavorText(LocalizedString flavorText)
    {
      ValidateParam(flavorText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_FlavorText = flavorText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_NonIdentifiedNameText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetNonIdentifiedNameText(LocalizedString nonIdentifiedNameText)
    {
      ValidateParam(nonIdentifiedNameText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_NonIdentifiedNameText = nonIdentifiedNameText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_NonIdentifiedDescriptionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetNonIdentifiedDescriptionText(LocalizedString nonIdentifiedDescriptionText)
    {
      ValidateParam(nonIdentifiedDescriptionText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_NonIdentifiedDescriptionText = nonIdentifiedDescriptionText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_Icon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetIcon(Sprite icon)
    {
      ValidateParam(icon);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Icon = icon;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_Cost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetCost(int cost)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Cost = cost;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_Weight"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetWeight(float weight)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Weight = weight;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_IsNotable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetIsNotable(bool isNotable)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IsNotable = isNotable;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_ForceStackable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetForceStackable(bool forceStackable)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ForceStackable = forceStackable;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_Destructible"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetDestructible(bool destructible)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Destructible = destructible;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_ShardItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="shardItem"><see cref="BlueprintItem"/></param>
    [Generated]
    public ItemConfigurator SetShardItem(string shardItem)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ShardItem = BlueprintTool.GetRef<BlueprintItemReference>(shardItem);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_MiscellaneousType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetMiscellaneousType(BlueprintItem.MiscellaneousItemType miscellaneousType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MiscellaneousType = miscellaneousType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_InventoryPutSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetInventoryPutSound(string inventoryPutSound)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_InventoryPutSound = inventoryPutSound;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_InventoryTakeSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetInventoryTakeSound(string inventoryTakeSound)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_InventoryTakeSound = inventoryTakeSound;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.NeedSkinningForCollect"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetNeedSkinningForCollect(bool needSkinningForCollect)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NeedSkinningForCollect = needSkinningForCollect;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.TrashLootTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetTrashLootTypes(TrashLootType[] trashLootTypes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TrashLootTypes = trashLootTypes;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintItem.TrashLootTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator AddToTrashLootTypes(params TrashLootType[] trashLootTypes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TrashLootTypes = CommonTool.Append(bp.TrashLootTypes, trashLootTypes ?? new TrashLootType[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintItem.TrashLootTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator RemoveFromTrashLootTypes(params TrashLootType[] trashLootTypes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TrashLootTypes = bp.TrashLootTypes.Where(item => !trashLootTypes.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_CachedEnchantments"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetCachedEnchantments(List<BlueprintItemEnchantment> cachedEnchantments)
    {
      ValidateParam(cachedEnchantments);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedEnchantments = cachedEnchantments;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintItem.m_CachedEnchantments"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator AddToCachedEnchantments(params BlueprintItemEnchantment[] cachedEnchantments)
    {
      ValidateParam(cachedEnchantments);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedEnchantments.AddRange(cachedEnchantments.ToList() ?? new List<BlueprintItemEnchantment>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintItem.m_CachedEnchantments"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator RemoveFromCachedEnchantments(params BlueprintItemEnchantment[] cachedEnchantments)
    {
      ValidateParam(cachedEnchantments);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedEnchantments = bp.m_CachedEnchantments.Where(item => !cachedEnchantments.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Adds <see cref="ArmorEnhancementBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmorEnhancementBonus))]
    public ItemConfigurator AddArmorEnhancementBonus(
        int enhancementValue = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArmorEnhancementBonus();
      component.EnhancementValue = enhancementValue;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ItemEnchantmentEnableWhileEtudePlaying"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="etude"><see cref="BlueprintEtude"/></param>
    [Generated]
    [Implements(typeof(ItemEnchantmentEnableWhileEtudePlaying))]
    public ItemConfigurator AddItemEnchantmentEnableWhileEtudePlaying(
        string etude = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ItemEnchantmentEnableWhileEtudePlaying();
      component.m_Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageReroll"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponDamageReroll))]
    public ItemConfigurator AddWeaponDamageReroll(
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponDamageReroll();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddItemShowInfoCallback"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddItemShowInfoCallback))]
    public ItemConfigurator AddItemShowInfoCallback(
        ActionList action,
        bool once = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(action);
    
      var component = new AddItemShowInfoCallback();
      component.Once = once;
      component.Action = action;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildPointsReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuildPointsReplacement))]
    public ItemConfigurator AddBuildPointsReplacement(
        int cost = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuildPointsReplacement();
      component.Cost = cost;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConsumableEventBonusReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ConsumableEventBonusReplacement))]
    public ItemConfigurator AddConsumableEventBonusReplacement(
        int cost = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ConsumableEventBonusReplacement();
      component.Cost = cost;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CopyRecipe"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="recipe"><see cref="BlueprintCookingRecipe"/></param>
    [Generated]
    [Implements(typeof(CopyRecipe))]
    public ItemConfigurator AddCopyRecipe(
        string recipe = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CopyRecipe();
      component.m_Recipe = BlueprintTool.GetRef<BlueprintCookingRecipeReference>(recipe);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CopyScroll"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="customSpell"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(CopyScroll))]
    public ItemConfigurator AddCopyScroll(
        string customSpell = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CopyScroll();
      component.m_CustomSpell = BlueprintTool.GetRef<BlueprintAbilityReference>(customSpell);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IdentifySkillReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IdentifySkillReplacement))]
    public ItemConfigurator AddIdentifySkillReplacement(
        IdentifySkillReplacement.SkillType skillType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IdentifySkillReplacement();
      component.m_SkillType = skillType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ItemDialog"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="dialogReference"><see cref="BlueprintDialog"/></param>
    [Generated]
    [Implements(typeof(ItemDialog))]
    public ItemConfigurator AddItemDialog(
        ConditionsBuilder conditions = null,
        LocalizedString itemName = null,
        string dialogReference = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(itemName);
    
      var component = new ItemDialog();
      component.m_Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.m_ItemName = itemName ?? Constants.Empty.String;
      component.m_DialogReference = BlueprintTool.GetRef<BlueprintDialogReference>(dialogReference);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ItemDlcRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="dlcReward"><see cref="BlueprintDlcReward"/></param>
    /// <param name="changeTo"><see cref="BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(ItemDlcRestriction))]
    public ItemConfigurator AddItemDlcRestriction(
        string dlcReward = null,
        string changeTo = null,
        bool hideInVendors = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ItemDlcRestriction();
      component.m_DlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(dlcReward);
      component.m_ChangeTo = BlueprintTool.GetRef<BlueprintItemReference>(changeTo);
      component.HideInVendors = hideInVendors;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ItemPolymorph"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="flagToCheck"><see cref="BlueprintUnlockableFlag"/></param>
    /// <param name="polymorphItems"><see cref="BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(ItemPolymorph))]
    public ItemConfigurator AddItemPolymorph(
        string flagToCheck = null,
        string[] polymorphItems = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ItemPolymorph();
      component.m_FlagToCheck = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(flagToCheck);
      component.m_PolymorphItems = polymorphItems.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name)).ToList();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MoneyReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MoneyReplacement))]
    public ItemConfigurator AddMoneyReplacement(
        long cost = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MoneyReplacement();
      component.Cost = cost;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TwoWeaponCriticalAdditionalAttackEnchant"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TwoWeaponCriticalAdditionalAttackEnchant))]
    public ItemConfigurator AddTwoWeaponCriticalAdditionalAttackEnchant(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TwoWeaponCriticalAdditionalAttackEnchant();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SuppressBane"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SuppressBane))]
    public ItemConfigurator AddSuppressBane(
        BlueprintComponent.Flags flags = default)
    {
      var component = new SuppressBane();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalConfirmationBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCriticalConfirmationBonus))]
    public ItemConfigurator AddWeaponCriticalConfirmationBonus(
        ContextValue value,
        int additionalBonus = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new WeaponCriticalConfirmationBonus();
      component.Value = value;
      component.AdditionalBonus = additionalBonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalEdgeIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCriticalEdgeIncrease))]
    public ItemConfigurator AddWeaponCriticalEdgeIncrease(
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponCriticalEdgeIncrease();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalEdgeStackable"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCriticalEdgeStackable))]
    public ItemConfigurator AddWeaponCriticalEdgeStackable(
        int bonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponCriticalEdgeStackable();
      component.Bonus = bonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalMultiplierIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCriticalMultiplierIncrease))]
    public ItemConfigurator AddWeaponCriticalMultiplierIncrease(
        int additionalMultiplier = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponCriticalMultiplierIncrease();
      component.AdditionalMultiplier = additionalMultiplier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageMultiplierStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponDamageMultiplierStatReplacement))]
    public ItemConfigurator AddWeaponDamageMultiplierStatReplacement(
        StatType stat = default,
        float multiplier = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponDamageMultiplierStatReplacement();
      component.Stat = stat;
      component.Multiplier = multiplier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponDamageStatReplacement))]
    public ItemConfigurator AddWeaponDamageStatReplacement(
        StatType stat = default,
        bool requiresFinesse = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponDamageStatReplacement();
      component.Stat = stat;
      component.RequiresFinesse = requiresFinesse;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponOversized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponOversized))]
    public ItemConfigurator AddWeaponOversized(
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponOversized();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstFactOwnerEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ACBonusAgainstFactOwnerEquipment))]
    public ItemConfigurator AddACBonusAgainstFactOwnerEquipment(
        string checkedFact = null,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ACBonusAgainstFactOwnerEquipment();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintFeatureReference>(checkedFact);
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCasterLevelEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spell"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddCasterLevelEquipment))]
    public ItemConfigurator AddCasterLevelEquipment(
        string spell = null,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddCasterLevelEquipment();
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(spell);
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddConditionImmunityEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddConditionImmunityEquipment))]
    public ItemConfigurator AddConditionImmunityEquipment(
        UnitCondition condition = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddConditionImmunityEquipment();
      component.Condition = condition;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSavesFixerArmorRecalculator"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddSavesFixerArmorRecalculator))]
    public ItemConfigurator AddSavesFixerArmorRecalculator(
        string feature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSavesFixerArmorRecalculator();
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellbookEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbook"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(AddSpellbookEquipment))]
    public ItemConfigurator AddSpellbookEquipment(
        string spellbook = null,
        int casterLevel = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSpellbookEquipment();
      component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(spellbook);
      component.CasterLevel = casterLevel;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddStatBonusEquipment))]
    public ItemConfigurator AddStatBonusEquipment(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddStatBonusEquipment();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusEquipmentUnlessEnchant"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedEnchantment"><see cref="BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(AddStatBonusEquipmentUnlessEnchant))]
    public ItemConfigurator AddStatBonusEquipmentUnlessEnchant(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int value = default,
        string checkedEnchantment = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddStatBonusEquipmentUnlessEnchant();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.m_CheckedEnchantment = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(checkedEnchantment);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddUnitFactEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blueprint"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddUnitFactEquipment))]
    public ItemConfigurator AddUnitFactEquipment(
        string blueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddUnitFactEquipment();
      component.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitFactReference>(blueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddUnitFeatureEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddUnitFeatureEquipment))]
    public ItemConfigurator AddUnitFeatureEquipment(
        string feature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddUnitFeatureEquipment();
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AllSavesBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AllSavesBonusEquipment))]
    public ItemConfigurator AddAllSavesBonusEquipment(
        ModifierDescriptor descriptor = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AllSavesBonusEquipment();
      component.Descriptor = descriptor;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstFactOwnerEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AttackBonusAgainstFactOwnerEquipment))]
    public ItemConfigurator AddAttackBonusAgainstFactOwnerEquipment(
        string checkedFact = null,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AttackBonusAgainstFactOwnerEquipment();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintFeatureReference>(checkedFact);
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstFactOwnerEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(DamageBonusAgainstFactOwnerEquipment))]
    public ItemConfigurator AddDamageBonusAgainstFactOwnerEquipment(
        string checkedFact = null,
        int damageBonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DamageBonusAgainstFactOwnerEquipment();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.DamageBonus = damageBonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EnchantmentAddBuffWhileInStealth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EnchantmentAddBuffWhileInStealth))]
    public ItemConfigurator AddEnchantmentAddBuffWhileInStealth(
        EnchantmentAddBuffWhileInStealth.BuffAndDeactivateDuration[] buffs = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(buffs);
    
      var component = new EnchantmentAddBuffWhileInStealth();
      component.Buffs = buffs;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EquipmentWeaponTypeDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EquipmentWeaponTypeDamageStatReplacement))]
    public ItemConfigurator AddEquipmentWeaponTypeDamageStatReplacement(
        StatType stat = default,
        bool allNaturalAndUnarmed = default,
        WeaponCategory category = default,
        bool requiresFinesse = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EquipmentWeaponTypeDamageStatReplacement();
      component.Stat = stat;
      component.AllNaturalAndUnarmed = allNaturalAndUnarmed;
      component.Category = category;
      component.RequiresFinesse = requiresFinesse;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EquipmentWeaponTypeEnhancement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EquipmentWeaponTypeEnhancement))]
    public ItemConfigurator AddEquipmentWeaponTypeEnhancement(
        int enhancement = default,
        bool allNaturalAndUnarmed = default,
        WeaponCategory category = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EquipmentWeaponTypeEnhancement();
      component.Enhancement = enhancement;
      component.AllNaturalAndUnarmed = allNaturalAndUnarmed;
      component.Category = category;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreConcealmentAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(IgnoreConcealmentAgainstFactOwner))]
    public ItemConfigurator AddIgnoreConcealmentAgainstFactOwner(
        string[] facts = null,
        bool not = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreConcealmentAgainstFactOwner();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.Not = not;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreResistanceForDamageFromEnchantment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreResistanceForDamageFromEnchantment))]
    public ItemConfigurator AddIgnoreResistanceForDamageFromEnchantment(
        IgnoreResistanceForDamageFromEnchantment.IgnoreType type = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreResistanceForDamageFromEnchantment();
      component.m_Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreTargetDREnchantment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreTargetDREnchantment))]
    public ItemConfigurator AddIgnoreTargetDREnchantment(
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreTargetDREnchantment();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ImproveEnhancmentIfHasEnchantment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(ImproveEnhancmentIfHasEnchantment))]
    public ItemConfigurator AddImproveEnhancmentIfHasEnchantment(
        string[] enchantments = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ImproveEnhancmentIfHasEnchantment();
      component.m_Enchantments = enchantments.Select(name => BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseMaxStatEnchantment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseMaxStatEnchantment))]
    public ItemConfigurator AddIncreaseMaxStatEnchantment(
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseMaxStatEnchantment();
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseStatEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseStatEquipment))]
    public ItemConfigurator AddIncreaseStatEquipment(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseStatEquipment();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MithralEnchantment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MithralEnchantment))]
    public ItemConfigurator AddMithralEnchantment(
        BlueprintComponent.Flags flags = default)
    {
      var component = new MithralEnchantment();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ModifyWeaponStatsConditional"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ModifyWeaponStatsConditional))]
    public ItemConfigurator AddModifyWeaponStatsConditional(
        ContextValue bonusDamage,
        ModifyWeaponStatsConditional.ModificationType type = default,
        DamageAlignment alignment = default,
        AlignmentComponent wielderAlignmentRestriction = default,
        AlignmentComponent targetAlignmentRestriction = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonusDamage);
    
      var component = new ModifyWeaponStatsConditional();
      component.m_Type = type;
      component.Alignment = alignment;
      component.BonusDamage = bonusDamage;
      component.WielderAlignmentRestriction = wielderAlignmentRestriction;
      component.TargetAlignmentRestriction = targetAlignmentRestriction;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NaturalDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NaturalDamageStatReplacement))]
    public ItemConfigurator AddNaturalDamageStatReplacement(
        StatType stat = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new NaturalDamageStatReplacement();
      component.Stat = stat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupAttackBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponGroupAttackBonusEquipment))]
    public ItemConfigurator AddWeaponGroupAttackBonusEquipment(
        WeaponFighterGroup weaponGroup = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponGroupAttackBonusEquipment();
      component.WeaponGroup = weaponGroup;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupDamageBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponGroupDamageBonusEquipment))]
    public ItemConfigurator AddWeaponGroupDamageBonusEquipment(
        WeaponFighterGroup weaponGroup = default,
        int attackBonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponGroupDamageBonusEquipment();
      component.WeaponGroup = weaponGroup;
      component.AttackBonus = attackBonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponRangeTypeAttackBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponRangeTypeAttackBonusEquipment))]
    public ItemConfigurator AddWeaponRangeTypeAttackBonusEquipment(
        WeaponRangeType rangeType = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponRangeTypeAttackBonusEquipment();
      component.RangeType = rangeType;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PreventAbilityInterruption"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilities"><see cref="BlueprintActivatableAbility"/></param>
    [Generated]
    [Implements(typeof(PreventAbilityInterruption))]
    public ItemConfigurator AddPreventAbilityInterruption(
        string[] abilities = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new PreventAbilityInterruption();
      component.m_Abilities = abilities.Select(name => BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(name)).ToList();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AdvanceArmorStats"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AdvanceArmorStats))]
    public ItemConfigurator AddAdvanceArmorStats(
        int maxDexBonusShift = default,
        int armorCheckPenaltyShift = default,
        int arcaneSpellFailureShift = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AdvanceArmorStats();
      component.MaxDexBonusShift = maxDexBonusShift;
      component.ArmorCheckPenaltyShift = armorCheckPenaltyShift;
      component.ArcaneSpellFailureShift = arcaneSpellFailureShift;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BrilliantEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BrilliantEnergy))]
    public ItemConfigurator AddBrilliantEnergy(
        BlueprintComponent.Flags flags = default)
    {
      var component = new BrilliantEnergy();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseWeaponDamageByBuffStack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(IncreaseWeaponDamageByBuffStack))]
    public ItemConfigurator AddIncreaseWeaponDamageByBuffStack(
        int bonusPerStack = default,
        string checkedBuff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseWeaponDamageByBuffStack();
      component.BonusPerStack = bonusPerStack;
      component.m_CheckedBuff = BlueprintTool.GetRef<BlueprintBuffReference>(checkedBuff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseWeaponEnhancementBonusOnTargetFocus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseWeaponEnhancementBonusOnTargetFocus))]
    public ItemConfigurator AddIncreaseWeaponEnhancementBonusOnTargetFocus(
        ContextValue bonusIncrementValue,
        ContextValue maximumTotalEnhancementBonus,
        UnitReference focusingTarget,
        int currentEnhancementBonus = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonusIncrementValue);
      ValidateParam(maximumTotalEnhancementBonus);
    
      var component = new IncreaseWeaponEnhancementBonusOnTargetFocus();
      component.BonusIncrementValue = bonusIncrementValue;
      component.MaximumTotalEnhancementBonus = maximumTotalEnhancementBonus;
      component.m_CurrentEnhancementBonus = currentEnhancementBonus;
      component.m_FocusingTarget = focusingTarget;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MissAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(MissAgainstFactOwner))]
    public ItemConfigurator AddMissAgainstFactOwner(
        string[] facts = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MissAgainstFactOwner();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponAlignment))]
    public ItemConfigurator AddWeaponAlignment(
        DamageAlignment alignment = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponAlignment();
      component.Alignment = alignment;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponAngelDamageDice"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="maximizeFeature"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(WeaponAngelDamageDice))]
    public ItemConfigurator AddWeaponAngelDamageDice(
        DiceFormula energyDamageDice,
        DamageEnergyType element = default,
        string maximizeFeature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponAngelDamageDice();
      component.EnergyDamageDice = energyDamageDice;
      component.Element = element;
      component.m_MaximizeFeature = BlueprintTool.GetRef<BlueprintUnitFactReference>(maximizeFeature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponBuffOnAttack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(WeaponBuffOnAttack))]
    public ItemConfigurator AddWeaponBuffOnAttack(
        Rounds duration,
        string buff = null,
        PrefabLink fx = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(fx);
    
      var component = new WeaponBuffOnAttack();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.Duration = duration;
      component.Fx = fx ?? Constants.Empty.PrefabLink;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponBuffOnConfirmedCrit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(WeaponBuffOnConfirmedCrit))]
    public ItemConfigurator AddWeaponBuffOnConfirmedCrit(
        Rounds duration,
        string buff = null,
        PrefabLink fx = null,
        bool onlyNatural20 = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(fx);
    
      var component = new WeaponBuffOnConfirmedCrit();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.Duration = duration;
      component.Fx = fx ?? Constants.Empty.PrefabLink;
      component.OnlyNatural20 = onlyNatural20;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponConditionalDamageDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponConditionalDamageDice))]
    public ItemConfigurator AddWeaponConditionalDamageDice(
        DamageDescription damage,
        bool checkWielder = default,
        bool isBane = default,
        ConditionsBuilder conditions = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(damage);
    
      var component = new WeaponConditionalDamageDice();
      component.Damage = damage;
      component.CheckWielder = checkWielder;
      component.IsBane = isBane;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponConditionalEnhancementBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponConditionalEnhancementBonus))]
    public ItemConfigurator AddWeaponConditionalEnhancementBonus(
        int enhancementBonus = default,
        bool checkWielder = default,
        bool isBane = default,
        ConditionsBuilder conditions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponConditionalEnhancementBonus();
      component.EnhancementBonus = enhancementBonus;
      component.CheckWielder = checkWielder;
      component.IsBane = isBane;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCritAutoconfirmAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCritAutoconfirmAgainstAlignment))]
    public ItemConfigurator AddWeaponCritAutoconfirmAgainstAlignment(
        AlignmentComponent enemyAlignment = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponCritAutoconfirmAgainstAlignment();
      component.EnemyAlignment = enemyAlignment;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCritAutoconfirmAgainstSize"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCritAutoconfirmAgainstSize))]
    public ItemConfigurator AddWeaponCritAutoconfirmAgainstSize(
        Size size = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponCritAutoconfirmAgainstSize();
      component.Size = size;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponDamageAgainstAlignment))]
    public ItemConfigurator AddWeaponDamageAgainstAlignment(
        ContextDiceValue value,
        AlignmentComponent enemyAlignment = default,
        DamageAlignment weaponAlignment = default,
        DamageEnergyType damageType = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new WeaponDamageAgainstAlignment();
      component.EnemyAlignment = enemyAlignment;
      component.WeaponAlignment = weaponAlignment;
      component.Value = value;
      component.DamageType = damageType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponDebuffOnAttack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(WeaponDebuffOnAttack))]
    public ItemConfigurator AddWeaponDebuffOnAttack(
        Rounds duration,
        string buff = null,
        SavingThrowType saveType = default,
        int dC = default,
        PrefabLink fx = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(fx);
    
      var component = new WeaponDebuffOnAttack();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.Duration = duration;
      component.SaveType = saveType;
      component.DC = dC;
      component.Fx = fx ?? Constants.Empty.PrefabLink;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponEnergyBurst"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponEnergyBurst))]
    public ItemConfigurator AddWeaponEnergyBurst(
        DamageEnergyType element = default,
        DiceType dice = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponEnergyBurst();
      component.Element = element;
      component.Dice = dice;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponEnergyDamageDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponEnergyDamageDice))]
    public ItemConfigurator AddWeaponEnergyDamageDice(
        DiceFormula energyDamageDice,
        DamageEnergyType element = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponEnergyDamageDice();
      component.EnergyDamageDice = energyDamageDice;
      component.Element = element;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponEnhancementBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponEnhancementBonus))]
    public ItemConfigurator AddWeaponEnhancementBonus(
        int enhancementBonus = default,
        bool stack = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponEnhancementBonus();
      component.EnhancementBonus = enhancementBonus;
      component.Stack = stack;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponExtraAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponExtraAttack))]
    public ItemConfigurator AddWeaponExtraAttack(
        int number = default,
        bool haste = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponExtraAttack();
      component.Number = number;
      component.Haste = haste;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponImprovised"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponImprovised))]
    public ItemConfigurator AddWeaponImprovised(
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponImprovised();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponMagic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponMagic))]
    public ItemConfigurator AddWeaponMagic(
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponMagic();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponMasterwork"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponMasterwork))]
    public ItemConfigurator AddWeaponMasterwork(
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponMasterwork();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponMaterial"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponMaterial))]
    public ItemConfigurator AddWeaponMaterial(
        PhysicalDamageMaterial material = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponMaterial();
      component.Material = material;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponReality"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponReality))]
    public ItemConfigurator AddWeaponReality(
        DamageRealityType reality = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponReality();
      component.Reality = reality;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeAttackEnchant"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="type"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(WeaponTypeAttackEnchant))]
    public ItemConfigurator AddWeaponTypeAttackEnchant(
        string type = null,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponTypeAttackEnchant();
      component.m_Type = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(type);
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }
  }
}
