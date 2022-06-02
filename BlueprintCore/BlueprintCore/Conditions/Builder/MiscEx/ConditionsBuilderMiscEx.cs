//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.ElementsSystem;
using Kingmaker.GameModes;
using Kingmaker.Settings.Difficulty;
using Kingmaker.UnitLogic.Mechanics.Conditions;

namespace BlueprintCore.Conditions.Builder.MiscEx
{
  /// <summary>
  /// Extension to <see cref="ConditionsBuilder"/> for conditions without a better extension container such as achievements vendor Conditions, and CustomEvent.
  /// </summary>
  /// <inheritdoc cref="ConditionsBuilder"/>
  public static class ConditionsBuilderMiscEx
  {

    /// <summary>
    /// Adds <see cref="ContextConditionDifficultyHigherThan"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AngelRepelTheProfaneBuff</term><description>50a18ee630a4973479e9950011425748</description></item>
    /// <item><term>GiantFly_Feature_Disease</term><description>1fa6430e6064d5f4f8553c67257a1878</description></item>
    /// <item><term>WightEnergyDrainAbility</term><description>35a7f7e6ad5b4374e812fc10ec1c836c</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder DifficultyHigherThan(
        this ConditionsBuilder builder,
        bool? checkOnlyForMonster = null,
        DifficultyPresetAsset? difficulty = null,
        bool? less = null,
        bool negate = false,
        bool? reverse = null)
    {
      var element = ElementTool.Create<ContextConditionDifficultyHigherThan>();
      element.CheckOnlyForMonster = checkOnlyForMonster ?? element.CheckOnlyForMonster;
      builder.Validate(difficulty);
      element.m_Difficulty = difficulty ?? element.m_Difficulty;
      element.Less = less ?? element.Less;
      element.Not = negate;
      element.Reverse = reverse ?? element.Reverse;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DifficultyHigherThan"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction 3</term><description>651c3ea9f9323e943823ed497736ac74</description></item>
    /// <item><term>CommandSetCombatMode4</term><description>c804cbf4f3e9427ca72b9800042cacb3</description></item>
    /// <item><term>Valmallos_Feature_CombatTrigger</term><description>f4621cc70bec4fe7b0373ed152e40570</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder DifficultyHigherThan(
        this ConditionsBuilder builder,
        DifficultyPresetAsset? difficulty = null,
        bool negate = false)
    {
      var element = ElementTool.Create<DifficultyHigherThan>();
      builder.Validate(difficulty);
      element.m_Difficulty = difficulty ?? element.m_Difficulty;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="EnlargedEncountersCapacity"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction 3</term><description>651c3ea9f9323e943823ed497736ac74</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder EnlargedEncountersCapacity(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<EnlargedEncountersCapacity>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GameModeActive"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CrusadeTutorial_01_Chapter2Intro</term><description>20073002e0594c88b5af911060e8dde8</description></item>
    /// <item><term>Tutorials_Chapter03</term><description>1b59d48741cbf9945adde5dc62f968d8</description></item>
    /// <item><term>Tutorials_Chapter04</term><description>6321277cfb08bb5469b148e2a7a7cc12</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder GameModeActive(
        this ConditionsBuilder builder,
        GameModeType.Enum? gameMode = null,
        bool negate = false)
    {
      var element = ElementTool.Create<GameModeActive>();
      element.m_GameMode = gameMode ?? element.m_GameMode;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HasEnoughMoneyForCustomCompanion"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0003</term><description>2295c50c6e3d4d93a86a9086aada9833</description></item>
    /// <item><term>Answer_0089</term><description>8639e5fa92c97d24886ae8c90acd38fe</description></item>
    /// <item><term>Answer_3</term><description>40b8e29fb08f4f59bd037e33519002ed</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder HasEnoughMoneyForCustomCompanion(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<HasEnoughMoneyForCustomCompanion>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HasEnoughMoneyForRespec"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0035</term><description>e04a20e1581a72843a53d18ac4e78408</description></item>
    /// <item><term>Answer_6</term><description>b410fd9e96874a849d94f792fc429d39</description></item>
    /// <item><term>MercenaryTrouble6</term><description>0a8297764e3f9bf4ba5757a0edecd019</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder HasEnoughMoneyForRespec(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<HasEnoughMoneyForRespec>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsDlcActive"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Cue_3</term><description>fd59cd739561481bae00977016d85c67</description></item>
    /// <item><term>Cue_4</term><description>d0421fc2ad1646debb25b9de5e452280</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="blueprintDlcReward">
    /// <para>
    /// Blueprint of type BlueprintDlcReward. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder IsDlcActive(
        this ConditionsBuilder builder,
        Blueprint<BlueprintDlcRewardReference>? blueprintDlcReward = null,
        bool negate = false)
    {
      var element = ElementTool.Create<IsDlcActive>();
      element.m_BlueprintDlcReward = blueprintDlcReward?.Reference ?? element.m_BlueprintDlcReward;
      if (element.m_BlueprintDlcReward is null)
      {
        element.m_BlueprintDlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsDLCEnabled"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AasimarRace</term><description>b7f02ba92b363064fb873963bec275ee</description></item>
    /// <item><term>Edge_SarkorianWedding_Chapter05_Army21</term><description>f5867b88ae4d4b189c025df9161e75d4</description></item>
    /// <item><term>Location_SarkorianWedding</term><description>da3e19fa23f94fa3a563bd866189e9da</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="blueprintDlcReward">
    /// <para>
    /// Blueprint of type BlueprintDlcReward. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder IsDLCEnabled(
        this ConditionsBuilder builder,
        Blueprint<BlueprintDlcRewardReference>? blueprintDlcReward = null,
        bool negate = false)
    {
      var element = ElementTool.Create<IsDLCEnabled>();
      element.m_BlueprintDlcReward = blueprintDlcReward?.Reference ?? element.m_BlueprintDlcReward;
      if (element.m_BlueprintDlcReward is null)
      {
        element.m_BlueprintDlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsleStateCondition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Alushinyrra_MediumCity_AssasinsGuild</term><description>66fac7083737ab0449932caf327667cd</description></item>
    /// <item><term>AlushinyrraLowerCity_BattleblisAvailble</term><description>fa9c548fa28e4b979db3bf6cefa09c32</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder IsleStateCondition(
        this ConditionsBuilder builder,
        IsleEvaluator? isle = null,
        bool negate = false,
        string? state = null)
    {
      var element = ElementTool.Create<IsleStateCondition>();
      builder.Validate(isle);
      element.m_Isle = isle ?? element.m_Isle;
      element.Not = negate;
      element.m_State = state ?? element.m_State;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsListContainsItem"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>areeluPuzzle_ItemRestriction</term><description>abd21b102fd546a0bd53dff0b566076f</description></item>
    /// <item><term>MaskPuzzleLootCont_3_CloseAction</term><description>2573e02967e95014c93266c845bc9f2e</description></item>
    /// <item><term>Slot_2_1_ItemRestriction</term><description>14081f100ba2a284b9f1d99cfd0c1363</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="list">
    /// <para>
    /// Blueprint of type BlueprintItemsList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder IsListContainsItem(
        this ConditionsBuilder builder,
        ItemEvaluator? item = null,
        Blueprint<BlueprintItemsList.Reference>? list = null,
        bool negate = false)
    {
      var element = ElementTool.Create<IsListContainsItem>();
      builder.Validate(item);
      element.Item = item ?? element.Item;
      element.List = list?.Reference ?? element.List;
      if (element.List is null)
      {
        element.List = BlueprintTool.GetRef<BlueprintItemsList.Reference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsRespecAllowed"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0027</term><description>e75acba3688113a40afa7a46f7fd7bb8</description></item>
    /// <item><term>Answer_0095</term><description>deae4190a11f1ca4c9617d9dc2307ba7</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder IsRespecAllowed(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<IsRespecAllowed>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsUnitCustomCompanion"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction 3</term><description>37d0bc9b4ebab6f4e9fe53edffaf4cf1</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder IsUnitCustomCompanion(
        this ConditionsBuilder builder,
        bool negate = false,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<IsUnitCustomCompanion>();
      element.Not = negate;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RespecIsFree"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Cue_2</term><description>48c4790378964832ae733ff5e26c7e20</description></item>
    /// <item><term>Cue_2</term><description>c8a45cb530054b0d896148e4e02263b9</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder RespecIsFree(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<RespecIsFree>();
      element.Not = negate;
      return builder.Add(element);
    }
  }
}
