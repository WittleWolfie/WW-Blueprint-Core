using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Capital;
using Kingmaker.Blueprints;
using Kingmaker.Corruption;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Dungeon.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Persistence;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Localization;
using System;

namespace BlueprintCore.Actions.Builder.AreaEx
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



    /// <summary>
    /// Adds <see cref="AskPlayerForLocationName"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Location"><see cref="BlueprintGlobalMapPoint"/></param>
    [Generated]
    [Implements(typeof(AskPlayerForLocationName))]
    public static ActionsBuilder AddAskPlayerForLocationName(
        this ActionsBuilder builder,
        string m_Location,
        Boolean Obligatory,
        LocalizedString Title,
        LocalizedString Hint,
        LocalizedString Default)
    {
      builder.Validate(Obligatory);
      builder.Validate(Title);
      builder.Validate(Hint);
      builder.Validate(Default);
      
      var element = ElementTool.Create<AskPlayerForLocationName>();
      element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(m_Location);
      element.Obligatory = Obligatory;
      element.Title = Title;
      element.Hint = Hint;
      element.Default = Default;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GlobalMapTeleport"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GlobalMapTeleport))]
    public static ActionsBuilder AddGlobalMapTeleport(
        this ActionsBuilder builder,
        LocationEvaluator Destination,
        FloatEvaluator SkipHours,
        Boolean UpdateLocationVisitedTime)
    {
      builder.Validate(Destination);
      builder.Validate(SkipHours);
      builder.Validate(UpdateLocationVisitedTime);
      
      var element = ElementTool.Create<GlobalMapTeleport>();
      element.Destination = Destination;
      element.SkipHours = SkipHours;
      element.UpdateLocationVisitedTime = UpdateLocationVisitedTime;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DecreaseCorruptionLevelAction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DecreaseCorruptionLevelAction))]
    public static ActionsBuilder AddDecreaseCorruptionLevelAction(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<DecreaseCorruptionLevelAction>());
    }

    /// <summary>
    /// Adds <see cref="CapitalExit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Destination"><see cref="BlueprintAreaEnterPoint"/></param>
    [Generated]
    [Implements(typeof(CapitalExit))]
    public static ActionsBuilder AddCapitalExit(
        this ActionsBuilder builder,
        string m_Destination,
        AutoSaveMode AutoSaveMode)
    {
      builder.Validate(AutoSaveMode);
      
      var element = ElementTool.Create<CapitalExit>();
      element.m_Destination = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(m_Destination);
      element.AutoSaveMode = AutoSaveMode;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GameActionSetIsleLock"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GameActionSetIsleLock))]
    public static ActionsBuilder AddGameActionSetIsleLock(
        this ActionsBuilder builder,
        IsleEvaluator m_Isle,
        Boolean m_IsLock)
    {
      builder.Validate(m_Isle);
      builder.Validate(m_IsLock);
      
      var element = ElementTool.Create<GameActionSetIsleLock>();
      element.m_Isle = m_Isle;
      element.m_IsLock = m_IsLock;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GameActionSetIsleState"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GameActionSetIsleState))]
    public static ActionsBuilder AddGameActionSetIsleState(
        this ActionsBuilder builder,
        IsleEvaluator m_Isle,
        String m_StateName)
    {
      builder.Validate(m_Isle);
      foreach (var item in m_StateName)
      {
        builder.Validate(item);
      }
      
      var element = ElementTool.Create<GameActionSetIsleState>();
      element.m_Isle = m_Isle;
      element.m_StateName = m_StateName;
      return builder.Add(element);
    }
  }
}
