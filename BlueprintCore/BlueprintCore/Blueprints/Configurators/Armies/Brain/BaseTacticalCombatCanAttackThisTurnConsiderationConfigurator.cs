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

    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<TacticalCombatCanAttackThisTurnConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.CanAttackScore = copyFrom.CanAttackScore;
          bp.CanNotAttackScore = copyFrom.CanNotAttackScore;
        });
    }

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
  }
}
