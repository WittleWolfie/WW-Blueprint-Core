using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCoreGen.CodeGen
{
  // TODO: Refactor and cleanup code generation
  // TODO: Explore handling complex nested types / types that implement IEnumerable like the Kingdom TagList and Dictionary
  // TODO: Unify name scheme across templates & auto-generated code (including fixing AddAdd in code-gen)
  public static class CodeGenerator
  {

    




    private static readonly Dictionary<Type, string> TypeNameOverrides =
        new()
        {
          { typeof(Kingmaker.UnitLogic.Mechanics.ValueType), "Kingmaker.UnitLogic.Mechanics.ValueType" },
          { typeof(Kingmaker.UnitLogic.Abilities.Components.TargetType), "Kingmaker.UnitLogic.Abilities.Components.TargetType" },
          { typeof(Kingmaker.AI.Blueprints.TargetType), "Kingmaker.AI.Blueprints.TargetType" },
        };
    
    /// <summary>
    /// Recursive function which generates the correct type name for generic types.
    /// </summary>
    public static string GetTypeName(Type type)
    {
      if (TypeNameOverrides.ContainsKey(type)) { return TypeNameOverrides[type]; }
      if (type.HasElementType && type.BaseType == typeof(Array))
      {
        return $"{GetTypeName(type.GetElementType())}[]";
      }
      if (!type.IsGenericType)
      {
        var name = GetConvertedTypeName(type);
        return type.DeclaringType is null ? name : $"{GetSimpleTypeName(type.DeclaringType)}.{name}";
      }
      string typeName = GetSimpleTypeName(type.GetGenericTypeDefinition());
      typeName = typeName.Substring(0, typeName.IndexOf('`'));
      string typeArguments =
          string.Join(",", type.GetGenericArguments().Select(typeArg => GetTypeName(typeArg)).ToArray());
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

    private static readonly Dictionary<string, string> ClassToPrimitive =
        new()
        {
          { "Boolean", "bool" },
          { "Byte", "byte" },
          { "SByte", "sbyte" },
          { "Int16", "short" },
          { "UInt16", "ushort" },
          { "Int32", "int" },
          { "UInt32", "uint" },
          { "Int64", "long" },
          { "UInt64", "ulong" },
          { "Char", "char" },
          { "Double", "double" },
          { "Single", "float" },
          { "String", "string" }
        };

    private static string GetConvertedTypeName(Type type)
    {
      if (ClassToPrimitive.ContainsKey(type.Name))
      {
        return ClassToPrimitive[type.Name];
      }
      return GetSimpleTypeName(type);
    }


  }
}
