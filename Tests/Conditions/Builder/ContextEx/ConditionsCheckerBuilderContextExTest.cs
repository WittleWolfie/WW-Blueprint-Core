using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Tests.Asserts;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Xunit;

namespace BlueprintCore.Tests.Conditions.Builder.ContextEx
{
  public class ConditionsCheckerBuilderContextExTest : ConditionsCheckerBuilderTestBase
  {
    [Fact]
    public void CasterHasFact()
    {
      var conditions = ConditionsCheckerBuilder.New().CasterHasFact(FactGuid).Build();

      Assert.Single(conditions.Conditions);
      var hasFact = (ContextConditionCasterHasFact)conditions.Conditions[0];
      ElementAsserts.IsValid(hasFact);
      Assert.Equal(Fact.ToReference<BlueprintUnitFactReference>(), hasFact.m_Fact);
    }

    [Fact]
    public void HasFact()
    {
      var conditions = ConditionsCheckerBuilder.New().HasFact(FactGuid).Build();

      Assert.Single(conditions.Conditions);
      var hasFact = (ContextConditionHasFact)conditions.Conditions[0];
      ElementAsserts.IsValid(hasFact);
      Assert.Equal(Fact.ToReference<BlueprintUnitFactReference>(), hasFact.m_Fact);
    }

    [Fact]
    public void HasBuffFromCaster()
    {
      var conditions =
          ConditionsCheckerBuilder.New().HasBuffFromCaster(BuffGuid).Build();

      Assert.Single(conditions.Conditions);
      var hasBuff = (ContextConditionHasBuffFromCaster)conditions.Conditions[0];
      ElementAsserts.IsValid(hasBuff);
      Assert.Equal(Buff.ToReference<BlueprintBuffReference>(), hasBuff.m_Buff);
    }

    [Fact]
    public void TargetIsYourself()
    {
      var conditions = ConditionsCheckerBuilder.New().TargetIsYourself().Build();

      Assert.Single(conditions.Conditions);
      var targetsYourself = (ContextConditionTargetIsYourself)conditions.Conditions[0];
      ElementAsserts.IsValid(targetsYourself);
    }
  }
}
