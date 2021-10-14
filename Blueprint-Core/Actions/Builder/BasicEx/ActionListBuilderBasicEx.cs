using System;
using System.Collections.Generic;
using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Buffs.Blueprints;


namespace BlueprintCore.Actions.Builder.BasicEx
{
  //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

  /**
   * Extension to ActionListBuilder which supports most game mechanics related actions that are not
   * ContextAction types.
   */
  public static class ActionListBuilderBasicEx
  {
    /**
     * AttachBuff
     *
     * @param buff BlueprintBuff
     */
    public static ActionListBuilder AttachBuff(
        this ActionListBuilder builder, string buff, UnitEvaluator target, IntEvaluator duration)
    {
      builder.Validate(target);
      builder.Validate(duration);

      var attachBuff = ElementTool.Create<AttachBuff>();
      attachBuff.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      attachBuff.Target = target;
      attachBuff.Duration = duration;
      return builder.Add(attachBuff);
    }

    /** CreaturesAround */
    public static ActionListBuilder OnCreaturesAround(
        this ActionListBuilder builder,
        ActionListBuilder actions,
        FloatEvaluator radius,
        PositionEvaluator center,
        bool checkLos = false,
        bool targetDead = false)
    {
      builder.Validate(radius);
      builder.Validate(center);

      var onCreatures = ElementTool.Create<CreaturesAround>();
      onCreatures.Actions = actions.Build();
      onCreatures.Radius = radius;
      onCreatures.Center = center;
      onCreatures.CheckLos = checkLos;
      onCreatures.IncludeDead = targetDead;
      return builder.Add(onCreatures);
    }

    /**
     * AddFact
     *
     * @param fact BlueprintUnitFact
     */
    public static ActionListBuilder AddFact(
        this ActionListBuilder builder, string fact, UnitEvaluator target)
    {
      builder.Validate(target);

      var addFact = ElementTool.Create<AddFact>();
      addFact.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(fact);
      addFact.Unit = target;
      return builder.Add(addFact);
    }

    /** AddFatigueHours */
    public static ActionListBuilder AddFatigue(
        this ActionListBuilder builder, IntEvaluator hours, UnitEvaluator target)
    {
      builder.Validate(hours);
      builder.Validate(target);

      var fatigue = ElementTool.Create<AddFatigueHours>();
      fatigue.Hours = hours;
      fatigue.Unit = target;
      return builder.Add(fatigue);
    }

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

    /** DamageParty */
    public static ActionListBuilder DamageParty(
        this ActionListBuilder builder,
        DamageDescription damage,
        UnitEvaluator source = null,
        bool enableBattleLog = true)
    {
      var dmg = ElementTool.Create<DamageParty>();
      dmg.Damage = damage;
      dmg.DisableBattleLog = !enableBattleLog;

      if (source == null)
      {
        dmg.NoSource = true;
      }
      else
      {
        builder.Validate(source);
        dmg.DamageSource = source;
      }
      return builder.Add(dmg);
    }

    /** DealDamage */
    public static ActionListBuilder DealDamage(
        this ActionListBuilder builder,
        UnitEvaluator target,
        DamageDescription damage,
        UnitEvaluator source = null,
        bool enableBattleLog = true,
        bool enableFxAndSound = true)
    {
      builder.Validate(target);

      var dmg = ElementTool.Create<DealDamage>();
      dmg.Target = target;
      dmg.Damage = damage;
      dmg.DisableBattleLog = !enableBattleLog;
      dmg.DisableFxAndSound = !enableFxAndSound;

      if (source == null)
      {
        dmg.NoSource = true;
      }
      else
      {
        builder.Validate(source);
        dmg.Source = source;
      }
      return builder.Add(dmg);
    }

    /** DealStatDamage */
    public static ActionListBuilder DealStatDamage(
        this ActionListBuilder builder,
        UnitEvaluator target,
        StatType type,
        DiceFormula damageDice,
        int damageBonus = 0,
        UnitEvaluator source = null,
        bool drain = false,
        bool enableBattleLog = true)
    {
      // if (!Constants.CoreStats.Contains(type))
      // {
      //   throw new InvalidOperationException($"Only str/dex/con/int/wis/cha can be damaged: {type}");
      // }
      builder.Validate(target);

      var dmg = ElementTool.Create<DealStatDamage>();
      dmg.Target = target;
      dmg.Stat = type;
      dmg.DamageDice = damageDice;
      dmg.DamageBonus = damageBonus;
      dmg.IsDrain = drain;
      dmg.DisableBattleLog = !enableBattleLog;

      if (source == null)
      {
        dmg.NoSource = true;
      }
      else
      {
        builder.Validate(source);
        dmg.Source = source;
      }
      return builder.Add(dmg);
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
      addItems.m_BlueprintLoot = BlueprintTool.GetRef<BlueprintUnitLootReference>(loot);
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
      addSummon.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(pool);
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
      addSummon.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(pool);
      addSummon.Unit = unit;
      return builder.Add(addSummon);
    }
  }
}