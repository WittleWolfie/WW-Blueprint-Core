//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Armies.Components;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Conditions;
using Kingmaker.Kingdom.Flags;
using Kingmaker.Kingdom.Settlements;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Conditions;

namespace BlueprintCore.Conditions.Builder.KingdomEx
{
  /// <summary>
  /// Extension to <see cref="ConditionsBuilder"/> for conditions involving the Kingdom and Crusade system.
  /// </summary>
  /// <inheritdoc cref="ConditionsBuilder"/>
  public static class ConditionsBuilderKingdomEx
  {

    /// <summary>
    /// Adds <see cref="AnySettlementUnderSiege"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-236233</term><description>78ddb7dcceaf4dd5b6178807c258909c</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder AnySettlementUnderSiege(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<AnySettlementUnderSiege>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ArmyInLocationDefeated"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-296978</term><description>983af9815687400f897ef380ec8e6b09</description></item>
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
    public static ConditionsBuilder ArmyInLocationDefeated(
        this ConditionsBuilder builder,
        Blueprint<BlueprintGlobalMapPointReference>? location = null,
        bool negate = false)
    {
      var element = ElementTool.Create<ArmyInLocationDefeated>();
      element.m_Location = location?.Reference ?? element.m_Location;
      if (element.m_Location is null)
      {
        element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPointReference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AutoKingdom"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Add3_SearchMoltenScar</term><description>39a11378f06fff740b8211686247d943</description></item>
    /// <item><term>Cue_0252_playerheir</term><description>a8764b751e8fb1240b998546ec6ed292</description></item>
    /// <item><term>PF-232045</term><description>e117b759ee6647e2a156d4c7f0637142</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder AutoKingdom(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<AutoKingdom>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionGarrisonClear"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CreateSettlementFort21</term><description>0b7377f7c46c6aa43bf66af6ec618836</description></item>
    /// <item><term>CreateSettlementFort56</term><description>ece5ff5b715642444b692d9d93b64b9c</description></item>
    /// <item><term>CreateSettlementRiverGarrison</term><description>947bf6259557aeb449557e4bc5228ead</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="globalMapPoint">
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
    public static ConditionsBuilder GarrisonClear(
        this ConditionsBuilder builder,
        Blueprint<BlueprintGlobalMapPointReference>? globalMapPoint = null,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionGarrisonClear>();
      element.m_GlobalMapPoint = globalMapPoint?.Reference ?? element.m_GlobalMapPoint;
      if (element.m_GlobalMapPoint is null)
      {
        element.m_GlobalMapPoint = BlueprintTool.GetRef<BlueprintGlobalMapPointReference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HasTacticalMorale"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Test_Bebilith Blueprint Camping Encounter</term><description>f2f8355d4bc8aa34195eeb2f5cf66645</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder HasTacticalMorale(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<HasTacticalMorale>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomBuffIsActive"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon2FireElementals</term><description>63364fac363349a99dd7fe96ca86dc7c</description></item>
    /// <item><term>Event71DumpExcavation</term><description>b0ca7e2b70c9447da43f7be86164d43c</description></item>
    /// <item><term>Trickster5ThugPaladin</term><description>e83a6a99081d467fb56d8afe1de6a4d5</description></item>
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
    public static ConditionsBuilder KingdomBuffIsActive(
        this ConditionsBuilder builder,
        Blueprint<BlueprintKingdomBuffReference>? blueprint = null,
        bool negate = false,
        Blueprint<BlueprintRegionReference>? region = null)
    {
      var element = ElementTool.Create<KingdomBuffIsActive>();
      element.m_Blueprint = blueprint?.Reference ?? element.m_Blueprint;
      if (element.m_Blueprint is null)
      {
        element.m_Blueprint = BlueprintTool.GetRef<BlueprintKingdomBuffReference>(null);
      }
      element.Not = negate;
      element.m_Region = region?.Reference ?? element.m_Region;
      if (element.m_Region is null)
      {
        element.m_Region = BlueprintTool.GetRef<BlueprintRegionReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomChapterWeek"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-218150</term><description>d7696062df7c4b948e1ce3e1b769fc9a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="week">
    /// <para>
    /// InfoBox: Week number from chapter start. To check chapter use etude checker.
    /// </para>
    /// </param>
    public static ConditionsBuilder KingdomChapterWeek(
        this ConditionsBuilder builder,
        bool negate = false,
        int? week = null)
    {
      var element = ElementTool.Create<KingdomChapterWeek>();
      element.Not = negate;
      element.Week = week ?? element.Week;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomEventIsBeingResolved"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CrusadeEvent04</term><description>e55f2d8389a14e6e999e23a7d1a6d736</description></item>
    /// <item><term>CrusadeEvent46</term><description>4f210692d86841d4bcc6cbeb28bbeeca</description></item>
    /// <item><term>PF-378483</term><description>f5dad497239a41fd96a12d4d1b1b38ef</description></item>
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
    public static ConditionsBuilder KingdomEventIsBeingResolved(
        this ConditionsBuilder builder,
        Blueprint<BlueprintKingdomEventBaseReference>? eventValue = null,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomEventIsBeingResolved>();
      element.m_Event = eventValue?.Reference ?? element.m_Event;
      if (element.m_Event is null)
      {
        element.m_Event = BlueprintTool.GetRef<BlueprintKingdomEventBaseReference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomExists"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter03</term><description>15e0048c7daf0ac4999c2313b58df0e3</description></item>
    /// <item><term>CrusadeTutorial_01_Chapter2Intro</term><description>20073002e0594c88b5af911060e8dde8</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder KingdomExists(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomExists>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomLeaderIs"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0260</term><description>fb07588e668af2f4b93ea5628ab833bc</description></item>
    /// <item><term>Cue_0263</term><description>082fed3c287c9054593eebc2101e79b2</description></item>
    /// <item><term>Cue_0264</term><description>63845fd8cb8868b4f95bdf5cdc3e73b8</description></item>
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
    public static ConditionsBuilder KingdomLeaderIs(
        this ConditionsBuilder builder,
        bool? allowCustomCompanions = null,
        LeaderType? leader = null,
        bool negate = false,
        Blueprint<BlueprintUnitReference>? unit = null)
    {
      var element = ElementTool.Create<KingdomLeaderIs>();
      element.AllowCustomCompanions = allowCustomCompanions ?? element.AllowCustomCompanions;
      element.Leader = leader ?? element.Leader;
      element.Not = negate;
      element.m_Unit = unit?.Reference ?? element.m_Unit;
      if (element.m_Unit is null)
      {
        element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomMoraleFlagCondition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MoraleFlagSiegeChapter3Controller_buff</term><description>bd5bfbd23acd4098b3a89100b61c3ce0</description></item>
    /// <item><term>MoraleFlagSiegeChapter5Controller_buff</term><description>30d599366a9e46fe992f9ca6fdf9365a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="flag">
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
    public static ConditionsBuilder KingdomMoraleFlagCondition(
        this ConditionsBuilder builder,
        Blueprint<BlueprintKingdomMoraleFlag.Reference>? flag = null,
        bool negate = false,
        KingdomMoraleFlag.State? state = null)
    {
      var element = ElementTool.Create<KingdomMoraleFlagCondition>();
      element.m_Flag = flag?.Reference ?? element.m_Flag;
      if (element.m_Flag is null)
      {
        element.m_Flag = BlueprintTool.GetRef<BlueprintKingdomMoraleFlag.Reference>(null);
      }
      element.Not = negate;
      element.m_State = state ?? element.m_State;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomProjectIsAvailable"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Add4_GotoMoltenScar</term><description>f6694c696284e2046b0f064f83c320c2</description></item>
    /// <item><term>Event61DrakePoison</term><description>23bd72781ce34695bc9af2468456b8af</description></item>
    /// <item><term>Trickster5ThugPaladin</term><description>e83a6a99081d467fb56d8afe1de6a4d5</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="project">
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
    public static ConditionsBuilder KingdomProjectIsAvailable(
        this ConditionsBuilder builder,
        bool? checkLeader = null,
        bool? checkResources = null,
        bool? finishableThisMonth = null,
        bool negate = false,
        Blueprint<BlueprintKingdomProjectReference>? project = null)
    {
      var element = ElementTool.Create<KingdomProjectIsAvailable>();
      element.CheckLeader = checkLeader ?? element.CheckLeader;
      element.CheckResources = checkResources ?? element.CheckResources;
      element.FinishableThisMonth = finishableThisMonth ?? element.FinishableThisMonth;
      element.Not = negate;
      element.m_Project = project?.Reference ?? element.m_Project;
      if (element.m_Project is null)
      {
        element.m_Project = BlueprintTool.GetRef<BlueprintKingdomProjectReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomProjectIsDone"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CreateSettlementFort21</term><description>0b7377f7c46c6aa43bf66af6ec618836</description></item>
    /// <item><term>CreateSettlementNearRegill</term><description>8b4cd3ebd7b3f3b4ea201bbfed62fa28</description></item>
    /// <item><term>PF-300995</term><description>f25549e2b0654ca6b20335c374e2258d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="project">
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
    public static ConditionsBuilder KingdomProjectIsDone(
        this ConditionsBuilder builder,
        bool negate = false,
        Blueprint<BlueprintKingdomProjectReference>? project = null)
    {
      var element = ElementTool.Create<KingdomProjectIsDone>();
      element.Not = negate;
      element.m_Project = project?.Reference ?? element.m_Project;
      if (element.m_Project is null)
      {
        element.m_Project = BlueprintTool.GetRef<BlueprintKingdomProjectReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomRankUpConditions"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter05</term><description>5b01aa690202e584888dfc600a4aac0a</description></item>
    /// <item><term>LogisticsRankUp2Project</term><description>e2c032467f1cf0b4d9ee4da1da92857a</description></item>
    /// <item><term>MilitaryRankUp8Project</term><description>11904fe03bcc431d8f8fb0a2d4ca3704</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder KingdomRankUpConditions(
        this ConditionsBuilder builder,
        bool negate = false,
        int? nextRank = null,
        KingdomStats.Type? stat = null)
    {
      var element = ElementTool.Create<KingdomRankUpConditions>();
      element.Not = negate;
      element.NextRank = nextRank ?? element.NextRank;
      element.Stat = stat ?? element.Stat;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomRegionIsConquered"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FlagDiplomacy7CrusadeResourcesForRegions</term><description>8663e81969a647fe9d6e8c3afd7d9172</description></item>
    /// <item><term>KingdomMoraleFlagChapter5Regions</term><description>b01624ee06444738964b678259f31a20</description></item>
    /// <item><term>Obj2_1</term><description>31325a3a01ba44a69d3c205784cc1816</description></item>
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
    public static ConditionsBuilder KingdomRegionIsConquered(
        this ConditionsBuilder builder,
        bool negate = false,
        Blueprint<BlueprintRegionReference>? region = null)
    {
      var element = ElementTool.Create<KingdomRegionIsConquered>();
      element.Not = negate;
      element.m_Region = region?.Reference ?? element.m_Region;
      if (element.m_Region is null)
      {
        element.m_Region = BlueprintTool.GetRef<BlueprintRegionReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomSettlementCount"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SettlementsTracker_buff</term><description>71dd611cd70443fcb04f0dce3bda76ef</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder KingdomSettlementCount(
        this ConditionsBuilder builder,
        int? count = null,
        SettlementState.LevelType? minLevel = null,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomSettlementCount>();
      element.Count = count ?? element.Count;
      element.MinLevel = minLevel ?? element.MinLevel;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomStatCheck"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>26!_SadisticGD_Checker_Sum</term><description>561508e5aeba4d37b7418a363411964d</description></item>
    /// <item><term>LogisticsRankUp3Project</term><description>de0bfee4dca3ebc4aae466ca6e799e01</description></item>
    /// <item><term>PF-252649</term><description>403f8687be754fe39430819391be0c73</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder KingdomStatCheck(
        this ConditionsBuilder builder,
        bool? atMost = null,
        bool? checkRank = null,
        bool negate = false,
        KingdomStats.Type? statType = null,
        int? value = null)
    {
      var element = ElementTool.Create<KingdomStatCheck>();
      element.AtMost = atMost ?? element.AtMost;
      element.CheckRank = checkRank ?? element.CheckRank;
      element.Not = negate;
      element.StatType = statType ?? element.StatType;
      element.Value = value ?? element.Value;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatSquadHitPointsCondition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyFingerOfDeath</term><description>16da1e53252444cc9f14bcf1c72f58fb</description></item>
    /// <item><term>ArmyMeleeCounterAttackFeature</term><description>9f86b8f30438920458feda7313591ec2</description></item>
    /// <item><term>ArmyRangedCounterAttackFeature</term><description>4d59f676f59579944948f8c461731ab8</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="checkInitiatorHP">
    /// <para>
    /// InfoBox: Compares with target&amp;apos;s HP by default
    /// </para>
    /// </param>
    public static ConditionsBuilder TacticalCombatSquadHitPointsCondition(
        this ConditionsBuilder builder,
        bool? checkInitiatorHP = null,
        bool negate = false,
        CompareOperation.Type? operation = null,
        ContextValue? referenceValue = null)
    {
      var element = ElementTool.Create<TacticalCombatSquadHitPointsCondition>();
      element.CheckInitiatorHP = checkInitiatorHP ?? element.CheckInitiatorHP;
      element.Not = negate;
      element.Operation = operation ?? element.Operation;
      element.ReferenceValue = referenceValue ?? element.ReferenceValue;
      if (element.ReferenceValue is null)
      {
        element.ReferenceValue = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="TargetHasArmyTag"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon5BaneOfDemonsAbility</term><description>843145bc1b9b45229c40b1a2128095f0</description></item>
    /// <item><term>RangerBlindingTrapArea</term><description>b4b532d5cd6f81642a6783a93ace06d1</description></item>
    /// <item><term>RitualHealAbility</term><description>08c5571e87eccfc47a8325f530e3693c</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder TargetHasArmyTag(
        this ConditionsBuilder builder,
        bool? needAllTags = null,
        bool negate = false,
        ArmyProperties? tags = null)
    {
      var element = ElementTool.Create<TargetHasArmyTag>();
      element.m_NeedAllTags = needAllTags ?? element.m_NeedAllTags;
      element.Not = negate;
      element.m_Tags = tags ?? element.m_Tags;
      return builder.Add(element);
    }
  }
}
