using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using System;
using System.Collections.Generic;

namespace BlueprintCoreGen.CodeGen.Overrides.Ignored
{
  /// <summary>
  /// Flags whether a type should be ignored. Usually this is for unused types but there are some manually ignored
  /// types as well.
  /// </summary>
  public static class Ignored
  {
    private static readonly List<Type> ManualIgnored =
      new()
      {
        // Types implemented in ActionsBuilder
        typeof(Conditional),

        // Types implemented in ConditionsBuilder
        typeof(False),
        typeof(GreaterThan),
        typeof(LessThan),
        typeof(OrAndLogic),
      };

    public static bool ShouldIgnore(Type type)
    {
      return ManualIgnored.Contains(type)
        || IgnoredBlueprintComponents.Types.Contains(type)
        || IgnoredBlueprintScriptableObjects.Types.Contains(type)
        || IgnoredConditions.Types.Contains(type)
        || IgnoredGameActions.Types.Contains(type);
    }
  }
}
