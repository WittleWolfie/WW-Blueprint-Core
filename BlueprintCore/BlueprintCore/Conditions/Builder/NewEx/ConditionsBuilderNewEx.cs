//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Conditions.New;
using BlueprintCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Conditions.Builder.NewEx
{
  /// <summary>
  /// Extension to <see cref="ConditionsBuilder"/> for conditions defined in BlueprintCore and not available in the base game.
  /// </summary>
  /// <inheritdoc cref="ConditionsBuilder"/>
  public static class ConditionsBuilderNewEx
  {

    /// <summary>
    /// Adds <see cref="HasActionsAvailable"/>
    /// </summary>
    public static ConditionsBuilder HasActionsAvailable(
        this ConditionsBuilder builder,
        bool negate = false,
        bool? requireFullRound = null,
        bool? requireMove = null,
        bool? requireStandard = null,
        bool? requireSwift = null)
    {
      var element = ElementTool.Create<HasActionsAvailable>();
      element.Not = negate;
      element.RequireFullRound = requireFullRound ?? element.RequireFullRound;
      element.RequireMove = requireMove ?? element.RequireMove;
      element.RequireStandard = requireStandard ?? element.RequireStandard;
      element.RequireSwift = requireSwift ?? element.RequireSwift;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="TargetInMeleeRange"/>
    /// </summary>
    public static ConditionsBuilder TargetInMeleeRange(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<TargetInMeleeRange>();
      element.Not = negate;
      return builder.Add(element);
    }
  }
}
