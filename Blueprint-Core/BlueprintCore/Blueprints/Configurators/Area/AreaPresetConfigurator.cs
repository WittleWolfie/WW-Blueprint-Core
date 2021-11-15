using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Enums;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Settings.Difficulty;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAreaPreset"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAreaPreset))]
  public abstract class BaseAreaPresetConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintAreaPreset
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseAreaPresetConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_Area"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintArea"/></param>
    [Generated]
    public TBuilder SetArea(string value)
    {
      return OnConfigureInternal(bp => bp.m_Area = BlueprintTool.GetRef<BlueprintAreaReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_EnterPoint"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintAreaEnterPoint"/></param>
    [Generated]
    public TBuilder SetEnterPoint(string value)
    {
      return OnConfigureInternal(bp => bp.m_EnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_GlobalMapLocation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintGlobalMapPoint"/></param>
    [Generated]
    public TBuilder SetGlobalMapLocation(string value)
    {
      return OnConfigureInternal(bp => bp.m_GlobalMapLocation = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(value));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.AlsoLoadMechanics"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAreaMechanics"/></param>
    [Generated]
    public TBuilder AddToAlsoLoadMechanics(params string[] values)
    {
      return OnConfigureInternal(bp => bp.AlsoLoadMechanics.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintAreaMechanicsReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.AlsoLoadMechanics"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAreaMechanics"/></param>
    [Generated]
    public TBuilder RemoveFromAlsoLoadMechanics(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintAreaMechanicsReference>(name));
            bp.AlsoLoadMechanics =
                bp.AlsoLoadMechanics
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.MakeAutosave"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetMakeAutosave(bool value)
    {
      return OnConfigureInternal(bp => bp.MakeAutosave = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_OverrideGameDifficulty"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetOverrideGameDifficulty(DifficultyPresetAsset value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_OverrideGameDifficulty = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_PlayerCharacter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintUnit"/></param>
    [Generated]
    public TBuilder SetPlayerCharacter(string value)
    {
      return OnConfigureInternal(bp => bp.m_PlayerCharacter = BlueprintTool.GetRef<BlueprintUnitReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.CharGen"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCharGen(bool value)
    {
      return OnConfigureInternal(bp => bp.CharGen = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.Alignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetAlignment(Alignment value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Alignment = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.PartyXp"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetPartyXp(int value)
    {
      return OnConfigureInternal(bp => bp.PartyXp = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.Companions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnit"/></param>
    [Generated]
    public TBuilder AddToCompanions(params string[] values)
    {
      return OnConfigureInternal(bp => bp.Companions.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.Companions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnit"/></param>
    [Generated]
    public TBuilder RemoveFromCompanions(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name));
            bp.Companions =
                bp.Companions
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.CompanionsRemote"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnit"/></param>
    [Generated]
    public TBuilder AddToCompanionsRemote(params string[] values)
    {
      return OnConfigureInternal(bp => bp.CompanionsRemote.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.CompanionsRemote"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnit"/></param>
    [Generated]
    public TBuilder RemoveFromCompanionsRemote(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name));
            bp.CompanionsRemote =
                bp.CompanionsRemote
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.ExCompanions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnit"/></param>
    [Generated]
    public TBuilder AddToExCompanions(params string[] values)
    {
      return OnConfigureInternal(bp => bp.ExCompanions.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.ExCompanions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnit"/></param>
    [Generated]
    public TBuilder RemoveFromExCompanions(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name));
            bp.ExCompanions =
                bp.ExCompanions
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.StartGameActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetStartGameActions(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.StartGameActions = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_DlcCampaign"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintDlcRewardCampaign"/></param>
    [Generated]
    public TBuilder SetDlcCampaign(string value)
    {
      return OnConfigureInternal(bp => bp.m_DlcCampaign = BlueprintTool.GetRef<BlueprintDlcRewardCampaignReference>(value));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.UnlockedFlags"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder AddToUnlockedFlags(params UnlockValuePair[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.UnlockedFlags.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.UnlockedFlags"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder RemoveFromUnlockedFlags(params UnlockValuePair[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.UnlockedFlags = bp.UnlockedFlags.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.StartedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintQuestObjective"/></param>
    [Generated]
    public TBuilder AddToStartedQuests(params string[] values)
    {
      return OnConfigureInternal(bp => bp.StartedQuests.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.StartedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintQuestObjective"/></param>
    [Generated]
    public TBuilder RemoveFromStartedQuests(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name));
            bp.StartedQuests =
                bp.StartedQuests
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.FinishedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintQuestObjective"/></param>
    [Generated]
    public TBuilder AddToFinishedQuests(params string[] values)
    {
      return OnConfigureInternal(bp => bp.FinishedQuests.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.FinishedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintQuestObjective"/></param>
    [Generated]
    public TBuilder RemoveFromFinishedQuests(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name));
            bp.FinishedQuests =
                bp.FinishedQuests
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.FailedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintQuestObjective"/></param>
    [Generated]
    public TBuilder AddToFailedQuests(params string[] values)
    {
      return OnConfigureInternal(bp => bp.FailedQuests.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.FailedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintQuestObjective"/></param>
    [Generated]
    public TBuilder RemoveFromFailedQuests(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name));
            bp.FailedQuests =
                bp.FailedQuests
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.StartEtudesNonRecursively"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintEtude"/></param>
    [Generated]
    public TBuilder AddToStartEtudesNonRecursively(params string[] values)
    {
      return OnConfigureInternal(bp => bp.StartEtudesNonRecursively.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.StartEtudesNonRecursively"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintEtude"/></param>
    [Generated]
    public TBuilder RemoveFromStartEtudesNonRecursively(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name));
            bp.StartEtudesNonRecursively =
                bp.StartEtudesNonRecursively
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.StartEtudes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintEtude"/></param>
    [Generated]
    public TBuilder AddToStartEtudes(params string[] values)
    {
      return OnConfigureInternal(bp => bp.StartEtudes.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.StartEtudes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintEtude"/></param>
    [Generated]
    public TBuilder RemoveFromStartEtudes(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name));
            bp.StartEtudes =
                bp.StartEtudes
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.ForceCompleteEtudes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintEtude"/></param>
    [Generated]
    public TBuilder AddToForceCompleteEtudes(params string[] values)
    {
      return OnConfigureInternal(bp => bp.ForceCompleteEtudes.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.ForceCompleteEtudes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintEtude"/></param>
    [Generated]
    public TBuilder RemoveFromForceCompleteEtudes(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name));
            bp.ForceCompleteEtudes =
                bp.ForceCompleteEtudes
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.CuesSeen"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintCueBase"/></param>
    [Generated]
    public TBuilder AddToCuesSeen(params string[] values)
    {
      return OnConfigureInternal(bp => bp.CuesSeen.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintCueBaseReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.CuesSeen"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintCueBase"/></param>
    [Generated]
    public TBuilder RemoveFromCuesSeen(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintCueBaseReference>(name));
            bp.CuesSeen =
                bp.CuesSeen
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.AnswersSelected"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAnswer"/></param>
    [Generated]
    public TBuilder AddToAnswersSelected(params string[] values)
    {
      return OnConfigureInternal(bp => bp.AnswersSelected.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.AnswersSelected"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAnswer"/></param>
    [Generated]
    public TBuilder RemoveFromAnswersSelected(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name));
            bp.AnswersSelected =
                bp.AnswersSelected
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.HasKingdom"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetHasKingdom(bool value)
    {
      return OnConfigureInternal(bp => bp.HasKingdom = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.KingdomManagementIsVisible"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetKingdomManagementIsVisible(bool value)
    {
      return OnConfigureInternal(bp => bp.KingdomManagementIsVisible = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.ActiveEvents"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintKingdomEventBase"/></param>
    [Generated]
    public TBuilder AddToActiveEvents(params string[] values)
    {
      return OnConfigureInternal(bp => bp.ActiveEvents.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintKingdomEventBaseReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.ActiveEvents"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintKingdomEventBase"/></param>
    [Generated]
    public TBuilder RemoveFromActiveEvents(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintKingdomEventBaseReference>(name));
            bp.ActiveEvents =
                bp.ActiveEvents
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.AddResources"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetAddResources(KingdomResourcesAmount value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.AddResources = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.AddConsumableEventBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetAddConsumableEventBonus(int value)
    {
      return OnConfigureInternal(bp => bp.AddConsumableEventBonus = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_KingdomDay"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetKingdomDay(int value)
    {
      return OnConfigureInternal(bp => bp.m_KingdomDay = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_KingdomIncomePerClaimed"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetKingdomIncomePerClaimed(KingdomResourcesAmount value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_KingdomIncomePerClaimed = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_KingdomIncomePerUpgraded"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetKingdomIncomePerUpgraded(KingdomResourcesAmount value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_KingdomIncomePerUpgraded = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_Stats"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetStats(BlueprintAreaPreset.KingdomsStatsPreset value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_Stats = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.m_Regions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder AddToRegions(params BlueprintAreaPreset.KingdomsRegionPreset[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_Regions = CommonTool.Append(bp.m_Regions, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.m_Regions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder RemoveFromRegions(params BlueprintAreaPreset.KingdomsRegionPreset[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_Regions = bp.m_Regions.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.m_History"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder AddToHistory(params BlueprintAreaPreset.KingdomsEventHistoryPreset[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_History = CommonTool.Append(bp.m_History, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.m_History"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder RemoveFromHistory(params BlueprintAreaPreset.KingdomsEventHistoryPreset[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_History = bp.m_History.Where(item => !values.Contains(item)).ToArray());
    }
  }

  /// <summary>Configurator for <see cref="BlueprintAreaPreset"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAreaPreset))]
  public class AreaPresetConfigurator : BaseBlueprintConfigurator<BlueprintAreaPreset, AreaPresetConfigurator>
  {
     private AreaPresetConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AreaPresetConfigurator For(string name)
    {
      return new AreaPresetConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AreaPresetConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintAreaPreset>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AreaPresetConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintAreaPreset>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_Area"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintArea"/></param>
    [Generated]
    public AreaPresetConfigurator SetArea(string value)
    {
      return OnConfigureInternal(bp => bp.m_Area = BlueprintTool.GetRef<BlueprintAreaReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_EnterPoint"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintAreaEnterPoint"/></param>
    [Generated]
    public AreaPresetConfigurator SetEnterPoint(string value)
    {
      return OnConfigureInternal(bp => bp.m_EnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_GlobalMapLocation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintGlobalMapPoint"/></param>
    [Generated]
    public AreaPresetConfigurator SetGlobalMapLocation(string value)
    {
      return OnConfigureInternal(bp => bp.m_GlobalMapLocation = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(value));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.AlsoLoadMechanics"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAreaMechanics"/></param>
    [Generated]
    public AreaPresetConfigurator AddToAlsoLoadMechanics(params string[] values)
    {
      return OnConfigureInternal(bp => bp.AlsoLoadMechanics.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintAreaMechanicsReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.AlsoLoadMechanics"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAreaMechanics"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromAlsoLoadMechanics(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintAreaMechanicsReference>(name));
            bp.AlsoLoadMechanics =
                bp.AlsoLoadMechanics
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.MakeAutosave"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetMakeAutosave(bool value)
    {
      return OnConfigureInternal(bp => bp.MakeAutosave = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_OverrideGameDifficulty"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetOverrideGameDifficulty(DifficultyPresetAsset value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_OverrideGameDifficulty = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_PlayerCharacter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintUnit"/></param>
    [Generated]
    public AreaPresetConfigurator SetPlayerCharacter(string value)
    {
      return OnConfigureInternal(bp => bp.m_PlayerCharacter = BlueprintTool.GetRef<BlueprintUnitReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.CharGen"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetCharGen(bool value)
    {
      return OnConfigureInternal(bp => bp.CharGen = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.Alignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetAlignment(Alignment value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Alignment = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.PartyXp"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetPartyXp(int value)
    {
      return OnConfigureInternal(bp => bp.PartyXp = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.Companions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnit"/></param>
    [Generated]
    public AreaPresetConfigurator AddToCompanions(params string[] values)
    {
      return OnConfigureInternal(bp => bp.Companions.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.Companions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnit"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromCompanions(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name));
            bp.Companions =
                bp.Companions
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.CompanionsRemote"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnit"/></param>
    [Generated]
    public AreaPresetConfigurator AddToCompanionsRemote(params string[] values)
    {
      return OnConfigureInternal(bp => bp.CompanionsRemote.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.CompanionsRemote"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnit"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromCompanionsRemote(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name));
            bp.CompanionsRemote =
                bp.CompanionsRemote
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.ExCompanions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnit"/></param>
    [Generated]
    public AreaPresetConfigurator AddToExCompanions(params string[] values)
    {
      return OnConfigureInternal(bp => bp.ExCompanions.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.ExCompanions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnit"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromExCompanions(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name));
            bp.ExCompanions =
                bp.ExCompanions
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.StartGameActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetStartGameActions(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.StartGameActions = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_DlcCampaign"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintDlcRewardCampaign"/></param>
    [Generated]
    public AreaPresetConfigurator SetDlcCampaign(string value)
    {
      return OnConfigureInternal(bp => bp.m_DlcCampaign = BlueprintTool.GetRef<BlueprintDlcRewardCampaignReference>(value));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.UnlockedFlags"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator AddToUnlockedFlags(params UnlockValuePair[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.UnlockedFlags.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.UnlockedFlags"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator RemoveFromUnlockedFlags(params UnlockValuePair[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.UnlockedFlags = bp.UnlockedFlags.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.StartedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintQuestObjective"/></param>
    [Generated]
    public AreaPresetConfigurator AddToStartedQuests(params string[] values)
    {
      return OnConfigureInternal(bp => bp.StartedQuests.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.StartedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintQuestObjective"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromStartedQuests(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name));
            bp.StartedQuests =
                bp.StartedQuests
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.FinishedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintQuestObjective"/></param>
    [Generated]
    public AreaPresetConfigurator AddToFinishedQuests(params string[] values)
    {
      return OnConfigureInternal(bp => bp.FinishedQuests.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.FinishedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintQuestObjective"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromFinishedQuests(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name));
            bp.FinishedQuests =
                bp.FinishedQuests
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.FailedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintQuestObjective"/></param>
    [Generated]
    public AreaPresetConfigurator AddToFailedQuests(params string[] values)
    {
      return OnConfigureInternal(bp => bp.FailedQuests.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.FailedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintQuestObjective"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromFailedQuests(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name));
            bp.FailedQuests =
                bp.FailedQuests
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.StartEtudesNonRecursively"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintEtude"/></param>
    [Generated]
    public AreaPresetConfigurator AddToStartEtudesNonRecursively(params string[] values)
    {
      return OnConfigureInternal(bp => bp.StartEtudesNonRecursively.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.StartEtudesNonRecursively"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintEtude"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromStartEtudesNonRecursively(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name));
            bp.StartEtudesNonRecursively =
                bp.StartEtudesNonRecursively
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.StartEtudes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintEtude"/></param>
    [Generated]
    public AreaPresetConfigurator AddToStartEtudes(params string[] values)
    {
      return OnConfigureInternal(bp => bp.StartEtudes.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.StartEtudes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintEtude"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromStartEtudes(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name));
            bp.StartEtudes =
                bp.StartEtudes
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.ForceCompleteEtudes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintEtude"/></param>
    [Generated]
    public AreaPresetConfigurator AddToForceCompleteEtudes(params string[] values)
    {
      return OnConfigureInternal(bp => bp.ForceCompleteEtudes.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.ForceCompleteEtudes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintEtude"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromForceCompleteEtudes(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name));
            bp.ForceCompleteEtudes =
                bp.ForceCompleteEtudes
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.CuesSeen"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintCueBase"/></param>
    [Generated]
    public AreaPresetConfigurator AddToCuesSeen(params string[] values)
    {
      return OnConfigureInternal(bp => bp.CuesSeen.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintCueBaseReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.CuesSeen"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintCueBase"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromCuesSeen(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintCueBaseReference>(name));
            bp.CuesSeen =
                bp.CuesSeen
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.AnswersSelected"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAnswer"/></param>
    [Generated]
    public AreaPresetConfigurator AddToAnswersSelected(params string[] values)
    {
      return OnConfigureInternal(bp => bp.AnswersSelected.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.AnswersSelected"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAnswer"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromAnswersSelected(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name));
            bp.AnswersSelected =
                bp.AnswersSelected
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.HasKingdom"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetHasKingdom(bool value)
    {
      return OnConfigureInternal(bp => bp.HasKingdom = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.KingdomManagementIsVisible"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetKingdomManagementIsVisible(bool value)
    {
      return OnConfigureInternal(bp => bp.KingdomManagementIsVisible = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.ActiveEvents"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintKingdomEventBase"/></param>
    [Generated]
    public AreaPresetConfigurator AddToActiveEvents(params string[] values)
    {
      return OnConfigureInternal(bp => bp.ActiveEvents.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintKingdomEventBaseReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.ActiveEvents"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintKingdomEventBase"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromActiveEvents(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintKingdomEventBaseReference>(name));
            bp.ActiveEvents =
                bp.ActiveEvents
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.AddResources"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetAddResources(KingdomResourcesAmount value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.AddResources = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.AddConsumableEventBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetAddConsumableEventBonus(int value)
    {
      return OnConfigureInternal(bp => bp.AddConsumableEventBonus = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_KingdomDay"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetKingdomDay(int value)
    {
      return OnConfigureInternal(bp => bp.m_KingdomDay = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_KingdomIncomePerClaimed"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetKingdomIncomePerClaimed(KingdomResourcesAmount value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_KingdomIncomePerClaimed = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_KingdomIncomePerUpgraded"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetKingdomIncomePerUpgraded(KingdomResourcesAmount value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_KingdomIncomePerUpgraded = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_Stats"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetStats(BlueprintAreaPreset.KingdomsStatsPreset value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_Stats = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.m_Regions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator AddToRegions(params BlueprintAreaPreset.KingdomsRegionPreset[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_Regions = CommonTool.Append(bp.m_Regions, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.m_Regions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator RemoveFromRegions(params BlueprintAreaPreset.KingdomsRegionPreset[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_Regions = bp.m_Regions.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.m_History"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator AddToHistory(params BlueprintAreaPreset.KingdomsEventHistoryPreset[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_History = CommonTool.Append(bp.m_History, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.m_History"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator RemoveFromHistory(params BlueprintAreaPreset.KingdomsEventHistoryPreset[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_History = bp.m_History.Where(item => !values.Contains(item)).ToArray());
    }
  }
}
