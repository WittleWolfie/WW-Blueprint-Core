using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain;

namespace BlueprintCore.Blueprints.Configurators.Armies.TacticalCombat.Brain
{
  /// <summary>Configurator for <see cref="BlueprintTacticalCombatBrain"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTacticalCombatBrain))]
  public class TacticalCombatBrainConfigurator : BaseBrainConfigurator<BlueprintTacticalCombatBrain, TacticalCombatBrainConfigurator>
  {
     private TacticalCombatBrainConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TacticalCombatBrainConfigurator For(string name)
    {
      return new TacticalCombatBrainConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static TacticalCombatBrainConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintTacticalCombatBrain>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TacticalCombatBrainConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintTacticalCombatBrain>(name, assetId);
      return For(name);
    }
  }
}
