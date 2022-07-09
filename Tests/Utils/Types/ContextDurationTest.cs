using BlueprintCore.Utils.Types;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Mechanics;
using Xunit;

namespace BlueprintCore.Test.Utils.Types
{
  public class ContextDurationTest
  {
    [Fact]
    public void Fixed()
    {
      var duration = ContextDuration.Fixed(5);

      Assert.Equal(expected: 5, actual: duration.BonusValue.Value);
      Assert.Equal(expected: DurationRate.Rounds, actual: duration.Rate);
      Assert.Equal(expected: DiceType.Zero, actual: duration.DiceType);
      Assert.Equal(expected: 0, actual: duration.DiceCountValue.Value);
    }

    [Fact]
    public void Fixed_WithOptionalValues()
    {
      var duration = ContextDuration.Fixed(5, rate: DurationRate.Minutes, isExtendable: true);

      Assert.Equal(expected: 5, actual: duration.BonusValue.Value);
      Assert.Equal(expected: DurationRate.Minutes, actual: duration.Rate);
      Assert.Equal(expected: DiceType.Zero, actual: duration.DiceType);
      Assert.Equal(expected: 0, actual: duration.DiceCountValue.Value);
      Assert.True(duration.IsExtendable);
    }

    [Fact]
    public void FixedDice()
    {
      var duration = ContextDuration.FixedDice(DiceType.D10);

      Assert.Equal(expected: 0, actual: duration.BonusValue.Value);
      Assert.Equal(expected: DurationRate.Rounds, actual: duration.Rate);
      Assert.Equal(expected: DiceType.D10, actual: duration.DiceType);
      Assert.Equal(expected: 1, actual: duration.DiceCountValue.Value);
    }

    [Fact]
    public void FixedDice_WithOptionalValues()
    {
      var duration =
        ContextDuration.FixedDice(DiceType.D10, diceCount: 3, bonus: 4, rate: DurationRate.Hours, isExtendable: true);

      Assert.Equal(expected: 4, actual: duration.BonusValue.Value);
      Assert.Equal(expected: DurationRate.Hours, actual: duration.Rate);
      Assert.Equal(expected: DiceType.D10, actual: duration.DiceType);
      Assert.Equal(expected: 3, actual: duration.DiceCountValue.Value);
      Assert.True(duration.IsExtendable);
    }

    [Fact]
    public void Variable()
    {
      var duration = ContextDuration.Variable(ContextValues.Rank());

      Assert.Equal(expected: 0, actual: duration.BonusValue.Value);
      Assert.True(duration.BonusValue.IsValueRank);
      Assert.Equal(expected: DurationRate.Rounds, actual: duration.Rate);
      Assert.Equal(expected: DiceType.Zero, actual: duration.DiceType);
      Assert.Equal(expected: 0, actual: duration.DiceCountValue.Value);
    }

    [Fact]
    public void Variable_WithOptionalValues()
    {
      var duration = ContextDuration.Variable(ContextValues.Rank(), rate: DurationRate.Minutes, isExtendable: true);

      Assert.Equal(expected: 0, actual: duration.BonusValue.Value);
      Assert.True(duration.BonusValue.IsValueRank);
      Assert.Equal(expected: DurationRate.Minutes, actual: duration.Rate);
      Assert.Equal(expected: DiceType.Zero, actual: duration.DiceType);
      Assert.Equal(expected: 0, actual: duration.DiceCountValue.Value);
      Assert.True(duration.IsExtendable);
    }

    [Fact]
    public void VariableDice()
    {
      var duration = ContextDuration.VariableDice(DiceType.D10, ContextValues.Shared(AbilitySharedValue.Duration));

      Assert.Equal(expected: 0, actual: duration.BonusValue.Value);
      Assert.Equal(expected: DurationRate.Rounds, actual: duration.Rate);
      Assert.Equal(expected: DiceType.D10, actual: duration.DiceType);
      Assert.Equal(expected: 0, actual: duration.DiceCountValue.Value);
      Assert.True(duration.DiceCountValue.IsValueShared);
      Assert.Equal(expected: AbilitySharedValue.Duration, actual: duration.DiceCountValue.ValueShared);
    }

    [Fact]
    public void VariableDice_WithOptionalValues()
    {
      var duration =
        ContextDuration.VariableDice(
          DiceType.D10,
          ContextValues.Shared(AbilitySharedValue.Duration),
          bonus: 4,
          rate: DurationRate.Hours,
          isExtendable: true);

      Assert.Equal(expected: 4, actual: duration.BonusValue.Value);
      Assert.Equal(expected: DurationRate.Hours, actual: duration.Rate);
      Assert.Equal(expected: DiceType.D10, actual: duration.DiceType);
      Assert.Equal(expected: 0, actual: duration.DiceCountValue.Value);
      Assert.True(duration.DiceCountValue.IsValueShared);
      Assert.Equal(expected: AbilitySharedValue.Duration, actual: duration.DiceCountValue.ValueShared);
      Assert.True(duration.IsExtendable);
    }
  }
}
