//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Assets.UnitLogic.Mechanics.Actions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
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
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Actions;
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AboutIzyagna</term><description>fa1f67444ec844508ea2eb6549581d5d</description></item>
    /// <item><term>Mephisto_Feature_CombatTrigger</term><description>e7255d5c90254cdb8ed7c5c0d1229c49</description></item>
    /// <item><term>ZeorisDaggerRing_BetrayalFeature</term><description>1f6fabee66d54992bc912236d36b50f8</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="permanentFeature">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="setRankFrom">
    /// <para>
    /// InfoBox: Can be null. Force set PermanentFeature rank to be equal to SetRankFrom rank
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder AddFeature(
        this ActionsBuilder builder,
        Blueprint<BlueprintFeatureReference> permanentFeature,
        Blueprint<BlueprintFeatureReference>? setRankFrom = null)
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>LocustCloneAbility</term><description>b8f6c04efaaaf2541ba07bbb772754ce</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="cloneFeature">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder AddLocustClone(
        this ActionsBuilder builder,
        Blueprint<BlueprintFeatureReference> cloneFeature)
    {
      var element = ElementTool.Create<ContextActionAddLocustClone>();
      element.m_CloneFeature = cloneFeature?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionAddRandomTrashItem"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Event71DumpExcavation</term><description>b0ca7e2b70c9447da43f7be86164d43c</description></item>
    /// <item><term>TricksterLoreNature1Feature</term><description>cb232b9ed5c216242a667e95527ad8e1</description></item>
    /// <item><term>TricksterLoreNature3Feature</term><description>b88ca3a5476ebcc4ea63d5c1e92ce222</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder AddRandomTrashItem(
        this ActionsBuilder builder,
        TrashLootType lootType,
        int maxCost,
        bool? identify = null,
        bool? silent = null)
    {
      var element = ElementTool.Create<ContextActionAddRandomTrashItem>();
      element.m_LootType = lootType;
      element.m_MaxCost = maxCost;
      element.m_Identify = identify ?? element.m_Identify;
      element.m_Silent = silent ?? element.m_Silent;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionApplyBuff"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1_FirstStage_AcidBuff</term><description>6afe27c9a2d64eb890673ff3649dacb3</description></item>
    /// <item><term>HeavyCrossbowOfDegradationAbility</term><description>24948f9879f673e41a7f664a2c775bd7</description></item>
    /// <item><term>ZeorisDaggerRing_GoverningFeature</term><description>0faee0a55f634902895b4e1faf828502</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="notLinkToAreaEffect">
    /// <para>
    /// InfoBox: By default all effects that were created from area effect will be destroyed after area effect ends. Check it on if you want buff to live longer
    /// </para>
    /// </param>
    public static ActionsBuilder ApplyBuffPermanent(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuffReference> buff,
        bool? asChild = null,
        bool? isFromSpell = null,
        bool? isNotDispelable = null,
        bool? notLinkToAreaEffect = null,
        bool? sameDuration = null,
        bool? toCaster = null)
    {
      var element = ElementTool.Create<ContextActionApplyBuff>();
      element.m_Buff = buff?.Reference;
      element.AsChild = asChild ?? element.AsChild;
      element.IsFromSpell = isFromSpell ?? element.IsFromSpell;
      element.IsNotDispelable = isNotDispelable ?? element.IsNotDispelable;
      element.NotLinkToAreaEffect = notLinkToAreaEffect ?? element.NotLinkToAreaEffect;
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1_FirstStage_AcidBuff</term><description>6afe27c9a2d64eb890673ff3649dacb3</description></item>
    /// <item><term>HeavyCrossbowOfDegradationAbility</term><description>24948f9879f673e41a7f664a2c775bd7</description></item>
    /// <item><term>ZeorisDaggerRing_GoverningFeature</term><description>0faee0a55f634902895b4e1faf828502</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="notLinkToAreaEffect">
    /// <para>
    /// InfoBox: By default all effects that were created from area effect will be destroyed after area effect ends. Check it on if you want buff to live longer
    /// </para>
    /// </param>
    public static ActionsBuilder ApplyBuffWithDurationSeconds(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuffReference> buff,
        float durationSeconds,
        bool? asChild = null,
        bool? isFromSpell = null,
        bool? isNotDispelable = null,
        bool? notLinkToAreaEffect = null,
        bool? sameDuration = null,
        bool? toCaster = null)
    {
      var element = ElementTool.Create<ContextActionApplyBuff>();
      element.m_Buff = buff?.Reference;
      element.DurationSeconds = durationSeconds;
      element.AsChild = asChild ?? element.AsChild;
      element.IsFromSpell = isFromSpell ?? element.IsFromSpell;
      element.IsNotDispelable = isNotDispelable ?? element.IsNotDispelable;
      element.NotLinkToAreaEffect = notLinkToAreaEffect ?? element.NotLinkToAreaEffect;
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1_FirstStage_AcidBuff</term><description>6afe27c9a2d64eb890673ff3649dacb3</description></item>
    /// <item><term>HeavyCrossbowOfDegradationAbility</term><description>24948f9879f673e41a7f664a2c775bd7</description></item>
    /// <item><term>ZeorisDaggerRing_GoverningFeature</term><description>0faee0a55f634902895b4e1faf828502</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="notLinkToAreaEffect">
    /// <para>
    /// InfoBox: By default all effects that were created from area effect will be destroyed after area effect ends. Check it on if you want buff to live longer
    /// </para>
    /// </param>
    public static ActionsBuilder ApplyBuff(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuffReference> buff,
        ContextDurationValue durationValue,
        bool? asChild = null,
        bool? isFromSpell = null,
        bool? isNotDispelable = null,
        bool? notLinkToAreaEffect = null,
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
      element.NotLinkToAreaEffect = notLinkToAreaEffect ?? element.NotLinkToAreaEffect;
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
    /// The caster's armor is enchanted based on its available enhancement bonus. e.g. If the armor can be enchanted to +4 and has a +1 enchantment, enchantmentPlus3 is applied.
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SacredArmorEnchantSwitchAbility</term><description>66484ebb8d358db4692ef4445fa6ac35</description></item>
    /// <item><term>ArcaneArmorEnchantSwitchAbility</term><description>ac21d1140c355a449a47a1daead83312</description></item>
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
        Blueprint<BlueprintArmorEnchantmentReference>? enchantmentPlus1 = null,
        Blueprint<BlueprintArmorEnchantmentReference>? enchantmentPlus2 = null,
        Blueprint<BlueprintArmorEnchantmentReference>? enchantmentPlus3 = null,
        Blueprint<BlueprintArmorEnchantmentReference>? enchantmentPlus4 = null,
        Blueprint<BlueprintArmorEnchantmentReference>? enchantmentPlus5 = null,
        ActivatableAbilityGroup? group = null)
    {
      var element = ElementTool.Create<ContextActionArmorEnchantPool>();
      builder.Validate(durationValue);
      element.DurationValue = durationValue;
      element.EnchantPool = enchantPool;
      element.m_DefaultEnchantments[0] = enchantmentPlus1?.Cast<BlueprintItemEnchantmentReference>()?.Reference ?? ArmorEnchantmentRefs.TemporaryArmorEnhancementBonus1.Cast<BlueprintItemEnchantmentReference>().Reference;
      element.m_DefaultEnchantments[1] = enchantmentPlus2?.Cast<BlueprintItemEnchantmentReference>()?.Reference ?? ArmorEnchantmentRefs.TemporaryArmorEnhancementBonus2.Cast<BlueprintItemEnchantmentReference>().Reference;
      element.m_DefaultEnchantments[2] = enchantmentPlus3?.Cast<BlueprintItemEnchantmentReference>()?.Reference ?? ArmorEnchantmentRefs.TemporaryArmorEnhancementBonus3.Cast<BlueprintItemEnchantmentReference>().Reference;
      element.m_DefaultEnchantments[3] = enchantmentPlus4?.Cast<BlueprintItemEnchantmentReference>()?.Reference ?? ArmorEnchantmentRefs.TemporaryArmorEnhancementBonus4.Cast<BlueprintItemEnchantmentReference>().Reference;
      element.m_DefaultEnchantments[4] = enchantmentPlus5?.Cast<BlueprintItemEnchantmentReference>()?.Reference ?? ArmorEnchantmentRefs.TemporaryArmorEnhancementBonus5.Cast<BlueprintItemEnchantmentReference>().Reference;
      element.Group = group ?? element.Group;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionShieldArmorEnchantPool"/>
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// The caster's shield is enchanted based on its available enhancement bonus. e.g. If the shield can be enchanted to +4 and has a +1 enchantment, enchantmentPlus3 is applied.
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SacredArmorShieldEnchantSwitchAbility</term><description>b0777d9974795a5489ff0efd735a4c2a</description></item>
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
        Blueprint<BlueprintArmorEnchantmentReference>? enchantmentPlus1 = null,
        Blueprint<BlueprintArmorEnchantmentReference>? enchantmentPlus2 = null,
        Blueprint<BlueprintArmorEnchantmentReference>? enchantmentPlus3 = null,
        Blueprint<BlueprintArmorEnchantmentReference>? enchantmentPlus4 = null,
        Blueprint<BlueprintArmorEnchantmentReference>? enchantmentPlus5 = null,
        ActivatableAbilityGroup? group = null)
    {
      var element = ElementTool.Create<ContextActionShieldArmorEnchantPool>();
      builder.Validate(durationValue);
      element.DurationValue = durationValue;
      element.EnchantPool = enchantPool;
      element.m_DefaultEnchantments[0] = enchantmentPlus1?.Cast<BlueprintItemEnchantmentReference>()?.Reference ?? ArmorEnchantmentRefs.TemporaryArmorEnhancementBonus1.Cast<BlueprintItemEnchantmentReference>().Reference;
      element.m_DefaultEnchantments[1] = enchantmentPlus2?.Cast<BlueprintItemEnchantmentReference>()?.Reference ?? ArmorEnchantmentRefs.TemporaryArmorEnhancementBonus2.Cast<BlueprintItemEnchantmentReference>().Reference;
      element.m_DefaultEnchantments[2] = enchantmentPlus3?.Cast<BlueprintItemEnchantmentReference>()?.Reference ?? ArmorEnchantmentRefs.TemporaryArmorEnhancementBonus3.Cast<BlueprintItemEnchantmentReference>().Reference;
      element.m_DefaultEnchantments[3] = enchantmentPlus4?.Cast<BlueprintItemEnchantmentReference>()?.Reference ?? ArmorEnchantmentRefs.TemporaryArmorEnhancementBonus4.Cast<BlueprintItemEnchantmentReference>().Reference;
      element.m_DefaultEnchantments[4] = enchantmentPlus5?.Cast<BlueprintItemEnchantmentReference>()?.Reference ?? ArmorEnchantmentRefs.TemporaryArmorEnhancementBonus5.Cast<BlueprintItemEnchantmentReference>().Reference;
      element.Group = group ?? element.Group;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Demoralize"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CornugonSmash</term><description>ceea53555d83f2547ae5fc47e0399e14</description></item>
    /// <item><term>ExecutionerAssassinateDemoralizeAction</term><description>3e7780219eb23b64f8dac5b29bb32e23</description></item>
    /// <item><term>TricksterPersuasionTier1Feature</term><description>4eefa883f5908a347a0b0a891fb859dd</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// <para>
    /// Applied on success. Defaults to Shaken.
    /// </para>
    /// </param>
    /// <param name="extraEffect">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// <para>
    /// Applied on success when the caster has the extraEffectFeature. Defaults to ShatterConfidence.
    /// </para>
    /// </param>
    /// <param name="extraEffectFeature">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// <para>
    /// Unit feature which determines whether to apply extraEffect on success. Defaults to ShatterConfidence.
    /// </para>
    /// </param>
    /// <param name="greaterBuff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// <para>
    /// Applied on success when the caster has a feature that adds a greater effect. Defaults to Frightened.
    /// </para>
    /// </param>
    public static ActionsBuilder Demoralize(
        this ActionsBuilder builder,
        int? bonus = null,
        Blueprint<BlueprintBuffReference> buff = null,
        bool? dazzlingDisplay = null,
        Blueprint<BlueprintBuffReference> extraEffect = null,
        Blueprint<BlueprintFeatureReference> extraEffectFeature = null,
        Blueprint<BlueprintBuffReference> greaterBuff = null,
        ActionsBuilder? tricksterRank3Actions = null)
    {
      var element = ElementTool.Create<Demoralize>();
      element.Bonus = bonus ?? element.Bonus;
      element.m_Buff = (BlueprintBuffReference)(buff?.Reference ?? BuffRefs.Shaken.Reference);
      if (element.m_Buff is null)
      {
        element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      element.DazzlingDisplay = dazzlingDisplay ?? element.DazzlingDisplay;
      element.m_ShatterConfidenceBuff = (BlueprintBuffReference)(extraEffect?.Reference ?? BuffRefs.ShatterConfidenceBuff.Reference);
      if (element.m_ShatterConfidenceBuff is null)
      {
        element.m_ShatterConfidenceBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      element.m_ShatterConfidenceFeature = (BlueprintFeatureReference)(extraEffectFeature?.Reference ?? FeatureRefs.ShatterConfidence.Reference);
      if (element.m_ShatterConfidenceFeature is null)
      {
        element.m_ShatterConfidenceFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      element.m_GreaterBuff = (BlueprintBuffReference)(greaterBuff?.Reference ?? BuffRefs.Frightened.Reference);
      if (element.m_GreaterBuff is null)
      {
        element.m_GreaterBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      element.TricksterRank3Actions = tricksterRank3Actions?.Build() ?? element.TricksterRank3Actions;
      if (element.TricksterRank3Actions is null)
      {
        element.TricksterRank3Actions = Utils.Constants.Empty.Actions;
      }
      element.m_SwordlordProwessFeature = (BlueprintFeatureReference)FeatureRefs.DisplayWeaponProwess.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionWeaponEnchantPool"/>
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// The caster's weapon is enchanted based on its available enhancement bonus. e.g. If the weapon can be enchanted to +4 and has a +1 enchantment, enchantmentPlus3 is applied.
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SacredWeaponEnchantSwitchAbility</term><description>cca63747a12b55f44ad56ef2d840d7f4</description></item>
    /// <item><term>ArcaneWeaponSwitchAbility</term><description>3c89dfc82c2a3f646808ea250eb91b91</description></item>
    /// <item><term>EldritchWeaponSwitchAbility</term><description>8da841a6b9209c544b949a583076b184</description></item>
    /// <item><term>WeaponBondSwitchAbility</term><description>7ff088ab58c69854b82ea95c2b0e35b4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="enchantmentPlus1">
    /// Defaults to TemporaryEnhancement1
    /// </param>
    /// <param name="enchantmentPlus2">
    /// Defaults to TemporaryEnhancement2
    /// </param>
    /// <param name="enchantmentPlus3">
    /// Defaults to TemporaryEnhancement3
    /// </param>
    /// <param name="enchantmentPlus4">
    /// Defaults to TemporaryEnhancement4
    /// </param>
    /// <param name="enchantmentPlus5">
    /// Defaults to TemporaryEnhancement5
    /// </param>
    public static ActionsBuilder WeaponEnchantPool(
        this ActionsBuilder builder,
        ContextDurationValue durationValue,
        EnchantPoolType enchantPool,
        Blueprint<BlueprintWeaponEnchantmentReference>? enchantmentPlus1 = null,
        Blueprint<BlueprintWeaponEnchantmentReference>? enchantmentPlus2 = null,
        Blueprint<BlueprintWeaponEnchantmentReference>? enchantmentPlus3 = null,
        Blueprint<BlueprintWeaponEnchantmentReference>? enchantmentPlus4 = null,
        Blueprint<BlueprintWeaponEnchantmentReference>? enchantmentPlus5 = null,
        ActivatableAbilityGroup? group = null)
    {
      var element = ElementTool.Create<ContextActionWeaponEnchantPool>();
      builder.Validate(durationValue);
      element.DurationValue = durationValue;
      element.EnchantPool = enchantPool;
      element.m_DefaultEnchantments[0] = enchantmentPlus1?.Cast<BlueprintItemEnchantmentReference>()?.Reference ?? WeaponEnchantmentRefs.TemporaryEnhancement1.Cast<BlueprintItemEnchantmentReference>().Reference;
      element.m_DefaultEnchantments[1] = enchantmentPlus2?.Cast<BlueprintItemEnchantmentReference>()?.Reference ?? WeaponEnchantmentRefs.TemporaryEnhancement2.Cast<BlueprintItemEnchantmentReference>().Reference;
      element.m_DefaultEnchantments[2] = enchantmentPlus3?.Cast<BlueprintItemEnchantmentReference>()?.Reference ?? WeaponEnchantmentRefs.TemporaryEnhancement3.Cast<BlueprintItemEnchantmentReference>().Reference;
      element.m_DefaultEnchantments[3] = enchantmentPlus4?.Cast<BlueprintItemEnchantmentReference>()?.Reference ?? WeaponEnchantmentRefs.TemporaryEnhancement4.Cast<BlueprintItemEnchantmentReference>().Reference;
      element.m_DefaultEnchantments[4] = enchantmentPlus5?.Cast<BlueprintItemEnchantmentReference>()?.Reference ?? WeaponEnchantmentRefs.TemporaryEnhancement5.Cast<BlueprintItemEnchantmentReference>().Reference;
      element.Group = group ?? element.Group;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionShieldWeaponEnchantPool"/>
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// The caster's shield is enchanted based on its available enhancement bonus. e.g. If the shield can be enchanted to +4 and has a +1 enchantment, enchantmentPlus3 is applied.
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SacredWeaponShieldEnchantSwitchAbility</term><description>a89fc47958b895948a6c613ec1b9da85</description></item>
    /// <item><term>SacredWeaponShieldEnchantSwitchAbility</term><description>a89fc47958b895948a6c613ec1b9da85</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="enchantmentPlus1">
    /// Defaults to TemporaryEnhancement1
    /// </param>
    /// <param name="enchantmentPlus2">
    /// Defaults to TemporaryEnhancement2
    /// </param>
    /// <param name="enchantmentPlus3">
    /// Defaults to TemporaryEnhancement3
    /// </param>
    /// <param name="enchantmentPlus4">
    /// Defaults to TemporaryEnhancement4
    /// </param>
    /// <param name="enchantmentPlus5">
    /// Defaults to TemporaryEnhancement5
    /// </param>
    public static ActionsBuilder ShieldWeaponEnchantPool(
        this ActionsBuilder builder,
        ContextDurationValue durationValue,
        EnchantPoolType enchantPool,
        Blueprint<BlueprintWeaponEnchantmentReference>? enchantmentPlus1 = null,
        Blueprint<BlueprintWeaponEnchantmentReference>? enchantmentPlus2 = null,
        Blueprint<BlueprintWeaponEnchantmentReference>? enchantmentPlus3 = null,
        Blueprint<BlueprintWeaponEnchantmentReference>? enchantmentPlus4 = null,
        Blueprint<BlueprintWeaponEnchantmentReference>? enchantmentPlus5 = null,
        ActivatableAbilityGroup? group = null)
    {
      var element = ElementTool.Create<ContextActionShieldWeaponEnchantPool>();
      builder.Validate(durationValue);
      element.DurationValue = durationValue;
      element.EnchantPool = enchantPool;
      element.m_DefaultEnchantments[0] = enchantmentPlus1?.Cast<BlueprintItemEnchantmentReference>()?.Reference ?? WeaponEnchantmentRefs.TemporaryEnhancement1.Cast<BlueprintItemEnchantmentReference>().Reference;
      element.m_DefaultEnchantments[1] = enchantmentPlus2?.Cast<BlueprintItemEnchantmentReference>()?.Reference ?? WeaponEnchantmentRefs.TemporaryEnhancement2.Cast<BlueprintItemEnchantmentReference>().Reference;
      element.m_DefaultEnchantments[2] = enchantmentPlus3?.Cast<BlueprintItemEnchantmentReference>()?.Reference ?? WeaponEnchantmentRefs.TemporaryEnhancement3.Cast<BlueprintItemEnchantmentReference>().Reference;
      element.m_DefaultEnchantments[3] = enchantmentPlus4?.Cast<BlueprintItemEnchantmentReference>()?.Reference ?? WeaponEnchantmentRefs.TemporaryEnhancement4.Cast<BlueprintItemEnchantmentReference>().Reference;
      element.m_DefaultEnchantments[4] = enchantmentPlus5?.Cast<BlueprintItemEnchantmentReference>()?.Reference ?? WeaponEnchantmentRefs.TemporaryEnhancement5.Cast<BlueprintItemEnchantmentReference>().Reference;
      element.Group = group ?? element.Group;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionBreathOfLife"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AngelBringBackTouch</term><description>067035da0186d6e43bb4138f433911ee</description></item>
    /// <item><term>FlamewardenEmbersTouch</term><description>9c7ebca48b7340242a761a9f53e2f010</description></item>
    /// <item><term>LifeKissBuff</term><description>7512011264d04fc4a15fa9329f287b86</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>TricksterBreathOfMoney</term><description>bc9f91f243634c04bcee43028362b5c3</description></item>
    /// </list>
    /// </remarks>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1_FirstStage_AcidBuff</term><description>6afe27c9a2d64eb890673ff3649dacb3</description></item>
    /// <item><term>HellAngelSwordMaximizeAbility</term><description>3784daa048b715b43911ef43da6b3817</description></item>
    /// <item><term>ZombieDeathEffectSlashingBuff</term><description>912375890d1543ddbce40176d06bb85d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="spell">
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="overrideDC">
    /// <para>
    /// Overrides the default spell DC
    /// </para>
    /// </param>
    /// <param name="overrideSpellLevel">
    /// <para>
    /// Overrides the default spell level
    /// </para>
    /// </param>
    public static ActionsBuilder CastSpell(
        this ActionsBuilder builder,
        Blueprint<BlueprintAbilityReference> spell,
        bool? castByTarget = null,
        bool? logIfCanNotTarget = null,
        ContextValue? overrideDC = null,
        ContextValue? overrideSpellLevel = null)
    {
      var element = ElementTool.Create<ContextActionCastSpell>();
      element.m_Spell = spell?.Reference;
      element.CastByTarget = castByTarget ?? element.CastByTarget;
      element.LogIfCanNotTarget = logIfCanNotTarget ?? element.LogIfCanNotTarget;
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AmiriCampBuff</term><description>f04177fdba7bb324589b7f2b0fd67604</description></item>
    /// <item><term>Hypnotism</term><description>88367310478c10b47903463c5d0152b0</description></item>
    /// <item><term>VampiricShadowShieldDamage</term><description>bc37ed2b2ed82d9498b310c30d7c9d2a</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AmiriCampBuff</term><description>f04177fdba7bb324589b7f2b0fd67604</description></item>
    /// <item><term>Hypnotism</term><description>88367310478c10b47903463c5d0152b0</description></item>
    /// <item><term>VampiricShadowShieldDamage</term><description>bc37ed2b2ed82d9498b310c30d7c9d2a</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AmiriCampBuff</term><description>f04177fdba7bb324589b7f2b0fd67604</description></item>
    /// <item><term>Hypnotism</term><description>88367310478c10b47903463c5d0152b0</description></item>
    /// <item><term>VampiricShadowShieldDamage</term><description>bc37ed2b2ed82d9498b310c30d7c9d2a</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AmiriCampBuff</term><description>f04177fdba7bb324589b7f2b0fd67604</description></item>
    /// <item><term>Hypnotism</term><description>88367310478c10b47903463c5d0152b0</description></item>
    /// <item><term>VampiricShadowShieldDamage</term><description>bc37ed2b2ed82d9498b310c30d7c9d2a</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AmiriCampBuff</term><description>f04177fdba7bb324589b7f2b0fd67604</description></item>
    /// <item><term>Hypnotism</term><description>88367310478c10b47903463c5d0152b0</description></item>
    /// <item><term>VampiricShadowShieldDamage</term><description>bc37ed2b2ed82d9498b310c30d7c9d2a</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AmiriCampBuff</term><description>f04177fdba7bb324589b7f2b0fd67604</description></item>
    /// <item><term>Hypnotism</term><description>88367310478c10b47903463c5d0152b0</description></item>
    /// <item><term>VampiricShadowShieldDamage</term><description>bc37ed2b2ed82d9498b310c30d7c9d2a</description></item>
    /// </list>
    /// </remarks>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonSummonAbilityTier10</term><description>2f1fe3e859b91fd43aac3c76e84b7634</description></item>
    /// <item><term>DemonSummonAbilityTier2</term><description>b17352531cb25d64fbf4078b856383c5</description></item>
    /// <item><term>TricksterSummonAbilityTier9</term><description>67a477f124a8a07428e6ae5a759da420</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="summonPool">
    /// <para>
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder ClearSummonPool(
        this ActionsBuilder builder,
        Blueprint<BlueprintSummonPoolReference> summonPool)
    {
      var element = ElementTool.Create<ContextActionClearSummonPool>();
      element.m_SummonPool = summonPool?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionCombatManeuver"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AnotherDragon_UndeadBreath</term><description>b17a9c289501ba740bf5853db381d4a9</description></item>
    /// <item><term>LegSweepBuff</term><description>b14f60ae4e3624947bfa24b783ecb8b8</description></item>
    /// <item><term>TwoHandedFighterPiledriverTripAbility</term><description>1202b3d188c9bdc46987a5da168ec6d9</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MimicOozeGrabFeature</term><description>d55a5450d8d9da64e90d1e35c9320183</description></item>
    /// <item><term>ShamblingMoundGrabFeature</term><description>efc1e80fb41e06544be46604983806d6</description></item>
    /// <item><term>ShifterGrabBear</term><description>fad3b744c99d42a48196ffd4d5557d15</description></item>
    /// </list>
    /// </remarks>
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
        element.Failure = Utils.Constants.Empty.Actions;
      }
      element.Success = success?.Build() ?? element.Success;
      if (element.Success is null)
      {
        element.Success = Utils.Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionDealDamage"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1_FirstStage_AcidBuff</term><description>6afe27c9a2d64eb890673ff3649dacb3</description></item>
    /// <item><term>FormOfTheDragonIIIGoldBreathWeaponAbility</term><description>6722219d5c8205c4d8ee4c2f41c31e4e</description></item>
    /// <item><term>ZombieSlashingExplosion</term><description>f6b63adab8b645c8beb9cab170dac9d3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="criticalSharedValue">
    /// <para>
    /// If specified and the attack roll is a critical, this shared value is set to 1
    /// </para>
    /// </param>
    /// <param name="resultSharedValue">
    /// <para>
    /// If specified, the resulting damage is stored in this shared value
    /// </para>
    /// </param>
    /// <param name="setFactAsReason">
    /// <para>
    /// InfoBox: Fact that holds action should be the reason rather than attack roll from context (to prevent infinite cycles
    /// </para>
    /// </param>
    /// <param name="useWeaponDamageModifiers">
    /// <para>
    /// InfoBox: For kinetic blades mainly. Adds damage modifiers from weapon stats rule (like power attack)
    /// </para>
    /// </param>
    public static ActionsBuilder DealDamage(
        this ActionsBuilder builder,
        DamageTypeDescription damageType,
        ContextDiceValue value,
        AbilitySharedValue? criticalSharedValue = null,
        bool? half = null,
        bool? halfIfSaved = null,
        bool? ignoreCritical = null,
        bool? ignoreUnitModifiers = null,
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
      element.IgnoreUnitModifiers = ignoreUnitModifiers ?? element.IgnoreUnitModifiers;
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1_FirstStage_AcidBuff</term><description>6afe27c9a2d64eb890673ff3649dacb3</description></item>
    /// <item><term>FormOfTheDragonIIIGoldBreathWeaponAbility</term><description>6722219d5c8205c4d8ee4c2f41c31e4e</description></item>
    /// <item><term>ZombieSlashingExplosion</term><description>f6b63adab8b645c8beb9cab170dac9d3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="criticalSharedValue">
    /// <para>
    /// If specified and the attack roll is a critical, this shared value is set to 1
    /// </para>
    /// </param>
    /// <param name="resultSharedValue">
    /// <para>
    /// If specified, the resulting damage is stored in this shared value
    /// </para>
    /// </param>
    /// <param name="setFactAsReason">
    /// <para>
    /// InfoBox: Fact that holds action should be the reason rather than attack roll from context (to prevent infinite cycles
    /// </para>
    /// </param>
    /// <param name="useWeaponDamageModifiers">
    /// <para>
    /// InfoBox: For kinetic blades mainly. Adds damage modifiers from weapon stats rule (like power attack)
    /// </para>
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
        bool? ignoreUnitModifiers = null,
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
      element.IgnoreUnitModifiers = ignoreUnitModifiers ?? element.IgnoreUnitModifiers;
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1_FirstStage_AcidBuff</term><description>6afe27c9a2d64eb890673ff3649dacb3</description></item>
    /// <item><term>FormOfTheDragonIIIGoldBreathWeaponAbility</term><description>6722219d5c8205c4d8ee4c2f41c31e4e</description></item>
    /// <item><term>ZombieSlashingExplosion</term><description>f6b63adab8b645c8beb9cab170dac9d3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="criticalSharedValue">
    /// <para>
    /// If specified and the attack roll is a critical, this shared value is set to 1
    /// </para>
    /// </param>
    /// <param name="resultSharedValue">
    /// <para>
    /// If specified, the resulting damage is stored in this shared value
    /// </para>
    /// </param>
    /// <param name="setFactAsReason">
    /// <para>
    /// InfoBox: Fact that holds action should be the reason rather than attack roll from context (to prevent infinite cycles
    /// </para>
    /// </param>
    public static ActionsBuilder DealDamageToAbility(
        this ActionsBuilder builder,
        StatType abilityType,
        ContextDiceValue value,
        AbilitySharedValue? criticalSharedValue = null,
        bool? drain = null,
        bool? halfIfSaved = null,
        bool? ignoreCritical = null,
        bool? ignoreUnitModifiers = null,
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
      element.IgnoreUnitModifiers = ignoreUnitModifiers ?? element.IgnoreUnitModifiers;
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1_FirstStage_AcidBuff</term><description>6afe27c9a2d64eb890673ff3649dacb3</description></item>
    /// <item><term>FormOfTheDragonIIIGoldBreathWeaponAbility</term><description>6722219d5c8205c4d8ee4c2f41c31e4e</description></item>
    /// <item><term>ZombieSlashingExplosion</term><description>f6b63adab8b645c8beb9cab170dac9d3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="criticalSharedValue">
    /// <para>
    /// If specified and the attack roll is a critical, this shared value is set to 1
    /// </para>
    /// </param>
    /// <param name="resultSharedValue">
    /// <para>
    /// If specified, the resulting damage is stored in this shared value
    /// </para>
    /// </param>
    /// <param name="setFactAsReason">
    /// <para>
    /// InfoBox: Fact that holds action should be the reason rather than attack roll from context (to prevent infinite cycles
    /// </para>
    /// </param>
    /// <param name="useWeaponDamageModifiers">
    /// <para>
    /// InfoBox: For kinetic blades mainly. Adds damage modifiers from weapon stats rule (like power attack)
    /// </para>
    /// </param>
    public static ActionsBuilder DealDamagePermanentNegativeLevels(
        this ActionsBuilder builder,
        ContextDiceValue value,
        AbilitySharedValue? criticalSharedValue = null,
        bool? halfIfSaved = null,
        bool? ignoreCritical = null,
        bool? ignoreUnitModifiers = null,
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
      element.IgnoreUnitModifiers = ignoreUnitModifiers ?? element.IgnoreUnitModifiers;
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1_FirstStage_AcidBuff</term><description>6afe27c9a2d64eb890673ff3649dacb3</description></item>
    /// <item><term>FormOfTheDragonIIIGoldBreathWeaponAbility</term><description>6722219d5c8205c4d8ee4c2f41c31e4e</description></item>
    /// <item><term>ZombieSlashingExplosion</term><description>f6b63adab8b645c8beb9cab170dac9d3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="criticalSharedValue">
    /// <para>
    /// If specified and the attack roll is a critical, this shared value is set to 1
    /// </para>
    /// </param>
    /// <param name="resultSharedValue">
    /// <para>
    /// If specified, the resulting damage is stored in this shared value
    /// </para>
    /// </param>
    /// <param name="setFactAsReason">
    /// <para>
    /// InfoBox: Fact that holds action should be the reason rather than attack roll from context (to prevent infinite cycles
    /// </para>
    /// </param>
    /// <param name="useWeaponDamageModifiers">
    /// <para>
    /// InfoBox: For kinetic blades mainly. Adds damage modifiers from weapon stats rule (like power attack)
    /// </para>
    /// </param>
    public static ActionsBuilder DealDamageTemporaryNegativeLevels(
        this ActionsBuilder builder,
        ContextDurationValue duration,
        ContextDiceValue value,
        AbilitySharedValue? criticalSharedValue = null,
        bool? halfIfSaved = null,
        bool? ignoreCritical = null,
        bool? ignoreUnitModifiers = null,
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
      element.IgnoreUnitModifiers = ignoreUnitModifiers ?? element.IgnoreUnitModifiers;
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonAreaEffectsGazeAllyBuff</term><description>5f628dc321f74a6bbadec25f665a402d</description></item>
    /// <item><term>HealersWayOthers</term><description>428006e0c196ffc48b54a4404b728c51</description></item>
    /// <item><term>ZombieDispelExplosion</term><description>bcd9277193ef41dfb8d3b292ee33c828</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="checkSchoolOrDescriptor">
    /// <para>
    /// If true, effects matching school or descriptor are targeted. If false, effects matching school and descriptor are targeted.
    /// </para>
    /// </param>
    /// <param name="descriptor">
    /// <para>
    /// Tooltip: &amp;apos;None&amp;apos; means &amp;apos;All&amp;apos;
    /// </para>
    /// </param>
    /// <param name="oneRollForAll">
    /// <para>
    /// InfoBox: If true only one roll for all checks will be made
    /// </para>
    /// </param>
    /// <param name="schools">
    /// <para>
    /// Tooltip: Empty means &amp;apos;All&amp;apos;
    /// </para>
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
        element.OnFail = Utils.Constants.Empty.Actions;
      }
      element.OnlyEnemyAreaEffects = onlyEnemyAreaEffects ?? element.OnlyEnemyAreaEffects;
      element.OnlyTargetEnemyBuffs = onlyTargetEnemyBuffs ?? element.OnlyTargetEnemyBuffs;
      element.OnSuccess = onSuccess?.Build() ?? element.OnSuccess;
      if (element.OnSuccess is null)
      {
        element.OnSuccess = Utils.Constants.Empty.Actions;
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
    /// Adds <see cref="EnhanceWeapon"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BeastTamerInspireFerocity10EffectBuff</term><description>f36ed94198f5d3e4ca238a9731487d10</description></item>
    /// <item><term>MagicWeaponGreaterPrimary</term><description>a3fe23711486ee9489af1dadd6906149</description></item>
    /// <item><term>ThornBody</term><description>2daf9c5112f16d54ab3cd6904c705c59</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="enchantment">
    /// <para>
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder EnhanceWeapon(
        this ActionsBuilder builder,
        ContextDurationValue durationValue,
        Blueprint<BlueprintItemEnchantmentReference> enchantment,
        bool? useSecondaryHand = null)
    {
      var element = ElementTool.Create<EnhanceWeapon>();
      builder.Validate(durationValue);
      element.DurationValue = durationValue;
      element.m_Enchantment = new BlueprintItemEnchantmentReference[] { enchantment.Reference };
      element.UseSecondaryHand = useSecondaryHand ?? element.UseSecondaryHand;
      element.EnchantmentType = Kingmaker.UnitLogic.Mechanics.Actions.EnhanceWeapon.EnchantmentApplyType.MagicWeapon;
      element.Greater = false;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="EnhanceWeapon"/>
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// The enchantment at index EnchantLevel - 1 is applied or the last enchantment if it is too large.
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BeastTamerInspireFerocity10EffectBuff</term><description>f36ed94198f5d3e4ca238a9731487d10</description></item>
    /// <item><term>MagicWeaponGreaterPrimary</term><description>a3fe23711486ee9489af1dadd6906149</description></item>
    /// <item><term>ThornBody</term><description>2daf9c5112f16d54ab3cd6904c705c59</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="enchantment">
    /// <para>
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder EnhanceWeaponGreater(
        this ActionsBuilder builder,
        ContextDurationValue durationValue,
        ContextValue enchantLevel,
        List<Blueprint<BlueprintItemEnchantmentReference>> enchantment,
        bool? useSecondaryHand = null)
    {
      var element = ElementTool.Create<EnhanceWeapon>();
      builder.Validate(durationValue);
      element.DurationValue = durationValue;
      element.EnchantLevel = enchantLevel;
      element.m_Enchantment = enchantment?.Select(bp => bp.Reference)?.ToArray();
      element.UseSecondaryHand = useSecondaryHand ?? element.UseSecondaryHand;
      element.EnchantmentType = Kingmaker.UnitLogic.Mechanics.Actions.EnhanceWeapon.EnchantmentApplyType.MagicWeapon;
      element.Greater = true;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="EnhanceWeapon"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BeastTamerInspireFerocity10EffectBuff</term><description>f36ed94198f5d3e4ca238a9731487d10</description></item>
    /// <item><term>MagicWeaponGreaterPrimary</term><description>a3fe23711486ee9489af1dadd6906149</description></item>
    /// <item><term>ThornBody</term><description>2daf9c5112f16d54ab3cd6904c705c59</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="enchantment">
    /// <para>
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder EnhanceNaturalWeapon(
        this ActionsBuilder builder,
        ContextDurationValue durationValue,
        Blueprint<BlueprintItemEnchantmentReference> enchantment)
    {
      var element = ElementTool.Create<EnhanceWeapon>();
      builder.Validate(durationValue);
      element.DurationValue = durationValue;
      element.m_Enchantment = new BlueprintItemEnchantmentReference[] { enchantment.Reference };
      element.EnchantmentType = Kingmaker.UnitLogic.Mechanics.Actions.EnhanceWeapon.EnchantmentApplyType.MagicFang;
      element.Greater = false;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="EnhanceWeapon"/>
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// The enchantment at index EnchantLevel - 1 is applied or the last enchantment if it is too large.
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BeastTamerInspireFerocity10EffectBuff</term><description>f36ed94198f5d3e4ca238a9731487d10</description></item>
    /// <item><term>MagicWeaponGreaterPrimary</term><description>a3fe23711486ee9489af1dadd6906149</description></item>
    /// <item><term>ThornBody</term><description>2daf9c5112f16d54ab3cd6904c705c59</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="enchantment">
    /// <para>
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder EnhanceNaturalWeaponGreater(
        this ActionsBuilder builder,
        ContextDurationValue durationValue,
        ContextValue enchantLevel,
        List<Blueprint<BlueprintItemEnchantmentReference>> enchantment)
    {
      var element = ElementTool.Create<EnhanceWeapon>();
      builder.Validate(durationValue);
      element.DurationValue = durationValue;
      element.EnchantLevel = enchantLevel;
      element.m_Enchantment = enchantment?.Select(bp => bp.Reference)?.ToArray();
      element.EnchantmentType = Kingmaker.UnitLogic.Mechanics.Actions.EnhanceWeapon.EnchantmentApplyType.MagicFang;
      element.Greater = true;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionEnchantWornItem"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Abadar_Buff</term><description>70b34e1de03641b4a5a35b5fda6f0642</description></item>
    /// <item><term>LawDomainGreaterAbility</term><description>0b1615ec2dabc6f4294a254b709188a4</description></item>
    /// <item><term>TestEnchantWeapon</term><description>65eb9b6865a556f47a0b67ddce1689de</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="enchantment">
    /// <para>
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder EnchantWornItem(
        this ActionsBuilder builder,
        ContextDurationValue durationValue,
        Blueprint<BlueprintItemEnchantmentReference> enchantment,
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0031</term><description>651f8c38ef915c14499ff3e4447d8b17</description></item>
    /// <item><term>DiplomacyRankUp2Project</term><description>eec2844333716044680b3e7c4f34d638</description></item>
    /// <item><term>ObjectiveFirstBuildings</term><description>457030968c4bfc948ada8121bd6aa837</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="objective">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder FinishObjective(
        this ActionsBuilder builder,
        Blueprint<BlueprintQuestObjectiveReference> objective)
    {
      var element = ElementTool.Create<ContextActionFinishObjective>();
      element.m_Objective = objective?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionGrapple"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GolemAutumnGrabFeature</term><description>0d1d262d3437ec143b16b47e24317bbc</description></item>
    /// <item><term>ShamblingMoundGrabFeature</term><description>efc1e80fb41e06544be46604983806d6</description></item>
    /// <item><term>ShifterGrabBear</term><description>fad3b744c99d42a48196ffd4d5557d15</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="casterBuff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// <para>
    /// Buff applied to the caster for the duration of the grapple check
    /// </para>
    /// </param>
    /// <param name="targetBuff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// <para>
    /// Buff applied to the target for the duration of the grapple check
    /// </para>
    /// </param>
    public static ActionsBuilder Grapple(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuffReference>? casterBuff = null,
        Blueprint<BlueprintBuffReference>? targetBuff = null)
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AngelCleansingFlames</term><description>3c4c33f314a8bd64994d34ed5db2b96f</description></item>
    /// <item><term>PowerOfFaithTier3Area</term><description>9175b3337ba088446b4050e9d4473c47</description></item>
    /// <item><term>WitchHexRegenerativeSinewRestorationAbility</term><description>0a6effb356101cc46aa0bed8c3ab6fd4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="value">
    /// <para>
    /// Required when the heal type is StatDamageHealType.Dice
    /// </para>
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
        element.Value = Utils.Constants.Empty.DiceValue;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionHealTarget"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1_FirstDeathAbility</term><description>4445d9d1c21141c6a0bb24baf373ef78</description></item>
    /// <item><term>HellsSealVariantFireHealingBuff</term><description>7dff1e5c8150dc441b7600468092a8c6</description></item>
    /// <item><term>ZachariusParalyzingTouchAbility</term><description>dbd157bc98c11a341b3b605ad58d5a57</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneMovementFeature</term><description>16c1ec2a313ce0b49ac1acbda42496e8</description></item>
    /// <item><term>FormOfTheDragonIGoldBreathWeaponAbility</term><description>5674de7c683b642409bfaf59838453a1</description></item>
    /// <item><term>XantirOnlySwarm_MidnightFaneInThePastFeature</term><description>5131c4b93f314bd4589edf612b4eb600</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonPrimordialMagicSupportGazeAllyBuff</term><description>7e86ccb12393470db3f0fc6757acb17b</description></item>
    /// <item><term>FeralRaiderEnchantment</term><description>50309931d32f4b758181af05c7fe617c</description></item>
    /// <item><term>SongOfTheFallenEffectArea</term><description>7ee5526cb80b4ded87e9aa09cb5f5095</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder OnOwner(
        this ActionsBuilder builder,
        ActionsBuilder actions)
    {
      var element = ElementTool.Create<ContextActionOnOwner>();
      element.Actions = actions?.Build();
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionsOnPet"/>
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Actions are run on all of the target unit's pets.
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidMaw</term><description>75de4ded3e731dc4f84d978fe947dc67</description></item>
    /// <item><term>FeralRaiderEnchantment</term><description>50309931d32f4b758181af05c7fe617c</description></item>
    /// <item><term>SoheiMonasticMountAbility</term><description>15029d70cc507ae4cb480a7092775302</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="petType">
    /// <para>
    /// If specified, actions only run on pets of that type.
    /// </para>
    /// </param>
    public static ActionsBuilder OnPets(
        this ActionsBuilder builder,
        ActionsBuilder actions,
        PetType? petType = null)
    {
      var element = ElementTool.Create<ContextActionsOnPet>();
      element.Actions = actions?.Build();
      element.PetType = petType ?? element.PetType;
      element.AllPets = petType is not null;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionOnRandomAreaTarget"/>
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Only works inside of AbilityAreaEffectRunAction and only effects enemies.
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_ElementalLocusAreaEffect</term><description>a7e320519348419fb7f8cede05692535</description></item>
    /// <item><term>StormCallArea</term><description>85c1ea0021ce2714f8559fb618bf7ff6</description></item>
    /// </list>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AngelPhoenixGiftBuff</term><description>9988e25ec217c0249a28213e7dc0017c</description></item>
    /// <item><term>GauntletsOfMightySwipeBuff</term><description>20ea90af5be842841b71ef3c8241d1d7</description></item>
    /// <item><term>NokNokCampBuff</term><description>f2c1c3b5db4ff444b9496b7f6127e2ee</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="filterNoFact">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder OnRandomTargetsAround(
        this ActionsBuilder builder,
        ActionsBuilder actions,
        Blueprint<BlueprintUnitFactReference>? filterNoFact = null,
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BloodlineSerpentineDenOfSpidersSpiderSwarmDamageBuff</term><description>9c414efda39e67344846171c1547edc1</description></item>
    /// <item><term>MandragoraSwarmDamageBuff</term><description>0f4923163104a8748b88e91ec7e14837</description></item>
    /// <item><term>VescavorSwarmDamageBuff</term><description>ddc847a49246ded4f93fe2bf0e2a7dab</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Artifact_HornsOfNaragaDeactivateAbility</term><description>ae0c700e37d044998e8bafefe76fc4f7</description></item>
    /// <item><term>InvisibilityMassBuff</term><description>21d0ca87ffdda4845be154ba0fe3ac6a</description></item>
    /// <item><term>ZeorisDaggerRing_GoverningFeature</term><description>0faee0a55f634902895b4e1faf828502</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder PartyMembers(
        this ActionsBuilder builder,
        ActionsBuilder? action = null)
    {
      var element = ElementTool.Create<ContextActionPartyMembers>();
      element.Action = action?.Build() ?? element.Action;
      if (element.Action is null)
      {
        element.Action = Utils.Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionProjectileFx"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Archpriest_PossessionAbility</term><description>a3855d55b2304f89b63ebd1a9b1dc144</description></item>
    /// <item><term>DLC2_HealWizard_Spell</term><description>d531862b380248028238aef16983ee55</description></item>
    /// <item><term>VampiricTouchForImbueArrow</term><description>e317cd6700fcb894ca5bb00b9f742eba</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="projectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder ProjectileFx(
        this ActionsBuilder builder,
        Blueprint<BlueprintProjectileReference> projectile)
    {
      var element = ElementTool.Create<ContextActionProjectileFx>();
      element.m_Projectile = projectile?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRandomize"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AmberLoveGlovesFeature</term><description>12d49e8aa9ce501429f98c2ed564d94c</description></item>
    /// <item><term>FlagTrickster3Economy</term><description>4b833c6fcdfa47918927d80edf7ef9ae</description></item>
    /// <item><term>Vrolikai_AreaEffect_DeathStealingGaze</term><description>9fd8c97fa994e5b4da2ff5a9606faab5</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="weightedActions">
    /// <para>
    /// List of a pair mapping to ContextActionRandomize.ActionWrapper. Weight represents the relative probability compared to the other entries in the list.
    /// </para>
    /// </param>
    public static ActionsBuilder Randomize(this ActionsBuilder builder, params (ActionsBuilder actions, int weight)[] weightedActions)
    {
      var element = ElementTool.Create<ContextActionRandomize>();
      builder.Validate(weightedActions);
      element.m_Actions = weightedActions.Select(action => new ContextActionRandomize.ActionWrapper { Action = action.actions.Build(), Weight = action.weight }).ToArray();
      element.CalculateSeed = false;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRandomize"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AmberLoveGlovesFeature</term><description>12d49e8aa9ce501429f98c2ed564d94c</description></item>
    /// <item><term>FlagTrickster3Economy</term><description>4b833c6fcdfa47918927d80edf7ef9ae</description></item>
    /// <item><term>Vrolikai_AreaEffect_DeathStealingGaze</term><description>9fd8c97fa994e5b4da2ff5a9606faab5</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="weightedActions">
    /// <para>
    /// List of a pair mapping to ContextActionRandomize.ActionWrapper. Weight represents the relative probability compared to the other entries in the list.
    /// </para>
    /// </param>
    public static ActionsBuilder RandomizeWithSeed(
        this ActionsBuilder builder,
        IntEvaluator salt,
        IntEvaluator seed,
        List<(ActionsBuilder actions, int weight)> weightedActions)
    {
      var element = ElementTool.Create<ContextActionRandomize>();
      builder.Validate(salt);
      element.Salt = salt;
      builder.Validate(seed);
      element.Seed = seed;
      builder.Validate(weightedActions);
      element.m_Actions = weightedActions.Select(action => new ContextActionRandomize.ActionWrapper { Action = action.actions.Build(), Weight = action.weight }).ToArray();
      element.CalculateSeed = true;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRecoverItemCharges"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SkeletalFingerRodQuickenNormalFeature</term><description>5e441ed7d3887d24bbc9a6e600dbb7d2</description></item>
    /// <item><term>SkeletalFingerRodQuickenNormalKillBuff</term><description>e1c9d88a7be14454bd110a2ea406c3e0</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="item">
    /// <para>
    /// Blueprint of type BlueprintItemEquipment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder RecoverItemCharges(
        this ActionsBuilder builder,
        Blueprint<BlueprintItemEquipmentReference> item,
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BloodHazeEffectBuff</term><description>06bd4a59646b7fa468166d1c745f31dc</description></item>
    /// <item><term>FormOfTheDragonIIBrassBreathWeaponAbility</term><description>eec22855045a0c4419b2e61457797283</description></item>
    /// <item><term>WitchHexCackleAbility</term><description>4bd01292a9bc4304f861a6a07f03b855</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="targetBuff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder IncreaseBuffDuration(
        this ActionsBuilder builder,
        ContextDurationValue durationValue,
        Blueprint<BlueprintBuffReference> targetBuff,
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BloodHazeEffectBuff</term><description>06bd4a59646b7fa468166d1c745f31dc</description></item>
    /// <item><term>FormOfTheDragonIIBrassBreathWeaponAbility</term><description>eec22855045a0c4419b2e61457797283</description></item>
    /// <item><term>WitchHexCackleAbility</term><description>4bd01292a9bc4304f861a6a07f03b855</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="targetBuff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder ReduceBuffDuration(
        this ActionsBuilder builder,
        ContextDurationValue durationValue,
        Blueprint<BlueprintBuffReference> targetBuff,
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1_FirstDeathAbility</term><description>4445d9d1c21141c6a0bb24baf373ef78</description></item>
    /// <item><term>GrenadierAlchemistFireMove</term><description>4356fcafc22a1e04db280577676b6af0</description></item>
    /// <item><term>ZeorisDaggerRing_GoverningFeature</term><description>0faee0a55f634902895b4e1faf828502</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="onlyFromCaster">
    /// <para>
    /// InfoBox: Remove buff from target that was attached by caster
    /// </para>
    /// </param>
    /// <param name="toCaster">
    /// <para>
    /// InfoBox: Apply this action to caster = Remove buff From caster of context
    /// </para>
    /// </param>
    public static ActionsBuilder RemoveBuff(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuffReference> buff,
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AngelSwordSwitchAbility</term><description>9efd605503f248a428df32e20b3152a6</description></item>
    /// <item><term>JokeOfNatureArrowsQuiverQuiverOnEnemyAbility</term><description>c0d67ffae33edc34ea1b861de2825487</description></item>
    /// <item><term>WitchHexAnimalSkinAbility</term><description>3cae80cecdc2fb84b86587032132d48f</description></item>
    /// </list>
    /// </remarks>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidBreathSpell_Cutscene</term><description>1153db4515d4f2b4188a13336930c7cb</description></item>
    /// <item><term>IceStormArea</term><description>4c695315962bf9a4ea7fc7e2bb3e2f60</description></item>
    /// <item><term>WildShapeElementalAirSmallWhirlwindArea</term><description>91f4541e0eb353b4681289cc9615a79d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="targetBuff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder RemoveBuffSingleStack(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuffReference> targetBuff)
    {
      var element = ElementTool.Create<ContextActionRemoveBuffSingleStack>();
      element.m_TargetBuff = targetBuff?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRepeatedActions"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>RitualEnervationAbility</term><description>c7ada41e7da849aeb85672b669116364</description></item>
    /// </list>
    /// </remarks>
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
    /// Adds <see cref="ContextRestoreResource"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcanistConsumeSpellsAbility1</term><description>46ac75e80be0cbd448ac48af6e75303f</description></item>
    /// <item><term>BloodragerStandartRageBuff</term><description>5eac31e457999334b98f98b60fc73b2f</description></item>
    /// <item><term>SecondBreath</term><description>d7e6f8a0369530341b50987d3ebdfe57</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="resource">
    /// <para>
    /// Blueprint of type BlueprintAbilityResource. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="value">
    /// <para>
    /// Amount to restore. If not specified the resource is fully restored.
    /// </para>
    /// </param>
    public static ActionsBuilder RestoreResource(
        this ActionsBuilder builder,
        Blueprint<BlueprintAbilityResourceReference> resource,
        ContextValue? value = null)
    {
      var element = ElementTool.Create<ContextRestoreResource>();
      element.m_Resource = resource?.Reference;
      element.Value = value ?? element.Value;
      element.ContextValueRestoration = value is not null;
      if (element.Value is null)
      {
        element.Value = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextRestoreResource"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcanistConsumeSpellsAbility1</term><description>46ac75e80be0cbd448ac48af6e75303f</description></item>
    /// <item><term>BloodragerStandartRageBuff</term><description>5eac31e457999334b98f98b60fc73b2f</description></item>
    /// <item><term>SecondBreath</term><description>d7e6f8a0369530341b50987d3ebdfe57</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder RestoreAllResources(this ActionsBuilder builder)
    {
      var element = ElementTool.Create<ContextRestoreResource>();
      element.m_IsFullRestoreAllResources = true;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRestoreSpells"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>EldritchFontBottomlessWellAbility</term><description>9a6e3027901ab9841ad98d2cbfce0b72</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="spellbooks">
    /// <para>
    /// Blueprint of type BlueprintSpellbook. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder RestoreSpells(this ActionsBuilder builder, params Blueprint<BlueprintSpellbookReference>[] spellbooks)
    {
      var element = ElementTool.Create<ContextActionRestoreSpells>();
      element.m_Spellbooks = spellbooks.Select(bp => bp.Reference).ToArray();
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionResurrect"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AngelfireApostleVersatileChannelResurrection</term><description>ad3aa8d5ef1c870448c23aae301a45b6</description></item>
    /// <item><term>RaiseDead</term><description>a0fc99f0933d01643b2b8fe570caa4c5</description></item>
    /// <item><term>WitchHexLifeGiverAbility</term><description>cedc4959ab311d548881844eecddf57a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="customResurrectionBuff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// <para>
    /// Replaces the default resurrection buff. Must contain a ResurrectionLogic component.
    /// </para>
    /// </param>
    /// <param name="resultHealth">
    /// <para>
    /// Percentage of unit's health after resurrection as a float between 0.0 (0%) and 1.0 (100%).
    /// </para>
    /// </param>
    public static ActionsBuilder Resurrect(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuffReference>? customResurrectionBuff = null,
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AngelfireApostleVersatileChannelResurrection</term><description>ad3aa8d5ef1c870448c23aae301a45b6</description></item>
    /// <item><term>RaiseDead</term><description>a0fc99f0933d01643b2b8fe570caa4c5</description></item>
    /// <item><term>WitchHexLifeGiverAbility</term><description>cedc4959ab311d548881844eecddf57a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="customResurrectionBuff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// <para>
    /// Replaces the default resurrection buff. Must contain a ResurrectionLogic component.
    /// </para>
    /// </param>
    public static ActionsBuilder ResurrectAndFullRestore(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuffReference>? customResurrectionBuff = null)
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1_FirstStage_AcidBuff</term><description>6afe27c9a2d64eb890673ff3649dacb3</description></item>
    /// <item><term>FormOfTheDragonIIIFrightfulPresenceArea</term><description>5d44a8408f6907a4eb19a28ae24fb5fe</description></item>
    /// <item><term>ZachariusFearAuraArea</term><description>d363527fe31581149b2d53686075c14d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="fromBuff">
    /// <para>
    /// InfoBox: Search through Actions, find ContextActionApplyBuff and use it in saving throw rule (used in BuffDescriptorImmunity for now)
    /// </para>
    /// <para>
    /// If true, onResult must have a ContextActionConditionalSaved w/ ContextActionApplyBuff in it's success actions. The buff associated with that component is attached to the RuleSavingThrow.
    /// </para>
    /// </param>
    /// <param name="useDCFromContextSavingThrow">
    /// <para>
    /// InfoBox: If context already had saving throw use DC from it (for example if this action is in trigger on fireball cast) If not check this fact DC or CustomDC
    /// </para>
    /// </param>
    public static ActionsBuilder SavingThrow(
        this ActionsBuilder builder,
        SavingThrowType type,
        List<(ConditionsBuilder conditions, ContextValue modifier)>? conditionalDCModifiers = null,
        ContextValue? customDC = null,
        bool? fromBuff = null,
        ActionsBuilder? onResult = null,
        bool? useDCFromContextSavingThrow = null)
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
        element.Actions = Utils.Constants.Empty.Actions;
      }
      element.UseDCFromContextSavingThrow = useDCFromContextSavingThrow ?? element.UseDCFromContextSavingThrow;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSelectByValue"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ElementalAssessor</term><description>6303b404df12b0f4793fa0763b21dd2c</description></item>
    /// <item><term>FrigidTouch</term><description>c83447189aabc72489164dfc246f3a36</description></item>
    /// <item><term>SiroccoArea</term><description>b21bc337e2beaa74b8823570cd45d6dd</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="actionVariants">
    /// <para>
    /// The action associated with the highest value is selected to run.
    /// </para>
    /// </param>
    public static ActionsBuilder SelectByValue(this ActionsBuilder builder, params (ContextValue value, ActionsBuilder action)[] actionVariants)
    {
      var element = ElementTool.Create<ContextActionSelectByValue>();
      element.m_Variants = actionVariants.Select(variant => new ContextActionSelectByValue.ValueAndAction { Value = variant.value, Action = variant.action.Build() }).ToArray();
      element.m_Type = ContextActionSelectByValue.SelectionType.Greatest;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSkillCheck"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcanistExploitIcyTombBuff</term><description>fb64c249d44317443bb1f2271ed963af</description></item>
    /// <item><term>MasterHealingTechniqueDireConditionsBuff</term><description>c6d46d67f5d5dab4c8565c602316974e</description></item>
    /// <item><term>TsunamiArea</term><description>800daf41c11463742ad24efd71ab1916</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder SkillCheck(
        this ActionsBuilder builder,
        StatType stat,
        ContextValue? customDC = null,
        List<(ConditionsBuilder condition, ContextValue value)>? dcModifiers = null,
        ActionsBuilder? failure = null,
        ActionsBuilder? success = null)
    {
      var element = ElementTool.Create<ContextActionSkillCheck>();
      element.Stat = stat;
      element.CustomDC = customDC ?? element.CustomDC;
      element.UseCustomDC = customDC is not null;
      if (element.CustomDC is null)
      {
        element.CustomDC = ContextValues.Constant(0);
      }
      element.m_ConditionalDCIncrease = dcModifiers?.Select(mod => new ContextActionSkillCheck.ConditionalDCIncrease { Condition = mod.condition.Build(), Value = mod.value })?.ToArray() ?? element.m_ConditionalDCIncrease;
      if (element.m_ConditionalDCIncrease is null)
      {
        element.m_ConditionalDCIncrease = new ContextActionSkillCheck.ConditionalDCIncrease[0];
      }
      element.Failure = failure?.Build() ?? element.Failure;
      if (element.Failure is null)
      {
        element.Failure = Utils.Constants.Empty.Actions;
      }
      element.Success = success?.Build() ?? element.Success;
      if (element.Success is null)
      {
        element.Success = Utils.Constants.Empty.Actions;
      }
      element.CalculateDCDifference = false;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSkillCheck"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcanistExploitIcyTombBuff</term><description>fb64c249d44317443bb1f2271ed963af</description></item>
    /// <item><term>MasterHealingTechniqueDireConditionsBuff</term><description>c6d46d67f5d5dab4c8565c602316974e</description></item>
    /// <item><term>TsunamiArea</term><description>800daf41c11463742ad24efd71ab1916</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder SkillCheckWithDegreesOfFailure(
        this ActionsBuilder builder,
        StatType stat,
        ContextValue? customDC = null,
        List<(ConditionsBuilder condition, ContextValue value)>? dcModifiers = null,
        ActionsBuilder? failure = null,
        ActionsBuilder? failureBy10orMore = null,
        ActionsBuilder? failureBy5to10 = null,
        ActionsBuilder? success = null)
    {
      var element = ElementTool.Create<ContextActionSkillCheck>();
      element.Stat = stat;
      element.CustomDC = customDC ?? element.CustomDC;
      element.UseCustomDC = customDC is not null;
      if (element.CustomDC is null)
      {
        element.CustomDC = ContextValues.Constant(0);
      }
      element.m_ConditionalDCIncrease = dcModifiers?.Select(mod => new ContextActionSkillCheck.ConditionalDCIncrease { Condition = mod.condition.Build(), Value = mod.value })?.ToArray() ?? element.m_ConditionalDCIncrease;
      if (element.m_ConditionalDCIncrease is null)
      {
        element.m_ConditionalDCIncrease = new ContextActionSkillCheck.ConditionalDCIncrease[0];
      }
      element.Failure = failure?.Build() ?? element.Failure;
      if (element.Failure is null)
      {
        element.Failure = Utils.Constants.Empty.Actions;
      }
      element.FailureDiffMoreOrEqual10 = failureBy10orMore?.Build() ?? element.FailureDiffMoreOrEqual10;
      if (element.FailureDiffMoreOrEqual10 is null)
      {
        element.FailureDiffMoreOrEqual10 = Utils.Constants.Empty.Actions;
      }
      element.FailureDiffMoreOrEqual5Less10 = failureBy5to10?.Build() ?? element.FailureDiffMoreOrEqual5Less10;
      if (element.FailureDiffMoreOrEqual5Less10 is null)
      {
        element.FailureDiffMoreOrEqual5Less10 = Utils.Constants.Empty.Actions;
      }
      element.Success = success?.Build() ?? element.Success;
      if (element.Success is null)
      {
        element.Success = Utils.Constants.Empty.Actions;
      }
      element.CalculateDCDifference = true;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSpawnAreaEffect"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidFog</term><description>dbf99b00cd35d0a4491c6cc9e771b487</description></item>
    /// <item><term>RainbowDomeElecticity</term><description>f8ba0223241905e40ba55f8d80c57987</description></item>
    /// <item><term>ZoneOfPredetermination</term><description>756f1d07f9ae29448888ecf016fa40a7</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="areaEffect">
    /// <para>
    /// Blueprint of type BlueprintAbilityAreaEffect. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder SpawnAreaEffect(
        this ActionsBuilder builder,
        Blueprint<BlueprintAbilityAreaEffectReference> areaEffect,
        ContextDurationValue durationValue,
        bool? onUnit = null)
    {
      var element = ElementTool.Create<ContextActionSpawnAreaEffect>();
      element.m_AreaEffect = areaEffect?.Reference;
      builder.Validate(durationValue);
      element.DurationValue = durationValue;
      element.OnUnit = onUnit ?? element.OnUnit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSpawnControllableProjectile"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BoneSpearDismemberBuff</term><description>06014e98a84795a49a790283ec2d2847</description></item>
    /// <item><term>KillAndSpawnControllableProjectileBuff</term><description>fca25a203061ff149a71966c61657535</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="associatedCasterBuff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="controllableProjectile">
    /// <para>
    /// Blueprint of type BlueprintControllableProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder SpawnControllableProjectile(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuffReference> associatedCasterBuff,
        Blueprint<BlueprintControllableProjectileReference> controllableProjectile)
    {
      var element = ElementTool.Create<ContextActionSpawnControllableProjectile>();
      element.AssociatedCasterBuff = associatedCasterBuff?.Reference;
      element.ControllableProjectile = controllableProjectile?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSpawnMonster"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbrogailSummonPersonalGuard</term><description>43ca50d925914df3b98d11a026ab076a</description></item>
    /// <item><term>MonsterTacticianSummonVd3</term><description>e13ba416a447d8e42a4af18ee2dfe2ee</description></item>
    /// <item><term>WrigglingManSummon</term><description>e3a62a210a59e3c44b153b79279884fb</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="monster">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder SpawnMonster(
        this ActionsBuilder builder,
        ContextDiceValue countValue,
        ContextDurationValue durationValue,
        Blueprint<BlueprintUnitReference> monster,
        ActionsBuilder? afterSpawn = null,
        bool? doNotLinkToCaster = null,
        bool? isDirectlyControllable = null,
        ContextValue? levelValue = null)
    {
      var element = ElementTool.Create<ContextActionSpawnMonster>();
      element.CountValue = countValue;
      builder.Validate(durationValue);
      element.DurationValue = durationValue;
      element.m_Blueprint = monster?.Reference;
      element.AfterSpawn = afterSpawn?.Build() ?? element.AfterSpawn;
      if (element.AfterSpawn is null)
      {
        element.AfterSpawn = Utils.Constants.Empty.Actions;
      }
      element.DoNotLinkToCaster = doNotLinkToCaster ?? element.DoNotLinkToCaster;
      element.IsDirectlyControllable = isDirectlyControllable ?? element.IsDirectlyControllable;
      element.LevelValue = levelValue ?? element.LevelValue;
      if (element.LevelValue is null)
      {
        element.LevelValue = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSpawnMonster"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbrogailSummonPersonalGuard</term><description>43ca50d925914df3b98d11a026ab076a</description></item>
    /// <item><term>MonsterTacticianSummonVd3</term><description>e13ba416a447d8e42a4af18ee2dfe2ee</description></item>
    /// <item><term>WrigglingManSummon</term><description>e3a62a210a59e3c44b153b79279884fb</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="monster">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="summonPool">
    /// <para>
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder SpawnMonsterUsingSummonPool(
        this ActionsBuilder builder,
        ContextDiceValue countValue,
        ContextDurationValue durationValue,
        Blueprint<BlueprintUnitReference> monster,
        Blueprint<BlueprintSummonPoolReference> summonPool,
        ActionsBuilder? afterSpawn = null,
        bool? doNotLinkToCaster = null,
        bool? isDirectlyControllable = null,
        ContextValue? levelValue = null,
        bool? useLimitFromSummonPool = null)
    {
      var element = ElementTool.Create<ContextActionSpawnMonster>();
      element.CountValue = countValue;
      builder.Validate(durationValue);
      element.DurationValue = durationValue;
      element.m_Blueprint = monster?.Reference;
      element.m_SummonPool = summonPool?.Reference;
      element.AfterSpawn = afterSpawn?.Build() ?? element.AfterSpawn;
      if (element.AfterSpawn is null)
      {
        element.AfterSpawn = Utils.Constants.Empty.Actions;
      }
      element.DoNotLinkToCaster = doNotLinkToCaster ?? element.DoNotLinkToCaster;
      element.IsDirectlyControllable = isDirectlyControllable ?? element.IsDirectlyControllable;
      element.LevelValue = levelValue ?? element.LevelValue;
      if (element.LevelValue is null)
      {
        element.LevelValue = ContextValues.Constant(0);
      }
      element.UseLimitFromSummonPool = useLimitFromSummonPool ?? element.UseLimitFromSummonPool;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSpawnUnlinkedMonster"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SoulsCloakCurseBuff</term><description>40f948d8e5ee2534eb3d701f256f96b5</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="monster">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder SpawnUnlinkedMonster(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnitReference> monster)
    {
      var element = ElementTool.Create<ContextActionSpawnUnlinkedMonster>();
      element.m_Blueprint = monster?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextSpendResource"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcanistArcaneReservoirResourceBuff</term><description>1dd776b7b27dcd54ab3cedbbaf440cf3</description></item>
    /// <item><term>PrismaticRingFeature</term><description>40365c7ca844d11459cd8be4c1ce7586</description></item>
    /// <item><term>TheUndyingLoveOfTheHopebringerShieldFeature</term><description>c03a1dd822ef4bac84fe76a986d1993d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="resource">
    /// <para>
    /// Blueprint of type BlueprintAbilityResource. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="value">
    /// <para>
    /// Amount to spend. If not specified the resource is fully spent.
    /// </para>
    /// </param>
    public static ActionsBuilder ContextSpendResource(
        this ActionsBuilder builder,
        Blueprint<BlueprintAbilityResourceReference> resource,
        ContextValue? value = null)
    {
      var element = ElementTool.Create<ContextSpendResource>();
      element.m_Resource = resource?.Reference;
      element.Value = value ?? element.Value;
      element.ContextValueSpendure = value is not null;
      if (element.Value is null)
      {
        element.Value = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionStealBuffs"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_ShadowBalorNahindry_Features</term><description>1af82391db22467580a54baaae3bc164</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="descriptor">
    /// <para>
    /// InfoBox: Target buff should have at least one of the descriptors to be stolen
    /// </para>
    /// </param>
    public static ActionsBuilder StealBuffs(
        this ActionsBuilder builder,
        SpellDescriptorWrapper descriptor)
    {
      var element = ElementTool.Create<ContextActionStealBuffs>();
      element.m_Descriptor = descriptor;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSwarmAttack"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BloodlineSerpentineDenOfSpidersSpiderSwarmDamageBuff</term><description>9c414efda39e67344846171c1547edc1</description></item>
    /// <item><term>MandragoraSwarmDamageBuff</term><description>0f4923163104a8748b88e91ec7e14837</description></item>
    /// <item><term>VescavorSwarmDamageBuff</term><description>ddc847a49246ded4f93fe2bf0e2a7dab</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder SwarmAttack(
        this ActionsBuilder builder,
        ActionsBuilder attackActions)
    {
      var element = ElementTool.Create<ContextActionSwarmAttack>();
      element.AttackActions = attackActions?.Build();
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwordlordAdaptiveTacticsAdd"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AdaptiveTactics</term><description>e01152417a8ac2248b4f69711b819441</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="source">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder SwordlordAdaptiveTacticsAdd(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnitFactReference> source)
    {
      var element = ElementTool.Create<SwordlordAdaptiveTacticsAdd>();
      element.m_Source = source?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="BuffActionAddStatBonus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbruptEndEnchantment</term><description>66f1ac1f205e99f4e83c9b3aa8f0b0b1</description></item>
    /// <item><term>DLC3_DivineNeutralBuff</term><description>16127cf3f8e7430780a36345ae76a56e</description></item>
    /// <item><term>TouchOfGracelessnessBuff</term><description>dc2fb898c3d07a546b31bd5d49ffadba</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CambionMinibossKineticist_Preheat</term><description>d01773433d2f44878d64aa8af0f031de</description></item>
    /// <item><term>ElementalBastionAbility</term><description>af6e27aa6e300454580d7de074ff315a</description></item>
    /// </list>
    /// </remarks>
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
    /// Adds <see cref="ContextActionBatteringBlast"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BatteringBlast</term><description>0a2f7c6aa81bc6548ac7780d8b70bcbc</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbyssalChainsBuff</term><description>32c0fa6d6b154f06bfdb50bd70096aa8</description></item>
    /// <item><term>PhantasmalWebGrappledBuff</term><description>bf6c03b98af9a374c8d61988b5f3ba96</description></item>
    /// <item><term>WebGrappled</term><description>a719abac0ea0ce346b401060754cc1c0</description></item>
    /// </list>
    /// </remarks>
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
        element.Failure = Utils.Constants.Empty.Actions;
      }
      element.Success = success?.Build() ?? element.Success;
      if (element.Success is null)
      {
        element.Success = Utils.Constants.Empty.Actions;
      }
      element.UseCMB = useCMB ?? element.UseCMB;
      element.UseCMD = useCMD ?? element.UseCMD;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionConditionalSaved"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1_FirstStage_AcidBuff</term><description>6afe27c9a2d64eb890673ff3649dacb3</description></item>
    /// <item><term>GiantSpiderPoisonFeature</term><description>094714bb08f4e1943a8e9d2384ebe573</description></item>
    /// <item><term>ZachariusParalyzingTouchAbility</term><description>dbd157bc98c11a341b3b605ad58d5a57</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder ConditionalSaved(
        this ActionsBuilder builder,
        ActionsBuilder? failed = null,
        ActionsBuilder? succeed = null)
    {
      var element = ElementTool.Create<ContextActionConditionalSaved>();
      element.Failed = failed?.Build() ?? element.Failed;
      if (element.Failed is null)
      {
        element.Failed = Utils.Constants.Empty.Actions;
      }
      element.Succeed = succeed?.Build() ?? element.Succeed;
      if (element.Succeed is null)
      {
        element.Succeed = Utils.Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionDealWeaponDamage"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AngelSwordOverwhelmingFlamesAbility</term><description>2b3166ffad7420f4fb02ed71660b2a8c</description></item>
    /// <item><term>MasteryDamageOnCombMan</term><description>e68766277fcd48846ba630b54fdafc9a</description></item>
    /// <item><term>WideSweepAbility</term><description>69811d984ba4ab8419873b09c1641e36</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="ignoreAttackRoll">
    /// <para>
    /// InfoBox: Check it if you want to avoid critical/sneak damage in this action
    /// </para>
    /// </param>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>RepurposeBuffUndead</term><description>5e18ce2e21330e34690c372fbd9d6d60</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder DetachFromSpawner(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDetachFromSpawner>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionDevourBySwarm"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SwarmDevourAbility</term><description>dabe876d25b785d4caa22b7a23b6fa67</description></item>
    /// <item><term>SwarmFeastEnemyBuff</term><description>edd6db0bfe1e0de4598f34909a4d7253</description></item>
    /// <item><term>SwarmProtectCorpseArea</term><description>4634d1da7c394ec4a49cb38e59e91f44</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder DevourBySwarm(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDevourBySwarm>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionDisarm"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_FAB_ShatterScream_Stage2</term><description>ca923546508b4c42a42e39dbdcbc14ed</description></item>
    /// <item><term>GelatinousDisarmFeature</term><description>4e83f1e0e52b4613982b14ee2796928f</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder Disarm(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDisarm>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionDismissAreaEffect"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DismissAreaEffect</term><description>97a23111df7547fd8f6417f9ba9b9775</description></item>
    /// <item><term>DismissInfusionAbility</term><description>feba4322f7614276a69efece6d5093c3</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder DismissAreaEffect(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDismissAreaEffect>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionDismount"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbilityDismount</term><description>1b2778c5f09ec124f891415e0e16b283</description></item>
    /// <item><term>ForceDismountBuff</term><description>45f5320d24e7456fa04871a0afa8ecbc</description></item>
    /// <item><term>MountedBuff</term><description>b2d13e8f3bb0f1d4c891d71b4d983cf7</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder Dismount(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDismount>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionDropItems"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_FAB_ShatterScream_Stage2</term><description>ca923546508b4c42a42e39dbdcbc14ed</description></item>
    /// <item><term>SecretOfSubduingProneBuff</term><description>a48d1cb1c286bf94bb34273c98419040</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder DropItems(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDropItems>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionGiveExperience"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SecretOfSubduing</term><description>51e2cae397618ec4bb8be9d28bbac70a</description></item>
    /// <item><term>SecretOfSubduingProneBuff</term><description>a48d1cb1c286bf94bb34273c98419040</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder GiveExperience(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionGiveExperience>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionHealBurn"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DarkElementalistSoulPowerAbility</term><description>31a1e5b27cdb78f4094630610519981c</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AngelfireApostleVersatileChannelRestoration</term><description>4a7976b5985fc0a4bb525f634b1538db</description></item>
    /// <item><term>RestorationGreater</term><description>fafd77c6bfa85c04ba31fdc1c962c914</description></item>
    /// <item><term>WilasGundersonBlessing_Cutscene</term><description>3317c942ca6d8be4fb7139f8b9750085</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AssassinHideInPlainSightAbility</term><description>b3a91afd21cfa39468e04a58a3834ac0</description></item>
    /// <item><term>ForesterCamouflageAbility</term><description>5fb85744155126d4fb2b01767705c24c</description></item>
    /// <item><term>SlayerCamouflageAbility</term><description>0d9e2a7b692c8e74d8e9779160d58047</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder HideInPlainSight(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionHideInPlainSight>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionIncreaseSwarmThatWalksStrength"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SwarmDLC1StartBuff</term><description>b1cbd85ed89e4b85899fc41c2487e5b7</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder IncreaseSwarmThatWalksStrength(
        this ActionsBuilder builder,
        ContextValue? swarmStartStrength = null)
    {
      var element = ElementTool.Create<ContextActionIncreaseSwarmThatWalksStrength>();
      element.SwarmStartStrength = swarmStartStrength ?? element.SwarmStartStrength;
      if (element.SwarmStartStrength is null)
      {
        element.SwarmStartStrength = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionKill"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbsoluteDeath</term><description>7d721be6d74f07f4d952ee8d6f8f44a0</description></item>
    /// <item><term>ImpalerEnchantment</term><description>a70838190b8751e4c93f5c410d8ca356</description></item>
    /// <item><term>WordOfChaos</term><description>69f2e7aff2d1cd148b8075ee476515b1</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BatteringBlast</term><description>0a2f7c6aa81bc6548ac7780d8b70bcbc</description></item>
    /// <item><term>DLC3_SplintershredGreataxeAbility</term><description>8178f4bc2cc2436aaecb52f5500f4b2e</description></item>
    /// <item><term>WaterTorrent</term><description>cd7b6981218a0274c916db0a2fc29855</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder KnockdownTarget(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionKnockdownTarget>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionMakeKnowledgeCheck"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>StudentOfWarKnowFastYourEnemyAbility</term><description>0190e1225d974ad4affccae4bf19fc66</description></item>
    /// <item><term>StudentOfWarKnowYourEnemyAbility</term><description>4c056d3a0d3c4414399d1476c4142edb</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder MakeKnowledgeCheck(
        this ActionsBuilder builder,
        ActionsBuilder? failActions = null,
        ActionsBuilder? successActions = null)
    {
      var element = ElementTool.Create<ContextActionMakeKnowledgeCheck>();
      element.FailActions = failActions?.Build() ?? element.FailActions;
      if (element.FailActions is null)
      {
        element.FailActions = Utils.Constants.Empty.Actions;
      }
      element.SuccessActions = successActions?.Build() ?? element.SuccessActions;
      if (element.SuccessActions is null)
      {
        element.SuccessActions = Utils.Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionMarkForceDismemberOwner"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/Mark Force Dismember
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BloodBoilerEnchantment</term><description>7d26d85337ee5d145ad563b7b83ca54d</description></item>
    /// <item><term>BoneSpearDismemberBuff</term><description>06014e98a84795a49a790283ec2d2847</description></item>
    /// <item><term>KillAndSpawnControllableProjectileBuff</term><description>fca25a203061ff149a71966c61657535</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyMeleeCounterAttackFeature</term><description>9f86b8f30438920458feda7313591ec2</description></item>
    /// <item><term>BladeWhirlwindAbility</term><description>80f10dc9181a0f64f97a9f7ac9f47d65</description></item>
    /// <item><term>SwordlordDisarmingStrike</term><description>c7ea46f5e1822994ba069c11819844ae</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbilityMount</term><description>6101a05a025278e43988ac303e9eb122</description></item>
    /// <item><term>MountTargetAbility</term><description>9f8c0f4fcabdb3145b449826d17da18d</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder Mount(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionMount>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionOnTargetPoint"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonAreaEffectsGazeAllyBuff</term><description>5f628dc321f74a6bbadec25f665a402d</description></item>
    /// <item><term>Valmallos_Buff_AeonGazeAlly</term><description>67e8a3dd2d6a47a2bcf20e059a01fc72</description></item>
    /// <item><term>Valmallos_Buff_AeonGazeAlly_Core</term><description>8c43b0cd1ba54777b2eecb0c16caf5cf</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder OnTargetPoint(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null)
    {
      var element = ElementTool.Create<ContextActionOnTargetPoint>();
      element.Actions = actions?.Build() ?? element.Actions;
      if (element.Actions is null)
      {
        element.Actions = Utils.Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionProvokeAttackFromCaster"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_FAB_ShatterScream_Stage2</term><description>ca923546508b4c42a42e39dbdcbc14ed</description></item>
    /// <item><term>SwordlordCounterattack</term><description>ff125ecc8b2c1894b879b7bcf34e1b17</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder ProvokeAttackFromCaster(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionProvokeAttackFromCaster>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionProvokeAttackOfOpportunity"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CoupDeGraceAbility</term><description>32280b137ca642c45be17e2d92898758</description></item>
    /// <item><term>CureCriticalWoundsPretendPotion</term><description>0e41945b6701d7643b4f19c145d7d9e1</description></item>
    /// <item><term>WarpriestFervorPositiveAbility</term><description>051eaf10f7fe97f49aaf87bdc68580bd</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BladeBarrierArea</term><description>cae4347a512809e4388fb3949dc0bc67</description></item>
    /// <item><term>Marilith_Feature_CrushingTail</term><description>c4feadd14be24254386fa8ff836d5f0d</description></item>
    /// <item><term>WindsOfVengeanceBuff</term><description>796a2fe600e5ead41b29cd9963cf2de9</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyRangedCounterAttackFeature</term><description>4d59f676f59579944948f8c461731ab8</description></item>
    /// <item><term>BackrankAssistanceEnemyBuff</term><description>63e80c5f1e57a504496d6ec7c0f8acbd</description></item>
    /// <item><term>DLC3_EvercoldHeavyCrossbowEnchantment</term><description>7eea1f49ab5648e2a4433debe95341be</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FightDefensivelyFeature</term><description>ca22afeb94442b64fb8536e7a9f7dc11</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>RestorationGreater</term><description>fafd77c6bfa85c04ba31fdc1c962c914</description></item>
    /// <item><term>Revival</term><description>3007b582267846e9a66718459f62a0c3</description></item>
    /// <item><term>WilasGundersonBlessing_Cutscene</term><description>3317c942ca6d8be4fb7139f8b9750085</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder RemoveDeathDoor(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionRemoveDeathDoor>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionRemoveSelf"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbruptForceBuff</term><description>4cf7aa3c1b2e2354b877135e4b4f32b2</description></item>
    /// <item><term>HellsDecreeAbilityMagicEvocationBuff</term><description>ea03cb0438d8ce049a6dbf1e89d9f911</description></item>
    /// <item><term>ZeorisDaggerRing_BetrayalEnemyFeature</term><description>1a695b8dfffc46f7a74527e510fd452b</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder RemoveSelf(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionRemoveSelf>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionResetAlignment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Atonement</term><description>febb7ccf00cf713428032b11a3b44158</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="resetAlignmentLock">
    /// <para>
    /// InfoBox: If true also removes lock from mythic restriction
    /// </para>
    /// </param>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>HeroNeverSurrender</term><description>a6a86db75c6af6d41aa480f05adae693</description></item>
    /// <item><term>JoyOfLife</term><description>50497d3b8d0b40e4682fd643f5080f45</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="excludeSpellbooks">
    /// <para>
    /// Blueprint of type BlueprintSpellbook. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder RestoreAllSpellSlots(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintSpellbookReference>>? excludeSpellbooks = null,
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
    /// Adds <see cref="ContextActionSwallowWhole"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GelatinousSwallowWholeFeature</term><description>e3e173c63a024e0e8bcaf79a6fa9729d</description></item>
    /// <item><term>NightcrawlerFeature</term><description>b43d334a926e4375bb45b7def885d693</description></item>
    /// <item><term>PurpleWormSwallowWholeFeature</term><description>dee864aec4a0d344b913dd27a4b504cb</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="targetBuff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder SwallowWhole(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuffReference>? targetBuff = null)
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
    /// Adds <see cref="ContextActionSwarmTarget"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BloodlineSerpentineDenOfSpidersSpiderSwarmDamageEffectBuff</term><description>cbdbf81a41b8a824d8a738e3bfc9cae2</description></item>
    /// <item><term>LocustSwarmDamageEffectBuff</term><description>8f9cdbc4194eaa643869d7c59763e569</description></item>
    /// <item><term>VescavorSwarmDamageEffectBuff</term><description>3736187b9dde93746a048892c88f9c4e</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder SwarmTarget(
        this ActionsBuilder builder,
        bool? remove = null)
    {
      var element = ElementTool.Create<ContextActionSwarmTarget>();
      element.Remove = remove ?? element.Remove;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionUnsummon"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Artifact_HornsOfNaragaUnsummonBuff</term><description>bf24f9a2ae9047029f53ef8c797c50cf</description></item>
    /// <item><term>DemonicHungerUnsummonBuff</term><description>ebf8d1a86bbf0984baec6cae7cbbe262</description></item>
    /// <item><term>RangedLegerdemainUntargetable</term><description>5f632e786b68d8d4c8bb66275fc600a7</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder Unsummon(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionUnsummon>());
    }

    /// <summary>
    /// Adds <see cref="SwordlordAdaptiveTacticsClear"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AdaptiveTactics</term><description>e01152417a8ac2248b4f69711b819441</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder SwordlordAdaptiveTacticsClear(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<SwordlordAdaptiveTacticsClear>());
    }
  }
}
