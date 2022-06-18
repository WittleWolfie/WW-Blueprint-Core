//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.QA.Clockwork;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.QA
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintClockworkScenarioPart"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseClockworkScenarioPartConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintClockworkScenarioPart
    where TBuilder : BaseClockworkScenarioPartConfigurator<T, TBuilder>
  {
    protected BaseClockworkScenarioPartConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenarioPart.RetrySkillChecks"/>
    /// </summary>
    public TBuilder SetRetrySkillChecks(params EntityReference[] retrySkillChecks)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(retrySkillChecks);
          bp.RetrySkillChecks = retrySkillChecks.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintClockworkScenarioPart.RetrySkillChecks"/>
    /// </summary>
    public TBuilder AddToRetrySkillChecks(params EntityReference[] retrySkillChecks)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RetrySkillChecks = bp.RetrySkillChecks ?? new();
          bp.RetrySkillChecks.AddRange(retrySkillChecks);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenarioPart.RetrySkillChecks"/>
    /// </summary>
    public TBuilder RemoveFromRetrySkillChecks(params EntityReference[] retrySkillChecks)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RetrySkillChecks is null) { return; }
          bp.RetrySkillChecks = bp.RetrySkillChecks.Where(val => !retrySkillChecks.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenarioPart.RetrySkillChecks"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromRetrySkillChecks(Func<EntityReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RetrySkillChecks is null) { return; }
          bp.RetrySkillChecks = bp.RetrySkillChecks.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintClockworkScenarioPart.RetrySkillChecks"/>
    /// </summary>
    public TBuilder ClearRetrySkillChecks()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RetrySkillChecks = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenarioPart.RetrySkillChecks"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyRetrySkillChecks(Action<EntityReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RetrySkillChecks is null) { return; }
          bp.RetrySkillChecks.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenarioPart.HighPriorityAnswers"/>
    /// </summary>
    ///
    /// <param name="highPriorityAnswers">
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
    public TBuilder SetHighPriorityAnswers(params Blueprint<BlueprintAnswerReference>[] highPriorityAnswers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HighPriorityAnswers = highPriorityAnswers.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintClockworkScenarioPart.HighPriorityAnswers"/>
    /// </summary>
    ///
    /// <param name="highPriorityAnswers">
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
    public TBuilder AddToHighPriorityAnswers(params Blueprint<BlueprintAnswerReference>[] highPriorityAnswers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HighPriorityAnswers = bp.HighPriorityAnswers ?? new();
          bp.HighPriorityAnswers.AddRange(highPriorityAnswers.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenarioPart.HighPriorityAnswers"/>
    /// </summary>
    ///
    /// <param name="highPriorityAnswers">
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
    public TBuilder RemoveFromHighPriorityAnswers(params Blueprint<BlueprintAnswerReference>[] highPriorityAnswers)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.HighPriorityAnswers is null) { return; }
          bp.HighPriorityAnswers = bp.HighPriorityAnswers.Where(val => !highPriorityAnswers.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenarioPart.HighPriorityAnswers"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromHighPriorityAnswers(Func<BlueprintAnswerReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.HighPriorityAnswers is null) { return; }
          bp.HighPriorityAnswers = bp.HighPriorityAnswers.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintClockworkScenarioPart.HighPriorityAnswers"/>
    /// </summary>
    public TBuilder ClearHighPriorityAnswers()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HighPriorityAnswers = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenarioPart.HighPriorityAnswers"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyHighPriorityAnswers(Action<BlueprintAnswerReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.HighPriorityAnswers is null) { return; }
          bp.HighPriorityAnswers.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenarioPart.DoNotSellItems"/>
    /// </summary>
    ///
    /// <param name="doNotSellItems">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetDoNotSellItems(params Blueprint<BlueprintItemReference>[] doNotSellItems)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotSellItems = doNotSellItems.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintClockworkScenarioPart.DoNotSellItems"/>
    /// </summary>
    ///
    /// <param name="doNotSellItems">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToDoNotSellItems(params Blueprint<BlueprintItemReference>[] doNotSellItems)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotSellItems = bp.DoNotSellItems ?? new();
          bp.DoNotSellItems.AddRange(doNotSellItems.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenarioPart.DoNotSellItems"/>
    /// </summary>
    ///
    /// <param name="doNotSellItems">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromDoNotSellItems(params Blueprint<BlueprintItemReference>[] doNotSellItems)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotSellItems is null) { return; }
          bp.DoNotSellItems = bp.DoNotSellItems.Where(val => !doNotSellItems.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenarioPart.DoNotSellItems"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromDoNotSellItems(Func<BlueprintItemReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotSellItems is null) { return; }
          bp.DoNotSellItems = bp.DoNotSellItems.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintClockworkScenarioPart.DoNotSellItems"/>
    /// </summary>
    public TBuilder ClearDoNotSellItems()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotSellItems = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenarioPart.DoNotSellItems"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyDoNotSellItems(Action<BlueprintItemReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotSellItems is null) { return; }
          bp.DoNotSellItems.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenarioPart.DoNotInterract"/>
    /// </summary>
    public TBuilder SetDoNotInterract(params ClockworkEntityReference[] doNotInterract)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(doNotInterract);
          bp.DoNotInterract = doNotInterract.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintClockworkScenarioPart.DoNotInterract"/>
    /// </summary>
    public TBuilder AddToDoNotInterract(params ClockworkEntityReference[] doNotInterract)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotInterract = bp.DoNotInterract ?? new();
          bp.DoNotInterract.AddRange(doNotInterract);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenarioPart.DoNotInterract"/>
    /// </summary>
    public TBuilder RemoveFromDoNotInterract(params ClockworkEntityReference[] doNotInterract)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotInterract is null) { return; }
          bp.DoNotInterract = bp.DoNotInterract.Where(val => !doNotInterract.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenarioPart.DoNotInterract"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromDoNotInterract(Func<ClockworkEntityReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotInterract is null) { return; }
          bp.DoNotInterract = bp.DoNotInterract.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintClockworkScenarioPart.DoNotInterract"/>
    /// </summary>
    public TBuilder ClearDoNotInterract()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotInterract = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenarioPart.DoNotInterract"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyDoNotInterract(Action<ClockworkEntityReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotInterract is null) { return; }
          bp.DoNotInterract.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenarioPart.DoNotInterractUnits"/>
    /// </summary>
    ///
    /// <param name="doNotInterractUnits">
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
    public TBuilder SetDoNotInterractUnits(params Blueprint<BlueprintUnitReference>[] doNotInterractUnits)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotInterractUnits = doNotInterractUnits.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintClockworkScenarioPart.DoNotInterractUnits"/>
    /// </summary>
    ///
    /// <param name="doNotInterractUnits">
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
    public TBuilder AddToDoNotInterractUnits(params Blueprint<BlueprintUnitReference>[] doNotInterractUnits)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotInterractUnits = bp.DoNotInterractUnits ?? new();
          bp.DoNotInterractUnits.AddRange(doNotInterractUnits.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenarioPart.DoNotInterractUnits"/>
    /// </summary>
    ///
    /// <param name="doNotInterractUnits">
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
    public TBuilder RemoveFromDoNotInterractUnits(params Blueprint<BlueprintUnitReference>[] doNotInterractUnits)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotInterractUnits is null) { return; }
          bp.DoNotInterractUnits = bp.DoNotInterractUnits.Where(val => !doNotInterractUnits.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenarioPart.DoNotInterractUnits"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromDoNotInterractUnits(Func<BlueprintUnitReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotInterractUnits is null) { return; }
          bp.DoNotInterractUnits = bp.DoNotInterractUnits.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintClockworkScenarioPart.DoNotInterractUnits"/>
    /// </summary>
    public TBuilder ClearDoNotInterractUnits()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotInterractUnits = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenarioPart.DoNotInterractUnits"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyDoNotInterractUnits(Action<BlueprintUnitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotInterractUnits is null) { return; }
          bp.DoNotInterractUnits.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenarioPart.DoNotUseAnswer"/>
    /// </summary>
    ///
    /// <param name="doNotUseAnswer">
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
    public TBuilder SetDoNotUseAnswer(params Blueprint<BlueprintAnswerReference>[] doNotUseAnswer)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotUseAnswer = doNotUseAnswer.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintClockworkScenarioPart.DoNotUseAnswer"/>
    /// </summary>
    ///
    /// <param name="doNotUseAnswer">
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
    public TBuilder AddToDoNotUseAnswer(params Blueprint<BlueprintAnswerReference>[] doNotUseAnswer)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotUseAnswer = bp.DoNotUseAnswer ?? new();
          bp.DoNotUseAnswer.AddRange(doNotUseAnswer.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenarioPart.DoNotUseAnswer"/>
    /// </summary>
    ///
    /// <param name="doNotUseAnswer">
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
    public TBuilder RemoveFromDoNotUseAnswer(params Blueprint<BlueprintAnswerReference>[] doNotUseAnswer)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotUseAnswer is null) { return; }
          bp.DoNotUseAnswer = bp.DoNotUseAnswer.Where(val => !doNotUseAnswer.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenarioPart.DoNotUseAnswer"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromDoNotUseAnswer(Func<BlueprintAnswerReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotUseAnswer is null) { return; }
          bp.DoNotUseAnswer = bp.DoNotUseAnswer.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintClockworkScenarioPart.DoNotUseAnswer"/>
    /// </summary>
    public TBuilder ClearDoNotUseAnswer()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotUseAnswer = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenarioPart.DoNotUseAnswer"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyDoNotUseAnswer(Action<BlueprintAnswerReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotUseAnswer is null) { return; }
          bp.DoNotUseAnswer.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenarioPart.DoNotEnterAreas"/>
    /// </summary>
    ///
    /// <param name="doNotEnterAreas">
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetDoNotEnterAreas(params Blueprint<BlueprintAreaReference>[] doNotEnterAreas)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotEnterAreas = doNotEnterAreas.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintClockworkScenarioPart.DoNotEnterAreas"/>
    /// </summary>
    ///
    /// <param name="doNotEnterAreas">
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToDoNotEnterAreas(params Blueprint<BlueprintAreaReference>[] doNotEnterAreas)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotEnterAreas = bp.DoNotEnterAreas ?? new();
          bp.DoNotEnterAreas.AddRange(doNotEnterAreas.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenarioPart.DoNotEnterAreas"/>
    /// </summary>
    ///
    /// <param name="doNotEnterAreas">
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromDoNotEnterAreas(params Blueprint<BlueprintAreaReference>[] doNotEnterAreas)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotEnterAreas is null) { return; }
          bp.DoNotEnterAreas = bp.DoNotEnterAreas.Where(val => !doNotEnterAreas.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenarioPart.DoNotEnterAreas"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromDoNotEnterAreas(Func<BlueprintAreaReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotEnterAreas is null) { return; }
          bp.DoNotEnterAreas = bp.DoNotEnterAreas.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintClockworkScenarioPart.DoNotEnterAreas"/>
    /// </summary>
    public TBuilder ClearDoNotEnterAreas()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotEnterAreas = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenarioPart.DoNotEnterAreas"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyDoNotEnterAreas(Action<BlueprintAreaReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotEnterAreas is null) { return; }
          bp.DoNotEnterAreas.ForEach(action);
        });
    }

    /// <summary>
    /// Adds <see cref="AreaTest"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Clockwork/Area Test
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>123</term><description>535217378b8a4ca3ba5a45f0002de07c</description></item>
    /// <item><term>Drezen_Prison</term><description>eab84d625d847bf48864dbe56d30e0b6</description></item>
    /// <item><term>WarCamp_Start_Simple</term><description>cc9b472d6185c754f9f7f8090aef6c8b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="area">
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="areaPart">
    /// <para>
    /// Blueprint of type BlueprintAreaPart. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddAreaTest(
        Blueprint<BlueprintAreaReference>? area = null,
        Blueprint<BlueprintAreaPartReference>? areaPart = null,
        ClockworkCommandList? commandList = null,
        Condition? condition = null,
        bool? everyVisit = null)
    {
      var component = new AreaTest();
      component.Area = area?.Reference ?? component.Area;
      if (component.Area is null)
      {
        component.Area = BlueprintTool.GetRef<BlueprintAreaReference>(null);
      }
      component.AreaPart = areaPart?.Reference ?? component.AreaPart;
      if (component.AreaPart is null)
      {
        component.AreaPart = BlueprintTool.GetRef<BlueprintAreaPartReference>(null);
      }
      Validate(commandList);
      component.CommandList = commandList ?? component.CommandList;
      Validate(condition);
      component.Condition = condition ?? component.Condition;
      component.EveryVisit = everyVisit ?? component.EveryVisit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConditionalCommandList"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Clockwork/Conditional Command List
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>chap0</term><description>95c4212a36594186b509e87d00d2d480</description></item>
    /// <item><term>mDemon3chap</term><description>6383f35b37eb4a83a8a8458f2937156c</description></item>
    /// <item><term>WoljifQ</term><description>d79f05dbd35b468fa16312f30d61a5e1</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddConditionalCommandList(
        ClockworkCommandList? commandList = null,
        Condition? condition = null)
    {
      var component = new ConditionalCommandList();
      Validate(commandList);
      component.CommandList = commandList ?? component.CommandList;
      Validate(condition);
      component.Condition = condition ?? component.Condition;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MythicLevelUpPlan"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Clockwork/MythicLevelUpPlan
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon_Fighter</term><description>de62074c6cc24ce89073a349aebefef6</description></item>
    /// <item><term>Lich_Fighter</term><description>b0ec7b4817594e7aa941d4c2cd6d04a6</description></item>
    /// <item><term>Trickster_Fighter</term><description>3e0f32cbd70a4773aff644efc48451ab</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="beginnerMythic">
    /// <para>
    /// InfoBox: Первые 2 уровня доступен только Mythic Hero
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="earlyMythic">
    /// <para>
    /// InfoBox: План срабатывает при левелапе на 3 уровень
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="lateMythic">
    /// <para>
    /// InfoBox: План срабатывает при левелапе на 9 уровень
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddMythicLevelUpPlan(
        Blueprint<BlueprintFeatureReference>? beginnerMythic = null,
        Blueprint<BlueprintFeatureReference>? earlyMythic = null,
        Blueprint<BlueprintFeatureReference>? lateMythic = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new MythicLevelUpPlan();
      component.BeginnerMythic = beginnerMythic?.Reference ?? component.BeginnerMythic;
      if (component.BeginnerMythic is null)
      {
        component.BeginnerMythic = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      component.EarlyMythic = earlyMythic?.Reference ?? component.EarlyMythic;
      if (component.EarlyMythic is null)
      {
        component.EarlyMythic = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      component.LateMythic = lateMythic?.Reference ?? component.LateMythic;
      if (component.LateMythic is null)
      {
        component.LateMythic = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="NavmeshHolesChecker"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Clockwork/NavmeshHolesChecker
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon_Fighter</term><description>de62074c6cc24ce89073a349aebefef6</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddNavmeshHolesChecker(
        bool? isInit = null,
        float? lastHeight = null,
        float? maxDeltaHeightPerFrame = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new NavmeshHolesChecker();
      component.m_IsInit = isInit ?? component.m_IsInit;
      component.m_LastHeight = lastHeight ?? component.m_LastHeight;
      component.MaxDeltaHeightPerFrame = maxDeltaHeightPerFrame ?? component.MaxDeltaHeightPerFrame;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    protected override void SetDefaults()
    {
      base.SetDefaults();
    
      if (Blueprint.RetrySkillChecks is null)
      {
        Blueprint.RetrySkillChecks = new();
      }
      if (Blueprint.HighPriorityAnswers is null)
      {
        Blueprint.HighPriorityAnswers = new();
      }
      if (Blueprint.DoNotSellItems is null)
      {
        Blueprint.DoNotSellItems = new();
      }
      if (Blueprint.DoNotInterract is null)
      {
        Blueprint.DoNotInterract = new();
      }
      if (Blueprint.DoNotInterractUnits is null)
      {
        Blueprint.DoNotInterractUnits = new();
      }
      if (Blueprint.DoNotUseAnswer is null)
      {
        Blueprint.DoNotUseAnswer = new();
      }
      if (Blueprint.DoNotEnterAreas is null)
      {
        Blueprint.DoNotEnterAreas = new();
      }
    }
  }
}
