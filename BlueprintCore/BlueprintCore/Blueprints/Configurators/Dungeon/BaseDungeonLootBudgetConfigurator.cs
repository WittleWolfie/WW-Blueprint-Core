//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDungeonLootBudget"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDungeonLootBudgetConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintDungeonLootBudget
    where TBuilder : BaseDungeonLootBudgetConfigurator<T, TBuilder>
  {
    protected BaseDungeonLootBudgetConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintDungeonLootBudget>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.CrToLootCost = copyFrom.CrToLootCost;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintDungeonLootBudget>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.CrToLootCost = copyFrom.CrToLootCost;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonLootBudget.CrToLootCost"/>
    /// </summary>
    ///
    /// <param name="crToLootCost">
    /// <para>
    /// Tooltip: Minimal item cost dependecy from the stage CR.
    /// </para>
    /// </param>
    public TBuilder SetCrToLootCost(params int[] crToLootCost)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CrToLootCost = crToLootCost;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonLootBudget.CrToLootCost"/>
    /// </summary>
    ///
    /// <param name="crToLootCost">
    /// <para>
    /// Tooltip: Minimal item cost dependecy from the stage CR.
    /// </para>
    /// </param>
    public TBuilder AddToCrToLootCost(params int[] crToLootCost)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CrToLootCost = bp.CrToLootCost ?? new int[0];
          bp.CrToLootCost = CommonTool.Append(bp.CrToLootCost, crToLootCost);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonLootBudget.CrToLootCost"/>
    /// </summary>
    ///
    /// <param name="crToLootCost">
    /// <para>
    /// Tooltip: Minimal item cost dependecy from the stage CR.
    /// </para>
    /// </param>
    public TBuilder RemoveFromCrToLootCost(params int[] crToLootCost)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CrToLootCost is null) { return; }
          bp.CrToLootCost = bp.CrToLootCost.Where(val => !crToLootCost.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonLootBudget.CrToLootCost"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCrToLootCost(Func<int, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CrToLootCost is null) { return; }
          bp.CrToLootCost = bp.CrToLootCost.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonLootBudget.CrToLootCost"/>
    /// </summary>
    public TBuilder ClearCrToLootCost()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CrToLootCost = new int[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonLootBudget.CrToLootCost"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCrToLootCost(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CrToLootCost is null) { return; }
          bp.CrToLootCost.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.CrToLootCost is null)
      {
        Blueprint.CrToLootCost = new int[0];
      }
    }
  }
}
