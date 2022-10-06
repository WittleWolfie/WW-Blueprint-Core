//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.RandomEncounters.Settings;
using Kingmaker.ResourceLinks;
using System;

namespace BlueprintCore.Blueprints.Configurators.RandomEncounters
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintSpawnableObject"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseSpawnableObjectConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintSpawnableObject
    where TBuilder : BaseSpawnableObjectConfigurator<T, TBuilder>
  {
    protected BaseSpawnableObjectConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintSpawnableObject>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Prefab = copyFrom.Prefab;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintSpawnableObject>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Prefab = copyFrom.Prefab;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpawnableObject.Prefab"/>
    /// </summary>
    ///
    /// <param name="prefab">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetPrefab(AssetLink<PrefabLink> prefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Prefab = prefab?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSpawnableObject.Prefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPrefab(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Prefab is null) { return; }
          action.Invoke(bp.Prefab);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Prefab is null)
      {
        Blueprint.Prefab = Utils.Constants.Empty.PrefabLink;
      }
    }
  }
}
