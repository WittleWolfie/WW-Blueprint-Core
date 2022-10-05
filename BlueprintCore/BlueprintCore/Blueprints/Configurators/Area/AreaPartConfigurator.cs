//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using System;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Configurator for <see cref="BlueprintAreaPart"/>.
  /// </summary>
  /// <inheritdoc/>
  public class AreaPartConfigurator
    : BaseAreaPartConfigurator<BlueprintAreaPart, AreaPartConfigurator>
  {
    private AreaPartConfigurator(Blueprint<BlueprintReference<BlueprintAreaPart>> blueprint) : base(blueprint) { }

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
    public static AreaPartConfigurator For(Blueprint<BlueprintReference<BlueprintAreaPart>> blueprint)
    {
      return new AreaPartConfigurator(blueprint);
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
    public static AreaPartConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintAreaPart>(name, guid);
      return For(name);
    }


    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public AreaPartConfigurator CopyFrom(
      Blueprint<BlueprintReference<BlueprintAreaPart>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    return Self;
    }
  }
}
