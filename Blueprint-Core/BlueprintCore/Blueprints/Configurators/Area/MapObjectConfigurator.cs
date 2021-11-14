using BlueprintCore.Utils;
using Kingmaker.Blueprints.Area;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintMapObject"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintMapObject))]
  public abstract class BaseMapObjectConfigurator<T, TBuilder>
      : BaseLogicConnectorConfigurator<T, TBuilder>
      where T : BlueprintMapObject
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseMapObjectConfigurator(string name) : base(name) { }
  }
}
