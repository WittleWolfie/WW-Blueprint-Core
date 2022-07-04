using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Mechanics;

#nullable enable
namespace BlueprintCore.Utils.Types
{
  /// <summary>
  /// Helper class for creating <see cref="ContextDurationValue"/> objects.
  /// </summary>
  public static class ContextDuration
  {
    /// <summary>
    /// Constant duration: (value) (rate). e.g. 3 rounds
    /// </summary>
    /// <param name="isExtendable">Determines if the duration is affected by Extend Metamagic.</param>
    public static ContextDurationValue Fixed(
      int value, DurationRate rate = DurationRate.Rounds, bool? isExtendable = null)
    {
      return Create(bonus: value, rate: rate, diceType: DiceType.Zero, diceCount: 0, isExtendable: isExtendable);
    }

    /// <summary>
    /// Fixed dice roll duration: (diceCount)(diceType) + (bonus) (rate). e.g. 2d6 + 3 rounds
    /// </summary>
    /// <param name="isExtendable">Determines if the duration is affected by Extend Metamagic.</param>
    public static ContextDurationValue FixedDice(
      DiceType diceType,
      int diceCount = 1,
      int bonus = 0,
      DurationRate rate = DurationRate.Rounds,
      bool? isExtendable = null)
    {
      return Create(bonus: bonus, rate: rate, diceType: diceType, diceCount: diceCount, isExtendable: isExtendable);
    }

    /// <summary>
    /// Context dependent duration: (value) (rate). e.g. ContextValues.Rank() rounds
    /// </summary>
    /// <param name="isExtendable">Determines if the duration is affected by Extend Metamagic.</param>
    public static ContextDurationValue Variable(
      ContextValue value, DurationRate rate = DurationRate.Rounds, bool? isExtendable = null)
    {
      return Create(bonus: value, rate: rate, diceType: DiceType.Zero, diceCount: 0, isExtendable: isExtendable);
    }

    /// <summary>
    /// Context dependent dice roll: (diceCount)(diceType) + (bonus). e.g. ContextValues.Rank()d6 + 2
    /// </summary>
    /// <param name="isExtendable">Determines if the duration is affected by Extend Metamagic.</param>
    public static ContextDurationValue VariableDice(
      DiceType diceType,
      ContextValue diceCount,
      ContextValue? bonus = null,
      DurationRate rate = DurationRate.Rounds,
      bool? isExtendable = null)
    {
      return Create(
        bonus: bonus ?? 0, rate: rate, diceType: diceType, diceCount: diceCount, isExtendable: isExtendable);
    }

    private static ContextDurationValue Create(
      ContextValue bonus,
      DurationRate rate,
      DiceType diceType,
      ContextValue diceCount,
      bool? isExtendable = null)
    {
      var duration = new ContextDurationValue
      {
        BonusValue = bonus,
        Rate = rate,
        DiceType = diceType,
        DiceCountValue = diceCount
      };
      if (isExtendable != null)
      {
        duration.m_IsExtendable = isExtendable.Value;
      }
      return duration;
    }
  }
}