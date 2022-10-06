//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
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

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintCrusadeEventTimeline>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Chapters = copyFrom.Chapters;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintCrusadeEventTimeline>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Chapters = copyFrom.Chapters;
        });
    }

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
          bp.Chapters = bp.Chapters.Where(e => !predicate(e)).ToArray();
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

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Chapters is null)
      {
        Blueprint.Chapters = new BlueprintCrusadeEventTimeline.ChapterInfo[0];
      }
    }
  }
}
