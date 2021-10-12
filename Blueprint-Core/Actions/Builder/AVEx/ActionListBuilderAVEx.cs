using BlueprintCore.Utils;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;

namespace BlueprintCore.Actions.Builder.AVEx
{
  /**
   * Extension to ActionListBuilder for Audiovisual actions such as dialogs, camera, cutscenes,
   * visual effects, and sounds.
   */
  public static class ActionListBuilderAVEx
  {
    /** ChangeBookEventImage */
    public static ActionListBuilder ChangeBookImage(this ActionListBuilder builder, SpriteLink image)
    {
      var setImage = ElementTool.Create<ChangeBookEventImage>();
      setImage.m_Image = image;
      return builder.Add(setImage);
    }

    /** CameratoPosition */
    public static ActionListBuilder MoveCamera(
        this ActionListBuilder builder, PositionEvaluator position)
    {
      builder.Validate(position);

      var moveCamera = ElementTool.Create<CameraToPosition>();
      moveCamera.Position = position;
      return builder.Add(moveCamera);
    }

    /** AddDialogNotification */
    public static ActionListBuilder AddDialogNotification(
        this ActionListBuilder builder, LocalizedString text)
    {
      var notification = ElementTool.Create<AddDialogNotification>();
      notification.Text = text;
      return builder.Add(notification);
    }

    //----- FX -----//

    /** ClearBlood */
    public static ActionListBuilder ClearBlood(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ClearBlood>());
    }
  }
}