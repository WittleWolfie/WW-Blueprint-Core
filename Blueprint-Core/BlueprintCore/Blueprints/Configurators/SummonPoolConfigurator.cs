using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintSummonPool"/>.</summary>
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
    public static SummonPoolConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintSummonPool>(name, assetId);
      return For(name);
    }

  }
}
