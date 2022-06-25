//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="ManualTargetConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseManualTargetConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : ManualTargetConsideration
    where TBuilder : BaseManualTargetConsiderationConfigurator<T, TBuilder>
  {
    protected BaseManualTargetConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="ManualTargetConsideration.IsManualTargetScore"/>
    /// </summary>
    public TBuilder SetIsManualTargetScore(float isManualTargetScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsManualTargetScore = isManualTargetScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="ManualTargetConsideration.IsManualTargetScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIsManualTargetScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.IsManualTargetScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ManualTargetConsideration.NotManualTargetScore"/>
    /// </summary>
    public TBuilder SetNotManualTargetScore(float notManualTargetScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NotManualTargetScore = notManualTargetScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="ManualTargetConsideration.NotManualTargetScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNotManualTargetScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.NotManualTargetScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ManualTargetConsideration.NoManualTargetScore"/>
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
    /// Modifies <see cref="ManualTargetConsideration.NoManualTargetScore"/> by invoking the provided action.
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
