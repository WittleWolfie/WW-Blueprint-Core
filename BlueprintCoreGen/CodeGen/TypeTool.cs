using static BlueprintCoreGen.CodeGen.Overrides.GlobalOverrides;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;

namespace BlueprintCoreGen.CodeGen
{
  /// <summary>
  /// Utils for type operations.
  /// </summary>
  public class TypeTool
  {
    private static readonly Dictionary<string, Type> TypesByName = new();

    public static void InitTypesByName(Type[] gameTypes, Type[] blueprintCoreTypes)
    {
      foreach (var type in gameTypes)
      {
        TypesByName.TryAdd(type.Name, type);
      }

      foreach (var type in blueprintCoreTypes)
      {
        TypesByName.TryAdd(type.Name, type);
      }
    }

    public static Type TypeByName(string type)
    {
      if (TypesByName.ContainsKey(type))
      {
        return TypesByName[type];
      }
      return AccessTools.TypeByName(type);
    }

    /// <summary>
    /// Recursive function which generates the correct type name for generic types.
    /// </summary>
    public static string GetName(Type type)
    {
      if (TypeNameOverrides.ContainsKey(type)) { return TypeNameOverrides[type]; }

      if (type.HasElementType && type.BaseType == typeof(Array))
      {
        return $"{GetName(type.GetElementType()!)}[]";
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

    /// <summary>
    /// Returns whether the given type is a bit flag enum.
    /// </summary>
    public static bool IsBitFlag(Type type)
    {
      return type.IsEnum && type.GetAttribute<FlagsAttribute>() is not null;
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
  }
}
