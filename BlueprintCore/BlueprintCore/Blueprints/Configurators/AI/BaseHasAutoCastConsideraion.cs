//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="HasAutoCastConsideraion"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseHasAutoCastConsideraionConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : HasAutoCastConsideraion
    where TBuilder : BaseHasAutoCastConsideraionConfigurator<T, TBuilder>
  {
    protected BaseHasAutoCastConsideraionConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
