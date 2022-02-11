using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
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
    /// Returns a statement calling the provided validation function passing in itself or its entries (for enumerable
    /// types).
    /// </summary>
    List<string> GetValidation(string validateFunction);

    /// <summary>
    /// Returns a statement which assigns the parameter to the specified object's field.
    /// </summary>
    List<string> GetAssignment(string objectName);
  }

  // TODO: For custom methods entirely they'll be overridden at the Method level. I think. Maybe this shouldn't be done
  // at all because it causes some of the problems I'm trying to avoid?

  // TODO: For blueprint fields there should be some kind of list of methods where the field determines which are
  // relevant. This allows for things like the custom LevelEntry modifier requested by phoenix.

  public static class NewFieldFactory
  {
    /// <summary>
    /// Returns an list of field parameters used to construct an object of the specified type. The list is ordered such
    /// that optional parameters are at the end.
    /// </summary>
    /// 
    /// <remarks></remarks>
    public static List<IFieldParameter> CreateFieldParameter(Type objectType)
    {
      return
          objectType.GetFields()
              .Where(fieldInfo => !ShouldIgnore(fieldInfo, objectType))
              .Select(fieldInfo => CreateFieldParameter(fieldInfo, objectType))
              .Append(InitParam)
              .ToList();
    }

    private static readonly IFieldParameter InitParam =
        new FieldParameter();

    /// <summary>
    /// Common parameters applicable to all BlueprintComponent constructors.
    /// </summary>
    public static readonly List<IFieldParameter> UniqueComponentParams =
        new()
        {
          new FieldParameter(
            new() { typeof(BlueprintConfigurator<>) },
            new(),
            "ComponentMerge mergeBehavior = ComponentMerge.Replace",
            new(),
            new()),
          new FieldParameter(
            new() { typeof(Action), typeof(BlueprintComponent) },
            new(),
            "Action<BlueprintComponent, BlueprintComponent>? mergeAction = null",
            new(),
            new())
        };

    private static IFieldParameter CreateFieldParameter(FieldInfo info, Type sourceType)
    {
      FieldParameter param =
          new(
              GetImports(info.FieldType),
              GetComment(),
              GetDeclaration(info),
              GetValidationFmt(info.FieldType),
              GetAssignmentFmt());

      
      


      var field =
          info.FieldType.IsSubclassOf(typeof(BlueprintReferenceBase))
              ? new BlueprintField(
                  info.Name,
                  GetParamName(info.Name),
                  info.FieldType)
              : new SimpleField(
                  info.Name,
                  TypeTool.GetName(info.FieldType),
                  GetParamName(info.Name),
                  ShouldSkipValidation(info.FieldType),
                  info.FieldType);

      // Additional imports for generic types
      if (info.FieldType.IsGenericType)
      {
        field.Imports.AddRange(info.FieldType.GetGenericArguments());
      }

      // Set the default value, if applicable
      if (field.DefaultValue is null)
      {
        field.DefaultValue = GetDefaultValue(info.FieldType);
      }

      // Apply type specific overrides
      if (FieldOverrides.ByType.ContainsKey(info.FieldType))
      {
        field.ApplyFieldOverride(FieldOverrides.ByType[info.FieldType]);
      }

      // Apply field specific overrides
      foreach (Type type in FieldOverrides.ByName.Keys)
      {
        // Just checking the source type misses inherited fields so loop through all keys
        if ((sourceType == type || sourceType.IsSubclassOf(type))
            && FieldOverrides.ByName[type].ContainsKey(info.Name))
        {
          field.ApplyFieldOverride(FieldOverrides.ByName[type][info.Name]);
        }
      }

      return field;
    }

    private static List<Type> GetImports(Type type)
    {
      List<Type> imports = new() { type };
      if (!type.IsGenericType)
      {
        return imports.ToList();
      }
      type.GetGenericArguments().ToList().ForEach(t => imports.AddRange(GetImports(t)));
      return imports;
    }

    private static List<string> GetCommentFmt(FieldInfo info)
    {
      var blueprintType = TypeTool.GetBlueprintType(info.FieldType);
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

    private static List<string> GetValidationFmt(Type type)
    {
      if (ShouldSkipValidation(type))
      {
        return new();
      }
      return new() { "{0}({1});" };
    }

    private static List<string> GetAssignmentFmt()
    {
      return new() { "{0}.{1} = {2};" };
    }

    private static List<string> GetAssignmentFmtIfNull()
    {
      // TODO: Add default value handling for lists.
      // Note: Type specific overrides, i.e. values in Constants.Empty, can be handled through override config. Lists
      // and arrays need handling here because overrides don't support type subclassing.
      return new();
    }

    /// <summary>
    /// Determines if a type is nullable. Note that object types are not considered nullable, this specifically is
    /// identifying types that are not nullable by default, e.g. bool?.
    /// </summary>
    private static bool IsNullable(Type type)
    {
      return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
    }

    private static bool ShouldSkipValidation(Type type)
    {
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
      return false;
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

    private class FieldParameter : IFieldParameter
    {
      public List<Type> Imports { get; }
      public List<string> Comment => GetComment();
      public string Declaration => GetDeclaration();

      private string FieldName { get; }
      private string ParamName { get; set; }
      private string TypeName { get; set; }

      /// <summary>
      /// Comment format string where {0} is the parameter name
      /// </summary>
      private List<string> CommentFmt { get; set; }

      /// <summary>
      /// Default value for optional parameters
      /// </summary>
      private string? DefaultValue { get; set; }

      /// <summary>
      /// Validation format string where {0} is the validation function and {1} is the parameter name
      /// </summary>
      private List<string> ValidationFmt { get; set; }

      /// <summary>
      /// Assignment format string where {0} is the object name, {1} is the field name, and {2} is the parameter name
      /// </summary>
      private List<string> AssignmentFmt { get; }

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
          List<string> validationFmt,
          List<string> assignmentFmt,
          List<string> assignmentFmtIfNull)
      {
        FieldName = fieldName;
        ParamName = paramName;
        TypeName = typeName;
        Imports = imports;
        CommentFmt = commentFmt;
        ValidationFmt = validationFmt;
        AssignmentFmt = assignmentFmt;
        AssignmentFmtIfNull = assignmentFmtIfNull;
      }

      private List<string> GetComment()
      {
        return CommentFmt.Select(line => string.Format(line, ParamName)).ToList();
      }

      private string GetDeclaration()
      {
        return string.IsNullOrEmpty(DefaultValue)
            ? $"{TypeName} {ParamName}"
            : $"{TypeName} {ParamName} = {DefaultValue}";
      }

      public List<string> GetValidation(string validateFunction)
      {
        return ValidationFmt.Select(line => string.Format(line, validateFunction, ParamName)).ToList();
      }

      public List<string> GetAssignment(string objectName)
      {
        List<string> assignment = new();
        if (string.IsNullOrEmpty(DefaultValue))
        {
          // Required
          assignment.AddRange(AssignmentFmt.Select(line => string.Format(line, objectName, FieldName, ParamName)));
        }
        else
        {
          // Optional. Only assign if the parameter value is non-null.
          assignment.Add($"if ({ParamName} is not null)");
          assignment.Add($"{{");
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

    private class BlueprintField : SimpleField
    {
      public BlueprintField(string fieldName, string paramName, Type type)
          : base(fieldName, "string?", paramName, true, type, typeof(BlueprintTool))
      {
        var blueprintType = TypeTool.GetBlueprintType(type);

        Comment =
            $"<param name=\"{ParamName}\"><see cref=\"{blueprintType.Namespace}.{TypeTool.GetName(blueprintType)}\"/></param>";
        DefaultValue = "null";

        AssignmentFmt = new() { "{0}.{1} = BlueprintTool.GetRef<" + TypeTool.GetName(type) + ">({2});" };
        ValidationFmt = new();
      }
    }

    private class EnumerableField : SimpleField, IEnumerableField
    {
      public string EnumerableTypeName { get; set; }

      public EnumerableField(
          string fieldName,
          string typeName,
          string enumerableTypeName,
          string paramName,
          bool shouldSkipValidation,
          params Type[] imports)
          : base(fieldName, typeName, paramName, shouldSkipValidation, imports)
      {
        EnumerableTypeName = enumerableTypeName;

        if (!shouldSkipValidation)
        {
          ValidationFmt =
              new()
              {
                "if ({1} is not null)",
                "{",
                "  foreach (var item in {1}) { {0}(item); }",
                "}"
              };
        }
      }
    }

    private class EnumerableBlueprintField : BlueprintField, IEnumerableField
    {
      public string EnumerableTypeName { get; set; }

      public EnumerableBlueprintField(
          string fieldName,
          string paramName,
          bool isArray,
          Type refType,
          params Type[] imports)
          : base(fieldName, "string[]?", "string", paramName, true, imports)
      {
        var blueprintType = TypeTool.GetBlueprintType(refType);

        if (isArray)
        {
          AssignmentFmt =
              new()
              {
                "{0}.{1} = {2}.Select(bp => BlueprintTool.GetRef<" + TypeTool.GetName(refType) + ">(bp)).ToArray();"
              };
        }

        Imports.Add(typeof(BlueprintTool));
      }
    }
  }
}
