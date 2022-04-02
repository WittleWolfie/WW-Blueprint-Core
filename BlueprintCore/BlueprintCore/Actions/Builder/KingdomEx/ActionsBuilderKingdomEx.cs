//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Armies.Components;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Armies.TacticalCombat.GameActions;
using Kingmaker.Armies.TacticalCombat.Grid;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Crusade.GlobalMagic;
using Kingmaker.Crusade.GlobalMagic.Actions;
using Kingmaker.Crusade.GlobalMagic.Actions.DamageLogic;
using Kingmaker.Crusade.GlobalMagic.Actions.SummonLogics;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Globalmap.State;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Actions;
using Kingmaker.Kingdom.AI;
using Kingmaker.Kingdom.Armies;
using Kingmaker.Kingdom.Armies.Actions;
using Kingmaker.Kingdom.Artisans;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Kingdom.Flags;
using Kingmaker.Kingdom.Settlements;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Actions.Builder.KingdomEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for actions involving the Kingdom and Crusade system.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderKingdomEx
  {

    /// <summary>
    /// Adds <see cref="AddBuffToSquad"/>
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
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AddBuffToSquad(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference> buff,
        SquadFilter filter,
        GlobalMagicValue hoursDuration)
    {
      var element = ElementTool.Create<AddBuffToSquad>();
      element.m_Buff = buff?.Reference;
      builder.Validate(filter);
      element.m_Filter = filter;
      builder.Validate(hoursDuration);
      element.m_HoursDuration = hoursDuration;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddCrusadeResources"/>
    /// </summary>
    public static ActionsBuilder AddCrusadeResources(
        this ActionsBuilder builder,
        KingdomResourcesAmount _resourcesAmount)
    {
      var element = ElementTool.Create<AddCrusadeResources>();
      element._resourcesAmount = _resourcesAmount;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddMorale"/>
    /// </summary>
    public static ActionsBuilder AddMorale(
        this ActionsBuilder builder,
        int? bonus = null,
        DiceFormula? change = null,
        bool? substract = null)
    {
      var element = ElementTool.Create<AddMorale>();
      element.Bonus = bonus ?? element.Bonus;
      element.Change = change ?? element.Change;
      element.Substract = substract ?? element.Substract;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddMorale"/>
    /// </summary>
    public static ActionsBuilder SubtractMorale(
        this ActionsBuilder builder,
        int? bonus = null,
        DiceFormula? change = null,
        bool? substract = null)
    {
      var element = ElementTool.Create<AddMorale>();
      element.Bonus = bonus ?? element.Bonus;
      element.Change = change ?? element.Change;
      element.Substract = substract ?? element.Substract;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangeArmyMorale"/>
    /// </summary>
    public static ActionsBuilder ChangeArmyMorale(
        this ActionsBuilder builder,
        GlobalMagicValue changeValue,
        GlobalMagicValue duration)
    {
      var element = ElementTool.Create<ChangeArmyMorale>();
      builder.Validate(changeValue);
      element.m_ChangeValue = changeValue;
      builder.Validate(duration);
      element.m_Duration = duration;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangeTacticalMorale"/>
    /// </summary>
    public static ActionsBuilder ChangeTacticalMorale(
        this ActionsBuilder builder,
        ContextValue value)
    {
      var element = ElementTool.Create<ChangeTacticalMorale>();
      element.m_Value = value;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionAddCrusadeResource"/>
    /// </summary>
    public static ActionsBuilder AddCrusadeResource(
        this ActionsBuilder builder,
        KingdomResourcesAmount resourcesAmount)
    {
      var element = ElementTool.Create<ContextActionAddCrusadeResource>();
      element.m_ResourcesAmount = resourcesAmount;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionArmyRemoveFacts"/>
    /// </summary>
    ///
    /// <param name="factsToRemove">
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ArmyRemoveFacts(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>>? factsToRemove = null)
    {
      var element = ElementTool.Create<ContextActionArmyRemoveFacts>();
      element.m_FactsToRemove = factsToRemove?.Select(bp => bp.Reference)?.ToArray() ?? element.m_FactsToRemove;
      if (element.m_FactsToRemove is null)
      {
        element.m_FactsToRemove = new BlueprintUnitFactReference[0];
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSquadUnitsKill"/>
    /// </summary>
    public static ActionsBuilder KillSquadUnits(
        this ActionsBuilder builder,
        float floatCount)
    {
      var element = ElementTool.Create<ContextActionSquadUnitsKill>();
      element.m_FloatCount = floatCount;
      element.m_UseFloatValue = true;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSquadUnitsKill"/>
    /// </summary>
    public static ActionsBuilder KillSquadLeaders(
        this ActionsBuilder builder,
        ContextDiceValue count)
    {
      var element = ElementTool.Create<ContextActionSquadUnitsKill>();
      element.m_Count = count;
      element.m_UseFloatValue = false;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSummonTacticalSquad"/>
    /// </summary>
    ///
    /// <param name="blueprint">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="summonPool">
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SummonTacticalSquad(
        this ActionsBuilder builder,
        ContextValue count,
        ActionsBuilder? afterSpawn = null,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? blueprint = null,
        Blueprint<BlueprintSummonPool, BlueprintSummonPoolReference>? summonPool = null)
    {
      var element = ElementTool.Create<ContextActionSummonTacticalSquad>();
      element.m_Count = count;
      element.m_AfterSpawn = afterSpawn?.Build() ?? element.m_AfterSpawn;
      if (element.m_AfterSpawn is null)
      {
        element.m_AfterSpawn = Utils.Constants.Empty.Actions;
      }
      element.m_Blueprint = blueprint?.Reference ?? element.m_Blueprint;
      if (element.m_Blueprint is null)
      {
        element.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      element.m_SummonPool = summonPool?.Reference ?? element.m_SummonPool;
      if (element.m_SummonPool is null)
      {
        element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionTacticalCombatDealDamage"/>
    /// </summary>
    public static ActionsBuilder TacticalCombatDealDamage(
        this ActionsBuilder builder,
        DamageTypeDescription damageType,
        DiceType diceType,
        bool? half = null,
        bool? ignoreCritical = null,
        int? minHPAfterDamage = null,
        ContextValue? rollsCount = null)
    {
      var element = ElementTool.Create<ContextActionTacticalCombatDealDamage>();
      builder.Validate(damageType);
      element.DamageType = damageType;
      element.DiceType = diceType;
      element.Half = half ?? element.Half;
      element.IgnoreCritical = ignoreCritical ?? element.IgnoreCritical;
      element.MinHPAfterDamage = minHPAfterDamage ?? element.MinHPAfterDamage;
      element.UseMinHPAfterDamage = minHPAfterDamage is not null;
      element.RollsCount = rollsCount ?? element.RollsCount;
      if (element.RollsCount is null)
      {
        element.RollsCount = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CreateArmy"/>
    /// </summary>
    ///
    /// <param name="army">
    /// Blueprint of type BlueprintArmyPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="location">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="armyLeader">
    /// Blueprint of type BlueprintArmyLeader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder CreateCrusaderArmy(
        this ActionsBuilder builder,
        Blueprint<BlueprintArmyPreset, BlueprintArmyPreset.Reference> army,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference> location,
        bool? applyRecruitIncrease = null,
        Blueprint<BlueprintArmyLeader, ArmyLeader.Reference>? armyLeader = null,
        float? armySpeed = null,
        int? movementPoints = null)
    {
      var element = ElementTool.Create<CreateArmy>();
      element.Preset = army?.Reference;
      element.Location = location?.Reference;
      element.m_ApplyRecruitIncrease = applyRecruitIncrease ?? element.m_ApplyRecruitIncrease;
      element.ArmyLeader = armyLeader?.Reference ?? element.ArmyLeader;
      element.WithLeader = armyLeader is not null;
      if (element.ArmyLeader is null)
      {
        element.ArmyLeader = BlueprintTool.GetRef<ArmyLeader.Reference>(null);
      }
      element.m_ArmySpeed = armySpeed ?? element.m_ArmySpeed;
      element.MovementPoints = movementPoints ?? element.MovementPoints;
      element.Faction = ArmyFaction.Crusaders;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CreateArmy"/>
    /// </summary>
    ///
    /// <param name="army">
    /// Blueprint of type BlueprintArmyPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="location">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="armyLeader">
    /// Blueprint of type BlueprintArmyLeader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="completeActions">
    /// Blueprint of type BlueprintActionList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder CreateDemonArmy(
        this ActionsBuilder builder,
        Blueprint<BlueprintArmyPreset, BlueprintArmyPreset.Reference> army,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference> location,
        Blueprint<BlueprintArmyLeader, ArmyLeader.Reference>? armyLeader = null,
        float? armySpeed = null,
        Blueprint<BlueprintActionList, BlueprintActionList.Reference>? completeActions = null,
        bool targetNearestEnemy = false)
    {
      var element = ElementTool.Create<CreateArmy>();
      element.Preset = army?.Reference;
      element.Location = location?.Reference;
      element.ArmyLeader = armyLeader?.Reference ?? element.ArmyLeader;
      element.WithLeader = armyLeader is not null;
      if (element.ArmyLeader is null)
      {
        element.ArmyLeader = BlueprintTool.GetRef<ArmyLeader.Reference>(null);
      }
      element.m_ArmySpeed = armySpeed ?? element.m_ArmySpeed;
      element.m_CompleteActions = completeActions?.Reference ?? element.m_CompleteActions;
      if (element.m_CompleteActions is null)
      {
        element.m_CompleteActions = BlueprintTool.GetRef<BlueprintActionList.Reference>(null);
      }
      element.m_MoveTarget = targetNearestEnemy ? TravelLogicType.NearestEnemy : TravelLogicType.None;;
      element.Faction = ArmyFaction.Demons;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CreateArmyFromLosses"/>
    /// </summary>
    ///
    /// <param name="location">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder CreateArmyFromLosses(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference> location,
        int squadsMaxCount,
        int sumExperience,
        bool? applyRecruitIncrease = null)
    {
      var element = ElementTool.Create<CreateArmyFromLosses>();
      element.m_Location = location?.Reference;
      element.m_SquadsMaxCount = squadsMaxCount;
      element.m_SumExperience = sumExperience;
      element.m_ApplyRecruitIncrease = applyRecruitIncrease ?? element.m_ApplyRecruitIncrease;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CreateGarrison"/>
    /// </summary>
    ///
    /// <param name="army">
    /// Blueprint of type BlueprintArmyPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="location">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="armyLeader">
    /// Blueprint of type BlueprintArmyLeader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder CreateGarrison(
        this ActionsBuilder builder,
        Blueprint<BlueprintArmyPreset, BlueprintArmyPreset.Reference> army,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference> location,
        Blueprint<BlueprintArmyLeader, ArmyLeader.Reference>? armyLeader = null,
        bool? hasNoReward = null)
    {
      var element = ElementTool.Create<CreateGarrison>();
      element.Preset = army?.Reference;
      element.Location = location?.Reference;
      element.ArmyLeader = armyLeader?.Reference ?? element.ArmyLeader;
      element.WithLeader = armyLeader is not null;
      if (element.ArmyLeader is null)
      {
        element.ArmyLeader = BlueprintTool.GetRef<ArmyLeader.Reference>(null);
      }
      element.HasNoReward = hasNoReward ?? element.HasNoReward;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="FakeSkipTime"/>
    /// </summary>
    public static ActionsBuilder FakeSkipTime(
        this ActionsBuilder builder,
        GlobalMagicValue skipDays)
    {
      var element = ElementTool.Create<FakeSkipTime>();
      builder.Validate(skipDays);
      element.m_SkipDays = skipDays;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GainDiceArmyDamage"/>
    /// </summary>
    public static ActionsBuilder GainDiceArmyDamage(
        this ActionsBuilder builder,
        GlobalMagicValue diceValue,
        SquadFilter filter)
    {
      var element = ElementTool.Create<GainDiceArmyDamage>();
      builder.Validate(diceValue);
      element.m_DiceValue = diceValue;
      builder.Validate(filter);
      element.m_Filter = filter;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GainGlobalMagicSpell"/>
    /// </summary>
    ///
    /// <param name="spell">
    /// Blueprint of type BlueprintGlobalMagicSpell. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder GainGlobalMagicSpell(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMagicSpell, BlueprintGlobalMagicSpell.Reference> spell)
    {
      var element = ElementTool.Create<GainGlobalMagicSpell>();
      element.m_Spell = spell?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionActivateEventDeck"/>
    /// </summary>
    ///
    /// <param name="deck">
    /// Blueprint of type BlueprintKingdomDeck. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionActivateEventDeck(
        this ActionsBuilder builder,
        Blueprint<BlueprintKingdomDeck, BlueprintKingdomDeckReference> deck)
    {
      var element = ElementTool.Create<KingdomActionActivateEventDeck>();
      element.m_Deck = deck?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionAddBPRandom"/>
    /// </summary>
    public static ActionsBuilder KingdomActionAddBPRandom(
        this ActionsBuilder builder,
        KingdomResource resourceType,
        int? bonus = null,
        DiceFormula? change = null,
        bool? includeInEventStats = null)
    {
      var element = ElementTool.Create<KingdomActionAddBPRandom>();
      element.ResourceType = resourceType;
      element.Bonus = bonus ?? element.Bonus;
      element.Change = change ?? element.Change;
      element.IncludeInEventStats = includeInEventStats ?? element.IncludeInEventStats;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionAddBuff"/>
    /// </summary>
    ///
    /// <param name="buff">
    /// Blueprint of type BlueprintKingdomBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="region">
    /// Blueprint of type BlueprintRegion. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionAddBuff(
        this ActionsBuilder builder,
        Blueprint<BlueprintKingdomBuff, BlueprintKingdomBuffReference> buff,
        bool? applyToRegion = null,
        bool? copyToAdjacentRegions = null,
        int? overrideDuration = null,
        Blueprint<BlueprintRegion, BlueprintRegionReference>? region = null)
    {
      var element = ElementTool.Create<KingdomActionAddBuff>();
      element.m_Blueprint = buff?.Reference;
      element.ApplyToRegion = applyToRegion ?? element.ApplyToRegion;
      element.CopyToAdjacentRegions = copyToAdjacentRegions ?? element.CopyToAdjacentRegions;
      element.OverrideDuration = overrideDuration ?? element.OverrideDuration;
      element.m_Region = region?.Reference ?? element.m_Region;
      if (element.m_Region is null)
      {
        element.m_Region = BlueprintTool.GetRef<BlueprintRegionReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionAddFreeBuilding"/>
    /// </summary>
    ///
    /// <param name="building">
    /// Blueprint of type BlueprintSettlementBuilding. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AddFreeBuilding(
        this ActionsBuilder builder,
        Blueprint<BlueprintSettlementBuilding, BlueprintSettlementBuildingReference> building,
        int? count = null)
    {
      var element = ElementTool.Create<KingdomActionAddFreeBuilding>();
      element.m_Building = building?.Reference;
      element.Count = count ?? element.Count;
      element.Anywhere = true;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionAddFreeBuilding"/>
    /// </summary>
    ///
    /// <param name="building">
    /// Blueprint of type BlueprintSettlementBuilding. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="settlement">
    /// Blueprint of type BlueprintSettlement. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AddFreeBuildingToSettlement(
        this ActionsBuilder builder,
        Blueprint<BlueprintSettlementBuilding, BlueprintSettlementBuildingReference> building,
        Blueprint<BlueprintSettlement, BlueprintSettlement.Reference> settlement,
        int? count = null)
    {
      var element = ElementTool.Create<KingdomActionAddFreeBuilding>();
      element.m_Building = building?.Reference;
      element.m_Settlement = settlement?.Reference;
      element.Count = count ?? element.Count;
      element.Anywhere = false;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionAddRandomBuff"/>
    /// </summary>
    ///
    /// <param name="buffs">
    /// Blueprint of type BlueprintKingdomBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionAddRandomBuff(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintKingdomBuff, BlueprintKingdomBuffReference>>? buffs = null,
        int? overrideDurationDays = null)
    {
      var element = ElementTool.Create<KingdomActionAddRandomBuff>();
      element.m_Buffs = buffs?.Select(bp => bp.Reference)?.ToList() ?? element.m_Buffs;
      if (element.m_Buffs is null)
      {
        element.m_Buffs = new();
      }
      element.OverrideDurationDays = overrideDurationDays ?? element.OverrideDurationDays;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionArtisanRequestHelp"/>
    /// </summary>
    ///
    /// <param name="artisan">
    /// Blueprint of type BlueprintKingdomArtisan. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="project">
    /// Blueprint of type BlueprintKingdomProject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionArtisanRequestHelp(
        this ActionsBuilder builder,
        Blueprint<BlueprintKingdomArtisan, BlueprintKingdomArtisanReference> artisan,
        Blueprint<BlueprintKingdomProject, BlueprintKingdomProjectReference> project)
    {
      var element = ElementTool.Create<KingdomActionArtisanRequestHelp>();
      element.m_Artisan = artisan?.Reference;
      element.m_Project = project?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionConquerRegion"/>
    /// </summary>
    ///
    /// <param name="region">
    /// Blueprint of type BlueprintRegion. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionConquerRegion(
        this ActionsBuilder builder,
        Blueprint<BlueprintRegion, BlueprintRegionReference> region)
    {
      var element = ElementTool.Create<KingdomActionConquerRegion>();
      element.m_Region = region?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionFillSettlement"/>
    /// </summary>
    ///
    /// <param name="buildList">
    /// Blueprint of type SettlementBuildList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="specificSettlement">
    /// Blueprint of type BlueprintSettlement. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionFillSettlement(
        this ActionsBuilder builder,
        Blueprint<SettlementBuildList, SettlementBuildListReference> buildList,
        Blueprint<BlueprintSettlement, BlueprintSettlement.Reference> specificSettlement)
    {
      var element = ElementTool.Create<KingdomActionFillSettlement>();
      element.m_BuildList = buildList?.Reference;
      element.m_SpecificSettlement = specificSettlement?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionFillSettlementByLocation"/>
    /// </summary>
    ///
    /// <param name="buildList">
    /// Blueprint of type SettlementBuildList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="specificSettlementLocation">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionFillSettlementByLocation(
        this ActionsBuilder builder,
        Blueprint<SettlementBuildList, SettlementBuildListReference> buildList,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPointReference> specificSettlementLocation)
    {
      var element = ElementTool.Create<KingdomActionFillSettlementByLocation>();
      element.m_BuildList = buildList?.Reference;
      element.m_SpecificSettlementLocation = specificSettlementLocation?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionFoundSettlement"/>
    /// </summary>
    ///
    /// <param name="location">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="settlement">
    /// Blueprint of type BlueprintSettlement. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionFoundSettlement(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference> location,
        Blueprint<BlueprintSettlement, BlueprintSettlement.Reference> settlement)
    {
      var element = ElementTool.Create<KingdomActionFoundSettlement>();
      element.m_Location = location?.Reference;
      element.m_Settlement = settlement?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionGainLeaderExperience"/>
    /// </summary>
    public static ActionsBuilder KingdomActionGainLeaderExperience(
        this ActionsBuilder builder,
        IntEvaluator value,
        float? multiplierCoefficient = null)
    {
      var element = ElementTool.Create<KingdomActionGainLeaderExperience>();
      builder.Validate(value);
      element.m_Value = value;
      element.m_MultiplierCoefficient = multiplierCoefficient ?? element.m_MultiplierCoefficient;
      element.m_MultiplyByLeaderLevel = multiplierCoefficient is not null;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ManuallySetGlobalSpellCooldown"/>
    /// </summary>
    ///
    /// <param name="spell">
    /// Blueprint of type BlueprintGlobalMagicSpell. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ManuallySetGlobalSpellCooldown(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMagicSpell, BlueprintGlobalMagicSpell.Reference> spell)
    {
      var element = ElementTool.Create<ManuallySetGlobalSpellCooldown>();
      element.m_Spell = spell?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="OpenTeleportationInterface"/>
    /// </summary>
    public static ActionsBuilder OpenTeleportationInterface(
        this ActionsBuilder builder,
        ActionsBuilder onTeleportActions)
    {
      var element = ElementTool.Create<OpenTeleportationInterface>();
      element.m_OnTeleportActions = onTeleportActions?.Build();
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveGlobalMagicSpell"/>
    /// </summary>
    ///
    /// <param name="spell">
    /// Blueprint of type BlueprintGlobalMagicSpell. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RemoveGlobalMagicSpell(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMagicSpell, BlueprintGlobalMagicSpell.Reference> spell)
    {
      var element = ElementTool.Create<RemoveGlobalMagicSpell>();
      element.m_Spell = spell?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveUnitsByExp"/>
    /// </summary>
    public static ActionsBuilder RemoveUnitsByExp(
        this ActionsBuilder builder,
        GlobalMagicValue expValue,
        SquadFilter filter)
    {
      var element = ElementTool.Create<RemoveUnitsByExp>();
      builder.Validate(expValue);
      element.m_ExpValue = expValue;
      builder.Validate(filter);
      element.m_Filter = filter;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RepairLeaderMana"/>
    /// </summary>
    public static ActionsBuilder RepairLeaderMana(
        this ActionsBuilder builder,
        GlobalMagicValue value)
    {
      var element = ElementTool.Create<RepairLeaderMana>();
      builder.Validate(value);
      element.m_Value = value;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SummonExistUnits"/>
    /// </summary>
    public static ActionsBuilder SummonExistUnits(
        this ActionsBuilder builder,
        GlobalMagicValue sumExpCost)
    {
      var element = ElementTool.Create<SummonExistUnits>();
      builder.Validate(sumExpCost);
      element.m_SumExpCost = sumExpCost;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SummonRandomGroup"/>
    /// </summary>
    public static ActionsBuilder SummonRandomGroup(
        this ActionsBuilder builder,
        SummonRandomGroup.RandomGroup[] randomGroups)
    {
      var element = ElementTool.Create<SummonRandomGroup>();
      foreach (var item in randomGroups) { builder.Validate(item); }
      element.m_RandomGroups = randomGroups;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddGrowthBonus"/>
    /// </summary>
    public static ActionsBuilder AddGrowthBonus(
        this ActionsBuilder builder,
        int? bonus = null)
    {
      var element = ElementTool.Create<AddGrowthBonus>();
      element.Bonus = bonus ?? element.Bonus;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddMercenaryToPool"/>
    /// </summary>
    ///
    /// <param name="unit">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AddMercenaryToPool(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? unit = null,
        float? weight = null)
    {
      var element = ElementTool.Create<AddMercenaryToPool>();
      element.m_Unit = unit?.Reference ?? element.m_Unit;
      if (element.m_Unit is null)
      {
        element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      element.m_Weight = weight ?? element.m_Weight;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddTacticalArmyFeature"/>
    /// </summary>
    ///
    /// <param name="armyUnits">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="features">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AddTacticalArmyFeature(
        this ActionsBuilder builder,
        ArmyProperties? armyTag = null,
        List<Blueprint<BlueprintUnit, BlueprintUnitReference>>? armyUnits = null,
        bool? byTag = null,
        bool? byUnits = null,
        ArmyFaction? faction = null,
        List<Blueprint<BlueprintFeature, BlueprintFeatureReference>>? features = null,
        MercenariesIncludeOption? mercenariesFilter = null)
    {
      var element = ElementTool.Create<AddTacticalArmyFeature>();
      element.m_ArmyTag = armyTag ?? element.m_ArmyTag;
      element.m_ArmyUnits = armyUnits?.Select(bp => bp.Reference)?.ToArray() ?? element.m_ArmyUnits;
      if (element.m_ArmyUnits is null)
      {
        element.m_ArmyUnits = new BlueprintUnitReference[0];
      }
      element.m_ByTag = byTag ?? element.m_ByTag;
      element.m_ByUnits = byUnits ?? element.m_ByUnits;
      element.m_Faction = faction ?? element.m_Faction;
      element.m_Features = features?.Select(bp => bp.Reference)?.ToArray() ?? element.m_Features;
      if (element.m_Features is null)
      {
        element.m_Features = new BlueprintFeatureReference[0];
      }
      element.m_MercenariesFilter = mercenariesFilter ?? element.m_MercenariesFilter;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ArmyAdditionalAction"/>
    /// </summary>
    public static ActionsBuilder ArmyAdditionalAction(
        this ActionsBuilder builder,
        bool? canAddInBonusMoraleTurn = null,
        bool? inCurrentTurn = null)
    {
      var element = ElementTool.Create<ArmyAdditionalAction>();
      element.m_CanAddInBonusMoraleTurn = canAddInBonusMoraleTurn ?? element.m_CanAddInBonusMoraleTurn;
      element.m_InCurrentTurn = inCurrentTurn ?? element.m_InCurrentTurn;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="BlockTacticalCell"/>
    /// </summary>
    public static ActionsBuilder BlockTacticalCell(
        this ActionsBuilder builder,
        TacticalMapObstacle.Link? obstaclePrefab = null)
    {
      var element = ElementTool.Create<BlockTacticalCell>();
      builder.Validate(obstaclePrefab);
      element.m_ObstaclePrefab = obstaclePrefab ?? element.m_ObstaclePrefab;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangeKingdomMoraleMaximum"/>
    /// </summary>
    public static ActionsBuilder ChangeKingdomMoraleMaximum(
        this ActionsBuilder builder,
        int? maxValueDelta = null)
    {
      var element = ElementTool.Create<ChangeKingdomMoraleMaximum>();
      element.m_MaxValueDelta = maxValueDelta ?? element.m_MaxValueDelta;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangeMercenaryWeight"/>
    /// </summary>
    ///
    /// <param name="unit">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ChangeMercenaryWeight(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? unit = null,
        float? weight = null)
    {
      var element = ElementTool.Create<ChangeMercenaryWeight>();
      element.m_Unit = unit?.Reference ?? element.m_Unit;
      if (element.m_Unit is null)
      {
        element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      element.m_Weight = weight ?? element.m_Weight;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRestoreLeaderAction"/>
    /// </summary>
    public static ActionsBuilder RestoreLeaderAction(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionRestoreLeaderAction>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionStopUnit"/>
    /// </summary>
    public static ActionsBuilder StopUnit(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionStopUnit>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionTacticalCombatHealTarget"/>
    /// </summary>
    public static ActionsBuilder TacticalCombatHealTarget(
        this ActionsBuilder builder,
        DiceType? diceType = null,
        ContextValue? rollsCount = null)
    {
      var element = ElementTool.Create<ContextActionTacticalCombatHealTarget>();
      element.DiceType = diceType ?? element.DiceType;
      element.RollsCount = rollsCount ?? element.RollsCount;
      if (element.RollsCount is null)
      {
        element.RollsCount = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DecreaseRecruitsGrowth"/>
    /// </summary>
    ///
    /// <param name="unit">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder DecreaseRecruitsGrowth(
        this ActionsBuilder builder,
        int? count = null,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? unit = null)
    {
      var element = ElementTool.Create<DecreaseRecruitsGrowth>();
      element.Count = count ?? element.Count;
      element.m_Unit = unit?.Reference ?? element.m_Unit;
      if (element.m_Unit is null)
      {
        element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DecreaseRecruitsPool"/>
    /// </summary>
    ///
    /// <param name="unit">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder DecreaseRecruitsPool(
        this ActionsBuilder builder,
        int? count = null,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? unit = null)
    {
      var element = ElementTool.Create<DecreaseRecruitsPool>();
      element.Count = count ?? element.Count;
      element.m_Unit = unit?.Reference ?? element.m_Unit;
      if (element.m_Unit is null)
      {
        element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="EnterKingdomInterface"/>
    /// </summary>
    ///
    /// <param name="returnPoint">
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder EnterKingdomInterface(
        this ActionsBuilder builder,
        Blueprint<BlueprintAreaEnterPoint, BlueprintAreaEnterPointReference>? returnPoint = null,
        ActionsBuilder? triggerAfterAuto = null)
    {
      var element = ElementTool.Create<EnterKingdomInterface>();
      element.m_ReturnPoint = returnPoint?.Reference ?? element.m_ReturnPoint;
      if (element.m_ReturnPoint is null)
      {
        element.m_ReturnPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(null);
      }
      element.TriggerAfterAuto = triggerAfterAuto?.Build() ?? element.TriggerAfterAuto;
      if (element.TriggerAfterAuto is null)
      {
        element.TriggerAfterAuto = Utils.Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ExchangeRecruits"/>
    /// </summary>
    ///
    /// <param name="newUnit">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="oldUnit">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ExchangeRecruits(
        this ActionsBuilder builder,
        float? convertCoefficient = null,
        int? newGrowth = null,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? newUnit = null,
        int? oldGrowth = null,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? oldUnit = null)
    {
      var element = ElementTool.Create<ExchangeRecruits>();
      element.ConvertCoefficient = convertCoefficient ?? element.ConvertCoefficient;
      element.NewGrowth = newGrowth ?? element.NewGrowth;
      element.m_NewUnit = newUnit?.Reference ?? element.m_NewUnit;
      if (element.m_NewUnit is null)
      {
        element.m_NewUnit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      element.OldGrowth = oldGrowth ?? element.OldGrowth;
      element.m_OldUnit = oldUnit?.Reference ?? element.m_OldUnit;
      if (element.m_OldUnit is null)
      {
        element.m_OldUnit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IncreaseRecruitsGrowth"/>
    /// </summary>
    ///
    /// <param name="unit">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder IncreaseRecruitsGrowth(
        this ActionsBuilder builder,
        int? count = null,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? unit = null)
    {
      var element = ElementTool.Create<IncreaseRecruitsGrowth>();
      element.Count = count ?? element.Count;
      element.m_Unit = unit?.Reference ?? element.m_Unit;
      if (element.m_Unit is null)
      {
        element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IncreaseRecruitsPool"/>
    /// </summary>
    ///
    /// <param name="unit">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder IncreaseRecruitsPool(
        this ActionsBuilder builder,
        int? count = null,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? unit = null)
    {
      var element = ElementTool.Create<IncreaseRecruitsPool>();
      element.Count = count ?? element.Count;
      element.m_Unit = unit?.Reference ?? element.m_Unit;
      if (element.m_Unit is null)
      {
        element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionAddMercenaryReroll"/>
    /// </summary>
    public static ActionsBuilder KingdomActionAddMercenaryReroll(
        this ActionsBuilder builder,
        int? freeRerollsToAdd = null)
    {
      var element = ElementTool.Create<KingdomActionAddMercenaryReroll>();
      element.m_FreeRerollsToAdd = freeRerollsToAdd ?? element.m_FreeRerollsToAdd;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionChangeToAutoCrusade"/>
    /// </summary>
    public static ActionsBuilder KingdomActionChangeToAutoCrusade(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionChangeToAutoCrusade>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionCollectLoot"/>
    /// </summary>
    public static ActionsBuilder KingdomActionCollectLoot(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionCollectLoot>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionDestroyAllSettlements"/>
    /// </summary>
    public static ActionsBuilder KingdomActionDestroyAllSettlements(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionDestroyAllSettlements>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionDisable"/>
    /// </summary>
    public static ActionsBuilder KingdomActionDisable(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionDisable>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionEnable"/>
    /// </summary>
    public static ActionsBuilder KingdomActionEnable(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionEnable>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionFinishRandomBuilding"/>
    /// </summary>
    public static ActionsBuilder KingdomActionFinishRandomBuilding(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionFinishRandomBuilding>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionFoundKingdom"/>
    /// </summary>
    public static ActionsBuilder KingdomActionFoundKingdom(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionFoundKingdom>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionGetArtisanGift"/>
    /// </summary>
    ///
    /// <param name="artisan">
    /// Blueprint of type BlueprintKingdomArtisan. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionGetArtisanGift(
        this ActionsBuilder builder,
        Blueprint<BlueprintKingdomArtisan, BlueprintKingdomArtisanReference>? artisan = null)
    {
      var element = ElementTool.Create<KingdomActionGetArtisanGift>();
      element.m_Artisan = artisan?.Reference ?? element.m_Artisan;
      if (element.m_Artisan is null)
      {
        element.m_Artisan = BlueprintTool.GetRef<BlueprintKingdomArtisanReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionGetArtisanGiftWithCertainTier"/>
    /// </summary>
    ///
    /// <param name="artisan">
    /// Blueprint of type BlueprintKingdomArtisan. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionGetArtisanGiftWithCertainTier(
        this ActionsBuilder builder,
        Blueprint<BlueprintKingdomArtisan, BlueprintKingdomArtisanReference>? artisan = null,
        int? tier = null)
    {
      var element = ElementTool.Create<KingdomActionGetArtisanGiftWithCertainTier>();
      element.m_Artisan = artisan?.Reference ?? element.m_Artisan;
      if (element.m_Artisan is null)
      {
        element.m_Artisan = BlueprintTool.GetRef<BlueprintKingdomArtisanReference>(null);
      }
      element.tier = tier ?? element.tier;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionGetPartyGoldByUnitsCount"/>
    /// </summary>
    public static ActionsBuilder KingdomActionGetPartyGoldByUnitsCount(
        this ActionsBuilder builder,
        float? coefficient = null,
        int? goldPerUnit = null)
    {
      var element = ElementTool.Create<KingdomActionGetPartyGoldByUnitsCount>();
      element.m_Coefficient = coefficient ?? element.m_Coefficient;
      element.m_GoldPerUnit = goldPerUnit ?? element.m_GoldPerUnit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionGetResourcesByUnitsCount"/>
    /// </summary>
    public static ActionsBuilder KingdomActionGetResourcesByUnitsCount(
        this ActionsBuilder builder,
        float? coefficient = null,
        KingdomResourcesAmount? resourcePerUnit = null)
    {
      var element = ElementTool.Create<KingdomActionGetResourcesByUnitsCount>();
      element.m_Coefficient = coefficient ?? element.m_Coefficient;
      element.m_ResourcePerUnit = resourcePerUnit ?? element.m_ResourcePerUnit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionGetResourcesPercent"/>
    /// </summary>
    public static ActionsBuilder KingdomActionGetResourcesPercent(
        this ActionsBuilder builder,
        int? maxResourceCountGained = null,
        float? percent = null,
        KingdomResource? resourceType = null)
    {
      var element = ElementTool.Create<KingdomActionGetResourcesPercent>();
      element.m_MaxResourceCountGained = maxResourceCountGained ?? element.m_MaxResourceCountGained;
      element.m_Percent = percent ?? element.m_Percent;
      element.m_ResourceType = resourceType ?? element.m_ResourceType;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionGiveLoot"/>
    /// </summary>
    public static ActionsBuilder KingdomActionGiveLoot(
        this ActionsBuilder builder,
        LootEntry[]? loot = null)
    {
      var element = ElementTool.Create<KingdomActionGiveLoot>();
      foreach (var item in loot) { builder.Validate(item); }
      element.Loot = loot ?? element.Loot;
      if (element.Loot is null)
      {
        element.Loot = new LootEntry[0];
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionImproveSettlement"/>
    /// </summary>
    ///
    /// <param name="specificSettlement">
    /// Blueprint of type BlueprintSettlement. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionImproveSettlement(
        this ActionsBuilder builder,
        Blueprint<BlueprintSettlement, BlueprintSettlement.Reference>? specificSettlement = null,
        SettlementState.LevelType? toLevel = null)
    {
      var element = ElementTool.Create<KingdomActionImproveSettlement>();
      element.m_SpecificSettlement = specificSettlement?.Reference ?? element.m_SpecificSettlement;
      if (element.m_SpecificSettlement is null)
      {
        element.m_SpecificSettlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(null);
      }
      element.ToLevel = toLevel ?? element.ToLevel;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionImproveStat"/>
    /// </summary>
    public static ActionsBuilder KingdomActionImproveStat(
        this ActionsBuilder builder,
        KingdomStats.Type? statType = null)
    {
      var element = ElementTool.Create<KingdomActionImproveStat>();
      element.StatType = statType ?? element.StatType;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionMakeRoll"/>
    /// </summary>
    public static ActionsBuilder KingdomActionMakeRoll(
        this ActionsBuilder builder,
        int? dC = null,
        ActionsBuilder? onFailure = null,
        ActionsBuilder? onSuccess = null,
        KingdomStats.Type? stat = null)
    {
      var element = ElementTool.Create<KingdomActionMakeRoll>();
      element.DC = dC ?? element.DC;
      element.OnFailure = onFailure?.Build() ?? element.OnFailure;
      if (element.OnFailure is null)
      {
        element.OnFailure = Utils.Constants.Empty.Actions;
      }
      element.OnSuccess = onSuccess?.Build() ?? element.OnSuccess;
      if (element.OnSuccess is null)
      {
        element.OnSuccess = Utils.Constants.Empty.Actions;
      }
      element.Stat = stat ?? element.Stat;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionModifyBuildTime"/>
    /// </summary>
    public static ActionsBuilder KingdomActionModifyBuildTime(
        this ActionsBuilder builder,
        float? changeTime = null)
    {
      var element = ElementTool.Create<KingdomActionModifyBuildTime>();
      element.ChangeTime = changeTime ?? element.ChangeTime;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionModifyClaims"/>
    /// </summary>
    public static ActionsBuilder KingdomActionModifyClaims(
        this ActionsBuilder builder,
        float? changeCost = null,
        float? changeTime = null)
    {
      var element = ElementTool.Create<KingdomActionModifyClaims>();
      element.ChangeCost = changeCost ?? element.ChangeCost;
      element.ChangeTime = changeTime ?? element.ChangeTime;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionModifyEventDC"/>
    /// </summary>
    public static ActionsBuilder KingdomActionModifyEventDC(
        this ActionsBuilder builder,
        int? modifier = null)
    {
      var element = ElementTool.Create<KingdomActionModifyEventDC>();
      element.Modifier = modifier ?? element.Modifier;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionModifyRE"/>
    /// </summary>
    public static ActionsBuilder KingdomActionModifyRE(
        this ActionsBuilder builder,
        float? claimedChange = null,
        float? unclaimedChange = null,
        float? upgradedChange = null)
    {
      var element = ElementTool.Create<KingdomActionModifyRE>();
      element.ClaimedChange = claimedChange ?? element.ClaimedChange;
      element.UnclaimedChange = unclaimedChange ?? element.UnclaimedChange;
      element.UpgradedChange = upgradedChange ?? element.UpgradedChange;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionModifyRankTime"/>
    /// </summary>
    public static ActionsBuilder KingdomActionModifyRankTime(
        this ActionsBuilder builder,
        float? changeTime = null)
    {
      var element = ElementTool.Create<KingdomActionModifyRankTime>();
      element.ChangeTime = changeTime ?? element.ChangeTime;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionModifyStatRandom"/>
    /// </summary>
    public static ActionsBuilder KingdomActionModifyStatRandom(
        this ActionsBuilder builder,
        DiceFormula? change = null,
        bool? includeInEventStats = null)
    {
      var element = ElementTool.Create<KingdomActionModifyStatRandom>();
      element.Change = change ?? element.Change;
      element.IncludeInEventStats = includeInEventStats ?? element.IncludeInEventStats;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionModifyStats"/>
    /// </summary>
    public static ActionsBuilder KingdomActionModifyStats(
        this ActionsBuilder builder,
        KingdomStats.Changes? changes = null,
        bool? includeInEventStats = null)
    {
      var element = ElementTool.Create<KingdomActionModifyStats>();
      builder.Validate(changes);
      element.Changes = changes ?? element.Changes;
      element.IncludeInEventStats = includeInEventStats ?? element.IncludeInEventStats;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionModifyUnrest"/>
    /// </summary>
    public static ActionsBuilder KingdomActionModifyUnrest(
        this ActionsBuilder builder,
        bool? bounded = null,
        bool? makeBetter = null,
        KingdomStatusChangeReason? reason = null,
        SharedStringAsset? reasonString = null,
        KingdomStatusType? upTo = null)
    {
      var element = ElementTool.Create<KingdomActionModifyUnrest>();
      element.Bounded = bounded ?? element.Bounded;
      element.MakeBetter = makeBetter ?? element.MakeBetter;
      element.Reason = reason ?? element.Reason;
      builder.Validate(reasonString);
      element.ReasonString = reasonString ?? element.ReasonString;
      element.UpTo = upTo ?? element.UpTo;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionNextChapter"/>
    /// </summary>
    public static ActionsBuilder KingdomActionNextChapter(
        this ActionsBuilder builder,
        int? chapterNumber = null)
    {
      var element = ElementTool.Create<KingdomActionNextChapter>();
      element.ChapterNumber = chapterNumber ?? element.ChapterNumber;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionPullRankupChangesIntoDialog"/>
    /// </summary>
    public static ActionsBuilder KingdomActionPullRankupChangesIntoDialog(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionPullRankupChangesIntoDialog>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionRemoveAllLeaders"/>
    /// </summary>
    public static ActionsBuilder KingdomActionRemoveAllLeaders(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionRemoveAllLeaders>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionRemoveBuff"/>
    /// </summary>
    ///
    /// <param name="blueprint">
    /// Blueprint of type BlueprintKingdomBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="region">
    /// Blueprint of type BlueprintRegion. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionRemoveBuff(
        this ActionsBuilder builder,
        bool? allBuffs = null,
        bool? applyToRegion = null,
        Blueprint<BlueprintKingdomBuff, BlueprintKingdomBuffReference>? blueprint = null,
        Blueprint<BlueprintRegion, BlueprintRegionReference>? region = null)
    {
      var element = ElementTool.Create<KingdomActionRemoveBuff>();
      element.m_AllBuffs = allBuffs ?? element.m_AllBuffs;
      element.ApplyToRegion = applyToRegion ?? element.ApplyToRegion;
      element.m_Blueprint = blueprint?.Reference ?? element.m_Blueprint;
      if (element.m_Blueprint is null)
      {
        element.m_Blueprint = BlueprintTool.GetRef<BlueprintKingdomBuffReference>(null);
      }
      element.m_Region = region?.Reference ?? element.m_Region;
      if (element.m_Region is null)
      {
        element.m_Region = BlueprintTool.GetRef<BlueprintRegionReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionRemoveEvent"/>
    /// </summary>
    ///
    /// <param name="eventBlueprint">
    /// Blueprint of type BlueprintKingdomEventBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionRemoveEvent(
        this ActionsBuilder builder,
        bool? allIfMultiple = null,
        bool? cancelIfInProgress = null,
        Blueprint<BlueprintKingdomEventBase, BlueprintKingdomEventBaseReference>? eventBlueprint = null)
    {
      var element = ElementTool.Create<KingdomActionRemoveEvent>();
      element.AllIfMultiple = allIfMultiple ?? element.AllIfMultiple;
      element.CancelIfInProgress = cancelIfInProgress ?? element.CancelIfInProgress;
      element.m_EventBlueprint = eventBlueprint?.Reference ?? element.m_EventBlueprint;
      if (element.m_EventBlueprint is null)
      {
        element.m_EventBlueprint = BlueprintTool.GetRef<BlueprintKingdomEventBaseReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionRemoveEventDeck"/>
    /// </summary>
    ///
    /// <param name="deck">
    /// Blueprint of type BlueprintKingdomDeck. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionRemoveEventDeck(
        this ActionsBuilder builder,
        Blueprint<BlueprintKingdomDeck, BlueprintKingdomDeckReference>? deck = null)
    {
      var element = ElementTool.Create<KingdomActionRemoveEventDeck>();
      element.m_Deck = deck?.Reference ?? element.m_Deck;
      if (element.m_Deck is null)
      {
        element.m_Deck = BlueprintTool.GetRef<BlueprintKingdomDeckReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionRequestArtisanGift"/>
    /// </summary>
    ///
    /// <param name="artisan">
    /// Blueprint of type BlueprintKingdomArtisan. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="itemType">
    /// Blueprint of type ArtisanItemDeck. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionRequestArtisanGift(
        this ActionsBuilder builder,
        Blueprint<BlueprintKingdomArtisan, BlueprintKingdomArtisanReference>? artisan = null,
        Blueprint<ArtisanItemDeck, ArtisanItemDeckReference>? itemType = null)
    {
      var element = ElementTool.Create<KingdomActionRequestArtisanGift>();
      element.m_Artisan = artisan?.Reference ?? element.m_Artisan;
      if (element.m_Artisan is null)
      {
        element.m_Artisan = BlueprintTool.GetRef<BlueprintKingdomArtisanReference>(null);
      }
      element.m_ItemType = itemType?.Reference ?? element.m_ItemType;
      if (element.m_ItemType is null)
      {
        element.m_ItemType = BlueprintTool.GetRef<ArtisanItemDeckReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionResetRecurrence"/>
    /// </summary>
    public static ActionsBuilder KingdomActionResetRecurrence(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionResetRecurrence>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionResolveCrusadeEvent"/>
    /// </summary>
    ///
    /// <param name="eventBlueprint">
    /// Blueprint of type BlueprintCrusadeEvent. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionResolveCrusadeEvent(
        this ActionsBuilder builder,
        Blueprint<BlueprintCrusadeEvent, BlueprintCrusadeEvent.Reference>? eventBlueprint = null,
        int? solutionIndex = null)
    {
      var element = ElementTool.Create<KingdomActionResolveCrusadeEvent>();
      element.m_EventBlueprint = eventBlueprint?.Reference ?? element.m_EventBlueprint;
      if (element.m_EventBlueprint is null)
      {
        element.m_EventBlueprint = BlueprintTool.GetRef<BlueprintCrusadeEvent.Reference>(null);
      }
      element.m_SolutionIndex = solutionIndex ?? element.m_SolutionIndex;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionResolveEvent"/>
    /// </summary>
    ///
    /// <param name="eventBlueprint">
    /// Blueprint of type BlueprintKingdomEvent. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionResolveEvent(
        this ActionsBuilder builder,
        Alignment? alignment = null,
        Blueprint<BlueprintKingdomEvent, BlueprintKingdomEventReference>? eventBlueprint = null,
        bool? finalResolve = null,
        EventResult.MarginType? result = null)
    {
      var element = ElementTool.Create<KingdomActionResolveEvent>();
      element.Alignment = alignment ?? element.Alignment;
      element.m_EventBlueprint = eventBlueprint?.Reference ?? element.m_EventBlueprint;
      if (element.m_EventBlueprint is null)
      {
        element.m_EventBlueprint = BlueprintTool.GetRef<BlueprintKingdomEventReference>(null);
      }
      element.FinalResolve = finalResolve ?? element.FinalResolve;
      element.Result = result ?? element.Result;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionResolveProject"/>
    /// </summary>
    ///
    /// <param name="eventBlueprint">
    /// Blueprint of type BlueprintKingdomProject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionResolveProject(
        this ActionsBuilder builder,
        Blueprint<BlueprintKingdomProject, BlueprintKingdomProjectReference>? eventBlueprint = null)
    {
      var element = ElementTool.Create<KingdomActionResolveProject>();
      element.m_EventBlueprint = eventBlueprint?.Reference ?? element.m_EventBlueprint;
      if (element.m_EventBlueprint is null)
      {
        element.m_EventBlueprint = BlueprintTool.GetRef<BlueprintKingdomProjectReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionRestartEvent"/>
    /// </summary>
    public static ActionsBuilder KingdomActionRestartEvent(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionRestartEvent>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionRollbackRecurrence"/>
    /// </summary>
    public static ActionsBuilder KingdomActionRollbackRecurrence(
        this ActionsBuilder builder,
        bool? includeResources = null,
        bool? includeResourcesPerTurn = null,
        bool? includeStats = null,
        int? lastNDays = null,
        int? lastNTimes = null,
        float? resourcesRatio = null,
        KingdomActionRollbackRecurrence.RollbackType? type = null)
    {
      var element = ElementTool.Create<KingdomActionRollbackRecurrence>();
      element.m_IncludeResources = includeResources ?? element.m_IncludeResources;
      element.m_IncludeResourcesPerTurn = includeResourcesPerTurn ?? element.m_IncludeResourcesPerTurn;
      element.m_IncludeStats = includeStats ?? element.m_IncludeStats;
      element.m_LastNDays = lastNDays ?? element.m_LastNDays;
      element.m_LastNTimes = lastNTimes ?? element.m_LastNTimes;
      element.m_ResourcesRatio = resourcesRatio ?? element.m_ResourcesRatio;
      element.m_Type = type ?? element.m_Type;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionSetAlignment"/>
    /// </summary>
    public static ActionsBuilder KingdomActionSetAlignment(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionSetAlignment>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionSetNotVisible"/>
    /// </summary>
    public static ActionsBuilder KingdomActionSetNotVisible(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionSetNotVisible>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionSetRegionalIncome"/>
    /// </summary>
    public static ActionsBuilder KingdomActionSetRegionalIncome(
        this ActionsBuilder builder,
        bool? add = null,
        KingdomResourcesAmount? incomePerClaimed = null,
        KingdomResourcesAmount? incomePerUpgraded = null)
    {
      var element = ElementTool.Create<KingdomActionSetRegionalIncome>();
      element.Add = add ?? element.Add;
      element.IncomePerClaimed = incomePerClaimed ?? element.IncomePerClaimed;
      element.IncomePerUpgraded = incomePerUpgraded ?? element.IncomePerUpgraded;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionSetVisible"/>
    /// </summary>
    public static ActionsBuilder KingdomActionSetVisible(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionSetVisible>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionSpawnRandomArmy"/>
    /// </summary>
    ///
    /// <param name="armies">
    /// Blueprint of type BlueprintArmyPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="locations">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionSpawnRandomArmy(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintArmyPreset, BlueprintArmyPresetReference>>? armies = null,
        ArmyFaction? faction = null,
        List<Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>>? locations = null)
    {
      var element = ElementTool.Create<KingdomActionSpawnRandomArmy>();
      element.m_Armies = armies?.Select(bp => bp.Reference)?.ToList() ?? element.m_Armies;
      if (element.m_Armies is null)
      {
        element.m_Armies = new();
      }
      element.m_Faction = faction ?? element.m_Faction;
      element.m_Locations = locations?.Select(bp => bp.Reference)?.ToList() ?? element.m_Locations;
      if (element.m_Locations is null)
      {
        element.m_Locations = new();
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionStartEvent"/>
    /// </summary>
    ///
    /// <param name="eventValue">
    /// Blueprint of type BlueprintKingdomEventBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="region">
    /// Blueprint of type BlueprintRegion. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionStartEvent(
        this ActionsBuilder builder,
        bool? checkTriggerImmediately = null,
        bool? checkTriggerOnStart = null,
        int? delayDays = null,
        Blueprint<BlueprintKingdomEventBase, BlueprintKingdomEventBaseReference>? eventValue = null,
        bool? randomRegion = null,
        Blueprint<BlueprintRegion, BlueprintRegionReference>? region = null,
        bool? startNextMonth = null)
    {
      var element = ElementTool.Create<KingdomActionStartEvent>();
      element.CheckTriggerImmediately = checkTriggerImmediately ?? element.CheckTriggerImmediately;
      element.CheckTriggerOnStart = checkTriggerOnStart ?? element.CheckTriggerOnStart;
      element.DelayDays = delayDays ?? element.DelayDays;
      element.m_Event = eventValue?.Reference ?? element.m_Event;
      if (element.m_Event is null)
      {
        element.m_Event = BlueprintTool.GetRef<BlueprintKingdomEventBaseReference>(null);
      }
      element.RandomRegion = randomRegion ?? element.RandomRegion;
      element.m_Region = region?.Reference ?? element.m_Region;
      if (element.m_Region is null)
      {
        element.m_Region = BlueprintTool.GetRef<BlueprintRegionReference>(null);
      }
      element.StartNextMonth = startNextMonth ?? element.StartNextMonth;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionUnlockArtisan"/>
    /// </summary>
    ///
    /// <param name="artisan">
    /// Blueprint of type BlueprintKingdomArtisan. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionUnlockArtisan(
        this ActionsBuilder builder,
        Blueprint<BlueprintKingdomArtisan, BlueprintKingdomArtisanReference>? artisan = null)
    {
      var element = ElementTool.Create<KingdomActionUnlockArtisan>();
      element.m_Artisan = artisan?.Reference ?? element.m_Artisan;
      if (element.m_Artisan is null)
      {
        element.m_Artisan = BlueprintTool.GetRef<BlueprintKingdomArtisanReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomAddMoraleFlags"/>
    /// </summary>
    ///
    /// <param name="newFlags">
    /// Blueprint of type BlueprintKingdomMoraleFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomAddMoraleFlags(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintKingdomMoraleFlag, BlueprintKingdomMoraleFlag.Reference>>? newFlags = null)
    {
      var element = ElementTool.Create<KingdomAddMoraleFlags>();
      element.m_NewFlags = newFlags?.Select(bp => bp.Reference)?.ToArray() ?? element.m_NewFlags;
      if (element.m_NewFlags is null)
      {
        element.m_NewFlags = new BlueprintKingdomMoraleFlag.Reference[0];
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomFlagIncrement"/>
    /// </summary>
    ///
    /// <param name="targetFlag">
    /// Blueprint of type BlueprintKingdomMoraleFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomFlagIncrement(
        this ActionsBuilder builder,
        int? increment = null,
        Blueprint<BlueprintKingdomMoraleFlag, BlueprintKingdomMoraleFlag.Reference>? targetFlag = null)
    {
      var element = ElementTool.Create<KingdomFlagIncrement>();
      element.m_Increment = increment ?? element.m_Increment;
      element.m_TargetFlag = targetFlag?.Reference ?? element.m_TargetFlag;
      if (element.m_TargetFlag is null)
      {
        element.m_TargetFlag = BlueprintTool.GetRef<BlueprintKingdomMoraleFlag.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomIncreaseIncome"/>
    /// </summary>
    public static ActionsBuilder KingdomIncreaseIncome(
        this ActionsBuilder builder,
        int? bonus = null,
        KingdomResource? resourceType = null)
    {
      var element = ElementTool.Create<KingdomIncreaseIncome>();
      element.Bonus = bonus ?? element.Bonus;
      element.ResourceType = resourceType ?? element.ResourceType;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomMoraleFlagUpdateIncome"/>
    /// </summary>
    ///
    /// <param name="targetFlag">
    /// Blueprint of type BlueprintKingdomMoraleFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomMoraleFlagUpdateIncome(
        this ActionsBuilder builder,
        Blueprint<BlueprintKingdomMoraleFlag, BlueprintKingdomMoraleFlag.Reference>? targetFlag = null)
    {
      var element = ElementTool.Create<KingdomMoraleFlagUpdateIncome>();
      element.m_TargetFlag = targetFlag?.Reference ?? element.m_TargetFlag;
      if (element.m_TargetFlag is null)
      {
        element.m_TargetFlag = BlueprintTool.GetRef<BlueprintKingdomMoraleFlag.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomRemoveMoraleFlags"/>
    /// </summary>
    ///
    /// <param name="flagsToRemove">
    /// Blueprint of type BlueprintKingdomMoraleFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomRemoveMoraleFlags(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintKingdomMoraleFlag, BlueprintKingdomMoraleFlag.Reference>>? flagsToRemove = null)
    {
      var element = ElementTool.Create<KingdomRemoveMoraleFlags>();
      element.m_FlagsToRemove = flagsToRemove?.Select(bp => bp.Reference)?.ToArray() ?? element.m_FlagsToRemove;
      if (element.m_FlagsToRemove is null)
      {
        element.m_FlagsToRemove = new BlueprintKingdomMoraleFlag.Reference[0];
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomSetFlagState"/>
    /// </summary>
    ///
    /// <param name="targetFlag">
    /// Blueprint of type BlueprintKingdomMoraleFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomSetFlagState(
        this ActionsBuilder builder,
        int? maxDays = null,
        KingdomMoraleFlag.State? state = null,
        Blueprint<BlueprintKingdomMoraleFlag, BlueprintKingdomMoraleFlag.Reference>? targetFlag = null)
    {
      var element = ElementTool.Create<KingdomSetFlagState>();
      element.m_MaxDays = maxDays ?? element.m_MaxDays;
      element.m_State = state ?? element.m_State;
      element.m_TargetFlag = targetFlag?.Reference ?? element.m_TargetFlag;
      if (element.m_TargetFlag is null)
      {
        element.m_TargetFlag = BlueprintTool.GetRef<BlueprintKingdomMoraleFlag.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RecruiteArmyLeader"/>
    /// </summary>
    ///
    /// <param name="armyLeader">
    /// Blueprint of type BlueprintArmyLeader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RecruiteArmyLeader(
        this ActionsBuilder builder,
        Blueprint<BlueprintArmyLeader, ArmyLeader.Reference>? armyLeader = null)
    {
      var element = ElementTool.Create<RecruiteArmyLeader>();
      element.ArmyLeader = armyLeader?.Reference ?? element.ArmyLeader;
      if (element.ArmyLeader is null)
      {
        element.ArmyLeader = BlueprintTool.GetRef<ArmyLeader.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ReduceNegativeMorale"/>
    /// </summary>
    public static ActionsBuilder ReduceNegativeMorale(
        this ActionsBuilder builder,
        int? value = null)
    {
      var element = ElementTool.Create<ReduceNegativeMorale>();
      element.m_Value = value ?? element.m_Value;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveCrusadeResources"/>
    /// </summary>
    public static ActionsBuilder RemoveCrusadeResources(
        this ActionsBuilder builder,
        KingdomResourcesAmount? resourcesAmount = null)
    {
      var element = ElementTool.Create<RemoveCrusadeResources>();
      element.m_ResourcesAmount = resourcesAmount ?? element.m_ResourcesAmount;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveDemonArmies"/>
    /// </summary>
    ///
    /// <param name="armyPreset">
    /// Blueprint of type BlueprintArmyPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RemoveDemonArmies(
        this ActionsBuilder builder,
        Blueprint<BlueprintArmyPreset, BlueprintArmyPresetReference>? armyPreset = null,
        ArmyType? armyType = null)
    {
      var element = ElementTool.Create<RemoveDemonArmies>();
      element.m_ArmyPreset = armyPreset?.Reference ?? element.m_ArmyPreset;
      if (element.m_ArmyPreset is null)
      {
        element.m_ArmyPreset = BlueprintTool.GetRef<BlueprintArmyPresetReference>(null);
      }
      element.m_ArmyType = armyType ?? element.m_ArmyType;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveGarrison"/>
    /// </summary>
    ///
    /// <param name="location">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RemoveGarrison(
        this ActionsBuilder builder,
        bool? handleAsGarrisonDefeated = null,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>? location = null)
    {
      var element = ElementTool.Create<RemoveGarrison>();
      element.HandleAsGarrisonDefeated = handleAsGarrisonDefeated ?? element.HandleAsGarrisonDefeated;
      element.m_Location = location?.Reference ?? element.m_Location;
      if (element.m_Location is null)
      {
        element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveMercenaryFromPool"/>
    /// </summary>
    ///
    /// <param name="unit">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RemoveMercenaryFromPool(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? unit = null)
    {
      var element = ElementTool.Create<RemoveMercenaryFromPool>();
      element.m_Unit = unit?.Reference ?? element.m_Unit;
      if (element.m_Unit is null)
      {
        element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveUnitFromArmy"/>
    /// </summary>
    ///
    /// <param name="unitToRemove">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RemoveUnitFromArmy(
        this ActionsBuilder builder,
        ArmiesEvaluator? armies = null,
        int? experience = null,
        bool? limitUnitExperienceMaximum = null,
        bool? limitUnitExperienceMinimum = null,
        RemoveUnitFromArmy.RemoveUnitFromArmyMode? mode = null,
        float? percentage = null,
        bool? removeCheapestUnit = null,
        bool? removeSpecificUnit = null,
        int? unitExperienceMaximum = null,
        int? unitExperienceMinimum = null,
        UnitTag[]? unitTagBlacklist = null,
        UnitTag[]? unitTagWhitelist = null,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? unitToRemove = null)
    {
      var element = ElementTool.Create<RemoveUnitFromArmy>();
      builder.Validate(armies);
      element.m_Armies = armies ?? element.m_Armies;
      element.m_Experience = experience ?? element.m_Experience;
      element.m_LimitUnitExperienceMaximum = limitUnitExperienceMaximum ?? element.m_LimitUnitExperienceMaximum;
      element.m_LimitUnitExperienceMinimum = limitUnitExperienceMinimum ?? element.m_LimitUnitExperienceMinimum;
      element.m_Mode = mode ?? element.m_Mode;
      element.m_Percentage = percentage ?? element.m_Percentage;
      element.m_RemoveCheapestUnit = removeCheapestUnit ?? element.m_RemoveCheapestUnit;
      element.m_RemoveSpecificUnit = removeSpecificUnit ?? element.m_RemoveSpecificUnit;
      element.m_UnitExperienceMaximum = unitExperienceMaximum ?? element.m_UnitExperienceMaximum;
      element.m_UnitExperienceMinimum = unitExperienceMinimum ?? element.m_UnitExperienceMinimum;
      element.m_UnitTagBlacklist = unitTagBlacklist ?? element.m_UnitTagBlacklist;
      if (element.m_UnitTagBlacklist is null)
      {
        element.m_UnitTagBlacklist = new UnitTag[0];
      }
      element.m_UnitTagWhitelist = unitTagWhitelist ?? element.m_UnitTagWhitelist;
      if (element.m_UnitTagWhitelist is null)
      {
        element.m_UnitTagWhitelist = new UnitTag[0];
      }
      element.m_UnitToRemove = unitToRemove?.Reference ?? element.m_UnitToRemove;
      if (element.m_UnitToRemove is null)
      {
        element.m_UnitToRemove = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ReplaceBuildings"/>
    /// </summary>
    ///
    /// <param name="newBuilding">
    /// Blueprint of type BlueprintSettlementBuilding. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    /// <param name="oldBuilding">
    /// Blueprint of type BlueprintSettlementBuilding. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ReplaceBuildings(
        this ActionsBuilder builder,
        Blueprint<BlueprintSettlementBuilding, BlueprintSettlementBuildingReference>? newBuilding = null,
        Blueprint<BlueprintSettlementBuilding, BlueprintSettlementBuildingReference>? oldBuilding = null)
    {
      var element = ElementTool.Create<ReplaceBuildings>();
      element.m_NewBuilding = newBuilding?.Reference ?? element.m_NewBuilding;
      if (element.m_NewBuilding is null)
      {
        element.m_NewBuilding = BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(null);
      }
      element.m_OldBuilding = oldBuilding?.Reference ?? element.m_OldBuilding;
      if (element.m_OldBuilding is null)
      {
        element.m_OldBuilding = BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetRecruitPoint"/>
    /// </summary>
    ///
    /// <param name="point">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SetRecruitPoint(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>? point = null)
    {
      var element = ElementTool.Create<SetRecruitPoint>();
      element.m_Point = point?.Reference ?? element.m_Point;
      if (element.m_Point is null)
      {
        element.m_Point = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetWarCampLocation"/>
    /// </summary>
    ///
    /// <param name="location">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SetWarCampLocation(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>? location = null)
    {
      var element = ElementTool.Create<SetWarCampLocation>();
      element.m_Location = location?.Reference ?? element.m_Location;
      if (element.m_Location is null)
      {
        element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatRecoverLeaderMana"/>
    /// </summary>
    public static ActionsBuilder TacticalCombatRecoverLeaderMana(
        this ActionsBuilder builder,
        ContextValue? value = null)
    {
      var element = ElementTool.Create<TacticalCombatRecoverLeaderMana>();
      element.m_Value = value ?? element.m_Value;
      if (element.m_Value is null)
      {
        element.m_Value = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="TeleportArmyAction"/>
    /// </summary>
    public static ActionsBuilder TeleportArmyAction(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<TeleportArmyAction>());
    }

    /// <summary>
    /// Adds <see cref="UnlockUnitsGrowth"/>
    /// </summary>
    ///
    /// <param name="unit">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder UnlockUnitsGrowth(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? unit = null)
    {
      var element = ElementTool.Create<UnlockUnitsGrowth>();
      element.m_Unit = unit?.Reference ?? element.m_Unit;
      if (element.m_Unit is null)
      {
        element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      return builder.Add(element);
    }
  }
}
