using BlueprintCore.Blueprints.Configurators.RandomEncounters.Settings;
using BlueprintCore.Utils;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.ElementsSystem;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Configurator for <see cref="BlueprintDungeonShrine"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintDungeonShrine))]
  public class DungeonShrineConfigurator : BaseSpawnableObjectConfigurator<BlueprintDungeonShrine, DungeonShrineConfigurator>
  {
    private DungeonShrineConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DungeonShrineConfigurator For(string name)
    {
      return new DungeonShrineConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static DungeonShrineConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintDungeonShrine>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DungeonShrineConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintDungeonShrine>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonShrine.UseCondition"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="useCondition"><see cref="ConditionsHolder"/></param>
    [Generated]
    public DungeonShrineConfigurator SetUseCondition(string useCondition)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.UseCondition = BlueprintTool.GetRef<ConditionsReference>(useCondition);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonShrine.CheckPassedActions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkPassedActions"><see cref="ActionsHolder"/></param>
    [Generated]
    public DungeonShrineConfigurator SetCheckPassedActions(string checkPassedActions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CheckPassedActions = BlueprintTool.GetRef<ActionsReference>(checkPassedActions);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonShrine.CheckFailedActions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkFailedActions"><see cref="ActionsHolder"/></param>
    [Generated]
    public DungeonShrineConfigurator SetCheckFailedActions(string checkFailedActions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CheckFailedActions = BlueprintTool.GetRef<ActionsReference>(checkFailedActions);
          });
    }
  }
}
