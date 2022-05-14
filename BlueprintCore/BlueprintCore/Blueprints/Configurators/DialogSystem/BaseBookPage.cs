//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintBookPage"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseBookPageConfigurator<T, TBuilder>
    : BaseCueBaseConfigurator<T, TBuilder>
    where T : BlueprintBookPage
    where TBuilder : BaseBookPageConfigurator<T, TBuilder>
  {
    protected BaseBookPageConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
