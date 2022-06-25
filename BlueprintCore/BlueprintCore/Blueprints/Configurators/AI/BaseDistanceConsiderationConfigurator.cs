//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="DistanceConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDistanceConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : DistanceConsideration
    where TBuilder : BaseDistanceConsiderationConfigurator<T, TBuilder>
  {
    protected BaseDistanceConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="DistanceConsideration.MinDistance"/>
    /// </summary>
    public TBuilder SetMinDistance(float minDistance)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinDistance = minDistance;
        });
    }

    /// <summary>
    /// Modifies <see cref="DistanceConsideration.MinDistance"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMinDistance(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MinDistance);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="DistanceConsideration.MaxDistance"/>
    /// </summary>
    public TBuilder SetMaxDistance(float maxDistance)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaxDistance = maxDistance;
        });
    }

    /// <summary>
    /// Modifies <see cref="DistanceConsideration.MaxDistance"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMaxDistance(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MaxDistance);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="DistanceConsideration.MaxDistanceScore"/>
    /// </summary>
    public TBuilder SetMaxDistanceScore(float maxDistanceScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaxDistanceScore = maxDistanceScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="DistanceConsideration.MaxDistanceScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMaxDistanceScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MaxDistanceScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="DistanceConsideration.MinDistanceScore"/>
    /// </summary>
    public TBuilder SetMinDistanceScore(float minDistanceScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinDistanceScore = minDistanceScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="DistanceConsideration.MinDistanceScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMinDistanceScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MinDistanceScore);
        });
    }
  }
}
