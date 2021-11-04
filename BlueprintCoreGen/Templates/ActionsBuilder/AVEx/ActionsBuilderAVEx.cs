// [Replace("// ", "")]
// using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Assets.UnitLogic.Mechanics.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Visual.Animation;
using Kingmaker.Visual.Animation.Actions;

namespace BlueprintCoreGen.Actions.Builder.AVEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for actions involving audiovisual effects such as dialogs, camera,
  /// cutscenes, and sounds.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderAVEx
  {
    /// <summary>
    /// Adds <see cref="ChangeBookEventImage"/>
    /// </summary>
    [Implements(typeof(ChangeBookEventImage))]
    public static ActionsBuilder ChangeBookImage(this ActionsBuilder builder, SpriteLink image)
    {
      var setImage = ElementTool.Create<ChangeBookEventImage>();
      setImage.m_Image = image;
      return builder.Add(setImage);
    }

    /// <summary>
    /// Adds <see cref="CameraToPosition"/>
    /// </summary>
    [Implements(typeof(CameraToPosition))]
    public static ActionsBuilder MoveCamera(this ActionsBuilder builder, PositionEvaluator position)
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
    [Implements(typeof(AddDialogNotification))]
    public static ActionsBuilder AddDialogNotification(this ActionsBuilder builder, LocalizedString text)
    {
      var notification = ElementTool.Create<AddDialogNotification>();
      notification.Text = text;
      return builder.Add(notification);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.ClearBlood">ClearBlood</see>
    /// </summary>
    [Implements(typeof(ClearBlood))]
    public static ActionsBuilder ClearBlood(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ClearBlood>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionRunAnimationClip"/>
    /// </summary>
    [Implements(typeof(ContextActionRunAnimationClip))]
    public static ActionsBuilder RunAnimationClip(
        this ActionsBuilder builder,
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
    /// Adds <see cref="ContextActionShowBark"/>
    /// </summary>
    [Implements(typeof(ContextActionShowBark))]
    public static ActionsBuilder Bark(
        this ActionsBuilder builder,
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
    /// Adds <see cref="ContextActionSpawnFx"/>
    /// </summary>

    [Implements(typeof(ContextActionSpawnFx))]
    public static ActionsBuilder SpawnFx(this ActionsBuilder builder, PrefabLink prefab)
    {
      var spawnFx = ElementTool.Create<ContextActionSpawnFx>();
      spawnFx.PrefabLink = prefab;
      return builder.Add(spawnFx);
    }

    //----- Kingmaker.Assets.UnitLogic.Mechanics.Actions -----//

    /// <summary>
    /// Adds <see cref="ContextActionPlaySound"/>
    /// </summary>
    [Implements(typeof(ContextActionPlaySound))]
    public static ActionsBuilder PlaySound(this ActionsBuilder builder, string soundName)
    {
      var playSound = ElementTool.Create<ContextActionPlaySound>();
      playSound.SoundName = soundName;
      return builder.Add(playSound);
    }
  }
}