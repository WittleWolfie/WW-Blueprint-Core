using BlueprintCore.Utils;
using Kingmaker.Armies;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>Configurator for <see cref="BlueprintArmyLeader"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArmyLeader))]
  public class ArmyLeaderConfigurator : BaseBlueprintConfigurator<BlueprintArmyLeader, ArmyLeaderConfigurator>
  {
     private ArmyLeaderConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArmyLeaderConfigurator For(string name)
    {
      return new ArmyLeaderConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ArmyLeaderConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintArmyLeader>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArmyLeaderConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintArmyLeader>(name, assetId);
      return For(name);
    }
  }
}
