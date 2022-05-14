//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Encyclopedia;

namespace BlueprintCore.Blueprints.Configurators.Encyclopedia
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintEncyclopediaPage"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseEncyclopediaPageConfigurator<T, TBuilder>
    : BaseEncyclopediaNodeConfigurator<T, TBuilder>
    where T : BlueprintEncyclopediaPage
    where TBuilder : BaseEncyclopediaPageConfigurator<T, TBuilder>
  {
    protected BaseEncyclopediaPageConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
