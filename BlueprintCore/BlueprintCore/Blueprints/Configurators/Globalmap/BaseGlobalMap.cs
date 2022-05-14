//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintGlobalMap"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseGlobalMapConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintGlobalMap
    where TBuilder : BaseGlobalMapConfigurator<T, TBuilder>
  {
    protected BaseGlobalMapConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
