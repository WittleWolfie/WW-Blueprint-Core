//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.Armies.Brain
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintTacticalCombatAiAction"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTacticalCombatAiActionConfigurator<T, TBuilder>
    : BaseAiActionConfigurator<T, TBuilder>
    where T : BlueprintTacticalCombatAiAction
    where TBuilder : BaseTacticalCombatAiActionConfigurator<T, TBuilder>
  {
    protected BaseTacticalCombatAiActionConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintTacticalCombatAiAction>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    return Self;
    }
  }
}
