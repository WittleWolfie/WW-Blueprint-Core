//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Configurator for <see cref="OverrideLegacyUnits"/>.
  /// </summary>
  /// <inheritdoc/>
  public class OverrideLegacyUnitsConfigurator
    : BaseOverrideLegacyUnitsConfigurator<OverrideLegacyUnits, OverrideLegacyUnitsConfigurator>
  {
    private OverrideLegacyUnitsConfigurator(Blueprint<BlueprintReference<OverrideLegacyUnits>> blueprint) : base(blueprint) { }

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
    public static OverrideLegacyUnitsConfigurator For(Blueprint<BlueprintReference<OverrideLegacyUnits>> blueprint)
    {
      return new OverrideLegacyUnitsConfigurator(blueprint);
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
    public static OverrideLegacyUnitsConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<OverrideLegacyUnits>(name, guid);
      return For(name);
    }


    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public OverrideLegacyUnitsConfigurator CopyFrom(
      Blueprint<BlueprintReference<OverrideLegacyUnits>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    return Self;
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public OverrideLegacyUnitsConfigurator CopyFrom(
      Blueprint<BlueprintReference<OverrideLegacyUnits>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    return Self;
    }
  }
}