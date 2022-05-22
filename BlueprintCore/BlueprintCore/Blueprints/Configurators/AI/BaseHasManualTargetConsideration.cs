//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="HasManualTargetConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseHasManualTargetConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : HasManualTargetConsideration
    where TBuilder : BaseHasManualTargetConsiderationConfigurator<T, TBuilder>
  {
    protected BaseHasManualTargetConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="HasManualTargetConsideration.HasManualTargetScore"/>
    /// </summary>
    public TBuilder SetHasManualTargetScore(float hasManualTargetScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasManualTargetScore = hasManualTargetScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="HasManualTargetConsideration.HasManualTargetScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHasManualTargetScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.HasManualTargetScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HasManualTargetConsideration.NoManualTargetScore"/>
    /// </summary>
    public TBuilder SetNoManualTargetScore(float noManualTargetScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NoManualTargetScore = noManualTargetScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="HasManualTargetConsideration.NoManualTargetScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNoManualTargetScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.NoManualTargetScore);
        });
    }
  }
}
