//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.QA.Arbiter;

namespace BlueprintCore.Blueprints.Configurators.QA
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintArbiterRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseArbiterRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintArbiterRoot
    where TBuilder : BaseArbiterRootConfigurator<T, TBuilder>
  {
    protected BaseArbiterRootConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
