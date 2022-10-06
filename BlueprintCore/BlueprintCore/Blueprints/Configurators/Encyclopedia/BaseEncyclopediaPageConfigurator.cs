//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Encyclopedia;
using Kingmaker.Blueprints.Encyclopedia.Blocks;
using Kingmaker.Utility;
using System;
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
    protected BaseEncyclopediaPageConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintEncyclopediaPage>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_ParentAsset = copyFrom.m_ParentAsset;
          bp.Blocks = copyFrom.Blocks;
          bp.ConsoleBlocks = copyFrom.ConsoleBlocks;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintEncyclopediaPage>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_ParentAsset = copyFrom.m_ParentAsset;
          bp.Blocks = copyFrom.Blocks;
          bp.ConsoleBlocks = copyFrom.ConsoleBlocks;
        });
    }

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
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetParentAsset(Blueprint<BlueprintEncyclopediaNodeReference> parentAsset)
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
    public TBuilder SetBlocks(params BlueprintEncyclopediaBlock[] blocks)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(blocks);
          bp.Blocks = blocks.ToList();
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
          bp.Blocks = bp.Blocks.Where(e => !predicate(e)).ToList();
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

    /// <summary>
    /// Sets the value of <see cref="BlueprintEncyclopediaPage.ConsoleBlocks"/>
    /// </summary>
    public TBuilder SetConsoleBlocks(params BlueprintEncyclopediaBlock[] consoleBlocks)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(consoleBlocks);
          bp.ConsoleBlocks = consoleBlocks.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintEncyclopediaPage.ConsoleBlocks"/>
    /// </summary>
    public TBuilder AddToConsoleBlocks(params BlueprintEncyclopediaBlock[] consoleBlocks)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ConsoleBlocks = bp.ConsoleBlocks ?? new();
          bp.ConsoleBlocks.AddRange(consoleBlocks);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintEncyclopediaPage.ConsoleBlocks"/>
    /// </summary>
    public TBuilder RemoveFromConsoleBlocks(params BlueprintEncyclopediaBlock[] consoleBlocks)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ConsoleBlocks is null) { return; }
          bp.ConsoleBlocks = bp.ConsoleBlocks.Where(val => !consoleBlocks.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintEncyclopediaPage.ConsoleBlocks"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromConsoleBlocks(Func<BlueprintEncyclopediaBlock, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ConsoleBlocks is null) { return; }
          bp.ConsoleBlocks = bp.ConsoleBlocks.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintEncyclopediaPage.ConsoleBlocks"/>
    /// </summary>
    public TBuilder ClearConsoleBlocks()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ConsoleBlocks = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintEncyclopediaPage.ConsoleBlocks"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyConsoleBlocks(Action<BlueprintEncyclopediaBlock> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ConsoleBlocks is null) { return; }
          bp.ConsoleBlocks.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_ParentAsset is null)
      {
        Blueprint.m_ParentAsset = BlueprintTool.GetRef<BlueprintEncyclopediaNodeReference>(null);
      }
      if (Blueprint.Blocks is null)
      {
        Blueprint.Blocks = new();
      }
      if (Blueprint.ConsoleBlocks is null)
      {
        Blueprint.ConsoleBlocks = new();
      }
    }
  }
}
