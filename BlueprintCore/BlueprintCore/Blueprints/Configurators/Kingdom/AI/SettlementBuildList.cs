//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.AI;

namespace BlueprintCore.Blueprints.Configurators.Kingdom.AI
{
  /// <summary>
  /// Configurator for <see cref="SettlementBuildList"/>.
  /// </summary>
  /// <inheritdoc/>
  public class SettlementBuildListConfigurator
    : BaseSettlementBuildListConfigurator<SettlementBuildList, SettlementBuildListConfigurator>
  {
    private SettlementBuildListConfigurator(Blueprint<SettlementBuildList, BlueprintReference<SettlementBuildList>> blueprint) : base(blueprint) { }

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
    public static SettlementBuildListConfigurator For(Blueprint<SettlementBuildList, BlueprintReference<SettlementBuildList>> blueprint)
    {
      return new SettlementBuildListConfigurator(blueprint);
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
    public static SettlementBuildListConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<SettlementBuildList>(name, guid);
      return For(name);
    }

  }
}
