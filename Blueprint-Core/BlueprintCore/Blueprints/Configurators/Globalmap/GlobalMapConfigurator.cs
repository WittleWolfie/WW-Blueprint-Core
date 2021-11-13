using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Globalmap.Blueprints;
namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>Configurator for <see cref="BlueprintGlobalMap"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintGlobalMap))]
  public class GlobalMapConfigurator : BaseBlueprintConfigurator<BlueprintGlobalMap, GlobalMapConfigurator>
  {
     private GlobalMapConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static GlobalMapConfigurator For(string name)
    {
      return new GlobalMapConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static GlobalMapConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintGlobalMap>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static GlobalMapConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintGlobalMap>(name, assetId);
      return For(name);
    }

  }
}
