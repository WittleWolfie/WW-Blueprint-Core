using BlueprintCore.Utils;
using Kingmaker.Globalmap.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>Configurator for <see cref="BlueprintGlobalMapEdge"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintGlobalMapEdge))]
  public class GlobalMapEdgeConfigurator : BaseBlueprintConfigurator<BlueprintGlobalMapEdge, GlobalMapEdgeConfigurator>
  {
     private GlobalMapEdgeConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static GlobalMapEdgeConfigurator For(string name)
    {
      return new GlobalMapEdgeConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static GlobalMapEdgeConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintGlobalMapEdge>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static GlobalMapEdgeConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintGlobalMapEdge>(name, assetId);
      return For(name);
    }
  }
}
