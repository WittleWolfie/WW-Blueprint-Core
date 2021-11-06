using BlueprintCore.Utils;
using Kingmaker.Assets.Designers.EventConditionActionSystem.Conditions;
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
  }
}
