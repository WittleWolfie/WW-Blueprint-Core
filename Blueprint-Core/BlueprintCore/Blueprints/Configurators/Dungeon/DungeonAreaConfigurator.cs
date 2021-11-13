using BlueprintCore.Blueprints.Configurators.Area;
using BlueprintCore.Utils;
using Kingmaker.Dungeon.Blueprints;
namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>Configurator for <see cref="BlueprintDungeonArea"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintDungeonArea))]
  public class DungeonAreaConfigurator : BaseAreaConfigurator<BlueprintDungeonArea, DungeonAreaConfigurator>
  {
     private DungeonAreaConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DungeonAreaConfigurator For(string name)
    {
      return new DungeonAreaConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static DungeonAreaConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintDungeonArea>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DungeonAreaConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintDungeonArea>(name, assetId);
      return For(name);
    }

  }
}
