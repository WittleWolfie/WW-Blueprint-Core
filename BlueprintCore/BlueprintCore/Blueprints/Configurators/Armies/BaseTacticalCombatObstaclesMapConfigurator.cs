//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
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
    protected BaseTacticalCombatObstaclesMapConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintTacticalCombatObstaclesMap>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Obstacles = copyFrom.Obstacles;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintTacticalCombatObstaclesMap>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Obstacles = copyFrom.Obstacles;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatObstaclesMap.Obstacles"/>
    /// </summary>
    public TBuilder SetObstacles(params BlueprintTacticalCombatObstaclesMap.MapObstacle[] obstacles)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(obstacles);
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
          bp.Obstacles = bp.Obstacles.Where(e => !predicate(e)).ToArray();
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

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Obstacles is null)
      {
        Blueprint.Obstacles = new BlueprintTacticalCombatObstaclesMap.MapObstacle[0];
      }
    }
  }
}
