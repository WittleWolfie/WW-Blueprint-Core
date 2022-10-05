//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="ActiveCommandConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public class ActiveCommandConsiderationConfigurator
    : BaseActiveCommandConsiderationConfigurator<ActiveCommandConsideration, ActiveCommandConsiderationConfigurator>
  {
    private ActiveCommandConsiderationConfigurator(Blueprint<BlueprintReference<ActiveCommandConsideration>> blueprint) : base(blueprint) { }

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
    public static ActiveCommandConsiderationConfigurator For(Blueprint<BlueprintReference<ActiveCommandConsideration>> blueprint)
    {
      return new ActiveCommandConsiderationConfigurator(blueprint);
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
    public static ActiveCommandConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<ActiveCommandConsideration>(name, guid);
      return For(name);
    }


    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public ActiveCommandConsiderationConfigurator CopyFrom(
      Blueprint<BlueprintReference<ActiveCommandConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    return Self;
    }
  }
}
