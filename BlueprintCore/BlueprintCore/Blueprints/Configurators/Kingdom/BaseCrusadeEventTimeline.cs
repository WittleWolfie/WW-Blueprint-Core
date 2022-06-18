//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCrusadeEventTimeline"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCrusadeEventTimelineConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintCrusadeEventTimeline
    where TBuilder : BaseCrusadeEventTimelineConfigurator<T, TBuilder>
  {
    protected BaseCrusadeEventTimelineConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCrusadeEventTimeline.Chapters"/>
    /// </summary>
    public TBuilder SetChapters(params BlueprintCrusadeEventTimeline.ChapterInfo[] chapters)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(chapters);
          bp.Chapters = chapters;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCrusadeEventTimeline.Chapters"/>
    /// </summary>
    public TBuilder AddToChapters(params BlueprintCrusadeEventTimeline.ChapterInfo[] chapters)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Chapters = bp.Chapters ?? new BlueprintCrusadeEventTimeline.ChapterInfo[0];
          bp.Chapters = CommonTool.Append(bp.Chapters, chapters);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCrusadeEventTimeline.Chapters"/>
    /// </summary>
    public TBuilder RemoveFromChapters(params BlueprintCrusadeEventTimeline.ChapterInfo[] chapters)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Chapters is null) { return; }
          bp.Chapters = bp.Chapters.Where(val => !chapters.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCrusadeEventTimeline.Chapters"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromChapters(Func<BlueprintCrusadeEventTimeline.ChapterInfo, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Chapters is null) { return; }
          bp.Chapters = bp.Chapters.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCrusadeEventTimeline.Chapters"/>
    /// </summary>
    public TBuilder ClearChapters()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Chapters = new BlueprintCrusadeEventTimeline.ChapterInfo[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCrusadeEventTimeline.Chapters"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyChapters(Action<BlueprintCrusadeEventTimeline.ChapterInfo> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Chapters is null) { return; }
          bp.Chapters.ForEach(action);
        });
    }

    protected override void SetDefaults()
    {
      base.SetDefaults();
    
      if (Blueprint.Chapters is null)
      {
        Blueprint.Chapters = new BlueprintCrusadeEventTimeline.ChapterInfo[0];
      }
    }
  }
}
