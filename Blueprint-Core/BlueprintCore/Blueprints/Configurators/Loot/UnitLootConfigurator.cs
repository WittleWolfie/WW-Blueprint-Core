using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Loot;
namespace BlueprintCore.Blueprints.Configurators.Loot
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintUnitLoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnitLoot))]
  public abstract class BaseUnitLootConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintUnitLoot
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseUnitLootConfigurator(string name) : base(name) { }

  }

  /// <summary>Configurator for <see cref="BlueprintUnitLoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnitLoot))]
  public class UnitLootConfigurator : BaseBlueprintConfigurator<BlueprintUnitLoot, UnitLootConfigurator>
  {
     private UnitLootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitLootConfigurator For(string name)
    {
      return new UnitLootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static UnitLootConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintUnitLoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitLootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintUnitLoot>(name, assetId);
      return For(name);
    }

  }
}
