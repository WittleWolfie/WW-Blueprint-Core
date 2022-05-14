using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.ElementsSystem;
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
