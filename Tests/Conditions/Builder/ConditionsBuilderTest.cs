using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder.NewEx;
using BlueprintCore.Test.Asserts;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.ElementsSystem;
using Xunit;
using static BlueprintCore.Test.TestData.Blueprints;
using static BlueprintCore.Test.TestData.Elements;

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
    public void Add_WithInit()
    {
      var conditions =
        ConditionsBuilder.New()
          .Add<HasBuff>(
            c =>
            {
              c.m_Buff = Buff.Reference;
              c.Target = new ClickedUnit();
            })
          .Build();

      Assert.Single(conditions.Conditions);
      var condition = (HasBuff)conditions.Conditions[0];
      ElementAsserts.IsValid(condition);

      Assert.Equal(Buff.Reference, condition.m_Buff);
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

    [Fact]
    public void AddFalse()
    {
      var conditions = ConditionsBuilder.New().AddFalse().Build();

      Assert.Single(conditions.Conditions);
      var condition = (False)conditions.Conditions[0];
      ElementAsserts.IsValid(condition);
      Assert.False(condition.Not);
    }

    [Fact]
    public void AddTrue()
    {
      var conditions = ConditionsBuilder.New().AddTrue().Build();

      Assert.Single(conditions.Conditions);
      var condition = (False)conditions.Conditions[0];
      ElementAsserts.IsValid(condition);
      Assert.True(condition.Not);
    }

    [Fact]
    public void AddGreaterThan()
    {
      var conditions =
          ConditionsBuilder.New()
              .AddGreaterThan(IntConst, IntConstAlt)
              .Build();

      Assert.Single(conditions.Conditions);
      var condition = (GreaterThan)conditions.Conditions[0];
      ElementAsserts.IsValid(condition);
      Assert.False(condition.Not);

      Assert.False(condition.FloatValues);
      Assert.Equal(IntConst, condition.Value);
      Assert.Equal(IntConstAlt, condition.MinValue);
    }

    [Fact]
    public void AddGreaterThan_WithFloats()
    {
      var conditions =
          ConditionsBuilder.New()
              .AddGreaterThan(FloatConst, FloatConstAlt)
              .Build();

      Assert.Single(conditions.Conditions);
      var condition = (GreaterThan)conditions.Conditions[0];
      ElementAsserts.IsValid(condition);
      Assert.False(condition.Not);

      Assert.True(condition.FloatValues);
      Assert.Equal(FloatConst, condition.FloatValue);
      Assert.Equal(FloatConstAlt, condition.FloatMinValue);
    }

    [Fact]
    public void AddLessThanOrEqualTo()
    {
      var conditions =
          ConditionsBuilder.New()
              .AddLessThanOrEqualTo(IntConst, IntConstAlt)
              .Build();

      Assert.Single(conditions.Conditions);
      var condition = (GreaterThan)conditions.Conditions[0];
      ElementAsserts.IsValid(condition);
      Assert.True(condition.Not);

      Assert.False(condition.FloatValues);
      Assert.Equal(IntConst, condition.Value);
      Assert.Equal(IntConstAlt, condition.MinValue);
    }

    [Fact]
    public void AddLessThanOrEqualTo_WithFloats()
    {
      var conditions =
          ConditionsBuilder.New()
              .AddLessThanOrEqualTo(FloatConst, FloatConstAlt)
              .Build();

      Assert.Single(conditions.Conditions);
      var condition = (GreaterThan)conditions.Conditions[0];
      ElementAsserts.IsValid(condition);
      Assert.True(condition.Not);

      Assert.True(condition.FloatValues);
      Assert.Equal(FloatConst, condition.FloatValue);
      Assert.Equal(FloatConstAlt, condition.FloatMinValue);
    }

    [Fact]
    public void AddIsEqual()
    {
      var conditions =
          ConditionsBuilder.New()
              .AddIsEqual(IntConst, IntConstAlt)
              .Build();

      Assert.Single(conditions.Conditions);
      var condition = (IsEqual)conditions.Conditions[0];
      ElementAsserts.IsValid(condition);
      Assert.False(condition.Not);

      Assert.Equal(IntConst, condition.FirstValue);
      Assert.Equal(IntConstAlt, condition.SecondValue);
    }

    [Fact]
    public void AddIsNotEqual()
    {
      var conditions =
          ConditionsBuilder.New()
              .AddIsNotEqual(IntConst, IntConstAlt)
              .Build();

      Assert.Single(conditions.Conditions);
      var condition = (IsEqual)conditions.Conditions[0];
      ElementAsserts.IsValid(condition);
      Assert.True(condition.Not);

      Assert.Equal(IntConst, condition.FirstValue);
      Assert.Equal(IntConstAlt, condition.SecondValue);
    }

    [Fact]
    public void AddLessThan()
    {
      var conditions =
          ConditionsBuilder.New()
              .AddLessThan(IntConst, IntConstAlt)
              .Build();

      Assert.Single(conditions.Conditions);
      var condition = (LessThan)conditions.Conditions[0];
      ElementAsserts.IsValid(condition);
      Assert.False(condition.Not);

      Assert.False(condition.FloatValues);
      Assert.Equal(IntConst, condition.Value);
      Assert.Equal(IntConstAlt, condition.MaxValue);
    }

    [Fact]
    public void AddLessThan_WithFloats()
    {
      var conditions =
          ConditionsBuilder.New()
              .AddLessThan(FloatConst, FloatConstAlt)
              .Build();

      Assert.Single(conditions.Conditions);
      var condition = (LessThan)conditions.Conditions[0];
      ElementAsserts.IsValid(condition);
      Assert.False(condition.Not);

      Assert.True(condition.FloatValues);
      Assert.Equal(FloatConst, condition.FloatValue);
      Assert.Equal(FloatConstAlt, condition.FloatMaxValue);
    }

    [Fact]
    public void AddGreaterThanOrEqualTo()
    {
      var conditions =
          ConditionsBuilder.New()
              .AddGreaterThanOrEqualTo(IntConst, IntConstAlt)
              .Build();

      Assert.Single(conditions.Conditions);
      var condition = (LessThan)conditions.Conditions[0];
      ElementAsserts.IsValid(condition);
      Assert.True(condition.Not);

      Assert.False(condition.FloatValues);
      Assert.Equal(IntConst, condition.Value);
      Assert.Equal(IntConstAlt, condition.MaxValue);
    }

    [Fact]
    public void AddGreaterThanOrEqualTo_WithFloats()
    {
      var conditions =
          ConditionsBuilder.New()
              .AddGreaterThanOrEqualTo(FloatConst, FloatConstAlt)
              .Build();

      Assert.Single(conditions.Conditions);
      var condition = (LessThan)conditions.Conditions[0];
      ElementAsserts.IsValid(condition);
      Assert.True(condition.Not);

      Assert.True(condition.FloatValues);
      Assert.Equal(FloatConst, condition.FloatValue);
      Assert.Equal(FloatConstAlt, condition.FloatMaxValue);
    }
    
    [Fact]
    public void AddOrAndLogic()
    {
      var conditions =
          ConditionsBuilder.New()
              .AddOrAndLogic(ConditionsBuilder.New().TargetInMeleeRange())
              .Build();

      Assert.Single(conditions.Conditions);
      var condition = (OrAndLogic)conditions.Conditions[0];
      ElementAsserts.IsValid(condition);
      Assert.False(condition.Not);

      Assert.Single(condition.ConditionsChecker.Conditions);
      ElementAsserts.IsValid(condition.ConditionsChecker.Conditions[0]);
    }
  }
}
