//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Encyclopedia;

namespace BlueprintCore.Blueprints.Configurators.Encyclopedia
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintEncyclopediaNode"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseEncyclopediaNodeConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintEncyclopediaNode
    where TBuilder : BaseEncyclopediaNodeConfigurator<T, TBuilder>
  {
    protected BaseEncyclopediaNodeConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
