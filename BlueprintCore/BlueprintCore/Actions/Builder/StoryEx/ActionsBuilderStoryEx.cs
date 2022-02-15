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
//***** AUTO-GENERATED - DO NOT EDIT *****//
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
        Dictionary<Alignment,AlignmentSelector.ActionAndCondition>? actionsByAlignment = null,
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
      if (actionsByAlignment is not null)
      {
        builder.Validate(actionsByAlignment);
        element.m_ActionsByAlignment = actionsByAlignment;
      }
      if (chaoticEvil is not null)
      {
        element.ChaoticEvil = chaoticEvil;
      }
      if (chaoticGood is not null)
      {
        element.ChaoticGood = chaoticGood;
      }
      if (chaoticNeutral is not null)
      {
        element.ChaoticNeutral = chaoticNeutral;
      }
      if (lawfulEvil is not null)
      {
        element.LawfulEvil = lawfulEvil;
      }
      if (lawfulGood is not null)
      {
        element.LawfulGood = lawfulGood;
      }
      if (lawfulNeutral is not null)
      {
        element.LawfulNeutral = lawfulNeutral;
      }
      if (neutralEvil is not null)
      {
        element.NeutralEvil = neutralEvil;
      }
      if (neutralGood is not null)
      {
        element.NeutralGood = neutralGood;
      }
      if (selectClosest is not null)
      {
        element.SelectClosest = selectClosest;
      }
      if (trueNeutral is not null)
      {
        element.TrueNeutral = trueNeutral;
      }
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
      if (etude is not null)
      {
        element.Etude = etude.Reference;
      }
      if (element.Etude is null)
      {
        element.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(null);
      }
      if (etudeEvaluator is not null)
      {
        builder.Validate(etudeEvaluator);
        element.EtudeEvaluator = etudeEvaluator;
      }
      if (evaluate is not null)
      {
        element.Evaluate = evaluate;
      }
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
      if (romance is not null)
      {
        element.m_Romance = romance.Reference;
      }
      if (element.m_Romance is null)
      {
        element.m_Romance = BlueprintTool.GetRef<BlueprintRomanceCounterReference>(null);
      }
      if (valueEvaluator is not null)
      {
        builder.Validate(valueEvaluator);
        element.ValueEvaluator = valueEvaluator;
      }
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
      if (addToTheName is not null)
      {
        element.AddToTheName = addToTheName;
      }
      if (newName is not null)
      {
        element.NewName = newName;
      }
      if (element.NewName is null)
      {
        element.NewName = Constants.Empty.String;
      }
      if (returnTheOldName is not null)
      {
        element.ReturnTheOldName = returnTheOldName;
      }
      if (unit is not null)
      {
        builder.Validate(unit);
        element.Unit = unit;
      }
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
      if (objective is not null)
      {
        element.m_Objective = objective.Reference;
      }
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
      if (fade is not null)
      {
        element.Fade = fade;
      }
      if (target is not null)
      {
        builder.Validate(target);
        element.Target = target;
      }
      if (unhide is not null)
      {
        element.Unhide = unhide;
      }
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
      if (hide is not null)
      {
        element.Hide = hide;
      }
      if (target is not null)
      {
        builder.Validate(target);
        element.Target = target;
      }
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
      if (flag is not null)
      {
        element.m_Flag = flag.Reference;
      }
      if (element.m_Flag is null)
      {
        element.m_Flag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(null);
      }
      if (unlockIfNot is not null)
      {
        element.UnlockIfNot = unlockIfNot;
      }
      if (value is not null)
      {
        builder.Validate(value);
        element.Value = value;
      }
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
      if (unit is not null)
      {
        builder.Validate(unit);
        element.m_Unit = unit;
      }
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
      if (alignmentMask is not null)
      {
        element.AlignmentMask = alignmentMask;
      }
      if (targetAlignment is not null)
      {
        element.TargetAlignment = targetAlignment;
      }
      if (unit is not null)
      {
        builder.Validate(unit);
        element.Unit = unit;
      }
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
      if (flag is not null)
      {
        element.m_Flag = flag.Reference;
      }
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
      if (romance is not null)
      {
        element.m_Romance = romance.Reference;
      }
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
      if (answers is not null)
      {
        element.m_Answers = answers.Select(bp => bp.Reference).ToArray();
      }
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
      if (cues is not null)
      {
        element.m_Cues = cues.Select(bp => bp.Reference).ToArray();
      }
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
      if (globalMap is not null)
      {
        element.m_GlobalMap = globalMap.Reference;
      }
      if (element.m_GlobalMap is null)
      {
        element.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMap.Reference>(null);
      }
      if (location is not null)
      {
        element.m_Location = location.Reference;
      }
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
      if (globalMap is not null)
      {
        element.m_GlobalMap = globalMap.Reference;
      }
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
      if (orientation is not null)
      {
        builder.Validate(orientation);
        element.Orientation = orientation;
      }
      if (position is not null)
      {
        builder.Validate(position);
        element.Position = position;
      }
      if (unit is not null)
      {
        builder.Validate(unit);
        element.Unit = unit;
      }
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
      if (afterDetach is not null)
      {
        element.AfterDetach = afterDetach.Build();
      }
      if (element.AfterDetach is null)
      {
        element.AfterDetach = Constants.Empty.Actions;
      }
      if (detachAllExcept is not null)
      {
        element.m_DetachAllExcept = detachAllExcept.Select(bp => bp.Reference).ToArray();
      }
      if (element.m_DetachAllExcept is null)
      {
        element.m_DetachAllExcept = new BlueprintUnitReference[0];
      }
      if (partySize is not null)
      {
        element.m_PartySize = partySize;
      }
      if (restrictPartySize is not null)
      {
        element.m_RestrictPartySize = restrictPartySize;
      }
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
      if (afterDetach is not null)
      {
        element.AfterDetach = afterDetach.Build();
      }
      if (element.AfterDetach is null)
      {
        element.AfterDetach = Constants.Empty.Actions;
      }
      if (detachThese is not null)
      {
        foreach (var item in detachThese) { builder.Validate(item); }
        element.DetachThese = detachThese;
      }
      if (element.DetachThese is null)
      {
        element.DetachThese = new UnitEvaluator[0];
      }
      if (partySize is not null)
      {
        element.m_PartySize = partySize;
      }
      if (restrictPartySize is not null)
      {
        element.m_RestrictPartySize = restrictPartySize;
      }
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
      if (addToParty is not null)
      {
        element.AddToParty = addToParty;
      }
      if (matchPlayerXpExactly is not null)
      {
        element.MatchPlayerXpExactly = matchPlayerXpExactly;
      }
      if (onRecruit is not null)
      {
        element.OnRecruit = onRecruit.Build();
      }
      if (element.OnRecruit is null)
      {
        element.OnRecruit = Constants.Empty.Actions;
      }
      if (onRecruitImmediate is not null)
      {
        element.OnRecruitImmediate = onRecruitImmediate.Build();
      }
      if (element.OnRecruitImmediate is null)
      {
        element.OnRecruitImmediate = Constants.Empty.Actions;
      }
      if (recruited is not null)
      {
        foreach (var item in recruited) { builder.Validate(item); }
        element.Recruited = recruited;
      }
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
      if (companionBlueprint is not null)
      {
        element.m_CompanionBlueprint = companionBlueprint.Reference;
      }
      if (element.m_CompanionBlueprint is null)
      {
        element.m_CompanionBlueprint = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      if (onRecruit is not null)
      {
        element.OnRecruit = onRecruit.Build();
      }
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
      if (mapObject is not null)
      {
        builder.Validate(mapObject);
        element.MapObject = mapObject;
      }
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
      if (levels is not null)
      {
        element.Levels = levels;
      }
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
      if (add is not null)
      {
        element.m_Add = add.Reference;
      }
      if (element.m_Add is null)
      {
        element.m_Add = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      if (remove is not null)
      {
        element.m_Remove = remove.Reference;
      }
      if (element.m_Remove is null)
      {
        element.m_Remove = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      if (unit is not null)
      {
        builder.Validate(unit);
        element.Unit = unit;
      }
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
      if (objectivesToReset is not null)
      {
        element.m_ObjectivesToReset = objectivesToReset.Select(bp => bp.Reference).ToArray();
      }
      if (element.m_ObjectivesToReset is null)
      {
        element.m_ObjectivesToReset = new BlueprintQuestObjectiveReference[0];
      }
      if (objectiveToStart is not null)
      {
        element.m_ObjectiveToStart = objectiveToStart.Reference;
      }
      if (element.m_ObjectiveToStart is null)
      {
        element.m_ObjectiveToStart = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(null);
      }
      if (quest is not null)
      {
        element.m_Quest = quest.Reference;
      }
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
      if (objective is not null)
      {
        element.m_Objective = objective.Reference;
      }
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
      if (forFree is not null)
      {
        element.ForFree = forFree;
      }
      if (matchPlayerXpExactly is not null)
      {
        element.MatchPlayerXpExactly = matchPlayerXpExactly;
      }
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
      if (romance is not null)
      {
        element.m_Romance = romance.Reference;
      }
      if (element.m_Romance is null)
      {
        element.m_Romance = BlueprintTool.GetRef<BlueprintRomanceCounterReference>(null);
      }
      if (valueEvaluator is not null)
      {
        builder.Validate(valueEvaluator);
        element.ValueEvaluator = valueEvaluator;
      }
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
      if (romance is not null)
      {
        element.m_Romance = romance.Reference;
      }
      if (element.m_Romance is null)
      {
        element.m_Romance = BlueprintTool.GetRef<BlueprintRomanceCounterReference>(null);
      }
      if (valueEvaluator is not null)
      {
        builder.Validate(valueEvaluator);
        element.ValueEvaluator = valueEvaluator;
      }
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
      if (position is not null)
      {
        builder.Validate(position);
        element.Position = position;
      }
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
      if (desireLevel is not null)
      {
        element.DesireLevel = desireLevel;
      }
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
      if (objective is not null)
      {
        element.m_Objective = objective.Reference;
      }
      if (element.m_Objective is null)
      {
        element.m_Objective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(null);
      }
      if (startObjectiveIfNone is not null)
      {
        element.StartObjectiveIfNone = startObjectiveIfNone;
      }
      if (status is not null)
      {
        element.Status = status;
      }
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
      if (portrait is not null)
      {
        element.m_Portrait = portrait.Reference;
      }
      if (element.m_Portrait is null)
      {
        element.m_Portrait = BlueprintTool.GetRef<BlueprintPortraitReference>(null);
      }
      if (unit is not null)
      {
        builder.Validate(unit);
        element.Unit = unit;
      }
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
      if (alignment is not null)
      {
        element.Alignment = alignment;
      }
      if (amount is not null)
      {
        builder.Validate(amount);
        element.Amount = amount;
      }
      if (unit is not null)
      {
        builder.Validate(unit);
        element.Unit = unit;
      }
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
      if (onAccept is not null)
      {
        element.OnAccept = onAccept.Build();
      }
      if (element.OnAccept is null)
      {
        element.OnAccept = Constants.Empty.Actions;
      }
      if (onCancel is not null)
      {
        element.OnCancel = onCancel.Build();
      }
      if (element.OnCancel is null)
      {
        element.OnCancel = Constants.Empty.Actions;
      }
      if (parameters is not null)
      {
        builder.Validate(parameters);
        element.Parameters = parameters;
      }
      if (text is not null)
      {
        element.Text = text;
      }
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
      if (onClose is not null)
      {
        element.OnClose = onClose.Build();
      }
      if (element.OnClose is null)
      {
        element.OnClose = Constants.Empty.Actions;
      }
      if (text is not null)
      {
        element.Text = text;
      }
      if (element.Text is null)
      {
        element.Text = Constants.Empty.String;
      }
      if (waitTime is not null)
      {
        element.WaitTime = waitTime;
      }
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
      if (stringValue is not null)
      {
        element.String = stringValue;
      }
      if (element.String is null)
      {
        element.String = Constants.Empty.String;
      }
      if (type is not null)
      {
        element.Type = type;
      }
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
      if (target is not null)
      {
        builder.Validate(target);
        element.Target = target;
      }
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
      if (unit1 is not null)
      {
        builder.Validate(unit1);
        element.Unit1 = unit1;
      }
      if (unit2 is not null)
      {
        builder.Validate(unit2);
        element.Unit2 = unit2;
      }
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
      if (dialogEvaluator is not null)
      {
        builder.Validate(dialogEvaluator);
        element.DialogEvaluator = dialogEvaluator;
      }
      if (dialogue is not null)
      {
        element.m_Dialogue = dialogue.Reference;
      }
      if (element.m_Dialogue is null)
      {
        element.m_Dialogue = BlueprintTool.GetRef<BlueprintDialogReference>(null);
      }
      if (dialogueOwner is not null)
      {
        builder.Validate(dialogueOwner);
        element.DialogueOwner = dialogueOwner;
      }
      if (speakerName is not null)
      {
        element.SpeakerName = speakerName;
      }
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
      if (encounter is not null)
      {
        element.m_Encounter = encounter.Reference;
      }
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
      if (etude is not null)
      {
        element.Etude = etude.Reference;
      }
      if (element.Etude is null)
      {
        element.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(null);
      }
      if (etudeEvaluator is not null)
      {
        builder.Validate(etudeEvaluator);
        element.EtudeEvaluator = etudeEvaluator;
      }
      if (evaluate is not null)
      {
        element.Evaluate = evaluate;
      }
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
      if (globalMap is not null)
      {
        element.m_GlobalMap = globalMap.Reference;
      }
      if (element.m_GlobalMap is null)
      {
        element.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMap.Reference>(null);
      }
      if (isOn is not null)
      {
        element.IsOn = isOn;
      }
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
      if (chapter is not null)
      {
        element.Chapter = chapter;
      }
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
      if (closeIfAlreadyOpen is not null)
      {
        element.CloseIfAlreadyOpen = closeIfAlreadyOpen;
      }
      if (door is not null)
      {
        builder.Validate(door);
        element.Door = door;
      }
      if (openIfAlreadyClosed is not null)
      {
        element.OpenIfAlreadyClosed = openIfAlreadyClosed;
      }
      if (unlockIfLocked is not null)
      {
        element.UnlockIfLocked = unlockIfLocked;
      }
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
      if (faction is not null)
      {
        element.m_Faction = faction.Reference;
      }
      if (element.m_Faction is null)
      {
        element.m_Faction = BlueprintTool.GetRef<BlueprintFactionReference>(null);
      }
      if (includeGroup is not null)
      {
        element.IncludeGroup = includeGroup;
      }
      if (resetAllRelations is not null)
      {
        element.ResetAllRelations = resetAllRelations;
      }
      if (target is not null)
      {
        builder.Validate(target);
        element.Target = target;
      }
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
      if (disableIfAlreadyEnabled is not null)
      {
        element.DisableIfAlreadyEnabled = disableIfAlreadyEnabled;
      }
      if (enableIfAlreadyDisabled is not null)
      {
        element.EnableIfAlreadyDisabled = enableIfAlreadyDisabled;
      }
      if (mapObject is not null)
      {
        builder.Validate(mapObject);
        element.MapObject = mapObject;
      }
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
      if (disable is not null)
      {
        element.Disable = disable;
      }
      if (unit is not null)
      {
        builder.Validate(unit);
        element.Unit = unit;
      }
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
      if (factionToAttack is not null)
      {
        element.m_FactionToAttack = factionToAttack.Reference;
      }
      if (element.m_FactionToAttack is null)
      {
        element.m_FactionToAttack = BlueprintTool.GetRef<BlueprintFactionReference>(null);
      }
      if (target is not null)
      {
        builder.Validate(target);
        element.Target = target;
      }
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
      if (faction is not null)
      {
        element.Faction = faction.Reference;
      }
      if (element.Faction is null)
      {
        element.Faction = BlueprintTool.GetRef<BlueprintFactionReference>(null);
      }
      if (includeGroup is not null)
      {
        element.IncludeGroup = includeGroup;
      }
      if (target is not null)
      {
        builder.Validate(target);
        element.Target = target;
      }
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
      if (matchTimeOfDay is not null)
      {
        element.MatchTimeOfDay = matchTimeOfDay;
      }
      if (minutesToSkip is not null)
      {
        builder.Validate(minutesToSkip);
        element.MinutesToSkip = minutesToSkip;
      }
      if (noFatigue is not null)
      {
        element.NoFatigue = noFatigue;
      }
      if (silent is not null)
      {
        element.Silent = silent;
      }
      if (timeOfDay is not null)
      {
        element.TimeOfDay = timeOfDay;
      }
      if (type is not null)
      {
        element.m_Type = type;
      }
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
      if (position is not null)
      {
        builder.Validate(position);
        element.Position = position;
      }
      if (unit is not null)
      {
        builder.Validate(unit);
        element.Unit = unit;
      }
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
      if (first is not null)
      {
        builder.Validate(first);
        element.First = first;
      }
      if (second is not null)
      {
        builder.Validate(second);
        element.Second = second;
      }
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
      if (story is not null)
      {
        element.m_Story = story.Reference;
      }
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
      if (flag is not null)
      {
        element.m_flag = flag.Reference;
      }
      if (element.m_flag is null)
      {
        element.m_flag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(null);
      }
      if (flagValue is not null)
      {
        element.flagValue = flagValue;
      }
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
      if (answers is not null)
      {
        element.m_Answers = answers.Select(bp => bp.Reference).ToArray();
      }
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
      if (companionBlueprint is not null)
      {
        element.m_CompanionBlueprint = companionBlueprint.Reference;
      }
      if (element.m_CompanionBlueprint is null)
      {
        element.m_CompanionBlueprint = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      if (onUnrecruit is not null)
      {
        element.OnUnrecruit = onUnrecruit.Build();
      }
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
      if (etude is not null)
      {
        element.Etude = etude.Reference;
      }
      if (element.Etude is null)
      {
        element.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(null);
      }
      if (progress is not null)
      {
        builder.Validate(progress);
        element.Progress = progress;
      }
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
