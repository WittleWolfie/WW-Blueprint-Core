using BlueprintCore.Utils;
using Kingmaker.Blueprints.Area;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>Configurator for <see cref="BlueprintSettlementAreaPreset"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintSettlementAreaPreset))]
  public class SettlementAreaPresetConfigurator : BaseAreaPresetConfigurator<BlueprintSettlementAreaPreset, SettlementAreaPresetConfigurator>
  {
     private SettlementAreaPresetConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SettlementAreaPresetConfigurator For(string name)
    {
      return new SettlementAreaPresetConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static SettlementAreaPresetConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintSettlementAreaPreset>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SettlementAreaPresetConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintSettlementAreaPreset>(name, assetId);
      return For(name);
    }
  }
}
