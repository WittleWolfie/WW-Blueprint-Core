//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="SwarmTargetsConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseSwarmTargetsConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : SwarmTargetsConsideration
    where TBuilder : BaseSwarmTargetsConsiderationConfigurator<T, TBuilder>
  {
    protected BaseSwarmTargetsConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="SwarmTargetsConsideration.HasEnemiesScore"/>
    /// </summary>
    public TBuilder SetHasEnemiesScore(float hasEnemiesScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasEnemiesScore = hasEnemiesScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="SwarmTargetsConsideration.HasEnemiesScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHasEnemiesScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.HasEnemiesScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="SwarmTargetsConsideration.NoEnemiesScore"/>
    /// </summary>
    public TBuilder SetNoEnemiesScore(float noEnemiesScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NoEnemiesScore = noEnemiesScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="SwarmTargetsConsideration.NoEnemiesScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNoEnemiesScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.NoEnemiesScore);
        });
    }
  }
}
