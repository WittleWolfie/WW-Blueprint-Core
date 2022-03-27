//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Assets.UnitLogic.Mechanics.Actions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Blueprints.Quests;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.Settings;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Actions;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Class.Kineticist.Actions;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Utility;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Actions.Builder.ContextEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for most <see cref="ContextAction"/> types. Some <see cref="ContextAction"/> types are in more specific extensions such as <see cref="AVEx.ActionsBuilderAVEx">AVEx</see> or <see cref="KingdomEx.ActionsBuilderKingdomEx">KingdomEx</see>.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderContextEx
  {

    /// <summary>
    /// Adds <see cref="ContextActionAddFeature"/>
    /// </summary>
    ///
    /// <param name="permanentFeature">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="setRankFrom">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AddFeature(
        this ActionsBuilder builder,
        Blueprint<BlueprintFeature, BlueprintFeatureReference> permanentFeature,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? setRankFrom = null)
    {
      var element = ElementTool.Create<ContextActionAddFeature>();
      element.m_PermanentFeature = permanentFeature?.Reference;
      element.m_SetRankFrom = setRankFrom?.Reference ?? element.m_SetRankFrom;
      if (element.m_SetRankFrom is null)
      {
        element.m_SetRankFrom = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionAddLocustClone"/>
    /// </summary>
    ///
    /// <param name="cloneFeature">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AddLocustClone(
        this ActionsBuilder builder,
        Blueprint<BlueprintFeature, BlueprintFeatureReference> cloneFeature)
    {
      var element = ElementTool.Create<ContextActionAddLocustClone>();
      element.m_CloneFeature = cloneFeature?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionApplyBuff"/>
    /// </summary>
    ///
    /// <param name="buff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ApplyBuffPermanent(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference> buff,
        bool? asChild = null,
        bool? isFromSpell = null,
        bool? isNotDispelable = null,
        bool? sameDuration = null,
        bool? toCaster = null)
    {
      var element = ElementTool.Create<ContextActionApplyBuff>();
      element.m_Buff = buff?.Reference;
      element.AsChild = asChild ?? element.AsChild;
      element.IsFromSpell = isFromSpell ?? element.IsFromSpell;
      element.IsNotDispelable = isNotDispelable ?? element.IsNotDispelable;
      element.SameDuration = sameDuration ?? element.SameDuration;
      element.ToCaster = toCaster ?? element.ToCaster;
      element.Permanent = true;
      element.UseDurationSeconds = false;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionApplyBuff"/>
    /// </summary>
    ///
    /// <param name="buff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ApplyBuffWithDurationSeconds(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference> buff,
        float durationSeconds,
        bool? asChild = null,
        bool? isFromSpell = null,
        bool? isNotDispelable = null,
        bool? sameDuration = null,
        bool? toCaster = null)
    {
      var element = ElementTool.Create<ContextActionApplyBuff>();
      element.m_Buff = buff?.Reference;
      element.DurationSeconds = durationSeconds;
      element.AsChild = asChild ?? element.AsChild;
      element.IsFromSpell = isFromSpell ?? element.IsFromSpell;
      element.IsNotDispelable = isNotDispelable ?? element.IsNotDispelable;
      element.SameDuration = sameDuration ?? element.SameDuration;
      element.ToCaster = toCaster ?? element.ToCaster;
      element.Permanent = false;
      element.UseDurationSeconds = true;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionApplyBuff"/>
    /// </summary>
    ///
    /// <param name="buff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ApplyBuff(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference> buff,
        ContextDurationValue durationValue,
        bool? asChild = null,
        bool? isFromSpell = null,
        bool? isNotDispelable = null,
        bool? sameDuration = null,
        bool? toCaster = null)
    {
      var element = ElementTool.Create<ContextActionApplyBuff>();
      element.m_Buff = buff?.Reference;
      builder.Validate(durationValue);
      element.DurationValue = durationValue;
      element.AsChild = asChild ?? element.AsChild;
      element.IsFromSpell = isFromSpell ?? element.IsFromSpell;
      element.IsNotDispelable = isNotDispelable ?? element.IsNotDispelable;
      element.SameDuration = sameDuration ?? element.SameDuration;
      element.ToCaster = toCaster ?? element.ToCaster;
      element.Permanent = false;
      element.UseDurationSeconds = false;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionArmorEnchantPool"/>
    /// </summary>
    ///
    /// <remarks>
    /// The caster's armor is enchanted based on its available enhancement bonus. e.g. If the armor can be enchanted to +4 and has a +1 enchantment, enchantmentPlus3 is applied.
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SacredArmorEnchantSwitchAbility</term><description>66484ebb8d358db4692ef4445fa6ac35</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="enchantmentPlus1">
    /// Defaults to TemporaryArmorEnhancementBonus1
    /// </param>
    /// <param name="enchantmentPlus2">
    /// Defaults to TemporaryArmorEnhancementBonus2
    /// </param>
    /// <param name="enchantmentPlus3">
    /// Defaults to TemporaryArmorEnhancementBonus3
    /// </param>
    /// <param name="enchantmentPlus4">
    /// Defaults to TemporaryArmorEnhancementBonus4
    /// </param>
    /// <param name="enchantmentPlus5">
    /// Defaults to TemporaryArmorEnhancementBonus5
    /// </param>
    public static ActionsBuilder ArmorEnchantPool(
        this ActionsBuilder builder,
        ContextDurationValue durationValue,
        EnchantPoolType enchantPool,
        Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>? enchantmentPlus1 = null,
        Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>? enchantmentPlus2 = null,
        Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>? enchantmentPlus3 = null,
        Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>? enchantmentPlus4 = null,
        Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>? enchantmentPlus5 = null,
        ActivatableAbilityGroup? group = null)
    {
      var element = ElementTool.Create<ContextActionArmorEnchantPool>();
      builder.Validate(durationValue);
      element.DurationValue = durationValue;
      element.EnchantPool = enchantPool;
      element.m_DefaultEnchantments[0] = enchantmentPlus1?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus1.Reference;
      element.m_DefaultEnchantments[1] = enchantmentPlus2?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus2.Reference;
      element.m_DefaultEnchantments[2] = enchantmentPlus3?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus3.Reference;
      element.m_DefaultEnchantments[3] = enchantmentPlus4?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus4.Reference;
      element.m_DefaultEnchantments[4] = enchantmentPlus5?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus5.Reference;
      element.Group = group ?? element.Group;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionShieldArmorEnchantPool"/>
    /// </summary>
    ///
    /// <remarks>
    /// The caster's shield is enchanted based on its available enhancement bonus. e.g. If the shield can be enchanted to +4 and has a +1 enchantment, enchantmentPlus3 is applied.
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SacredArmorShieldEnchantSwitchAbility</term><description>b0777d9974795a5489ff0efd735a4c2a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="enchantmentPlus1">
    /// Defaults to TemporaryArmorEnhancementBonus1
    /// </param>
    /// <param name="enchantmentPlus2">
    /// Defaults to TemporaryArmorEnhancementBonus2
    /// </param>
    /// <param name="enchantmentPlus3">
    /// Defaults to TemporaryArmorEnhancementBonus3
    /// </param>
    /// <param name="enchantmentPlus4">
    /// Defaults to TemporaryArmorEnhancementBonus4
    /// </param>
    /// <param name="enchantmentPlus5">
    /// Defaults to TemporaryArmorEnhancementBonus5
    /// </param>
    public static ActionsBuilder ShieldArmorEnchantPool(
        this ActionsBuilder builder,
        ContextDurationValue durationValue,
        EnchantPoolType enchantPool,
        Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>? enchantmentPlus1 = null,
        Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>? enchantmentPlus2 = null,
        Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>? enchantmentPlus3 = null,
        Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>? enchantmentPlus4 = null,
        Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>? enchantmentPlus5 = null,
        ActivatableAbilityGroup? group = null)
    {
      var element = ElementTool.Create<ContextActionShieldArmorEnchantPool>();
      builder.Validate(durationValue);
      element.DurationValue = durationValue;
      element.EnchantPool = enchantPool;
      element.m_DefaultEnchantments[0] = enchantmentPlus1?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus1.Reference;
      element.m_DefaultEnchantments[1] = enchantmentPlus2?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus2.Reference;
      element.m_DefaultEnchantments[2] = enchantmentPlus3?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus3.Reference;
      element.m_DefaultEnchantments[3] = enchantmentPlus4?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus4.Reference;
      element.m_DefaultEnchantments[4] = enchantmentPlus5?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus5.Reference;
      element.Group = group ?? element.Group;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionWeaponEnchantPool"/>
    /// </summary>
    ///
    /// <remarks>
    /// The caster's weapon is enchanted based on its available enhancement bonus. e.g. If the weapon can be enchanted to +4 and has a +1 enchantment, enchantmentPlus3 is applied.
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SacredWeaponEnchantSwitchAbility</term><description>cca63747a12b55f44ad56ef2d840d7f4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="enchantmentPlus1">
    /// Defaults to TemporaryEnhancementBonus1
    /// </param>
    /// <param name="enchantmentPlus2">
    /// Defaults to TemporaryEnhancementBonus2
    /// </param>
    /// <param name="enchantmentPlus3">
    /// Defaults to TemporaryEnhancementBonus3
    /// </param>
    /// <param name="enchantmentPlus4">
    /// Defaults to TemporaryEnhancementBonus4
    /// </param>
    /// <param name="enchantmentPlus5">
    /// Defaults to TemporaryEnhancementBonus5
    /// </param>
    public static ActionsBuilder WeaponEnchantPool(
        this ActionsBuilder builder,
        ContextDurationValue durationValue,
        EnchantPoolType enchantPool,
        Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>? enchantmentPlus1 = null,
        Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>? enchantmentPlus2 = null,
        Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>? enchantmentPlus3 = null,
        Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>? enchantmentPlus4 = null,
        Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>? enchantmentPlus5 = null,
        ActivatableAbilityGroup? group = null)
    {
      var element = ElementTool.Create<ContextActionWeaponEnchantPool>();
      builder.Validate(durationValue);
      element.DurationValue = durationValue;
      element.EnchantPool = enchantPool;
      element.m_DefaultEnchantments[0] = enchantmentPlus1?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus1.Reference;
      element.m_DefaultEnchantments[1] = enchantmentPlus2?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus2.Reference;
      element.m_DefaultEnchantments[2] = enchantmentPlus3?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus3.Reference;
      element.m_DefaultEnchantments[3] = enchantmentPlus4?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus4.Reference;
      element.m_DefaultEnchantments[4] = enchantmentPlus5?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus5.Reference;
      element.Group = group ?? element.Group;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionShieldWeaponEnchantPool"/>
    /// </summary>
    ///
    /// <remarks>
    /// The caster's shield is enchanted based on its available enhancement bonus. e.g. If the shield can be enchanted to +4 and has a +1 enchantment, enchantmentPlus3 is applied.
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SacredWeaponShieldEnchantSwitchAbility</term><description>a89fc47958b895948a6c613ec1b9da85</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="enchantmentPlus1">
    /// Defaults to TemporaryEnhancementBonus1
    /// </param>
    /// <param name="enchantmentPlus2">
    /// Defaults to TemporaryEnhancementBonus2
    /// </param>
    /// <param name="enchantmentPlus3">
    /// Defaults to TemporaryEnhancementBonus3
    /// </param>
    /// <param name="enchantmentPlus4">
    /// Defaults to TemporaryEnhancementBonus4
    /// </param>
    /// <param name="enchantmentPlus5">
    /// Defaults to TemporaryEnhancementBonus5
    /// </param>
    public static ActionsBuilder ShieldWeaponEnchantPool(
        this ActionsBuilder builder,
        ContextDurationValue durationValue,
        EnchantPoolType enchantPool,
        Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>? enchantmentPlus1 = null,
        Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>? enchantmentPlus2 = null,
        Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>? enchantmentPlus3 = null,
        Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>? enchantmentPlus4 = null,
        Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>? enchantmentPlus5 = null,
        ActivatableAbilityGroup? group = null)
    {
      var element = ElementTool.Create<ContextActionShieldWeaponEnchantPool>();
      builder.Validate(durationValue);
      element.DurationValue = durationValue;
      element.EnchantPool = enchantPool;
      element.m_DefaultEnchantments[0] = enchantmentPlus1?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus1.Reference;
      element.m_DefaultEnchantments[1] = enchantmentPlus2?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus2.Reference;
      element.m_DefaultEnchantments[2] = enchantmentPlus3?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus3.Reference;
      element.m_DefaultEnchantments[3] = enchantmentPlus4?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus4.Reference;
      element.m_DefaultEnchantments[4] = enchantmentPlus5?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus5.Reference;
      element.Group = group ?? element.Group;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionAttackWithWeapon"/>
    /// </summary>
    ///
    /// <param name="weaponRef">
    /// Blueprint of type BlueprintItemWeapon. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AttackWithWeapon(
        this ActionsBuilder builder,
        StatType stat,
        Blueprint<BlueprintItemWeapon, BlueprintItemWeaponReference> weaponRef)
    {
      var element = ElementTool.Create<ContextActionAttackWithWeapon>();
      element.m_Stat = stat;
      element.m_WeaponRef = weaponRef?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionBreathOfLife"/>
    /// </summary>
    public static ActionsBuilder BreathOfLife(
        this ActionsBuilder builder,
        ContextDiceValue value)
    {
      var element = ElementTool.Create<ContextActionBreathOfLife>();
      element.Value = value;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionBreathOfMoney"/>
    /// </summary>
    public static ActionsBuilder BreathOfMoney(
        this ActionsBuilder builder,
        ContextValue maxCoins,
        ContextValue minCoins)
    {
      var element = ElementTool.Create<ContextActionBreathOfMoney>();
      element.MaxCoins = maxCoins;
      element.MinCoins = minCoins;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionCastSpell"/>
    /// </summary>
    ///
    /// <param name="spell">
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="overrideDC">
    /// Overrides the default spell DC
    /// </param>
    /// <param name="overrideSpellLevel">
    /// Overrides the default spell level
    /// </param>
    public static ActionsBuilder CastSpell(
        this ActionsBuilder builder,
        Blueprint<BlueprintAbility, BlueprintAbilityReference> spell,
        bool? castByTarget = null,
        ContextValue? overrideDC = null,
        ContextValue? overrideSpellLevel = null)
    {
      var element = ElementTool.Create<ContextActionCastSpell>();
      element.m_Spell = spell?.Reference;
      element.CastByTarget = castByTarget ?? element.CastByTarget;
      element.DC = overrideDC ?? element.DC;
      element.OverrideDC = overrideDC is not null;
      if (element.DC is null)
      {
        element.DC = ContextValues.Constant(0);
      }
      element.SpellLevel = overrideSpellLevel ?? element.SpellLevel;
      element.OverrideSpellLevel = overrideSpellLevel is not null;
      if (element.SpellLevel is null)
      {
        element.SpellLevel = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionChangeSharedValue"/>
    /// </summary>
    public static ActionsBuilder ChangeSharedValueTo(
        this ActionsBuilder builder,
        ContextValue setValue,
        AbilitySharedValue sharedValue)
    {
      var element = ElementTool.Create<ContextActionChangeSharedValue>();
      element.SetValue = setValue;
      element.SharedValue = sharedValue;
      element.Type = SharedValueChangeType.Set;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionChangeSharedValue"/>
    /// </summary>
    public static ActionsBuilder ChangeSharedValueToHD(
        this ActionsBuilder builder,
        AbilitySharedValue sharedValue)
    {
      var element = ElementTool.Create<ContextActionChangeSharedValue>();
      element.SharedValue = sharedValue;
      element.Type = SharedValueChangeType.SubHD;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionChangeSharedValue"/>
    /// </summary>
    public static ActionsBuilder ChangeSharedValueAddTo(
        this ActionsBuilder builder,
        ContextValue addValue,
        AbilitySharedValue sharedValue)
    {
      var element = ElementTool.Create<ContextActionChangeSharedValue>();
      element.AddValue = addValue;
      element.SharedValue = sharedValue;
      element.Type = SharedValueChangeType.Add;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionChangeSharedValue"/>
    /// </summary>
    public static ActionsBuilder ChangeSharedValueMultiply(
        this ActionsBuilder builder,
        ContextValue multiplyValue,
        AbilitySharedValue sharedValue)
    {
      var element = ElementTool.Create<ContextActionChangeSharedValue>();
      element.MultiplyValue = multiplyValue;
      element.SharedValue = sharedValue;
      element.Type = SharedValueChangeType.Multiply;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionChangeSharedValue"/>
    /// </summary>
    public static ActionsBuilder ChangeSharedValueDivideBy2(
        this ActionsBuilder builder,
        AbilitySharedValue sharedValue)
    {
      var element = ElementTool.Create<ContextActionChangeSharedValue>();
      element.SharedValue = sharedValue;
      element.Type = SharedValueChangeType.Div2;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionChangeSharedValue"/>
    /// </summary>
    public static ActionsBuilder ChangeSharedValueDivideBy4(
        this ActionsBuilder builder,
        AbilitySharedValue sharedValue)
    {
      var element = ElementTool.Create<ContextActionChangeSharedValue>();
      element.SharedValue = sharedValue;
      element.Type = SharedValueChangeType.Div4;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionClearSummonPool"/>
    /// </summary>
    ///
    /// <param name="summonPool">
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ClearSummonPool(
        this ActionsBuilder builder,
        Blueprint<BlueprintSummonPool, BlueprintSummonPoolReference> summonPool)
    {
      var element = ElementTool.Create<ContextActionClearSummonPool>();
      element.m_SummonPool = summonPool?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionCombatManeuver"/>
    /// </summary>
    public static ActionsBuilder CombatManeuver(
        this ActionsBuilder builder,
        ActionsBuilder onSuccess,
        CombatManeuver type,
        bool? batteringBlast = null,
        bool? ignoreConcealment = null,
        StatType? newStat = null,
        bool? useBestMentalStat = null,
        bool? useCasterLevelAsBaseAttack = null,
        bool? useCastingStat = null,
        bool? useKineticistMainStat = null)
    {
      var element = ElementTool.Create<ContextActionCombatManeuver>();
      element.OnSuccess = onSuccess?.Build();
      element.Type = type;
      element.BatteringBlast = batteringBlast ?? element.BatteringBlast;
      element.IgnoreConcealment = ignoreConcealment ?? element.IgnoreConcealment;
      element.NewStat = newStat ?? element.NewStat;
      element.UseBestMentalStat = useBestMentalStat ?? element.UseBestMentalStat;
      element.UseCasterLevelAsBaseAttack = useCasterLevelAsBaseAttack ?? element.UseCasterLevelAsBaseAttack;
      element.UseCastingStat = useCastingStat ?? element.UseCastingStat;
      element.UseKineticistMainStat = useKineticistMainStat ?? element.UseKineticistMainStat;
      element.ReplaceStat = element.NewStat != StatType.Unknown || element.UseKineticistMainStat || element.UseCastingStat || element.UseCasterLevelAsBaseAttack || element.UseBestMentalStat;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionCombatManeuverCustom"/>
    /// </summary>
    public static ActionsBuilder CombatManeuverCustom(
        this ActionsBuilder builder,
        CombatManeuver type,
        ActionsBuilder? failure = null,
        ActionsBuilder? success = null)
    {
      var element = ElementTool.Create<ContextActionCombatManeuverCustom>();
      element.Type = type;
      element.Failure = failure?.Build() ?? element.Failure;
      if (element.Failure is null)
      {
        element.Failure = BlueprintCore.Utils.Constants.Empty.Actions;
      }
      element.Success = success?.Build() ?? element.Success;
      if (element.Success is null)
      {
        element.Success = BlueprintCore.Utils.Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionDealDamage"/>
    /// </summary>
    ///
    /// <param name="criticalSharedValue">
    /// If specified and the attack roll is a critical, this shared value is set to 1
    /// </param>
    /// <param name="resultSharedValue">
    /// If specified, the resulting damage is stored in this shared value
    /// </param>
    public static ActionsBuilder DealDamage(
        this ActionsBuilder builder,
        DamageTypeDescription damageType,
        ContextDiceValue value,
        AbilitySharedValue? criticalSharedValue = null,
        bool? half = null,
        bool? halfIfSaved = null,
        bool? ignoreCritical = null,
        bool? isAoE = null,
        int? minHPAfterDamage = null,
        AbilitySharedValue? resultSharedValue = null,
        bool? setFactAsReason = null,
        bool? useWeaponDamageModifiers = null,
        bool? writeRawResultToSharedValue = null)
    {
      var element = ElementTool.Create<ContextActionDealDamage>();
      builder.Validate(damageType);
      element.DamageType = damageType;
      element.Value = value;
      element.CriticalSharedValue = criticalSharedValue ?? element.CriticalSharedValue;
      element.WriteCriticalToSharedValue = criticalSharedValue is not null;
      element.Half = half ?? element.Half;
      element.HalfIfSaved = halfIfSaved ?? element.HalfIfSaved;
      element.IgnoreCritical = ignoreCritical ?? element.IgnoreCritical;
      element.IsAoE = isAoE ?? element.IsAoE;
      element.MinHPAfterDamage = minHPAfterDamage ?? element.MinHPAfterDamage;
      element.UseMinHPAfterDamage = minHPAfterDamage is not null;
      element.ResultSharedValue = resultSharedValue ?? element.ResultSharedValue;
      element.WriteResultToSharedValue = resultSharedValue is not null;
      element.SetFactAsReason = setFactAsReason ?? element.SetFactAsReason;
      element.UseWeaponDamageModifiers = useWeaponDamageModifiers ?? element.UseWeaponDamageModifiers;
      element.WriteRawResultToSharedValue = writeRawResultToSharedValue ?? element.WriteRawResultToSharedValue;
      element.m_Type = ContextActionDealDamage.Type.Damage;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionDealDamage"/>
    /// </summary>
    ///
    /// <param name="criticalSharedValue">
    /// If specified and the attack roll is a critical, this shared value is set to 1
    /// </param>
    /// <param name="resultSharedValue">
    /// If specified, the resulting damage is stored in this shared value
    /// </param>
    public static ActionsBuilder DealDamagePreRolled(
        this ActionsBuilder builder,
        DamageTypeDescription damageType,
        AbilitySharedValue preRolledSharedValue,
        bool? alreadyHalved = null,
        AbilitySharedValue? criticalSharedValue = null,
        bool? half = null,
        bool? halfIfSaved = null,
        bool? ignoreCritical = null,
        int? minHPAfterDamage = null,
        AbilitySharedValue? resultSharedValue = null,
        bool? setFactAsReason = null,
        bool? useWeaponDamageModifiers = null,
        bool? writeRawResultToSharedValue = null)
    {
      var element = ElementTool.Create<ContextActionDealDamage>();
      builder.Validate(damageType);
      element.DamageType = damageType;
      element.PreRolledSharedValue = preRolledSharedValue;
      element.ReadPreRolledFromSharedValue = true;
      element.AlreadyHalved = alreadyHalved ?? element.AlreadyHalved;
      element.CriticalSharedValue = criticalSharedValue ?? element.CriticalSharedValue;
      element.WriteCriticalToSharedValue = criticalSharedValue is not null;
      element.Half = half ?? element.Half;
      element.HalfIfSaved = halfIfSaved ?? element.HalfIfSaved;
      element.IgnoreCritical = ignoreCritical ?? element.IgnoreCritical;
      element.MinHPAfterDamage = minHPAfterDamage ?? element.MinHPAfterDamage;
      element.UseMinHPAfterDamage = minHPAfterDamage is not null;
      element.ResultSharedValue = resultSharedValue ?? element.ResultSharedValue;
      element.WriteResultToSharedValue = resultSharedValue is not null;
      element.SetFactAsReason = setFactAsReason ?? element.SetFactAsReason;
      element.UseWeaponDamageModifiers = useWeaponDamageModifiers ?? element.UseWeaponDamageModifiers;
      element.WriteRawResultToSharedValue = writeRawResultToSharedValue ?? element.WriteRawResultToSharedValue;
      element.m_Type = ContextActionDealDamage.Type.Damage;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionDealDamage"/>
    /// </summary>
    ///
    /// <param name="criticalSharedValue">
    /// If specified and the attack roll is a critical, this shared value is set to 1
    /// </param>
    /// <param name="resultSharedValue">
    /// If specified, the resulting damage is stored in this shared value
    /// </param>
    public static ActionsBuilder DealDamageToAbility(
        this ActionsBuilder builder,
        StatType abilityType,
        ContextDiceValue value,
        AbilitySharedValue? criticalSharedValue = null,
        bool? drain = null,
        bool? halfIfSaved = null,
        bool? ignoreCritical = null,
        int? minAbilityAfterDamage = null,
        AbilitySharedValue? resultSharedValue = null,
        bool? setFactAsReason = null,
        bool? writeRawResultToSharedValue = null)
    {
      var element = ElementTool.Create<ContextActionDealDamage>();
      element.AbilityType = abilityType;
      element.Value = value;
      element.CriticalSharedValue = criticalSharedValue ?? element.CriticalSharedValue;
      element.WriteCriticalToSharedValue = criticalSharedValue is not null;
      element.Drain = drain ?? element.Drain;
      element.HalfIfSaved = halfIfSaved ?? element.HalfIfSaved;
      element.IgnoreCritical = ignoreCritical ?? element.IgnoreCritical;
      element.MinHPAfterDamage = minAbilityAfterDamage ?? element.MinHPAfterDamage;
      element.UseMinHPAfterDamage = minAbilityAfterDamage is not null;
      element.ResultSharedValue = resultSharedValue ?? element.ResultSharedValue;
      element.WriteResultToSharedValue = resultSharedValue is not null;
      element.SetFactAsReason = setFactAsReason ?? element.SetFactAsReason;
      element.WriteRawResultToSharedValue = writeRawResultToSharedValue ?? element.WriteRawResultToSharedValue;
      element.m_Type = ContextActionDealDamage.Type.AbilityDamage;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionDealDamage"/>
    /// </summary>
    ///
    /// <param name="criticalSharedValue">
    /// If specified and the attack roll is a critical, this shared value is set to 1
    /// </param>
    /// <param name="resultSharedValue">
    /// If specified, the resulting damage is stored in this shared value
    /// </param>
    public static ActionsBuilder DealDamagePermanentNegativeLevels(
        this ActionsBuilder builder,
        ContextDiceValue value,
        AbilitySharedValue? criticalSharedValue = null,
        bool? halfIfSaved = null,
        bool? ignoreCritical = null,
        AbilitySharedValue? resultSharedValue = null,
        bool? setFactAsReason = null,
        bool? useWeaponDamageModifiers = null,
        bool? writeRawResultToSharedValue = null)
    {
      var element = ElementTool.Create<ContextActionDealDamage>();
      element.Value = value;
      element.CriticalSharedValue = criticalSharedValue ?? element.CriticalSharedValue;
      element.WriteCriticalToSharedValue = criticalSharedValue is not null;
      element.HalfIfSaved = halfIfSaved ?? element.HalfIfSaved;
      element.IgnoreCritical = ignoreCritical ?? element.IgnoreCritical;
      element.ResultSharedValue = resultSharedValue ?? element.ResultSharedValue;
      element.WriteResultToSharedValue = resultSharedValue is not null;
      element.SetFactAsReason = setFactAsReason ?? element.SetFactAsReason;
      element.UseWeaponDamageModifiers = useWeaponDamageModifiers ?? element.UseWeaponDamageModifiers;
      element.WriteRawResultToSharedValue = writeRawResultToSharedValue ?? element.WriteRawResultToSharedValue;
      element.EnergyDrainType = EnergyDrainType.Permanent;
      element.m_Type = ContextActionDealDamage.Type.EnergyDrain;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionDealDamage"/>
    /// </summary>
    ///
    /// <param name="criticalSharedValue">
    /// If specified and the attack roll is a critical, this shared value is set to 1
    /// </param>
    /// <param name="resultSharedValue">
    /// If specified, the resulting damage is stored in this shared value
    /// </param>
    public static ActionsBuilder DealDamageTemporaryNegativeLevels(
        this ActionsBuilder builder,
        ContextDurationValue duration,
        ContextDiceValue value,
        AbilitySharedValue? criticalSharedValue = null,
        bool? halfIfSaved = null,
        bool? ignoreCritical = null,
        bool makePermanentOnFailedSave = false,
        AbilitySharedValue? resultSharedValue = null,
        bool? setFactAsReason = null,
        bool? useWeaponDamageModifiers = null,
        bool? writeRawResultToSharedValue = null)
    {
      var element = ElementTool.Create<ContextActionDealDamage>();
      builder.Validate(duration);
      element.Duration = duration;
      element.Value = value;
      element.CriticalSharedValue = criticalSharedValue ?? element.CriticalSharedValue;
      element.WriteCriticalToSharedValue = criticalSharedValue is not null;
      element.HalfIfSaved = halfIfSaved ?? element.HalfIfSaved;
      element.IgnoreCritical = ignoreCritical ?? element.IgnoreCritical;
      element.EnergyDrainType = makePermanentOnFailedSave ? EnergyDrainType.SaveOrBecamePermanent : EnergyDrainType.Temporary;
      element.ResultSharedValue = resultSharedValue ?? element.ResultSharedValue;
      element.WriteResultToSharedValue = resultSharedValue is not null;
      element.SetFactAsReason = setFactAsReason ?? element.SetFactAsReason;
      element.UseWeaponDamageModifiers = useWeaponDamageModifiers ?? element.UseWeaponDamageModifiers;
      element.WriteRawResultToSharedValue = writeRawResultToSharedValue ?? element.WriteRawResultToSharedValue;
      element.m_Type = ContextActionDealDamage.Type.EnergyDrain;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionDispelMagic"/>
    /// </summary>
    ///
    /// <param name="checkSchoolOrDescriptor">
    /// If true, effects matching school or descriptor are targeted. If false, effects matching school and descriptor are targeted.
    /// </param>
    public static ActionsBuilder DispelMagic(
        this ActionsBuilder builder,
        ContextActionDispelMagic.BuffType buffType,
        RuleDispelMagic.CheckType checkType,
        ContextValue maxSpellLevel,
        int? checkBonus = null,
        bool? checkSchoolOrDescriptor = null,
        ContextValue? contextBonus = null,
        ContextValue? countToRemove = null,
        SpellDescriptorWrapper? descriptor = null,
        ContextValue? maxCasterLevel = null,
        bool? oneRollForAll = null,
        ActionsBuilder? onFail = null,
        bool? onlyEnemyAreaEffects = null,
        bool? onlyTargetEnemyBuffs = null,
        ActionsBuilder? onSuccess = null,
        SpellSchool[]? schools = null,
        StatType? skill = null)
    {
      var element = ElementTool.Create<ContextActionDispelMagic>();
      element.m_BuffType = buffType;
      element.m_CheckType = checkType;
      element.m_MaxSpellLevel = maxSpellLevel;
      element.CheckBonus = checkBonus ?? element.CheckBonus;
      element.CheckSchoolOrDescriptor = checkSchoolOrDescriptor ?? element.CheckSchoolOrDescriptor;
      element.ContextBonus = contextBonus ?? element.ContextBonus;
      if (element.ContextBonus is null)
      {
        element.ContextBonus = ContextValues.Constant(0);
      }
      element.m_CountToRemove = countToRemove ?? element.m_CountToRemove;
      element.m_StopAfterCountRemoved = countToRemove is not null;
      if (element.m_CountToRemove is null)
      {
        element.m_CountToRemove = ContextValues.Constant(0);
      }
      element.Descriptor = descriptor ?? element.Descriptor;
      element.m_MaxCasterLevel = maxCasterLevel ?? element.m_MaxCasterLevel;
      element.m_UseMaxCasterLevel = maxCasterLevel is not null;
      if (element.m_MaxCasterLevel is null)
      {
        element.m_MaxCasterLevel = ContextValues.Constant(0);
      }
      element.OneRollForAll = oneRollForAll ?? element.OneRollForAll;
      element.OnFail = onFail?.Build() ?? element.OnFail;
      if (element.OnFail is null)
      {
        element.OnFail = BlueprintCore.Utils.Constants.Empty.Actions;
      }
      element.OnlyEnemyAreaEffects = onlyEnemyAreaEffects ?? element.OnlyEnemyAreaEffects;
      element.OnlyTargetEnemyBuffs = onlyTargetEnemyBuffs ?? element.OnlyTargetEnemyBuffs;
      element.OnSuccess = onSuccess?.Build() ?? element.OnSuccess;
      if (element.OnSuccess is null)
      {
        element.OnSuccess = BlueprintCore.Utils.Constants.Empty.Actions;
      }
      element.Schools = schools ?? element.Schools;
      if (element.Schools is null)
      {
        element.Schools = new SpellSchool[0];
      }
      element.m_Skill = skill ?? element.m_Skill;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionEnchantWornItem"/>
    /// </summary>
    ///
    /// <param name="enchantment">
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder EnchantWornItem(
        this ActionsBuilder builder,
        ContextDurationValue durationValue,
        Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference> enchantment,
        EquipSlotBase.SlotType slot,
        bool? permanent = null,
        bool? removeOnUnequip = null,
        bool? toCaster = null)
    {
      var element = ElementTool.Create<ContextActionEnchantWornItem>();
      builder.Validate(durationValue);
      element.DurationValue = durationValue;
      element.m_Enchantment = enchantment?.Reference;
      element.Slot = slot;
      element.Permanent = permanent ?? element.Permanent;
      element.RemoveOnUnequip = removeOnUnequip ?? element.RemoveOnUnequip;
      element.ToCaster = toCaster ?? element.ToCaster;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionFinishObjective"/>
    /// </summary>
    ///
    /// <param name="objective">
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder FinishObjective(
        this ActionsBuilder builder,
        Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference> objective)
    {
      var element = ElementTool.Create<ContextActionFinishObjective>();
      element.m_Objective = objective?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionForEachSwallowedUnit"/>
    /// </summary>
    public static ActionsBuilder ForEachSwallowedUnit(
        this ActionsBuilder builder,
        ActionsBuilder action)
    {
      var element = ElementTool.Create<ContextActionForEachSwallowedUnit>();
      element.Action = action?.Build();
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionGrapple"/>
    /// </summary>
    ///
    /// <param name="casterBuff">
    /// Buff applied to the caster for the duration of the grapple check
    /// </param>
    /// <param name="targetBuff">
    /// Buff applied to the target for the duration of the grapple check
    /// </param>
    public static ActionsBuilder Grapple(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? casterBuff = null,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? targetBuff = null)
    {
      var element = ElementTool.Create<ContextActionGrapple>();
      element.m_CasterBuff = casterBuff?.Reference ?? element.m_CasterBuff;
      if (element.m_CasterBuff is null)
      {
        element.m_CasterBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      element.m_TargetBuff = targetBuff?.Reference ?? element.m_TargetBuff;
      if (element.m_TargetBuff is null)
      {
        element.m_TargetBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionHealStatDamage"/>
    /// </summary>
    ///
    /// <param name="value">
    /// Required when the heal type is StatDamageHealType.Dice
    /// </param>
    public static ActionsBuilder HealStatDamage(
        this ActionsBuilder builder,
        ContextActionHealStatDamage.StatDamageHealType healType,
        ContextActionHealStatDamage.StatClass statClass,
        bool? healDrain = null,
        AbilitySharedValue? resultSharedValue = null,
        ContextDiceValue? value = null)
    {
      var element = ElementTool.Create<ContextActionHealStatDamage>();
      element.m_HealType = healType;
      element.m_StatClass = statClass;
      element.HealDrain = healDrain ?? element.HealDrain;
      element.ResultSharedValue = resultSharedValue ?? element.ResultSharedValue;
      element.WriteResultToSharedValue = resultSharedValue is not null;
      element.Value = value ?? element.Value;
      if (element.Value is null)
      {
        element.Value = BlueprintCore.Utils.Constants.Empty.DiceValue;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionHealTarget"/>
    /// </summary>
    public static ActionsBuilder HealTarget(
        this ActionsBuilder builder,
        ContextDiceValue value)
    {
      var element = ElementTool.Create<ContextActionHealTarget>();
      element.Value = value;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionOnContextCaster"/>
    /// </summary>
    public static ActionsBuilder OnContextCaster(
        this ActionsBuilder builder,
        ActionsBuilder actions)
    {
      var element = ElementTool.Create<ContextActionOnContextCaster>();
      element.Actions = actions?.Build();
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionOnOwner"/>
    /// </summary>
    public static ActionsBuilder OnOwner(
        this ActionsBuilder builder,
        ActionsBuilder actions)
    {
      var element = ElementTool.Create<ContextActionOnOwner>();
      element.Actions = actions?.Build();
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionOnRandomAreaTarget"/>
    /// </summary>
    ///
    /// <remarks>
    /// Only works inside of AbilityAreaEffectRunAction and only effects enemies.
    /// </remarks>
    public static ActionsBuilder OnRandomAreaTarget(
        this ActionsBuilder builder,
        ActionsBuilder actions)
    {
      var element = ElementTool.Create<ContextActionOnRandomAreaTarget>();
      element.Actions = actions?.Build();
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionOnRandomTargetsAround"/>
    /// </summary>
    ///
    /// <param name="filterNoFact">
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder OnRandomTargetsAround(
        this ActionsBuilder builder,
        ActionsBuilder actions,
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? filterNoFact = null,
        int? numberOfTargets = null,
        bool? onEnemies = null,
        Feet? radius = null)
    {
      var element = ElementTool.Create<ContextActionOnRandomTargetsAround>();
      element.Actions = actions?.Build();
      element.m_FilterNoFact = filterNoFact?.Reference ?? element.m_FilterNoFact;
      if (element.m_FilterNoFact is null)
      {
        element.m_FilterNoFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      element.NumberOfTargets = numberOfTargets ?? element.NumberOfTargets;
      element.OnEnemies = onEnemies ?? element.OnEnemies;
      element.Radius = radius ?? element.Radius;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionOnSwarmTargets"/>
    /// </summary>
    public static ActionsBuilder OnSwarmTargets(
        this ActionsBuilder builder,
        ActionsBuilder actions)
    {
      var element = ElementTool.Create<ContextActionOnSwarmTargets>();
      element.Actions = actions?.Build();
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionPartyMembers"/>
    /// </summary>
    public static ActionsBuilder PartyMembers(
        this ActionsBuilder builder,
        ActionsBuilder? action = null)
    {
      var element = ElementTool.Create<ContextActionPartyMembers>();
      element.Action = action?.Build() ?? element.Action;
      if (element.Action is null)
      {
        element.Action = BlueprintCore.Utils.Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionProjectileFx"/>
    /// </summary>
    ///
    /// <param name="projectile">
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ProjectileFx(
        this ActionsBuilder builder,
        Blueprint<BlueprintProjectile, BlueprintProjectileReference> projectile)
    {
      var element = ElementTool.Create<ContextActionProjectileFx>();
      element.m_Projectile = projectile?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRandomize"/>
    /// </summary>
    ///
    /// <param name="weightedActions">
    /// List of a pair mapping to ContextActionRandomize.ActionWrapper. Weight represents the relative probability compared to the other entries in the list.
    /// </param>
    public static ActionsBuilder Randomize(
        this ActionsBuilder builder,
        params (ActionsBuilder actions, int weight)[] weightedActions)
    {
      var element = ElementTool.Create<ContextActionRandomize>();
      foreach (var item in weightedActions) { builder.Validate(item); }
      element.m_Actions = weightedActions.Select(action => new ContextActionRandomize.ActionWrapper { Action = action.actions.Build(), Weight = action.weight }).ToArray();
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRecoverItemCharges"/>
    /// </summary>
    ///
    /// <param name="item">
    /// Blueprint of type BlueprintItemEquipment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RecoverItemCharges(
        this ActionsBuilder builder,
        Blueprint<BlueprintItemEquipment, BlueprintItemEquipmentReference> item,
        int? chargesRecoverCount = null)
    {
      var element = ElementTool.Create<ContextActionRecoverItemCharges>();
      element.m_Item = item?.Reference;
      element.ChargesRecoverCount = chargesRecoverCount ?? element.ChargesRecoverCount;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionReduceBuffDuration"/>
    /// </summary>
    ///
    /// <param name="targetBuff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder IncreaseBuffDuration(
        this ActionsBuilder builder,
        ContextDurationValue durationValue,
        Blueprint<BlueprintBuff, BlueprintBuffReference> targetBuff,
        bool? toTarget = null)
    {
      var element = ElementTool.Create<ContextActionReduceBuffDuration>();
      builder.Validate(durationValue);
      element.DurationValue = durationValue;
      element.m_TargetBuff = targetBuff?.Reference;
      element.ToTarget = toTarget ?? element.ToTarget;
      element.Increase = true;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionReduceBuffDuration"/>
    /// </summary>
    ///
    /// <param name="targetBuff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ReduceBuffDuration(
        this ActionsBuilder builder,
        ContextDurationValue durationValue,
        Blueprint<BlueprintBuff, BlueprintBuffReference> targetBuff,
        bool? toTarget = null)
    {
      var element = ElementTool.Create<ContextActionReduceBuffDuration>();
      builder.Validate(durationValue);
      element.DurationValue = durationValue;
      element.m_TargetBuff = targetBuff?.Reference;
      element.ToTarget = toTarget ?? element.ToTarget;
      element.Increase = false;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRemoveBuff"/>
    /// </summary>
    ///
    /// <param name="buff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RemoveBuff(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference> buff,
        bool? onlyFromCaster = null,
        bool? removeRank = null,
        bool? toCaster = null)
    {
      var element = ElementTool.Create<ContextActionRemoveBuff>();
      element.m_Buff = buff?.Reference;
      element.OnlyFromCaster = onlyFromCaster ?? element.OnlyFromCaster;
      element.RemoveRank = removeRank ?? element.RemoveRank;
      element.ToCaster = toCaster ?? element.ToCaster;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRemoveBuffsByDescriptor"/>
    /// </summary>
    public static ActionsBuilder RemoveBuffsByDescriptor(
        this ActionsBuilder builder,
        SpellDescriptorWrapper spellDescriptor,
        bool? notSelf = null)
    {
      var element = ElementTool.Create<ContextActionRemoveBuffsByDescriptor>();
      element.SpellDescriptor = spellDescriptor;
      element.NotSelf = notSelf ?? element.NotSelf;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRemoveBuffSingleStack"/>
    /// </summary>
    ///
    /// <param name="targetBuff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RemoveBuffSingleStack(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference> targetBuff)
    {
      var element = ElementTool.Create<ContextActionRemoveBuffSingleStack>();
      element.m_TargetBuff = targetBuff?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRepeatedActions"/>
    /// </summary>
    public static ActionsBuilder RepeatedActions(
        this ActionsBuilder builder,
        ActionsBuilder actions,
        ContextDiceValue value)
    {
      var element = ElementTool.Create<ContextActionRepeatedActions>();
      element.Actions = actions?.Build();
      element.Value = value;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRestoreSpells"/>
    /// </summary>
    ///
    /// <param name="spellbooks">
    /// Blueprint of type BlueprintSpellbook. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RestoreSpells(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintSpellbook, BlueprintSpellbookReference>> spellbooks)
    {
      var element = ElementTool.Create<ContextActionRestoreSpells>();
      element.m_Spellbooks = spellbooks?.Select(bp => bp.Reference)?.ToArray();
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionResurrect"/>
    /// </summary>
    ///
    /// <param name="customResurrectionBuff">
    /// Replaces the default resurrection buff. Must contain a ResurrectionLogic component.
    /// </param>
    /// <param name="resultHealth">
    /// Percentage of unit's health after resurrection as a float between 0.0 (0%) and 1.0 (100%).
    /// </param>
    public static ActionsBuilder Resurrect(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? customResurrectionBuff = null,
        float? resultHealth = null)
    {
      var element = ElementTool.Create<ContextActionResurrect>();
      element.m_CustomResurrectionBuff = customResurrectionBuff?.Reference ?? element.m_CustomResurrectionBuff;
      if (element.m_CustomResurrectionBuff is null)
      {
        element.m_CustomResurrectionBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      element.ResultHealth = resultHealth ?? element.ResultHealth;
      element.FullRestore = false;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionResurrect"/>
    /// </summary>
    ///
    /// <param name="customResurrectionBuff">
    /// Replaces the default resurrection buff. Must contain a ResurrectionLogic component.
    /// </param>
    public static ActionsBuilder ResurrectAndFullRestore(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? customResurrectionBuff = null)
    {
      var element = ElementTool.Create<ContextActionResurrect>();
      element.m_CustomResurrectionBuff = customResurrectionBuff?.Reference ?? element.m_CustomResurrectionBuff;
      if (element.m_CustomResurrectionBuff is null)
      {
        element.m_CustomResurrectionBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      element.FullRestore = true;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSavingThrow"/>
    /// </summary>
    ///
    /// <param name="fromBuff">
    /// If true, onResult must have a ContextActionConditionalSaved w/ ContextActionApplyBuff in it's success actions. The buff associated with that component is attached to the RuleSavingThrow.
    /// </param>
    public static ActionsBuilder SavingThrow(
        this ActionsBuilder builder,
        SavingThrowType type,
        List<(ConditionsBuilder conditions, ContextValue modifier)>? conditionalDCModifiers = null,
        ContextValue? customDC = null,
        bool? fromBuff = null,
        ActionsBuilder? onResult = null)
    {
      var element = ElementTool.Create<ContextActionSavingThrow>();
      element.Type = type;
      element.m_ConditionalDCIncrease = conditionalDCModifiers?.Select(mod => new ContextActionSavingThrow.ConditionalDCIncrease { Condition = mod.conditions.Build(), Value = mod.modifier })?.ToArray() ?? element.m_ConditionalDCIncrease;
      if (element.m_ConditionalDCIncrease is null)
      {
        element.m_ConditionalDCIncrease = new ContextActionSavingThrow.ConditionalDCIncrease[0];
      }
      element.CustomDC = customDC ?? element.CustomDC;
      element.HasCustomDC = customDC is not null;
      if (element.CustomDC is null)
      {
        element.CustomDC = ContextValues.Constant(0);
      }
      element.FromBuff = fromBuff ?? element.FromBuff;
      element.Actions = onResult?.Build() ?? element.Actions;
      if (element.Actions is null)
      {
        element.Actions = BlueprintCore.Utils.Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomSharedBurden"/>
    /// </summary>
    public static ActionsBuilder AbilityCustomSharedBurden(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<AbilityCustomSharedBurden>());
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomSharedGrace"/>
    /// </summary>
    public static ActionsBuilder AbilityCustomSharedGrace(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<AbilityCustomSharedGrace>());
    }

    /// <summary>
    /// Adds <see cref="BuffActionAddStatBonus"/>
    /// </summary>
    public static ActionsBuilder BuffActionAddStatBonus(
        this ActionsBuilder builder,
        ModifierDescriptor? descriptor = null,
        StatType? stat = null,
        ContextValue? value = null)
    {
      var element = ElementTool.Create<BuffActionAddStatBonus>();
      element.Descriptor = descriptor ?? element.Descriptor;
      element.Stat = stat ?? element.Stat;
      element.Value = value ?? element.Value;
      if (element.Value is null)
      {
        element.Value = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionAcceptBurn"/>
    /// </summary>
    public static ActionsBuilder AcceptBurn(
        this ActionsBuilder builder,
        ContextValue? value = null)
    {
      var element = ElementTool.Create<ContextActionAcceptBurn>();
      element.Value = value ?? element.Value;
      if (element.Value is null)
      {
        element.Value = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionAddRandomTrashItem"/>
    /// </summary>
    public static ActionsBuilder AddRandomTrashItem(
        this ActionsBuilder builder,
        bool? identify = null,
        TrashLootType? lootType = null,
        int? maxCost = null,
        bool? silent = null)
    {
      var element = ElementTool.Create<ContextActionAddRandomTrashItem>();
      element.m_Identify = identify ?? element.m_Identify;
      element.m_LootType = lootType ?? element.m_LootType;
      element.m_MaxCost = maxCost ?? element.m_MaxCost;
      element.m_Silent = silent ?? element.m_Silent;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionAeonRollbackToSavedState"/>
    /// </summary>
    public static ActionsBuilder AeonRollbackToSavedState(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionAeonRollbackToSavedState>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionBatteringBlast"/>
    /// </summary>
    public static ActionsBuilder BatteringBlast(
        this ActionsBuilder builder,
        bool? remove = null)
    {
      var element = ElementTool.Create<ContextActionBatteringBlast>();
      element.Remove = remove ?? element.Remove;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionBreakFree"/>
    /// </summary>
    public static ActionsBuilder BreakFree(
        this ActionsBuilder builder,
        ActionsBuilder? failure = null,
        ActionsBuilder? success = null,
        bool? useCMB = null,
        bool? useCMD = null)
    {
      var element = ElementTool.Create<ContextActionBreakFree>();
      element.Failure = failure?.Build() ?? element.Failure;
      if (element.Failure is null)
      {
        element.Failure = BlueprintCore.Utils.Constants.Empty.Actions;
      }
      element.Success = success?.Build() ?? element.Success;
      if (element.Success is null)
      {
        element.Success = BlueprintCore.Utils.Constants.Empty.Actions;
      }
      element.UseCMB = useCMB ?? element.UseCMB;
      element.UseCMD = useCMD ?? element.UseCMD;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionConditionalSaved"/>
    /// </summary>
    public static ActionsBuilder ConditionalSaved(
        this ActionsBuilder builder,
        ActionsBuilder? failed = null,
        ActionsBuilder? succeed = null)
    {
      var element = ElementTool.Create<ContextActionConditionalSaved>();
      element.Failed = failed?.Build() ?? element.Failed;
      if (element.Failed is null)
      {
        element.Failed = BlueprintCore.Utils.Constants.Empty.Actions;
      }
      element.Succeed = succeed?.Build() ?? element.Succeed;
      if (element.Succeed is null)
      {
        element.Succeed = BlueprintCore.Utils.Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionDealWeaponDamage"/>
    /// </summary>
    public static ActionsBuilder DealWeaponDamage(
        this ActionsBuilder builder,
        bool? canBeRanged = null,
        bool? ignoreAttackRoll = null)
    {
      var element = ElementTool.Create<ContextActionDealWeaponDamage>();
      element.CanBeRanged = canBeRanged ?? element.CanBeRanged;
      element.IgnoreAttackRoll = ignoreAttackRoll ?? element.IgnoreAttackRoll;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionDetachFromSpawner"/>
    /// </summary>
    public static ActionsBuilder DetachFromSpawner(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDetachFromSpawner>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionDetectSecretDoors"/>
    /// </summary>
    public static ActionsBuilder DetectSecretDoors(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDetectSecretDoors>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionDevourBySwarm"/>
    /// </summary>
    public static ActionsBuilder DevourBySwarm(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDevourBySwarm>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionDisarm"/>
    /// </summary>
    public static ActionsBuilder Disarm(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDisarm>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionDismissAreaEffect"/>
    /// </summary>
    public static ActionsBuilder DismissAreaEffect(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDismissAreaEffect>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionDismount"/>
    /// </summary>
    public static ActionsBuilder Dismount(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDismount>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionDropItems"/>
    /// </summary>
    public static ActionsBuilder DropItems(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDropItems>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionGiveExperience"/>
    /// </summary>
    public static ActionsBuilder GiveExperience(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionGiveExperience>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionHealBurn"/>
    /// </summary>
    public static ActionsBuilder HealBurn(
        this ActionsBuilder builder,
        ContextValue? value = null)
    {
      var element = ElementTool.Create<ContextActionHealBurn>();
      element.Value = value ?? element.Value;
      if (element.Value is null)
      {
        element.Value = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionHealEnergyDrain"/>
    /// </summary>
    public static ActionsBuilder HealEnergyDrain(
        this ActionsBuilder builder,
        EnergyDrainHealType? permanentNegativeLevelsHeal = null,
        EnergyDrainHealType? temporaryNegativeLevelsHeal = null)
    {
      var element = ElementTool.Create<ContextActionHealEnergyDrain>();
      element.PermanentNegativeLevelsHeal = permanentNegativeLevelsHeal ?? element.PermanentNegativeLevelsHeal;
      element.TemporaryNegativeLevelsHeal = temporaryNegativeLevelsHeal ?? element.TemporaryNegativeLevelsHeal;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionHideInPlainSight"/>
    /// </summary>
    public static ActionsBuilder HideInPlainSight(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionHideInPlainSight>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionKill"/>
    /// </summary>
    public static ActionsBuilder Kill(
        this ActionsBuilder builder,
        UnitState.DismemberType? dismember = null)
    {
      var element = ElementTool.Create<ContextActionKill>();
      element.Dismember = dismember ?? element.Dismember;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionKnockdownTarget"/>
    /// </summary>
    public static ActionsBuilder KnockdownTarget(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionKnockdownTarget>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionMakeKnowledgeCheck"/>
    /// </summary>
    public static ActionsBuilder MakeKnowledgeCheck(
        this ActionsBuilder builder,
        ActionsBuilder? failActions = null,
        ActionsBuilder? successActions = null)
    {
      var element = ElementTool.Create<ContextActionMakeKnowledgeCheck>();
      element.FailActions = failActions?.Build() ?? element.FailActions;
      if (element.FailActions is null)
      {
        element.FailActions = BlueprintCore.Utils.Constants.Empty.Actions;
      }
      element.SuccessActions = successActions?.Build() ?? element.SuccessActions;
      if (element.SuccessActions is null)
      {
        element.SuccessActions = BlueprintCore.Utils.Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionMarkForceDismemberOwner"/>
    /// </summary>
    public static ActionsBuilder MarkForceDismemberOwner(
        this ActionsBuilder builder,
        UnitState.DismemberType? forceDismemberType = null)
    {
      var element = ElementTool.Create<ContextActionMarkForceDismemberOwner>();
      element.ForceDismemberType = forceDismemberType ?? element.ForceDismemberType;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionMeleeAttack"/>
    /// </summary>
    public static ActionsBuilder MeleeAttack(
        this ActionsBuilder builder,
        bool? autoCritConfirmation = null,
        bool? autoCritThreat = null,
        bool? autoHit = null,
        bool? extraAttack = null,
        bool? fullAttack = null,
        bool? ignoreStatBonus = null,
        bool? selectNewTarget = null)
    {
      var element = ElementTool.Create<ContextActionMeleeAttack>();
      element.AutoCritConfirmation = autoCritConfirmation ?? element.AutoCritConfirmation;
      element.AutoCritThreat = autoCritThreat ?? element.AutoCritThreat;
      element.AutoHit = autoHit ?? element.AutoHit;
      element.ExtraAttack = extraAttack ?? element.ExtraAttack;
      element.FullAttack = fullAttack ?? element.FullAttack;
      element.IgnoreStatBonus = ignoreStatBonus ?? element.IgnoreStatBonus;
      element.SelectNewTarget = selectNewTarget ?? element.SelectNewTarget;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionMount"/>
    /// </summary>
    public static ActionsBuilder Mount(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionMount>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionPrintHDRestrictionToCombatLog"/>
    /// </summary>
    public static ActionsBuilder PrintHDRestrictionToCombatLog(
        this ActionsBuilder builder,
        ContextValue? hitDice = null)
    {
      var element = ElementTool.Create<ContextActionPrintHDRestrictionToCombatLog>();
      element.HitDice = hitDice ?? element.HitDice;
      if (element.HitDice is null)
      {
        element.HitDice = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionProvokeAttackFromCaster"/>
    /// </summary>
    public static ActionsBuilder ProvokeAttackFromCaster(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionProvokeAttackFromCaster>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionProvokeAttackOfOpportunity"/>
    /// </summary>
    public static ActionsBuilder ProvokeAttackOfOpportunity(
        this ActionsBuilder builder,
        bool? applyToCaster = null)
    {
      var element = ElementTool.Create<ContextActionProvokeAttackOfOpportunity>();
      element.ApplyToCaster = applyToCaster ?? element.ApplyToCaster;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionPush"/>
    /// </summary>
    public static ActionsBuilder Push(
        this ActionsBuilder builder,
        ContextValue? distance = null,
        bool? provokeAttackOfOpportunity = null)
    {
      var element = ElementTool.Create<ContextActionPush>();
      element.Distance = distance ?? element.Distance;
      if (element.Distance is null)
      {
        element.Distance = ContextValues.Constant(0);
      }
      element.ProvokeAttackOfOpportunity = provokeAttackOfOpportunity ?? element.ProvokeAttackOfOpportunity;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRangedAttack"/>
    /// </summary>
    public static ActionsBuilder RangedAttack(
        this ActionsBuilder builder,
        bool? autoCritConfirmation = null,
        bool? autoCritThreat = null,
        bool? autoHit = null,
        bool? extraAttack = null,
        bool? fullAttack = null,
        bool? ignoreStatBonus = null,
        bool? selectNewTarget = null)
    {
      var element = ElementTool.Create<ContextActionRangedAttack>();
      element.AutoCritConfirmation = autoCritConfirmation ?? element.AutoCritConfirmation;
      element.AutoCritThreat = autoCritThreat ?? element.AutoCritThreat;
      element.AutoHit = autoHit ?? element.AutoHit;
      element.ExtraAttack = extraAttack ?? element.ExtraAttack;
      element.FullAttack = fullAttack ?? element.FullAttack;
      element.IgnoreStatBonus = ignoreStatBonus ?? element.IgnoreStatBonus;
      element.SelectNewTarget = selectNewTarget ?? element.SelectNewTarget;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionReduceDebilitatingBuffsDuration"/>
    /// </summary>
    public static ActionsBuilder ReduceDebilitatingBuffsDuration(
        this ActionsBuilder builder,
        StatsAdjustmentsType? statsAdjustmentsType = null)
    {
      var element = ElementTool.Create<ContextActionReduceDebilitatingBuffsDuration>();
      element.StatsAdjustmentsType = statsAdjustmentsType ?? element.StatsAdjustmentsType;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRemoveDeathDoor"/>
    /// </summary>
    public static ActionsBuilder RemoveDeathDoor(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionRemoveDeathDoor>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionRemoveSelf"/>
    /// </summary>
    public static ActionsBuilder RemoveSelf(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionRemoveSelf>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionResetAlignment"/>
    /// </summary>
    public static ActionsBuilder ResetAlignment(
        this ActionsBuilder builder,
        bool? resetAlignmentLock = null)
    {
      var element = ElementTool.Create<ContextActionResetAlignment>();
      element.m_ResetAlignmentLock = resetAlignmentLock ?? element.m_ResetAlignmentLock;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRestoreAllSpellSlots"/>
    /// </summary>
    ///
    /// <param name="excludeSpellbooks">
    /// Blueprint of type BlueprintSpellbook. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RestoreAllSpellSlots(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintSpellbook, BlueprintSpellbookReference>>? excludeSpellbooks = null,
        UnitEvaluator? target = null,
        int? upToSpellLevel = null)
    {
      var element = ElementTool.Create<ContextActionRestoreAllSpellSlots>();
      element.m_ExcludeSpellbooks = excludeSpellbooks?.Select(bp => bp.Reference)?.ToList() ?? element.m_ExcludeSpellbooks;
      if (element.m_ExcludeSpellbooks is null)
      {
        element.m_ExcludeSpellbooks = new();
      }
      builder.Validate(target);
      element.m_Target = target ?? element.m_Target;
      element.m_UpToSpellLevel = upToSpellLevel ?? element.m_UpToSpellLevel;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSelectByValue"/>
    /// </summary>
    public static ActionsBuilder SelectByValue(
        this ActionsBuilder builder,
        ContextActionSelectByValue.SelectionType? type = null,
        ContextActionSelectByValue.ValueAndAction[]? variants = null)
    {
      var element = ElementTool.Create<ContextActionSelectByValue>();
      element.m_Type = type ?? element.m_Type;
      element.m_Variants = variants ?? element.m_Variants;
      if (element.m_Variants is null)
      {
        element.m_Variants = new ContextActionSelectByValue.ValueAndAction[0];
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSkillCheck"/>
    /// </summary>
    public static ActionsBuilder SkillCheck(
        this ActionsBuilder builder,
        bool? calculateDCDifference = null,
        ContextActionSkillCheck.ConditionalDCIncrease[]? conditionalDCIncrease = null,
        ContextValue? customDC = null,
        ActionsBuilder? failure = null,
        ActionsBuilder? failureDiffMoreOrEqual10 = null,
        ActionsBuilder? failureDiffMoreOrEqual5Less10 = null,
        StatType? stat = null,
        ActionsBuilder? success = null,
        bool? useCustomDC = null)
    {
      var element = ElementTool.Create<ContextActionSkillCheck>();
      element.CalculateDCDifference = calculateDCDifference ?? element.CalculateDCDifference;
      element.m_ConditionalDCIncrease = conditionalDCIncrease ?? element.m_ConditionalDCIncrease;
      if (element.m_ConditionalDCIncrease is null)
      {
        element.m_ConditionalDCIncrease = new ContextActionSkillCheck.ConditionalDCIncrease[0];
      }
      element.CustomDC = customDC ?? element.CustomDC;
      if (element.CustomDC is null)
      {
        element.CustomDC = ContextValues.Constant(0);
      }
      element.Failure = failure?.Build() ?? element.Failure;
      if (element.Failure is null)
      {
        element.Failure = BlueprintCore.Utils.Constants.Empty.Actions;
      }
      element.FailureDiffMoreOrEqual10 = failureDiffMoreOrEqual10?.Build() ?? element.FailureDiffMoreOrEqual10;
      if (element.FailureDiffMoreOrEqual10 is null)
      {
        element.FailureDiffMoreOrEqual10 = BlueprintCore.Utils.Constants.Empty.Actions;
      }
      element.FailureDiffMoreOrEqual5Less10 = failureDiffMoreOrEqual5Less10?.Build() ?? element.FailureDiffMoreOrEqual5Less10;
      if (element.FailureDiffMoreOrEqual5Less10 is null)
      {
        element.FailureDiffMoreOrEqual5Less10 = BlueprintCore.Utils.Constants.Empty.Actions;
      }
      element.Stat = stat ?? element.Stat;
      element.Success = success?.Build() ?? element.Success;
      if (element.Success is null)
      {
        element.Success = BlueprintCore.Utils.Constants.Empty.Actions;
      }
      element.UseCustomDC = useCustomDC ?? element.UseCustomDC;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionsOnPet"/>
    /// </summary>
    public static ActionsBuilder sOnPet(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null,
        bool? allPets = null,
        PetType? petType = null)
    {
      var element = ElementTool.Create<ContextActionsOnPet>();
      element.Actions = actions?.Build() ?? element.Actions;
      if (element.Actions is null)
      {
        element.Actions = BlueprintCore.Utils.Constants.Empty.Actions;
      }
      element.AllPets = allPets ?? element.AllPets;
      element.PetType = petType ?? element.PetType;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSpawnAreaEffect"/>
    /// </summary>
    ///
    /// <param name="areaEffect">
    /// Blueprint of type BlueprintAbilityAreaEffect. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SpawnAreaEffect(
        this ActionsBuilder builder,
        Blueprint<BlueprintAbilityAreaEffect, BlueprintAbilityAreaEffectReference>? areaEffect = null,
        ContextDurationValue? durationValue = null,
        bool? onUnit = null)
    {
      var element = ElementTool.Create<ContextActionSpawnAreaEffect>();
      element.m_AreaEffect = areaEffect?.Reference ?? element.m_AreaEffect;
      if (element.m_AreaEffect is null)
      {
        element.m_AreaEffect = BlueprintTool.GetRef<BlueprintAbilityAreaEffectReference>(null);
      }
      builder.Validate(durationValue);
      element.DurationValue = durationValue ?? element.DurationValue;
      element.OnUnit = onUnit ?? element.OnUnit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSpawnControllableProjectile"/>
    /// </summary>
    ///
    /// <param name="associatedCasterBuff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="controllableProjectile">
    /// Blueprint of type BlueprintControllableProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SpawnControllableProjectile(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? associatedCasterBuff = null,
        Blueprint<BlueprintControllableProjectile, BlueprintControllableProjectileReference>? controllableProjectile = null)
    {
      var element = ElementTool.Create<ContextActionSpawnControllableProjectile>();
      element.AssociatedCasterBuff = associatedCasterBuff?.Reference ?? element.AssociatedCasterBuff;
      if (element.AssociatedCasterBuff is null)
      {
        element.AssociatedCasterBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      element.ControllableProjectile = controllableProjectile?.Reference ?? element.ControllableProjectile;
      if (element.ControllableProjectile is null)
      {
        element.ControllableProjectile = BlueprintTool.GetRef<BlueprintControllableProjectileReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSpawnMonster"/>
    /// </summary>
    ///
    /// <param name="blueprint">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="summonPool">
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SpawnMonster(
        this ActionsBuilder builder,
        ActionsBuilder? afterSpawn = null,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? blueprint = null,
        ContextDiceValue? countValue = null,
        bool? doNotLinkToCaster = null,
        ContextDurationValue? durationValue = null,
        bool? isDirectlyControllable = null,
        ContextValue? levelValue = null,
        Blueprint<BlueprintSummonPool, BlueprintSummonPoolReference>? summonPool = null,
        bool? useLimitFromSummonPool = null)
    {
      var element = ElementTool.Create<ContextActionSpawnMonster>();
      element.AfterSpawn = afterSpawn?.Build() ?? element.AfterSpawn;
      if (element.AfterSpawn is null)
      {
        element.AfterSpawn = BlueprintCore.Utils.Constants.Empty.Actions;
      }
      element.m_Blueprint = blueprint?.Reference ?? element.m_Blueprint;
      if (element.m_Blueprint is null)
      {
        element.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      element.CountValue = countValue ?? element.CountValue;
      if (element.CountValue is null)
      {
        element.CountValue = BlueprintCore.Utils.Constants.Empty.DiceValue;
      }
      element.DoNotLinkToCaster = doNotLinkToCaster ?? element.DoNotLinkToCaster;
      builder.Validate(durationValue);
      element.DurationValue = durationValue ?? element.DurationValue;
      element.IsDirectlyControllable = isDirectlyControllable ?? element.IsDirectlyControllable;
      element.LevelValue = levelValue ?? element.LevelValue;
      if (element.LevelValue is null)
      {
        element.LevelValue = ContextValues.Constant(0);
      }
      element.m_SummonPool = summonPool?.Reference ?? element.m_SummonPool;
      if (element.m_SummonPool is null)
      {
        element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      element.UseLimitFromSummonPool = useLimitFromSummonPool ?? element.UseLimitFromSummonPool;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSpawnUnlinkedMonster"/>
    /// </summary>
    ///
    /// <param name="blueprint">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SpawnUnlinkedMonster(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? blueprint = null)
    {
      var element = ElementTool.Create<ContextActionSpawnUnlinkedMonster>();
      element.m_Blueprint = blueprint?.Reference ?? element.m_Blueprint;
      if (element.m_Blueprint is null)
      {
        element.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSpendAttackOfOpportunity"/>
    /// </summary>
    public static ActionsBuilder SpendAttackOfOpportunity(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionSpendAttackOfOpportunity>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionStealBuffs"/>
    /// </summary>
    public static ActionsBuilder StealBuffs(
        this ActionsBuilder builder,
        SpellDescriptorWrapper? descriptor = null)
    {
      var element = ElementTool.Create<ContextActionStealBuffs>();
      element.m_Descriptor = descriptor ?? element.m_Descriptor;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSwallowWhole"/>
    /// </summary>
    ///
    /// <param name="targetBuff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SwallowWhole(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? targetBuff = null)
    {
      var element = ElementTool.Create<ContextActionSwallowWhole>();
      element.m_TargetBuff = targetBuff?.Reference ?? element.m_TargetBuff;
      if (element.m_TargetBuff is null)
      {
        element.m_TargetBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSwarmAttack"/>
    /// </summary>
    public static ActionsBuilder SwarmAttack(
        this ActionsBuilder builder,
        ActionsBuilder? attackActions = null)
    {
      var element = ElementTool.Create<ContextActionSwarmAttack>();
      element.AttackActions = attackActions?.Build() ?? element.AttackActions;
      if (element.AttackActions is null)
      {
        element.AttackActions = BlueprintCore.Utils.Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSwarmTarget"/>
    /// </summary>
    public static ActionsBuilder SwarmTarget(
        this ActionsBuilder builder,
        bool? remove = null)
    {
      var element = ElementTool.Create<ContextActionSwarmTarget>();
      element.Remove = remove ?? element.Remove;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSwitchDualCompanion"/>
    /// </summary>
    public static ActionsBuilder SwitchDualCompanion(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionSwitchDualCompanion>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionTranslocate"/>
    /// </summary>
    public static ActionsBuilder Translocate(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionTranslocate>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionUnsummon"/>
    /// </summary>
    public static ActionsBuilder Unsummon(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionUnsummon>());
    }

    /// <summary>
    /// Adds <see cref="ContextRestoreResource"/>
    /// </summary>
    ///
    /// <param name="resource">
    /// Blueprint of type BlueprintAbilityResource. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextRestoreResource(
        this ActionsBuilder builder,
        bool? contextValueRestoration = null,
        bool? isFullRestoreAllResources = null,
        Blueprint<BlueprintAbilityResource, BlueprintAbilityResourceReference>? resource = null,
        ContextValue? value = null)
    {
      var element = ElementTool.Create<ContextRestoreResource>();
      element.ContextValueRestoration = contextValueRestoration ?? element.ContextValueRestoration;
      element.m_IsFullRestoreAllResources = isFullRestoreAllResources ?? element.m_IsFullRestoreAllResources;
      element.m_Resource = resource?.Reference ?? element.m_Resource;
      if (element.m_Resource is null)
      {
        element.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(null);
      }
      element.Value = value ?? element.Value;
      if (element.Value is null)
      {
        element.Value = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextSpendResource"/>
    /// </summary>
    ///
    /// <param name="resource">
    /// Blueprint of type BlueprintAbilityResource. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextSpendResource(
        this ActionsBuilder builder,
        bool? contextValueSpendure = null,
        Blueprint<BlueprintAbilityResource, BlueprintAbilityResourceReference>? resource = null,
        ContextValue? value = null)
    {
      var element = ElementTool.Create<ContextSpendResource>();
      element.ContextValueSpendure = contextValueSpendure ?? element.ContextValueSpendure;
      element.m_Resource = resource?.Reference ?? element.m_Resource;
      if (element.m_Resource is null)
      {
        element.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(null);
      }
      element.Value = value ?? element.Value;
      if (element.Value is null)
      {
        element.Value = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Demoralize"/>
    /// </summary>
    ///
    /// <param name="buff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="greaterBuff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="shatterConfidenceBuff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="shatterConfidenceFeature">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="swordlordProwessFeature">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder Demoralize(
        this ActionsBuilder builder,
        int? bonus = null,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? buff = null,
        bool? dazzlingDisplay = null,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? greaterBuff = null,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? shatterConfidenceBuff = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? shatterConfidenceFeature = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? swordlordProwessFeature = null,
        ActionsBuilder? tricksterRank3Actions = null)
    {
      var element = ElementTool.Create<Demoralize>();
      element.Bonus = bonus ?? element.Bonus;
      element.m_Buff = buff?.Reference ?? element.m_Buff;
      if (element.m_Buff is null)
      {
        element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      element.DazzlingDisplay = dazzlingDisplay ?? element.DazzlingDisplay;
      element.m_GreaterBuff = greaterBuff?.Reference ?? element.m_GreaterBuff;
      if (element.m_GreaterBuff is null)
      {
        element.m_GreaterBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      element.m_ShatterConfidenceBuff = shatterConfidenceBuff?.Reference ?? element.m_ShatterConfidenceBuff;
      if (element.m_ShatterConfidenceBuff is null)
      {
        element.m_ShatterConfidenceBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      element.m_ShatterConfidenceFeature = shatterConfidenceFeature?.Reference ?? element.m_ShatterConfidenceFeature;
      if (element.m_ShatterConfidenceFeature is null)
      {
        element.m_ShatterConfidenceFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      element.m_SwordlordProwessFeature = swordlordProwessFeature?.Reference ?? element.m_SwordlordProwessFeature;
      if (element.m_SwordlordProwessFeature is null)
      {
        element.m_SwordlordProwessFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      element.TricksterRank3Actions = tricksterRank3Actions?.Build() ?? element.TricksterRank3Actions;
      if (element.TricksterRank3Actions is null)
      {
        element.TricksterRank3Actions = BlueprintCore.Utils.Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="EnhanceWeapon"/>
    /// </summary>
    ///
    /// <param name="enchantment">
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder EnhanceWeapon(
        this ActionsBuilder builder,
        ContextDurationValue? durationValue = null,
        ContextValue? enchantLevel = null,
        List<Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>>? enchantment = null,
        EnhanceWeapon.EnchantmentApplyType? enchantmentType = null,
        bool? greater = null,
        bool? useSecondaryHand = null)
    {
      var element = ElementTool.Create<EnhanceWeapon>();
      builder.Validate(durationValue);
      element.DurationValue = durationValue ?? element.DurationValue;
      element.EnchantLevel = enchantLevel ?? element.EnchantLevel;
      if (element.EnchantLevel is null)
      {
        element.EnchantLevel = ContextValues.Constant(0);
      }
      element.m_Enchantment = enchantment?.Select(bp => bp.Reference)?.ToArray() ?? element.m_Enchantment;
      if (element.m_Enchantment is null)
      {
        element.m_Enchantment = new BlueprintItemEnchantmentReference[0];
      }
      element.EnchantmentType = enchantmentType ?? element.EnchantmentType;
      element.Greater = greater ?? element.Greater;
      element.UseSecondaryHand = useSecondaryHand ?? element.UseSecondaryHand;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwordlordAdaptiveTacticsAdd"/>
    /// </summary>
    ///
    /// <param name="source">
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SwordlordAdaptiveTacticsAdd(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? source = null)
    {
      var element = ElementTool.Create<SwordlordAdaptiveTacticsAdd>();
      element.m_Source = source?.Reference ?? element.m_Source;
      if (element.m_Source is null)
      {
        element.m_Source = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwordlordAdaptiveTacticsClear"/>
    /// </summary>
    public static ActionsBuilder SwordlordAdaptiveTacticsClear(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<SwordlordAdaptiveTacticsClear>());
    }
  }
}
