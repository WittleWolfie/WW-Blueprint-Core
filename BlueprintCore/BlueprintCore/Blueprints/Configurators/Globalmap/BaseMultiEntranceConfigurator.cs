//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
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
    protected BaseMultiEntranceConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintMultiEntrance>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Map = copyFrom.Map;
          bp.Name = copyFrom.Name;
          bp.m_Entries = copyFrom.m_Entries;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintMultiEntrance>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Map = copyFrom.Map;
          bp.Name = copyFrom.Name;
          bp.m_Entries = copyFrom.m_Entries;
        });
    }

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
    /// Sets the value of <see cref="BlueprintMultiEntrance.Name"/>
    /// </summary>
    ///
    /// <param name="name">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetName(LocalString name)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Name = name?.LocalizedString;
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetEntries(params Blueprint<BlueprintMultiEntranceEntryReference>[] entries)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Entries = entries.Select(bp => bp.Reference).ToArray();
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToEntries(params Blueprint<BlueprintMultiEntranceEntryReference>[] entries)
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromEntries(params Blueprint<BlueprintMultiEntranceEntryReference>[] entries)
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
    public TBuilder RemoveFromEntries(Func<BlueprintMultiEntranceEntryReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Entries is null) { return; }
          bp.m_Entries = bp.m_Entries.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintMultiEntrance.m_Entries"/>
    /// </summary>
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
    public TBuilder ModifyEntries(Action<BlueprintMultiEntranceEntryReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Entries is null) { return; }
          bp.m_Entries.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Name is null)
      {
        Blueprint.Name = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_Entries is null)
      {
        Blueprint.m_Entries = new BlueprintMultiEntranceEntryReference[0];
      }
    }
  }
}
