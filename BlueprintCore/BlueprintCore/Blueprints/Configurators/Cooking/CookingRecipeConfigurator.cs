//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Controllers.Rest.Cooking;

namespace BlueprintCore.Blueprints.Configurators.Cooking
{
  /// <summary>
  /// Configurator for <see cref="BlueprintCookingRecipe"/>.
  /// </summary>
  /// <inheritdoc/>
  public class CookingRecipeConfigurator
    : BaseCookingRecipeConfigurator<BlueprintCookingRecipe, CookingRecipeConfigurator>
  {
    private CookingRecipeConfigurator(Blueprint<BlueprintReference<BlueprintCookingRecipe>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Returns a configurator to modify the specified blueprint.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this to modify existing blueprints, such as blueprints from the base game.
    /// </para>
    /// <para>
    /// If you're using <see href="https://github.com/OwlcatOpenSource/WrathModificationTemplate">WrathModificationTemplate</see> blueprints defined in JSON already exist.
    /// </para>
    /// </remarks>
    public static CookingRecipeConfigurator For(Blueprint<BlueprintReference<BlueprintCookingRecipe>> blueprint)
    {
      return new CookingRecipeConfigurator(blueprint);
    }
    /// <summary>
    /// Creates a new blueprint and returns a new configurator to modify it.
    /// </summary>
    /// <remarks>
    /// <para>
    /// After creating a blueprint with this method you can use either name or GUID to reference the blueprint in BlueprintCore API calls.
    /// </para>
    /// <para>
    /// An implicit cast converts the string to <see cref="Utils.Blueprint{TRef}"/>, exposing the blueprint instance and its reference.
    /// </para>
    /// </remarks>
    public static CookingRecipeConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintCookingRecipe>(name, guid);
      return For(name);
    }

  }
}
