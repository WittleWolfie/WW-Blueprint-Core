using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Cutscenes;
using Kingmaker.Assets.UnitLogic.Mechanics.Actions;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.NamedParameters;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.Sound;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Visual.Animation.Actions;
//***** AUTO-GENERATED - DO NOT EDIT *****//
namespace BlueprintCore.Actions.Builder.AVEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for actions involving audiovisual effects such as dialogs, camera, cutscenes, and sounds.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderAVEx
{

    /// <summary>
    /// Adds <see cref="ContextActionPlaySound"/>
    /// </summary>
    public static ActionsBuilder ContextActionPlaySound(
        this ActionsBuilder builder,
        string? soundName = null)
    {
      var element = ElementTool.Create<ContextActionPlaySound>();
      if (soundName is not null)
      {
        element.SoundName = soundName;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddDialogNotification"/>
    /// </summary>
    public static ActionsBuilder AddDialogNotification(
        this ActionsBuilder builder,
        LocalizedString? text = null)
    {
      var element = ElementTool.Create<AddDialogNotification>();
      if (text is not null)
      {
        element.Text = text;
      }
      if (element.Text is null)
      {
        element.Text = Constants.Empty.String;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CameraToPosition"/>
    /// </summary>
    public static ActionsBuilder CameraToPosition(
        this ActionsBuilder builder,
        PositionEvaluator? position = null)
    {
      var element = ElementTool.Create<CameraToPosition>();
      if (position is not null)
      {
        builder.Validate(position);
        element.Position = position;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangeBookEventImage"/>
    /// </summary>
    public static ActionsBuilder ChangeBookEventImage(
        this ActionsBuilder builder,
        SpriteLink? image = null)
    {
      var element = ElementTool.Create<ChangeBookEventImage>();
      if (image is not null)
      {
        builder.Validate(image);
        element.m_Image = image;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ClearBlood"/>
    /// </summary>
    public static ActionsBuilder ClearBlood(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ClearBlood>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionRunAnimationClip"/>
    /// </summary>
    public static ActionsBuilder ContextActionRunAnimationClip(
        this ActionsBuilder builder,
        AnimationClipWrapperLink? clipWrapper = null,
        ExecutionMode? mode = null,
        float? transitionIn = null,
        float? transitionOut = null)
    {
      var element = ElementTool.Create<ContextActionRunAnimationClip>();
      if (clipWrapper is not null)
      {
        builder.Validate(clipWrapper);
        element.ClipWrapper = clipWrapper;
      }
      if (mode is not null)
      {
        element.Mode = mode;
      }
      if (transitionIn is not null)
      {
        element.TransitionIn = transitionIn;
      }
      if (transitionOut is not null)
      {
        element.TransitionOut = transitionOut;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionShowBark"/>
    /// </summary>
    public static ActionsBuilder ContextActionShowBark(
        this ActionsBuilder builder,
        bool? barkDurationByText = null,
        bool? showWhileUnconscious = null,
        LocalizedString? whatToBark = null,
        SharedStringAsset? whatToBarkShared = null)
    {
      var element = ElementTool.Create<ContextActionShowBark>();
      if (barkDurationByText is not null)
      {
        element.BarkDurationByText = barkDurationByText;
      }
      if (showWhileUnconscious is not null)
      {
        element.ShowWhileUnconscious = showWhileUnconscious;
      }
      if (whatToBark is not null)
      {
        element.WhatToBark = whatToBark;
      }
      if (element.WhatToBark is null)
      {
        element.WhatToBark = Constants.Empty.String;
      }
      if (whatToBarkShared is not null)
      {
        builder.Validate(whatToBarkShared);
        element.WhatToBarkShared = whatToBarkShared;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSpawnFx"/>
    /// </summary>
    public static ActionsBuilder ContextActionSpawnFx(
        this ActionsBuilder builder,
        PrefabLink? prefabLink = null)
    {
      var element = ElementTool.Create<ContextActionSpawnFx>();
      if (prefabLink is not null)
      {
        element.PrefabLink = prefabLink;
      }
      if (element.PrefabLink is null)
      {
        element.PrefabLink = Constants.Empty.PrefabLink;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="OverrideRainIntesity"/>
    /// </summary>
    public static ActionsBuilder OverrideRainIntesity(
        this ActionsBuilder builder,
        float? duration = null,
        float? rainIntensity = null)
    {
      var element = ElementTool.Create<OverrideRainIntesity>();
      if (duration is not null)
      {
        element.Duration = duration;
      }
      if (rainIntensity is not null)
      {
        element.RainIntensity = rainIntensity;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Play2DSound"/>
    /// </summary>
    public static ActionsBuilder Play2DSound(
        this ActionsBuilder builder,
        bool? setRace = null,
        bool? setSex = null,
        string? soundName = null)
    {
      var element = ElementTool.Create<Play2DSound>();
      if (setRace is not null)
      {
        element.SetRace = setRace;
      }
      if (setSex is not null)
      {
        element.SetSex = setSex;
      }
      if (soundName is not null)
      {
        element.SoundName = soundName;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Play3DSound"/>
    /// </summary>
    public static ActionsBuilder Play3DSound(
        this ActionsBuilder builder,
        bool? setCurrentSpeaker = null,
        bool? setRace = null,
        bool? setSex = null,
        string? soundName = null,
        EntityReference? soundSourceObject = null)
    {
      var element = ElementTool.Create<Play3DSound>();
      if (setCurrentSpeaker is not null)
      {
        element.SetCurrentSpeaker = setCurrentSpeaker;
      }
      if (setRace is not null)
      {
        element.SetRace = setRace;
      }
      if (setSex is not null)
      {
        element.SetSex = setSex;
      }
      if (soundName is not null)
      {
        element.SoundName = soundName;
      }
      if (soundSourceObject is not null)
      {
        builder.Validate(soundSourceObject);
        element.SoundSourceObject = soundSourceObject;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PlayAnimationOneShot"/>
    /// </summary>
    public static ActionsBuilder PlayAnimationOneShot(
        this ActionsBuilder builder,
        AnimationClipWrapperLink? clipWrapper = null,
        float? transitionIn = null,
        float? transitionOut = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<PlayAnimationOneShot>();
      if (clipWrapper is not null)
      {
        builder.Validate(clipWrapper);
        element.m_ClipWrapper = clipWrapper;
      }
      if (transitionIn is not null)
      {
        element.TransitionIn = transitionIn;
      }
      if (transitionOut is not null)
      {
        element.TransitionOut = transitionOut;
      }
      if (unit is not null)
      {
        builder.Validate(unit);
        element.Unit = unit;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PlayCustomMusic"/>
    /// </summary>
    public static ActionsBuilder PlayCustomMusic(
        this ActionsBuilder builder,
        string? musicEventStart = null,
        string? musicEventStop = null)
    {
      var element = ElementTool.Create<PlayCustomMusic>();
      if (musicEventStart is not null)
      {
        element.MusicEventStart = musicEventStart;
      }
      if (musicEventStop is not null)
      {
        element.MusicEventStop = musicEventStop;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PlayCutscene"/>
    /// </summary>
    ///
    /// <param name="cutscene">
    /// Blueprint of type Cutscene. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder PlayCutscene(
        this ActionsBuilder builder,
        bool? checkExistence = null,
        Blueprint<Cutscene, CutsceneReference>? cutscene = null,
        ParametrizedContextSetter? parameters = null,
        bool? putInQueue = null)
    {
      var element = ElementTool.Create<PlayCutscene>();
      if (checkExistence is not null)
      {
        element.CheckExistence = checkExistence;
      }
      if (cutscene is not null)
      {
        element.m_Cutscene = cutscene.Reference;
      }
      if (element.m_Cutscene is null)
      {
        element.m_Cutscene = BlueprintTool.GetRef<CutsceneReference>(null);
      }
      if (parameters is not null)
      {
        builder.Validate(parameters);
        element.Parameters = parameters;
      }
      if (putInQueue is not null)
      {
        element.PutInQueue = putInQueue;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ReloadMechanic"/>
    /// </summary>
    public static ActionsBuilder ReloadMechanic(
        this ActionsBuilder builder,
        bool? clearFx = null,
        string? desc = null)
    {
      var element = ElementTool.Create<ReloadMechanic>();
      if (clearFx is not null)
      {
        element.ClearFx = clearFx;
      }
      if (desc is not null)
      {
        element.Desc = desc;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetSoundState"/>
    /// </summary>
    public static ActionsBuilder SetSoundState(
        this ActionsBuilder builder,
        AkStateReference? state = null)
    {
      var element = ElementTool.Create<SetSoundState>();
      if (state is not null)
      {
        builder.Validate(state);
        element.m_State = state;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ShowBark"/>
    /// </summary>
    public static ActionsBuilder ShowBark(
        this ActionsBuilder builder,
        bool? barkDurationByText = null,
        MapObjectEvaluator? targetMapObject = null,
        UnitEvaluator? targetUnit = null,
        LocalizedString? whatToBark = null,
        SharedStringAsset? whatToBarkShared = null)
    {
      var element = ElementTool.Create<ShowBark>();
      if (barkDurationByText is not null)
      {
        element.BarkDurationByText = barkDurationByText;
      }
      if (targetMapObject is not null)
      {
        builder.Validate(targetMapObject);
        element.TargetMapObject = targetMapObject;
      }
      if (targetUnit is not null)
      {
        builder.Validate(targetUnit);
        element.TargetUnit = targetUnit;
      }
      if (whatToBark is not null)
      {
        element.WhatToBark = whatToBark;
      }
      if (element.WhatToBark is null)
      {
        element.WhatToBark = Constants.Empty.String;
      }
      if (whatToBarkShared is not null)
      {
        builder.Validate(whatToBarkShared);
        element.WhatToBarkShared = whatToBarkShared;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SpawnFx"/>
    /// </summary>
    public static ActionsBuilder SpawnFx(
        this ActionsBuilder builder,
        PrefabLink? fxPrefab = null,
        TransformEvaluator? target = null)
    {
      var element = ElementTool.Create<SpawnFx>();
      if (fxPrefab is not null)
      {
        element.FxPrefab = fxPrefab;
      }
      if (element.FxPrefab is null)
      {
        element.FxPrefab = Constants.Empty.PrefabLink;
      }
      if (target is not null)
      {
        builder.Validate(target);
        element.Target = target;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="StopCustomMusic"/>
    /// </summary>
    public static ActionsBuilder StopCustomMusic(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<StopCustomMusic>());
    }

    /// <summary>
    /// Adds <see cref="StopCutscene"/>
    /// </summary>
    ///
    /// <param name="cutscene">
    /// Blueprint of type Cutscene. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder StopCutscene(
        this ActionsBuilder builder,
        StopCutscene.UnitCheckType? checkType = null,
        Blueprint<Cutscene, CutsceneReference>? cutscene = null,
        UnitEvaluator? withUnit = null)
    {
      var element = ElementTool.Create<StopCutscene>();
      if (checkType is not null)
      {
        element.m_CheckType = checkType;
      }
      if (cutscene is not null)
      {
        element.m_Cutscene = cutscene.Reference;
      }
      if (element.m_Cutscene is null)
      {
        element.m_Cutscene = BlueprintTool.GetRef<CutsceneReference>(null);
      }
      if (withUnit is not null)
      {
        builder.Validate(withUnit);
        element.WithUnit = withUnit;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ToggleObjectFx"/>
    /// </summary>
    public static ActionsBuilder ToggleObjectFx(
        this ActionsBuilder builder,
        MapObjectEvaluator? target = null,
        bool? toggleOn = null)
    {
      var element = ElementTool.Create<ToggleObjectFx>();
      if (target is not null)
      {
        builder.Validate(target);
        element.Target = target;
      }
      if (toggleOn is not null)
      {
        element.ToggleOn = toggleOn;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ToggleObjectMusic"/>
    /// </summary>
    public static ActionsBuilder ToggleObjectMusic(
        this ActionsBuilder builder,
        MapObjectEvaluator? target = null,
        bool? toggleOn = null)
    {
      var element = ElementTool.Create<ToggleObjectMusic>();
      if (target is not null)
      {
        builder.Validate(target);
        element.Target = target;
      }
      if (toggleOn is not null)
      {
        element.ToggleOn = toggleOn;
      }
      return builder.Add(element);
    }
  }
}
