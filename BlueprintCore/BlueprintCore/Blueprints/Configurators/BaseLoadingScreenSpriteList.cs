//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ResourceLinks;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
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
    protected BaseLoadingScreenSpriteListConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintLoadingScreenSpriteList.m_GenericSpritesLink"/>
    /// </summary>
    public TBuilder SetGenericSpritesLink(List<SpriteLink> genericSpritesLink)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in genericSpritesLink) { Validate(item); }
          bp.m_GenericSpritesLink = genericSpritesLink;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintLoadingScreenSpriteList.m_GenericSpritesLink"/>
    /// </summary>
    public TBuilder AddToGenericSpritesLink(params SpriteLink[] genericSpritesLink)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_GenericSpritesLink = bp.m_GenericSpritesLink ?? new();
          bp.m_GenericSpritesLink.AddRange(genericSpritesLink);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintLoadingScreenSpriteList.m_GenericSpritesLink"/>
    /// </summary>
    public TBuilder RemoveFromGenericSpritesLink(params SpriteLink[] genericSpritesLink)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_GenericSpritesLink is null) { return; }
          bp.m_GenericSpritesLink = bp.m_GenericSpritesLink.Where(val => !genericSpritesLink.Contains(val)).ToList();
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
          bp.m_GenericSpritesLink = bp.m_GenericSpritesLink.Where(predicate).ToList();
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
    public TBuilder SetSettingTypeScreensList(List<BlueprintLoadingScreenSpriteList.SettingTypeScreens> settingTypeScreensList)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in settingTypeScreensList) { Validate(item); }
          bp.m_SettingTypeScreensList = settingTypeScreensList;
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
          bp.m_SettingTypeScreensList = bp.m_SettingTypeScreensList.Where(predicate).ToList();
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
  }
}