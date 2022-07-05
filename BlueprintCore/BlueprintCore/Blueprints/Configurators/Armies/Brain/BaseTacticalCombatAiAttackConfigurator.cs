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
    protected BaseTacticalCombatAiAttackConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatAiAttack.CanAttackAllies"/>
    /// </summary>
    public TBuilder SetCanAttackAllies(bool canAttackAllies = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CanAttackAllies = canAttackAllies;
        });
    }
  }
}
