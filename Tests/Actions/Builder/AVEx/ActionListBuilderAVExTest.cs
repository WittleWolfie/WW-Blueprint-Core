using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.AVEx;
using BlueprintCore.Tests.Asserts;
using BlueprintCore.Utils;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Xunit;

namespace BlueprintCore.Tests.Actions.Builder.AVEx
{
  public class ActionListBuilderAVExTest : ActionListBuilderTestBase
  {
    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    [Fact]
    public void ChangeBookImage()
    {
      var image = new SpriteLink { AssetId = "hi" };

      var actions = ActionListBuilder.New().ChangeBookImage(image).Build();

      Assert.Single(actions.Actions);
      var setImage = (ChangeBookEventImage)actions.Actions[0];
      ElementAsserts.IsValid(setImage);

      Assert.Equal(image, setImage.m_Image);
    }

    [Fact]
    public void MoveCamera()
    {
      var position = ElementTool.Create<UnitPosition>();
      position.Unit = ClickedUnit;

      var actions = ActionListBuilder.New().MoveCamera(position).Build();

      Assert.Single(actions.Actions);
      var moveCamera = (CameraToPosition)actions.Actions[0];
      ElementAsserts.IsValid(moveCamera);

      Assert.Equal(position, moveCamera.Position);
    }

    [Fact]
    public void AddDialogNotification()
    {
      var text = new LocalizedString { Key = "test_key" };

      var actions =
          ActionListBuilder.New().AddDialogNotification(text).Build();

      Assert.Single(actions.Actions);
      var notification = (AddDialogNotification)actions.Actions[0];
      ElementAsserts.IsValid(notification);

      Assert.Equal(text.Key, notification.Text.Key);
    }

    [Fact]
    public void ClearBlood()
    {
      var actions = ActionListBuilder.New().ClearBlood().Build();

      Assert.Single(actions.Actions);
      var clearBlood = (ClearBlood)actions.Actions[0];
      ElementAsserts.IsValid(clearBlood);
    }
  }
}
