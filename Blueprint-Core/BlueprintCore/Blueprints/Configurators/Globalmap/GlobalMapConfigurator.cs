using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom.Blueprints;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>Configurator for <see cref="BlueprintGlobalMap"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintGlobalMap))]
  public class GlobalMapConfigurator : BaseBlueprintConfigurator<BlueprintGlobalMap, GlobalMapConfigurator>
  {
     private GlobalMapConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static GlobalMapConfigurator For(string name)
    {
      return new GlobalMapConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static GlobalMapConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintGlobalMap>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static GlobalMapConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintGlobalMap>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.m_StartLocation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintGlobalMapPoint"/></param>
    [Generated]
    public GlobalMapConfigurator SetStartLocation(string value)
    {
      return OnConfigureInternal(bp => bp.m_StartLocation = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.m_GlobalMapEnterPoint"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintAreaEnterPoint"/></param>
    [Generated]
    public GlobalMapConfigurator SetGlobalMapEnterPoint(string value)
    {
      return OnConfigureInternal(bp => bp.m_GlobalMapEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.m_RegionsMask"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapConfigurator SetRegionsMask(RegionsMask value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_RegionsMask = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.VisualSpeedBase"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapConfigurator SetVisualSpeedBase(float value)
    {
      return OnConfigureInternal(bp => bp.VisualSpeedBase = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.MechanicsSpeedBase"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapConfigurator SetMechanicsSpeedBase(float value)
    {
      return OnConfigureInternal(bp => bp.MechanicsSpeedBase = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.ArmySpeedFactor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapConfigurator SetArmySpeedFactor(float value)
    {
      return OnConfigureInternal(bp => bp.ArmySpeedFactor = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.ArmyGoToPointSpeedMultiplier"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapConfigurator SetArmyGoToPointSpeedMultiplier(float value)
    {
      return OnConfigureInternal(bp => bp.ArmyGoToPointSpeedMultiplier = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.RandomEncounterTimer"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapConfigurator SetRandomEncounterTimer(float value)
    {
      return OnConfigureInternal(bp => bp.RandomEncounterTimer = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.ExploreDistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapConfigurator SetExploreDistance(float value)
    {
      return OnConfigureInternal(bp => bp.ExploreDistance = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.RestrictTravelingToClosedLocations"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapConfigurator SetRestrictTravelingToClosedLocations(bool value)
    {
      return OnConfigureInternal(bp => bp.RestrictTravelingToClosedLocations = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMap.Points"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintGlobalMapPoint"/></param>
    [Generated]
    public GlobalMapConfigurator AddToPoints(params string[] values)
    {
      return OnConfigureInternal(bp => bp.Points = CommonTool.Append(bp.Points, values.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMap.Points"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintGlobalMapPoint"/></param>
    [Generated]
    public GlobalMapConfigurator RemoveFromPoints(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(name));
            bp.Points =
                bp.Points
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMap.Edges"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintGlobalMapEdge"/></param>
    [Generated]
    public GlobalMapConfigurator AddToEdges(params string[] values)
    {
      return OnConfigureInternal(bp => bp.Edges.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapEdge.Reference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMap.Edges"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintGlobalMapEdge"/></param>
    [Generated]
    public GlobalMapConfigurator RemoveFromEdges(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapEdge.Reference>(name));
            bp.Edges =
                bp.Edges
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.EnterWarCampAction"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapConfigurator SetEnterWarCampAction(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.EnterWarCampAction = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.EnterAzataIslandAction"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapConfigurator SetEnterAzataIslandAction(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.EnterAzataIslandAction = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.IsKenabres"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapConfigurator SetIsKenabres(bool value)
    {
      return OnConfigureInternal(bp => bp.IsKenabres = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.CampLocation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintGlobalMapPoint"/></param>
    [Generated]
    public GlobalMapConfigurator SetCampLocation(string value)
    {
      return OnConfigureInternal(bp => bp.CampLocation = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(value));
    }
  }
}
