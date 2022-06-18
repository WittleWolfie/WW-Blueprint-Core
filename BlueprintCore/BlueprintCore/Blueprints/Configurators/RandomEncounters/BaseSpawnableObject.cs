//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
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

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpawnableObject.Prefab"/>
    /// </summary>
    public TBuilder SetPrefab(PrefabLink prefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Prefab = prefab;
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

    protected override void SetDefaults()
    {
      base.SetDefaults();
    
      if (Blueprint.Prefab is null)
      {
        Blueprint.Prefab = Utils.Constants.Empty.PrefabLink;
      }
    }
  }
}
