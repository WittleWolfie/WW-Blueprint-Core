//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCueSequence"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCueSequenceConfigurator<T, TBuilder>
    : BaseCueBaseConfigurator<T, TBuilder>
    where T : BlueprintCueSequence
    where TBuilder : BaseCueSequenceConfigurator<T, TBuilder>
  {
    protected BaseCueSequenceConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
