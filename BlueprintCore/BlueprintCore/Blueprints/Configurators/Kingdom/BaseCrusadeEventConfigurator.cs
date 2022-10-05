//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCrusadeEvent"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCrusadeEventConfigurator<T, TBuilder>
    : BaseKingdomEventBaseConfigurator<T, TBuilder>
    where T : BlueprintCrusadeEvent
    where TBuilder : BaseCrusadeEventConfigurator<T, TBuilder>
  {
    protected BaseCrusadeEventConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintCrusadeEvent>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_EventSolutions = copyFrom.m_EventSolutions;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCrusadeEvent.m_EventSolutions"/>
    /// </summary>
    public TBuilder SetEventSolutions(params EventSolution[] eventSolutions)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(eventSolutions);
          bp.m_EventSolutions = eventSolutions;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCrusadeEvent.m_EventSolutions"/>
    /// </summary>
    public TBuilder AddToEventSolutions(params EventSolution[] eventSolutions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_EventSolutions = bp.m_EventSolutions ?? new EventSolution[0];
          bp.m_EventSolutions = CommonTool.Append(bp.m_EventSolutions, eventSolutions);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCrusadeEvent.m_EventSolutions"/>
    /// </summary>
    public TBuilder RemoveFromEventSolutions(params EventSolution[] eventSolutions)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_EventSolutions is null) { return; }
          bp.m_EventSolutions = bp.m_EventSolutions.Where(val => !eventSolutions.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCrusadeEvent.m_EventSolutions"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromEventSolutions(Func<EventSolution, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_EventSolutions is null) { return; }
          bp.m_EventSolutions = bp.m_EventSolutions.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCrusadeEvent.m_EventSolutions"/>
    /// </summary>
    public TBuilder ClearEventSolutions()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_EventSolutions = new EventSolution[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCrusadeEvent.m_EventSolutions"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyEventSolutions(Action<EventSolution> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_EventSolutions is null) { return; }
          bp.m_EventSolutions.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_EventSolutions is null)
      {
        Blueprint.m_EventSolutions = new EventSolution[0];
      }
    }
  }
}
