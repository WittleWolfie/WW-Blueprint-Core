using BlueprintCore.Utils;
using Kingmaker.Assets.UnitLogic.Mechanics.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Visual.Animation.Actions;
using Kingmaker.Visual.Animation;

namespace BlueprintCore.Actions.Builder.AVEx
{
  /// <summary>
  /// Extension to <see cref="ActionListBuilder">ActionListBuilder</see> for actions involving audiovisual effects such
  /// as dialogs, camera, cutscenes, and sounds.
  /// </summary>
  /// <inheritdoc cref="ActionListBuilder"/>
  public static class ActionListBuilderAVEx
  {
    /// <summary>
    /// Adds <see cref="ChangeBookEventImage">ChangeBookEventImage</see>
    /// </summary>
    public static ActionListBuilder ChangeBookImage(this ActionListBuilder builder, SpriteLink image)
    {
      var setImage = ElementTool.Create<ChangeBookEventImage>();
      setImage.m_Image = image;
      return builder.Add(setImage);
    }

    /// <summary>
    /// Adds <see cref="CameraToPosition">CameraToPosition</see>
    /// </summary>
    public static ActionListBuilder MoveCamera(this ActionListBuilder builder, PositionEvaluator position)
    {
      builder.Validate(position);

      var moveCamera = ElementTool.Create<CameraToPosition>();
      moveCamera.Position = position;
      return builder.Add(moveCamera);
    }

    /// <summary>
    /// Adds
    /// <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.AddDialogNotification">AddDialogNotification</see>
    /// </summary>
    public static ActionListBuilder AddDialogNotification(this ActionListBuilder builder, LocalizedString text)
    {
      var notification = ElementTool.Create<AddDialogNotification>();
      notification.Text = text;
      return builder.Add(notification);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.ClearBlood">ClearBlood</see>
    /// </summary>
    public static ActionListBuilder ClearBlood(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ClearBlood>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionRunAnimationClip">ContextActionRunAnimationClip</see>
    /// </summary>
    public static ActionListBuilder RunAnimationClip(
        this ActionListBuilder builder,
        AnimationClipWrapper clip,
        ExecutionMode mode = ExecutionMode.Interrupted,
        float transitionIn = 0.25f,
        float transitionOut = 0.25f)
    {
      var animation = ElementTool.Create<ContextActionRunAnimationClip>();
      animation.ClipWrapper = clip;
      animation.Mode = mode;
      animation.TransitionIn = transitionIn;
      animation.TransitionOut = transitionOut;
      return builder.Add(animation);
    }

    /// <summary>
    /// Adds <see cref="ContextActionShowBark">ContextActionShowBark</see>
    /// </summary>
    public static ActionListBuilder Bark(
        this ActionListBuilder builder,
        LocalizedString bark,
        bool showIfUnconcious = false,
        bool durationBasedOnTextLength = false)
    {
      var showBark = ElementTool.Create<ContextActionShowBark>();
      showBark.WhatToBark = bark;
      showBark.ShowWhileUnconscious = showIfUnconcious;
      showBark.BarkDurationByText = durationBasedOnTextLength;
      return builder.Add(showBark);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSpawnFx">ContextActionSpawnFx</see>
    /// </summary>
    public static ActionListBuilder SpawnFx(this ActionListBuilder builder, PrefabLink prefab)
    {
      var spawnFx = ElementTool.Create<ContextActionSpawnFx>();
      spawnFx.PrefabLink = prefab;
      return builder.Add(spawnFx);
    }

    //----- Kingmaker.Assets.UnitLogic.Mechanics.Actions -----//

    /// <summary>
    /// Adds <see cref="ContextActionPlaySound">ContextActionPlaySound</see>
    /// </summary>
    public static ActionListBuilder PlaySound(this ActionListBuilder builder, string soundName)
    {
      var playSound = ElementTool.Create<ContextActionPlaySound>();
      playSound.SoundName = soundName;
      return builder.Add(playSound);
    }

  }
}