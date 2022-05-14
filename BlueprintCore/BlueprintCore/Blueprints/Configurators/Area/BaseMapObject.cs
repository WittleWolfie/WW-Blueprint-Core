//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;

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
    protected BaseMapObjectConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
