//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Designers;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Designers.EventConditionActionSystem.NamedParameters;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Conditions.Builder.BasicEx
{
  /// <summary>
  /// Extension to <see cref="ConditionsBuilder"/> for most game mechanics related conditions not included in <see cref="ContextEx.ConditionsBuilderContextEx">ContextEx</see>.
  /// </summary>
  /// <inheritdoc cref="ConditionsBuilder"/>
  public static class ConditionsBuilderBasicEx
  {

    /// <summary>
    /// Adds <see cref="BuffConditionCheckRoundNumber"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ResonatingWordBuff</term><description>45dadc2e291367b45b1110d3be039cad</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder BuffConditionCheckRoundNumber(
        this ConditionsBuilder builder,
        bool negate = false,
        int? roundNumber = null)
    {
      var element = ElementTool.Create<BuffConditionCheckRoundNumber>();
      element.Not = negate;
      element.RoundNumber = roundNumber ?? element.RoundNumber;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CheckConditionsHolder"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0058</term><description>70feca2bda2039f4fa472f0f4d09edde</description></item>
    /// <item><term>Slot_3_3_ItemRestriction</term><description>4f0361cf4f7412d49b0aef6b8061c8a8</description></item>
    /// <item><term>Slot_7_5_ItemRestriction</term><description>b9e743b4c4b467a409a37905af58ce4b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="conditionsHolder">
    /// <para>
    /// Blueprint of type ConditionsHolder. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder CheckConditionsHolder(
        this ConditionsBuilder builder,
        Blueprint<ConditionsReference>? conditionsHolder = null,
        bool negate = false,
        ParametrizedContextSetter? parameters = null)
    {
      var element = ElementTool.Create<CheckConditionsHolder>();
      element.ConditionsHolder = conditionsHolder?.Reference ?? element.ConditionsHolder;
      if (element.ConditionsHolder is null)
      {
        element.ConditionsHolder = BlueprintTool.GetRef<ConditionsReference>(null);
      }
      element.Not = negate;
      builder.Validate(parameters);
      element.Parameters = parameters ?? element.Parameters;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CheckItemCondition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AreshkagalDungeon_Arena</term><description>67fb6b5c69c149ecb2aed1b38d299fb7</description></item>
    /// <item><term>Cue_0214</term><description>165086c84dfc4c14ca9e9583f7b17adb</description></item>
    /// <item><term>Cue_0221</term><description>36d7a9a7d4e40684ea6ac72668fb8e36</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="targetItem">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="unitEvaluator">
    /// <para>
    /// InfoBox: If empty - check all units in party
    /// </para>
    /// </param>
    public static ConditionsBuilder CheckItemCondition(
        this ConditionsBuilder builder,
        bool negate = false,
        CheckItemCondition.RequiredState? requiredState = null,
        Blueprint<BlueprintItemReference>? targetItem = null,
        UnitEvaluator? unitEvaluator = null)
    {
      var element = ElementTool.Create<CheckItemCondition>();
      element.Not = negate;
      element.m_RequiredState = requiredState ?? element.m_RequiredState;
      element.m_TargetItem = targetItem?.Reference ?? element.m_TargetItem;
      if (element.m_TargetItem is null)
      {
        element.m_TargetItem = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      builder.Validate(unitEvaluator);
      element.m_UnitEvaluator = unitEvaluator ?? element.m_UnitEvaluator;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CompanionInParty"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Condition/CompanionInParty
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Alushinyrra_HigherCity_VellodusMansion</term><description>d062cf7333b145b8bb85d4400dbea44d</description></item>
    /// <item><term>Cue_0027</term><description>d840080822d64e14fac385010630d8c3</description></item>
    /// <item><term>Yozz_GreyborQ2Bark_Conditions</term><description>e25cbb4124873114ba3b75176e004517</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="companion">
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
    public static ConditionsBuilder CompanionInParty(
        this ConditionsBuilder builder,
        Blueprint<BlueprintUnitReference>? companion = null,
        bool? matchWhenActive = null,
        bool? matchWhenDead = null,
        bool? matchWhenDetached = null,
        bool? matchWhenEx = null,
        bool? matchWhenRemote = null,
        bool negate = false)
    {
      var element = ElementTool.Create<CompanionInParty>();
      element.m_companion = companion?.Reference ?? element.m_companion;
      if (element.m_companion is null)
      {
        element.m_companion = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      element.MatchWhenActive = matchWhenActive ?? element.MatchWhenActive;
      element.MatchWhenDead = matchWhenDead ?? element.MatchWhenDead;
      element.MatchWhenDetached = matchWhenDetached ?? element.MatchWhenDetached;
      element.MatchWhenEx = matchWhenEx ?? element.MatchWhenEx;
      element.MatchWhenRemote = matchWhenRemote ?? element.MatchWhenRemote;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CompanionIsDead"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Condition/CompanionIsDead
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0015</term><description>72050eac97c4b944f9a99ce16a680f16</description></item>
    /// <item><term>DLC6_GreyborDiedOutsideKenabres</term><description>fff61aabdc5f4e28ab2e5b1e7abaaeca</description></item>
    /// <item><term>UlbrigNotInParty_Dead</term><description>4863a2dfe7f847e588df50710ebf2a3f</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="companion">
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
    public static ConditionsBuilder CompanionIsDead(
        this ConditionsBuilder builder,
        bool? anyCompanion = null,
        Blueprint<BlueprintUnitReference>? companion = null,
        bool? includeRemote = null,
        bool negate = false)
    {
      var element = ElementTool.Create<CompanionIsDead>();
      element.anyCompanion = anyCompanion ?? element.anyCompanion;
      element.m_companion = companion?.Reference ?? element.m_companion;
      if (element.m_companion is null)
      {
        element.m_companion = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      element.includeRemote = includeRemote ?? element.includeRemote;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CompanionIsLost"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Condition/CompanionIsLost
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Sosiel_Q2_KTC</term><description>4ff659434ee301e4d99cad924df322fe</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="companion">
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
    public static ConditionsBuilder CompanionIsLost(
        this ConditionsBuilder builder,
        Blueprint<BlueprintUnitReference>? companion = null,
        bool negate = false)
    {
      var element = ElementTool.Create<CompanionIsLost>();
      element.m_Companion = companion?.Reference ?? element.m_Companion;
      if (element.m_Companion is null)
      {
        element.m_Companion = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HasBuff"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Condition/HasBuff
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>2Wave</term><description>4e1dcba08c1e4a89aea4aaa07f8f89ae</description></item>
    /// <item><term>DLC3_GiantHeart_SZ</term><description>1108e32529a04a5abe2f6820f3518a6c</description></item>
    /// <item><term>WhispersOfMadnessAttach</term><description>72d6ba35e78ff9e4f8e59ef16f192c60</description></item>
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
    public static ConditionsBuilder HasBuff(
        this ConditionsBuilder builder,
        Blueprint<BlueprintBuffReference>? buff = null,
        bool negate = false,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<HasBuff>();
      element.m_Buff = buff?.Reference ?? element.m_Buff;
      if (element.m_Buff is null)
      {
        element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      element.Not = negate;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HasFact"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AmuletOfUnforgivingElementsFeature</term><description>2cc9b7e8d7117a9458285333822bf95d</description></item>
    /// <item><term>Cue_0009</term><description>e5573f05bf6c4d678fbbbabb5e3cd61f</description></item>
    /// <item><term>UncotrollableRageBuff</term><description>06bf19096c1f4d9c9252cf60a08e0e2c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="fact">
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
    public static ConditionsBuilder HasFact(
        this ConditionsBuilder builder,
        Blueprint<BlueprintUnitFactReference>? fact = null,
        bool negate = false,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<HasFact>();
      element.m_Fact = fact?.Reference ?? element.m_Fact;
      if (element.m_Fact is null)
      {
        element.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      element.Not = negate;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsEnemy"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>5d0de4fd6d752294e932745a29b0a4d9</description></item>
    /// <item><term>ShowPartySelection</term><description>cb81a7635afad1e4a9fb3a5dae1b0bb3</description></item>
    /// <item><term>Unused_SZ_1</term><description>204c7132bafa41c993ffdb9ae675d5eb</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder IsEnemy(
        this ConditionsBuilder builder,
        UnitEvaluator? firstUnit = null,
        bool negate = false,
        UnitEvaluator? secondUnit = null)
    {
      var element = ElementTool.Create<IsEnemy>();
      builder.Validate(firstUnit);
      element.FirstUnit = firstUnit ?? element.FirstUnit;
      element.Not = negate;
      builder.Validate(secondUnit);
      element.SecondUnit = secondUnit ?? element.SecondUnit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsEqual"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Condition/IsEqual
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AirBlastAbility</term><description>31f668b12011e344aa542aa07ab6c8d9</description></item>
    /// <item><term>ExtendedRangeWaterBlastAbility</term><description>11eba1184c7108846a665d8ca317963f</description></item>
    /// <item><term>XO_Puzzle_2_complete</term><description>8288ad6ec196461f963d6160edbfaca4</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder IsEqual(
        this ConditionsBuilder builder,
        IntEvaluator? firstValue = null,
        bool negate = false,
        IntEvaluator? secondValue = null)
    {
      var element = ElementTool.Create<IsEqual>();
      builder.Validate(firstValue);
      element.FirstValue = firstValue ?? element.FirstValue;
      element.Not = negate;
      builder.Validate(secondValue);
      element.SecondValue = secondValue ?? element.SecondValue;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsInCombat"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AneviaDialog</term><description>85d9ab0f99b3f914bb10671c9c63f6a3</description></item>
    /// <item><term>Graveyard_1AreaExitSP</term><description>42206503306d47b78576856f49dd1b48</description></item>
    /// <item><term>WP_1_ScriptZone</term><description>0613d54edb72463e8bcada03f359bf91</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder IsInCombat(
        this ConditionsBuilder builder,
        bool negate = false,
        bool? player = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<IsInCombat>();
      element.Not = negate;
      element.Player = player ?? element.Player;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsInTurnBasedCombat"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandDelay1</term><description>b9a2d53aef964891afbda0ce61f177ac</description></item>
    /// <item><term>Tutor_TBM_DH_Buff</term><description>8827906427fe4a5da2c33e8d67d57a23</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder IsInTurnBasedCombat(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<IsInTurnBasedCombat>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsPartyMember"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AneviaStart</term><description>e537a72ee38591847ad2f231ab1a1f9e</description></item>
    /// <item><term>GargoyleSpawn00</term><description>dabb8e29ce4288d4fadd1f1a0af2c02c</description></item>
    /// <item><term>YakerDialogue</term><description>c0b7b22035f586d48b0f32bd094473d6</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder IsPartyMember(
        this ConditionsBuilder builder,
        bool negate = false,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<IsPartyMember>();
      element.Not = negate;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsUnconscious"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandUnitLookAt</term><description>0a467c59d8cf78b4c911aeb922b54ef1</description></item>
    /// <item><term>Cue_0002</term><description>7abec2ad3309e6241a77216ee24925b6</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder IsUnconscious(
        this ConditionsBuilder builder,
        bool negate = false,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<IsUnconscious>();
      element.Not = negate;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsUnitLevelLessThan"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandUnitCastSpell1</term><description>e434cffdc4d847089f84b666dce699a8</description></item>
    /// <item><term>CommandUnitCastSpell3</term><description>c7cbbb646d6a4e78ac0acbcf8413a89e</description></item>
    /// <item><term>SoulsCloakCurseBuff</term><description>40f948d8e5ee2534eb3d701f256f96b5</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder IsUnitLevelLessThan(
        this ConditionsBuilder builder,
        bool? checkExperience = null,
        int? level = null,
        bool negate = false,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<IsUnitLevelLessThan>();
      element.CheckExperience = checkExperience ?? element.CheckExperience;
      element.Level = level ?? element.Level;
      element.Not = negate;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsUnitMythicExperience"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC1_Levelup</term><description>dca1299c933b43dd8078cdf078ee6121</description></item>
    /// <item><term>MythicLevel</term><description>dc66b7adec0e41c2b948b4bc9c31ec99</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder IsUnitMythicExperience(
        this ConditionsBuilder builder,
        bool? checkMaxLevel = null,
        bool? checkMinLevel = null,
        IntEvaluator? maxLevel = null,
        IntEvaluator? minLevel = null,
        bool negate = false,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<IsUnitMythicExperience>();
      element.CheckMaxLevel = checkMaxLevel ?? element.CheckMaxLevel;
      element.CheckMinLevel = checkMinLevel ?? element.CheckMinLevel;
      builder.Validate(maxLevel);
      element.MaxLevel = maxLevel ?? element.MaxLevel;
      builder.Validate(minLevel);
      element.MinLevel = minLevel ?? element.MinLevel;
      element.Not = negate;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsUnitMythicLevel"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0014</term><description>e150a8363c8e4723a0fbb0f5de6d931a</description></item>
    /// <item><term>EveryoneIsMortal</term><description>11dbdcadc7d74dc09e70ef386931a14f</description></item>
    /// <item><term>SwarmThatWalksClass</term><description>5295b8e13c2303f4c88bdb3d7760a757</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder IsUnitMythicLevel(
        this ConditionsBuilder builder,
        bool? checkMaxLevel = null,
        bool? checkMinLevel = null,
        IntEvaluator? maxLevel = null,
        IntEvaluator? minLevel = null,
        bool negate = false,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<IsUnitMythicLevel>();
      element.CheckMaxLevel = checkMaxLevel ?? element.CheckMaxLevel;
      element.CheckMinLevel = checkMinLevel ?? element.CheckMinLevel;
      builder.Validate(maxLevel);
      element.MaxLevel = maxLevel ?? element.MaxLevel;
      builder.Validate(minLevel);
      element.MinLevel = minLevel ?? element.MinLevel;
      element.Not = negate;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ItemBlueprint"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Bowl_ItemRestriction</term><description>10283016767d4ed3b36db71bea8c450d</description></item>
    /// <item><term>Purple_Slot_1_3_Art_1_2f</term><description>4d8f9308cb80ab3488acb8ed79eda4ed</description></item>
    /// <item><term>YellowPuzzleSolveChecker</term><description>00016e6128651a548b2c50f23456a3e0</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="blueprint">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder ItemBlueprint(
        this ConditionsBuilder builder,
        Blueprint<BlueprintItemReference>? blueprint = null,
        ItemEvaluator? item = null,
        bool negate = false)
    {
      var element = ElementTool.Create<ItemBlueprint>();
      element.Blueprint = blueprint?.Reference ?? element.Blueprint;
      if (element.Blueprint is null)
      {
        element.Blueprint = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      builder.Validate(item);
      element.Item = item ?? element.Item;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ItemFromCollectionCondition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Darkness_AlushinyrraHub</term><description>cbd58d1c17f043618053e6633e70b4df</description></item>
    /// <item><term>DungeonLootMagic</term><description>24e7b8fe37484e06bc88738c9f032da2</description></item>
    /// <item><term>Mimic_Items_Books</term><description>1edfca79fc5347f6a76dd105879a7fe9</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder ItemFromCollectionCondition(
        this ConditionsBuilder builder,
        bool? any = null,
        ConditionsBuilder? condition = null,
        ItemsCollectionEvaluator? items = null,
        bool negate = false)
    {
      var element = ElementTool.Create<ItemFromCollectionCondition>();
      element.Any = any ?? element.Any;
      element.Condition = condition?.Build() ?? element.Condition;
      if (element.Condition is null)
      {
        element.Condition = Utils.Constants.Empty.Conditions;
      }
      builder.Validate(items);
      element.Items = items ?? element.Items;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ItemsEnough"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Condition/ItemsEnough
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidButton1_CheckPassedActions</term><description>2a969038211346358597f80d271d9b94</description></item>
    /// <item><term>BookOfDreams2ChapterBuff</term><description>1b0fbef2b200476c877bb73749691e69</description></item>
    /// <item><term>ZeorisDagger_ReforgeProject</term><description>22e8219563e84f11b6aed62661030770</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="ignoreRemoteCompanions">
    /// <para>
    /// InfoBox: Check item `equipped` state and don&amp;apos;t count items equipped on remote companions
    /// </para>
    /// </param>
    /// <param name="itemToCheck">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="quantity">
    /// <para>
    /// InfoBox: Quantity = 0, will return true always
    /// </para>
    /// </param>
    public static ConditionsBuilder ItemsEnough(
        this ConditionsBuilder builder,
        bool? checkBesmaritesChests = null,
        bool? checkInPlayerHubChest = null,
        bool? checkMemoriesChests = null,
        bool? ignoreRemoteCompanions = null,
        Blueprint<BlueprintItemReference>? itemToCheck = null,
        bool? money = null,
        bool negate = false,
        int? quantity = null)
    {
      var element = ElementTool.Create<ItemsEnough>();
      element.CheckBesmaritesChests = checkBesmaritesChests ?? element.CheckBesmaritesChests;
      element.CheckInPlayerHubChest = checkInPlayerHubChest ?? element.CheckInPlayerHubChest;
      element.CheckMemoriesChests = checkMemoriesChests ?? element.CheckMemoriesChests;
      element.IgnoreRemoteCompanions = ignoreRemoteCompanions ?? element.IgnoreRemoteCompanions;
      element.m_ItemToCheck = itemToCheck?.Reference ?? element.m_ItemToCheck;
      if (element.m_ItemToCheck is null)
      {
        element.m_ItemToCheck = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      element.Money = money ?? element.Money;
      element.Not = negate;
      element.Quantity = quantity ?? element.Quantity;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PartyCanUseAbility"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0003</term><description>5939379b7bd42484da6ba4aeb42e47f4</description></item>
    /// <item><term>Answer_0007</term><description>67824493fd984374d8b283a57a859a55</description></item>
    /// <item><term>CommandUnitCastSpell</term><description>6de48df0278243acaaffcc635326001b</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder PartyCanUseAbility(
        this ConditionsBuilder builder,
        bool? allowItems = null,
        AbilitiesHelper.AbilityDescription? description = null,
        bool negate = false)
    {
      var element = ElementTool.Create<PartyCanUseAbility>();
      element.AllowItems = allowItems ?? element.AllowItems;
      builder.Validate(description);
      element.Description = description ?? element.Description;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PartyUnits"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Condition/PartyUnits
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BossCastSpell_zone</term><description>5efbf1ebdf0387041b437ba46fc2773c</description></item>
    /// <item><term>Leaver_D4</term><description>bb1882474ed5493cb1c7b8aa8209d006</description></item>
    /// <item><term>WatchPoint_SZWall_FoW</term><description>0f1fdc5a42ea41a4b87da4021e89dabd</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder PartyUnits(
        this ConditionsBuilder builder,
        bool? any = null,
        ConditionsBuilder? conditions = null,
        bool negate = false)
    {
      var element = ElementTool.Create<PartyUnits>();
      element.Any = any ?? element.Any;
      element.Conditions = conditions?.Build() ?? element.Conditions;
      if (element.Conditions is null)
      {
        element.Conditions = Utils.Constants.Empty.Conditions;
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PcFemale"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0015</term><description>dd120d8b8a1b2974f97f3d1a866e7ae4</description></item>
    /// <item><term>Cue_0011</term><description>54040c1da639468eaaca394098ae341f</description></item>
    /// <item><term>WorldwoundEdge_GMBE</term><description>c68fad6a2d296f54f825eb1557153923</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder PcFemale(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<PcFemale>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PcMale"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0029</term><description>c4d69d3fb9060c14497b2123fc408845</description></item>
    /// <item><term>CommandAction</term><description>e13b97f1aad64f599a2d4d3f1b537714</description></item>
    /// <item><term>Cue_0234</term><description>7364becdf5cc4b94dba30a9fe7c3b790</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder PcMale(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<PcMale>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PcRace"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0005</term><description>f2c31b4d7efe2fd49a391e65f44d8b6e</description></item>
    /// <item><term>Cue_0033</term><description>bfab14e84cdc6b04ca914029e263cdf6</description></item>
    /// <item><term>WarCamp_TheatreFirstVisit</term><description>f546a7d95bfda0e4f9cb798f00b69db3</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder PcRace(
        this ConditionsBuilder builder,
        bool negate = false,
        Race? race = null)
    {
      var element = ElementTool.Create<PcRace>();
      element.Not = negate;
      element.Race = race ?? element.Race;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SummonPoolCount"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>07930ce9ce7a4211a6e0aacfa91c3585</description></item>
    /// <item><term>DLC5_PrisonersBarks_Actions</term><description>da00c07cd04b457997b687b0c3141c63</description></item>
    /// <item><term>PF-487847</term><description>685b8dc82e8b4131b3155baa846ffe8f</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="summonPoll">
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
    public static ConditionsBuilder SummonPoolCount(
        this ConditionsBuilder builder,
        bool? aliveOnly = null,
        int? count = null,
        bool negate = false,
        SummonPoolCount.Operation? operation = null,
        Blueprint<BlueprintSummonPoolReference>? summonPoll = null)
    {
      var element = ElementTool.Create<SummonPoolCount>();
      element.m_AliveOnly = aliveOnly ?? element.m_AliveOnly;
      element.m_Count = count ?? element.m_Count;
      element.Not = negate;
      element.m_Operation = operation ?? element.m_Operation;
      element.m_SummonPoll = summonPoll?.Reference ?? element.m_SummonPoll;
      if (element.m_SummonPoll is null)
      {
        element.m_SummonPoll = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SummonPoolExistsAndEmpty"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Cue_0017</term><description>4565910d19f940688a09c3e50a48f3b2</description></item>
    /// <item><term>Graveyard_HillSkipped</term><description>d36afdd4f689406ebdc2593b066fb129</description></item>
    /// <item><term>XCOM_Triggers</term><description>d10e9d61d16925845be53a113cc7db44</description></item>
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
    public static ConditionsBuilder SummonPoolExistsAndEmpty(
        this ConditionsBuilder builder,
        bool negate = false,
        Blueprint<BlueprintSummonPoolReference>? summonPool = null)
    {
      var element = ElementTool.Create<SummonPoolExistsAndEmpty>();
      element.Not = negate;
      element.m_SummonPool = summonPool?.Reference ?? element.m_SummonPool;
      if (element.m_SummonPool is null)
      {
        element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitArmor"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmorFocusHeavyMythicFeatureOffenceBuff</term><description>fcd913568e1544108eceb8db2a90cd0f</description></item>
    /// <item><term>ArmorFocusMediumMythicFeatureOffenceBuff</term><description>a9446282d567471496566a3b464559dc</description></item>
    /// <item><term>DLC3_VeryHotIslandMod</term><description>a9352268e6a74a9fb7db6defb71cc55a</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder UnitArmor(
        this ConditionsBuilder builder,
        ArmorProficiencyGroup[]? excludeArmorCategories = null,
        ArmorProficiencyGroup[]? includeArmorCategories = null,
        bool negate = false,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<UnitArmor>();
      element.ExcludeArmorCategories = excludeArmorCategories ?? element.ExcludeArmorCategories;
      if (element.ExcludeArmorCategories is null)
      {
        element.ExcludeArmorCategories = new ArmorProficiencyGroup[0];
      }
      element.IncludeArmorCategories = includeArmorCategories ?? element.IncludeArmorCategories;
      if (element.IncludeArmorCategories is null)
      {
        element.IncludeArmorCategories = new ArmorProficiencyGroup[0];
      }
      element.Not = negate;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitIsDead"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Condition/UnitIsDead
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AasimarGirlSlave_Actions</term><description>4c1760ddc1a183b4f94ee50cc47f4c37</description></item>
    /// <item><term>CommandMoveUnit2</term><description>961fbe025c684333982aba87a9fa2a1f</description></item>
    /// <item><term>WenduTraitor_DrezensStreet</term><description>aaa0452f52514e46bbc9a52fa95f467b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="target">
    /// <para>
    /// InfoBox: This condition may fail if the unit has died and was later destroyed. Consider using SpawnerUnitIsDead or a Summon Pool.
    /// </para>
    /// </param>
    public static ConditionsBuilder UnitIsDead(
        this ConditionsBuilder builder,
        bool negate = false,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<UnitIsDead>();
      element.Not = negate;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitIsHidden"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0017</term><description>e5bf1752b172c084f8b70351d9037e1d</description></item>
    /// <item><term>CommandMoveUnit9</term><description>6c3bc83b962c4c3d93bfa51b98ff17d1</description></item>
    /// <item><term>XCOM_StartCutscene</term><description>94342ced3cb04f96bc1f7c2914ee99f4</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder UnitIsHidden(
        this ConditionsBuilder builder,
        bool negate = false,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<UnitIsHidden>();
      element.Not = negate;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitBlueprint"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Condition/UnitBlueprint
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0023</term><description>7b20b077ed8be9842a561843f40fa0c9</description></item>
    /// <item><term>Cue_0126</term><description>7dcd9dc63ea06594294d9961f13272a9</description></item>
    /// <item><term>Muse_Abad_info_cutscene</term><description>098c81e45ba142f9a761d6c2ff02507e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="blueprint">
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
    public static ConditionsBuilder UnitBlueprint(
        this ConditionsBuilder builder,
        Blueprint<BlueprintUnitReference>? blueprint = null,
        bool negate = false,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<UnitBlueprint>();
      element.m_Blueprint = blueprint?.Reference ?? element.m_Blueprint;
      if (element.m_Blueprint is null)
      {
        element.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      element.Not = negate;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitClass"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonMythicClass</term><description>15a85e67b7d69554cab9ed5830d0268e</description></item>
    /// <item><term>Cue_0016</term><description>3443b336153f4377a199216f7d211d72</description></item>
    /// <item><term>TrueRazmirLoser_dialogue</term><description>a8c8f86b2f6d4d11958e459937d8846b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="clazz">
    /// <para>
    /// Blueprint of type BlueprintCharacterClass. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder UnitClass(
        this ConditionsBuilder builder,
        Blueprint<BlueprintCharacterClassReference>? clazz = null,
        bool? limitMaxLevel = null,
        bool? limitMinLevel = null,
        IntEvaluator? maxLevel = null,
        IntEvaluator? minLevel = null,
        bool negate = false,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<UnitClass>();
      element.m_Class = clazz?.Reference ?? element.m_Class;
      if (element.m_Class is null)
      {
        element.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(null);
      }
      element.LimitMaxLevel = limitMaxLevel ?? element.LimitMaxLevel;
      element.LimitMinLevel = limitMinLevel ?? element.LimitMinLevel;
      builder.Validate(maxLevel);
      element.MaxLevel = maxLevel ?? element.MaxLevel;
      builder.Validate(minLevel);
      element.MinLevel = minLevel ?? element.MinLevel;
      element.Not = negate;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitEqual"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Condition/UnitEqual
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AlarmZone</term><description>a7081ca4e21e8594f93bc84a4eb2a7a8</description></item>
    /// <item><term>CommandUnitPlayCutsceneAnimation 92</term><description>c62f3fe69de14e99925090fa30dd902a</description></item>
    /// <item><term>Ziggurat_ZachariusBeginRitual</term><description>8a020a9f01405ae4fa417500e1efd2e6</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder UnitEqual(
        this ConditionsBuilder builder,
        UnitEvaluator? firstUnit = null,
        bool negate = false,
        UnitEvaluator? secondUnit = null)
    {
      var element = ElementTool.Create<UnitEqual>();
      builder.Validate(firstUnit);
      element.FirstUnit = firstUnit ?? element.FirstUnit;
      element.Not = negate;
      builder.Validate(secondUnit);
      element.SecondUnit = secondUnit ?? element.SecondUnit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitFromSpawnerIsDead"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Condition/UnitFromSpawnerIsDead
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>52_TrulyImportantDeed_Checker_Tavern</term><description>5470ea99ea3b4bc7a7048d7f12ecb18e</description></item>
    /// <item><term>CommandDelay7</term><description>26ebc8012baa4d12a3ea017a57b657c5</description></item>
    /// <item><term>VillodusBrokenFight(Convert)</term><description>3106ac332876402b9199aa6a7b3fe10c</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder UnitFromSpawnerIsDead(
        this ConditionsBuilder builder,
        bool negate = false,
        EntityReference? target = null)
    {
      var element = ElementTool.Create<UnitFromSpawnerIsDead>();
      element.Not = negate;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitFromSummonPool"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aranka_Area_InspireCourage</term><description>3c0cbe32b0e1cce48b4407fd637ea203</description></item>
    /// <item><term>CommandAction 1</term><description>84156b459d057844a9a8427faa9562ef</description></item>
    /// <item><term>FulsomeQueen_scene_2_failsafe</term><description>470b6c480eedb4a46be293bca9ee705b</description></item>
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
    public static ConditionsBuilder UnitFromSummonPool(
        this ConditionsBuilder builder,
        bool negate = false,
        Blueprint<BlueprintSummonPoolReference>? summonPool = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<UnitFromSummonPool>();
      element.Not = negate;
      element.m_SummonPool = summonPool?.Reference ?? element.m_SummonPool;
      if (element.m_SummonPool is null)
      {
        element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitGender"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>4825507512d7234448eaa92ad6384268</description></item>
    /// <item><term>CommandUnitPlayCutsceneAnimation 67</term><description>b63766d2c96a45acb9a9ca1308024417</description></item>
    /// <item><term>DLC6_SpawnedUnitBecomesCosplayer_Actions_CutsceneNeutral</term><description>360a220ca7be40a3a52b9bc56c3f4987</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder UnitGender(
        this ConditionsBuilder builder,
        Gender? gender = null,
        bool negate = false,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<UnitGender>();
      element.Gender = gender ?? element.Gender;
      element.Not = negate;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitIsNull"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>3943d90f59434f979bae0d2f0c7937e6</description></item>
    /// <item><term>CommandSetCombatMode 2</term><description>6dbcd56d8a6c4974382459bcf30a8c79</description></item>
    /// <item><term>Sitting_Param</term><description>02c9b508081b1954e4329af6db335091</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder UnitIsNull(
        this ConditionsBuilder builder,
        bool negate = false,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<UnitIsNull>();
      element.Not = negate;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitWithBlueprintExists"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-420292_1</term><description>1d5a4ed0b3ba47c2a7718ea0a2bc2a94</description></item>
    /// <item><term>PF-420292_2</term><description>d47c4adaa34049aa8b5d717874cd03c2</description></item>
    /// <item><term>PF-420292_3</term><description>98d9def66e2c4e4495fe06c93900fbcf</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="blueprint">
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
    public static ConditionsBuilder UnitWithBlueprintExists(
        this ConditionsBuilder builder,
        Blueprint<BlueprintUnitReference>? blueprint = null,
        bool? includeDead = null,
        bool? includeHidden = null,
        bool negate = false)
    {
      var element = ElementTool.Create<UnitWithBlueprintExists>();
      element.m_Blueprint = blueprint?.Reference ?? element.m_Blueprint;
      if (element.m_Blueprint is null)
      {
        element.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      element.m_IncludeDead = includeDead ?? element.m_IncludeDead;
      element.m_IncludeHidden = includeHidden ?? element.m_IncludeHidden;
      element.Not = negate;
      return builder.Add(element);
    }
  }
}
