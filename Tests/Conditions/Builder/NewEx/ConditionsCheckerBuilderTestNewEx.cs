using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.NewEx;
using BlueprintCore.Conditions.New;
using BlueprintCore.Test.Asserts;
using Xunit;

namespace BlueprintCore.Test.Conditions.Builder.NewEx
{
  public class ConditionsCheckerBuilderNewExTest : TestBase
  {
    [Fact]
    public void IsDemoralizeAction()
    {
      var conditions = ConditionsCheckerBuilder.New().IsDemoralizeAction().Build();

      Assert.Single(conditions.Conditions);
      var isDemoralize = (IsDemoralizeAction)conditions.Conditions[0];
      ElementAsserts.IsValid(isDemoralize);
    }

    [Fact]
    public void TargetInMeleeRange()
    {
      var conditions = ConditionsCheckerBuilder.New().TargetInMeleeRange().Build();

      Assert.Single(conditions.Conditions);
      var inMeleeRange = (TargetInMeleeRange)conditions.Conditions[0];
      ElementAsserts.IsValid(inMeleeRange);
    }
  }
}
