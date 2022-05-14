//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Controllers.Rest.Cooking;

namespace BlueprintCore.Blueprints.Configurators.Cooking
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCookingRecipe"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCookingRecipeConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintCookingRecipe
    where TBuilder : BaseCookingRecipeConfigurator<T, TBuilder>
  {
    protected BaseCookingRecipeConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
