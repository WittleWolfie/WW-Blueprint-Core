//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintTimelineRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTimelineRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintTimelineRoot
    where TBuilder : BaseTimelineRootConfigurator<T, TBuilder>
  {
    protected BaseTimelineRootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintTimelineRoot>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.FixTimelines = copyFrom.FixTimelines;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintTimelineRoot>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.FixTimelines = copyFrom.FixTimelines;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTimelineRoot.FixTimelines"/>
    /// </summary>
    public TBuilder SetFixTimelines(params BlueprintTimelineRoot.TimelineFixer[] fixTimelines)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(fixTimelines);
          bp.FixTimelines = fixTimelines;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintTimelineRoot.FixTimelines"/>
    /// </summary>
    public TBuilder AddToFixTimelines(params BlueprintTimelineRoot.TimelineFixer[] fixTimelines)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FixTimelines = bp.FixTimelines ?? new BlueprintTimelineRoot.TimelineFixer[0];
          bp.FixTimelines = CommonTool.Append(bp.FixTimelines, fixTimelines);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintTimelineRoot.FixTimelines"/>
    /// </summary>
    public TBuilder RemoveFromFixTimelines(params BlueprintTimelineRoot.TimelineFixer[] fixTimelines)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FixTimelines is null) { return; }
          bp.FixTimelines = bp.FixTimelines.Where(val => !fixTimelines.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintTimelineRoot.FixTimelines"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromFixTimelines(Func<BlueprintTimelineRoot.TimelineFixer, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FixTimelines is null) { return; }
          bp.FixTimelines = bp.FixTimelines.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintTimelineRoot.FixTimelines"/>
    /// </summary>
    public TBuilder ClearFixTimelines()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FixTimelines = new BlueprintTimelineRoot.TimelineFixer[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTimelineRoot.FixTimelines"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyFixTimelines(Action<BlueprintTimelineRoot.TimelineFixer> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FixTimelines is null) { return; }
          bp.FixTimelines.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.FixTimelines is null)
      {
        Blueprint.FixTimelines = new BlueprintTimelineRoot.TimelineFixer[0];
      }
    }
  }
}
