using BlueprintCoreGen.CodeGen.Methods;
using static BlueprintCoreGen.CodeGen.Overrides.GlobalOverrides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BlueprintCoreGen.CodeGen.Params
{

  // TODO: For blueprint fields there should be some kind of list of methods where the field determines which are
  // relevant. This allows for things like the custom LevelEntry modifier requested by phoenix.

  public static class ParametersFactory
  {
    /// <summary>
    /// Returns an list of parameters used to construct an object of the specified type. The list is ordered such
    /// that optional parameters are at the end.
    /// </summary>
    /// 
    /// <remarks>
    /// By default, will create a parameter for every field in the object. Behavior can be modified using
    /// methodOverride.
    /// </remarks>
    public static List<IParameter> CreateForConstructor(Type objectType, MethodOverride? methodOverride)
    {
      return
        objectType.GetFields()
          .Where(fieldInfo => !ShouldIgnore(fieldInfo, objectType))
          .Select(fieldInfo => CreateFieldParameter(fieldInfo, objectType, methodOverride))
          .Where(fieldParam => !fieldParam.Ignore)
          .Select(fieldParam => fieldParam as IParameterInternal)
          .Concat(methodOverride?.GetExtraParams() ?? new List<IParameterInternal>())
          .OrderBy(param => !string.IsNullOrEmpty(param.Declaration) ? 0 : 1)
          .ThenBy(param => param.Required ? 0 : 1)
          .ThenBy(field => field.ParamName, StringComparer.CurrentCultureIgnoreCase)
          .Select(field => field as IParameter)
          .ToList();
    }

    /// <summary>
    /// Returns if the field should be ignored.
    /// </summary>
    private static bool ShouldIgnore(FieldInfo info, Type sourceType)
    {
      if (IgnoredFields.ContainsKey(sourceType) && IgnoredFields[sourceType].Contains(info.Name))
      {
        return true;
      }

      return info.Name.Contains("__BackingField") // Compiler generated field
                                                  // Skip constant, static, and read-only
          || info.IsLiteral
          || info.IsStatic
          || info.IsInitOnly;
    }

    private static FieldParameter CreateFieldParameter(
        FieldInfo info, Type sourceType, MethodOverride? methodOverride)
    {
      var blueprintType = TypeTool.GetBlueprintType(info.FieldType);
      var enumerableType = TypeTool.GetEnumerableType(info.FieldType);

      // These are annoying to pull out of the recursive GetImports function, so handle them separately.
      List<Type> imports = new();
      if (blueprintType is not null) { imports.Add(blueprintType); }
      if (enumerableType is not null) { imports.Add(enumerableType); }

      FieldParameter param =
          new(
              info.Name,
              GetParamName(info.Name),
              GetTypeName(info.FieldType, blueprintType, enumerableType),
              GetImports(info.FieldType).Concat(imports).ToList(),
              GetCommentFmt(blueprintType),
              GetDefaultValue(),
              GetValidationFmt(info.FieldType, blueprintType, enumerableType),
              GetAssignmentFmt(info.FieldType, blueprintType, enumerableType),
              GetAssignmentFmtIfNull(info.FieldType, blueprintType, enumerableType));

      // TODO: Convert to use config overrides.
      // Apply type specific overrides
      if (FieldParamOverrides.ByType.ContainsKey(info.FieldType))
      {
        param.ApplyOverride(FieldParamOverrides.ByType[info.FieldType]);
      }

      // Apply field specific overrides
      foreach (Type type in FieldParamOverrides.ByName.Keys)
      {
        // Just checking the source type misses inherited fields so loop through all keys
        if ((sourceType == type || sourceType.IsSubclassOf(type))
            && FieldParamOverrides.ByName[type].ContainsKey(info.Name))
        {
          param.ApplyOverride(FieldParamOverrides.ByName[type][info.Name]);
        }
      }

      methodOverride?.ApplyTo(info, param);

      return param;
    }

    /// <summary>
    /// Returns a parameter name derived from the field name.
    /// </summary>
    private static string GetParamName(string fieldName)
    {
      StringBuilder paramName = new(fieldName);
      if (paramName[0] == 'm' && paramName[1] == '_')
      {
        paramName.Remove(0, 2);
      }
      paramName[0] = char.ToLower(paramName[0]);

      var result = paramName.ToString();
      if (ParamNameOverrides.ContainsKey(result)) { return ParamNameOverrides[result]; }
      return result;
    }

    private static string GetTypeName(Type type, Type? blueprintType, Type? enumerableType)
    {
      if (blueprintType is not null)
      {
        if (enumerableType is not null)
        {
          return $"List<Blueprint<{TypeTool.GetName(blueprintType)}, {TypeTool.GetName(enumerableType)}>>";
        }
        return $"Blueprint<{TypeTool.GetName(blueprintType)}, {TypeTool.GetName(type)}>";
      }

      return TypeTool.GetName(type);
    }

    private static List<Type> GetImports(Type type)
    {
      List<Type> imports = new() { type, typeof(Enumerable), typeof(List<>) };
      if (!type.IsGenericType)
      {
        return imports.ToList();
      }
      type.GetGenericArguments().ToList().ForEach(t => imports.AddRange(GetImports(t)));
      return imports;
    }

    private static List<string> GetCommentFmt(Type? blueprintType)
    {
      if (blueprintType is not null)
      {
        return GetBlueprintCommentFmt(blueprintType);
      }
      return new();
    }

    // Also used by MethodOverrides
    public static List<string> GetBlueprintCommentFmt(Type blueprintType)
    {
      return
        new()
        {
          $"Blueprint of type {TypeTool.GetName(blueprintType)}. You can pass in the blueprint using:",
          $"<list type =\"bullet\">",
          $"  <item><term>A blueprint instance</term></item>",
          $"  <item><term>A blueprint reference</term></item>",
          $"  <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>",
          $"  <item><term>A blueprint name registered with <see cref=\"BlueprintCore.Utils.BlueprintTool\">BlueprintTool</see></term></item>",
          $"</list>",
          $"See <see cref=\"BlueprintCore.Utils.Blueprint{{{{T, TRef}}}}\">Blueprint</see> for more details.",
        };
    }

    public static string GetDefaultValue()
    {
      return "null";
    }

    private static List<string> GetValidationFmt(Type type, Type? blueprintType, Type? enumerableType)
    {
      if (ShouldSkipValidation(type, blueprintType)
          || (enumerableType is not null && ShouldSkipValidation(enumerableType, blueprintType)))
      {
        return new();
      }

      if (enumerableType is not null)
      {
        return new() { "foreach (var item in {1}) {{ {0}(item); }}" };
      }

      return new() { "{0}({1});" };
    }

    private static bool ShouldSkipValidation(Type type, Type? blueprintType)
    {
      // Primitives & structs
      if (type.IsPrimitive || type.IsEnum || type.IsValueType)
      {
        return true;
      }
      if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
      {
        return true;
      }

      if (type == typeof(string))
      {
        return true;
      }

      if (blueprintType is not null)
      {
        return true;
      }

      return false;
    }

    private static string GetAssignmentFmt(Type type, Type? blueprintType, Type? enumerableType)
    {
      if (blueprintType is not null)
      {
        if (enumerableType is not null)
        {
          if (type.IsArray)
          {
            return "{0}.Select(bp => bp.Reference).ToArray()";
          }

          return "{0}.Select(bp => bp.Reference).ToList()";
        }

        return "{0}.Reference";
      }

      return "{0}";
    }

    private static string GetAssignmentFmtIfNull(Type type, Type? blueprintType, Type? enumerableType)
    {
      if (enumerableType is not null)
      {
        if (type.IsArray)
        {
          return $"new {TypeTool.GetName(enumerableType)}[0]";
        }
        return "new()";
      }

      if (blueprintType is not null)
      {
        return $"BlueprintTool.GetRef<{TypeTool.GetName(type)}>(null)";
      }

      return "";
    }
  }
}
