using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain;

namespace BlueprintCore.Blueprints.Configurators.Armies.TacticalCombat.Brain
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintTacticalCombatAiAction"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTacticalCombatAiAction))]
  public abstract class BaseTacticalCombatAiActionConfigurator<T, TBuilder>
      : BaseAiActionConfigurator<T, TBuilder>
      where T : BlueprintTacticalCombatAiAction
      where TBuilder : BaseTacticalCombatAiActionConfigurator<T, TBuilder>
  {
    protected BaseTacticalCombatAiActionConfigurator(string name) : base(name) { }
  }
}
