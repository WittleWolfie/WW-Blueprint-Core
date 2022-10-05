//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
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

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_WeatherProfiles is null)
      {
        Blueprint.m_WeatherProfiles = new WeatherProfile[0];
      }
    }
  }
}
