using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.NewEx;
using BlueprintCore.Actions.New;
using BlueprintCore.Test.Asserts;
using Xunit;

namespace BlueprintCore.Test.Actions.Builder.NewEx
{
  public class ActionsBuilderNewExTest : TestBase
  {
    [Fact]
    public void SwitchToDemoralizeTarget()
    {
      var actions = ActionsBuilder.New().SwitchToDemoralizeTarget().Build();

      Assert.Single(actions.Actions);
      var retarget = (SwitchToDemoralizeTarget)actions.Actions[0];
      ElementAsserts.IsValid(retarget);
    }
  }
}