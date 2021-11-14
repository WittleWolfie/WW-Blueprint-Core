using BlueprintCore.Utils;
using Kingmaker.Dungeon.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>Configurator for <see cref="BlueprintGenericPackLoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintGenericPackLoot))]
  public class GenericPackLootConfigurator : BaseBlueprintConfigurator<BlueprintGenericPackLoot, GenericPackLootConfigurator>
  {
     private GenericPackLootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static GenericPackLootConfigurator For(string name)
    {
      return new GenericPackLootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static GenericPackLootConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintGenericPackLoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static GenericPackLootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintGenericPackLoot>(name, assetId);
      return For(name);
    }
  }
}
