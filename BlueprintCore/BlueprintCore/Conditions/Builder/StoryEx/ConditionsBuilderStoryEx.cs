//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AreaLogic;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.AreaLogic.QuestSystem;
using Kingmaker.Assets.Code.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Assets.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.BarkBanters;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Quests;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Alignments;
using System;
using System.Collections.Generic;

namespace BlueprintCore.Conditions.Builder.StoryEx
{
  /// <summary>
  /// Extension to <see cref="ConditionsBuilder"/> for conditions related to the story such as companion stories, quests, name changes, and etudes.
  /// </summary>
  /// <inheritdoc cref="ConditionsBuilder"/>
  public static class ConditionsBuilderStoryEx
  {

    /// <summary>
    /// Adds <see cref="AlignmentCheck"/>
    /// </summary>
    public static ConditionsBuilder AlignmentCheck(
        this ConditionsBuilder builder,
        AlignmentComponent? alignment = null,
        bool negate = false)
    {
      var element = ElementTool.Create<AlignmentCheck>();
      element.Alignment = alignment ?? element.Alignment;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AnotherEtudeOfGroupIsPlaying"/>
    /// </summary>
    ///
    /// <param name="group">
    /// Blueprint of type BlueprintEtudeConflictingGroup. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder AnotherEtudeOfGroupIsPlaying(
        this ConditionsBuilder builder,
        Blueprint<BlueprintEtudeConflictingGroup, BlueprintEtudeConflictingGroupReference>? group = null,
        bool negate = false)
    {
      var element = ElementTool.Create<AnotherEtudeOfGroupIsPlaying>();
      element.m_Group = group?.Reference ?? element.m_Group;
      if (element.m_Group is null)
      {
        element.m_Group = BlueprintTool.GetRef<BlueprintEtudeConflictingGroupReference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AnswerListShown"/>
    /// </summary>
    ///
    /// <param name="answersList">
    /// Blueprint of type BlueprintAnswersList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder AnswerListShown(
        this ConditionsBuilder builder,
        Blueprint<BlueprintAnswersList, BlueprintAnswersListReference>? answersList = null,
        bool? currentDialog = null,
        bool negate = false)
    {
      var element = ElementTool.Create<AnswerListShown>();
      element.m_AnswersList = answersList?.Reference ?? element.m_AnswersList;
      if (element.m_AnswersList is null)
      {
        element.m_AnswersList = BlueprintTool.GetRef<BlueprintAnswersListReference>(null);
      }
      element.CurrentDialog = currentDialog ?? element.CurrentDialog;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AnswerSelected"/>
    /// </summary>
    ///
    /// <param name="answer">
    /// Blueprint of type BlueprintAnswer. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder AnswerSelected(
        this ConditionsBuilder builder,
        Blueprint<BlueprintAnswer, BlueprintAnswerReference>? answer = null,
        bool? currentDialog = null,
        bool negate = false)
    {
      var element = ElementTool.Create<AnswerSelected>();
      element.m_Answer = answer?.Reference ?? element.m_Answer;
      if (element.m_Answer is null)
      {
        element.m_Answer = BlueprintTool.GetRef<BlueprintAnswerReference>(null);
      }
      element.CurrentDialog = currentDialog ?? element.CurrentDialog;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="BarkBanterPlayed"/>
    /// </summary>
    ///
    /// <param name="banter">
    /// Blueprint of type BlueprintBarkBanter. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder BarkBanterPlayed(
        this ConditionsBuilder builder,
        Blueprint<BlueprintBarkBanter, BlueprintBarkBanterReference>? banter = null,
        bool negate = false)
    {
      var element = ElementTool.Create<BarkBanterPlayed>();
      element.m_Banter = banter?.Reference ?? element.m_Banter;
      if (element.m_Banter is null)
      {
        element.m_Banter = BlueprintTool.GetRef<BlueprintBarkBanterReference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangeableDynamicIsLoaded"/>
    /// </summary>
    public static ConditionsBuilder ChangeableDynamicIsLoaded(
        this ConditionsBuilder builder,
        bool negate = false,
        SceneReference? scene = null)
    {
      var element = ElementTool.Create<ChangeableDynamicIsLoaded>();
      element.Not = negate;
      builder.Validate(scene);
      element.Scene = scene ?? element.Scene;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CheckFailed"/>
    /// </summary>
    ///
    /// <param name="check">
    /// Blueprint of type BlueprintCheck. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder CheckFailed(
        this ConditionsBuilder builder,
        Blueprint<BlueprintCheck, BlueprintCheckReference>? check = null,
        bool negate = false)
    {
      var element = ElementTool.Create<CheckFailed>();
      element.m_Check = check?.Reference ?? element.m_Check;
      if (element.m_Check is null)
      {
        element.m_Check = BlueprintTool.GetRef<BlueprintCheckReference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CheckPassed"/>
    /// </summary>
    ///
    /// <param name="check">
    /// Blueprint of type BlueprintCheck. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder CheckPassed(
        this ConditionsBuilder builder,
        Blueprint<BlueprintCheck, BlueprintCheckReference>? check = null,
        bool negate = false)
    {
      var element = ElementTool.Create<CheckPassed>();
      element.m_Check = check?.Reference ?? element.m_Check;
      if (element.m_Check is null)
      {
        element.m_Check = BlueprintTool.GetRef<BlueprintCheckReference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CheckUnitSeeUnit"/>
    /// </summary>
    public static ConditionsBuilder CheckUnitSeeUnit(
        this ConditionsBuilder builder,
        bool negate = false,
        UnitEvaluator? target = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<CheckUnitSeeUnit>();
      element.Not = negate;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CompanionStoryUnlocked"/>
    /// </summary>
    ///
    /// <param name="companionStory">
    /// Blueprint of type BlueprintCompanionStory. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder CompanionStoryUnlocked(
        this ConditionsBuilder builder,
        Blueprint<BlueprintCompanionStory, BlueprintCompanionStoryReference>? companionStory = null,
        bool negate = false)
    {
      var element = ElementTool.Create<CompanionStoryUnlocked>();
      element.m_CompanionStory = companionStory?.Reference ?? element.m_CompanionStory;
      if (element.m_CompanionStory is null)
      {
        element.m_CompanionStory = BlueprintTool.GetRef<BlueprintCompanionStoryReference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CueSeen"/>
    /// </summary>
    ///
    /// <param name="cue">
    /// Blueprint of type BlueprintCueBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder CueSeen(
        this ConditionsBuilder builder,
        Blueprint<BlueprintCueBase, BlueprintCueBaseReference>? cue = null,
        bool? currentDialog = null,
        bool negate = false)
    {
      var element = ElementTool.Create<CueSeen>();
      element.m_Cue = cue?.Reference ?? element.m_Cue;
      if (element.m_Cue is null)
      {
        element.m_Cue = BlueprintTool.GetRef<BlueprintCueBaseReference>(null);
      }
      element.CurrentDialog = currentDialog ?? element.CurrentDialog;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CurrentChapter"/>
    /// </summary>
    public static ConditionsBuilder CurrentChapter(
        this ConditionsBuilder builder,
        int? chapter = null,
        bool negate = false)
    {
      var element = ElementTool.Create<CurrentChapter>();
      element.Chapter = chapter ?? element.Chapter;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CutsceneQueueState"/>
    /// </summary>
    public static ConditionsBuilder CutsceneQueueState(
        this ConditionsBuilder builder,
        bool? first = null,
        bool? last = null,
        bool negate = false)
    {
      var element = ElementTool.Create<CutsceneQueueState>();
      element.First = first ?? element.First;
      element.Last = last ?? element.Last;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DayOfTheMonth"/>
    /// </summary>
    public static ConditionsBuilder DayOfTheMonth(
        this ConditionsBuilder builder,
        int? day = null,
        bool negate = false)
    {
      var element = ElementTool.Create<DayOfTheMonth>();
      element.Day = day ?? element.Day;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DayOfTheWeek"/>
    /// </summary>
    public static ConditionsBuilder DayOfTheWeek(
        this ConditionsBuilder builder,
        DayOfWeek? day = null,
        bool negate = false)
    {
      var element = ElementTool.Create<DayOfTheWeek>();
      element.Day = day ?? element.Day;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DayTime"/>
    /// </summary>
    public static ConditionsBuilder DayTime(
        this ConditionsBuilder builder,
        bool negate = false,
        TimeOfDay? time = null)
    {
      var element = ElementTool.Create<DayTime>();
      element.Not = negate;
      element.Time = time ?? element.Time;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DialogSeen"/>
    /// </summary>
    ///
    /// <param name="dialog">
    /// Blueprint of type BlueprintDialog. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder DialogSeen(
        this ConditionsBuilder builder,
        Blueprint<BlueprintDialog, BlueprintDialogReference>? dialog = null,
        bool negate = false)
    {
      var element = ElementTool.Create<DialogSeen>();
      element.m_Dialog = dialog?.Reference ?? element.m_Dialog;
      if (element.m_Dialog is null)
      {
        element.m_Dialog = BlueprintTool.GetRef<BlueprintDialogReference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="EtudeStatus"/>
    /// </summary>
    ///
    /// <param name="etude">
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder EtudeStatus(
        this ConditionsBuilder builder,
        bool? completed = null,
        bool? completionInProgress = null,
        Blueprint<BlueprintEtude, BlueprintEtudeReference>? etude = null,
        bool negate = false,
        bool? notStarted = null,
        bool? playing = null,
        bool? started = null)
    {
      var element = ElementTool.Create<EtudeStatus>();
      element.Completed = completed ?? element.Completed;
      element.CompletionInProgress = completionInProgress ?? element.CompletionInProgress;
      element.m_Etude = etude?.Reference ?? element.m_Etude;
      if (element.m_Etude is null)
      {
        element.m_Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(null);
      }
      element.Not = negate;
      element.NotStarted = notStarted ?? element.NotStarted;
      element.Playing = playing ?? element.Playing;
      element.Started = started ?? element.Started;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="FlagInRange"/>
    /// </summary>
    ///
    /// <param name="flag">
    /// Blueprint of type BlueprintUnlockableFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder FlagInRange(
        this ConditionsBuilder builder,
        Blueprint<BlueprintUnlockableFlag, BlueprintUnlockableFlagReference>? flag = null,
        int? maxValue = null,
        int? minValue = null,
        bool negate = false)
    {
      var element = ElementTool.Create<FlagInRange>();
      element.m_Flag = flag?.Reference ?? element.m_Flag;
      if (element.m_Flag is null)
      {
        element.m_Flag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(null);
      }
      element.MaxValue = maxValue ?? element.MaxValue;
      element.MinValue = minValue ?? element.MinValue;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="FlagUnlocked"/>
    /// </summary>
    ///
    /// <param name="conditionFlag">
    /// Blueprint of type BlueprintUnlockableFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder FlagUnlocked(
        this ConditionsBuilder builder,
        Blueprint<BlueprintUnlockableFlag, BlueprintUnlockableFlagReference>? conditionFlag = null,
        bool? exceptSpecifiedValues = null,
        bool negate = false,
        List<int>? specifiedValues = null)
    {
      var element = ElementTool.Create<FlagUnlocked>();
      element.m_ConditionFlag = conditionFlag?.Reference ?? element.m_ConditionFlag;
      if (element.m_ConditionFlag is null)
      {
        element.m_ConditionFlag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(null);
      }
      element.ExceptSpecifiedValues = exceptSpecifiedValues ?? element.ExceptSpecifiedValues;
      element.Not = negate;
      element.SpecifiedValues = specifiedValues ?? element.SpecifiedValues;
      if (element.SpecifiedValues is null)
      {
        element.SpecifiedValues = new();
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsLegendPathSelected"/>
    /// </summary>
    public static ConditionsBuilder IsLegendPathSelected(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<IsLegendPathSelected>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MonthFromList"/>
    /// </summary>
    public static ConditionsBuilder MonthFromList(
        this ConditionsBuilder builder,
        int[]? months = null,
        bool negate = false)
    {
      var element = ElementTool.Create<MonthFromList>();
      element.Months = months ?? element.Months;
      if (element.Months is null)
      {
        element.Months = new int[0];
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ObjectiveStatus"/>
    /// </summary>
    ///
    /// <param name="questObjective">
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder ObjectiveStatus(
        this ConditionsBuilder builder,
        bool negate = false,
        Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference>? questObjective = null,
        QuestObjectiveState? state = null)
    {
      var element = ElementTool.Create<ObjectiveStatus>();
      element.Not = negate;
      element.m_QuestObjective = questObjective?.Reference ?? element.m_QuestObjective;
      if (element.m_QuestObjective is null)
      {
        element.m_QuestObjective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(null);
      }
      element.State = state ?? element.State;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PlayerAlignmentIs"/>
    /// </summary>
    public static ConditionsBuilder PlayerAlignmentIs(
        this ConditionsBuilder builder,
        AlignmentMaskType? alignment = null,
        bool negate = false)
    {
      var element = ElementTool.Create<PlayerAlignmentIs>();
      element.Alignment = alignment ?? element.Alignment;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PlayerHasNoCharactersOnRoster"/>
    /// </summary>
    public static ConditionsBuilder PlayerHasNoCharactersOnRoster(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<PlayerHasNoCharactersOnRoster>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PlayerHasRecruitsOnRoster"/>
    /// </summary>
    public static ConditionsBuilder PlayerHasRecruitsOnRoster(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<PlayerHasRecruitsOnRoster>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PlayerSignificantClassIs"/>
    /// </summary>
    ///
    /// <param name="characterClass">
    /// Blueprint of type BlueprintCharacterClass. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="characterClassGroup">
    /// Blueprint of type BlueprintCharacterClassGroup. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder PlayerSignificantClassIs(
        this ConditionsBuilder builder,
        Blueprint<BlueprintCharacterClass, BlueprintCharacterClassReference>? characterClass = null,
        Blueprint<BlueprintCharacterClassGroup, BlueprintCharacterClassGroupReference>? characterClassGroup = null,
        bool? checkGroup = null,
        bool negate = false)
    {
      var element = ElementTool.Create<PlayerSignificantClassIs>();
      element.m_CharacterClass = characterClass?.Reference ?? element.m_CharacterClass;
      if (element.m_CharacterClass is null)
      {
        element.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(null);
      }
      element.m_CharacterClassGroup = characterClassGroup?.Reference ?? element.m_CharacterClassGroup;
      if (element.m_CharacterClassGroup is null)
      {
        element.m_CharacterClassGroup = BlueprintTool.GetRef<BlueprintCharacterClassGroupReference>(null);
      }
      element.CheckGroup = checkGroup ?? element.CheckGroup;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PlayerTopClassIs"/>
    /// </summary>
    ///
    /// <param name="characterClass">
    /// Blueprint of type BlueprintCharacterClass. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="characterClassGroup">
    /// Blueprint of type BlueprintCharacterClassGroup. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder PlayerTopClassIs(
        this ConditionsBuilder builder,
        Blueprint<BlueprintCharacterClass, BlueprintCharacterClassReference>? characterClass = null,
        Blueprint<BlueprintCharacterClassGroup, BlueprintCharacterClassGroupReference>? characterClassGroup = null,
        bool? checkGroup = null,
        bool negate = false)
    {
      var element = ElementTool.Create<PlayerTopClassIs>();
      element.m_CharacterClass = characterClass?.Reference ?? element.m_CharacterClass;
      if (element.m_CharacterClass is null)
      {
        element.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(null);
      }
      element.m_CharacterClassGroup = characterClassGroup?.Reference ?? element.m_CharacterClassGroup;
      if (element.m_CharacterClassGroup is null)
      {
        element.m_CharacterClassGroup = BlueprintTool.GetRef<BlueprintCharacterClassGroupReference>(null);
      }
      element.CheckGroup = checkGroup ?? element.CheckGroup;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="QuestStatus"/>
    /// </summary>
    ///
    /// <param name="quest">
    /// Blueprint of type BlueprintQuest. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder QuestStatus(
        this ConditionsBuilder builder,
        bool negate = false,
        Blueprint<BlueprintQuest, BlueprintQuestReference>? quest = null,
        QuestState? state = null)
    {
      var element = ElementTool.Create<QuestStatus>();
      element.Not = negate;
      element.m_Quest = quest?.Reference ?? element.m_Quest;
      if (element.m_Quest is null)
      {
        element.m_Quest = BlueprintTool.GetRef<BlueprintQuestReference>(null);
      }
      element.State = state ?? element.State;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RomanceLocked"/>
    /// </summary>
    ///
    /// <param name="romance">
    /// Blueprint of type BlueprintRomanceCounter. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder RomanceLocked(
        this ConditionsBuilder builder,
        bool negate = false,
        Blueprint<BlueprintRomanceCounter, BlueprintRomanceCounterReference>? romance = null)
    {
      var element = ElementTool.Create<RomanceLocked>();
      element.Not = negate;
      element.m_Romance = romance?.Reference ?? element.m_Romance;
      if (element.m_Romance is null)
      {
        element.m_Romance = BlueprintTool.GetRef<BlueprintRomanceCounterReference>(null);
      }
      return builder.Add(element);
    }
  }
}
