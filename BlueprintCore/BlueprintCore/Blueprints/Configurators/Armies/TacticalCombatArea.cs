//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Blueprints;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>
  /// Configurator for <see cref="BlueprintTacticalCombatArea"/>.
  /// </summary>
  /// <inheritdoc/>
  public class TacticalCombatAreaConfigurator
    : BaseTacticalCombatAreaConfigurator<BlueprintTacticalCombatArea, TacticalCombatAreaConfigurator>
  {
    private TacticalCombatAreaConfigurator(Blueprint<BlueprintTacticalCombatArea, BlueprintReference<BlueprintTacticalCombatArea>> blueprint) : base(blueprint) { }

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
    public static TacticalCombatAreaConfigurator For(Blueprint<BlueprintTacticalCombatArea, BlueprintReference<BlueprintTacticalCombatArea>> blueprint)
    {
      return new TacticalCombatAreaConfigurator(blueprint);
    }
    /// <summary>
    /// Creates a new blueprint and returns a new configurator to modify it.
    /// </summary>
    /// <remarks>
    /// <para>
    /// After creating a blueprint with this method you can use either name or GUID to reference the blueprint in BlueprintCore API calls.
    /// </para>
    /// <para>
    /// An implicit cast converts the string to <see cref="Utils.Blueprint{T, TRef}"/>, exposing the blueprint instance and its reference.
    /// </para>
    /// </remarks>
    public static TacticalCombatAreaConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintTacticalCombatArea>(name, guid);
      return For(name);
    }

  }
}
