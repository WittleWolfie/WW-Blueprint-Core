//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="HealthAroundConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseHealthAroundConsiderationConfigurator<T, TBuilder>
    : BaseUnitsAroundConsiderationConfigurator<T, TBuilder>
    where T : HealthAroundConsideration
    where TBuilder : BaseHealthAroundConsiderationConfigurator<T, TBuilder>
  {
    protected BaseHealthAroundConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
