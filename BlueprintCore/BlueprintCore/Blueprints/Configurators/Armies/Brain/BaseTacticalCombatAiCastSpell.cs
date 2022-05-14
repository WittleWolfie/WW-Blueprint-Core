//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Armies.Brain
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintTacticalCombatAiCastSpell"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTacticalCombatAiCastSpellConfigurator<T, TBuilder>
    : BaseTacticalCombatAiActionConfigurator<T, TBuilder>
    where T : BlueprintTacticalCombatAiCastSpell
    where TBuilder : BaseTacticalCombatAiCastSpellConfigurator<T, TBuilder>
  {
    protected BaseTacticalCombatAiCastSpellConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
