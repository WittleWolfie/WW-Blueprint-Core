using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder.NewEx;
using BlueprintCore.Test.Asserts;
using Kingmaker.ElementsSystem;
using Xunit;

namespace BlueprintCore.Test.Conditions.Builder
{
  public class ConditionsBuilderTest : TestBase
  {
    [Fact]
    public void UseOr()
    {
      var conditions = ConditionsBuilder.New().UseOr().Build();

      Assert.Equal(Operation.Or, conditions.Operation);
      Assert.NotNull(conditions.Conditions);
    }

    [Fact]
    public void MultipleConditions()
    {
      var conditions =
          ConditionsBuilder.New()
              .TargetInMeleeRange()
              .TargetIsYourself()
              .Build();

      Assert.Equal(2, conditions.Conditions.Length);
      foreach (Element element in conditions.Conditions)
      {
        ElementAsserts.IsValid(element);
      }
    }
  }
}
