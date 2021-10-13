using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Mechanics;

namespace BlueprintCore.Utils
{
  public static class ContextDuration
  {
    public static ContextDurationValue Fixed(int value, DurationRate rate = DurationRate.Rounds)
    {
      var duration = new ContextDurationValue
      {
        BonusValue = value,
        Rate = rate,
        DiceType = DiceType.Zero,
        DiceCountValue = 0,
      };
      return duration;
    }
  }
}