//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="HitThisRoundConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseHitThisRoundConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : HitThisRoundConsideration
    where TBuilder : BaseHitThisRoundConsiderationConfigurator<T, TBuilder>
  {
    protected BaseHitThisRoundConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="HitThisRoundConsideration.HitScore"/>
    /// </summary>
    public TBuilder SetHitScore(float hitScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HitScore = hitScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="HitThisRoundConsideration.HitScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHitScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.HitScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HitThisRoundConsideration.NoHitScore"/>
    /// </summary>
    public TBuilder SetNoHitScore(float noHitScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NoHitScore = noHitScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="HitThisRoundConsideration.NoHitScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNoHitScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.NoHitScore);
        });
    }
  }
}
