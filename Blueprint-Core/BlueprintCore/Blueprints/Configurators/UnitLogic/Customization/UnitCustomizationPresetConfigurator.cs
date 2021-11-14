using BlueprintCore.Utils;
using Kingmaker.UnitLogic.Customization;

namespace BlueprintCore.Blueprints.Configurators.UnitLogic.Customization
{
  /// <summary>Configurator for <see cref="UnitCustomizationPreset"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(UnitCustomizationPreset))]
  public class UnitCustomizationPresetConfigurator : BaseBlueprintConfigurator<UnitCustomizationPreset, UnitCustomizationPresetConfigurator>
  {
     private UnitCustomizationPresetConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitCustomizationPresetConfigurator For(string name)
    {
      return new UnitCustomizationPresetConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static UnitCustomizationPresetConfigurator New(string name)
    {
      BlueprintTool.Create<UnitCustomizationPreset>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitCustomizationPresetConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<UnitCustomizationPreset>(name, assetId);
      return For(name);
    }
  }
}
