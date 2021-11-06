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
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.GiveObjective)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.HideUnit)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.HideWeapons)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.IncrementFlagValue)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.InterruptAllActions)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.LockAlignment)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.LockFlag)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.LockRomance)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.MakeItemNonRemovable)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.MarkAnswersSelected)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.MarkCuesSeen)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.MoveAzataIslandToLocation)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.MoveAzataIslandToNearestCrossroad)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.MovePartyItemsAction)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.OverrideUnitReturnPosition)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.PartyMembersAttach)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.PartyMembersDetach)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.PartyMembersDetachEvaluated)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.PartyMembersSwapAttachedAndDetached)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.Recruit)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.RecruitInactive)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.RelockInteraction)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.RemoveMythicLevels)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.ReplaceAllMythicLevelsWithMythicHeroLevels)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.ReplaceFeatureInProgression)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.ResetQuest)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.ResetQuestObjective)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.RespecCompanion)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.RomanceSetMaximum)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.RomanceSetMinimum)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.ScriptZoneActivate)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.ScriptZoneDeactivate)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.ScripZoneUnits)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.SetDialogPosition)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.SetMythicLevelForMainCharacter)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.SetObjectiveStatus)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.SetPortrait)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.ShiftAlignment)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.ShowDialogBox)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.ShowMessageBox)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.ShowUIWarning)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.StartDialog)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.StartEtude)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.SwitchAzataIsland)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.SwitchChapter)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.SwitchDualCompanion)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.TimeSkip)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.UnlinkDualCompanions)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.UnlockCompanionStory)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.UnlockFlag)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.UnmarkAnswersSelected)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.Unrecruit)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.UpdateEtudeProgressBar)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.UpdateEtudes)]

  }
}