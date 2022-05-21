//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.QuestSystem;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Classes.Experience;
using Kingmaker.Blueprints.Quests;
using Kingmaker.Designers.EventConditionActionSystem.ObjectiveEvents;
using Kingmaker.ElementsSystem;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Localization;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Quests
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintQuestObjective"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseQuestObjectiveConfigurator<T, TBuilder>
    : BaseFactConfigurator<T, TBuilder>
    where T : BlueprintQuestObjective
    where TBuilder : BaseQuestObjectiveConfigurator<T, TBuilder>
  {
    protected BaseQuestObjectiveConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintQuestObjective.m_Addendums"/>
    /// </summary>
    ///
    /// <param name="addendums">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAddendums(params Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference>[] addendums)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Addendums = addendums.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintQuestObjective.m_Addendums"/>
    /// </summary>
    ///
    /// <param name="addendums">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToAddendums(params Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference>[] addendums)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Addendums = bp.m_Addendums ?? new();
          bp.m_Addendums.AddRange(addendums.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintQuestObjective.m_Addendums"/>
    /// </summary>
    ///
    /// <param name="addendums">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAddendums(params Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference>[] addendums)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Addendums is null) { return; }
          bp.m_Addendums = bp.m_Addendums.Where(val => !addendums.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintQuestObjective.m_Addendums"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="addendums">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAddendums(Func<BlueprintQuestObjectiveReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Addendums is null) { return; }
          bp.m_Addendums = bp.m_Addendums.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintQuestObjective.m_Addendums"/>
    /// </summary>
    ///
    /// <param name="addendums">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearAddendums()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Addendums = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestObjective.m_Addendums"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="addendums">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyAddendums(Action<BlueprintQuestObjectiveReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Addendums is null) { return; }
          bp.m_Addendums.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintQuestObjective.m_Areas"/>
    /// </summary>
    ///
    /// <param name="areas">
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAreas(params Blueprint<BlueprintArea, BlueprintAreaReference>[] areas)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Areas = areas.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintQuestObjective.m_Areas"/>
    /// </summary>
    ///
    /// <param name="areas">
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToAreas(params Blueprint<BlueprintArea, BlueprintAreaReference>[] areas)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Areas = bp.m_Areas ?? new();
          bp.m_Areas.AddRange(areas.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintQuestObjective.m_Areas"/>
    /// </summary>
    ///
    /// <param name="areas">
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAreas(params Blueprint<BlueprintArea, BlueprintAreaReference>[] areas)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Areas is null) { return; }
          bp.m_Areas = bp.m_Areas.Where(val => !areas.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintQuestObjective.m_Areas"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="areas">
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAreas(Func<BlueprintAreaReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Areas is null) { return; }
          bp.m_Areas = bp.m_Areas.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintQuestObjective.m_Areas"/>
    /// </summary>
    ///
    /// <param name="areas">
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearAreas()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Areas = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestObjective.m_Areas"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="areas">
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyAreas(Action<BlueprintAreaReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Areas is null) { return; }
          bp.m_Areas.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintQuestObjective.Title"/>
    /// </summary>
    public TBuilder SetTitle(LocalizedString title)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Title = title;
          if (bp.Title is null)
          {
            bp.Title = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestObjective.Title"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTitle(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Title is null) { return; }
          action.Invoke(bp.Title);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintQuestObjective.Locations"/>
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetLocations(params Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>[] locations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Locations = locations.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintQuestObjective.Locations"/>
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToLocations(params Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>[] locations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Locations = bp.Locations ?? new();
          bp.Locations.AddRange(locations.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintQuestObjective.Locations"/>
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromLocations(params Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>[] locations)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Locations is null) { return; }
          bp.Locations = bp.Locations.Where(val => !locations.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintQuestObjective.Locations"/> that match the provided predicate.
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromLocations(Func<BlueprintGlobalMapPoint.Reference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Locations is null) { return; }
          bp.Locations = bp.Locations.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintQuestObjective.Locations"/>
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearLocations()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Locations = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestObjective.Locations"/> by invoking the provided action on each element.
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyLocations(Action<BlueprintGlobalMapPoint.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Locations is null) { return; }
          bp.Locations.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintQuestObjective.MultiEntranceEntries"/>
    /// </summary>
    ///
    /// <param name="multiEntranceEntries">
    /// <para>
    /// Blueprint of type BlueprintMultiEntranceEntry. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetMultiEntranceEntries(params Blueprint<BlueprintMultiEntranceEntry, BlueprintMultiEntranceEntry.Reference>[] multiEntranceEntries)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MultiEntranceEntries = multiEntranceEntries.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintQuestObjective.MultiEntranceEntries"/>
    /// </summary>
    ///
    /// <param name="multiEntranceEntries">
    /// <para>
    /// Blueprint of type BlueprintMultiEntranceEntry. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToMultiEntranceEntries(params Blueprint<BlueprintMultiEntranceEntry, BlueprintMultiEntranceEntry.Reference>[] multiEntranceEntries)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MultiEntranceEntries = bp.MultiEntranceEntries ?? new();
          bp.MultiEntranceEntries.AddRange(multiEntranceEntries.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintQuestObjective.MultiEntranceEntries"/>
    /// </summary>
    ///
    /// <param name="multiEntranceEntries">
    /// <para>
    /// Blueprint of type BlueprintMultiEntranceEntry. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromMultiEntranceEntries(params Blueprint<BlueprintMultiEntranceEntry, BlueprintMultiEntranceEntry.Reference>[] multiEntranceEntries)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.MultiEntranceEntries is null) { return; }
          bp.MultiEntranceEntries = bp.MultiEntranceEntries.Where(val => !multiEntranceEntries.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintQuestObjective.MultiEntranceEntries"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="multiEntranceEntries">
    /// <para>
    /// Blueprint of type BlueprintMultiEntranceEntry. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromMultiEntranceEntries(Func<BlueprintMultiEntranceEntry.Reference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.MultiEntranceEntries is null) { return; }
          bp.MultiEntranceEntries = bp.MultiEntranceEntries.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintQuestObjective.MultiEntranceEntries"/>
    /// </summary>
    ///
    /// <param name="multiEntranceEntries">
    /// <para>
    /// Blueprint of type BlueprintMultiEntranceEntry. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearMultiEntranceEntries()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MultiEntranceEntries = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestObjective.MultiEntranceEntries"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="multiEntranceEntries">
    /// <para>
    /// Blueprint of type BlueprintMultiEntranceEntry. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyMultiEntranceEntries(Action<BlueprintMultiEntranceEntry.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.MultiEntranceEntries is null) { return; }
          bp.MultiEntranceEntries.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintQuestObjective.Description"/>
    /// </summary>
    public TBuilder SetDescription(LocalizedString description)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Description = description;
          if (bp.Description is null)
          {
            bp.Description = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestObjective.Description"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDescription(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Description is null) { return; }
          action.Invoke(bp.Description);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintQuestObjective.AutoFailDays"/>
    /// </summary>
    public TBuilder SetAutoFailDays(int autoFailDays)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AutoFailDays = autoFailDays;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestObjective.AutoFailDays"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAutoFailDays(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AutoFailDays);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintQuestObjective.IsFakeFail"/>
    /// </summary>
    public TBuilder SetIsFakeFail(bool isFakeFail = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsFakeFail = isFakeFail;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestObjective.IsFakeFail"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIsFakeFail(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.IsFakeFail);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintQuestObjective.StartOnKingdomTime"/>
    /// </summary>
    public TBuilder SetStartOnKingdomTime(bool startOnKingdomTime = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StartOnKingdomTime = startOnKingdomTime;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestObjective.StartOnKingdomTime"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyStartOnKingdomTime(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.StartOnKingdomTime);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintQuestObjective.m_FinishParent"/>
    /// </summary>
    public TBuilder SetFinishParent(bool finishParent = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_FinishParent = finishParent;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestObjective.m_FinishParent"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFinishParent(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_FinishParent);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintQuestObjective.m_Hidden"/>
    /// </summary>
    public TBuilder SetHidden(bool hidden = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Hidden = hidden;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestObjective.m_Hidden"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHidden(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_Hidden);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintQuestObjective.m_NextObjectives"/>
    /// </summary>
    ///
    /// <param name="nextObjectives">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetNextObjectives(params Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference>[] nextObjectives)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_NextObjectives = nextObjectives.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintQuestObjective.m_NextObjectives"/>
    /// </summary>
    ///
    /// <param name="nextObjectives">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToNextObjectives(params Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference>[] nextObjectives)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_NextObjectives = bp.m_NextObjectives ?? new();
          bp.m_NextObjectives.AddRange(nextObjectives.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintQuestObjective.m_NextObjectives"/>
    /// </summary>
    ///
    /// <param name="nextObjectives">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromNextObjectives(params Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference>[] nextObjectives)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_NextObjectives is null) { return; }
          bp.m_NextObjectives = bp.m_NextObjectives.Where(val => !nextObjectives.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintQuestObjective.m_NextObjectives"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="nextObjectives">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromNextObjectives(Func<BlueprintQuestObjectiveReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_NextObjectives is null) { return; }
          bp.m_NextObjectives = bp.m_NextObjectives.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintQuestObjective.m_NextObjectives"/>
    /// </summary>
    ///
    /// <param name="nextObjectives">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearNextObjectives()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_NextObjectives = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestObjective.m_NextObjectives"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="nextObjectives">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyNextObjectives(Action<BlueprintQuestObjectiveReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_NextObjectives is null) { return; }
          bp.m_NextObjectives.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintQuestObjective.m_Quest"/>
    /// </summary>
    ///
    /// <param name="quest">
    /// <para>
    /// Blueprint of type BlueprintQuest. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetQuest(Blueprint<BlueprintQuest, BlueprintQuestReference> quest)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Quest = quest?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestObjective.m_Quest"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="quest">
    /// <para>
    /// Blueprint of type BlueprintQuest. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyQuest(Action<BlueprintQuestReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Quest is null) { return; }
          action.Invoke(bp.m_Quest);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintQuestObjective.m_Type"/>
    /// </summary>
    public TBuilder SetType(BlueprintQuestObjective.Type type)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Type = type;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestObjective.m_Type"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyType(Action<BlueprintQuestObjective.Type> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_Type);
        });
    }

    /// <summary>
    /// Adds <see cref="Experience"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>00_FindEchoLair</term><description>876fc5d40aa5d8b47ac0138cf0a680ae</description></item>
    /// <item><term>CR7_GhoulHuntmaster_RangerRanged</term><description>e884bd90f8936a743ac534bba620c549</description></item>
    /// <item><term>Ziforian_normal</term><description>7ef2998dbeb7fda43a47ce842f4d142d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="playerGainsNoExp">
    /// <para>
    /// InfoBox: When true, Exp will be used in encounter CR calculation, but player will not gained it
    /// </para>
    /// </param>
    public TBuilder AddExperience(
        IntEvaluator? count = null,
        int? cR = null,
        bool? dummy = null,
        EncounterType? encounter = null,
        float? modifier = null,
        bool? playerGainsNoExp = null)
    {
      var component = new Experience();
      Validate(count);
      component.Count = count ?? component.Count;
      component.CR = cR ?? component.CR;
      component.Dummy = dummy ?? component.Dummy;
      component.Encounter = encounter ?? component.Encounter;
      component.Modifier = modifier ?? component.Modifier;
      component.PlayerGainsNoExp = playerGainsNoExp ?? component.PlayerGainsNoExp;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ObjectiveStatusTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Events/ObjectiveStatusTrigger
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>01_GoToCamp</term><description>10d044829fd19a54eb85cae569fc009f</description></item>
    /// <item><term>Obj1_FixAlignmentLich</term><description>d14da774c4afbff43bf605a164f1715c</description></item>
    /// <item><term>SosielQ1_HiddenFail</term><description>19b7d800c358c104280ddf5ade6a7b55</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddObjectiveStatusTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? conditions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        QuestObjectiveState? objectiveState = null)
    {
      var component = new ObjectiveStatusTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.Conditions = conditions?.Build() ?? component.Conditions;
      if (component.Conditions is null)
      {
        component.Conditions = Utils.Constants.Empty.Conditions;
      }
      component.objectiveState = objectiveState ?? component.objectiveState;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }
  }
}
