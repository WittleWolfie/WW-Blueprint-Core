//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintFeatureSelectMythicSpellbook"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseFeatureSelectMythicSpellbookConfigurator<T, TBuilder>
    : BaseFeatureConfigurator<T, TBuilder>
    where T : BlueprintFeatureSelectMythicSpellbook
    where TBuilder : BaseFeatureSelectMythicSpellbookConfigurator<T, TBuilder>
  {
    protected BaseFeatureSelectMythicSpellbookConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFeatureSelectMythicSpellbook.m_CachedItems"/>
    /// </summary>
    public TBuilder SetCachedItems(params IFeatureSelectionItem[] cachedItems)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(cachedItems);
          bp.m_CachedItems = cachedItems.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintFeatureSelectMythicSpellbook.m_CachedItems"/>
    /// </summary>
    public TBuilder AddToCachedItems(params IFeatureSelectionItem[] cachedItems)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CachedItems = bp.m_CachedItems ?? new();
          bp.m_CachedItems.AddRange(cachedItems);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintFeatureSelectMythicSpellbook.m_CachedItems"/>
    /// </summary>
    public TBuilder RemoveFromCachedItems(params IFeatureSelectionItem[] cachedItems)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedItems is null) { return; }
          bp.m_CachedItems = bp.m_CachedItems.Where(val => !cachedItems.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintFeatureSelectMythicSpellbook.m_CachedItems"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCachedItems(Func<IFeatureSelectionItem, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedItems is null) { return; }
          bp.m_CachedItems = bp.m_CachedItems.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintFeatureSelectMythicSpellbook.m_CachedItems"/>
    /// </summary>
    public TBuilder ClearCachedItems()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CachedItems = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFeatureSelectMythicSpellbook.m_CachedItems"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCachedItems(Action<IFeatureSelectionItem> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedItems is null) { return; }
          bp.m_CachedItems.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFeatureSelectMythicSpellbook.m_AllowedSpellbooks"/>
    /// </summary>
    ///
    /// <param name="allowedSpellbooks">
    /// <para>
    /// Blueprint of type BlueprintSpellbook. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAllowedSpellbooks(params Blueprint<BlueprintSpellbookReference>[] allowedSpellbooks)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AllowedSpellbooks = allowedSpellbooks.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintFeatureSelectMythicSpellbook.m_AllowedSpellbooks"/>
    /// </summary>
    ///
    /// <param name="allowedSpellbooks">
    /// <para>
    /// Blueprint of type BlueprintSpellbook. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToAllowedSpellbooks(params Blueprint<BlueprintSpellbookReference>[] allowedSpellbooks)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AllowedSpellbooks = bp.m_AllowedSpellbooks ?? new BlueprintSpellbookReference[0];
          bp.m_AllowedSpellbooks = CommonTool.Append(bp.m_AllowedSpellbooks, allowedSpellbooks.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintFeatureSelectMythicSpellbook.m_AllowedSpellbooks"/>
    /// </summary>
    ///
    /// <param name="allowedSpellbooks">
    /// <para>
    /// Blueprint of type BlueprintSpellbook. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAllowedSpellbooks(params Blueprint<BlueprintSpellbookReference>[] allowedSpellbooks)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AllowedSpellbooks is null) { return; }
          bp.m_AllowedSpellbooks = bp.m_AllowedSpellbooks.Where(val => !allowedSpellbooks.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintFeatureSelectMythicSpellbook.m_AllowedSpellbooks"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromAllowedSpellbooks(Func<BlueprintSpellbookReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AllowedSpellbooks is null) { return; }
          bp.m_AllowedSpellbooks = bp.m_AllowedSpellbooks.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintFeatureSelectMythicSpellbook.m_AllowedSpellbooks"/>
    /// </summary>
    public TBuilder ClearAllowedSpellbooks()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AllowedSpellbooks = new BlueprintSpellbookReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFeatureSelectMythicSpellbook.m_AllowedSpellbooks"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyAllowedSpellbooks(Action<BlueprintSpellbookReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AllowedSpellbooks is null) { return; }
          bp.m_AllowedSpellbooks.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFeatureSelectMythicSpellbook.m_MythicSpellList"/>
    /// </summary>
    ///
    /// <param name="mythicSpellList">
    /// <para>
    /// Blueprint of type BlueprintSpellList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetMythicSpellList(Blueprint<BlueprintSpellListReference> mythicSpellList)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MythicSpellList = mythicSpellList?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFeatureSelectMythicSpellbook.m_MythicSpellList"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMythicSpellList(Action<BlueprintSpellListReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MythicSpellList is null) { return; }
          action.Invoke(bp.m_MythicSpellList);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFeatureSelectMythicSpellbook.m_SpellKnownForSpontaneous"/>
    /// </summary>
    ///
    /// <param name="spellKnownForSpontaneous">
    /// <para>
    /// InfoBox: Table should be based on mythic level (not caster level!)
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintSpellsTable. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSpellKnownForSpontaneous(Blueprint<BlueprintSpellsTableReference> spellKnownForSpontaneous)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SpellKnownForSpontaneous = spellKnownForSpontaneous?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFeatureSelectMythicSpellbook.m_SpellKnownForSpontaneous"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpellKnownForSpontaneous(Action<BlueprintSpellsTableReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SpellKnownForSpontaneous is null) { return; }
          action.Invoke(bp.m_SpellKnownForSpontaneous);
        });
    }
  }
}
