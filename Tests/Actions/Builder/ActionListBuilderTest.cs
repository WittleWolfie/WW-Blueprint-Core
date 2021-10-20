using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Actions.Builder.NewEx;
using BlueprintCore.Actions.New;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Test.Asserts;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using System;
using Xunit;
using static BlueprintCore.Test.TestData;

namespace BlueprintCore.Test.Actions.Builder
{
  public class ActionListBuilderTest : TestBase
  {
    [Fact]
    public void Empty()
    {
      var actions = ActionsBuilder.New().Build();

      Assert.NotNull(actions.Actions);
      Assert.Empty(actions.Actions);
    }

    [Fact]
    public void MultipleActions()
    {
      var actions =
          ActionsBuilder.New()
              .ApplyBuff(BuffGuid, useDurationSeconds: true)
              .MeleeAttack()
              .RemoveBuff(BuffGuid)
              .Build();

      Assert.Equal(3, actions.Actions.Length);
      foreach (Element element in actions.Actions)
      {
        ElementAsserts.IsValid(element);
      }
    }

    [Fact]
    public void Conditional()
    {
      var conditions = ConditionsBuilder.New().TargetIsYourself();

      var actions =
          ActionsBuilder.New()
              .Conditional(
                  conditions,
                  ifTrue: ActionsBuilder.New().MeleeAttack(),
                  ifFalse: ActionsBuilder.New().SwitchToDemoralizeTarget())
              .Build();

      Assert.Single(actions.Actions);
      var conditional = (Conditional)actions.Actions[0];
      ElementAsserts.IsValid(conditional);

      Assert.Single(conditional.ConditionsChecker.Conditions);
      Assert.IsType<ContextConditionTargetIsYourself>(conditional.ConditionsChecker.Conditions[0]);

      Assert.Single(conditional.IfTrue.Actions);
      Assert.IsType<ContextActionMeleeAttack>(conditional.IfTrue.Actions[0]);

      Assert.Single(conditional.IfFalse.Actions);
      Assert.IsType<SwitchToDemoralizeTarget>(conditional.IfFalse.Actions[0]);
    }

    [Fact]
    public void Conditional_WithoutFalseActions()
    {
      var conditions = ConditionsBuilder.New().TargetIsYourself();

      var actions =
          ActionsBuilder.New()
              .Conditional(
                  conditions,
                  ifTrue: ActionsBuilder.New().MeleeAttack().SwitchToDemoralizeTarget())
              .Build();

      Assert.Single(actions.Actions);
      var conditional = (Conditional)actions.Actions[0];
      ElementAsserts.IsValid(conditional);

      Assert.Single(conditional.ConditionsChecker.Conditions);
      Assert.IsType<ContextConditionTargetIsYourself>(conditional.ConditionsChecker.Conditions[0]);

      Assert.Equal(2, conditional.IfTrue.Actions.Length);
      Assert.IsType<ContextActionMeleeAttack>(conditional.IfTrue.Actions[0]);
      Assert.IsType<SwitchToDemoralizeTarget>(conditional.IfTrue.Actions[1]);
    }

    [Fact]
    public void Conditional_WithoutTrueActions()
    {
      var conditions = ConditionsBuilder.New().TargetIsYourself();

      var actions =
          ActionsBuilder.New()
              .Conditional(
                  conditions,
                  ifFalse: ActionsBuilder.New().MeleeAttack().SwitchToDemoralizeTarget())
              .Build();

      Assert.Single(actions.Actions);
      var conditional = (Conditional)actions.Actions[0];
      ElementAsserts.IsValid(conditional);

      Assert.Single(conditional.ConditionsChecker.Conditions);
      Assert.IsType<ContextConditionTargetIsYourself>(conditional.ConditionsChecker.Conditions[0]);

      Assert.Equal(2, conditional.IfFalse.Actions.Length);
      Assert.IsType<ContextActionMeleeAttack>(conditional.IfFalse.Actions[0]);
      Assert.IsType<SwitchToDemoralizeTarget>(conditional.IfFalse.Actions[1]);
    }

    [Fact]
    public void Conditional_WithoutActions()
    {
      var conditions = ConditionsBuilder.New().TargetIsYourself();

      Assert.Throws<InvalidOperationException>(
          () => ActionsBuilder.New().Conditional(conditions).Build());
    }
  }
}
