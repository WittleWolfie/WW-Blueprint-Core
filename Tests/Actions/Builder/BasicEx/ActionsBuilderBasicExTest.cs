using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Test.Asserts;
using BlueprintCore.Utils;
using System;
using System.Collections.Generic;
using Xunit;
using static BlueprintCore.Test.TestData;


namespace BlueprintCore.Test.Actions.Builder.BasicEx
{
  public class ActionsBuilderBasicExTest : TestBase
  {
    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    [Fact]
    public void AttachBuff()
    {
      TestInt.Value = 5;

      var actions =
          ActionsBuilder.New()
              .AttachBuff(BuffGuid, TestUnit, TestInt)
              .Build();

      Assert.Single(actions.Actions);
      var attachBuff = (AttachBuff)actions.Actions[0];
      ElementAsserts.IsValid(attachBuff);

      Assert.Equal(Buff.ToReference<BlueprintBuffReference>(), attachBuff.m_Buff);
      Assert.Equal(TestUnit, attachBuff.Target);
      Assert.Equal(5, attachBuff.Duration.GetValue());
    }

    [Fact]
    public void OnCreaturesAround()
    {
      var actions =
          ActionsBuilder.New()
              .OnCreaturesAround(
                  ActionsBuilder.New().ClearAllUnitReturnPosition(), TestDistance, TestPosition)
              .Build();

      Assert.Single(actions.Actions);
      var onCreatures = (CreaturesAround)actions.Actions[0];
      ElementAsserts.IsValid(onCreatures);

      Assert.Single(onCreatures.Actions.Actions);
      Assert.IsType<ClearUnitReturnPosition>(onCreatures.Actions.Actions[0]);

      Assert.Equal(TestDistance, onCreatures.Radius);
      Assert.Equal(TestPosition, onCreatures.Center);
      Assert.False(onCreatures.CheckLos);
      Assert.False(onCreatures.IncludeDead);
    }

    [Fact]
    public void OnCreaturesAround_WithOptionalValues()
    {
      var actions =
          ActionsBuilder.New()
              .OnCreaturesAround(
                  ActionsBuilder.New().ClearAllUnitReturnPosition(),
                  TestDistance,
                  TestPosition,
                  checkLos: true,
                  targetDead: true)
              .Build();

      Assert.Single(actions.Actions);
      var onCreatures = (CreaturesAround)actions.Actions[0];
      ElementAsserts.IsValid(onCreatures);

      Assert.Single(onCreatures.Actions.Actions);
      Assert.IsType<ClearUnitReturnPosition>(onCreatures.Actions.Actions[0]);

      Assert.Equal(TestDistance, onCreatures.Radius);
      Assert.Equal(TestPosition, onCreatures.Center);
      Assert.True(onCreatures.CheckLos);
      Assert.True(onCreatures.IncludeDead);
    }

    [Fact]
    public void AddFact()
    {
      var actions = ActionsBuilder.New().AddFact(BuffGuid, TestUnit).Build();

      Assert.Single(actions.Actions);
      var addFact = (AddFact)actions.Actions[0];
      ElementAsserts.IsValid(addFact);

      Assert.Equal(Buff.ToReference<BlueprintUnitFactReference>(), addFact.m_Fact);
      Assert.Equal(TestUnit, addFact.Unit);
    }

    [Fact]
    public void AddFatigue()
    {
      var hours = ElementTool.Create<IntConstant>();

      var actions = ActionsBuilder.New().AddFatigue(hours, TestUnit).Build();

      Assert.Single(actions.Actions);
      var fatigue = (AddFatigueHours)actions.Actions[0];
      ElementAsserts.IsValid(fatigue);

      Assert.Equal(hours, fatigue.Hours);
      Assert.Equal(TestUnit, fatigue.Unit);
    }

    [Fact]
    public void ChangeAlignment()
    {
      var actions =
          ActionsBuilder.New().ChangeAlignment(TestUnit, Alignment.LawfulEvil).Build();

      Assert.Single(actions.Actions);
      var changeAlignment = (ChangeAlignment)actions.Actions[0];
      ElementAsserts.IsValid(changeAlignment);

      Assert.Equal(TestUnit, changeAlignment.Unit);
      Assert.Equal(Alignment.LawfulEvil, changeAlignment.Alignment);
    }

    [Fact]
    public void ChangePlayerAlignment()
    {
      var actions = ActionsBuilder.New().ChangePlayerAlignment(Alignment.ChaoticGood).Build();

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
          ActionsBuilder.New()
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
      var actions = ActionsBuilder.New().DamageParty(TestDamage).Build();

      Assert.Single(actions.Actions);
      var dmg = (DamageParty)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(TestDamage, dmg.Damage);
      Assert.True(dmg.NoSource);
      Assert.False(dmg.DamageSource);
    }

