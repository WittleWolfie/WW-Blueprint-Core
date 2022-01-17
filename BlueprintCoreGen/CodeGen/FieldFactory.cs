using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlueprintCoreGen.CodeGen
{
  public static class NewFieldFactory
  {
    public static List<INewField> CreateForType(Type type)
    {
      return
          type.GetFields()
              .Where(fieldInfo => !ShouldIgnore(fieldInfo, type))
              .Select(fieldInfo => CreateInternal(fieldInfo, type))
              .ToList();
    }

    private static INewField CreateInternal(FieldInfo info, Type sourceType)
    {
      var enumerableType = TypeTool.GetEnumerableType(info.FieldType);
      if (enumerableType is not null)
      {
        return CreateEnumerableField(info, sourceType, enumerableType);
      }

      return CreateField(info, sourceType);
    }

    private static INewField CreateEnumerableField(FieldInfo info, Type sourceType, Type enumerableType)
    {
      return null;
    }

    private static INewField CreateField(FieldInfo info, Type sourceType)
    {
      var field =
          new SimpleField(
              info.Name,
              TypeTool.GetName(info.FieldType),
              GetParamName(info.Name),
              info.FieldType);
      
      if (FieldOverrides.ByType.ContainsKey(info.FieldType))
      {
        field.ApplyFieldOverride(FieldOverrides.ByType[info.FieldType]);
      }

      // Just checking the source type misses inherited fields so loop through all keys
      foreach (Type type in FieldOverrides.ByName.Keys)
      {
        if ((sourceType == type || sourceType.IsSubclassOf(type))
            && FieldOverrides.ByName[type].ContainsKey(info.Name))
        {
          field.ApplyFieldOverride(FieldOverrides.ByName[type][info.Name]);
        }
      }

      return field;
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
      public List<string> AssignmentFmt { get; set; }

      /// <summary>
      /// Validation format string where {0} is validateFunction and {1} is ParamName
      /// </summary>
      public List<string> ValidationFmt { get; set; }

      private readonly string? fieldName;

      public SimpleField(string fieldName, string typeName, string paramName, params Type[] imports)
      {
        this.fieldName = fieldName;
        TypeName = typeName;
        ParamName = paramName;
        Imports = new();
        Imports.AddRange(imports);

        AssignmentFmt = new() { "{0}.{1} = {2};" };
        ValidationFmt = new() { "{0}.{1};" };
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
  }
}
