//***** AUTO-GENERATED - DO NOT EDIT *****//

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
        Blueprint<BlueprintBuff, BlueprintBuffReference> buff,
        IntEvaluator duration,
        UnitEvaluator target)
    {
      var element = ElementTool.Create<AttachBuff>();
      element.m_Buff = buff.Reference;
      builder.Validate(duration);
      element.Duration = duration;
      builder.Validate(target);
      element.Target = target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CreaturesAround"/>
    /// </summary>
    public static ActionsBuilder OnCreaturesAround(
        this ActionsBuilder builder,
        ActionsBuilder actions,
        PositionEvaluator center,
        FloatEvaluator radius,
        bool? checkLos = null,
        bool? includeDead = null)
    {
      var element = ElementTool.Create<CreaturesAround>();
      element.Actions = actions.Build();
      builder.Validate(center);
      element.Center = center;
      builder.Validate(radius);
      element.Radius = radius;
      element.CheckLos = checkLos ?? element.CheckLos;
      element.IncludeDead = includeDead ?? element.IncludeDead;
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
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference> fact,
        UnitEvaluator unit)
    {
      var element = ElementTool.Create<AddFact>();
      element.m_Fact = fact.Reference;
      builder.Validate(unit);
      element.Unit = unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddFatigueHours"/>
    /// </summary>
    public static ActionsBuilder AddFatigueHours(
        this ActionsBuilder builder,
        IntEvaluator hours,
        UnitEvaluator unit)
    {
      var element = ElementTool.Create<AddFatigueHours>();
      builder.Validate(hours);
      element.Hours = hours;
      builder.Validate(unit);
      element.Unit = unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangeAlignment"/>
    /// </summary>
    public static ActionsBuilder ChangeAlignment(
        this ActionsBuilder builder,
        Alignment alignment,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<ChangeAlignment>();
      element.Alignment = alignment;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangePlayerAlignment"/>
    /// </summary>
    public static ActionsBuilder ChangePlayerAlignment(
        this ActionsBuilder builder,
        Alignment targetAlignment,
        bool? canUnlockAlignment = null)
    {
      var element = ElementTool.Create<ChangePlayerAlignment>();
      element.TargetAlignment = targetAlignment;
      element.CanUnlockAlignment = canUnlockAlignment ?? element.CanUnlockAlignment;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DamageParty"/>
    /// </summary>
    public static ActionsBuilder DamageParty(
        this ActionsBuilder builder,
        DamageDescription damage,
        UnitEvaluator? damageSource = null,
        bool? disableBattleLog = null,
        bool? noSource = null)
    {
      var element = ElementTool.Create<DamageParty>();
      builder.Validate(damage);
      element.Damage = damage;
      builder.Validate(damageSource);
      element.DamageSource = damageSource ?? element.DamageSource;
      element.NoSource = damageSource is null;
      element.DisableBattleLog = disableBattleLog ?? element.DisableBattleLog;
      element.NoSource = noSource ?? element.NoSource;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DealDamage"/>
    /// </summary>
    public static ActionsBuilder DealDamage(
        this ActionsBuilder builder,
        DamageDescription damage,
        UnitEvaluator target,
        bool? disableBattleLog = null,
        bool? disableFxAndSound = null,
        bool? noSource = null,
        UnitEvaluator? source = null)
    {
      var element = ElementTool.Create<DealDamage>();
      builder.Validate(damage);
      element.Damage = damage;
      builder.Validate(target);
      element.Target = target;
      element.DisableBattleLog = disableBattleLog ?? element.DisableBattleLog;
      element.DisableFxAndSound = disableFxAndSound ?? element.DisableFxAndSound;
      element.NoSource = noSource ?? element.NoSource;
      builder.Validate(source);
      element.Source = source ?? element.Source;
      element.NoSource = source is null;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DealStatDamage"/>
    /// </summary>
    public static ActionsBuilder DealStatDamage(
        this ActionsBuilder builder,
        DiceFormula damageDice,
        StatType stat,
        UnitEvaluator target,
        int? damageBonus = null,
        bool? disableBattleLog = null,
        bool? isDrain = null,
        bool? noSource = null,
        UnitEvaluator? source = null)
    {
      var element = ElementTool.Create<DealStatDamage>();
      element.DamageDice = damageDice;
      element.Stat = stat;
      builder.Validate(target);
      element.Target = target;
      element.DamageBonus = damageBonus ?? element.DamageBonus;
      element.DisableBattleLog = disableBattleLog ?? element.DisableBattleLog;
      element.IsDrain = isDrain ?? element.IsDrain;
      element.NoSource = noSource ?? element.NoSource;
      builder.Validate(source);
      element.Source = source ?? element.Source;
      element.NoSource = source is null;
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
    public static ActionsBuilder AddItems(
        this ActionsBuilder builder,
        List<LootEntry> items,
        ItemsCollectionEvaluator toCollection,
        Blueprint<BlueprintUnitLoot, BlueprintUnitLootReference>? blueprintLoot = null,
        bool? identify = null,
        bool? silent = null,
        bool? useBlueprintUnitLoot = null)
    {
      var element = ElementTool.Create<AddItemsToCollection>();
      foreach (var item in items) { builder.Validate(item); }
      element.Loot = items;
      builder.Validate(toCollection);
      element.ItemsCollection = toCollection;
      element.m_BlueprintLoot = blueprintLoot.Reference ?? element.m_BlueprintLoot;
      if (element.m_BlueprintLoot is null)
      {
        element.m_BlueprintLoot = BlueprintTool.GetRef<BlueprintUnitLootReference>(null);
      }
      element.Identify = identify ?? element.Identify;
      element.Silent = silent ?? element.Silent;
      element.UseBlueprintUnitLoot = useBlueprintUnitLoot ?? element.UseBlueprintUnitLoot;
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
    public static ActionsBuilder AddItemsFromBlueprint(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnitLoot, BlueprintUnitLootReference> blueprintLoot,
        ItemsCollectionEvaluator toCollection,
        bool? identify = null,
        List<LootEntry>? loot = null,
        bool? silent = null,
        bool? useBlueprintUnitLoot = null)
    {
      var element = ElementTool.Create<AddItemsToCollection>();
      element.m_BlueprintLoot = blueprintLoot.Reference;
      builder.Validate(toCollection);
      element.ItemsCollection = toCollection;
      element.Identify = identify ?? element.Identify;
      foreach (var item in loot) { builder.Validate(item); }
      element.Loot = loot ?? element.Loot;
      if (element.Loot is null)
      {
        element.Loot = new();
      }
      element.Silent = silent ?? element.Silent;
      element.UseBlueprintUnitLoot = useBlueprintUnitLoot ?? element.UseBlueprintUnitLoot;
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
      builder.Validate(level);
      element.Level = level ?? element.Level;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
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
      element.FadeOut = fadeOut ?? element.FadeOut;
      builder.Validate(target);
      element.Target = target ?? element.Target;
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
      builder.Validate(groupHolder);
      element.GroupHolder = groupHolder ?? element.GroupHolder;
      builder.Validate(targetUnit);
      element.TargetUnit = targetUnit ?? element.TargetUnit;
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
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
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
      element.m_SummonPool = summonPool.Reference ?? element.m_SummonPool;
      if (element.m_SummonPool is null)
      {
        element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
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
      element.m_SummonPool = summonPool.Reference ?? element.m_SummonPool;
      if (element.m_SummonPool is null)
      {
        element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
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
      element.m_Buff = buff.Reference ?? element.m_Buff;
      if (element.m_Buff is null)
      {
        element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      builder.Validate(target);
      element.Target = target ?? element.Target;
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
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
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
      element.DamageBonus = damageBonus ?? element.DamageBonus;
      element.DamageDice = damageDice ?? element.DamageDice;
      element.DisableBattleLog = disableBattleLog ?? element.DisableBattleLog;
      element.Duration = duration ?? element.Duration;
      element.NoSource = noSource ?? element.NoSource;
      builder.Validate(source);
      element.Source = source ?? element.Source;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      element.Type = type ?? element.Type;
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
      element.m_ActionsOnRestEnd = actionsOnRestEnd.Build() ?? element.m_ActionsOnRestEnd;
      if (element.m_ActionsOnRestEnd is null)
      {
        element.m_ActionsOnRestEnd = Constants.Empty.Actions;
      }
      element.m_IgnoreCorruption = ignoreCorruption ?? element.m_IgnoreCorruption;
      element.m_Immediate = immediate ?? element.m_Immediate;
      element.m_RestWithCraft = restWithCraft ?? element.m_RestWithCraft;
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
      builder.Validate(count);
      element.Count = count ?? element.Count;
      element.CR = cR ?? element.CR;
      element.Dummy = dummy ?? element.Dummy;
      element.Encounter = encounter ?? element.Encounter;
      element.Modifier = modifier ?? element.Modifier;
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
      element.Levels = levels ?? element.Levels;
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
      builder.Validate(healSource);
      element.HealSource = healSource ?? element.HealSource;
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
      builder.Validate(healAmount);
      element.HealAmount = healAmount ?? element.HealAmount;
      builder.Validate(source);
      element.Source = source ?? element.Source;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      element.ToFullHP = toFullHP ?? element.ToFullHP;
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
      builder.Validate(charges);
      element.Charges = charges ?? element.Charges;
      builder.Validate(collection);
      element.Collection = collection ?? element.Collection;
      element.m_Item = item.Reference ?? element.m_Item;
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
      element.Critical = critical ?? element.Critical;
      element.DisableBattleLog = disableBattleLog ?? element.DisableBattleLog;
      builder.Validate(killer);
      element.Killer = killer ?? element.Killer;
      element.RemoveExp = removeExp ?? element.RemoveExp;
      builder.Validate(target);
      element.Target = target ?? element.Target;
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
      builder.Validate(targetLevel);
      element.TargetLevel = targetLevel ?? element.TargetLevel;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
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
      element.AutoHit = autoHit ?? element.AutoHit;
      builder.Validate(caster);
      element.Caster = caster ?? element.Caster;
      element.IgnoreStatBonus = ignoreStatBonus ?? element.IgnoreStatBonus;
      builder.Validate(target);
      element.Target = target ?? element.Target;
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
      element.Actions = actions.Build() ?? element.Actions;
      if (element.Actions is null)
      {
        element.Actions = Constants.Empty.Actions;
      }
      element.m_UnitsList = unitsList ?? element.m_UnitsList;
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
      element.AllowItems = allowItems ?? element.AllowItems;
      builder.Validate(description);
      element.Description = description ?? element.Description;
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
      element.m_companion = companion.Reference ?? element.m_companion;
      if (element.m_companion is null)
      {
        element.m_companion = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      element.riseAllCompanions = riseAllCompanions ?? element.riseAllCompanions;
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
      element.Actions = actions ?? element.Actions;
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
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
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
      element.m_Fact = fact.Reference ?? element.m_Fact;
      if (element.m_Fact is null)
      {
        element.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
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
      element.DC = dC ?? element.DC;
      element.LogFailure = logFailure ?? element.LogFailure;
      element.LogSuccess = logSuccess ?? element.LogSuccess;
      element.OnFailure = onFailure.Build() ?? element.OnFailure;
      if (element.OnFailure is null)
      {
        element.OnFailure = Constants.Empty.Actions;
      }
      element.OnSuccess = onSuccess.Build() ?? element.OnSuccess;
      if (element.OnSuccess is null)
      {
        element.OnSuccess = Constants.Empty.Actions;
      }
      element.Stat = stat ?? element.Stat;
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
      element.DC = dC ?? element.DC;
      element.ForbidPartyHelpInCamp = forbidPartyHelpInCamp ?? element.ForbidPartyHelpInCamp;
      element.LogFailure = logFailure ?? element.LogFailure;
      element.LogSuccess = logSuccess ?? element.LogSuccess;
      element.OnFailure = onFailure.Build() ?? element.OnFailure;
      if (element.OnFailure is null)
      {
        element.OnFailure = Constants.Empty.Actions;
      }
      element.OnSuccess = onSuccess.Build() ?? element.OnSuccess;
      if (element.OnSuccess is null)
      {
        element.OnSuccess = Constants.Empty.Actions;
      }
      element.Stat = stat ?? element.Stat;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      element.Voice = voice ?? element.Voice;
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
      element.Comment = comment ?? element.Comment;
      element.Holder = holder.Reference ?? element.Holder;
      if (element.Holder is null)
      {
        element.Holder = BlueprintTool.GetRef<ActionsReference>(null);
      }
      builder.Validate(parameters);
      element.Parameters = parameters ?? element.Parameters;
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
      element.ActionsOnSpawn = actionsOnSpawn.Build() ?? element.ActionsOnSpawn;
      if (element.ActionsOnSpawn is null)
      {
        element.ActionsOnSpawn = Constants.Empty.Actions;
      }
      foreach (var item in spawners) { builder.Validate(item); }
      element.Spawners = spawners ?? element.Spawners;
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
      element.ActionsOnSpawn = actionsOnSpawn.Build() ?? element.ActionsOnSpawn;
      if (element.ActionsOnSpawn is null)
      {
        element.ActionsOnSpawn = Constants.Empty.Actions;
      }
      element.m_IgnoreSpawnerConditions = ignoreSpawnerConditions ?? element.m_IgnoreSpawnerConditions;
      element.m_Pool = pool.Reference ?? element.m_Pool;
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
      element.ActionsOnSpawn = actionsOnSpawn.Build() ?? element.ActionsOnSpawn;
      if (element.ActionsOnSpawn is null)
      {
        element.ActionsOnSpawn = Constants.Empty.Actions;
      }
      builder.Validate(group);
      element.Group = group ?? element.Group;
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
      element.Condition = condition ?? element.Condition;
      element.Remove = remove ?? element.Remove;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
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
      element.GroupBySummonPool = groupBySummonPool ?? element.GroupBySummonPool;
      element.Offset = offset ?? element.Offset;
      element.OnSummmon = onSummmon.Build() ?? element.OnSummmon;
      if (element.OnSummmon is null)
      {
        element.OnSummmon = Constants.Empty.Actions;
      }
      element.m_SummonPool = summonPool.Reference ?? element.m_SummonPool;
      if (element.m_SummonPool is null)
      {
        element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      builder.Validate(transform);
      element.Transform = transform ?? element.Transform;
      element.m_Unit = unit.Reference ?? element.m_Unit;
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
      element.Actions = actions.Build() ?? element.Actions;
      if (element.Actions is null)
      {
        element.Actions = Constants.Empty.Actions;
      }
      element.Conditions = conditions.Build() ?? element.Conditions;
      if (element.Conditions is null)
      {
        element.Conditions = Constants.Empty.Conditions;
      }
      element.m_SummonPool = summonPool.Reference ?? element.m_SummonPool;
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
      element.m_CopyBlueprint = copyBlueprint.Reference ?? element.m_CopyBlueprint;
      if (element.m_CopyBlueprint is null)
      {
        element.m_CopyBlueprint = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      builder.Validate(copyFrom);
      element.CopyFrom = copyFrom ?? element.CopyFrom;
      element.DoNotCreateItems = doNotCreateItems ?? element.DoNotCreateItems;
      builder.Validate(locator);
      element.Locator = locator ?? element.Locator;
      element.OnSummon = onSummon.Build() ?? element.OnSummon;
      if (element.OnSummon is null)
      {
        element.OnSummon = Constants.Empty.Actions;
      }
      element.m_SummonPool = summonPool.Reference ?? element.m_SummonPool;
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
      element.m_Ability = ability.Reference ?? element.m_Ability;
      if (element.m_Ability is null)
      {
        element.m_Ability = BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(null);
      }
      element.IsOn = isOn ?? element.IsOn;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
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
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
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
      element.Actions = actions.Build() ?? element.Actions;
      if (element.Actions is null)
      {
        element.Actions = Constants.Empty.Actions;
      }
      builder.Validate(group);
      element.m_Group = group ?? element.m_Group;
      return builder.Add(element);
    }
  }
}
