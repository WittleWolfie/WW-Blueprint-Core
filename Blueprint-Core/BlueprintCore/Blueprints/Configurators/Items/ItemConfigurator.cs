using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items;
namespace BlueprintCore.Blueprints.Configurators.Items
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItem"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItem))]
  public abstract class BaseItemConfigurator<T, TBuilder>
      : BaseFactConfigurator<T, TBuilder>
      where T : BlueprintItem
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseItemConfigurator(string name) : base(name) { }

  }

  /// <summary>Configurator for <see cref="BlueprintItem"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItem))]
  public class ItemConfigurator : BaseFactConfigurator<BlueprintItem, ItemConfigurator>
  {
     private ItemConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemConfigurator For(string name)
    {
      return new ItemConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ItemConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintItem>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintItem>(name, assetId);
      return For(name);
    }

  }
}
