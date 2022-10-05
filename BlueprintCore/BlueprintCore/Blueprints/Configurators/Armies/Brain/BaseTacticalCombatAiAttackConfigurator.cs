//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain;
using Kingmaker.Blueprints;
using System;

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

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintTacticalCombatAiAttack>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.CanAttackAllies = copyFrom.CanAttackAllies;
        });
    }

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
