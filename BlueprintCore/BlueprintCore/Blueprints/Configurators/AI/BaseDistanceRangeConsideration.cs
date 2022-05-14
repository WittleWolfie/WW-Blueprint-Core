//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="DistanceRangeConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDistanceRangeConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : DistanceRangeConsideration
    where TBuilder : BaseDistanceRangeConsiderationConfigurator<T, TBuilder>
  {
    protected BaseDistanceRangeConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="DistanceRangeConsideration.MinDistance"/>
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
    /// Modifies <see cref="DistanceRangeConsideration.MinDistance"/> by invoking the provided action.
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
    /// Sets the value of <see cref="DistanceRangeConsideration.MaxDistance"/>
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
    /// Modifies <see cref="DistanceRangeConsideration.MaxDistance"/> by invoking the provided action.
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
    /// Sets the value of <see cref="DistanceRangeConsideration.InsideDistanceRangeScore"/>
    /// </summary>
    public TBuilder SetInsideDistanceRangeScore(float insideDistanceRangeScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.InsideDistanceRangeScore = insideDistanceRangeScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="DistanceRangeConsideration.InsideDistanceRangeScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyInsideDistanceRangeScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.InsideDistanceRangeScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="DistanceRangeConsideration.OutsideDistanceRangeScore"/>
    /// </summary>
    public TBuilder SetOutsideDistanceRangeScore(float outsideDistanceRangeScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OutsideDistanceRangeScore = outsideDistanceRangeScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="DistanceRangeConsideration.OutsideDistanceRangeScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOutsideDistanceRangeScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.OutsideDistanceRangeScore);
        });
    }
  }
}
