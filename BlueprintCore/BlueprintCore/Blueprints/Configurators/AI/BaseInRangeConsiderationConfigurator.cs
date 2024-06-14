//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="InRangeConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseInRangeConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : InRangeConsideration
    where TBuilder : BaseInRangeConsiderationConfigurator<T, TBuilder>
  {
    protected BaseInRangeConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<InRangeConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.InRangeScore = copyFrom.InRangeScore;
          bp.OutOfRangeScore = copyFrom.OutOfRangeScore;
          bp.OnlyIfThreated = copyFrom.OnlyIfThreated;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<InRangeConsideration>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.InRangeScore = copyFrom.InRangeScore;
          bp.OutOfRangeScore = copyFrom.OutOfRangeScore;
          bp.OnlyIfThreated = copyFrom.OnlyIfThreated;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="InRangeConsideration.InRangeScore"/>
    /// </summary>
    public TBuilder SetInRangeScore(float inRangeScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.InRangeScore = inRangeScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="InRangeConsideration.OutOfRangeScore"/>
    /// </summary>
    public TBuilder SetOutOfRangeScore(float outOfRangeScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OutOfRangeScore = outOfRangeScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="InRangeConsideration.OnlyIfThreated"/>
    /// </summary>
    public TBuilder SetOnlyIfThreated(bool onlyIfThreated = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OnlyIfThreated = onlyIfThreated;
        });
    }
  }
}
