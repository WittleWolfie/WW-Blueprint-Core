//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="LifeStateConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseLifeStateConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : LifeStateConsideration
    where TBuilder : BaseLifeStateConsiderationConfigurator<T, TBuilder>
  {
    protected BaseLifeStateConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
