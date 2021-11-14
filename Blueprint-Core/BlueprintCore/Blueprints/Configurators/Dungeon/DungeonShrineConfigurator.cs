using BlueprintCore.Blueprints.Configurators.RandomEncounters.Settings;
using BlueprintCore.Utils;
using Kingmaker.Dungeon.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>Configurator for <see cref="BlueprintDungeonShrine"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintDungeonShrine))]
  public class DungeonShrineConfigurator : BaseSpawnableObjectConfigurator<BlueprintDungeonShrine, DungeonShrineConfigurator>
  {
     private DungeonShrineConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DungeonShrineConfigurator For(string name)
    {
      return new DungeonShrineConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static DungeonShrineConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintDungeonShrine>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DungeonShrineConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintDungeonShrine>(name, assetId);
      return For(name);
    }
  }
}
