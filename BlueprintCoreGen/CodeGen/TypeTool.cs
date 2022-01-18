using Kingmaker.Blueprints;
using Kingmaker.Utility;
using Microsoft.VisualBasic.FileIO;
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
      if (Overrides.TypeNameOverrides.ContainsKey(type))
      {
        return Overrides.TypeNameOverrides[type];
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
    /// Returns the type of Blueprint represented by the given BlueprintReferenceBase type
    /// </summary>
    public static Type GetBlueprintType(Type blueprintReferenceType)
    {
      var refType = blueprintReferenceType;
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
