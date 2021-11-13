using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.UnitLogic.Abilities.Blueprints;
namespace BlueprintCore.Blueprints.Configurators.UnitLogic.Abilities
{
  /// <summary>Configurator for <see cref="BlueprintAreaEffectPitVisualSettings"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAreaEffectPitVisualSettings))]
  public class AreaEffectPitVisualSettingsConfigurator : BaseBlueprintConfigurator<BlueprintAreaEffectPitVisualSettings, AreaEffectPitVisualSettingsConfigurator>
  {
     private AreaEffectPitVisualSettingsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AreaEffectPitVisualSettingsConfigurator For(string name)
    {
      return new AreaEffectPitVisualSettingsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AreaEffectPitVisualSettingsConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintAreaEffectPitVisualSettings>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AreaEffectPitVisualSettingsConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintAreaEffectPitVisualSettings>(name, assetId);
      return For(name);
    }

  }
}
