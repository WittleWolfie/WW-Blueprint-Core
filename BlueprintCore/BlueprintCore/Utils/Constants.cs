using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Mechanics;

#nullable enable
namespace BlueprintCore.Utils
{
  public static class Constants
  {
    /// <summary>Empty, non-null object constants.</summary>
    /// 
    /// <remarks>
    /// It is generally recommended to use these in place of null. Some areas of the Wrath codebase are null safe, but
    /// many are not. Most code behaves correctly with empty objects.
    /// </remarks>
    public static class Empty
    {
      public static readonly ActionList Actions = new() { Actions = new GameAction[0] };
      public static readonly ConditionsChecker Conditions = new() { Conditions = new Condition[0] };
      public static readonly ContextDiceValue DiceValue = new()
      {
        DiceType = DiceType.Zero,
        DiceCountValue = 0,
        BonusValue = 0
      };
      public static readonly LocalizedString String = new();
      public static readonly PrefabLink PrefabLink = new();
      public static readonly ShowCheck ShowCheck = new();
      public static readonly CueSelection CueSelection = new();
      public static readonly CharacterSelection CharacterSelection = new();
      public static readonly DialogSpeaker DialogSpeaker = new() { NoSpeaker = true };
    }
  }
}