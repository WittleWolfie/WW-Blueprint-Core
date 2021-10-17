using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;

namespace BlueprintCore.Actions.Builder.StoryEx
{
  /// <summary>
  /// Extension to <see cref="ActionListBuilder"/> for actions related to the story such as companion stories, quests,
  /// name changes, and etudes.
  /// </summary>
  /// <inheritdoc cref="ActionListBuilder"/>
  public static class ActionListBuilderStoryEx
  {
    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.CompleteEtude">CompleteEtude</see>
    /// </summary>
    /// 
    /// <param name="etude"><see cref="BlueprintEtude"/></param>
    public static ActionListBuilder CompleteEtude(
        this ActionListBuilder builder, string etude, BlueprintEvaluator evaluator = null)
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
    public static ActionListBuilder ChangeRomance(
       this ActionListBuilder builder, string romance, IntEvaluator value)
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
    public static ActionListBuilder ChangeUnitName(
        this ActionListBuilder builder,
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
    public static ActionListBuilder ResetUnitName(
        this ActionListBuilder builder, UnitEvaluator unit)
    {
      builder.Validate(unit);

      var changeName = ElementTool.Create<ChangeUnitName>();
      changeName.Unit = unit;
      changeName.ReturnTheOldName = true;
      return builder.Add(changeName);
    }
  }
}