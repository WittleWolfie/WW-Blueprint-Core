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
    protected BaseThreatedByConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

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
    /// Modifies <see cref="ThreatedByConsideration.MinCount"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMinCount(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MinCount);
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
    /// Modifies <see cref="ThreatedByConsideration.MaxCount"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMaxCount(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MaxCount);
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
    /// Modifies <see cref="ThreatedByConsideration.BelowMinScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBelowMinScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.BelowMinScore);
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
    /// Modifies <see cref="ThreatedByConsideration.MinScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMinScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MinScore);
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
    /// Modifies <see cref="ThreatedByConsideration.MaxScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMaxScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MaxScore);
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

    /// <summary>
    /// Modifies <see cref="ThreatedByConsideration.ExtraTargetScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyExtraTargetScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ExtraTargetScore);
        });
    }
  }
}
