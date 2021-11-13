using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Dungeon.Blueprints;
namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>Configurator for <see cref="BlueprintDungeonBoon"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintDungeonBoon))]
  public class DungeonBoonConfigurator : BaseBlueprintConfigurator<BlueprintDungeonBoon, DungeonBoonConfigurator>
  {
     private DungeonBoonConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DungeonBoonConfigurator For(string name)
    {
      return new DungeonBoonConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static DungeonBoonConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintDungeonBoon>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DungeonBoonConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintDungeonBoon>(name, assetId);
      return For(name);
    }

  }
}
