//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintTacticalCombatObstaclesMap"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTacticalCombatObstaclesMapConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintTacticalCombatObstaclesMap
    where TBuilder : BaseTacticalCombatObstaclesMapConfigurator<T, TBuilder>
  {
    protected BaseTacticalCombatObstaclesMapConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatObstaclesMap.Obstacles"/>
    /// </summary>
    public TBuilder SetObstacles(params BlueprintTacticalCombatObstaclesMap.MapObstacle[] obstacles)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in obstacles) { Validate(item); }
          bp.Obstacles = obstacles;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintTacticalCombatObstaclesMap.Obstacles"/>
    /// </summary>
    public TBuilder AddToObstacles(params BlueprintTacticalCombatObstaclesMap.MapObstacle[] obstacles)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Obstacles = bp.Obstacles ?? new BlueprintTacticalCombatObstaclesMap.MapObstacle[0];
          bp.Obstacles = CommonTool.Append(bp.Obstacles, obstacles);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintTacticalCombatObstaclesMap.Obstacles"/>
    /// </summary>
    public TBuilder RemoveFromObstacles(params BlueprintTacticalCombatObstaclesMap.MapObstacle[] obstacles)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Obstacles is null) { return; }
          bp.Obstacles = bp.Obstacles.Where(val => !obstacles.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintTacticalCombatObstaclesMap.Obstacles"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromObstacles(Func<BlueprintTacticalCombatObstaclesMap.MapObstacle, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Obstacles is null) { return; }
          bp.Obstacles = bp.Obstacles.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintTacticalCombatObstaclesMap.Obstacles"/>
    /// </summary>
    public TBuilder ClearObstacles()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Obstacles = new BlueprintTacticalCombatObstaclesMap.MapObstacle[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatObstaclesMap.Obstacles"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyObstacles(Action<BlueprintTacticalCombatObstaclesMap.MapObstacle> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Obstacles is null) { return; }
          bp.Obstacles.ForEach(action);
        });
    }
  }
}
