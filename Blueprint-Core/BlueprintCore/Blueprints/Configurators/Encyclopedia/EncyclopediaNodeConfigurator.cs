using BlueprintCore.Utils;
using Kingmaker.Blueprints.Encyclopedia;

namespace BlueprintCore.Blueprints.Configurators.Encyclopedia
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintEncyclopediaNode"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintEncyclopediaNode))]
  public abstract class BaseEncyclopediaNodeConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintEncyclopediaNode
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseEncyclopediaNodeConfigurator(string name) : base(name) { }
  }
}
