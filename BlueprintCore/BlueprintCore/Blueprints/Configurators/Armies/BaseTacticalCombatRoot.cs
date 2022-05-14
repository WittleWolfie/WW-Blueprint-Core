//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Blueprints;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintTacticalCombatRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTacticalCombatRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintTacticalCombatRoot
    where TBuilder : BaseTacticalCombatRootConfigurator<T, TBuilder>
  {
    protected BaseTacticalCombatRootConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
