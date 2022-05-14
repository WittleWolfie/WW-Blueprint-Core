//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCompanionStory"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCompanionStoryConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintCompanionStory
    where TBuilder : BaseCompanionStoryConfigurator<T, TBuilder>
  {
    protected BaseCompanionStoryConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
