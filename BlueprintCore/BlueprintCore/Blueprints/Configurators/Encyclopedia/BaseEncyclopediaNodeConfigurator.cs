//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Encyclopedia;
using Kingmaker.Localization;
using Kingmaker.Utility;
using System;
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
    protected BaseEncyclopediaNodeConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintEncyclopediaNode>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Title = copyFrom.Title;
          bp.m_Expanded = copyFrom.m_Expanded;
          bp.ChildPages = copyFrom.ChildPages;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintEncyclopediaNode.Title"/>
    /// </summary>
    ///
    /// <param name="title">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetTitle(LocalString title)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Title = title?.LocalizedString;
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetChildPages(params Blueprint<BlueprintEncyclopediaPageReference>[] childPages)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ChildPages = childPages.Select(bp => bp.Reference).ToList();
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToChildPages(params Blueprint<BlueprintEncyclopediaPageReference>[] childPages)
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromChildPages(params Blueprint<BlueprintEncyclopediaPageReference>[] childPages)
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
    public TBuilder RemoveFromChildPages(Func<BlueprintEncyclopediaPageReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ChildPages is null) { return; }
          bp.ChildPages = bp.ChildPages.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintEncyclopediaNode.ChildPages"/>
    /// </summary>
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
    public TBuilder ModifyChildPages(Action<BlueprintEncyclopediaPageReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ChildPages is null) { return; }
          bp.ChildPages.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Title is null)
      {
        Blueprint.Title = Utils.Constants.Empty.String;
      }
      if (Blueprint.ChildPages is null)
      {
        Blueprint.ChildPages = new();
      }
    }
  }
}
