using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.RandomEncounters.Settings;

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
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseSpawnableObjectConfigurator(string name) : base(name) { }
  }

  /// <summary>Configurator for <see cref="BlueprintSpawnableObject"/>.</summary>
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
    public static SpawnableObjectConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintSpawnableObject>(name, assetId);
      return For(name);
    }
  }
}
