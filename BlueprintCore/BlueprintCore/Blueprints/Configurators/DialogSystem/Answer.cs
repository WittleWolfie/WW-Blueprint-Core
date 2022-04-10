using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Alignments;
using System;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Configurator for <see cref="BlueprintAnswer"/>.
  /// </summary>
  /// <inheritdoc/>
  
  public class AnswerConfigurator : BaseAnswerBaseConfigurator<BlueprintAnswer, AnswerConfigurator>
  {
    private AnswerConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AnswerConfigurator For(string name)
    {
      return new AnswerConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AnswerConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintAnswer>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.Text"/> (Auto Generated)
    /// </summary>
    
    public AnswerConfigurator SetText(LocalizedString? text)
    {
      ValidateParam(text);

      return OnConfigureInternal(
          bp =>
          {
            bp.Text = text ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.NextCue"/> (Auto Generated)
    /// </summary>
    
    public AnswerConfigurator SetNextCue(CueSelection nextCue)
    {
      ValidateParam(nextCue);

      return OnConfigureInternal(
          bp =>
          {
            bp.NextCue = nextCue;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.ShowOnce"/> (Auto Generated)
    /// </summary>
    
    public AnswerConfigurator SetShowOnce(bool showOnce)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ShowOnce = showOnce;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.ShowOnceCurrentDialog"/> (Auto Generated)
    /// </summary>
    
    public AnswerConfigurator SetShowOnceCurrentDialog(bool showOnceCurrentDialog)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ShowOnceCurrentDialog = showOnceCurrentDialog;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.ShowCheck"/> (Auto Generated)
    /// </summary>
    
    public AnswerConfigurator SetShowCheck(ShowCheck showCheck)
    {
      ValidateParam(showCheck);

      return OnConfigureInternal(
          bp =>
          {
            bp.ShowCheck = showCheck;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.Experience"/> (Auto Generated)
    /// </summary>
    
    public AnswerConfigurator SetExperience(DialogExperience experience)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Experience = experience;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.DebugMode"/> (Auto Generated)
    /// </summary>
    
    public AnswerConfigurator SetDebugMode(bool debugMode)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DebugMode = debugMode;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.CharacterSelection"/> (Auto Generated)
    /// </summary>
    
    public AnswerConfigurator SetCharacterSelection(CharacterSelection characterSelection)
    {
      ValidateParam(characterSelection);

      return OnConfigureInternal(
          bp =>
          {
            bp.CharacterSelection = characterSelection;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.ShowConditions"/> (Auto Generated)
    /// </summary>
    
    public AnswerConfigurator SetShowConditions(ConditionsBuilder? showConditions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ShowConditions = showConditions?.Build() ?? Constants.Empty.Conditions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.SelectConditions"/> (Auto Generated)
    /// </summary>
    
    public AnswerConfigurator SetSelectConditions(ConditionsBuilder? selectConditions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SelectConditions = selectConditions?.Build() ?? Constants.Empty.Conditions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.RequireValidCue"/> (Auto Generated)
    /// </summary>
    
    public AnswerConfigurator SetRequireValidCue(bool requireValidCue)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RequireValidCue = requireValidCue;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.AddToHistory"/> (Auto Generated)
    /// </summary>
    
    public AnswerConfigurator SetAddToHistory(bool addToHistory)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AddToHistory = addToHistory;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.OnSelect"/> (Auto Generated)
    /// </summary>
    
    public AnswerConfigurator SetOnSelect(ActionsBuilder? onSelect)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OnSelect = onSelect?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.FakeChecks"/> (Auto Generated)
    /// </summary>
    
    public AnswerConfigurator SetFakeChecks(CheckData[]? fakeChecks)
    {
      ValidateParam(fakeChecks);

      return OnConfigureInternal(
          bp =>
          {
            bp.FakeChecks = fakeChecks;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAnswer.FakeChecks"/> (Auto Generated)
    /// </summary>
    
    public AnswerConfigurator AddToFakeChecks(params CheckData[] fakeChecks)
    {
      ValidateParam(fakeChecks);
      return OnConfigureInternal(
          bp =>
          {
            bp.FakeChecks = CommonTool.Append(bp.FakeChecks, fakeChecks ?? new CheckData[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAnswer.FakeChecks"/> (Auto Generated)
    /// </summary>
    
    public AnswerConfigurator RemoveFromFakeChecks(params CheckData[] fakeChecks)
    {
      ValidateParam(fakeChecks);
      return OnConfigureInternal(
          bp =>
          {
            bp.FakeChecks = bp.FakeChecks.Where(item => !fakeChecks.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.AlignmentShift"/> (Auto Generated)
    /// </summary>
    
    public AnswerConfigurator SetAlignmentShift(AlignmentShift alignmentShift)
    {
      ValidateParam(alignmentShift);

      return OnConfigureInternal(
          bp =>
          {
            bp.AlignmentShift = alignmentShift;
          });
    }

    /// <summary>
    /// Adds <see cref="ActingCompanion"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companion"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    
    
    public AnswerConfigurator AddActingCompanion(
        string? companion = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ActingCompanion();
      component.m_Companion = BlueprintTool.GetRef<BlueprintUnitReference>(companion);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}
