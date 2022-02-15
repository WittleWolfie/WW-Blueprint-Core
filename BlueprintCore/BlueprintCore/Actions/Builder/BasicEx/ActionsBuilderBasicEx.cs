using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Experience;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Designers;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.NamedParameters;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using System.Collections.Generic;
using UnityEngine;
//***** AUTO-GENERATED - DO NOT EDIT *****//
namespace BlueprintCore.Actions.Builder.BasicEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for most game mechanics related actions not included in <see cref="ContextEx.ActionsBuilderContextEx">ContextEx</see>.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderBasicEx
{

    /// <summary>
    /// Adds <see cref="AttachBuff"/>
    /// </summary>
    ///
    /// <param name="buff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AttachBuff(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? buff = null,
        IntEvaluator? duration = null,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<AttachBuff>();
      if (buff is not null)
      {
        element.m_Buff = buff.Reference;
      }
      if (element.m_Buff is null)
      {
        element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      if (duration is not null)
      {
        builder.Validate(duration);
        element.Duration = duration;
      }
      if (target is not null)
      {
        builder.Validate(target);
        element.Target = target;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CreaturesAround"/>
    /// </summary>
    public static ActionsBuilder CreaturesAround(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null,
        PositionEvaluator? center = null,
        bool? checkLos = null,
        bool? includeDead = null,
        FloatEvaluator? radius = null)
    {
      var element = ElementTool.Create<CreaturesAround>();
      if (actions is not null)
      {
        element.Actions = actions.Build();
      }
      if (element.Actions is null)
      {
        element.Actions = Constants.Empty.Actions;
      }
      if (center is not null)
      {
        builder.Validate(center);
        element.Center = center;
      }
      if (checkLos is not null)
      {
        element.CheckLos = checkLos;
      }
      if (includeDead is not null)
      {
        element.IncludeDead = includeDead;
      }
      if (radius is not null)
      {
        builder.Validate(radius);
        element.Radius = radius;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddFact"/>
    /// </summary>
    ///
    /// <param name="fact">
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AddFact(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? fact = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<AddFact>();
      if (fact is not null)
      {
        element.m_Fact = fact.Reference;
      }
      if (element.m_Fact is null)
      {
        element.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      if (unit is not null)
      {
        builder.Validate(unit);
        element.Unit = unit;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddFatigueHours"/>
    /// </summary>
    public static ActionsBuilder AddFatigueHours(
        this ActionsBuilder builder,
        IntEvaluator? hours = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<AddFatigueHours>();
      if (hours is not null)
      {
        builder.Validate(hours);
        element.Hours = hours;
      }
      if (unit is not null)
      {
        builder.Validate(unit);
        element.Unit = unit;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangeAlignment"/>
    /// </summary>
    public static ActionsBuilder ChangeAlignment(
        this ActionsBuilder builder,
        Alignment? alignment = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<ChangeAlignment>();
      if (alignment is not null)
      {
        element.Alignment = alignment;
      }
      if (unit is not null)
      {
        builder.Validate(unit);
        element.Unit = unit;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangePlayerAlignment"/>
    /// </summary>
    public static ActionsBuilder ChangePlayerAlignment(
        this ActionsBuilder builder,
        bool? canUnlockAlignment = null,
        Alignment? targetAlignment = null)
    {
      var element = ElementTool.Create<ChangePlayerAlignment>();
      if (canUnlockAlignment is not null)
      {
        element.CanUnlockAlignment = canUnlockAlignment;
      }
      if (targetAlignment is not null)
      {
        element.TargetAlignment = targetAlignment;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DamageParty"/>
    /// </summary>
    public static ActionsBuilder DamageParty(
        this ActionsBuilder builder,
        DamageDescription? damage = null,
        UnitEvaluator? damageSource = null,
        bool? disableBattleLog = null,
        bool? noSource = null)
    {
      var element = ElementTool.Create<DamageParty>();
      if (damage is not null)
      {
        builder.Validate(damage);
        element.Damage = damage;
      }
      if (damageSource is not null)
      {
        builder.Validate(damageSource);
        element.DamageSource = damageSource;
      }
      if (disableBattleLog is not null)
      {
        element.DisableBattleLog = disableBattleLog;
      }
      if (noSource is not null)
      {
        element.NoSource = noSource;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DealDamage"/>
    /// </summary>
    public static ActionsBuilder DealDamage(
        this ActionsBuilder builder,
        DamageDescription? damage = null,
        bool? disableBattleLog = null,
        bool? disableFxAndSound = null,
        bool? noSource = null,
        UnitEvaluator? source = null,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<DealDamage>();
      if (damage is not null)
      {
        builder.Validate(damage);
        element.Damage = damage;
      }
      if (disableBattleLog is not null)
      {
        element.DisableBattleLog = disableBattleLog;
      }
      if (disableFxAndSound is not null)
      {
        element.DisableFxAndSound = disableFxAndSound;
      }
      if (noSource is not null)
      {
        element.NoSource = noSource;
      }
      if (source is not null)
      {
        builder.Validate(source);
        element.Source = source;
      }
      if (target is not null)
      {
        builder.Validate(target);
        element.Target = target;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DealStatDamage"/>
    /// </summary>
    public static ActionsBuilder DealStatDamage(
        this ActionsBuilder builder,
        int? damageBonus = null,
        DiceFormula? damageDice = null,
        bool? disableBattleLog = null,
        bool? isDrain = null,
        bool? noSource = null,
        UnitEvaluator? source = null,
        StatType? stat = null,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<DealStatDamage>();
      if (damageBonus is not null)
      {
        element.DamageBonus = damageBonus;
      }
      if (damageDice is not null)
      {
        element.DamageDice = damageDice;
      }
      if (disableBattleLog is not null)
      {
        element.DisableBattleLog = disableBattleLog;
      }
      if (isDrain is not null)
      {
        element.IsDrain = isDrain;
      }
      if (noSource is not null)
      {
        element.NoSource = noSource;
      }
      if (source is not null)
      {
        builder.Validate(source);
        element.Source = source;
      }
      if (stat is not null)
      {
        element.Stat = stat;
      }
      if (target is not null)
      {
        builder.Validate(target);
        element.Target = target;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddItemsToCollection"/>
    /// </summary>
    ///
    /// <param name="blueprintLoot">
    /// Blueprint of type BlueprintUnitLoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AddItemsToCollection(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnitLoot, BlueprintUnitLootReference>? blueprintLoot = null,
        bool? identify = null,
        ItemsCollectionEvaluator? itemsCollection = null,
        List<LootEntry>? loot = null,
        bool? silent = null,
        bool? useBlueprintUnitLoot = null)
    {
      var element = ElementTool.Create<AddItemsToCollection>();
      if (blueprintLoot is not null)
      {
        element.m_BlueprintLoot = blueprintLoot.Reference;
      }
      if (element.m_BlueprintLoot is null)
      {
        element.m_BlueprintLoot = BlueprintTool.GetRef<BlueprintUnitLootReference>(null);
      }
      if (identify is not null)
      {
        element.Identify = identify;
      }
      if (itemsCollection is not null)
      {
        builder.Validate(itemsCollection);
        element.ItemsCollection = itemsCollection;
      }
      if (loot is not null)
      {
        foreach (var item in loot) { builder.Validate(item); }
        element.Loot = loot;
      }
      if (element.Loot is null)
      {
        element.Loot = new();
      }
      if (silent is not null)
      {
        element.Silent = silent;
      }
      if (useBlueprintUnitLoot is not null)
      {
        element.UseBlueprintUnitLoot = useBlueprintUnitLoot;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddItemToPlayer"/>
    /// </summary>
    ///
    /// <param name="itemToGive">
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AddItemToPlayer(
        this ActionsBuilder builder,
        bool? equip = null,
        UnitEvaluator? equipOn = null,
        bool? errorIfDidNotEquip = null,
        bool? identify = null,
        Blueprint<BlueprintItem, BlueprintItemReference>? itemToGive = null,
        int? preferredWeaponSet = null,
        int? quantity = null,
        bool? silent = null)
    {
      var element = ElementTool.Create<AddItemToPlayer>();
      if (equip is not null)
      {
        element.Equip = equip;
      }
      if (equipOn is not null)
      {
        builder.Validate(equipOn);
        element.EquipOn = equipOn;
      }
      if (errorIfDidNotEquip is not null)
      {
        element.ErrorIfDidNotEquip = errorIfDidNotEquip;
      }
      if (identify is not null)
      {
        element.Identify = identify;
      }
      if (itemToGive is not null)
      {
        element.m_ItemToGive = itemToGive.Reference;
      }
      if (element.m_ItemToGive is null)
      {
        element.m_ItemToGive = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      if (preferredWeaponSet is not null)
      {
        element.PreferredWeaponSet = preferredWeaponSet;
      }
      if (quantity is not null)
      {
        element.Quantity = quantity;
      }
      if (silent is not null)
      {
        element.Silent = silent;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AdvanceUnitLevel"/>
    /// </summary>
    public static ActionsBuilder AdvanceUnitLevel(
        this ActionsBuilder builder,
        IntEvaluator? level = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<AdvanceUnitLevel>();
      if (level is not null)
      {
        builder.Validate(level);
        element.Level = level;
      }
      if (unit is not null)
      {
        builder.Validate(unit);
        element.Unit = unit;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DestroyUnit"/>
    /// </summary>
    public static ActionsBuilder DestroyUnit(
        this ActionsBuilder builder,
        bool? fadeOut = null,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<DestroyUnit>();
      if (fadeOut is not null)
      {
        element.FadeOut = fadeOut;
      }
      if (target is not null)
      {
        builder.Validate(target);
        element.Target = target;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CombineToGroup"/>
    /// </summary>
    public static ActionsBuilder CombineToGroup(
        this ActionsBuilder builder,
        UnitEvaluator? groupHolder = null,
        UnitEvaluator? targetUnit = null)
    {
      var element = ElementTool.Create<CombineToGroup>();
      if (groupHolder is not null)
      {
        builder.Validate(groupHolder);
        element.GroupHolder = groupHolder;
      }
      if (targetUnit is not null)
      {
        builder.Validate(targetUnit);
        element.TargetUnit = targetUnit;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ClearUnitReturnPosition"/>
    /// </summary>
    public static ActionsBuilder ClearUnitReturnPosition(
        this ActionsBuilder builder,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<ClearUnitReturnPosition>();
      if (unit is not null)
      {
        builder.Validate(unit);
        element.Unit = unit;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddUnitToSummonPool"/>
    /// </summary>
    ///
    /// <param name="summonPool">
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AddUnitToSummonPool(
        this ActionsBuilder builder,
        Blueprint<BlueprintSummonPool, BlueprintSummonPoolReference>? summonPool = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<AddUnitToSummonPool>();
      if (summonPool is not null)
      {
        element.m_SummonPool = summonPool.Reference;
      }
      if (element.m_SummonPool is null)
      {
        element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      if (unit is not null)
      {
        builder.Validate(unit);
        element.Unit = unit;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DeleteUnitFromSummonPool"/>
    /// </summary>
    ///
    /// <param name="summonPool">
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder DeleteUnitFromSummonPool(
        this ActionsBuilder builder,
        Blueprint<BlueprintSummonPool, BlueprintSummonPoolReference>? summonPool = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<DeleteUnitFromSummonPool>();
      if (summonPool is not null)
      {
        element.m_SummonPool = summonPool.Reference;
      }
      if (element.m_SummonPool is null)
      {
        element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      if (unit is not null)
      {
        builder.Validate(unit);
        element.Unit = unit;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DetachBuff"/>
    /// </summary>
    ///
    /// <param name="buff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder DetachBuff(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? buff = null,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<DetachBuff>();
      if (buff is not null)
      {
        element.m_Buff = buff.Reference;
      }
      if (element.m_Buff is null)
      {
        element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      if (target is not null)
      {
        builder.Validate(target);
        element.Target = target;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DisableExperienceFromUnit"/>
    /// </summary>
    public static ActionsBuilder DisableExperienceFromUnit(
        this ActionsBuilder builder,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<DisableExperienceFromUnit>();
      if (unit is not null)
      {
        builder.Validate(unit);
        element.Unit = unit;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DrainEnergy"/>
    /// </summary>
    public static ActionsBuilder DrainEnergy(
        this ActionsBuilder builder,
        int? damageBonus = null,
        DiceFormula? damageDice = null,
        bool? disableBattleLog = null,
        Rounds? duration = null,
        bool? noSource = null,
        UnitEvaluator? source = null,
        UnitEvaluator? target = null,
        EnergyDrainType? type = null)
    {
      var element = ElementTool.Create<DrainEnergy>();
      if (damageBonus is not null)
      {
        element.DamageBonus = damageBonus;
      }
      if (damageDice is not null)
      {
        element.DamageDice = damageDice;
      }
      if (disableBattleLog is not null)
      {
        element.DisableBattleLog = disableBattleLog;
      }
      if (duration is not null)
      {
        element.Duration = duration;
      }
      if (noSource is not null)
      {
        element.NoSource = noSource;
      }
      if (source is not null)
      {
        builder.Validate(source);
        element.Source = source;
      }
      if (target is not null)
      {
        builder.Validate(target);
        element.Target = target;
      }
      if (type is not null)
      {
        element.Type = type;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="FakePartyRest"/>
    /// </summary>
    public static ActionsBuilder FakePartyRest(
        this ActionsBuilder builder,
        ActionsBuilder? actionsOnRestEnd = null,
        bool? ignoreCorruption = null,
        bool? immediate = null,
        bool? restWithCraft = null)
    {
      var element = ElementTool.Create<FakePartyRest>();
      if (actionsOnRestEnd is not null)
      {
        element.m_ActionsOnRestEnd = actionsOnRestEnd.Build();
      }
      if (element.m_ActionsOnRestEnd is null)
      {
        element.m_ActionsOnRestEnd = Constants.Empty.Actions;
      }
      if (ignoreCorruption is not null)
      {
        element.m_IgnoreCorruption = ignoreCorruption;
      }
      if (immediate is not null)
      {
        element.m_Immediate = immediate;
      }
      if (restWithCraft is not null)
      {
        element.m_RestWithCraft = restWithCraft;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GainExp"/>
    /// </summary>
    public static ActionsBuilder GainExp(
        this ActionsBuilder builder,
        IntEvaluator? count = null,
        int? cR = null,
        bool? dummy = null,
        EncounterType? encounter = null,
        float? modifier = null)
    {
      var element = ElementTool.Create<GainExp>();
      if (count is not null)
      {
        builder.Validate(count);
        element.Count = count;
      }
      if (cR is not null)
      {
        element.CR = cR;
      }
      if (dummy is not null)
      {
        element.Dummy = dummy;
      }
      if (encounter is not null)
      {
        element.Encounter = encounter;
      }
      if (modifier is not null)
      {
        element.Modifier = modifier;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GainMythicLevel"/>
    /// </summary>
    public static ActionsBuilder GainMythicLevel(
        this ActionsBuilder builder,
        int? levels = null)
    {
      var element = ElementTool.Create<GainMythicLevel>();
      if (levels is not null)
      {
        element.Levels = levels;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HealParty"/>
    /// </summary>
    public static ActionsBuilder HealParty(
        this ActionsBuilder builder,
        UnitEvaluator? healSource = null)
    {
      var element = ElementTool.Create<HealParty>();
      if (healSource is not null)
      {
        builder.Validate(healSource);
        element.HealSource = healSource;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HealUnit"/>
    /// </summary>
    public static ActionsBuilder HealUnit(
        this ActionsBuilder builder,
        IntEvaluator? healAmount = null,
        UnitEvaluator? source = null,
        UnitEvaluator? target = null,
        bool? toFullHP = null)
    {
      var element = ElementTool.Create<HealUnit>();
      if (healAmount is not null)
      {
        builder.Validate(healAmount);
        element.HealAmount = healAmount;
      }
      if (source is not null)
      {
        builder.Validate(source);
        element.Source = source;
      }
      if (target is not null)
      {
        builder.Validate(target);
        element.Target = target;
      }
      if (toFullHP is not null)
      {
        element.ToFullHP = toFullHP;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ItemSetCharges"/>
    /// </summary>
    ///
    /// <param name="item">
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ItemSetCharges(
        this ActionsBuilder builder,
        IntEvaluator? charges = null,
        ItemsCollectionEvaluator? collection = null,
        Blueprint<BlueprintItem, BlueprintItemReference>? item = null)
    {
      var element = ElementTool.Create<ItemSetCharges>();
      if (charges is not null)
      {
        builder.Validate(charges);
        element.Charges = charges;
      }
      if (collection is not null)
      {
        builder.Validate(collection);
        element.Collection = collection;
      }
      if (item is not null)
      {
        element.m_Item = item.Reference;
      }
      if (element.m_Item is null)
      {
        element.m_Item = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Kill"/>
    /// </summary>
    public static ActionsBuilder Kill(
        this ActionsBuilder builder,
        bool? critical = null,
        bool? disableBattleLog = null,
        UnitEvaluator? killer = null,
        bool? removeExp = null,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<Kill>();
      if (critical is not null)
      {
        element.Critical = critical;
      }
      if (disableBattleLog is not null)
      {
        element.DisableBattleLog = disableBattleLog;
      }
      if (killer is not null)
      {
        builder.Validate(killer);
        element.Killer = killer;
      }
      if (removeExp is not null)
      {
        element.RemoveExp = removeExp;
      }
      if (target is not null)
      {
        builder.Validate(target);
        element.Target = target;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="LevelUpUnit"/>
    /// </summary>
    public static ActionsBuilder LevelUpUnit(
        this ActionsBuilder builder,
        IntEvaluator? targetLevel = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<LevelUpUnit>();
      if (targetLevel is not null)
      {
        builder.Validate(targetLevel);
        element.TargetLevel = targetLevel;
      }
      if (unit is not null)
      {
        builder.Validate(unit);
        element.Unit = unit;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MeleeAttack"/>
    /// </summary>
    public static ActionsBuilder MeleeAttack(
        this ActionsBuilder builder,
        bool? autoHit = null,
        UnitEvaluator? caster = null,
        bool? ignoreStatBonus = null,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<MeleeAttack>();
      if (autoHit is not null)
      {
        element.AutoHit = autoHit;
      }
      if (caster is not null)
      {
        builder.Validate(caster);
        element.Caster = caster;
      }
      if (ignoreStatBonus is not null)
      {
        element.IgnoreStatBonus = ignoreStatBonus;
      }
      if (target is not null)
      {
        builder.Validate(target);
        element.Target = target;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PartyUnits"/>
    /// </summary>
    public static ActionsBuilder PartyUnits(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null,
        Player.CharactersList? unitsList = null)
    {
      var element = ElementTool.Create<PartyUnits>();
      if (actions is not null)
      {
        element.Actions = actions.Build();
      }
      if (element.Actions is null)
      {
        element.Actions = Constants.Empty.Actions;
      }
      if (unitsList is not null)
      {
        element.m_UnitsList = unitsList;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PartyUseAbility"/>
    /// </summary>
    public static ActionsBuilder PartyUseAbility(
        this ActionsBuilder builder,
        bool? allowItems = null,
        AbilitiesHelper.AbilityDescription? description = null)
    {
      var element = ElementTool.Create<PartyUseAbility>();
      if (allowItems is not null)
      {
        element.AllowItems = allowItems;
      }
      if (description is not null)
      {
        builder.Validate(description);
        element.Description = description;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RaiseDead"/>
    /// </summary>
    ///
    /// <param name="companion">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RaiseDead(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? companion = null,
        bool? riseAllCompanions = null)
    {
      var element = ElementTool.Create<RaiseDead>();
      if (companion is not null)
      {
        element.m_companion = companion.Reference;
      }
      if (element.m_companion is null)
      {
        element.m_companion = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      if (riseAllCompanions is not null)
      {
        element.riseAllCompanions = riseAllCompanions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RandomAction"/>
    /// </summary>
    public static ActionsBuilder RandomAction(
        this ActionsBuilder builder,
        ActionAndWeight[]? actions = null)
    {
      var element = ElementTool.Create<RandomAction>();
      if (actions is not null)
      {
        element.Actions = actions;
      }
      if (element.Actions is null)
      {
        element.Actions = new ActionAndWeight[0];
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveDeathDoor"/>
    /// </summary>
    public static ActionsBuilder RemoveDeathDoor(
        this ActionsBuilder builder,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<RemoveDeathDoor>();
      if (unit is not null)
      {
        builder.Validate(unit);
        element.Unit = unit;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveFact"/>
    /// </summary>
    ///
    /// <param name="fact">
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RemoveFact(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? fact = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<RemoveFact>();
      if (fact is not null)
      {
        element.m_Fact = fact.Reference;
      }
      if (element.m_Fact is null)
      {
        element.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      if (unit is not null)
      {
        builder.Validate(unit);
        element.Unit = unit;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RollPartySkillCheck"/>
    /// </summary>
    public static ActionsBuilder RollPartySkillCheck(
        this ActionsBuilder builder,
        int? dC = null,
        bool? logFailure = null,
        bool? logSuccess = null,
        ActionsBuilder? onFailure = null,
        ActionsBuilder? onSuccess = null,
        StatType? stat = null)
    {
      var element = ElementTool.Create<RollPartySkillCheck>();
      if (dC is not null)
      {
        element.DC = dC;
      }
      if (logFailure is not null)
      {
        element.LogFailure = logFailure;
      }
      if (logSuccess is not null)
      {
        element.LogSuccess = logSuccess;
      }
      if (onFailure is not null)
      {
        element.OnFailure = onFailure.Build();
      }
      if (element.OnFailure is null)
      {
        element.OnFailure = Constants.Empty.Actions;
      }
      if (onSuccess is not null)
      {
        element.OnSuccess = onSuccess.Build();
      }
      if (element.OnSuccess is null)
      {
        element.OnSuccess = Constants.Empty.Actions;
      }
      if (stat is not null)
      {
        element.Stat = stat;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RollSkillCheck"/>
    /// </summary>
    public static ActionsBuilder RollSkillCheck(
        this ActionsBuilder builder,
        int? dC = null,
        bool? forbidPartyHelpInCamp = null,
        bool? logFailure = null,
        bool? logSuccess = null,
        ActionsBuilder? onFailure = null,
        ActionsBuilder? onSuccess = null,
        StatType? stat = null,
        UnitEvaluator? unit = null,
        bool? voice = null)
    {
      var element = ElementTool.Create<RollSkillCheck>();
      if (dC is not null)
      {
        element.DC = dC;
      }
      if (forbidPartyHelpInCamp is not null)
      {
        element.ForbidPartyHelpInCamp = forbidPartyHelpInCamp;
      }
      if (logFailure is not null)
      {
        element.LogFailure = logFailure;
      }
      if (logSuccess is not null)
      {
        element.LogSuccess = logSuccess;
      }
      if (onFailure is not null)
      {
        element.OnFailure = onFailure.Build();
      }
      if (element.OnFailure is null)
      {
        element.OnFailure = Constants.Empty.Actions;
      }
      if (onSuccess is not null)
      {
        element.OnSuccess = onSuccess.Build();
      }
      if (element.OnSuccess is null)
      {
        element.OnSuccess = Constants.Empty.Actions;
      }
      if (stat is not null)
      {
        element.Stat = stat;
      }
      if (unit is not null)
      {
        builder.Validate(unit);
        element.Unit = unit;
      }
      if (voice is not null)
      {
        element.Voice = voice;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RunActionHolder"/>
    /// </summary>
    ///
    /// <param name="holder">
    /// Blueprint of type ActionsHolder. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RunActionHolder(
        this ActionsBuilder builder,
        string? comment = null,
        Blueprint<ActionsHolder, ActionsReference>? holder = null,
        ParametrizedContextSetter? parameters = null)
    {
      var element = ElementTool.Create<RunActionHolder>();
      if (comment is not null)
      {
        element.Comment = comment;
      }
      if (holder is not null)
      {
        element.Holder = holder.Reference;
      }
      if (element.Holder is null)
      {
        element.Holder = BlueprintTool.GetRef<ActionsReference>(null);
      }
      if (parameters is not null)
      {
        builder.Validate(parameters);
        element.Parameters = parameters;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Spawn"/>
    /// </summary>
    public static ActionsBuilder Spawn(
        this ActionsBuilder builder,
        ActionsBuilder? actionsOnSpawn = null,
        EntityReference[]? spawners = null)
    {
      var element = ElementTool.Create<Spawn>();
      if (actionsOnSpawn is not null)
      {
        element.ActionsOnSpawn = actionsOnSpawn.Build();
      }
      if (element.ActionsOnSpawn is null)
      {
        element.ActionsOnSpawn = Constants.Empty.Actions;
      }
      if (spawners is not null)
      {
        foreach (var item in spawners) { builder.Validate(item); }
        element.Spawners = spawners;
      }
      if (element.Spawners is null)
      {
        element.Spawners = new EntityReference[0];
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SpawnBySummonPool"/>
    /// </summary>
    ///
    /// <param name="pool">
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SpawnBySummonPool(
        this ActionsBuilder builder,
        ActionsBuilder? actionsOnSpawn = null,
        bool? ignoreSpawnerConditions = null,
        Blueprint<BlueprintSummonPool, BlueprintSummonPoolReference>? pool = null)
    {
      var element = ElementTool.Create<SpawnBySummonPool>();
      if (actionsOnSpawn is not null)
      {
        element.ActionsOnSpawn = actionsOnSpawn.Build();
      }
      if (element.ActionsOnSpawn is null)
      {
        element.ActionsOnSpawn = Constants.Empty.Actions;
      }
      if (ignoreSpawnerConditions is not null)
      {
        element.m_IgnoreSpawnerConditions = ignoreSpawnerConditions;
      }
      if (pool is not null)
      {
        element.m_Pool = pool.Reference;
      }
      if (element.m_Pool is null)
      {
        element.m_Pool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SpawnByUnitGroup"/>
    /// </summary>
    public static ActionsBuilder SpawnByUnitGroup(
        this ActionsBuilder builder,
        ActionsBuilder? actionsOnSpawn = null,
        EntityReference? group = null)
    {
      var element = ElementTool.Create<SpawnByUnitGroup>();
      if (actionsOnSpawn is not null)
      {
        element.ActionsOnSpawn = actionsOnSpawn.Build();
      }
      if (element.ActionsOnSpawn is null)
      {
        element.ActionsOnSpawn = Constants.Empty.Actions;
      }
      if (group is not null)
      {
        builder.Validate(group);
        element.Group = group;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="StatusEffect"/>
    /// </summary>
    public static ActionsBuilder StatusEffect(
        this ActionsBuilder builder,
        UnitCondition? condition = null,
        bool? remove = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<StatusEffect>();
      if (condition is not null)
      {
        element.Condition = condition;
      }
      if (remove is not null)
      {
        element.Remove = remove;
      }
      if (unit is not null)
      {
        builder.Validate(unit);
        element.Unit = unit;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Summon"/>
    /// </summary>
    ///
    /// <param name="summonPool">
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="unit">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder Summon(
        this ActionsBuilder builder,
        bool? groupBySummonPool = null,
        Vector3? offset = null,
        ActionsBuilder? onSummmon = null,
        Blueprint<BlueprintSummonPool, BlueprintSummonPoolReference>? summonPool = null,
        TransformEvaluator? transform = null,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? unit = null)
    {
      var element = ElementTool.Create<Summon>();
      if (groupBySummonPool is not null)
      {
        element.GroupBySummonPool = groupBySummonPool;
      }
      if (offset is not null)
      {
        element.Offset = offset;
      }
      if (onSummmon is not null)
      {
        element.OnSummmon = onSummmon.Build();
      }
      if (element.OnSummmon is null)
      {
        element.OnSummmon = Constants.Empty.Actions;
      }
      if (summonPool is not null)
      {
        element.m_SummonPool = summonPool.Reference;
      }
      if (element.m_SummonPool is null)
      {
        element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      if (transform is not null)
      {
        builder.Validate(transform);
        element.Transform = transform;
      }
      if (unit is not null)
      {
        element.m_Unit = unit.Reference;
      }
      if (element.m_Unit is null)
      {
        element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SummonPoolUnits"/>
    /// </summary>
    ///
    /// <param name="summonPool">
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SummonPoolUnits(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null,
        ConditionsBuilder? conditions = null,
        Blueprint<BlueprintSummonPool, BlueprintSummonPoolReference>? summonPool = null)
    {
      var element = ElementTool.Create<SummonPoolUnits>();
      if (actions is not null)
      {
        element.Actions = actions.Build();
      }
      if (element.Actions is null)
      {
        element.Actions = Constants.Empty.Actions;
      }
      if (conditions is not null)
      {
        element.Conditions = conditions.Build();
      }
      if (element.Conditions is null)
      {
        element.Conditions = Constants.Empty.Conditions;
      }
      if (summonPool is not null)
      {
        element.m_SummonPool = summonPool.Reference;
      }
      if (element.m_SummonPool is null)
      {
        element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SummonUnitCopy"/>
    /// </summary>
    ///
    /// <param name="copyBlueprint">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="summonPool">
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SummonUnitCopy(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? copyBlueprint = null,
        UnitEvaluator? copyFrom = null,
        bool? doNotCreateItems = null,
        LocatorEvaluator? locator = null,
        ActionsBuilder? onSummon = null,
        Blueprint<BlueprintSummonPool, BlueprintSummonPoolReference>? summonPool = null)
    {
      var element = ElementTool.Create<SummonUnitCopy>();
      if (copyBlueprint is not null)
      {
        element.m_CopyBlueprint = copyBlueprint.Reference;
      }
      if (element.m_CopyBlueprint is null)
      {
        element.m_CopyBlueprint = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      if (copyFrom is not null)
      {
        builder.Validate(copyFrom);
        element.CopyFrom = copyFrom;
      }
      if (doNotCreateItems is not null)
      {
        element.DoNotCreateItems = doNotCreateItems;
      }
      if (locator is not null)
      {
        builder.Validate(locator);
        element.Locator = locator;
      }
      if (onSummon is not null)
      {
        element.OnSummon = onSummon.Build();
      }
      if (element.OnSummon is null)
      {
        element.OnSummon = Constants.Empty.Actions;
      }
      if (summonPool is not null)
      {
        element.m_SummonPool = summonPool.Reference;
      }
      if (element.m_SummonPool is null)
      {
        element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwitchActivatableAbility"/>
    /// </summary>
    ///
    /// <param name="ability">
    /// Blueprint of type BlueprintActivatableAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SwitchActivatableAbility(
        this ActionsBuilder builder,
        Blueprint<BlueprintActivatableAbility, BlueprintActivatableAbilityReference>? ability = null,
        bool? isOn = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<SwitchActivatableAbility>();
      if (ability is not null)
      {
        element.m_Ability = ability.Reference;
      }
      if (element.m_Ability is null)
      {
        element.m_Ability = BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(null);
      }
      if (isOn is not null)
      {
        element.IsOn = isOn;
      }
      if (unit is not null)
      {
        builder.Validate(unit);
        element.Unit = unit;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwitchDualCompanion"/>
    /// </summary>
    public static ActionsBuilder SwitchDualCompanion(
        this ActionsBuilder builder,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<SwitchDualCompanion>();
      if (unit is not null)
      {
        builder.Validate(unit);
        element.Unit = unit;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitsFromSpawnersInUnitGroup"/>
    /// </summary>
    public static ActionsBuilder UnitsFromSpawnersInUnitGroup(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null,
        EntityReference? group = null)
    {
      var element = ElementTool.Create<UnitsFromSpawnersInUnitGroup>();
      if (actions is not null)
      {
        element.Actions = actions.Build();
      }
      if (element.Actions is null)
      {
        element.Actions = Constants.Empty.Actions;
      }
      if (group is not null)
      {
        builder.Validate(group);
        element.m_Group = group;
      }
      return builder.Add(element);
    }
  }
}
