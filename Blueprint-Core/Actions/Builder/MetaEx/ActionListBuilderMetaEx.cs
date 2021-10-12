using System;
using System.Collections.Generic;
using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Achievements.Actions;
using Kingmaker.Achievements.Blueprints;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Localization;
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

    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

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