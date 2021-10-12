using System;
using System.Collections.Generic;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Actions.Builder.MetaEx;
using BlueprintCore.Tests.Asserts;
using BlueprintCore.Utils;
using Kingmaker.Achievements.Actions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.Dungeon.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Xunit;

namespace BlueprintCore.Tests.Actions
{
  public class ActionListBuilderMetaExTest : ActionListBuilderTestBase
  {
    //----- Kingmaker.Achievements.Actions -----//

    [Fact]
    public void IncrementAchievement()
    {
      var actions =
          ActionListBuilder.New()
              .IncrementAchievement(AchievementGuid)
              .Build();

      Assert.Single(actions.Actions);
      var increment = (ActionAchievementIncrementCounter)actions.Actions[0];
      ElementAsserts.IsValid(increment);

      Assert.Equal(Achievement.ToReference<AchievementDataReference>(), increment.m_Achievement);
    }

    [Fact]
    public void UnlockAchievement()
    {
      var actions =
          ActionListBuilder.New()
              .UnlockAchievement(AchievementGuid)
              .Build();

      Assert.Single(actions.Actions);
      var unlock = (ActionAchievementUnlock)actions.Actions[0];
      ElementAsserts.IsValid(unlock);

      Assert.Equal(Achievement.ToReference<AchievementDataReference>(), unlock.m_Achievement);
    }

    //----- Kingmaker.Dungeon.Actions -----//

    [Fact]
    public void CreateImportedCompanion()
    {
      var actions = ActionListBuilder.New().CreateImportedCompanion(5).Build();

      Assert.Single(actions.Actions);
      var createCompanion = (ActionCreateImportedCompanion)actions.Actions[0];
      ElementAsserts.IsValid(createCompanion);

      Assert.Equal(5, createCompanion.Index);
    }

    [Fact]
    public void TeleportToLastDungeonStageEntrance()
    {
      var actions = ActionListBuilder.New().TeleportToLastDungeonStageEntrance().Build();

      Assert.Single(actions.Actions);
      var teleport = (ActionEnterToDungeon)actions.Actions[0];
      ElementAsserts.IsValid(teleport);

      Assert.Equal(1, teleport.FirstStage);
    }

    [Fact]
    public void TeleportToLastDungeonStageEntrance_WithMinStage()
    {
      var actions = ActionListBuilder.New().TeleportToLastDungeonStageEntrance(3).Build();

      Assert.Single(actions.Actions);
      var teleport = (ActionEnterToDungeon)actions.Actions[0];
      ElementAsserts.IsValid(teleport);

      Assert.Equal(3, teleport.FirstStage);
    }

    [Fact]
    public void EnterNextDungeonStage()
    {
      var actions = ActionListBuilder.New().EnterNextDungeonStage().Build();

      Assert.Single(actions.Actions);
      var nextStage = (ActionGoDeeperIntoDungeon)actions.Actions[0];
      ElementAsserts.IsValid(nextStage);
    }

    [Fact]
    public void IncrementDungeonStage()
    {
      var actions = ActionListBuilder.New().IncrementDungeonStage().Build();

      Assert.Single(actions.Actions);
      var increment = (ActionIncreaseDungeonStage)actions.Actions[0];
      ElementAsserts.IsValid(increment);
    }

    [Fact]
    public void SetDungeonStage()
    {
      var actions = ActionListBuilder.New().SetDungeonStage().Build();

      Assert.Single(actions.Actions);
      var setStage = (ActionSetDungeonStage)actions.Actions[0];
      ElementAsserts.IsValid(setStage);

      Assert.Equal(1, setStage.Stage);
    }

    [Fact]
    public void SetDungeonStage_WithStage()
    {
      var actions = ActionListBuilder.New().SetDungeonStage(2).Build();

      Assert.Single(actions.Actions);
      var setStage = (ActionSetDungeonStage)actions.Actions[0];
      ElementAsserts.IsValid(setStage);

      Assert.Equal(2, setStage.Stage);
    }

    //----- -----//

