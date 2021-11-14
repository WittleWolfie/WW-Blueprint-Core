using BlueprintCore.Utils;
using Kingmaker.Blueprints.Loot;

namespace BlueprintCore.Blueprints.Configurators.Loot
{
  /// <summary>Configurator for <see cref="BlueprintLoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintLoot))]
  public class LootConfigurator : BaseBlueprintConfigurator<BlueprintLoot, LootConfigurator>
  {
     private LootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static LootConfigurator For(string name)
    {
      return new LootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static LootConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintLoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static LootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintLoot>(name, assetId);
      return For(name);
    }
  }
}
