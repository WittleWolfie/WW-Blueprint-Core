//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintSequenceExit"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseSequenceExitConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintSequenceExit
    where TBuilder : BaseSequenceExitConfigurator<T, TBuilder>
  {
    protected BaseSequenceExitConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSequenceExit.Answers"/>
    /// </summary>
    ///
    /// <param name="answers">
    /// <para>
    /// Blueprint of type BlueprintAnswerBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAnswers(params Blueprint<BlueprintAnswerBaseReference>[] answers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Answers = answers.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintSequenceExit.Answers"/>
    /// </summary>
    ///
    /// <param name="answers">
    /// <para>
    /// Blueprint of type BlueprintAnswerBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToAnswers(params Blueprint<BlueprintAnswerBaseReference>[] answers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Answers = bp.Answers ?? new();
          bp.Answers.AddRange(answers.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintSequenceExit.Answers"/>
    /// </summary>
    ///
    /// <param name="answers">
    /// <para>
    /// Blueprint of type BlueprintAnswerBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAnswers(params Blueprint<BlueprintAnswerBaseReference>[] answers)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Answers is null) { return; }
          bp.Answers = bp.Answers.Where(val => !answers.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintSequenceExit.Answers"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromAnswers(Func<BlueprintAnswerBaseReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Answers is null) { return; }
          bp.Answers = bp.Answers.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintSequenceExit.Answers"/>
    /// </summary>
    public TBuilder ClearAnswers()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Answers = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSequenceExit.Answers"/> by invoking the provided action on each element.
    /// </summary>
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
    /// Sets the value of <see cref="BlueprintSequenceExit.Continue"/>
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
    /// Modifies <see cref="BlueprintSequenceExit.Continue"/> by invoking the provided action.
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

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Answers is null)
      {
        Blueprint.Answers = new();
      }
    }
  }
}
