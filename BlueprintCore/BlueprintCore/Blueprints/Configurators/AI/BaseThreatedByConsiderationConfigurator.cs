//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="ThreatedByConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseThreatedByConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : ThreatedByConsideration
    where TBuilder : BaseThreatedByConsiderationConfigurator<T, TBuilder>
  {
    protected BaseThreatedByConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<ThreatedByConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.MinCount = copyFrom.MinCount;
          bp.MaxCount = copyFrom.MaxCount;
          bp.BelowMinScore = copyFrom.BelowMinScore;
          bp.MinScore = copyFrom.MinScore;
          bp.MaxScore = copyFrom.MaxScore;
          bp.ExtraTargetScore = copyFrom.ExtraTargetScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ThreatedByConsideration.MinCount"/>
    /// </summary>
    public TBuilder SetMinCount(int minCount)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinCount = minCount;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ThreatedByConsideration.MaxCount"/>
    /// </summary>
    public TBuilder SetMaxCount(int maxCount)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaxCount = maxCount;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ThreatedByConsideration.BelowMinScore"/>
    /// </summary>
    public TBuilder SetBelowMinScore(float belowMinScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BelowMinScore = belowMinScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ThreatedByConsideration.MinScore"/>
    /// </summary>
    public TBuilder SetMinScore(float minScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinScore = minScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ThreatedByConsideration.MaxScore"/>
    /// </summary>
    public TBuilder SetMaxScore(float maxScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaxScore = maxScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ThreatedByConsideration.ExtraTargetScore"/>
    /// </summary>
    public TBuilder SetExtraTargetScore(float extraTargetScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ExtraTargetScore = extraTargetScore;
        });
    }
  }
}
