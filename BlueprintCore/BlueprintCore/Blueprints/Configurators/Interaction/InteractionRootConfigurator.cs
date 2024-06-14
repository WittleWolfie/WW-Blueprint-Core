//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Interaction;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Interaction;
using System;

namespace BlueprintCore.Blueprints.Configurators.Interaction
{
  /// <summary>
  /// Configurator for <see cref="BlueprintInteractionRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public class InteractionRootConfigurator
    : BaseInteractionRootConfigurator<BlueprintInteractionRoot, InteractionRootConfigurator>
  {
    private InteractionRootConfigurator(Blueprint<BlueprintReference<BlueprintInteractionRoot>> blueprint) : base(blueprint) { }

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
    public static InteractionRootConfigurator For(Blueprint<BlueprintReference<BlueprintInteractionRoot>> blueprint)
    {
      return new InteractionRootConfigurator(blueprint);
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
    public static InteractionRootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintInteractionRoot>(name, guid);
      return For(name);
    }


    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public InteractionRootConfigurator CopyFrom(
      Blueprint<BlueprintReference<BlueprintInteractionRoot>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    return Self;
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public InteractionRootConfigurator CopyFrom(
      Blueprint<BlueprintReference<BlueprintInteractionRoot>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    return Self;
    }
  }
}
