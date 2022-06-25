//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="LifeStateConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseLifeStateConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : LifeStateConsideration
    where TBuilder : BaseLifeStateConsiderationConfigurator<T, TBuilder>
  {
    protected BaseLifeStateConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="LifeStateConsideration.AliveScore"/>
    /// </summary>
    public TBuilder SetAliveScore(float aliveScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AliveScore = aliveScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="LifeStateConsideration.AliveScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAliveScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AliveScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LifeStateConsideration.DeadScore"/>
    /// </summary>
    public TBuilder SetDeadScore(float deadScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DeadScore = deadScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="LifeStateConsideration.DeadScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDeadScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.DeadScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LifeStateConsideration.UnconsciousScore"/>
    /// </summary>
    public TBuilder SetUnconsciousScore(float unconsciousScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UnconsciousScore = unconsciousScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="LifeStateConsideration.UnconsciousScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUnconsciousScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.UnconsciousScore);
        });
    }
  }
}
