using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.NewEx;
using BlueprintCore.Actions.New;
using BlueprintCore.Tests.Asserts;
using Xunit;

namespace BlueprintCore.Tests.Actions.Builder.NewEx
{
  public class ActionListBuilderNewExTest : ActionListBuilderTestBase
  {
    [Fact]
    public void SwitchToDemoralizeTarget()
    {
      var actions = ActionListBuilder.New().SwitchToDemoralizeTarget().Build();

      Assert.Single(actions.Actions);
      var retarget = (SwitchToDemoralizeTarget)actions.Actions[0];
      ElementAsserts.IsValid(retarget);
    }
  }
}
