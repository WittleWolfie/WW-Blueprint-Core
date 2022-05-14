//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="ActiveCommandConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseActiveCommandConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : ActiveCommandConsideration
    where TBuilder : BaseActiveCommandConsiderationConfigurator<T, TBuilder>
  {
    protected BaseActiveCommandConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="ActiveCommandConsideration.CommandType"/>
    /// </summary>
    public TBuilder SetCommandType(UnitCommand.CommandType commandType)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CommandType = commandType;
        });
    }

    /// <summary>
    /// Modifies <see cref="ActiveCommandConsideration.CommandType"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCommandType(Action<UnitCommand.CommandType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CommandType);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ActiveCommandConsideration.HasCommandScore"/>
    /// </summary>
    public TBuilder SetHasCommandScore(float hasCommandScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasCommandScore = hasCommandScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="ActiveCommandConsideration.HasCommandScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHasCommandScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.HasCommandScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ActiveCommandConsideration.NoCommandScore"/>
    /// </summary>
    public TBuilder SetNoCommandScore(float noCommandScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NoCommandScore = noCommandScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="ActiveCommandConsideration.NoCommandScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNoCommandScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.NoCommandScore);
        });
    }
  }
}
