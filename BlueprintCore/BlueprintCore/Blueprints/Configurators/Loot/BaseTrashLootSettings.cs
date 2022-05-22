//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Loot
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="TrashLootSettings"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTrashLootSettingsConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : TrashLootSettings
    where TBuilder : BaseTrashLootSettingsConfigurator<T, TBuilder>
  {
    protected BaseTrashLootSettingsConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="TrashLootSettings.CRToCost"/>
    /// </summary>
    public TBuilder SetCRToCost(params int[] cRToCost)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CRToCost = cRToCost;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="TrashLootSettings.CRToCost"/>
    /// </summary>
    public TBuilder AddToCRToCost(params int[] cRToCost)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CRToCost = bp.CRToCost ?? new int[0];
          bp.CRToCost = CommonTool.Append(bp.CRToCost, cRToCost);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="TrashLootSettings.CRToCost"/>
    /// </summary>
    public TBuilder RemoveFromCRToCost(params int[] cRToCost)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CRToCost is null) { return; }
          bp.CRToCost = bp.CRToCost.Where(val => !cRToCost.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="TrashLootSettings.CRToCost"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCRToCost(Func<int, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CRToCost is null) { return; }
          bp.CRToCost = bp.CRToCost.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="TrashLootSettings.CRToCost"/>
    /// </summary>
    public TBuilder ClearCRToCost()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CRToCost = new int[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="TrashLootSettings.CRToCost"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCRToCost(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CRToCost is null) { return; }
          bp.CRToCost.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="TrashLootSettings.ChanceToIncreaseItemsCount"/>
    /// </summary>
    public TBuilder SetChanceToIncreaseItemsCount(params int[] chanceToIncreaseItemsCount)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ChanceToIncreaseItemsCount = chanceToIncreaseItemsCount;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="TrashLootSettings.ChanceToIncreaseItemsCount"/>
    /// </summary>
    public TBuilder AddToChanceToIncreaseItemsCount(params int[] chanceToIncreaseItemsCount)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ChanceToIncreaseItemsCount = bp.ChanceToIncreaseItemsCount ?? new int[0];
          bp.ChanceToIncreaseItemsCount = CommonTool.Append(bp.ChanceToIncreaseItemsCount, chanceToIncreaseItemsCount);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="TrashLootSettings.ChanceToIncreaseItemsCount"/>
    /// </summary>
    public TBuilder RemoveFromChanceToIncreaseItemsCount(params int[] chanceToIncreaseItemsCount)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ChanceToIncreaseItemsCount is null) { return; }
          bp.ChanceToIncreaseItemsCount = bp.ChanceToIncreaseItemsCount.Where(val => !chanceToIncreaseItemsCount.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="TrashLootSettings.ChanceToIncreaseItemsCount"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromChanceToIncreaseItemsCount(Func<int, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ChanceToIncreaseItemsCount is null) { return; }
          bp.ChanceToIncreaseItemsCount = bp.ChanceToIncreaseItemsCount.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="TrashLootSettings.ChanceToIncreaseItemsCount"/>
    /// </summary>
    public TBuilder ClearChanceToIncreaseItemsCount()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ChanceToIncreaseItemsCount = new int[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="TrashLootSettings.ChanceToIncreaseItemsCount"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyChanceToIncreaseItemsCount(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ChanceToIncreaseItemsCount is null) { return; }
          bp.ChanceToIncreaseItemsCount.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="TrashLootSettings.Types"/>
    /// </summary>
    public TBuilder SetTypes(params TrashLootSettings.TypeSettings[] types)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in types) { Validate(item); }
          bp.Types = types.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="TrashLootSettings.Types"/>
    /// </summary>
    public TBuilder AddToTypes(params TrashLootSettings.TypeSettings[] types)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Types = bp.Types ?? new();
          bp.Types.AddRange(types);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="TrashLootSettings.Types"/>
    /// </summary>
    public TBuilder RemoveFromTypes(params TrashLootSettings.TypeSettings[] types)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Types is null) { return; }
          bp.Types = bp.Types.Where(val => !types.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="TrashLootSettings.Types"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromTypes(Func<TrashLootSettings.TypeSettings, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Types is null) { return; }
          bp.Types = bp.Types.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="TrashLootSettings.Types"/>
    /// </summary>
    public TBuilder ClearTypes()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Types = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="TrashLootSettings.Types"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyTypes(Action<TrashLootSettings.TypeSettings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Types is null) { return; }
          bp.Types.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="TrashLootSettings.Table"/>
    /// </summary>
    public TBuilder SetTable(params TrashLootSettings.TypeChance[] table)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in table) { Validate(item); }
          bp.Table = table;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="TrashLootSettings.Table"/>
    /// </summary>
    public TBuilder AddToTable(params TrashLootSettings.TypeChance[] table)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Table = bp.Table ?? new TrashLootSettings.TypeChance[0];
          bp.Table = CommonTool.Append(bp.Table, table);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="TrashLootSettings.Table"/>
    /// </summary>
    public TBuilder RemoveFromTable(params TrashLootSettings.TypeChance[] table)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Table is null) { return; }
          bp.Table = bp.Table.Where(val => !table.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="TrashLootSettings.Table"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromTable(Func<TrashLootSettings.TypeChance, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Table is null) { return; }
          bp.Table = bp.Table.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="TrashLootSettings.Table"/>
    /// </summary>
    public TBuilder ClearTable()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Table = new TrashLootSettings.TypeChance[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="TrashLootSettings.Table"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyTable(Action<TrashLootSettings.TypeChance> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Table is null) { return; }
          bp.Table.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="TrashLootSettings.SuperTrashLoot"/>
    /// </summary>
    public TBuilder SetSuperTrashLoot(params TrashLootSettings.SettingAndItems[] superTrashLoot)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in superTrashLoot) { Validate(item); }
          bp.SuperTrashLoot = superTrashLoot;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="TrashLootSettings.SuperTrashLoot"/>
    /// </summary>
    public TBuilder AddToSuperTrashLoot(params TrashLootSettings.SettingAndItems[] superTrashLoot)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SuperTrashLoot = bp.SuperTrashLoot ?? new TrashLootSettings.SettingAndItems[0];
          bp.SuperTrashLoot = CommonTool.Append(bp.SuperTrashLoot, superTrashLoot);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="TrashLootSettings.SuperTrashLoot"/>
    /// </summary>
    public TBuilder RemoveFromSuperTrashLoot(params TrashLootSettings.SettingAndItems[] superTrashLoot)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SuperTrashLoot is null) { return; }
          bp.SuperTrashLoot = bp.SuperTrashLoot.Where(val => !superTrashLoot.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="TrashLootSettings.SuperTrashLoot"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromSuperTrashLoot(Func<TrashLootSettings.SettingAndItems, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SuperTrashLoot is null) { return; }
          bp.SuperTrashLoot = bp.SuperTrashLoot.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="TrashLootSettings.SuperTrashLoot"/>
    /// </summary>
    public TBuilder ClearSuperTrashLoot()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SuperTrashLoot = new TrashLootSettings.SettingAndItems[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="TrashLootSettings.SuperTrashLoot"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifySuperTrashLoot(Action<TrashLootSettings.SettingAndItems> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SuperTrashLoot is null) { return; }
          bp.SuperTrashLoot.ForEach(action);
        });
    }
  }
}
