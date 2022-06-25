using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Console;
using Kingmaker.Blueprints.Credits;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.ElementsSystem;
using Kingmaker.QA.Arbiter;
using Kingmaker.QA.Clockwork;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BlueprintCoreGen.CodeGen.Overrides.Ignored
{
  /// <summary>
  /// Flags whether a type should be ignored. Usually this is for unused types but there are some manually ignored
  /// types as well.
  /// </summary>
  public static class Ignored
  {
    private static readonly List<(Type type, List<string> names)> IgnoredFields =
      new()
      {
        (typeof(Element), new() { "name" }),
        (typeof(BlueprintComponent), new() { "m_Flags", "m_PrototypeLink", "name" }),
        (
          typeof(BlueprintScriptableObject),
          new()
          {
            "Components",
            "m_AllElements",
            "AssetGuid",
            "m_PrototypeId",
            "m_Overrides",
            "Comment",
            "name",
            "m_ValidationStatus"
          }
        ),
        (typeof(BlueprintFeatureSelection), new() { "m_Features" }),
      };
    public static bool ShouldIgnoreField(FieldInfo info, Type sourceType)
    {
      if (info.FieldType.IsGenericType && info.FieldType.GetGenericTypeDefinition() == typeof(ReferenceListProxy<,>))
      {
        return true;
      }

      var ignoreField = false;
      IgnoredFields.ForEach(
        ignoredFields =>
        {
          if (
            (sourceType == ignoredFields.type || sourceType.IsSubclassOf(ignoredFields.type))
            && ignoredFields.names.Contains(info.Name))
          {
            ignoreField = true;
          }
        });

      return ignoreField
        || info.Name.Contains("_Cached")        // Name used by Owlcat for cache fields
        || info.Name.Contains("__BackingField") // Compiler generated field
                                                // Skip constant, static, and read-only
        || info.IsLiteral
        || info.IsStatic
        || info.IsInitOnly;
    }

    private static readonly List<Type> IgnoredTypes =
      new()
      {
        // Types implemented in ActionsBuilder
        typeof(Conditional),

        // Types implemented in ConditionsBuilder
        typeof(False),
        typeof(GreaterThan),
        typeof(LessThan),
        typeof(OrAndLogic),

        // Legacy types
        typeof(AddStatBonusScaled),

        // QA Types
        typeof(BlueprintArbiterInstruction),
        typeof(BlueprintArbiterRoot),
        typeof(BlueprintClockworkScenario),
        typeof(BlueprintClockworkScenarioPart),

        // Credits
        typeof(BlueprintCreditsGroup),
        typeof(BlueprintCreditsRoles),
        typeof(BlueprintCreditsTeams),

        // Console
        typeof(GamePadTexts),
      };
    public static bool ShouldIgnore(Type type)
    {
      return IgnoredTypes.Contains(type)
        || IgnoredBlueprintComponents.Types.Contains(type)
        || IgnoredBlueprintScriptableObjects.Types.Contains(type)
        || IgnoredConditions.Types.Contains(type)
        || IgnoredGameActions.Types.Contains(type);
    }
  }
}
