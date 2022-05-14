//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="CanMakeFullAttackConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCanMakeFullAttackConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : CanMakeFullAttackConsideration
    where TBuilder : BaseCanMakeFullAttackConsiderationConfigurator<T, TBuilder>
  {
    protected BaseCanMakeFullAttackConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="CanMakeFullAttackConsideration.SuccessScore"/>
    /// </summary>
    public TBuilder SetSuccessScore(float successScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SuccessScore = successScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="CanMakeFullAttackConsideration.SuccessScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySuccessScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.SuccessScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="CanMakeFullAttackConsideration.FailScore"/>
    /// </summary>
    public TBuilder SetFailScore(float failScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FailScore = failScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="CanMakeFullAttackConsideration.FailScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFailScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.FailScore);
        });
    }
  }
}
