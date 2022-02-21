//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AreaLogic;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Quests;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.NamedParameters;
using Kingmaker.Designers.Quests.Common;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Localization;
using Kingmaker.RandomEncounters.Settings;
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
    /// Adds <see cref="AlignmentSelector"/>
    /// </summary>
    public static ActionsBuilder AlignmentSelector(
        this ActionsBuilder builder,
        Dictionary<Alignment, AlignmentSelector.ActionAndCondition>? actionsByAlignment = null,
        AlignmentSelector.ActionAndCondition? chaoticEvil = null,
        AlignmentSelector.ActionAndCondition? chaoticGood = null,
        AlignmentSelector.ActionAndCondition? chaoticNeutral = null,
        AlignmentSelector.ActionAndCondition? lawfulEvil = null,
        AlignmentSelector.ActionAndCondition? lawfulGood = null,
        AlignmentSelector.ActionAndCondition? lawfulNeutral = null,
        AlignmentSelector.ActionAndCondition? neutralEvil = null,
        AlignmentSelector.ActionAndCondition? neutralGood = null,
        bool? selectClosest = null,
        AlignmentSelector.ActionAndCondition? trueNeutral = null)
    {
      var element = ElementTool.Create<AlignmentSelector>();
      builder.Validate(actionsByAlignment);
      element.m_ActionsByAlignment = actionsByAlignment ?? element.m_ActionsByAlignment;
      element.ChaoticEvil = chaoticEvil ?? element.ChaoticEvil;
      element.ChaoticGood = chaoticGood ?? element.ChaoticGood;
      element.ChaoticNeutral = chaoticNeutral ?? element.ChaoticNeutral;
      element.LawfulEvil = lawfulEvil ?? element.LawfulEvil;
      element.LawfulGood = lawfulGood ?? element.LawfulGood;
      element.LawfulNeutral = lawfulNeutral ?? element.LawfulNeutral;
      element.NeutralEvil = neutralEvil ?? element.NeutralEvil;
      element.NeutralGood = neutralGood ?? element.NeutralGood;
      element.SelectClosest = selectClosest ?? element.SelectClosest;
      element.TrueNeutral = trueNeutral ?? element.TrueNeutral;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CompleteEtude"/>
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder CompleteEtude(
        this ActionsBuilder builder,
        Blueprint<BlueprintEtude, BlueprintEtudeReference>? etude = null,
        BlueprintEvaluator? etudeEvaluator = null,
        bool? evaluate = null)
    {
      var element = ElementTool.Create<CompleteEtude>();
      element.Etude = etude.Reference ?? element.Etude;
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
    /// Adds <see cref="ChangeRomance"/>
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ChangeRomance(
        this ActionsBuilder builder,
        Blueprint<BlueprintRomanceCounter, BlueprintRomanceCounterReference>? romance = null,
        IntEvaluator? valueEvaluator = null)
    {
      var element = ElementTool.Create<ChangeRomance>();
      element.m_Romance = romance.Reference ?? element.m_Romance;
      if (element.m_Romance is null)
      {
        element.m_Romance = BlueprintTool.GetRef<BlueprintRomanceCounterReference>(null);
      }
      builder.Validate(valueEvaluator);
      element.ValueEvaluator = valueEvaluator ?? element.ValueEvaluator;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangeUnitName"/>
    /// </summary>
    public static ActionsBuilder ChangeUnitName(
        this ActionsBuilder builder,
        bool? addToTheName = null,
        LocalizedString? newName = null,
        bool? returnTheOldName = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<ChangeUnitName>();
      element.AddToTheName = addToTheName ?? element.AddToTheName;
      element.NewName = newName ?? element.NewName;
      if (element.NewName is null)
      {
        element.NewName = Constants.Empty.String;
      }
      element.ReturnTheOldName = returnTheOldName ?? element.ReturnTheOldName;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DismissAllCompanions"/>
    /// </summary>
    public static ActionsBuilder DismissAllCompanions(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<DismissAllCompanions>());
    }

    /// <summary>
    /// Adds <see cref="GiveObjective"/>
    /// </summary>
    ///
    /// <param name="objective">
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder GiveObjective(
        this ActionsBuilder builder,
        Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference>? objective = null)
    {
      var element = ElementTool.Create<GiveObjective>();
      element.m_Objective = objective.Reference ?? element.m_Objective;
      if (element.m_Objective is null)
      {
        element.m_Objective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HideUnit"/>
    /// </summary>
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
    /// <param name="flag">
    /// Blueprint of type BlueprintUnlockableFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder IncrementFlagValue(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnlockableFlag, BlueprintUnlockableFlagReference>? flag = null,
        bool? unlockIfNot = null,
        IntEvaluator? value = null)
    {
      var element = ElementTool.Create<IncrementFlagValue>();
      element.m_Flag = flag.Reference ?? element.m_Flag;
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
    /// <param name="flag">
    /// Blueprint of type BlueprintUnlockableFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder LockFlag(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnlockableFlag, BlueprintUnlockableFlagReference>? flag = null)
    {
      var element = ElementTool.Create<LockFlag>();
      element.m_Flag = flag.Reference ?? element.m_Flag;
      if (element.m_Flag is null)
      {
        element.m_Flag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="LockRomance"/>
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder LockRomance(
        this ActionsBuilder builder,
        Blueprint<BlueprintRomanceCounter, BlueprintRomanceCounterReference>? romance = null)
    {
      var element = ElementTool.Create<LockRomance>();
      element.m_Romance = romance.Reference ?? element.m_Romance;
      if (element.m_Romance is null)
      {
        element.m_Romance = BlueprintTool.GetRef<BlueprintRomanceCounterReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MarkAnswersSelected"/>
    /// </summary>
    ///
    /// <param name="answers">
    /// Blueprint of type BlueprintAnswer. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder MarkAnswersSelected(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintAnswer, BlueprintAnswerReference>>? answers = null)
    {
      var element = ElementTool.Create<MarkAnswersSelected>();
      element.m_Answers = answers.Select(bp => bp.Reference).ToArray() ?? element.m_Answers;
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
    /// <param name="cues">
    /// Blueprint of type BlueprintCueBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder MarkCuesSeen(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintCueBase, BlueprintCueBaseReference>>? cues = null)
    {
      var element = ElementTool.Create<MarkCuesSeen>();
      element.m_Cues = cues.Select(bp => bp.Reference).ToArray() ?? element.m_Cues;
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
    /// <param name="globalMap">
    /// Blueprint of type BlueprintGlobalMap. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="location">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder MoveAzataIslandToLocation(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMap, BlueprintGlobalMap.Reference>? globalMap = null,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>? location = null)
    {
      var element = ElementTool.Create<MoveAzataIslandToLocation>();
      element.m_GlobalMap = globalMap.Reference ?? element.m_GlobalMap;
      if (element.m_GlobalMap is null)
      {
        element.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMap.Reference>(null);
      }
      element.m_Location = location.Reference ?? element.m_Location;
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
    /// <param name="globalMap">
    /// Blueprint of type BlueprintGlobalMap. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder MoveAzataIslandToNearestCrossroad(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMap, BlueprintGlobalMap.Reference>? globalMap = null)
    {
      var element = ElementTool.Create<MoveAzataIslandToNearestCrossroad>();
      element.m_GlobalMap = globalMap.Reference ?? element.m_GlobalMap;
      if (element.m_GlobalMap is null)
      {
        element.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMap.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="OverrideUnitReturnPosition"/>
    /// </summary>
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
    public static ActionsBuilder PartyMembersAttach(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<PartyMembersAttach>());
    }

    /// <summary>
    /// Adds <see cref="PartyMembersDetach"/>
    /// </summary>
    ///
    /// <param name="detachAllExcept">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder PartyMembersDetach(
        this ActionsBuilder builder,
        ActionsBuilder? afterDetach = null,
        List<Blueprint<BlueprintUnit, BlueprintUnitReference>>? detachAllExcept = null,
        int? partySize = null,
        bool? restrictPartySize = null)
    {
      var element = ElementTool.Create<PartyMembersDetach>();
      element.AfterDetach = afterDetach.Build() ?? element.AfterDetach;
      if (element.AfterDetach is null)
      {
        element.AfterDetach = Constants.Empty.Actions;
      }
      element.m_DetachAllExcept = detachAllExcept.Select(bp => bp.Reference).ToArray() ?? element.m_DetachAllExcept;
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
    public static ActionsBuilder PartyMembersDetachEvaluated(
        this ActionsBuilder builder,
        ActionsBuilder? afterDetach = null,
        UnitEvaluator[]? detachThese = null,
        int? partySize = null,
        bool? restrictPartySize = null)
    {
      var element = ElementTool.Create<PartyMembersDetachEvaluated>();
      element.AfterDetach = afterDetach.Build() ?? element.AfterDetach;
      if (element.AfterDetach is null)
      {
        element.AfterDetach = Constants.Empty.Actions;
      }
      foreach (var item in detachThese) { builder.Validate(item); }
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
    public static ActionsBuilder PartyMembersSwapAttachedAndDetached(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<PartyMembersSwapAttachedAndDetached>());
    }

    /// <summary>
    /// Adds <see cref="Recruit"/>
    /// </summary>
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
      element.OnRecruit = onRecruit.Build() ?? element.OnRecruit;
      if (element.OnRecruit is null)
      {
        element.OnRecruit = Constants.Empty.Actions;
      }
      element.OnRecruitImmediate = onRecruitImmediate.Build() ?? element.OnRecruitImmediate;
      if (element.OnRecruitImmediate is null)
      {
        element.OnRecruitImmediate = Constants.Empty.Actions;
      }
      foreach (var item in recruited) { builder.Validate(item); }
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
    /// <param name="companionBlueprint">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RecruitInactive(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? companionBlueprint = null,
        ActionsBuilder? onRecruit = null)
    {
      var element = ElementTool.Create<RecruitInactive>();
      element.m_CompanionBlueprint = companionBlueprint.Reference ?? element.m_CompanionBlueprint;
      if (element.m_CompanionBlueprint is null)
      {
        element.m_CompanionBlueprint = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      element.OnRecruit = onRecruit.Build() ?? element.OnRecruit;
      if (element.OnRecruit is null)
      {
        element.OnRecruit = Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RelockInteraction"/>
    /// </summary>
    public static ActionsBuilder RelockInteraction(
        this ActionsBuilder builder,
        MapObjectEvaluator? mapObject = null)
    {
      var element = ElementTool.Create<RelockInteraction>();
      builder.Validate(mapObject);
      element.MapObject = mapObject ?? element.MapObject;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveMythicLevels"/>
    /// </summary>
    public static ActionsBuilder RemoveMythicLevels(
        this ActionsBuilder builder,
        int? levels = null)
    {
      var element = ElementTool.Create<RemoveMythicLevels>();
      element.Levels = levels ?? element.Levels;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ReplaceAllMythicLevelsWithMythicHeroLevels"/>
    /// </summary>
    public static ActionsBuilder ReplaceAllMythicLevelsWithMythicHeroLevels(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ReplaceAllMythicLevelsWithMythicHeroLevels>());
    }

    /// <summary>
    /// Adds <see cref="ReplaceFeatureInProgression"/>
    /// </summary>
    ///
    /// <param name="add">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="remove">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ReplaceFeatureInProgression(
        this ActionsBuilder builder,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? add = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? remove = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<ReplaceFeatureInProgression>();
      element.m_Add = add.Reference ?? element.m_Add;
      if (element.m_Add is null)
      {
        element.m_Add = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      element.m_Remove = remove.Reference ?? element.m_Remove;
      if (element.m_Remove is null)
      {
        element.m_Remove = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ResetQuest"/>
    /// </summary>
    ///
    /// <param name="objectivesToReset">
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="objectiveToStart">
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="quest">
    /// Blueprint of type BlueprintQuest. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ResetQuest(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference>>? objectivesToReset = null,
        Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference>? objectiveToStart = null,
        Blueprint<BlueprintQuest, BlueprintQuestReference>? quest = null)
    {
      var element = ElementTool.Create<ResetQuest>();
      element.m_ObjectivesToReset = objectivesToReset.Select(bp => bp.Reference).ToArray() ?? element.m_ObjectivesToReset;
      if (element.m_ObjectivesToReset is null)
      {
        element.m_ObjectivesToReset = new BlueprintQuestObjectiveReference[0];
      }
      element.m_ObjectiveToStart = objectiveToStart.Reference ?? element.m_ObjectiveToStart;
      if (element.m_ObjectiveToStart is null)
      {
        element.m_ObjectiveToStart = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(null);
      }
      element.m_Quest = quest.Reference ?? element.m_Quest;
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
    /// <param name="objective">
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ResetQuestObjective(
        this ActionsBuilder builder,
        Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference>? objective = null)
    {
      var element = ElementTool.Create<ResetQuestObjective>();
      element.m_Objective = objective.Reference ?? element.m_Objective;
      if (element.m_Objective is null)
      {
        element.m_Objective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RespecCompanion"/>
    /// </summary>
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
    /// Adds <see cref="RomanceSetMaximum"/>
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RomanceSetMaximum(
        this ActionsBuilder builder,
        Blueprint<BlueprintRomanceCounter, BlueprintRomanceCounterReference>? romance = null,
        IntEvaluator? valueEvaluator = null)
    {
      var element = ElementTool.Create<RomanceSetMaximum>();
      element.m_Romance = romance.Reference ?? element.m_Romance;
      if (element.m_Romance is null)
      {
        element.m_Romance = BlueprintTool.GetRef<BlueprintRomanceCounterReference>(null);
      }
      builder.Validate(valueEvaluator);
      element.ValueEvaluator = valueEvaluator ?? element.ValueEvaluator;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RomanceSetMinimum"/>
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RomanceSetMinimum(
        this ActionsBuilder builder,
        Blueprint<BlueprintRomanceCounter, BlueprintRomanceCounterReference>? romance = null,
        IntEvaluator? valueEvaluator = null)
    {
      var element = ElementTool.Create<RomanceSetMinimum>();
      element.m_Romance = romance.Reference ?? element.m_Romance;
      if (element.m_Romance is null)
      {
        element.m_Romance = BlueprintTool.GetRef<BlueprintRomanceCounterReference>(null);
      }
      builder.Validate(valueEvaluator);
      element.ValueEvaluator = valueEvaluator ?? element.ValueEvaluator;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetDialogPosition"/>
    /// </summary>
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
    /// <param name="objective">
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SetObjectiveStatus(
        this ActionsBuilder builder,
        Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference>? objective = null,
        bool? startObjectiveIfNone = null,
        SummonPoolCountTrigger.ObjectiveStatus? status = null)
    {
      var element = ElementTool.Create<SetObjectiveStatus>();
      element.m_Objective = objective.Reference ?? element.m_Objective;
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
    /// <param name="portrait">
    /// Blueprint of type BlueprintPortrait. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SetPortrait(
        this ActionsBuilder builder,
        Blueprint<BlueprintPortrait, BlueprintPortraitReference>? portrait = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<SetPortrait>();
      element.m_Portrait = portrait.Reference ?? element.m_Portrait;
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
    public static ActionsBuilder ShowDialogBox(
        this ActionsBuilder builder,
        ActionsBuilder? onAccept = null,
        ActionsBuilder? onCancel = null,
        ParametrizedContextSetter? parameters = null,
        LocalizedString? text = null)
    {
      var element = ElementTool.Create<ShowDialogBox>();
      element.OnAccept = onAccept.Build() ?? element.OnAccept;
      if (element.OnAccept is null)
      {
        element.OnAccept = Constants.Empty.Actions;
      }
      element.OnCancel = onCancel.Build() ?? element.OnCancel;
      if (element.OnCancel is null)
      {
        element.OnCancel = Constants.Empty.Actions;
      }
      builder.Validate(parameters);
      element.Parameters = parameters ?? element.Parameters;
      element.Text = text ?? element.Text;
      if (element.Text is null)
      {
        element.Text = Constants.Empty.String;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ShowMessageBox"/>
    /// </summary>
    public static ActionsBuilder ShowMessageBox(
        this ActionsBuilder builder,
        ActionsBuilder? onClose = null,
        LocalizedString? text = null,
        int? waitTime = null)
    {
      var element = ElementTool.Create<ShowMessageBox>();
      element.OnClose = onClose.Build() ?? element.OnClose;
      if (element.OnClose is null)
      {
        element.OnClose = Constants.Empty.Actions;
      }
      element.Text = text ?? element.Text;
      if (element.Text is null)
      {
        element.Text = Constants.Empty.String;
      }
      element.WaitTime = waitTime ?? element.WaitTime;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ShowUIWarning"/>
    /// </summary>
    public static ActionsBuilder ShowUIWarning(
        this ActionsBuilder builder,
        LocalizedString? stringValue = null,
        WarningNotificationType? type = null)
    {
      var element = ElementTool.Create<ShowUIWarning>();
      element.String = stringValue ?? element.String;
      if (element.String is null)
      {
        element.String = Constants.Empty.String;
      }
      element.Type = type ?? element.Type;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SplitUnitGroup"/>
    /// </summary>
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
    /// <param name="dialogue">
    /// Blueprint of type BlueprintDialog. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder StartDialog(
        this ActionsBuilder builder,
        BlueprintEvaluator? dialogEvaluator = null,
        Blueprint<BlueprintDialog, BlueprintDialogReference>? dialogue = null,
        UnitEvaluator? dialogueOwner = null,
        LocalizedString? speakerName = null)
    {
      var element = ElementTool.Create<StartDialog>();
      builder.Validate(dialogEvaluator);
      element.DialogEvaluator = dialogEvaluator ?? element.DialogEvaluator;
      element.m_Dialogue = dialogue.Reference ?? element.m_Dialogue;
      if (element.m_Dialogue is null)
      {
        element.m_Dialogue = BlueprintTool.GetRef<BlueprintDialogReference>(null);
      }
      builder.Validate(dialogueOwner);
      element.DialogueOwner = dialogueOwner ?? element.DialogueOwner;
      element.SpeakerName = speakerName ?? element.SpeakerName;
      if (element.SpeakerName is null)
      {
        element.SpeakerName = Constants.Empty.String;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="StartEncounter"/>
    /// </summary>
    ///
    /// <param name="encounter">
    /// Blueprint of type BlueprintRandomEncounter. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder StartEncounter(
        this ActionsBuilder builder,
        Blueprint<BlueprintRandomEncounter, BlueprintRandomEncounterReference>? encounter = null)
    {
      var element = ElementTool.Create<StartEncounter>();
      element.m_Encounter = encounter.Reference ?? element.m_Encounter;
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
    /// <param name="etude">
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder StartEtude(
        this ActionsBuilder builder,
        Blueprint<BlueprintEtude, BlueprintEtudeReference>? etude = null,
        BlueprintEvaluator? etudeEvaluator = null,
        bool? evaluate = null)
    {
      var element = ElementTool.Create<StartEtude>();
      element.Etude = etude.Reference ?? element.Etude;
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
    /// <param name="globalMap">
    /// Blueprint of type BlueprintGlobalMap. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SwitchAzataIsland(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMap, BlueprintGlobalMap.Reference>? globalMap = null,
        bool? isOn = null)
    {
      var element = ElementTool.Create<SwitchAzataIsland>();
      element.m_GlobalMap = globalMap.Reference ?? element.m_GlobalMap;
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
    /// <param name="faction">
    /// Blueprint of type BlueprintFaction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SwitchFaction(
        this ActionsBuilder builder,
        Blueprint<BlueprintFaction, BlueprintFactionReference>? faction = null,
        bool? includeGroup = null,
        bool? resetAllRelations = null,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<SwitchFaction>();
      element.m_Faction = faction.Reference ?? element.m_Faction;
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
    /// <param name="factionToAttack">
    /// Blueprint of type BlueprintFaction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SwitchToEnemy(
        this ActionsBuilder builder,
        Blueprint<BlueprintFaction, BlueprintFactionReference>? factionToAttack = null,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<SwitchToEnemy>();
      element.m_FactionToAttack = factionToAttack.Reference ?? element.m_FactionToAttack;
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
    /// <param name="faction">
    /// Blueprint of type BlueprintFaction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SwitchToNeutral(
        this ActionsBuilder builder,
        Blueprint<BlueprintFaction, BlueprintFactionReference>? faction = null,
        bool? includeGroup = null,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<SwitchToNeutral>();
      element.Faction = faction.Reference ?? element.Faction;
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
    /// Adds <see cref="UnlinkDualCompanions"/>
    /// </summary>
    public static ActionsBuilder UnlinkDualCompanions(
        this ActionsBuilder builder,
        UnitEvaluator? first = null,
        UnitEvaluator? second = null)
    {
      var element = ElementTool.Create<UnlinkDualCompanions>();
      builder.Validate(first);
      element.First = first ?? element.First;
      builder.Validate(second);
      element.Second = second ?? element.Second;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnlockCompanionStory"/>
    /// </summary>
    ///
    /// <param name="story">
    /// Blueprint of type BlueprintCompanionStory. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder UnlockCompanionStory(
        this ActionsBuilder builder,
        Blueprint<BlueprintCompanionStory, BlueprintCompanionStoryReference>? story = null)
    {
      var element = ElementTool.Create<UnlockCompanionStory>();
      element.m_Story = story.Reference ?? element.m_Story;
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
    /// <param name="flag">
    /// Blueprint of type BlueprintUnlockableFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder UnlockFlag(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnlockableFlag, BlueprintUnlockableFlagReference>? flag = null,
        int? flagValue = null)
    {
      var element = ElementTool.Create<UnlockFlag>();
      element.m_flag = flag.Reference ?? element.m_flag;
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
    /// <param name="answers">
    /// Blueprint of type BlueprintAnswer. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder UnmarkAnswersSelected(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintAnswer, BlueprintAnswerReference>>? answers = null)
    {
      var element = ElementTool.Create<UnmarkAnswersSelected>();
      element.m_Answers = answers.Select(bp => bp.Reference).ToArray() ?? element.m_Answers;
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
    /// <param name="companionBlueprint">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder Unrecruit(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? companionBlueprint = null,
        ActionsBuilder? onUnrecruit = null)
    {
      var element = ElementTool.Create<Unrecruit>();
      element.m_CompanionBlueprint = companionBlueprint.Reference ?? element.m_CompanionBlueprint;
      if (element.m_CompanionBlueprint is null)
      {
        element.m_CompanionBlueprint = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      element.OnUnrecruit = onUnrecruit.Build() ?? element.OnUnrecruit;
      if (element.OnUnrecruit is null)
      {
        element.OnUnrecruit = Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UpdateEtudeProgressBar"/>
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder UpdateEtudeProgressBar(
        this ActionsBuilder builder,
        Blueprint<BlueprintEtude, BlueprintEtudeReference>? etude = null,
        IntEvaluator? progress = null)
    {
      var element = ElementTool.Create<UpdateEtudeProgressBar>();
      element.Etude = etude.Reference ?? element.Etude;
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
    public static ActionsBuilder UpdateEtudes(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<UpdateEtudes>());
    }
  }
}
