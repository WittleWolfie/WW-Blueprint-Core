using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintPortrait"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintPortrait))]
  public class PortraitConfigurator : BaseBlueprintConfigurator<BlueprintPortrait, PortraitConfigurator>
  {
     private PortraitConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static PortraitConfigurator For(string name)
    {
      return new PortraitConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static PortraitConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintPortrait>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static PortraitConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintPortrait>(name, assetId);
      return For(name);
    }

  }
}
