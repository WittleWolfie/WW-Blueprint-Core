//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintGlobalMapEdge"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseGlobalMapEdgeConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintGlobalMapEdge
    where TBuilder : BaseGlobalMapEdgeConfigurator<T, TBuilder>
  {
    protected BaseGlobalMapEdgeConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
