using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using System;
using System.Collections.Generic;

namespace BlueprintCoreGen.CodeGen.Overrides
{
  /// <summary>
  /// Stores hardcoded overrides.
  /// </summary>
  public class GlobalOverrides
  {
    /// <summary>
    /// List blueprint types which should not have concrete implementations because they have custom implementations.
    /// </summary>
    public static readonly HashSet<Type> CustomBlueprintConfigurators =
      new()
      {
        typeof(BlueprintAbility),
        typeof(BlueprintAbilityAreaEffect),
        typeof(BlueprintAbilityResource),
        typeof(BlueprintBuff)
      };

    public static readonly Dictionary<Type, string> TypeNameOverrides =
        new()
        {
          // Name conflicts
          { typeof(Kingmaker.AI.Blueprints.TargetType), "Kingmaker.AI.Blueprints.TargetType" },
          { typeof(Kingmaker.UnitLogic.Abilities.Components.TargetType), "Kingmaker.UnitLogic.Abilities.Components.TargetType" },
          { typeof(Kingmaker.UnitLogic.Mechanics.ValueType), "Kingmaker.UnitLogic.Mechanics.ValueType" },
          { typeof(UnityEngine.Object), "UnityEngine.Object" },

          { typeof(bool), "bool" },
          { typeof(bool?), "bool" },

          { typeof(byte), "byte" },
          { typeof(byte?), "byte" },

          { typeof(sbyte), "sbyte" },
          { typeof(sbyte?), "sbyte" },

          { typeof(ushort), "ushort" },
          { typeof(ushort?), "ushort" },

          { typeof(int), "int" },
          { typeof(int?), "int" },

          { typeof(uint), "uint" },
          { typeof(uint?), "uint" },

          { typeof(long), "long" },
          { typeof(long?), "long" },

          { typeof(ulong), "ulong" },
          { typeof(ulong?), "ulong" },

          { typeof(char), "char" },
          { typeof(char?), "char" },

          { typeof(double), "double" },
          { typeof(double?), "double" },

          { typeof(float), "float" },
          { typeof(float?), "float" },

          { typeof(string), "string" },
        };

    /// <summary>
    /// Ensures parameter names compile successfully. This is for things like 'm_Class' which would map to a parameter
    /// name of 'class' normally.
    /// </summary>
    public static readonly Dictionary<string, string> ParamNameOverrides =
          new()
          {
            { "default", "defaultValue" },
            { "event", "eventValue" },
            { "break", "breakValue" },
            { "string", "stringValue" },
            { "class", "clazz" },
            { "override", "overrideValue" },
            { "continue", "continueValue" },
            { "double", "doubleValue" }
          };
  }
}
