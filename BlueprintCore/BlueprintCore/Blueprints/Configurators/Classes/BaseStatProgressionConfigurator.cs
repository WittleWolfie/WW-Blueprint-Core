//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintStatProgression"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseStatProgressionConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintStatProgression
    where TBuilder : BaseStatProgressionConfigurator<T, TBuilder>
  {
    protected BaseStatProgressionConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintStatProgression>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Bonuses = copyFrom.Bonuses;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintStatProgression>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Bonuses = copyFrom.Bonuses;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintStatProgression.Bonuses"/>
    /// </summary>
    public TBuilder SetBonuses(params int[] bonuses)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Bonuses = bonuses;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintStatProgression.Bonuses"/>
    /// </summary>
    public TBuilder AddToBonuses(params int[] bonuses)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Bonuses = bp.Bonuses ?? new int[0];
          bp.Bonuses = CommonTool.Append(bp.Bonuses, bonuses);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintStatProgression.Bonuses"/>
    /// </summary>
    public TBuilder RemoveFromBonuses(params int[] bonuses)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Bonuses is null) { return; }
          bp.Bonuses = bp.Bonuses.Where(val => !bonuses.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintStatProgression.Bonuses"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromBonuses(Func<int, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Bonuses is null) { return; }
          bp.Bonuses = bp.Bonuses.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintStatProgression.Bonuses"/>
    /// </summary>
    public TBuilder ClearBonuses()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Bonuses = new int[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintStatProgression.Bonuses"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyBonuses(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Bonuses is null) { return; }
          bp.Bonuses.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Bonuses is null)
      {
        Blueprint.Bonuses = new int[0];
      }
    }
  }
}
