//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAnswersList"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAnswersListConfigurator<T, TBuilder>
    : BaseAnswerBaseConfigurator<T, TBuilder>
    where T : BlueprintAnswersList
    where TBuilder : BaseAnswersListConfigurator<T, TBuilder>
  {
    protected BaseAnswersListConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAnswersList.ShowOnce"/>
    /// </summary>
    public TBuilder SetShowOnce(bool showOnce = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ShowOnce = showOnce;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAnswersList.Conditions"/>
    /// </summary>
    public TBuilder SetConditions(ConditionsBuilder conditions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Conditions = conditions?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAnswersList.Conditions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyConditions(Action<ConditionsChecker> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Conditions is null) { return; }
          action.Invoke(bp.Conditions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAnswersList.Answers"/>
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
    /// Adds to the contents of <see cref="BlueprintAnswersList.Answers"/>
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
    /// Removes elements from <see cref="BlueprintAnswersList.Answers"/>
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
    /// Removes elements from <see cref="BlueprintAnswersList.Answers"/> that match the provided predicate.
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
    /// Removes all elements from <see cref="BlueprintAnswersList.Answers"/>
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
    /// Modifies <see cref="BlueprintAnswersList.Answers"/> by invoking the provided action on each element.
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

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Conditions is null)
      {
        Blueprint.Conditions = Utils.Constants.Empty.Conditions;
      }
      if (Blueprint.Answers is null)
      {
        Blueprint.Answers = new();
      }
    }
  }
}
