using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Footrprints;
namespace BlueprintCore.Blueprints.Configurators.Footrprints
{
  /// <summary>Configurator for <see cref="BlueprintFootprintType"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintFootprintType))]
  public class FootprintTypeConfigurator : BaseBlueprintConfigurator<BlueprintFootprintType, FootprintTypeConfigurator>
  {
     private FootprintTypeConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FootprintTypeConfigurator For(string name)
    {
      return new FootprintTypeConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static FootprintTypeConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintFootprintType>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FootprintTypeConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintFootprintType>(name, assetId);
      return For(name);
    }

  }
}
