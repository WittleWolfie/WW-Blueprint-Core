using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using System;
using System.Collections.Generic;

namespace BlueprintCoreGen.CodeGen.Overrides.Actions
{
  /// <summary>
  /// Stores types which should not be included in builders or configurators. Usually this indicates they are unused by
  /// the game but it is also used for some manual overrides such as basic condition operations implemented directly in
  /// ConditionsBuilder.
  /// </summary>
  public static class Ignored
  {
    public static readonly List<Type> BuilderTypes =
      new()
      {
        // ** Types implemented in ActionsBuilder **//

        typeof(Conditional),

        // *****************************************//

        // ** Types implemented in ConditionsBuilder **//

        typeof(False),
        typeof(GreaterThan),
        typeof(LessThan),
        typeof(OrAndLogic),

        // ********************************************//
      };
  }
}
