//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Localization;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintMultiEntrance"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseMultiEntranceConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintMultiEntrance
    where TBuilder : BaseMultiEntranceConfigurator<T, TBuilder>
  {
    protected BaseMultiEntranceConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintMultiEntrance.Map"/>
    /// </summary>
    public TBuilder SetMap(BlueprintMultiEntrance.BlueprintMultiEntranceMap map)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Map = map;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintMultiEntrance.Map"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMap(Action<BlueprintMultiEntrance.BlueprintMultiEntranceMap> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Map);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintMultiEntrance.Name"/>
    /// </summary>
    public TBuilder SetName(LocalizedString name)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Name = name;
          if (bp.Name is null)
          {
            bp.Name = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintMultiEntrance.Name"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Name is null) { return; }
          action.Invoke(bp.Name);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintMultiEntrance.m_Entries"/>
    /// </summary>
    ///
    /// <param name="entries">
    /// <para>
    /// Blueprint of type BlueprintMultiEntranceEntry. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetEntries(List<Blueprint<BlueprintMultiEntranceEntry, BlueprintMultiEntranceEntryReference>> entries)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Entries = entries?.Select(bp => bp.Reference)?.ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintMultiEntrance.m_Entries"/>
    /// </summary>
    ///
    /// <param name="entries">
    /// <para>
    /// Blueprint of type BlueprintMultiEntranceEntry. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToEntries(params Blueprint<BlueprintMultiEntranceEntry, BlueprintMultiEntranceEntryReference>[] entries)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Entries = bp.m_Entries ?? new BlueprintMultiEntranceEntryReference[0];
          bp.m_Entries = CommonTool.Append(bp.m_Entries, entries.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintMultiEntrance.m_Entries"/>
    /// </summary>
    ///
    /// <param name="entries">
    /// <para>
    /// Blueprint of type BlueprintMultiEntranceEntry. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromEntries(params Blueprint<BlueprintMultiEntranceEntry, BlueprintMultiEntranceEntryReference>[] entries)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Entries is null) { return; }
          bp.m_Entries = bp.m_Entries.Where(val => !entries.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintMultiEntrance.m_Entries"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="entries">
    /// <para>
    /// Blueprint of type BlueprintMultiEntranceEntry. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromEntries(Func<BlueprintMultiEntranceEntryReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Entries is null) { return; }
          bp.m_Entries = bp.m_Entries.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintMultiEntrance.m_Entries"/>
    /// </summary>
    ///
    /// <param name="entries">
    /// <para>
    /// Blueprint of type BlueprintMultiEntranceEntry. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearEntries()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Entries = new BlueprintMultiEntranceEntryReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintMultiEntrance.m_Entries"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="entries">
    /// <para>
    /// Blueprint of type BlueprintMultiEntranceEntry. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyEntries(Action<BlueprintMultiEntranceEntryReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Entries is null) { return; }
          bp.m_Entries.ForEach(action);
        });
    }
  }
}
