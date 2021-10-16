using BlueprintCore.Utils;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;

namespace BlueprintCore.Actions.Builder.AVEx
{
  /// <summary>
  /// Extension to <see cref="ActionListBuilder">ActionListBuilder</see> for actions involving audiovisual effects such
  /// as dialogs, camera, cutscenes, and sounds.
  /// </summary>
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

    //----- FX -----//

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.ClearBlood">ClearBlood</see>
    /// </summary>
    public static ActionListBuilder ClearBlood(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ClearBlood>());
    }
  }
}