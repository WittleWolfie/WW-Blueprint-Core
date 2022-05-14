//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="HasManualTargetConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseHasManualTargetConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : HasManualTargetConsideration
    where TBuilder : BaseHasManualTargetConsiderationConfigurator<T, TBuilder>
  {
    protected BaseHasManualTargetConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
