//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Encyclopedia;
using Kingmaker.Blueprints.Encyclopedia.Blocks;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Encyclopedia
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintEncyclopediaPage"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseEncyclopediaPageConfigurator<T, TBuilder>
    : BaseEncyclopediaNodeConfigurator<T, TBuilder>
    where T : BlueprintEncyclopediaPage
    where TBuilder : BaseEncyclopediaPageConfigurator<T, TBuilder>
  {
    protected BaseEncyclopediaPageConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintEncyclopediaPage.m_ParentAsset"/>
    /// </summary>
    ///
    /// <param name="parentAsset">
    /// <para>
    /// Blueprint of type BlueprintEncyclopediaNode. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetParentAsset(Blueprint<BlueprintEncyclopediaNode, BlueprintEncyclopediaNodeReference> parentAsset)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ParentAsset = parentAsset?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintEncyclopediaPage.m_ParentAsset"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="parentAsset">
    /// <para>
    /// Blueprint of type BlueprintEncyclopediaNode. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyParentAsset(Action<BlueprintEncyclopediaNodeReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ParentAsset is null) { return; }
          action.Invoke(bp.m_ParentAsset);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintEncyclopediaPage.Blocks"/>
    /// </summary>
    public TBuilder SetBlocks(List<BlueprintEncyclopediaBlock> blocks)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in blocks) { Validate(item); }
          bp.Blocks = blocks;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintEncyclopediaPage.Blocks"/>
    /// </summary>
    public TBuilder AddToBlocks(params BlueprintEncyclopediaBlock[] blocks)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Blocks = bp.Blocks ?? new();
          bp.Blocks.AddRange(blocks);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintEncyclopediaPage.Blocks"/>
    /// </summary>
    public TBuilder RemoveFromBlocks(params BlueprintEncyclopediaBlock[] blocks)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Blocks is null) { return; }
          bp.Blocks = bp.Blocks.Where(val => !blocks.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintEncyclopediaPage.Blocks"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromBlocks(Func<BlueprintEncyclopediaBlock, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Blocks is null) { return; }
          bp.Blocks = bp.Blocks.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintEncyclopediaPage.Blocks"/>
    /// </summary>
    public TBuilder ClearBlocks()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Blocks = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintEncyclopediaPage.Blocks"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyBlocks(Action<BlueprintEncyclopediaBlock> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Blocks is null) { return; }
          bp.Blocks.ForEach(action);
        });
    }
  }
}
