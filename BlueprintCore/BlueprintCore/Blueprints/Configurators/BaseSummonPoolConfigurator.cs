//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;

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
  }
}
