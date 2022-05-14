//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="ActiveCommandConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseActiveCommandConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : ActiveCommandConsideration
    where TBuilder : BaseActiveCommandConsiderationConfigurator<T, TBuilder>
  {
    protected BaseActiveCommandConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
