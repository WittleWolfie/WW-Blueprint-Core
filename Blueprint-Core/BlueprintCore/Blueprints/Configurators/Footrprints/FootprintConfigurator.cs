using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Footrprints;

namespace BlueprintCore.Blueprints.Configurators.Footrprints
{
  /// <summary>Configurator for <see cref="BlueprintFootprint"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintFootprint))]
  public class FootprintConfigurator : BaseBlueprintConfigurator<BlueprintFootprint, FootprintConfigurator>
  {
     private FootprintConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FootprintConfigurator For(string name)
    {
      return new FootprintConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static FootprintConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintFootprint>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FootprintConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintFootprint>(name, assetId);
      return For(name);
    }
  }
}
