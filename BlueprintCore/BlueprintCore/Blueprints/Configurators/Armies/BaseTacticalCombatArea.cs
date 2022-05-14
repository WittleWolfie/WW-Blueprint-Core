//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Area;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Blueprints;
using Kingmaker.Blueprints;
using System;
using UnityEngine;

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

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatArea.m_GridCenter"/>
    /// </summary>
    public TBuilder SetGridCenter(Vector3 gridCenter)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_GridCenter = gridCenter;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatArea.m_GridCenter"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyGridCenter(Action<Vector3> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_GridCenter);
        });
    }
  }
}
