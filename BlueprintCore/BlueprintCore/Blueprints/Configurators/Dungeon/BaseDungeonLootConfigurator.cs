//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDungeonLoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDungeonLootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintDungeonLoot
    where TBuilder : BaseDungeonLootConfigurator<T, TBuilder>
  {
    protected BaseDungeonLootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonLoot.m_Items"/>
    /// </summary>
    ///
    /// <param name="items">
    /// <para>
    /// Tooltip: Include all the items specific to this loot blueprints.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetItems(params Blueprint<BlueprintItemReference>[] items)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Items = items.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonLoot.m_Items"/>
    /// </summary>
    ///
    /// <param name="items">
    /// <para>
    /// Tooltip: Include all the items specific to this loot blueprints.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToItems(params Blueprint<BlueprintItemReference>[] items)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Items = bp.m_Items ?? new BlueprintItemReference[0];
          bp.m_Items = CommonTool.Append(bp.m_Items, items.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonLoot.m_Items"/>
    /// </summary>
    ///
    /// <param name="items">
    /// <para>
    /// Tooltip: Include all the items specific to this loot blueprints.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromItems(params Blueprint<BlueprintItemReference>[] items)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Items is null) { return; }
          bp.m_Items = bp.m_Items.Where(val => !items.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonLoot.m_Items"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromItems(Func<BlueprintItemReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Items is null) { return; }
          bp.m_Items = bp.m_Items.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonLoot.m_Items"/>
    /// </summary>
    public TBuilder ClearItems()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Items = new BlueprintItemReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonLoot.m_Items"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyItems(Action<BlueprintItemReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Items is null) { return; }
          bp.m_Items.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonLoot.Filter"/>
    /// </summary>
    ///
    /// <param name="filter">
    /// <para>
    /// Tooltip: Settings used to automatically collect the items with the Collect button.
    /// </para>
    /// </param>
    public TBuilder SetFilter(DungeonLootFilter filter)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(filter);
          bp.Filter = filter;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonLoot.Filter"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFilter(Action<DungeonLootFilter> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Filter is null) { return; }
          action.Invoke(bp.Filter);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonLoot.DoNotRepeat"/>
    /// </summary>
    ///
    /// <param name="doNotRepeat">
    /// <para>
    /// Tooltip: No more than one same item per island.
    /// </para>
    /// </param>
    public TBuilder SetDoNotRepeat(bool doNotRepeat = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotRepeat = doNotRepeat;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonLoot.DoNotRepeatInSameRun"/>
    /// </summary>
    ///
    /// <param name="doNotRepeatInSameRun">
    /// <para>
    /// Tooltip: No more than one same item per run.
    /// </para>
    /// </param>
    public TBuilder SetDoNotRepeatInSameRun(bool doNotRepeatInSameRun = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotRepeatInSameRun = doNotRepeatInSameRun;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonLoot.Budgeting"/>
    /// </summary>
    ///
    /// <param name="budgeting">
    /// <para>
    /// Tooltip: Use the cost to calculate the budget.
    /// </para>
    /// </param>
    public TBuilder SetBudgeting(bool budgeting = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Budgeting = budgeting;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonLoot.m_Budget"/>
    /// </summary>
    ///
    /// <param name="budget">
    /// <para>
    /// Blueprint of type BlueprintDungeonLootBudget. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBudget(Blueprint<BlueprintDungeonLootBudgetReference> budget)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Budget = budget?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonLoot.m_Budget"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBudget(Action<BlueprintDungeonLootBudgetReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Budget is null) { return; }
          action.Invoke(bp.m_Budget);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonLoot.CountOfItemsPerIsland"/>
    /// </summary>
    public TBuilder SetCountOfItemsPerIsland(params IntegerWeighted[] countOfItemsPerIsland)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(countOfItemsPerIsland);
          bp.CountOfItemsPerIsland = countOfItemsPerIsland;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonLoot.CountOfItemsPerIsland"/>
    /// </summary>
    public TBuilder AddToCountOfItemsPerIsland(params IntegerWeighted[] countOfItemsPerIsland)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CountOfItemsPerIsland = bp.CountOfItemsPerIsland ?? new IntegerWeighted[0];
          bp.CountOfItemsPerIsland = CommonTool.Append(bp.CountOfItemsPerIsland, countOfItemsPerIsland);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonLoot.CountOfItemsPerIsland"/>
    /// </summary>
    public TBuilder RemoveFromCountOfItemsPerIsland(params IntegerWeighted[] countOfItemsPerIsland)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfItemsPerIsland is null) { return; }
          bp.CountOfItemsPerIsland = bp.CountOfItemsPerIsland.Where(val => !countOfItemsPerIsland.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonLoot.CountOfItemsPerIsland"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCountOfItemsPerIsland(Func<IntegerWeighted, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfItemsPerIsland is null) { return; }
          bp.CountOfItemsPerIsland = bp.CountOfItemsPerIsland.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonLoot.CountOfItemsPerIsland"/>
    /// </summary>
    public TBuilder ClearCountOfItemsPerIsland()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CountOfItemsPerIsland = new IntegerWeighted[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonLoot.CountOfItemsPerIsland"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCountOfItemsPerIsland(Action<IntegerWeighted> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfItemsPerIsland is null) { return; }
          bp.CountOfItemsPerIsland.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonLoot.CountOfItemsPerChest"/>
    /// </summary>
    public TBuilder SetCountOfItemsPerChest(params IntegerWeighted[] countOfItemsPerChest)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(countOfItemsPerChest);
          bp.CountOfItemsPerChest = countOfItemsPerChest;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonLoot.CountOfItemsPerChest"/>
    /// </summary>
    public TBuilder AddToCountOfItemsPerChest(params IntegerWeighted[] countOfItemsPerChest)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CountOfItemsPerChest = bp.CountOfItemsPerChest ?? new IntegerWeighted[0];
          bp.CountOfItemsPerChest = CommonTool.Append(bp.CountOfItemsPerChest, countOfItemsPerChest);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonLoot.CountOfItemsPerChest"/>
    /// </summary>
    public TBuilder RemoveFromCountOfItemsPerChest(params IntegerWeighted[] countOfItemsPerChest)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfItemsPerChest is null) { return; }
          bp.CountOfItemsPerChest = bp.CountOfItemsPerChest.Where(val => !countOfItemsPerChest.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonLoot.CountOfItemsPerChest"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCountOfItemsPerChest(Func<IntegerWeighted, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfItemsPerChest is null) { return; }
          bp.CountOfItemsPerChest = bp.CountOfItemsPerChest.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonLoot.CountOfItemsPerChest"/>
    /// </summary>
    public TBuilder ClearCountOfItemsPerChest()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CountOfItemsPerChest = new IntegerWeighted[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonLoot.CountOfItemsPerChest"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCountOfItemsPerChest(Action<IntegerWeighted> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfItemsPerChest is null) { return; }
          bp.CountOfItemsPerChest.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonLoot.m_LootIncompatible"/>
    /// </summary>
    ///
    /// <param name="lootIncompatible">
    /// <para>
    /// Tooltip: Loot that cannot be in the same chest.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonLoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetLootIncompatible(params Blueprint<BlueprintDungeonLootReference>[] lootIncompatible)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_LootIncompatible = lootIncompatible.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonLoot.m_LootIncompatible"/>
    /// </summary>
    ///
    /// <param name="lootIncompatible">
    /// <para>
    /// Tooltip: Loot that cannot be in the same chest.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonLoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToLootIncompatible(params Blueprint<BlueprintDungeonLootReference>[] lootIncompatible)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_LootIncompatible = bp.m_LootIncompatible ?? new BlueprintDungeonLootReference[0];
          bp.m_LootIncompatible = CommonTool.Append(bp.m_LootIncompatible, lootIncompatible.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonLoot.m_LootIncompatible"/>
    /// </summary>
    ///
    /// <param name="lootIncompatible">
    /// <para>
    /// Tooltip: Loot that cannot be in the same chest.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonLoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromLootIncompatible(params Blueprint<BlueprintDungeonLootReference>[] lootIncompatible)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_LootIncompatible is null) { return; }
          bp.m_LootIncompatible = bp.m_LootIncompatible.Where(val => !lootIncompatible.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonLoot.m_LootIncompatible"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromLootIncompatible(Func<BlueprintDungeonLootReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_LootIncompatible is null) { return; }
          bp.m_LootIncompatible = bp.m_LootIncompatible.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonLoot.m_LootIncompatible"/>
    /// </summary>
    public TBuilder ClearLootIncompatible()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_LootIncompatible = new BlueprintDungeonLootReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonLoot.m_LootIncompatible"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyLootIncompatible(Action<BlueprintDungeonLootReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_LootIncompatible is null) { return; }
          bp.m_LootIncompatible.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonLoot.OptionalItems"/>
    /// </summary>
    public TBuilder SetOptionalItems(params ItemWithCheck[] optionalItems)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(optionalItems);
          bp.OptionalItems = optionalItems;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonLoot.OptionalItems"/>
    /// </summary>
    public TBuilder AddToOptionalItems(params ItemWithCheck[] optionalItems)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OptionalItems = bp.OptionalItems ?? new ItemWithCheck[0];
          bp.OptionalItems = CommonTool.Append(bp.OptionalItems, optionalItems);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonLoot.OptionalItems"/>
    /// </summary>
    public TBuilder RemoveFromOptionalItems(params ItemWithCheck[] optionalItems)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OptionalItems is null) { return; }
          bp.OptionalItems = bp.OptionalItems.Where(val => !optionalItems.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonLoot.OptionalItems"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromOptionalItems(Func<ItemWithCheck, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OptionalItems is null) { return; }
          bp.OptionalItems = bp.OptionalItems.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonLoot.OptionalItems"/>
    /// </summary>
    public TBuilder ClearOptionalItems()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OptionalItems = new ItemWithCheck[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonLoot.OptionalItems"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyOptionalItems(Action<ItemWithCheck> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OptionalItems is null) { return; }
          bp.OptionalItems.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Items is null)
      {
        Blueprint.m_Items = new BlueprintItemReference[0];
      }
      if (Blueprint.m_Budget is null)
      {
        Blueprint.m_Budget = BlueprintTool.GetRef<BlueprintDungeonLootBudgetReference>(null);
      }
      if (Blueprint.CountOfItemsPerIsland is null)
      {
        Blueprint.CountOfItemsPerIsland = new IntegerWeighted[0];
      }
      if (Blueprint.CountOfItemsPerChest is null)
      {
        Blueprint.CountOfItemsPerChest = new IntegerWeighted[0];
      }
      if (Blueprint.m_LootIncompatible is null)
      {
        Blueprint.m_LootIncompatible = new BlueprintDungeonLootReference[0];
      }
      if (Blueprint.OptionalItems is null)
      {
        Blueprint.OptionalItems = new ItemWithCheck[0];
      }
    }
  }
}
