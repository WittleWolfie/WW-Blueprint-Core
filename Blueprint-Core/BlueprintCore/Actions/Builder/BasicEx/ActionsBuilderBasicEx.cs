using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Experience;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;

namespace BlueprintCore.Actions.Builder.BasicEx
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



    /// <summary>
    /// Adds <see cref="DetachBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(DetachBuff))]
    public static ActionsBuilder AddDetachBuff(
        this ActionsBuilder builder,
        string m_Buff,
        UnitEvaluator Target)
    {
      builder.Validate(Target);
      
      var element = ElementTool.Create<DetachBuff>();
      element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      element.Target = Target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DisableExperienceFromUnit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableExperienceFromUnit))]
    public static ActionsBuilder AddDisableExperienceFromUnit(
        this ActionsBuilder builder,
        UnitEvaluator Unit)
    {
      builder.Validate(Unit);
      
      var element = ElementTool.Create<DisableExperienceFromUnit>();
      element.Unit = Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DrainEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DrainEnergy))]
    public static ActionsBuilder AddDrainEnergy(
        this ActionsBuilder builder,
        Boolean NoSource,
        UnitEvaluator Source,
        UnitEvaluator Target,
        EnergyDrainType Type,
        Rounds Duration,
        DiceFormula DamageDice,
        Int32 DamageBonus,
        Boolean DisableBattleLog)
    {
      builder.Validate(NoSource);
      builder.Validate(Source);
      builder.Validate(Target);
      builder.Validate(Type);
      builder.Validate(Duration);
      builder.Validate(DamageDice);
      builder.Validate(DamageBonus);
      builder.Validate(DisableBattleLog);
      
      var element = ElementTool.Create<DrainEnergy>();
      element.NoSource = NoSource;
      element.Source = Source;
      element.Target = Target;
      element.Type = Type;
      element.Duration = Duration;
      element.DamageDice = DamageDice;
      element.DamageBonus = DamageBonus;
      element.DisableBattleLog = DisableBattleLog;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GainExp"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GainExp))]
    public static ActionsBuilder AddGainExp(
        this ActionsBuilder builder,
        EncounterType Encounter,
        Int32 CR,
        Single Modifier,
        IntEvaluator Count,
        Boolean Dummy)
    {
      builder.Validate(Encounter);
      builder.Validate(CR);
      builder.Validate(Modifier);
      builder.Validate(Count);
      builder.Validate(Dummy);
      
      var element = ElementTool.Create<GainExp>();
      element.Encounter = Encounter;
      element.CR = CR;
      element.Modifier = Modifier;
      element.Count = Count;
      element.Dummy = Dummy;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GainMythicLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GainMythicLevel))]
    public static ActionsBuilder AddGainMythicLevel(
        this ActionsBuilder builder,
        Int32 Levels)
    {
      builder.Validate(Levels);
      
      var element = ElementTool.Create<GainMythicLevel>();
      element.Levels = Levels;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HealParty"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HealParty))]
    public static ActionsBuilder AddHealParty(
        this ActionsBuilder builder,
        UnitEvaluator HealSource)
    {
      builder.Validate(HealSource);
      
      var element = ElementTool.Create<HealParty>();
      element.HealSource = HealSource;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HealUnit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HealUnit))]
    public static ActionsBuilder AddHealUnit(
        this ActionsBuilder builder,
        UnitEvaluator Source,
        UnitEvaluator Target,
        Boolean ToFullHP,
        IntEvaluator HealAmount)
    {
      builder.Validate(Source);
      builder.Validate(Target);
      builder.Validate(ToFullHP);
      builder.Validate(HealAmount);
      
      var element = ElementTool.Create<HealUnit>();
      element.Source = Source;
      element.Target = Target;
      element.ToFullHP = ToFullHP;
      element.HealAmount = HealAmount;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ItemSetCharges"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Item"><see cref="BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(ItemSetCharges))]
    public static ActionsBuilder AddItemSetCharges(
        this ActionsBuilder builder,
        string m_Item,
        IntEvaluator Charges,
        ItemsCollectionEvaluator Collection)
    {
      builder.Validate(Charges);
      builder.Validate(Collection);
      
      var element = ElementTool.Create<ItemSetCharges>();
      element.m_Item = BlueprintTool.GetRef<BlueprintItemReference>(m_Item);
      element.Charges = Charges;
      element.Collection = Collection;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Kill"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Kill))]
    public static ActionsBuilder AddKill(
        this ActionsBuilder builder,
        UnitEvaluator Target,
        UnitEvaluator Killer,
        Boolean Critical,
        Boolean DisableBattleLog,
        Boolean RemoveExp)
    {
      builder.Validate(Target);
      builder.Validate(Killer);
      builder.Validate(Critical);
      builder.Validate(DisableBattleLog);
      builder.Validate(RemoveExp);
      
      var element = ElementTool.Create<Kill>();
      element.Target = Target;
      element.Killer = Killer;
      element.Critical = Critical;
      element.DisableBattleLog = DisableBattleLog;
      element.RemoveExp = RemoveExp;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="LevelUpUnit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LevelUpUnit))]
    public static ActionsBuilder AddLevelUpUnit(
        this ActionsBuilder builder,
        UnitEvaluator Unit,
        IntEvaluator TargetLevel)
    {
      builder.Validate(Unit);
      builder.Validate(TargetLevel);
      
      var element = ElementTool.Create<LevelUpUnit>();
      element.Unit = Unit;
      element.TargetLevel = TargetLevel;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MeleeAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MeleeAttack))]
    public static ActionsBuilder AddMeleeAttack(
        this ActionsBuilder builder,
        UnitEvaluator Caster,
        UnitEvaluator Target,
        Boolean AutoHit,
        Boolean IgnoreStatBonus)
    {
      builder.Validate(Caster);
      builder.Validate(Target);
      builder.Validate(AutoHit);
      builder.Validate(IgnoreStatBonus);

      var element = ElementTool.Create<MeleeAttack>();
      element.Caster = Caster;
      element.Target = Target;
      element.AutoHit = AutoHit;
      element.IgnoreStatBonus = IgnoreStatBonus;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RaiseDead"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_companion"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(RaiseDead))]
    public static ActionsBuilder AddRaiseDead(
        this ActionsBuilder builder,
        string m_companion,
        Boolean riseAllCompanions)
    {
      builder.Validate(riseAllCompanions);

      var element = ElementTool.Create<RaiseDead>();
      element.m_companion = BlueprintTool.GetRef<BlueprintUnitReference>(m_companion);
      element.riseAllCompanions = riseAllCompanions;
      return builder.Add(element);
    }
  }
}
