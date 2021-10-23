using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.NewEx;
using BlueprintCore.Conditions.New;
using BlueprintCore.Test.Asserts;
using Xunit;

namespace BlueprintCore.Test.Conditions.Builder.NewEx
{
  public class ConditionsBuilderNewExTest : TestBase
  {
    [Fact]
    public void TargetInMeleeRange()
    {
      var conditions = ConditionsBuilder.New().TargetInMeleeRange().Build();

      Assert.Single(conditions.Conditions);
      var inMeleeRange = (TargetInMeleeRange)conditions.Conditions[0];
      ElementAsserts.IsValid(inMeleeRange);
    }
  }
}