    [Fact]
    public void ChangeAlignment()
    {
      var actions =
          ActionListBuilder.New().ChangeAlignment(ClickedUnit, Alignment.LawfulEvil).Build();

      Assert.Single(actions.Actions);
      var changeAlignment = (ChangeAlignment)actions.Actions[0];
      ElementAsserts.IsValid(changeAlignment);

      Assert.Equal(ClickedUnit, changeAlignment.Unit);
      Assert.Equal(Alignment.LawfulEvil, changeAlignment.Alignment);
    }

    [Fact]
    public void ChangePlayerAlignment()
    {
      var actions = ActionListBuilder.New().ChangePlayerAlignment(Alignment.ChaoticGood).Build();

      Assert.Single(actions.Actions);
      var changeAlignment = (ChangePlayerAlignment)actions.Actions[0];
      ElementAsserts.IsValid(changeAlignment);

      Assert.Equal(Alignment.ChaoticGood, changeAlignment.TargetAlignment);
      Assert.False(changeAlignment.CanUnlockAlignment);
    }

    [Fact]
    public void ChangePlayerAlignment_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .ChangePlayerAlignment(Alignment.TrueNeutral, unlockAlignment: true)
              .Build();

      Assert.Single(actions.Actions);
      var changeAlignment = (ChangePlayerAlignment)actions.Actions[0];
      ElementAsserts.IsValid(changeAlignment);

      Assert.Equal(Alignment.TrueNeutral, changeAlignment.TargetAlignment);
      Assert.True(changeAlignment.CanUnlockAlignment);
    }

    [Fact]
    public void ChangeAreaEntrance()
    {
      var actions =
          ActionListBuilder.New()
              .ChangeAreaEntrance(GlobalMapPointGuid, AreaEnterPointGuid)
              .Build();

      Assert.Single(actions.Actions);
      var changeEntrance = (AreaEntranceChange)actions.Actions[0];
      ElementAsserts.IsValid(changeEntrance);

      Assert.Equal(
          GlobalMapPoint.ToReference<BlueprintGlobalMapPoint.Reference>(),
          changeEntrance.m_Location);

      Assert.Equal(
          AreaEnterPoint.ToReference<BlueprintAreaEnterPointReference>(),
          changeEntrance.m_NewEntrance);
    }

    [Fact]
    public void ChangeCurrentAreaName()
    {
      var name = new LocalizedString { Key = "name" };

      var actions = ActionListBuilder.New().ChangeCurrentAreaName(name).Build();

      Assert.Single(actions.Actions);
      var changeName = (ChangeCurrentAreaName)actions.Actions[0];
      ElementAsserts.IsValid(changeName);

      Assert.Equal(name, changeName.NewName);
      Assert.False(changeName.RestoreDefault);
    }

    [Fact]
    public void ResetCurrentAreaName()
    {
      var actions = ActionListBuilder.New().ResetCurrentAreaName().Build();

      Assert.Single(actions.Actions);
      var changeName = (ChangeCurrentAreaName)actions.Actions[0];
      ElementAsserts.IsValid(changeName);

      Assert.True(changeName.RestoreDefault);
    }

    [Fact]
    public void ChangeBookImage()
    {
      var image = new SpriteLink { AssetId = "hi" };

      var actions = ActionListBuilder.New().ChangeBookImage(image).Build();

      Assert.Single(actions.Actions);
      var setImage = (ChangeBookEventImage)actions.Actions[0];
      ElementAsserts.IsValid(setImage);

      Assert.Equal(image, setImage.m_Image);
    }

    [Fact]
    public void MoveCamera()
    {
      var position = ElementTool.Create<UnitPosition>();
      position.Unit = ClickedUnit;

      var actions = ActionListBuilder.New().MoveCamera(position).Build();

      Assert.Single(actions.Actions);
      var moveCamera = (CameraToPosition)actions.Actions[0];
      ElementAsserts.IsValid(moveCamera);

      Assert.Equal(position, moveCamera.Position);
    }

