using System;
using BlueprintCore.Conditions;
using BlueprintCore.Conditions.New;
using BlueprintCore.Tests.Asserts;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Xunit;

namespace BlueprintCore.Tests.Conditions
{
  [Collection("Harmony")]
  public class ConditionsCheckerBuilderTest : IDisposable
  {
    private static readonly string FactGuid = "f7dba63d-9b33-436d-9841-ca2821b89a1b";
    private readonly BlueprintUnitFact Fact = Util.Create<BlueprintUnitFact>(FactGuid);
    private static readonly string BuffGuid = "f3b38c34-2526-4ba6-a682-a751e5c05305";
    private readonly BlueprintBuff Buff = Util.Create<BlueprintBuff>(BuffGuid);

    public ConditionsCheckerBuilderTest()
    {
      BlueprintPatch.Add(Fact);
      BlueprintPatch.Add(Buff);
    }

    public void Dispose()
    {
      BlueprintPatch.Clear();
    }

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
