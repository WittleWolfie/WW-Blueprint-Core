using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.AVEx;
using BlueprintCore.Test.Asserts;
using BlueprintCore.Utils;
using Kingmaker.Assets.UnitLogic.Mechanics.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Visual.Animation.Actions;
using System.Runtime.Serialization;
using Xunit;
using static BlueprintCore.Test.TestData;

namespace BlueprintCore.Test.Actions.Builder.AVEx
{
  public class ActionsBuilderAVExTest : TestBase
  {
    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    [Fact]
    public void ChangeBookImage()
    {
      var image = new SpriteLink { AssetId = "hi" };

      var actions = ActionsBuilder.New().ChangeBookImage(image).Build();

      Assert.Single(actions.Actions);
      var setImage = (ChangeBookEventImage)actions.Actions[0];
      ElementAsserts.IsValid(setImage);

      Assert.Equal(image, setImage.m_Image);
    }

    [Fact]
    public void MoveCamera()
    {
      var position = ElementTool.Create<UnitPosition>();
      position.Unit = TestUnit;

      var actions = ActionsBuilder.New().MoveCamera(position).Build();

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
          ActionsBuilder.New().AddDialogNotification(text).Build();

      Assert.Single(actions.Actions);
      var notification = (AddDialogNotification)actions.Actions[0];
      ElementAsserts.IsValid(notification);

      Assert.Equal(text.Key, notification.Text.Key);
    }

    [Fact]
    public void ClearBlood()
    {
      var actions = ActionsBuilder.New().ClearBlood().Build();

      Assert.Single(actions.Actions);
      var clearBlood = (ClearBlood)actions.Actions[0];
      ElementAsserts.IsValid(clearBlood);
    }

    [Fact]
    public void RunAnimationClip()
    {
      // This is necessary because AnimationClipWrapper inherits from SerializedObject which cannot
      // be constructed in unit tests.
      var clip =
          (AnimationClipWrapperLink)FormatterServices.GetUninitializedObject(
              typeof(AnimationClipWrapperLink));

      var actions = ActionsBuilder.New().RunAnimationClip(clip).Build();

      Assert.Single(actions.Actions);
      var animation = (ContextActionRunAnimationClip)actions.Actions[0];
      ElementAsserts.IsValid(animation);

      Assert.Equal(clip, animation.ClipWrapper);
      Assert.Equal(ExecutionMode.Interrupted, animation.Mode);
      Assert.Equal(0.25f, animation.TransitionIn);
      Assert.Equal(0.25f, animation.TransitionOut);
    }

    [Fact]
    public void RunAnimationClip_WithOptionalValues()
    {
      // This is necessary because AnimationClipWrapper inherits from SerializedObject which cannot
      // be constructed in unit tests.
      var clip =
          (AnimationClipWrapperLink)FormatterServices.GetUninitializedObject(
              typeof(AnimationClipWrapperLink));

      var actions =
          ActionsBuilder.New()
              .RunAnimationClip(
                  clip, mode: ExecutionMode.Sequenced, transitionIn: 0.5f, transitionOut: 0.5f)
              .Build();

      Assert.Single(actions.Actions);
      var animation = (ContextActionRunAnimationClip)actions.Actions[0];
      ElementAsserts.IsValid(animation);

      Assert.Equal(clip, animation.ClipWrapper);
      Assert.Equal(ExecutionMode.Sequenced, animation.Mode);
      Assert.Equal(0.5f, animation.TransitionIn);
      Assert.Equal(0.5f, animation.TransitionOut);
    }

    [Fact]
    public void Bark()
    {
      var actions = ActionsBuilder.New().Bark(new LocalizedString { Key = "bark" }).Build();

      Assert.Single(actions.Actions);
      var bark = (ContextActionShowBark)actions.Actions[0];
      ElementAsserts.IsValid(bark);

      Assert.Equal("bark", bark.WhatToBark.Key);
      Assert.False(bark.ShowWhileUnconscious);
      Assert.False(bark.BarkDurationByText);
    }

    [Fact]
    public void Bark_WithOptionalValues()
    {
      var actions =
          ActionsBuilder.New()
              .Bark(
                  new LocalizedString { Key = "bark" },
                  showIfUnconcious: true,
                  durationBasedOnTextLength: true)
              .Build();

      Assert.Single(actions.Actions);
      var bark = (ContextActionShowBark)actions.Actions[0];
      ElementAsserts.IsValid(bark);

      Assert.Equal("bark", bark.WhatToBark.Key);
      Assert.True(bark.ShowWhileUnconscious);
      Assert.True(bark.BarkDurationByText);
    }

    [Fact]
    public void SpawnFx()
    {
      var prefab = new PrefabLink();

      var actions = ActionsBuilder.New().SpawnFx(prefab).Build();

      Assert.Single(actions.Actions);
      var spawnFx = (ContextActionSpawnFx)actions.Actions[0];
      ElementAsserts.IsValid(spawnFx);

      Assert.Equal(prefab, spawnFx.PrefabLink);
    }

    //----- Kingmaker.Assets.UnitLogic.Mechanics.Actions -----//

    [Fact]
    public void PlaySound()
    {
      var actions = ActionsBuilder.New().PlaySound("a sound").Build();

      Assert.Single(actions.Actions);
      var playSound = (ContextActionPlaySound)actions.Actions[0];
      ElementAsserts.IsValid(playSound);

      Assert.Equal("a sound", playSound.SoundName);
    }
  }
}
