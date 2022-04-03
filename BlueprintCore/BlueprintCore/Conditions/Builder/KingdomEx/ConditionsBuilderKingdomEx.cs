//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Armies.Components;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Artisans;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Kingdom.Conditions;
using Kingmaker.Kingdom.Flags;
using Kingmaker.Kingdom.Settlements;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using System.Collections.Generic;
using System.Linq;

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
    public static ConditionsBuilder ArmyInLocationDefeated(
        this ConditionsBuilder builder,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPointReference>? location = null,
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
    public static ConditionsBuilder AutoKingdom(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<AutoKingdom>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="BuildingHasNeighbours"/>
    /// </summary>
    ///
    /// <param name="specificBuildings">
    /// Blueprint of type BlueprintSettlementBuilding. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder BuildingHasNeighbours(
        this ConditionsBuilder builder,
        bool? anywhereInTown = null,
        bool negate = false,
        List<Blueprint<BlueprintSettlementBuilding, BlueprintSettlementBuildingReference>>? specificBuildings = null)
    {
      var element = ElementTool.Create<BuildingHasNeighbours>();
      element.AnywhereInTown = anywhereInTown ?? element.AnywhereInTown;
      element.Not = negate;
      element.m_SpecificBuildings = specificBuildings?.Select(bp => bp.Reference)?.ToArray() ?? element.m_SpecificBuildings;
      if (element.m_SpecificBuildings is null)
      {
        element.m_SpecificBuildings = new BlueprintSettlementBuildingReference[0];
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionGarrisonClear"/>
    /// </summary>
    ///
    /// <param name="globalMapPoint">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder ContextConditionGarrisonClear(
        this ConditionsBuilder builder,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPointReference>? globalMapPoint = null,
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
    /// Adds <see cref="DaysTillNextMonth"/>
    /// </summary>
    public static ConditionsBuilder DaysTillNextMonth(
        this ConditionsBuilder builder,
        bool? atMost = null,
        int? days = null,
        bool negate = false)
    {
      var element = ElementTool.Create<DaysTillNextMonth>();
      element.AtMost = atMost ?? element.AtMost;
      element.Days = days ?? element.Days;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="EventLifetime"/>
    /// </summary>
    public static ConditionsBuilder EventLifetime(
        this ConditionsBuilder builder,
        int? lessThan = null,
        int? moreThan = null,
        bool negate = false)
    {
      var element = ElementTool.Create<EventLifetime>();
      element.LessThan = lessThan ?? element.LessThan;
      element.MoreThan = moreThan ?? element.MoreThan;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HasTacticalMorale"/>
    /// </summary>
    public static ConditionsBuilder HasTacticalMorale(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<HasTacticalMorale>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomAlignmentIs"/>
    /// </summary>
    public static ConditionsBuilder KingdomAlignmentIs(
        this ConditionsBuilder builder,
        AlignmentMaskType? alignment = null,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomAlignmentIs>();
      element.Alignment = alignment ?? element.Alignment;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomAllArmiesInRegionDefeated"/>
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
    public static ConditionsBuilder KingdomAllArmiesInRegionDefeated(
        this ConditionsBuilder builder,
        bool negate = false,
        Blueprint<BlueprintRegion, BlueprintRegionReference>? region = null)
    {
      var element = ElementTool.Create<KingdomAllArmiesInRegionDefeated>();
      element.Not = negate;
      element.m_Region = region?.Reference ?? element.m_Region;
      if (element.m_Region is null)
      {
        element.m_Region = BlueprintTool.GetRef<BlueprintRegionReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomArtisanState"/>
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
    public static ConditionsBuilder KingdomArtisanState(
        this ConditionsBuilder builder,
        KingdomArtisanState.CheckType? _Check = null,
        Blueprint<BlueprintKingdomArtisan, BlueprintKingdomArtisanReference>? artisan = null,
        bool negate = false,
        int? tier = null)
    {
      var element = ElementTool.Create<KingdomArtisanState>();
      element._Check = _Check ?? element._Check;
      element.m_Artisan = artisan?.Reference ?? element.m_Artisan;
      if (element.m_Artisan is null)
      {
        element.m_Artisan = BlueprintTool.GetRef<BlueprintKingdomArtisanReference>(null);
      }
      element.Not = negate;
      element.Tier = tier ?? element.Tier;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomBuffIsActive"/>
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
    public static ConditionsBuilder KingdomBuffIsActive(
        this ConditionsBuilder builder,
        Blueprint<BlueprintKingdomBuff, BlueprintKingdomBuffReference>? blueprint = null,
        bool negate = false,
        Blueprint<BlueprintRegion, BlueprintRegionReference>? region = null)
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
    /// Adds <see cref="KingdomDay"/>
    /// </summary>
    public static ConditionsBuilder KingdomDay(
        this ConditionsBuilder builder,
        bool? atMost = null,
        int? day = null,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomDay>();
      element.AtMost = atMost ?? element.AtMost;
      element.Day = day ?? element.Day;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomEventCanStart"/>
    /// </summary>
    ///
    /// <param name="eventValue">
    /// Blueprint of type BlueprintKingdomEvent. You can pass in the blueprint using:
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
    public static ConditionsBuilder KingdomEventCanStart(
        this ConditionsBuilder builder,
        Blueprint<BlueprintKingdomEvent, BlueprintKingdomEventReference>? eventValue = null,
        bool negate = false,
        Blueprint<BlueprintRegion, BlueprintRegionReference>? region = null)
    {
      var element = ElementTool.Create<KingdomEventCanStart>();
      element.m_Event = eventValue?.Reference ?? element.m_Event;
      if (element.m_Event is null)
      {
        element.m_Event = BlueprintTool.GetRef<BlueprintKingdomEventReference>(null);
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
    /// Adds <see cref="KingdomEventIsActive"/>
    /// </summary>
    ///
    /// <param name="eventValue">
    /// Blueprint of type BlueprintKingdomEvent. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder KingdomEventIsActive(
        this ConditionsBuilder builder,
        Blueprint<BlueprintKingdomEvent, BlueprintKingdomEventReference>? eventValue = null,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomEventIsActive>();
      element.m_Event = eventValue?.Reference ?? element.m_Event;
      if (element.m_Event is null)
      {
        element.m_Event = BlueprintTool.GetRef<BlueprintKingdomEventReference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomEventIsBeingResolved"/>
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
    public static ConditionsBuilder KingdomEventIsBeingResolved(
        this ConditionsBuilder builder,
        Blueprint<BlueprintKingdomEventBase, BlueprintKingdomEventBaseReference>? eventValue = null,
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
    public static ConditionsBuilder KingdomExists(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomExists>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomHasResolvableEvent"/>
    /// </summary>
    public static ConditionsBuilder KingdomHasResolvableEvent(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomHasResolvableEvent>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomHasUpgradeableSettlement"/>
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
    public static ConditionsBuilder KingdomHasUpgradeableSettlement(
        this ConditionsBuilder builder,
        SettlementState.LevelType? level = null,
        bool negate = false,
        Blueprint<BlueprintSettlement, BlueprintSettlement.Reference>? specificSettlement = null)
    {
      var element = ElementTool.Create<KingdomHasUpgradeableSettlement>();
      element.Level = level ?? element.Level;
      element.Not = negate;
      element.m_SpecificSettlement = specificSettlement?.Reference ?? element.m_SpecificSettlement;
      if (element.m_SpecificSettlement is null)
      {
        element.m_SpecificSettlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomIsVisible"/>
    /// </summary>
    public static ConditionsBuilder KingdomIsVisible(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomIsVisible>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomLeaderIs"/>
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
    public static ConditionsBuilder KingdomLeaderIs(
        this ConditionsBuilder builder,
        bool? allowCustomCompanions = null,
        LeaderType? leader = null,
        bool negate = false,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? unit = null)
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
    /// <param name="flag">
    /// Blueprint of type BlueprintKingdomMoraleFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder KingdomMoraleFlagCondition(
        this ConditionsBuilder builder,
        Blueprint<BlueprintKingdomMoraleFlag, BlueprintKingdomMoraleFlag.Reference>? flag = null,
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
    public static ConditionsBuilder KingdomProjectIsAvailable(
        this ConditionsBuilder builder,
        bool? checkLeader = null,
        bool? checkResources = null,
        bool? finishableThisMonth = null,
        bool negate = false,
        Blueprint<BlueprintKingdomProject, BlueprintKingdomProjectReference>? project = null)
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
    public static ConditionsBuilder KingdomProjectIsDone(
        this ConditionsBuilder builder,
        bool negate = false,
        Blueprint<BlueprintKingdomProject, BlueprintKingdomProjectReference>? project = null)
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
    public static ConditionsBuilder KingdomRegionIsConquered(
        this ConditionsBuilder builder,
        bool negate = false,
        Blueprint<BlueprintRegion, BlueprintRegionReference>? region = null)
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
    /// Adds <see cref="KingdomRegionIsUpgraded"/>
    /// </summary>
    ///
    /// <param name="eventValue">
    /// Blueprint of type BlueprintKingdomUpgrade. You can pass in the blueprint using:
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
    public static ConditionsBuilder KingdomRegionIsUpgraded(
        this ConditionsBuilder builder,
        Blueprint<BlueprintKingdomUpgrade, BlueprintKingdomUpgradeReference>? eventValue = null,
        bool negate = false,
        Blueprint<BlueprintRegion, BlueprintRegionReference>? region = null)
    {
      var element = ElementTool.Create<KingdomRegionIsUpgraded>();
      element.m_Event = eventValue?.Reference ?? element.m_Event;
      if (element.m_Event is null)
      {
        element.m_Event = BlueprintTool.GetRef<BlueprintKingdomUpgradeReference>(null);
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
    /// Adds <see cref="KingdomSettlementCount"/>
    /// </summary>
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
    /// Adds <see cref="KingdomSettlementHasBuilding"/>
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
    public static ConditionsBuilder KingdomSettlementHasBuilding(
        this ConditionsBuilder builder,
        Blueprint<BlueprintSettlementBuilding, BlueprintSettlementBuildingReference>? building = null,
        bool negate = false,
        Blueprint<BlueprintSettlement, BlueprintSettlement.Reference>? settlement = null)
    {
      var element = ElementTool.Create<KingdomSettlementHasBuilding>();
      element.m_Building = building?.Reference ?? element.m_Building;
      if (element.m_Building is null)
      {
        element.m_Building = BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(null);
      }
      element.Not = negate;
      element.m_Settlement = settlement?.Reference ?? element.m_Settlement;
      if (element.m_Settlement is null)
      {
        element.m_Settlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomStatCheck"/>
    /// </summary>
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
    /// Adds <see cref="KingdomStatIsMaximum"/>
    /// </summary>
    public static ConditionsBuilder KingdomStatIsMaximum(
        this ConditionsBuilder builder,
        bool negate = false,
        KingdomStats.Type? statType = null)
    {
      var element = ElementTool.Create<KingdomStatIsMaximum>();
      element.Not = negate;
      element.StatType = statType ?? element.StatType;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomTaskResolvedBy"/>
    /// </summary>
    public static ConditionsBuilder KingdomTaskResolvedBy(
        this ConditionsBuilder builder,
        LeaderType[]? leaders = null,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomTaskResolvedBy>();
      element.Leaders = leaders ?? element.Leaders;
      if (element.Leaders is null)
      {
        element.Leaders = new LeaderType[0];
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomUnrestCheck"/>
    /// </summary>
    public static ConditionsBuilder KingdomUnrestCheck(
        this ConditionsBuilder builder,
        bool? atMost = null,
        bool negate = false,
        KingdomStatusType? value = null)
    {
      var element = ElementTool.Create<KingdomUnrestCheck>();
      element.AtMost = atMost ?? element.AtMost;
      element.Not = negate;
      element.Value = value ?? element.Value;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatSquadHitPointsCondition"/>
    /// </summary>
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
