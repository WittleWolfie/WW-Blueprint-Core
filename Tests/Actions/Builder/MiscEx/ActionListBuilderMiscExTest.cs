using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.MiscEx;
using BlueprintCore.Test.Asserts;
using Kingmaker.Achievements.Actions;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Xunit;
using static BlueprintCore.Test.TestData;

namespace BlueprintCore.Test.Actions.Builder.MiscEx
{
  public class ActionListBuilderMiscExTest : TestBase
  {
    //----- Kingmaker.Achievements.Actions -----//

    [Fact]
    public void IncrementAchievement()
    {
      var actions =
          ActionListBuilder.New()
              .IncrementAchievement(AchievementGuid)
              .Build();

      Assert.Single(actions.Actions);
      var increment = (ActionAchievementIncrementCounter)actions.Actions[0];
      ElementAsserts.IsValid(increment);

      Assert.Equal(Achievement.ToReference<AchievementDataReference>(), increment.m_Achievement);
    }

    [Fact]
    public void UnlockAchievement()
    {
      var actions =
          ActionListBuilder.New()
              .UnlockAchievement(AchievementGuid)
              .Build();

      Assert.Single(actions.Actions);
      var unlock = (ActionAchievementUnlock)actions.Actions[0];
      ElementAsserts.IsValid(unlock);

      Assert.Equal(Achievement.ToReference<AchievementDataReference>(), unlock.m_Achievement);
    }

    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    [Fact]
    public void CreateCustomCompanion()
    {
      var actions = ActionListBuilder.New().CreateCustomCompanion().Build();

      Assert.Single(actions.Actions);
      var createCompanion = (CreateCustomCompanion)actions.Actions[0];
      ElementAsserts.IsValid(createCompanion);

      Assert.False(createCompanion.ForFree);
      Assert.False(createCompanion.MatchPlayerXpExactly);
      Assert.NotNull(createCompanion.OnCreate.Actions);
    }

    [Fact]
    public void CreateCustomCompanion_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .CreateCustomCompanion(
                  free: true,
                  matchPlayerXp: true,
                  onCreate: ActionListBuilder.New().CustomEvent("event_id"))
              .Build();

      Assert.Single(actions.Actions);
      var createCompanion = (CreateCustomCompanion)actions.Actions[0];
      ElementAsserts.IsValid(createCompanion);

      Assert.True(createCompanion.ForFree);
      Assert.True(createCompanion.MatchPlayerXpExactly);
      Assert.Single(createCompanion.OnCreate.Actions);
      Assert.IsType<CustomEvent>(createCompanion.OnCreate.Actions[0]);
    }

    [Fact]
    public void CustomEvent()
    {
      var eventId = "event_id";
      var actions = ActionListBuilder.New().CustomEvent(eventId).Build();

      Assert.Single(actions.Actions);
      var customEvent = (CustomEvent)actions.Actions[0];
      ElementAsserts.IsValid(customEvent);

      Assert.Equal(eventId, customEvent.EventId);
    }
  }
}
