using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Armies.Blueprints;
namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>Configurator for <see cref="BlueprintArmyPreset"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArmyPreset))]
  public class ArmyPresetConfigurator : BaseBlueprintConfigurator<BlueprintArmyPreset, ArmyPresetConfigurator>
  {
     private ArmyPresetConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArmyPresetConfigurator For(string name)
    {
      return new ArmyPresetConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ArmyPresetConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintArmyPreset>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArmyPresetConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintArmyPreset>(name, assetId);
      return For(name);
    }

  }
}
