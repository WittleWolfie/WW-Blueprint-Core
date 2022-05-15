//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Encyclopedia;
using Kingmaker.Localization;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Encyclopedia
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintEncyclopediaNode"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseEncyclopediaNodeConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintEncyclopediaNode
    where TBuilder : BaseEncyclopediaNodeConfigurator<T, TBuilder>
  {
    protected BaseEncyclopediaNodeConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintEncyclopediaNode.Title"/>
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
    /// Modifies <see cref="BlueprintEncyclopediaNode.Title"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintEncyclopediaNode.m_Expanded"/>
    /// </summary>
    public TBuilder SetExpanded(bool expanded = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Expanded = expanded;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintEncyclopediaNode.m_Expanded"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyExpanded(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_Expanded);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintEncyclopediaNode.ChildPages"/>
    /// </summary>
    ///
    /// <param name="childPages">
    /// <para>
    /// Blueprint of type BlueprintEncyclopediaPage. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetChildPages(List<Blueprint<BlueprintEncyclopediaPage, BlueprintEncyclopediaPageReference>> childPages)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ChildPages = childPages?.Select(bp => bp.Reference)?.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintEncyclopediaNode.ChildPages"/>
    /// </summary>
    ///
    /// <param name="childPages">
    /// <para>
    /// Blueprint of type BlueprintEncyclopediaPage. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToChildPages(params Blueprint<BlueprintEncyclopediaPage, BlueprintEncyclopediaPageReference>[] childPages)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ChildPages = bp.ChildPages ?? new();
          bp.ChildPages.AddRange(childPages.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintEncyclopediaNode.ChildPages"/>
    /// </summary>
    ///
    /// <param name="childPages">
    /// <para>
    /// Blueprint of type BlueprintEncyclopediaPage. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromChildPages(params Blueprint<BlueprintEncyclopediaPage, BlueprintEncyclopediaPageReference>[] childPages)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ChildPages is null) { return; }
          bp.ChildPages = bp.ChildPages.Where(val => !childPages.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintEncyclopediaNode.ChildPages"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="childPages">
    /// <para>
    /// Blueprint of type BlueprintEncyclopediaPage. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromChildPages(Func<BlueprintEncyclopediaPageReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ChildPages is null) { return; }
          bp.ChildPages = bp.ChildPages.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintEncyclopediaNode.ChildPages"/>
    /// </summary>
    ///
    /// <param name="childPages">
    /// <para>
    /// Blueprint of type BlueprintEncyclopediaPage. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearChildPages()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ChildPages = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintEncyclopediaNode.ChildPages"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="childPages">
    /// <para>
    /// Blueprint of type BlueprintEncyclopediaPage. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyChildPages(Action<BlueprintEncyclopediaPageReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ChildPages is null) { return; }
          bp.ChildPages.ForEach(action);
        });
    }
  }
}
