//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Footrprints;

namespace BlueprintCore.Blueprints.Configurators.Footrprints
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintFootprintType"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseFootprintTypeConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintFootprintType
    where TBuilder : BaseFootprintTypeConfigurator<T, TBuilder>
  {
    protected BaseFootprintTypeConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
