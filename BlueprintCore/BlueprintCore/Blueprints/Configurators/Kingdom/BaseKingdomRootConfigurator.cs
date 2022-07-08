//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Localization;
using Kingmaker.UI.Kingdom;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="KingdomRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseKingdomRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : KingdomRoot
    where TBuilder : BaseKingdomRootConfigurator<T, TBuilder>
  {
    protected BaseKingdomRootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.m_BlueprintRegionCapital"/>
    /// </summary>
    ///
    /// <param name="blueprintRegionCapital">
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
    public TBuilder SetBlueprintRegionCapital(Blueprint<BlueprintRegionReference> blueprintRegionCapital)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BlueprintRegionCapital = blueprintRegionCapital?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_BlueprintRegionCapital"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBlueprintRegionCapital(Action<BlueprintRegionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BlueprintRegionCapital is null) { return; }
          action.Invoke(bp.m_BlueprintRegionCapital);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.m_CapitalSettlement"/>
    /// </summary>
    ///
    /// <param name="capitalSettlement">
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
    public TBuilder SetCapitalSettlement(Blueprint<BlueprintSettlement.Reference> capitalSettlement)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CapitalSettlement = capitalSettlement?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_CapitalSettlement"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCapitalSettlement(Action<BlueprintSettlement.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CapitalSettlement is null) { return; }
          action.Invoke(bp.m_CapitalSettlement);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.m_ThroneRoom"/>
    /// </summary>
    ///
    /// <param name="throneRoom">
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
    public TBuilder SetThroneRoom(Blueprint<BlueprintAreaEnterPointReference> throneRoom)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ThroneRoom = throneRoom?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_ThroneRoom"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyThroneRoom(Action<BlueprintAreaEnterPointReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ThroneRoom is null) { return; }
          action.Invoke(bp.m_ThroneRoom);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.SettlementEmptyMarker"/>
    /// </summary>
    public TBuilder SetSettlementEmptyMarker(KingdomUISettlementEmptyMarker settlementEmptyMarker)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(settlementEmptyMarker);
          bp.SettlementEmptyMarker = settlementEmptyMarker;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.SettlementEmptyMarker"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySettlementEmptyMarker(Action<KingdomUISettlementEmptyMarker> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SettlementEmptyMarker is null) { return; }
          action.Invoke(bp.SettlementEmptyMarker);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.m_StartingEventDecks"/>
    /// </summary>
    ///
    /// <param name="startingEventDecks">
    /// <para>
    /// Blueprint of type BlueprintKingdomDeck. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetStartingEventDecks(params Blueprint<BlueprintKingdomDeckReference>[] startingEventDecks)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StartingEventDecks = startingEventDecks.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="KingdomRoot.m_StartingEventDecks"/>
    /// </summary>
    ///
    /// <param name="startingEventDecks">
    /// <para>
    /// Blueprint of type BlueprintKingdomDeck. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToStartingEventDecks(params Blueprint<BlueprintKingdomDeckReference>[] startingEventDecks)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StartingEventDecks = bp.m_StartingEventDecks ?? new BlueprintKingdomDeckReference[0];
          bp.m_StartingEventDecks = CommonTool.Append(bp.m_StartingEventDecks, startingEventDecks.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomRoot.m_StartingEventDecks"/>
    /// </summary>
    ///
    /// <param name="startingEventDecks">
    /// <para>
    /// Blueprint of type BlueprintKingdomDeck. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromStartingEventDecks(params Blueprint<BlueprintKingdomDeckReference>[] startingEventDecks)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_StartingEventDecks is null) { return; }
          bp.m_StartingEventDecks = bp.m_StartingEventDecks.Where(val => !startingEventDecks.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomRoot.m_StartingEventDecks"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromStartingEventDecks(Func<BlueprintKingdomDeckReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_StartingEventDecks is null) { return; }
          bp.m_StartingEventDecks = bp.m_StartingEventDecks.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="KingdomRoot.m_StartingEventDecks"/>
    /// </summary>
    public TBuilder ClearStartingEventDecks()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StartingEventDecks = new BlueprintKingdomDeckReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_StartingEventDecks"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyStartingEventDecks(Action<BlueprintKingdomDeckReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_StartingEventDecks is null) { return; }
          bp.m_StartingEventDecks.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.m_KingdomProjectEvents"/>
    /// </summary>
    ///
    /// <param name="kingdomProjectEvents">
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
    public TBuilder SetKingdomProjectEvents(params Blueprint<BlueprintKingdomProjectReference>[] kingdomProjectEvents)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_KingdomProjectEvents = kingdomProjectEvents.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="KingdomRoot.m_KingdomProjectEvents"/>
    /// </summary>
    ///
    /// <param name="kingdomProjectEvents">
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
    public TBuilder AddToKingdomProjectEvents(params Blueprint<BlueprintKingdomProjectReference>[] kingdomProjectEvents)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_KingdomProjectEvents = bp.m_KingdomProjectEvents ?? new();
          bp.m_KingdomProjectEvents.AddRange(kingdomProjectEvents.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomRoot.m_KingdomProjectEvents"/>
    /// </summary>
    ///
    /// <param name="kingdomProjectEvents">
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
    public TBuilder RemoveFromKingdomProjectEvents(params Blueprint<BlueprintKingdomProjectReference>[] kingdomProjectEvents)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_KingdomProjectEvents is null) { return; }
          bp.m_KingdomProjectEvents = bp.m_KingdomProjectEvents.Where(val => !kingdomProjectEvents.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomRoot.m_KingdomProjectEvents"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromKingdomProjectEvents(Func<BlueprintKingdomProjectReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_KingdomProjectEvents is null) { return; }
          bp.m_KingdomProjectEvents = bp.m_KingdomProjectEvents.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="KingdomRoot.m_KingdomProjectEvents"/>
    /// </summary>
    public TBuilder ClearKingdomProjectEvents()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_KingdomProjectEvents = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_KingdomProjectEvents"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyKingdomProjectEvents(Action<BlueprintKingdomProjectReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_KingdomProjectEvents is null) { return; }
          bp.m_KingdomProjectEvents.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.m_Buildings"/>
    /// </summary>
    ///
    /// <param name="buildings">
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
    public TBuilder SetBuildings(params Blueprint<BlueprintSettlementBuildingReference>[] buildings)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Buildings = buildings.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="KingdomRoot.m_Buildings"/>
    /// </summary>
    ///
    /// <param name="buildings">
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
    public TBuilder AddToBuildings(params Blueprint<BlueprintSettlementBuildingReference>[] buildings)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Buildings = bp.m_Buildings ?? new BlueprintSettlementBuildingReference[0];
          bp.m_Buildings = CommonTool.Append(bp.m_Buildings, buildings.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomRoot.m_Buildings"/>
    /// </summary>
    ///
    /// <param name="buildings">
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
    public TBuilder RemoveFromBuildings(params Blueprint<BlueprintSettlementBuildingReference>[] buildings)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Buildings is null) { return; }
          bp.m_Buildings = bp.m_Buildings.Where(val => !buildings.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomRoot.m_Buildings"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromBuildings(Func<BlueprintSettlementBuildingReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Buildings is null) { return; }
          bp.m_Buildings = bp.m_Buildings.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="KingdomRoot.m_Buildings"/>
    /// </summary>
    public TBuilder ClearBuildings()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Buildings = new BlueprintSettlementBuildingReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_Buildings"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyBuildings(Action<BlueprintSettlementBuildingReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Buildings is null) { return; }
          bp.m_Buildings.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.m_UnrestPriorityDeck"/>
    /// </summary>
    ///
    /// <param name="unrestPriorityDeck">
    /// <para>
    /// Blueprint of type BlueprintKingdomDeck. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetUnrestPriorityDeck(Blueprint<BlueprintKingdomDeckReference> unrestPriorityDeck)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_UnrestPriorityDeck = unrestPriorityDeck?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_UnrestPriorityDeck"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUnrestPriorityDeck(Action<BlueprintKingdomDeckReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_UnrestPriorityDeck is null) { return; }
          action.Invoke(bp.m_UnrestPriorityDeck);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.UnrestDeckTrigger"/>
    /// </summary>
    public TBuilder SetUnrestDeckTrigger(KingdomStatusType unrestDeckTrigger)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UnrestDeckTrigger = unrestDeckTrigger;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.m_UnrestMitigationEvents"/>
    /// </summary>
    ///
    /// <param name="unrestMitigationEvents">
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
    public TBuilder SetUnrestMitigationEvents(params Blueprint<BlueprintKingdomProjectReference>[] unrestMitigationEvents)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_UnrestMitigationEvents = unrestMitigationEvents.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="KingdomRoot.m_UnrestMitigationEvents"/>
    /// </summary>
    ///
    /// <param name="unrestMitigationEvents">
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
    public TBuilder AddToUnrestMitigationEvents(params Blueprint<BlueprintKingdomProjectReference>[] unrestMitigationEvents)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_UnrestMitigationEvents = bp.m_UnrestMitigationEvents ?? new BlueprintKingdomProjectReference[0];
          bp.m_UnrestMitigationEvents = CommonTool.Append(bp.m_UnrestMitigationEvents, unrestMitigationEvents.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomRoot.m_UnrestMitigationEvents"/>
    /// </summary>
    ///
    /// <param name="unrestMitigationEvents">
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
    public TBuilder RemoveFromUnrestMitigationEvents(params Blueprint<BlueprintKingdomProjectReference>[] unrestMitigationEvents)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_UnrestMitigationEvents is null) { return; }
          bp.m_UnrestMitigationEvents = bp.m_UnrestMitigationEvents.Where(val => !unrestMitigationEvents.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomRoot.m_UnrestMitigationEvents"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromUnrestMitigationEvents(Func<BlueprintKingdomProjectReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_UnrestMitigationEvents is null) { return; }
          bp.m_UnrestMitigationEvents = bp.m_UnrestMitigationEvents.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="KingdomRoot.m_UnrestMitigationEvents"/>
    /// </summary>
    public TBuilder ClearUnrestMitigationEvents()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_UnrestMitigationEvents = new BlueprintKingdomProjectReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_UnrestMitigationEvents"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyUnrestMitigationEvents(Action<BlueprintKingdomProjectReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_UnrestMitigationEvents is null) { return; }
          bp.m_UnrestMitigationEvents.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.m_UIRoot"/>
    /// </summary>
    ///
    /// <param name="uIRoot">
    /// <para>
    /// Blueprint of type KingdomUIRoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetUIRoot(Blueprint<KingdomUIRootReference> uIRoot)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_UIRoot = uIRoot?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_UIRoot"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUIRoot(Action<KingdomUIRootReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_UIRoot is null) { return; }
          action.Invoke(bp.m_UIRoot);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.LeaderSlots"/>
    /// </summary>
    public TBuilder SetLeaderSlots(params LeaderSlot[] leaderSlots)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(leaderSlots);
          bp.LeaderSlots = leaderSlots;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="KingdomRoot.LeaderSlots"/>
    /// </summary>
    public TBuilder AddToLeaderSlots(params LeaderSlot[] leaderSlots)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LeaderSlots = bp.LeaderSlots ?? new LeaderSlot[0];
          bp.LeaderSlots = CommonTool.Append(bp.LeaderSlots, leaderSlots);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomRoot.LeaderSlots"/>
    /// </summary>
    public TBuilder RemoveFromLeaderSlots(params LeaderSlot[] leaderSlots)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LeaderSlots is null) { return; }
          bp.LeaderSlots = bp.LeaderSlots.Where(val => !leaderSlots.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomRoot.LeaderSlots"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromLeaderSlots(Func<LeaderSlot, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LeaderSlots is null) { return; }
          bp.LeaderSlots = bp.LeaderSlots.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="KingdomRoot.LeaderSlots"/>
    /// </summary>
    public TBuilder ClearLeaderSlots()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LeaderSlots = new LeaderSlot[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.LeaderSlots"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyLeaderSlots(Action<LeaderSlot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LeaderSlots is null) { return; }
          bp.LeaderSlots.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.m_StartingNPCLeaders"/>
    /// </summary>
    ///
    /// <param name="startingNPCLeaders">
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
    public TBuilder SetStartingNPCLeaders(params Blueprint<BlueprintUnitReference>[] startingNPCLeaders)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StartingNPCLeaders = startingNPCLeaders.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="KingdomRoot.m_StartingNPCLeaders"/>
    /// </summary>
    ///
    /// <param name="startingNPCLeaders">
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
    public TBuilder AddToStartingNPCLeaders(params Blueprint<BlueprintUnitReference>[] startingNPCLeaders)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StartingNPCLeaders = bp.m_StartingNPCLeaders ?? new BlueprintUnitReference[0];
          bp.m_StartingNPCLeaders = CommonTool.Append(bp.m_StartingNPCLeaders, startingNPCLeaders.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomRoot.m_StartingNPCLeaders"/>
    /// </summary>
    ///
    /// <param name="startingNPCLeaders">
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
    public TBuilder RemoveFromStartingNPCLeaders(params Blueprint<BlueprintUnitReference>[] startingNPCLeaders)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_StartingNPCLeaders is null) { return; }
          bp.m_StartingNPCLeaders = bp.m_StartingNPCLeaders.Where(val => !startingNPCLeaders.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomRoot.m_StartingNPCLeaders"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromStartingNPCLeaders(Func<BlueprintUnitReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_StartingNPCLeaders is null) { return; }
          bp.m_StartingNPCLeaders = bp.m_StartingNPCLeaders.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="KingdomRoot.m_StartingNPCLeaders"/>
    /// </summary>
    public TBuilder ClearStartingNPCLeaders()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StartingNPCLeaders = new BlueprintUnitReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_StartingNPCLeaders"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyStartingNPCLeaders(Action<BlueprintUnitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_StartingNPCLeaders is null) { return; }
          bp.m_StartingNPCLeaders.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.m_Timeline"/>
    /// </summary>
    ///
    /// <param name="timeline">
    /// <para>
    /// Blueprint of type BlueprintKingdomEventTimeline. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetTimeline(Blueprint<BlueprintKingdomEventTimelineReference> timeline)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Timeline = timeline?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_Timeline"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTimeline(Action<BlueprintKingdomEventTimelineReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Timeline is null) { return; }
          action.Invoke(bp.m_Timeline);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.m_CrusadeEventsTimeline"/>
    /// </summary>
    ///
    /// <param name="crusadeEventsTimeline">
    /// <para>
    /// Blueprint of type BlueprintCrusadeEventTimeline. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetCrusadeEventsTimeline(Blueprint<BlueprintCrusadeEventTimeline.Reference> crusadeEventsTimeline)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CrusadeEventsTimeline = crusadeEventsTimeline?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_CrusadeEventsTimeline"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCrusadeEventsTimeline(Action<BlueprintCrusadeEventTimeline.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CrusadeEventsTimeline is null) { return; }
          action.Invoke(bp.m_CrusadeEventsTimeline);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.m_RegionUpgradesAvailable"/>
    /// </summary>
    ///
    /// <param name="regionUpgradesAvailable">
    /// <para>
    /// Blueprint of type BlueprintUnlockableFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetRegionUpgradesAvailable(Blueprint<BlueprintUnlockableFlagReference> regionUpgradesAvailable)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_RegionUpgradesAvailable = regionUpgradesAvailable?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_RegionUpgradesAvailable"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRegionUpgradesAvailable(Action<BlueprintUnlockableFlagReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_RegionUpgradesAvailable is null) { return; }
          action.Invoke(bp.m_RegionUpgradesAvailable);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.m_BpVendorItem"/>
    /// </summary>
    ///
    /// <param name="bpVendorItem">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBpVendorItem(Blueprint<BlueprintItemReference> bpVendorItem)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BpVendorItem = bpVendorItem?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_BpVendorItem"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBpVendorItem(Action<BlueprintItemReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BpVendorItem is null) { return; }
          action.Invoke(bp.m_BpVendorItem);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.m_ConsumableEventBonusVendorItem"/>
    /// </summary>
    ///
    /// <param name="consumableEventBonusVendorItem">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetConsumableEventBonusVendorItem(Blueprint<BlueprintItemReference> consumableEventBonusVendorItem)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ConsumableEventBonusVendorItem = consumableEventBonusVendorItem?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_ConsumableEventBonusVendorItem"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyConsumableEventBonusVendorItem(Action<BlueprintItemReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ConsumableEventBonusVendorItem is null) { return; }
          action.Invoke(bp.m_ConsumableEventBonusVendorItem);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.StatIncreaseOnEvent"/>
    /// </summary>
    public TBuilder SetStatIncreaseOnEvent(int statIncreaseOnEvent)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StatIncreaseOnEvent = statIncreaseOnEvent;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.StatMaxRankInBarony"/>
    /// </summary>
    public TBuilder SetStatMaxRankInBarony(int statMaxRankInBarony)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StatMaxRankInBarony = statMaxRankInBarony;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.ResourcesPerEconomyRank"/>
    /// </summary>
    public TBuilder SetResourcesPerEconomyRank(KingdomResourcesAmount resourcesPerEconomyRank)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ResourcesPerEconomyRank = resourcesPerEconomyRank;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.ResourcesPerEconomyRank"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyResourcesPerEconomyRank(Action<KingdomResourcesAmount> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ResourcesPerEconomyRank);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.SettlementCost"/>
    /// </summary>
    public TBuilder SetSettlementCost(KingdomResourcesAmount settlementCost)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SettlementCost = settlementCost;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.SettlementCost"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySettlementCost(Action<KingdomResourcesAmount> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.SettlementCost);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.KingdomStatRankStep"/>
    /// </summary>
    public TBuilder SetKingdomStatRankStep(int kingdomStatRankStep)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.KingdomStatRankStep = kingdomStatRankStep;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.BaronySubsidy"/>
    /// </summary>
    public TBuilder SetBaronySubsidy(KingdomResourcesAmount baronySubsidy)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BaronySubsidy = baronySubsidy;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.BaronySubsidy"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBaronySubsidy(Action<KingdomResourcesAmount> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.BaronySubsidy);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.BaronyResourcesModifier"/>
    /// </summary>
    public TBuilder SetBaronyResourcesModifier(float baronyResourcesModifier)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BaronyResourcesModifier = baronyResourcesModifier;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.ResourcesAtStart"/>
    /// </summary>
    public TBuilder SetResourcesAtStart(KingdomResourcesAmount resourcesAtStart)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ResourcesAtStart = resourcesAtStart;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.ResourcesAtStart"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyResourcesAtStart(Action<KingdomResourcesAmount> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ResourcesAtStart);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.ResourcesAtStartPerTurn"/>
    /// </summary>
    public TBuilder SetResourcesAtStartPerTurn(KingdomResourcesAmount resourcesAtStartPerTurn)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ResourcesAtStartPerTurn = resourcesAtStartPerTurn;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.ResourcesAtStartPerTurn"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyResourcesAtStartPerTurn(Action<KingdomResourcesAmount> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ResourcesAtStartPerTurn);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.ConsumableEventBonusAtStart"/>
    /// </summary>
    public TBuilder SetConsumableEventBonusAtStart(int consumableEventBonusAtStart)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ConsumableEventBonusAtStart = consumableEventBonusAtStart;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.ConsumableEventBonusPerRankUp"/>
    /// </summary>
    public TBuilder SetConsumableEventBonusPerRankUp(int consumableEventBonusPerRankUp)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ConsumableEventBonusPerRankUp = consumableEventBonusPerRankUp;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.ConsumableEventBonusModifierValue"/>
    /// </summary>
    public TBuilder SetConsumableEventBonusModifierValue(int consumableEventBonusModifierValue)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ConsumableEventBonusModifierValue = consumableEventBonusModifierValue;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.CustomLeaderPenalty"/>
    /// </summary>
    public TBuilder SetCustomLeaderPenalty(int customLeaderPenalty)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CustomLeaderPenalty = customLeaderPenalty;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.BuildingSequenceCostMultiplier"/>
    /// </summary>
    public TBuilder SetBuildingSequenceCostMultiplier(float buildingSequenceCostMultiplier)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BuildingSequenceCostMultiplier = buildingSequenceCostMultiplier;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.DefaultMapResourceCost"/>
    /// </summary>
    public TBuilder SetDefaultMapResourceCost(KingdomResourcesAmount defaultMapResourceCost)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DefaultMapResourceCost = defaultMapResourceCost;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.DefaultMapResourceCost"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDefaultMapResourceCost(Action<KingdomResourcesAmount> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.DefaultMapResourceCost);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.RavenVisitDelayDays"/>
    /// </summary>
    public TBuilder SetRavenVisitDelayDays(int ravenVisitDelayDays)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RavenVisitDelayDays = ravenVisitDelayDays;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.DefaultName"/>
    /// </summary>
    ///
    /// <param name="defaultName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetDefaultName(LocalString defaultName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DefaultName = defaultName?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.DefaultName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDefaultName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DefaultName is null) { return; }
          action.Invoke(bp.DefaultName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.MoraleMaxValue"/>
    /// </summary>
    public TBuilder SetMoraleMaxValue(int moraleMaxValue)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MoraleMaxValue = moraleMaxValue;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.MoraleDefaultMaxValue"/>
    /// </summary>
    public TBuilder SetMoraleDefaultMaxValue(int moraleDefaultMaxValue)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MoraleDefaultMaxValue = moraleDefaultMaxValue;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.MoraleMinValue"/>
    /// </summary>
    public TBuilder SetMoraleMinValue(int moraleMinValue)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MoraleMinValue = moraleMinValue;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.MoraleStartValue"/>
    /// </summary>
    public TBuilder SetMoraleStartValue(int moraleStartValue)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MoraleStartValue = moraleStartValue;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.StartArmySquadsCount"/>
    /// </summary>
    public TBuilder SetStartArmySquadsCount(int startArmySquadsCount)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StartArmySquadsCount = startArmySquadsCount;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.MaxArmySquadsCount"/>
    /// </summary>
    ///
    /// <param name="maxArmySquadsCount">
    /// <para>
    /// InfoBox: Army can&amp;apos;t have squads more than that, even with bonuses
    /// </para>
    /// </param>
    public TBuilder SetMaxArmySquadsCount(int maxArmySquadsCount)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaxArmySquadsCount = maxArmySquadsCount;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.m_StoryModeBuff"/>
    /// </summary>
    ///
    /// <param name="storyModeBuff">
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
    public TBuilder SetStoryModeBuff(Blueprint<BlueprintKingdomBuffReference> storyModeBuff)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StoryModeBuff = storyModeBuff?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_StoryModeBuff"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyStoryModeBuff(Action<BlueprintKingdomBuffReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_StoryModeBuff is null) { return; }
          action.Invoke(bp.m_StoryModeBuff);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.m_CasualModeBuff"/>
    /// </summary>
    ///
    /// <param name="casualModeBuff">
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
    public TBuilder SetCasualModeBuff(Blueprint<BlueprintKingdomBuffReference> casualModeBuff)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CasualModeBuff = casualModeBuff?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_CasualModeBuff"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCasualModeBuff(Action<BlueprintKingdomBuffReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CasualModeBuff is null) { return; }
          action.Invoke(bp.m_CasualModeBuff);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.Village"/>
    /// </summary>
    public TBuilder SetVillage(KingdomRoot.SettlementLevelData village)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(village);
          bp.Village = village;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.Village"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyVillage(Action<KingdomRoot.SettlementLevelData> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Village is null) { return; }
          action.Invoke(bp.Village);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.Town"/>
    /// </summary>
    public TBuilder SetTown(KingdomRoot.SettlementLevelData town)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(town);
          bp.Town = town;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.Town"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTown(Action<KingdomRoot.SettlementLevelData> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Town is null) { return; }
          action.Invoke(bp.Town);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.City"/>
    /// </summary>
    public TBuilder SetCity(KingdomRoot.SettlementLevelData city)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(city);
          bp.City = city;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.City"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCity(Action<KingdomRoot.SettlementLevelData> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.City is null) { return; }
          action.Invoke(bp.City);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.Stats"/>
    /// </summary>
    public TBuilder SetStats(params KingdomRoot.StatData[] stats)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(stats);
          bp.Stats = stats;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="KingdomRoot.Stats"/>
    /// </summary>
    public TBuilder AddToStats(params KingdomRoot.StatData[] stats)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Stats = bp.Stats ?? new KingdomRoot.StatData[0];
          bp.Stats = CommonTool.Append(bp.Stats, stats);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomRoot.Stats"/>
    /// </summary>
    public TBuilder RemoveFromStats(params KingdomRoot.StatData[] stats)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Stats is null) { return; }
          bp.Stats = bp.Stats.Where(val => !stats.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomRoot.Stats"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromStats(Func<KingdomRoot.StatData, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Stats is null) { return; }
          bp.Stats = bp.Stats.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="KingdomRoot.Stats"/>
    /// </summary>
    public TBuilder ClearStats()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Stats = new KingdomRoot.StatData[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.Stats"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyStats(Action<KingdomRoot.StatData> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Stats is null) { return; }
          bp.Stats.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.m_EntryPoint"/>
    /// </summary>
    ///
    /// <param name="entryPoint">
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
    public TBuilder SetEntryPoint(Blueprint<BlueprintAreaEnterPointReference> entryPoint)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_EntryPoint = entryPoint?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_EntryPoint"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyEntryPoint(Action<BlueprintAreaEnterPointReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_EntryPoint is null) { return; }
          action.Invoke(bp.m_EntryPoint);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.m_Regions"/>
    /// </summary>
    ///
    /// <param name="regions">
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
    public TBuilder SetRegions(params Blueprint<BlueprintRegionReference>[] regions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Regions = regions.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="KingdomRoot.m_Regions"/>
    /// </summary>
    ///
    /// <param name="regions">
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
    public TBuilder AddToRegions(params Blueprint<BlueprintRegionReference>[] regions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Regions = bp.m_Regions ?? new BlueprintRegionReference[0];
          bp.m_Regions = CommonTool.Append(bp.m_Regions, regions.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomRoot.m_Regions"/>
    /// </summary>
    ///
    /// <param name="regions">
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
    public TBuilder RemoveFromRegions(params Blueprint<BlueprintRegionReference>[] regions)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Regions is null) { return; }
          bp.m_Regions = bp.m_Regions.Where(val => !regions.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomRoot.m_Regions"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromRegions(Func<BlueprintRegionReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Regions is null) { return; }
          bp.m_Regions = bp.m_Regions.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="KingdomRoot.m_Regions"/>
    /// </summary>
    public TBuilder ClearRegions()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Regions = new BlueprintRegionReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_Regions"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyRegions(Action<BlueprintRegionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Regions is null) { return; }
          bp.m_Regions.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.m_Locations"/>
    /// </summary>
    ///
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
    public TBuilder SetLocations(params Blueprint<BlueprintGlobalMapPoint.Reference>[] locations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Locations = locations.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="KingdomRoot.m_Locations"/>
    /// </summary>
    ///
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
    public TBuilder AddToLocations(params Blueprint<BlueprintGlobalMapPoint.Reference>[] locations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Locations = bp.m_Locations ?? new BlueprintGlobalMapPoint.Reference[0];
          bp.m_Locations = CommonTool.Append(bp.m_Locations, locations.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomRoot.m_Locations"/>
    /// </summary>
    ///
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
    public TBuilder RemoveFromLocations(params Blueprint<BlueprintGlobalMapPoint.Reference>[] locations)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Locations is null) { return; }
          bp.m_Locations = bp.m_Locations.Where(val => !locations.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomRoot.m_Locations"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromLocations(Func<BlueprintGlobalMapPoint.Reference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Locations is null) { return; }
          bp.m_Locations = bp.m_Locations.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="KingdomRoot.m_Locations"/>
    /// </summary>
    public TBuilder ClearLocations()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Locations = new BlueprintGlobalMapPoint.Reference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.m_Locations"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyLocations(Action<BlueprintGlobalMapPoint.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Locations is null) { return; }
          bp.m_Locations.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.ArtisanTierChances"/>
    /// </summary>
    public TBuilder SetArtisanTierChances(params int[] artisanTierChances)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ArtisanTierChances = artisanTierChances;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="KingdomRoot.ArtisanTierChances"/>
    /// </summary>
    public TBuilder AddToArtisanTierChances(params int[] artisanTierChances)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ArtisanTierChances = bp.ArtisanTierChances ?? new int[0];
          bp.ArtisanTierChances = CommonTool.Append(bp.ArtisanTierChances, artisanTierChances);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomRoot.ArtisanTierChances"/>
    /// </summary>
    public TBuilder RemoveFromArtisanTierChances(params int[] artisanTierChances)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ArtisanTierChances is null) { return; }
          bp.ArtisanTierChances = bp.ArtisanTierChances.Where(val => !artisanTierChances.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomRoot.ArtisanTierChances"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromArtisanTierChances(Func<int, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ArtisanTierChances is null) { return; }
          bp.ArtisanTierChances = bp.ArtisanTierChances.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="KingdomRoot.ArtisanTierChances"/>
    /// </summary>
    public TBuilder ClearArtisanTierChances()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ArtisanTierChances = new int[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.ArtisanTierChances"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyArtisanTierChances(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ArtisanTierChances is null) { return; }
          bp.ArtisanTierChances.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.ArtisanTierChancesRequest"/>
    /// </summary>
    public TBuilder SetArtisanTierChancesRequest(params int[] artisanTierChancesRequest)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ArtisanTierChancesRequest = artisanTierChancesRequest;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="KingdomRoot.ArtisanTierChancesRequest"/>
    /// </summary>
    public TBuilder AddToArtisanTierChancesRequest(params int[] artisanTierChancesRequest)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ArtisanTierChancesRequest = bp.ArtisanTierChancesRequest ?? new int[0];
          bp.ArtisanTierChancesRequest = CommonTool.Append(bp.ArtisanTierChancesRequest, artisanTierChancesRequest);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomRoot.ArtisanTierChancesRequest"/>
    /// </summary>
    public TBuilder RemoveFromArtisanTierChancesRequest(params int[] artisanTierChancesRequest)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ArtisanTierChancesRequest is null) { return; }
          bp.ArtisanTierChancesRequest = bp.ArtisanTierChancesRequest.Where(val => !artisanTierChancesRequest.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomRoot.ArtisanTierChancesRequest"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromArtisanTierChancesRequest(Func<int, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ArtisanTierChancesRequest is null) { return; }
          bp.ArtisanTierChancesRequest = bp.ArtisanTierChancesRequest.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="KingdomRoot.ArtisanTierChancesRequest"/>
    /// </summary>
    public TBuilder ClearArtisanTierChancesRequest()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ArtisanTierChancesRequest = new int[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.ArtisanTierChancesRequest"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyArtisanTierChancesRequest(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ArtisanTierChancesRequest is null) { return; }
          bp.ArtisanTierChancesRequest.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.ArtisanMasterpieceChance"/>
    /// </summary>
    public TBuilder SetArtisanMasterpieceChance(float artisanMasterpieceChance)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ArtisanMasterpieceChance = artisanMasterpieceChance;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.DifficultyDCMod"/>
    /// </summary>
    public TBuilder SetDifficultyDCMod(params int[] difficultyDCMod)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DifficultyDCMod = difficultyDCMod;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="KingdomRoot.DifficultyDCMod"/>
    /// </summary>
    public TBuilder AddToDifficultyDCMod(params int[] difficultyDCMod)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DifficultyDCMod = bp.DifficultyDCMod ?? new int[0];
          bp.DifficultyDCMod = CommonTool.Append(bp.DifficultyDCMod, difficultyDCMod);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomRoot.DifficultyDCMod"/>
    /// </summary>
    public TBuilder RemoveFromDifficultyDCMod(params int[] difficultyDCMod)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DifficultyDCMod is null) { return; }
          bp.DifficultyDCMod = bp.DifficultyDCMod.Where(val => !difficultyDCMod.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomRoot.DifficultyDCMod"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromDifficultyDCMod(Func<int, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DifficultyDCMod is null) { return; }
          bp.DifficultyDCMod = bp.DifficultyDCMod.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="KingdomRoot.DifficultyDCMod"/>
    /// </summary>
    public TBuilder ClearDifficultyDCMod()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DifficultyDCMod = new int[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.DifficultyDCMod"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyDifficultyDCMod(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DifficultyDCMod is null) { return; }
          bp.DifficultyDCMod.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.AutoCheatResources"/>
    /// </summary>
    public TBuilder SetAutoCheatResources(KingdomResourcesAmount autoCheatResources)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AutoCheatResources = autoCheatResources;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.AutoCheatResources"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAutoCheatResources(Action<KingdomResourcesAmount> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AutoCheatResources);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.AutoCheatResourcesPerDay"/>
    /// </summary>
    public TBuilder SetAutoCheatResourcesPerDay(KingdomResourcesAmount autoCheatResourcesPerDay)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AutoCheatResourcesPerDay = autoCheatResourcesPerDay;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.AutoCheatResourcesPerDay"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAutoCheatResourcesPerDay(Action<KingdomResourcesAmount> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AutoCheatResourcesPerDay);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.AviaryTimeReduction"/>
    /// </summary>
    public TBuilder SetAviaryTimeReduction(int aviaryTimeReduction)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AviaryTimeReduction = aviaryTimeReduction;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.ProjectRefundFactor"/>
    /// </summary>
    public TBuilder SetProjectRefundFactor(float projectRefundFactor)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ProjectRefundFactor = projectRefundFactor;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.RankUps"/>
    /// </summary>
    public TBuilder SetRankUps(KingdomRankUpsRoot rankUps)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(rankUps);
          bp.RankUps = rankUps;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomRoot.RankUps"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRankUps(Action<KingdomRankUpsRoot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RankUps is null) { return; }
          action.Invoke(bp.RankUps);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomRoot.SiegeCooldownHours"/>
    /// </summary>
    public TBuilder SetSiegeCooldownHours(int siegeCooldownHours)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SiegeCooldownHours = siegeCooldownHours;
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_BlueprintRegionCapital is null)
      {
        Blueprint.m_BlueprintRegionCapital = BlueprintTool.GetRef<BlueprintRegionReference>(null);
      }
      if (Blueprint.m_CapitalSettlement is null)
      {
        Blueprint.m_CapitalSettlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(null);
      }
      if (Blueprint.m_ThroneRoom is null)
      {
        Blueprint.m_ThroneRoom = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(null);
      }
      if (Blueprint.m_StartingEventDecks is null)
      {
        Blueprint.m_StartingEventDecks = new BlueprintKingdomDeckReference[0];
      }
      if (Blueprint.m_KingdomProjectEvents is null)
      {
        Blueprint.m_KingdomProjectEvents = new();
      }
      if (Blueprint.m_Buildings is null)
      {
        Blueprint.m_Buildings = new BlueprintSettlementBuildingReference[0];
      }
      if (Blueprint.m_UnrestPriorityDeck is null)
      {
        Blueprint.m_UnrestPriorityDeck = BlueprintTool.GetRef<BlueprintKingdomDeckReference>(null);
      }
      if (Blueprint.m_UnrestMitigationEvents is null)
      {
        Blueprint.m_UnrestMitigationEvents = new BlueprintKingdomProjectReference[0];
      }
      if (Blueprint.m_UIRoot is null)
      {
        Blueprint.m_UIRoot = BlueprintTool.GetRef<KingdomUIRootReference>(null);
      }
      if (Blueprint.LeaderSlots is null)
      {
        Blueprint.LeaderSlots = new LeaderSlot[0];
      }
      if (Blueprint.m_StartingNPCLeaders is null)
      {
        Blueprint.m_StartingNPCLeaders = new BlueprintUnitReference[0];
      }
      if (Blueprint.m_Timeline is null)
      {
        Blueprint.m_Timeline = BlueprintTool.GetRef<BlueprintKingdomEventTimelineReference>(null);
      }
      if (Blueprint.m_CrusadeEventsTimeline is null)
      {
        Blueprint.m_CrusadeEventsTimeline = BlueprintTool.GetRef<BlueprintCrusadeEventTimeline.Reference>(null);
      }
      if (Blueprint.m_RegionUpgradesAvailable is null)
      {
        Blueprint.m_RegionUpgradesAvailable = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(null);
      }
      if (Blueprint.m_BpVendorItem is null)
      {
        Blueprint.m_BpVendorItem = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      if (Blueprint.m_ConsumableEventBonusVendorItem is null)
      {
        Blueprint.m_ConsumableEventBonusVendorItem = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      if (Blueprint.DefaultName is null)
      {
        Blueprint.DefaultName = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_StoryModeBuff is null)
      {
        Blueprint.m_StoryModeBuff = BlueprintTool.GetRef<BlueprintKingdomBuffReference>(null);
      }
      if (Blueprint.m_CasualModeBuff is null)
      {
        Blueprint.m_CasualModeBuff = BlueprintTool.GetRef<BlueprintKingdomBuffReference>(null);
      }
      if (Blueprint.Stats is null)
      {
        Blueprint.Stats = new KingdomRoot.StatData[0];
      }
      if (Blueprint.m_EntryPoint is null)
      {
        Blueprint.m_EntryPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(null);
      }
      if (Blueprint.m_Regions is null)
      {
        Blueprint.m_Regions = new BlueprintRegionReference[0];
      }
      if (Blueprint.m_Locations is null)
      {
        Blueprint.m_Locations = new BlueprintGlobalMapPoint.Reference[0];
      }
      if (Blueprint.ArtisanTierChances is null)
      {
        Blueprint.ArtisanTierChances = new int[0];
      }
      if (Blueprint.ArtisanTierChancesRequest is null)
      {
        Blueprint.ArtisanTierChancesRequest = new int[0];
      }
      if (Blueprint.DifficultyDCMod is null)
      {
        Blueprint.DifficultyDCMod = new int[0];
      }
    }
  }
}
