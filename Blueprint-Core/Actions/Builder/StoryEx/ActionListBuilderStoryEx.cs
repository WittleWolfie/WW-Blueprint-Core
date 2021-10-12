using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;

namespace BlueprintCore.Actions.Builder.StoryEx
{
  /**
   * Extension to ActionListBuilder for story related actions including companion stories, name
   * changes, quests, and etudes.
   */
  public static class ActionListBuilderStoryEx
  {
    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    /**
     * CompleteEtude
     *
     * @param etude BlueprintEtude
     */
    public static ActionListBuilder CompleteEtude(
        this ActionListBuilder builder, string etude, BlueprintEvaluator evaluator = null)
    {
      var completeEtude = ElementTool.Create<CompleteEtude>();
      completeEtude.Etude = BlueprintTool.GetRef<BlueprintEtude, BlueprintEtudeReference>(etude);
      if (evaluator != null)
      {
        completeEtude.EtudeEvaluator = evaluator;
        completeEtude.Evaluate = true;
      }
      return builder.Add(completeEtude);
    }

    /**
     * ChangeRomance
     *
     * @param romance BlueprintRomanceCounter
     */
    public static ActionListBuilder ChangeRomance(
       this ActionListBuilder builder, string romance, IntEvaluator value)
    {
      builder.Validate(value);

      var changeRomance = ElementTool.Create<ChangeRomance>();
      changeRomance.m_Romance =
          BlueprintTool.GetRef<BlueprintRomanceCounter, BlueprintRomanceCounterReference>(romance);
      changeRomance.ValueEvaluator = value;
      return builder.Add(changeRomance);
    }

    /** ChangeUnitName */
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

    /** ChangeUnitName */
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