//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Encyclopedia;
using Kingmaker.Utility;
using Owlcat.Runtime.UI.ConsoleTools.GamepadInput;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Encyclopedia
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintEncyclopediaChapter"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseEncyclopediaChapterConfigurator<T, TBuilder>
    : BaseEncyclopediaPageConfigurator<T, TBuilder>
    where T : BlueprintEncyclopediaChapter
    where TBuilder : BaseEncyclopediaChapterConfigurator<T, TBuilder>
  {
    protected BaseEncyclopediaChapterConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintEncyclopediaChapter>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Platforms = copyFrom.Platforms;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintEncyclopediaChapter.Platforms"/>
    /// </summary>
    public TBuilder SetPlatforms(params ConsoleType[] platforms)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Platforms = platforms.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintEncyclopediaChapter.Platforms"/>
    /// </summary>
    public TBuilder AddToPlatforms(params ConsoleType[] platforms)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Platforms = bp.Platforms ?? new();
          bp.Platforms.AddRange(platforms);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintEncyclopediaChapter.Platforms"/>
    /// </summary>
    public TBuilder RemoveFromPlatforms(params ConsoleType[] platforms)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Platforms is null) { return; }
          bp.Platforms = bp.Platforms.Where(val => !platforms.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintEncyclopediaChapter.Platforms"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromPlatforms(Func<ConsoleType, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Platforms is null) { return; }
          bp.Platforms = bp.Platforms.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintEncyclopediaChapter.Platforms"/>
    /// </summary>
    public TBuilder ClearPlatforms()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Platforms = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintEncyclopediaChapter.Platforms"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyPlatforms(Action<ConsoleType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Platforms is null) { return; }
          bp.Platforms.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Platforms is null)
      {
        Blueprint.Platforms = new();
      }
    }
  }
}
