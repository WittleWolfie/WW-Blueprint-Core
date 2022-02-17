using Kingmaker.Blueprints;
using Kingmaker.Utility;
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

    /// <summary>
    /// Recursive function which generates the correct type name for generic types.
    /// </summary>
    public static string GetName(Type type)
    {
      if (TypeNameOverrides.ContainsKey(type)) { return TypeNameOverrides[type]; }

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

    /// <summary>
    /// Returns the complete using statement to import the given type or null if the type is defined in the global
    /// namespace.
    /// </summary>
    public static string? GetImport(Type type)
    {
      // Skip type defined in the global namespace
      if (!string.IsNullOrEmpty(type.Namespace))
      {
        return $"using {type.Namespace};";
      }
      return null;
    }

    /// <summary>
    /// Returns the type of blueprint represented, or null if it does not represent a blueprint type.
    /// </summary>
    public static Type? GetBlueprintType(Type type)
    {
      var refType = GetEnumerableType(type) ?? type;
      if (!refType.IsSubclassOf(typeof(BlueprintReferenceBase))) { return null; }

      while (!(refType!.IsGenericType && refType.GetGenericTypeDefinition() == typeof(BlueprintReference<>)))
      {
        refType = refType.BaseType;
      }
      return refType.GenericTypeArguments[0];
    }

    /// <summary>
    /// Returns the type of enumerable represented, or null if it is not enumerable or an unsupported enumerable type.
    /// </summary>
    public static Type? GetEnumerableType(Type type)
    {
      if (type == typeof(string)
          // For now just skip dictionaries
          || type.GetInterfaces()
              .Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IDictionary<,>))
              .Any()
          // Maybe this type can be added later
          || type.IsSubclassOf(typeof(TagListBase)))
      {
        return null;
      }

      return type.GetInterfaces()
          .FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
          ?.GetGenericArguments()[0];
    }

    // TODO: Delete? Seems like this isn't needed.
    private static string GetSimpleTypeName(Type type)
    {
      //if (string.IsNullOrEmpty(type.Namespace))
      //{
      //  return $"global::{type.Name}";
      //}
      return type.Name;
    }

    /// <summary>
    /// Type name overrides. Applies globally.
    /// </summary>
    private static Dictionary<Type, string> TypeNameOverrides =
        new()
        {
          // Name conflicts
          { typeof(Kingmaker.AI.Blueprints.TargetType), "Kingmaker.AI.Blueprints.TargetType" },
          { typeof(Kingmaker.UnitLogic.Abilities.Components.TargetType), "Kingmaker.UnitLogic.Abilities.Components.TargetType" },
          { typeof(Kingmaker.UnitLogic.Mechanics.ValueType), "Kingmaker.UnitLogic.Mechanics.ValueType" },

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
  }
}
