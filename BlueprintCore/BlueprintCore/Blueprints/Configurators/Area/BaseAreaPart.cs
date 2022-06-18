//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.Utility;
using Owlcat.Runtime.Visual.Effects.WeatherSystem;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAreaPart"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAreaPartConfigurator<T, TBuilder>
    : BaseFactConfigurator<T, TBuilder>
    where T : BlueprintAreaPart
    where TBuilder : BaseAreaPartConfigurator<T, TBuilder>
  {
    protected BaseAreaPartConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPart.m_DynamicScene"/>
    /// </summary>
    public TBuilder SetDynamicScene(SceneReference dynamicScene)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(dynamicScene);
          bp.m_DynamicScene = dynamicScene;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.m_DynamicScene"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDynamicScene(Action<SceneReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DynamicScene is null) { return; }
          action.Invoke(bp.m_DynamicScene);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPart.m_StaticScene"/>
    /// </summary>
    public TBuilder SetStaticScene(SceneReference staticScene)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(staticScene);
          bp.m_StaticScene = staticScene;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.m_StaticScene"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyStaticScene(Action<SceneReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_StaticScene is null) { return; }
          action.Invoke(bp.m_StaticScene);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPart.m_LightScene"/>
    /// </summary>
    public TBuilder SetLightScene(SceneReference lightScene)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(lightScene);
          bp.m_LightScene = lightScene;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.m_LightScene"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLightScene(Action<SceneReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_LightScene is null) { return; }
          action.Invoke(bp.m_LightScene);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPart.m_Bounds"/>
    /// </summary>
    public TBuilder SetBounds(AreaPartBounds bounds)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(bounds);
          bp.m_Bounds = bounds;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.m_Bounds"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBounds(Action<AreaPartBounds> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Bounds is null) { return; }
          action.Invoke(bp.m_Bounds);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPart.m_AudioTimeOfDayVariants"/>
    /// </summary>
    public TBuilder SetAudioTimeOfDayVariants(params SceneReference[] audioTimeOfDayVariants)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(audioTimeOfDayVariants);
          bp.m_AudioTimeOfDayVariants = audioTimeOfDayVariants;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAreaPart.m_AudioTimeOfDayVariants"/>
    /// </summary>
    public TBuilder AddToAudioTimeOfDayVariants(params SceneReference[] audioTimeOfDayVariants)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AudioTimeOfDayVariants = bp.m_AudioTimeOfDayVariants ?? new SceneReference[0];
          bp.m_AudioTimeOfDayVariants = CommonTool.Append(bp.m_AudioTimeOfDayVariants, audioTimeOfDayVariants);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPart.m_AudioTimeOfDayVariants"/>
    /// </summary>
    public TBuilder RemoveFromAudioTimeOfDayVariants(params SceneReference[] audioTimeOfDayVariants)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AudioTimeOfDayVariants is null) { return; }
          bp.m_AudioTimeOfDayVariants = bp.m_AudioTimeOfDayVariants.Where(val => !audioTimeOfDayVariants.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPart.m_AudioTimeOfDayVariants"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromAudioTimeOfDayVariants(Func<SceneReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AudioTimeOfDayVariants is null) { return; }
          bp.m_AudioTimeOfDayVariants = bp.m_AudioTimeOfDayVariants.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAreaPart.m_AudioTimeOfDayVariants"/>
    /// </summary>
    public TBuilder ClearAudioTimeOfDayVariants()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AudioTimeOfDayVariants = new SceneReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.m_AudioTimeOfDayVariants"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyAudioTimeOfDayVariants(Action<SceneReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AudioTimeOfDayVariants is null) { return; }
          bp.m_AudioTimeOfDayVariants.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPart.m_SoundBankNames"/>
    /// </summary>
    public TBuilder SetSoundBankNames(params string[] soundBankNames)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SoundBankNames = soundBankNames;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAreaPart.m_SoundBankNames"/>
    /// </summary>
    public TBuilder AddToSoundBankNames(params string[] soundBankNames)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SoundBankNames = bp.m_SoundBankNames ?? new string[0];
          bp.m_SoundBankNames = CommonTool.Append(bp.m_SoundBankNames, soundBankNames);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPart.m_SoundBankNames"/>
    /// </summary>
    public TBuilder RemoveFromSoundBankNames(params string[] soundBankNames)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SoundBankNames is null) { return; }
          bp.m_SoundBankNames = bp.m_SoundBankNames.Where(val => !soundBankNames.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPart.m_SoundBankNames"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromSoundBankNames(Func<string, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SoundBankNames is null) { return; }
          bp.m_SoundBankNames = bp.m_SoundBankNames.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAreaPart.m_SoundBankNames"/>
    /// </summary>
    public TBuilder ClearSoundBankNames()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SoundBankNames = new string[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.m_SoundBankNames"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifySoundBankNames(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SoundBankNames is null) { return; }
          bp.m_SoundBankNames.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPart.m_ManageBanksSeparately"/>
    /// </summary>
    ///
    /// <param name="manageBanksSeparately">
    /// <para>
    /// InfoBox: Turn on to load banks only on enter this area part
    /// </para>
    /// </param>
    public TBuilder SetManageBanksSeparately(bool manageBanksSeparately = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ManageBanksSeparately = manageBanksSeparately;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.m_ManageBanksSeparately"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyManageBanksSeparately(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_ManageBanksSeparately);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPart.m_UnloadBanksDelay"/>
    /// </summary>
    ///
    /// <param name="unloadBanksDelay">
    /// <para>
    /// InfoBox: Delay before area banks unload. Needed to fade all sounds properly
    /// </para>
    /// </param>
    public TBuilder SetUnloadBanksDelay(float unloadBanksDelay)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_UnloadBanksDelay = unloadBanksDelay;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.m_UnloadBanksDelay"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUnloadBanksDelay(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_UnloadBanksDelay);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPart.MusicTheme"/>
    /// </summary>
    public TBuilder SetMusicTheme(string musicTheme)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MusicTheme = musicTheme;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.MusicTheme"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMusicTheme(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.MusicTheme is null) { return; }
          action.Invoke(bp.MusicTheme);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPart.MusicThemeStop"/>
    /// </summary>
    public TBuilder SetMusicThemeStop(string musicThemeStop)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MusicThemeStop = musicThemeStop;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.MusicThemeStop"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMusicThemeStop(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.MusicThemeStop is null) { return; }
          action.Invoke(bp.MusicThemeStop);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPart.m_IndoorType"/>
    /// </summary>
    public TBuilder SetIndoorType(IndoorType indoorType)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IndoorType = indoorType;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.m_IndoorType"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIndoorType(Action<IndoorType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_IndoorType);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPart.m_WeatherProfile"/>
    /// </summary>
    public TBuilder SetWeatherProfile(WeatherProfileExtended weatherProfile)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(weatherProfile);
          bp.m_WeatherProfile = weatherProfile;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.m_WeatherProfile"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyWeatherProfile(Action<WeatherProfileExtended> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_WeatherProfile is null) { return; }
          action.Invoke(bp.m_WeatherProfile);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPart.m_WeatherInclemencyMin"/>
    /// </summary>
    public TBuilder SetWeatherInclemencyMin(InclemencyType weatherInclemencyMin)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_WeatherInclemencyMin = weatherInclemencyMin;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.m_WeatherInclemencyMin"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyWeatherInclemencyMin(Action<InclemencyType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_WeatherInclemencyMin);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPart.m_WeatherInclemencyMax"/>
    /// </summary>
    public TBuilder SetWeatherInclemencyMax(InclemencyType weatherInclemencyMax)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_WeatherInclemencyMax = weatherInclemencyMax;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.m_WeatherInclemencyMax"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyWeatherInclemencyMax(Action<InclemencyType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_WeatherInclemencyMax);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPart.IsSingleLightScene"/>
    /// </summary>
    public TBuilder SetIsSingleLightScene(bool isSingleLightScene = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsSingleLightScene = isSingleLightScene;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.IsSingleLightScene"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIsSingleLightScene(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.IsSingleLightScene);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPart.LocalMapRotation"/>
    /// </summary>
    public TBuilder SetLocalMapRotation(float localMapRotation)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LocalMapRotation = localMapRotation;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.LocalMapRotation"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLocalMapRotation(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.LocalMapRotation);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPart.Setting"/>
    /// </summary>
    public TBuilder SetSetting(AreaSetting setting)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Setting = setting;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.Setting"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySetting(Action<AreaSetting> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Setting);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPart.GraphCache"/>
    /// </summary>
    public TBuilder SetGraphCache(TextAssetLink graphCache)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(graphCache);
          bp.GraphCache = graphCache;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.GraphCache"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyGraphCache(Action<TextAssetLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.GraphCache is null) { return; }
          action.Invoke(bp.GraphCache);
        });
    }

    protected override void SetDefaults()
    {
      base.SetDefaults();
    
      if (Blueprint.m_AudioTimeOfDayVariants is null)
      {
        Blueprint.m_AudioTimeOfDayVariants = new SceneReference[0];
      }
      if (Blueprint.m_SoundBankNames is null)
      {
        Blueprint.m_SoundBankNames = new string[0];
      }
    }
  }
}
