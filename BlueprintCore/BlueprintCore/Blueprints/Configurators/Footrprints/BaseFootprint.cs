//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Footrprints;

namespace BlueprintCore.Blueprints.Configurators.Footrprints
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintFootprint"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseFootprintConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintFootprint
    where TBuilder : BaseFootprintConfigurator<T, TBuilder>
  {
    protected BaseFootprintConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
