//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="HealthConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseHealthConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : HealthConsideration
    where TBuilder : BaseHealthConsiderationConfigurator<T, TBuilder>
  {
    protected BaseHealthConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="HealthConsideration.FullBorder"/>
    /// </summary>
    public TBuilder SetFullBorder(int fullBorder)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FullBorder = fullBorder;
        });
    }

    /// <summary>
    /// Modifies <see cref="HealthConsideration.FullBorder"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFullBorder(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.FullBorder);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HealthConsideration.DeadBorder"/>
    /// </summary>
    public TBuilder SetDeadBorder(int deadBorder)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DeadBorder = deadBorder;
        });
    }

    /// <summary>
    /// Modifies <see cref="HealthConsideration.DeadBorder"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDeadBorder(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.DeadBorder);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HealthConsideration.AboveFullScore"/>
    /// </summary>
    public TBuilder SetAboveFullScore(float aboveFullScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AboveFullScore = aboveFullScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="HealthConsideration.AboveFullScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAboveFullScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AboveFullScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HealthConsideration.BelowDeadScore"/>
    /// </summary>
    public TBuilder SetBelowDeadScore(float belowDeadScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BelowDeadScore = belowDeadScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="HealthConsideration.BelowDeadScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBelowDeadScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.BelowDeadScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HealthConsideration.FullScore"/>
    /// </summary>
    public TBuilder SetFullScore(float fullScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FullScore = fullScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="HealthConsideration.FullScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFullScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.FullScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HealthConsideration.DeadScore"/>
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
    /// Modifies <see cref="HealthConsideration.DeadScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDeadScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.DeadScore);
        });
    }
  }
}