    [Fact]
    public void AddCampingEncounter()
    {
      var actions = ActionListBuilder.New().AddCampingEncounter(CampingEncounterGuid).Build();

      Assert.Single(actions.Actions);
      var addEncounter = (AddCampingEncounter)actions.Actions[0];
      ElementAsserts.IsValid(addEncounter);

      Assert.Equal(
          CampingEncounter.ToReference<BlueprintCampingEncounterReference>(),
          addEncounter.m_Encounter);
    }

    [Fact]
    public void DestroyMapObject()
    {
      var actions = ActionListBuilder.New().DestroyMapObject(Trap).Build();

      Assert.Single(actions.Actions);
      var destroy = (DestroyMapObject)actions.Actions[0];
      ElementAsserts.IsValid(destroy);

      Assert.Equal(Trap, destroy.MapObject);
    }

    [Fact]
    public void CreateCustomCompanion()
    {
      var actions = ActionListBuilder.New().CreateCustomCompanion().Build();

      Assert.Single(actions.Actions);
      var createCompanion = (CreateCustomCompanion)actions.Actions[0];
      ElementAsserts.IsValid(createCompanion);

      Assert.False(createCompanion.ForFree);
      Assert.False(createCompanion.MatchPlayerXpExactly);
      Assert.NotNull(createCompanion.OnCreate.Actions);
    }

    [Fact]
    public void CreateCustomCompanion_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .CreateCustomCompanion(
                  free: true,
                  matchPlayerXp: true,
                  onCreate: ActionListBuilder.New().MeleeAttack())
              .Build();

      Assert.Single(actions.Actions);
      var createCompanion = (CreateCustomCompanion)actions.Actions[0];
      ElementAsserts.IsValid(createCompanion);

