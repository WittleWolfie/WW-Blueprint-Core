using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Dungeon.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Localization;

namespace BlueprintCoreGen.Actions.Builder.AreaEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for actions involving the game map, dungeons, or locations. See also
  /// <see cref="KingdomEx.ActionsBuilderKingdomEx">KingdomEx</see>.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderAreaEx
  {
    //----- Kingmaker.Dungeon.Actions -----//

    /// <summary>
    /// Adds <see cref="ActionCreateImportedCompanion"/>
    /// </summary>
    [Implements(typeof(ActionCreateImportedCompanion))]
    public static ActionsBuilder CreateImportedCompanion(this ActionsBuilder builder, int index)
    {
      var createCompanion = ElementTool.Create<ActionCreateImportedCompanion>();
      createCompanion.Index = index;
      return builder.Add(createCompanion);
    }

    /// <summary>
    /// Adds <see cref="ActionEnterToDungeon"/>
    /// </summary>
    [Implements(typeof(ActionEnterToDungeon))]
    public static ActionsBuilder TeleportToLastDungeonStageEntrance(this ActionsBuilder builder, int minStage = 1)
    {
      var teleport = ElementTool.Create<ActionEnterToDungeon>();
      teleport.FirstStage = minStage;
      return builder.Add(teleport);
    }


    /// <summary>
    /// Adds <see cref="ActionGoDeeperIntoDungeon"/>
    /// </summary>
    [Implements(typeof(ActionGoDeeperIntoDungeon))]
    public static ActionsBuilder EnterNextDungeonStage(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ActionGoDeeperIntoDungeon>());
    }

    /// <summary>
    /// Adds <see cref="ActionIncreaseDungeonStage"/>
    /// </summary>
    [Implements(typeof(ActionIncreaseDungeonStage))]
    public static ActionsBuilder IncrementDungeonStage(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ActionIncreaseDungeonStage>());
    }

    /// <summary>
    /// Adds <see cref="ActionSetDungeonStage"/>
    /// </summary>
    [Implements(typeof(ActionSetDungeonStage))]
    public static ActionsBuilder SetDungeonStage(this ActionsBuilder builder, int stage = 1)
    {
      var setStage = ElementTool.Create<ActionSetDungeonStage>();
      setStage.Stage = stage;
      return builder.Add(setStage);
    }

    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    /// <summary>
    /// Adds <see cref="AreaEntranceChange"/>
    /// </summary>
    /// 
    /// <param name="location"><see cref="BlueprintGlobalMapPoint"/></param>
    /// <param name="newLocation"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint">BlueprintAreaEnterPoint</see></param>
    [Implements(typeof(AreaEntranceChange))]
    public static ActionsBuilder ChangeAreaEntrance(
        this ActionsBuilder builder, string location, string newLocation)
    {
      var changeEntrance = ElementTool.Create<AreaEntranceChange>();
      changeEntrance.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(location);
      changeEntrance.m_NewEntrance = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(newLocation);
      return builder.Add(changeEntrance);
    }

    /// <summary>
    /// Adds
    /// <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.ChangeCurrentAreaName">ChangeCurrentAreaName</see>
    /// </summary>
    [Implements(typeof(ChangeCurrentAreaName))]
    public static ActionsBuilder ChangeCurrentAreaName(this ActionsBuilder builder, LocalizedString name)
    {
      var changeName = ElementTool.Create<ChangeCurrentAreaName>();
      changeName.NewName = name;
      return builder.Add(changeName);
    }

    /// <summary>
    /// Adds
    /// <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.ChangeCurrentAreaName">ChangeCurrentAreaName</see>
    /// </summary>
    [Implements(typeof(ChangeCurrentAreaName))]
    public static ActionsBuilder ResetCurrentAreaName(this ActionsBuilder builder)
    {
      var changeName = ElementTool.Create<ChangeCurrentAreaName>();
      changeName.RestoreDefault = true;
      return builder.Add(changeName);
    }

    /// <summary>
    /// Adds
    /// <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.AddCampingEncounter">AddCampingEncounter</see>
    /// </summary>
    [Implements(typeof(AddCampingEncounter))]
    public static ActionsBuilder AddCampingEncounter(this ActionsBuilder builder, string encounter)
    {
      var addEncounter = ElementTool.Create<AddCampingEncounter>();
      addEncounter.m_Encounter = BlueprintTool.GetRef<BlueprintCampingEncounterReference>(encounter);
      return builder.Add(addEncounter);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.DestroyMapObject">DestroyMapObject</see>
    /// </summary>
    [Implements(typeof(DestroyMapObject))]
    public static ActionsBuilder DestroyMapObject(this ActionsBuilder builder, MapObjectEvaluator obj)
    {
      var destroy = ElementTool.Create<DestroyMapObject>();
      destroy.MapObject = obj;
      return builder.Add(destroy);
    }

    //----- Auto Generated -----//

    // [Generate(Kingmaker.AreaLogic.Capital.CapitalExit)]
    // [Generate(Kingmaker.Corruption.DecreaseCorruptionLevelAction)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.AskPlayerForLocationName)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.GlobalMapTeleport)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.HideMapObject)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.LocalMapSetDirty)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.MakeServiceCaster)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.MarkLocationClosed)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.MarkLocationExplored)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.MarkOnLocalMap)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.OpenLootContainer)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.RemoveAllAreasFromSave)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.RemoveAmbush)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.RemoveAreaFromSave)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.RemoveCampingEncounter)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.ResetLocationPerceptionCheck)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.RevealGlobalMap)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.ShowMultiEntrance)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.SpotMapObject)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.SpotUnit)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.TeleportParty)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.TranslocatePlayer)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.TranslocateUnit)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.TrapCastSpell)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.UnlockCookingRecipe)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.UnlockLocation)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.UnlockMapEdge)]
    // [Generate(Kingmaker.ElementsSystem.GameActionSetIsleLock)]
    // [Generate(Kingmaker.ElementsSystem.GameActionSetIsleState)]

  }
}
