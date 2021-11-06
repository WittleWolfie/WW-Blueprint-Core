using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Localization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Actions.Builder.StoryEx
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



    /// <summary>
    /// Adds <see cref="AlignmentSelector"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AlignmentSelector))]
    public static ActionsBuilder AddAlignmentSelector(
        this ActionsBuilder builder,
        Boolean SelectClosest,
        AlignmentSelector.ActionAndCondition LawfulGood,
        AlignmentSelector.ActionAndCondition NeutralGood,
        AlignmentSelector.ActionAndCondition ChaoticGood,
        AlignmentSelector.ActionAndCondition LawfulNeutral,
        AlignmentSelector.ActionAndCondition TrueNeutral,
        AlignmentSelector.ActionAndCondition ChaoticNeutral,
        AlignmentSelector.ActionAndCondition LawfulEvil,
        AlignmentSelector.ActionAndCondition NeutralEvil,
        AlignmentSelector.ActionAndCondition ChaoticEvil,
        Dictionary<Alignment,AlignmentSelector.ActionAndCondition> m_ActionsByAlignment)
    {
      builder.Validate(SelectClosest);
      builder.Validate(LawfulGood);
      builder.Validate(NeutralGood);
      builder.Validate(ChaoticGood);
      builder.Validate(LawfulNeutral);
      builder.Validate(TrueNeutral);
      builder.Validate(ChaoticNeutral);
      builder.Validate(LawfulEvil);
      builder.Validate(NeutralEvil);
      builder.Validate(ChaoticEvil);
      foreach (var item in m_ActionsByAlignment)
      {
        builder.Validate(item);
      }
      
      var element = ElementTool.Create<AlignmentSelector>();
      element.SelectClosest = SelectClosest;
      element.LawfulGood = LawfulGood;
      element.NeutralGood = NeutralGood;
      element.ChaoticGood = ChaoticGood;
      element.LawfulNeutral = LawfulNeutral;
      element.TrueNeutral = TrueNeutral;
      element.ChaoticNeutral = ChaoticNeutral;
      element.LawfulEvil = LawfulEvil;
      element.NeutralEvil = NeutralEvil;
      element.ChaoticEvil = ChaoticEvil;
      element.m_ActionsByAlignment = m_ActionsByAlignment;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DismissAllCompanions"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DismissAllCompanions))]
    public static ActionsBuilder AddDismissAllCompanions(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<DismissAllCompanions>());
    }

    /// <summary>
    /// Adds <see cref="LockRomance"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Romance"><see cref="BlueprintRomanceCounter"/></param>
    [Generated]
    [Implements(typeof(LockRomance))]
    public static ActionsBuilder AddLockRomance(
        this ActionsBuilder builder,
        string m_Romance)
    {
      
      var element = ElementTool.Create<LockRomance>();
      element.m_Romance = BlueprintTool.GetRef<BlueprintRomanceCounterReference>(m_Romance);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnmarkAnswersSelected"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Answers"><see cref="BlueprintAnswer"/></param>
    [Generated]
    [Implements(typeof(UnmarkAnswersSelected))]
    public static ActionsBuilder AddUnmarkAnswersSelected(
        this ActionsBuilder builder,
        string[] m_Answers)
    {
      
      var element = ElementTool.Create<UnmarkAnswersSelected>();
      element.m_Answers = m_Answers.Select(bp => BlueprintTool.GetRef<BlueprintAnswerReference>(bp)).ToArray();
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Unrecruit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CompanionBlueprint"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(Unrecruit))]
    public static ActionsBuilder AddUnrecruit(
        this ActionsBuilder builder,
        string m_CompanionBlueprint,
        ActionsBuilder OnUnrecruit)
    {
      
      var element = ElementTool.Create<Unrecruit>();
      element.m_CompanionBlueprint = BlueprintTool.GetRef<BlueprintUnitReference>(m_CompanionBlueprint);
      element.OnUnrecruit = OnUnrecruit.Build();
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UpdateEtudeProgressBar"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="Etude"><see cref="BlueprintEtude"/></param>
    [Generated]
    [Implements(typeof(UpdateEtudeProgressBar))]
    public static ActionsBuilder AddUpdateEtudeProgressBar(
        this ActionsBuilder builder,
        IntEvaluator Progress,
        string Etude)
    {
      builder.Validate(Progress);
      
      var element = ElementTool.Create<UpdateEtudeProgressBar>();
      element.Progress = Progress;
      element.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(Etude);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UpdateEtudes"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UpdateEtudes))]
    public static ActionsBuilder AddUpdateEtudes(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<UpdateEtudes>());
    }
  }
}
