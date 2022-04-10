using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.Visual.LightSelector;
using Owlcat.Runtime.Visual.Effects.WeatherSystem;
using System;
using System.Linq;

#nullable enable
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
    protected BaseAreaPartConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_DynamicScene"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetDynamicScene(SceneReference dynamicScene)
    {
      ValidateParam(dynamicScene);

      return OnConfigureInternal(
          bp =>
          {
            bp.m_DynamicScene = dynamicScene;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_StaticScene"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetStaticScene(SceneReference staticScene)
    {
      ValidateParam(staticScene);

      return OnConfigureInternal(
          bp =>
          {
            bp.m_StaticScene = staticScene;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_LightScene"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetLightScene(SceneReference lightScene)
    {
      ValidateParam(lightScene);

      return OnConfigureInternal(
          bp =>
          {
            bp.m_LightScene = lightScene;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_Bounds"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetBounds(AreaPartBounds bounds)
    {
      ValidateParam(bounds);

      return OnConfigureInternal(
          bp =>
          {
            bp.m_Bounds = bounds;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_AudioTimeOfDayVariants"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetAudioTimeOfDayVariants(SceneReference[]? audioTimeOfDayVariants)
    {
      ValidateParam(audioTimeOfDayVariants);

      return OnConfigureInternal(
          bp =>
          {
            bp.m_AudioTimeOfDayVariants = audioTimeOfDayVariants;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPart.m_AudioTimeOfDayVariants"/> (Auto Generated)
    /// </summary>
    
    public TBuilder AddToAudioTimeOfDayVariants(params SceneReference[] audioTimeOfDayVariants)
    {
      ValidateParam(audioTimeOfDayVariants);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AudioTimeOfDayVariants = CommonTool.Append(bp.m_AudioTimeOfDayVariants, audioTimeOfDayVariants ?? new SceneReference[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPart.m_AudioTimeOfDayVariants"/> (Auto Generated)
    /// </summary>
    
    public TBuilder RemoveFromAudioTimeOfDayVariants(params SceneReference[] audioTimeOfDayVariants)
    {
      ValidateParam(audioTimeOfDayVariants);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AudioTimeOfDayVariants = bp.m_AudioTimeOfDayVariants.Where(item => !audioTimeOfDayVariants.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_SoundBankNames"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetSoundBankNames(string[]? soundBankNames)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SoundBankNames = soundBankNames;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPart.m_SoundBankNames"/> (Auto Generated)
    /// </summary>
    
    public TBuilder AddToSoundBankNames(params string[] soundBankNames)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SoundBankNames = CommonTool.Append(bp.m_SoundBankNames, soundBankNames ?? new string[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPart.m_SoundBankNames"/> (Auto Generated)
    /// </summary>
    
    public TBuilder RemoveFromSoundBankNames(params string[] soundBankNames)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SoundBankNames = bp.m_SoundBankNames.Where(item => !soundBankNames.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_ManageBanksSeparately"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetManageBanksSeparately(bool manageBanksSeparately)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ManageBanksSeparately = manageBanksSeparately;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_UnloadBanksDelay"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetUnloadBanksDelay(float unloadBanksDelay)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_UnloadBanksDelay = unloadBanksDelay;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.MusicTheme"/> (Auto Generated)
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
    /// Sets <see cref="BlueprintAreaPart.MusicThemeStop"/> (Auto Generated)
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
    /// Sets <see cref="BlueprintAreaPart.m_IndoorType"/> (Auto Generated)
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
    /// Sets <see cref="BlueprintAreaPart.m_WeatherProfile"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetWeatherProfile(WeatherProfileExtended weatherProfile)
    {
      ValidateParam(weatherProfile);

      return OnConfigureInternal(
          bp =>
          {
            bp.m_WeatherProfile = weatherProfile;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_WeatherInclemencyMin"/> (Auto Generated)
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
    /// Sets <see cref="BlueprintAreaPart.m_WeatherInclemencyMax"/> (Auto Generated)
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
    /// Sets <see cref="BlueprintAreaPart.IsSingleLightScene"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetIsSingleLightScene(bool isSingleLightScene)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsSingleLightScene = isSingleLightScene;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.LocalMapRotation"/> (Auto Generated)
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
    /// Sets <see cref="BlueprintAreaPart.Setting"/> (Auto Generated)
    /// </summary>
    
    public TBuilder Setting(AreaSetting setting)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Setting = setting;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.GraphCache"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetGraphCache(TextAssetLink graphCache)
    {
      ValidateParam(graphCache);

      return OnConfigureInternal(
          bp =>
          {
            bp.GraphCache = graphCache;
          });
    }

    /// <summary>
    /// Adds <see cref="TimeOfDaySettingsOverride"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="settings"><see cref="Kingmaker.Visual.LightSelector.BlueprintTimeOfDaySettings"/></param>
    /// <param name="overrideValue"><see cref="Kingmaker.Visual.LightSelector.BlueprintTimeOfDaySettings"/></param>
    
    
    public TBuilder AddTimeOfDaySettingsOverride(
        string? settings = null,
        string? overrideValue = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TimeOfDaySettingsOverride();
      component.m_Settings = BlueprintTool.GetRef<BlueprintTimeOfDaySettingsReference>(settings);
      component.m_Override = BlueprintTool.GetRef<BlueprintTimeOfDaySettingsReference>(overrideValue);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }

  /// <summary>
  /// Configurator for <see cref="BlueprintAreaPart"/>.
  /// </summary>
  /// <inheritdoc/>
  
  public class AreaPartConfigurator : BaseFactConfigurator<BlueprintAreaPart, AreaPartConfigurator>
  {
    private AreaPartConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AreaPartConfigurator For(string name)
    {
      return new AreaPartConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AreaPartConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintAreaPart>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_DynamicScene"/> (Auto Generated)
    /// </summary>
    
    public AreaPartConfigurator SetDynamicScene(SceneReference dynamicScene)
    {
      ValidateParam(dynamicScene);

      return OnConfigureInternal(
          bp =>
          {
            bp.m_DynamicScene = dynamicScene;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_StaticScene"/> (Auto Generated)
    /// </summary>
    
    public AreaPartConfigurator SetStaticScene(SceneReference staticScene)
    {
      ValidateParam(staticScene);

      return OnConfigureInternal(
          bp =>
          {
            bp.m_StaticScene = staticScene;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_LightScene"/> (Auto Generated)
    /// </summary>
    
    public AreaPartConfigurator SetLightScene(SceneReference lightScene)
    {
      ValidateParam(lightScene);

      return OnConfigureInternal(
          bp =>
          {
            bp.m_LightScene = lightScene;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_Bounds"/> (Auto Generated)
    /// </summary>
    
    public AreaPartConfigurator SetBounds(AreaPartBounds bounds)
    {
      ValidateParam(bounds);

      return OnConfigureInternal(
          bp =>
          {
            bp.m_Bounds = bounds;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_AudioTimeOfDayVariants"/> (Auto Generated)
    /// </summary>
    
    public AreaPartConfigurator SetAudioTimeOfDayVariants(SceneReference[]? audioTimeOfDayVariants)
    {
      ValidateParam(audioTimeOfDayVariants);

      return OnConfigureInternal(
          bp =>
          {
            bp.m_AudioTimeOfDayVariants = audioTimeOfDayVariants;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPart.m_AudioTimeOfDayVariants"/> (Auto Generated)
    /// </summary>
    
    public AreaPartConfigurator AddToAudioTimeOfDayVariants(params SceneReference[] audioTimeOfDayVariants)
    {
      ValidateParam(audioTimeOfDayVariants);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AudioTimeOfDayVariants = CommonTool.Append(bp.m_AudioTimeOfDayVariants, audioTimeOfDayVariants ?? new SceneReference[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPart.m_AudioTimeOfDayVariants"/> (Auto Generated)
    /// </summary>
    
    public AreaPartConfigurator RemoveFromAudioTimeOfDayVariants(params SceneReference[] audioTimeOfDayVariants)
    {
      ValidateParam(audioTimeOfDayVariants);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AudioTimeOfDayVariants = bp.m_AudioTimeOfDayVariants.Where(item => !audioTimeOfDayVariants.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_SoundBankNames"/> (Auto Generated)
    /// </summary>
    
    public AreaPartConfigurator SetSoundBankNames(string[]? soundBankNames)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SoundBankNames = soundBankNames;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPart.m_SoundBankNames"/> (Auto Generated)
    /// </summary>
    
    public AreaPartConfigurator AddToSoundBankNames(params string[] soundBankNames)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SoundBankNames = CommonTool.Append(bp.m_SoundBankNames, soundBankNames ?? new string[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPart.m_SoundBankNames"/> (Auto Generated)
    /// </summary>
    
    public AreaPartConfigurator RemoveFromSoundBankNames(params string[] soundBankNames)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SoundBankNames = bp.m_SoundBankNames.Where(item => !soundBankNames.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_ManageBanksSeparately"/> (Auto Generated)
    /// </summary>
    
    public AreaPartConfigurator SetManageBanksSeparately(bool manageBanksSeparately)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ManageBanksSeparately = manageBanksSeparately;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_UnloadBanksDelay"/> (Auto Generated)
    /// </summary>
    
    public AreaPartConfigurator SetUnloadBanksDelay(float unloadBanksDelay)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_UnloadBanksDelay = unloadBanksDelay;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.MusicTheme"/> (Auto Generated)
    /// </summary>
    
    public AreaPartConfigurator SetMusicTheme(string musicTheme)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MusicTheme = musicTheme;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.MusicThemeStop"/> (Auto Generated)
    /// </summary>
    
    public AreaPartConfigurator SetMusicThemeStop(string musicThemeStop)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MusicThemeStop = musicThemeStop;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_IndoorType"/> (Auto Generated)
    /// </summary>
    
    public AreaPartConfigurator SetIndoorType(IndoorType indoorType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IndoorType = indoorType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_WeatherProfile"/> (Auto Generated)
    /// </summary>
    
    public AreaPartConfigurator SetWeatherProfile(WeatherProfileExtended weatherProfile)
    {
      ValidateParam(weatherProfile);

      return OnConfigureInternal(
          bp =>
          {
            bp.m_WeatherProfile = weatherProfile;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_WeatherInclemencyMin"/> (Auto Generated)
    /// </summary>
    
    public AreaPartConfigurator SetWeatherInclemencyMin(InclemencyType weatherInclemencyMin)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_WeatherInclemencyMin = weatherInclemencyMin;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_WeatherInclemencyMax"/> (Auto Generated)
    /// </summary>
    
    public AreaPartConfigurator SetWeatherInclemencyMax(InclemencyType weatherInclemencyMax)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_WeatherInclemencyMax = weatherInclemencyMax;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.IsSingleLightScene"/> (Auto Generated)
    /// </summary>
    
    public AreaPartConfigurator SetIsSingleLightScene(bool isSingleLightScene)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsSingleLightScene = isSingleLightScene;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.LocalMapRotation"/> (Auto Generated)
    /// </summary>
    
    public AreaPartConfigurator SetLocalMapRotation(float localMapRotation)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.LocalMapRotation = localMapRotation;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.Setting"/> (Auto Generated)
    /// </summary>
    
    public AreaPartConfigurator Setting(AreaSetting setting)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Setting = setting;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.GraphCache"/> (Auto Generated)
    /// </summary>
    
    public AreaPartConfigurator SetGraphCache(TextAssetLink graphCache)
    {
      ValidateParam(graphCache);

      return OnConfigureInternal(
          bp =>
          {
            bp.GraphCache = graphCache;
          });
    }

    /// <summary>
    /// Adds <see cref="TimeOfDaySettingsOverride"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="settings"><see cref="Kingmaker.Visual.LightSelector.BlueprintTimeOfDaySettings"/></param>
    /// <param name="overrideValue"><see cref="Kingmaker.Visual.LightSelector.BlueprintTimeOfDaySettings"/></param>
    
    
    public AreaPartConfigurator AddTimeOfDaySettingsOverride(
        string? settings = null,
        string? overrideValue = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TimeOfDaySettingsOverride();
      component.m_Settings = BlueprintTool.GetRef<BlueprintTimeOfDaySettingsReference>(settings);
      component.m_Override = BlueprintTool.GetRef<BlueprintTimeOfDaySettingsReference>(overrideValue);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}
