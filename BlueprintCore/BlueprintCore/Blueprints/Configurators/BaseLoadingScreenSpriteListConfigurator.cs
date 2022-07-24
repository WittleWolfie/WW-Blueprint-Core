//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.ResourceLinks;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintLoadingScreenSpriteList"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseLoadingScreenSpriteListConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintLoadingScreenSpriteList
    where TBuilder : BaseLoadingScreenSpriteListConfigurator<T, TBuilder>
  {
    protected BaseLoadingScreenSpriteListConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintLoadingScreenSpriteList.m_GenericSpritesLink"/>
    /// </summary>
    ///
    /// <param name="genericSpritesLink">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder SetGenericSpritesLink(params AssetLink<SpriteLink>[] genericSpritesLink)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_GenericSpritesLink = genericSpritesLink?.Select(entry => entry?.Get())?.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintLoadingScreenSpriteList.m_GenericSpritesLink"/>
    /// </summary>
    ///
    /// <param name="genericSpritesLink">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder AddToGenericSpritesLink(params AssetLink<SpriteLink>[] genericSpritesLink)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_GenericSpritesLink = bp.m_GenericSpritesLink ?? new();
          bp.m_GenericSpritesLink.AddRange(genericSpritesLink?.Select(entry => entry?.Get()));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintLoadingScreenSpriteList.m_GenericSpritesLink"/>
    /// </summary>
    ///
    /// <param name="genericSpritesLink">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder RemoveFromGenericSpritesLink(params AssetLink<SpriteLink>[] genericSpritesLink)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_GenericSpritesLink is null) { return; }
          var convertedParams = genericSpritesLink.Select(entry => entry?.Get());
          bp.m_GenericSpritesLink = bp.m_GenericSpritesLink.Where(val => !convertedParams.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintLoadingScreenSpriteList.m_GenericSpritesLink"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromGenericSpritesLink(Func<SpriteLink, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_GenericSpritesLink is null) { return; }
          bp.m_GenericSpritesLink = bp.m_GenericSpritesLink.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintLoadingScreenSpriteList.m_GenericSpritesLink"/>
    /// </summary>
    public TBuilder ClearGenericSpritesLink()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_GenericSpritesLink = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintLoadingScreenSpriteList.m_GenericSpritesLink"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyGenericSpritesLink(Action<SpriteLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_GenericSpritesLink is null) { return; }
          bp.m_GenericSpritesLink.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintLoadingScreenSpriteList.m_SettingTypeScreensList"/>
    /// </summary>
    public TBuilder SetSettingTypeScreensList(params BlueprintLoadingScreenSpriteList.SettingTypeScreens[] settingTypeScreensList)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(settingTypeScreensList);
          bp.m_SettingTypeScreensList = settingTypeScreensList.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintLoadingScreenSpriteList.m_SettingTypeScreensList"/>
    /// </summary>
    public TBuilder AddToSettingTypeScreensList(params BlueprintLoadingScreenSpriteList.SettingTypeScreens[] settingTypeScreensList)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SettingTypeScreensList = bp.m_SettingTypeScreensList ?? new();
          bp.m_SettingTypeScreensList.AddRange(settingTypeScreensList);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintLoadingScreenSpriteList.m_SettingTypeScreensList"/>
    /// </summary>
    public TBuilder RemoveFromSettingTypeScreensList(params BlueprintLoadingScreenSpriteList.SettingTypeScreens[] settingTypeScreensList)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SettingTypeScreensList is null) { return; }
          bp.m_SettingTypeScreensList = bp.m_SettingTypeScreensList.Where(val => !settingTypeScreensList.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintLoadingScreenSpriteList.m_SettingTypeScreensList"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromSettingTypeScreensList(Func<BlueprintLoadingScreenSpriteList.SettingTypeScreens, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SettingTypeScreensList is null) { return; }
          bp.m_SettingTypeScreensList = bp.m_SettingTypeScreensList.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintLoadingScreenSpriteList.m_SettingTypeScreensList"/>
    /// </summary>
    public TBuilder ClearSettingTypeScreensList()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SettingTypeScreensList = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintLoadingScreenSpriteList.m_SettingTypeScreensList"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifySettingTypeScreensList(Action<BlueprintLoadingScreenSpriteList.SettingTypeScreens> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SettingTypeScreensList is null) { return; }
          bp.m_SettingTypeScreensList.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_GenericSpritesLink is null)
      {
        Blueprint.m_GenericSpritesLink = new();
      }
      if (Blueprint.m_SettingTypeScreensList is null)
      {
        Blueprint.m_SettingTypeScreensList = new();
      }
    }
  }
}
