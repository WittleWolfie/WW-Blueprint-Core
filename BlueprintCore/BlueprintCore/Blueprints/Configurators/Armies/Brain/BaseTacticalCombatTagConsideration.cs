//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain.Considerations;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Armies.Brain
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="TacticalCombatTagConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTacticalCombatTagConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : TacticalCombatTagConsideration
    where TBuilder : BaseTacticalCombatTagConsiderationConfigurator<T, TBuilder>
  {
    protected BaseTacticalCombatTagConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
