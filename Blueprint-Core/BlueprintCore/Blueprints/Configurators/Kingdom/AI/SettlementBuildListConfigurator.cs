using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Kingdom.AI;

namespace BlueprintCore.Blueprints.Configurators.Kingdom.AI
{
  /// <summary>Configurator for <see cref="SettlementBuildList"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(SettlementBuildList))]
  public class SettlementBuildListConfigurator : BaseBlueprintConfigurator<SettlementBuildList, SettlementBuildListConfigurator>
  {
     private SettlementBuildListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SettlementBuildListConfigurator For(string name)
    {
      return new SettlementBuildListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static SettlementBuildListConfigurator New(string name)
    {
      BlueprintTool.Create<SettlementBuildList>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SettlementBuildListConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<SettlementBuildList>(name, assetId);
      return For(name);
    }
  }
}
