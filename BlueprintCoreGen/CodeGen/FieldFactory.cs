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
              GetParamName(info.Name));

      if 

      return ApplyOverrides(field, info, sourceType);
    }

    private static INewField ApplyOverrides(SimpleField field, FieldInfo info, Type sourceType)
    {
      // TODO: apply global overrides (e.g. ActionList => ActionsBuilder)

      // TODO: apply overrides
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

      private string? fieldName;

      public SimpleField(string fieldName, string typeName, string paramName)
      {
        this.fieldName = fieldName;
        TypeName = typeName;
        ParamName = paramName;
        Imports = new();
      }

      // TODO: Convert to delegates for use in overrides
      public List<string> GetAssignment(string objectName)
      {
        return new() { $"{objectName}.{fieldName} = {ParamName};" };
      }

      public List<string> GetValidation(string validateFunction)
      {
        return new() { $"{validateFunction}({ParamName});" };
      }
    }
  }
}
