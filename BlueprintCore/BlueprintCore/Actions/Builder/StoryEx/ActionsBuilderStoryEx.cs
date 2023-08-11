//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AreaLogic;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.NamedParameters;
using Kingmaker.Designers.Quests.Common;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.UI;
using Kingmaker.UnitLogic.Alignments;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Actions.Builder.StoryEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for actions related to the story such as companion stories, quests, name changes, and etudes.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderStoryEx
  {

    /// <summary>
    /// Adds <see cref="CompleteEtude"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>03_SanctumBosses</term><description>d44f91b07f9914349aa0b6c082d98c25</description></item>
    /// <item><term>Cue_0059</term><description>4a26cafe16d65de438c948ca7c824b9e</description></item>
    /// <item><term>ZigguratActive</term><description>6716edd224e0d4049a55030f4d01c8ed</description></item>
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
    public static ActionsBuilder CompleteEtude(
        this ActionsBuilder builder,
        Blueprint<BlueprintEtudeReference> etude,
        BlueprintEvaluator? etudeEvaluator = null)
    {
      var element = ElementTool.Create<CompleteEtude>();
      element.Etude = etude?.Reference;
      builder.Validate(etudeEvaluator);
      element.EtudeEvaluator = etudeEvaluator ?? element.EtudeEvaluator;
      element.Evaluate = etudeEvaluator is not null;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangeUnitName"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonQ10_DuringQuest</term><description>fb99a426b8bf1f247a2272920a1fd13d</description></item>
    /// <item><term>Cue_0034</term><description>0c6bc0a3700c34c4f99e8f09d9758662</description></item>
    /// <item><term>ThresholdCamp_Scripts03</term><description>21cfdbf1fe184c7e9325ec071d06fbd2</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="newName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public static ActionsBuilder ChangeUnitName(
        this ActionsBuilder builder,
        LocalString newName,
        UnitEvaluator unit,
        bool? addToTheName = null)
    {
      var element = ElementTool.Create<ChangeUnitName>();
      element.NewName = newName?.LocalizedString;
      builder.Validate(unit);
      element.Unit = unit;
      element.AddToTheName = addToTheName ?? element.AddToTheName;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangeUnitName"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonQ10_DuringQuest</term><description>fb99a426b8bf1f247a2272920a1fd13d</description></item>
    /// <item><term>Cue_0034</term><description>0c6bc0a3700c34c4f99e8f09d9758662</description></item>
    /// <item><term>ThresholdCamp_Scripts03</term><description>21cfdbf1fe184c7e9325ec071d06fbd2</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder ResetUnitName(
        this ActionsBuilder builder,
        UnitEvaluator unit)
    {
      var element = ElementTool.Create<ChangeUnitName>();
      builder.Validate(unit);
      element.Unit = unit;
      element.ReturnTheOldName = true;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ClearQuestsOnAutoKingdom"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-456340</term><description>d4dafb9d6ac9417e8eb8a8b4f13166cc</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder ClearQuestsOnAutoKingdom(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ClearQuestsOnAutoKingdom>());
    }

    /// <summary>
    /// Adds <see cref="DismissAllCompanions"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>3300820c09d5401cad71f932e41b6449</description></item>
    /// <item><term>MythicLocustC5_Reborn_Dialogue</term><description>ed50bd741b39e544ea97997d5e1de457</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder DismissAllCompanions(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<DismissAllCompanions>());
    }

    /// <summary>
    /// Adds <see cref="GiveObjective"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/GiveObjective
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>02_ScoutsDead_objZone</term><description>3ffadf67fe817d444b1cb9c6cff78744</description></item>
    /// <item><term>Cue_0031</term><description>80fb1da0d62dd0048a4f9600617fca40</description></item>
    /// <item><term>ZoeyPendantTeleport</term><description>9a90929e2db1be448b495509170a4251</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="objective">
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
    public static ActionsBuilder GiveObjective(
        this ActionsBuilder builder,
        Blueprint<BlueprintQuestObjectiveReference>? objective = null)
    {
      var element = ElementTool.Create<GiveObjective>();
      element.m_Objective = objective?.Reference ?? element.m_Objective;
      if (element.m_Objective is null)
      {
        element.m_Objective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HideUnit"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>[Nocticula]_SpawnActions</term><description>d77f996b50fad684bb0435c1d12a526d</description></item>
    /// <item><term>CommandAction3</term><description>4b8ff1a81e4746e0af33158d5483b6d5</description></item>
    /// <item><term>ZigguratZachariusInZiggurat</term><description>2844d387f27a0bb468f72603dd15eda2</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder HideUnit(
        this ActionsBuilder builder,
        bool? fade = null,
        UnitEvaluator? target = null,
        bool? unhide = null)
    {
      var element = ElementTool.Create<HideUnit>();
      element.Fade = fade ?? element.Fade;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      element.Unhide = unhide ?? element.Unhide;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HideWeapons"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/HideWeapons
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AfterFinalDIalog_EpicRelief</term><description>2fa48a4ad45a0f64d8f2881ff9802dd8</description></item>
    /// <item><term>Daeran_Q2_Stage_2</term><description>504306e194b725f44b4bde54453eba89</description></item>
    /// <item><term>WoundedInCamp_SpawnActions</term><description>e714318adb3985b4eaecfb632bb9c31b</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder HideWeapons(
        this ActionsBuilder builder,
        bool? hide = null,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<HideWeapons>();
      element.Hide = hide ?? element.Hide;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IncrementFlagValue"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/IncrementFlagValue
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>26!_SadisticGD_Checker_restTrigger</term><description>7bc48a5ec7e240e1a059148777166ba7</description></item>
    /// <item><term>Burn_PlayerDream_Actions</term><description>3693a985cf4ff5c44a6683021e940655</description></item>
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
    public static ActionsBuilder IncrementFlagValue(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnlockableFlagReference>? flag = null,
        bool? unlockIfNot = null,
        IntEvaluator? value = null)
    {
      var element = ElementTool.Create<IncrementFlagValue>();
      element.m_Flag = flag?.Reference ?? element.m_Flag;
      if (element.m_Flag is null)
      {
        element.m_Flag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(null);
      }
      element.UnlockIfNot = unlockIfNot ?? element.UnlockIfNot;
      builder.Validate(value);
      element.Value = value ?? element.Value;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="InterruptAllActions"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Ch5_QueenInDrezen_Mechanic</term><description>46bd4af031b869248b305629b396d6c2</description></item>
    /// <item><term>CommandAction 3</term><description>919e1dc652bbe8d4db8b508644866899</description></item>
    /// <item><term>WayUp_Actions</term><description>83d0eb422bd7e774eb1710025088ed0f</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder InterruptAllActions(
        this ActionsBuilder builder,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<InterruptAllActions>();
      builder.Validate(unit);
      element.m_Unit = unit ?? element.m_Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="LockAlignment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>05_BeLegend</term><description>31934f4d6e497944a8da7c2954fdc64a</description></item>
    /// <item><term>Cue_0043</term><description>e60784dcd0c89594e90636a54b6ae3c8</description></item>
    /// <item><term>PlayerIsTrickster</term><description>9f486a9c0c9abfc4a952bb22e88a7e96</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="alignmentMask">
    /// <para>
    /// InfoBox: Current unit alignment will be shifted to the nearest available sector. None selected =&amp;gt; removes locking and current alignment remains.
    /// </para>
    /// </param>
    /// <param name="targetAlignment">
    /// <para>
    /// InfoBox: Considered as initial alignment. This is usually sector&amp;apos;s center (LG for Angel, NE for Lich) Will be ignored for `None` mask (all or none square selected)
    /// </para>
    /// </param>
    public static ActionsBuilder LockAlignment(
        this ActionsBuilder builder,
        AlignmentMaskType? alignmentMask = null,
        Alignment? targetAlignment = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<LockAlignment>();
      element.AlignmentMask = alignmentMask ?? element.AlignmentMask;
      element.TargetAlignment = targetAlignment ?? element.TargetAlignment;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="LockFlag"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/LockFlag
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>2Wave</term><description>4e1dcba08c1e4a89aea4aaa07f8f89ae</description></item>
    /// <item><term>DLC2_Sv_Back_to_Camp</term><description>a5d1dcfc715243c98e4f958435c52be4</description></item>
    /// <item><term>Wintersun_Default</term><description>87839550c801db944b102f61084fd245</description></item>
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
    public static ActionsBuilder LockFlag(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnlockableFlagReference>? flag = null)
    {
      var element = ElementTool.Create<LockFlag>();
      element.m_Flag = flag?.Reference ?? element.m_Flag;
      if (element.m_Flag is null)
      {
        element.m_Flag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MarkAnswersSelected"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0010</term><description>256754d9917f45d2835490b33d376f45</description></item>
    /// <item><term>Answer_0112</term><description>bdd52f320db765e44adc09990797cf6e</description></item>
    /// <item><term>MarhevokMain_dialogue</term><description>da43f91cbb6a4e289e30b5da85f4c871</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="answers">
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
    public static ActionsBuilder MarkAnswersSelected(this ActionsBuilder builder, params Blueprint<BlueprintAnswerReference>[] answers)
    {
      var element = ElementTool.Create<MarkAnswersSelected>();
      element.m_Answers = answers.Select(bp => bp.Reference).ToArray();
      if (element.m_Answers is null)
      {
        element.m_Answers = new BlueprintAnswerReference[0];
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MarkCuesSeen"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0004</term><description>f866dffcf5d343c4c9954b80fe261d12</description></item>
    /// <item><term>Answer_0005</term><description>40acb258ff09dd34fb6b5fa14b7293d5</description></item>
    /// <item><term>Answer_0006</term><description>162c5317b3fc6904293119850da3e749</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="cues">
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
    public static ActionsBuilder MarkCuesSeen(this ActionsBuilder builder, params Blueprint<BlueprintCueBaseReference>[] cues)
    {
      var element = ElementTool.Create<MarkCuesSeen>();
      element.m_Cues = cues.Select(bp => bp.Reference).ToArray();
      if (element.m_Cues is null)
      {
        element.m_Cues = new BlueprintCueBaseReference[0];
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MoveAzataIslandToLocation"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AzataIsland_GlobalSpell</term><description>765b5d6d0e6f4505a6471db58b3fa6ce</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="globalMap">
    /// <para>
    /// Blueprint of type BlueprintGlobalMap. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="location">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder MoveAzataIslandToLocation(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMap.Reference>? globalMap = null,
        Blueprint<BlueprintGlobalMapPoint.Reference>? location = null)
    {
      var element = ElementTool.Create<MoveAzataIslandToLocation>();
      element.m_GlobalMap = globalMap?.Reference ?? element.m_GlobalMap;
      if (element.m_GlobalMap is null)
      {
        element.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMap.Reference>(null);
      }
      element.m_Location = location?.Reference ?? element.m_Location;
      if (element.m_Location is null)
      {
        element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MoveAzataIslandToNearestCrossroad"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GlobalSpellAzataSummonIsland</term><description>efa3f3db644a459e91bc05da1371b045</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="globalMap">
    /// <para>
    /// Blueprint of type BlueprintGlobalMap. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder MoveAzataIslandToNearestCrossroad(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMap.Reference>? globalMap = null)
    {
      var element = ElementTool.Create<MoveAzataIslandToNearestCrossroad>();
      element.m_GlobalMap = globalMap?.Reference ?? element.m_GlobalMap;
      if (element.m_GlobalMap is null)
      {
        element.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMap.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="OverrideUnitReturnPosition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Assault</term><description>bf453dba07efed44db2ce4f69bf72bc4</description></item>
    /// <item><term>CommandAction 10</term><description>a83273816d00a41439bd31e62abcbc16</description></item>
    /// <item><term>Pulura_Stage_2.3_OutdoorBattle</term><description>81643e1d577dfd945985eca65a261510</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder OverrideUnitReturnPosition(
        this ActionsBuilder builder,
        FloatEvaluator? orientation = null,
        PositionEvaluator? position = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<OverrideUnitReturnPosition>();
      builder.Validate(orientation);
      element.Orientation = orientation ?? element.Orientation;
      builder.Validate(position);
      element.Position = position ?? element.Position;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PartyMembersAttach"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>e9824e45f9edf664595e1b8a98996094</description></item>
    /// <item><term>CommandAction1</term><description>02be6f61530c48d1bebb91e00c02a5d5</description></item>
    /// <item><term>WenduagQ1</term><description>fb5bb4409b95c07488e0e06f71c1c2ad</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder PartyMembersAttach(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<PartyMembersAttach>());
    }

    /// <summary>
    /// Adds <see cref="PartyMembersDetach"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>a997885cb2dfec7458da8565b0ce4d26</description></item>
    /// <item><term>Cue_0014</term><description>0a84b4f3ffa209b4d8af7187b3bedd10</description></item>
    /// <item><term>SosielMeetsTrever</term><description>81acdfdea46f56d49b39f140f23a242c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="detachAllExcept">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder PartyMembersDetach(
        this ActionsBuilder builder,
        ActionsBuilder? afterDetach = null,
        List<Blueprint<BlueprintUnitReference>>? detachAllExcept = null,
        int? partySize = null,
        bool? restrictPartySize = null)
    {
      var element = ElementTool.Create<PartyMembersDetach>();
      element.AfterDetach = afterDetach?.Build() ?? element.AfterDetach;
      if (element.AfterDetach is null)
      {
        element.AfterDetach = Utils.Constants.Empty.Actions;
      }
      element.m_DetachAllExcept = detachAllExcept?.Select(bp => bp.Reference)?.ToArray() ?? element.m_DetachAllExcept;
      if (element.m_DetachAllExcept is null)
      {
        element.m_DetachAllExcept = new BlueprintUnitReference[0];
      }
      element.m_PartySize = partySize ?? element.m_PartySize;
      element.m_RestrictPartySize = restrictPartySize ?? element.m_RestrictPartySize;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PartyMembersDetachEvaluated"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AfterNotDate_dialog</term><description>cbe4991d3d5bad14dac33ca4e67ae2ce</description></item>
    /// <item><term>Cue_0023</term><description>8324aaaafc557d34386fff05f9301881</description></item>
    /// <item><term>VaultOfGraves_MythicDemonChapter03</term><description>e3fb405c90492e946a02e176a10268ef</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder PartyMembersDetachEvaluated(
        this ActionsBuilder builder,
        ActionsBuilder? afterDetach = null,
        UnitEvaluator[]? detachThese = null,
        int? partySize = null,
        bool? restrictPartySize = null)
    {
      var element = ElementTool.Create<PartyMembersDetachEvaluated>();
      element.AfterDetach = afterDetach?.Build() ?? element.AfterDetach;
      if (element.AfterDetach is null)
      {
        element.AfterDetach = Utils.Constants.Empty.Actions;
      }
      builder.Validate(detachThese);
      element.DetachThese = detachThese ?? element.DetachThese;
      if (element.DetachThese is null)
      {
        element.DetachThese = new UnitEvaluator[0];
      }
      element.m_PartySize = partySize ?? element.m_PartySize;
      element.m_RestrictPartySize = restrictPartySize ?? element.m_RestrictPartySize;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PartyMembersSwapAttachedAndDetached"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AfterNotDate_dialog</term><description>cbe4991d3d5bad14dac33ca4e67ae2ce</description></item>
    /// <item><term>Cue_0002</term><description>e02ad67ac7924fdca6c2e143c5fc3809</description></item>
    /// <item><term>VaultOfGraves_MythicDemonChapter03</term><description>e3fb405c90492e946a02e176a10268ef</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder PartyMembersSwapAttachedAndDetached(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<PartyMembersSwapAttachedAndDetached>());
    }

    /// <summary>
    /// Adds <see cref="RemoveQuest"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CrusadeMain_Ch2_quest</term><description>fc269c56388944e7ada9a8462abbe2cb</description></item>
    /// <item><term>Military_rankUp6_1_errand</term><description>8fa2068e272a4b2196a8964c04b0ee68</description></item>
    /// <item><term>PF-480843</term><description>bd396fda4bb84e3a8b1e3a5e6f2f4496</description></item>
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
    public static ActionsBuilder RemoveQuest(
        this ActionsBuilder builder,
        Blueprint<BlueprintQuestReference>? quest = null)
    {
      var element = ElementTool.Create<RemoveQuest>();
      element.m_Quest = quest?.Reference ?? element.m_Quest;
      if (element.m_Quest is null)
      {
        element.m_Quest = BlueprintTool.GetRef<BlueprintQuestReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Recruit"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/Recruit
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aftermath_DaeranQ3_dialog</term><description>9a428e24ce273284989196e240051263</description></item>
    /// <item><term>Cue_0137</term><description>121cc01414b509c4098239378424c81c</description></item>
    /// <item><term>WoljifWish_Join_dialogue</term><description>70d8abb125a1a0b46a7207b3181c48aa</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder Recruit(
        this ActionsBuilder builder,
        bool? addToParty = null,
        bool? matchPlayerXpExactly = null,
        ActionsBuilder? onRecruit = null,
        ActionsBuilder? onRecruitImmediate = null,
        Recruit.RecruitData[]? recruited = null)
    {
      var element = ElementTool.Create<Recruit>();
      element.AddToParty = addToParty ?? element.AddToParty;
      element.MatchPlayerXpExactly = matchPlayerXpExactly ?? element.MatchPlayerXpExactly;
      element.OnRecruit = onRecruit?.Build() ?? element.OnRecruit;
      if (element.OnRecruit is null)
      {
        element.OnRecruit = Utils.Constants.Empty.Actions;
      }
      element.OnRecruitImmediate = onRecruitImmediate?.Build() ?? element.OnRecruitImmediate;
      if (element.OnRecruitImmediate is null)
      {
        element.OnRecruitImmediate = Utils.Constants.Empty.Actions;
      }
      builder.Validate(recruited);
      element.Recruited = recruited ?? element.Recruited;
      if (element.Recruited is null)
      {
        element.Recruited = new Recruit.RecruitData[0];
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RecruitInactive"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0011</term><description>d596596f28463f34eb87a3824851ce0e</description></item>
    /// <item><term>Cue_0036</term><description>91645746b99d12646af479beace7ec9d</description></item>
    /// <item><term>Waiting_WenduagInterlude03</term><description>03f99cb6f8f2f6a4f9304087d27c55f7</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="companionBlueprint">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder RecruitInactive(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnitReference>? companionBlueprint = null,
        ActionsBuilder? onRecruit = null)
    {
      var element = ElementTool.Create<RecruitInactive>();
      element.m_CompanionBlueprint = companionBlueprint?.Reference ?? element.m_CompanionBlueprint;
      if (element.m_CompanionBlueprint is null)
      {
        element.m_CompanionBlueprint = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      element.OnRecruit = onRecruit?.Build() ?? element.OnRecruit;
      if (element.OnRecruit is null)
      {
        element.OnRecruit = Utils.Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveMythicLevels"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>301e51edf1251a9489244d37421d89fb</description></item>
    /// <item><term>Cue_0061</term><description>0e5f7e7d35731094182a2d8bc78730b3</description></item>
    /// <item><term>MythicLevel</term><description>dc66b7adec0e41c2b948b4bc9c31ec99</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="clazz">
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
    public static ActionsBuilder RemoveMythicLevels(
        this ActionsBuilder builder,
        Blueprint<BlueprintCharacterClassReference>? clazz = null,
        int? levels = null,
        bool? specificClass = null,
        bool? specificUnit = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<RemoveMythicLevels>();
      element.m_Class = clazz?.Reference ?? element.m_Class;
      if (element.m_Class is null)
      {
        element.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(null);
      }
      element.Levels = levels ?? element.Levels;
      element.SpecificClass = specificClass ?? element.SpecificClass;
      element.SpecificUnit = specificUnit ?? element.SpecificUnit;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ResetQuest"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-217557</term><description>aa0f48fdd6c8461b9c291f7348f7ca2f</description></item>
    /// <item><term>PF-287242</term><description>6646f4f6b88845cba2ae37ad8077e386</description></item>
    /// <item><term>PF-360873</term><description>c5d488664d6d41429973b17e464caecb</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="objectivesToReset">
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
    /// <param name="objectiveToStart">
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
    public static ActionsBuilder ResetQuest(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintQuestObjectiveReference>>? objectivesToReset = null,
        Blueprint<BlueprintQuestObjectiveReference>? objectiveToStart = null,
        Blueprint<BlueprintQuestReference>? quest = null)
    {
      var element = ElementTool.Create<ResetQuest>();
      element.m_ObjectivesToReset = objectivesToReset?.Select(bp => bp.Reference)?.ToArray() ?? element.m_ObjectivesToReset;
      if (element.m_ObjectivesToReset is null)
      {
        element.m_ObjectivesToReset = new BlueprintQuestObjectiveReference[0];
      }
      element.m_ObjectiveToStart = objectiveToStart?.Reference ?? element.m_ObjectiveToStart;
      if (element.m_ObjectiveToStart is null)
      {
        element.m_ObjectiveToStart = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(null);
      }
      element.m_Quest = quest?.Reference ?? element.m_Quest;
      if (element.m_Quest is null)
      {
        element.m_Quest = BlueprintTool.GetRef<BlueprintQuestReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ResetQuestObjective"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-349340_Sosiel</term><description>b9d83ab5df1e435fb1197bd882478d7d</description></item>
    /// <item><term>PF-450866 - 2</term><description>6eeab145c0b54f3b8f61cc46ccb6731e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="objective">
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
    public static ActionsBuilder ResetQuestObjective(
        this ActionsBuilder builder,
        Blueprint<BlueprintQuestObjectiveReference>? objective = null)
    {
      var element = ElementTool.Create<ResetQuestObjective>();
      element.m_Objective = objective?.Reference ?? element.m_Objective;
      if (element.m_Objective is null)
      {
        element.m_Objective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RespecCompanion"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Cue_0020</term><description>0a9c94cf71bc4512a78d8cff189b80fc</description></item>
    /// <item><term>Cue_2</term><description>48c4790378964832ae733ff5e26c7e20</description></item>
    /// <item><term>Cue_7</term><description>09768a45ed444decbfe548eb118ac37e</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder RespecCompanion(
        this ActionsBuilder builder,
        bool? forFree = null,
        bool? matchPlayerXpExactly = null)
    {
      var element = ElementTool.Create<RespecCompanion>();
      element.ForFree = forFree ?? element.ForFree;
      element.MatchPlayerXpExactly = matchPlayerXpExactly ?? element.MatchPlayerXpExactly;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetDialogPosition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction 4</term><description>882a9834a9e1ea5408d9ab18264a1ddf</description></item>
    /// <item><term>Cue_0022</term><description>51c72b5f2ad84794eb23177130fec996</description></item>
    /// <item><term>Cue_3</term><description>18e414bb4ddf4f2285fd33dc92cc9d27</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder SetDialogPosition(
        this ActionsBuilder builder,
        PositionEvaluator? position = null)
    {
      var element = ElementTool.Create<SetDialogPosition>();
      builder.Validate(position);
      element.Position = position ?? element.Position;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetMythicLevelForMainCharacter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Legend_Mythic_Revert</term><description>b3d8c1415ea630349adc4e83d6e9a4be</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="desireLevel">
    /// <para>
    /// InfoBox: Main character will get mythic level = DesireLevel. Note: Action won&amp;apos;t reduce mythic level
    /// </para>
    /// </param>
    public static ActionsBuilder SetMythicLevelForMainCharacter(
        this ActionsBuilder builder,
        int? desireLevel = null)
    {
      var element = ElementTool.Create<SetMythicLevelForMainCharacter>();
      element.DesireLevel = desireLevel ?? element.DesireLevel;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetObjectiveStatus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/SetObjectiveStatus
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>02_ScoutsDead_objZone</term><description>3ffadf67fe817d444b1cb9c6cff78744</description></item>
    /// <item><term>Cue_0032</term><description>3c839251239086e42be81e6af27da241</description></item>
    /// <item><term>ZoeyPendantTeleport</term><description>9a90929e2db1be448b495509170a4251</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="objective">
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
    public static ActionsBuilder SetObjectiveStatus(
        this ActionsBuilder builder,
        Blueprint<BlueprintQuestObjectiveReference>? objective = null,
        bool? startObjectiveIfNone = null,
        SummonPoolCountTrigger.ObjectiveStatus? status = null)
    {
      var element = ElementTool.Create<SetObjectiveStatus>();
      element.m_Objective = objective?.Reference ?? element.m_Objective;
      if (element.m_Objective is null)
      {
        element.m_Objective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(null);
      }
      element.StartObjectiveIfNone = startObjectiveIfNone ?? element.StartObjectiveIfNone;
      element.Status = status ?? element.Status;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetPortrait"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>4fa67e84c3ddbd5448debce210a6d7b6</description></item>
    /// <item><term>Cue_0066</term><description>a02937e970f392b46bfec4cbd8364b90</description></item>
    /// <item><term>WoljifDemonEndingGood</term><description>709161cd9da156146ac6e3c394caa854</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="portrait">
    /// <para>
    /// Blueprint of type BlueprintPortrait. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder SetPortrait(
        this ActionsBuilder builder,
        Blueprint<BlueprintPortraitReference>? portrait = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<SetPortrait>();
      element.m_Portrait = portrait?.Reference ?? element.m_Portrait;
      if (element.m_Portrait is null)
      {
        element.m_Portrait = BlueprintTool.GetRef<BlueprintPortraitReference>(null);
      }
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ShiftAlignment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CrusadeEvent01</term><description>c43ecfae55274a07b63ced113a161993</description></item>
    /// <item><term>CrusadeEvent41</term><description>b99ed0995deb4493b712468e19a84b5c</description></item>
    /// <item><term>CrusadeEvent87</term><description>fcfc30b343d64ae9a364d165db617555</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder ShiftAlignment(
        this ActionsBuilder builder,
        AlignmentShiftDirection? alignment = null,
        IntEvaluator? amount = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<ShiftAlignment>();
      element.Alignment = alignment ?? element.Alignment;
      builder.Validate(amount);
      element.Amount = amount ?? element.Amount;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ShowDialogBox"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Alushinyrra_ToDimalchioMansion_Transition</term><description>e9921430f7a74f44894c93450f79b0e9</description></item>
    /// <item><term>HorgusSupport</term><description>4bb5843d18521ec47b28ba4e2acda776</description></item>
    /// <item><term>Supplies_Actions_RemoveDathDoor</term><description>784b72fb34265604080c985eef646c2a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="text">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public static ActionsBuilder ShowDialogBox(
        this ActionsBuilder builder,
        ActionsBuilder? onAccept = null,
        ActionsBuilder? onCancel = null,
        ParametrizedContextSetter? parameters = null,
        LocalString? text = null)
    {
      var element = ElementTool.Create<ShowDialogBox>();
      element.OnAccept = onAccept?.Build() ?? element.OnAccept;
      if (element.OnAccept is null)
      {
        element.OnAccept = Utils.Constants.Empty.Actions;
      }
      element.OnCancel = onCancel?.Build() ?? element.OnCancel;
      if (element.OnCancel is null)
      {
        element.OnCancel = Utils.Constants.Empty.Actions;
      }
      builder.Validate(parameters);
      element.Parameters = parameters ?? element.Parameters;
      element.Text = text?.LocalizedString ?? element.Text;
      if (element.Text is null)
      {
        element.Text = Utils.Constants.Empty.String;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ShowMessageBox"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AreeluWelcome_FN_dialog</term><description>5e1e26deee65d5e4082864de2dba2d7d</description></item>
    /// <item><term>KingdomMoraleFlagChapter2</term><description>6195e82164ff47d3a67ff5fd0d74d5e3</description></item>
    /// <item><term>XCOM_Battle</term><description>f830cff9020aa434c8b8a49980af4035</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="text">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public static ActionsBuilder ShowMessageBox(
        this ActionsBuilder builder,
        ActionsBuilder? onClose = null,
        LocalString? text = null,
        int? waitTime = null)
    {
      var element = ElementTool.Create<ShowMessageBox>();
      element.OnClose = onClose?.Build() ?? element.OnClose;
      if (element.OnClose is null)
      {
        element.OnClose = Utils.Constants.Empty.Actions;
      }
      element.Text = text?.LocalizedString ?? element.Text;
      if (element.Text is null)
      {
        element.Text = Utils.Constants.Empty.String;
      }
      element.WaitTime = waitTime ?? element.WaitTime;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ShowUIWarning"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>2f7e1fcc714b426ab4c5b5780a19a070</description></item>
    /// <item><term>DrezenCapital</term><description>2570015799edf594daf2f076f2f975d8</description></item>
    /// <item><term>Threshold</term><description>207fad718f41237449b0acf414cc991a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="stringValue">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public static ActionsBuilder ShowUIWarning(
        this ActionsBuilder builder,
        LocalString? stringValue = null,
        WarningNotificationType? type = null)
    {
      var element = ElementTool.Create<ShowUIWarning>();
      element.String = stringValue?.LocalizedString ?? element.String;
      if (element.String is null)
      {
        element.String = Utils.Constants.Empty.String;
      }
      element.Type = type ?? element.Type;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SplitUnitGroup"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0026</term><description>d5176f6a75262904082f34ea99761d58</description></item>
    /// <item><term>Cue_0010</term><description>01213825658f5ec4eb82c347d060f224</description></item>
    /// <item><term>VellexiaThirdDate</term><description>02ffbe686c198854da2d51e72fccb9ca</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder SplitUnitGroup(
        this ActionsBuilder builder,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<SplitUnitGroup>();
      builder.Validate(target);
      element.Target = target ?? element.Target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="StartCombat"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AlushinyrraHigherCity_DefaultEtude</term><description>41574c2d4b6d89e41b096094d0aed4f2</description></item>
    /// <item><term>CommandAction2</term><description>9a4c010590dc488ba79edc7b5c7c8388</description></item>
    /// <item><term>ZigguratRiot</term><description>5ecb3695c95e4bd4b836a0deac1ecfd7</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="unit1">
    /// <para>
    /// InfoBox: Unit1 will become enemy of Unit2&amp;apos;s Faction
    /// </para>
    /// </param>
    public static ActionsBuilder StartCombat(
        this ActionsBuilder builder,
        UnitEvaluator? unit1 = null,
        UnitEvaluator? unit2 = null)
    {
      var element = ElementTool.Create<StartCombat>();
      builder.Validate(unit1);
      element.Unit1 = unit1 ?? element.Unit1;
      builder.Validate(unit2);
      element.Unit2 = unit2 ?? element.Unit2;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="StartDialog"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/StartDialog
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>!Octavia_Companion_Warrior_Test</term><description>0f5938a10fd0d3644be33747d6d2b11c</description></item>
    /// <item><term>EnterTheCrypt</term><description>5080014668d748b4dae66923922be309</description></item>
    /// <item><term>ZombiesDead</term><description>c042c6cb0eaaafc418c94615e4aac891</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="dialogEvaluator">
    /// <para>
    /// Tooltip: Evaluator. Works if Dialogue is null
    /// </para>
    /// </param>
    /// <param name="dialogue">
    /// <para>
    /// Tooltip: This dialog overrides dialog in &amp;apos;Dialogue Owner&amp;apos; if it exists
    /// </para>
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
    /// <param name="dialogueOwner">
    /// <para>
    /// Tooltip: Unit with BlueprintDialog. If unit have no BlueprintDialog or Null - Dialog from field &amp;apos;Dialog&amp;apos; will be used.
    /// </para>
    /// </param>
    /// <param name="speakerName">
    /// <para>
    /// Tooltip: Interlocutor name. Uses only if &amp;apos;Dialogue Owner&amp;apos; is Null
    /// </para>
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public static ActionsBuilder StartDialog(
        this ActionsBuilder builder,
        BlueprintEvaluator? dialogEvaluator = null,
        Blueprint<BlueprintDialogReference>? dialogue = null,
        UnitEvaluator? dialogueOwner = null,
        LocalString? speakerName = null)
    {
      var element = ElementTool.Create<StartDialog>();
      builder.Validate(dialogEvaluator);
      element.DialogEvaluator = dialogEvaluator ?? element.DialogEvaluator;
      element.m_Dialogue = dialogue?.Reference ?? element.m_Dialogue;
      if (element.m_Dialogue is null)
      {
        element.m_Dialogue = BlueprintTool.GetRef<BlueprintDialogReference>(null);
      }
      builder.Validate(dialogueOwner);
      element.DialogueOwner = dialogueOwner ?? element.DialogueOwner;
      element.SpeakerName = speakerName?.LocalizedString ?? element.SpeakerName;
      if (element.SpeakerName is null)
      {
        element.SpeakerName = Utils.Constants.Empty.String;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="StartEncounter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Angel_LeapOfFaithBE</term><description>6b9a55d7c63e4fa5ab553d0141a92f22</description></item>
    /// <item><term>GlobalmapBeforeLostChapel</term><description>739f6806ac4123b4389eea950c5af95b</description></item>
    /// <item><term>GlobalSpellTeleportParty</term><description>8accb3511e0b4eeb822c5867a3dde1e1</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="encounter">
    /// <para>
    /// Blueprint of type BlueprintRandomEncounter. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder StartEncounter(
        this ActionsBuilder builder,
        Blueprint<BlueprintRandomEncounterReference>? encounter = null)
    {
      var element = ElementTool.Create<StartEncounter>();
      element.m_Encounter = encounter?.Reference ?? element.m_Encounter;
      if (element.m_Encounter is null)
      {
        element.m_Encounter = BlueprintTool.GetRef<BlueprintRandomEncounterReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="StartEtude"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>01_IzDrezen</term><description>09c503b7a398d49469b9463ee9d22fd4</description></item>
    /// <item><term>Cue_0029</term><description>641b810209eac7c47b42a4f210d7c58e</description></item>
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
    public static ActionsBuilder StartEtude(
        this ActionsBuilder builder,
        Blueprint<BlueprintEtudeReference>? etude = null,
        BlueprintEvaluator? etudeEvaluator = null,
        bool? evaluate = null)
    {
      var element = ElementTool.Create<StartEtude>();
      element.Etude = etude?.Reference ?? element.Etude;
      if (element.Etude is null)
      {
        element.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(null);
      }
      builder.Validate(etudeEvaluator);
      element.EtudeEvaluator = etudeEvaluator ?? element.EtudeEvaluator;
      element.Evaluate = evaluate ?? element.Evaluate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwitchAzataIsland"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AzataIsland_GlobalSpell</term><description>765b5d6d0e6f4505a6471db58b3fa6ce</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="globalMap">
    /// <para>
    /// Blueprint of type BlueprintGlobalMap. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder SwitchAzataIsland(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMap.Reference>? globalMap = null,
        bool? isOn = null)
    {
      var element = ElementTool.Create<SwitchAzataIsland>();
      element.m_GlobalMap = globalMap?.Reference ?? element.m_GlobalMap;
      if (element.m_GlobalMap is null)
      {
        element.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMap.Reference>(null);
      }
      element.IsOn = isOn ?? element.IsOn;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwitchChapter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter01</term><description>df17ab913c348644b9bd3fe3f9781a84</description></item>
    /// <item><term>Chapter04</term><description>637a57423a82b044f888677c92f5d6cb</description></item>
    /// <item><term>Chapter06</term><description>41bf413e0fa2ea34b937d4445edd5f89</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder SwitchChapter(
        this ActionsBuilder builder,
        int? chapter = null)
    {
      var element = ElementTool.Create<SwitchChapter>();
      element.Chapter = chapter ?? element.Chapter;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwitchDoor"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/SwitchDoor
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>10State_0</term><description>1f815765df0d4d7ba19f731dfa064081</description></item>
    /// <item><term>CommandAction2</term><description>8ab3ec7ee2b24d2eb421a23fed3807cb</description></item>
    /// <item><term>Zantir_Switch</term><description>9fb1869b916481d49a39a9ba82bf6051</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder SwitchDoor(
        this ActionsBuilder builder,
        bool? closeIfAlreadyOpen = null,
        MapObjectEvaluator? door = null,
        bool? openIfAlreadyClosed = null,
        bool? unlockIfLocked = null)
    {
      var element = ElementTool.Create<SwitchDoor>();
      element.CloseIfAlreadyOpen = closeIfAlreadyOpen ?? element.CloseIfAlreadyOpen;
      builder.Validate(door);
      element.Door = door ?? element.Door;
      element.OpenIfAlreadyClosed = openIfAlreadyClosed ?? element.OpenIfAlreadyClosed;
      element.UnlockIfLocked = unlockIfLocked ?? element.UnlockIfLocked;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwitchFaction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>[Hepzamirah]_SpawnActions</term><description>df28026f8a4845a3978f48834852e6b0</description></item>
    /// <item><term>CorruptedHeraldPhase_SpawnActions</term><description>7779daca8cb7c8e42b6be3097ccfd8f7</description></item>
    /// <item><term>ZombiesOnStreets</term><description>ffcf5bca11694784686d9947ed226a88</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="faction">
    /// <para>
    /// Blueprint of type BlueprintFaction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder SwitchFaction(
        this ActionsBuilder builder,
        Blueprint<BlueprintFactionReference>? faction = null,
        bool? includeGroup = null,
        bool? resetAllRelations = null,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<SwitchFaction>();
      element.m_Faction = faction?.Reference ?? element.m_Faction;
      if (element.m_Faction is null)
      {
        element.m_Faction = BlueprintTool.GetRef<BlueprintFactionReference>(null);
      }
      element.IncludeGroup = includeGroup ?? element.IncludeGroup;
      element.ResetAllRelations = resetAllRelations ?? element.ResetAllRelations;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwitchInteraction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1ArenaCombat</term><description>8e64ed1e12bc30c498402e99c95e75e3</description></item>
    /// <item><term>DoorToThirdPart_CheckPassedActions</term><description>b53fdf6e8469fe043b12c632e059a005</description></item>
    /// <item><term>YeribethHall_FinishCipher1</term><description>d5c8170f5bf5725459b6f7f895ecd458</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder SwitchInteraction(
        this ActionsBuilder builder,
        bool? disableIfAlreadyEnabled = null,
        bool? enableIfAlreadyDisabled = null,
        MapObjectEvaluator? mapObject = null)
    {
      var element = ElementTool.Create<SwitchInteraction>();
      element.DisableIfAlreadyEnabled = disableIfAlreadyEnabled ?? element.DisableIfAlreadyEnabled;
      element.EnableIfAlreadyDisabled = enableIfAlreadyDisabled ?? element.EnableIfAlreadyDisabled;
      builder.Validate(mapObject);
      element.MapObject = mapObject ?? element.MapObject;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwitchRoaming"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>(CR 6) Skeleton_2H_SpawnActions</term><description>483880b43aba4e45bbc3e30f9bf81ed6</description></item>
    /// <item><term>CommandAction1</term><description>818cf6e9dfa2412eb401b59a414c2b6d</description></item>
    /// <item><term>Graveyard_MobsSwitches</term><description>1aa3edfb014a45d29bbb84bf63dcca4b</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder SwitchRoaming(
        this ActionsBuilder builder,
        bool? disable = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<SwitchRoaming>();
      element.Disable = disable ?? element.Disable;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwitchToEnemy"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AttackAllHellknights</term><description>827e0ead039d45a09e481c98b14503ae</description></item>
    /// <item><term>Cue_0026</term><description>74bd0306d928a0846ae7def845816219</description></item>
    /// <item><term>XantirLastCombat</term><description>a885b376ef17bdf4aa1ae37ac6e911f3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="factionToAttack">
    /// <para>
    /// Blueprint of type BlueprintFaction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder SwitchToEnemy(
        this ActionsBuilder builder,
        Blueprint<BlueprintFactionReference>? factionToAttack = null,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<SwitchToEnemy>();
      element.m_FactionToAttack = factionToAttack?.Reference ?? element.m_FactionToAttack;
      if (element.m_FactionToAttack is null)
      {
        element.m_FactionToAttack = BlueprintTool.GetRef<BlueprintFactionReference>(null);
      }
      builder.Validate(target);
      element.Target = target ?? element.Target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwitchToNeutral"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/SwitchToNeutral
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon_MidnightFaneInThePast</term><description>fa385eeb6fe506549b9e72ae562a95f9</description></item>
    /// <item><term>FirstFight</term><description>47382ce748a8442439c44e93fb5012e5</description></item>
    /// <item><term>XantirLeave</term><description>652616d20e85ce24f95dc683119f8f71</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="faction">
    /// <para>
    /// Blueprint of type BlueprintFaction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="target">
    /// <para>
    /// InfoBox: Makes the Target unit stop attacking the Faction
    /// </para>
    /// </param>
    public static ActionsBuilder SwitchToNeutral(
        this ActionsBuilder builder,
        Blueprint<BlueprintFactionReference>? faction = null,
        bool? includeGroup = null,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<SwitchToNeutral>();
      element.Faction = faction?.Reference ?? element.Faction;
      if (element.Faction is null)
      {
        element.Faction = BlueprintTool.GetRef<BlueprintFactionReference>(null);
      }
      element.IncludeGroup = includeGroup ?? element.IncludeGroup;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="TimeSkip"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/TimeSkip(Filler)
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcrobaticCheckS1_CheckFailedActions</term><description>024cfea8fa605e5438485ae1bdb6c4f8</description></item>
    /// <item><term>CommandAction1</term><description>205d4b15d494430fac73062d5534112c</description></item>
    /// <item><term>Zaval_CheckFailedActions</term><description>57342a166ff440cf8df490f6d8a1bfca</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder TimeSkip(
        this ActionsBuilder builder,
        bool? matchTimeOfDay = null,
        IntEvaluator? minutesToSkip = null,
        bool? noFatigue = null,
        bool? silent = null,
        TimeOfDay? timeOfDay = null,
        TimeSkip.SkipType? type = null)
    {
      var element = ElementTool.Create<TimeSkip>();
      element.MatchTimeOfDay = matchTimeOfDay ?? element.MatchTimeOfDay;
      builder.Validate(minutesToSkip);
      element.MinutesToSkip = minutesToSkip ?? element.MinutesToSkip;
      element.NoFatigue = noFatigue ?? element.NoFatigue;
      element.Silent = silent ?? element.Silent;
      element.TimeOfDay = timeOfDay ?? element.TimeOfDay;
      element.m_Type = type ?? element.m_Type;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitLookAt"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0001</term><description>0345db4a50d64c97bdd84d615583836e</description></item>
    /// <item><term>CommandAction2</term><description>1c880f250634462288bf95943dccc626</description></item>
    /// <item><term>Warcamp_Tour_Seelah_Dialogue</term><description>f7facc83e8c6ed4489341f31cb72505c</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder UnitLookAt(
        this ActionsBuilder builder,
        PositionEvaluator? position = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<UnitLookAt>();
      builder.Validate(position);
      element.Position = position ?? element.Position;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnlockCompanionStory"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>03_TalkToSeelah</term><description>a113e5ccc842cab439fdd4dc882c34a8</description></item>
    /// <item><term>Obj_0_Secret</term><description>c4d35a3ca9759da479903dec9a3984fa</description></item>
    /// <item><term>WrathOfTheRighteous</term><description>f0e6f6b732c40284ab3c103cad2455cc</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="story">
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
    public static ActionsBuilder UnlockCompanionStory(
        this ActionsBuilder builder,
        Blueprint<BlueprintCompanionStoryReference>? story = null)
    {
      var element = ElementTool.Create<UnlockCompanionStory>();
      element.m_Story = story?.Reference ?? element.m_Story;
      if (element.m_Story is null)
      {
        element.m_Story = BlueprintTool.GetRef<BlueprintCompanionStoryReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnlockFlag"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/UnlockFlag
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>2Wave</term><description>4e1dcba08c1e4a89aea4aaa07f8f89ae</description></item>
    /// <item><term>Cue_0036</term><description>186ce307ae6b3af4dae62682f933db4d</description></item>
    /// <item><term>ZombiesOnStreets</term><description>ffcf5bca11694784686d9947ed226a88</description></item>
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
    public static ActionsBuilder UnlockFlag(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnlockableFlagReference>? flag = null,
        int? flagValue = null)
    {
      var element = ElementTool.Create<UnlockFlag>();
      element.m_flag = flag?.Reference ?? element.m_flag;
      if (element.m_flag is null)
      {
        element.m_flag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(null);
      }
      element.flagValue = flagValue ?? element.flagValue;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnmarkAnswersSelected"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0004</term><description>05d101f17f0b47f5a03c5b6e1f9c2f33</description></item>
    /// <item><term>Cue_0098_FifthRiddle</term><description>a4378804c4a6acd44a3f76c7e1cf519c</description></item>
    /// <item><term>UnmarkAnswers</term><description>3c7ada0ed1917924780a24fdc46afd9b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="answers">
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
    public static ActionsBuilder UnmarkAnswersSelected(this ActionsBuilder builder, params Blueprint<BlueprintAnswerReference>[] answers)
    {
      var element = ElementTool.Create<UnmarkAnswersSelected>();
      element.m_Answers = answers.Select(bp => bp.Reference).ToArray();
      if (element.m_Answers is null)
      {
        element.m_Answers = new BlueprintAnswerReference[0];
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Unrecruit"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/Unrecruit
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0019</term><description>4e30b6b69abc1b24ba38f211f98b9da2</description></item>
    /// <item><term>Cue_0035</term><description>77dfb3878cb86c449a5f2f5fd23b2114</description></item>
    /// <item><term>WarCamp_GorgoyleAttack</term><description>29990bd61e5e3d84195f4f0d0ae81ec8</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="companionBlueprint">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder Unrecruit(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnitReference>? companionBlueprint = null,
        UnitEvaluator? companionEvaluator = null,
        ActionsBuilder? onUnrecruit = null,
        bool? useEvaluator = null)
    {
      var element = ElementTool.Create<Unrecruit>();
      element.m_CompanionBlueprint = companionBlueprint?.Reference ?? element.m_CompanionBlueprint;
      if (element.m_CompanionBlueprint is null)
      {
        element.m_CompanionBlueprint = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      builder.Validate(companionEvaluator);
      element.m_CompanionEvaluator = companionEvaluator ?? element.m_CompanionEvaluator;
      element.OnUnrecruit = onUnrecruit?.Build() ?? element.OnUnrecruit;
      if (element.OnUnrecruit is null)
      {
        element.OnUnrecruit = Utils.Constants.Empty.Actions;
      }
      element.m_UseEvaluator = useEvaluator ?? element.m_UseEvaluator;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UpdateEtudeProgressBar"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DH_ProgressBar</term><description>4d82ae4995764612a08163fe14ab36b5</description></item>
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
    public static ActionsBuilder UpdateEtudeProgressBar(
        this ActionsBuilder builder,
        Blueprint<BlueprintEtudeReference>? etude = null,
        IntEvaluator? progress = null)
    {
      var element = ElementTool.Create<UpdateEtudeProgressBar>();
      element.Etude = etude?.Reference ?? element.Etude;
      if (element.Etude is null)
      {
        element.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(null);
      }
      builder.Validate(progress);
      element.Progress = progress ?? element.Progress;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UpdateEtudes"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonQ3NearTailor</term><description>ea14530f3c887a94ca311579f9b40f00</description></item>
    /// <item><term>CrystalSlot_4_Action_Section_1_3</term><description>9926940d88f64a7da205811df2e3e154</description></item>
    /// <item><term>WenduagDefeated_dialogue</term><description>6d17f0dee27a7a9449d0ee9a641f8266</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder UpdateEtudes(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<UpdateEtudes>());
    }
  }
}
