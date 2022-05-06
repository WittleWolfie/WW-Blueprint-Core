using BlueprintCoreGen.CodeGen.Methods;
using static BlueprintCoreGen.CodeGen.Overrides.GlobalOverrides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json.Linq;
using System.IO;
using UnityEngine;
using Kingmaker.Utility;

namespace BlueprintCoreGen.CodeGen.Params
{
  public static class ParametersFactory
  {
    public enum FieldOperation
    {
      Set,
      AddTo,
      RemoveFrom
    }
    public static List<IParameter> CreateForConfiguratorField(
      FieldInfo field, MethodOverride methodOverride, params IParameterInternal[] extraParams)
    {
      // TODO
      return null;
    }

    /// <summary>
    /// Returns a list of parameters used to construct an object of the specified type. The list is ordered such
    /// that optional parameters are at the end.
    /// </summary>
    /// 
    /// <remarks>
    /// By default, will create a parameter for every field in the object. Behavior can be modified using
    /// methodOverride.
    /// </remarks>
    public static List<IParameter> CreateForConstructor(
      Type objectType, MethodOverride methodOverride, params IParameterInternal[] extraParams)
    {
      return
        objectType.GetFields()
          .Where(fieldInfo => !ShouldIgnore(fieldInfo, objectType))
          .Select(fieldInfo => CreateFieldParameter(fieldInfo, objectType, methodOverride))
          .Where(fieldParam => !fieldParam.Ignore)
          .Select(fieldParam => fieldParam as IParameterInternal)
          .Concat(methodOverride.GetExtraParams() ?? new List<IParameterInternal>())
          .Concat(extraParams)
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
      var ignoredField = false;
      IgnoredFields.ForEach(
        ignoredFields =>
        {
          if ((sourceType == ignoredFields.type || sourceType.IsSubclassOf(ignoredFields.type)) && ignoredFields.names.Contains(info.Name))
          {
            ignoredField = true;
          }
        });

      return ignoredField
          || info.Name.Contains("__BackingField") // Compiler generated field
                                                  // Skip constant, static, and read-only
          || info.IsLiteral
          || info.IsStatic
          || info.IsInitOnly;
    }

    private static FieldParameter CreateFieldParameter(
        FieldInfo info, Type sourceType, MethodOverride methodOverride)
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
              GetCommentFmt(info, blueprintType),
              GetDefaultValue(),
              GetValidationFmt(info.FieldType, blueprintType, enumerableType),
              GetAssignmentFmt(info.FieldType, blueprintType, enumerableType),
              GetAssignmentFmtIfNull(info.FieldType, blueprintType, enumerableType));

      // Apply type specific, then field specific, then method specific overrides (priority order).
      GetTypeOverride(info.FieldType)?.ApplyTo(param);
      GetFieldOverride(info.Name, sourceType)?.ApplyTo(param);
      methodOverride.ApplyTo(info, param);

      return param;
    }

    private static Dictionary<Type, FieldTypeOverride>? OverridesByType;
    private static FieldTypeOverride? GetTypeOverride(Type fieldType)
    {
      if (OverridesByType is null)
      {
        OverridesByType = new();
        JArray array = JArray.Parse(File.ReadAllText("CodeGen/Overrides/FieldTypes.json"));
        array.ToObject<List<FieldTypeOverride>>().ForEach(
          fieldOverride =>
          {
            OverridesByType.Add(TypeTool.TypeByName(fieldOverride.TypeName), fieldOverride);
          });
      }
      return OverridesByType.ContainsKey(fieldType) ? OverridesByType[fieldType] : null;
    }

    private static List<(Type sourceType, FieldOverride fieldOverride)>? OverridesBySourceType;
    private static FieldOverride? GetFieldOverride(string fieldName, Type sourceType)
    {
      if (OverridesBySourceType is null)
      {
        OverridesBySourceType = new();
        JArray array = JArray.Parse(File.ReadAllText("CodeGen/Overrides/Fields.json"));
        array.ToObject<List<FieldOverride>>().ForEach(
          fieldOverride =>
            OverridesBySourceType.Add((TypeTool.TypeByName(fieldOverride.SourceTypeName), fieldOverride)));
      }

      // Just checking the source type misses inherited fields so loop through all keys.
      return OverridesBySourceType.Where(
        fieldOverride =>
          fieldName.Equals(fieldOverride.fieldOverride.FieldName)
            && (sourceType == fieldOverride.sourceType || sourceType.IsSubclassOf(fieldOverride.sourceType)))
        .Select(fieldOverride => fieldOverride.fieldOverride)
        .FirstOrDefault();
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

    private static List<string> GetCommentFmt(FieldInfo info, Type? blueprintType)
    {
      List<string> commentFmt = new();
      var tooltipAttr = info.GetCustomAttribute<TooltipAttribute>();
      if (tooltipAttr is not null)
      {
        AddParagraphToComments(commentFmt, $"Tooltip: {tooltipAttr.tooltip}");
      }

      var infoBox = info.GetCustomAttribute<InfoBoxAttribute>();
      if (infoBox is not null)
      {
        AddParagraphToComments(commentFmt, $"InfoBox: {infoBox.Text}");
      }

      if (blueprintType is not null)
      {
        AddBlueprintParagraphToComments(commentFmt, blueprintType);
      }
      return commentFmt;
    }

    private static void AddParagraphToComments(List<string> comments, params string[] paragraph)
    {
      comments.Add(@"<para>");
      paragraph.ForEach(line => comments.Add(line));
      comments.Add(@"</para>");
    }

    private static void AddBlueprintParagraphToComments(List<string> comments, Type blueprintType)
    {
      AddParagraphToComments(
        comments,
        $"Blueprint of type {TypeTool.GetName(blueprintType)}. You can pass in the blueprint using:",
        $"<list type =\"bullet\">",
        $"  <item><term>A blueprint instance</term></item>",
        $"  <item><term>A blueprint reference</term></item>",
        $"  <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>",
        $"  <item><term>A blueprint name registered with <see cref=\"BlueprintCore.Utils.BlueprintTool\">BlueprintTool</see></term></item>",
        $"</list>",
        $"See <see cref=\"BlueprintCore.Utils.Blueprint{{{{T, TRef}}}}\">Blueprint</see> for more details.");
    }

    public static string GetDefaultValue()
    {
      return "null";
    }

    // TODO: Validation parenting is technically supported but doesn't work yet. Need to figure out how to handle the
    // case where an ActionsBuilder or ConditionsBuilder accepts a builder as an input. At that point there is no
    // Validator to point to so the child would need to ignore it. Somehow need to store child values? Maybe the
    // Validator can special case ActionsBuilder/ConditionsBuilder types?
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
            return "{0}?.Select(bp => bp.Reference)?.ToArray()";
          }

          return "{0}?.Select(bp => bp.Reference)?.ToList()";
        }

        return "{0}?.Reference";
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
