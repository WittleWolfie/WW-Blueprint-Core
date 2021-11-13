using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Controllers.Rest.Cooking;
namespace BlueprintCore.Blueprints.Configurators.Controllers.Rest.Cooking
{
  /// <summary>Configurator for <see cref="BlueprintCookingRecipe"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCookingRecipe))]
  public class CookingRecipeConfigurator : BaseBlueprintConfigurator<BlueprintCookingRecipe, CookingRecipeConfigurator>
  {
     private CookingRecipeConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CookingRecipeConfigurator For(string name)
    {
      return new CookingRecipeConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CookingRecipeConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintCookingRecipe>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CookingRecipeConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintCookingRecipe>(name, assetId);
      return For(name);
    }

  }
}
