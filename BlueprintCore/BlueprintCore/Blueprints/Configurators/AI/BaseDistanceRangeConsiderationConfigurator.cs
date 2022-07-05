//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;

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
