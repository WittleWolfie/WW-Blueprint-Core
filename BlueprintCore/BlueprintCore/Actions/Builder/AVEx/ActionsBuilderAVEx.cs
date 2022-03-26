//***** AUTO-GENERATED - DO NOT EDIT *****//

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

namespace BlueprintCore.Actions.Builder.AVEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for actions involving audiovisual effects such as dialogs, camera, cutscenes, and sounds.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderAVEx
  {

    /// <summary>
    /// Adds <see cref="AddDialogNotification"/>
    /// </summary>
    public static ActionsBuilder AddDialogNotification(
        this ActionsBuilder builder,
        LocalizedString text)
    {
      var element = ElementTool.Create<AddDialogNotification>();
      element.Text = text;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangeBookEventImage"/>
    /// </summary>
    public static ActionsBuilder ChangeBookEventImage(
        this ActionsBuilder builder,
        SpriteLink image)
    {
      var element = ElementTool.Create<ChangeBookEventImage>();
      builder.Validate(image);
      element.m_Image = image;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionPlaySound"/>
    /// </summary>
    public static ActionsBuilder PlaySound(
        this ActionsBuilder builder,
        string soundName)
    {
      var element = ElementTool.Create<ContextActionPlaySound>();
      element.SoundName = soundName;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRunAnimationClip"/>
    /// </summary>
    public static ActionsBuilder RunAnimationClip(
        this ActionsBuilder builder,
        AnimationClipWrapperLink clipWrapper,
        ExecutionMode mode = ExecutionMode.Interrupted,
        float? transitionIn = null,
        float? transitionOut = null)
    {
      var element = ElementTool.Create<ContextActionRunAnimationClip>();
      builder.Validate(clipWrapper);
      element.ClipWrapper = clipWrapper;
      element.Mode = mode;
      element.TransitionIn = transitionIn ?? element.TransitionIn;
      element.TransitionOut = transitionOut ?? element.TransitionOut;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionShowBark"/>
    /// </summary>
    public static ActionsBuilder ShowBark(
        this ActionsBuilder builder,
        LocalizedString whatToBark,
        bool? barkDurationByText = null,
        bool? showWhileUnconscious = null,
        SharedStringAsset? whatToBarkShared = null)
    {
      var element = ElementTool.Create<ContextActionShowBark>();
      element.WhatToBark = whatToBark;
      element.BarkDurationByText = barkDurationByText ?? element.BarkDurationByText;
      element.ShowWhileUnconscious = showWhileUnconscious ?? element.ShowWhileUnconscious;
      builder.Validate(whatToBarkShared);
      element.WhatToBarkShared = whatToBarkShared ?? element.WhatToBarkShared;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSpawnFx"/>
    /// </summary>
    public static ActionsBuilder SpawnFx(
        this ActionsBuilder builder,
        PrefabLink prefabLink)
    {
      var element = ElementTool.Create<ContextActionSpawnFx>();
      element.PrefabLink = prefabLink;
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
      builder.Validate(position);
      element.Position = position ?? element.Position;
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
    /// Adds <see cref="OverrideRainIntesity"/>
    /// </summary>
    public static ActionsBuilder OverrideRainIntesity(
        this ActionsBuilder builder,
        float? duration = null,
        float? rainIntensity = null)
    {
      var element = ElementTool.Create<OverrideRainIntesity>();
      element.Duration = duration ?? element.Duration;
      element.RainIntensity = rainIntensity ?? element.RainIntensity;
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
      element.SetRace = setRace ?? element.SetRace;
      element.SetSex = setSex ?? element.SetSex;
      element.SoundName = soundName ?? element.SoundName;
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
      element.SetCurrentSpeaker = setCurrentSpeaker ?? element.SetCurrentSpeaker;
      element.SetRace = setRace ?? element.SetRace;
      element.SetSex = setSex ?? element.SetSex;
      element.SoundName = soundName ?? element.SoundName;
      builder.Validate(soundSourceObject);
      element.SoundSourceObject = soundSourceObject ?? element.SoundSourceObject;
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
      builder.Validate(clipWrapper);
      element.m_ClipWrapper = clipWrapper ?? element.m_ClipWrapper;
      element.TransitionIn = transitionIn ?? element.TransitionIn;
      element.TransitionOut = transitionOut ?? element.TransitionOut;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
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
      element.MusicEventStart = musicEventStart ?? element.MusicEventStart;
      element.MusicEventStop = musicEventStop ?? element.MusicEventStop;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder PlayCutscene(
        this ActionsBuilder builder,
        bool? checkExistence = null,
        Blueprint<Cutscene, CutsceneReference>? cutscene = null,
        ParametrizedContextSetter? parameters = null,
        bool? putInQueue = null)
    {
      var element = ElementTool.Create<PlayCutscene>();
      element.CheckExistence = checkExistence ?? element.CheckExistence;
      element.m_Cutscene = cutscene?.Reference ?? element.m_Cutscene;
      if (element.m_Cutscene is null)
      {
        element.m_Cutscene = BlueprintTool.GetRef<CutsceneReference>(null);
      }
      builder.Validate(parameters);
      element.Parameters = parameters ?? element.Parameters;
      element.PutInQueue = putInQueue ?? element.PutInQueue;
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
      element.ClearFx = clearFx ?? element.ClearFx;
      element.Desc = desc ?? element.Desc;
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
      builder.Validate(state);
      element.m_State = state ?? element.m_State;
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
      element.BarkDurationByText = barkDurationByText ?? element.BarkDurationByText;
      builder.Validate(targetMapObject);
      element.TargetMapObject = targetMapObject ?? element.TargetMapObject;
      builder.Validate(targetUnit);
      element.TargetUnit = targetUnit ?? element.TargetUnit;
      element.WhatToBark = whatToBark ?? element.WhatToBark;
      if (element.WhatToBark is null)
      {
        element.WhatToBark = BlueprintCore.Utils.Constants.Empty.String;
      }
      builder.Validate(whatToBarkShared);
      element.WhatToBarkShared = whatToBarkShared ?? element.WhatToBarkShared;
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
      element.FxPrefab = fxPrefab ?? element.FxPrefab;
      if (element.FxPrefab is null)
      {
        element.FxPrefab = BlueprintCore.Utils.Constants.Empty.PrefabLink;
      }
      builder.Validate(target);
      element.Target = target ?? element.Target;
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
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder StopCutscene(
        this ActionsBuilder builder,
        StopCutscene.UnitCheckType? checkType = null,
        Blueprint<Cutscene, CutsceneReference>? cutscene = null,
        UnitEvaluator? withUnit = null)
    {
      var element = ElementTool.Create<StopCutscene>();
      element.m_CheckType = checkType ?? element.m_CheckType;
      element.m_Cutscene = cutscene?.Reference ?? element.m_Cutscene;
      if (element.m_Cutscene is null)
      {
        element.m_Cutscene = BlueprintTool.GetRef<CutsceneReference>(null);
      }
      builder.Validate(withUnit);
      element.WithUnit = withUnit ?? element.WithUnit;
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
      builder.Validate(target);
      element.Target = target ?? element.Target;
      element.ToggleOn = toggleOn ?? element.ToggleOn;
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
      builder.Validate(target);
      element.Target = target ?? element.Target;
      element.ToggleOn = toggleOn ?? element.ToggleOn;
      return builder.Add(element);
    }
  }
}
