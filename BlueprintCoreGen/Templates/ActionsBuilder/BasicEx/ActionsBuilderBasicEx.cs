using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using System;
using System.Collections.Generic;

namespace BlueprintCoreGen.Actions.Builder.BasicEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for most game mechanics related actions not included in
  /// <see cref="ContextEx.ActionsBuilderContextEx">ContextEx</see>.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderBasicEx
  {
    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.AttachBuff">AttachBuff</see>
    /// </summary>
    /// 
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/>BlueprintBuff</param>
    [Implements(typeof(AttachBuff))]
    public static ActionsBuilder AttachBuff(
        this ActionsBuilder builder, string buff, UnitEvaluator target, IntEvaluator duration)
    {
      builder.Validate(target);
      builder.Validate(duration);

      var attachBuff = ElementTool.Create<AttachBuff>();
      attachBuff.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      attachBuff.Target = target;
      attachBuff.Duration = duration;
      return builder.Add(attachBuff);
    }

    /// <summary>
    /// Adds <see cref="CreaturesAround"/>
    /// </summary>
    [Implements(typeof(CreaturesAround))]
    public static ActionsBuilder OnCreaturesAround(
        this ActionsBuilder builder,
        ActionsBuilder actions,
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

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.AddFact">AddFact</see>
    /// </summary>
    ///
    /// <param name="fact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/>BlueprintUnitFact</param>
    [Implements(typeof(AddFact))]
    public static ActionsBuilder AddFact(this ActionsBuilder builder, string fact, UnitEvaluator target)
    {
      builder.Validate(target);

      var addFact = ElementTool.Create<AddFact>();
      addFact.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(fact);
      addFact.Unit = target;
      return builder.Add(addFact);
    }

    /// <summary>
    /// Adds <see cref="AddFatigueHours"/>
    /// </summary>
    [Implements(typeof(AddFatigueHours))]
    public static ActionsBuilder AddFatigue(this ActionsBuilder builder, IntEvaluator hours, UnitEvaluator target)
    {
      builder.Validate(hours);
      builder.Validate(target);

      var fatigue = ElementTool.Create<AddFatigueHours>();
      fatigue.Hours = hours;
      fatigue.Unit = target;
      return builder.Add(fatigue);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.ChangeAlignment">ChangeAlignment</see>
    /// </summary>
    [Implements(typeof(ChangeAlignment))]
    public static ActionsBuilder ChangeAlignment(
        this ActionsBuilder builder, UnitEvaluator target, Alignment alignment)
    {
      builder.Validate(target);

      var changeAlignment = ElementTool.Create<ChangeAlignment>();
      changeAlignment.Unit = target;
      changeAlignment.Alignment = alignment;
      return builder.Add(changeAlignment);
    }

    /// <summary>
    /// Adds
    /// <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.ChangePlayerAlignment">ChangePlayerAlignment</see>
    /// </summary>
    [Implements(typeof(ChangePlayerAlignment))]
    public static ActionsBuilder ChangePlayerAlignment(
        this ActionsBuilder builder, Alignment alignment, bool unlockAlignment = false)
    {
      var changeAlignment = ElementTool.Create<ChangePlayerAlignment>();
      changeAlignment.TargetAlignment = alignment;
      changeAlignment.CanUnlockAlignment = unlockAlignment;
      return builder.Add(changeAlignment);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.DamageParty">DamageParty</see>
    /// </summary>
    [Implements(typeof(DamageParty))]
    public static ActionsBuilder DamageParty(
        this ActionsBuilder builder,
        DamageDescription damage,
        UnitEvaluator source = null,
        bool enableBattleLog = true)
    {
      var dmg = ElementTool.Create<DamageParty>();
      dmg.Damage = damage;
      dmg.DisableBattleLog = !enableBattleLog;

      if (source == null) { dmg.NoSource = true; }
      else
      {
        builder.Validate(source);
        dmg.DamageSource = source;
      }
      return builder.Add(dmg);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.DealDamage">DealDamage</see>
    /// </summary>
    [Implements(typeof(DealDamage))]
    public static ActionsBuilder DealDamage(
        this ActionsBuilder builder,
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

      if (source == null) { dmg.NoSource = true; }
      else
      {
        builder.Validate(source);
        dmg.Source = source;
      }
      return builder.Add(dmg);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.DealStatDamage">DealStatDamage</see>
    /// </summary>
    [Implements(typeof(DealStatDamage))]
    public static ActionsBuilder DealStatDamage(
        this ActionsBuilder builder,
        UnitEvaluator target,
        StatType type,
        DiceFormula damageDice,
        int damageBonus = 0,
        UnitEvaluator source = null,
        bool drain = false,
        bool enableBattleLog = true)
    {
      builder.Validate(target);

      var dmg = ElementTool.Create<DealStatDamage>();
      dmg.Target = target;
      dmg.Stat = type;
      dmg.DamageDice = damageDice;
      dmg.DamageBonus = damageBonus;
      dmg.IsDrain = drain;
      dmg.DisableBattleLog = !enableBattleLog;

      if (source == null) { dmg.NoSource = true; }
      else
      {
        builder.Validate(source);
        dmg.Source = source;
      }
      return builder.Add(dmg);
    }

    /// <summary>
    /// Adds <see cref="AddItemsToCollection"/>
    /// </summary>
    [Implements(typeof(AddItemsToCollection))]
    public static ActionsBuilder AddItems(
        this ActionsBuilder builder,
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

    /// <summary>
    /// Adds <see cref="AddItemsToCollection"/>
    /// </summary>
    /// 
    /// <param name="loot"><see cref="BlueprintUnitLoot">BlueprintUnitLoot</see></param>
    [Implements(typeof(AddItemsToCollection))]
    public static ActionsBuilder AddItemsFromBlueprint(
        this ActionsBuilder builder,
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

    /// <summary>
    /// Adds <see cref="AddItemToPlayer"/>
    /// </summary>
    /// 
    /// <remarks>
    /// <list type="bullet">
    /// <item>
    ///   <description>
    ///     If the item is a <see cref="BlueprintItemEquipmentHand"/> use <see cref="GiveHandSlotItemToPlayer"/>
    ///   </description>
    /// </item>
    /// <item>
    ///   <description>
    ///     If the item is a <see cref="BlueprintItemEquipment"/> use <see cref="GiveEquipmentToPlayer"/>
    ///   </description>
    /// </item>
    /// <item>
    ///   <description>
    ///     For any other items use <see cref="GiveItemToPlayer"/>.
    ///   </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// 
    /// <param name="item"><see cref="BlueprintItem"/></param>
    [Implements(typeof(AddItemToPlayer))]
    public static ActionsBuilder GiveItemToPlayer(
        this ActionsBuilder builder,
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

    /// <inheritdoc cref="GiveItemToPlayer"/>
    /// <param name="equipment"><see cref="BlueprintItemEquipment"/></param>
    [Implements(typeof(AddItemToPlayer))]
    public static ActionsBuilder GiveEquipmentToPlayer(
        this ActionsBuilder builder,
        string equipment,
        bool equip = false,
        UnitEvaluator equipOn = null,
        bool errorIfDidNotEquip = true,
        int count = 1,
        bool silent = false,
        bool identify = false)
    {
      var item = BlueprintTool.Get<BlueprintItemEquipment>(equipment);
      if (item is BlueprintItemEquipmentHand)
      {
        throw new InvalidOperationException(
            "Item fits in hand slot. Use GiveHandSlotItemToPlayer()");
      }

      return GiveItemToPlayer(
          builder,
          item,
          count,
          silent,
          identify,
          equip: equip,
          equipOn: equipOn,
          errorIfDidNotEquip: errorIfDidNotEquip);
    }

    /// <inheritdoc cref="GiveItemToPlayer"/>
    /// <param name="handItem"><see cref="BlueprintItemEquipmentHand"/></param>
    [Implements(typeof(AddItemToPlayer))]
    public static ActionsBuilder GiveHandSlotItemToPlayer(
        this ActionsBuilder builder,
        string handItem,
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
          BlueprintTool.Get<BlueprintItemEquipmentHand>(handItem),
          count,
          silent,
          identify,
          equip: equip,
          equipOn: equipOn,
          errorIfDidNotEquip: errorIfDidNotEquip,
          preferredHandSlot: preferredHandSlot);
    }

    private static ActionsBuilder GiveItemToPlayer(
        ActionsBuilder builder,
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

    /// <summary>
    /// Adds <see cref="AdvanceUnitLevel"/>
    /// </summary>
    [Implements(typeof(AdvanceUnitLevel))]
    public static ActionsBuilder AdvanceLevel(
        this ActionsBuilder builder, UnitEvaluator unit, IntEvaluator targetLevel)
    {
      builder.Validate(unit);
      builder.Validate(targetLevel);

      var advanceLevel = ElementTool.Create<AdvanceUnitLevel>();
      advanceLevel.Unit = unit;
      advanceLevel.Level = targetLevel;
      return builder.Add(advanceLevel);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.DestroyUnit">DestroyUnit</see>
    /// </summary>
    [Implements(typeof(DestroyUnit))]
    public static ActionsBuilder DestroyUnit(
        this ActionsBuilder builder, UnitEvaluator unit, bool fadeOut = false)
    {
      builder.Validate(unit);

      var destroy = ElementTool.Create<DestroyUnit>();
      destroy.Target = unit;
      destroy.FadeOut = fadeOut;
      return builder.Add(destroy);
    }

    /// <summary>
    /// Adds <see cref="CombineToGroup"/>
    /// </summary>
    [Implements(typeof(CombineToGroup))]
    public static ActionsBuilder AddUnitToGroup(
        this ActionsBuilder builder, UnitEvaluator unit, UnitEvaluator group)
    {
      builder.Validate(unit);
      builder.Validate(group);

      var addToGroup = ElementTool.Create<CombineToGroup>();
      addToGroup.TargetUnit = unit;
      addToGroup.GroupHolder = group;
      return builder.Add(addToGroup);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.ClearUnitReturnPosition">ClearUnitReturnPosition</see>
    /// </summary>
    [Implements(typeof(ClearUnitReturnPosition))]
    public static ActionsBuilder ClearUnitReturnPosition(
        this ActionsBuilder builder, UnitEvaluator unit)
    {
      builder.Validate(unit);

      var clearReturnPosition = ElementTool.Create<ClearUnitReturnPosition>();
      clearReturnPosition.Unit = unit;
      return builder.Add(clearReturnPosition);
    }

    /// <inheritdoc cref="ClearUnitReturnPosition"/>
    [Implements(typeof(ClearUnitReturnPosition))]
    public static ActionsBuilder ClearAllUnitReturnPosition(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ClearUnitReturnPosition>());
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.AddUnitToSummonPool">AddUnitToSummonPool</see>
    /// </summary>
    /// 
    /// <param name="pool"><see cref="BlueprintSummonPool"/></param>
    [Implements(typeof(AddUnitToSummonPool))]
    public static ActionsBuilder AddUnitToSummonPool(
        this ActionsBuilder builder, UnitEvaluator unit, string pool)
    {
      builder.Validate(unit);

      var addSummon = ElementTool.Create<AddUnitToSummonPool>();
      addSummon.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(pool);
      addSummon.Unit = unit;
      return builder.Add(addSummon);
    }

    /// <summary>
    /// Adds <see cref="DeleteUnitFromSummonPool"/>
    /// </summary>
    /// 
    /// <param name="pool"><see cref="BlueprintSummonPool"/></param>
    [Implements(typeof(DeleteUnitFromSummonPool))]
    public static ActionsBuilder RemoveUnitFromSummonPool(
        this ActionsBuilder builder, UnitEvaluator unit, string pool)
    {
      builder.Validate(unit);

      var addSummon = ElementTool.Create<DeleteUnitFromSummonPool>();
      addSummon.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(pool);
      addSummon.Unit = unit;
      return builder.Add(addSummon);
    }

    //----- Auto Generated -----//

    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.DetachBuff)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.DisableExperienceFromUnit)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.DrainEnergy)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.GainExp)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.GainMythicLevel)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.HealParty)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.HealUnit)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.ItemSetCharges)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.Kill)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.LevelUpUnit)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.MeleeAttack)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.RaiseDead)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.RemoveDeathDoor)]

  }
}