//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCue"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCueConfigurator<T, TBuilder>
    : BaseCueBaseConfigurator<T, TBuilder>
    where T : BlueprintCue
    where TBuilder : BaseCueConfigurator<T, TBuilder>
  {
    protected BaseCueConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCue.Text"/>
    /// </summary>
    public TBuilder SetText(LocalizedString text)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Text = text;
          if (bp.Text is null)
          {
            bp.Text = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCue.Text"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyText(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Text is null) { return; }
          action.Invoke(bp.Text);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCue.Experience"/>
    /// </summary>
    public TBuilder SetExperience(DialogExperience experience)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Experience = experience;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCue.Experience"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyExperience(Action<DialogExperience> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Experience);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCue.Speaker"/>
    /// </summary>
    public TBuilder SetSpeaker(DialogSpeaker speaker)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(speaker);
          bp.Speaker = speaker;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCue.Speaker"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpeaker(Action<DialogSpeaker> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Speaker is null) { return; }
          action.Invoke(bp.Speaker);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCue.TurnSpeaker"/>
    /// </summary>
    public TBuilder SetTurnSpeaker(bool turnSpeaker = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TurnSpeaker = turnSpeaker;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCue.TurnSpeaker"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTurnSpeaker(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.TurnSpeaker);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCue.Animation"/>
    /// </summary>
    public TBuilder SetAnimation(DialogAnimation animation)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Animation = animation;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCue.Animation"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAnimation(Action<DialogAnimation> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Animation);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCue.m_Listener"/>
    /// </summary>
    ///
    /// <param name="listener">
    /// <para>
    /// Tooltip: Listener portrait (main character by default)
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetListener(Blueprint<BlueprintUnit, BlueprintUnitReference> listener)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Listener = listener?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCue.m_Listener"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="listener">
    /// <para>
    /// Tooltip: Listener portrait (main character by default)
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyListener(Action<BlueprintUnitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Listener is null) { return; }
          action.Invoke(bp.m_Listener);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCue.OnShow"/>
    /// </summary>
    public TBuilder SetOnShow(ActionsBuilder onShow)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OnShow = onShow?.Build();
          if (bp.OnShow is null)
          {
            bp.OnShow = Utils.Constants.Empty.Actions;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCue.OnShow"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOnShow(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OnShow is null) { return; }
          action.Invoke(bp.OnShow);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCue.OnStop"/>
    /// </summary>
    public TBuilder SetOnStop(ActionsBuilder onStop)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OnStop = onStop?.Build();
          if (bp.OnStop is null)
          {
            bp.OnStop = Utils.Constants.Empty.Actions;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCue.OnStop"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOnStop(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OnStop is null) { return; }
          action.Invoke(bp.OnStop);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCue.AlignmentShift"/>
    /// </summary>
    public TBuilder SetAlignmentShift(AlignmentShift alignmentShift)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(alignmentShift);
          bp.AlignmentShift = alignmentShift;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCue.AlignmentShift"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAlignmentShift(Action<AlignmentShift> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.AlignmentShift is null) { return; }
          action.Invoke(bp.AlignmentShift);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCue.Answers"/>
    /// </summary>
    ///
    /// <param name="answers">
    /// <para>
    /// Blueprint of type BlueprintAnswerBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAnswers(List<Blueprint<BlueprintAnswerBase, BlueprintAnswerBaseReference>> answers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Answers = answers?.Select(bp => bp.Reference)?.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCue.Answers"/>
    /// </summary>
    ///
    /// <param name="answers">
    /// <para>
    /// Blueprint of type BlueprintAnswerBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToAnswers(params Blueprint<BlueprintAnswerBase, BlueprintAnswerBaseReference>[] answers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Answers = bp.Answers ?? new();
          bp.Answers.AddRange(answers.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCue.Answers"/>
    /// </summary>
    ///
    /// <param name="answers">
    /// <para>
    /// Blueprint of type BlueprintAnswerBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAnswers(params Blueprint<BlueprintAnswerBase, BlueprintAnswerBaseReference>[] answers)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Answers is null) { return; }
          bp.Answers = bp.Answers.Where(val => !answers.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCue.Answers"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="answers">
    /// <para>
    /// Blueprint of type BlueprintAnswerBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAnswers(Func<BlueprintAnswerBaseReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Answers is null) { return; }
          bp.Answers = bp.Answers.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCue.Answers"/>
    /// </summary>
    ///
    /// <param name="answers">
    /// <para>
    /// Blueprint of type BlueprintAnswerBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearAnswers()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Answers = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCue.Answers"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="answers">
    /// <para>
    /// Blueprint of type BlueprintAnswerBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyAnswers(Action<BlueprintAnswerBaseReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Answers is null) { return; }
          bp.Answers.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCue.Continue"/>
    /// </summary>
    public TBuilder SetContinueValue(CueSelection continueValue)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(continueValue);
          bp.Continue = continueValue;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCue.Continue"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyContinueValue(Action<CueSelection> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Continue is null) { return; }
          action.Invoke(bp.Continue);
        });
    }
  }
}
