//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Craft;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Craft;
using System;

namespace BlueprintCore.Blueprints.Configurators.Craft
{
  /// <summary>
  /// Configurator for <see cref="BlueprintIngredient"/>.
  /// </summary>
  /// <inheritdoc/>
  public class IngredientConfigurator
    : BaseIngredientConfigurator<BlueprintIngredient, IngredientConfigurator>
  {
    private IngredientConfigurator(Blueprint<BlueprintReference<BlueprintIngredient>> blueprint) : base(blueprint) { }

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
    public static IngredientConfigurator For(Blueprint<BlueprintReference<BlueprintIngredient>> blueprint)
    {
      return new IngredientConfigurator(blueprint);
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
    public static IngredientConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintIngredient>(name, guid);
      return For(name);
    }


    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public IngredientConfigurator CopyFrom(
      Blueprint<BlueprintReference<BlueprintIngredient>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    return Self;
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public IngredientConfigurator CopyFrom(
      Blueprint<BlueprintReference<BlueprintIngredient>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    return Self;
    }
  }
}
