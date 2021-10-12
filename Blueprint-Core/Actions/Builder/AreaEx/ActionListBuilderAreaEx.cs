using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Dungeon.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Localization;
using Kingmaker.RandomEncounters.Settings;

namespace BlueprintCore.Actions.Builder.AreaEx
{
  /**
   * Extension to ActionListBuilder for map, dungeon, and other location based actions. See also
   * KingdomEx which contains similar actions tied specifically to the Kingdom and Crusade system.
   */
  public static class ActionListBuilderAreaEx
  {
    //----- Kingmaker.Dungeon.Actions -----//

    /** ActionCreateImportedCompanion */
    public static ActionListBuilder CreateImportedCompanion(
        this ActionListBuilder builder, int index)
    {
      var createCompanion = ElementTool.Create<ActionCreateImportedCompanion>();
      createCompanion.Index = index;
      return builder.Add(createCompanion);
    }

    /** ActionEnterToDungeon */
    public static ActionListBuilder TeleportToLastDungeonStageEntrance(
        this ActionListBuilder builder, int minStage = 1)
    {
      var teleport = ElementTool.Create<ActionEnterToDungeon>();
      teleport.FirstStage = minStage;
      return builder.Add(teleport);
    }

    /** ActionGoDeeperIntoDungeon */
    public static ActionListBuilder EnterNextDungeonStage(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ActionGoDeeperIntoDungeon>());
    }

    /** ActionIncreaseDungeonStage */
    public static ActionListBuilder IncrementDungeonStage(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ActionIncreaseDungeonStage>());
    }

    /** ActionSetDungeonStage */
    public static ActionListBuilder SetDungeonStage(this ActionListBuilder builder, int stage = 1)
    {
      var setStage = ElementTool.Create<ActionSetDungeonStage>();
      setStage.Stage = stage;
      return builder.Add(setStage);
    }

    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    /**
     * AddEntranceChange
     *
     * @param location BlueprintGlobalMapPoint
     * @param newLocation BlueprintAreaEnterPoint
     */
    public static ActionListBuilder ChangeAreaEntrance(
        this ActionListBuilder builder, string location, string newLocation)
    {
      var changeEntrance = ElementTool.Create<AreaEntranceChange>();
      changeEntrance.m_Location =
          BlueprintTool
              .GetRef<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>(location);
      changeEntrance.m_NewEntrance =
          BlueprintTool
              .GetRef<BlueprintAreaEnterPoint, BlueprintAreaEnterPointReference>(newLocation);
      return builder.Add(changeEntrance);
    }

    /** ChangeCurrentAreaName */
    public static ActionListBuilder ChangeCurrentAreaName(
        this ActionListBuilder builder, LocalizedString name)
    {
      var changeName = ElementTool.Create<ChangeCurrentAreaName>();
      changeName.NewName = name;
      return builder.Add(changeName);
    }

    /** ChangeCurrentAreaName */
    public static ActionListBuilder ResetCurrentAreaName(this ActionListBuilder builder)
    {
      var changeName = ElementTool.Create<ChangeCurrentAreaName>();
      changeName.RestoreDefault = true;
      return builder.Add(changeName);
    }

    /**
     * AddCampingEncounter
     *
     * @param encounter BlueprintCampingEncounter
     */
    public static ActionListBuilder AddCampingEncounter(
        this ActionListBuilder builder, string encounter)
    {
      var addEncounter = ElementTool.Create<AddCampingEncounter>();
      addEncounter.m_Encounter =
          BlueprintTool
              .GetRef<BlueprintCampingEncounter, BlueprintCampingEncounterReference>(encounter);
      return builder.Add(addEncounter);
    }

    /** DestroyMapObject */
    public static ActionListBuilder DestroyMapObject(
        this ActionListBuilder builder, MapObjectEvaluator obj)
    {
      var destroy = ElementTool.Create<DestroyMapObject>();
      destroy.MapObject = obj;
      return builder.Add(destroy);
    }
  }
}