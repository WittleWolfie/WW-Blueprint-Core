using System;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Actions.Builder.NewEx;
using BlueprintCore.Actions.New;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder.NewEx;
using BlueprintCore.Tests.Asserts;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Xunit;

namespace BlueprintCore.Tests.Actions
{
  public class ActionListBuilderTest : ActionListBuilderTestBase
  {
    [Fact]
    public void Empty()
    {
      var actions = ActionListBuilder.New().Build();

      Assert.NotNull(actions.Actions);
      Assert.Empty(actions.Actions);
    }

    [Fact]
    public void MultipleActions()
    {
      var actions =
          ActionListBuilder.New()
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
      var conditions = ConditionsCheckerBuilder.New().TargetIsYourself();

      var actions =
          ActionListBuilder.New()
              .Conditional(
                  conditions,
                  ifTrue: ActionListBuilder.New().MeleeAttack(),
                  ifFalse: ActionListBuilder.New().SwitchToDemoralizeTarget())
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
      var conditions = ConditionsCheckerBuilder.New().TargetIsYourself();

      var actions =
          ActionListBuilder.New()
              .Conditional(
                  conditions,
                  ifTrue: ActionListBuilder.New().MeleeAttack().SwitchToDemoralizeTarget())
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
      var conditions = ConditionsCheckerBuilder.New().TargetIsYourself();

      var actions =
          ActionListBuilder.New()
              .Conditional(
                  conditions,
                  ifFalse: ActionListBuilder.New().MeleeAttack().SwitchToDemoralizeTarget())
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
      var conditions = ConditionsCheckerBuilder.New().TargetIsYourself();

      Assert.Throws<InvalidOperationException>(
          () => ActionListBuilder.New().Conditional(conditions).Build());
    }
  }
}
