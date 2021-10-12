using System;
using System.Collections.Generic;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Tests.Asserts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Xunit;


namespace BlueprintCore.Tests.Actions
{
  public class ActionListBuilderBasicExTest : ActionListBuilderTestBase
  {
    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    [Fact]
    public void AttachBuff()
    {
      IntConstant.Value = 5;

      var actions =
          ActionListBuilder.New()
              .AttachBuff(BuffGuid, ClickedUnit, IntConstant)
              .Build();

      Assert.Single(actions.Actions);
      var attachBuff = (AttachBuff)actions.Actions[0];
      ElementAsserts.IsValid(attachBuff);

      Assert.Equal(Buff.ToReference<BlueprintBuffReference>(), attachBuff.m_Buff);
      Assert.Equal(ClickedUnit, attachBuff.Target);
      Assert.Equal(5, attachBuff.Duration.GetValue());
    }

    [Fact]
    public void OnCreaturesAround()
    {
      var actions =
          ActionListBuilder.New()
              .OnCreaturesAround(
                  ActionListBuilder.New().ClearAllUnitReturnPosition(), Distance, NearestPosition)
              .Build();

      Assert.Single(actions.Actions);
      var onCreatures = (CreaturesAround)actions.Actions[0];
      ElementAsserts.IsValid(onCreatures);

      Assert.Single(onCreatures.Actions.Actions);
      Assert.IsType<ClearUnitReturnPosition>(onCreatures.Actions.Actions[0]);

      Assert.Equal(Distance, onCreatures.Radius);
      Assert.Equal(NearestPosition, onCreatures.Center);
      Assert.False(onCreatures.CheckLos);
      Assert.False(onCreatures.IncludeDead);
    }

    [Fact]
    public void OnCreaturesAround_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .OnCreaturesAround(
                  ActionListBuilder.New().ClearAllUnitReturnPosition(),
                  Distance,
                  NearestPosition,
                  checkLos: true,
                  targetDead: true)
              .Build();

      Assert.Single(actions.Actions);
      var onCreatures = (CreaturesAround)actions.Actions[0];
      ElementAsserts.IsValid(onCreatures);

      Assert.Single(onCreatures.Actions.Actions);
      Assert.IsType<ClearUnitReturnPosition>(onCreatures.Actions.Actions[0]);

      Assert.Equal(Distance, onCreatures.Radius);
      Assert.Equal(NearestPosition, onCreatures.Center);
      Assert.True(onCreatures.CheckLos);
      Assert.True(onCreatures.IncludeDead);
    }

    [Fact]
    public void AddFact()
    {
      var actions = ActionListBuilder.New().AddFact(BuffGuid, ClickedUnit).Build();

      Assert.Single(actions.Actions);
      var addFact = (AddFact)actions.Actions[0];
      ElementAsserts.IsValid(addFact);

      Assert.Equal(Buff.ToReference<BlueprintUnitFactReference>(), addFact.m_Fact);
      Assert.Equal(ClickedUnit, addFact.Unit);
    }

    [Fact]
    public void AddFatigue()
    {
      var hours = ElementTool.Create<IntConstant>();

      var actions = ActionListBuilder.New().AddFatigue(hours, ClickedUnit).Build();

      Assert.Single(actions.Actions);
      var fatigue = (AddFatigueHours)actions.Actions[0];
      ElementAsserts.IsValid(fatigue);

      Assert.Equal(hours, fatigue.Hours);
      Assert.Equal(ClickedUnit, fatigue.Unit);
    }

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
    public void DamageParty()
    {
      var actions = ActionListBuilder.New().DamageParty(Damage).Build();

      Assert.Single(actions.Actions);
      var dmg = (DamageParty)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(Damage, dmg.Damage);
      Assert.True(dmg.NoSource);
      Assert.False(dmg.DamageSource);
    }

    [Fact]
    public void DamageParty_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .DamageParty(Damage, source: ClickedUnit, enableBattleLog: false)
              .Build();

      Assert.Single(actions.Actions);
      var dmg = (DamageParty)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(Damage, dmg.Damage);
      Assert.False(dmg.NoSource);
      Assert.True(dmg.DamageSource);
      Assert.Equal(ClickedUnit, dmg.DamageSource);
    }

    [Fact]
    public void DealDamage()
    {
      var actions = ActionListBuilder.New().DealDamage(ClickedUnit, Damage).Build();

      Assert.Single(actions.Actions);
      var dmg = (DealDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(Damage, dmg.Damage);
      Assert.Equal(ClickedUnit, dmg.Target);
      Assert.True(dmg.NoSource);

      Assert.False(dmg.DisableBattleLog);
      Assert.False(dmg.DisableFxAndSound);
    }

    [Fact]
    public void DealDamage_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .DealDamage(
                  ClickedUnit,
                  Damage,
                  source: ClickedUnit,
                  enableBattleLog: false,
                  enableFxAndSound: false)
              .Build();

      Assert.Single(actions.Actions);
      var dmg = (DealDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(Damage, dmg.Damage);
      Assert.Equal(ClickedUnit, dmg.Target);
      Assert.False(dmg.NoSource);
      Assert.Equal(ClickedUnit, dmg.Source);

      Assert.True(dmg.DisableBattleLog);
      Assert.True(dmg.DisableFxAndSound);
    }

    [Fact]
    public void DealStatDamage()
    {
      var actions =
          ActionListBuilder.New()
              .DealStatDamage(ClickedUnit, StatType.Strength, new DiceFormula(1, DiceType.D4))
              .Build();

      Assert.Single(actions.Actions);
      var dmg = (DealStatDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(ClickedUnit, dmg.Target);
      Assert.Equal(StatType.Strength, dmg.Stat);
      Assert.Equal(1, dmg.DamageDice.Rolls);
      Assert.Equal(DiceType.D4, dmg.DamageDice.Dice);
      Assert.Equal(0, dmg.DamageBonus);

      Assert.False(dmg.IsDrain);
      Assert.False(dmg.DisableBattleLog);
      Assert.True(dmg.NoSource);
    }

    [Fact]
    public void DealStatDamage_WithInvalidStat()
    {
      Assert.Throws<InvalidOperationException>(
          () =>
            ActionListBuilder.New()
                .DealStatDamage(ClickedUnit, StatType.AC, new DiceFormula(1, DiceType.D4))
                .Build());
    }

    [Fact]
    public void DealStatDamage_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .DealStatDamage(
                  ClickedUnit,
                  StatType.Wisdom,
                  new DiceFormula(2, DiceType.D6),
                  damageBonus: 2,
                  source: ClickedUnit,
                  drain: true,
                  enableBattleLog: false)
              .Build();

      Assert.Single(actions.Actions);
      var dmg = (DealStatDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(ClickedUnit, dmg.Target);
      Assert.Equal(StatType.Wisdom, dmg.Stat);
      Assert.Equal(2, dmg.DamageDice.Rolls);
      Assert.Equal(DiceType.D6, dmg.DamageDice.Dice);
      Assert.Equal(2, dmg.DamageBonus);

      Assert.True(dmg.IsDrain);
      Assert.True(dmg.DisableBattleLog);
      Assert.False(dmg.NoSource);
      Assert.Equal(ClickedUnit, dmg.Source);
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
  }
}
