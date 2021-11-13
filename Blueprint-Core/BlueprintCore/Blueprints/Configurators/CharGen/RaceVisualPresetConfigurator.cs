using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.CharGen;
namespace BlueprintCore.Blueprints.Configurators.CharGen
{
  /// <summary>Configurator for <see cref="BlueprintRaceVisualPreset"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintRaceVisualPreset))]
  public class RaceVisualPresetConfigurator : BaseBlueprintConfigurator<BlueprintRaceVisualPreset, RaceVisualPresetConfigurator>
  {
     private RaceVisualPresetConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static RaceVisualPresetConfigurator For(string name)
    {
      return new RaceVisualPresetConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static RaceVisualPresetConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintRaceVisualPreset>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static RaceVisualPresetConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintRaceVisualPreset>(name, assetId);
      return For(name);
    }

  }
}
