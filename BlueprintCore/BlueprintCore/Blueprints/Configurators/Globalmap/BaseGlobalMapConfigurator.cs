//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Utility;
using System;
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
    }
  }
}
