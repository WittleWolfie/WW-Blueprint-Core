using BlueprintCore.Utils;
using Kingmaker.Blueprints.Loot;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Loot
{
  /// <summary>Configurator for <see cref="TrashLootSettings"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(TrashLootSettings))]
  public class TrashLootSettingsConfigurator : BaseBlueprintConfigurator<TrashLootSettings, TrashLootSettingsConfigurator>
  {
     private TrashLootSettingsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TrashLootSettingsConfigurator For(string name)
    {
      return new TrashLootSettingsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static TrashLootSettingsConfigurator New(string name)
    {
      BlueprintTool.Create<TrashLootSettings>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TrashLootSettingsConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<TrashLootSettings>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="TrashLootSettings.CRToCost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator AddToCRToCost(params int[] values)
    {
      return OnConfigureInternal(bp => bp.CRToCost = CommonTool.Append(bp.CRToCost, values));
    }

    /// <summary>
    /// Modifies <see cref="TrashLootSettings.CRToCost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator RemoveFromCRToCost(params int[] values)
    {
      return OnConfigureInternal(bp => bp.CRToCost = bp.CRToCost.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="TrashLootSettings.ChanceToIncreaseItemsCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator AddToChanceToIncreaseItemsCount(params int[] values)
    {
      return OnConfigureInternal(bp => bp.ChanceToIncreaseItemsCount = CommonTool.Append(bp.ChanceToIncreaseItemsCount, values));
    }

    /// <summary>
    /// Modifies <see cref="TrashLootSettings.ChanceToIncreaseItemsCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator RemoveFromChanceToIncreaseItemsCount(params int[] values)
    {
      return OnConfigureInternal(bp => bp.ChanceToIncreaseItemsCount = bp.ChanceToIncreaseItemsCount.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="TrashLootSettings.Types"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator AddToTypes(params TrashLootSettings.TypeSettings[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Types.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="TrashLootSettings.Types"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator RemoveFromTypes(params TrashLootSettings.TypeSettings[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Types = bp.Types.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Modifies <see cref="TrashLootSettings.Table"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator AddToTable(params TrashLootSettings.TypeChance[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Table = CommonTool.Append(bp.Table, values));
    }

    /// <summary>
    /// Modifies <see cref="TrashLootSettings.Table"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator RemoveFromTable(params TrashLootSettings.TypeChance[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Table = bp.Table.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="TrashLootSettings.SuperTrashLoot"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator AddToSuperTrashLoot(params TrashLootSettings.SettingAndItems[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.SuperTrashLoot = CommonTool.Append(bp.SuperTrashLoot, values));
    }

    /// <summary>
    /// Modifies <see cref="TrashLootSettings.SuperTrashLoot"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator RemoveFromSuperTrashLoot(params TrashLootSettings.SettingAndItems[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.SuperTrashLoot = bp.SuperTrashLoot.Where(item => !values.Contains(item)).ToArray());
    }
  }
}