    [Fact]
    public void DamageParty_WithOptionalValues()
    {
      var actions =
          ActionsBuilder.New()
              .DamageParty(TestDamage, source: TestUnit, enableBattleLog: false)
              .Build();

      Assert.Single(actions.Actions);
      var dmg = (DamageParty)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(TestDamage, dmg.Damage);
      Assert.False(dmg.NoSource);
      Assert.True(dmg.DamageSource);
      Assert.Equal(TestUnit, dmg.DamageSource);
    }

    [Fact]
    public void DealDamage()
    {
      var actions = ActionsBuilder.New().DealDamage(TestUnit, TestDamage).Build();

      Assert.Single(actions.Actions);
      var dmg = (DealDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(TestDamage, dmg.Damage);
      Assert.Equal(TestUnit, dmg.Target);
      Assert.True(dmg.NoSource);

      Assert.False(dmg.DisableBattleLog);
      Assert.False(dmg.DisableFxAndSound);
    }

    [Fact]
    public void DealDamage_WithOptionalValues()
    {
      var actions =
          ActionsBuilder.New()
              .DealDamage(
                  TestUnit,
                  TestDamage,
                  source: TestUnit,
                  enableBattleLog: false,
                  enableFxAndSound: false)
              .Build();

      Assert.Single(actions.Actions);
      var dmg = (DealDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(TestDamage, dmg.Damage);
      Assert.Equal(TestUnit, dmg.Target);
      Assert.False(dmg.NoSource);
      Assert.Equal(TestUnit, dmg.Source);

      Assert.True(dmg.DisableBattleLog);
      Assert.True(dmg.DisableFxAndSound);
    }

    [Fact]
    public void DealStatDamage()
    {
      var actions =
          ActionsBuilder.New()
              .DealStatDamage(TestUnit, StatType.Strength, new DiceFormula(1, DiceType.D4))
              .Build();

      Assert.Single(actions.Actions);
      var dmg = (DealStatDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(TestUnit, dmg.Target);
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
            ActionsBuilder.New()
                .DealStatDamage(TestUnit, StatType.AC, new DiceFormula(1, DiceType.D4))
                .Build());
    }

    [Fact]
    public void DealStatDamage_WithOptionalValues()
    {
      var actions =
          ActionsBuilder.New()
              .DealStatDamage(
                  TestUnit,
                  StatType.Wisdom,
                  new DiceFormula(2, DiceType.D6),
                  damageBonus: 2,
                  source: TestUnit,
                  drain: true,
                  enableBattleLog: false)
              .Build();

      Assert.Single(actions.Actions);
      var dmg = (DealStatDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(TestUnit, dmg.Target);
      Assert.Equal(StatType.Wisdom, dmg.Stat);
      Assert.Equal(2, dmg.DamageDice.Rolls);
      Assert.Equal(DiceType.D6, dmg.DamageDice.Dice);
      Assert.Equal(2, dmg.DamageBonus);

      Assert.True(dmg.IsDrain);
      Assert.True(dmg.DisableBattleLog);
      Assert.False(dmg.NoSource);
      Assert.Equal(TestUnit, dmg.Source);
    }

    [Fact]
    public void AddItems()
    {
      var items = new List<LootEntry>();
      var toCollection = ElementTool.Create<UnitInventory>();

      var actions = ActionsBuilder.New().AddItems(items, toCollection).Build();

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
          ActionsBuilder.New()
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
          ActionsBuilder.New().AddItemsFromBlueprint(LootGuid, toCollection).Build();

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
          ActionsBuilder.New()
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
      var actions = ActionsBuilder.New().GiveItemToPlayer(ItemGuid).Build();

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
            ActionsBuilder.New().GiveItemToPlayer(ArmorGuid).Build());
    }

    [Fact]
    public void GiveItemToPlayer_WithHandSlotItem()
    {
      Assert.Throws<InvalidOperationException>(
          () =>
            ActionsBuilder.New().GiveItemToPlayer(SimpleHandItemGuid).Build());
    }

    [Fact]
    public void GiveItemToPlayer_WithOptionalValues()
    {
      var actions =
          ActionsBuilder.New()
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
          ActionsBuilder.New().GiveEquipmentToPlayer(ArmorGuid).Build();

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
            ActionsBuilder.New().GiveEquipmentToPlayer(SimpleHandItemGuid, TestUnit).Build());
    }

    [Fact]
    public void GiveEquipmentToPlayer_WithOptionalValues()
    {
      var actions =
          ActionsBuilder.New()
              .GiveEquipmentToPlayer(
                  ArmorGuid,
                  equip: true,
                  equipOn: TestUnit,
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
      Assert.Equal(TestUnit, addItem.EquipOn);
      Assert.False(addItem.ErrorIfDidNotEquip);
      Assert.Equal(0, addItem.PreferredWeaponSet);
      Assert.Equal(2, addItem.Quantity);
      Assert.True(addItem.Silent);
      Assert.True(addItem.Identify);
    }

    [Fact]
    public void GiveHandSlotItemToPlayer()
    {
      var actions = ActionsBuilder.New().GiveHandSlotItemToPlayer(SimpleHandItemGuid).Build();

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
          ActionsBuilder.New()
              .GiveHandSlotItemToPlayer(
                  SimpleHandItemGuid,
                  equip: true,
                  equipOn: TestUnit,
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
      Assert.Equal(TestUnit, addItem.EquipOn);
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

      var actions = ActionsBuilder.New().AdvanceLevel(TestUnit, targetLevel).Build();

      Assert.Single(actions.Actions);
      var advanceLevel = (AdvanceUnitLevel)actions.Actions[0];
      ElementAsserts.IsValid(advanceLevel);

      Assert.Equal(TestUnit, advanceLevel.Unit);
      Assert.Equal(targetLevel, advanceLevel.Level);
    }

    [Fact]
    public void DestroyUnit()
    {
      var actions = ActionsBuilder.New().DestroyUnit(TestUnit).Build();

      Assert.Single(actions.Actions);
      var destroy = (DestroyUnit)actions.Actions[0];
      ElementAsserts.IsValid(destroy);

      Assert.Equal(TestUnit, destroy.Target);
      Assert.False(destroy.FadeOut);
    }

    [Fact]
    public void DestroyUnit_WithFadeOut()
    {
      var actions = ActionsBuilder.New().DestroyUnit(TestUnit, fadeOut: true).Build();

      Assert.Single(actions.Actions);
      var destroy = (DestroyUnit)actions.Actions[0];
      ElementAsserts.IsValid(destroy);

      Assert.Equal(TestUnit, destroy.Target);
      Assert.True(destroy.FadeOut);
    }

    [Fact]
    public void AddUnitToGroup()
    {
      var group = ElementTool.Create<PlayerCharacter>();

      var actions = ActionsBuilder.New().AddUnitToGroup(TestUnit, group).Build();

      Assert.Single(actions.Actions);
      var addToGroup = (CombineToGroup)actions.Actions[0];
      ElementAsserts.IsValid(addToGroup);

      Assert.Equal(TestUnit, addToGroup.TargetUnit);
      Assert.Equal(group, addToGroup.GroupHolder);
    }

    [Fact]
    public void ClearUnitReturnPosition()
    {
      var actions = ActionsBuilder.New().ClearUnitReturnPosition(TestUnit).Build();

      Assert.Single(actions.Actions);
      var clearReturnPosition = (ClearUnitReturnPosition)actions.Actions[0];
      ElementAsserts.IsValid(clearReturnPosition);

      Assert.Equal(TestUnit, clearReturnPosition.Unit);
    }

    [Fact]
    public void ClearAllUnitReturnPosition()
    {
      var actions = ActionsBuilder.New().ClearAllUnitReturnPosition().Build();

      Assert.Single(actions.Actions);
      var clearReturnPosition = (ClearUnitReturnPosition)actions.Actions[0];
      ElementAsserts.IsValid(clearReturnPosition);

      Assert.Null(clearReturnPosition.Unit);
    }

    [Fact]
    public void AddUnitToSummonPool()
    {
      var actions =
          ActionsBuilder.New().AddUnitToSummonPool(TestUnit, SummonPoolGuid).Build();

      Assert.Single(actions.Actions);
      var addSummon = (AddUnitToSummonPool)actions.Actions[0];
      ElementAsserts.IsValid(addSummon);

      Assert.Equal(TestUnit, addSummon.Unit);
      Assert.Equal(SummonPool.ToReference<BlueprintSummonPoolReference>(), addSummon.m_SummonPool);
    }

    [Fact]
    public void RemoveUnitFromSummonPool()
    {
      var actions =
          ActionsBuilder.New().RemoveUnitFromSummonPool(TestUnit, SummonPoolGuid).Build();

      Assert.Single(actions.Actions);
      var addSummon = (DeleteUnitFromSummonPool)actions.Actions[0];
      ElementAsserts.IsValid(addSummon);

      Assert.Equal(TestUnit, addSummon.Unit);
      Assert.Equal(SummonPool.ToReference<BlueprintSummonPoolReference>(), addSummon.m_SummonPool);
    }
  }
}
