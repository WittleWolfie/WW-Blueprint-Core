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

    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<DistanceConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.MinDistance = copyFrom.MinDistance;
          bp.MaxDistance = copyFrom.MaxDistance;
          bp.MaxDistanceScore = copyFrom.MaxDistanceScore;
          bp.MinDistanceScore = copyFrom.MinDistanceScore;
        });
    }

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
  }
}
