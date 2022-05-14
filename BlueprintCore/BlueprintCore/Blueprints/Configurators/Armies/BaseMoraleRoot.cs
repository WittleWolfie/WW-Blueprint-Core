//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="MoraleRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseMoraleRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : MoraleRoot
    where TBuilder : BaseMoraleRootConfigurator<T, TBuilder>
  {
    protected BaseMoraleRootConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
