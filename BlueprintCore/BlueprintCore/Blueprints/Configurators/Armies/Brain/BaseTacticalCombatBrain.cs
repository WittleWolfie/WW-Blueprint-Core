//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Armies.Brain
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintTacticalCombatBrain"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTacticalCombatBrainConfigurator<T, TBuilder>
    : BaseBrainConfigurator<T, TBuilder>
    where T : BlueprintTacticalCombatBrain
    where TBuilder : BaseTacticalCombatBrainConfigurator<T, TBuilder>
  {
    protected BaseTacticalCombatBrainConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
