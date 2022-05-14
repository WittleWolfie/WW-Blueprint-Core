//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="ManualTargetConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseManualTargetConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : ManualTargetConsideration
    where TBuilder : BaseManualTargetConsiderationConfigurator<T, TBuilder>
  {
    protected BaseManualTargetConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
