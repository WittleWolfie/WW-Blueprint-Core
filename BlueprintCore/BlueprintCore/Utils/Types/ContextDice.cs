using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Mechanics;

namespace BlueprintCore.Utils.Types
{
  /// <summary>
  /// Util for creating <c>ContextDiceValue</c>
  /// </summary>
  public static class ContextDice
  {
    /// <param name="diceCount">Number of dice to roll. Default 1</param>
    /// <param name="bonus">Fixed bonus added to result. Default 0</param>
    public static ContextDiceValue Value(
      DiceType diceType, ContextValue diceCount = null, ContextValue bonus = null)
    {
      return new() { DiceType = diceType, DiceCountValue = diceCount ?? 1, BonusValue = bonus ?? 0 };
    }
  }
}
