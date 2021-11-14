using BlueprintCore.Utils;
using Kingmaker.UI;

namespace BlueprintCore.Blueprints.Configurators.UI
{
  /// <summary>Configurator for <see cref="BlueprintUISound"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUISound))]
  public class UISoundConfigurator : BaseBlueprintConfigurator<BlueprintUISound, UISoundConfigurator>
  {
     private UISoundConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UISoundConfigurator For(string name)
    {
      return new UISoundConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static UISoundConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintUISound>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UISoundConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintUISound>(name, assetId);
      return For(name);
    }
  }
}
