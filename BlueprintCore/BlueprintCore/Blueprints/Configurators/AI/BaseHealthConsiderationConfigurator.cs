//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
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
    protected BaseHealthConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<HealthConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.FullBorder = copyFrom.FullBorder;
          bp.DeadBorder = copyFrom.DeadBorder;
          bp.AboveFullScore = copyFrom.AboveFullScore;
          bp.BelowDeadScore = copyFrom.BelowDeadScore;
          bp.FullScore = copyFrom.FullScore;
          bp.DeadScore = copyFrom.DeadScore;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<HealthConsideration>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.FullBorder = copyFrom.FullBorder;
          bp.DeadBorder = copyFrom.DeadBorder;
          bp.AboveFullScore = copyFrom.AboveFullScore;
          bp.BelowDeadScore = copyFrom.BelowDeadScore;
          bp.FullScore = copyFrom.FullScore;
          bp.DeadScore = copyFrom.DeadScore;
        });
    }

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
  }
}
