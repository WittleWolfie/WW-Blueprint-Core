using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder.NewEx;
using BlueprintCore.Tests.Asserts;
using Kingmaker.ElementsSystem;
using Xunit;

namespace BlueprintCore.Tests.Conditions.Builder
{
  public class ConditionsCheckerBuilderTest : ConditionsCheckerBuilderTestBase
  {
    [Fact]
    public void UseOr()
    {
      var conditions = ConditionsCheckerBuilder.New().UseOr().Build();

      Assert.Equal(Operation.Or, conditions.Operation);
      Assert.NotNull(conditions.Conditions);
    }

    [Fact]
    public void MultipleConditions()
    {
      var conditions =
          ConditionsCheckerBuilder.New()
              .IsDemoralizeAction()
              .TargetInMeleeRange()
              .TargetIsYourself()
              .Build();

      Assert.Equal(3, conditions.Conditions.Length);
      foreach (Element element in conditions.Conditions)
      {
        ElementAsserts.IsValid(element);
      }
    }
  }
}
