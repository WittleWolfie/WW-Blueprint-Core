//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="AlignmentConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAlignmentConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : AlignmentConsideration
    where TBuilder : BaseAlignmentConsiderationConfigurator<T, TBuilder>
  {
    protected BaseAlignmentConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
