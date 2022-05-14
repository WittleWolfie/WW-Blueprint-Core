//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAnswer"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAnswerConfigurator<T, TBuilder>
    : BaseAnswerBaseConfigurator<T, TBuilder>
    where T : BlueprintAnswer
    where TBuilder : BaseAnswerConfigurator<T, TBuilder>
  {
    protected BaseAnswerConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
