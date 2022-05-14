//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Interaction;

namespace BlueprintCore.Blueprints.Configurators.Interaction
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintInteractionRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseInteractionRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintInteractionRoot
    where TBuilder : BaseInteractionRootConfigurator<T, TBuilder>
  {
    protected BaseInteractionRootConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
