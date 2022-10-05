//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.Armies.Brain
{
  /// <summary>
  /// Configurator for <see cref="BlueprintTacticalCombatBrain"/>.
  /// </summary>
  /// <inheritdoc/>
  public class TacticalCombatBrainConfigurator
    : BaseTacticalCombatBrainConfigurator<BlueprintTacticalCombatBrain, TacticalCombatBrainConfigurator>
  {
    private TacticalCombatBrainConfigurator(Blueprint<BlueprintReference<BlueprintTacticalCombatBrain>> blueprint) : base(blueprint) { }

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
    public static TacticalCombatBrainConfigurator For(Blueprint<BlueprintReference<BlueprintTacticalCombatBrain>> blueprint)
    {
      return new TacticalCombatBrainConfigurator(blueprint);
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
    public static TacticalCombatBrainConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintTacticalCombatBrain>(name, guid);
      return For(name);
    }


    public TacticalCombatBrainConfigurator CopyFrom(
      Blueprint<BlueprintReference<BlueprintTacticalCombatBrain>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    return Self;
    }
  }
}
