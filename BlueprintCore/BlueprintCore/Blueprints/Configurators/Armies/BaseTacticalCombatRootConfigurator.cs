//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Armies.TacticalCombat.Blueprints;
using Kingmaker.Armies.TacticalCombat.Brain;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.Utility;
using Owlcat.Runtime.Core.Math;
using System;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
    /// <summary>
    /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintTacticalCombatRoot"/>.
    /// </summary>
    /// <inheritdoc/>
    public abstract class BaseTacticalCombatRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintTacticalCombatRoot
    where TBuilder : BaseTacticalCombatRootConfigurator<T, TBuilder>
  {
    protected BaseTacticalCombatRootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_ProbabilitySampler"/>
    /// </summary>
    public TBuilder SetProbabilitySampler(ProbabilityCurveSampler probabilitySampler)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(probabilitySampler);
          bp.m_ProbabilitySampler = probabilitySampler;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatRoot.m_ProbabilitySampler"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyProbabilitySampler(Action<ProbabilityCurveSampler> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ProbabilitySampler is null) { return; }
          action.Invoke(bp.m_ProbabilitySampler);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_CrusadersFaction"/>
    /// </summary>
    ///
    /// <param name="crusadersFaction">
    /// <para>
    /// Blueprint of type BlueprintFaction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetCrusadersFaction(Blueprint<BlueprintFactionReference> crusadersFaction)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CrusadersFaction = crusadersFaction?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatRoot.m_CrusadersFaction"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCrusadersFaction(Action<BlueprintFactionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CrusadersFaction is null) { return; }
          action.Invoke(bp.m_CrusadersFaction);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_DemonsFaction"/>
    /// </summary>
    ///
    /// <param name="demonsFaction">
    /// <para>
    /// Blueprint of type BlueprintFaction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetDemonsFaction(Blueprint<BlueprintFactionReference> demonsFaction)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DemonsFaction = demonsFaction?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatRoot.m_DemonsFaction"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDemonsFaction(Action<BlueprintFactionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DemonsFaction is null) { return; }
          action.Invoke(bp.m_DemonsFaction);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_DefaultBrain"/>
    /// </summary>
    ///
    /// <param name="defaultBrain">
    /// <para>
    /// Blueprint of type BlueprintTacticalCombatBrain. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetDefaultBrain(Blueprint<BlueprintTacticalCombatBrain.Reference> defaultBrain)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DefaultBrain = defaultBrain?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatRoot.m_DefaultBrain"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDefaultBrain(Action<BlueprintTacticalCombatBrain.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DefaultBrain is null) { return; }
          action.Invoke(bp.m_DefaultBrain);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_DefaultLeaderBrain"/>
    /// </summary>
    ///
    /// <param name="defaultLeaderBrain">
    /// <para>
    /// Blueprint of type BlueprintTacticalCombatBrain. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetDefaultLeaderBrain(Blueprint<BlueprintTacticalCombatBrain.Reference> defaultLeaderBrain)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DefaultLeaderBrain = defaultLeaderBrain?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatRoot.m_DefaultLeaderBrain"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDefaultLeaderBrain(Action<BlueprintTacticalCombatBrain.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DefaultLeaderBrain is null) { return; }
          action.Invoke(bp.m_DefaultLeaderBrain);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_AiSpellCastWeight"/>
    /// </summary>
    public TBuilder SetAiSpellCastWeight(float aiSpellCastWeight)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AiSpellCastWeight = aiSpellCastWeight;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_AiCanUseRituals"/>
    /// </summary>
    public TBuilder SetAiCanUseRituals(bool aiCanUseRituals = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AiCanUseRituals = aiCanUseRituals;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_DelayBetweenTurns"/>
    /// </summary>
    public TBuilder SetDelayBetweenTurns(float delayBetweenTurns)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DelayBetweenTurns = delayBetweenTurns;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_DelayAfterMoraleEffect"/>
    /// </summary>
    public TBuilder SetDelayAfterMoraleEffect(float delayAfterMoraleEffect)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DelayAfterMoraleEffect = delayAfterMoraleEffect;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_DelayBeforeBattleEnd"/>
    /// </summary>
    ///
    /// <param name="delayBeforeBattleEnd">
    /// <para>
    /// InfoBox: Time in seconds from last kill before result shown
    /// </para>
    /// </param>
    public TBuilder SetDelayBeforeBattleEnd(float delayBeforeBattleEnd)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DelayBeforeBattleEnd = delayBeforeBattleEnd;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_MaxTurnDuration"/>
    /// </summary>
    ///
    /// <param name="maxTurnDuration">
    /// <para>
    /// InfoBox: Time in seconds before assert
    /// </para>
    /// </param>
    public TBuilder SetMaxTurnDuration(float maxTurnDuration)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MaxTurnDuration = maxTurnDuration;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_MoveSpeed"/>
    /// </summary>
    public TBuilder SetMoveSpeed(int moveSpeed)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MoveSpeed = moveSpeed;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_MaxSquadsCount"/>
    /// </summary>
    public TBuilder SetMaxSquadsCount(int maxSquadsCount)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MaxSquadsCount = maxSquadsCount;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_BuffPrefix"/>
    /// </summary>
    ///
    /// <param name="buffPrefix">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetBuffPrefix(LocalString buffPrefix)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BuffPrefix = buffPrefix?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatRoot.m_BuffPrefix"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBuffPrefix(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BuffPrefix is null) { return; }
          action.Invoke(bp.m_BuffPrefix);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_ArmyLossesCoefOnRetreat"/>
    /// </summary>
    public TBuilder SetArmyLossesCoefOnRetreat(float armyLossesCoefOnRetreat)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ArmyLossesCoefOnRetreat = armyLossesCoefOnRetreat;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_DiceRollResultsDistribution"/>
    /// </summary>
    public TBuilder SetDiceRollResultsDistribution(AnimationCurve diceRollResultsDistribution)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(diceRollResultsDistribution);
          bp.m_DiceRollResultsDistribution = diceRollResultsDistribution;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatRoot.m_DiceRollResultsDistribution"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDiceRollResultsDistribution(Action<AnimationCurve> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DiceRollResultsDistribution is null) { return; }
          action.Invoke(bp.m_DiceRollResultsDistribution);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_BannedUnitFacts"/>
    /// </summary>
    ///
    /// <param name="bannedUnitFacts">
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
    public TBuilder SetBannedUnitFacts(params Blueprint<BlueprintUnitFactReference>[] bannedUnitFacts)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BannedUnitFacts = bannedUnitFacts.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintTacticalCombatRoot.m_BannedUnitFacts"/>
    /// </summary>
    ///
    /// <param name="bannedUnitFacts">
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
    public TBuilder AddToBannedUnitFacts(params Blueprint<BlueprintUnitFactReference>[] bannedUnitFacts)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BannedUnitFacts = bp.m_BannedUnitFacts ?? new();
          bp.m_BannedUnitFacts.AddRange(bannedUnitFacts.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintTacticalCombatRoot.m_BannedUnitFacts"/>
    /// </summary>
    ///
    /// <param name="bannedUnitFacts">
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
    public TBuilder RemoveFromBannedUnitFacts(params Blueprint<BlueprintUnitFactReference>[] bannedUnitFacts)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BannedUnitFacts is null) { return; }
          bp.m_BannedUnitFacts = bp.m_BannedUnitFacts.Where(val => !bannedUnitFacts.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintTacticalCombatRoot.m_BannedUnitFacts"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromBannedUnitFacts(Func<BlueprintUnitFactReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BannedUnitFacts is null) { return; }
          bp.m_BannedUnitFacts = bp.m_BannedUnitFacts.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintTacticalCombatRoot.m_BannedUnitFacts"/>
    /// </summary>
    public TBuilder ClearBannedUnitFacts()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BannedUnitFacts = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatRoot.m_BannedUnitFacts"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyBannedUnitFacts(Action<BlueprintUnitFactReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BannedUnitFacts is null) { return; }
          bp.m_BannedUnitFacts.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_DefaultZone"/>
    /// </summary>
    public TBuilder SetDefaultZone(TacticalCombatAreaZone defaultZone)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DefaultZone = defaultZone;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_ZoneSettings"/>
    /// </summary>
    public TBuilder SetZoneSettings(params BlueprintTacticalCombatRoot.TacticalZoneSettings[] zoneSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(zoneSettings);
          bp.m_ZoneSettings = zoneSettings.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintTacticalCombatRoot.m_ZoneSettings"/>
    /// </summary>
    public TBuilder AddToZoneSettings(params BlueprintTacticalCombatRoot.TacticalZoneSettings[] zoneSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ZoneSettings = bp.m_ZoneSettings ?? new();
          bp.m_ZoneSettings.AddRange(zoneSettings);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintTacticalCombatRoot.m_ZoneSettings"/>
    /// </summary>
    public TBuilder RemoveFromZoneSettings(params BlueprintTacticalCombatRoot.TacticalZoneSettings[] zoneSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ZoneSettings is null) { return; }
          bp.m_ZoneSettings = bp.m_ZoneSettings.Where(val => !zoneSettings.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintTacticalCombatRoot.m_ZoneSettings"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromZoneSettings(Func<BlueprintTacticalCombatRoot.TacticalZoneSettings, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ZoneSettings is null) { return; }
          bp.m_ZoneSettings = bp.m_ZoneSettings.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintTacticalCombatRoot.m_ZoneSettings"/>
    /// </summary>
    public TBuilder ClearZoneSettings()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ZoneSettings = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatRoot.m_ZoneSettings"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyZoneSettings(Action<BlueprintTacticalCombatRoot.TacticalZoneSettings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ZoneSettings is null) { return; }
          bp.m_ZoneSettings.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_LeaderManaResource"/>
    /// </summary>
    ///
    /// <param name="leaderManaResource">
    /// <para>
    /// Blueprint of type BlueprintAbilityResource. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetLeaderManaResource(Blueprint<BlueprintAbilityResourceReference> leaderManaResource)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_LeaderManaResource = leaderManaResource?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatRoot.m_LeaderManaResource"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLeaderManaResource(Action<BlueprintAbilityResourceReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_LeaderManaResource is null) { return; }
          action.Invoke(bp.m_LeaderManaResource);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_UnitTiersByBaseHealth"/>
    /// </summary>
    public TBuilder SetUnitTiersByBaseHealth(params int[] unitTiersByBaseHealth)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_UnitTiersByBaseHealth = unitTiersByBaseHealth.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintTacticalCombatRoot.m_UnitTiersByBaseHealth"/>
    /// </summary>
    public TBuilder AddToUnitTiersByBaseHealth(params int[] unitTiersByBaseHealth)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_UnitTiersByBaseHealth = bp.m_UnitTiersByBaseHealth ?? new();
          bp.m_UnitTiersByBaseHealth.AddRange(unitTiersByBaseHealth);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintTacticalCombatRoot.m_UnitTiersByBaseHealth"/>
    /// </summary>
    public TBuilder RemoveFromUnitTiersByBaseHealth(params int[] unitTiersByBaseHealth)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_UnitTiersByBaseHealth is null) { return; }
          bp.m_UnitTiersByBaseHealth = bp.m_UnitTiersByBaseHealth.Where(val => !unitTiersByBaseHealth.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintTacticalCombatRoot.m_UnitTiersByBaseHealth"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromUnitTiersByBaseHealth(Func<int, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_UnitTiersByBaseHealth is null) { return; }
          bp.m_UnitTiersByBaseHealth = bp.m_UnitTiersByBaseHealth.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintTacticalCombatRoot.m_UnitTiersByBaseHealth"/>
    /// </summary>
    public TBuilder ClearUnitTiersByBaseHealth()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_UnitTiersByBaseHealth = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatRoot.m_UnitTiersByBaseHealth"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyUnitTiersByBaseHealth(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_UnitTiersByBaseHealth is null) { return; }
          bp.m_UnitTiersByBaseHealth.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_AutoVictoryCoefficient"/>
    /// </summary>
    ///
    /// <param name="autoVictoryCoefficient">
    /// <para>
    /// InfoBox: Get auto win result if `Enemy Army Exp / Player Army Exp &amp;lt;= AutoVictoryCoefficient`
    /// </para>
    /// </param>
    public TBuilder SetAutoVictoryCoefficient(float autoVictoryCoefficient)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AutoVictoryCoefficient = autoVictoryCoefficient;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_PlayerLossesCoefficientA"/>
    /// </summary>
    ///
    /// <param name="playerLossesCoefficientA">
    /// <para>
    /// InfoBox: PlayerLosses = A * x^2 + B * x + C, where x = Enemy Army Exp / Player Army Exp
    /// </para>
    /// </param>
    public TBuilder SetPlayerLossesCoefficientA(float playerLossesCoefficientA)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PlayerLossesCoefficientA = playerLossesCoefficientA;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_PlayerLossesCoefficientB"/>
    /// </summary>
    public TBuilder SetPlayerLossesCoefficientB(float playerLossesCoefficientB)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PlayerLossesCoefficientB = playerLossesCoefficientB;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_PlayerLossesCoefficientC"/>
    /// </summary>
    public TBuilder SetPlayerLossesCoefficientC(float playerLossesCoefficientC)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PlayerLossesCoefficientC = playerLossesCoefficientC;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_EnemyLossesCoefficientA"/>
    /// </summary>
    ///
    /// <param name="enemyLossesCoefficientA">
    /// <para>
    /// InfoBox: EnemyLosses = A - B * x, where x = Enemy Army Exp / Player Army Exp
    /// </para>
    /// </param>
    public TBuilder SetEnemyLossesCoefficientA(float enemyLossesCoefficientA)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_EnemyLossesCoefficientA = enemyLossesCoefficientA;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_EnemyLossesCoefficientB"/>
    /// </summary>
    public TBuilder SetEnemyLossesCoefficientB(float enemyLossesCoefficientB)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_EnemyLossesCoefficientB = enemyLossesCoefficientB;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_MaxTierLossesPercent"/>
    /// </summary>
    ///
    /// <param name="maxTierLossesPercent">
    /// <para>
    /// InfoBox: Calculate losses starting from low grade to higher, killing at most MaxGradeLossesPercent of units. If after first iteration there should be more losses, go from low grade reducing count without any cap
    /// </para>
    /// </param>
    public TBuilder SetMaxTierLossesPercent(float maxTierLossesPercent)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MaxTierLossesPercent = maxTierLossesPercent;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_LowLossesPercent"/>
    /// </summary>
    ///
    /// <param name="lowLossesPercent">
    /// <para>
    /// InfoBox: Used to color armies on global map. Player losses &amp;lt; LowLossesPercent -&amp;gt; green
    /// </para>
    /// </param>
    public TBuilder SetLowLossesPercent(float lowLossesPercent)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_LowLossesPercent = lowLossesPercent;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_HighLossesPercent"/>
    /// </summary>
    ///
    /// <param name="highLossesPercent">
    /// <para>
    /// InfoBox: Used to color armies on global map. Player losses &amp;gt; m_HighLossesPercent -&amp;gt; red. Between high and low -&amp;gt; yellow
    /// </para>
    /// </param>
    public TBuilder SetHighLossesPercent(float highLossesPercent)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_HighLossesPercent = highLossesPercent;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_DismembermentDamageCoefficient"/>
    /// </summary>
    ///
    /// <param name="dismembermentDamageCoefficient">
    /// <para>
    /// Tooltip: Damage to original stack full health ratio should exceed this value to trigger dismemberment
    /// </para>
    /// </param>
    public TBuilder SetDismembermentDamageCoefficient(float dismembermentDamageCoefficient)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DismembermentDamageCoefficient = dismembermentDamageCoefficient;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_WinnerCutscene"/>
    /// </summary>
    ///
    /// <param name="winnerCutscene">
    /// <para>
    /// Blueprint of type Cutscene. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetWinnerCutscene(Blueprint<CutsceneReference> winnerCutscene)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_WinnerCutscene = winnerCutscene?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatRoot.m_WinnerCutscene"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyWinnerCutscene(Action<CutsceneReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_WinnerCutscene is null) { return; }
          action.Invoke(bp.m_WinnerCutscene);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_PositiveMoraleFx"/>
    /// </summary>
    ///
    /// <param name="positiveMoraleFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetPositiveMoraleFx(AssetLink<PrefabLink> positiveMoraleFx)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PositiveMoraleFx = positiveMoraleFx?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatRoot.m_PositiveMoraleFx"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPositiveMoraleFx(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_PositiveMoraleFx is null) { return; }
          action.Invoke(bp.m_PositiveMoraleFx);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_NegativeMoraleFx"/>
    /// </summary>
    ///
    /// <param name="negativeMoraleFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetNegativeMoraleFx(AssetLink<PrefabLink> negativeMoraleFx)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_NegativeMoraleFx = negativeMoraleFx?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatRoot.m_NegativeMoraleFx"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNegativeMoraleFx(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_NegativeMoraleFx is null) { return; }
          action.Invoke(bp.m_NegativeMoraleFx);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatRoot.m_AudioScalingFactor"/>
    /// </summary>
    public TBuilder SetAudioScalingFactor(float audioScalingFactor)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AudioScalingFactor = audioScalingFactor;
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_CrusadersFaction is null)
      {
        Blueprint.m_CrusadersFaction = BlueprintTool.GetRef<BlueprintFactionReference>(null);
      }
      if (Blueprint.m_DemonsFaction is null)
      {
        Blueprint.m_DemonsFaction = BlueprintTool.GetRef<BlueprintFactionReference>(null);
      }
      if (Blueprint.m_DefaultBrain is null)
      {
        Blueprint.m_DefaultBrain = BlueprintTool.GetRef<BlueprintTacticalCombatBrain.Reference>(null);
      }
      if (Blueprint.m_DefaultLeaderBrain is null)
      {
        Blueprint.m_DefaultLeaderBrain = BlueprintTool.GetRef<BlueprintTacticalCombatBrain.Reference>(null);
      }
      if (Blueprint.m_BuffPrefix is null)
      {
        Blueprint.m_BuffPrefix = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_BannedUnitFacts is null)
      {
        Blueprint.m_BannedUnitFacts = new();
      }
      if (Blueprint.m_ZoneSettings is null)
      {
        Blueprint.m_ZoneSettings = new();
      }
      if (Blueprint.m_LeaderManaResource is null)
      {
        Blueprint.m_LeaderManaResource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(null);
      }
      if (Blueprint.m_UnitTiersByBaseHealth is null)
      {
        Blueprint.m_UnitTiersByBaseHealth = new();
      }
      if (Blueprint.m_WinnerCutscene is null)
      {
        Blueprint.m_WinnerCutscene = BlueprintTool.GetRef<CutsceneReference>(null);
      }
      if (Blueprint.m_PositiveMoraleFx is null)
      {
        Blueprint.m_PositiveMoraleFx = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.m_NegativeMoraleFx is null)
      {
        Blueprint.m_NegativeMoraleFx = Utils.Constants.Empty.PrefabLink;
      }
    }
  }
}
