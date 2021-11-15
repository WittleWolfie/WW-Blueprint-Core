using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Localization;
using Kingmaker.UI.Kingdom;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>Configurator for <see cref="KingdomRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(KingdomRoot))]
  public class KingdomRootConfigurator : BaseBlueprintConfigurator<KingdomRoot, KingdomRootConfigurator>
  {
     private KingdomRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomRootConfigurator For(string name)
    {
      return new KingdomRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static KingdomRootConfigurator New(string name)
    {
      BlueprintTool.Create<KingdomRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<KingdomRoot>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_BlueprintRegionCapital"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintRegion"/></param>
    [Generated]
    public KingdomRootConfigurator SetBlueprintRegionCapital(string value)
    {
      return OnConfigureInternal(bp => bp.m_BlueprintRegionCapital = BlueprintTool.GetRef<BlueprintRegionReference>(value));
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_CapitalSettlement"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintSettlement"/></param>
    [Generated]
    public KingdomRootConfigurator SetCapitalSettlement(string value)
    {
      return OnConfigureInternal(bp => bp.m_CapitalSettlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(value));
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_ThroneRoom"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintAreaEnterPoint"/></param>
    [Generated]
    public KingdomRootConfigurator SetThroneRoom(string value)
    {
      return OnConfigureInternal(bp => bp.m_ThroneRoom = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(value));
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.SettlementEmptyMarker"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetSettlementEmptyMarker(KingdomUISettlementEmptyMarker value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.SettlementEmptyMarker = value);
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_StartingEventDecks"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintKingdomDeck"/></param>
    [Generated]
    public KingdomRootConfigurator AddToStartingEventDecks(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_StartingEventDecks = CommonTool.Append(bp.m_StartingEventDecks, values.Select(name => BlueprintTool.GetRef<BlueprintKingdomDeckReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_StartingEventDecks"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintKingdomDeck"/></param>
    [Generated]
    public KingdomRootConfigurator RemoveFromStartingEventDecks(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintKingdomDeckReference>(name));
            bp.m_StartingEventDecks =
                bp.m_StartingEventDecks
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_KingdomProjectEvents"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintKingdomProject"/></param>
    [Generated]
    public KingdomRootConfigurator AddToKingdomProjectEvents(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_KingdomProjectEvents.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintKingdomProjectReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_KingdomProjectEvents"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintKingdomProject"/></param>
    [Generated]
    public KingdomRootConfigurator RemoveFromKingdomProjectEvents(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintKingdomProjectReference>(name));
            bp.m_KingdomProjectEvents =
                bp.m_KingdomProjectEvents
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_Buildings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintSettlementBuilding"/></param>
    [Generated]
    public KingdomRootConfigurator AddToBuildings(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Buildings = CommonTool.Append(bp.m_Buildings, values.Select(name => BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_Buildings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintSettlementBuilding"/></param>
    [Generated]
    public KingdomRootConfigurator RemoveFromBuildings(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(name));
            bp.m_Buildings =
                bp.m_Buildings
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_UnrestPriorityDeck"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintKingdomDeck"/></param>
    [Generated]
    public KingdomRootConfigurator SetUnrestPriorityDeck(string value)
    {
      return OnConfigureInternal(bp => bp.m_UnrestPriorityDeck = BlueprintTool.GetRef<BlueprintKingdomDeckReference>(value));
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.UnrestDeckTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetUnrestDeckTrigger(KingdomStatusType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.UnrestDeckTrigger = value);
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_UnrestMitigationEvents"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintKingdomProject"/></param>
    [Generated]
    public KingdomRootConfigurator AddToUnrestMitigationEvents(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_UnrestMitigationEvents = CommonTool.Append(bp.m_UnrestMitigationEvents, values.Select(name => BlueprintTool.GetRef<BlueprintKingdomProjectReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_UnrestMitigationEvents"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintKingdomProject"/></param>
    [Generated]
    public KingdomRootConfigurator RemoveFromUnrestMitigationEvents(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintKingdomProjectReference>(name));
            bp.m_UnrestMitigationEvents =
                bp.m_UnrestMitigationEvents
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_UIRoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="KingdomUIRoot"/></param>
    [Generated]
    public KingdomRootConfigurator SetUIRoot(string value)
    {
      return OnConfigureInternal(bp => bp.m_UIRoot = BlueprintTool.GetRef<KingdomUIRootReference>(value));
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.LeaderSlots"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator AddToLeaderSlots(params LeaderSlot[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.LeaderSlots = CommonTool.Append(bp.LeaderSlots, values));
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.LeaderSlots"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator RemoveFromLeaderSlots(params LeaderSlot[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.LeaderSlots = bp.LeaderSlots.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_StartingNPCLeaders"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnit"/></param>
    [Generated]
    public KingdomRootConfigurator AddToStartingNPCLeaders(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_StartingNPCLeaders = CommonTool.Append(bp.m_StartingNPCLeaders, values.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_StartingNPCLeaders"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnit"/></param>
    [Generated]
    public KingdomRootConfigurator RemoveFromStartingNPCLeaders(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name));
            bp.m_StartingNPCLeaders =
                bp.m_StartingNPCLeaders
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_Timeline"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintKingdomEventTimeline"/></param>
    [Generated]
    public KingdomRootConfigurator SetTimeline(string value)
    {
      return OnConfigureInternal(bp => bp.m_Timeline = BlueprintTool.GetRef<BlueprintKingdomEventTimelineReference>(value));
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_CrusadeEventsTimeline"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintCrusadeEventTimeline"/></param>
    [Generated]
    public KingdomRootConfigurator SetCrusadeEventsTimeline(string value)
    {
      return OnConfigureInternal(bp => bp.m_CrusadeEventsTimeline = BlueprintTool.GetRef<BlueprintCrusadeEventTimeline.Reference>(value));
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_RegionUpgradesAvailable"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintUnlockableFlag"/></param>
    [Generated]
    public KingdomRootConfigurator SetRegionUpgradesAvailable(string value)
    {
      return OnConfigureInternal(bp => bp.m_RegionUpgradesAvailable = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(value));
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_BpVendorItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintItem"/></param>
    [Generated]
    public KingdomRootConfigurator SetBpVendorItem(string value)
    {
      return OnConfigureInternal(bp => bp.m_BpVendorItem = BlueprintTool.GetRef<BlueprintItemReference>(value));
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_ConsumableEventBonusVendorItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintItem"/></param>
    [Generated]
    public KingdomRootConfigurator SetConsumableEventBonusVendorItem(string value)
    {
      return OnConfigureInternal(bp => bp.m_ConsumableEventBonusVendorItem = BlueprintTool.GetRef<BlueprintItemReference>(value));
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.StatIncreaseOnEvent"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetStatIncreaseOnEvent(int value)
    {
      return OnConfigureInternal(bp => bp.StatIncreaseOnEvent = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.StatMaxRankInBarony"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetStatMaxRankInBarony(int value)
    {
      return OnConfigureInternal(bp => bp.StatMaxRankInBarony = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.ResourcesPerEconomyRank"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetResourcesPerEconomyRank(KingdomResourcesAmount value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ResourcesPerEconomyRank = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.SettlementCost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetSettlementCost(KingdomResourcesAmount value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.SettlementCost = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.KingdomStatRankStep"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetKingdomStatRankStep(int value)
    {
      return OnConfigureInternal(bp => bp.KingdomStatRankStep = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.BaronySubsidy"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetBaronySubsidy(KingdomResourcesAmount value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.BaronySubsidy = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.BaronyResourcesModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetBaronyResourcesModifier(float value)
    {
      return OnConfigureInternal(bp => bp.BaronyResourcesModifier = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.ResourcesAtStart"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetResourcesAtStart(KingdomResourcesAmount value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ResourcesAtStart = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.ResourcesAtStartPerTurn"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetResourcesAtStartPerTurn(KingdomResourcesAmount value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ResourcesAtStartPerTurn = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.ConsumableEventBonusAtStart"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetConsumableEventBonusAtStart(int value)
    {
      return OnConfigureInternal(bp => bp.ConsumableEventBonusAtStart = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.ConsumableEventBonusPerRankUp"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetConsumableEventBonusPerRankUp(int value)
    {
      return OnConfigureInternal(bp => bp.ConsumableEventBonusPerRankUp = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.ConsumableEventBonusModifierValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetConsumableEventBonusModifierValue(int value)
    {
      return OnConfigureInternal(bp => bp.ConsumableEventBonusModifierValue = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.CustomLeaderPenalty"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetCustomLeaderPenalty(int value)
    {
      return OnConfigureInternal(bp => bp.CustomLeaderPenalty = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.BuildingSequenceCostMultiplier"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetBuildingSequenceCostMultiplier(float value)
    {
      return OnConfigureInternal(bp => bp.BuildingSequenceCostMultiplier = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.DefaultMapResourceCost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetDefaultMapResourceCost(KingdomResourcesAmount value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.DefaultMapResourceCost = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.RavenVisitDelayDays"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetRavenVisitDelayDays(int value)
    {
      return OnConfigureInternal(bp => bp.RavenVisitDelayDays = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.DefaultName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetDefaultName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.DefaultName = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.MoraleMaxValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetMoraleMaxValue(int value)
    {
      return OnConfigureInternal(bp => bp.MoraleMaxValue = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.MoraleDefaultMaxValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetMoraleDefaultMaxValue(int value)
    {
      return OnConfigureInternal(bp => bp.MoraleDefaultMaxValue = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.MoraleMinValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetMoraleMinValue(int value)
    {
      return OnConfigureInternal(bp => bp.MoraleMinValue = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.MoraleStartValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetMoraleStartValue(int value)
    {
      return OnConfigureInternal(bp => bp.MoraleStartValue = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.StartArmySquadsCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetStartArmySquadsCount(int value)
    {
      return OnConfigureInternal(bp => bp.StartArmySquadsCount = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.MaxArmySquadsCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetMaxArmySquadsCount(int value)
    {
      return OnConfigureInternal(bp => bp.MaxArmySquadsCount = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_StoryModeBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintKingdomBuff"/></param>
    [Generated]
    public KingdomRootConfigurator SetStoryModeBuff(string value)
    {
      return OnConfigureInternal(bp => bp.m_StoryModeBuff = BlueprintTool.GetRef<BlueprintKingdomBuffReference>(value));
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_CasualModeBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintKingdomBuff"/></param>
    [Generated]
    public KingdomRootConfigurator SetCasualModeBuff(string value)
    {
      return OnConfigureInternal(bp => bp.m_CasualModeBuff = BlueprintTool.GetRef<BlueprintKingdomBuffReference>(value));
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.Village"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetVillage(KingdomRoot.SettlementLevelData value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Village = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.Town"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetTown(KingdomRoot.SettlementLevelData value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Town = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.City"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetCity(KingdomRoot.SettlementLevelData value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.City = value);
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.Stats"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator AddToStats(params KingdomRoot.StatData[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Stats = CommonTool.Append(bp.Stats, values));
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.Stats"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator RemoveFromStats(params KingdomRoot.StatData[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Stats = bp.Stats.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_EntryPoint"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintAreaEnterPoint"/></param>
    [Generated]
    public KingdomRootConfigurator SetEntryPoint(string value)
    {
      return OnConfigureInternal(bp => bp.m_EntryPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(value));
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_Regions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintRegion"/></param>
    [Generated]
    public KingdomRootConfigurator AddToRegions(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Regions = CommonTool.Append(bp.m_Regions, values.Select(name => BlueprintTool.GetRef<BlueprintRegionReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_Regions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintRegion"/></param>
    [Generated]
    public KingdomRootConfigurator RemoveFromRegions(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintRegionReference>(name));
            bp.m_Regions =
                bp.m_Regions
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_Locations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintGlobalMapPoint"/></param>
    [Generated]
    public KingdomRootConfigurator AddToLocations(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Locations = CommonTool.Append(bp.m_Locations, values.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_Locations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintGlobalMapPoint"/></param>
    [Generated]
    public KingdomRootConfigurator RemoveFromLocations(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(name));
            bp.m_Locations =
                bp.m_Locations
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.ArtisanTierChances"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator AddToArtisanTierChances(params int[] values)
    {
      return OnConfigureInternal(bp => bp.ArtisanTierChances = CommonTool.Append(bp.ArtisanTierChances, values));
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.ArtisanTierChances"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator RemoveFromArtisanTierChances(params int[] values)
    {
      return OnConfigureInternal(bp => bp.ArtisanTierChances = bp.ArtisanTierChances.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.ArtisanTierChancesRequest"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator AddToArtisanTierChancesRequest(params int[] values)
    {
      return OnConfigureInternal(bp => bp.ArtisanTierChancesRequest = CommonTool.Append(bp.ArtisanTierChancesRequest, values));
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.ArtisanTierChancesRequest"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator RemoveFromArtisanTierChancesRequest(params int[] values)
    {
      return OnConfigureInternal(bp => bp.ArtisanTierChancesRequest = bp.ArtisanTierChancesRequest.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.ArtisanMasterpieceChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetArtisanMasterpieceChance(float value)
    {
      return OnConfigureInternal(bp => bp.ArtisanMasterpieceChance = value);
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.DifficultyDCMod"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator AddToDifficultyDCMod(params int[] values)
    {
      return OnConfigureInternal(bp => bp.DifficultyDCMod = CommonTool.Append(bp.DifficultyDCMod, values));
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.DifficultyDCMod"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator RemoveFromDifficultyDCMod(params int[] values)
    {
      return OnConfigureInternal(bp => bp.DifficultyDCMod = bp.DifficultyDCMod.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.AutoCheatResources"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetAutoCheatResources(KingdomResourcesAmount value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.AutoCheatResources = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.AutoCheatResourcesPerDay"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetAutoCheatResourcesPerDay(KingdomResourcesAmount value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.AutoCheatResourcesPerDay = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.AviaryTimeReduction"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetAviaryTimeReduction(int value)
    {
      return OnConfigureInternal(bp => bp.AviaryTimeReduction = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.ProjectRefundFactor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetProjectRefundFactor(float value)
    {
      return OnConfigureInternal(bp => bp.ProjectRefundFactor = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.RankUps"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetRankUps(KingdomRankUpsRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.RankUps = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.SiegeCooldownHours"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetSiegeCooldownHours(int value)
    {
      return OnConfigureInternal(bp => bp.SiegeCooldownHours = value);
    }
  }
}
