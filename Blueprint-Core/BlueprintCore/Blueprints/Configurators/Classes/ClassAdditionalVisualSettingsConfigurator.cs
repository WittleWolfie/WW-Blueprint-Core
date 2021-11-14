using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>Configurator for <see cref="BlueprintClassAdditionalVisualSettings"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintClassAdditionalVisualSettings))]
  public class ClassAdditionalVisualSettingsConfigurator : BaseBlueprintConfigurator<BlueprintClassAdditionalVisualSettings, ClassAdditionalVisualSettingsConfigurator>
  {
     private ClassAdditionalVisualSettingsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ClassAdditionalVisualSettingsConfigurator For(string name)
    {
      return new ClassAdditionalVisualSettingsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ClassAdditionalVisualSettingsConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintClassAdditionalVisualSettings>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ClassAdditionalVisualSettingsConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintClassAdditionalVisualSettings>(name, assetId);
      return For(name);
    }
  }
}
