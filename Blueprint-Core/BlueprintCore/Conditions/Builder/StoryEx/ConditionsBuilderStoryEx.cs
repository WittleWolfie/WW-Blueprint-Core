using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic;
using Kingmaker.AreaLogic.QuestSystem;
using Kingmaker.Assets.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Alignments;
using System;
using System.Collections.Generic;
namespace BlueprintCore.Conditions.Builder.MiscEx
{
  /// <summary>
  /// Extension to <see cref="ConditionsBuilder"/> for conditions related to the story such as companion stories, quests,
  /// name changes, and etudes.
  /// </summary>
  /// <inheritdoc cref="ConditionsBuilder"/>
  public static class ConditionsBuilderStoryEx
  {
    //----- Auto Generated -----//



    /// <summary>
    /// Adds <see cref="BarkBanterPlayed"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Banter"><see cref="BlueprintBarkBanter"/></param>
    [Generated]
    [Implements(typeof(BarkBanterPlayed))]
    public static ConditionsBuilder AddBarkBanterPlayed(
        this ConditionsBuilder builder,
        string m_Banter,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<BarkBanterPlayed>();
      element.m_Banter = BlueprintTool.GetRef<BlueprintBarkBanterReference>(m_Banter);
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DialogSeen"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Dialog"><see cref="BlueprintDialog"/></param>
    [Generated]
    [Implements(typeof(DialogSeen))]
    public static ConditionsBuilder AddDialogSeen(
        this ConditionsBuilder builder,
        string m_Dialog,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<DialogSeen>();
      element.m_Dialog = BlueprintTool.GetRef<BlueprintDialogReference>(m_Dialog);
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AlignmentCheck"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AlignmentCheck))]
    public static ConditionsBuilder AddAlignmentCheck(
        this ConditionsBuilder builder,
        AlignmentComponent Alignment,
        Boolean Not)
    {
      builder.Validate(Alignment);
      builder.Validate(Not);
      
      var element = ElementTool.Create<AlignmentCheck>();
      element.Alignment = Alignment;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AnotherEtudeOfGroupIsPlaying"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Group"><see cref="BlueprintEtudeConflictingGroup"/></param>
    [Generated]
    [Implements(typeof(AnotherEtudeOfGroupIsPlaying))]
    public static ConditionsBuilder AddAnotherEtudeOfGroupIsPlaying(
        this ConditionsBuilder builder,
        string m_Group,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<AnotherEtudeOfGroupIsPlaying>();
      element.m_Group = BlueprintTool.GetRef<BlueprintEtudeConflictingGroupReference>(m_Group);
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AnswerListShown"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_AnswersList"><see cref="BlueprintAnswersList"/></param>
    [Generated]
    [Implements(typeof(AnswerListShown))]
    public static ConditionsBuilder AddAnswerListShown(
        this ConditionsBuilder builder,
        string m_AnswersList,
        Boolean CurrentDialog,
        Boolean Not)
    {
      builder.Validate(CurrentDialog);
      builder.Validate(Not);
      
      var element = ElementTool.Create<AnswerListShown>();
      element.m_AnswersList = BlueprintTool.GetRef<BlueprintAnswersListReference>(m_AnswersList);
      element.CurrentDialog = CurrentDialog;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AnswerSelected"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Answer"><see cref="BlueprintAnswer"/></param>
    [Generated]
    [Implements(typeof(AnswerSelected))]
    public static ConditionsBuilder AddAnswerSelected(
        this ConditionsBuilder builder,
        string m_Answer,
        Boolean CurrentDialog,
        Boolean Not)
    {
      builder.Validate(CurrentDialog);
      builder.Validate(Not);
      
      var element = ElementTool.Create<AnswerSelected>();
      element.m_Answer = BlueprintTool.GetRef<BlueprintAnswerReference>(m_Answer);
      element.CurrentDialog = CurrentDialog;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CompanionStoryUnlocked"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CompanionStory"><see cref="BlueprintCompanionStory"/></param>
    [Generated]
    [Implements(typeof(CompanionStoryUnlocked))]
    public static ConditionsBuilder AddCompanionStoryUnlocked(
        this ConditionsBuilder builder,
        string m_CompanionStory,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<CompanionStoryUnlocked>();
      element.m_CompanionStory = BlueprintTool.GetRef<BlueprintCompanionStoryReference>(m_CompanionStory);
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CueSeen"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Cue"><see cref="BlueprintCueBase"/></param>
    [Generated]
    [Implements(typeof(CueSeen))]
    public static ConditionsBuilder AddCueSeen(
        this ConditionsBuilder builder,
        string m_Cue,
        Boolean CurrentDialog,
        Boolean Not)
    {
      builder.Validate(CurrentDialog);
      builder.Validate(Not);
      
      var element = ElementTool.Create<CueSeen>();
      element.m_Cue = BlueprintTool.GetRef<BlueprintCueBaseReference>(m_Cue);
      element.CurrentDialog = CurrentDialog;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CurrentChapter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CurrentChapter))]
    public static ConditionsBuilder AddCurrentChapter(
        this ConditionsBuilder builder,
        Int32 Chapter,
        Boolean Not)
    {
      builder.Validate(Chapter);
      builder.Validate(Not);
      
      var element = ElementTool.Create<CurrentChapter>();
      element.Chapter = Chapter;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CutsceneQueueState"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CutsceneQueueState))]
    public static ConditionsBuilder AddCutsceneQueueState(
        this ConditionsBuilder builder,
        Boolean First,
        Boolean Last,
        Boolean Not)
    {
      builder.Validate(First);
      builder.Validate(Last);
      builder.Validate(Not);
      
      var element = ElementTool.Create<CutsceneQueueState>();
      element.First = First;
      element.Last = Last;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DayOfTheMonth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DayOfTheMonth))]
    public static ConditionsBuilder AddDayOfTheMonth(
        this ConditionsBuilder builder,
        Int32 Day,
        Boolean Not)
    {
      builder.Validate(Day);
      builder.Validate(Not);
      
      var element = ElementTool.Create<DayOfTheMonth>();
      element.Day = Day;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DayOfTheWeek"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DayOfTheWeek))]
    public static ConditionsBuilder AddDayOfTheWeek(
        this ConditionsBuilder builder,
        DayOfWeek Day,
        Boolean Not)
    {
      builder.Validate(Day);
      builder.Validate(Not);
      
      var element = ElementTool.Create<DayOfTheWeek>();
      element.Day = Day;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DayTime"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DayTime))]
    public static ConditionsBuilder AddDayTime(
        this ConditionsBuilder builder,
        TimeOfDay Time,
        Boolean Not)
    {
      builder.Validate(Time);
      builder.Validate(Not);
      
      var element = ElementTool.Create<DayTime>();
      element.Time = Time;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="EtudeStatus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Etude"><see cref="BlueprintEtude"/></param>
    [Generated]
    [Implements(typeof(EtudeStatus))]
    public static ConditionsBuilder AddEtudeStatus(
        this ConditionsBuilder builder,
        string m_Etude,
        Boolean NotStarted,
        Boolean Started,
        Boolean Playing,
        Boolean CompletionInProgress,
        Boolean Completed,
        Boolean Not)
    {
      builder.Validate(NotStarted);
      builder.Validate(Started);
      builder.Validate(Playing);
      builder.Validate(CompletionInProgress);
      builder.Validate(Completed);
      builder.Validate(Not);
      
      var element = ElementTool.Create<EtudeStatus>();
      element.m_Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(m_Etude);
      element.NotStarted = NotStarted;
      element.Started = Started;
      element.Playing = Playing;
      element.CompletionInProgress = CompletionInProgress;
      element.Completed = Completed;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="FlagInRange"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Flag"><see cref="BlueprintUnlockableFlag"/></param>
    [Generated]
    [Implements(typeof(FlagInRange))]
    public static ConditionsBuilder AddFlagInRange(
        this ConditionsBuilder builder,
        string m_Flag,
        Int32 MinValue,
        Int32 MaxValue,
        Boolean Not)
    {
      builder.Validate(MinValue);
      builder.Validate(MaxValue);
      builder.Validate(Not);
      
      var element = ElementTool.Create<FlagInRange>();
      element.m_Flag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(m_Flag);
      element.MinValue = MinValue;
      element.MaxValue = MaxValue;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="FlagUnlocked"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_ConditionFlag"><see cref="BlueprintUnlockableFlag"/></param>
    [Generated]
    [Implements(typeof(FlagUnlocked))]
    public static ConditionsBuilder AddFlagUnlocked(
        this ConditionsBuilder builder,
        string m_ConditionFlag,
        Boolean ExceptSpecifiedValues,
        List<Int32> SpecifiedValues,
        Boolean Not)
    {
      builder.Validate(ExceptSpecifiedValues);
      foreach (var item in SpecifiedValues)
      {
        builder.Validate(item);
      }
      builder.Validate(Not);
      
      var element = ElementTool.Create<FlagUnlocked>();
      element.m_ConditionFlag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(m_ConditionFlag);
      element.ExceptSpecifiedValues = ExceptSpecifiedValues;
      element.SpecifiedValues = SpecifiedValues;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsLegendPathSelected"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsLegendPathSelected))]
    public static ConditionsBuilder AddIsLegendPathSelected(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<IsLegendPathSelected>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PlayerAlignmentIs"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PlayerAlignmentIs))]
    public static ConditionsBuilder AddPlayerAlignmentIs(
        this ConditionsBuilder builder,
        AlignmentMaskType Alignment,
        Boolean Not)
    {
      builder.Validate(Alignment);
      builder.Validate(Not);
      
      var element = ElementTool.Create<PlayerAlignmentIs>();
      element.Alignment = Alignment;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PlayerHasNoCharactersOnRoster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PlayerHasNoCharactersOnRoster))]
    public static ConditionsBuilder AddPlayerHasNoCharactersOnRoster(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<PlayerHasNoCharactersOnRoster>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PlayerHasRecruitsOnRoster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PlayerHasRecruitsOnRoster))]
    public static ConditionsBuilder AddPlayerHasRecruitsOnRoster(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<PlayerHasRecruitsOnRoster>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PlayerSignificantClassIs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_CharacterClassGroup"><see cref="BlueprintCharacterClassGroup"/></param>
    [Generated]
    [Implements(typeof(PlayerSignificantClassIs))]
    public static ConditionsBuilder AddPlayerSignificantClassIs(
        this ConditionsBuilder builder,
        Boolean CheckGroup,
        string m_CharacterClass,
        string m_CharacterClassGroup,
        Boolean Not)
    {
      builder.Validate(CheckGroup);
      builder.Validate(Not);
      
      var element = ElementTool.Create<PlayerSignificantClassIs>();
      element.CheckGroup = CheckGroup;
      element.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      element.m_CharacterClassGroup = BlueprintTool.GetRef<BlueprintCharacterClassGroupReference>(m_CharacterClassGroup);
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PlayerTopClassIs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_CharacterClassGroup"><see cref="BlueprintCharacterClassGroup"/></param>
    [Generated]
    [Implements(typeof(PlayerTopClassIs))]
    public static ConditionsBuilder AddPlayerTopClassIs(
        this ConditionsBuilder builder,
        Boolean CheckGroup,
        string m_CharacterClass,
        string m_CharacterClassGroup,
        Boolean Not)
    {
      builder.Validate(CheckGroup);
      builder.Validate(Not);
      
      var element = ElementTool.Create<PlayerTopClassIs>();
      element.CheckGroup = CheckGroup;
      element.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      element.m_CharacterClassGroup = BlueprintTool.GetRef<BlueprintCharacterClassGroupReference>(m_CharacterClassGroup);
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="QuestStatus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Quest"><see cref="BlueprintQuest"/></param>
    [Generated]
    [Implements(typeof(QuestStatus))]
    public static ConditionsBuilder AddQuestStatus(
        this ConditionsBuilder builder,
        string m_Quest,
        QuestState State,
        Boolean Not)
    {
      builder.Validate(State);
      builder.Validate(Not);
      
      var element = ElementTool.Create<QuestStatus>();
      element.m_Quest = BlueprintTool.GetRef<BlueprintQuestReference>(m_Quest);
      element.State = State;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RomanceLocked"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Romance"><see cref="BlueprintRomanceCounter"/></param>
    [Generated]
    [Implements(typeof(RomanceLocked))]
    public static ConditionsBuilder AddRomanceLocked(
        this ConditionsBuilder builder,
        string m_Romance,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<RomanceLocked>();
      element.m_Romance = BlueprintTool.GetRef<BlueprintRomanceCounterReference>(m_Romance);
      element.Not = Not;
      return builder.Add(element);
    }
  }
}
