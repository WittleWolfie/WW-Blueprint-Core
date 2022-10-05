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
    protected BaseDistanceRangeConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<DistanceRangeConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.MinDistance = copyFrom.MinDistance;
          bp.MaxDistance = copyFrom.MaxDistance;
          bp.InsideDistanceRangeScore = copyFrom.InsideDistanceRangeScore;
          bp.OutsideDistanceRangeScore = copyFrom.OutsideDistanceRangeScore;
        });
    }

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
  }
}
