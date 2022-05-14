//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Armies.Brain
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintTacticalCombatAiAttack"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTacticalCombatAiAttackConfigurator<T, TBuilder>
    : BaseTacticalCombatAiActionConfigurator<T, TBuilder>
    where T : BlueprintTacticalCombatAiAttack
    where TBuilder : BaseTacticalCombatAiAttackConfigurator<T, TBuilder>
  {
    protected BaseTacticalCombatAiAttackConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
