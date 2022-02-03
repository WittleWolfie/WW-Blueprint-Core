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

  /// <summary>
  /// Represents a field within a blueprint.
  /// </summary>
  public interface IBlueprintField
  {

  }

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
              .Select(fieldInfo => CreateForConstructor(fieldInfo, objectType))
              .ToList();
    }

    public static List<INewField> CreateForBlueprintConfigurator(Type blueprintType)
    {
      return null;
    }

    public static readonly List<INewField> UniqueComponentFields =
        new() { new MergeBehaviorField(), new MergeActionField() };

    private static INewField CreateForConstructor(FieldInfo info, Type sourceType)
    {
      var enumerableType = TypeTool.GetEnumerableType(info.FieldType);
      if (enumerableType is not null)
      {
        return CreateEnumerableField(info, sourceType, enumerableType);
      }

      return CreateField(info, sourceType);
    }

    // TODO: Maybe get rid of the concrete classes and replace w/ 1 for Enumerable and 1 for non-Enumerable?
    // The idea is that the Factory code creates them with a simple constructor that sets each value.

    private static INewField CreateEnumerableField(FieldInfo info, Type sourceType, Type enumerableType)
    {
      var field =
          enumerableType.IsSubclassOf(typeof(BlueprintReferenceBase))
              ? new 
      return null;
    }

    private static INewField CreateField(FieldInfo info, Type sourceType)
    {
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

    private class SimpleField : INewField
    {
      public string TypeName { get; set; }

      public string ParamName { get; set; }

      public string? Comment { get; set; }

      public string? DefaultValue { get; set; }

      public List<Type> Imports { get; set; }

      /// <summary>
      /// Assignment format string where {0} is objectName, {1} is fieldName, and {2} is ParamName
      /// </summary>
      public virtual List<string> AssignmentFmt { get; set; }

      /// <summary>
      /// Validation format string where {0} is validateFunction and {1} is ParamName
      /// </summary>
      public List<string> ValidationFmt { get; set; }

      protected readonly string? fieldName;

      public SimpleField(
          string? fieldName, string typeName, string paramName, bool shouldSkipValidation, params Type[] imports)
      {
        this.fieldName = fieldName;
        TypeName = typeName;
        ParamName = paramName;
        Imports = new();
        Imports.AddRange(imports);

        AssignmentFmt = new() { "{0}.{1} = {2};" };
        ValidationFmt = shouldSkipValidation ? new() : new() { "{0}({1});" };
      }

      public List<string> GetAssignment(string objectName)
      {
        return AssignmentFmt.Select(line => string.Format(line, objectName, fieldName, ParamName)).ToList();
      }

      public List<string> GetValidation(string validateFunction)
      {
        return ValidationFmt.Select(line => string.Format(line, validateFunction, ParamName)).ToList();
      }

      public void ApplyFieldOverride(FieldOverride fieldOverride)
      {
        if (fieldOverride.TypeName is not null)
        {
          TypeName = fieldOverride.TypeName;
        }

        if (fieldOverride.ParamName is not null)
        {
          ParamName = fieldOverride.ParamName;
        }

        if (fieldOverride.Comment is not null)
        {
          Comment = fieldOverride.Comment;
        }

        if (fieldOverride.DefaultValue is not null)
        {
          DefaultValue = fieldOverride.DefaultValue;
        }

        if (fieldOverride.ValidationFmt is not null)
        {
          ValidationFmt = fieldOverride.ValidationFmt;
        }

        if (fieldOverride.AssignmentFmt is not null)
        {
          AssignmentFmt = fieldOverride.AssignmentFmt;
        }

        Imports.AddRange(fieldOverride.Imports);
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

    private class MergeBehaviorField : SimpleField
    {
      public MergeBehaviorField()
          : base(
              null,
              "ComponentMerge",
              "mergeBehavior",
              true,
              typeof(BlueprintConfigurator<>),
              typeof(Action),
              typeof(BlueprintComponent))
      {
        DefaultValue = "ComponentMerge.Replace";

        AssignmentFmt = new();
        ValidationFmt = new();
      }
    }

    private class MergeActionField : SimpleField
    {
      public MergeActionField() : base(null, "Action<BlueprintComponent, BluepprintComponent>?", "mergeAction", true)
      {
        DefaultValue = "null";

        AssignmentFmt = new();
        ValidationFmt = new();
      }
    }
  }
}
