//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using System;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintMapObject"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseMapObjectConfigurator<T, TBuilder>
    : BaseLogicConnectorConfigurator<T, TBuilder>
    where T : BlueprintMapObject
    where TBuilder : BaseMapObjectConfigurator<T, TBuilder>
  {
    protected BaseMapObjectConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintMapObject.Prefab"/>
    /// </summary>
    public TBuilder SetPrefab(GameObject prefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(prefab);
          bp.Prefab = prefab;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintMapObject.Prefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPrefab(Action<GameObject> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Prefab is null) { return; }
          action.Invoke(bp.Prefab);
        });
    }
  }
}
