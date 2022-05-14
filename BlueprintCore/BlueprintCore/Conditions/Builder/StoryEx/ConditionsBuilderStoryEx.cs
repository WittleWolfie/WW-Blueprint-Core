//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AreaLogic;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.AreaLogic.QuestSystem;
using Kingmaker.Assets.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.BarkBanters;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Quests;
using Kingmaker.Blueprints.Root;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.DialogSystem.Blueprints;
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>LootCondition</term><description>d1d246fc5c3df5d48aaee5dd199e75ab</description></item>
    /// <item><term>RighteousMight</term><description>90810e5cf53bf854293cbd5ea1066252</description></item>
    /// <item><term>RobeOfVirtueFeature</term><description>f3b1a7b396fc0b048b93967c6738708f</description></item>
    /// </list>
    /// </remarks>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon_FirstKTC_Ch5</term><description>a165ac24237977340b5bfceac10a67a8</description></item>
    /// <item><term>KTC_Malessa</term><description>ed0ec52c7c9cbcd4c87eaf97195da4a7</description></item>
    /// <item><term>YozzTeleportsToShamirasPalase</term><description>03e68d18fd2a47fc95917ba3f45d720d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="group">
    /// <para>
    /// InfoBox: Внутри этюда будет игнорировать сам этюд
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintEtudeConflictingGroup. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0008</term><description>a3a7361d053ff5741a1fa619c6882d87</description></item>
    /// <item><term>Answer_0238</term><description>74e958b78406e494ea5a1f702bdba1e1</description></item>
    /// <item><term>PF-277910</term><description>7792579c4cbc48eb896c9c0d3ef478cc</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="answersList">
    /// <para>
    /// Blueprint of type BlueprintAnswersList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="currentDialog">
    /// <para>
    /// Tooltip: Only check shown answer lists in current dialog instance. By default whole game history matters.
    /// </para>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AfterNotDate_dialog</term><description>cbe4991d3d5bad14dac33ca4e67ae2ce</description></item>
    /// <item><term>Answer_0042</term><description>f86429ebe97210a43ba15b53e387fac5</description></item>
    /// <item><term>YozzTeleportsToShamirasPalase</term><description>03e68d18fd2a47fc95917ba3f45d720d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="answer">
    /// <para>
    /// Blueprint of type BlueprintAnswer. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="currentDialog">
    /// <para>
    /// Tooltip: Only check selected answers in current dialog instance. By default whole game history matters.
    /// </para>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Banter_CameliaDaeran_banter7_pack2</term><description>9ee702a55f580d0489e3a2529681a691</description></item>
    /// <item><term>Banter_NenioLann_banter2</term><description>c4592758c5cc69548b7a69f8e4775841</description></item>
    /// <item><term>Banter_WoljifEmber_banter6</term><description>5a59dc95c91885a459a834e464c99a1f</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="banter">
    /// <para>
    /// Blueprint of type BlueprintBarkBanter. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
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
    /// Adds <see cref="CampaignCompleted"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC1_MythicPowersAfterCompletion</term><description>637667bed8e04ffdbf40de38794b6228</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="campaign">
    /// <para>
    /// Blueprint of type BlueprintCampaign. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder CampaignCompleted(
        this ConditionsBuilder builder,
        Blueprint<BlueprintCampaign, BlueprintCampaignReference>? campaign = null,
        bool negate = false)
    {
      var element = ElementTool.Create<CampaignCompleted>();
      element.m_Campaign = campaign?.Reference ?? element.m_Campaign;
      if (element.m_Campaign is null)
      {
        element.m_Campaign = BlueprintTool.GetRef<BlueprintCampaignReference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CheckFailed"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0018</term><description>8d05fd803d64f5c4ab9ffc8bf61d816b</description></item>
    /// <item><term>Cue_0084</term><description>203ef597927aeff45a02f5a766fafb82</description></item>
    /// <item><term>Cue_9</term><description>32716e33b77e4b6983a8dbcd2e128f49</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="check">
    /// <para>
    /// Blueprint of type BlueprintCheck. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0001</term><description>d902f8aff72348e882f84fc6aa9c8c2e</description></item>
    /// <item><term>Cue_0034</term><description>cab33f23f9c1f284eab13e33fbdc3df0</description></item>
    /// <item><term>ReiforceTrixterBefore</term><description>8e1bf1034cd7b6c449477b3888d2a659</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="check">
    /// <para>
    /// Blueprint of type BlueprintCheck. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
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
    /// Adds <see cref="CueSeen"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>[Kerz]_BarkCondition</term><description>59c232c2fa5e7c54baa235fee0e049d6</description></item>
    /// <item><term>BookPage_Room1Clean</term><description>e43df5891e0598e4d9f6583db03dff51</description></item>
    /// <item><term>ZanedraInTemple</term><description>0d22fd186d557a049b46c0fb3d623f04</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="cue">
    /// <para>
    /// Blueprint of type BlueprintCueBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="currentDialog">
    /// <para>
    /// Tooltip: Only check shown cues in current dialog instance. By default whole game history matters.
    /// </para>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Cue_0132</term><description>0267c6f5fd920ac41b57f5dc31a16201</description></item>
    /// <item><term>PF-332075_Restart_SosielRoman</term><description>52c5ed8b094e471fbe4eba0b4397082f</description></item>
    /// <item><term>PF-348009</term><description>f694fa0ccae94d6f8be56f7e0681613b</description></item>
    /// </list>
    /// </remarks>
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
    /// Adds <see cref="DayOfTheMonth"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0023</term><description>bb30ee6ab838dac4cba66ca2da58d394</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>EmberQ1_EmberPreachingInPrison</term><description>2d696d7e4ae237947832954d602dbaff</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonQ3Scene_DayTime</term><description>ffb3b99adfa368444b4a46ea36e5aec9</description></item>
    /// <item><term>VileniaStaysNearTavern</term><description>1fc25e220db7e0b49a2efbe45c43c0ed</description></item>
    /// <item><term>WenduagQ1Drill</term><description>76c88c9c00369e5419d8b0c70b67eef6</description></item>
    /// </list>
    /// </remarks>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>[MainHall] [Tall_DesnaPriest] Final_Bark_Conditions</term><description>7f8be13550ec4db894002cae58c9b811</description></item>
    /// <item><term>Banter_NenioSosielVaenic_banter1</term><description>4c20ae4ef35884f4f845fa42db620783</description></item>
    /// <item><term>ZigguratDeadRomanceTimer</term><description>587df869a564f7046a48bbf27f017619</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="dialog">
    /// <para>
    /// Blueprint of type BlueprintDialog. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>[DLC1_Taberdine]_BarkConditions</term><description>c1bbb11f93d44e13b5587d4c9701515d</description></item>
    /// <item><term>Cue_0006</term><description>8235006c1e10df244a3467c7b3900f2a</description></item>
    /// <item><term>ZombiesOnStreets</term><description>ffcf5bca11694784686d9947ed226a88</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="etude">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
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
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Condition/FlagInRange
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>10State_0</term><description>1f815765df0d4d7ba19f731dfa064081</description></item>
    /// <item><term>Cue_0047</term><description>85f8dd5f52684058b8f8266a140d6407</description></item>
    /// <item><term>Zacharius_FinalBetrayal_dialogue</term><description>5ec3e47a05de18c46b36f08c8dfbeafb</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="flag">
    /// <para>
    /// Blueprint of type BlueprintUnlockableFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
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
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Condition/FlagUnlocked
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>!Octavia_Companion_Warrior_Test</term><description>0f5938a10fd0d3644be33747d6d2b11c</description></item>
    /// <item><term>Cue_0004</term><description>b401438256f1c094abee4837b69be9c2</description></item>
    /// <item><term>ZigguratRiot</term><description>5ecb3695c95e4bd4b836a0deac1ecfd7</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="conditionFlag">
    /// <para>
    /// Blueprint of type BlueprintUnlockableFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="exceptSpecifiedValues">
    /// <para>
    /// Tooltip: False - white list. True - black list
    /// </para>
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
    /// Adds <see cref="IsCampaignImported"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC1_Levelup</term><description>dca1299c933b43dd8078cdf078ee6121</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="blueprintCampaign">
    /// <para>
    /// Blueprint of type BlueprintCampaign. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder IsCampaignImported(
        this ConditionsBuilder builder,
        Blueprint<BlueprintCampaign, BlueprintCampaignReference>? blueprintCampaign = null,
        bool negate = false)
    {
      var element = ElementTool.Create<IsCampaignImported>();
      element.m_BlueprintCampaign = blueprintCampaign?.Reference ?? element.m_BlueprintCampaign;
      if (element.m_BlueprintCampaign is null)
      {
        element.m_BlueprintCampaign = BlueprintTool.GetRef<BlueprintCampaignReference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsLegendPathSelected"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction1</term><description>bb530e9345434933ba412402ca787bf1</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0023</term><description>bb30ee6ab838dac4cba66ca2da58d394</description></item>
    /// </list>
    /// </remarks>
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
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Condition/ObjectiveStatus
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>!Octavia_Companion_Warrior_Test</term><description>0f5938a10fd0d3644be33747d6d2b11c</description></item>
    /// <item><term>Cue_0004</term><description>5abeda626d328fb4197d0732f345d691</description></item>
    /// <item><term>Ziggurat_ZachariusBeginRitual</term><description>8a020a9f01405ae4fa417500e1efd2e6</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="questObjective">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon_Chapter04_Quests</term><description>715233cf827adfe4e8a3e1adf8babad4</description></item>
    /// <item><term>Cue_0074_PleaseFix</term><description>17e298c6166609e438a721a714e7e7af</description></item>
    /// <item><term>TestCrusadeEvent</term><description>c8bcf035a7d947e09386fad55e986753</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Cue_0021</term><description>6d1aead07823d1642be37d05b37ee4ce</description></item>
    /// <item><term>Cue_0023</term><description>e44174a44be472249869b451f553bb0c</description></item>
    /// <item><term>Cue_0046</term><description>a60a1d0078dfc364494c50de8661930c</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Cue_0016</term><description>79b2d4385e23cc44bbb31bbe4044cb74</description></item>
    /// </list>
    /// </remarks>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0001</term><description>2a5615c36b154ef79b0f7bff878081a0</description></item>
    /// <item><term>Cue_0020</term><description>a66a6e34e9aa8d749921acdc7a0ae938</description></item>
    /// <item><term>Gift_From_Stranger_Notification</term><description>e688d0cd0791435eaf84bbe4561624bc</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="characterClass">
    /// <para>
    /// Blueprint of type BlueprintCharacterClass. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="characterClassGroup">
    /// <para>
    /// Blueprint of type BlueprintCharacterClassGroup. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Cue_0003</term><description>5ab2e262087a41ef9840818c0943ccfe</description></item>
    /// <item><term>Cue_0011</term><description>b52f80037fa9479b8cec3f0eb4f3d053</description></item>
    /// <item><term>Cue_9</term><description>5a3c9ac7639c47ac9489e9b840b6ce19</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="characterClass">
    /// <para>
    /// Blueprint of type BlueprintCharacterClass. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="characterClassGroup">
    /// <para>
    /// Blueprint of type BlueprintCharacterClassGroup. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
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
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Condition/QuestStatus
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>30_HeroicVictory</term><description>a43192eddffb455db6004059811ac92d</description></item>
    /// <item><term>Cue_0007</term><description>c614a833b23046b0b44a8548f01e2026</description></item>
    /// <item><term>ZigguratNoMoreLich</term><description>ca82ea555e8408c4e8839cdd5079e099</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="quest">
    /// <para>
    /// Blueprint of type BlueprintQuest. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
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
  }
}
