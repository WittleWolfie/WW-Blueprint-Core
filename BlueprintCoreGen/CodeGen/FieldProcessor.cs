using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static BlueprintCoreGen.CodeGen.OldIField;

namespace BlueprintCoreGen.CodeGen
{
  public static class FieldProcessor
  {
    private static bool IsIgnoredEnumerableType(Type fieldType)
    {
      return fieldType == typeof(string)
          // For now just skip dictionaries
          || fieldType.GetInterfaces()
              .Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IDictionary<,>))
              .Any()
          // Maybe this type can be added later
          || fieldType.IsSubclassOf(typeof(TagListBase));
    }

    public static OldIField Process(FieldInfo field)
    {
      var enumerableType = GetEnumerableType(field.FieldType);
      if (enumerableType != null && !IsIgnoredEnumerableType(field.FieldType))
      {
        if (enumerableType.IsSubclassOf(typeof(BlueprintReferenceBase)))
        {
          return new EnumerableBlueprintField(field, enumerableType);
        }
        else
        {
          return new OldEnumerableField(field, enumerableType);
        }
      }
      else if(field.FieldType.IsSubclassOf(typeof(BlueprintReferenceBase)))
      {
        return new BlueprintField(field);
      }
      else
      {
        return new OldField(field);
      }
    }

    public static Type GetEnumerableType(Type type)
    {
      return type.GetInterfaces()
          .FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
          ?.GetGenericArguments()[0];
    }
  }

  public interface OldIField
  {
    bool IsOptional();
    string GetParamComment();
    string GetParamDeclaration();
    string GetAssignment();
    List<string> GetValidation(GetValidationCall fieldValidationProcessor);
    List<Type> GetImports();
    void SetParamName(string name);

    delegate string GetValidationCall(string varName);
  }

  public interface IOldEnumerable : OldIField
  {
    Type GetEnumerableType();

    List<string> GetAdd(string bpVarName);

    List<string> GetRemove(string bpVarName);
  }

  public class OldField : OldIField
  {
    protected FieldInfo Info { get; private set; }
    protected string ParamName { get; private set; }

    private readonly FieldType Type;

    public OldField(FieldInfo fieldInfo)
    {
      Info = fieldInfo;
      if (Info.FieldType == typeof(ActionList))
      {
        Type = FieldType.Actions;
      }
      else if (Info.FieldType == typeof(ConditionsChecker))
      {
        Type = FieldType.Conditions;
      }
      else
      {
        Type = FieldType.Default;
      }
      ParamName = Info.Name;
    }

    public virtual void SetParamName(string name)
    {
      ParamName = name;
    }

    public virtual bool IsOptional()
    {
      return false;
    }

    public virtual string GetParamComment()
    {
      return null;
    }

    public virtual string GetParamDeclaration()
    {
      switch (Type)
      {
        case FieldType.Actions:
          return $"ActionsBuilder {ParamName}";
        case FieldType.Conditions:
          return $"ConditionsBuilder {ParamName}";
        case FieldType.Default:
        default:
          return $"{CodeGenerator.GetTypeName(Info.FieldType)} {ParamName}";
      }
    }

    public virtual string GetAssignment()
    {
      switch (Type)
      {
        case FieldType.Actions:
        case FieldType.Conditions:
          return $"{Info.Name} = {ParamName}.Build();";
        case FieldType.Default:
        default:
          return $"{Info.Name} = {ParamName};";
      }
    }

    public virtual List<string> GetValidation(GetValidationCall fieldValidationProcessor)
    {
      switch (Type)
      {
        case FieldType.Actions:
        case FieldType.Conditions:
          return new();
        default:
          if (Info.FieldType.IsPrimitive) return new();
          return new() { fieldValidationProcessor(ParamName) };
      }
    }

    public virtual List<Type> GetImports()
    {
      List<Type> imports = new() { Info.FieldType };
      switch (Type)
      {
        case FieldType.Actions:
          imports.Add(typeof(ActionsBuilder));
          break;
        case FieldType.Conditions:
          imports.Add(typeof(ConditionsBuilder));
          break;
        default:
          GetTypes(Info.FieldType, imports);
          break;
      }
      return imports;
    }

    /// <summary>
    /// Recursive function which adds all generic types to the provided list.
    /// </summary>
    protected static void GetTypes(Type type, List<Type> types)
    {
      types.Add(type);
      if (!type.IsGenericType)
      {
        return;
      }
      type.GetGenericArguments().ToList().ForEach(t => GetTypes(t, types));
    }

    private enum FieldType
    {
      Default = 0,
      Conditions,
      Actions
    }
  }

  public class NegateConditionField : OldIField
  {
    public NegateConditionField()
    {
    }

    public bool IsOptional()
    {
      return true;
    }

    public string GetParamComment()
    {
      return null;
    }

    public string GetParamDeclaration()
    {
      return "bool negate = false";
    }

    public string GetAssignment()
    {
      return "Not = negate;";
    }

    public void SetParamName(string name) { throw new NotImplementedException(); }

    public List<Type> GetImports()
    {
      return new();
    }

    public List<string> GetValidation(GetValidationCall fieldValidationProcessor)
    {
      return new();
    }
  }

  public class OldEnumerableField : OldField, IOldEnumerable
  {
    private readonly Type EnumerableType;

    public OldEnumerableField(FieldInfo fieldInfo, Type enumerableType) : base(fieldInfo)
    {
      EnumerableType = enumerableType;
    }

    public List<string> GetAdd(string bpVarName)
    {
      return
          new()
          {
            Info.FieldType.IsArray
                ? $"{bpVarName}.{Info.Name} = CommonTool.Append({bpVarName}.{Info.Name}, {ParamName})"
                : $"{bpVarName}.{Info.Name}.AddRange({ParamName})"
          };
    }

    public Type GetEnumerableType()
    {
      return EnumerableType;
    }

    public List<string> GetRemove(string bpVarName)
    {
      var toEnumerable = Info.FieldType.IsArray ? "ToArray()" : "ToList()";
      return
          new()
          {
            $"{bpVarName}.{Info.Name} = {bpVarName}.{Info.Name}.Where(item => !{ParamName}.Contains(item)).{toEnumerable}"
          };
    }

    public override List<string> GetValidation(GetValidationCall fieldValidationProcessor)
    {
      if (EnumerableType.IsPrimitive) return new();
      return new List<string>
      {
        $"foreach (var item in {ParamName})",
        $"{{",
        $"  {fieldValidationProcessor("item")}",
        $"}}"
      };
    }
  }

  public class BlueprintField : OldField
  {
    protected readonly Type BlueprintType;

    public BlueprintField(FieldInfo fieldInfo) : this(fieldInfo, fieldInfo.FieldType) { }

    protected BlueprintField(FieldInfo fieldInfo, Type referenceType) : base(fieldInfo)
    {
      BlueprintType = GetBlueprintTypeFromReferenceType(referenceType);
    }

    public override string GetParamComment()
    {
      return $"<param name=\"{ParamName}\"><see cref=\"{BlueprintType.Name}\"/></param>";
    }

    public override string GetParamDeclaration()
    {
      return $"string {ParamName}";
    }

    public override string GetAssignment()
    {
      return $"{Info.Name} = BlueprintTool.GetRef<{CodeGenerator.GetTypeName(Info.FieldType)}>({ParamName});";
    }

    public override List<string> GetValidation(GetValidationCall fieldValidationProcessor)
    {
      return new();
    }

    public override List<Type> GetImports()
    {
      List<Type> imports = base.GetImports();
      imports.Add(typeof(BlueprintTool));
      return imports;
    }

    private static Type GetBlueprintTypeFromReferenceType(Type referenceType)
    {
      var refType = referenceType;
      while (!(refType.IsGenericType && refType.GetGenericTypeDefinition() == typeof(BlueprintReference<>)))
      {
        refType = refType.BaseType;
      }
      return refType.GenericTypeArguments[0];
    }
  }

  public class EnumerableBlueprintField : BlueprintField, IOldEnumerable
  {
    private readonly Type ReferenceType;

    public EnumerableBlueprintField(FieldInfo fieldInfo, Type referenceType) : base(fieldInfo, referenceType)
    {
      ReferenceType = referenceType;
    }

    public override string GetParamDeclaration()
    {
      return $"string[] {ParamName}";
    }

    public override string GetAssignment()
    {
      var toEnumerable = IsList(Info.FieldType) ? "ToList()" : "ToArray()";
      return $"{Info.Name} = {ParamName}.Select(bp => BlueprintTool.GetRef<{CodeGenerator.GetTypeName(ReferenceType)}>(bp)).{toEnumerable};";
    }

    public override List<Type> GetImports()
    {
      List<Type> imports = base.GetImports();
      imports.Add(typeof(Enumerable));
      return imports;
    }

    private static bool IsList(Type type)
    {
      var baseType = type;
      while (baseType is not null)
      {
        if (baseType.IsGenericType && baseType.GetGenericTypeDefinition() == typeof(List<>))
        {
          return true;
        }
        baseType = baseType.BaseType;
      }
      return false;
    }

    public Type GetEnumerableType()
    {
      return typeof(string);
    }

    public List<string> GetAdd(string bpVarName)
    {
      var refConversion =
          $"{ParamName}.Select(name => BlueprintTool.GetRef<{CodeGenerator.GetTypeName(ReferenceType)}>(name))";
      return
          new()
          {
            Info.FieldType.IsArray
                ? $"{bpVarName}.{Info.Name} = CommonTool.Append({bpVarName}.{Info.Name}, {refConversion}.ToArray())"
               : $"{bpVarName}.{Info.Name}.AddRange({refConversion})"
          };
    }

    public List<string> GetRemove(string bpVarName)
    {
      var refConversion =
          $"{ParamName}.Select(name => BlueprintTool.GetRef<{CodeGenerator.GetTypeName(ReferenceType)}>(name))";
      var toEnumerable = Info.FieldType.IsArray ? "ToArray()" : "ToList()";
      return
          new()
          {
            $"var excludeRefs = {refConversion};",
            $"{bpVarName}.{Info.Name} =",
            $"    {bpVarName}.{Info.Name}",
            $"        .Where(",
            $"            bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))",
            $"        .{toEnumerable};"
          };
    }
  }
}
