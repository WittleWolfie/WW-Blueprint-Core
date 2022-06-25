//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.Armies.Brain
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="TacticalCombatCanAttackThisTurnConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTacticalCombatCanAttackThisTurnConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : TacticalCombatCanAttackThisTurnConsideration
    where TBuilder : BaseTacticalCombatCanAttackThisTurnConsiderationConfigurator<T, TBuilder>
  {
    protected BaseTacticalCombatCanAttackThisTurnConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="TacticalCombatCanAttackThisTurnConsideration.CanAttackScore"/>
    /// </summary>
    public TBuilder SetCanAttackScore(float canAttackScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CanAttackScore = canAttackScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="TacticalCombatCanAttackThisTurnConsideration.CanAttackScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCanAttackScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CanAttackScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="TacticalCombatCanAttackThisTurnConsideration.CanNotAttackScore"/>
    /// </summary>
    public TBuilder SetCanNotAttackScore(float canNotAttackScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CanNotAttackScore = canNotAttackScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="TacticalCombatCanAttackThisTurnConsideration.CanNotAttackScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCanNotAttackScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CanNotAttackScore);
        });
    }
  }
}
