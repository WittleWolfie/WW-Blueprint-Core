using BlueprintCoreGen.CodeGen.Methods;
using static BlueprintCoreGen.CodeGen.Overrides.GlobalOverrides;
using static BlueprintCoreGen.CodeGen.Overrides.Ignored.Ignored;
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
    /// <summary>
    /// Returns a parameter which can be used to construct any field modification methods.
    /// </summary>
    public static IBlueprintParameter? CreateForBlueprintField(Type blueprintType, FieldInfo field)
    { 
      if (ShouldIgnoreField(field, blueprintType))
      {
        return null;
      }
      return CreateBlueprintFieldParameter(field, blueprintType);
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
          .Where(fieldInfo => !ShouldIgnoreField(fieldInfo, objectType))
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
          GetParamsTypeName(info.FieldType, blueprintType, enumerableType),
          GetImports(info.FieldType).Concat(imports).ToList(),
          GetCommentFmt(info, blueprintType),
          GetDefaultValue(),
          GetValidationFmt(info.FieldType, blueprintType, enumerableType),
          GetAssignmentFmt(info.FieldType, blueprintType, enumerableType),
          GetAssignmentFmtIfNull(info.FieldType, blueprintType, enumerableType),
          GetParamsAssignmentFmt(info.FieldType, blueprintType, enumerableType));

      // Apply type specific, then field specific, then method specific overrides (priority order).
      GetTypeOverride(info.FieldType)?.ApplyTo(param);
      GetFieldOverride(info.Name, sourceType)?.ApplyTo(param);
      methodOverride.ApplyTo(info, param);

      return param;
    }

    private static BlueprintFieldParameter CreateBlueprintFieldParameter(FieldInfo info, Type sourceType)
    {
      var blueprintType = TypeTool.GetBlueprintType(info.FieldType);
      var enumerableType = TypeTool.GetEnumerableType(info.FieldType);

      // These are annoying to pull out of the recursive GetImports function, so handle them separately.
      List<Type> imports = new();
      imports.Add(typeof(LinqExtensions));
      if (blueprintType is not null) { imports.Add(blueprintType); }
      if (enumerableType is not null) { imports.Add(enumerableType); }

      BlueprintFieldParameter param =
        new(
          info.Name,
          GetParamName(info.Name),
          GetTypeName(info.FieldType, blueprintType, enumerableType),
          GetParamsTypeName(info.FieldType, blueprintType, enumerableType),
          GetImports(info.FieldType).Concat(imports).ToList(),
          GetCommentFmt(info, blueprintType),
          GetDefaultValueForBlueprintField(info.FieldType),
          GetValidationFmt(info.FieldType, blueprintType, enumerableType),
          GetSetComment(info),
          GetAssignmentFmtForBlueprintField(info.FieldType, blueprintType, enumerableType),
          GetAddComment(info),
          GetAddOperationFmt(info, blueprintType, enumerableType),
          GetRemoveComment(info),
          GetRemoveOperationFmt(info, enumerableType),
          GetRemovePredicateComment(info),
          GetRemovePredicateFmt(info, enumerableType),
          GetClearComment(info),
          GetClearOperationFmt(info, enumerableType),
          GetModifyComment(info, enumerableType),
          GetModifyOperationFmt(info, enumerableType),
          GetAssignmentFmtIfNull(info.FieldType, blueprintType, enumerableType));

      GetTypeOverride(info.FieldType)?.ApplyTo(param);
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
    internal static string GetParamName(string fieldName)
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
          return $"List<Blueprint<{TypeTool.GetName(enumerableType)}>>";
        }
        return $"Blueprint<{TypeTool.GetName(type)}>";
      }

      return TypeTool.GetName(type);
    }

    private static string GetParamsTypeName(Type type, Type? blueprintType, Type? enumerableType)
    {
      if (blueprintType is not null)
      {
        if (enumerableType is not null)
        {
          return $"Blueprint<{TypeTool.GetName(enumerableType)}>";
        }
        return $"Blueprint<{TypeTool.GetName(type)}>";
      }

      if (enumerableType is not null)
      {
        return TypeTool.GetName(enumerableType);
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
        AddParagraphToComments(commentFmt, $"Tooltip: {GetSanitizedComment(tooltipAttr.tooltip)}");
      }

      var infoBox = info.GetCustomAttribute<InfoBoxAttribute>();
      if (infoBox is not null)
      {
        AddParagraphToComments(commentFmt, $"InfoBox: {GetSanitizedComment(infoBox.Text)}");
      }

      if (blueprintType is not null)
      {
        AddBlueprintParagraphToComments(commentFmt, blueprintType);
      }
      return commentFmt;
    }

    private static string GetSanitizedComment(string comment)
    {
      return comment
        .Replace("\n", " ")
        .Replace("\r", " ")
        .Replace("\"", "&quot;")
        .Replace("'", "&apos;")
        .Replace("<", "&lt;")
        .Replace(">", "&gt;")
        .Replace("&", "&amp;");
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
        $"  <item><term>A blueprint name registered with <see cref=\"BlueprintTool\">BlueprintTool</see></term></item>",
        $"</list>",
        $"See <see cref=\"Blueprint{{TRef}}\">Blueprint</see> for more details.");
    }

    public static string GetDefaultValue()
    {
      return "null";
    }

    public static string GetDefaultValueForBlueprintField(Type fieldType)
    {
      if (fieldType == typeof(bool))
      {
        return "true";
      }
      return "";
    }

    // TODO: Validation parenting is technically supported but doesn't work yet. Need to figure out how to handle the
    // case where an ActionsBuilder or ConditionsBuilder accepts a builder as an input. At that point there is no
    // Validator to point to so the child would need to ignore it. Somehow need to store child values? Maybe the
    // Validator can special case ActionsBuilder/ConditionsBuilder types?
    private static string GetValidationFmt(Type type, Type? blueprintType, Type? enumerableType)
    {
      if (ShouldSkipValidation(type, blueprintType)
          || (enumerableType is not null && ShouldSkipValidation(enumerableType, blueprintType)))
      {
        return "";
      }

      return "{0}({1});";
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

    private static string GetAssignmentFmtForBlueprintField(Type type, Type? blueprintType, Type? enumerableType)
    {
      var assignmentFmt = GetParamsAssignmentFmt(type, blueprintType, enumerableType);
      return string.IsNullOrEmpty(assignmentFmt)
        ? GetAssignmentFmt(type,blueprintType, enumerableType)
        : assignmentFmt;
    }

    private static string GetParamsAssignmentFmt(Type type, Type? blueprintType, Type? enumerableType)
    {
      // BitFlags, Lists, and Arrays support params setters
      if (TypeTool.IsBitFlag(type))
      {
        return $"{{0}}.Aggregate(({TypeTool.GetName(type)}) 0, (f1, f2) => f1 | f2)";
      }
      else if (enumerableType is not null)
      {
        if (blueprintType is not null)
        {
          var toEnumerable = type.IsArray ? ".ToArray()" : ".ToList()";
          return $"{{0}}.Select(bp => bp.Reference){toEnumerable}";
        }
        return type.IsArray ? $"{{0}}" : $"{{0}}.ToList()";
      }
      return string.Empty;
    }

    private static List<string> GetAddOperationFmt(FieldInfo field, Type? blueprintType, Type? enumerableType)
    {
      List<string> addOperationFmt = new();
      if (TypeTool.IsBitFlag(field.FieldType))
      {
        addOperationFmt.Add($"{{1}}.ForEach(f => {{0}}.{field.Name} |= f);");
      }
      else if (field.FieldType.IsArray)
      {
        var paramRef = blueprintType is null ? $"{{1}}" : $"{{1}}.Select(bp => bp.Reference).ToArray()";
        addOperationFmt.Add($"{{0}}.{field.Name} = {{0}}.{field.Name} ?? new {TypeTool.GetName(enumerableType!)}[0];");
        addOperationFmt.Add($"{{0}}.{field.Name} = CommonTool.Append({{0}}.{field.Name}, {paramRef});");
      }
      else if (enumerableType is not null)
      {
        var paramRef = blueprintType is null ? $"{{1}}" : $"{{1}}.Select(bp => bp.Reference)";
        addOperationFmt.Add($"{{0}}.{field.Name} = {{0}}.{field.Name} ?? new();");
        addOperationFmt.Add($"{{0}}.{field.Name}.AddRange({paramRef});");
      }
      return addOperationFmt;
    }

    private static List<string> GetRemoveOperationFmt(FieldInfo field, Type? enumerableType)
    {
      List<string> removeOperationFmt = new();
      if (TypeTool.IsBitFlag(field.FieldType))
      {
        removeOperationFmt.Add($"{{1}}.ForEach(f => {{0}}.{field.Name} &= ~f);");
      }
      else if (enumerableType is not null)
      {
        var toEnumerable = field.FieldType.IsArray ? "ToArray()" : "ToList()";
        removeOperationFmt.Add($"if ({{0}}.{field.Name} is null) {{{{ return; }}}}");
        removeOperationFmt.Add(
          $"{{0}}.{field.Name} = {{0}}.{field.Name}.Where(val => !{{1}}.Contains(val)).{toEnumerable};");
      }
      return removeOperationFmt;
    }

    private static List<string> GetRemovePredicateFmt(FieldInfo field, Type? enumerableType)
    {
      List<string> removeOperationFmt = new();
      if (enumerableType is not null)
      {
        var toEnumerable = field.FieldType.IsArray ? "ToArray()" : "ToList()";
        removeOperationFmt.Add($"if ({{0}}.{field.Name} is null) {{{{ return; }}}}");
        removeOperationFmt.Add($"{{0}}.{field.Name} = {{0}}.{field.Name}.Where({{1}}).{toEnumerable};");
      }
      return removeOperationFmt;
    }

    private static List<string> GetClearOperationFmt(FieldInfo field, Type? enumerableType)
    {
      List<string> clearOperationFmt = new();
      if (field.FieldType.IsArray)
      {
        clearOperationFmt.Add($"{{0}}.{field.Name} = new {TypeTool.GetName(enumerableType!)}[0];");
      }
      else if (enumerableType is not null)
      {
        clearOperationFmt.Add($"{{0}}.{field.Name} = new();");
      }
      return clearOperationFmt;
    }

    private static List<string> GetModifyOperationFmt(FieldInfo field, Type? enumerableType)
    {
      if (TypeTool.IsBitFlag(field.FieldType)
        || field.FieldType.IsPrimitive
        || field.FieldType.IsEnum)
      {
        return new(); 
      }

      List<string> modifyOperationFmt = new();
      if (!field.FieldType.IsValueType)
      {
        modifyOperationFmt.Add($"if ({{0}}.{field.Name} is null) {{{{ return; }}}}");
      }

      if (enumerableType is not null)
      {
        modifyOperationFmt.Add($"{{0}}.{field.Name}.ForEach({{1}});");
      }
      else
      {
        modifyOperationFmt.Add($"{{1}}.Invoke({{0}}.{field.Name});");
      }
      return modifyOperationFmt;
    }

    private static string GetSetComment(FieldInfo field)
    {
      return $"Sets the value of <see cref=\"{TypeTool.GetName(field.DeclaringType!)}.{field.Name}\"/>";
    }

    private static string GetAddComment(FieldInfo field)
    {
      return $"Adds to the contents of <see cref=\"{TypeTool.GetName(field.DeclaringType!)}.{field.Name}\"/>";
    }

    private static string GetRemoveComment(FieldInfo field)
    {
      return $"Removes elements from <see cref=\"{TypeTool.GetName(field.DeclaringType!)}.{field.Name}\"/>";
    }

    private static string GetRemovePredicateComment(FieldInfo field)
    {
      return $"Removes elements from <see cref=\"{TypeTool.GetName(field.DeclaringType!)}.{field.Name}\"/> that match the provided predicate.";
    }

    private static string GetClearComment(FieldInfo field)
    {
      return $"Removes all elements from <see cref=\"{TypeTool.GetName(field.DeclaringType!)}.{field.Name}\"/>";
    }

    private static string GetModifyComment(FieldInfo field, Type? enumerableType)
    {
      if (enumerableType is not null)
      {
        return $"Modifies <see cref=\"{TypeTool.GetName(field.DeclaringType!)}.{field.Name}\"/> by invoking the provided action on each element.";
      }
      return $"Modifies <see cref=\"{TypeTool.GetName(field.DeclaringType!)}.{field.Name}\"/> by invoking the provided action.";
    }
  }
}
