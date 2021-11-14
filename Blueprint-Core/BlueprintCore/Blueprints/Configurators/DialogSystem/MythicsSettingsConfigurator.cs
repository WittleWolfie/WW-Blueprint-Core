using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.DialogSystem.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>Configurator for <see cref="BlueprintMythicsSettings"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintMythicsSettings))]
  public class MythicsSettingsConfigurator : BaseBlueprintConfigurator<BlueprintMythicsSettings, MythicsSettingsConfigurator>
  {
     private MythicsSettingsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static MythicsSettingsConfigurator For(string name)
    {
      return new MythicsSettingsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static MythicsSettingsConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintMythicsSettings>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static MythicsSettingsConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintMythicsSettings>(name, assetId);
      return For(name);
    }
  }
}
