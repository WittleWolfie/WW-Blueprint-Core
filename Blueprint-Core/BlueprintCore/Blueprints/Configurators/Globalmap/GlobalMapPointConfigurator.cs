using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Globalmap.Blueprints;
namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>Configurator for <see cref="BlueprintGlobalMapPoint"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintGlobalMapPoint))]
  public class GlobalMapPointConfigurator : BaseBlueprintConfigurator<BlueprintGlobalMapPoint, GlobalMapPointConfigurator>
  {
     private GlobalMapPointConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static GlobalMapPointConfigurator For(string name)
    {
      return new GlobalMapPointConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static GlobalMapPointConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintGlobalMapPoint>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static GlobalMapPointConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintGlobalMapPoint>(name, assetId);
      return For(name);
    }

  }
}
