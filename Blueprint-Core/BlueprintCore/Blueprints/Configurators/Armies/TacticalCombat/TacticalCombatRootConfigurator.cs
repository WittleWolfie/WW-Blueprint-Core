using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Blueprints;
using Kingmaker.Armies.TacticalCombat.Brain;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Owlcat.Runtime.Core.Math;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Armies.TacticalCombat
{
  /// <summary>Configurator for <see cref="BlueprintTacticalCombatRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTacticalCombatRoot))]
  public class TacticalCombatRootConfigurator : BaseBlueprintConfigurator<BlueprintTacticalCombatRoot, TacticalCombatRootConfigurator>
  {
     private TacticalCombatRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TacticalCombatRootConfigurator For(string name)
    {
      return new TacticalCombatRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static TacticalCombatRootConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintTacticalCombatRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TacticalCombatRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintTacticalCombatRoot>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_ProbabilitySampler"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetProbabilitySampler(ProbabilityCurveSampler value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_ProbabilitySampler = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_CrusadersFaction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintFaction"/></param>
    [Generated]
    public TacticalCombatRootConfigurator SetCrusadersFaction(string value)
    {
      return OnConfigureInternal(bp => bp.m_CrusadersFaction = BlueprintTool.GetRef<BlueprintFactionReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_DemonsFaction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintFaction"/></param>
    [Generated]
    public TacticalCombatRootConfigurator SetDemonsFaction(string value)
    {
      return OnConfigureInternal(bp => bp.m_DemonsFaction = BlueprintTool.GetRef<BlueprintFactionReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_DefaultBrain"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintTacticalCombatBrain"/></param>
    [Generated]
    public TacticalCombatRootConfigurator SetDefaultBrain(string value)
    {
      return OnConfigureInternal(bp => bp.m_DefaultBrain = BlueprintTool.GetRef<BlueprintTacticalCombatBrain.Reference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_DefaultLeaderBrain"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintTacticalCombatBrain"/></param>
    [Generated]
    public TacticalCombatRootConfigurator SetDefaultLeaderBrain(string value)
    {
      return OnConfigureInternal(bp => bp.m_DefaultLeaderBrain = BlueprintTool.GetRef<BlueprintTacticalCombatBrain.Reference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_AiSpellCastWeight"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetAiSpellCastWeight(float value)
    {
      return OnConfigureInternal(bp => bp.m_AiSpellCastWeight = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_AiCanUseRituals"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetAiCanUseRituals(bool value)
    {
      return OnConfigureInternal(bp => bp.m_AiCanUseRituals = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_DelayBetweenTurns"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetDelayBetweenTurns(float value)
    {
      return OnConfigureInternal(bp => bp.m_DelayBetweenTurns = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_DelayAfterMoraleEffect"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetDelayAfterMoraleEffect(float value)
    {
      return OnConfigureInternal(bp => bp.m_DelayAfterMoraleEffect = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_DelayBeforeBattleEnd"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetDelayBeforeBattleEnd(float value)
    {
      return OnConfigureInternal(bp => bp.m_DelayBeforeBattleEnd = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_MaxTurnDuration"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetMaxTurnDuration(float value)
    {
      return OnConfigureInternal(bp => bp.m_MaxTurnDuration = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_MoveSpeed"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetMoveSpeed(int value)
    {
      return OnConfigureInternal(bp => bp.m_MoveSpeed = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_MaxSquadsCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetMaxSquadsCount(int value)
    {
      return OnConfigureInternal(bp => bp.m_MaxSquadsCount = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_BuffPrefix"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetBuffPrefix(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_BuffPrefix = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_ArmyLossesCoefOnRetreat"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetArmyLossesCoefOnRetreat(float value)
    {
      return OnConfigureInternal(bp => bp.m_ArmyLossesCoefOnRetreat = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_AutoVictoryChanceCoefficient"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetAutoVictoryChanceCoefficient(float value)
    {
      return OnConfigureInternal(bp => bp.m_AutoVictoryChanceCoefficient = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_AutoVictoryChanceMinimum"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetAutoVictoryChanceMinimum(float value)
    {
      return OnConfigureInternal(bp => bp.m_AutoVictoryChanceMinimum = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_AutoCombatLossesCoefficient"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetAutoCombatLossesCoefficient(float value)
    {
      return OnConfigureInternal(bp => bp.m_AutoCombatLossesCoefficient = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_AutoCombatMinimumLossesCoefficient"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetAutoCombatMinimumLossesCoefficient(float value)
    {
      return OnConfigureInternal(bp => bp.m_AutoCombatMinimumLossesCoefficient = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_DiceRollResultsDistribution"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetDiceRollResultsDistribution(AnimationCurve value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_DiceRollResultsDistribution = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatRoot.m_BannedUnitFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    public TacticalCombatRootConfigurator AddToBannedUnitFacts(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_BannedUnitFacts.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatRoot.m_BannedUnitFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    public TacticalCombatRootConfigurator RemoveFromBannedUnitFacts(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name));
            bp.m_BannedUnitFacts =
                bp.m_BannedUnitFacts
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_DefaultZone"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetDefaultZone(TacticalCombatAreaZone value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_DefaultZone = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatRoot.m_ZoneSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator AddToZoneSettings(params BlueprintTacticalCombatRoot.TacticalZoneSettings[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_ZoneSettings.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatRoot.m_ZoneSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator RemoveFromZoneSettings(params BlueprintTacticalCombatRoot.TacticalZoneSettings[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_ZoneSettings = bp.m_ZoneSettings.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_LeaderManaResource"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    public TacticalCombatRootConfigurator SetLeaderManaResource(string value)
    {
      return OnConfigureInternal(bp => bp.m_LeaderManaResource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_WinnerCutscene"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="Cutscene"/></param>
    [Generated]
    public TacticalCombatRootConfigurator SetWinnerCutscene(string value)
    {
      return OnConfigureInternal(bp => bp.m_WinnerCutscene = BlueprintTool.GetRef<CutsceneReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_PositiveMoraleFx"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetPositiveMoraleFx(PrefabLink value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_PositiveMoraleFx = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_NegativeMoraleFx"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetNegativeMoraleFx(PrefabLink value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_NegativeMoraleFx = value);
    }
  }
}
