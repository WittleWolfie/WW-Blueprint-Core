//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Area;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
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
    protected BaseTacticalCombatAreaConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintTacticalCombatArea>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_GridCenter = copyFrom.m_GridCenter;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintTacticalCombatArea>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_GridCenter = copyFrom.m_GridCenter;
        });
    }

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
