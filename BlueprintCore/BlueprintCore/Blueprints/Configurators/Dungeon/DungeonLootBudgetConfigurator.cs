//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Configurator for <see cref="BlueprintDungeonLootBudget"/>.
  /// </summary>
  /// <inheritdoc/>
  public class DungeonLootBudgetConfigurator
    : BaseDungeonLootBudgetConfigurator<BlueprintDungeonLootBudget, DungeonLootBudgetConfigurator>
  {
    private DungeonLootBudgetConfigurator(Blueprint<BlueprintReference<BlueprintDungeonLootBudget>> blueprint) : base(blueprint) { }

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
    public static DungeonLootBudgetConfigurator For(Blueprint<BlueprintReference<BlueprintDungeonLootBudget>> blueprint)
    {
      return new DungeonLootBudgetConfigurator(blueprint);
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
    public static DungeonLootBudgetConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintDungeonLootBudget>(name, guid);
      return For(name);
    }


    public DungeonLootBudgetConfigurator CopyFrom(
      Blueprint<BlueprintReference<BlueprintDungeonLootBudget>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    return Self;
    }
  }
}
