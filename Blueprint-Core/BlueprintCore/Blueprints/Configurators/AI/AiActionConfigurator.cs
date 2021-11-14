using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAiAction"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAiAction))]
  public abstract class BaseAiActionConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintAiAction
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseAiActionConfigurator(string name) : base(name) { }
  }
}
