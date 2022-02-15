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
//***** AUTO-GENERATED - DO NOT EDIT *****//
namespace BlueprintCore.Actions.Builder.KingdomEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for actions involving the Kingdom and Crusade system.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderKingdomEx
{

    /// <summary>
    /// Adds <see cref="BlockTacticalCell"/>
    /// </summary>
    public static ActionsBuilder BlockTacticalCell(
        this ActionsBuilder builder,
        TacticalMapObstacle.Link? obstaclePrefab = null)
    {
      var element = ElementTool.Create<BlockTacticalCell>();
      if (obstaclePrefab is not null)
      {
        builder.Validate(obstaclePrefab);
        element.m_ObstaclePrefab = obstaclePrefab;
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
      if (value is not null)
      {
        element.m_Value = value;
      }
      if (element.m_Value is null)
      {
        element.m_Value = ContextValues.Constant(0);
      }
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
      if (canAddInBonusMoraleTurn is not null)
      {
        element.m_CanAddInBonusMoraleTurn = canAddInBonusMoraleTurn;
      }
      if (inCurrentTurn is not null)
      {
        element.m_InCurrentTurn = inCurrentTurn;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionAddCrusadeResource"/>
    /// </summary>
    public static ActionsBuilder ContextActionAddCrusadeResource(
        this ActionsBuilder builder,
        KingdomResourcesAmount? resourcesAmount = null)
    {
      var element = ElementTool.Create<ContextActionAddCrusadeResource>();
      if (resourcesAmount is not null)
      {
        element.m_ResourcesAmount = resourcesAmount;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionArmyRemoveFacts(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>>? factsToRemove = null)
    {
      var element = ElementTool.Create<ContextActionArmyRemoveFacts>();
      if (factsToRemove is not null)
      {
        element.m_FactsToRemove = factsToRemove.Select(bp => bp.Reference).ToArray();
      }
      if (element.m_FactsToRemove is null)
      {
        element.m_FactsToRemove = new BlueprintUnitFactReference[0];
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRestoreLeaderAction"/>
    /// </summary>
    public static ActionsBuilder ContextActionRestoreLeaderAction(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionRestoreLeaderAction>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionStopUnit"/>
    /// </summary>
    public static ActionsBuilder ContextActionStopUnit(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionStopUnit>());
    }

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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AddBuffToSquad(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? buff = null,
        SquadFilter? filter = null,
        GlobalMagicValue? hoursDuration = null)
    {
      var element = ElementTool.Create<AddBuffToSquad>();
      if (buff is not null)
      {
        element.m_Buff = buff.Reference;
      }
      if (element.m_Buff is null)
      {
        element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      if (filter is not null)
      {
        builder.Validate(filter);
        element.m_Filter = filter;
      }
      if (hoursDuration is not null)
      {
        builder.Validate(hoursDuration);
        element.m_HoursDuration = hoursDuration;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangeArmyMorale"/>
    /// </summary>
    public static ActionsBuilder ChangeArmyMorale(
        this ActionsBuilder builder,
        GlobalMagicValue? changeValue = null,
        GlobalMagicValue? duration = null)
    {
      var element = ElementTool.Create<ChangeArmyMorale>();
      if (changeValue is not null)
      {
        builder.Validate(changeValue);
        element.m_ChangeValue = changeValue;
      }
      if (duration is not null)
      {
        builder.Validate(duration);
        element.m_Duration = duration;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="FakeSkipTime"/>
    /// </summary>
    public static ActionsBuilder FakeSkipTime(
        this ActionsBuilder builder,
        GlobalMagicValue? skipDays = null)
    {
      var element = ElementTool.Create<FakeSkipTime>();
      if (skipDays is not null)
      {
        builder.Validate(skipDays);
        element.m_SkipDays = skipDays;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder GainGlobalMagicSpell(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMagicSpell, BlueprintGlobalMagicSpell.Reference>? spell = null)
    {
      var element = ElementTool.Create<GainGlobalMagicSpell>();
      if (spell is not null)
      {
        element.m_Spell = spell.Reference;
      }
      if (element.m_Spell is null)
      {
        element.m_Spell = BlueprintTool.GetRef<BlueprintGlobalMagicSpell.Reference>(null);
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ManuallySetGlobalSpellCooldown(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMagicSpell, BlueprintGlobalMagicSpell.Reference>? spell = null)
    {
      var element = ElementTool.Create<ManuallySetGlobalSpellCooldown>();
      if (spell is not null)
      {
        element.m_Spell = spell.Reference;
      }
      if (element.m_Spell is null)
      {
        element.m_Spell = BlueprintTool.GetRef<BlueprintGlobalMagicSpell.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="OpenTeleportationInterface"/>
    /// </summary>
    public static ActionsBuilder OpenTeleportationInterface(
        this ActionsBuilder builder,
        ActionsBuilder? onTeleportActions = null)
    {
      var element = ElementTool.Create<OpenTeleportationInterface>();
      if (onTeleportActions is not null)
      {
        element.m_OnTeleportActions = onTeleportActions.Build();
      }
      if (element.m_OnTeleportActions is null)
      {
        element.m_OnTeleportActions = Constants.Empty.Actions;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RemoveGlobalMagicSpell(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMagicSpell, BlueprintGlobalMagicSpell.Reference>? spell = null)
    {
      var element = ElementTool.Create<RemoveGlobalMagicSpell>();
      if (spell is not null)
      {
        element.m_Spell = spell.Reference;
      }
      if (element.m_Spell is null)
      {
        element.m_Spell = BlueprintTool.GetRef<BlueprintGlobalMagicSpell.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RepairLeaderMana"/>
    /// </summary>
    public static ActionsBuilder RepairLeaderMana(
        this ActionsBuilder builder,
        GlobalMagicValue? value = null)
    {
      var element = ElementTool.Create<RepairLeaderMana>();
      if (value is not null)
      {
        builder.Validate(value);
        element.m_Value = value;
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
    /// Adds <see cref="GainDiceArmyDamage"/>
    /// </summary>
    public static ActionsBuilder GainDiceArmyDamage(
        this ActionsBuilder builder,
        GlobalMagicValue? diceValue = null,
        SquadFilter? filter = null)
    {
      var element = ElementTool.Create<GainDiceArmyDamage>();
      if (diceValue is not null)
      {
        builder.Validate(diceValue);
        element.m_DiceValue = diceValue;
      }
      if (filter is not null)
      {
        builder.Validate(filter);
        element.m_Filter = filter;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveUnitsByExp"/>
    /// </summary>
    public static ActionsBuilder RemoveUnitsByExp(
        this ActionsBuilder builder,
        GlobalMagicValue? expValue = null,
        SquadFilter? filter = null)
    {
      var element = ElementTool.Create<RemoveUnitsByExp>();
      if (expValue is not null)
      {
        builder.Validate(expValue);
        element.m_ExpValue = expValue;
      }
      if (filter is not null)
      {
        builder.Validate(filter);
        element.m_Filter = filter;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SummonExistUnits"/>
    /// </summary>
    public static ActionsBuilder SummonExistUnits(
        this ActionsBuilder builder,
        GlobalMagicValue? sumExpCost = null)
    {
      var element = ElementTool.Create<SummonExistUnits>();
      if (sumExpCost is not null)
      {
        builder.Validate(sumExpCost);
        element.m_SumExpCost = sumExpCost;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SummonRandomGroup"/>
    /// </summary>
    public static ActionsBuilder SummonRandomGroup(
        this ActionsBuilder builder,
        SummonRandomGroup.RandomGroup[]? randomGroups = null)
    {
      var element = ElementTool.Create<SummonRandomGroup>();
      if (randomGroups is not null)
      {
        foreach (var item in randomGroups) { builder.Validate(item); }
        element.m_RandomGroups = randomGroups;
      }
      if (element.m_RandomGroups is null)
      {
        element.m_RandomGroups = new SummonRandomGroup.RandomGroup[0];
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="armyLeader">
    /// Blueprint of type BlueprintArmyLeader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="location">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder CreateCrusaderArmy(
        this ActionsBuilder builder,
        bool? applyRecruitIncrease = null,
        Blueprint<BlueprintArmyPreset, BlueprintArmyPreset.Reference>? army = ,
        Blueprint<BlueprintArmyLeader, ArmyLeader.Reference>? armyLeader = null,
        float? armySpeed = null,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>? location = ,
        int? movementPoints = null)
    {
      var element = ElementTool.Create<CreateArmy>();
      if (applyRecruitIncrease is not null)
      {
        element.m_ApplyRecruitIncrease = applyRecruitIncrease;
      }
      if (army is not null)
      {
        element.Preset = army.Reference;
      }
      if (element.Preset is null)
      {
        element.Preset = BlueprintTool.GetRef<BlueprintArmyPreset.Reference>(null);
      }
      if (armyLeader is not null)
      {
        element.ArmyLeader = armyLeader.Reference;
        element.WithLeader = true;
      }
      if (element.ArmyLeader is null)
      {
        element.ArmyLeader = BlueprintTool.GetRef<ArmyLeader.Reference>(null);
      }
      if (armySpeed is not null)
      {
        element.m_ArmySpeed = armySpeed;
      }
      if (faction is not null)
      {
        element.Faction = ArmyFaction.Crusaders;
      }
      if (location is not null)
      {
        element.Location = location.Reference;
      }
      if (element.Location is null)
      {
        element.Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      if (movementPoints is not null)
      {
        element.MovementPoints = movementPoints;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="armyLeader">
    /// Blueprint of type BlueprintArmyLeader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="completeActions">
    /// Blueprint of type BlueprintActionList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="location">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder CreateDemonArmy(
        this ActionsBuilder builder,
        Blueprint<BlueprintArmyPreset, BlueprintArmyPreset.Reference>? army = ,
        Blueprint<BlueprintArmyLeader, ArmyLeader.Reference>? armyLeader = null,
        float? armySpeed = null,
        Blueprint<BlueprintActionList, BlueprintActionList.Reference>? completeActions = null,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>? location = ,
        bool targetNearestEnemy)
    {
      var element = ElementTool.Create<CreateArmy>();
      if (army is not null)
      {
        element.Preset = army.Reference;
      }
      if (element.Preset is null)
      {
        element.Preset = BlueprintTool.GetRef<BlueprintArmyPreset.Reference>(null);
      }
      if (armyLeader is not null)
      {
        element.ArmyLeader = armyLeader.Reference;
        element.WithLeader = true;
      }
      if (element.ArmyLeader is null)
      {
        element.ArmyLeader = BlueprintTool.GetRef<ArmyLeader.Reference>(null);
      }
      if (armySpeed is not null)
      {
        element.m_ArmySpeed = armySpeed;
      }
      if (completeActions is not null)
      {
        element.m_CompleteActions = completeActions.Reference;
      }
      if (element.m_CompleteActions is null)
      {
        element.m_CompleteActions = BlueprintTool.GetRef<BlueprintActionList.Reference>(null);
      }
      if (faction is not null)
      {
        element.Faction = ArmyFaction.Demons;
      }
      if (location is not null)
      {
        element.Location = location.Reference;
      }
      if (element.Location is null)
      {
        element.Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      element.m_MoveTarget = targetNearestEnemy ? TravelLogicType.NearestEnemy : TravelLogicType.None;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="armyLeader">
    /// Blueprint of type BlueprintArmyLeader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="completeActions">
    /// Blueprint of type BlueprintActionList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="spawnLocation">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="targetLocation">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder CreateDemonArmyTargetingLocation(
        this ActionsBuilder builder,
        Blueprint<BlueprintArmyPreset, BlueprintArmyPreset.Reference>? army = ,
        Blueprint<BlueprintArmyLeader, ArmyLeader.Reference>? armyLeader = null,
        Blueprint<BlueprintActionList, BlueprintActionList.Reference>? completeActions = null,
        int? daysToDestination = null,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>? spawnLocation = ,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>? targetLocation = )
    {
      var element = ElementTool.Create<CreateArmy>();
      if (army is not null)
      {
        element.Preset = army.Reference;
      }
      if (element.Preset is null)
      {
        element.Preset = BlueprintTool.GetRef<BlueprintArmyPreset.Reference>(null);
      }
      if (armyLeader is not null)
      {
        element.ArmyLeader = armyLeader.Reference;
        element.WithLeader = true;
      }
      if (element.ArmyLeader is null)
      {
        element.ArmyLeader = BlueprintTool.GetRef<ArmyLeader.Reference>(null);
      }
      if (completeActions is not null)
      {
        element.m_CompleteActions = completeActions.Reference;
      }
      if (element.m_CompleteActions is null)
      {
        element.m_CompleteActions = BlueprintTool.GetRef<BlueprintActionList.Reference>(null);
      }
      if (daysToDestination is not null)
      {
        element.m_DaysToDestination = daysToDestination;
      }
      if (faction is not null)
      {
        element.Faction = ArmyFaction.Demons;
      }
      if (moveTarget is not null)
      {
        element.m_MoveTarget = TravelLogicType.Location;
      }
      if (spawnLocation is not null)
      {
        element.Location = spawnLocation.Reference;
      }
      if (element.Location is null)
      {
        element.Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      if (targetLocation is not null)
      {
        element.m_TargetLocation = targetLocation.Reference;
      }
      if (element.m_TargetLocation is null)
      {
        element.m_TargetLocation = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CreateGarrison"/>
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="location">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="preset">
    /// Blueprint of type BlueprintArmyPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder CreateGarrison(
        this ActionsBuilder builder,
        Blueprint<BlueprintArmyLeader, ArmyLeader.Reference>? armyLeader = null,
        bool? hasNoReward = null,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>? location = null,
        Blueprint<BlueprintArmyPreset, BlueprintArmyPreset.Reference>? preset = null,
        bool? withLeader = null)
    {
      var element = ElementTool.Create<CreateGarrison>();
      if (armyLeader is not null)
      {
        element.ArmyLeader = armyLeader.Reference;
      }
      if (element.ArmyLeader is null)
      {
        element.ArmyLeader = BlueprintTool.GetRef<ArmyLeader.Reference>(null);
      }
      if (hasNoReward is not null)
      {
        element.HasNoReward = hasNoReward;
      }
      if (location is not null)
      {
        element.Location = location.Reference;
      }
      if (element.Location is null)
      {
        element.Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      if (preset is not null)
      {
        element.Preset = preset.Reference;
      }
      if (element.Preset is null)
      {
        element.Preset = BlueprintTool.GetRef<BlueprintArmyPreset.Reference>(null);
      }
      if (withLeader is not null)
      {
        element.WithLeader = withLeader;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder CreateArmyFromLosses(
        this ActionsBuilder builder,
        bool? applyRecruitIncrease = null,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>? location = null,
        int? squadsMaxCount = null,
        int? sumExperience = null)
    {
      var element = ElementTool.Create<CreateArmyFromLosses>();
      if (applyRecruitIncrease is not null)
      {
        element.m_ApplyRecruitIncrease = applyRecruitIncrease;
      }
      if (location is not null)
      {
        element.m_Location = location.Reference;
      }
      if (element.m_Location is null)
      {
        element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      if (squadsMaxCount is not null)
      {
        element.m_SquadsMaxCount = squadsMaxCount;
      }
      if (sumExperience is not null)
      {
        element.m_SumExperience = sumExperience;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder EnterKingdomInterface(
        this ActionsBuilder builder,
        Blueprint<BlueprintAreaEnterPoint, BlueprintAreaEnterPointReference>? returnPoint = null,
        ActionsBuilder? triggerAfterAuto = null)
    {
      var element = ElementTool.Create<EnterKingdomInterface>();
      if (returnPoint is not null)
      {
        element.m_ReturnPoint = returnPoint.Reference;
      }
      if (element.m_ReturnPoint is null)
      {
        element.m_ReturnPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(null);
      }
      if (triggerAfterAuto is not null)
      {
        element.TriggerAfterAuto = triggerAfterAuto.Build();
      }
      if (element.TriggerAfterAuto is null)
      {
        element.TriggerAfterAuto = Constants.Empty.Actions;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RecruiteArmyLeader(
        this ActionsBuilder builder,
        Blueprint<BlueprintArmyLeader, ArmyLeader.Reference>? armyLeader = null)
    {
      var element = ElementTool.Create<RecruiteArmyLeader>();
      if (armyLeader is not null)
      {
        element.ArmyLeader = armyLeader.Reference;
      }
      if (element.ArmyLeader is null)
      {
        element.ArmyLeader = BlueprintTool.GetRef<ArmyLeader.Reference>(null);
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RemoveDemonArmies(
        this ActionsBuilder builder,
        Blueprint<BlueprintArmyPreset, BlueprintArmyPresetReference>? armyPreset = null,
        ArmyType? armyType = null)
    {
      var element = ElementTool.Create<RemoveDemonArmies>();
      if (armyPreset is not null)
      {
        element.m_ArmyPreset = armyPreset.Reference;
      }
      if (element.m_ArmyPreset is null)
      {
        element.m_ArmyPreset = BlueprintTool.GetRef<BlueprintArmyPresetReference>(null);
      }
      if (armyType is not null)
      {
        element.m_ArmyType = armyType;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RemoveGarrison(
        this ActionsBuilder builder,
        bool? handleAsGarrisonDefeated = null,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>? location = null)
    {
      var element = ElementTool.Create<RemoveGarrison>();
      if (handleAsGarrisonDefeated is not null)
      {
        element.HandleAsGarrisonDefeated = handleAsGarrisonDefeated;
      }
      if (location is not null)
      {
        element.m_Location = location.Reference;
      }
      if (element.m_Location is null)
      {
        element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
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
      if (armies is not null)
      {
        builder.Validate(armies);
        element.m_Armies = armies;
      }
      if (experience is not null)
      {
        element.m_Experience = experience;
      }
      if (limitUnitExperienceMaximum is not null)
      {
        element.m_LimitUnitExperienceMaximum = limitUnitExperienceMaximum;
      }
      if (limitUnitExperienceMinimum is not null)
      {
        element.m_LimitUnitExperienceMinimum = limitUnitExperienceMinimum;
      }
      if (mode is not null)
      {
        element.m_Mode = mode;
      }
      if (percentage is not null)
      {
        element.m_Percentage = percentage;
      }
      if (removeCheapestUnit is not null)
      {
        element.m_RemoveCheapestUnit = removeCheapestUnit;
      }
      if (removeSpecificUnit is not null)
      {
        element.m_RemoveSpecificUnit = removeSpecificUnit;
      }
      if (unitExperienceMaximum is not null)
      {
        element.m_UnitExperienceMaximum = unitExperienceMaximum;
      }
      if (unitExperienceMinimum is not null)
      {
        element.m_UnitExperienceMinimum = unitExperienceMinimum;
      }
      if (unitTagBlacklist is not null)
      {
        element.m_UnitTagBlacklist = unitTagBlacklist;
      }
      if (element.m_UnitTagBlacklist is null)
      {
        element.m_UnitTagBlacklist = new UnitTag[0];
      }
      if (unitTagWhitelist is not null)
      {
        element.m_UnitTagWhitelist = unitTagWhitelist;
      }
      if (element.m_UnitTagWhitelist is null)
      {
        element.m_UnitTagWhitelist = new UnitTag[0];
      }
      if (unitToRemove is not null)
      {
        element.m_UnitToRemove = unitToRemove.Reference;
      }
      if (element.m_UnitToRemove is null)
      {
        element.m_UnitToRemove = BlueprintTool.GetRef<BlueprintUnitReference>(null);
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SetWarCampLocation(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>? location = null)
    {
      var element = ElementTool.Create<SetWarCampLocation>();
      if (location is not null)
      {
        element.m_Location = location.Reference;
      }
      if (element.m_Location is null)
      {
        element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
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
      if (bonus is not null)
      {
        element.Bonus = bonus;
      }
      if (change is not null)
      {
        element.Change = change;
      }
      if (substract is not null)
      {
        element.Substract = substract;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionActivateEventDeck(
        this ActionsBuilder builder,
        Blueprint<BlueprintKingdomDeck, BlueprintKingdomDeckReference>? deck = null)
    {
      var element = ElementTool.Create<KingdomActionActivateEventDeck>();
      if (deck is not null)
      {
        element.m_Deck = deck.Reference;
      }
      if (element.m_Deck is null)
      {
        element.m_Deck = BlueprintTool.GetRef<BlueprintKingdomDeckReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionAddBPRandom"/>
    /// </summary>
    public static ActionsBuilder KingdomActionAddBPRandom(
        this ActionsBuilder builder,
        int? bonus = null,
        DiceFormula? change = null,
        bool? includeInEventStats = null,
        KingdomResource? resourceType = null)
    {
      var element = ElementTool.Create<KingdomActionAddBPRandom>();
      if (bonus is not null)
      {
        element.Bonus = bonus;
      }
      if (change is not null)
      {
        element.Change = change;
      }
      if (includeInEventStats is not null)
      {
        element.IncludeInEventStats = includeInEventStats;
      }
      if (resourceType is not null)
      {
        element.ResourceType = resourceType;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionAddBuff"/>
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="region">
    /// Blueprint of type BlueprintRegion. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionAddBuff(
        this ActionsBuilder builder,
        bool? applyToRegion = null,
        Blueprint<BlueprintKingdomBuff, BlueprintKingdomBuffReference>? blueprint = null,
        bool? copyToAdjacentRegions = null,
        int? overrideDuration = null,
        Blueprint<BlueprintRegion, BlueprintRegionReference>? region = null)
    {
      var element = ElementTool.Create<KingdomActionAddBuff>();
      if (applyToRegion is not null)
      {
        element.ApplyToRegion = applyToRegion;
      }
      if (blueprint is not null)
      {
        element.m_Blueprint = blueprint.Reference;
      }
      if (element.m_Blueprint is null)
      {
        element.m_Blueprint = BlueprintTool.GetRef<BlueprintKingdomBuffReference>(null);
      }
      if (copyToAdjacentRegions is not null)
      {
        element.CopyToAdjacentRegions = copyToAdjacentRegions;
      }
      if (overrideDuration is not null)
      {
        element.OverrideDuration = overrideDuration;
      }
      if (region is not null)
      {
        element.m_Region = region.Reference;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="settlement">
    /// Blueprint of type BlueprintSettlement. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionAddFreeBuilding(
        this ActionsBuilder builder,
        bool? anywhere = null,
        Blueprint<BlueprintSettlementBuilding, BlueprintSettlementBuildingReference>? building = null,
        int? count = null,
        Blueprint<BlueprintSettlement, BlueprintSettlement.Reference>? settlement = null)
    {
      var element = ElementTool.Create<KingdomActionAddFreeBuilding>();
      if (anywhere is not null)
      {
        element.Anywhere = anywhere;
      }
      if (building is not null)
      {
        element.m_Building = building.Reference;
      }
      if (element.m_Building is null)
      {
        element.m_Building = BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(null);
      }
      if (count is not null)
      {
        element.Count = count;
      }
      if (settlement is not null)
      {
        element.m_Settlement = settlement.Reference;
      }
      if (element.m_Settlement is null)
      {
        element.m_Settlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(null);
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
      if (freeRerollsToAdd is not null)
      {
        element.m_FreeRerollsToAdd = freeRerollsToAdd;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionAddRandomBuff(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintKingdomBuff, BlueprintKingdomBuffReference>>? buffs = null,
        int? overrideDurationDays = null)
    {
      var element = ElementTool.Create<KingdomActionAddRandomBuff>();
      if (buffs is not null)
      {
        element.m_Buffs = buffs.Select(bp => bp.Reference).ToList();
      }
      if (element.m_Buffs is null)
      {
        element.m_Buffs = new();
      }
      if (overrideDurationDays is not null)
      {
        element.OverrideDurationDays = overrideDurationDays;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="project">
    /// Blueprint of type BlueprintKingdomProject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionArtisanRequestHelp(
        this ActionsBuilder builder,
        Blueprint<BlueprintKingdomArtisan, BlueprintKingdomArtisanReference>? artisan = null,
        Blueprint<BlueprintKingdomProject, BlueprintKingdomProjectReference>? project = null)
    {
      var element = ElementTool.Create<KingdomActionArtisanRequestHelp>();
      if (artisan is not null)
      {
        element.m_Artisan = artisan.Reference;
      }
      if (element.m_Artisan is null)
      {
        element.m_Artisan = BlueprintTool.GetRef<BlueprintKingdomArtisanReference>(null);
      }
      if (project is not null)
      {
        element.m_Project = project.Reference;
      }
      if (element.m_Project is null)
      {
        element.m_Project = BlueprintTool.GetRef<BlueprintKingdomProjectReference>(null);
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionConquerRegion(
        this ActionsBuilder builder,
        Blueprint<BlueprintRegion, BlueprintRegionReference>? region = null)
    {
      var element = ElementTool.Create<KingdomActionConquerRegion>();
      if (region is not null)
      {
        element.m_Region = region.Reference;
      }
      if (element.m_Region is null)
      {
        element.m_Region = BlueprintTool.GetRef<BlueprintRegionReference>(null);
      }
      return builder.Add(element);
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="specificSettlement">
    /// Blueprint of type BlueprintSettlement. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionFillSettlement(
        this ActionsBuilder builder,
        Blueprint<SettlementBuildList, SettlementBuildListReference>? buildList = null,
        Blueprint<BlueprintSettlement, BlueprintSettlement.Reference>? specificSettlement = null)
    {
      var element = ElementTool.Create<KingdomActionFillSettlement>();
      if (buildList is not null)
      {
        element.m_BuildList = buildList.Reference;
      }
      if (element.m_BuildList is null)
      {
        element.m_BuildList = BlueprintTool.GetRef<SettlementBuildListReference>(null);
      }
      if (specificSettlement is not null)
      {
        element.m_SpecificSettlement = specificSettlement.Reference;
      }
      if (element.m_SpecificSettlement is null)
      {
        element.m_SpecificSettlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(null);
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="specificSettlementLocation">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionFillSettlementByLocation(
        this ActionsBuilder builder,
        Blueprint<SettlementBuildList, SettlementBuildListReference>? buildList = null,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPointReference>? specificSettlementLocation = null)
    {
      var element = ElementTool.Create<KingdomActionFillSettlementByLocation>();
      if (buildList is not null)
      {
        element.m_BuildList = buildList.Reference;
      }
      if (element.m_BuildList is null)
      {
        element.m_BuildList = BlueprintTool.GetRef<SettlementBuildListReference>(null);
      }
      if (specificSettlementLocation is not null)
      {
        element.m_SpecificSettlementLocation = specificSettlementLocation.Reference;
      }
      if (element.m_SpecificSettlementLocation is null)
      {
        element.m_SpecificSettlementLocation = BlueprintTool.GetRef<BlueprintGlobalMapPointReference>(null);
      }
      return builder.Add(element);
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="settlement">
    /// Blueprint of type BlueprintSettlement. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionFoundSettlement(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>? location = null,
        Blueprint<BlueprintSettlement, BlueprintSettlement.Reference>? settlement = null)
    {
      var element = ElementTool.Create<KingdomActionFoundSettlement>();
      if (location is not null)
      {
        element.m_Location = location.Reference;
      }
      if (element.m_Location is null)
      {
        element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      if (settlement is not null)
      {
        element.m_Settlement = settlement.Reference;
      }
      if (element.m_Settlement is null)
      {
        element.m_Settlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionGainLeaderExperience"/>
    /// </summary>
    public static ActionsBuilder KingdomActionGainLeaderExperience(
        this ActionsBuilder builder,
        float? multiplierCoefficient = null,
        bool? multiplyByLeaderLevel = null,
        IntEvaluator? value = null)
    {
      var element = ElementTool.Create<KingdomActionGainLeaderExperience>();
      if (multiplierCoefficient is not null)
      {
        element.m_MultiplierCoefficient = multiplierCoefficient;
      }
      if (multiplyByLeaderLevel is not null)
      {
        element.m_MultiplyByLeaderLevel = multiplyByLeaderLevel;
      }
      if (value is not null)
      {
        builder.Validate(value);
        element.m_Value = value;
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
      if (bonus is not null)
      {
        element.Bonus = bonus;
      }
      if (resourceType is not null)
      {
        element.ResourceType = resourceType;
      }
      return builder.Add(element);
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionGetArtisanGift(
        this ActionsBuilder builder,
        Blueprint<BlueprintKingdomArtisan, BlueprintKingdomArtisanReference>? artisan = null)
    {
      var element = ElementTool.Create<KingdomActionGetArtisanGift>();
      if (artisan is not null)
      {
        element.m_Artisan = artisan.Reference;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionGetArtisanGiftWithCertainTier(
        this ActionsBuilder builder,
        Blueprint<BlueprintKingdomArtisan, BlueprintKingdomArtisanReference>? artisan = null,
        int? tier = null)
    {
      var element = ElementTool.Create<KingdomActionGetArtisanGiftWithCertainTier>();
      if (artisan is not null)
      {
        element.m_Artisan = artisan.Reference;
      }
      if (element.m_Artisan is null)
      {
        element.m_Artisan = BlueprintTool.GetRef<BlueprintKingdomArtisanReference>(null);
      }
      if (tier is not null)
      {
        element.tier = tier;
      }
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
      if (coefficient is not null)
      {
        element.m_Coefficient = coefficient;
      }
      if (goldPerUnit is not null)
      {
        element.m_GoldPerUnit = goldPerUnit;
      }
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
      if (coefficient is not null)
      {
        element.m_Coefficient = coefficient;
      }
      if (resourcePerUnit is not null)
      {
        element.m_ResourcePerUnit = resourcePerUnit;
      }
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
      if (maxResourceCountGained is not null)
      {
        element.m_MaxResourceCountGained = maxResourceCountGained;
      }
      if (percent is not null)
      {
        element.m_Percent = percent;
      }
      if (resourceType is not null)
      {
        element.m_ResourceType = resourceType;
      }
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
      if (loot is not null)
      {
        foreach (var item in loot) { builder.Validate(item); }
        element.Loot = loot;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionImproveSettlement(
        this ActionsBuilder builder,
        Blueprint<BlueprintSettlement, BlueprintSettlement.Reference>? specificSettlement = null,
        SettlementState.LevelType? toLevel = null)
    {
      var element = ElementTool.Create<KingdomActionImproveSettlement>();
      if (specificSettlement is not null)
      {
        element.m_SpecificSettlement = specificSettlement.Reference;
      }
      if (element.m_SpecificSettlement is null)
      {
        element.m_SpecificSettlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(null);
      }
      if (toLevel is not null)
      {
        element.ToLevel = toLevel;
      }
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
      if (statType is not null)
      {
        element.StatType = statType;
      }
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
      if (dC is not null)
      {
        element.DC = dC;
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
    /// Adds <see cref="KingdomActionModifyBuildTime"/>
    /// </summary>
    public static ActionsBuilder KingdomActionModifyBuildTime(
        this ActionsBuilder builder,
        float? changeTime = null)
    {
      var element = ElementTool.Create<KingdomActionModifyBuildTime>();
      if (changeTime is not null)
      {
        element.ChangeTime = changeTime;
      }
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
      if (changeCost is not null)
      {
        element.ChangeCost = changeCost;
      }
      if (changeTime is not null)
      {
        element.ChangeTime = changeTime;
      }
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
      if (modifier is not null)
      {
        element.Modifier = modifier;
      }
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
      if (claimedChange is not null)
      {
        element.ClaimedChange = claimedChange;
      }
      if (unclaimedChange is not null)
      {
        element.UnclaimedChange = unclaimedChange;
      }
      if (upgradedChange is not null)
      {
        element.UpgradedChange = upgradedChange;
      }
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
      if (changeTime is not null)
      {
        element.ChangeTime = changeTime;
      }
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
      if (change is not null)
      {
        element.Change = change;
      }
      if (includeInEventStats is not null)
      {
        element.IncludeInEventStats = includeInEventStats;
      }
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
      if (changes is not null)
      {
        builder.Validate(changes);
        element.Changes = changes;
      }
      if (includeInEventStats is not null)
      {
        element.IncludeInEventStats = includeInEventStats;
      }
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
      if (bounded is not null)
      {
        element.Bounded = bounded;
      }
      if (makeBetter is not null)
      {
        element.MakeBetter = makeBetter;
      }
      if (reason is not null)
      {
        element.Reason = reason;
      }
      if (reasonString is not null)
      {
        builder.Validate(reasonString);
        element.ReasonString = reasonString;
      }
      if (upTo is not null)
      {
        element.UpTo = upTo;
      }
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
      if (chapterNumber is not null)
      {
        element.ChapterNumber = chapterNumber;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="region">
    /// Blueprint of type BlueprintRegion. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionRemoveBuff(
        this ActionsBuilder builder,
        bool? allBuffs = null,
        bool? applyToRegion = null,
        Blueprint<BlueprintKingdomBuff, BlueprintKingdomBuffReference>? blueprint = null,
        Blueprint<BlueprintRegion, BlueprintRegionReference>? region = null)
    {
      var element = ElementTool.Create<KingdomActionRemoveBuff>();
      if (allBuffs is not null)
      {
        element.m_AllBuffs = allBuffs;
      }
      if (applyToRegion is not null)
      {
        element.ApplyToRegion = applyToRegion;
      }
      if (blueprint is not null)
      {
        element.m_Blueprint = blueprint.Reference;
      }
      if (element.m_Blueprint is null)
      {
        element.m_Blueprint = BlueprintTool.GetRef<BlueprintKingdomBuffReference>(null);
      }
      if (region is not null)
      {
        element.m_Region = region.Reference;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionRemoveEvent(
        this ActionsBuilder builder,
        bool? allIfMultiple = null,
        bool? cancelIfInProgress = null,
        Blueprint<BlueprintKingdomEventBase, BlueprintKingdomEventBaseReference>? eventBlueprint = null)
    {
      var element = ElementTool.Create<KingdomActionRemoveEvent>();
      if (allIfMultiple is not null)
      {
        element.AllIfMultiple = allIfMultiple;
      }
      if (cancelIfInProgress is not null)
      {
        element.CancelIfInProgress = cancelIfInProgress;
      }
      if (eventBlueprint is not null)
      {
        element.m_EventBlueprint = eventBlueprint.Reference;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionRemoveEventDeck(
        this ActionsBuilder builder,
        Blueprint<BlueprintKingdomDeck, BlueprintKingdomDeckReference>? deck = null)
    {
      var element = ElementTool.Create<KingdomActionRemoveEventDeck>();
      if (deck is not null)
      {
        element.m_Deck = deck.Reference;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="itemType">
    /// Blueprint of type ArtisanItemDeck. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionRequestArtisanGift(
        this ActionsBuilder builder,
        Blueprint<BlueprintKingdomArtisan, BlueprintKingdomArtisanReference>? artisan = null,
        Blueprint<ArtisanItemDeck, ArtisanItemDeckReference>? itemType = null)
    {
      var element = ElementTool.Create<KingdomActionRequestArtisanGift>();
      if (artisan is not null)
      {
        element.m_Artisan = artisan.Reference;
      }
      if (element.m_Artisan is null)
      {
        element.m_Artisan = BlueprintTool.GetRef<BlueprintKingdomArtisanReference>(null);
      }
      if (itemType is not null)
      {
        element.m_ItemType = itemType.Reference;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionResolveCrusadeEvent(
        this ActionsBuilder builder,
        Blueprint<BlueprintCrusadeEvent, BlueprintCrusadeEvent.Reference>? eventBlueprint = null,
        int? solutionIndex = null)
    {
      var element = ElementTool.Create<KingdomActionResolveCrusadeEvent>();
      if (eventBlueprint is not null)
      {
        element.m_EventBlueprint = eventBlueprint.Reference;
      }
      if (element.m_EventBlueprint is null)
      {
        element.m_EventBlueprint = BlueprintTool.GetRef<BlueprintCrusadeEvent.Reference>(null);
      }
      if (solutionIndex is not null)
      {
        element.m_SolutionIndex = solutionIndex;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionResolveEvent(
        this ActionsBuilder builder,
        Alignment? alignment = null,
        Blueprint<BlueprintKingdomEvent, BlueprintKingdomEventReference>? eventBlueprint = null,
        bool? finalResolve = null,
        EventResult.MarginType? result = null)
    {
      var element = ElementTool.Create<KingdomActionResolveEvent>();
      if (alignment is not null)
      {
        element.Alignment = alignment;
      }
      if (eventBlueprint is not null)
      {
        element.m_EventBlueprint = eventBlueprint.Reference;
      }
      if (element.m_EventBlueprint is null)
      {
        element.m_EventBlueprint = BlueprintTool.GetRef<BlueprintKingdomEventReference>(null);
      }
      if (finalResolve is not null)
      {
        element.FinalResolve = finalResolve;
      }
      if (result is not null)
      {
        element.Result = result;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionResolveProject(
        this ActionsBuilder builder,
        Blueprint<BlueprintKingdomProject, BlueprintKingdomProjectReference>? eventBlueprint = null)
    {
      var element = ElementTool.Create<KingdomActionResolveProject>();
      if (eventBlueprint is not null)
      {
        element.m_EventBlueprint = eventBlueprint.Reference;
      }
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
      if (includeResources is not null)
      {
        element.m_IncludeResources = includeResources;
      }
      if (includeResourcesPerTurn is not null)
      {
        element.m_IncludeResourcesPerTurn = includeResourcesPerTurn;
      }
      if (includeStats is not null)
      {
        element.m_IncludeStats = includeStats;
      }
      if (lastNDays is not null)
      {
        element.m_LastNDays = lastNDays;
      }
      if (lastNTimes is not null)
      {
        element.m_LastNTimes = lastNTimes;
      }
      if (resourcesRatio is not null)
      {
        element.m_ResourcesRatio = resourcesRatio;
      }
      if (type is not null)
      {
        element.m_Type = type;
      }
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
      if (add is not null)
      {
        element.Add = add;
      }
      if (incomePerClaimed is not null)
      {
        element.IncomePerClaimed = incomePerClaimed;
      }
      if (incomePerUpgraded is not null)
      {
        element.IncomePerUpgraded = incomePerUpgraded;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="locations">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionSpawnRandomArmy(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintArmyPreset, BlueprintArmyPresetReference>>? armies = null,
        ArmyFaction? faction = null,
        List<Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>>? locations = null)
    {
      var element = ElementTool.Create<KingdomActionSpawnRandomArmy>();
      if (armies is not null)
      {
        element.m_Armies = armies.Select(bp => bp.Reference).ToList();
      }
      if (element.m_Armies is null)
      {
        element.m_Armies = new();
      }
      if (faction is not null)
      {
        element.m_Faction = faction;
      }
      if (locations is not null)
      {
        element.m_Locations = locations.Select(bp => bp.Reference).ToList();
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="region">
    /// Blueprint of type BlueprintRegion. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
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
      if (checkTriggerImmediately is not null)
      {
        element.CheckTriggerImmediately = checkTriggerImmediately;
      }
      if (checkTriggerOnStart is not null)
      {
        element.CheckTriggerOnStart = checkTriggerOnStart;
      }
      if (delayDays is not null)
      {
        element.DelayDays = delayDays;
      }
      if (eventValue is not null)
      {
        element.m_Event = eventValue.Reference;
      }
      if (element.m_Event is null)
      {
        element.m_Event = BlueprintTool.GetRef<BlueprintKingdomEventBaseReference>(null);
      }
      if (randomRegion is not null)
      {
        element.RandomRegion = randomRegion;
      }
      if (region is not null)
      {
        element.m_Region = region.Reference;
      }
      if (element.m_Region is null)
      {
        element.m_Region = BlueprintTool.GetRef<BlueprintRegionReference>(null);
      }
      if (startNextMonth is not null)
      {
        element.StartNextMonth = startNextMonth;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomActionUnlockArtisan(
        this ActionsBuilder builder,
        Blueprint<BlueprintKingdomArtisan, BlueprintKingdomArtisanReference>? artisan = null)
    {
      var element = ElementTool.Create<KingdomActionUnlockArtisan>();
      if (artisan is not null)
      {
        element.m_Artisan = artisan.Reference;
      }
      if (element.m_Artisan is null)
      {
        element.m_Artisan = BlueprintTool.GetRef<BlueprintKingdomArtisanReference>(null);
      }
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
      if (bonus is not null)
      {
        element.Bonus = bonus;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AddMercenaryToPool(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? unit = null,
        float? weight = null)
    {
      var element = ElementTool.Create<AddMercenaryToPool>();
      if (unit is not null)
      {
        element.m_Unit = unit.Reference;
      }
      if (element.m_Unit is null)
      {
        element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      if (weight is not null)
      {
        element.m_Weight = weight;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="features">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
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
      if (armyTag is not null)
      {
        element.m_ArmyTag = armyTag;
      }
      if (armyUnits is not null)
      {
        element.m_ArmyUnits = armyUnits.Select(bp => bp.Reference).ToArray();
      }
      if (element.m_ArmyUnits is null)
      {
        element.m_ArmyUnits = new BlueprintUnitReference[0];
      }
      if (byTag is not null)
      {
        element.m_ByTag = byTag;
      }
      if (byUnits is not null)
      {
        element.m_ByUnits = byUnits;
      }
      if (faction is not null)
      {
        element.m_Faction = faction;
      }
      if (features is not null)
      {
        element.m_Features = features.Select(bp => bp.Reference).ToArray();
      }
      if (element.m_Features is null)
      {
        element.m_Features = new BlueprintFeatureReference[0];
      }
      if (mercenariesFilter is not null)
      {
        element.m_MercenariesFilter = mercenariesFilter;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ChangeMercenaryWeight(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? unit = null,
        float? weight = null)
    {
      var element = ElementTool.Create<ChangeMercenaryWeight>();
      if (unit is not null)
      {
        element.m_Unit = unit.Reference;
      }
      if (element.m_Unit is null)
      {
        element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      if (weight is not null)
      {
        element.m_Weight = weight;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder DecreaseRecruitsGrowth(
        this ActionsBuilder builder,
        int? count = null,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? unit = null)
    {
      var element = ElementTool.Create<DecreaseRecruitsGrowth>();
      if (count is not null)
      {
        element.Count = count;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder DecreaseRecruitsPool(
        this ActionsBuilder builder,
        int? count = null,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? unit = null)
    {
      var element = ElementTool.Create<DecreaseRecruitsPool>();
      if (count is not null)
      {
        element.Count = count;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="oldUnit">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
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
      if (convertCoefficient is not null)
      {
        element.ConvertCoefficient = convertCoefficient;
      }
      if (newGrowth is not null)
      {
        element.NewGrowth = newGrowth;
      }
      if (newUnit is not null)
      {
        element.m_NewUnit = newUnit.Reference;
      }
      if (element.m_NewUnit is null)
      {
        element.m_NewUnit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      if (oldGrowth is not null)
      {
        element.OldGrowth = oldGrowth;
      }
      if (oldUnit is not null)
      {
        element.m_OldUnit = oldUnit.Reference;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder IncreaseRecruitsGrowth(
        this ActionsBuilder builder,
        int? count = null,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? unit = null)
    {
      var element = ElementTool.Create<IncreaseRecruitsGrowth>();
      if (count is not null)
      {
        element.Count = count;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder IncreaseRecruitsPool(
        this ActionsBuilder builder,
        int? count = null,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? unit = null)
    {
      var element = ElementTool.Create<IncreaseRecruitsPool>();
      if (count is not null)
      {
        element.Count = count;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RemoveMercenaryFromPool(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? unit = null)
    {
      var element = ElementTool.Create<RemoveMercenaryFromPool>();
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="oldBuilding">
    /// Blueprint of type BlueprintSettlementBuilding. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ReplaceBuildings(
        this ActionsBuilder builder,
        Blueprint<BlueprintSettlementBuilding, BlueprintSettlementBuildingReference>? newBuilding = null,
        Blueprint<BlueprintSettlementBuilding, BlueprintSettlementBuildingReference>? oldBuilding = null)
    {
      var element = ElementTool.Create<ReplaceBuildings>();
      if (newBuilding is not null)
      {
        element.m_NewBuilding = newBuilding.Reference;
      }
      if (element.m_NewBuilding is null)
      {
        element.m_NewBuilding = BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(null);
      }
      if (oldBuilding is not null)
      {
        element.m_OldBuilding = oldBuilding.Reference;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SetRecruitPoint(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>? point = null)
    {
      var element = ElementTool.Create<SetRecruitPoint>();
      if (point is not null)
      {
        element.m_Point = point.Reference;
      }
      if (element.m_Point is null)
      {
        element.m_Point = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      return builder.Add(element);
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder UnlockUnitsGrowth(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? unit = null)
    {
      var element = ElementTool.Create<UnlockUnitsGrowth>();
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
    /// Adds <see cref="AddCrusadeResources"/>
    /// </summary>
    public static ActionsBuilder AddCrusadeResources(
        this ActionsBuilder builder,
        KingdomResourcesAmount? _resourcesAmount = null)
    {
      var element = ElementTool.Create<AddCrusadeResources>();
      if (_resourcesAmount is not null)
      {
        element._resourcesAmount = _resourcesAmount;
      }
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
      if (resourcesAmount is not null)
      {
        element.m_ResourcesAmount = resourcesAmount;
      }
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
      if (maxValueDelta is not null)
      {
        element.m_MaxValueDelta = maxValueDelta;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomAddMoraleFlags(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintKingdomMoraleFlag, BlueprintKingdomMoraleFlag.Reference>>? newFlags = null)
    {
      var element = ElementTool.Create<KingdomAddMoraleFlags>();
      if (newFlags is not null)
      {
        element.m_NewFlags = newFlags.Select(bp => bp.Reference).ToArray();
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomFlagIncrement(
        this ActionsBuilder builder,
        int? increment = null,
        Blueprint<BlueprintKingdomMoraleFlag, BlueprintKingdomMoraleFlag.Reference>? targetFlag = null)
    {
      var element = ElementTool.Create<KingdomFlagIncrement>();
      if (increment is not null)
      {
        element.m_Increment = increment;
      }
      if (targetFlag is not null)
      {
        element.m_TargetFlag = targetFlag.Reference;
      }
      if (element.m_TargetFlag is null)
      {
        element.m_TargetFlag = BlueprintTool.GetRef<BlueprintKingdomMoraleFlag.Reference>(null);
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomMoraleFlagUpdateIncome(
        this ActionsBuilder builder,
        Blueprint<BlueprintKingdomMoraleFlag, BlueprintKingdomMoraleFlag.Reference>? targetFlag = null)
    {
      var element = ElementTool.Create<KingdomMoraleFlagUpdateIncome>();
      if (targetFlag is not null)
      {
        element.m_TargetFlag = targetFlag.Reference;
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomRemoveMoraleFlags(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintKingdomMoraleFlag, BlueprintKingdomMoraleFlag.Reference>>? flagsToRemove = null)
    {
      var element = ElementTool.Create<KingdomRemoveMoraleFlags>();
      if (flagsToRemove is not null)
      {
        element.m_FlagsToRemove = flagsToRemove.Select(bp => bp.Reference).ToArray();
      }
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
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder KingdomSetFlagState(
        this ActionsBuilder builder,
        int? maxDays = null,
        KingdomMoraleFlag.State? state = null,
        Blueprint<BlueprintKingdomMoraleFlag, BlueprintKingdomMoraleFlag.Reference>? targetFlag = null)
    {
      var element = ElementTool.Create<KingdomSetFlagState>();
      if (maxDays is not null)
      {
        element.m_MaxDays = maxDays;
      }
      if (state is not null)
      {
        element.m_State = state;
      }
      if (targetFlag is not null)
      {
        element.m_TargetFlag = targetFlag.Reference;
      }
      if (element.m_TargetFlag is null)
      {
        element.m_TargetFlag = BlueprintTool.GetRef<BlueprintKingdomMoraleFlag.Reference>(null);
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
      if (value is not null)
      {
        element.m_Value = value;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangeTacticalMorale"/>
    /// </summary>
    public static ActionsBuilder ChangeTacticalMorale(
        this ActionsBuilder builder,
        ContextValue? value = null)
    {
      var element = ElementTool.Create<ChangeTacticalMorale>();
      if (value is not null)
      {
        element.m_Value = value;
      }
      if (element.m_Value is null)
      {
        element.m_Value = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSquadUnitsKill"/>
    /// </summary>
    public static ActionsBuilder ContextActionSquadUnitsKill(
        this ActionsBuilder builder,
        ContextDiceValue? count = null,
        float? floatCount = null,
        bool? useFloatValue = null)
    {
      var element = ElementTool.Create<ContextActionSquadUnitsKill>();
      if (count is not null)
      {
        element.m_Count = count;
      }
      if (element.m_Count is null)
      {
        element.m_Count = Constants.Empty.DiceValue;
      }
      if (floatCount is not null)
      {
        element.m_FloatCount = floatCount;
      }
      if (useFloatValue is not null)
      {
        element.m_UseFloatValue = useFloatValue;
      }
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
    public static ActionsBuilder ContextActionSummonTacticalSquad(
        this ActionsBuilder builder,
        ActionsBuilder? afterSpawn = null,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? blueprint = null,
        ContextValue? count = null,
        Blueprint<BlueprintSummonPool, BlueprintSummonPoolReference>? summonPool = null)
    {
      var element = ElementTool.Create<ContextActionSummonTacticalSquad>();
      if (afterSpawn is not null)
      {
        element.m_AfterSpawn = afterSpawn.Build();
      }
      if (element.m_AfterSpawn is null)
      {
        element.m_AfterSpawn = Constants.Empty.Actions;
      }
      if (blueprint is not null)
      {
        element.m_Blueprint = blueprint.Reference;
      }
      if (element.m_Blueprint is null)
      {
        element.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      if (count is not null)
      {
        element.m_Count = count;
      }
      if (element.m_Count is null)
      {
        element.m_Count = ContextValues.Constant(0);
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
    /// Adds <see cref="ContextActionTacticalCombatDealDamage"/>
    /// </summary>
    public static ActionsBuilder ContextActionTacticalCombatDealDamage(
        this ActionsBuilder builder,
        DamageTypeDescription? damageType = null,
        DiceType? diceType = null,
        bool? half = null,
        bool? ignoreCritical = null,
        int? minHPAfterDamage = null,
        ContextValue? rollsCount = null,
        bool? useMinHPAfterDamage = null)
    {
      var element = ElementTool.Create<ContextActionTacticalCombatDealDamage>();
      if (damageType is not null)
      {
        builder.Validate(damageType);
        element.DamageType = damageType;
      }
      if (diceType is not null)
      {
        element.DiceType = diceType;
      }
      if (half is not null)
      {
        element.Half = half;
      }
      if (ignoreCritical is not null)
      {
        element.IgnoreCritical = ignoreCritical;
      }
      if (minHPAfterDamage is not null)
      {
        element.MinHPAfterDamage = minHPAfterDamage;
      }
      if (rollsCount is not null)
      {
        element.RollsCount = rollsCount;
      }
      if (element.RollsCount is null)
      {
        element.RollsCount = ContextValues.Constant(0);
      }
      if (useMinHPAfterDamage is not null)
      {
        element.UseMinHPAfterDamage = useMinHPAfterDamage;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionTacticalCombatHealTarget"/>
    /// </summary>
    public static ActionsBuilder ContextActionTacticalCombatHealTarget(
        this ActionsBuilder builder,
        DiceType? diceType = null,
        ContextValue? rollsCount = null)
    {
      var element = ElementTool.Create<ContextActionTacticalCombatHealTarget>();
      if (diceType is not null)
      {
        element.DiceType = diceType;
      }
      if (rollsCount is not null)
      {
        element.RollsCount = rollsCount;
      }
      if (element.RollsCount is null)
      {
        element.RollsCount = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }
  }
}
