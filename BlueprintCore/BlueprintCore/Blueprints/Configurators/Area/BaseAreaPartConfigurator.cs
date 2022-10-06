//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Enums;
using Kingmaker.Localization;
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

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintAreaPart>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_DynamicScene = copyFrom.m_DynamicScene;
          bp.m_StaticScene = copyFrom.m_StaticScene;
          bp.m_StaticSceneConsoleOverride = copyFrom.m_StaticSceneConsoleOverride;
          bp.m_LightScene = copyFrom.m_LightScene;
          bp.m_LightSceneConsoleOverride = copyFrom.m_LightSceneConsoleOverride;
          bp.m_Bounds = copyFrom.m_Bounds;
          bp.m_AudioTimeOfDayVariants = copyFrom.m_AudioTimeOfDayVariants;
          bp.m_SoundBankNames = copyFrom.m_SoundBankNames;
          bp.m_ManageBanksSeparately = copyFrom.m_ManageBanksSeparately;
          bp.m_UnloadBanksDelay = copyFrom.m_UnloadBanksDelay;
          bp.MusicTheme = copyFrom.MusicTheme;
          bp.MusicThemeStop = copyFrom.MusicThemeStop;
          bp.m_IndoorType = copyFrom.m_IndoorType;
          bp.m_WeatherProfile = copyFrom.m_WeatherProfile;
          bp.m_WeatherInclemencyMin = copyFrom.m_WeatherInclemencyMin;
          bp.m_WeatherInclemencyMax = copyFrom.m_WeatherInclemencyMax;
          bp.IsSingleLightScene = copyFrom.IsSingleLightScene;
          bp.LocalMapRotation = copyFrom.LocalMapRotation;
          bp.Setting = copyFrom.Setting;
          bp.AreaLocalName = copyFrom.AreaLocalName;
          bp.GraphCache = copyFrom.GraphCache;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintAreaPart>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_DynamicScene = copyFrom.m_DynamicScene;
          bp.m_StaticScene = copyFrom.m_StaticScene;
          bp.m_StaticSceneConsoleOverride = copyFrom.m_StaticSceneConsoleOverride;
          bp.m_LightScene = copyFrom.m_LightScene;
          bp.m_LightSceneConsoleOverride = copyFrom.m_LightSceneConsoleOverride;
          bp.m_Bounds = copyFrom.m_Bounds;
          bp.m_AudioTimeOfDayVariants = copyFrom.m_AudioTimeOfDayVariants;
          bp.m_SoundBankNames = copyFrom.m_SoundBankNames;
          bp.m_ManageBanksSeparately = copyFrom.m_ManageBanksSeparately;
          bp.m_UnloadBanksDelay = copyFrom.m_UnloadBanksDelay;
          bp.MusicTheme = copyFrom.MusicTheme;
          bp.MusicThemeStop = copyFrom.MusicThemeStop;
          bp.m_IndoorType = copyFrom.m_IndoorType;
          bp.m_WeatherProfile = copyFrom.m_WeatherProfile;
          bp.m_WeatherInclemencyMin = copyFrom.m_WeatherInclemencyMin;
          bp.m_WeatherInclemencyMax = copyFrom.m_WeatherInclemencyMax;
          bp.IsSingleLightScene = copyFrom.IsSingleLightScene;
          bp.LocalMapRotation = copyFrom.LocalMapRotation;
          bp.Setting = copyFrom.Setting;
          bp.AreaLocalName = copyFrom.AreaLocalName;
          bp.GraphCache = copyFrom.GraphCache;
        });
    }

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
    /// Sets the value of <see cref="BlueprintAreaPart.m_StaticSceneConsoleOverride"/>
    /// </summary>
    public TBuilder SetStaticSceneConsoleOverride(SceneReference staticSceneConsoleOverride)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(staticSceneConsoleOverride);
          bp.m_StaticSceneConsoleOverride = staticSceneConsoleOverride;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.m_StaticSceneConsoleOverride"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyStaticSceneConsoleOverride(Action<SceneReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_StaticSceneConsoleOverride is null) { return; }
          action.Invoke(bp.m_StaticSceneConsoleOverride);
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
    /// Sets the value of <see cref="BlueprintAreaPart.m_LightSceneConsoleOverride"/>
    /// </summary>
    public TBuilder SetLightSceneConsoleOverride(SceneReference lightSceneConsoleOverride)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(lightSceneConsoleOverride);
          bp.m_LightSceneConsoleOverride = lightSceneConsoleOverride;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.m_LightSceneConsoleOverride"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLightSceneConsoleOverride(Action<SceneReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_LightSceneConsoleOverride is null) { return; }
          action.Invoke(bp.m_LightSceneConsoleOverride);
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
          bp.m_AudioTimeOfDayVariants = bp.m_AudioTimeOfDayVariants.Where(e => !predicate(e)).ToArray();
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
          bp.m_SoundBankNames = bp.m_SoundBankNames.Where(e => !predicate(e)).ToArray();
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
    /// Sets the value of <see cref="BlueprintAreaPart.AreaLocalName"/>
    /// </summary>
    ///
    /// <param name="areaLocalName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetAreaLocalName(LocalString areaLocalName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AreaLocalName = areaLocalName?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPart.AreaLocalName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAreaLocalName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.AreaLocalName is null) { return; }
          action.Invoke(bp.AreaLocalName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPart.GraphCache"/>
    /// </summary>
    ///
    /// <param name="graphCache">
    /// You can pass in the animation using a TextAssetLink or it's AssetId.
    /// </param>
    public TBuilder SetGraphCache(AssetLink<TextAssetLink> graphCache)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.GraphCache = graphCache?.Get();
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

    /// <summary>
    /// Adds <see cref="AdditionalPreloadComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Prologue_Kenabres_CitizenIdle</term><description>bffcc04cd70a5db44b1d8c1477b10cc9</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="resources">
    /// <para>
    /// Blueprint of type ResourceListForPreload. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AdditionalPreloadComponent(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Blueprint<ResourceListForPreload.Ref>? resources = null)
    {
      var component = new AdditionalPreloadComponent();
      component.Resources = resources?.Reference ?? component.Resources;
      if (component.Resources is null)
      {
        component.Resources = BlueprintTool.GetRef<ResourceListForPreload.Ref>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_AudioTimeOfDayVariants is null)
      {
        Blueprint.m_AudioTimeOfDayVariants = new SceneReference[0];
      }
      if (Blueprint.m_SoundBankNames is null)
      {
        Blueprint.m_SoundBankNames = new string[0];
      }
      if (Blueprint.AreaLocalName is null)
      {
        Blueprint.AreaLocalName = Utils.Constants.Empty.String;
      }
    }
  }
}
