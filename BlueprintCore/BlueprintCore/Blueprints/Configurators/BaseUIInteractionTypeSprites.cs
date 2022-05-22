//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintUIInteractionTypeSprites"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseUIInteractionTypeSpritesConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintUIInteractionTypeSprites
    where TBuilder : BaseUIInteractionTypeSpritesConfigurator<T, TBuilder>
  {
    protected BaseUIInteractionTypeSpritesConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUIInteractionTypeSprites.Main"/>
    /// </summary>
    public TBuilder SetMain(Sprite main)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(main);
          bp.Main = main;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUIInteractionTypeSprites.Main"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMain(Action<Sprite> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Main is null) { return; }
          action.Invoke(bp.Main);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUIInteractionTypeSprites.Active"/>
    /// </summary>
    public TBuilder SetActive(Sprite active)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(active);
          bp.Active = active;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUIInteractionTypeSprites.Active"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyActive(Action<Sprite> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Active is null) { return; }
          action.Invoke(bp.Active);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUIInteractionTypeSprites.Hover"/>
    /// </summary>
    public TBuilder SetHover(Sprite hover)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(hover);
          bp.Hover = hover;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUIInteractionTypeSprites.Hover"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHover(Action<Sprite> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Hover is null) { return; }
          action.Invoke(bp.Hover);
        });
    }
  }
}
