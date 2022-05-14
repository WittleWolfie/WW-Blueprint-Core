//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="InRangeConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public class InRangeConsiderationConfigurator
    : BaseInRangeConsiderationConfigurator<InRangeConsideration, InRangeConsiderationConfigurator>
  {
    private InRangeConsiderationConfigurator(Blueprint<InRangeConsideration, BlueprintReference<InRangeConsideration>> blueprint) : base(blueprint) { }

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
    public static InRangeConsiderationConfigurator For(Blueprint<InRangeConsideration, BlueprintReference<InRangeConsideration>> blueprint)
    {
      return new InRangeConsiderationConfigurator(blueprint);
    }
    /// <summary>
    /// Creates a new blueprint and returns a new configurator to modify it.
    /// </summary>
    /// <remarks>
    /// <para>
    /// After creating a blueprint with this method you can use either name or GUID to reference the blueprint in BlueprintCore API calls.
    /// </para>
    /// <para>
    /// An implicit cast converts the string to <see cref="Blueprint<,>"/>, exposing the blueprint instance and its reference.
    /// </para>
    /// </remarks>
    public static InRangeConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<InRangeConsideration>(name, guid);
      return For(name);
    }

  }
}
