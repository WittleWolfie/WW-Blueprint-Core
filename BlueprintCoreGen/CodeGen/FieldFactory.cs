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
              .ToList();
    }

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

    private static List<string> GetComment()
    {
      return new();
    }

    private static string GetDeclaration(FieldInfo info)
    {
      return $"{TypeTool.GetName(info.FieldType)} {GetParamName(info.Name)}";
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

    private static string? GetDefaultValue(Type type)
    {
      // TODO: Pull the default hardcoded value by instantiating an object

      if (type.IsPrimitive || type.IsEnum) { return "default"; }
      if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>)) { return "null"; }
      return null;
    }

    private static bool ShouldSkipValidation(Type type)
    {
      if (type.IsPrimitive)
      {
        return true;
      }
      if (type == typeof(string))
      {
        return true;
      }
      if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
      {
        return true;
      }
      if (type.IsValueType)
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
      public List<string> Comment { get; }
      public string Declaration { get; }

      /// <summary>
      /// Validation format string where {0} is validateFunction
      /// </summary>
      private List<string> ValidationFmt { get; set; }

      /// <summary>
      /// Assignment format string where {0} is objectName
      /// </summary>
      private List<string> AssignmentFmt { get; }

      public FieldParameter(
          List<Type> imports,
          List<string> comment,
          string declaration,
          List<string> validationFmt,
          List<string> assignmentFmt)
      {
        Imports = imports;
        Comment = comment;
        Declaration = declaration;
        ValidationFmt = validationFmt;
        AssignmentFmt = assignmentFmt;
      }

      public List<string> GetValidation(string validateFunction)
      {
        return ValidationFmt.Select(line => string.Format(line, validateFunction)).ToList();
      }

      public List<string> GetAssignment(string objectName)
      {
        return AssignmentFmt.Select(line => string.Format(line, objectName)).ToList();
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
