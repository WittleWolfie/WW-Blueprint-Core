//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="LastTargetConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseLastTargetConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : LastTargetConsideration
    where TBuilder : BaseLastTargetConsiderationConfigurator<T, TBuilder>
  {
    protected BaseLastTargetConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="LastTargetConsideration.SameLastTargetScore"/>
    /// </summary>
    public TBuilder SetSameLastTargetScore(float sameLastTargetScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SameLastTargetScore = sameLastTargetScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="LastTargetConsideration.SameLastTargetScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySameLastTargetScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.SameLastTargetScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LastTargetConsideration.OtherLastTargetScore"/>
    /// </summary>
    public TBuilder SetOtherLastTargetScore(float otherLastTargetScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OtherLastTargetScore = otherLastTargetScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="LastTargetConsideration.OtherLastTargetScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOtherLastTargetScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.OtherLastTargetScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LastTargetConsideration.NoLastTargetScore"/>
    /// </summary>
    public TBuilder SetNoLastTargetScore(float noLastTargetScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NoLastTargetScore = noLastTargetScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="LastTargetConsideration.NoLastTargetScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNoLastTargetScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.NoLastTargetScore);
        });
    }
  }
}
