using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Configurator for <see cref="BlueprintSummonPool"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintSummonPool))]
  public class SummonPoolConfigurator : BaseBlueprintConfigurator<BlueprintSummonPool, SummonPoolConfigurator>
  {
    private SummonPoolConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SummonPoolConfigurator For(string name)
    {
      return new SummonPoolConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static SummonPoolConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintSummonPool>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SummonPoolConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintSummonPool>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSummonPool.Limit"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SummonPoolConfigurator SetLimit(int limit)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Limit = limit;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSummonPool.DoNotRemoveDeadUnits"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SummonPoolConfigurator SetDoNotRemoveDeadUnits(bool doNotRemoveDeadUnits)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DoNotRemoveDeadUnits = doNotRemoveDeadUnits;
          });
    }
  }
}
