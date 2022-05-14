//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="LineOfSightConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseLineOfSightConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : LineOfSightConsideration
    where TBuilder : BaseLineOfSightConsiderationConfigurator<T, TBuilder>
  {
    protected BaseLineOfSightConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
