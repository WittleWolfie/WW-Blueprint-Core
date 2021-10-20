using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Test.Asserts;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Xunit;
using static BlueprintCore.Test.TestData;

namespace BlueprintCore.Test.Conditions.Builder.ContextEx
{
  public class ConditionsBuilderContextExTest : TestBase
  {
    [Fact]
    public void CasterHasFact()
    {
      var conditions = ConditionsBuilder.New().CasterHasFact(FactGuid).Build();

      Assert.Single(conditions.Conditions);
      var hasFact = (ContextConditionCasterHasFact)conditions.Conditions[0];
      ElementAsserts.IsValid(hasFact);
      Assert.Equal(TestFact.ToReference<BlueprintUnitFactReference>(), hasFact.m_Fact);
    }

    [Fact]
    public void HasFact()
    {
      var conditions = ConditionsBuilder.New().HasFact(FactGuid).Build();

      Assert.Single(conditions.Conditions);
      var hasFact = (ContextConditionHasFact)conditions.Conditions[0];
      ElementAsserts.IsValid(hasFact);
      Assert.Equal(TestFact.ToReference<BlueprintUnitFactReference>(), hasFact.m_Fact);
    }

    [Fact]
    public void HasBuffFromCaster()
    {
      var conditions =
          ConditionsBuilder.New().HasBuffFromCaster(BuffGuid).Build();

      Assert.Single(conditions.Conditions);
      var hasBuff = (ContextConditionHasBuffFromCaster)conditions.Conditions[0];
      ElementAsserts.IsValid(hasBuff);
      Assert.Equal(Buff.ToReference<BlueprintBuffReference>(), hasBuff.m_Buff);
    }

    [Fact]
    public void TargetIsYourself()
    {
      var conditions = ConditionsBuilder.New().TargetIsYourself().Build();

      Assert.Single(conditions.Conditions);
      var targetsYourself = (ContextConditionTargetIsYourself)conditions.Conditions[0];
      ElementAsserts.IsValid(targetsYourself);
    }
  }
}
