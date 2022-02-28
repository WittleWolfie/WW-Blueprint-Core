//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints;
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
    /// Adds <see cref="ContextActionSwarmAttack"/>
    /// </summary>
    public static ActionsBuilder SwarmAttack(
        this ActionsBuilder builder,
        ActionsBuilder? attackActions = null)
    {
      var element = ElementTool.Create<ContextActionSwarmAttack>();
      element.AttackActions = attackActions.Build() ?? element.AttackActions;
      if (element.AttackActions is null)
      {
        element.AttackActions = Constants.Empty.Actions;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RestoreAllSpellSlots(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintSpellbook, BlueprintSpellbookReference>>? excludeSpellbooks = null,
        UnitEvaluator? target = null,
        int? upToSpellLevel = null)
    {
      var element = ElementTool.Create<ContextActionRestoreAllSpellSlots>();
      element.m_ExcludeSpellbooks = excludeSpellbooks.Select(bp => bp.Reference).ToList() ?? element.m_ExcludeSpellbooks;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="setRankFrom">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AddFeature(
        this ActionsBuilder builder,
        Blueprint<BlueprintFeature, BlueprintFeatureReference> permanentFeature,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? setRankFrom = null)
    {
      var element = ElementTool.Create<ContextActionAddFeature>();
      element.m_PermanentFeature = permanentFeature.Reference;
      element.m_SetRankFrom = setRankFrom.Reference ?? element.m_SetRankFrom;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AddLocustClone(
        this ActionsBuilder builder,
        Blueprint<BlueprintFeature, BlueprintFeatureReference> cloneFeature)
    {
      var element = ElementTool.Create<ContextActionAddLocustClone>();
      element.m_CloneFeature = cloneFeature.Reference;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
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
      element.m_Buff = buff.Reference;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
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
      element.m_Buff = buff.Reference;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
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
      element.m_Buff = buff.Reference;
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
    /// <para>
    /// The caster's armor is enchanted based on its available enhancement bonus.
    /// e.g. If the armor can be enchanted to +4 and has a +1 enchantment, enchantmentPlus3 is applied.
    /// </para>
    /// 
    /// <list type="bullet">
    /// <listheader>
    ///   <term>Example Blueprints:</term>
    /// </listheader>
    /// <item>
    ///   <description>SacredArmorEnchantSwitchAbility - 66484ebb8d358db4692ef4445fa6ac35</description>
    /// </item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="enchantmentPlus1">
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// 
    /// Defaults to TemporaryArmorEnhancementBonus1
    /// </param>
    ///
    /// <param name="enchantmentPlus2">
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// 
    /// Defaults to TemporaryArmorEnhancementBonus2
    /// </param>
    ///
    /// <param name="enchantmentPlus3">
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// 
    /// Defaults to TemporaryArmorEnhancementBonus3
    /// </param>
    ///
    /// <param name="enchantmentPlus4">
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// 
    /// Defaults to TemporaryArmorEnhancementBonus4
    /// </param>
    ///
    /// <param name="enchantmentPlus5">
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// 
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
    /// <para>
    /// The caster's shield is enchanted based on its available enhancement bonus.
    /// e.g. If the shield can be enchanted to +4 and has a +1 enchantment, enchantmentPlus3 is applied.
    /// </para>
    /// 
    /// <list type="bullet">
    /// <listheader>
    ///   <term>Example Blueprints:</term>
    /// </listheader>
    /// <item>
    ///   <description>SacredArmorShieldEnchantSwitchAbility - b0777d9974795a5489ff0efd735a4c2a</description>
    /// </item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="enchantmentPlus1">
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// 
    /// Defaults to TemporaryArmorEnhancementBonus1
    /// </param>
    ///
    /// <param name="enchantmentPlus2">
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// 
    /// Defaults to TemporaryArmorEnhancementBonus2
    /// </param>
    ///
    /// <param name="enchantmentPlus3">
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// 
    /// Defaults to TemporaryArmorEnhancementBonus3
    /// </param>
    ///
    /// <param name="enchantmentPlus4">
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// 
    /// Defaults to TemporaryArmorEnhancementBonus4
    /// </param>
    ///
    /// <param name="enchantmentPlus5">
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// 
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
    /// <param name="defaultEnchantments">
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder WeaponEnchantPool(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>>? defaultEnchantments = null,
        ContextDurationValue? durationValue = null,
        EnchantPoolType? enchantPool = null,
        ActivatableAbilityGroup? group = null)
    {
      var element = ElementTool.Create<ContextActionWeaponEnchantPool>();
      element.m_DefaultEnchantments = defaultEnchantments.Select(bp => bp.Reference).ToArray() ?? element.m_DefaultEnchantments;
      if (element.m_DefaultEnchantments is null)
      {
        element.m_DefaultEnchantments = new BlueprintItemEnchantmentReference[0];
      }
      builder.Validate(durationValue);
      element.DurationValue = durationValue ?? element.DurationValue;
      element.EnchantPool = enchantPool ?? element.EnchantPool;
      element.Group = group ?? element.Group;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionShieldWeaponEnchantPool"/>
    /// </summary>
    ///
    /// <param name="defaultEnchantments">
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ShieldWeaponEnchantPool(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>>? defaultEnchantments = null,
        ContextDurationValue? durationValue = null,
        EnchantPoolType? enchantPool = null,
        ActivatableAbilityGroup? group = null)
    {
      var element = ElementTool.Create<ContextActionShieldWeaponEnchantPool>();
      element.m_DefaultEnchantments = defaultEnchantments.Select(bp => bp.Reference).ToArray() ?? element.m_DefaultEnchantments;
      if (element.m_DefaultEnchantments is null)
      {
        element.m_DefaultEnchantments = new BlueprintItemEnchantmentReference[0];
      }
      builder.Validate(durationValue);
      element.DurationValue = durationValue ?? element.DurationValue;
      element.EnchantPool = enchantPool ?? element.EnchantPool;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AttackWithWeapon(
        this ActionsBuilder builder,
        StatType? stat = null,
        Blueprint<BlueprintItemWeapon, BlueprintItemWeaponReference>? weaponRef = null)
    {
      var element = ElementTool.Create<ContextActionAttackWithWeapon>();
      element.m_Stat = stat ?? element.m_Stat;
      element.m_WeaponRef = weaponRef.Reference ?? element.m_WeaponRef;
      if (element.m_WeaponRef is null)
      {
        element.m_WeaponRef = BlueprintTool.GetRef<BlueprintItemWeaponReference>(null);
      }
      return builder.Add(element);
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
      element.Failure = failure.Build() ?? element.Failure;
      if (element.Failure is null)
      {
        element.Failure = Constants.Empty.Actions;
      }
      element.Success = success.Build() ?? element.Success;
      if (element.Success is null)
      {
        element.Success = Constants.Empty.Actions;
      }
      element.UseCMB = useCMB ?? element.UseCMB;
      element.UseCMD = useCMD ?? element.UseCMD;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionBreathOfLife"/>
    /// </summary>
    public static ActionsBuilder BreathOfLife(
        this ActionsBuilder builder,
        ContextDiceValue? value = null)
    {
      var element = ElementTool.Create<ContextActionBreathOfLife>();
      element.Value = value ?? element.Value;
      if (element.Value is null)
      {
        element.Value = Constants.Empty.DiceValue;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionBreathOfMoney"/>
    /// </summary>
    public static ActionsBuilder BreathOfMoney(
        this ActionsBuilder builder,
        ContextValue? maxCoins = null,
        ContextValue? minCoins = null)
    {
      var element = ElementTool.Create<ContextActionBreathOfMoney>();
      element.MaxCoins = maxCoins ?? element.MaxCoins;
      if (element.MaxCoins is null)
      {
        element.MaxCoins = ContextValues.Constant(0);
      }
      element.MinCoins = minCoins ?? element.MinCoins;
      if (element.MinCoins is null)
      {
        element.MinCoins = ContextValues.Constant(0);
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder CastSpell(
        this ActionsBuilder builder,
        bool? castByTarget = null,
        ContextValue? dC = null,
        bool? overrideDC = null,
        bool? overrideSpellLevel = null,
        Blueprint<BlueprintAbility, BlueprintAbilityReference>? spell = null,
        ContextValue? spellLevel = null)
    {
      var element = ElementTool.Create<ContextActionCastSpell>();
      element.CastByTarget = castByTarget ?? element.CastByTarget;
      element.DC = dC ?? element.DC;
      if (element.DC is null)
      {
        element.DC = ContextValues.Constant(0);
      }
      element.OverrideDC = overrideDC ?? element.OverrideDC;
      element.OverrideSpellLevel = overrideSpellLevel ?? element.OverrideSpellLevel;
      element.m_Spell = spell.Reference ?? element.m_Spell;
      if (element.m_Spell is null)
      {
        element.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      element.SpellLevel = spellLevel ?? element.SpellLevel;
      if (element.SpellLevel is null)
      {
        element.SpellLevel = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionChangeSharedValue"/>
    /// </summary>
    public static ActionsBuilder ChangeSharedValue(
        this ActionsBuilder builder,
        ContextValue? addValue = null,
        ContextValue? multiplyValue = null,
        ContextValue? setValue = null,
        AbilitySharedValue? sharedValue = null,
        SharedValueChangeType? type = null)
    {
      var element = ElementTool.Create<ContextActionChangeSharedValue>();
      element.AddValue = addValue ?? element.AddValue;
      if (element.AddValue is null)
      {
        element.AddValue = ContextValues.Constant(0);
      }
      element.MultiplyValue = multiplyValue ?? element.MultiplyValue;
      if (element.MultiplyValue is null)
      {
        element.MultiplyValue = ContextValues.Constant(0);
      }
      element.SetValue = setValue ?? element.SetValue;
      if (element.SetValue is null)
      {
        element.SetValue = ContextValues.Constant(0);
      }
      element.SharedValue = sharedValue ?? element.SharedValue;
      element.Type = type ?? element.Type;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ClearSummonPool(
        this ActionsBuilder builder,
        Blueprint<BlueprintSummonPool, BlueprintSummonPoolReference>? summonPool = null)
    {
      var element = ElementTool.Create<ContextActionClearSummonPool>();
      element.m_SummonPool = summonPool.Reference ?? element.m_SummonPool;
      if (element.m_SummonPool is null)
      {
        element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionCombatManeuver"/>
    /// </summary>
    public static ActionsBuilder CombatManeuver(
        this ActionsBuilder builder,
        bool? batteringBlast = null,
        bool? ignoreConcealment = null,
        StatType? newStat = null,
        ActionsBuilder? onSuccess = null,
        bool? replaceStat = null,
        CombatManeuver? type = null,
        bool? useBestMentalStat = null,
        bool? useCasterLevelAsBaseAttack = null,
        bool? useCastingStat = null,
        bool? useKineticistMainStat = null)
    {
      var element = ElementTool.Create<ContextActionCombatManeuver>();
      element.BatteringBlast = batteringBlast ?? element.BatteringBlast;
      element.IgnoreConcealment = ignoreConcealment ?? element.IgnoreConcealment;
      element.NewStat = newStat ?? element.NewStat;
      element.OnSuccess = onSuccess.Build() ?? element.OnSuccess;
      if (element.OnSuccess is null)
      {
        element.OnSuccess = Constants.Empty.Actions;
      }
      element.ReplaceStat = replaceStat ?? element.ReplaceStat;
      element.Type = type ?? element.Type;
      element.UseBestMentalStat = useBestMentalStat ?? element.UseBestMentalStat;
      element.UseCasterLevelAsBaseAttack = useCasterLevelAsBaseAttack ?? element.UseCasterLevelAsBaseAttack;
      element.UseCastingStat = useCastingStat ?? element.UseCastingStat;
      element.UseKineticistMainStat = useKineticistMainStat ?? element.UseKineticistMainStat;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionCombatManeuverCustom"/>
    /// </summary>
    public static ActionsBuilder CombatManeuverCustom(
        this ActionsBuilder builder,
        ActionsBuilder? failure = null,
        ActionsBuilder? success = null,
        CombatManeuver? type = null)
    {
      var element = ElementTool.Create<ContextActionCombatManeuverCustom>();
      element.Failure = failure.Build() ?? element.Failure;
      if (element.Failure is null)
      {
        element.Failure = Constants.Empty.Actions;
      }
      element.Success = success.Build() ?? element.Success;
      if (element.Success is null)
      {
        element.Success = Constants.Empty.Actions;
      }
      element.Type = type ?? element.Type;
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
      element.Failed = failed.Build() ?? element.Failed;
      if (element.Failed is null)
      {
        element.Failed = Constants.Empty.Actions;
      }
      element.Succeed = succeed.Build() ?? element.Succeed;
      if (element.Succeed is null)
      {
        element.Succeed = Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionDealDamage"/>
    /// </summary>
    public static ActionsBuilder DealDamage(
        this ActionsBuilder builder,
        StatType? abilityType = null,
        bool? alreadyHalved = null,
        AbilitySharedValue? criticalSharedValue = null,
        DamageTypeDescription? damageType = null,
        bool? drain = null,
        ContextDurationValue? duration = null,
        EnergyDrainType? energyDrainType = null,
        bool? half = null,
        bool? halfIfSaved = null,
        bool? ignoreCritical = null,
        bool? isAoE = null,
        bool? isAOE = null,
        int? minHPAfterDamage = null,
        AbilitySharedValue? preRolledSharedValue = null,
        bool? readPreRolledFromSharedValue = null,
        AbilitySharedValue? resultSharedValue = null,
        bool? setFactAsReason = null,
        ContextActionDealDamage.Type? type = null,
        bool? useMinHPAfterDamage = null,
        bool? useWeaponDamageModifiers = null,
        ContextDiceValue? value = null,
        bool? writeCriticalToSharedValue = null,
        bool? writeRawResultToSharedValue = null,
        bool? writeResultToSharedValue = null)
    {
      var element = ElementTool.Create<ContextActionDealDamage>();
      element.AbilityType = abilityType ?? element.AbilityType;
      element.AlreadyHalved = alreadyHalved ?? element.AlreadyHalved;
      element.CriticalSharedValue = criticalSharedValue ?? element.CriticalSharedValue;
      builder.Validate(damageType);
      element.DamageType = damageType ?? element.DamageType;
      element.Drain = drain ?? element.Drain;
      builder.Validate(duration);
      element.Duration = duration ?? element.Duration;
      element.EnergyDrainType = energyDrainType ?? element.EnergyDrainType;
      element.Half = half ?? element.Half;
      element.HalfIfSaved = halfIfSaved ?? element.HalfIfSaved;
      element.IgnoreCritical = ignoreCritical ?? element.IgnoreCritical;
      element.IsAoE = isAoE ?? element.IsAoE;
      element.m_IsAOE = isAOE ?? element.m_IsAOE;
      element.MinHPAfterDamage = minHPAfterDamage ?? element.MinHPAfterDamage;
      element.PreRolledSharedValue = preRolledSharedValue ?? element.PreRolledSharedValue;
      element.ReadPreRolledFromSharedValue = readPreRolledFromSharedValue ?? element.ReadPreRolledFromSharedValue;
      element.ResultSharedValue = resultSharedValue ?? element.ResultSharedValue;
      element.SetFactAsReason = setFactAsReason ?? element.SetFactAsReason;
      element.m_Type = type ?? element.m_Type;
      element.UseMinHPAfterDamage = useMinHPAfterDamage ?? element.UseMinHPAfterDamage;
      element.UseWeaponDamageModifiers = useWeaponDamageModifiers ?? element.UseWeaponDamageModifiers;
      element.Value = value ?? element.Value;
      if (element.Value is null)
      {
        element.Value = Constants.Empty.DiceValue;
      }
      element.WriteCriticalToSharedValue = writeCriticalToSharedValue ?? element.WriteCriticalToSharedValue;
      element.WriteRawResultToSharedValue = writeRawResultToSharedValue ?? element.WriteRawResultToSharedValue;
      element.WriteResultToSharedValue = writeResultToSharedValue ?? element.WriteResultToSharedValue;
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
    /// Adds <see cref="ContextActionDispelMagic"/>
    /// </summary>
    public static ActionsBuilder DispelMagic(
        this ActionsBuilder builder,
        ContextActionDispelMagic.BuffType? buffType = null,
        int? checkBonus = null,
        bool? checkSchoolOrDescriptor = null,
        RuleDispelMagic.CheckType? checkType = null,
        ContextValue? contextBonus = null,
        ContextValue? countToRemove = null,
        SpellDescriptorWrapper? descriptor = null,
        ContextValue? maxCasterLevel = null,
        ContextValue? maxSpellLevel = null,
        bool? oneRollForAll = null,
        ActionsBuilder? onFail = null,
        bool? onlyEnemyAreaEffects = null,
        bool? onlyTargetEnemyBuffs = null,
        ActionsBuilder? onSuccess = null,
        SpellSchool[]? schools = null,
        StatType? skill = null,
        bool? stopAfterCountRemoved = null,
        bool? useMaxCasterLevel = null)
    {
      var element = ElementTool.Create<ContextActionDispelMagic>();
      element.m_BuffType = buffType ?? element.m_BuffType;
      element.CheckBonus = checkBonus ?? element.CheckBonus;
      element.CheckSchoolOrDescriptor = checkSchoolOrDescriptor ?? element.CheckSchoolOrDescriptor;
      element.m_CheckType = checkType ?? element.m_CheckType;
      element.ContextBonus = contextBonus ?? element.ContextBonus;
      if (element.ContextBonus is null)
      {
        element.ContextBonus = ContextValues.Constant(0);
      }
      element.m_CountToRemove = countToRemove ?? element.m_CountToRemove;
      if (element.m_CountToRemove is null)
      {
        element.m_CountToRemove = ContextValues.Constant(0);
      }
      element.Descriptor = descriptor ?? element.Descriptor;
      element.m_MaxCasterLevel = maxCasterLevel ?? element.m_MaxCasterLevel;
      if (element.m_MaxCasterLevel is null)
      {
        element.m_MaxCasterLevel = ContextValues.Constant(0);
      }
      element.m_MaxSpellLevel = maxSpellLevel ?? element.m_MaxSpellLevel;
      if (element.m_MaxSpellLevel is null)
      {
        element.m_MaxSpellLevel = ContextValues.Constant(0);
      }
      element.OneRollForAll = oneRollForAll ?? element.OneRollForAll;
      element.OnFail = onFail.Build() ?? element.OnFail;
      if (element.OnFail is null)
      {
        element.OnFail = Constants.Empty.Actions;
      }
      element.OnlyEnemyAreaEffects = onlyEnemyAreaEffects ?? element.OnlyEnemyAreaEffects;
      element.OnlyTargetEnemyBuffs = onlyTargetEnemyBuffs ?? element.OnlyTargetEnemyBuffs;
      element.OnSuccess = onSuccess.Build() ?? element.OnSuccess;
      if (element.OnSuccess is null)
      {
        element.OnSuccess = Constants.Empty.Actions;
      }
      element.Schools = schools ?? element.Schools;
      if (element.Schools is null)
      {
        element.Schools = new SpellSchool[0];
      }
      element.m_Skill = skill ?? element.m_Skill;
      element.m_StopAfterCountRemoved = stopAfterCountRemoved ?? element.m_StopAfterCountRemoved;
      element.m_UseMaxCasterLevel = useMaxCasterLevel ?? element.m_UseMaxCasterLevel;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionDropItems"/>
    /// </summary>
    public static ActionsBuilder DropItems(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDropItems>());
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder EnchantWornItem(
        this ActionsBuilder builder,
        ContextDurationValue? durationValue = null,
        Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>? enchantment = null,
        bool? permanent = null,
        bool? removeOnUnequip = null,
        EquipSlotBase.SlotType? slot = null,
        bool? toCaster = null)
    {
      var element = ElementTool.Create<ContextActionEnchantWornItem>();
      builder.Validate(durationValue);
      element.DurationValue = durationValue ?? element.DurationValue;
      element.m_Enchantment = enchantment.Reference ?? element.m_Enchantment;
      if (element.m_Enchantment is null)
      {
        element.m_Enchantment = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(null);
      }
      element.Permanent = permanent ?? element.Permanent;
      element.RemoveOnUnequip = removeOnUnequip ?? element.RemoveOnUnequip;
      element.Slot = slot ?? element.Slot;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder FinishObjective(
        this ActionsBuilder builder,
        Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference>? objective = null)
    {
      var element = ElementTool.Create<ContextActionFinishObjective>();
      element.m_Objective = objective.Reference ?? element.m_Objective;
      if (element.m_Objective is null)
      {
        element.m_Objective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionForEachSwallowedUnit"/>
    /// </summary>
    public static ActionsBuilder ForEachSwallowedUnit(
        this ActionsBuilder builder,
        ActionsBuilder? action = null)
    {
      var element = ElementTool.Create<ContextActionForEachSwallowedUnit>();
      element.Action = action.Build() ?? element.Action;
      if (element.Action is null)
      {
        element.Action = Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionGiveExperience"/>
    /// </summary>
    public static ActionsBuilder GiveExperience(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionGiveExperience>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionGrapple"/>
    /// </summary>
    ///
    /// <param name="casterBuff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="targetBuff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder Grapple(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? casterBuff = null,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? targetBuff = null)
    {
      var element = ElementTool.Create<ContextActionGrapple>();
      element.m_CasterBuff = casterBuff.Reference ?? element.m_CasterBuff;
      if (element.m_CasterBuff is null)
      {
        element.m_CasterBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      element.m_TargetBuff = targetBuff.Reference ?? element.m_TargetBuff;
      if (element.m_TargetBuff is null)
      {
        element.m_TargetBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
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
    /// Adds <see cref="ContextActionHealStatDamage"/>
    /// </summary>
    public static ActionsBuilder HealStatDamage(
        this ActionsBuilder builder,
        bool? healDrain = null,
        ContextActionHealStatDamage.StatDamageHealType? healType = null,
        AbilitySharedValue? resultSharedValue = null,
        ContextActionHealStatDamage.StatClass? statClass = null,
        ContextDiceValue? value = null,
        bool? writeResultToSharedValue = null)
    {
      var element = ElementTool.Create<ContextActionHealStatDamage>();
      element.HealDrain = healDrain ?? element.HealDrain;
      element.m_HealType = healType ?? element.m_HealType;
      element.ResultSharedValue = resultSharedValue ?? element.ResultSharedValue;
      element.m_StatClass = statClass ?? element.m_StatClass;
      element.Value = value ?? element.Value;
      if (element.Value is null)
      {
        element.Value = Constants.Empty.DiceValue;
      }
      element.WriteResultToSharedValue = writeResultToSharedValue ?? element.WriteResultToSharedValue;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionHealTarget"/>
    /// </summary>
    public static ActionsBuilder HealTarget(
        this ActionsBuilder builder,
        ContextDiceValue? value = null)
    {
      var element = ElementTool.Create<ContextActionHealTarget>();
      element.Value = value ?? element.Value;
      if (element.Value is null)
      {
        element.Value = Constants.Empty.DiceValue;
      }
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
      element.FailActions = failActions.Build() ?? element.FailActions;
      if (element.FailActions is null)
      {
        element.FailActions = Constants.Empty.Actions;
      }
      element.SuccessActions = successActions.Build() ?? element.SuccessActions;
      if (element.SuccessActions is null)
      {
        element.SuccessActions = Constants.Empty.Actions;
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
    /// Adds <see cref="ContextActionOnContextCaster"/>
    /// </summary>
    public static ActionsBuilder OnContextCaster(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null)
    {
      var element = ElementTool.Create<ContextActionOnContextCaster>();
      element.Actions = actions.Build() ?? element.Actions;
      if (element.Actions is null)
      {
        element.Actions = Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionOnOwner"/>
    /// </summary>
    public static ActionsBuilder OnOwner(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null)
    {
      var element = ElementTool.Create<ContextActionOnOwner>();
      element.Actions = actions.Build() ?? element.Actions;
      if (element.Actions is null)
      {
        element.Actions = Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionOnRandomAreaTarget"/>
    /// </summary>
    public static ActionsBuilder OnRandomAreaTarget(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null,
        bool? onEnemies = null)
    {
      var element = ElementTool.Create<ContextActionOnRandomAreaTarget>();
      element.Actions = actions.Build() ?? element.Actions;
      if (element.Actions is null)
      {
        element.Actions = Constants.Empty.Actions;
      }
      element.OnEnemies = onEnemies ?? element.OnEnemies;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder OnRandomTargetsAround(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null,
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? filterNoFact = null,
        int? numberOfTargets = null,
        bool? onEnemies = null,
        Feet? radius = null)
    {
      var element = ElementTool.Create<ContextActionOnRandomTargetsAround>();
      element.Actions = actions.Build() ?? element.Actions;
      if (element.Actions is null)
      {
        element.Actions = Constants.Empty.Actions;
      }
      element.m_FilterNoFact = filterNoFact.Reference ?? element.m_FilterNoFact;
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
        ActionsBuilder? actions = null)
    {
      var element = ElementTool.Create<ContextActionOnSwarmTargets>();
      element.Actions = actions.Build() ?? element.Actions;
      if (element.Actions is null)
      {
        element.Actions = Constants.Empty.Actions;
      }
      return builder.Add(element);
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ProjectileFx(
        this ActionsBuilder builder,
        Blueprint<BlueprintProjectile, BlueprintProjectileReference>? projectile = null)
    {
      var element = ElementTool.Create<ContextActionProjectileFx>();
      element.m_Projectile = projectile.Reference ?? element.m_Projectile;
      if (element.m_Projectile is null)
      {
        element.m_Projectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
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
    /// Adds <see cref="ContextActionRandomize"/>
    /// </summary>
    public static ActionsBuilder Randomize(
        this ActionsBuilder builder,
        ContextActionRandomize.ActionWrapper[]? actions = null)
    {
      var element = ElementTool.Create<ContextActionRandomize>();
      foreach (var item in actions) { builder.Validate(item); }
      element.m_Actions = actions ?? element.m_Actions;
      if (element.m_Actions is null)
      {
        element.m_Actions = new ContextActionRandomize.ActionWrapper[0];
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RecoverItemCharges(
        this ActionsBuilder builder,
        int? chargesRecoverCount = null,
        Blueprint<BlueprintItemEquipment, BlueprintItemEquipmentReference>? item = null)
    {
      var element = ElementTool.Create<ContextActionRecoverItemCharges>();
      element.ChargesRecoverCount = chargesRecoverCount ?? element.ChargesRecoverCount;
      element.m_Item = item.Reference ?? element.m_Item;
      if (element.m_Item is null)
      {
        element.m_Item = BlueprintTool.GetRef<BlueprintItemEquipmentReference>(null);
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ReduceBuffDuration(
        this ActionsBuilder builder,
        ContextDurationValue? durationValue = null,
        bool? increase = null,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? targetBuff = null,
        bool? toTarget = null)
    {
      var element = ElementTool.Create<ContextActionReduceBuffDuration>();
      builder.Validate(durationValue);
      element.DurationValue = durationValue ?? element.DurationValue;
      element.Increase = increase ?? element.Increase;
      element.m_TargetBuff = targetBuff.Reference ?? element.m_TargetBuff;
      if (element.m_TargetBuff is null)
      {
        element.m_TargetBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      element.ToTarget = toTarget ?? element.ToTarget;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RemoveBuff(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? buff = null,
        bool? onlyFromCaster = null,
        bool? removeRank = null,
        bool? toCaster = null)
    {
      var element = ElementTool.Create<ContextActionRemoveBuff>();
      element.m_Buff = buff.Reference ?? element.m_Buff;
      if (element.m_Buff is null)
      {
        element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
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
        bool? notSelf = null,
        SpellDescriptorWrapper? spellDescriptor = null)
    {
      var element = ElementTool.Create<ContextActionRemoveBuffsByDescriptor>();
      element.NotSelf = notSelf ?? element.NotSelf;
      element.SpellDescriptor = spellDescriptor ?? element.SpellDescriptor;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RemoveBuffSingleStack(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? targetBuff = null)
    {
      var element = ElementTool.Create<ContextActionRemoveBuffSingleStack>();
      element.m_TargetBuff = targetBuff.Reference ?? element.m_TargetBuff;
      if (element.m_TargetBuff is null)
      {
        element.m_TargetBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
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
    /// Adds <see cref="ContextActionRepeatedActions"/>
    /// </summary>
    public static ActionsBuilder RepeatedActions(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null,
        ContextDiceValue? value = null)
    {
      var element = ElementTool.Create<ContextActionRepeatedActions>();
      element.Actions = actions.Build() ?? element.Actions;
      if (element.Actions is null)
      {
        element.Actions = Constants.Empty.Actions;
      }
      element.Value = value ?? element.Value;
      if (element.Value is null)
      {
        element.Value = Constants.Empty.DiceValue;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RestoreSpells(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintSpellbook, BlueprintSpellbookReference>>? spellbooks = null)
    {
      var element = ElementTool.Create<ContextActionRestoreSpells>();
      element.m_Spellbooks = spellbooks.Select(bp => bp.Reference).ToArray() ?? element.m_Spellbooks;
      if (element.m_Spellbooks is null)
      {
        element.m_Spellbooks = new BlueprintSpellbookReference[0];
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionResurrect"/>
    /// </summary>
    ///
    /// <param name="customResurrectionBuff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder Resurrect(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? customResurrectionBuff = null,
        bool? fullRestore = null,
        float? resultHealth = null)
    {
      var element = ElementTool.Create<ContextActionResurrect>();
      element.m_CustomResurrectionBuff = customResurrectionBuff.Reference ?? element.m_CustomResurrectionBuff;
      if (element.m_CustomResurrectionBuff is null)
      {
        element.m_CustomResurrectionBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      element.FullRestore = fullRestore ?? element.FullRestore;
      element.ResultHealth = resultHealth ?? element.ResultHealth;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSavingThrow"/>
    /// </summary>
    public static ActionsBuilder SavingThrow(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null,
        ContextActionSavingThrow.ConditionalDCIncrease[]? conditionalDCIncrease = null,
        ContextValue? customDC = null,
        bool? fromBuff = null,
        bool? hasCustomDC = null,
        SavingThrowType? type = null)
    {
      var element = ElementTool.Create<ContextActionSavingThrow>();
      element.Actions = actions.Build() ?? element.Actions;
      if (element.Actions is null)
      {
        element.Actions = Constants.Empty.Actions;
      }
      element.m_ConditionalDCIncrease = conditionalDCIncrease ?? element.m_ConditionalDCIncrease;
      if (element.m_ConditionalDCIncrease is null)
      {
        element.m_ConditionalDCIncrease = new ContextActionSavingThrow.ConditionalDCIncrease[0];
      }
      element.CustomDC = customDC ?? element.CustomDC;
      if (element.CustomDC is null)
      {
        element.CustomDC = ContextValues.Constant(0);
      }
      element.FromBuff = fromBuff ?? element.FromBuff;
      element.HasCustomDC = hasCustomDC ?? element.HasCustomDC;
      element.Type = type ?? element.Type;
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
      element.Failure = failure.Build() ?? element.Failure;
      if (element.Failure is null)
      {
        element.Failure = Constants.Empty.Actions;
      }
      element.FailureDiffMoreOrEqual10 = failureDiffMoreOrEqual10.Build() ?? element.FailureDiffMoreOrEqual10;
      if (element.FailureDiffMoreOrEqual10 is null)
      {
        element.FailureDiffMoreOrEqual10 = Constants.Empty.Actions;
      }
      element.FailureDiffMoreOrEqual5Less10 = failureDiffMoreOrEqual5Less10.Build() ?? element.FailureDiffMoreOrEqual5Less10;
      if (element.FailureDiffMoreOrEqual5Less10 is null)
      {
        element.FailureDiffMoreOrEqual5Less10 = Constants.Empty.Actions;
      }
      element.Stat = stat ?? element.Stat;
      element.Success = success.Build() ?? element.Success;
      if (element.Success is null)
      {
        element.Success = Constants.Empty.Actions;
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
      element.Actions = actions.Build() ?? element.Actions;
      if (element.Actions is null)
      {
        element.Actions = Constants.Empty.Actions;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SpawnAreaEffect(
        this ActionsBuilder builder,
        Blueprint<BlueprintAbilityAreaEffect, BlueprintAbilityAreaEffectReference>? areaEffect = null,
        ContextDurationValue? durationValue = null,
        bool? onUnit = null)
    {
      var element = ElementTool.Create<ContextActionSpawnAreaEffect>();
      element.m_AreaEffect = areaEffect.Reference ?? element.m_AreaEffect;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="controllableProjectile">
    /// Blueprint of type BlueprintControllableProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SpawnControllableProjectile(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? associatedCasterBuff = null,
        Blueprint<BlueprintControllableProjectile, BlueprintControllableProjectileReference>? controllableProjectile = null)
    {
      var element = ElementTool.Create<ContextActionSpawnControllableProjectile>();
      element.AssociatedCasterBuff = associatedCasterBuff.Reference ?? element.AssociatedCasterBuff;
      if (element.AssociatedCasterBuff is null)
      {
        element.AssociatedCasterBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      element.ControllableProjectile = controllableProjectile.Reference ?? element.ControllableProjectile;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="summonPool">
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
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
      element.AfterSpawn = afterSpawn.Build() ?? element.AfterSpawn;
      if (element.AfterSpawn is null)
      {
        element.AfterSpawn = Constants.Empty.Actions;
      }
      element.m_Blueprint = blueprint.Reference ?? element.m_Blueprint;
      if (element.m_Blueprint is null)
      {
        element.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      element.CountValue = countValue ?? element.CountValue;
      if (element.CountValue is null)
      {
        element.CountValue = Constants.Empty.DiceValue;
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
      element.m_SummonPool = summonPool.Reference ?? element.m_SummonPool;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SpawnUnlinkedMonster(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? blueprint = null)
    {
      var element = ElementTool.Create<ContextActionSpawnUnlinkedMonster>();
      element.m_Blueprint = blueprint.Reference ?? element.m_Blueprint;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SwallowWhole(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? targetBuff = null)
    {
      var element = ElementTool.Create<ContextActionSwallowWhole>();
      element.m_TargetBuff = targetBuff.Reference ?? element.m_TargetBuff;
      if (element.m_TargetBuff is null)
      {
        element.m_TargetBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
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
      element.m_Resource = resource.Reference ?? element.m_Resource;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextSpendResource(
        this ActionsBuilder builder,
        bool? contextValueSpendure = null,
        Blueprint<BlueprintAbilityResource, BlueprintAbilityResourceReference>? resource = null,
        ContextValue? value = null)
    {
      var element = ElementTool.Create<ContextSpendResource>();
      element.ContextValueSpendure = contextValueSpendure ?? element.ContextValueSpendure;
      element.m_Resource = resource.Reference ?? element.m_Resource;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="greaterBuff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="shatterConfidenceBuff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="shatterConfidenceFeature">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="swordlordProwessFeature">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
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
      element.m_Buff = buff.Reference ?? element.m_Buff;
      if (element.m_Buff is null)
      {
        element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      element.DazzlingDisplay = dazzlingDisplay ?? element.DazzlingDisplay;
      element.m_GreaterBuff = greaterBuff.Reference ?? element.m_GreaterBuff;
      if (element.m_GreaterBuff is null)
      {
        element.m_GreaterBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      element.m_ShatterConfidenceBuff = shatterConfidenceBuff.Reference ?? element.m_ShatterConfidenceBuff;
      if (element.m_ShatterConfidenceBuff is null)
      {
        element.m_ShatterConfidenceBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      element.m_ShatterConfidenceFeature = shatterConfidenceFeature.Reference ?? element.m_ShatterConfidenceFeature;
      if (element.m_ShatterConfidenceFeature is null)
      {
        element.m_ShatterConfidenceFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      element.m_SwordlordProwessFeature = swordlordProwessFeature.Reference ?? element.m_SwordlordProwessFeature;
      if (element.m_SwordlordProwessFeature is null)
      {
        element.m_SwordlordProwessFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      element.TricksterRank3Actions = tricksterRank3Actions.Build() ?? element.TricksterRank3Actions;
      if (element.TricksterRank3Actions is null)
      {
        element.TricksterRank3Actions = Constants.Empty.Actions;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
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
      element.m_Enchantment = enchantment.Select(bp => bp.Reference).ToArray() ?? element.m_Enchantment;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SwordlordAdaptiveTacticsAdd(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? source = null)
    {
      var element = ElementTool.Create<SwordlordAdaptiveTacticsAdd>();
      element.m_Source = source.Reference ?? element.m_Source;
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
