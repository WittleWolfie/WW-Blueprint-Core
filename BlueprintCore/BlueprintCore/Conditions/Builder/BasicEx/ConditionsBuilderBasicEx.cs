//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items;
using Kingmaker.Designers;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Designers.EventConditionActionSystem.NamedParameters;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Conditions;

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
    /// <item><term>Slot_3_2_ItemRestriction</term><description>1477f17f059aec64880505ed455fae7b</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder CheckConditionsHolder(
        this ConditionsBuilder builder,
        Blueprint<ConditionsHolder, ConditionsReference>? conditionsHolder = null,
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
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
        Blueprint<BlueprintItem, BlueprintItemReference>? targetItem = null,
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
    /// <item><term>Cue_0028</term><description>8d0651bbec3caaf46b82d72490d2b24d</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder CompanionInParty(
        this ConditionsBuilder builder,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? companion = null,
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
    /// <item><term>DaeranRomance_HolyCarpet</term><description>a47a5d2f17acaf24fae7f86af6ba734d</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder CompanionIsDead(
        this ConditionsBuilder builder,
        bool? anyCompanion = null,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? companion = null,
        bool negate = false)
    {
      var element = ElementTool.Create<CompanionIsDead>();
      element.anyCompanion = anyCompanion ?? element.anyCompanion;
      element.m_companion = companion?.Reference ?? element.m_companion;
      if (element.m_companion is null)
      {
        element.m_companion = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder CompanionIsLost(
        this ConditionsBuilder builder,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? companion = null,
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
    /// <item><term>AlushinyrraBeggar_Actions</term><description>a5a61ef3563441544bc2763003c9e653</description></item>
    /// <item><term>CommandAction 9</term><description>a36aa9372df6f9b4b9fc9e02c0feca7c</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder HasBuff(
        this ConditionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? buff = null,
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
    /// <item><term>Answer_0001</term><description>3d7ba59b443f44e1b6a830cd0c3e9550</description></item>
    /// <item><term>Answer_0267</term><description>37d6832ded0bce04b8c43a957dd1987e</description></item>
    /// <item><term>ThirdElementWater</term><description>86eff374d040404438ad97fedd7218bc</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder HasFact(
        this ConditionsBuilder builder,
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? fact = null,
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
    /// <item><term>Arrow_Puzzle_1_complete</term><description>fc34b75fb3f147d398607271584ee70f</description></item>
    /// <item><term>Cue_0059</term><description>b1eb561b4bd711d46bdb85c229519f8d</description></item>
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
    /// <item><term>IrabethF2_route2</term><description>70c05f4809f513a478f0cadeb2733dac</description></item>
    /// <item><term>Winterson_DaeranRomanceInteraction</term><description>27de7726b37e62b4daa670805c64bc6b</description></item>
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
    /// <item><term>NecromantInMall</term><description>1b52d48e18fb11848912a24a90694ae9</description></item>
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
    /// <item><term>DevilMythicClass</term><description>211f49705f478b3468db6daa802452a2</description></item>
    /// <item><term>GoldenDragonClass</term><description>daf1235b6217787499c14e4e32142523</description></item>
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
    /// <item><term>BridgePuzzle_ItemRestriction</term><description>a56ff402d9024f4b83203bf56593c13e</description></item>
    /// <item><term>Purple_Slot_1_4_Art_1_5f</term><description>4635a28022e37d743abe290f17c19b4b</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder ItemBlueprint(
        this ConditionsBuilder builder,
        Blueprint<BlueprintItem, BlueprintItemReference>? blueprint = null,
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
    /// <item><term>Answer_4</term><description>90bf560582a440d48818649b02dc145f</description></item>
    /// <item><term>ZeorisDagger_ReforgeProject</term><description>22e8219563e84f11b6aed62661030770</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="ignoreRemoteCompanions">
    /// <para>
    /// InfoBox: Check item `equipped` state and don't count items equipped on remote companions
    /// </para>
    /// </param>
    /// <param name="itemToCheck">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder ItemsEnough(
        this ConditionsBuilder builder,
        bool? checkInPlayerHubChest = null,
        bool? ignoreRemoteCompanions = null,
        Blueprint<BlueprintItem, BlueprintItemReference>? itemToCheck = null,
        bool? money = null,
        bool negate = false,
        int? quantity = null)
    {
      var element = ElementTool.Create<ItemsEnough>();
      element.CheckInPlayerHubChest = checkInPlayerHubChest ?? element.CheckInPlayerHubChest;
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
    /// <item><term>Answer_0065</term><description>a4e1af2f7eff831479aeef4799cdbf59</description></item>
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
    /// <item><term>PrologueTest</term><description>3bf75ba9a63e44959a2e54655acce34e</description></item>
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
    /// <item><term>Cue_0019</term><description>1071445514a15ec42a057a987886a0b5</description></item>
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
    /// <item><term>Cue_0035</term><description>c1a8b930c3827b74b9a2c0f253a08910</description></item>
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
    /// Adds <see cref="SummonPoolExistsAndEmpty"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Graveyard_AfterStartDialogue</term><description>b179654bab55435c8164bed60aaf150d</description></item>
    /// <item><term>Graveyard_WP1Skipped_SZ</term><description>7d45e27f9bd148cb8514ad85df04f537</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder SummonPoolExistsAndEmpty(
        this ConditionsBuilder builder,
        bool negate = false,
        Blueprint<BlueprintSummonPool, BlueprintSummonPoolReference>? summonPool = null)
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
    /// <item><term>CommandUnitCastSpell 1</term><description>135a7dc5d5a058f4891db6fc7e86f143</description></item>
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
    /// <item><term>Cue_0019</term><description>1686b22fd9f8d364e9cee0180d95ce1b</description></item>
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
    /// <item><term>GoodHopeTrollLair</term><description>8b9916170be016a49a94cc41634b3a24</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder UnitBlueprint(
        this ConditionsBuilder builder,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? blueprint = null,
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
    /// <item><term>Cue_0068</term><description>be4db75c106fb854cbc45323e0754c5b</description></item>
    /// <item><term>Timer_Before_KTC_MythicDemonRankUp2</term><description>5caab08042b37f641ad9ff9ad411c44e</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder UnitClass(
        this ConditionsBuilder builder,
        Blueprint<BlueprintCharacterClass, BlueprintCharacterClassReference>? clazz = null,
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
    /// <item><term>GlobalPuzzle_AreshkaArena</term><description>95952942631a4a2d9617c14c1fa989a4</description></item>
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
    /// <item><term>CommandSetCombatMode 8</term><description>3566ac28c35062047a6aefc2aaffec8e</description></item>
    /// <item><term>SZ_Inquis2</term><description>11903f7d8ea24f9ea9425468adf277f2</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder UnitFromSummonPool(
        this ConditionsBuilder builder,
        bool negate = false,
        Blueprint<BlueprintSummonPool, BlueprintSummonPoolReference>? summonPool = null,
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
    /// <item><term>CommandAction</term><description>6406c24f83d2450ba83fd3a5b770ca1d</description></item>
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
    /// <item><term>CommandAction</term><description>bc9bee1516bd40d4aa0ca4e70e753cf3</description></item>
    /// <item><term>CommandSetCombatMode</term><description>49386302edee1644197cef3cf6b28f98</description></item>
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
  }
}
