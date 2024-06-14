//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Corruption;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Corruption;
using System;

namespace BlueprintCore.Blueprints.Configurators.Corruption
{
  /// <summary>
  /// Configurator for <see cref="BlueprintCorruptionRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public class CorruptionRootConfigurator
    : BaseCorruptionRootConfigurator<BlueprintCorruptionRoot, CorruptionRootConfigurator>
  {
    private CorruptionRootConfigurator(Blueprint<BlueprintReference<BlueprintCorruptionRoot>> blueprint) : base(blueprint) { }

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
    public static CorruptionRootConfigurator For(Blueprint<BlueprintReference<BlueprintCorruptionRoot>> blueprint)
    {
      return new CorruptionRootConfigurator(blueprint);
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
    public static CorruptionRootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintCorruptionRoot>(name, guid);
      return For(name);
    }


    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public CorruptionRootConfigurator CopyFrom(
      Blueprint<BlueprintReference<BlueprintCorruptionRoot>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    return Self;
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public CorruptionRootConfigurator CopyFrom(
      Blueprint<BlueprintReference<BlueprintCorruptionRoot>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    return Self;
    }
  }
}