      Assert.True(createCompanion.ForFree);
      Assert.True(createCompanion.MatchPlayerXpExactly);
      Assert.Single(createCompanion.OnCreate.Actions);
      Assert.IsType<ContextActionMeleeAttack>(createCompanion.OnCreate.Actions[0]);
    }

    [Fact]
    public void AddDialogNotification()
    {
      var text = new LocalizedString { Key = "test_key" };

      var actions =
          ActionListBuilder.New().AddDialogNotification(text).Build();

      Assert.Single(actions.Actions);
      var notification = (AddDialogNotification)actions.Actions[0];
      ElementAsserts.IsValid(notification);

      Assert.Equal(text.Key, notification.Text.Key);
    }

    [Fact]
    public void CompleteEtude()
    {
      var actions = ActionListBuilder.New().CompleteEtude(EtudeGuid).Build();

      Assert.Single(actions.Actions);
      var completeEtude = (CompleteEtude)actions.Actions[0];
      ElementAsserts.IsValid(completeEtude);

      Assert.Equal(Etude.ToReference<BlueprintEtudeReference>(), completeEtude.Etude);
      Assert.False(completeEtude.Evaluate);
    }

    [Fact]
    public void CompleteEtude_WithEvaluator()
    {
      var evaluator = ElementTool.Create<Dialog>();

      var actions = ActionListBuilder.New().CompleteEtude(EtudeGuid, evaluator: evaluator).Build();

      Assert.Single(actions.Actions);
      var completeEtude = (CompleteEtude)actions.Actions[0];
      ElementAsserts.IsValid(completeEtude);

      Assert.Equal(Etude.ToReference<BlueprintEtudeReference>(), completeEtude.Etude);
      Assert.Equal(evaluator, completeEtude.EtudeEvaluator);
      Assert.True(completeEtude.Evaluate);
    }

    [Fact]
    public void CustomEvent()
    {
      var eventId = "event_id";
      var actions = ActionListBuilder.New().CustomEvent(eventId).Build();

      Assert.Single(actions.Actions);
      var customEvent = (CustomEvent)actions.Actions[0];
      ElementAsserts.IsValid(customEvent);

      Assert.Equal(eventId, customEvent.EventId);
    }

    [Fact]
    public void AddItems()
    {
      var items = new List<LootEntry>();
      var toCollection = ElementTool.Create<UnitInventory>();

      var actions = ActionListBuilder.New().AddItems(items, toCollection).Build();

      Assert.Single(actions.Actions);
      var addItems = (AddItemsToCollection)actions.Actions[0];
      ElementAsserts.IsValid(addItems);

      Assert.Equal(items, addItems.Loot);
      Assert.Equal(toCollection, addItems.ItemsCollection);
      Assert.False(addItems.Silent);
      Assert.False(addItems.Identify);
    }

    [Fact]
    public void AddItems_WithOptionalValues()
    {
      var items = new List<LootEntry>();
      var toCollection = ElementTool.Create<UnitInventory>();

      var actions =
          ActionListBuilder.New()
              .AddItems(items, toCollection, silent: true, identify: true)
              .Build();

      Assert.Single(actions.Actions);
      var addItems = (AddItemsToCollection)actions.Actions[0];
      ElementAsserts.IsValid(addItems);

      Assert.Equal(items, addItems.Loot);
      Assert.Equal(toCollection, addItems.ItemsCollection);
      Assert.True(addItems.Silent);
      Assert.True(addItems.Identify);
    }

    [Fact]
    public void AddItemsFromBlueprint()
    {
      var toCollection = ElementTool.Create<UnitInventory>();

      var actions =
          ActionListBuilder.New().AddItemsFromBlueprint(LootGuid, toCollection).Build();

      Assert.Single(actions.Actions);
      var addItems = (AddItemsToCollection)actions.Actions[0];
      ElementAsserts.IsValid(addItems);

      Assert.Equal(Loot.ToReference<BlueprintUnitLootReference>(), addItems.m_BlueprintLoot);
      Assert.Equal(toCollection, addItems.ItemsCollection);
      Assert.False(addItems.Silent);
      Assert.False(addItems.Identify);
    }

    [Fact]
    public void AddItemsFromBlueprint_WithOptionalValues()
    {
      var toCollection = ElementTool.Create<UnitInventory>();

      var actions =
          ActionListBuilder.New()
              .AddItemsFromBlueprint(LootGuid, toCollection, silent: true, identify: true)
              .Build();

      Assert.Single(actions.Actions);
      var addItems = (AddItemsToCollection)actions.Actions[0];
      ElementAsserts.IsValid(addItems);

      Assert.Equal(Loot.ToReference<BlueprintUnitLootReference>(), addItems.m_BlueprintLoot);
      Assert.Equal(toCollection, addItems.ItemsCollection);
      Assert.True(addItems.Silent);
      Assert.True(addItems.Identify);
    }

    [Fact]
    public void GiveItemToPlayer()
    {
      var actions = ActionListBuilder.New().GiveItemToPlayer(ItemGuid).Build();

      Assert.Single(actions.Actions);
      var addItem = (AddItemToPlayer)actions.Actions[0];
      ElementAsserts.IsValid(addItem);

      Assert.Equal(Item.ToReference<BlueprintItemReference>(), addItem.m_ItemToGive);
      Assert.False(addItem.Equip);
      Assert.Null(addItem.EquipOn);
      Assert.True(addItem.ErrorIfDidNotEquip);
      Assert.Equal(0, addItem.PreferredWeaponSet);
      Assert.Equal(1, addItem.Quantity);
      Assert.False(addItem.Silent);
      Assert.False(addItem.Identify);
    }

    [Fact]
    public void GiveItemToPlayer_WithEquipment()
    {
      Assert.Throws<InvalidOperationException>(
          () =>
            ActionListBuilder.New().GiveItemToPlayer(ArmorGuid).Build());
    }

    [Fact]
    public void GiveItemToPlayer_WithHandSlotItem()
    {
      Assert.Throws<InvalidOperationException>(
          () =>
            ActionListBuilder.New().GiveItemToPlayer(SimpleHandItemGuid).Build());
    }

    [Fact]
    public void GiveItemToPlayer_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .GiveItemToPlayer(ItemGuid, count: 2, silent: true, identify: true)
              .Build();

      Assert.Single(actions.Actions);
      var addItem = (AddItemToPlayer)actions.Actions[0];
      ElementAsserts.IsValid(addItem);

      Assert.Equal(Item.ToReference<BlueprintItemReference>(), addItem.m_ItemToGive);
      Assert.False(addItem.Equip);
      Assert.Null(addItem.EquipOn);
      Assert.True(addItem.ErrorIfDidNotEquip);
      Assert.Equal(0, addItem.PreferredWeaponSet);
      Assert.Equal(2, addItem.Quantity);
      Assert.True(addItem.Silent);
      Assert.True(addItem.Identify);
    }

    [Fact]
    public void GiveEquipmentToPlayer()
    {
      var actions =
          ActionListBuilder.New().GiveEquipmentToPlayer(ArmorGuid).Build();

      Assert.Single(actions.Actions);
      var addItem = (AddItemToPlayer)actions.Actions[0];
      ElementAsserts.IsValid(addItem);

      Assert.Equal(Armor.ToReference<BlueprintItemReference>(), addItem.m_ItemToGive);
      Assert.False(addItem.Equip);
      Assert.Null(addItem.EquipOn);
      Assert.True(addItem.ErrorIfDidNotEquip);
      Assert.Equal(0, addItem.PreferredWeaponSet);
      Assert.Equal(1, addItem.Quantity);
      Assert.False(addItem.Silent);
      Assert.False(addItem.Identify);
    }

    [Fact]
    public void GiveEquipmentToPlayer_WithHandSlotItem()
    {
      Assert.Throws<InvalidOperationException>(
          () =>
            ActionListBuilder.New().GiveEquipmentToPlayer(SimpleHandItemGuid, ClickedUnit).Build());
    }

    [Fact]
    public void GiveEquipmentToPlayer_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .GiveEquipmentToPlayer(
                  ArmorGuid,
                  equip: true,
                  equipOn: ClickedUnit,
                  errorIfDidNotEquip: false,
                  count: 2,
                  silent: true,
                  identify: true)
              .Build();

      Assert.Single(actions.Actions);
      var addItem = (AddItemToPlayer)actions.Actions[0];
      ElementAsserts.IsValid(addItem);

      Assert.Equal(Armor.ToReference<BlueprintItemReference>(), addItem.m_ItemToGive);
      Assert.True(addItem.Equip);
      Assert.Equal(ClickedUnit, addItem.EquipOn);
      Assert.False(addItem.ErrorIfDidNotEquip);
      Assert.Equal(0, addItem.PreferredWeaponSet);
      Assert.Equal(2, addItem.Quantity);
      Assert.True(addItem.Silent);
      Assert.True(addItem.Identify);
    }

    [Fact]
    public void GiveHandSlotItemToPlayer()
    {
      var actions = ActionListBuilder.New().GiveHandSlotItemToPlayer(SimpleHandItemGuid).Build();

      Assert.Single(actions.Actions);
      var addItem = (AddItemToPlayer)actions.Actions[0];
      ElementAsserts.IsValid(addItem);

      Assert.Equal(SimpleHandItem.ToReference<BlueprintItemReference>(), addItem.m_ItemToGive);
      Assert.False(addItem.Equip);
      Assert.Null(addItem.EquipOn);
      Assert.True(addItem.ErrorIfDidNotEquip);
      Assert.Equal(0, addItem.PreferredWeaponSet);
      Assert.Equal(1, addItem.Quantity);
      Assert.False(addItem.Silent);
      Assert.False(addItem.Identify);
    }

    [Fact]
    public void GiveHandSlotItemToPlayer_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .GiveHandSlotItemToPlayer(
                  SimpleHandItemGuid,
                  equip: true,
                  equipOn: ClickedUnit,
                  errorIfDidNotEquip: false,
                  preferredHandSlot: 2,
                  count: 2,
                  silent: true,
                  identify: true)
              .Build();

      Assert.Single(actions.Actions);
      var addItem = (AddItemToPlayer)actions.Actions[0];
      ElementAsserts.IsValid(addItem);

      Assert.Equal(SimpleHandItem.ToReference<BlueprintItemReference>(), addItem.m_ItemToGive);
      Assert.True(addItem.Equip);
      Assert.Equal(ClickedUnit, addItem.EquipOn);
      Assert.False(addItem.ErrorIfDidNotEquip);
      Assert.Equal(2, addItem.PreferredWeaponSet);
      Assert.Equal(2, addItem.Quantity);
      Assert.True(addItem.Silent);
      Assert.True(addItem.Identify);
    }

    [Fact]
    public void GiveRandomTrashToPlayer()
    {
      var actions =
          ActionListBuilder.New().GiveRandomTrashToPlayer(TrashLootType.Scrolls, 2).Build();

      Assert.Single(actions.Actions);
      var giveTrash = (ContextActionAddRandomTrashItem)actions.Actions[0];
      ElementAsserts.IsValid(giveTrash);

      Assert.Equal(TrashLootType.Scrolls, giveTrash.m_LootType);
      Assert.Equal(2, giveTrash.m_MaxCost);
      Assert.False(giveTrash.m_Identify);
      Assert.False(giveTrash.m_Silent);
    }

    [Fact]
    public void GiveRandomTrashToPlayer_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .GiveRandomTrashToPlayer(TrashLootType.Scrolls, 3, identify: true, silent: true)
              .Build();

      Assert.Single(actions.Actions);
      var giveTrash = (ContextActionAddRandomTrashItem)actions.Actions[0];
      ElementAsserts.IsValid(giveTrash);

      Assert.Equal(TrashLootType.Scrolls, giveTrash.m_LootType);
      Assert.Equal(3, giveTrash.m_MaxCost);
      Assert.True(giveTrash.m_Identify);
      Assert.True(giveTrash.m_Silent);
    }

    [Fact]
    public void AdvanceLevel()
    {
      var targetLevel = ElementTool.Create<IntConstant>();

      var actions = ActionListBuilder.New().AdvanceLevel(ClickedUnit, targetLevel).Build();

      Assert.Single(actions.Actions);
      var advanceLevel = (AdvanceUnitLevel)actions.Actions[0];
      ElementAsserts.IsValid(advanceLevel);

      Assert.Equal(ClickedUnit, advanceLevel.Unit);
      Assert.Equal(targetLevel, advanceLevel.Level);
    }

    [Fact]
    public void ChangeRomance()
    {
      var value = ElementTool.Create<IntConstant>();
      value.Value = 12;

      var actions = ActionListBuilder.New().ChangeRomance(RomanceGuid, value).Build();

      Assert.Single(actions.Actions);
      var changeRomance = (ChangeRomance)actions.Actions[0];
      ElementAsserts.IsValid(changeRomance);

      Assert.Equal(
          Romance.ToReference<BlueprintRomanceCounterReference>(), changeRomance.m_Romance);
      Assert.Equal(12, changeRomance.ValueEvaluator.GetValue());
    }

    [Fact]
    public void DestroyUnit()
    {
      var actions = ActionListBuilder.New().DestroyUnit(ClickedUnit).Build();

      Assert.Single(actions.Actions);
      var destroy = (DestroyUnit)actions.Actions[0];
      ElementAsserts.IsValid(destroy);

      Assert.Equal(ClickedUnit, destroy.Target);
      Assert.False(destroy.FadeOut);
    }

    [Fact]
    public void DestroyUnit_WithFadeOut()
    {
      var actions = ActionListBuilder.New().DestroyUnit(ClickedUnit, fadeOut: true).Build();

      Assert.Single(actions.Actions);
      var destroy = (DestroyUnit)actions.Actions[0];
      ElementAsserts.IsValid(destroy);

      Assert.Equal(ClickedUnit, destroy.Target);
      Assert.True(destroy.FadeOut);
    }

    [Fact]
    public void AddUnitToGroup()
    {
      var group = ElementTool.Create<PlayerCharacter>();

      var actions = ActionListBuilder.New().AddUnitToGroup(ClickedUnit, group).Build();

      Assert.Single(actions.Actions);
      var addToGroup = (CombineToGroup)actions.Actions[0];
      ElementAsserts.IsValid(addToGroup);

      Assert.Equal(ClickedUnit, addToGroup.TargetUnit);
      Assert.Equal(group, addToGroup.GroupHolder);
    }

    [Fact]
    public void ChangeUnitName()
    {
      var name = new LocalizedString { Key = "new name" };

      var actions = ActionListBuilder.New().ChangeUnitName(ClickedUnit, name).Build();

      Assert.Single(actions.Actions);
      var changeName = (ChangeUnitName)actions.Actions[0];
      ElementAsserts.IsValid(changeName);

      Assert.Equal(ClickedUnit, changeName.Unit);
      Assert.Equal(name, changeName.NewName);
      Assert.False(changeName.AddToTheName);
      Assert.False(changeName.ReturnTheOldName);
    }

    [Fact]
    public void ChangeUnitName_WithAppendName()
    {
      var name = new LocalizedString { Key = "new name" };

      var actions =
          ActionListBuilder.New().ChangeUnitName(ClickedUnit, name, appendName: true).Build();

      Assert.Single(actions.Actions);
      var changeName = (ChangeUnitName)actions.Actions[0];
      ElementAsserts.IsValid(changeName);

      Assert.Equal(ClickedUnit, changeName.Unit);
      Assert.Equal(name, changeName.NewName);
      Assert.True(changeName.AddToTheName);
      Assert.False(changeName.ReturnTheOldName);
    }

    [Fact]
    public void ResetUnitName()
    {
      var actions = ActionListBuilder.New().ResetUnitName(ClickedUnit).Build();

      Assert.Single(actions.Actions);
      var changeName = (ChangeUnitName)actions.Actions[0];
      ElementAsserts.IsValid(changeName);

      Assert.Equal(ClickedUnit, changeName.Unit);
      Assert.False(changeName.AddToTheName);
      Assert.True(changeName.ReturnTheOldName);
    }

    [Fact]
    public void ClearUnitReturnPosition()
    {
      var actions = ActionListBuilder.New().ClearUnitReturnPosition(ClickedUnit).Build();

      Assert.Single(actions.Actions);
      var clearReturnPosition = (ClearUnitReturnPosition)actions.Actions[0];
      ElementAsserts.IsValid(clearReturnPosition);

      Assert.Equal(ClickedUnit, clearReturnPosition.Unit);
    }

    [Fact]
    public void ClearAllUnitReturnPosition()
    {
      var actions = ActionListBuilder.New().ClearAllUnitReturnPosition().Build();

      Assert.Single(actions.Actions);
      var clearReturnPosition = (ClearUnitReturnPosition)actions.Actions[0];
      ElementAsserts.IsValid(clearReturnPosition);

      Assert.Null(clearReturnPosition.Unit);
    }

    [Fact]
    public void AddUnitToSummonPool()
    {
      var actions =
          ActionListBuilder.New().AddUnitToSummonPool(ClickedUnit, SummonPoolGuid).Build();

      Assert.Single(actions.Actions);
      var addSummon = (AddUnitToSummonPool)actions.Actions[0];
      ElementAsserts.IsValid(addSummon);

      Assert.Equal(ClickedUnit, addSummon.Unit);
      Assert.Equal(SummonPool.ToReference<BlueprintSummonPoolReference>(), addSummon.m_SummonPool);
    }

    [Fact]
    public void RemoveUnitFromSummonPool()
    {
      var actions =
          ActionListBuilder.New().RemoveUnitFromSummonPool(ClickedUnit, SummonPoolGuid).Build();

      Assert.Single(actions.Actions);
      var addSummon = (DeleteUnitFromSummonPool)actions.Actions[0];
      ElementAsserts.IsValid(addSummon);

      Assert.Equal(ClickedUnit, addSummon.Unit);
      Assert.Equal(SummonPool.ToReference<BlueprintSummonPoolReference>(), addSummon.m_SummonPool);
    }

    [Fact]
    public void ClearBlood()
    {
      var actions = ActionListBuilder.New().ClearBlood().Build();

      Assert.Single(actions.Actions);
      var clearBlood = (ClearBlood)actions.Actions[0];
      ElementAsserts.IsValid(clearBlood);
    }
  }
}
