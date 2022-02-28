using BlueprintCoreGen.CodeGen.Override;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BlueprintCoreGen.CodeGen
{
  /// <summary>
  /// Represents a method input parameter in a constructor method. i.e. Parameters in builder methods and configurator
  /// component methods.
  /// </summary>
  public interface IParameter
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
    /// Returns a statement which uses the parameter to operate on the object. Typically this is assigning the 
    /// parameter value to a field in the object. The provided validation function is called on the parameter before
    /// assignment.
    /// </summary>
    List<string> GetOperation(string objectName, string validateFunction);
  }

  /// <summary>
  /// Internal representation of a parameter used in the factory.
  /// </summary>
  internal interface IParameterInternal : IParameter
  {
    /// <summary>
    /// If true the parameter should not be declared. This is typically used for constant inputs to a method.
    /// </summary>
    bool SkipDeclaration { get; }

    /// <summary>
    /// If true the parameter is required and should be included in method parameter lists before optional parameters.
    /// </summary>
    bool Required { get; }

    /// <summary>
    /// Name of the parameter
    /// </summary>
    string ParamName { get; }
  }

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
    /// By default, will create a parameter for every field in the object. Overrides can be specified by type,  type
    /// and field name, or by using the overridesByName param. Overrides are applied in that order, so type is the
    /// lowest priority followed by type and field name followed by overridesByName.
    /// </remarks>
    /// 
    /// <param name="overridesByName">
    /// Overrides the fields matching the provided names. Highest priority override, applied after type specific and
    /// type + name specific.
    /// </param>
    /// <param name="extraParameters">
    /// Adds extra parameters that do not map directly to a field.
    /// </param>
    public static List<IParameter> CreateForConstructor(
      Type objectType, Dictionary<string, FieldParamOverride>? overridesByName, List<ExtraParameter>? extraParameters)
    {
      return
        objectType.GetFields()
          .Where(fieldInfo => !ShouldIgnore(fieldInfo))
          .Select(fieldInfo => CreateFieldParameter(fieldInfo, objectType, overridesByName))
          .Where(fieldParam => !fieldParam.Ignore)
          .Select(fieldParam => fieldParam as IParameterInternal)
          .Concat(
            extraParameters?.Select(extraParam => extraParam as IParameterInternal) ?? new List<IParameterInternal>())
          .OrderBy(param => !param.SkipDeclaration ? 0 : 1)
          .ThenBy(param => param.Required ? 0 : 1)
          .ThenBy(field => field.ParamName, StringComparer.CurrentCultureIgnoreCase)
          .Select(field => field as IParameter)
          .ToList();
    }

    private static bool ShouldIgnore(FieldInfo info)
    {
      return info.Name.Contains("__BackingField") // Compiler generated field
                                                  // Skip constant, static, and read-only
          || info.IsLiteral
          || info.IsStatic
          || info.IsInitOnly;
    }

    private static FieldParameter CreateFieldParameter(
        FieldInfo info, Type sourceType, Dictionary<string, FieldParamOverride>? overridesByName)
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

      // Apply the provided overrides last
      if (overridesByName is not null && overridesByName.ContainsKey(info.Name))
      {
        param.ApplyOverride(overridesByName[info.Name]);
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
      if (NameOverrides.ContainsKey(result)) { return NameOverrides[result]; }
      return result;
    }

    /// <summary>
    /// These ensure GetParamName returns a name that will compile successfully. This is for things like 'm_Class' which
    /// would map to a parameter name of 'class' normally.
    /// </summary>
    private static readonly Dictionary<string, string> NameOverrides =
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
        return GetBlueprintCommentFmt(blueprintType).Prepend("<param name=\"{0}\">").Append("</param>").ToList();
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
          $"See <see cref=\"BlueprintCore.Utils.Blueprint\">Blueprint</see> for more details.",
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

    private class FieldParameter : IParameterInternal
    {
      /// <summary>
      /// If true the parameter should be left out
      /// </summary>
      public bool Ignore = false;

      /// <summary>
      /// If true the declaration should be left out
      /// </summary>
      public bool SkipDeclaration { get; private set; }

      /// <summary>
      /// If true appends `?` to the type name
      /// </summary>
      private bool IsNullable = true;

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

      public bool Required => string.IsNullOrEmpty(DefaultValue);

      /// <summary>
      /// Validation format string where {0} is the validation function and {1} is the parameter name
      /// </summary>
      private List<string> ValidationFmt { get; set; }

      /// <summary>
      /// Assignment format string for the right hand side of an assignment statement, where {0} is the parameter name
      /// </summary>
      private string AssignmentFmtRhs { get; set; }

      /// <summary>
      /// Assignment string for the right hand side of an assignment statement if the field is null
      /// </summary>
      private string? AssignmentIfNullRhs { get; set; }

      /// <summary>
      /// Assignment format strings for additional lines of code after the assignment statement, where {0} is the
      /// object name and {1} is the parameter name
      /// </summary>
      private List<string> ExtraAssignmentFmtLines { get; set; }

      public FieldParameter(
          string fieldName,
          string paramName,
          string typeName,
          List<Type> imports,
          List<string> commentFmt,
          string defaultValue,
          List<string> validationFmt,
          string assignmentRhsFmt,
          string assignmentIfNullRhs)
      {
        SkipDeclaration = false;

        FieldName = fieldName;
        ParamName = paramName;
        TypeName = typeName;

        Imports = imports;
        CommentFmt = commentFmt;
        DefaultValue = defaultValue;

        ValidationFmt = validationFmt;
        AssignmentFmtRhs = assignmentRhsFmt;
        AssignmentIfNullRhs = assignmentIfNullRhs;
        ExtraAssignmentFmtLines = new();
      }

      public void ApplyOverride(FieldParamOverride fieldParamOverride)
      {
        Ignore = fieldParamOverride.Ignore;
        SkipDeclaration = fieldParamOverride.SkipDeclaration;
        IsNullable = fieldParamOverride.IsNullable ?? IsNullable;

        Imports.AddRange(fieldParamOverride.Imports);
        ParamName = fieldParamOverride.ParamName ?? ParamName;
        TypeName = fieldParamOverride.TypeName ?? TypeName;
        CommentFmt = fieldParamOverride.CommentFmt ?? CommentFmt;
        DefaultValue = fieldParamOverride.DefaultValue ?? DefaultValue;

        ValidationFmt = fieldParamOverride.ValidationFmt ?? ValidationFmt;
        AssignmentFmtRhs = fieldParamOverride.AssignmentRhsFmt ?? AssignmentFmtRhs;
        AssignmentIfNullRhs = fieldParamOverride.AssignmentIfNullRhs ?? AssignmentIfNullRhs;
        ExtraAssignmentFmtLines = fieldParamOverride.ExtraAssignmentFmtLines ?? ExtraAssignmentFmtLines;
      }

      private List<string> GetComment()
      {
        return CommentFmt.Select(line => string.Format(line, ParamName)).ToList();
      }

      private string GetDeclaration()
      {
        if (SkipDeclaration) { return ""; }

        var declaration = IsNullable ? $"{TypeName}? {ParamName}" : $"{TypeName} {ParamName}";
        return string.IsNullOrEmpty(DefaultValue)
            ? declaration
            : $"{declaration} = {DefaultValue}";
      }

      public List<string> GetOperation(string objectName, string validateFunction)
      {
        List<string> assignment = new();
        assignment.AddRange(ValidationFmt.Select(line => string.Format(line, validateFunction, ParamName)));

        if (IsNullable)
        {
          assignment.Add(
              string.Format($"{objectName}.{FieldName} = {AssignmentFmtRhs} ?? {objectName}.{FieldName};", ParamName));
        }
        else
        {
          assignment.Add(string.Format($"{objectName}.{FieldName} = {AssignmentFmtRhs};", ParamName));
        }

        return assignment.Concat(GetExtraAssignmentLines(objectName)).Concat(GetAssignmentIfNull(objectName)).ToList();
      }

      private List<string> GetExtraAssignmentLines(string objectName)
      {
        if (!ExtraAssignmentFmtLines.Any())
        {
          return new();
        }

        return ExtraAssignmentFmtLines.Select(line => string.Format($"{line}", objectName, ParamName)).ToList();
      }

      private List<string> GetAssignmentIfNull(string objectName)
      {
        if (string.IsNullOrEmpty(AssignmentIfNullRhs))
        {
          return new();
        }

        List<string> assignmentIfNull = new();
        assignmentIfNull.Add($"if ({objectName}.{FieldName} is null)");
        assignmentIfNull.Add($"{{");
        assignmentIfNull.Add($"  {objectName}.{FieldName} = {AssignmentIfNullRhs};");
        assignmentIfNull.Add($"}}");
        return assignmentIfNull;
      }
    }
  }
}
