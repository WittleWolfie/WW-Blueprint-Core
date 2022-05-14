//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAnswersList"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAnswersListConfigurator<T, TBuilder>
    : BaseAnswerBaseConfigurator<T, TBuilder>
    where T : BlueprintAnswersList
    where TBuilder : BaseAnswersListConfigurator<T, TBuilder>
  {
    protected BaseAnswersListConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
