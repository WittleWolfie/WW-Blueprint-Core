using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Dungeon.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>Configurator for <see cref="BlueprintDungeonLocalizedStrings"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintDungeonLocalizedStrings))]
  public class DungeonLocalizedStringsConfigurator : BaseBlueprintConfigurator<BlueprintDungeonLocalizedStrings, DungeonLocalizedStringsConfigurator>
  {
     private DungeonLocalizedStringsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DungeonLocalizedStringsConfigurator For(string name)
    {
      return new DungeonLocalizedStringsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static DungeonLocalizedStringsConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintDungeonLocalizedStrings>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DungeonLocalizedStringsConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintDungeonLocalizedStrings>(name, assetId);
      return For(name);
    }
  }
}
