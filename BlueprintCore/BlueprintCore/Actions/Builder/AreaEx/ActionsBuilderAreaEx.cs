//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Capital;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Controllers.Rest.Cooking;
using Kingmaker.Corruption;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Dungeon.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Persistence;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Localization;
using Kingmaker.RandomEncounters.Settings;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Actions.Builder.AreaEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for actions involving the game map, dungeons, or locations. See also <see cref="KingdomEx.ActionsBuilderKingdomEx">KingdomEx</see>.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderAreaEx
{

    /// <summary>
    /// Adds <see cref="CapitalExit"/>
    /// </summary>
    ///
    /// <param name="destination">
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder CapitalExit(
        this ActionsBuilder builder,
        AutoSaveMode? autoSaveMode = null,
        Blueprint<BlueprintAreaEnterPoint, BlueprintAreaEnterPointReference>? destination = null)
    {
      var element = ElementTool.Create<CapitalExit>();
      element.AutoSaveMode = autoSaveMode ?? element.AutoSaveMode;
      element.m_Destination = destination.Reference ?? element.m_Destination;
      if (element.m_Destination is null)
      {
        element.m_Destination = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DecreaseCorruptionLevelAction"/>
    /// </summary>
    public static ActionsBuilder DecreaseCorruptionLevelAction(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<DecreaseCorruptionLevelAction>());
    }

    /// <summary>
    /// Adds <see cref="AddCampingEncounter"/>
    /// </summary>
    ///
    /// <param name="encounter">
    /// Blueprint of type BlueprintCampingEncounter. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AddCampingEncounter(
        this ActionsBuilder builder,
        Blueprint<BlueprintCampingEncounter, BlueprintCampingEncounterReference> encounter)
    {
      var element = ElementTool.Create<AddCampingEncounter>();
      element.m_Encounter = encounter.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AreaEntranceChange"/>
    /// </summary>
    ///
    /// <param name="location">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="newEntrance">
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AreaEntranceChange(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference> location,
        Blueprint<BlueprintAreaEnterPoint, BlueprintAreaEnterPointReference> newEntrance)
    {
      var element = ElementTool.Create<AreaEntranceChange>();
      element.m_Location = location.Reference;
      element.m_NewEntrance = newEntrance.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AskPlayerForLocationName"/>
    /// </summary>
    ///
    /// <param name="location">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AskPlayerForLocationName(
        this ActionsBuilder builder,
        LocalizedString? defaultValue = null,
        LocalizedString? hint = null,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>? location = null,
        bool? obligatory = null,
        LocalizedString? title = null)
    {
      var element = ElementTool.Create<AskPlayerForLocationName>();
      element.Default = defaultValue ?? element.Default;
      if (element.Default is null)
      {
        element.Default = Constants.Empty.String;
      }
      element.Hint = hint ?? element.Hint;
      if (element.Hint is null)
      {
        element.Hint = Constants.Empty.String;
      }
      element.m_Location = location.Reference ?? element.m_Location;
      if (element.m_Location is null)
      {
        element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      element.Obligatory = obligatory ?? element.Obligatory;
      element.Title = title ?? element.Title;
      if (element.Title is null)
      {
        element.Title = Constants.Empty.String;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangeCurrentAreaName"/>
    /// </summary>
    public static ActionsBuilder ChangeCurrentAreaName(
        this ActionsBuilder builder,
        LocalizedString newName)
    {
      var element = ElementTool.Create<ChangeCurrentAreaName>();
      element.NewName = newName;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangeCurrentAreaName"/>
    /// </summary>
    public static ActionsBuilder ResetCurrentAreaName(this ActionsBuilder builder)
    {
      var element = ElementTool.Create<ChangeCurrentAreaName>();
      element.RestoreDefault = true;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DestroyMapObject"/>
    /// </summary>
    public static ActionsBuilder DestroyMapObject(
        this ActionsBuilder builder,
        MapObjectEvaluator mapObject)
    {
      var element = ElementTool.Create<DestroyMapObject>();
      builder.Validate(mapObject);
      element.MapObject = mapObject;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GlobalMapTeleport"/>
    /// </summary>
    public static ActionsBuilder GlobalMapTeleport(
        this ActionsBuilder builder,
        LocationEvaluator? destination = null,
        FloatEvaluator? skipHours = null,
        bool? updateLocationVisitedTime = null)
    {
      var element = ElementTool.Create<GlobalMapTeleport>();
      builder.Validate(destination);
      element.Destination = destination ?? element.Destination;
      builder.Validate(skipHours);
      element.SkipHours = skipHours ?? element.SkipHours;
      element.UpdateLocationVisitedTime = updateLocationVisitedTime ?? element.UpdateLocationVisitedTime;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HideMapObject"/>
    /// </summary>
    public static ActionsBuilder HideMapObject(
        this ActionsBuilder builder,
        MapObjectEvaluator? mapObject = null,
        bool? unhide = null)
    {
      var element = ElementTool.Create<HideMapObject>();
      builder.Validate(mapObject);
      element.MapObject = mapObject ?? element.MapObject;
      element.Unhide = unhide ?? element.Unhide;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="LocalMapSetDirty"/>
    /// </summary>
    public static ActionsBuilder LocalMapSetDirty(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<LocalMapSetDirty>());
    }

    /// <summary>
    /// Adds <see cref="MakeServiceCaster"/>
    /// </summary>
    public static ActionsBuilder MakeServiceCaster(
        this ActionsBuilder builder,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<MakeServiceCaster>();
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MarkLocationClosed"/>
    /// </summary>
    ///
    /// <param name="location">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder MarkLocationClosed(
        this ActionsBuilder builder,
        bool? closed = null,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>? location = null)
    {
      var element = ElementTool.Create<MarkLocationClosed>();
      element.Closed = closed ?? element.Closed;
      element.m_Location = location.Reference ?? element.m_Location;
      if (element.m_Location is null)
      {
        element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MarkLocationExplored"/>
    /// </summary>
    ///
    /// <param name="location">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder MarkLocationExplored(
        this ActionsBuilder builder,
        bool? explored = null,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>? location = null)
    {
      var element = ElementTool.Create<MarkLocationExplored>();
      element.Explored = explored ?? element.Explored;
      element.m_Location = location.Reference ?? element.m_Location;
      if (element.m_Location is null)
      {
        element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MarkOnLocalMap"/>
    /// </summary>
    public static ActionsBuilder MarkOnLocalMap(
        this ActionsBuilder builder,
        bool? hidden = null,
        MapObjectEvaluator? mapObject = null)
    {
      var element = ElementTool.Create<MarkOnLocalMap>();
      element.Hidden = hidden ?? element.Hidden;
      builder.Validate(mapObject);
      element.MapObject = mapObject ?? element.MapObject;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="OpenLootContainer"/>
    /// </summary>
    public static ActionsBuilder OpenLootContainer(
        this ActionsBuilder builder,
        MapObjectEvaluator? mapObject = null)
    {
      var element = ElementTool.Create<OpenLootContainer>();
      builder.Validate(mapObject);
      element.MapObject = mapObject ?? element.MapObject;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveAllAreasFromSave"/>
    /// </summary>
    ///
    /// <param name="except">
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RemoveAllAreasFromSave(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintArea, BlueprintAreaReference>>? except = null)
    {
      var element = ElementTool.Create<RemoveAllAreasFromSave>();
      element.m_Except = except.Select(bp => bp.Reference).ToArray() ?? element.m_Except;
      if (element.m_Except is null)
      {
        element.m_Except = new BlueprintAreaReference[0];
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveAmbush"/>
    /// </summary>
    public static ActionsBuilder RemoveAmbush(
        this ActionsBuilder builder,
        bool? exitStealth = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<RemoveAmbush>();
      element.m_ExitStealth = exitStealth ?? element.m_ExitStealth;
      builder.Validate(unit);
      element.m_Unit = unit ?? element.m_Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveCampingEncounter"/>
    /// </summary>
    ///
    /// <param name="encounter">
    /// Blueprint of type BlueprintCampingEncounter. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RemoveCampingEncounter(
        this ActionsBuilder builder,
        Blueprint<BlueprintCampingEncounter, BlueprintCampingEncounterReference>? encounter = null)
    {
      var element = ElementTool.Create<RemoveCampingEncounter>();
      element.m_Encounter = encounter.Reference ?? element.m_Encounter;
      if (element.m_Encounter is null)
      {
        element.m_Encounter = BlueprintTool.GetRef<BlueprintCampingEncounterReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ResetLocationPerceptionCheck"/>
    /// </summary>
    ///
    /// <param name="location">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ResetLocationPerceptionCheck(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>? location = null)
    {
      var element = ElementTool.Create<ResetLocationPerceptionCheck>();
      element.m_Location = location.Reference ?? element.m_Location;
      if (element.m_Location is null)
      {
        element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RevealGlobalMap"/>
    /// </summary>
    ///
    /// <param name="points">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RevealGlobalMap(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>>? points = null,
        bool? revealEdges = null)
    {
      var element = ElementTool.Create<RevealGlobalMap>();
      element.Points = points.Select(bp => bp.Reference).ToArray() ?? element.Points;
      if (element.Points is null)
      {
        element.Points = new BlueprintGlobalMapPoint.Reference[0];
      }
      element.RevealEdges = revealEdges ?? element.RevealEdges;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ScriptZoneActivate"/>
    /// </summary>
    public static ActionsBuilder ScriptZoneActivate(
        this ActionsBuilder builder,
        EntityReference? scriptZone = null)
    {
      var element = ElementTool.Create<ScriptZoneActivate>();
      builder.Validate(scriptZone);
      element.ScriptZone = scriptZone ?? element.ScriptZone;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ScriptZoneDeactivate"/>
    /// </summary>
    public static ActionsBuilder ScriptZoneDeactivate(
        this ActionsBuilder builder,
        EntityReference? scriptZone = null)
    {
      var element = ElementTool.Create<ScriptZoneDeactivate>();
      builder.Validate(scriptZone);
      element.ScriptZone = scriptZone ?? element.ScriptZone;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ScripZoneUnits"/>
    /// </summary>
    public static ActionsBuilder ScripZoneUnits(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null,
        EntityReference? scriptZone = null)
    {
      var element = ElementTool.Create<ScripZoneUnits>();
      element.Actions = actions.Build() ?? element.Actions;
      if (element.Actions is null)
      {
        element.Actions = Constants.Empty.Actions;
      }
      builder.Validate(scriptZone);
      element.ScriptZone = scriptZone ?? element.ScriptZone;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetDeviceState"/>
    /// </summary>
    public static ActionsBuilder SetDeviceState(
        this ActionsBuilder builder,
        MapObjectEvaluator? device = null,
        IntEvaluator? state = null)
    {
      var element = ElementTool.Create<SetDeviceState>();
      builder.Validate(device);
      element.Device = device ?? element.Device;
      builder.Validate(state);
      element.State = state ?? element.State;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetDeviceTrigger"/>
    /// </summary>
    public static ActionsBuilder SetDeviceTrigger(
        this ActionsBuilder builder,
        MapObjectEvaluator? device = null,
        string? trigger = null)
    {
      var element = ElementTool.Create<SetDeviceTrigger>();
      builder.Validate(device);
      element.Device = device ?? element.Device;
      element.Trigger = trigger ?? element.Trigger;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetDisableDevice"/>
    /// </summary>
    public static ActionsBuilder SetDisableDevice(
        this ActionsBuilder builder,
        MapObjectEvaluator? mapObject = null,
        int? overrideDC = null)
    {
      var element = ElementTool.Create<SetDisableDevice>();
      builder.Validate(mapObject);
      element.MapObject = mapObject ?? element.MapObject;
      element.OverrideDC = overrideDC ?? element.OverrideDC;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ShowMultiEntrance"/>
    /// </summary>
    ///
    /// <param name="map">
    /// Blueprint of type BlueprintMultiEntrance. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ShowMultiEntrance(
        this ActionsBuilder builder,
        Blueprint<BlueprintMultiEntrance, BlueprintMultiEntranceReference>? map = null)
    {
      var element = ElementTool.Create<ShowMultiEntrance>();
      element.m_Map = map.Reference ?? element.m_Map;
      if (element.m_Map is null)
      {
        element.m_Map = BlueprintTool.GetRef<BlueprintMultiEntranceReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SpotMapObject"/>
    /// </summary>
    public static ActionsBuilder SpotMapObject(
        this ActionsBuilder builder,
        UnitEvaluator? spotter = null,
        MapObjectEvaluator? target = null)
    {
      var element = ElementTool.Create<SpotMapObject>();
      builder.Validate(spotter);
      element.Spotter = spotter ?? element.Spotter;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SpotUnit"/>
    /// </summary>
    public static ActionsBuilder SpotUnit(
        this ActionsBuilder builder,
        UnitEvaluator? spotter = null,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<SpotUnit>();
      builder.Validate(spotter);
      element.Spotter = spotter ?? element.Spotter;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="TeleportParty"/>
    /// </summary>
    ///
    /// <param name="exitPositon">
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder TeleportParty(
        this ActionsBuilder builder,
        ActionsBuilder? afterTeleport = null,
        AutoSaveMode? autoSaveMode = null,
        Blueprint<BlueprintAreaEnterPoint, BlueprintAreaEnterPointReference>? exitPositon = null,
        bool? forcePauseAfterTeleport = null)
    {
      var element = ElementTool.Create<TeleportParty>();
      element.AfterTeleport = afterTeleport.Build() ?? element.AfterTeleport;
      if (element.AfterTeleport is null)
      {
        element.AfterTeleport = Constants.Empty.Actions;
      }
      element.AutoSaveMode = autoSaveMode ?? element.AutoSaveMode;
      element.m_exitPositon = exitPositon.Reference ?? element.m_exitPositon;
      if (element.m_exitPositon is null)
      {
        element.m_exitPositon = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(null);
      }
      element.ForcePauseAfterTeleport = forcePauseAfterTeleport ?? element.ForcePauseAfterTeleport;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="TranslocatePlayer"/>
    /// </summary>
    public static ActionsBuilder TranslocatePlayer(
        this ActionsBuilder builder,
        bool? byFormationAndWithPets = null,
        bool? scrollCameraToPlayer = null,
        EntityReference? transolcatePosition = null)
    {
      var element = ElementTool.Create<TranslocatePlayer>();
      element.ByFormationAndWithPets = byFormationAndWithPets ?? element.ByFormationAndWithPets;
      element.ScrollCameraToPlayer = scrollCameraToPlayer ?? element.ScrollCameraToPlayer;
      builder.Validate(transolcatePosition);
      element.transolcatePosition = transolcatePosition ?? element.transolcatePosition;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="TranslocateUnit"/>
    /// </summary>
    public static ActionsBuilder TranslocateUnit(
        this ActionsBuilder builder,
        bool? copyRotation = null,
        FloatEvaluator? translocateOrientationEvaluator = null,
        EntityReference? translocatePosition = null,
        PositionEvaluator? translocatePositionEvaluator = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<TranslocateUnit>();
      element.m_CopyRotation = copyRotation ?? element.m_CopyRotation;
      builder.Validate(translocateOrientationEvaluator);
      element.translocateOrientationEvaluator = translocateOrientationEvaluator ?? element.translocateOrientationEvaluator;
      builder.Validate(translocatePosition);
      element.translocatePosition = translocatePosition ?? element.translocatePosition;
      builder.Validate(translocatePositionEvaluator);
      element.translocatePositionEvaluator = translocatePositionEvaluator ?? element.translocatePositionEvaluator;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="TrapCastSpell"/>
    /// </summary>
    ///
    /// <param name="spell">
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder TrapCastSpell(
        this ActionsBuilder builder,
        PositionEvaluator? actorPosition = null,
        int? dC = null,
        bool? disableBattleLog = null,
        bool? overrideDC = null,
        bool? overrideSpellLevel = null,
        Blueprint<BlueprintAbility, BlueprintAbilityReference>? spell = null,
        int? spellLevel = null,
        PositionEvaluator? targetPoint = null,
        MapObjectEvaluator? trapObject = null,
        UnitEvaluator? triggeringUnit = null)
    {
      var element = ElementTool.Create<TrapCastSpell>();
      builder.Validate(actorPosition);
      element.ActorPosition = actorPosition ?? element.ActorPosition;
      element.DC = dC ?? element.DC;
      element.DisableBattleLog = disableBattleLog ?? element.DisableBattleLog;
      element.OverrideDC = overrideDC ?? element.OverrideDC;
      element.OverrideSpellLevel = overrideSpellLevel ?? element.OverrideSpellLevel;
      element.m_Spell = spell.Reference ?? element.m_Spell;
      if (element.m_Spell is null)
      {
        element.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      element.SpellLevel = spellLevel ?? element.SpellLevel;
      builder.Validate(targetPoint);
      element.TargetPoint = targetPoint ?? element.TargetPoint;
      builder.Validate(trapObject);
      element.TrapObject = trapObject ?? element.TrapObject;
      builder.Validate(triggeringUnit);
      element.TriggeringUnit = triggeringUnit ?? element.TriggeringUnit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnlockCookingRecipe"/>
    /// </summary>
    ///
    /// <param name="recipe">
    /// Blueprint of type BlueprintCookingRecipe. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder UnlockCookingRecipe(
        this ActionsBuilder builder,
        Blueprint<BlueprintCookingRecipe, BlueprintCookingRecipeReference>? recipe = null)
    {
      var element = ElementTool.Create<UnlockCookingRecipe>();
      element.m_Recipe = recipe.Reference ?? element.m_Recipe;
      if (element.m_Recipe is null)
      {
        element.m_Recipe = BlueprintTool.GetRef<BlueprintCookingRecipeReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnlockLocation"/>
    /// </summary>
    ///
    /// <param name="location">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder UnlockLocation(
        this ActionsBuilder builder,
        bool? fakeDescription = null,
        bool? hideInstead = null,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>? location = null)
    {
      var element = ElementTool.Create<UnlockLocation>();
      element.FakeDescription = fakeDescription ?? element.FakeDescription;
      element.HideInstead = hideInstead ?? element.HideInstead;
      element.m_Location = location.Reference ?? element.m_Location;
      if (element.m_Location is null)
      {
        element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnlockMapEdge"/>
    /// </summary>
    ///
    /// <param name="edge">
    /// Blueprint of type BlueprintGlobalMapEdge. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder UnlockMapEdge(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMapEdge, BlueprintGlobalMapEdge.Reference>? edge = null,
        bool? openEdges = null)
    {
      var element = ElementTool.Create<UnlockMapEdge>();
      element.m_Edge = edge.Reference ?? element.m_Edge;
      if (element.m_Edge is null)
      {
        element.m_Edge = BlueprintTool.GetRef<BlueprintGlobalMapEdge.Reference>(null);
      }
      element.OpenEdges = openEdges ?? element.OpenEdges;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ActionCreateImportedCompanion"/>
    /// </summary>
    public static ActionsBuilder CreateImportedCompanion(
        this ActionsBuilder builder,
        int index)
    {
      var element = ElementTool.Create<ActionCreateImportedCompanion>();
      element.Index = index;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ActionEnterToDungeon"/>
    /// </summary>
    public static ActionsBuilder EnterToDungeon(
        this ActionsBuilder builder,
        int? firstStage = null)
    {
      var element = ElementTool.Create<ActionEnterToDungeon>();
      element.FirstStage = firstStage ?? element.FirstStage;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ActionGoDeeperIntoDungeon"/>
    /// </summary>
    public static ActionsBuilder GoDeeperIntoDungeon(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ActionGoDeeperIntoDungeon>());
    }

    /// <summary>
    /// Adds <see cref="ActionIncreaseDungeonStage"/>
    /// </summary>
    public static ActionsBuilder IncreaseDungeonStage(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ActionIncreaseDungeonStage>());
    }

    /// <summary>
    /// Adds <see cref="ActionSetDungeonStage"/>
    /// </summary>
    public static ActionsBuilder SetDungeonStage(
        this ActionsBuilder builder,
        int? stage = null)
    {
      var element = ElementTool.Create<ActionSetDungeonStage>();
      element.Stage = stage ?? element.Stage;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GameActionSetIsleLock"/>
    /// </summary>
    public static ActionsBuilder GameActionSetIsleLock(
        this ActionsBuilder builder,
        IsleEvaluator? isle = null,
        bool? isLock = null)
    {
      var element = ElementTool.Create<GameActionSetIsleLock>();
      builder.Validate(isle);
      element.m_Isle = isle ?? element.m_Isle;
      element.m_IsLock = isLock ?? element.m_IsLock;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GameActionSetIsleState"/>
    /// </summary>
    public static ActionsBuilder GameActionSetIsleState(
        this ActionsBuilder builder,
        IsleEvaluator? isle = null,
        string? stateName = null)
    {
      var element = ElementTool.Create<GameActionSetIsleState>();
      builder.Validate(isle);
      element.m_Isle = isle ?? element.m_Isle;
      element.m_StateName = stateName ?? element.m_StateName;
      return builder.Add(element);
    }
  }
}
