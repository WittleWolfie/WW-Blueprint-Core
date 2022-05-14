//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;

namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintRoot
    where TBuilder : BaseRootConfigurator<T, TBuilder>
  {
    protected BaseRootConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
