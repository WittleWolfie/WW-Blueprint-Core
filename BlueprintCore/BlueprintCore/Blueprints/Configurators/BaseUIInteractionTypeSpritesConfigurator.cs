//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
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

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintUIInteractionTypeSprites>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Main = copyFrom.Main;
          bp.Active = copyFrom.Active;
          bp.Hover = copyFrom.Hover;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintUIInteractionTypeSprites>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Main = copyFrom.Main;
          bp.Active = copyFrom.Active;
          bp.Hover = copyFrom.Hover;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUIInteractionTypeSprites.Main"/>
    /// </summary>
    ///
    /// <param name="main">
    /// You can pass in the animation using a Sprite or it's AssetId.
    /// </param>
    public TBuilder SetMain(Asset<Sprite> main)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Main = main?.Get();
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
    ///
    /// <param name="active">
    /// You can pass in the animation using a Sprite or it's AssetId.
    /// </param>
    public TBuilder SetActive(Asset<Sprite> active)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Active = active?.Get();
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
    ///
    /// <param name="hover">
    /// You can pass in the animation using a Sprite or it's AssetId.
    /// </param>
    public TBuilder SetHover(Asset<Sprite> hover)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Hover = hover?.Get();
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
