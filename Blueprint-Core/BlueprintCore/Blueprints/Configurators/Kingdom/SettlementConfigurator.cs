using BlueprintCore.Utils;
using Kingmaker.Kingdom;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>Configurator for <see cref="BlueprintSettlement"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintSettlement))]
  public class SettlementConfigurator : BaseBlueprintConfigurator<BlueprintSettlement, SettlementConfigurator>
  {
     private SettlementConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SettlementConfigurator For(string name)
    {
      return new SettlementConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static SettlementConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintSettlement>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SettlementConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintSettlement>(name, assetId);
      return For(name);
    }
  }
}
