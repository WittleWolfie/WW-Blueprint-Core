//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.AreaLogic;
using Kingmaker.Armies;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Armies.Components;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Armies.TacticalCombat.GameActions;
using Kingmaker.Armies.TacticalCombat.Grid;
using Kingmaker.Blueprints;
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
using Kingmaker.Kingdom.Armies;
using Kingmaker.Kingdom.Armies.Actions;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Kingdom.Flags;
using Kingmaker.Kingdom.Settlements;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GlobalSpellAmplifyResistance</term><description>6a3342d49c59f704a98f952c7168058e</description></item>
    /// <item><term>GlobalSpellLichEnervation</term><description>d35e171beb890534ba7180487db2acde</description></item>
    /// <item><term>GlobalSpellTricksterMassHideousLaughter</term><description>f892a4ab290579c4cb5d70050f5f6776</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder AddBuffToSquad(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuffReference> buff,
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0008</term><description>92b7ac3cfcd10424ba04f8b74f041bd8</description></item>
    /// <item><term>CrusadeEvent57</term><description>31eeeb38e7c44b159536fcefc2c236bf</description></item>
    /// <item><term>Logistics6Spoiling</term><description>a945643238004736ba604bbc55b232ae</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbductedSouls_event</term><description>446e4191ab45485ca8316e4b388d4671</description></item>
    /// <item><term>CrusadeEvent72</term><description>f605189b5c4f4e189c381c79b7d7e3d7</description></item>
    /// <item><term>TimeLoss04_Action</term><description>93ddb85426414eeda6706b5e20402613</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbductedSouls_event</term><description>446e4191ab45485ca8316e4b388d4671</description></item>
    /// <item><term>CrusadeEvent72</term><description>f605189b5c4f4e189c381c79b7d7e3d7</description></item>
    /// <item><term>TimeLoss04_Action</term><description>93ddb85426414eeda6706b5e20402613</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GlobalSpellMarkOfTerror</term><description>e2b56bb4acf390c459919baff3894ecf</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyBlessBuffWarwarpriest</term><description>015bb401d6484d3aa2984ad04b1ddcb7</description></item>
    /// <item><term>ArmyMorale20Buff</term><description>66f7b701c57e4deb95266f16541f729e</description></item>
    /// <item><term>RitualHeroismAbility</term><description>f6d4d5b4a41d5c640b529a79e2650aa8</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyRaiderResourcesForKilling</term><description>14fafae0fc8e9014d9ae82328b7641ea</description></item>
    /// <item><term>FlagTrickster3Economy</term><description>4b833c6fcdfa47918927d80edf7ef9ae</description></item>
    /// <item><term>PillageFact</term><description>8d01674744b34641828b77e53e0cfb9a</description></item>
    /// </list>
    /// </remarks>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Azata5SongOfTheLastStepTeleportBuff</term><description>2b1c9935ca2f4e7aaaa8b0712411be30</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="factsToRemove">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder ArmyRemoveFacts(this ActionsBuilder builder, params Blueprint<BlueprintUnitFactReference>[] factsToRemove)
    {
      var element = ElementTool.Create<ContextActionArmyRemoveFacts>();
      element.m_FactsToRemove = factsToRemove.Select(bp => bp.Reference).ToArray();
      if (element.m_FactsToRemove is null)
      {
        element.m_FactsToRemove = new BlueprintUnitFactReference[0];
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSquadUnitsKill"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyPhantasmalKiller</term><description>1778a8c678bc41f984bd7c0d5e52e3c9</description></item>
    /// <item><term>ArmyUltimatePhantasmalKiller</term><description>e7dbab1d761e482ab46e316ce7af2d6b</description></item>
    /// <item><term>ArmyVorpalStrike</term><description>da6d24ec5a87417f93683ac4b41b3f25</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="floatCount">
    /// <para>
    /// InfoBox: For leader, it is just count (for formulas use Count and custom properties ) For squad, it is coefficient that will be multiplied by current squad size
    /// </para>
    /// </param>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyPhantasmalKiller</term><description>1778a8c678bc41f984bd7c0d5e52e3c9</description></item>
    /// <item><term>ArmyUltimatePhantasmalKiller</term><description>e7dbab1d761e482ab46e316ce7af2d6b</description></item>
    /// <item><term>ArmyVorpalStrike</term><description>da6d24ec5a87417f93683ac4b41b3f25</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="count">
    /// <para>
    /// InfoBox: For leader, it is just count (use custom properties for formulas) For squad, it is coefficient that will be multiplied by current squad size
    /// </para>
    /// </param>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Angel3SummonHeavenlyHostAbility</term><description>f317d44314a843e7aaf3fc202cbe9577</description></item>
    /// <item><term>ArmySummonMarilith</term><description>78c258abcb744f75ab6b71121aadf47d</description></item>
    /// <item><term>SummonSquadSlow</term><description>7985c14f44ad9c64eb32c6d5e9a713fc</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="count">
    /// <para>
    /// InfoBox: For leader, it is just count to summon. For squad, it is coefficient that will be multiplied by current squad size
    /// </para>
    /// </param>
    /// <param name="blueprint">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="summonPool">
    /// <para>
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder SummonTacticalSquad(
        this ActionsBuilder builder,
        ContextValue count,
        ActionsBuilder? afterSpawn = null,
        Blueprint<BlueprintUnitReference>? blueprint = null,
        Blueprint<BlueprintSummonPoolReference>? summonPool = null)
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon5BaneOfDemonsBuff</term><description>7f3a76f5ebee4ff593528ff3e3175a02</description></item>
    /// <item><term>RangerFrostBlastTrapArea</term><description>f991f22da1b51ae48ab59e15e3a28ff4</description></item>
    /// <item><term>RitualStoneCallAbility</term><description>705b85d1ffc2a4347bdfcba7480b32dc</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="rollsCount">
    /// <para>
    /// InfoBox: Result = RollsCount * (5 + Power * Power)d(DiceType)
    /// </para>
    /// </param>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon2FireElementals</term><description>63364fac363349a99dd7fe96ca86dc7c</description></item>
    /// <item><term>Event28HostOfDrunkards</term><description>3c366759ed964186ab14946c39f8a8ae</description></item>
    /// <item><term>ZanedraAndDemons_ISanctum_dialog</term><description>f4eadbafa9adad44bb46639dece46717</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="army">
    /// <para>
    /// Blueprint of type BlueprintArmyPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="location">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="applyRecruitIncrease">
    /// <para>
    /// InfoBox: Increase squads size according to KingdomUnitsGrowthIncrease active components
    /// </para>
    /// </param>
    /// <param name="armyLeader">
    /// <para>
    /// Blueprint of type BlueprintArmyLeader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder CreateCrusaderArmy(
        this ActionsBuilder builder,
        Blueprint<BlueprintArmyPreset.Reference> army,
        Blueprint<BlueprintGlobalMapPoint.Reference> location,
        bool? applyRecruitIncrease = null,
        Blueprint<ArmyLeader.Reference>? armyLeader = null,
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon2FireElementals</term><description>63364fac363349a99dd7fe96ca86dc7c</description></item>
    /// <item><term>Event28HostOfDrunkards</term><description>3c366759ed964186ab14946c39f8a8ae</description></item>
    /// <item><term>ZanedraAndDemons_ISanctum_dialog</term><description>f4eadbafa9adad44bb46639dece46717</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="army">
    /// <para>
    /// Blueprint of type BlueprintArmyPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="location">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="armyLeader">
    /// <para>
    /// Blueprint of type BlueprintArmyLeader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="completeActions">
    /// <para>
    /// Blueprint of type BlueprintActionList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder CreateDemonArmy(
        this ActionsBuilder builder,
        Blueprint<BlueprintArmyPreset.Reference> army,
        Blueprint<BlueprintGlobalMapPoint.Reference> location,
        Blueprint<ArmyLeader.Reference>? armyLeader = null,
        float? armySpeed = null,
        Blueprint<BlueprintActionList.Reference>? completeActions = null,
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyRestoration1</term><description>319d42458570421e9ed4279f206ae3d6</description></item>
    /// <item><term>ArmyRestoration3</term><description>71eba76e806a4136b11bb7e94a8a4c7f</description></item>
    /// <item><term>ArmyRestoration4</term><description>b44b7bb6e84e44c090edb711effb6bd4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="location">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="applyRecruitIncrease">
    /// <para>
    /// InfoBox: Increase squads size according to KingdomUnitsGrowthIncrease active components
    /// </para>
    /// </param>
    public static ActionsBuilder CreateArmyFromLosses(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMapPoint.Reference> location,
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>KingdomMoraleFlagChapter3Siege</term><description>0b405fd736f54c05b65aaee855ad585e</description></item>
    /// <item><term>KingdomMoraleFlagChapter5Siege</term><description>97f654fb595348b4a492ef17baf2af04</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="army">
    /// <para>
    /// Blueprint of type BlueprintArmyPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="location">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="armyLeader">
    /// <para>
    /// Blueprint of type BlueprintArmyLeader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="hasNoReward">
    /// <para>
    /// InfoBox: No Exp will be received on defeating garrison and garrison will not hide armies on GM behind it.
    /// </para>
    /// </param>
    public static ActionsBuilder CreateGarrison(
        this ActionsBuilder builder,
        Blueprint<BlueprintArmyPreset.Reference> army,
        Blueprint<BlueprintGlobalMapPoint.Reference> location,
        Blueprint<ArmyLeader.Reference>? armyLeader = null,
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GlobalSpellAeonTimeManipulation</term><description>669323b91db4ebc44831d514970e75a8</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GlobalSpellAmbush</term><description>8298c3d4c66d47a78fde4b7210cfe3d8</description></item>
    /// <item><term>GlobalSpellAngelStormOfJustice</term><description>783a66393159b534680c91bf60a374ff</description></item>
    /// <item><term>GlobalSpellMightyTempest</term><description>9e67c7f0586d6754cbf8c47ab0bc9705</description></item>
    /// </list>
    /// </remarks>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter03</term><description>15e0048c7daf0ac4999c2313b58df0e3</description></item>
    /// <item><term>FlagAngel5BestowProtection</term><description>c70913a7b8494fa3b1f0ce2fc701718a</description></item>
    /// <item><term>FlagLich4AnimateDead</term><description>47ed8cdcd0b44771afb5a2d32eb91ad4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="spell">
    /// <para>
    /// Blueprint of type BlueprintGlobalMagicSpell. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder GainGlobalMagicSpell(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMagicSpell.Reference> spell)
    {
      var element = ElementTool.Create<GainGlobalMagicSpell>();
      element.m_Spell = spell?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionAddBPRandom"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Amber_ReforgeProject</term><description>3b4b2c6077fab6741b63b55a274bf18c</description></item>
    /// <item><term>KnightsEmblemShortswordProject_Enchanting</term><description>739656c82b61413b92f8293b949420d9</description></item>
    /// <item><term>ZeorisDaggerRingProject_Enchanting</term><description>0dc3a4e036064970857b3c3e296a7d94</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="includeInEventStats">
    /// <para>
    /// Tooltip: When true, stat changes are stored in current event resolution history
    /// </para>
    /// </param>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon2FireElementals</term><description>63364fac363349a99dd7fe96ca86dc7c</description></item>
    /// <item><term>Diplomacy8Buildings</term><description>3725744cd17f464d8f2bf31a480e3045</description></item>
    /// <item><term>Trickster5ThugPaladin</term><description>e83a6a99081d467fb56d8afe1de6a4d5</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buff">
    /// <para>
    /// Blueprint of type BlueprintKingdomBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="applyToRegion">
    /// <para>
    /// InfoBox: If true applies buff to region from Region field or (if it&amp;apos;s null) to region for context (settlement, event or parent buff)
    /// </para>
    /// </param>
    /// <param name="region">
    /// <para>
    /// Blueprint of type BlueprintRegion. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder KingdomActionAddBuff(
        this ActionsBuilder builder,
        Blueprint<BlueprintKingdomBuffReference> buff,
        bool? applyToRegion = null,
        bool? copyToAdjacentRegions = null,
        int? overrideDuration = null,
        Blueprint<BlueprintRegionReference>? region = null)
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
    /// Adds <see cref="KingdomActionAddRandomBuff"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FlagTrickster3Economy</term><description>4b833c6fcdfa47918927d80edf7ef9ae</description></item>
    /// <item><term>FlagTrickster3Everything</term><description>7886a2f17fed4514ba7d2a53730f38bf</description></item>
    /// <item><term>FlagTrickster6Equipment</term><description>f0a1778be6af47c58e32e125810ea3cd</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buffs">
    /// <para>
    /// Blueprint of type BlueprintKingdomBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder KingdomActionAddRandomBuff(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintKingdomBuffReference>>? buffs = null,
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
    /// Adds <see cref="KingdomActionConquerRegion"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter03</term><description>15e0048c7daf0ac4999c2313b58df0e3</description></item>
    /// <item><term>KingdomMoraleFlagChapter3Regions</term><description>d04ff8f15c034f56bcfbad952a74bdb3</description></item>
    /// <item><term>KingdomMoraleFlagChapter5Regions</term><description>b01624ee06444738964b678259f31a20</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="region">
    /// <para>
    /// Blueprint of type BlueprintRegion. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder KingdomActionConquerRegion(
        this ActionsBuilder builder,
        Blueprint<BlueprintRegionReference> region)
    {
      var element = ElementTool.Create<KingdomActionConquerRegion>();
      element.m_Region = region?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionFillSettlement"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter03</term><description>15e0048c7daf0ac4999c2313b58df0e3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buildList">
    /// <para>
    /// Blueprint of type SettlementBuildList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="specificSettlement">
    /// <para>
    /// Blueprint of type BlueprintSettlement. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder KingdomActionFillSettlement(
        this ActionsBuilder builder,
        Blueprint<SettlementBuildListReference> buildList,
        Blueprint<BlueprintSettlement.Reference> specificSettlement)
    {
      var element = ElementTool.Create<KingdomActionFillSettlement>();
      element.m_BuildList = buildList?.Reference;
      element.m_SpecificSettlement = specificSettlement?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionFoundSettlement"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter03</term><description>15e0048c7daf0ac4999c2313b58df0e3</description></item>
    /// <item><term>CreateSettlementIncubusLair</term><description>2d5d98015300319409a9b79f4bc31e0e</description></item>
    /// <item><term>KingdomMoraleFlagChapter5Regions</term><description>b01624ee06444738964b678259f31a20</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="location">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="settlement">
    /// <para>
    /// Blueprint of type BlueprintSettlement. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder KingdomActionFoundSettlement(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMapPoint.Reference> location,
        Blueprint<BlueprintSettlement.Reference> settlement)
    {
      var element = ElementTool.Create<KingdomActionFoundSettlement>();
      element.m_Location = location?.Reference;
      element.m_Settlement = settlement?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionGainLeaderExperience"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Event64SecurityTraining</term><description>67217afddedc419481c7cb58b5379c6d</description></item>
    /// <item><term>Leadership8LeaderEXP</term><description>374dcca26ef2441bab95ceab14350428</description></item>
    /// <item><term>MythicDragon_RankUp01_Option02</term><description>aa700189d693a4c4c86693e5ec5d5b69</description></item>
    /// </list>
    /// </remarks>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GlobalSpellTeleportParty</term><description>8accb3511e0b4eeb822c5867a3dde1e1</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="spell">
    /// <para>
    /// Blueprint of type BlueprintGlobalMagicSpell. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder ManuallySetGlobalSpellCooldown(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMagicSpell.Reference> spell)
    {
      var element = ElementTool.Create<ManuallySetGlobalSpellCooldown>();
      element.m_Spell = spell?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="OpenTeleportationInterface"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GlobalSpellTeleportParty</term><description>8accb3511e0b4eeb822c5867a3dde1e1</description></item>
    /// </list>
    /// </remarks>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FlagAngel3Justice</term><description>3c3c9b5f8cb74663bda5e092c1f6ecc8</description></item>
    /// <item><term>FlagLich4AnimateDead</term><description>47ed8cdcd0b44771afb5a2d32eb91ad4</description></item>
    /// <item><term>GlobalSpellRelicKeeperGain</term><description>e70e64a830064439b0c22032a8a3c6ac</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="spell">
    /// <para>
    /// Blueprint of type BlueprintGlobalMagicSpell. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder RemoveGlobalMagicSpell(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMagicSpell.Reference> spell)
    {
      var element = ElementTool.Create<RemoveGlobalMagicSpell>();
      element.m_Spell = spell?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveUnitsByExp"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GlobalSpellLegendBanish</term><description>273ad88db15c06241849f76f6623099d</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GlobalSpellReplenish</term><description>e3a0fc7210f02f34daff21f6df42d246</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GlobalSpellCallToArms</term><description>68f1485a4b5dd7348bbe54c370136490</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GlobalSpellAngelSummonHeavenlyHost</term><description>5425f939e31478e4ca8b00ff6ca161c9</description></item>
    /// <item><term>GlobalSpellLichAnimateDead</term><description>a8207b313ed41ad408c96fff5edfe85f</description></item>
    /// <item><term>GlobalSpellLocustSummonSwarm</term><description>ce50c4fe24bdab14b823d76d4c42352b</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder SummonRandomGroup(this ActionsBuilder builder, params SummonRandomGroup.RandomGroup[] randomGroups)
    {
      var element = ElementTool.Create<SummonRandomGroup>();
      builder.Validate(randomGroups);
      element.m_RandomGroups = randomGroups;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddGrowthBonus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Leadership4FreeRecruitsEffect</term><description>f05a75fb26224d04bf376466220c232d</description></item>
    /// <item><term>Leadership4FreeRecruitsSmallEffect</term><description>ced9fd0a41aa48c7920fbc563b305faa</description></item>
    /// <item><term>Leadership4RecruitsForMoraleEffect</term><description>7c200175267a495b91215d91cba81888</description></item>
    /// </list>
    /// </remarks>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter02</term><description>0e20d73ea0da6a94d94a6b42035a1ce0</description></item>
    /// <item><term>FlagMilitary3AxeThrowers</term><description>07ee057cca794cf286be5adcf3fcbbc8</description></item>
    /// <item><term>Obj3B_TalkWithSull</term><description>5c32d5a46133ae34e9aa8aa1a9efbcbf</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="unit">
    /// <para>
    /// InfoBox: Amount to hire is setup in BlueprintUnit -&amp;gt; ArmyUnitComponent -&amp;gt; MercenariesBaseGrowths
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder AddMercenaryToPool(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnitReference>? unit = null,
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0003</term><description>8df6da6c3db0b744baeca86c24fddc03</description></item>
    /// <item><term>Event33ProfitablePurchase</term><description>cd3ffefdcd5d4a4e87fe7012f2aa7b92</description></item>
    /// <item><term>ZachariusUndeadUpgrade_level2</term><description>ce15dfd148df49df892eda52eb46cf34</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="armyUnits">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="features">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder AddTacticalArmyFeature(
        this ActionsBuilder builder,
        ArmyProperties? armyTag = null,
        List<Blueprint<BlueprintUnitReference>>? armyUnits = null,
        bool? byTag = null,
        bool? byUnits = null,
        ArmyFaction? faction = null,
        List<Blueprint<BlueprintFeatureReference>>? features = null,
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyAdditionalActionAfterKill</term><description>d0781dcef7f2a3a4e896a5b107123933</description></item>
    /// <item><term>TacticianRank1</term><description>cea098cc8ed24e828ee2576185f8ba0b</description></item>
    /// <item><term>TacticianRank3</term><description>5234a68ecf404794a3aee34c9416aecb</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="inCurrentTurn">
    /// <para>
    /// InfoBox: Can&amp;apos;t be used on combat setup. Otherwise make sure that context target is not null
    /// </para>
    /// </param>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>RangerObstacleAbility</term><description>f23bb74fff45484cbc09d54152a9f3f4</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BuildingBreweryClerics</term><description>30e7244cab4c4acd9279c734d985ff93</description></item>
    /// <item><term>BuildingBreweryWizards</term><description>6da87777fa6f4a36870d473d93a75fbf</description></item>
    /// <item><term>FlagLegend1Morale</term><description>ebda3d4d2b39416dbec3dc4a7bbd4760</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="maxValueDelta">
    /// <para>
    /// InfoBox: Can be negative
    /// </para>
    /// </param>
    public static ActionsBuilder ChangeKingdomMoraleMaximum(
        this ActionsBuilder builder,
        int? maxValueDelta = null)
    {
      var element = ElementTool.Create<ChangeKingdomMoraleMaximum>();
      element.m_MaxValueDelta = maxValueDelta ?? element.m_MaxValueDelta;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionByArmyLeader"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyAeon3Spikes</term><description>249ad28266fc4d579e21c626bc198ea2</description></item>
    /// <item><term>FighterPoisonousStrikeBuff2</term><description>6f31c37e011f4481bd3e8be1e70b6336</description></item>
    /// <item><term>FighterPoisonousStrikeBuff3</term><description>ea1b9aef227b4fceb15e936668cd0f56</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder ByArmyLeader(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null)
    {
      var element = ElementTool.Create<ContextActionByArmyLeader>();
      element.Actions = actions?.Build() ?? element.Actions;
      if (element.Actions is null)
      {
        element.Actions = Utils.Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRestoreLeaderAction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>EmergencyOrderBuff</term><description>8f95988103a545c2900adb3bfc4ba64f</description></item>
    /// <item><term>TwincastBuff</term><description>f868a773106e4e78a777d850acd38ee8</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder RestoreLeaderAction(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionRestoreLeaderAction>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionStopUnit"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PlaceBanner</term><description>8960de0453ba3b54880ec5a4458a76e3</description></item>
    /// <item><term>RangerPitArea</term><description>37cf4546ecbf4aee9ab28697c6e0e86a</description></item>
    /// <item><term>RangerSpringTrapArea</term><description>7feffc237b734814875497233e5d00b5</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder StopUnit(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionStopUnit>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionTacticalCombatHealTarget"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Azata1SongOfSeasonsAbilityArea</term><description>257a806b4d2b452d9fa9f603d0d1c8a2</description></item>
    /// <item><term>RitualCureWoundsAbility</term><description>cfa06dceb9a886b46b01fa62024b748a</description></item>
    /// <item><term>RitualJudgementDayAbility</term><description>814a31b50da1434aa9f8622b87157fda</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="rollsCount">
    /// <para>
    /// InfoBox: Result = RollsCount * (5 + Power * Power)d(DiceType)
    /// </para>
    /// </param>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter03</term><description>15e0048c7daf0ac4999c2313b58df0e3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="unit">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder DecreaseRecruitsGrowth(
        this ActionsBuilder builder,
        int? count = null,
        Blueprint<BlueprintUnitReference>? unit = null)
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
    /// Adds <see cref="EnterKingdomInterface"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Area 51_CheckPassedActions</term><description>e8876f8698f9bf24785b0d2af72b72c0</description></item>
    /// <item><term>CapitalKingdomButton_Actions</term><description>cd8bf939dd1348244948e058c1e10c5d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="returnPoint">
    /// <para>
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder EnterKingdomInterface(
        this ActionsBuilder builder,
        Blueprint<BlueprintAreaEnterPointReference>? returnPoint = null,
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0004</term><description>11d0c42fc7fc4fe98ac31b1561c30364</description></item>
    /// <item><term>Answer_0023</term><description>f2742a2a32a612549aa1ad3160c50e16</description></item>
    /// <item><term>MythicDevil_RankUp02_Option03</term><description>304b0e0aa6714d4499123b0c3c4ba729</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="convertCoefficient">
    /// <para>
    /// InfoBox: Current amount in squads and recruit pools would be multiplied by this coefficient
    /// </para>
    /// </param>
    /// <param name="newGrowth">
    /// <para>
    /// InfoBox: New-old growth serves as parameters to calculate growth change coefficient: GrowthCoefficient = NewGrowth / OldGrowth Weekly growth = `current weekly growth` * GrowthCoefficient Note that this only affect base growth (without morale and buidlings). Result and values can be zero (means zero base growth)
    /// </para>
    /// </param>
    /// <param name="newUnit">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="oldUnit">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder ExchangeRecruits(
        this ActionsBuilder builder,
        float? convertCoefficient = null,
        int? newGrowth = null,
        Blueprint<BlueprintUnitReference>? newUnit = null,
        int? oldGrowth = null,
        Blueprint<BlueprintUnitReference>? oldUnit = null)
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
    /// Adds <see cref="ForceDayTime"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>UlbrigRomance_GardenGods_LightState01</term><description>12993a3773c44833bbaaf3f91a3687b9</description></item>
    /// <item><term>UlbrigRomance_GardenGods_LightState02</term><description>da1d94ab114f4c78985ca7d5b7f0fd09</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder ForceDayTime(
        this ActionsBuilder builder,
        TimeOfDay? dayTime = null,
        bool? hasOverride = null,
        bool? reloadStaticIfNeeded = null)
    {
      var element = ElementTool.Create<ForceDayTime>();
      element.DayTime = dayTime ?? element.DayTime;
      element.HasOverride = hasOverride ?? element.HasOverride;
      element.ReloadStaticIfNeeded = reloadStaticIfNeeded ?? element.ReloadStaticIfNeeded;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IncreaseRecruitsGrowth"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter02</term><description>0e20d73ea0da6a94d94a6b42035a1ce0</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="unit">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder IncreaseRecruitsGrowth(
        this ActionsBuilder builder,
        int? count = null,
        Blueprint<BlueprintUnitReference>? unit = null)
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter02</term><description>0e20d73ea0da6a94d94a6b42035a1ce0</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="unit">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder IncreaseRecruitsPool(
        this ActionsBuilder builder,
        int? count = null,
        Blueprint<BlueprintUnitReference>? unit = null)
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-250459</term><description>6a8a9838d55847cf8660de463fb26659</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>KingdomMoraleFlagChapter3Siege</term><description>0b405fd736f54c05b65aaee855ad585e</description></item>
    /// <item><term>KingdomMoraleFlagChapter5Siege</term><description>97f654fb595348b4a492ef17baf2af04</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder KingdomActionChangeToAutoCrusade(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionChangeToAutoCrusade>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionDestroyAllSettlements"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FlagLocust</term><description>328fc139938f4582a605917a729169f3</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder KingdomActionDestroyAllSettlements(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionDestroyAllSettlements>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionDisable"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter03</term><description>15e0048c7daf0ac4999c2313b58df0e3</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder KingdomActionDisable(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionDisable>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionEnable"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter05</term><description>5b01aa690202e584888dfc600a4aac0a</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder KingdomActionEnable(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionEnable>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionFinishRandomBuilding"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FlagTrickster3Economy</term><description>4b833c6fcdfa47918927d80edf7ef9ae</description></item>
    /// <item><term>FlagTrickster3Everything</term><description>7886a2f17fed4514ba7d2a53730f38bf</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder KingdomActionFinishRandomBuilding(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionFinishRandomBuilding>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionFoundKingdom"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter02</term><description>0e20d73ea0da6a94d94a6b42035a1ce0</description></item>
    /// <item><term>Chapter03</term><description>15e0048c7daf0ac4999c2313b58df0e3</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder KingdomActionFoundKingdom(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionFoundKingdom>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionGetPartyGoldByUnitsCount"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FlagTrickster1Money</term><description>6c97784129e5492fa08496f2d4139f22</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="coefficient">
    /// <para>
    /// InfoBox: Formula: Gold to add = GoldPerUnit * (All units count) * Coefficient
    /// </para>
    /// </param>
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
    /// Adds <see cref="KingdomActionGetResourcesPercent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Logistics6Accumulation</term><description>86e157a49e15496a9deac395011061be</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="maxResourceCountGained">
    /// <para>
    /// InfoBox: Non-positive value means no limits
    /// </para>
    /// </param>
    /// <param name="resourceType">
    /// <para>
    /// InfoBox: None - to get all resources
    /// </para>
    /// </param>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GiftFromStranger_Event</term><description>6c8020c5f9f44c4f9c99d6b10d6d3238</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder KingdomActionGiveLoot(this ActionsBuilder builder, params LootEntry[] loot)
    {
      var element = ElementTool.Create<KingdomActionGiveLoot>();
      builder.Validate(loot);
      element.Loot = loot;
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>UpgradeToCity</term><description>ecb59fbdd3354dfab7ba944ec79fabea</description></item>
    /// <item><term>UpgradeToTown</term><description>67dc50f3f87746528d66302e9a401975</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="specificSettlement">
    /// <para>
    /// Blueprint of type BlueprintSettlement. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder KingdomActionImproveSettlement(
        this ActionsBuilder builder,
        Blueprint<BlueprintSettlement.Reference>? specificSettlement = null,
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon2FireElementals</term><description>63364fac363349a99dd7fe96ca86dc7c</description></item>
    /// <item><term>BaphometFireRobeProject_Enchanting</term><description>06e32ef321fa400698013b3b80da5fc8</description></item>
    /// <item><term>ZeorisDaggerRingProject_Enchanting</term><description>0dc3a4e036064970857b3c3e296a7d94</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder KingdomActionImproveStat(
        this ActionsBuilder builder,
        KingdomStats.Type? statType = null)
    {
      var element = ElementTool.Create<KingdomActionImproveStat>();
      element.StatType = statType ?? element.StatType;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionModifyStats"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0054</term><description>d6e30610613f65b4997c592f622f80f1</description></item>
    /// <item><term>CrusadeEvent63</term><description>7ef34faced78457a97fa47de371d7c18</description></item>
    /// <item><term>SarcorianElders_Ring</term><description>1375b1d6ec7842668d5c340c6fd77259</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="includeInEventStats">
    /// <para>
    /// Tooltip: When true, stat changes are stored in current event resolution history
    /// </para>
    /// </param>
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
    /// Adds <see cref="KingdomActionNextChapter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter03</term><description>15e0048c7daf0ac4999c2313b58df0e3</description></item>
    /// <item><term>Chapter05</term><description>5b01aa690202e584888dfc600a4aac0a</description></item>
    /// <item><term>PF-218150</term><description>d7696062df7c4b948e1ce3e1b769fc9a</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder KingdomActionNextChapter(
        this ActionsBuilder builder,
        int? chapterNumber = null)
    {
      var element = ElementTool.Create<KingdomActionNextChapter>();
      element.ChapterNumber = chapterNumber ?? element.ChapterNumber;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionRemoveAllLeaders"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FlagLocust</term><description>328fc139938f4582a605917a729169f3</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder KingdomActionRemoveAllLeaders(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionRemoveAllLeaders>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionRemoveBuff"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter02</term><description>0e20d73ea0da6a94d94a6b42035a1ce0</description></item>
    /// <item><term>MythicAzata_RankUp03_Option01</term><description>6ba3c9a71e2676e44af20c8c9449db43</description></item>
    /// <item><term>QuatermasterErrandTracker_buff</term><description>1ed15e9a59ec4524a8f301a20c88d20f</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="blueprint">
    /// <para>
    /// Blueprint of type BlueprintKingdomBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="region">
    /// <para>
    /// Blueprint of type BlueprintRegion. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder KingdomActionRemoveBuff(
        this ActionsBuilder builder,
        bool? allBuffs = null,
        bool? applyToRegion = null,
        Blueprint<BlueprintKingdomBuffReference>? blueprint = null,
        Blueprint<BlueprintRegionReference>? region = null)
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Add4_GotoMoltenScar</term><description>f6694c696284e2046b0f064f83c320c2</description></item>
    /// <item><term>KTC_LichRankUp_1_Notification</term><description>34a1fb6d575b3cd458fd6ce51c89491c</description></item>
    /// <item><term>WenduagKTC_WenduagComeNeathholm_Notification</term><description>2cd5a9a5a2531f645acdd5f72ef3218e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="eventBlueprint">
    /// <para>
    /// Blueprint of type BlueprintKingdomEventBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder KingdomActionRemoveEvent(
        this ActionsBuilder builder,
        bool? allIfMultiple = null,
        bool? cancelIfInProgress = null,
        Blueprint<BlueprintKingdomEventBaseReference>? eventBlueprint = null)
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
    /// Adds <see cref="KingdomActionResolveCrusadeEvent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AutoKingdomProjectsControllerCh3</term><description>b31b96dd34f8415382c8ec26787364d3</description></item>
    /// <item><term>AutoKingdomProjectsControllerCh5</term><description>cc52c843d1564064aa892f78f1e81e09</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="eventBlueprint">
    /// <para>
    /// Blueprint of type BlueprintCrusadeEvent. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder KingdomActionResolveCrusadeEvent(
        this ActionsBuilder builder,
        Blueprint<BlueprintCrusadeEvent.Reference>? eventBlueprint = null,
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Daeran_Q3_KTC_LiotrSetsTrap</term><description>2d5236c9c51ac1c4aa2d1591e4bc6634</description></item>
    /// <item><term>KTC_LocustRankUp_3</term><description>80ce567699864e45b5258c6f1fba89ca</description></item>
    /// <item><term>Timer_Before_KTC_TeachMeHowToBreathe</term><description>4edd42f27b29cb747b8025b6c608fb29</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="eventBlueprint">
    /// <para>
    /// Blueprint of type BlueprintKingdomEvent. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder KingdomActionResolveEvent(
        this ActionsBuilder builder,
        Alignment? alignment = null,
        Blueprint<BlueprintKingdomEventReference>? eventBlueprint = null,
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonAutoKingdomDelay</term><description>7e50ed6c545e4fc486680348003de3cd</description></item>
    /// <item><term>PF-233878</term><description>156061427b524196bf93123488e66c42</description></item>
    /// <item><term>TricksterAutoKingdomDelay</term><description>c70a8c4b5c2c4f69be373b2d05640b3b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="eventBlueprint">
    /// <para>
    /// Blueprint of type BlueprintKingdomProject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder KingdomActionResolveProject(
        this ActionsBuilder builder,
        Blueprint<BlueprintKingdomProjectReference>? eventBlueprint = null)
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
    /// Adds <see cref="KingdomActionSetNotVisible"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FlagLocust</term><description>328fc139938f4582a605917a729169f3</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder KingdomActionSetNotVisible(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionSetNotVisible>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionSetVisible"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter03</term><description>15e0048c7daf0ac4999c2313b58df0e3</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder KingdomActionSetVisible(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionSetVisible>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionSpawnRandomArmy"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Leadership8BigArmyDecreaseMorale</term><description>8d8138b95569410bba903e1355da0d9d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="armies">
    /// <para>
    /// Blueprint of type BlueprintArmyPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="locations">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder KingdomActionSpawnRandomArmy(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintArmyPresetReference>>? armies = null,
        ArmyFaction? faction = null,
        List<Blueprint<BlueprintGlobalMapPoint.Reference>>? locations = null)
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Add3_SearchMoltenScar</term><description>39a11378f06fff740b8211686247d943</description></item>
    /// <item><term>KTC_Fail_Notification</term><description>93e8ee34311b5e64788bcd5c53bfed0f</description></item>
    /// <item><term>ZeorisDaggerRingProject_Enchanting</term><description>0dc3a4e036064970857b3c3e296a7d94</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="eventValue">
    /// <para>
    /// Blueprint of type BlueprintKingdomEventBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="region">
    /// <para>
    /// Blueprint of type BlueprintRegion. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder KingdomActionStartEvent(
        this ActionsBuilder builder,
        bool? checkTriggerImmediately = null,
        bool? checkTriggerOnStart = null,
        int? delayDays = null,
        Blueprint<BlueprintKingdomEventBaseReference>? eventValue = null,
        bool? randomRegion = null,
        Blueprint<BlueprintRegionReference>? region = null,
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Outskirts_Enter_Preset</term><description>7a43d75fcb44054448d7a182bc614874</description></item>
    /// <item><term>SouthNarlmarches_Enter_Preset</term><description>b7cf402555915ec489da07d87896d808</description></item>
    /// <item><term>Varnhold_Water_Enter_Preset</term><description>90c7f4a6e036db247bb0d460c025336c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="artisan">
    /// <para>
    /// Blueprint of type BlueprintKingdomArtisan. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder KingdomActionUnlockArtisan(
        this ActionsBuilder builder,
        Blueprint<BlueprintKingdomArtisanReference>? artisan = null)
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter02</term><description>0e20d73ea0da6a94d94a6b42035a1ce0</description></item>
    /// <item><term>Chapter03</term><description>15e0048c7daf0ac4999c2313b58df0e3</description></item>
    /// <item><term>Chapter05</term><description>5b01aa690202e584888dfc600a4aac0a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="newFlags">
    /// <para>
    /// Blueprint of type BlueprintKingdomMoraleFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder KingdomAddMoraleFlags(this ActionsBuilder builder, params Blueprint<BlueprintKingdomMoraleFlag.Reference>[] newFlags)
    {
      var element = ElementTool.Create<KingdomAddMoraleFlags>();
      element.m_NewFlags = newFlags.Select(bp => bp.Reference).ToArray();
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter02</term><description>0e20d73ea0da6a94d94a6b42035a1ce0</description></item>
    /// <item><term>KingdomMoraleFlagChapter3</term><description>244ac0d9e51646a485443bc3bc9a0df4</description></item>
    /// <item><term>MoraleFlagSiegeChapter5Controller_buff</term><description>30d599366a9e46fe992f9ca6fdf9365a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="increment">
    /// <para>
    /// InfoBox: Can be negative
    /// </para>
    /// </param>
    /// <param name="targetFlag">
    /// <para>
    /// Blueprint of type BlueprintKingdomMoraleFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder KingdomFlagIncrement(
        this ActionsBuilder builder,
        int? increment = null,
        Blueprint<BlueprintKingdomMoraleFlag.Reference>? targetFlag = null)
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Event14RansomFromTheMountainKings</term><description>782bec7bd7a3403ea18c2b5428529807</description></item>
    /// <item><term>Event73NorthernHunters</term><description>6096c97970834a02b6d76a59507d4951</description></item>
    /// <item><term>SarcorianElders_Ring</term><description>1375b1d6ec7842668d5c340c6fd77259</description></item>
    /// </list>
    /// </remarks>
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
    /// Adds <see cref="KingdomMoraleUpdateIncome"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-217801</term><description>31ce5bf15c194b2eac8695fa8b13105b</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder KingdomMoraleUpdateIncome(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomMoraleUpdateIncome>());
    }

    /// <summary>
    /// Adds <see cref="KingdomRemoveMoraleFlags"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter02</term><description>0e20d73ea0da6a94d94a6b42035a1ce0</description></item>
    /// <item><term>Chapter05</term><description>5b01aa690202e584888dfc600a4aac0a</description></item>
    /// <item><term>FlagLocust</term><description>328fc139938f4582a605917a729169f3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="flagsToRemove">
    /// <para>
    /// Blueprint of type BlueprintKingdomMoraleFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder KingdomRemoveMoraleFlags(this ActionsBuilder builder, params Blueprint<BlueprintKingdomMoraleFlag.Reference>[] flagsToRemove)
    {
      var element = ElementTool.Create<KingdomRemoveMoraleFlags>();
      element.m_FlagsToRemove = flagsToRemove.Select(bp => bp.Reference).ToArray();
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter03</term><description>15e0048c7daf0ac4999c2313b58df0e3</description></item>
    /// <item><term>KingdomMoraleFlagChapter3Siege</term><description>0b405fd736f54c05b65aaee855ad585e</description></item>
    /// <item><term>PF-236233</term><description>78ddb7dcceaf4dd5b6178807c258909c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="targetFlag">
    /// <para>
    /// Blueprint of type BlueprintKingdomMoraleFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder KingdomSetFlagState(
        this ActionsBuilder builder,
        int? maxDays = null,
        KingdomMoraleFlag.State? state = null,
        Blueprint<BlueprintKingdomMoraleFlag.Reference>? targetFlag = null)
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0016</term><description>e2e87e30b89549f43aa480d406920971</description></item>
    /// <item><term>Cue_0009</term><description>ec96aeab93d54e56941585e208f78c1e</description></item>
    /// <item><term>Objective_0001</term><description>f995e2e22a4d41449b90bde8b60b05a5</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="armyLeader">
    /// <para>
    /// Blueprint of type BlueprintArmyLeader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder RecruiteArmyLeader(
        this ActionsBuilder builder,
        Blueprint<ArmyLeader.Reference>? armyLeader = null)
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter05</term><description>5b01aa690202e584888dfc600a4aac0a</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter05</term><description>5b01aa690202e584888dfc600a4aac0a</description></item>
    /// <item><term>CrusadeEvent42</term><description>efee1f0851084652a0f42b38557ef8e1</description></item>
    /// <item><term>CrusadeEvent86</term><description>30a96e0fab3d4db59203180884104d7b</description></item>
    /// </list>
    /// </remarks>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter03</term><description>15e0048c7daf0ac4999c2313b58df0e3</description></item>
    /// <item><term>PF-327938</term><description>7d2c63b906d847008193e873e265af5e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="armyPreset">
    /// <para>
    /// Blueprint of type BlueprintArmyPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder RemoveDemonArmies(
        this ActionsBuilder builder,
        Blueprint<BlueprintArmyPresetReference>? armyPreset = null,
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>RemoveArmiesFromGlobalmap</term><description>d10fae0930c412c4290575a98e3d17b7</description></item>
    /// <item><term>WorldWoundGMChapter3NearDrezenPreset</term><description>6610566be22fe264eb3d652bfb6dfedb</description></item>
    /// <item><term>WorldWoundGMChapter5_SE_Test_Lann</term><description>810e4c69f3154066ba977654614b4573</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="location">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder RemoveGarrison(
        this ActionsBuilder builder,
        bool? handleAsGarrisonDefeated = null,
        Blueprint<BlueprintGlobalMapPoint.Reference>? location = null)
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter05</term><description>5b01aa690202e584888dfc600a4aac0a</description></item>
    /// <item><term>FlagAzata3Priest</term><description>4be4f82560f547b2b7e30663980bc861</description></item>
    /// <item><term>RegillNotInParty_KickedOut</term><description>2b2cfaa1727070c43b10729920112730</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="unit">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder RemoveMercenaryFromPool(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnitReference>? unit = null)
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
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/RemoveUnitFromArmy
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter05</term><description>5b01aa690202e584888dfc600a4aac0a</description></item>
    /// <item><term>Cue_0051</term><description>9d75b86f23a4ac24ab1ccd8a74859fc1</description></item>
    /// <item><term>WorldWoundGMChapter5_SE_Test_Lann</term><description>810e4c69f3154066ba977654614b4573</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="experience">
    /// <para>
    /// Tooltip: Total experience to remove from the armies. If it exceeds the total price of the army -- the whole army will be removed.
    /// </para>
    /// </param>
    /// <param name="percentage">
    /// <para>
    /// Tooltip: Total experience percentage to remove from the armies. 100% will remove all units, 50% will halven them, 0% will do nothing.
    /// </para>
    /// </param>
    /// <param name="unitExperienceMaximum">
    /// <para>
    /// Tooltip: Only units cheaper than this threshold will be considered for removal.
    /// </para>
    /// </param>
    /// <param name="unitExperienceMinimum">
    /// <para>
    /// Tooltip: Only units pricier than this threshold will be considered for removal.
    /// </para>
    /// </param>
    /// <param name="unitTagBlacklist">
    /// <para>
    /// Tooltip: If set then only units without these tags will be considered for removal.
    /// </para>
    /// </param>
    /// <param name="unitTagWhitelist">
    /// <para>
    /// Tooltip: If set then only units with any of these tags will be considered for removal.
    /// </para>
    /// </param>
    /// <param name="unitToRemove">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
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
        Blueprint<BlueprintUnitReference>? unitToRemove = null)
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0009</term><description>717df11c29382d54cbe1e12f29349cb9</description></item>
    /// <item><term>MythicDevil_RankUp03_Option03</term><description>28d4f7db0536ac84aa354f345ad19932</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="newBuilding">
    /// <para>
    /// Blueprint of type BlueprintSettlementBuilding. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="oldBuilding">
    /// <para>
    /// Blueprint of type BlueprintSettlementBuilding. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder ReplaceBuildings(
        this ActionsBuilder builder,
        Blueprint<BlueprintSettlementBuildingReference>? newBuilding = null,
        Blueprint<BlueprintSettlementBuildingReference>? oldBuilding = null)
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter02</term><description>0e20d73ea0da6a94d94a6b42035a1ce0</description></item>
    /// <item><term>DrezenCapital_Chapter05_Coronation</term><description>4881f9b9131249dca002482ef3e915af</description></item>
    /// <item><term>SeelahWarcamp_Chapter05_LegendBegins</term><description>149b7c31c9944d828d9ab4867f58ca47</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="point">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder SetRecruitPoint(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMapPoint.Reference>? point = null)
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter02</term><description>0e20d73ea0da6a94d94a6b42035a1ce0</description></item>
    /// <item><term>GlobalmapBeforeLostChapel</term><description>739f6806ac4123b4389eea950c5af95b</description></item>
    /// <item><term>WarCamp_CouncilKTFromGMTest_Preset</term><description>89d4e2fc3c314b548b0b0bf41349670c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="location">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder SetWarCampLocation(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMapPoint.Reference>? location = null)
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyManaWhenHitFeature</term><description>d34526e42698470096f1d4ba2ae6651f</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GlobalSpellMassTeleportation</term><description>79cb4ea3fcb3a7a4c8a1055014f3bd0d</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder TeleportArmyAction(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<TeleportArmyAction>());
    }

    /// <summary>
    /// Adds <see cref="UnlockUnitsGrowth"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0006</term><description>b515734110d84de6af4c3577f412b4aa</description></item>
    /// <item><term>Answer_0032</term><description>11a461c5f93e9c04ca0e5b5d70dc8566</description></item>
    /// <item><term>Chapter05</term><description>5b01aa690202e584888dfc600a4aac0a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="unit">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder UnlockUnitsGrowth(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnitReference>? unit = null)
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
