using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Globalmap.Blueprints;
namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>Configurator for <see cref="BlueprintGlobalMapPointVariation"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintGlobalMapPointVariation))]
  public class GlobalMapPointVariationConfigurator : BaseBlueprintConfigurator<BlueprintGlobalMapPointVariation, GlobalMapPointVariationConfigurator>
  {
     private GlobalMapPointVariationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static GlobalMapPointVariationConfigurator For(string name)
    {
      return new GlobalMapPointVariationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static GlobalMapPointVariationConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintGlobalMapPointVariation>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static GlobalMapPointVariationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintGlobalMapPointVariation>(name, assetId);
      return For(name);
    }

  }
}
