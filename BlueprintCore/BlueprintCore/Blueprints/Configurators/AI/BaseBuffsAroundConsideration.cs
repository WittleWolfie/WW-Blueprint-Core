//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BuffsAroundConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseBuffsAroundConsiderationConfigurator<T, TBuilder>
    : BaseUnitsAroundConsiderationConfigurator<T, TBuilder>
    where T : BuffsAroundConsideration
    where TBuilder : BaseBuffsAroundConsiderationConfigurator<T, TBuilder>
  {
    protected BaseBuffsAroundConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
