using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.UnitLogic.Customization;
namespace BlueprintCore.Blueprints.Configurators.UnitLogic.Customization
{
  /// <summary>Configurator for <see cref="RaceGenderDistribution"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(RaceGenderDistribution))]
  public class RaceGenderDistributionConfigurator : BaseBlueprintConfigurator<RaceGenderDistribution, RaceGenderDistributionConfigurator>
  {
     private RaceGenderDistributionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static RaceGenderDistributionConfigurator For(string name)
    {
      return new RaceGenderDistributionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static RaceGenderDistributionConfigurator New(string name)
    {
      BlueprintTool.Create<RaceGenderDistribution>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static RaceGenderDistributionConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<RaceGenderDistribution>(name, assetId);
      return For(name);
    }

  }
}
