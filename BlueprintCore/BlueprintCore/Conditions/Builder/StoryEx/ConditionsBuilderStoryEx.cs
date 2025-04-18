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
using System.Linq;

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
    /// <item><term>KTC_Markyll</term><description>5f62cb2e58c073b47a529420b953ec8c</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder AnotherEtudeOfGroupIsPlaying(
        this ConditionsBuilder builder,
        Blueprint<BlueprintEtudeConflictingGroupReference>? group = null,
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
    /// <item><term>AnswersList_0001</term><description>e5da46510ef941a284e5280a914ec174</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="currentDialog">
    /// <para>
    /// Tooltip: Only check shown answer lists in current dialog instance. By default whole game history matters.
    /// </para>
    /// </param>
    public static ConditionsBuilder AnswerListShown(
        this ConditionsBuilder builder,
        Blueprint<BlueprintAnswersListReference>? answersList = null,
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
    /// <item><term>Answer_0042</term><description>512791c223017b44188a7f785c26e7c8</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="currentDialog">
    /// <para>
    /// Tooltip: Only check selected answers in current dialog instance. By default whole game history matters.
    /// </para>
    /// </param>
    public static ConditionsBuilder AnswerSelected(
        this ConditionsBuilder builder,
        Blueprint<BlueprintAnswerReference>? answer = null,
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder BarkBanterPlayed(
        this ConditionsBuilder builder,
        Blueprint<BlueprintBarkBanterReference>? banter = null,
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder CampaignCompleted(
        this ConditionsBuilder builder,
        Blueprint<BlueprintCampaignReference>? campaign = null,
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
    /// <item><term>Cue_0062</term><description>58f7300ad7ecc804ca03cdf989db589c</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder CheckFailed(
        this ConditionsBuilder builder,
        Blueprint<BlueprintCheckReference>? check = null,
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
    /// <item><term>Cue_0029</term><description>940ac039c81a0da4499e8f72291899f5</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder CheckPassed(
        this ConditionsBuilder builder,
        Blueprint<BlueprintCheckReference>? check = null,
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
    /// Adds <see cref="CompanionStoryUnlocked"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Condition/CompanionStoryUnlocked
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-390709_EvilArushaStory</term><description>e933ae2b386c45f4bd080bebb152ccfd</description></item>
    /// <item><term>PF-478038</term><description>4f81e1eb17d0488cb0577baadf4b7a21</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="companionStory">
    /// <para>
    /// Blueprint of type BlueprintCompanionStory. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder CompanionStoryUnlocked(
        this ConditionsBuilder builder,
        Blueprint<BlueprintCompanionStoryReference>? companionStory = null,
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>[Kerz]_BarkCondition</term><description>59c232c2fa5e7c54baa235fee0e049d6</description></item>
    /// <item><term>CommandAction</term><description>d2f944e7194b4990acfa69221125a2d1</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="currentDialog">
    /// <para>
    /// Tooltip: Only check shown cues in current dialog instance. By default whole game history matters.
    /// </para>
    /// </param>
    public static ConditionsBuilder CueSeen(
        this ConditionsBuilder builder,
        Blueprint<BlueprintCueBaseReference>? cue = null,
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
    /// <item><term>Answer_8</term><description>c3827533bf2b4c6ba276a53dcf826dc7</description></item>
    /// <item><term>PF-217333</term><description>e99f249471e442279e2687a1a5ef5264</description></item>
    /// <item><term>Ulbrig_KTC_JoiningInDrezen</term><description>cf15af283da744128648fd080eba1b4a</description></item>
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
    /// <item><term>DLC4_Wolf_Night</term><description>e06f060f459e4a6191e559fca3fd636a</description></item>
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
    /// <item><term>Banter_SeelahCamelia_banter3</term><description>c6771ab728dbc8048ac6544c520d757f</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder DialogSeen(
        this ConditionsBuilder builder,
        Blueprint<BlueprintDialogReference>? dialog = null,
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
    /// <item><term> DLC5_b2_warlord_dialogue </term><description>7044ec8b144e416395eae35d5a2eba82</description></item>
    /// <item><term>Cue_0010</term><description>690c66a7a25c0fa4f86ed3def55aa47b</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder EtudeStatus(
        this ConditionsBuilder builder,
        bool? completed = null,
        bool? completionInProgress = null,
        Blueprint<BlueprintEtudeReference>? etude = null,
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
    /// <item><term>Cue_0039</term><description>cd1da96cf45e49c0ab54c5b5f98dec4e</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder FlagInRange(
        this ConditionsBuilder builder,
        Blueprint<BlueprintUnlockableFlagReference>? flag = null,
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
    /// <item><term>Cue_0011</term><description>117e49a3a1c723f4ba906fa311abbfd5</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="exceptSpecifiedValues">
    /// <para>
    /// Tooltip: False - white list. True - black list
    /// </para>
    /// </param>
    public static ConditionsBuilder FlagUnlocked(
        this ConditionsBuilder builder,
        Blueprint<BlueprintUnlockableFlagReference>? conditionFlag = null,
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
    /// Adds <see cref="IsCampaign"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0006</term><description>13e54e84a1344930b2d35ec4fba205ff</description></item>
    /// <item><term>Cue_0029</term><description>323a1a0007534614907ab14bf9e1b78f</description></item>
    /// <item><term>Ship_translocate</term><description>2b46c98f1687478e93b8625670f996ba</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder IsCampaign(
        this ConditionsBuilder builder,
        Blueprint<BlueprintCampaignReference>? blueprintCampaign = null,
        bool negate = false)
    {
      var element = ElementTool.Create<IsCampaign>();
      element.m_BlueprintCampaign = blueprintCampaign?.Reference ?? element.m_BlueprintCampaign;
      if (element.m_BlueprintCampaign is null)
      {
        element.m_BlueprintCampaign = BlueprintTool.GetRef<BlueprintCampaignReference>(null);
      }
      element.Not = negate;
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
    /// <item><term>Answer_0001</term><description>25507e334eab48a49c148163a087f190</description></item>
    /// <item><term>DLC5_FrozenTemplePart</term><description>ee12fc5bb7d446fdb1f2b0fb8c81a6de</description></item>
    /// <item><term>Sendri_DefaultActor</term><description>fbdd6de122cd4c8899e230778c20d0d3</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder IsCampaignImported(
        this ConditionsBuilder builder,
        Blueprint<BlueprintCampaignReference>? blueprintCampaign = null,
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
    /// <item><term>Cue_0017</term><description>ff4e4a3b7de5327499fa491cc8398ffc</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder ObjectiveStatus(
        this ConditionsBuilder builder,
        bool negate = false,
        Blueprint<BlueprintQuestObjectiveReference>? questObjective = null,
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
    /// <item><term>Cue_0071</term><description>68b586541d285f846b21fb140b485a1a</description></item>
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
    /// <item><term>Cue_0060</term><description>6ea88ed6d7ac02c42b1eb4d641db14ad</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="characterClassGroup">
    /// <para>
    /// Blueprint of type BlueprintCharacterClassGroup. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder PlayerSignificantClassIs(
        this ConditionsBuilder builder,
        Blueprint<BlueprintCharacterClassReference>? characterClass = null,
        Blueprint<BlueprintCharacterClassGroupReference>? characterClassGroup = null,
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="characterClassGroup">
    /// <para>
    /// Blueprint of type BlueprintCharacterClassGroup. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder PlayerTopClassIs(
        this ConditionsBuilder builder,
        Blueprint<BlueprintCharacterClassReference>? characterClass = null,
        Blueprint<BlueprintCharacterClassGroupReference>? characterClassGroup = null,
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
    /// <item><term>Cue_0019</term><description>3e21e0f399982e74a8cca273b331e5b9</description></item>
    /// <item><term>ZigguratNoMoreLichTransition</term><description>857ac3ee06be46688c1040033fd2224a</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder QuestStatus(
        this ConditionsBuilder builder,
        bool negate = false,
        Blueprint<BlueprintQuestReference>? quest = null,
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
