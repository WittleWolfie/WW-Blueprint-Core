using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Enums;
using Kingmaker.Visual.LightSelector;
using Owlcat.Runtime.Visual.Effects.WeatherSystem;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAreaPart"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAreaPart))]
  public abstract class BaseAreaPartConfigurator<T, TBuilder>
      : BaseFactConfigurator<T, TBuilder>
      where T : BlueprintAreaPart
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseAreaPartConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_DynamicScene"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDynamicScene(SceneReference value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_DynamicScene = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_StaticScene"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetStaticScene(SceneReference value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_StaticScene = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_LightScene"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetLightScene(SceneReference value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_LightScene = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_Bounds"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetBounds(AreaPartBounds value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_Bounds = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.m_AudioTimeOfDayVariants"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder AddToAudioTimeOfDayVariants(params SceneReference[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_AudioTimeOfDayVariants = CommonTool.Append(bp.m_AudioTimeOfDayVariants, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.m_AudioTimeOfDayVariants"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder RemoveFromAudioTimeOfDayVariants(params SceneReference[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_AudioTimeOfDayVariants = bp.m_AudioTimeOfDayVariants.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.m_SoundBankNames"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder AddToSoundBankNames(params string[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_SoundBankNames = CommonTool.Append(bp.m_SoundBankNames, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.m_SoundBankNames"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder RemoveFromSoundBankNames(params string[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_SoundBankNames = bp.m_SoundBankNames.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_ManageBanksSeparately"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetManageBanksSeparately(bool value)
    {
      return OnConfigureInternal(bp => bp.m_ManageBanksSeparately = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_UnloadBanksDelay"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetUnloadBanksDelay(float value)
    {
      return OnConfigureInternal(bp => bp.m_UnloadBanksDelay = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.MusicTheme"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetMusicTheme(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.MusicTheme = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.MusicThemeStop"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetMusicThemeStop(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.MusicThemeStop = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_IndoorType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIndoorType(IndoorType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_IndoorType = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_WeatherProfile"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetWeatherProfile(WeatherProfileExtended value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_WeatherProfile = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_WeatherInclemencyMin"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetWeatherInclemencyMin(InclemencyType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_WeatherInclemencyMin = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_WeatherInclemencyMax"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetWeatherInclemencyMax(InclemencyType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_WeatherInclemencyMax = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.IsSingleLightScene"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIsSingleLightScene(bool value)
    {
      return OnConfigureInternal(bp => bp.IsSingleLightScene = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.LocalMapRotation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetLocalMapRotation(float value)
    {
      return OnConfigureInternal(bp => bp.LocalMapRotation = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.Setting"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetSetting(AreaSetting value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Setting = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.GraphCache"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetGraphCache(TextAsset value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.GraphCache = value);
    }

    /// <summary>
    /// Adds <see cref="TimeOfDaySettingsOverride"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Settings"><see cref="BlueprintTimeOfDaySettings"/></param>
    /// <param name="m_Override"><see cref="BlueprintTimeOfDaySettings"/></param>
    [Generated]
    [Implements(typeof(TimeOfDaySettingsOverride))]
    public TBuilder AddTimeOfDaySettingsOverride(
        string m_Settings,
        string m_Override)
    {
      
      var component =  new TimeOfDaySettingsOverride();
      component.m_Settings = BlueprintTool.GetRef<BlueprintTimeOfDaySettingsReference>(m_Settings);
      component.m_Override = BlueprintTool.GetRef<BlueprintTimeOfDaySettingsReference>(m_Override);
      return AddComponent(component);
    }
  }

  /// <summary>Configurator for <see cref="BlueprintAreaPart"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAreaPart))]
  public class AreaPartConfigurator : BaseFactConfigurator<BlueprintAreaPart, AreaPartConfigurator>
  {
     private AreaPartConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AreaPartConfigurator For(string name)
    {
      return new AreaPartConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AreaPartConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintAreaPart>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AreaPartConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintAreaPart>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_DynamicScene"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPartConfigurator SetDynamicScene(SceneReference value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_DynamicScene = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_StaticScene"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPartConfigurator SetStaticScene(SceneReference value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_StaticScene = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_LightScene"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPartConfigurator SetLightScene(SceneReference value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_LightScene = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_Bounds"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPartConfigurator SetBounds(AreaPartBounds value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_Bounds = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.m_AudioTimeOfDayVariants"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPartConfigurator AddToAudioTimeOfDayVariants(params SceneReference[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_AudioTimeOfDayVariants = CommonTool.Append(bp.m_AudioTimeOfDayVariants, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.m_AudioTimeOfDayVariants"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPartConfigurator RemoveFromAudioTimeOfDayVariants(params SceneReference[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_AudioTimeOfDayVariants = bp.m_AudioTimeOfDayVariants.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.m_SoundBankNames"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPartConfigurator AddToSoundBankNames(params string[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_SoundBankNames = CommonTool.Append(bp.m_SoundBankNames, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.m_SoundBankNames"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPartConfigurator RemoveFromSoundBankNames(params string[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_SoundBankNames = bp.m_SoundBankNames.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_ManageBanksSeparately"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPartConfigurator SetManageBanksSeparately(bool value)
    {
      return OnConfigureInternal(bp => bp.m_ManageBanksSeparately = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_UnloadBanksDelay"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPartConfigurator SetUnloadBanksDelay(float value)
    {
      return OnConfigureInternal(bp => bp.m_UnloadBanksDelay = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.MusicTheme"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPartConfigurator SetMusicTheme(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.MusicTheme = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.MusicThemeStop"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPartConfigurator SetMusicThemeStop(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.MusicThemeStop = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_IndoorType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPartConfigurator SetIndoorType(IndoorType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_IndoorType = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_WeatherProfile"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPartConfigurator SetWeatherProfile(WeatherProfileExtended value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_WeatherProfile = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_WeatherInclemencyMin"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPartConfigurator SetWeatherInclemencyMin(InclemencyType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_WeatherInclemencyMin = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.m_WeatherInclemencyMax"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPartConfigurator SetWeatherInclemencyMax(InclemencyType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_WeatherInclemencyMax = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.IsSingleLightScene"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPartConfigurator SetIsSingleLightScene(bool value)
    {
      return OnConfigureInternal(bp => bp.IsSingleLightScene = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.LocalMapRotation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPartConfigurator SetLocalMapRotation(float value)
    {
      return OnConfigureInternal(bp => bp.LocalMapRotation = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.Setting"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPartConfigurator SetSetting(AreaSetting value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Setting = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPart.GraphCache"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPartConfigurator SetGraphCache(TextAsset value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.GraphCache = value);
    }

    /// <summary>
    /// Adds <see cref="TimeOfDaySettingsOverride"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Settings"><see cref="BlueprintTimeOfDaySettings"/></param>
    /// <param name="m_Override"><see cref="BlueprintTimeOfDaySettings"/></param>
    [Generated]
    [Implements(typeof(TimeOfDaySettingsOverride))]
    public AreaPartConfigurator AddTimeOfDaySettingsOverride(
        string m_Settings,
        string m_Override)
    {
      
      var component =  new TimeOfDaySettingsOverride();
      component.m_Settings = BlueprintTool.GetRef<BlueprintTimeOfDaySettingsReference>(m_Settings);
      component.m_Override = BlueprintTool.GetRef<BlueprintTimeOfDaySettingsReference>(m_Override);
      return AddComponent(component);
    }
  }
}
