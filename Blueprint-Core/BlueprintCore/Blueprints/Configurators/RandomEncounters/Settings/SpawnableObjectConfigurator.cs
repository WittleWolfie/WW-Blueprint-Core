using BlueprintCore.Utils;
using Kingmaker.RandomEncounters.Settings;
using Kingmaker.ResourceLinks;

namespace BlueprintCore.Blueprints.Configurators.RandomEncounters.Settings
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintSpawnableObject"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintSpawnableObject))]
  public abstract class BaseSpawnableObjectConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintSpawnableObject
      where TBuilder : BaseSpawnableObjectConfigurator<T, TBuilder>
  {
    protected BaseSpawnableObjectConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintSpawnableObject.Prefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetPrefab(PrefabLink prefab)
    {
      ValidateParam(prefab);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Prefab = prefab ?? Constants.Empty.PrefabLink;
          });
    }
  }

  /// <summary>
  /// Configurator for <see cref="BlueprintSpawnableObject"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintSpawnableObject))]
  public class SpawnableObjectConfigurator : BaseBlueprintConfigurator<BlueprintSpawnableObject, SpawnableObjectConfigurator>
  {
    private SpawnableObjectConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SpawnableObjectConfigurator For(string name)
    {
      return new SpawnableObjectConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static SpawnableObjectConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintSpawnableObject>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SpawnableObjectConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintSpawnableObject>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpawnableObject.Prefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpawnableObjectConfigurator SetPrefab(PrefabLink prefab)
    {
      ValidateParam(prefab);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Prefab = prefab ?? Constants.Empty.PrefabLink;
          });
    }
  }
}
