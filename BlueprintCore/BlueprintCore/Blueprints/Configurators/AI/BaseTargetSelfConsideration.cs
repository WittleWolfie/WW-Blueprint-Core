//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="TargetSelfConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTargetSelfConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : TargetSelfConsideration
    where TBuilder : BaseTargetSelfConsiderationConfigurator<T, TBuilder>
  {
    protected BaseTargetSelfConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="TargetSelfConsideration.SelfScore"/>
    /// </summary>
    public TBuilder SetSelfScore(float selfScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SelfScore = selfScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="TargetSelfConsideration.SelfScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySelfScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.SelfScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="TargetSelfConsideration.OthersScore"/>
    /// </summary>
    public TBuilder SetOthersScore(float othersScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OthersScore = othersScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="TargetSelfConsideration.OthersScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOthersScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.OthersScore);
        });
    }
  }
}
