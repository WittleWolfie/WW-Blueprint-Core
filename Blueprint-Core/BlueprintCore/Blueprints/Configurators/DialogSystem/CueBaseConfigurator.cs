using BlueprintCore.Utils;
using Kingmaker.DialogSystem.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCueBase"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCueBase))]
  public abstract class BaseCueBaseConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintCueBase
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseCueBaseConfigurator(string name) : base(name) { }
  }
}
