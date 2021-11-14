using BlueprintCore.Utils;
using Kingmaker.Kingdom.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>Configurator for <see cref="BlueprintArmyPresetList"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArmyPresetList))]
  public class ArmyPresetListConfigurator : BaseBlueprintConfigurator<BlueprintArmyPresetList, ArmyPresetListConfigurator>
  {
     private ArmyPresetListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArmyPresetListConfigurator For(string name)
    {
      return new ArmyPresetListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ArmyPresetListConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintArmyPresetList>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArmyPresetListConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintArmyPresetList>(name, assetId);
      return For(name);
    }
  }
}
