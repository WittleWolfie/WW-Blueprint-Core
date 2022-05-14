//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="LineOfSightConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseLineOfSightConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : LineOfSightConsideration
    where TBuilder : BaseLineOfSightConsiderationConfigurator<T, TBuilder>
  {
    protected BaseLineOfSightConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="LineOfSightConsideration.HasNoLosScore"/>
    /// </summary>
    public TBuilder SetHasNoLosScore(float hasNoLosScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasNoLosScore = hasNoLosScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="LineOfSightConsideration.HasNoLosScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHasNoLosScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.HasNoLosScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LineOfSightConsideration.HasLosScore"/>
    /// </summary>
    public TBuilder SetHasLosScore(float hasLosScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasLosScore = hasLosScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="LineOfSightConsideration.HasLosScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHasLosScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.HasLosScore);
        });
    }
  }
}
