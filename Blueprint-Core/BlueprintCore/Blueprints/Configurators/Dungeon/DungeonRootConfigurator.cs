using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.View.Roaming;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>Configurator for <see cref="BlueprintDungeonRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintDungeonRoot))]
  public class DungeonRootConfigurator : BaseBlueprintConfigurator<BlueprintDungeonRoot, DungeonRootConfigurator>
  {
     private DungeonRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DungeonRootConfigurator For(string name)
    {
      return new DungeonRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static DungeonRootConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintDungeonRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DungeonRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintDungeonRoot>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.DebugOutput"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetDebugOutput(BlueprintDungeonRoot.DebugOutputSettings value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.DebugOutput = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.Test"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetTest(BlueprintDungeonRoot.TestSettings value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Test = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_Localization"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintDungeonLocalizedStrings"/></param>
    [Generated]
    public DungeonRootConfigurator SetLocalization(string value)
    {
      return OnConfigureInternal(bp => bp.m_Localization = BlueprintTool.GetRef<BlueprintDungeonLocalizedStringsReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_NewGamePreset"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintAreaPreset"/></param>
    [Generated]
    public DungeonRootConfigurator SetNewGamePreset(string value)
    {
      return OnConfigureInternal(bp => bp.m_NewGamePreset = BlueprintTool.GetRef<BlueprintAreaPresetReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.BoonsPoolSize"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetBoonsPoolSize(int value)
    {
      return OnConfigureInternal(bp => bp.BoonsPoolSize = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.QuestItemPerStageChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetQuestItemPerStageChance(int value)
    {
      return OnConfigureInternal(bp => bp.QuestItemPerStageChance = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_UnitsWithQuestItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintSummonPool"/></param>
    [Generated]
    public DungeonRootConfigurator SetUnitsWithQuestItems(string value)
    {
      return OnConfigureInternal(bp => bp.m_UnitsWithQuestItems = BlueprintTool.GetRef<BlueprintSummonPoolReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_MainVendorTable"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintSharedVendorTable"/></param>
    [Generated]
    public DungeonRootConfigurator SetMainVendorTable(string value)
    {
      return OnConfigureInternal(bp => bp.m_MainVendorTable = BlueprintTool.GetRef<BlueprintSharedVendorTableReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_DivineVendorTable"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintSharedVendorTable"/></param>
    [Generated]
    public DungeonRootConfigurator SetDivineVendorTable(string value)
    {
      return OnConfigureInternal(bp => bp.m_DivineVendorTable = BlueprintTool.GetRef<BlueprintSharedVendorTableReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_CorruptedFighterClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    public DungeonRootConfigurator SetCorruptedFighterClass(string value)
    {
      return OnConfigureInternal(bp => bp.m_CorruptedFighterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_CorruptedArcherClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    public DungeonRootConfigurator SetCorruptedArcherClass(string value)
    {
      return OnConfigureInternal(bp => bp.m_CorruptedArcherClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_CorruptedCasterClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    public DungeonRootConfigurator SetCorruptedCasterClass(string value)
    {
      return OnConfigureInternal(bp => bp.m_CorruptedCasterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.StartSetting"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetStartSetting(DungeonStageSetting value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.StartSetting = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.FirstChangeSettingStage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetFirstChangeSettingStage(int value)
    {
      return OnConfigureInternal(bp => bp.FirstChangeSettingStage = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.ChangeSettingFrequency"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetChangeSettingFrequency(int value)
    {
      return OnConfigureInternal(bp => bp.ChangeSettingFrequency = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.RoomsPerStage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetRoomsPerStage(int value)
    {
      return OnConfigureInternal(bp => bp.RoomsPerStage = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.EmptyRoomsPerStage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetEmptyRoomsPerStage(int value)
    {
      return OnConfigureInternal(bp => bp.EmptyRoomsPerStage = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.FirstBossStage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetFirstBossStage(int value)
    {
      return OnConfigureInternal(bp => bp.FirstBossStage = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.BossFrequency"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetBossFrequency(int value)
    {
      return OnConfigureInternal(bp => bp.BossFrequency = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.FirstMiniBossStage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetFirstMiniBossStage(int value)
    {
      return OnConfigureInternal(bp => bp.FirstMiniBossStage = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.MiniBossFrequency"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetMiniBossFrequency(int value)
    {
      return OnConfigureInternal(bp => bp.MiniBossFrequency = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.HardEncountersPerStage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetHardEncountersPerStage(int value)
    {
      return OnConfigureInternal(bp => bp.HardEncountersPerStage = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.AdditionalHardEncounterChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetAdditionalHardEncounterChance(int value)
    {
      return OnConfigureInternal(bp => bp.AdditionalHardEncounterChance = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.ApplyThemeChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetApplyThemeChance(int value)
    {
      return OnConfigureInternal(bp => bp.ApplyThemeChance = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.AdditionalShrineChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetAdditionalShrineChance(int value)
    {
      return OnConfigureInternal(bp => bp.AdditionalShrineChance = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.AdditionalLockedChestChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetAdditionalLockedChestChance(int value)
    {
      return OnConfigureInternal(bp => bp.AdditionalLockedChestChance = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.SecretEncounterChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetSecretEncounterChance(int value)
    {
      return OnConfigureInternal(bp => bp.SecretEncounterChance = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.FinalBossPortalChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetFinalBossPortalChance(int value)
    {
      return OnConfigureInternal(bp => bp.FinalBossPortalChance = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.FirstIncreaseCRStage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetFirstIncreaseCRStage(int value)
    {
      return OnConfigureInternal(bp => bp.FirstIncreaseCRStage = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.IncreaseCRFrequency"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetIncreaseCRFrequency(int value)
    {
      return OnConfigureInternal(bp => bp.IncreaseCRFrequency = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.BossCRBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetBossCRBonus(int value)
    {
      return OnConfigureInternal(bp => bp.BossCRBonus = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.MiniBossCRBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetMiniBossCRBonus(int value)
    {
      return OnConfigureInternal(bp => bp.MiniBossCRBonus = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.HardEncounterCRBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetHardEncounterCRBonus(int value)
    {
      return OnConfigureInternal(bp => bp.HardEncounterCRBonus = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.RoomCRBonuses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToRoomCRBonuses(params int[] values)
    {
      return OnConfigureInternal(bp => bp.RoomCRBonuses = CommonTool.Append(bp.RoomCRBonuses, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.RoomCRBonuses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromRoomCRBonuses(params int[] values)
    {
      return OnConfigureInternal(bp => bp.RoomCRBonuses = bp.RoomCRBonuses.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.EveryRoomCRBonuses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToEveryRoomCRBonuses(params BlueprintDungeonRoot.StageCRBonus[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.EveryRoomCRBonuses = CommonTool.Append(bp.EveryRoomCRBonuses, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.EveryRoomCRBonuses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromEveryRoomCRBonuses(params BlueprintDungeonRoot.StageCRBonus[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.EveryRoomCRBonuses = bp.EveryRoomCRBonuses.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.CorruptedUnitChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetCorruptedUnitChance(int value)
    {
      return OnConfigureInternal(bp => bp.CorruptedUnitChance = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.UnitsCountInPack"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToUnitsCountInPack(params BlueprintDungeonRoot.UnitsPerPack[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.UnitsCountInPack = CommonTool.Append(bp.UnitsCountInPack, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.UnitsCountInPack"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromUnitsCountInPack(params BlueprintDungeonRoot.UnitsPerPack[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.UnitsCountInPack = bp.UnitsCountInPack.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.UnitsCountInBossPack"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToUnitsCountInBossPack(params BlueprintDungeonRoot.UnitsPerPack[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.UnitsCountInBossPack = CommonTool.Append(bp.UnitsCountInBossPack, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.UnitsCountInBossPack"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromUnitsCountInBossPack(params BlueprintDungeonRoot.UnitsPerPack[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.UnitsCountInBossPack = bp.UnitsCountInBossPack.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.PacksCountInRoom"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToPacksCountInRoom(params BlueprintDungeonRoot.ValueWithWeight[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.PacksCountInRoom = CommonTool.Append(bp.PacksCountInRoom, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.PacksCountInRoom"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromPacksCountInRoom(params BlueprintDungeonRoot.ValueWithWeight[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.PacksCountInRoom = bp.PacksCountInRoom.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.PacksCountInBossRoom"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToPacksCountInBossRoom(params BlueprintDungeonRoot.ValueWithWeight[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.PacksCountInBossRoom = CommonTool.Append(bp.PacksCountInBossRoom, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.PacksCountInBossRoom"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromPacksCountInBossRoom(params BlueprintDungeonRoot.ValueWithWeight[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.PacksCountInBossRoom = bp.PacksCountInBossRoom.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.Armies"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToArmies(params DungeonArmySettings[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Armies = CommonTool.Append(bp.Armies, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.Armies"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromArmies(params DungeonArmySettings[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Armies = bp.Armies.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.Roaming"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetRoaming(RoamingUnitSettings value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Roaming = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.CustomBosses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToCustomBosses(params BlueprintDungeonRoot.CustomBossSettings[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.CustomBosses = CommonTool.Append(bp.CustomBosses, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.CustomBosses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromCustomBosses(params BlueprintDungeonRoot.CustomBossSettings[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.CustomBosses = bp.CustomBosses.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_StageUnits"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintSummonPool"/></param>
    [Generated]
    public DungeonRootConfigurator SetStageUnits(string value)
    {
      return OnConfigureInternal(bp => bp.m_StageUnits = BlueprintTool.GetRef<BlueprintSummonPoolReference>(value));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.LootTableSmall"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToLootTableSmall(params BlueprintDungeonRoot.LootTypeWeight[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.LootTableSmall = CommonTool.Append(bp.LootTableSmall, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.LootTableSmall"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromLootTableSmall(params BlueprintDungeonRoot.LootTypeWeight[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.LootTableSmall = bp.LootTableSmall.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.LootTableBig"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToLootTableBig(params BlueprintDungeonRoot.LootTypeWeight[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.LootTableBig = CommonTool.Append(bp.LootTableBig, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.LootTableBig"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromLootTableBig(params BlueprintDungeonRoot.LootTypeWeight[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.LootTableBig = bp.LootTableBig.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.LootCRBonuses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToLootCRBonuses(params BlueprintDungeonRoot.ValueWithWeight[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.LootCRBonuses = CommonTool.Append(bp.LootCRBonuses, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.LootCRBonuses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromLootCRBonuses(params BlueprintDungeonRoot.ValueWithWeight[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.LootCRBonuses = bp.LootCRBonuses.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.Loot"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetLoot(DungeonLootRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Loot = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.Items"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToItems(params BlueprintDungeonRoot.ItemsList[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Items = CommonTool.Append(bp.Items, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.Items"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromItems(params BlueprintDungeonRoot.ItemsList[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Items = bp.Items.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_Essentials"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintItemEquipment"/></param>
    [Generated]
    public DungeonRootConfigurator AddToEssentials(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Essentials = CommonTool.Append(bp.m_Essentials, values.Select(name => BlueprintTool.GetRef<BlueprintItemEquipmentReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_Essentials"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintItemEquipment"/></param>
    [Generated]
    public DungeonRootConfigurator RemoveFromEssentials(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintItemEquipmentReference>(name));
            bp.m_Essentials =
                bp.m_Essentials
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_PackSpawnLoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintGenericPackLoot"/></param>
    [Generated]
    public DungeonRootConfigurator SetPackSpawnLoot(string value)
    {
      return OnConfigureInternal(bp => bp.m_PackSpawnLoot = BlueprintTool.GetRef<BlueprintGenericPackLootReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.TrapDisabledEvent"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetTrapDisabledEvent(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.TrapDisabledEvent = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.TrapDisableFailedEvent"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetTrapDisableFailedEvent(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.TrapDisableFailedEvent = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.TrapInteractionStartedEvent"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetTrapInteractionStartedEvent(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.TrapInteractionStartedEvent = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.TrapInteractionEndedEvent"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetTrapInteractionEndedEvent(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.TrapInteractionEndedEvent = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_FinalBossPortal"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintSpawnableObject"/></param>
    [Generated]
    public DungeonRootConfigurator SetFinalBossPortal(string value)
    {
      return OnConfigureInternal(bp => bp.m_FinalBossPortal = BlueprintTool.GetRef<BlueprintDungeonSpawnableReference>(value));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.SpecialObjects"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToSpecialObjects(params BlueprintDungeonRoot.SpecialObjectsList[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.SpecialObjects = CommonTool.Append(bp.SpecialObjects, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.SpecialObjects"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromSpecialObjects(params BlueprintDungeonRoot.SpecialObjectsList[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.SpecialObjects = bp.SpecialObjects.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_Boons"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintDungeonBoon"/></param>
    [Generated]
    public DungeonRootConfigurator AddToBoons(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Boons = CommonTool.Append(bp.m_Boons, values.Select(name => BlueprintTool.GetRef<BlueprintDungeonBoonReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_Boons"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintDungeonBoon"/></param>
    [Generated]
    public DungeonRootConfigurator RemoveFromBoons(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintDungeonBoonReference>(name));
            bp.m_Boons =
                bp.m_Boons
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.ThemeBuffs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToThemeBuffs(params BlueprintDungeonRoot.ThemeBuffSettings[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.ThemeBuffs = CommonTool.Append(bp.ThemeBuffs, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.ThemeBuffs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromThemeBuffs(params BlueprintDungeonRoot.ThemeBuffSettings[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.ThemeBuffs = bp.ThemeBuffs.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.ThemeAudioScenes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToThemeAudioScenes(params BlueprintDungeonRoot.ThemeAudioSettings[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.ThemeAudioScenes = CommonTool.Append(bp.ThemeAudioScenes, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.ThemeAudioScenes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromThemeAudioScenes(params BlueprintDungeonRoot.ThemeAudioSettings[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.ThemeAudioScenes = bp.ThemeAudioScenes.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_TrapActor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintUnit"/></param>
    [Generated]
    public DungeonRootConfigurator SetTrapActor(string value)
    {
      return OnConfigureInternal(bp => bp.m_TrapActor = BlueprintTool.GetRef<BlueprintUnitReference>(value));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.Traps"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToTraps(params BlueprintDungeonRoot.TrapAndMinStage[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Traps = CommonTool.Append(bp.Traps, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.Traps"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromTraps(params BlueprintDungeonRoot.TrapAndMinStage[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Traps = bp.Traps.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.ExperienceRewardForCompleteStageStart"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetExperienceRewardForCompleteStageStart(int value)
    {
      return OnConfigureInternal(bp => bp.ExperienceRewardForCompleteStageStart = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.ExperienceRewardForCompleteStageStep"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetExperienceRewardForCompleteStageStep(int value)
    {
      return OnConfigureInternal(bp => bp.ExperienceRewardForCompleteStageStep = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_EnterPoints"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAreaEnterPoint"/></param>
    [Generated]
    public DungeonRootConfigurator AddToEnterPoints(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_EnterPoints = CommonTool.Append(bp.m_EnterPoints, values.Select(name => BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_EnterPoints"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAreaEnterPoint"/></param>
    [Generated]
    public DungeonRootConfigurator RemoveFromEnterPoints(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(name));
            bp.m_EnterPoints =
                bp.m_EnterPoints
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}
