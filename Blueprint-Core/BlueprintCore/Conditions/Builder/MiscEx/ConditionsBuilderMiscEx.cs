using BlueprintCore.Blueprints;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Assets.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.ElementsSystem;
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
        Boolean Not)
    {
      builder.Validate(Less);
      builder.Validate(Reverse);
      builder.Validate(CheckOnlyForMonster);
      builder.Validate(m_Difficulty);
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionDifficultyHigherThan>();
      element.Less = Less;
      element.Reverse = Reverse;
      element.CheckOnlyForMonster = CheckOnlyForMonster;
      element.m_Difficulty = m_Difficulty;
      element.Not = Not;
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
        Boolean Not)
    {
      builder.Validate(m_Difficulty);
      builder.Validate(Not);
      
      var element = ElementTool.Create<DifficultyHigherThan>();
      element.m_Difficulty = m_Difficulty;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="EnlargedEncountersCapacity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EnlargedEncountersCapacity))]
    public static ConditionsBuilder AddEnlargedEncountersCapacity(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<EnlargedEncountersCapacity>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Paused"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Paused))]
    public static ConditionsBuilder AddPaused(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<Paused>();
      element.Not = Not;
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
        Boolean Not)
    {
      builder.Validate(m_GameMode);
      builder.Validate(Not);
      
      var element = ElementTool.Create<GameModeActive>();
      element.m_GameMode = m_GameMode;
      element.Not = Not;
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
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<IsDLCEnabled>();
      element.m_BlueprintDlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(m_BlueprintDlcReward);
      element.Not = Not;
      return builder.Add(element);
    }



    /// <summary>
    /// Adds <see cref="False"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(False))]
    public static ConditionsBuilder AddFalse(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<False>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GreaterThan"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GreaterThan))]
    public static ConditionsBuilder AddGreaterThan(
        this ConditionsBuilder builder,
        Boolean FloatValues,
        IntEvaluator Value,
        IntEvaluator MinValue,
        FloatEvaluator FloatValue,
        FloatEvaluator FloatMinValue,
        Boolean Not)
    {
      builder.Validate(FloatValues);
      builder.Validate(Value);
      builder.Validate(MinValue);
      builder.Validate(FloatValue);
      builder.Validate(FloatMinValue);
      builder.Validate(Not);
      
      var element = ElementTool.Create<GreaterThan>();
      element.FloatValues = FloatValues;
      element.Value = Value;
      element.MinValue = MinValue;
      element.FloatValue = FloatValue;
      element.FloatMinValue = FloatMinValue;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsEqual"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsEqual))]
    public static ConditionsBuilder AddIsEqual(
        this ConditionsBuilder builder,
        IntEvaluator FirstValue,
        IntEvaluator SecondValue,
        Boolean Not)
    {
      builder.Validate(FirstValue);
      builder.Validate(SecondValue);
      builder.Validate(Not);
      
      var element = ElementTool.Create<IsEqual>();
      element.FirstValue = FirstValue;
      element.SecondValue = SecondValue;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="LessThan"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LessThan))]
    public static ConditionsBuilder AddLessThan(
        this ConditionsBuilder builder,
        Boolean FloatValues,
        IntEvaluator Value,
        IntEvaluator MaxValue,
        FloatEvaluator FloatValue,
        FloatEvaluator FloatMaxValue,
        Boolean Not)
    {
      builder.Validate(FloatValues);
      builder.Validate(Value);
      builder.Validate(MaxValue);
      builder.Validate(FloatValue);
      builder.Validate(FloatMaxValue);
      builder.Validate(Not);
      
      var element = ElementTool.Create<LessThan>();
      element.FloatValues = FloatValues;
      element.Value = Value;
      element.MaxValue = MaxValue;
      element.FloatValue = FloatValue;
      element.FloatMaxValue = FloatMaxValue;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="OrAndLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OrAndLogic))]
    public static ConditionsBuilder AddOrAndLogic(
        this ConditionsBuilder builder,
        String Comment,
        ConditionsBuilder ConditionsChecker,
        Boolean Not)
    {
      foreach (var item in Comment)
      {
        builder.Validate(item);
      }
      builder.Validate(Not);
      
      var element = ElementTool.Create<OrAndLogic>();
      element.Comment = Comment;
      element.ConditionsChecker = ConditionsChecker.Build();
      element.Not = Not;
      return builder.Add(element);
    }
  }
}
