using BlueprintCore.Test.TestData;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Xunit;

namespace BlueprintCore.Test.Utils.Types
{
  public class ContextValuesTest
  {
    [Fact]
    public void Constant()
    {
      var value = ContextValues.Constant(2);
      Assert.Equal(expected: ContextValueType.Simple, actual: value.ValueType);
      Assert.Equal(expected: 2, actual: value.Value);
    }

    [Fact]
    public void Rank()
    {
      var value = ContextValues.Rank();
      Assert.Equal(expected: ContextValueType.Rank, actual: value.ValueType);
      Assert.Equal(expected: AbilityRankType.Default, actual: value.ValueRank);
    }

    [Fact]
    public void Rank_WithType()
    {
      var value = ContextValues.Rank(AbilityRankType.DamageDice);
      Assert.Equal(expected: ContextValueType.Rank, actual: value.ValueType);
      Assert.Equal(expected: AbilityRankType.DamageDice, actual: value.ValueRank);
    }

    [Fact]
    public void Shared()
    {
      var value = ContextValues.Shared(AbilitySharedValue.Duration);
      Assert.Equal(expected: ContextValueType.Shared, actual: value.ValueType);
      Assert.Equal(expected: AbilitySharedValue.Duration, actual: value.ValueShared);
    }

    [Fact]
    public void Property()
    {
      var value = ContextValues.Property(UnitProperty.CR);
      Assert.Equal(expected: ContextValueType.TargetProperty, actual: value.ValueType);
      Assert.Equal(expected: UnitProperty.CR, actual: value.Property);
    }

    [Fact]
    public void Property_ToCaster()
    {
      var value = ContextValues.Property(UnitProperty.CR, toCaster: true);
      Assert.Equal(expected: ContextValueType.CasterProperty, actual: value.ValueType);
      Assert.Equal(expected: UnitProperty.CR, actual: value.Property);
    }

    [Fact]
    public void CustomProperty()
    {
      var value = ContextValues.CustomProperty(Guids.Property);
      Assert.Equal(expected: ContextValueType.TargetProperty, actual: value.ValueType);
      Assert.Equal(expected: TestData.Blueprints.Property.Reference, actual: value.m_CustomProperty);
    }

    [Fact]
    public void CustomProperty_ToCaster()
    {
      var value = ContextValues.CustomProperty(Guids.Property, toCaster: true);
      Assert.Equal(expected: ContextValueType.CasterProperty, actual: value.ValueType);
      Assert.Equal(expected: TestData.Blueprints.Property.Reference, actual: value.m_CustomProperty);
    }

    [Fact]
    public void SpellLevel()
    {
      var value = ContextValues.SpellLevel();
      Assert.Equal(expected: ContextValueType.AbilityParameter, actual: value.ValueType);
      Assert.Equal(expected: AbilityParameterType.Level, actual: value.m_AbilityParameter);
    }

    [Fact]
    public void CasterStatBonus()
    {
      var value = ContextValues.CasterStatBonus();
      Assert.Equal(expected: ContextValueType.AbilityParameter, actual: value.ValueType);
      Assert.Equal(expected: AbilityParameterType.CasterStatBonus, actual: value.m_AbilityParameter);
    }
  }
}
