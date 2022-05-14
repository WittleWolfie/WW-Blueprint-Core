//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="Consideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseConsiderationConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : Consideration
    where TBuilder : BaseConsiderationConfigurator<T, TBuilder>
  {
    protected BaseConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
