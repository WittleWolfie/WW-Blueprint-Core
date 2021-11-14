using BlueprintCore.Utils;
using Kingmaker.Kingdom.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>Configurator for <see cref="BlueprintRegion"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintRegion))]
  public class RegionConfigurator : BaseBlueprintConfigurator<BlueprintRegion, RegionConfigurator>
  {
     private RegionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static RegionConfigurator For(string name)
    {
      return new RegionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static RegionConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintRegion>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static RegionConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintRegion>(name, assetId);
      return For(name);
    }
  }
}
