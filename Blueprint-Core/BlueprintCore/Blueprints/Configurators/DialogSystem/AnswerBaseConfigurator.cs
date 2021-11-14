using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.DialogSystem.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAnswerBase"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAnswerBase))]
  public abstract class BaseAnswerBaseConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintAnswerBase
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseAnswerBaseConfigurator(string name) : base(name) { }
  }
}
