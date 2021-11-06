using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;

namespace BlueprintCoreGen.Actions.Builder.StoryEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for actions related to the story such as companion stories, quests,
  /// name changes, and etudes.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderStoryEx
  {
    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.CompleteEtude">CompleteEtude</see>
    /// </summary>
    /// 
    /// <param name="etude"><see cref="BlueprintEtude"/></param>
    [Implements(typeof(CompleteEtude))]
    public static ActionsBuilder CompleteEtude(
        this ActionsBuilder builder, string etude, BlueprintEvaluator evaluator = null)
    {
      var completeEtude = ElementTool.Create<CompleteEtude>();
      completeEtude.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      if (evaluator != null)
      {
        completeEtude.EtudeEvaluator = evaluator;
        completeEtude.Evaluate = true;
      }
      return builder.Add(completeEtude);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.ChangeRomance">ChangeRomance</see>
    /// </summary>
    /// 
    /// <param name="romance"><see cref="BlueprintRomanceCounter"/></param>
    [Implements(typeof(ChangeRomance))]
    public static ActionsBuilder ChangeRomance(
       this ActionsBuilder builder, string romance, IntEvaluator value)
    {
      builder.Validate(value);

      var changeRomance = ElementTool.Create<ChangeRomance>();
      changeRomance.m_Romance = BlueprintTool.GetRef<BlueprintRomanceCounterReference>(romance);
      changeRomance.ValueEvaluator = value;
      return builder.Add(changeRomance);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.ChangeUnitName">ChangeUnitName</see>
    /// </summary>
    [Implements(typeof(ChangeUnitName))]
    public static ActionsBuilder ChangeUnitName(
        this ActionsBuilder builder,
        UnitEvaluator unit,
        LocalizedString name,
        bool appendName = false)
    {
      builder.Validate(unit);

      var changeName = ElementTool.Create<ChangeUnitName>();
      changeName.Unit = unit;
      changeName.NewName = name;
      changeName.AddToTheName = appendName;
      return builder.Add(changeName);
    }

    /// <inheritdoc cref="ChangeUnitName"/>
    [Implements(typeof(ChangeUnitName))]
    public static ActionsBuilder ResetUnitName(
        this ActionsBuilder builder, UnitEvaluator unit)
    {
      builder.Validate(unit);

      var changeName = ElementTool.Create<ChangeUnitName>();
      changeName.Unit = unit;
      changeName.ReturnTheOldName = true;
      return builder.Add(changeName);
    }

    //----- Auto Generated -----//

    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.AlignmentSelector)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.DismissAllCompanions)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.LockRomance)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.UnmarkAnswersSelected)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.Unrecruit)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.UpdateEtudeProgressBar)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.UpdateEtudes)]

  }
}