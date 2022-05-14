//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCheck"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCheckConfigurator<T, TBuilder>
    : BaseCueBaseConfigurator<T, TBuilder>
    where T : BlueprintCheck
    where TBuilder : BaseCheckConfigurator<T, TBuilder>
  {
    protected BaseCheckConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
