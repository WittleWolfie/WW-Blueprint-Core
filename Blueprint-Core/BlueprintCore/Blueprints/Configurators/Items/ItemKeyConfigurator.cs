using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items;

namespace BlueprintCore.Blueprints.Configurators.Items
{
  /// <summary>
  /// Configurator for <see cref="BlueprintItemKey"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemKey))]
  public class ItemKeyConfigurator : BaseItemConfigurator<BlueprintItemKey, ItemKeyConfigurator>
  {
    private ItemKeyConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemKeyConfigurator For(string name)
    {
      return new ItemKeyConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ItemKeyConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintItemKey>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemKeyConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintItemKey>(name, assetId);
      return For(name);
    }
  }
}
