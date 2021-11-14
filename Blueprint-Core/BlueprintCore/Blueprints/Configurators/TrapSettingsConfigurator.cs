using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintTrapSettings"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTrapSettings))]
  public class TrapSettingsConfigurator : BaseBlueprintConfigurator<BlueprintTrapSettings, TrapSettingsConfigurator>
  {
     private TrapSettingsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TrapSettingsConfigurator For(string name)
    {
      return new TrapSettingsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static TrapSettingsConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintTrapSettings>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TrapSettingsConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintTrapSettings>(name, assetId);
      return For(name);
    }
  }
}
