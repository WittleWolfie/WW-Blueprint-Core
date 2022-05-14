//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Blueprints;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintTacticalCombatObstaclesMap"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTacticalCombatObstaclesMapConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintTacticalCombatObstaclesMap
    where TBuilder : BaseTacticalCombatObstaclesMapConfigurator<T, TBuilder>
  {
    protected BaseTacticalCombatObstaclesMapConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
