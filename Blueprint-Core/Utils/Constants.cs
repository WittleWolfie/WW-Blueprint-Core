using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Mechanics;

namespace BlueprintCore.Utils
{
  public static class Constants
  {
    /**
     * Probably an unnecessary optimization, but these constants are available whenever you need an
     * empty but non-null object.
     */
    public static class Empty
    {
      public static readonly ActionList Actions = new() { Actions = new GameAction[0] };
      public static readonly ArmorProficiencyGroup[] ArmorProficiencies =
          new ArmorProficiencyGroup[0];
      public static readonly ConditionsChecker Conditions = new() { Conditions = new Condition[0] };
      public static readonly ContextDiceValue DiceValue = new()
      {
        DiceType = DiceType.Zero,
        DiceCountValue = 0,
        BonusValue = 0
      };
      public static readonly LocalizedString String = new();
      public static readonly WeaponCategory[] WeaponCategories = new WeaponCategory[0];
    }
  }
}