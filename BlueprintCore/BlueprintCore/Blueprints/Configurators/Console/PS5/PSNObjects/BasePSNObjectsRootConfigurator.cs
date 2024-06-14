//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Console.PS5.PSNObjects;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Console.PS5.PSNObjects
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintPSNObjectsRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BasePSNObjectsRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintPSNObjectsRoot
    where TBuilder : BasePSNObjectsRootConfigurator<T, TBuilder>
  {
    protected BasePSNObjectsRootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintPSNObjectsRoot>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Activities = copyFrom.Activities;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintPSNObjectsRoot>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Activities = copyFrom.Activities;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintPSNObjectsRoot.Activities"/>
    /// </summary>
    public TBuilder SetActivities(params BlueprintPSNObjectsRoot.ActivityData[] activities)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(activities);
          bp.Activities = activities;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintPSNObjectsRoot.Activities"/>
    /// </summary>
    public TBuilder AddToActivities(params BlueprintPSNObjectsRoot.ActivityData[] activities)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Activities = bp.Activities ?? new BlueprintPSNObjectsRoot.ActivityData[0];
          bp.Activities = CommonTool.Append(bp.Activities, activities);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintPSNObjectsRoot.Activities"/>
    /// </summary>
    public TBuilder RemoveFromActivities(params BlueprintPSNObjectsRoot.ActivityData[] activities)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Activities is null) { return; }
          bp.Activities = bp.Activities.Where(val => !activities.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintPSNObjectsRoot.Activities"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromActivities(Func<BlueprintPSNObjectsRoot.ActivityData, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Activities is null) { return; }
          bp.Activities = bp.Activities.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintPSNObjectsRoot.Activities"/>
    /// </summary>
    public TBuilder ClearActivities()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Activities = new BlueprintPSNObjectsRoot.ActivityData[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintPSNObjectsRoot.Activities"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyActivities(Action<BlueprintPSNObjectsRoot.ActivityData> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Activities is null) { return; }
          bp.Activities.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Activities is null)
      {
        Blueprint.Activities = new BlueprintPSNObjectsRoot.ActivityData[0];
      }
    }
  }
}
