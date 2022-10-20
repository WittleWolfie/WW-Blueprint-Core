//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.ResourceLinks;
using Kingmaker.Utility;
using Owlcat.Runtime.Visual.Effects.WeatherSystem;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintPhotoModeRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BasePhotoModeRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintPhotoModeRoot
    where TBuilder : BasePhotoModeRootConfigurator<T, TBuilder>
  {
    protected BasePhotoModeRootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintPhotoModeRoot>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_WeatherProfiles = copyFrom.m_WeatherProfiles;
          bp.Frames = copyFrom.Frames;
          bp.Stickers = copyFrom.Stickers;
          bp.Icons = copyFrom.Icons;
          bp.SkyBoxes = copyFrom.SkyBoxes;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintPhotoModeRoot>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_WeatherProfiles = copyFrom.m_WeatherProfiles;
          bp.Frames = copyFrom.Frames;
          bp.Stickers = copyFrom.Stickers;
          bp.Icons = copyFrom.Icons;
          bp.SkyBoxes = copyFrom.SkyBoxes;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintPhotoModeRoot.m_WeatherProfiles"/>
    /// </summary>
    public TBuilder SetWeatherProfiles(params WeatherProfile[] weatherProfiles)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(weatherProfiles);
          bp.m_WeatherProfiles = weatherProfiles;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintPhotoModeRoot.m_WeatherProfiles"/>
    /// </summary>
    public TBuilder AddToWeatherProfiles(params WeatherProfile[] weatherProfiles)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_WeatherProfiles = bp.m_WeatherProfiles ?? new WeatherProfile[0];
          bp.m_WeatherProfiles = CommonTool.Append(bp.m_WeatherProfiles, weatherProfiles);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintPhotoModeRoot.m_WeatherProfiles"/>
    /// </summary>
    public TBuilder RemoveFromWeatherProfiles(params WeatherProfile[] weatherProfiles)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_WeatherProfiles is null) { return; }
          bp.m_WeatherProfiles = bp.m_WeatherProfiles.Where(val => !weatherProfiles.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintPhotoModeRoot.m_WeatherProfiles"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromWeatherProfiles(Func<WeatherProfile, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_WeatherProfiles is null) { return; }
          bp.m_WeatherProfiles = bp.m_WeatherProfiles.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintPhotoModeRoot.m_WeatherProfiles"/>
    /// </summary>
    public TBuilder ClearWeatherProfiles()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_WeatherProfiles = new WeatherProfile[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintPhotoModeRoot.m_WeatherProfiles"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyWeatherProfiles(Action<WeatherProfile> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_WeatherProfiles is null) { return; }
          bp.m_WeatherProfiles.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintPhotoModeRoot.Frames"/>
    /// </summary>
    ///
    /// <param name="frames">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder SetFrames(params AssetLink<SpriteLink>[] frames)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Frames = frames?.Select(entry => entry?.Get())?.ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintPhotoModeRoot.Frames"/>
    /// </summary>
    ///
    /// <param name="frames">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder AddToFrames(params AssetLink<SpriteLink>[] frames)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Frames = bp.Frames ?? new SpriteLink[0];
          bp.Frames = CommonTool.Append(bp.Frames, frames?.Select(entry => entry?.Get()).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintPhotoModeRoot.Frames"/>
    /// </summary>
    ///
    /// <param name="frames">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder RemoveFromFrames(params AssetLink<SpriteLink>[] frames)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Frames is null) { return; }
          var convertedParams = frames.Select(entry => entry?.Get());
          bp.Frames = bp.Frames.Where(val => !convertedParams.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintPhotoModeRoot.Frames"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromFrames(Func<SpriteLink, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Frames is null) { return; }
          bp.Frames = bp.Frames.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintPhotoModeRoot.Frames"/>
    /// </summary>
    public TBuilder ClearFrames()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Frames = new SpriteLink[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintPhotoModeRoot.Frames"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyFrames(Action<SpriteLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Frames is null) { return; }
          bp.Frames.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintPhotoModeRoot.Stickers"/>
    /// </summary>
    ///
    /// <param name="stickers">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder SetStickers(params AssetLink<SpriteLink>[] stickers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Stickers = stickers?.Select(entry => entry?.Get())?.ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintPhotoModeRoot.Stickers"/>
    /// </summary>
    ///
    /// <param name="stickers">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder AddToStickers(params AssetLink<SpriteLink>[] stickers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Stickers = bp.Stickers ?? new SpriteLink[0];
          bp.Stickers = CommonTool.Append(bp.Stickers, stickers?.Select(entry => entry?.Get()).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintPhotoModeRoot.Stickers"/>
    /// </summary>
    ///
    /// <param name="stickers">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder RemoveFromStickers(params AssetLink<SpriteLink>[] stickers)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Stickers is null) { return; }
          var convertedParams = stickers.Select(entry => entry?.Get());
          bp.Stickers = bp.Stickers.Where(val => !convertedParams.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintPhotoModeRoot.Stickers"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromStickers(Func<SpriteLink, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Stickers is null) { return; }
          bp.Stickers = bp.Stickers.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintPhotoModeRoot.Stickers"/>
    /// </summary>
    public TBuilder ClearStickers()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Stickers = new SpriteLink[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintPhotoModeRoot.Stickers"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyStickers(Action<SpriteLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Stickers is null) { return; }
          bp.Stickers.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintPhotoModeRoot.Icons"/>
    /// </summary>
    ///
    /// <param name="icons">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder SetIcons(params AssetLink<SpriteLink>[] icons)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Icons = icons?.Select(entry => entry?.Get())?.ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintPhotoModeRoot.Icons"/>
    /// </summary>
    ///
    /// <param name="icons">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder AddToIcons(params AssetLink<SpriteLink>[] icons)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Icons = bp.Icons ?? new SpriteLink[0];
          bp.Icons = CommonTool.Append(bp.Icons, icons?.Select(entry => entry?.Get()).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintPhotoModeRoot.Icons"/>
    /// </summary>
    ///
    /// <param name="icons">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder RemoveFromIcons(params AssetLink<SpriteLink>[] icons)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Icons is null) { return; }
          var convertedParams = icons.Select(entry => entry?.Get());
          bp.Icons = bp.Icons.Where(val => !convertedParams.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintPhotoModeRoot.Icons"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromIcons(Func<SpriteLink, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Icons is null) { return; }
          bp.Icons = bp.Icons.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintPhotoModeRoot.Icons"/>
    /// </summary>
    public TBuilder ClearIcons()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Icons = new SpriteLink[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintPhotoModeRoot.Icons"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyIcons(Action<SpriteLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Icons is null) { return; }
          bp.Icons.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintPhotoModeRoot.SkyBoxes"/>
    /// </summary>
    public TBuilder SetSkyBoxes(params MaterialLink[] skyBoxes)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(skyBoxes);
          bp.SkyBoxes = skyBoxes;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintPhotoModeRoot.SkyBoxes"/>
    /// </summary>
    public TBuilder AddToSkyBoxes(params MaterialLink[] skyBoxes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SkyBoxes = bp.SkyBoxes ?? new MaterialLink[0];
          bp.SkyBoxes = CommonTool.Append(bp.SkyBoxes, skyBoxes);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintPhotoModeRoot.SkyBoxes"/>
    /// </summary>
    public TBuilder RemoveFromSkyBoxes(params MaterialLink[] skyBoxes)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SkyBoxes is null) { return; }
          bp.SkyBoxes = bp.SkyBoxes.Where(val => !skyBoxes.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintPhotoModeRoot.SkyBoxes"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromSkyBoxes(Func<MaterialLink, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SkyBoxes is null) { return; }
          bp.SkyBoxes = bp.SkyBoxes.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintPhotoModeRoot.SkyBoxes"/>
    /// </summary>
    public TBuilder ClearSkyBoxes()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SkyBoxes = new MaterialLink[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintPhotoModeRoot.SkyBoxes"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifySkyBoxes(Action<MaterialLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SkyBoxes is null) { return; }
          bp.SkyBoxes.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_WeatherProfiles is null)
      {
        Blueprint.m_WeatherProfiles = new WeatherProfile[0];
      }
      if (Blueprint.Frames is null)
      {
        Blueprint.Frames = new SpriteLink[0];
      }
      if (Blueprint.Stickers is null)
      {
        Blueprint.Stickers = new SpriteLink[0];
      }
      if (Blueprint.Icons is null)
      {
        Blueprint.Icons = new SpriteLink[0];
      }
      if (Blueprint.SkyBoxes is null)
      {
        Blueprint.SkyBoxes = new MaterialLink[0];
      }
    }
  }
}
