using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Kingdom.Settlements;
namespace BlueprintCore.Blueprints.Configurators.Kingdom.Settlements
{
  /// <summary>Configurator for <see cref="BlueprintSettlementBuilding"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintSettlementBuilding))]
  public class SettlementBuildingConfigurator : BaseFactConfigurator<BlueprintSettlementBuilding, SettlementBuildingConfigurator>
  {
     private SettlementBuildingConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SettlementBuildingConfigurator For(string name)
    {
      return new SettlementBuildingConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static SettlementBuildingConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintSettlementBuilding>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SettlementBuildingConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintSettlementBuilding>(name, assetId);
      return For(name);
    }

  }
}
