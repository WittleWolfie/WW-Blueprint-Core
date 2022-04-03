//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Assets.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.DLC;
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
    public static ConditionsBuilder ContextConditionDifficultyHigherThan(
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
    public static ConditionsBuilder HasEnoughMoneyForRespec(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<HasEnoughMoneyForRespec>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsDLCEnabled"/>
    /// </summary>
    ///
    /// <param name="blueprintDlcReward">
    /// Blueprint of type BlueprintDlcReward. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder IsDLCEnabled(
        this ConditionsBuilder builder,
        Blueprint<BlueprintDlcReward, BlueprintDlcRewardReference>? blueprintDlcReward = null,
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
    /// <param name="list">
    /// Blueprint of type BlueprintItemsList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder IsListContainsItem(
        this ConditionsBuilder builder,
        ItemEvaluator? item = null,
        Blueprint<BlueprintItemsList, BlueprintItemsList.Reference>? list = null,
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
    /// Adds <see cref="Paused"/>
    /// </summary>
    public static ConditionsBuilder Paused(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<Paused>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RespecIsFree"/>
    /// </summary>
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
