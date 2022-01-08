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

      return CreateSimpleField(info, sourceType);
    }

    private static INewField CreateEnumerableField(FieldInfo info, Type sourceType, Type enumerableType)
    {
      return null;
    }

    private static INewField CreateSimpleField(FieldInfo info, Type sourceType)
    {
      return null;
    }

    private static bool ShouldIgnore(FieldInfo info, Type sourceType)
    {
      return false;
    }

    private class SimpleField : INewField
    {
      public string Name { get; private set; }

      public string TypeName { get; private set; }

      public string ParamName { get; private set; }

      public string? Comment { get; private set; }

      public string? DefaultValue { get; private set; }

      public List<Type> Imports { get; private set; }

      public SimpleField(
          string name,
          string typeName,
          string paramName,
          List<Type> imports,
          string? comment = null,
          string? defaultValue = null)
      {
        Name = name;
        TypeName = typeName;
        ParamName = paramName;
        Imports = imports;
        Comment = comment;
        DefaultValue = defaultValue;
      }

      // TODO: Convert to delegates for use in overrides
      public List<string> GetAssignment(string objectName)
      {
        return new() { $"{objectName}.{Name} = {ParamName};" };
      }

      public List<string> GetValidation(string validateFunction)
      {
        return new() { $"{validateFunction}({ParamName});" };
      }
    }
  }
}
