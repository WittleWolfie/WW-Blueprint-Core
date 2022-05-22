//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintSummonPool"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseSummonPoolConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintSummonPool
    where TBuilder : BaseSummonPoolConfigurator<T, TBuilder>
  {
    protected BaseSummonPoolConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSummonPool.Limit"/>
    /// </summary>
    public TBuilder SetLimit(int limit)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Limit = limit;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSummonPool.Limit"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLimit(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Limit);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSummonPool.DoNotRemoveDeadUnits"/>
    /// </summary>
    public TBuilder SetDoNotRemoveDeadUnits(bool doNotRemoveDeadUnits = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotRemoveDeadUnits = doNotRemoveDeadUnits;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSummonPool.DoNotRemoveDeadUnits"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDoNotRemoveDeadUnits(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.DoNotRemoveDeadUnits);
        });
    }
  }
}
