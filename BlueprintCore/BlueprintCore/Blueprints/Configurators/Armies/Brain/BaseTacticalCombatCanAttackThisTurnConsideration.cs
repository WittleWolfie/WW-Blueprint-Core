//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain.Considerations;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Armies.Brain
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="TacticalCombatCanAttackThisTurnConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTacticalCombatCanAttackThisTurnConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : TacticalCombatCanAttackThisTurnConsideration
    where TBuilder : BaseTacticalCombatCanAttackThisTurnConsiderationConfigurator<T, TBuilder>
  {
    protected BaseTacticalCombatCanAttackThisTurnConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
