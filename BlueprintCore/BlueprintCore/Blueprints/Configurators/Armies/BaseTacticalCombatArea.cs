//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Area;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Blueprints;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintTacticalCombatArea"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTacticalCombatAreaConfigurator<T, TBuilder>
    : BaseAreaConfigurator<T, TBuilder>
    where T : BlueprintTacticalCombatArea
    where TBuilder : BaseTacticalCombatAreaConfigurator<T, TBuilder>
  {
    protected BaseTacticalCombatAreaConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
