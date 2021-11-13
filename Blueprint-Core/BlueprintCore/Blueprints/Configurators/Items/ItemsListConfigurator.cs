using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items;
namespace BlueprintCore.Blueprints.Configurators.Items
{
  /// <summary>Configurator for <see cref="BlueprintItemsList"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemsList))]
  public class ItemsListConfigurator : BaseBlueprintConfigurator<BlueprintItemsList, ItemsListConfigurator>
  {
     private ItemsListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemsListConfigurator For(string name)
    {
      return new ItemsListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ItemsListConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintItemsList>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemsListConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintItemsList>(name, assetId);
      return For(name);
    }

  }
}
