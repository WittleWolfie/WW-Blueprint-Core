using System;
using System.Collections.Generic;
using System.Linq;
using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Achievements.Actions;
using Kingmaker.Achievements.Blueprints;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Dungeon.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Persistence.Versioning.PlayerUpgraderOnlyActions;
using Kingmaker.EntitySystem.Persistence.Versioning.UnitUpgraderOnlyActions;
using Kingmaker.EntitySystem.Persistence.Versioning.UpgraderOnlyActions;
using Kingmaker.Enums;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Localization;
using Kingmaker.RandomEncounters.Settings;
using Kingmaker.ResourceLinks;

namespace BlueprintCore.Actions.Builder.MetaEx
{
  /**
   * Extension to ActionListBuilder which supports non-character actions.
   *
   * Examples include adjusting map encounters, modifying achievements, or granting items.
   */
  public static class ActionListBuilderMetaEx
  {
    //----- Kingmaker.Achievements.Actions -----//

    /**
     * ActionAchievementIncrementCounter
     *
     * @param achievement AchievementData
     */
    public static ActionListBuilder IncrementAchievement(
        this ActionListBuilder builder, string achievement)
    {
      var increment = ElementTool.Create<ActionAchievementIncrementCounter>();
      increment.m_Achievement =
          BlueprintTool.GetRef<AchievementData, AchievementDataReference>(achievement);
      return builder.Add(increment);
    }

    /**
     * ActionAchievementUnlock
     *
     * @param achievement AchievementData
     */
    public static ActionListBuilder UnlockAchievement(
        this ActionListBuilder builder, string achievement)
    {
      var unlock = ElementTool.Create<ActionAchievementUnlock>();
      unlock.m_Achievement =
          BlueprintTool.GetRef<AchievementData, AchievementDataReference>(achievement);
      return builder.Add(unlock);
    }

    //----- Kingmaker.Dungeon.Actions -----//

    /** ActionCreateImportedCompanion */
    public static ActionListBuilder CreateImportedCompanion(
        this ActionListBuilder builder, int index)
    {
      var createCompanion = ElementTool.Create<ActionCreateImportedCompanion>();
      createCompanion.Index = index;
      return builder.Add(createCompanion);
    }

    /** ActionEnterToDungeon */
    public static ActionListBuilder TeleportToLastDungeonStageEntrance(
        this ActionListBuilder builder, int minStage = 1)
    {
      var teleport = ElementTool.Create<ActionEnterToDungeon>();
      teleport.FirstStage = minStage;
      return builder.Add(teleport);
    }

    /** ActionGoDeeperIntoDungeon */
    public static ActionListBuilder EnterNextDungeonStage(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ActionGoDeeperIntoDungeon>());
    }

