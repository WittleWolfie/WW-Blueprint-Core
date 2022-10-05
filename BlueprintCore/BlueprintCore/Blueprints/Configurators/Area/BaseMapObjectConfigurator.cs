//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
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

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintMapObject>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Prefab = copyFrom.Prefab;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintMapObject.Prefab"/>
    /// </summary>
    ///
    /// <param name="prefab">
    /// You can pass in the animation using a GameObject or it's AssetId.
    /// </param>
    public TBuilder SetPrefab(Asset<GameObject> prefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Prefab = prefab?.Get();
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
