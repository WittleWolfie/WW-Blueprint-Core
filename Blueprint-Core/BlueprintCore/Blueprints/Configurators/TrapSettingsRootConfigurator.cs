using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintTrapSettingsRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTrapSettingsRoot))]
  public class TrapSettingsRootConfigurator : BaseBlueprintConfigurator<BlueprintTrapSettingsRoot, TrapSettingsRootConfigurator>
  {
     private TrapSettingsRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TrapSettingsRootConfigurator For(string name)
    {
      return new TrapSettingsRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static TrapSettingsRootConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintTrapSettingsRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TrapSettingsRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintTrapSettingsRoot>(name, assetId);
      return For(name);
    }

  }
}
