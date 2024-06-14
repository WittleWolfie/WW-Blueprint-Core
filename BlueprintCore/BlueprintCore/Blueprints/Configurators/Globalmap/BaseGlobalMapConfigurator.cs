//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.ElementsSystem;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.ResourceLinks;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintGlobalMap"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseGlobalMapConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintGlobalMap
    where TBuilder : BaseGlobalMapConfigurator<T, TBuilder>
  {
    protected BaseGlobalMapConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintGlobalMap>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_StartLocation = copyFrom.m_StartLocation;
          bp.m_GlobalMapEnterPoint = copyFrom.m_GlobalMapEnterPoint;
          bp.m_RegionsMask = copyFrom.m_RegionsMask;
          bp.VisualSpeedBase = copyFrom.VisualSpeedBase;
          bp.MechanicsSpeedBase = copyFrom.MechanicsSpeedBase;
          bp.ArmySpeedFactor = copyFrom.ArmySpeedFactor;
          bp.ArmyGoToPointSpeedMultiplier = copyFrom.ArmyGoToPointSpeedMultiplier;
          bp.PartySpeedFactor = copyFrom.PartySpeedFactor;
          bp.RandomEncounterTimer = copyFrom.RandomEncounterTimer;
          bp.ExploreDistance = copyFrom.ExploreDistance;
          bp.RestrictTravelingToClosedLocations = copyFrom.RestrictTravelingToClosedLocations;
          bp.Points = copyFrom.Points;
          bp.Edges = copyFrom.Edges;
          bp.EnterWarCampAction = copyFrom.EnterWarCampAction;
          bp.EnterAzataIslandAction = copyFrom.EnterAzataIslandAction;
          bp.IsKenabres = copyFrom.IsKenabres;
          bp.CampLocation = copyFrom.CampLocation;
          bp.PlayerArmyPawnPrefab = copyFrom.PlayerArmyPawnPrefab;
          bp.OrdinaryDemonsArmyPawnPrefab = copyFrom.OrdinaryDemonsArmyPawnPrefab;
          bp.SpecialDemonsArmyPawnPrefab = copyFrom.SpecialDemonsArmyPawnPrefab;
          bp.TravellingDemonsArmyPawnPrefab = copyFrom.TravellingDemonsArmyPawnPrefab;
          bp.GarrisonPrefab = copyFrom.GarrisonPrefab;
          bp.ExploredLocationVisual = copyFrom.ExploredLocationVisual;
          bp.UnexploredLocationVisual = copyFrom.UnexploredLocationVisual;
          bp.LineTemplate = copyFrom.LineTemplate;
          bp.ClaimedResourceVisual = copyFrom.ClaimedResourceVisual;
          bp.WaypointVisual = copyFrom.WaypointVisual;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintGlobalMap>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_StartLocation = copyFrom.m_StartLocation;
          bp.m_GlobalMapEnterPoint = copyFrom.m_GlobalMapEnterPoint;
          bp.m_RegionsMask = copyFrom.m_RegionsMask;
          bp.VisualSpeedBase = copyFrom.VisualSpeedBase;
          bp.MechanicsSpeedBase = copyFrom.MechanicsSpeedBase;
          bp.ArmySpeedFactor = copyFrom.ArmySpeedFactor;
          bp.ArmyGoToPointSpeedMultiplier = copyFrom.ArmyGoToPointSpeedMultiplier;
          bp.PartySpeedFactor = copyFrom.PartySpeedFactor;
          bp.RandomEncounterTimer = copyFrom.RandomEncounterTimer;
          bp.ExploreDistance = copyFrom.ExploreDistance;
          bp.RestrictTravelingToClosedLocations = copyFrom.RestrictTravelingToClosedLocations;
          bp.Points = copyFrom.Points;
          bp.Edges = copyFrom.Edges;
          bp.EnterWarCampAction = copyFrom.EnterWarCampAction;
          bp.EnterAzataIslandAction = copyFrom.EnterAzataIslandAction;
          bp.IsKenabres = copyFrom.IsKenabres;
          bp.CampLocation = copyFrom.CampLocation;
          bp.PlayerArmyPawnPrefab = copyFrom.PlayerArmyPawnPrefab;
          bp.OrdinaryDemonsArmyPawnPrefab = copyFrom.OrdinaryDemonsArmyPawnPrefab;
          bp.SpecialDemonsArmyPawnPrefab = copyFrom.SpecialDemonsArmyPawnPrefab;
          bp.TravellingDemonsArmyPawnPrefab = copyFrom.TravellingDemonsArmyPawnPrefab;
          bp.GarrisonPrefab = copyFrom.GarrisonPrefab;
          bp.ExploredLocationVisual = copyFrom.ExploredLocationVisual;
          bp.UnexploredLocationVisual = copyFrom.UnexploredLocationVisual;
          bp.LineTemplate = copyFrom.LineTemplate;
          bp.ClaimedResourceVisual = copyFrom.ClaimedResourceVisual;
          bp.WaypointVisual = copyFrom.WaypointVisual;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.m_StartLocation"/>
    /// </summary>
    ///
    /// <param name="startLocation">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetStartLocation(Blueprint<BlueprintGlobalMapPoint.Reference> startLocation)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StartLocation = startLocation?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMap.m_StartLocation"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyStartLocation(Action<BlueprintGlobalMapPoint.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_StartLocation is null) { return; }
          action.Invoke(bp.m_StartLocation);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.m_GlobalMapEnterPoint"/>
    /// </summary>
    ///
    /// <param name="globalMapEnterPoint">
    /// <para>
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetGlobalMapEnterPoint(Blueprint<BlueprintAreaEnterPointReference> globalMapEnterPoint)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_GlobalMapEnterPoint = globalMapEnterPoint?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMap.m_GlobalMapEnterPoint"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyGlobalMapEnterPoint(Action<BlueprintAreaEnterPointReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_GlobalMapEnterPoint is null) { return; }
          action.Invoke(bp.m_GlobalMapEnterPoint);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.m_RegionsMask"/>
    /// </summary>
    public TBuilder SetRegionsMask(RegionsMask regionsMask)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(regionsMask);
          bp.m_RegionsMask = regionsMask;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMap.m_RegionsMask"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRegionsMask(Action<RegionsMask> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_RegionsMask is null) { return; }
          action.Invoke(bp.m_RegionsMask);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.VisualSpeedBase"/>
    /// </summary>
    ///
    /// <param name="visualSpeedBase">
    /// <para>
    /// Tooltip: Miles per second
    /// </para>
    /// </param>
    public TBuilder SetVisualSpeedBase(float visualSpeedBase)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.VisualSpeedBase = visualSpeedBase;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.MechanicsSpeedBase"/>
    /// </summary>
    ///
    /// <param name="mechanicsSpeedBase">
    /// <para>
    /// Tooltip: Miles per hour
    /// </para>
    /// </param>
    public TBuilder SetMechanicsSpeedBase(float mechanicsSpeedBase)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MechanicsSpeedBase = mechanicsSpeedBase;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.ArmySpeedFactor"/>
    /// </summary>
    public TBuilder SetArmySpeedFactor(float armySpeedFactor)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ArmySpeedFactor = armySpeedFactor;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.ArmyGoToPointSpeedMultiplier"/>
    /// </summary>
    public TBuilder SetArmyGoToPointSpeedMultiplier(float armyGoToPointSpeedMultiplier)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ArmyGoToPointSpeedMultiplier = armyGoToPointSpeedMultiplier;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.PartySpeedFactor"/>
    /// </summary>
    public TBuilder SetPartySpeedFactor(float partySpeedFactor)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PartySpeedFactor = partySpeedFactor;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.RandomEncounterTimer"/>
    /// </summary>
    ///
    /// <param name="randomEncounterTimer">
    /// <para>
    /// Tooltip: Interface animation duration for starting random encounter. Seconds.
    /// </para>
    /// </param>
    public TBuilder SetRandomEncounterTimer(float randomEncounterTimer)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RandomEncounterTimer = randomEncounterTimer;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.ExploreDistance"/>
    /// </summary>
    ///
    /// <param name="exploreDistance">
    /// <para>
    /// Tooltip: How long path does pawn see from its position
    /// </para>
    /// </param>
    public TBuilder SetExploreDistance(float exploreDistance)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ExploreDistance = exploreDistance;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.RestrictTravelingToClosedLocations"/>
    /// </summary>
    public TBuilder SetRestrictTravelingToClosedLocations(bool restrictTravelingToClosedLocations = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RestrictTravelingToClosedLocations = restrictTravelingToClosedLocations;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.Points"/>
    /// </summary>
    ///
    /// <param name="points">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetPoints(params Blueprint<BlueprintGlobalMapPoint.Reference>[] points)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Points = points.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintGlobalMap.Points"/>
    /// </summary>
    ///
    /// <param name="points">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToPoints(params Blueprint<BlueprintGlobalMapPoint.Reference>[] points)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Points = bp.Points ?? new BlueprintGlobalMapPoint.Reference[0];
          bp.Points = CommonTool.Append(bp.Points, points.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintGlobalMap.Points"/>
    /// </summary>
    ///
    /// <param name="points">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromPoints(params Blueprint<BlueprintGlobalMapPoint.Reference>[] points)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Points is null) { return; }
          bp.Points = bp.Points.Where(val => !points.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintGlobalMap.Points"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromPoints(Func<BlueprintGlobalMapPoint.Reference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Points is null) { return; }
          bp.Points = bp.Points.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintGlobalMap.Points"/>
    /// </summary>
    public TBuilder ClearPoints()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Points = new BlueprintGlobalMapPoint.Reference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMap.Points"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyPoints(Action<BlueprintGlobalMapPoint.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Points is null) { return; }
          bp.Points.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.Edges"/>
    /// </summary>
    ///
    /// <param name="edges">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapEdge. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetEdges(params Blueprint<BlueprintGlobalMapEdge.Reference>[] edges)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Edges = edges.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintGlobalMap.Edges"/>
    /// </summary>
    ///
    /// <param name="edges">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapEdge. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToEdges(params Blueprint<BlueprintGlobalMapEdge.Reference>[] edges)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Edges = bp.Edges ?? new();
          bp.Edges.AddRange(edges.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintGlobalMap.Edges"/>
    /// </summary>
    ///
    /// <param name="edges">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapEdge. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromEdges(params Blueprint<BlueprintGlobalMapEdge.Reference>[] edges)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Edges is null) { return; }
          bp.Edges = bp.Edges.Where(val => !edges.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintGlobalMap.Edges"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromEdges(Func<BlueprintGlobalMapEdge.Reference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Edges is null) { return; }
          bp.Edges = bp.Edges.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintGlobalMap.Edges"/>
    /// </summary>
    public TBuilder ClearEdges()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Edges = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMap.Edges"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyEdges(Action<BlueprintGlobalMapEdge.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Edges is null) { return; }
          bp.Edges.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.EnterWarCampAction"/>
    /// </summary>
    public TBuilder SetEnterWarCampAction(ActionsBuilder enterWarCampAction)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.EnterWarCampAction = enterWarCampAction?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMap.EnterWarCampAction"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyEnterWarCampAction(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.EnterWarCampAction is null) { return; }
          action.Invoke(bp.EnterWarCampAction);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.EnterAzataIslandAction"/>
    /// </summary>
    public TBuilder SetEnterAzataIslandAction(ActionsBuilder enterAzataIslandAction)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.EnterAzataIslandAction = enterAzataIslandAction?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMap.EnterAzataIslandAction"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyEnterAzataIslandAction(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.EnterAzataIslandAction is null) { return; }
          action.Invoke(bp.EnterAzataIslandAction);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.IsKenabres"/>
    /// </summary>
    public TBuilder SetIsKenabres(bool isKenabres = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsKenabres = isKenabres;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.CampLocation"/>
    /// </summary>
    ///
    /// <param name="campLocation">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetCampLocation(Blueprint<BlueprintGlobalMapPoint.Reference> campLocation)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CampLocation = campLocation?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMap.CampLocation"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCampLocation(Action<BlueprintGlobalMapPoint.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CampLocation is null) { return; }
          action.Invoke(bp.CampLocation);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.PlayerArmyPawnPrefab"/>
    /// </summary>
    ///
    /// <param name="playerArmyPawnPrefab">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetPlayerArmyPawnPrefab(AssetLink<PrefabLink> playerArmyPawnPrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PlayerArmyPawnPrefab = playerArmyPawnPrefab?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMap.PlayerArmyPawnPrefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPlayerArmyPawnPrefab(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.PlayerArmyPawnPrefab is null) { return; }
          action.Invoke(bp.PlayerArmyPawnPrefab);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.OrdinaryDemonsArmyPawnPrefab"/>
    /// </summary>
    ///
    /// <param name="ordinaryDemonsArmyPawnPrefab">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetOrdinaryDemonsArmyPawnPrefab(AssetLink<PrefabLink> ordinaryDemonsArmyPawnPrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OrdinaryDemonsArmyPawnPrefab = ordinaryDemonsArmyPawnPrefab?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMap.OrdinaryDemonsArmyPawnPrefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOrdinaryDemonsArmyPawnPrefab(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OrdinaryDemonsArmyPawnPrefab is null) { return; }
          action.Invoke(bp.OrdinaryDemonsArmyPawnPrefab);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.SpecialDemonsArmyPawnPrefab"/>
    /// </summary>
    ///
    /// <param name="specialDemonsArmyPawnPrefab">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetSpecialDemonsArmyPawnPrefab(AssetLink<PrefabLink> specialDemonsArmyPawnPrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SpecialDemonsArmyPawnPrefab = specialDemonsArmyPawnPrefab?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMap.SpecialDemonsArmyPawnPrefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpecialDemonsArmyPawnPrefab(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SpecialDemonsArmyPawnPrefab is null) { return; }
          action.Invoke(bp.SpecialDemonsArmyPawnPrefab);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.TravellingDemonsArmyPawnPrefab"/>
    /// </summary>
    ///
    /// <param name="travellingDemonsArmyPawnPrefab">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetTravellingDemonsArmyPawnPrefab(AssetLink<PrefabLink> travellingDemonsArmyPawnPrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TravellingDemonsArmyPawnPrefab = travellingDemonsArmyPawnPrefab?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMap.TravellingDemonsArmyPawnPrefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTravellingDemonsArmyPawnPrefab(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.TravellingDemonsArmyPawnPrefab is null) { return; }
          action.Invoke(bp.TravellingDemonsArmyPawnPrefab);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.GarrisonPrefab"/>
    /// </summary>
    ///
    /// <param name="garrisonPrefab">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetGarrisonPrefab(AssetLink<PrefabLink> garrisonPrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.GarrisonPrefab = garrisonPrefab?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMap.GarrisonPrefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyGarrisonPrefab(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.GarrisonPrefab is null) { return; }
          action.Invoke(bp.GarrisonPrefab);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.ExploredLocationVisual"/>
    /// </summary>
    ///
    /// <param name="exploredLocationVisual">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetExploredLocationVisual(AssetLink<PrefabLink> exploredLocationVisual)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ExploredLocationVisual = exploredLocationVisual?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMap.ExploredLocationVisual"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyExploredLocationVisual(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ExploredLocationVisual is null) { return; }
          action.Invoke(bp.ExploredLocationVisual);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.UnexploredLocationVisual"/>
    /// </summary>
    ///
    /// <param name="unexploredLocationVisual">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetUnexploredLocationVisual(AssetLink<PrefabLink> unexploredLocationVisual)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UnexploredLocationVisual = unexploredLocationVisual?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMap.UnexploredLocationVisual"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUnexploredLocationVisual(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UnexploredLocationVisual is null) { return; }
          action.Invoke(bp.UnexploredLocationVisual);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.LineTemplate"/>
    /// </summary>
    ///
    /// <param name="lineTemplate">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetLineTemplate(AssetLink<PrefabLink> lineTemplate)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LineTemplate = lineTemplate?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMap.LineTemplate"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLineTemplate(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LineTemplate is null) { return; }
          action.Invoke(bp.LineTemplate);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.ClaimedResourceVisual"/>
    /// </summary>
    ///
    /// <param name="claimedResourceVisual">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetClaimedResourceVisual(AssetLink<PrefabLink> claimedResourceVisual)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ClaimedResourceVisual = claimedResourceVisual?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMap.ClaimedResourceVisual"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyClaimedResourceVisual(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ClaimedResourceVisual is null) { return; }
          action.Invoke(bp.ClaimedResourceVisual);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMap.WaypointVisual"/>
    /// </summary>
    ///
    /// <param name="waypointVisual">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetWaypointVisual(AssetLink<PrefabLink> waypointVisual)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.WaypointVisual = waypointVisual?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMap.WaypointVisual"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyWaypointVisual(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.WaypointVisual is null) { return; }
          action.Invoke(bp.WaypointVisual);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_StartLocation is null)
      {
        Blueprint.m_StartLocation = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      if (Blueprint.m_GlobalMapEnterPoint is null)
      {
        Blueprint.m_GlobalMapEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(null);
      }
      if (Blueprint.Points is null)
      {
        Blueprint.Points = new BlueprintGlobalMapPoint.Reference[0];
      }
      if (Blueprint.Edges is null)
      {
        Blueprint.Edges = new();
      }
      if (Blueprint.EnterWarCampAction is null)
      {
        Blueprint.EnterWarCampAction = Utils.Constants.Empty.Actions;
      }
      if (Blueprint.EnterAzataIslandAction is null)
      {
        Blueprint.EnterAzataIslandAction = Utils.Constants.Empty.Actions;
      }
      if (Blueprint.CampLocation is null)
      {
        Blueprint.CampLocation = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      if (Blueprint.PlayerArmyPawnPrefab is null)
      {
        Blueprint.PlayerArmyPawnPrefab = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.OrdinaryDemonsArmyPawnPrefab is null)
      {
        Blueprint.OrdinaryDemonsArmyPawnPrefab = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.SpecialDemonsArmyPawnPrefab is null)
      {
        Blueprint.SpecialDemonsArmyPawnPrefab = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.TravellingDemonsArmyPawnPrefab is null)
      {
        Blueprint.TravellingDemonsArmyPawnPrefab = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.GarrisonPrefab is null)
      {
        Blueprint.GarrisonPrefab = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.ExploredLocationVisual is null)
      {
        Blueprint.ExploredLocationVisual = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.UnexploredLocationVisual is null)
      {
        Blueprint.UnexploredLocationVisual = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.LineTemplate is null)
      {
        Blueprint.LineTemplate = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.ClaimedResourceVisual is null)
      {
        Blueprint.ClaimedResourceVisual = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.WaypointVisual is null)
      {
        Blueprint.WaypointVisual = Utils.Constants.Empty.PrefabLink;
      }
    }
  }
}
