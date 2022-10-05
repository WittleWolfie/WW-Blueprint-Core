//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.Armies.Brain
{
  /// <summary>
  /// Configurator for <see cref="BlueprintTacticalCombatAiAttack"/>.
  /// </summary>
  /// <inheritdoc/>
  public class TacticalCombatAiAttackConfigurator
    : BaseTacticalCombatAiAttackConfigurator<BlueprintTacticalCombatAiAttack, TacticalCombatAiAttackConfigurator>
  {
    private TacticalCombatAiAttackConfigurator(Blueprint<BlueprintReference<BlueprintTacticalCombatAiAttack>> blueprint) : base(blueprint) { }

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
    public static TacticalCombatAiAttackConfigurator For(Blueprint<BlueprintReference<BlueprintTacticalCombatAiAttack>> blueprint)
    {
      return new TacticalCombatAiAttackConfigurator(blueprint);
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
    public static TacticalCombatAiAttackConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintTacticalCombatAiAttack>(name, guid);
      return For(name);
    }


    public TacticalCombatAiAttackConfigurator CopyFrom(
      Blueprint<BlueprintReference<BlueprintTacticalCombatAiAttack>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    return Self;
    }
  }
}
