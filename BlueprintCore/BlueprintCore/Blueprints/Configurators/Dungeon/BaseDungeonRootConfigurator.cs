//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Items;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.Dungeon.Enums;
using Kingmaker.ElementsSystem;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using Kingmaker.View.Roaming;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDungeonRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDungeonRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintDungeonRoot
    where TBuilder : BaseDungeonRootConfigurator<T, TBuilder>
  {
    protected BaseDungeonRootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintDungeonRoot>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.DebugOutput = copyFrom.DebugOutput;
          bp.Test = copyFrom.Test;
          bp.m_DungeonCampaign = copyFrom.m_DungeonCampaign;
          bp.m_Localization = copyFrom.m_Localization;
          bp.QuestItemPerStageChance = copyFrom.QuestItemPerStageChance;
          bp.m_UnitsWithQuestItems = copyFrom.m_UnitsWithQuestItems;
          bp.m_MainVendorTable = copyFrom.m_MainVendorTable;
          bp.m_DivineVendorTable = copyFrom.m_DivineVendorTable;
          bp.TravelSpeedMin = copyFrom.TravelSpeedMin;
          bp.TravelSpeedMax = copyFrom.TravelSpeedMax;
          bp.TravelTimeHours = copyFrom.TravelTimeHours;
          bp.m_MapPlayerPawnLink = copyFrom.m_MapPlayerPawnLink;
          bp.m_Maps = copyFrom.m_Maps;
          bp.MapStartIslandPawnPosition = copyFrom.MapStartIslandPawnPosition;
          bp.MapFinalIslandPawnPosition = copyFrom.MapFinalIslandPawnPosition;
          bp.MapDecorationGroups = copyFrom.MapDecorationGroups;
          bp.m_Expeditions = copyFrom.m_Expeditions;
          bp.m_Islands = copyFrom.m_Islands;
          bp.m_Modificators = copyFrom.m_Modificators;
          bp.CountOfObjectsPerModificator = copyFrom.CountOfObjectsPerModificator;
          bp.CountOfSecretRooms = copyFrom.CountOfSecretRooms;
          bp.m_Ship = copyFrom.m_Ship;
          bp.m_Port = copyFrom.m_Port;
          bp.m_RandomEncounterIslandIndexNotBefore = copyFrom.m_RandomEncounterIslandIndexNotBefore;
          bp.m_RandomEncounterChance = copyFrom.m_RandomEncounterChance;
          bp.CountOfUnitsInRandomEncounter = copyFrom.CountOfUnitsInRandomEncounter;
          bp.m_RandomEncounterArmies = copyFrom.m_RandomEncounterArmies;
          bp.ActionsOnRandomEncounter = copyFrom.ActionsOnRandomEncounter;
          bp.ExperienceMultiplierEasy = copyFrom.ExperienceMultiplierEasy;
          bp.ExperienceMultiplierNormal = copyFrom.ExperienceMultiplierNormal;
          bp.ExperienceMultiplierHard = copyFrom.ExperienceMultiplierHard;
          bp.Experience = copyFrom.Experience;
          bp.m_Tiers = copyFrom.m_Tiers;
          bp.m_Boons = copyFrom.m_Boons;
          bp.ActionsBeforeRestart = copyFrom.ActionsBeforeRestart;
          bp.ActionsAfterRestart = copyFrom.ActionsAfterRestart;
          bp.ActionsAfterChargen = copyFrom.ActionsAfterChargen;
          bp.ActionsBeforeExpeditionRestart = copyFrom.ActionsBeforeExpeditionRestart;
          bp.ActionsAfterExpeditionRestart = copyFrom.ActionsAfterExpeditionRestart;
          bp.CarryOverItemsCount = copyFrom.CarryOverItemsCount;
          bp.m_CarryOverItemsBlacklist = copyFrom.m_CarryOverItemsBlacklist;
          bp.SpreadDC = copyFrom.SpreadDC;
          bp.SavingThrowMinimalDC = copyFrom.SavingThrowMinimalDC;
          bp.SkillCheckMinimalDC = copyFrom.SkillCheckMinimalDC;
          bp.MicroBossCRBonus = copyFrom.MicroBossCRBonus;
          bp.CrToExperience = copyFrom.CrToExperience;
          bp.m_DifficultyCurves = copyFrom.m_DifficultyCurves;
          bp.m_Templates = copyFrom.m_Templates;
          bp.CountOfRandomTemplates = copyFrom.CountOfRandomTemplates;
          bp.m_DifficultyToCurve = copyFrom.m_DifficultyToCurve;
          bp.RoomEnterExcludesEnemies = copyFrom.RoomEnterExcludesEnemies;
          bp.RoomExitExcludesEnemies = copyFrom.RoomExitExcludesEnemies;
          bp.RoomArmyCountProbabilities = copyFrom.RoomArmyCountProbabilities;
          bp.SecretRoomSpecialArmyProbability = copyFrom.SecretRoomSpecialArmyProbability;
          bp.CountOfUnitsInRoom = copyFrom.CountOfUnitsInRoom;
          bp.CountOfRoomsWithUnits = copyFrom.CountOfRoomsWithUnits;
          bp.CountOfRoomsWithLoot = copyFrom.CountOfRoomsWithLoot;
          bp.CountOfChestLocked = copyFrom.CountOfChestLocked;
          bp.CountOfTraps = copyFrom.CountOfTraps;
          bp.m_MobFaction = copyFrom.m_MobFaction;
          bp.m_MobSummonPool = copyFrom.m_MobSummonPool;
          bp.RoamingProbability = copyFrom.RoamingProbability;
          bp.Roaming = copyFrom.Roaming;
          bp.m_OverrideCountByUnitTagEntries = copyFrom.m_OverrideCountByUnitTagEntries;
          bp.m_Armies = copyFrom.m_Armies;
          bp.m_TrapSpells = copyFrom.m_TrapSpells;
          bp.MinimalGoldRelativeAmountInChest = copyFrom.MinimalGoldRelativeAmountInChest;
          bp.m_Loot = copyFrom.m_Loot;
          bp.m_LootContainers = copyFrom.m_LootContainers;
          bp.m_BesmaritBossIsland = copyFrom.m_BesmaritBossIsland;
          bp.m_BesmaritModificator = copyFrom.m_BesmaritModificator;
          bp.m_BesmaritIslands = copyFrom.m_BesmaritIslands;
          bp.m_BesmaritChest = copyFrom.m_BesmaritChest;
          bp.m_BesmaritSceneChests = copyFrom.m_BesmaritSceneChests;
          bp.m_BesmaritBossReward = copyFrom.m_BesmaritBossReward;
          bp.m_BesmaritReward = copyFrom.m_BesmaritReward;
          bp.m_BesmaritFinishFlag = copyFrom.m_BesmaritFinishFlag;
          bp.m_ModifierSubeffects = copyFrom.m_ModifierSubeffects;
          bp.m_AddedDCForRest = copyFrom.m_AddedDCForRest;
          bp.CrToChestCost = copyFrom.CrToChestCost;
          bp.RewardRevealFx = copyFrom.RewardRevealFx;
          bp.TrapDisabledEvent = copyFrom.TrapDisabledEvent;
          bp.TrapDisableFailedEvent = copyFrom.TrapDisableFailedEvent;
          bp.TrapInteractionStartedEvent = copyFrom.TrapInteractionStartedEvent;
          bp.TrapInteractionEndedEvent = copyFrom.TrapInteractionEndedEvent;
          bp.BoonsAvailableCount = copyFrom.BoonsAvailableCount;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintDungeonRoot>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.DebugOutput = copyFrom.DebugOutput;
          bp.Test = copyFrom.Test;
          bp.m_DungeonCampaign = copyFrom.m_DungeonCampaign;
          bp.m_Localization = copyFrom.m_Localization;
          bp.QuestItemPerStageChance = copyFrom.QuestItemPerStageChance;
          bp.m_UnitsWithQuestItems = copyFrom.m_UnitsWithQuestItems;
          bp.m_MainVendorTable = copyFrom.m_MainVendorTable;
          bp.m_DivineVendorTable = copyFrom.m_DivineVendorTable;
          bp.TravelSpeedMin = copyFrom.TravelSpeedMin;
          bp.TravelSpeedMax = copyFrom.TravelSpeedMax;
          bp.TravelTimeHours = copyFrom.TravelTimeHours;
          bp.m_MapPlayerPawnLink = copyFrom.m_MapPlayerPawnLink;
          bp.m_Maps = copyFrom.m_Maps;
          bp.MapStartIslandPawnPosition = copyFrom.MapStartIslandPawnPosition;
          bp.MapFinalIslandPawnPosition = copyFrom.MapFinalIslandPawnPosition;
          bp.MapDecorationGroups = copyFrom.MapDecorationGroups;
          bp.m_Expeditions = copyFrom.m_Expeditions;
          bp.m_Islands = copyFrom.m_Islands;
          bp.m_Modificators = copyFrom.m_Modificators;
          bp.CountOfObjectsPerModificator = copyFrom.CountOfObjectsPerModificator;
          bp.CountOfSecretRooms = copyFrom.CountOfSecretRooms;
          bp.m_Ship = copyFrom.m_Ship;
          bp.m_Port = copyFrom.m_Port;
          bp.m_RandomEncounterIslandIndexNotBefore = copyFrom.m_RandomEncounterIslandIndexNotBefore;
          bp.m_RandomEncounterChance = copyFrom.m_RandomEncounterChance;
          bp.CountOfUnitsInRandomEncounter = copyFrom.CountOfUnitsInRandomEncounter;
          bp.m_RandomEncounterArmies = copyFrom.m_RandomEncounterArmies;
          bp.ActionsOnRandomEncounter = copyFrom.ActionsOnRandomEncounter;
          bp.ExperienceMultiplierEasy = copyFrom.ExperienceMultiplierEasy;
          bp.ExperienceMultiplierNormal = copyFrom.ExperienceMultiplierNormal;
          bp.ExperienceMultiplierHard = copyFrom.ExperienceMultiplierHard;
          bp.Experience = copyFrom.Experience;
          bp.m_Tiers = copyFrom.m_Tiers;
          bp.m_Boons = copyFrom.m_Boons;
          bp.ActionsBeforeRestart = copyFrom.ActionsBeforeRestart;
          bp.ActionsAfterRestart = copyFrom.ActionsAfterRestart;
          bp.ActionsAfterChargen = copyFrom.ActionsAfterChargen;
          bp.ActionsBeforeExpeditionRestart = copyFrom.ActionsBeforeExpeditionRestart;
          bp.ActionsAfterExpeditionRestart = copyFrom.ActionsAfterExpeditionRestart;
          bp.CarryOverItemsCount = copyFrom.CarryOverItemsCount;
          bp.m_CarryOverItemsBlacklist = copyFrom.m_CarryOverItemsBlacklist;
          bp.SpreadDC = copyFrom.SpreadDC;
          bp.SavingThrowMinimalDC = copyFrom.SavingThrowMinimalDC;
          bp.SkillCheckMinimalDC = copyFrom.SkillCheckMinimalDC;
          bp.MicroBossCRBonus = copyFrom.MicroBossCRBonus;
          bp.CrToExperience = copyFrom.CrToExperience;
          bp.m_DifficultyCurves = copyFrom.m_DifficultyCurves;
          bp.m_Templates = copyFrom.m_Templates;
          bp.CountOfRandomTemplates = copyFrom.CountOfRandomTemplates;
          bp.m_DifficultyToCurve = copyFrom.m_DifficultyToCurve;
          bp.RoomEnterExcludesEnemies = copyFrom.RoomEnterExcludesEnemies;
          bp.RoomExitExcludesEnemies = copyFrom.RoomExitExcludesEnemies;
          bp.RoomArmyCountProbabilities = copyFrom.RoomArmyCountProbabilities;
          bp.SecretRoomSpecialArmyProbability = copyFrom.SecretRoomSpecialArmyProbability;
          bp.CountOfUnitsInRoom = copyFrom.CountOfUnitsInRoom;
          bp.CountOfRoomsWithUnits = copyFrom.CountOfRoomsWithUnits;
          bp.CountOfRoomsWithLoot = copyFrom.CountOfRoomsWithLoot;
          bp.CountOfChestLocked = copyFrom.CountOfChestLocked;
          bp.CountOfTraps = copyFrom.CountOfTraps;
          bp.m_MobFaction = copyFrom.m_MobFaction;
          bp.m_MobSummonPool = copyFrom.m_MobSummonPool;
          bp.RoamingProbability = copyFrom.RoamingProbability;
          bp.Roaming = copyFrom.Roaming;
          bp.m_OverrideCountByUnitTagEntries = copyFrom.m_OverrideCountByUnitTagEntries;
          bp.m_Armies = copyFrom.m_Armies;
          bp.m_TrapSpells = copyFrom.m_TrapSpells;
          bp.MinimalGoldRelativeAmountInChest = copyFrom.MinimalGoldRelativeAmountInChest;
          bp.m_Loot = copyFrom.m_Loot;
          bp.m_LootContainers = copyFrom.m_LootContainers;
          bp.m_BesmaritBossIsland = copyFrom.m_BesmaritBossIsland;
          bp.m_BesmaritModificator = copyFrom.m_BesmaritModificator;
          bp.m_BesmaritIslands = copyFrom.m_BesmaritIslands;
          bp.m_BesmaritChest = copyFrom.m_BesmaritChest;
          bp.m_BesmaritSceneChests = copyFrom.m_BesmaritSceneChests;
          bp.m_BesmaritBossReward = copyFrom.m_BesmaritBossReward;
          bp.m_BesmaritReward = copyFrom.m_BesmaritReward;
          bp.m_BesmaritFinishFlag = copyFrom.m_BesmaritFinishFlag;
          bp.m_ModifierSubeffects = copyFrom.m_ModifierSubeffects;
          bp.m_AddedDCForRest = copyFrom.m_AddedDCForRest;
          bp.CrToChestCost = copyFrom.CrToChestCost;
          bp.RewardRevealFx = copyFrom.RewardRevealFx;
          bp.TrapDisabledEvent = copyFrom.TrapDisabledEvent;
          bp.TrapDisableFailedEvent = copyFrom.TrapDisableFailedEvent;
          bp.TrapInteractionStartedEvent = copyFrom.TrapInteractionStartedEvent;
          bp.TrapInteractionEndedEvent = copyFrom.TrapInteractionEndedEvent;
          bp.BoonsAvailableCount = copyFrom.BoonsAvailableCount;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.DebugOutput"/>
    /// </summary>
    public TBuilder SetDebugOutput(BlueprintDungeonRoot.DebugOutputSettings debugOutput)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(debugOutput);
          bp.DebugOutput = debugOutput;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.DebugOutput"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDebugOutput(Action<BlueprintDungeonRoot.DebugOutputSettings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DebugOutput is null) { return; }
          action.Invoke(bp.DebugOutput);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.Test"/>
    /// </summary>
    public TBuilder SetTest(BlueprintDungeonRoot.TestSettings test)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(test);
          bp.Test = test;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.Test"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTest(Action<BlueprintDungeonRoot.TestSettings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Test is null) { return; }
          action.Invoke(bp.Test);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_DungeonCampaign"/>
    /// </summary>
    ///
    /// <param name="dungeonCampaign">
    /// <para>
    /// Blueprint of type BlueprintDungeonCampaign. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetDungeonCampaign(Blueprint<BlueprintDungeonCampaignReference> dungeonCampaign)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DungeonCampaign = dungeonCampaign?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_DungeonCampaign"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDungeonCampaign(Action<BlueprintDungeonCampaignReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DungeonCampaign is null) { return; }
          action.Invoke(bp.m_DungeonCampaign);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_Localization"/>
    /// </summary>
    ///
    /// <param name="localization">
    /// <para>
    /// Blueprint of type BlueprintDungeonLocalizedStrings. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetLocalization(Blueprint<BlueprintDungeonLocalizedStringsReference> localization)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Localization = localization?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_Localization"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLocalization(Action<BlueprintDungeonLocalizedStringsReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Localization is null) { return; }
          action.Invoke(bp.m_Localization);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.QuestItemPerStageChance"/>
    /// </summary>
    public TBuilder SetQuestItemPerStageChance(int questItemPerStageChance)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.QuestItemPerStageChance = questItemPerStageChance;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_UnitsWithQuestItems"/>
    /// </summary>
    ///
    /// <param name="unitsWithQuestItems">
    /// <para>
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetUnitsWithQuestItems(Blueprint<BlueprintSummonPoolReference> unitsWithQuestItems)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_UnitsWithQuestItems = unitsWithQuestItems?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_UnitsWithQuestItems"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUnitsWithQuestItems(Action<BlueprintSummonPoolReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_UnitsWithQuestItems is null) { return; }
          action.Invoke(bp.m_UnitsWithQuestItems);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_MainVendorTable"/>
    /// </summary>
    ///
    /// <param name="mainVendorTable">
    /// <para>
    /// Blueprint of type BlueprintSharedVendorTable. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetMainVendorTable(Blueprint<BlueprintSharedVendorTableReference> mainVendorTable)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MainVendorTable = mainVendorTable?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_MainVendorTable"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMainVendorTable(Action<BlueprintSharedVendorTableReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MainVendorTable is null) { return; }
          action.Invoke(bp.m_MainVendorTable);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_DivineVendorTable"/>
    /// </summary>
    ///
    /// <param name="divineVendorTable">
    /// <para>
    /// Blueprint of type BlueprintSharedVendorTable. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetDivineVendorTable(Blueprint<BlueprintSharedVendorTableReference> divineVendorTable)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DivineVendorTable = divineVendorTable?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_DivineVendorTable"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDivineVendorTable(Action<BlueprintSharedVendorTableReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DivineVendorTable is null) { return; }
          action.Invoke(bp.m_DivineVendorTable);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.TravelSpeedMin"/>
    /// </summary>
    public TBuilder SetTravelSpeedMin(float travelSpeedMin)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TravelSpeedMin = travelSpeedMin;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.TravelSpeedMax"/>
    /// </summary>
    public TBuilder SetTravelSpeedMax(float travelSpeedMax)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TravelSpeedMax = travelSpeedMax;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.TravelTimeHours"/>
    /// </summary>
    public TBuilder SetTravelTimeHours(int travelTimeHours)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TravelTimeHours = travelTimeHours;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_MapPlayerPawnLink"/>
    /// </summary>
    ///
    /// <param name="mapPlayerPawnLink">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder SetMapPlayerPawnLink(AssetLink<SpriteLink> mapPlayerPawnLink)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MapPlayerPawnLink = mapPlayerPawnLink?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_MapPlayerPawnLink"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMapPlayerPawnLink(Action<SpriteLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MapPlayerPawnLink is null) { return; }
          action.Invoke(bp.m_MapPlayerPawnLink);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_Maps"/>
    /// </summary>
    ///
    /// <param name="maps">
    /// <para>
    /// Blueprint of type BlueprintDungeonMap. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetMaps(params Blueprint<BlueprintDungeonMapReference>[] maps)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Maps = maps.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.m_Maps"/>
    /// </summary>
    ///
    /// <param name="maps">
    /// <para>
    /// Blueprint of type BlueprintDungeonMap. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToMaps(params Blueprint<BlueprintDungeonMapReference>[] maps)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Maps = bp.m_Maps ?? new BlueprintDungeonMapReference[0];
          bp.m_Maps = CommonTool.Append(bp.m_Maps, maps.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_Maps"/>
    /// </summary>
    ///
    /// <param name="maps">
    /// <para>
    /// Blueprint of type BlueprintDungeonMap. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromMaps(params Blueprint<BlueprintDungeonMapReference>[] maps)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Maps is null) { return; }
          bp.m_Maps = bp.m_Maps.Where(val => !maps.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_Maps"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromMaps(Func<BlueprintDungeonMapReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Maps is null) { return; }
          bp.m_Maps = bp.m_Maps.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.m_Maps"/>
    /// </summary>
    public TBuilder ClearMaps()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Maps = new BlueprintDungeonMapReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_Maps"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyMaps(Action<BlueprintDungeonMapReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Maps is null) { return; }
          bp.m_Maps.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.MapStartIslandPawnPosition"/>
    /// </summary>
    ///
    /// <param name="mapStartIslandPawnPosition">
    /// <para>
    /// Tooltip: Pawn start position. 0 is for the topmost position, 1 is for bottommost position.
    /// </para>
    /// </param>
    public TBuilder SetMapStartIslandPawnPosition(Vector2 mapStartIslandPawnPosition)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MapStartIslandPawnPosition = mapStartIslandPawnPosition;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.MapStartIslandPawnPosition"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMapStartIslandPawnPosition(Action<Vector2> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MapStartIslandPawnPosition);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.MapFinalIslandPawnPosition"/>
    /// </summary>
    ///
    /// <param name="mapFinalIslandPawnPosition">
    /// <para>
    /// Tooltip: Pawn end position. 0 is for the topmost position, 1 is for bottommost position.
    /// </para>
    /// </param>
    public TBuilder SetMapFinalIslandPawnPosition(Vector2 mapFinalIslandPawnPosition)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MapFinalIslandPawnPosition = mapFinalIslandPawnPosition;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.MapFinalIslandPawnPosition"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMapFinalIslandPawnPosition(Action<Vector2> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MapFinalIslandPawnPosition);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.MapDecorationGroups"/>
    /// </summary>
    public TBuilder SetMapDecorationGroups(params BlueprintDungeonRoot.MapDecorationGroup[] mapDecorationGroups)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(mapDecorationGroups);
          bp.MapDecorationGroups = mapDecorationGroups;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.MapDecorationGroups"/>
    /// </summary>
    public TBuilder AddToMapDecorationGroups(params BlueprintDungeonRoot.MapDecorationGroup[] mapDecorationGroups)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MapDecorationGroups = bp.MapDecorationGroups ?? new BlueprintDungeonRoot.MapDecorationGroup[0];
          bp.MapDecorationGroups = CommonTool.Append(bp.MapDecorationGroups, mapDecorationGroups);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.MapDecorationGroups"/>
    /// </summary>
    public TBuilder RemoveFromMapDecorationGroups(params BlueprintDungeonRoot.MapDecorationGroup[] mapDecorationGroups)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.MapDecorationGroups is null) { return; }
          bp.MapDecorationGroups = bp.MapDecorationGroups.Where(val => !mapDecorationGroups.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.MapDecorationGroups"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromMapDecorationGroups(Func<BlueprintDungeonRoot.MapDecorationGroup, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.MapDecorationGroups is null) { return; }
          bp.MapDecorationGroups = bp.MapDecorationGroups.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.MapDecorationGroups"/>
    /// </summary>
    public TBuilder ClearMapDecorationGroups()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MapDecorationGroups = new BlueprintDungeonRoot.MapDecorationGroup[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.MapDecorationGroups"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyMapDecorationGroups(Action<BlueprintDungeonRoot.MapDecorationGroup> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.MapDecorationGroups is null) { return; }
          bp.MapDecorationGroups.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_Expeditions"/>
    /// </summary>
    ///
    /// <param name="expeditions">
    /// <para>
    /// Blueprint of type BlueprintDungeonExpedition. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetExpeditions(params Blueprint<BlueprintDungeonExpeditionReference>[] expeditions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Expeditions = expeditions.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.m_Expeditions"/>
    /// </summary>
    ///
    /// <param name="expeditions">
    /// <para>
    /// Blueprint of type BlueprintDungeonExpedition. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToExpeditions(params Blueprint<BlueprintDungeonExpeditionReference>[] expeditions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Expeditions = bp.m_Expeditions ?? new BlueprintDungeonExpeditionReference[0];
          bp.m_Expeditions = CommonTool.Append(bp.m_Expeditions, expeditions.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_Expeditions"/>
    /// </summary>
    ///
    /// <param name="expeditions">
    /// <para>
    /// Blueprint of type BlueprintDungeonExpedition. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromExpeditions(params Blueprint<BlueprintDungeonExpeditionReference>[] expeditions)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Expeditions is null) { return; }
          bp.m_Expeditions = bp.m_Expeditions.Where(val => !expeditions.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_Expeditions"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromExpeditions(Func<BlueprintDungeonExpeditionReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Expeditions is null) { return; }
          bp.m_Expeditions = bp.m_Expeditions.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.m_Expeditions"/>
    /// </summary>
    public TBuilder ClearExpeditions()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Expeditions = new BlueprintDungeonExpeditionReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_Expeditions"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyExpeditions(Action<BlueprintDungeonExpeditionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Expeditions is null) { return; }
          bp.m_Expeditions.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_Islands"/>
    /// </summary>
    ///
    /// <param name="islands">
    /// <para>
    /// Tooltip: Islands to choose from.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonIsland. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetIslands(params Blueprint<BlueprintDungeonIslandReference>[] islands)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Islands = islands.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.m_Islands"/>
    /// </summary>
    ///
    /// <param name="islands">
    /// <para>
    /// Tooltip: Islands to choose from.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonIsland. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToIslands(params Blueprint<BlueprintDungeonIslandReference>[] islands)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Islands = bp.m_Islands ?? new BlueprintDungeonIslandReference[0];
          bp.m_Islands = CommonTool.Append(bp.m_Islands, islands.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_Islands"/>
    /// </summary>
    ///
    /// <param name="islands">
    /// <para>
    /// Tooltip: Islands to choose from.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonIsland. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromIslands(params Blueprint<BlueprintDungeonIslandReference>[] islands)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Islands is null) { return; }
          bp.m_Islands = bp.m_Islands.Where(val => !islands.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_Islands"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromIslands(Func<BlueprintDungeonIslandReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Islands is null) { return; }
          bp.m_Islands = bp.m_Islands.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.m_Islands"/>
    /// </summary>
    public TBuilder ClearIslands()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Islands = new BlueprintDungeonIslandReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_Islands"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyIslands(Action<BlueprintDungeonIslandReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Islands is null) { return; }
          bp.m_Islands.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_Modificators"/>
    /// </summary>
    ///
    /// <param name="modificators">
    /// <para>
    /// Blueprint of type BlueprintDungeonModificator. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetModificators(params Blueprint<BlueprintDungeonModificatorReference>[] modificators)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Modificators = modificators.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.m_Modificators"/>
    /// </summary>
    ///
    /// <param name="modificators">
    /// <para>
    /// Blueprint of type BlueprintDungeonModificator. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToModificators(params Blueprint<BlueprintDungeonModificatorReference>[] modificators)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Modificators = bp.m_Modificators ?? new BlueprintDungeonModificatorReference[0];
          bp.m_Modificators = CommonTool.Append(bp.m_Modificators, modificators.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_Modificators"/>
    /// </summary>
    ///
    /// <param name="modificators">
    /// <para>
    /// Blueprint of type BlueprintDungeonModificator. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromModificators(params Blueprint<BlueprintDungeonModificatorReference>[] modificators)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Modificators is null) { return; }
          bp.m_Modificators = bp.m_Modificators.Where(val => !modificators.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_Modificators"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromModificators(Func<BlueprintDungeonModificatorReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Modificators is null) { return; }
          bp.m_Modificators = bp.m_Modificators.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.m_Modificators"/>
    /// </summary>
    public TBuilder ClearModificators()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Modificators = new BlueprintDungeonModificatorReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_Modificators"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyModificators(Action<BlueprintDungeonModificatorReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Modificators is null) { return; }
          bp.m_Modificators.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.CountOfObjectsPerModificator"/>
    /// </summary>
    public TBuilder SetCountOfObjectsPerModificator(params IntegerWeighted[] countOfObjectsPerModificator)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(countOfObjectsPerModificator);
          bp.CountOfObjectsPerModificator = countOfObjectsPerModificator;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.CountOfObjectsPerModificator"/>
    /// </summary>
    public TBuilder AddToCountOfObjectsPerModificator(params IntegerWeighted[] countOfObjectsPerModificator)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CountOfObjectsPerModificator = bp.CountOfObjectsPerModificator ?? new IntegerWeighted[0];
          bp.CountOfObjectsPerModificator = CommonTool.Append(bp.CountOfObjectsPerModificator, countOfObjectsPerModificator);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.CountOfObjectsPerModificator"/>
    /// </summary>
    public TBuilder RemoveFromCountOfObjectsPerModificator(params IntegerWeighted[] countOfObjectsPerModificator)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfObjectsPerModificator is null) { return; }
          bp.CountOfObjectsPerModificator = bp.CountOfObjectsPerModificator.Where(val => !countOfObjectsPerModificator.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.CountOfObjectsPerModificator"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCountOfObjectsPerModificator(Func<IntegerWeighted, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfObjectsPerModificator is null) { return; }
          bp.CountOfObjectsPerModificator = bp.CountOfObjectsPerModificator.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.CountOfObjectsPerModificator"/>
    /// </summary>
    public TBuilder ClearCountOfObjectsPerModificator()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CountOfObjectsPerModificator = new IntegerWeighted[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.CountOfObjectsPerModificator"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCountOfObjectsPerModificator(Action<IntegerWeighted> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfObjectsPerModificator is null) { return; }
          bp.CountOfObjectsPerModificator.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.CountOfSecretRooms"/>
    /// </summary>
    public TBuilder SetCountOfSecretRooms(params IntegerWeighted[] countOfSecretRooms)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(countOfSecretRooms);
          bp.CountOfSecretRooms = countOfSecretRooms;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.CountOfSecretRooms"/>
    /// </summary>
    public TBuilder AddToCountOfSecretRooms(params IntegerWeighted[] countOfSecretRooms)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CountOfSecretRooms = bp.CountOfSecretRooms ?? new IntegerWeighted[0];
          bp.CountOfSecretRooms = CommonTool.Append(bp.CountOfSecretRooms, countOfSecretRooms);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.CountOfSecretRooms"/>
    /// </summary>
    public TBuilder RemoveFromCountOfSecretRooms(params IntegerWeighted[] countOfSecretRooms)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfSecretRooms is null) { return; }
          bp.CountOfSecretRooms = bp.CountOfSecretRooms.Where(val => !countOfSecretRooms.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.CountOfSecretRooms"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCountOfSecretRooms(Func<IntegerWeighted, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfSecretRooms is null) { return; }
          bp.CountOfSecretRooms = bp.CountOfSecretRooms.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.CountOfSecretRooms"/>
    /// </summary>
    public TBuilder ClearCountOfSecretRooms()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CountOfSecretRooms = new IntegerWeighted[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.CountOfSecretRooms"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCountOfSecretRooms(Action<IntegerWeighted> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfSecretRooms is null) { return; }
          bp.CountOfSecretRooms.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_Ship"/>
    /// </summary>
    ///
    /// <param name="ship">
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetShip(Blueprint<BlueprintAreaReference> ship)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Ship = ship?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_Ship"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyShip(Action<BlueprintAreaReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Ship is null) { return; }
          action.Invoke(bp.m_Ship);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_Port"/>
    /// </summary>
    ///
    /// <param name="port">
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetPort(Blueprint<BlueprintAreaReference> port)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Port = port?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_Port"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPort(Action<BlueprintAreaReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Port is null) { return; }
          action.Invoke(bp.m_Port);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_RandomEncounterIslandIndexNotBefore"/>
    /// </summary>
    public TBuilder SetRandomEncounterIslandIndexNotBefore(int randomEncounterIslandIndexNotBefore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_RandomEncounterIslandIndexNotBefore = randomEncounterIslandIndexNotBefore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_RandomEncounterChance"/>
    /// </summary>
    public TBuilder SetRandomEncounterChance(float randomEncounterChance)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_RandomEncounterChance = randomEncounterChance;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.CountOfUnitsInRandomEncounter"/>
    /// </summary>
    public TBuilder SetCountOfUnitsInRandomEncounter(params IntegerWeighted[] countOfUnitsInRandomEncounter)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(countOfUnitsInRandomEncounter);
          bp.CountOfUnitsInRandomEncounter = countOfUnitsInRandomEncounter;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.CountOfUnitsInRandomEncounter"/>
    /// </summary>
    public TBuilder AddToCountOfUnitsInRandomEncounter(params IntegerWeighted[] countOfUnitsInRandomEncounter)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CountOfUnitsInRandomEncounter = bp.CountOfUnitsInRandomEncounter ?? new IntegerWeighted[0];
          bp.CountOfUnitsInRandomEncounter = CommonTool.Append(bp.CountOfUnitsInRandomEncounter, countOfUnitsInRandomEncounter);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.CountOfUnitsInRandomEncounter"/>
    /// </summary>
    public TBuilder RemoveFromCountOfUnitsInRandomEncounter(params IntegerWeighted[] countOfUnitsInRandomEncounter)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfUnitsInRandomEncounter is null) { return; }
          bp.CountOfUnitsInRandomEncounter = bp.CountOfUnitsInRandomEncounter.Where(val => !countOfUnitsInRandomEncounter.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.CountOfUnitsInRandomEncounter"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCountOfUnitsInRandomEncounter(Func<IntegerWeighted, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfUnitsInRandomEncounter is null) { return; }
          bp.CountOfUnitsInRandomEncounter = bp.CountOfUnitsInRandomEncounter.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.CountOfUnitsInRandomEncounter"/>
    /// </summary>
    public TBuilder ClearCountOfUnitsInRandomEncounter()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CountOfUnitsInRandomEncounter = new IntegerWeighted[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.CountOfUnitsInRandomEncounter"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCountOfUnitsInRandomEncounter(Action<IntegerWeighted> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfUnitsInRandomEncounter is null) { return; }
          bp.CountOfUnitsInRandomEncounter.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_RandomEncounterArmies"/>
    /// </summary>
    ///
    /// <param name="randomEncounterArmies">
    /// <para>
    /// Blueprint of type BlueprintDungeonArmy. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetRandomEncounterArmies(params Blueprint<BlueprintDungeonArmyReference>[] randomEncounterArmies)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_RandomEncounterArmies = randomEncounterArmies.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.m_RandomEncounterArmies"/>
    /// </summary>
    ///
    /// <param name="randomEncounterArmies">
    /// <para>
    /// Blueprint of type BlueprintDungeonArmy. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToRandomEncounterArmies(params Blueprint<BlueprintDungeonArmyReference>[] randomEncounterArmies)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_RandomEncounterArmies = bp.m_RandomEncounterArmies ?? new BlueprintDungeonArmyReference[0];
          bp.m_RandomEncounterArmies = CommonTool.Append(bp.m_RandomEncounterArmies, randomEncounterArmies.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_RandomEncounterArmies"/>
    /// </summary>
    ///
    /// <param name="randomEncounterArmies">
    /// <para>
    /// Blueprint of type BlueprintDungeonArmy. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromRandomEncounterArmies(params Blueprint<BlueprintDungeonArmyReference>[] randomEncounterArmies)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_RandomEncounterArmies is null) { return; }
          bp.m_RandomEncounterArmies = bp.m_RandomEncounterArmies.Where(val => !randomEncounterArmies.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_RandomEncounterArmies"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromRandomEncounterArmies(Func<BlueprintDungeonArmyReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_RandomEncounterArmies is null) { return; }
          bp.m_RandomEncounterArmies = bp.m_RandomEncounterArmies.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.m_RandomEncounterArmies"/>
    /// </summary>
    public TBuilder ClearRandomEncounterArmies()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_RandomEncounterArmies = new BlueprintDungeonArmyReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_RandomEncounterArmies"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyRandomEncounterArmies(Action<BlueprintDungeonArmyReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_RandomEncounterArmies is null) { return; }
          bp.m_RandomEncounterArmies.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.ActionsOnRandomEncounter"/>
    /// </summary>
    public TBuilder SetActionsOnRandomEncounter(ActionsBuilder actionsOnRandomEncounter)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ActionsOnRandomEncounter = actionsOnRandomEncounter?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.ActionsOnRandomEncounter"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyActionsOnRandomEncounter(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ActionsOnRandomEncounter is null) { return; }
          action.Invoke(bp.ActionsOnRandomEncounter);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.ExperienceMultiplierEasy"/>
    /// </summary>
    public TBuilder SetExperienceMultiplierEasy(float experienceMultiplierEasy)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ExperienceMultiplierEasy = experienceMultiplierEasy;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.ExperienceMultiplierNormal"/>
    /// </summary>
    public TBuilder SetExperienceMultiplierNormal(float experienceMultiplierNormal)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ExperienceMultiplierNormal = experienceMultiplierNormal;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.ExperienceMultiplierHard"/>
    /// </summary>
    public TBuilder SetExperienceMultiplierHard(float experienceMultiplierHard)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ExperienceMultiplierHard = experienceMultiplierHard;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.Experience"/>
    /// </summary>
    ///
    /// <param name="experience">
    /// <para>
    /// Tooltip: Experience per island
    /// </para>
    /// </param>
    public TBuilder SetExperience(params int[] experience)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Experience = experience;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.Experience"/>
    /// </summary>
    ///
    /// <param name="experience">
    /// <para>
    /// Tooltip: Experience per island
    /// </para>
    /// </param>
    public TBuilder AddToExperience(params int[] experience)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Experience = bp.Experience ?? new int[0];
          bp.Experience = CommonTool.Append(bp.Experience, experience);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.Experience"/>
    /// </summary>
    ///
    /// <param name="experience">
    /// <para>
    /// Tooltip: Experience per island
    /// </para>
    /// </param>
    public TBuilder RemoveFromExperience(params int[] experience)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Experience is null) { return; }
          bp.Experience = bp.Experience.Where(val => !experience.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.Experience"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromExperience(Func<int, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Experience is null) { return; }
          bp.Experience = bp.Experience.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.Experience"/>
    /// </summary>
    public TBuilder ClearExperience()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Experience = new int[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.Experience"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyExperience(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Experience is null) { return; }
          bp.Experience.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_Tiers"/>
    /// </summary>
    ///
    /// <param name="tiers">
    /// <para>
    /// Blueprint of type BlueprintDungeonTier. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetTiers(params Blueprint<BlueprintDungeonTierReference>[] tiers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Tiers = tiers.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.m_Tiers"/>
    /// </summary>
    ///
    /// <param name="tiers">
    /// <para>
    /// Blueprint of type BlueprintDungeonTier. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToTiers(params Blueprint<BlueprintDungeonTierReference>[] tiers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Tiers = bp.m_Tiers ?? new BlueprintDungeonTierReference[0];
          bp.m_Tiers = CommonTool.Append(bp.m_Tiers, tiers.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_Tiers"/>
    /// </summary>
    ///
    /// <param name="tiers">
    /// <para>
    /// Blueprint of type BlueprintDungeonTier. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromTiers(params Blueprint<BlueprintDungeonTierReference>[] tiers)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Tiers is null) { return; }
          bp.m_Tiers = bp.m_Tiers.Where(val => !tiers.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_Tiers"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromTiers(Func<BlueprintDungeonTierReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Tiers is null) { return; }
          bp.m_Tiers = bp.m_Tiers.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.m_Tiers"/>
    /// </summary>
    public TBuilder ClearTiers()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Tiers = new BlueprintDungeonTierReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_Tiers"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyTiers(Action<BlueprintDungeonTierReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Tiers is null) { return; }
          bp.m_Tiers.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_Boons"/>
    /// </summary>
    ///
    /// <param name="boons">
    /// <para>
    /// Blueprint of type BlueprintDungeonBoon. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBoons(params Blueprint<Kingmaker.Dungeon.Blueprints.BlueprintDungeonBoonReference>[] boons)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Boons = boons.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.m_Boons"/>
    /// </summary>
    ///
    /// <param name="boons">
    /// <para>
    /// Blueprint of type BlueprintDungeonBoon. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToBoons(params Blueprint<Kingmaker.Dungeon.Blueprints.BlueprintDungeonBoonReference>[] boons)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Boons = bp.m_Boons ?? new Kingmaker.Dungeon.Blueprints.BlueprintDungeonBoonReference[0];
          bp.m_Boons = CommonTool.Append(bp.m_Boons, boons.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_Boons"/>
    /// </summary>
    ///
    /// <param name="boons">
    /// <para>
    /// Blueprint of type BlueprintDungeonBoon. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromBoons(params Blueprint<Kingmaker.Dungeon.Blueprints.BlueprintDungeonBoonReference>[] boons)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Boons is null) { return; }
          bp.m_Boons = bp.m_Boons.Where(val => !boons.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_Boons"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromBoons(Func<Kingmaker.Dungeon.Blueprints.BlueprintDungeonBoonReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Boons is null) { return; }
          bp.m_Boons = bp.m_Boons.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.m_Boons"/>
    /// </summary>
    public TBuilder ClearBoons()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Boons = new Kingmaker.Dungeon.Blueprints.BlueprintDungeonBoonReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_Boons"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyBoons(Action<Kingmaker.Dungeon.Blueprints.BlueprintDungeonBoonReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Boons is null) { return; }
          bp.m_Boons.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.ActionsBeforeRestart"/>
    /// </summary>
    public TBuilder SetActionsBeforeRestart(ActionsBuilder actionsBeforeRestart)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ActionsBeforeRestart = actionsBeforeRestart?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.ActionsBeforeRestart"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyActionsBeforeRestart(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ActionsBeforeRestart is null) { return; }
          action.Invoke(bp.ActionsBeforeRestart);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.ActionsAfterRestart"/>
    /// </summary>
    public TBuilder SetActionsAfterRestart(ActionsBuilder actionsAfterRestart)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ActionsAfterRestart = actionsAfterRestart?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.ActionsAfterRestart"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyActionsAfterRestart(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ActionsAfterRestart is null) { return; }
          action.Invoke(bp.ActionsAfterRestart);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.ActionsAfterChargen"/>
    /// </summary>
    public TBuilder SetActionsAfterChargen(ActionsBuilder actionsAfterChargen)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ActionsAfterChargen = actionsAfterChargen?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.ActionsAfterChargen"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyActionsAfterChargen(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ActionsAfterChargen is null) { return; }
          action.Invoke(bp.ActionsAfterChargen);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.ActionsBeforeExpeditionRestart"/>
    /// </summary>
    public TBuilder SetActionsBeforeExpeditionRestart(ActionsBuilder actionsBeforeExpeditionRestart)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ActionsBeforeExpeditionRestart = actionsBeforeExpeditionRestart?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.ActionsBeforeExpeditionRestart"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyActionsBeforeExpeditionRestart(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ActionsBeforeExpeditionRestart is null) { return; }
          action.Invoke(bp.ActionsBeforeExpeditionRestart);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.ActionsAfterExpeditionRestart"/>
    /// </summary>
    public TBuilder SetActionsAfterExpeditionRestart(ActionsBuilder actionsAfterExpeditionRestart)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ActionsAfterExpeditionRestart = actionsAfterExpeditionRestart?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.ActionsAfterExpeditionRestart"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyActionsAfterExpeditionRestart(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ActionsAfterExpeditionRestart is null) { return; }
          action.Invoke(bp.ActionsAfterExpeditionRestart);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.CarryOverItemsCount"/>
    /// </summary>
    public TBuilder SetCarryOverItemsCount(int carryOverItemsCount)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CarryOverItemsCount = carryOverItemsCount;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_CarryOverItemsBlacklist"/>
    /// </summary>
    ///
    /// <param name="carryOverItemsBlacklist">
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
    public TBuilder SetCarryOverItemsBlacklist(params Blueprint<BlueprintItemReference>[] carryOverItemsBlacklist)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CarryOverItemsBlacklist = carryOverItemsBlacklist.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.m_CarryOverItemsBlacklist"/>
    /// </summary>
    ///
    /// <param name="carryOverItemsBlacklist">
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
    public TBuilder AddToCarryOverItemsBlacklist(params Blueprint<BlueprintItemReference>[] carryOverItemsBlacklist)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CarryOverItemsBlacklist = bp.m_CarryOverItemsBlacklist ?? new BlueprintItemReference[0];
          bp.m_CarryOverItemsBlacklist = CommonTool.Append(bp.m_CarryOverItemsBlacklist, carryOverItemsBlacklist.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_CarryOverItemsBlacklist"/>
    /// </summary>
    ///
    /// <param name="carryOverItemsBlacklist">
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
    public TBuilder RemoveFromCarryOverItemsBlacklist(params Blueprint<BlueprintItemReference>[] carryOverItemsBlacklist)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CarryOverItemsBlacklist is null) { return; }
          bp.m_CarryOverItemsBlacklist = bp.m_CarryOverItemsBlacklist.Where(val => !carryOverItemsBlacklist.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_CarryOverItemsBlacklist"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCarryOverItemsBlacklist(Func<BlueprintItemReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CarryOverItemsBlacklist is null) { return; }
          bp.m_CarryOverItemsBlacklist = bp.m_CarryOverItemsBlacklist.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.m_CarryOverItemsBlacklist"/>
    /// </summary>
    public TBuilder ClearCarryOverItemsBlacklist()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CarryOverItemsBlacklist = new BlueprintItemReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_CarryOverItemsBlacklist"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCarryOverItemsBlacklist(Action<BlueprintItemReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CarryOverItemsBlacklist is null) { return; }
          bp.m_CarryOverItemsBlacklist.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.SpreadDC"/>
    /// </summary>
    public TBuilder SetSpreadDC(int spreadDC)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SpreadDC = spreadDC;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.SavingThrowMinimalDC"/>
    /// </summary>
    public TBuilder SetSavingThrowMinimalDC(int savingThrowMinimalDC)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SavingThrowMinimalDC = savingThrowMinimalDC;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.SkillCheckMinimalDC"/>
    /// </summary>
    public TBuilder SetSkillCheckMinimalDC(int skillCheckMinimalDC)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SkillCheckMinimalDC = skillCheckMinimalDC;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.MicroBossCRBonus"/>
    /// </summary>
    public TBuilder SetMicroBossCRBonus(int microBossCRBonus)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MicroBossCRBonus = microBossCRBonus;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.CrToExperience"/>
    /// </summary>
    public TBuilder SetCrToExperience(params int[] crToExperience)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CrToExperience = crToExperience;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.CrToExperience"/>
    /// </summary>
    public TBuilder AddToCrToExperience(params int[] crToExperience)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CrToExperience = bp.CrToExperience ?? new int[0];
          bp.CrToExperience = CommonTool.Append(bp.CrToExperience, crToExperience);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.CrToExperience"/>
    /// </summary>
    public TBuilder RemoveFromCrToExperience(params int[] crToExperience)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CrToExperience is null) { return; }
          bp.CrToExperience = bp.CrToExperience.Where(val => !crToExperience.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.CrToExperience"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCrToExperience(Func<int, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CrToExperience is null) { return; }
          bp.CrToExperience = bp.CrToExperience.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.CrToExperience"/>
    /// </summary>
    public TBuilder ClearCrToExperience()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CrToExperience = new int[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.CrToExperience"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCrToExperience(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CrToExperience is null) { return; }
          bp.CrToExperience.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_DifficultyCurves"/>
    /// </summary>
    ///
    /// <param name="difficultyCurves">
    /// <para>
    /// Blueprint of type BlueprintDungeonDifficultyCurve. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetDifficultyCurves(params Blueprint<BlueprintDungeonDifficultyCurveReference>[] difficultyCurves)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DifficultyCurves = difficultyCurves.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.m_DifficultyCurves"/>
    /// </summary>
    ///
    /// <param name="difficultyCurves">
    /// <para>
    /// Blueprint of type BlueprintDungeonDifficultyCurve. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToDifficultyCurves(params Blueprint<BlueprintDungeonDifficultyCurveReference>[] difficultyCurves)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DifficultyCurves = bp.m_DifficultyCurves ?? new BlueprintDungeonDifficultyCurveReference[0];
          bp.m_DifficultyCurves = CommonTool.Append(bp.m_DifficultyCurves, difficultyCurves.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_DifficultyCurves"/>
    /// </summary>
    ///
    /// <param name="difficultyCurves">
    /// <para>
    /// Blueprint of type BlueprintDungeonDifficultyCurve. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromDifficultyCurves(params Blueprint<BlueprintDungeonDifficultyCurveReference>[] difficultyCurves)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DifficultyCurves is null) { return; }
          bp.m_DifficultyCurves = bp.m_DifficultyCurves.Where(val => !difficultyCurves.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_DifficultyCurves"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromDifficultyCurves(Func<BlueprintDungeonDifficultyCurveReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DifficultyCurves is null) { return; }
          bp.m_DifficultyCurves = bp.m_DifficultyCurves.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.m_DifficultyCurves"/>
    /// </summary>
    public TBuilder ClearDifficultyCurves()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DifficultyCurves = new BlueprintDungeonDifficultyCurveReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_DifficultyCurves"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyDifficultyCurves(Action<BlueprintDungeonDifficultyCurveReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DifficultyCurves is null) { return; }
          bp.m_DifficultyCurves.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_Templates"/>
    /// </summary>
    ///
    /// <param name="templates">
    /// <para>
    /// Blueprint of type BlueprintUnitTemplate. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetTemplates(params Blueprint<BlueprintUnitTemplateReference>[] templates)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Templates = templates.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.m_Templates"/>
    /// </summary>
    ///
    /// <param name="templates">
    /// <para>
    /// Blueprint of type BlueprintUnitTemplate. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToTemplates(params Blueprint<BlueprintUnitTemplateReference>[] templates)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Templates = bp.m_Templates ?? new BlueprintUnitTemplateReference[0];
          bp.m_Templates = CommonTool.Append(bp.m_Templates, templates.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_Templates"/>
    /// </summary>
    ///
    /// <param name="templates">
    /// <para>
    /// Blueprint of type BlueprintUnitTemplate. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromTemplates(params Blueprint<BlueprintUnitTemplateReference>[] templates)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Templates is null) { return; }
          bp.m_Templates = bp.m_Templates.Where(val => !templates.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_Templates"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromTemplates(Func<BlueprintUnitTemplateReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Templates is null) { return; }
          bp.m_Templates = bp.m_Templates.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.m_Templates"/>
    /// </summary>
    public TBuilder ClearTemplates()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Templates = new BlueprintUnitTemplateReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_Templates"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyTemplates(Action<BlueprintUnitTemplateReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Templates is null) { return; }
          bp.m_Templates.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.CountOfRandomTemplates"/>
    /// </summary>
    ///
    /// <param name="countOfRandomTemplates">
    /// <para>
    /// Tooltip: For diversity templates can be applied to random units even if there are enough other units in the army with the CR necessary.
    /// </para>
    /// </param>
    public TBuilder SetCountOfRandomTemplates(params IntegerWeighted[] countOfRandomTemplates)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(countOfRandomTemplates);
          bp.CountOfRandomTemplates = countOfRandomTemplates;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.CountOfRandomTemplates"/>
    /// </summary>
    ///
    /// <param name="countOfRandomTemplates">
    /// <para>
    /// Tooltip: For diversity templates can be applied to random units even if there are enough other units in the army with the CR necessary.
    /// </para>
    /// </param>
    public TBuilder AddToCountOfRandomTemplates(params IntegerWeighted[] countOfRandomTemplates)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CountOfRandomTemplates = bp.CountOfRandomTemplates ?? new IntegerWeighted[0];
          bp.CountOfRandomTemplates = CommonTool.Append(bp.CountOfRandomTemplates, countOfRandomTemplates);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.CountOfRandomTemplates"/>
    /// </summary>
    ///
    /// <param name="countOfRandomTemplates">
    /// <para>
    /// Tooltip: For diversity templates can be applied to random units even if there are enough other units in the army with the CR necessary.
    /// </para>
    /// </param>
    public TBuilder RemoveFromCountOfRandomTemplates(params IntegerWeighted[] countOfRandomTemplates)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfRandomTemplates is null) { return; }
          bp.CountOfRandomTemplates = bp.CountOfRandomTemplates.Where(val => !countOfRandomTemplates.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.CountOfRandomTemplates"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCountOfRandomTemplates(Func<IntegerWeighted, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfRandomTemplates is null) { return; }
          bp.CountOfRandomTemplates = bp.CountOfRandomTemplates.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.CountOfRandomTemplates"/>
    /// </summary>
    public TBuilder ClearCountOfRandomTemplates()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CountOfRandomTemplates = new IntegerWeighted[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.CountOfRandomTemplates"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCountOfRandomTemplates(Action<IntegerWeighted> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfRandomTemplates is null) { return; }
          bp.CountOfRandomTemplates.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_DifficultyToCurve"/>
    /// </summary>
    public TBuilder SetDifficultyToCurve(Dictionary<DungeonDifficulty,BlueprintDungeonDifficultyCurve> difficultyToCurve)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(difficultyToCurve);
          bp.m_DifficultyToCurve = difficultyToCurve;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_DifficultyToCurve"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDifficultyToCurve(Action<Dictionary<DungeonDifficulty,BlueprintDungeonDifficultyCurve>> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DifficultyToCurve is null) { return; }
          action.Invoke(bp.m_DifficultyToCurve);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.RoomEnterExcludesEnemies"/>
    /// </summary>
    ///
    /// <param name="roomEnterExcludesEnemies">
    /// <para>
    /// Tooltip: No enemies if the room has an entry.
    /// </para>
    /// </param>
    public TBuilder SetRoomEnterExcludesEnemies(bool roomEnterExcludesEnemies = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RoomEnterExcludesEnemies = roomEnterExcludesEnemies;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.RoomExitExcludesEnemies"/>
    /// </summary>
    ///
    /// <param name="roomExitExcludesEnemies">
    /// <para>
    /// Tooltip: No enemies if the room has an exit.
    /// </para>
    /// </param>
    public TBuilder SetRoomExitExcludesEnemies(bool roomExitExcludesEnemies = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RoomExitExcludesEnemies = roomExitExcludesEnemies;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.RoomArmyCountProbabilities"/>
    /// </summary>
    public TBuilder SetRoomArmyCountProbabilities(params IntegerWeighted[] roomArmyCountProbabilities)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(roomArmyCountProbabilities);
          bp.RoomArmyCountProbabilities = roomArmyCountProbabilities;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.RoomArmyCountProbabilities"/>
    /// </summary>
    public TBuilder AddToRoomArmyCountProbabilities(params IntegerWeighted[] roomArmyCountProbabilities)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RoomArmyCountProbabilities = bp.RoomArmyCountProbabilities ?? new IntegerWeighted[0];
          bp.RoomArmyCountProbabilities = CommonTool.Append(bp.RoomArmyCountProbabilities, roomArmyCountProbabilities);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.RoomArmyCountProbabilities"/>
    /// </summary>
    public TBuilder RemoveFromRoomArmyCountProbabilities(params IntegerWeighted[] roomArmyCountProbabilities)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RoomArmyCountProbabilities is null) { return; }
          bp.RoomArmyCountProbabilities = bp.RoomArmyCountProbabilities.Where(val => !roomArmyCountProbabilities.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.RoomArmyCountProbabilities"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromRoomArmyCountProbabilities(Func<IntegerWeighted, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RoomArmyCountProbabilities is null) { return; }
          bp.RoomArmyCountProbabilities = bp.RoomArmyCountProbabilities.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.RoomArmyCountProbabilities"/>
    /// </summary>
    public TBuilder ClearRoomArmyCountProbabilities()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RoomArmyCountProbabilities = new IntegerWeighted[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.RoomArmyCountProbabilities"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyRoomArmyCountProbabilities(Action<IntegerWeighted> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RoomArmyCountProbabilities is null) { return; }
          bp.RoomArmyCountProbabilities.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.SecretRoomSpecialArmyProbability"/>
    /// </summary>
    public TBuilder SetSecretRoomSpecialArmyProbability(float secretRoomSpecialArmyProbability)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SecretRoomSpecialArmyProbability = secretRoomSpecialArmyProbability;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.CountOfUnitsInRoom"/>
    /// </summary>
    public TBuilder SetCountOfUnitsInRoom(params IntegerWeighted[] countOfUnitsInRoom)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(countOfUnitsInRoom);
          bp.CountOfUnitsInRoom = countOfUnitsInRoom;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.CountOfUnitsInRoom"/>
    /// </summary>
    public TBuilder AddToCountOfUnitsInRoom(params IntegerWeighted[] countOfUnitsInRoom)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CountOfUnitsInRoom = bp.CountOfUnitsInRoom ?? new IntegerWeighted[0];
          bp.CountOfUnitsInRoom = CommonTool.Append(bp.CountOfUnitsInRoom, countOfUnitsInRoom);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.CountOfUnitsInRoom"/>
    /// </summary>
    public TBuilder RemoveFromCountOfUnitsInRoom(params IntegerWeighted[] countOfUnitsInRoom)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfUnitsInRoom is null) { return; }
          bp.CountOfUnitsInRoom = bp.CountOfUnitsInRoom.Where(val => !countOfUnitsInRoom.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.CountOfUnitsInRoom"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCountOfUnitsInRoom(Func<IntegerWeighted, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfUnitsInRoom is null) { return; }
          bp.CountOfUnitsInRoom = bp.CountOfUnitsInRoom.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.CountOfUnitsInRoom"/>
    /// </summary>
    public TBuilder ClearCountOfUnitsInRoom()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CountOfUnitsInRoom = new IntegerWeighted[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.CountOfUnitsInRoom"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCountOfUnitsInRoom(Action<IntegerWeighted> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfUnitsInRoom is null) { return; }
          bp.CountOfUnitsInRoom.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.CountOfRoomsWithUnits"/>
    /// </summary>
    public TBuilder SetCountOfRoomsWithUnits(params IntegerWeighted[] countOfRoomsWithUnits)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(countOfRoomsWithUnits);
          bp.CountOfRoomsWithUnits = countOfRoomsWithUnits;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.CountOfRoomsWithUnits"/>
    /// </summary>
    public TBuilder AddToCountOfRoomsWithUnits(params IntegerWeighted[] countOfRoomsWithUnits)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CountOfRoomsWithUnits = bp.CountOfRoomsWithUnits ?? new IntegerWeighted[0];
          bp.CountOfRoomsWithUnits = CommonTool.Append(bp.CountOfRoomsWithUnits, countOfRoomsWithUnits);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.CountOfRoomsWithUnits"/>
    /// </summary>
    public TBuilder RemoveFromCountOfRoomsWithUnits(params IntegerWeighted[] countOfRoomsWithUnits)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfRoomsWithUnits is null) { return; }
          bp.CountOfRoomsWithUnits = bp.CountOfRoomsWithUnits.Where(val => !countOfRoomsWithUnits.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.CountOfRoomsWithUnits"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCountOfRoomsWithUnits(Func<IntegerWeighted, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfRoomsWithUnits is null) { return; }
          bp.CountOfRoomsWithUnits = bp.CountOfRoomsWithUnits.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.CountOfRoomsWithUnits"/>
    /// </summary>
    public TBuilder ClearCountOfRoomsWithUnits()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CountOfRoomsWithUnits = new IntegerWeighted[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.CountOfRoomsWithUnits"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCountOfRoomsWithUnits(Action<IntegerWeighted> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfRoomsWithUnits is null) { return; }
          bp.CountOfRoomsWithUnits.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.CountOfRoomsWithLoot"/>
    /// </summary>
    public TBuilder SetCountOfRoomsWithLoot(params IntegerWeighted[] countOfRoomsWithLoot)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(countOfRoomsWithLoot);
          bp.CountOfRoomsWithLoot = countOfRoomsWithLoot;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.CountOfRoomsWithLoot"/>
    /// </summary>
    public TBuilder AddToCountOfRoomsWithLoot(params IntegerWeighted[] countOfRoomsWithLoot)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CountOfRoomsWithLoot = bp.CountOfRoomsWithLoot ?? new IntegerWeighted[0];
          bp.CountOfRoomsWithLoot = CommonTool.Append(bp.CountOfRoomsWithLoot, countOfRoomsWithLoot);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.CountOfRoomsWithLoot"/>
    /// </summary>
    public TBuilder RemoveFromCountOfRoomsWithLoot(params IntegerWeighted[] countOfRoomsWithLoot)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfRoomsWithLoot is null) { return; }
          bp.CountOfRoomsWithLoot = bp.CountOfRoomsWithLoot.Where(val => !countOfRoomsWithLoot.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.CountOfRoomsWithLoot"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCountOfRoomsWithLoot(Func<IntegerWeighted, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfRoomsWithLoot is null) { return; }
          bp.CountOfRoomsWithLoot = bp.CountOfRoomsWithLoot.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.CountOfRoomsWithLoot"/>
    /// </summary>
    public TBuilder ClearCountOfRoomsWithLoot()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CountOfRoomsWithLoot = new IntegerWeighted[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.CountOfRoomsWithLoot"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCountOfRoomsWithLoot(Action<IntegerWeighted> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfRoomsWithLoot is null) { return; }
          bp.CountOfRoomsWithLoot.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.CountOfChestLocked"/>
    /// </summary>
    public TBuilder SetCountOfChestLocked(params IntegerWeighted[] countOfChestLocked)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(countOfChestLocked);
          bp.CountOfChestLocked = countOfChestLocked;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.CountOfChestLocked"/>
    /// </summary>
    public TBuilder AddToCountOfChestLocked(params IntegerWeighted[] countOfChestLocked)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CountOfChestLocked = bp.CountOfChestLocked ?? new IntegerWeighted[0];
          bp.CountOfChestLocked = CommonTool.Append(bp.CountOfChestLocked, countOfChestLocked);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.CountOfChestLocked"/>
    /// </summary>
    public TBuilder RemoveFromCountOfChestLocked(params IntegerWeighted[] countOfChestLocked)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfChestLocked is null) { return; }
          bp.CountOfChestLocked = bp.CountOfChestLocked.Where(val => !countOfChestLocked.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.CountOfChestLocked"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCountOfChestLocked(Func<IntegerWeighted, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfChestLocked is null) { return; }
          bp.CountOfChestLocked = bp.CountOfChestLocked.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.CountOfChestLocked"/>
    /// </summary>
    public TBuilder ClearCountOfChestLocked()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CountOfChestLocked = new IntegerWeighted[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.CountOfChestLocked"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCountOfChestLocked(Action<IntegerWeighted> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfChestLocked is null) { return; }
          bp.CountOfChestLocked.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.CountOfTraps"/>
    /// </summary>
    public TBuilder SetCountOfTraps(params IntegerWeighted[] countOfTraps)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(countOfTraps);
          bp.CountOfTraps = countOfTraps;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.CountOfTraps"/>
    /// </summary>
    public TBuilder AddToCountOfTraps(params IntegerWeighted[] countOfTraps)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CountOfTraps = bp.CountOfTraps ?? new IntegerWeighted[0];
          bp.CountOfTraps = CommonTool.Append(bp.CountOfTraps, countOfTraps);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.CountOfTraps"/>
    /// </summary>
    public TBuilder RemoveFromCountOfTraps(params IntegerWeighted[] countOfTraps)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfTraps is null) { return; }
          bp.CountOfTraps = bp.CountOfTraps.Where(val => !countOfTraps.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.CountOfTraps"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCountOfTraps(Func<IntegerWeighted, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfTraps is null) { return; }
          bp.CountOfTraps = bp.CountOfTraps.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.CountOfTraps"/>
    /// </summary>
    public TBuilder ClearCountOfTraps()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CountOfTraps = new IntegerWeighted[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.CountOfTraps"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCountOfTraps(Action<IntegerWeighted> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CountOfTraps is null) { return; }
          bp.CountOfTraps.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_MobFaction"/>
    /// </summary>
    ///
    /// <param name="mobFaction">
    /// <para>
    /// Blueprint of type BlueprintFaction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetMobFaction(Blueprint<BlueprintFactionReference> mobFaction)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MobFaction = mobFaction?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_MobFaction"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMobFaction(Action<BlueprintFactionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MobFaction is null) { return; }
          action.Invoke(bp.m_MobFaction);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_MobSummonPool"/>
    /// </summary>
    ///
    /// <param name="mobSummonPool">
    /// <para>
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetMobSummonPool(Blueprint<BlueprintSummonPoolReference> mobSummonPool)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MobSummonPool = mobSummonPool?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_MobSummonPool"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMobSummonPool(Action<BlueprintSummonPoolReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MobSummonPool is null) { return; }
          action.Invoke(bp.m_MobSummonPool);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.RoamingProbability"/>
    /// </summary>
    public TBuilder SetRoamingProbability(float roamingProbability)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RoamingProbability = roamingProbability;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.Roaming"/>
    /// </summary>
    public TBuilder SetRoaming(RoamingUnitSettings roaming)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(roaming);
          bp.Roaming = roaming;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.Roaming"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRoaming(Action<RoamingUnitSettings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Roaming is null) { return; }
          action.Invoke(bp.Roaming);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_OverrideCountByUnitTagEntries"/>
    /// </summary>
    public TBuilder SetOverrideCountByUnitTagEntries(params BlueprintDungeonRoot.OverrideCountByUnitTagEntry[] overrideCountByUnitTagEntries)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(overrideCountByUnitTagEntries);
          bp.m_OverrideCountByUnitTagEntries = overrideCountByUnitTagEntries;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.m_OverrideCountByUnitTagEntries"/>
    /// </summary>
    public TBuilder AddToOverrideCountByUnitTagEntries(params BlueprintDungeonRoot.OverrideCountByUnitTagEntry[] overrideCountByUnitTagEntries)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_OverrideCountByUnitTagEntries = bp.m_OverrideCountByUnitTagEntries ?? new BlueprintDungeonRoot.OverrideCountByUnitTagEntry[0];
          bp.m_OverrideCountByUnitTagEntries = CommonTool.Append(bp.m_OverrideCountByUnitTagEntries, overrideCountByUnitTagEntries);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_OverrideCountByUnitTagEntries"/>
    /// </summary>
    public TBuilder RemoveFromOverrideCountByUnitTagEntries(params BlueprintDungeonRoot.OverrideCountByUnitTagEntry[] overrideCountByUnitTagEntries)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_OverrideCountByUnitTagEntries is null) { return; }
          bp.m_OverrideCountByUnitTagEntries = bp.m_OverrideCountByUnitTagEntries.Where(val => !overrideCountByUnitTagEntries.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_OverrideCountByUnitTagEntries"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromOverrideCountByUnitTagEntries(Func<BlueprintDungeonRoot.OverrideCountByUnitTagEntry, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_OverrideCountByUnitTagEntries is null) { return; }
          bp.m_OverrideCountByUnitTagEntries = bp.m_OverrideCountByUnitTagEntries.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.m_OverrideCountByUnitTagEntries"/>
    /// </summary>
    public TBuilder ClearOverrideCountByUnitTagEntries()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_OverrideCountByUnitTagEntries = new BlueprintDungeonRoot.OverrideCountByUnitTagEntry[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_OverrideCountByUnitTagEntries"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyOverrideCountByUnitTagEntries(Action<BlueprintDungeonRoot.OverrideCountByUnitTagEntry> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_OverrideCountByUnitTagEntries is null) { return; }
          bp.m_OverrideCountByUnitTagEntries.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_Armies"/>
    /// </summary>
    ///
    /// <param name="armies">
    /// <para>
    /// Blueprint of type BlueprintDungeonArmy. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetArmies(params Blueprint<BlueprintDungeonArmyReference>[] armies)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Armies = armies.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.m_Armies"/>
    /// </summary>
    ///
    /// <param name="armies">
    /// <para>
    /// Blueprint of type BlueprintDungeonArmy. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToArmies(params Blueprint<BlueprintDungeonArmyReference>[] armies)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Armies = bp.m_Armies ?? new BlueprintDungeonArmyReference[0];
          bp.m_Armies = CommonTool.Append(bp.m_Armies, armies.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_Armies"/>
    /// </summary>
    ///
    /// <param name="armies">
    /// <para>
    /// Blueprint of type BlueprintDungeonArmy. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromArmies(params Blueprint<BlueprintDungeonArmyReference>[] armies)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Armies is null) { return; }
          bp.m_Armies = bp.m_Armies.Where(val => !armies.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_Armies"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromArmies(Func<BlueprintDungeonArmyReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Armies is null) { return; }
          bp.m_Armies = bp.m_Armies.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.m_Armies"/>
    /// </summary>
    public TBuilder ClearArmies()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Armies = new BlueprintDungeonArmyReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_Armies"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyArmies(Action<BlueprintDungeonArmyReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Armies is null) { return; }
          bp.m_Armies.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_TrapSpells"/>
    /// </summary>
    ///
    /// <param name="trapSpells">
    /// <para>
    /// Blueprint of type BlueprintDungeonTrapSpellList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetTrapSpells(Blueprint<BlueprintDungeonTrapSpellListReference> trapSpells)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TrapSpells = trapSpells?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_TrapSpells"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTrapSpells(Action<BlueprintDungeonTrapSpellListReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TrapSpells is null) { return; }
          action.Invoke(bp.m_TrapSpells);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.MinimalGoldRelativeAmountInChest"/>
    /// </summary>
    ///
    /// <param name="minimalGoldRelativeAmountInChest">
    /// <para>
    /// Tooltip: Minimal gold amount in the chest relatively to the total gold amount that is to be distributed among all the chests on the island. 0 means any amount of gold can be in one chest, 1 means every chest has the same amount of gold.
    /// </para>
    /// </param>
    public TBuilder SetMinimalGoldRelativeAmountInChest(float minimalGoldRelativeAmountInChest)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinimalGoldRelativeAmountInChest = minimalGoldRelativeAmountInChest;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_Loot"/>
    /// </summary>
    ///
    /// <param name="loot">
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
    public TBuilder SetLoot(params Blueprint<BlueprintDungeonLootReference>[] loot)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Loot = loot.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.m_Loot"/>
    /// </summary>
    ///
    /// <param name="loot">
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
    public TBuilder AddToLoot(params Blueprint<BlueprintDungeonLootReference>[] loot)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Loot = bp.m_Loot ?? new BlueprintDungeonLootReference[0];
          bp.m_Loot = CommonTool.Append(bp.m_Loot, loot.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_Loot"/>
    /// </summary>
    ///
    /// <param name="loot">
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
    public TBuilder RemoveFromLoot(params Blueprint<BlueprintDungeonLootReference>[] loot)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Loot is null) { return; }
          bp.m_Loot = bp.m_Loot.Where(val => !loot.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_Loot"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromLoot(Func<BlueprintDungeonLootReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Loot is null) { return; }
          bp.m_Loot = bp.m_Loot.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.m_Loot"/>
    /// </summary>
    public TBuilder ClearLoot()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Loot = new BlueprintDungeonLootReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_Loot"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyLoot(Action<BlueprintDungeonLootReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Loot is null) { return; }
          bp.m_Loot.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_LootContainers"/>
    /// </summary>
    ///
    /// <param name="lootContainers">
    /// <para>
    /// Blueprint of type BlueprintDynamicMapObject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetLootContainers(params Blueprint<BlueprintDynamicMapObjectReference>[] lootContainers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_LootContainers = lootContainers.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.m_LootContainers"/>
    /// </summary>
    ///
    /// <param name="lootContainers">
    /// <para>
    /// Blueprint of type BlueprintDynamicMapObject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToLootContainers(params Blueprint<BlueprintDynamicMapObjectReference>[] lootContainers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_LootContainers = bp.m_LootContainers ?? new BlueprintDynamicMapObjectReference[0];
          bp.m_LootContainers = CommonTool.Append(bp.m_LootContainers, lootContainers.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_LootContainers"/>
    /// </summary>
    ///
    /// <param name="lootContainers">
    /// <para>
    /// Blueprint of type BlueprintDynamicMapObject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromLootContainers(params Blueprint<BlueprintDynamicMapObjectReference>[] lootContainers)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_LootContainers is null) { return; }
          bp.m_LootContainers = bp.m_LootContainers.Where(val => !lootContainers.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_LootContainers"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromLootContainers(Func<BlueprintDynamicMapObjectReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_LootContainers is null) { return; }
          bp.m_LootContainers = bp.m_LootContainers.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.m_LootContainers"/>
    /// </summary>
    public TBuilder ClearLootContainers()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_LootContainers = new BlueprintDynamicMapObjectReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_LootContainers"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyLootContainers(Action<BlueprintDynamicMapObjectReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_LootContainers is null) { return; }
          bp.m_LootContainers.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_BesmaritBossIsland"/>
    /// </summary>
    ///
    /// <param name="besmaritBossIsland">
    /// <para>
    /// Blueprint of type BlueprintDungeonIsland. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBesmaritBossIsland(Blueprint<BlueprintDungeonIslandReference> besmaritBossIsland)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BesmaritBossIsland = besmaritBossIsland?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_BesmaritBossIsland"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBesmaritBossIsland(Action<BlueprintDungeonIslandReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BesmaritBossIsland is null) { return; }
          action.Invoke(bp.m_BesmaritBossIsland);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_BesmaritModificator"/>
    /// </summary>
    ///
    /// <param name="besmaritModificator">
    /// <para>
    /// Blueprint of type BlueprintDungeonModificator. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBesmaritModificator(Blueprint<BlueprintDungeonModificatorReference> besmaritModificator)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BesmaritModificator = besmaritModificator?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_BesmaritModificator"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBesmaritModificator(Action<BlueprintDungeonModificatorReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BesmaritModificator is null) { return; }
          action.Invoke(bp.m_BesmaritModificator);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_BesmaritIslands"/>
    /// </summary>
    ///
    /// <param name="besmaritIslands">
    /// <para>
    /// Blueprint of type BlueprintDungeonIsland. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBesmaritIslands(params Blueprint<BlueprintDungeonIslandReference>[] besmaritIslands)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BesmaritIslands = besmaritIslands.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.m_BesmaritIslands"/>
    /// </summary>
    ///
    /// <param name="besmaritIslands">
    /// <para>
    /// Blueprint of type BlueprintDungeonIsland. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToBesmaritIslands(params Blueprint<BlueprintDungeonIslandReference>[] besmaritIslands)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BesmaritIslands = bp.m_BesmaritIslands ?? new BlueprintDungeonIslandReference[0];
          bp.m_BesmaritIslands = CommonTool.Append(bp.m_BesmaritIslands, besmaritIslands.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_BesmaritIslands"/>
    /// </summary>
    ///
    /// <param name="besmaritIslands">
    /// <para>
    /// Blueprint of type BlueprintDungeonIsland. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromBesmaritIslands(params Blueprint<BlueprintDungeonIslandReference>[] besmaritIslands)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BesmaritIslands is null) { return; }
          bp.m_BesmaritIslands = bp.m_BesmaritIslands.Where(val => !besmaritIslands.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_BesmaritIslands"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromBesmaritIslands(Func<BlueprintDungeonIslandReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BesmaritIslands is null) { return; }
          bp.m_BesmaritIslands = bp.m_BesmaritIslands.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.m_BesmaritIslands"/>
    /// </summary>
    public TBuilder ClearBesmaritIslands()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BesmaritIslands = new BlueprintDungeonIslandReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_BesmaritIslands"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyBesmaritIslands(Action<BlueprintDungeonIslandReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BesmaritIslands is null) { return; }
          bp.m_BesmaritIslands.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_BesmaritChest"/>
    /// </summary>
    public TBuilder SetBesmaritChest(BlueprintDungeonRoot.BesmaritChestSettings besmaritChest)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(besmaritChest);
          bp.m_BesmaritChest = besmaritChest;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_BesmaritChest"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBesmaritChest(Action<BlueprintDungeonRoot.BesmaritChestSettings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BesmaritChest is null) { return; }
          action.Invoke(bp.m_BesmaritChest);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_BesmaritSceneChests"/>
    /// </summary>
    public TBuilder SetBesmaritSceneChests(params MapObjectFromScene[] besmaritSceneChests)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(besmaritSceneChests);
          bp.m_BesmaritSceneChests = besmaritSceneChests;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.m_BesmaritSceneChests"/>
    /// </summary>
    public TBuilder AddToBesmaritSceneChests(params MapObjectFromScene[] besmaritSceneChests)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BesmaritSceneChests = bp.m_BesmaritSceneChests ?? new MapObjectFromScene[0];
          bp.m_BesmaritSceneChests = CommonTool.Append(bp.m_BesmaritSceneChests, besmaritSceneChests);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_BesmaritSceneChests"/>
    /// </summary>
    public TBuilder RemoveFromBesmaritSceneChests(params MapObjectFromScene[] besmaritSceneChests)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BesmaritSceneChests is null) { return; }
          bp.m_BesmaritSceneChests = bp.m_BesmaritSceneChests.Where(val => !besmaritSceneChests.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_BesmaritSceneChests"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromBesmaritSceneChests(Func<MapObjectFromScene, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BesmaritSceneChests is null) { return; }
          bp.m_BesmaritSceneChests = bp.m_BesmaritSceneChests.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.m_BesmaritSceneChests"/>
    /// </summary>
    public TBuilder ClearBesmaritSceneChests()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BesmaritSceneChests = new MapObjectFromScene[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_BesmaritSceneChests"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyBesmaritSceneChests(Action<MapObjectFromScene> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BesmaritSceneChests is null) { return; }
          bp.m_BesmaritSceneChests.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_BesmaritBossReward"/>
    /// </summary>
    ///
    /// <param name="besmaritBossReward">
    /// <para>
    /// Tooltip: Empty reward
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonIslandRewardLoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBesmaritBossReward(Blueprint<BlueprintDungeonIslandRewardLootReference> besmaritBossReward)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BesmaritBossReward = besmaritBossReward?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_BesmaritBossReward"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBesmaritBossReward(Action<BlueprintDungeonIslandRewardLootReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BesmaritBossReward is null) { return; }
          action.Invoke(bp.m_BesmaritBossReward);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_BesmaritReward"/>
    /// </summary>
    ///
    /// <param name="besmaritReward">
    /// <para>
    /// Blueprint of type BlueprintDungeonIslandRewardLoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBesmaritReward(Blueprint<BlueprintDungeonIslandRewardLootReference> besmaritReward)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BesmaritReward = besmaritReward?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_BesmaritReward"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBesmaritReward(Action<BlueprintDungeonIslandRewardLootReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BesmaritReward is null) { return; }
          action.Invoke(bp.m_BesmaritReward);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_BesmaritFinishFlag"/>
    /// </summary>
    ///
    /// <param name="besmaritFinishFlag">
    /// <para>
    /// Blueprint of type BlueprintUnlockableFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBesmaritFinishFlag(Blueprint<BlueprintUnlockableFlagReference> besmaritFinishFlag)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BesmaritFinishFlag = besmaritFinishFlag?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_BesmaritFinishFlag"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBesmaritFinishFlag(Action<BlueprintUnlockableFlagReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BesmaritFinishFlag is null) { return; }
          action.Invoke(bp.m_BesmaritFinishFlag);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_ModifierSubeffects"/>
    /// </summary>
    ///
    /// <param name="modifierSubeffects">
    /// <para>
    /// Tooltip: Buffs that will be removed when leaving the island
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetModifierSubeffects(params Blueprint<BlueprintBuffReference>[] modifierSubeffects)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ModifierSubeffects = modifierSubeffects.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.m_ModifierSubeffects"/>
    /// </summary>
    ///
    /// <param name="modifierSubeffects">
    /// <para>
    /// Tooltip: Buffs that will be removed when leaving the island
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToModifierSubeffects(params Blueprint<BlueprintBuffReference>[] modifierSubeffects)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ModifierSubeffects = bp.m_ModifierSubeffects ?? new BlueprintBuffReference[0];
          bp.m_ModifierSubeffects = CommonTool.Append(bp.m_ModifierSubeffects, modifierSubeffects.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_ModifierSubeffects"/>
    /// </summary>
    ///
    /// <param name="modifierSubeffects">
    /// <para>
    /// Tooltip: Buffs that will be removed when leaving the island
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromModifierSubeffects(params Blueprint<BlueprintBuffReference>[] modifierSubeffects)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ModifierSubeffects is null) { return; }
          bp.m_ModifierSubeffects = bp.m_ModifierSubeffects.Where(val => !modifierSubeffects.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_ModifierSubeffects"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromModifierSubeffects(Func<BlueprintBuffReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ModifierSubeffects is null) { return; }
          bp.m_ModifierSubeffects = bp.m_ModifierSubeffects.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.m_ModifierSubeffects"/>
    /// </summary>
    public TBuilder ClearModifierSubeffects()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ModifierSubeffects = new BlueprintBuffReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_ModifierSubeffects"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyModifierSubeffects(Action<BlueprintBuffReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ModifierSubeffects is null) { return; }
          bp.m_ModifierSubeffects.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.m_AddedDCForRest"/>
    /// </summary>
    public TBuilder SetAddedDCForRest(params int[] addedDCForRest)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AddedDCForRest = addedDCForRest;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.m_AddedDCForRest"/>
    /// </summary>
    public TBuilder AddToAddedDCForRest(params int[] addedDCForRest)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AddedDCForRest = bp.m_AddedDCForRest ?? new int[0];
          bp.m_AddedDCForRest = CommonTool.Append(bp.m_AddedDCForRest, addedDCForRest);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_AddedDCForRest"/>
    /// </summary>
    public TBuilder RemoveFromAddedDCForRest(params int[] addedDCForRest)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AddedDCForRest is null) { return; }
          bp.m_AddedDCForRest = bp.m_AddedDCForRest.Where(val => !addedDCForRest.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.m_AddedDCForRest"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromAddedDCForRest(Func<int, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AddedDCForRest is null) { return; }
          bp.m_AddedDCForRest = bp.m_AddedDCForRest.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.m_AddedDCForRest"/>
    /// </summary>
    public TBuilder ClearAddedDCForRest()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AddedDCForRest = new int[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.m_AddedDCForRest"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyAddedDCForRest(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AddedDCForRest is null) { return; }
          bp.m_AddedDCForRest.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.CrToChestCost"/>
    /// </summary>
    ///
    /// <param name="crToChestCost">
    /// <para>
    /// Tooltip: Chest budget dependecy from the stage CR.
    /// </para>
    /// </param>
    public TBuilder SetCrToChestCost(params int[] crToChestCost)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CrToChestCost = crToChestCost;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonRoot.CrToChestCost"/>
    /// </summary>
    ///
    /// <param name="crToChestCost">
    /// <para>
    /// Tooltip: Chest budget dependecy from the stage CR.
    /// </para>
    /// </param>
    public TBuilder AddToCrToChestCost(params int[] crToChestCost)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CrToChestCost = bp.CrToChestCost ?? new int[0];
          bp.CrToChestCost = CommonTool.Append(bp.CrToChestCost, crToChestCost);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.CrToChestCost"/>
    /// </summary>
    ///
    /// <param name="crToChestCost">
    /// <para>
    /// Tooltip: Chest budget dependecy from the stage CR.
    /// </para>
    /// </param>
    public TBuilder RemoveFromCrToChestCost(params int[] crToChestCost)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CrToChestCost is null) { return; }
          bp.CrToChestCost = bp.CrToChestCost.Where(val => !crToChestCost.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonRoot.CrToChestCost"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCrToChestCost(Func<int, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CrToChestCost is null) { return; }
          bp.CrToChestCost = bp.CrToChestCost.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonRoot.CrToChestCost"/>
    /// </summary>
    public TBuilder ClearCrToChestCost()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CrToChestCost = new int[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.CrToChestCost"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCrToChestCost(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CrToChestCost is null) { return; }
          bp.CrToChestCost.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.RewardRevealFx"/>
    /// </summary>
    ///
    /// <param name="rewardRevealFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetRewardRevealFx(AssetLink<PrefabLink> rewardRevealFx)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RewardRevealFx = rewardRevealFx?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.RewardRevealFx"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRewardRevealFx(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RewardRevealFx is null) { return; }
          action.Invoke(bp.RewardRevealFx);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.TrapDisabledEvent"/>
    /// </summary>
    public TBuilder SetTrapDisabledEvent(string trapDisabledEvent)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TrapDisabledEvent = trapDisabledEvent;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.TrapDisabledEvent"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTrapDisabledEvent(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.TrapDisabledEvent is null) { return; }
          action.Invoke(bp.TrapDisabledEvent);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.TrapDisableFailedEvent"/>
    /// </summary>
    public TBuilder SetTrapDisableFailedEvent(string trapDisableFailedEvent)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TrapDisableFailedEvent = trapDisableFailedEvent;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.TrapDisableFailedEvent"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTrapDisableFailedEvent(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.TrapDisableFailedEvent is null) { return; }
          action.Invoke(bp.TrapDisableFailedEvent);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.TrapInteractionStartedEvent"/>
    /// </summary>
    public TBuilder SetTrapInteractionStartedEvent(string trapInteractionStartedEvent)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TrapInteractionStartedEvent = trapInteractionStartedEvent;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.TrapInteractionStartedEvent"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTrapInteractionStartedEvent(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.TrapInteractionStartedEvent is null) { return; }
          action.Invoke(bp.TrapInteractionStartedEvent);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.TrapInteractionEndedEvent"/>
    /// </summary>
    public TBuilder SetTrapInteractionEndedEvent(string trapInteractionEndedEvent)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TrapInteractionEndedEvent = trapInteractionEndedEvent;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonRoot.TrapInteractionEndedEvent"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTrapInteractionEndedEvent(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.TrapInteractionEndedEvent is null) { return; }
          action.Invoke(bp.TrapInteractionEndedEvent);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonRoot.BoonsAvailableCount"/>
    /// </summary>
    ///
    /// <param name="boonsAvailableCount">
    /// <para>
    /// Tooltip: Count of boons to choose from at the start of a new run.
    /// </para>
    /// </param>
    public TBuilder SetBoonsAvailableCount(int boonsAvailableCount)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BoonsAvailableCount = boonsAvailableCount;
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_DungeonCampaign is null)
      {
        Blueprint.m_DungeonCampaign = BlueprintTool.GetRef<BlueprintDungeonCampaignReference>(null);
      }
      if (Blueprint.m_Localization is null)
      {
        Blueprint.m_Localization = BlueprintTool.GetRef<BlueprintDungeonLocalizedStringsReference>(null);
      }
      if (Blueprint.m_UnitsWithQuestItems is null)
      {
        Blueprint.m_UnitsWithQuestItems = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      if (Blueprint.m_MainVendorTable is null)
      {
        Blueprint.m_MainVendorTable = BlueprintTool.GetRef<BlueprintSharedVendorTableReference>(null);
      }
      if (Blueprint.m_DivineVendorTable is null)
      {
        Blueprint.m_DivineVendorTable = BlueprintTool.GetRef<BlueprintSharedVendorTableReference>(null);
      }
      if (Blueprint.m_Maps is null)
      {
        Blueprint.m_Maps = new BlueprintDungeonMapReference[0];
      }
      if (Blueprint.MapDecorationGroups is null)
      {
        Blueprint.MapDecorationGroups = new BlueprintDungeonRoot.MapDecorationGroup[0];
      }
      if (Blueprint.m_Expeditions is null)
      {
        Blueprint.m_Expeditions = new BlueprintDungeonExpeditionReference[0];
      }
      if (Blueprint.m_Islands is null)
      {
        Blueprint.m_Islands = new BlueprintDungeonIslandReference[0];
      }
      if (Blueprint.m_Modificators is null)
      {
        Blueprint.m_Modificators = new BlueprintDungeonModificatorReference[0];
      }
      if (Blueprint.CountOfObjectsPerModificator is null)
      {
        Blueprint.CountOfObjectsPerModificator = new IntegerWeighted[0];
      }
      if (Blueprint.CountOfSecretRooms is null)
      {
        Blueprint.CountOfSecretRooms = new IntegerWeighted[0];
      }
      if (Blueprint.m_Ship is null)
      {
        Blueprint.m_Ship = BlueprintTool.GetRef<BlueprintAreaReference>(null);
      }
      if (Blueprint.m_Port is null)
      {
        Blueprint.m_Port = BlueprintTool.GetRef<BlueprintAreaReference>(null);
      }
      if (Blueprint.CountOfUnitsInRandomEncounter is null)
      {
        Blueprint.CountOfUnitsInRandomEncounter = new IntegerWeighted[0];
      }
      if (Blueprint.m_RandomEncounterArmies is null)
      {
        Blueprint.m_RandomEncounterArmies = new BlueprintDungeonArmyReference[0];
      }
      if (Blueprint.ActionsOnRandomEncounter is null)
      {
        Blueprint.ActionsOnRandomEncounter = Utils.Constants.Empty.Actions;
      }
      if (Blueprint.Experience is null)
      {
        Blueprint.Experience = new int[0];
      }
      if (Blueprint.m_Tiers is null)
      {
        Blueprint.m_Tiers = new BlueprintDungeonTierReference[0];
      }
      if (Blueprint.m_Boons is null)
      {
        Blueprint.m_Boons = new Kingmaker.Dungeon.Blueprints.BlueprintDungeonBoonReference[0];
      }
      if (Blueprint.ActionsBeforeRestart is null)
      {
        Blueprint.ActionsBeforeRestart = Utils.Constants.Empty.Actions;
      }
      if (Blueprint.ActionsAfterRestart is null)
      {
        Blueprint.ActionsAfterRestart = Utils.Constants.Empty.Actions;
      }
      if (Blueprint.ActionsAfterChargen is null)
      {
        Blueprint.ActionsAfterChargen = Utils.Constants.Empty.Actions;
      }
      if (Blueprint.ActionsBeforeExpeditionRestart is null)
      {
        Blueprint.ActionsBeforeExpeditionRestart = Utils.Constants.Empty.Actions;
      }
      if (Blueprint.ActionsAfterExpeditionRestart is null)
      {
        Blueprint.ActionsAfterExpeditionRestart = Utils.Constants.Empty.Actions;
      }
      if (Blueprint.m_CarryOverItemsBlacklist is null)
      {
        Blueprint.m_CarryOverItemsBlacklist = new BlueprintItemReference[0];
      }
      if (Blueprint.CrToExperience is null)
      {
        Blueprint.CrToExperience = new int[0];
      }
      if (Blueprint.m_DifficultyCurves is null)
      {
        Blueprint.m_DifficultyCurves = new BlueprintDungeonDifficultyCurveReference[0];
      }
      if (Blueprint.m_Templates is null)
      {
        Blueprint.m_Templates = new BlueprintUnitTemplateReference[0];
      }
      if (Blueprint.CountOfRandomTemplates is null)
      {
        Blueprint.CountOfRandomTemplates = new IntegerWeighted[0];
      }
      if (Blueprint.RoomArmyCountProbabilities is null)
      {
        Blueprint.RoomArmyCountProbabilities = new IntegerWeighted[0];
      }
      if (Blueprint.CountOfUnitsInRoom is null)
      {
        Blueprint.CountOfUnitsInRoom = new IntegerWeighted[0];
      }
      if (Blueprint.CountOfRoomsWithUnits is null)
      {
        Blueprint.CountOfRoomsWithUnits = new IntegerWeighted[0];
      }
      if (Blueprint.CountOfRoomsWithLoot is null)
      {
        Blueprint.CountOfRoomsWithLoot = new IntegerWeighted[0];
      }
      if (Blueprint.CountOfChestLocked is null)
      {
        Blueprint.CountOfChestLocked = new IntegerWeighted[0];
      }
      if (Blueprint.CountOfTraps is null)
      {
        Blueprint.CountOfTraps = new IntegerWeighted[0];
      }
      if (Blueprint.m_MobFaction is null)
      {
        Blueprint.m_MobFaction = BlueprintTool.GetRef<BlueprintFactionReference>(null);
      }
      if (Blueprint.m_MobSummonPool is null)
      {
        Blueprint.m_MobSummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      if (Blueprint.m_OverrideCountByUnitTagEntries is null)
      {
        Blueprint.m_OverrideCountByUnitTagEntries = new BlueprintDungeonRoot.OverrideCountByUnitTagEntry[0];
      }
      if (Blueprint.m_Armies is null)
      {
        Blueprint.m_Armies = new BlueprintDungeonArmyReference[0];
      }
      if (Blueprint.m_TrapSpells is null)
      {
        Blueprint.m_TrapSpells = BlueprintTool.GetRef<BlueprintDungeonTrapSpellListReference>(null);
      }
      if (Blueprint.m_Loot is null)
      {
        Blueprint.m_Loot = new BlueprintDungeonLootReference[0];
      }
      if (Blueprint.m_LootContainers is null)
      {
        Blueprint.m_LootContainers = new BlueprintDynamicMapObjectReference[0];
      }
      if (Blueprint.m_BesmaritBossIsland is null)
      {
        Blueprint.m_BesmaritBossIsland = BlueprintTool.GetRef<BlueprintDungeonIslandReference>(null);
      }
      if (Blueprint.m_BesmaritModificator is null)
      {
        Blueprint.m_BesmaritModificator = BlueprintTool.GetRef<BlueprintDungeonModificatorReference>(null);
      }
      if (Blueprint.m_BesmaritIslands is null)
      {
        Blueprint.m_BesmaritIslands = new BlueprintDungeonIslandReference[0];
      }
      if (Blueprint.m_BesmaritSceneChests is null)
      {
        Blueprint.m_BesmaritSceneChests = new MapObjectFromScene[0];
      }
      if (Blueprint.m_BesmaritBossReward is null)
      {
        Blueprint.m_BesmaritBossReward = BlueprintTool.GetRef<BlueprintDungeonIslandRewardLootReference>(null);
      }
      if (Blueprint.m_BesmaritReward is null)
      {
        Blueprint.m_BesmaritReward = BlueprintTool.GetRef<BlueprintDungeonIslandRewardLootReference>(null);
      }
      if (Blueprint.m_BesmaritFinishFlag is null)
      {
        Blueprint.m_BesmaritFinishFlag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(null);
      }
      if (Blueprint.m_ModifierSubeffects is null)
      {
        Blueprint.m_ModifierSubeffects = new BlueprintBuffReference[0];
      }
      if (Blueprint.m_AddedDCForRest is null)
      {
        Blueprint.m_AddedDCForRest = new int[0];
      }
      if (Blueprint.CrToChestCost is null)
      {
        Blueprint.CrToChestCost = new int[0];
      }
      if (Blueprint.RewardRevealFx is null)
      {
        Blueprint.RewardRevealFx = Utils.Constants.Empty.PrefabLink;
      }
    }
  }
}
