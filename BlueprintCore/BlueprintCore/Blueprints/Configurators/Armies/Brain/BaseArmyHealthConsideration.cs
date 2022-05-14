//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain.Considerations;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Armies.Brain
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="ArmyHealthConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseArmyHealthConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : ArmyHealthConsideration
    where TBuilder : BaseArmyHealthConsiderationConfigurator<T, TBuilder>
  {
    protected BaseArmyHealthConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
