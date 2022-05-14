//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="DistanceConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDistanceConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : DistanceConsideration
    where TBuilder : BaseDistanceConsiderationConfigurator<T, TBuilder>
  {
    protected BaseDistanceConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