    /** ActionIncreaseDungeonStage */
    public static ActionListBuilder IncrementDungeonStage(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ActionIncreaseDungeonStage>());
    }

    /** ActionSetDungeonStage */
    public static ActionListBuilder SetDungeonStage(this ActionListBuilder builder, int stage = 1)
    {
      var setStage = ElementTool.Create<ActionSetDungeonStage>();
      setStage.Stage = stage;
      return builder.Add(setStage);
    }

    //----- Kingmaker.EntitySystem.Persistence.Versioning.*UpgraderOnlyActions -----//

    /**
     * AddFactIfEtudePlaying
     *
     * @param fact BlueprintUnitFact
     * @param etude BlueprintEtude
     */
    public static ActionListBuilder AddFactIfEtudePlaying(
        this ActionListBuilder builder,
        AddFactIfEtudePlaying.TargetType target,
        string fact,
        string etude)
    {
      var addFact = ElementTool.Create<AddFactIfEtudePlaying>();
      addFact.m_Target = target;
      addFact.m_Fact = BlueprintTool.GetRef<BlueprintUnitFact, BlueprintUnitFactReference>(fact);
      addFact.m_Etude = BlueprintTool.GetRef<BlueprintEtude, BlueprintEtudeReference>(etude);
      return builder.Add(addFact);
    }

    /** FixKingdomSystemBuffsAndStats */
    public static ActionListBuilder FixKingdomSystemBuffsAndStats(
        this ActionListBuilder builder,
        float? statPerFinances = null,
        float? statPerMaterials = null,
        float? statPerFavors = null,
        float? expDiplomacyCoefficient = null,
        float? diplomacyBonusCoefficient = null)
    {
      var fix = ElementTool.Create<FixKingdomSystemBuffsAndStats>();
      fix.m_StatPerFinances =
          statPerFinances is null ? fix.m_StatPerFinances : statPerFinances.Value;
      fix.m_StatPerMaterials =
          statPerMaterials is null ? fix.m_StatPerMaterials : statPerMaterials.Value;
      fix.m_StatPerFavors =
          statPerFavors is null ? fix.m_StatPerFavors : statPerFavors.Value;
      fix.m_UnitExpDiplomacyCoefficient =
          expDiplomacyCoefficient is null
              ? fix.m_UnitExpDiplomacyCoefficient
              : expDiplomacyCoefficient.Value;
      fix.m_DiplomacyBonusCoefficient =
          diplomacyBonusCoefficient is null
              ? fix.m_DiplomacyBonusCoefficient
              : diplomacyBonusCoefficient.Value;
      return builder.Add(fix);
    }

    /** ReenterScriptzone */
    public static ActionListBuilder ReEnterScriptZone(
        this ActionListBuilder builder, EntityReference scriptZone)
    {
      var reEnter = ElementTool.Create<ReenterScriptzone>();
      reEnter.m_ScriptZone = scriptZone;
      return builder.Add(reEnter);
    }

    /** RefreshCrusadeLogistic */
    public static ActionListBuilder RefreshCrusadeLogistic(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<RefreshCrusadeLogistic>());
    }

    /** RefreshSettingsPreset */
    public static ActionListBuilder RefreshSettingsPreset(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<RefreshSettingsPreset>());
    }

    /**
     * PlayerUpgraderOnlyActions.RemoveFact
     *
     * @param fact BlueprintUnitFact
     * @param ignoreFacts BlueprintUnitFact If the target has any of these facts, fact is not
     *   removed.
     */
    public static ActionListBuilder RemoveFact(
        this ActionListBuilder builder,
        string fact,
        params string[] ignoreFacts)
    {
      var removeFact = ElementTool.Create<
          Kingmaker.EntitySystem.Persistence.Versioning.PlayerUpgraderOnlyActions.RemoveFact>();
      removeFact.m_Fact = BlueprintTool.GetRef<BlueprintUnitFact, BlueprintUnitFactReference>(fact);
      removeFact.m_AdditionalExceptHasFacts =
          ignoreFacts
              .Select(
                  ignore =>
                      BlueprintTool.GetRef<BlueprintUnitFact, BlueprintUnitFactReference>(ignore))
              .ToArray();
      removeFact.m_ExceptHasFact =
          BlueprintReferenceBase.CreateTyped<BlueprintUnitFactReference>(null);
      return builder.Add(removeFact);
    }

    /** ResetMinDifficulty */
    public static ActionListBuilder ResetMinDifficulty(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ResetMinDifficulty>());
    }

    /**
     * FixItemInInventory
     *
     * @param addItem BlueprintItem
     * @param removeItem BlueprintItem
     */
    public static ActionListBuilder FixItemInInventory(
        this ActionListBuilder builder,
        string addItem = null,
        string removeItem = null,
        bool equipItem = false)
    {
      var fix = ElementTool.Create<FixItemInInventory>();
      fix.m_ToAdd =
          addItem is null
              ? BlueprintReferenceBase.CreateTyped<BlueprintItemReference>(null)
              : BlueprintTool.GetRef<BlueprintItem, BlueprintItemReference>(addItem);
      fix.m_ToRemove =
          removeItem is null
              ? BlueprintReferenceBase.CreateTyped<BlueprintItemReference>(null)
              : BlueprintTool.GetRef<BlueprintItem, BlueprintItemReference>(removeItem);
      fix.m_TryEquip = equipItem;
      return builder.Add(fix);
    }

    /** RecreateOnLoad */
    public static ActionListBuilder ReCreateOnLoad(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<RecreateOnLoad>());
    }

    /** SetAlignmentFromBlueprint */
    public static ActionListBuilder SetAlignmentFromBlueprint(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<SetAlignmentFromBlueprint>());
    }

    /** SetHandsFromBlueprint */
    public static ActionListBuilder SetHandsFromBlueprint(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<SetHandsFromBlueprint>());
    }

    /**
     * AddFeatureFromProgression
     *
     * @param feature BlueprintFeature
     * @param progression BlueprintProgression
     * @param archetype BlueprintArchetype
     * @param selection BlueprintFeatureSelection
     * @param ignoreFeature BlueprintFeature
     */
    public static ActionListBuilder AddFeatureFromProgression(
        this ActionListBuilder builder,
        string feature,
        string progression,
        int level,
        string archetype = null,
        string selection = null,
        string ignoreFeature = null)
    {
      var addFeature = ElementTool.Create<AddFeatureFromProgression>();
      addFeature.m_Feature =
          BlueprintTool.GetRef<BlueprintFeature, BlueprintFeatureReference>(feature);
      addFeature.m_Progression =
          BlueprintTool.GetRef<BlueprintProgression, BlueprintProgressionReference>(progression);
      addFeature.m_Level = level;
      addFeature.m_Archetype =
          archetype is null
              ? BlueprintReferenceBase.CreateTyped<BlueprintArchetypeReference>(null)
              : BlueprintTool.GetRef<BlueprintArchetype, BlueprintArchetypeReference>(archetype);
      addFeature.m_Selection =
          selection is null
              ? BlueprintReferenceBase.CreateTyped<BlueprintFeatureSelectionReference>(null)
              : BlueprintTool
                  .GetRef<BlueprintFeatureSelection, BlueprintFeatureSelectionReference>(selection);
      addFeature.m_ExceptHasFeature =
          ignoreFeature is null
              ? BlueprintReferenceBase.CreateTyped<BlueprintFeatureReference>(null)
              : BlueprintTool.GetRef<BlueprintFeature, BlueprintFeatureReference>(ignoreFeature);
      return builder.Add(addFeature);
    }

    /**
     * RecheckEtude
     *
     * @param etude BlueprintEtude
     */
    public static ActionListBuilder ReCheckEtude(
        this ActionListBuilder builder, string etude, bool redoAfterTrigger = false)
    {
      var reCheck = ElementTool.Create<RecheckEtude>();
      reCheck.Etude = BlueprintTool.GetRef<BlueprintEtude, BlueprintEtudeReference>(etude);
      reCheck.m_RedoOnceTriggers = redoAfterTrigger;
      return builder.Add(reCheck);
    }

    /** RefreshAllArmyLeaders */
    public static ActionListBuilder RefreshAllArmyLeaders(
        this ActionListBuilder builder, bool playerOnly = false)
    {
      var refresh = ElementTool.Create<RefreshAllArmyLeaders>();
      refresh.m_OnlyPlayerLeaders = playerOnly;
      return builder.Add(refresh);
    }

    /**
     * RemoveFeatureFromProgression
     *
     * @param feature BlueprintFeature
     * @param progression BlueprintProgression
     * @param archetype BlueprintArchetype
     * @param ignoreFeature BlueprintFeature
     */
    public static ActionListBuilder RemoveFeatureFromProgression(
        this ActionListBuilder builder,
        string feature,
        string progression,
        int level,
        string archetype = null,
        string ignoreFeature = null)
    {
      var removeFeature = ElementTool.Create<RemoveFeatureFromProgression>();
      removeFeature.m_Feature =
          BlueprintTool.GetRef<BlueprintFeature, BlueprintFeatureReference>(feature);
      removeFeature.m_Progression =
          BlueprintTool.GetRef<BlueprintProgression, BlueprintProgressionReference>(progression);
      removeFeature.m_Level = level;
      removeFeature.m_Archetype =
          archetype is null
              ? BlueprintReferenceBase.CreateTyped<BlueprintArchetypeReference>(null)
              : BlueprintTool.GetRef<BlueprintArchetype, BlueprintArchetypeReference>(archetype);
      removeFeature.m_ExceptHasFeature =
          ignoreFeature is null
              ? BlueprintReferenceBase.CreateTyped<BlueprintFeatureReference>(null)
              : BlueprintTool.GetRef<BlueprintFeature, BlueprintFeatureReference>(ignoreFeature);
      return builder.Add(removeFeature);
    }

    /**
     * ReplaceFeature
     *
     * @param oldFeature BlueprintFeature
     * @param newFeature BlueprintFeature
     * @param progression BlueprintProgression
     * @param ignoreFeature BlueprintFeature
     */
    public static ActionListBuilder ReplaceFeature(
        this ActionListBuilder builder,
        string oldFeature,
        string newFeature,
        string progression,
        string ignoreFeature = null)
    {
      var replaceFeature = ElementTool.Create<ReplaceFeature>();
      replaceFeature.m_ToReplace =
          BlueprintTool.GetRef<BlueprintFeature, BlueprintFeatureReference>(oldFeature);
      replaceFeature.m_Replacement =
          BlueprintTool.GetRef<BlueprintFeature, BlueprintFeatureReference>(newFeature);
      replaceFeature.m_FromProgression =
          BlueprintTool.GetRef<BlueprintProgression, BlueprintProgressionReference>(progression);
      replaceFeature.m_ExceptHasFeature =
          ignoreFeature is null
              ? BlueprintReferenceBase.CreateTyped<BlueprintFeatureReference>(null)
              : BlueprintTool.GetRef<BlueprintFeature, BlueprintFeatureReference>(ignoreFeature);
      return builder.Add(replaceFeature);
    }

    /** RestartTacticalCombat */
    public static ActionListBuilder RestartTacticalCombat(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<RestartTacticalCombat>());
    }

    /**
     * SetSharedVendorTable
     * 
     * @param table BlueprintSharedVendorTable
     */
    public static ActionListBuilder SetSharedVendorTable(
        this ActionListBuilder builder, string table, UnitEvaluator unit)
    {
      builder.Validate(unit);

      var setVendorTable = new SetSharedVendorTable(unit);
      ElementTool.Init(setVendorTable);
      setVendorTable.m_Table =
          BlueprintTool
              .GetRef<BlueprintSharedVendorTable, BlueprintSharedVendorTableReference>(table);
      setVendorTable.m_Unit = unit;
      return builder.Add(setVendorTable);
    }

    /**
     * StartEtudeForced
     *
     * @param etude BlueprintEtude
     */
    public static ActionListBuilder ForceStartEtude(this ActionListBuilder builder, string etude)
    {
      var startEtude = ElementTool.Create<StartEtudeForced>();
      startEtude.Etude = BlueprintTool.GetRef<BlueprintEtude, BlueprintEtudeReference>(etude);
      return builder.Add(startEtude);
    }

    /**
     * UnStartEtude
     *
     * @param etude BlueprintEtude
     */
    public static ActionListBuilder UnStartEtude(this ActionListBuilder builder, string etude)
    {
      var unStartEtude = ElementTool.Create<UnStartEtude>();
      unStartEtude.Etude = BlueprintTool.GetRef<BlueprintEtude, BlueprintEtudeReference>(etude);
      return builder.Add(unStartEtude);
    }

    //----- -----//

    /** ChangeAlignment */
    public static ActionListBuilder ChangeAlignment(
        this ActionListBuilder builder, UnitEvaluator target, Alignment alignment)
    {
      builder.Validate(target);

      var changeAlignment = ElementTool.Create<ChangeAlignment>();
      changeAlignment.Unit = target;
      changeAlignment.Alignment = alignment;
      return builder.Add(changeAlignment);
    }

    /** ChangePlayerAlignment */
    public static ActionListBuilder ChangePlayerAlignment(
        this ActionListBuilder builder, Alignment alignment, bool unlockAlignment = false)
    {
      var changeAlignment = ElementTool.Create<ChangePlayerAlignment>();
      changeAlignment.TargetAlignment = alignment;
      changeAlignment.CanUnlockAlignment = unlockAlignment;
      return builder.Add(changeAlignment);
    }

    /**
     * AddEntranceChange
     *
     * @param location BlueprintGlobalMapPoint
     * @param newLocation BlueprintAreaEnterPoint
     */
    public static ActionListBuilder ChangeAreaEntrance(
        this ActionListBuilder builder, string location, string newLocation)
    {
      var changeEntrance = ElementTool.Create<AreaEntranceChange>();
      changeEntrance.m_Location =
          BlueprintTool
              .GetRef<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>(location);
      changeEntrance.m_NewEntrance =
          BlueprintTool
              .GetRef<BlueprintAreaEnterPoint, BlueprintAreaEnterPointReference>(newLocation);
      return builder.Add(changeEntrance);
    }

    /** ChangeCurrentAreaName */
    public static ActionListBuilder ChangeCurrentAreaName(
        this ActionListBuilder builder, LocalizedString name)
    {
      var changeName = ElementTool.Create<ChangeCurrentAreaName>();
      changeName.NewName = name;
      return builder.Add(changeName);
    }

    /** ChangeCurrentAreaName */
    public static ActionListBuilder ResetCurrentAreaName(this ActionListBuilder builder)
    {
      var changeName = ElementTool.Create<ChangeCurrentAreaName>();
      changeName.RestoreDefault = true;
      return builder.Add(changeName);
    }

    /** ChangeBookEventImage */
    public static ActionListBuilder ChangeBookImage(this ActionListBuilder builder, SpriteLink image)
    {
      var setImage = ElementTool.Create<ChangeBookEventImage>();
      setImage.m_Image = image;
      return builder.Add(setImage);
    }

    /** CameratoPosition */
    public static ActionListBuilder MoveCamera(
        this ActionListBuilder builder, PositionEvaluator position)
    {
      builder.Validate(position);

      var moveCamera = ElementTool.Create<CameraToPosition>();
      moveCamera.Position = position;
      return builder.Add(moveCamera);
    }

    /**
     * AddCampingEncounter
     *
     * @param encounter BlueprintCampingEncounter
     */
    public static ActionListBuilder AddCampingEncounter(
        this ActionListBuilder builder, string encounter)
    {
      var addEncounter = ElementTool.Create<AddCampingEncounter>();
      addEncounter.m_Encounter =
          BlueprintTool
              .GetRef<BlueprintCampingEncounter, BlueprintCampingEncounterReference>(encounter);
      return builder.Add(addEncounter);
    }

    /** DestroyMapObject */
    public static ActionListBuilder DestroyMapObject(
        this ActionListBuilder builder, MapObjectEvaluator obj)
    {
      var destroy = ElementTool.Create<DestroyMapObject>();
      destroy.MapObject = obj;
      return builder.Add(destroy);
    }

    /** CreateCustomCompanion */
    public static ActionListBuilder CreateCustomCompanion(
        this ActionListBuilder builder,
        bool free = false,
        bool matchPlayerXp = false,
        ActionListBuilder onCreate = null)
    {
      var createCompanion = ElementTool.Create<CreateCustomCompanion>();
      createCompanion.ForFree = free;
      createCompanion.MatchPlayerXpExactly = matchPlayerXp;
      createCompanion.OnCreate = onCreate?.Build() ?? Constants.Empty.Actions;
      return builder.Add(createCompanion);
    }

    /** AddDialogNotification */
    public static ActionListBuilder AddDialogNotification(
        this ActionListBuilder builder, LocalizedString text)
    {
      var notification = ElementTool.Create<AddDialogNotification>();
      notification.Text = text;
      return builder.Add(notification);
    }

    /**
     * CompleteEtude
     *
     * @param etude BlueprintEtude
     */
    public static ActionListBuilder CompleteEtude(
        this ActionListBuilder builder, string etude, BlueprintEvaluator evaluator = null)
    {
      var completeEtude = ElementTool.Create<CompleteEtude>();
      completeEtude.Etude = BlueprintTool.GetRef<BlueprintEtude, BlueprintEtudeReference>(etude);
      if (evaluator != null)
      {
        completeEtude.EtudeEvaluator = evaluator;
        completeEtude.Evaluate = true;
      }
      return builder.Add(completeEtude);
    }

    /** CustomEvent */
    public static ActionListBuilder CustomEvent(this ActionListBuilder builder, string eventId)
    {
      var customEvent = ElementTool.Create<CustomEvent>();
      customEvent.EventId = eventId;
      return builder.Add(customEvent);
    }

    /** AddItemsToCollection */
    public static ActionListBuilder AddItems(
        this ActionListBuilder builder,
        List<LootEntry> items,
        ItemsCollectionEvaluator toCollection,
        bool silent = false,
        bool identify = false)
    {
      builder.Validate(toCollection);

      var addItems = ElementTool.Create<AddItemsToCollection>();
      addItems.Loot = items;
      addItems.ItemsCollection = toCollection;
      addItems.Silent = silent;
      addItems.Identify = identify;
      return builder.Add(addItems);
    }

    /**
     * AddItemsToCollection
     *
     * @param loot BlueprintUnitLoot
     */
    public static ActionListBuilder AddItemsFromBlueprint(
        this ActionListBuilder builder,
        string loot,
        ItemsCollectionEvaluator toCollection,
        bool silent = false,
        bool identify = false)
    {
      builder.Validate(toCollection);

      var addItems = ElementTool.Create<AddItemsToCollection>();
      addItems.m_BlueprintLoot =
          BlueprintTool.GetRef<BlueprintUnitLoot, BlueprintUnitLootReference>(loot);
      addItems.ItemsCollection = toCollection;
      addItems.Silent = silent;
      addItems.Identify = identify;
      return builder.Add(addItems);
    }

    /**
     * AddItemToPlayer
     *
     * -If the item is of type BlueprintItemEquipmentHand use {@link GiveHandSlotItemToPlayer}.
     * -If the item is of type BlueprintItemEquipment use {@link GiveEquipmentToPlayer}.
     *
     * @param item BlueprintItem
     */
    public static ActionListBuilder GiveItemToPlayer(
        this ActionListBuilder builder,
        string item,
        int count = 1,
        bool silent = false,
        bool identify = false)
    {
      var itemBlueprint = BlueprintTool.Get<BlueprintItem>(item);
      if (itemBlueprint is BlueprintItemEquipmentHand)
      {
        throw new InvalidOperationException(
            "Item fits in hand slot. Use GiveHandSlotItemToPlayer()");
      }
      else if (itemBlueprint is BlueprintItemEquipment)
      {
        throw new InvalidOperationException("Item is equippable. Use GiveEquipmentToPlayer()");
      }

      return GiveItemToPlayer(builder, itemBlueprint, count, silent, identify);
    }

    /**
     * AddItemToPlayer
     *
     * -If the item is of type BlueprintItemEquipmentHand use {@link GiveHandSlotItemToPlayer}.
     *
     * @param item BlueprintItem
     */
    public static ActionListBuilder GiveEquipmentToPlayer(
        this ActionListBuilder builder,
        string item,
        bool equip = false,
        UnitEvaluator equipOn = null,
        bool errorIfDidNotEquip = true,
        int count = 1,
        bool silent = false,
        bool identify = false)
    {
      var equipment = BlueprintTool.Get<BlueprintItemEquipment>(item);
      if (equipment is BlueprintItemEquipmentHand)
      {
        throw new InvalidOperationException(
            "Item fits in hand slot. Use GiveHandSlotItemToPlayer()");
      }

      return GiveItemToPlayer(
          builder,
          equipment,
          count,
          silent,
          identify,
          equip: equip,
          equipOn: equipOn,
          errorIfDidNotEquip: errorIfDidNotEquip);
    }

    /**
     * AddItemToPlayer
     *
     * @param item BlueprintItem
     */
    public static ActionListBuilder GiveHandSlotItemToPlayer(
        this ActionListBuilder builder,
        string item,
        bool equip = false,
        UnitEvaluator equipOn = null,
        bool errorIfDidNotEquip = true,
        int preferredHandSlot = 0,
        int count = 1,
        bool silent = false,
        bool identify = false)
    {
      return GiveItemToPlayer(
          builder,
          BlueprintTool.Get<BlueprintItemEquipmentHand>(item),
          count,
          silent,
          identify,
          equip: equip,
          equipOn: equipOn,
          errorIfDidNotEquip: errorIfDidNotEquip,
          preferredHandSlot: preferredHandSlot);
    }

    private static ActionListBuilder GiveItemToPlayer(
        ActionListBuilder builder,
        BlueprintItem item,
        int count,
        bool silent,
        bool identify,
        bool equip = false,
        UnitEvaluator equipOn = null,
        bool errorIfDidNotEquip = true,
        int preferredHandSlot = 0)
    {
      var giveItem = ElementTool.Create<AddItemToPlayer>();
      giveItem.m_ItemToGive = item.ToReference<BlueprintItemReference>();
      giveItem.Equip = equip;
      giveItem.ErrorIfDidNotEquip = errorIfDidNotEquip;
      giveItem.PreferredWeaponSet = preferredHandSlot;
      giveItem.Quantity = count;
      giveItem.Silent = silent;
      giveItem.Identify = identify;

      if (equipOn is not null)
      {
        builder.Validate(equipOn);
        giveItem.EquipOn = equipOn;
      }
      return builder.Add(giveItem);
    }

    /** ContextActionAddRandomTrashItem */
    public static ActionListBuilder GiveRandomTrashToPlayer(
        this ActionListBuilder builder,
        TrashLootType type,
        int maxCost,
        bool identify = false,
        bool silent = false)
    {
      var addTrash = ElementTool.Create<ContextActionAddRandomTrashItem>();
      addTrash.m_LootType = type;
      addTrash.m_MaxCost = maxCost;
      addTrash.m_Identify = identify;
      addTrash.m_Silent = silent;
      return builder.Add(addTrash);
    }

    /** AdvanceUnitLevel */
    public static ActionListBuilder AdvanceLevel(
        this ActionListBuilder builder, UnitEvaluator unit, IntEvaluator targetLevel)
    {
      builder.Validate(unit);
      builder.Validate(targetLevel);

      var advanceLevel = ElementTool.Create<AdvanceUnitLevel>();
      advanceLevel.Unit = unit;
      advanceLevel.Level = targetLevel;
      return builder.Add(advanceLevel);
    }

    /**
     * ChangeRomance
     *
     * @param romance BlueprintRomanceCounter
     */
    public static ActionListBuilder ChangeRomance(
       this ActionListBuilder builder, string romance, IntEvaluator value)
    {
      builder.Validate(value);

      var changeRomance = ElementTool.Create<ChangeRomance>();
      changeRomance.m_Romance =
          BlueprintTool.GetRef<BlueprintRomanceCounter, BlueprintRomanceCounterReference>(romance);
      changeRomance.ValueEvaluator = value;
      return builder.Add(changeRomance);
    }

    /** DestroyUnit */
    public static ActionListBuilder DestroyUnit(
        this ActionListBuilder builder, UnitEvaluator unit, bool fadeOut = false)
    {
      builder.Validate(unit);

      var destroy = ElementTool.Create<DestroyUnit>();
      destroy.Target = unit;
      destroy.FadeOut = fadeOut;
      return builder.Add(destroy);
    }

    /** CombineToGroup */
    public static ActionListBuilder AddUnitToGroup(
        this ActionListBuilder builder, UnitEvaluator unit, UnitEvaluator group)
    {
      builder.Validate(unit);
      builder.Validate(group);

      var addToGroup = ElementTool.Create<CombineToGroup>();
      addToGroup.TargetUnit = unit;
      addToGroup.GroupHolder = group;
      return builder.Add(addToGroup);
    }

    /** ChangeUnitName */
    public static ActionListBuilder ChangeUnitName(
        this ActionListBuilder builder,
        UnitEvaluator unit,
        LocalizedString name,
        bool appendName = false)
    {
      builder.Validate(unit);

      var changeName = ElementTool.Create<ChangeUnitName>();
      changeName.Unit = unit;
      changeName.NewName = name;
      changeName.AddToTheName = appendName;
      return builder.Add(changeName);
    }

    /** ChangeUnitName */
    public static ActionListBuilder ResetUnitName(
        this ActionListBuilder builder, UnitEvaluator unit)
    {
      builder.Validate(unit);

      var changeName = ElementTool.Create<ChangeUnitName>();
      changeName.Unit = unit;
      changeName.ReturnTheOldName = true;
      return builder.Add(changeName);
    }

    /** ClearUnitReturnPosition */
    public static ActionListBuilder ClearUnitReturnPosition(
        this ActionListBuilder builder, UnitEvaluator unit)
    {
      builder.Validate(unit);

      var clearReturnPosition = ElementTool.Create<ClearUnitReturnPosition>();
      clearReturnPosition.Unit = unit;
      return builder.Add(clearReturnPosition);
    }

    /** ClearUnitReturnPosition */
    public static ActionListBuilder ClearAllUnitReturnPosition(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ClearUnitReturnPosition>());
    }

    /**
     * AddUnitToSummonPool
     *
     * @param pool BlueprintSummonPool
     */
    public static ActionListBuilder AddUnitToSummonPool(
        this ActionListBuilder builder, UnitEvaluator unit, string pool)
    {
      builder.Validate(unit);

      var addSummon = ElementTool.Create<AddUnitToSummonPool>();
      addSummon.m_SummonPool =
          BlueprintTool.GetRef<BlueprintSummonPool, BlueprintSummonPoolReference>(pool);
      addSummon.Unit = unit;
      return builder.Add(addSummon);
    }

    /**
     * DeleteUnitFromSummonPool
     *
     * @param pool BlueprintSummonPool
     */
    public static ActionListBuilder RemoveUnitFromSummonPool(
        this ActionListBuilder builder, UnitEvaluator unit, string pool)
    {
      builder.Validate(unit);

      var addSummon = ElementTool.Create<DeleteUnitFromSummonPool>();
      addSummon.m_SummonPool =
          BlueprintTool.GetRef<BlueprintSummonPool, BlueprintSummonPoolReference>(pool);
      addSummon.Unit = unit;
      return builder.Add(addSummon);
    }

    //----- FX -----//

    /** ClearBlood */
    public static ActionListBuilder ClearBlood(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ClearBlood>());
    }
  }
}