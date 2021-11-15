using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;
using System.Linq;

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

    /// <summary>
    /// Modifies <see cref="BlueprintArmyPresetList.m_Presets"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintArmyPreset"/></param>
    [Generated]
    public ArmyPresetListConfigurator AddToPresets(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Presets = CommonTool.Append(bp.m_Presets, values.Select(name => BlueprintTool.GetRef<BlueprintArmyPresetReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmyPresetList.m_Presets"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintArmyPreset"/></param>
    [Generated]
    public ArmyPresetListConfigurator RemoveFromPresets(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintArmyPresetReference>(name));
            bp.m_Presets =
                bp.m_Presets
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}
