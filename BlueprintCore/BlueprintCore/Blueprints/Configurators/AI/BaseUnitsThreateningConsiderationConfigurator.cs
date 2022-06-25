//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="UnitsThreateningConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseUnitsThreateningConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : UnitsThreateningConsideration
    where TBuilder : BaseUnitsThreateningConsiderationConfigurator<T, TBuilder>
  {
    protected BaseUnitsThreateningConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="UnitsThreateningConsideration.MinCount"/>
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
    /// Modifies <see cref="UnitsThreateningConsideration.MinCount"/> by invoking the provided action.
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
    /// Sets the value of <see cref="UnitsThreateningConsideration.MaxCount"/>
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
    /// Modifies <see cref="UnitsThreateningConsideration.MaxCount"/> by invoking the provided action.
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
    /// Sets the value of <see cref="UnitsThreateningConsideration.BelowMinScore"/>
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
    /// Modifies <see cref="UnitsThreateningConsideration.BelowMinScore"/> by invoking the provided action.
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
    /// Sets the value of <see cref="UnitsThreateningConsideration.MinScore"/>
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
    /// Modifies <see cref="UnitsThreateningConsideration.MinScore"/> by invoking the provided action.
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
    /// Sets the value of <see cref="UnitsThreateningConsideration.MaxScore"/>
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
    /// Modifies <see cref="UnitsThreateningConsideration.MaxScore"/> by invoking the provided action.
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
    /// Sets the value of <see cref="UnitsThreateningConsideration.ExtraTargetScore"/>
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
    /// Modifies <see cref="UnitsThreateningConsideration.ExtraTargetScore"/> by invoking the provided action.
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
