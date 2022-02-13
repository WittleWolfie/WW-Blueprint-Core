using BlueprintCore.Blueprints.Configurators;
using BlueprintCoreGen.CodeGen.Override;
using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BlueprintCoreGen.CodeGen
{
  /// <summary>
  /// Represents a field used as an input parameter in a constructor method. i.e. Field parameters in builder methods
  /// and configurator component methods.
  /// </summary>
  public interface IFieldParameter
  {
    /// <summary>
    /// List of types to import.
    /// </summary>
    List<Type> Imports { get; }

    /// <summary>
    /// Parameter comment
    /// </summary>
    List<string> Comment { get; }

    /// <summary>
    /// Parameter declaration, e.g. <c>string name</c>
    /// </summary>
    string Declaration { get; }

    /// <summary>
    /// Returns a statement which assigns the parameter to the given object's field. The provided validation function
    /// is called on the parameter before assignment.
    /// </summary>
    List<string> GetAssignment(string objectName, string validateFunction);
  }

  // TODO: For custom methods entirely they'll be overridden at the Method level. I think. Maybe this shouldn't be done
  // at all because it causes some of the problems I'm trying to avoid?

  // TODO: For blueprint fields there should be some kind of list of methods where the field determines which are
  // relevant. This allows for things like the custom LevelEntry modifier requested by phoenix.

  public static class FieldFactory
  {
    /// <summary>
    /// Returns an list of field parameters used to construct an object of the specified type. The list is ordered such
    /// that optional parameters are at the end.
    /// </summary>
    /// 
    /// <remarks></remarks>
    public static List<IFieldParameter> CreateFieldParameters(Type objectType)
    {
      return
          objectType.GetFields()
              .Where(fieldInfo => !ShouldIgnore(fieldInfo, objectType))
              .Select(fieldInfo => CreateFieldParameter(fieldInfo, objectType))
              .Where(field => !field.Ignore)
              .OrderBy(field => field.DefaultValue is null ? 0 : 1)
              .ThenBy(field => field.ParamName, StringComparer.CurrentCultureIgnoreCase)
              .Select(field => field as IFieldParameter)
              .ToList();
    }

    private static bool ShouldIgnore(FieldInfo info, Type sourceType)
    {
      foreach (var (type, fieldNames) in Overrides.IgnoredFieldNamesByType)
      {
        if (sourceType.IsSubclassOf(type) || sourceType == type)
        {
          if (fieldNames.Contains(info.Name)) { return true; }
        }
      }

      return info.Name.Contains("__BackingField") // Compiler generated field
                                                  // Skip constant, static, and read-only
          || info.IsLiteral
          || info.IsStatic
          || info.IsInitOnly;
    }

    private static FieldParameter CreateFieldParameter(FieldInfo info, Type sourceType)
    {
      var blueprintType = TypeTool.GetBlueprintType(info.FieldType);
      var enumerableType = TypeTool.GetEnumerableType(info.FieldType);

      FieldParameter param =
          new(
              info.Name,
              GetParamName(info.Name),
              GetTypeName(info.FieldType, blueprintType, enumerableType),
              GetImports(info.FieldType),
              GetCommentFmt(blueprintType),
              GetDefaultValue(),
              GetValidationFmt(info.FieldType, blueprintType, enumerableType),
              GetAssignmentFmt(info.FieldType, blueprintType, enumerableType),
              GetAssignmentFmtIfNull(info.FieldType, blueprintType, enumerableType));

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

      return param;
    }

    private static string GetParamName(string fieldName)
    {
      StringBuilder paramName = new(fieldName);
      if (paramName[0] == 'm' && paramName[1] == '_')
      {
        paramName.Remove(0, 2);
      }
      paramName[0] = char.ToLower(paramName[0]);

      var result = paramName.ToString();
      if (Overrides.FriendlyNameOverrides.ContainsKey(result)) { return Overrides.FriendlyNameOverrides[result]; }
      return result;
    }

    private static string GetTypeName(Type type, Type? blueprintType, Type? enumerableType)
    {
      if (blueprintType is not null)
      {
        if (enumerableType is not null)
        {
          return "List<Blueprint>";
        }
        return "Blueprint";
      }

      return TypeTool.GetName(type);
    }

    private static List<Type> GetImports(Type type)
    {
      List<Type> imports = new() { type, typeof(Enumerable) };
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
        return
            new()
            {
              $"<param name=\"{{0}}\">",
              $"Blueprint of type {blueprintType.Name}. You can pass in the blueprint using:",
              $"<list type =\"bullet\">",
              $"  <item><term>A blueprint instance</term></item>",
              $"  <item><term>A blueprint reference</term><item>",
              $"  <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>",
              $"  <item><term>A blueprint name registered with <see cref=\"BlueprintCore.Utils.BlueprintTool\">BlueprintTool</see></term></item>",
              $"</list>",
              $"See <see cref=\"BlueprintCore.Utils.Blueprint\">Blueprint</see> for more details.",
              $"</param>"
            };
      }
      return new();
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
        return new() { "foreach (var item in {1}) { {0}(item); }" };
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

    private static List<string> GetAssignmentFmt(Type type, Type? blueprintType, Type? enumerableType)
    {
      if (blueprintType is not null)
      {
        if (enumerableType is not null)
        {
          if (type.IsArray)
          {
            return new() { "{0}.{1} = {2}.Select(bp => bp.Reference).ToArray();" };
          }

          return new() { "{0}.{1} = {2}.Select(bp => bp.Reference).ToList();" };
        }

        return new() { "{0}.{1} = {2}.Reference;" };
      }

      return new() { "{0}.{1} = {2};" };
    }

    private static List<string> GetAssignmentFmtIfNull(Type type, Type? blueprintType, Type? enumerableType)
    {
      if (enumerableType is not null)
      {
        if (type.IsArray)
        {
          return new() { $"{{0}}.{{1}} = new {TypeTool.GetName(enumerableType)}[0];" };
        }
        return new() { "{0}.{1} = new();" };
      }

      if (blueprintType is not null)
      {
        return new() { $"{{0}}.{{1}} = BlueprintTool.GetRef<{TypeTool.GetName(type)}>(null);" };
      }

      return new();
    }

    private class FieldParameter : IFieldParameter
    {
      /// <summary>
      /// If true the parameter should be left out
      /// </summary>
      public bool Ignore = false;
      public List<Type> Imports { get; }
      public List<string> Comment => GetComment();
      public string Declaration => GetDeclaration();

      private string FieldName { get; }
      public string ParamName { get; private set; }
      private string TypeName { get; set; }

      /// <summary>
      /// Comment format string where {0} is the parameter name
      /// </summary>
      private List<string> CommentFmt { get; set; }

      /// <summary>
      /// Default value for optional parameters
      /// </summary>
      public string? DefaultValue { get; private set; }

      /// <summary>
      /// Validation format string where {0} is the validation function and {1} is the parameter name
      /// </summary>
      private List<string> ValidationFmt { get; set; }

      /// <summary>
      /// Assignment format string where {0} is the object name, {1} is the field name, and {2} is the parameter name
      /// </summary>
      private List<string> AssignmentFmt { get; set; }

      /// <summary>
      /// Assignment format string if the field is null where {0} is the object name, {1} is the field name, and {2} is
      /// the parameter name
      /// </summary>
      private List<string> AssignmentFmtIfNull { get; set; }

      public FieldParameter(
          string fieldName,
          string paramName,
          string typeName,
          List<Type> imports,
          List<string> commentFmt,
          string defaultValue,
          List<string> validationFmt,
          List<string> assignmentFmt,
          List<string> assignmentFmtIfNull)
      {
        FieldName = fieldName;
        ParamName = paramName;
        TypeName = typeName;
        Imports = imports;
        CommentFmt = commentFmt;
        DefaultValue = defaultValue;
        ValidationFmt = validationFmt;
        AssignmentFmt = assignmentFmt;
        AssignmentFmtIfNull = assignmentFmtIfNull;
      }

      public void ApplyOverride(FieldParamOverride fieldParamOverride)
      {
        Ignore = fieldParamOverride.Ignore;
        Imports.AddRange(fieldParamOverride.Imports);
        ParamName = fieldParamOverride.ParamName ?? ParamName;
        TypeName = fieldParamOverride.TypeName ?? TypeName;
        CommentFmt = fieldParamOverride.CommentFmt ?? CommentFmt;
        DefaultValue = fieldParamOverride.DefaultValue ?? DefaultValue;
        ValidationFmt = fieldParamOverride.ValidationFmt ?? ValidationFmt;
        AssignmentFmt = fieldParamOverride.AssignmentFmt ?? AssignmentFmt;
        AssignmentFmtIfNull = fieldParamOverride.AssignmentFmtIfNull ?? AssignmentFmtIfNull;
      }

      private List<string> GetComment()
      {
        return CommentFmt.Select(line => string.Format(line, ParamName)).ToList();
      }

      private string GetDeclaration()
      {
        return string.IsNullOrEmpty(DefaultValue)
            ? $"{TypeName} {ParamName}"
            : $"{TypeName}? {ParamName} = {DefaultValue}";
      }

      public List<string> GetAssignment(string objectName, string validateFunction)
      {
        List<string> assignment = new();
        if (string.IsNullOrEmpty(DefaultValue))
        {
          // Required
          assignment.AddRange(ValidationFmt.Select(line => string.Format(line, validateFunction, ParamName)));
          assignment.AddRange(AssignmentFmt.Select(line => string.Format(line, objectName, FieldName, ParamName)));
        }
        else
        {
          // Optional. Only assign if the parameter value is non-null.
          assignment.Add($"if ({ParamName} is not null)");
          assignment.Add($"{{");
          assignment.AddRange(ValidationFmt.Select(line => string.Format($"  {line}", validateFunction, ParamName)));
          assignment.AddRange(
              AssignmentFmt.Select(line => string.Format($"  {line}", objectName, FieldName, ParamName)));
          assignment.Add($"}}");
        }
        return assignment.Concat(GetAssignmentIfNull(objectName)).ToList();
      }

      private List<string> GetAssignmentIfNull(string objectName)
      {
        if (!AssignmentFmtIfNull.Any())
        {
          return new();
        }

        List<string> assignmentIfNull = new();
        assignmentIfNull.Add($"if ({objectName}.{FieldName} is null)");
        assignmentIfNull.Add($"{{");
        assignmentIfNull.AddRange(
            AssignmentFmtIfNull.Select(line => string.Format($"  {line}", objectName, FieldName)));
        assignmentIfNull.Add($"}}");
        return assignmentIfNull;
      }
    }
  }
}
