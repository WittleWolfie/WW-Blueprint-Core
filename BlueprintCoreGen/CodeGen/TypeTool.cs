using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCoreGen.CodeGen
{
  /// <summary>
  /// Utils for type operations.
  /// </summary>
  public class TypeTool
  {
    private static readonly Dictionary<Type, string> TypeNameOverrides =
          new()
          {
            { typeof(Kingmaker.UnitLogic.Mechanics.ValueType), "Kingmaker.UnitLogic.Mechanics.ValueType" },
            { typeof(Kingmaker.UnitLogic.Abilities.Components.TargetType), "Kingmaker.UnitLogic.Abilities.Components.TargetType" },
            { typeof(Kingmaker.AI.Blueprints.TargetType), "Kingmaker.AI.Blueprints.TargetType" },
            { typeof(bool), "bool" },
            { typeof(bool?), "bool?" },
            { typeof(byte), "byte" },
            { typeof(byte), "byte?" },
            { typeof(sbyte), "sbyte" },
            { typeof(sbyte?), "sbyte?" },
            { typeof(ushort), "ushort" },
            { typeof(ushort?), "ushort?" },
            { typeof(int), "int" },
            { typeof(int?), "int?" },
            { typeof(uint), "uint" },
            { typeof(uint?), "uint?" },
            { typeof(long), "long" },
            { typeof(long?), "long?" },
            { typeof(ulong), "ulong" },
            { typeof(ulong?), "ulong?" },
            { typeof(char), "char" },
            { typeof(char?), "char?" },
            { typeof(double), "double" },
            { typeof(double?), "double?" },
            { typeof(float), "float" },
            { typeof(float?), "float?" },
            { typeof(string), "string" },
          };

    /// <summary>
    /// Recursive function which generates the correct type name for generic types.
    /// </summary>
    public static string GetName(Type type)
    {
      if (TypeNameOverrides.ContainsKey(type))
      {
        return TypeNameOverrides[type];
      }

      if (type.HasElementType && type.BaseType == typeof(Array))
      {
        return $"{GetName(type.GetElementType())}[]";
      }

      if (!type.IsGenericType)
      {
        var name = GetSimpleTypeName(type);
        return type.DeclaringType is null ? name : $"{GetSimpleTypeName(type.DeclaringType)}.{name}";
      }

      string typeName = GetSimpleTypeName(type.GetGenericTypeDefinition());
      typeName = typeName.Substring(0, typeName.IndexOf('`'));
      string typeArguments =
          string.Join(",", type.GetGenericArguments().Select(typeArg => GetName(typeArg)).ToArray());
      return typeName + "<" + typeArguments + ">";
    }

    private static string GetSimpleTypeName(Type type)
    {
      if (string.IsNullOrEmpty(type.Namespace))
      {
        return $"global::{type.Name}";
      }
      return type.Name;
    }
  }
}
