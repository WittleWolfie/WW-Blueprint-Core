using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items;

namespace BlueprintCore.Blueprints.Configurators.Items
{
  /// <summary>
  /// Configurator for <see cref="BlueprintHiddenItem"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintHiddenItem))]
  public class HiddenItemConfigurator : BaseItemConfigurator<BlueprintHiddenItem, HiddenItemConfigurator>
  {
    private HiddenItemConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static HiddenItemConfigurator For(string name)
    {
      return new HiddenItemConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static HiddenItemConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintHiddenItem>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static HiddenItemConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintHiddenItem>(name, assetId);
      return For(name);
    }
  }
}
