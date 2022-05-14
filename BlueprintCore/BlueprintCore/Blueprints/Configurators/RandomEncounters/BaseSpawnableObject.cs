//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.RandomEncounters.Settings;

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
    protected BaseSpawnableObjectConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
