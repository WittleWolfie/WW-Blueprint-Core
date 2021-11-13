using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Dungeon.Blueprints;
namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>Configurator for <see cref="BlueprintDungeonRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintDungeonRoot))]
  public class DungeonRootConfigurator : BaseBlueprintConfigurator<BlueprintDungeonRoot, DungeonRootConfigurator>
  {
     private DungeonRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DungeonRootConfigurator For(string name)
    {
      return new DungeonRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static DungeonRootConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintDungeonRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DungeonRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintDungeonRoot>(name, assetId);
      return For(name);
    }

  }
}
