//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Items;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Craft;

namespace BlueprintCore.Blueprints.Configurators.Craft
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintIngredient"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseIngredientConfigurator<T, TBuilder>
    : BaseItemConfigurator<T, TBuilder>
    where T : BlueprintIngredient
    where TBuilder : BaseIngredientConfigurator<T, TBuilder>
  {
    protected BaseIngredientConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
