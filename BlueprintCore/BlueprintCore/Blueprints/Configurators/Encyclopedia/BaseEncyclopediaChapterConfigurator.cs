//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Encyclopedia;

namespace BlueprintCore.Blueprints.Configurators.Encyclopedia
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintEncyclopediaChapter"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseEncyclopediaChapterConfigurator<T, TBuilder>
    : BaseEncyclopediaPageConfigurator<T, TBuilder>
    where T : BlueprintEncyclopediaChapter
    where TBuilder : BaseEncyclopediaChapterConfigurator<T, TBuilder>
  {
    protected BaseEncyclopediaChapterConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
