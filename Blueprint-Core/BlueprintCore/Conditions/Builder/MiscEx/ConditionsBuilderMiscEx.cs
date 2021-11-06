using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Assets.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.GameModes;
using Kingmaker.Settings.Difficulty;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using System;
namespace BlueprintCore.Conditions.Builder.MiscEx
{
  /// <summary>
  /// Extension to <see cref="ConditionsBuilder"/> for conditions without a better extension container such as
  /// difficulty.
  /// </summary>
  /// <inheritdoc cref="ConditionsBuilder"/>
  public static class ConditionsBuilderMiscEx
  {
    //----- Auto Generated -----//



    /// <summary>
    /// Adds <see cref="ContextConditionDifficultyHigherThan"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionDifficultyHigherThan))]
    public static ConditionsBuilder AddContextConditionDifficultyHigherThan(
        this ConditionsBuilder builder,
        Boolean Less,
        Boolean Reverse,
        Boolean CheckOnlyForMonster,
        DifficultyPresetAsset m_Difficulty,
        bool negate = false)
    {
      builder.Validate(Less);
      builder.Validate(Reverse);
      builder.Validate(CheckOnlyForMonster);
      builder.Validate(m_Difficulty);
      
      var element = ElementTool.Create<ContextConditionDifficultyHigherThan>();
      element.Less = Less;
      element.Reverse = Reverse;
      element.CheckOnlyForMonster = CheckOnlyForMonster;
      element.m_Difficulty = m_Difficulty;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DifficultyHigherThan"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DifficultyHigherThan))]
    public static ConditionsBuilder AddDifficultyHigherThan(
        this ConditionsBuilder builder,
        DifficultyPresetAsset m_Difficulty,
        bool negate = false)
    {
      builder.Validate(m_Difficulty);
      
      var element = ElementTool.Create<DifficultyHigherThan>();
      element.m_Difficulty = m_Difficulty;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="EnlargedEncountersCapacity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EnlargedEncountersCapacity))]
    public static ConditionsBuilder AddEnlargedEncountersCapacity(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      
      var element = ElementTool.Create<EnlargedEncountersCapacity>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Paused"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Paused))]
    public static ConditionsBuilder AddPaused(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      
      var element = ElementTool.Create<Paused>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GameModeActive"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GameModeActive))]
    public static ConditionsBuilder AddGameModeActive(
        this ConditionsBuilder builder,
        GameModeType.Enum m_GameMode,
        bool negate = false)
    {
      builder.Validate(m_GameMode);
      
      var element = ElementTool.Create<GameModeActive>();
      element.m_GameMode = m_GameMode;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsDLCEnabled"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_BlueprintDlcReward"><see cref="BlueprintDlcReward"/></param>
    [Generated]
    [Implements(typeof(IsDLCEnabled))]
    public static ConditionsBuilder AddIsDLCEnabled(
        this ConditionsBuilder builder,
        string m_BlueprintDlcReward,
        bool negate = false)
    {
      
      var element = ElementTool.Create<IsDLCEnabled>();
      element.m_BlueprintDlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(m_BlueprintDlcReward);
      element.Not = negate;
      return builder.Add(element);
    }
  }
}
