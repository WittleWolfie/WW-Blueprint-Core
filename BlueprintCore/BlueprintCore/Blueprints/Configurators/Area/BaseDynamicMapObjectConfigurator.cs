//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDynamicMapObject"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDynamicMapObjectConfigurator<T, TBuilder>
    : BaseMapObjectConfigurator<T, TBuilder>
    where T : BlueprintDynamicMapObject
    where TBuilder : BaseDynamicMapObjectConfigurator<T, TBuilder>
  {
    protected BaseDynamicMapObjectConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
