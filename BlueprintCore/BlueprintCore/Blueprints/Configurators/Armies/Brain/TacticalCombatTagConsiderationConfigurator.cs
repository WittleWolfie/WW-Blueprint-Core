//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain.Considerations;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Armies.Brain
{
  /// <summary>
  /// Configurator for <see cref="TacticalCombatTagConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public class TacticalCombatTagConsiderationConfigurator
    : BaseTacticalCombatTagConsiderationConfigurator<TacticalCombatTagConsideration, TacticalCombatTagConsiderationConfigurator>
  {
    private TacticalCombatTagConsiderationConfigurator(Blueprint<BlueprintReference<TacticalCombatTagConsideration>> blueprint) : base(blueprint) { }

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
    public static TacticalCombatTagConsiderationConfigurator For(Blueprint<BlueprintReference<TacticalCombatTagConsideration>> blueprint)
    {
      return new TacticalCombatTagConsiderationConfigurator(blueprint);
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
    public static TacticalCombatTagConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<TacticalCombatTagConsideration>(name, guid);
      return For(name);
    }

  }
}
