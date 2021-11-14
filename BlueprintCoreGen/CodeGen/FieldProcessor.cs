using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static BlueprintCoreGen.CodeGen.IField;

namespace BlueprintCoreGen.CodeGen
{
  public static class FieldProcessor
  {
    public static IField Process(FieldInfo field)
    {
      var enumerableType = GetEnumerableType(field.FieldType);
      if (enumerableType != null)
      {
        if (enumerableType.IsSubclassOf(typeof(BlueprintReferenceBase)))
        {
          return new EnumerableBlueprintField(field, enumerableType);
        }
        else
        {
          return new EnumerableField(field, enumerableType);
        }
      }
      else if(field.FieldType.IsSubclassOf(typeof(BlueprintReferenceBase)))
      {
        return new BlueprintField(field);
      }
      else
      {
        return new Field(field);
      }
    }

    private static Type GetEnumerableType(Type type)
    {
      return type.GetInterfaces()
          .FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
          ?.GetGenericArguments()[0];
    }
  }

  public interface IField
  {
    bool IsOptional();
    string GetParamComment();
    string GetParamDeclaration();
    string GetAssignment();
    List<string> GetValidation(GetValidationCall fieldValidationProcessor);
    List<Type> GetImports();

    delegate string GetValidationCall(string varName);
  }

  public class Field : IField
  {
    protected FieldInfo Info { get; private set; }

    private readonly FieldType Type;

    public Field(FieldInfo fieldInfo)
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
          return $"ActionsBuilder {Info.Name}";
        case FieldType.Conditions:
          return $"ConditionsBuilder {Info.Name}";
        case FieldType.Default:
        default:
          return $"{CodeGenerator.GetTypeName(Info.FieldType)} {Info.Name}";
      }
    }

    public virtual string GetAssignment()
    {
      switch (Type)
      {
        case FieldType.Actions:
        case FieldType.Conditions:
          return $"{Info.Name} = {Info.Name}.Build();";
        case FieldType.Default:
        default:
          return $"{Info.Name} = {Info.Name};";
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
          return new() { fieldValidationProcessor(Info.Name) };
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

  public class NegateConditionField : IField
  {
    public NegateConditionField() { }

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

    public List<Type> GetImports()
    {
      return new();
    }

    public List<string> GetValidation(GetValidationCall fieldValidationProcessor)
    {
      return new();
    }
  }

  public class EnumerableField : Field
  {
    private readonly Type EnumerableType;

    public EnumerableField(FieldInfo fieldInfo, Type enumerableType) : base(fieldInfo)
    {
      EnumerableType = enumerableType;
    }

    public override List<string> GetValidation(GetValidationCall fieldValidationProcessor)
    {
      if (EnumerableType.IsPrimitive) return new();
      return new List<string>
      {
        $"foreach (var item in {Info.Name})",
        $"{{",
        $"  {fieldValidationProcessor("item")}",
        $"}}"
      };
    }
  }

  public class BlueprintField : Field
  {
    protected readonly Type BlueprintType;

    public BlueprintField(FieldInfo fieldInfo) : this(fieldInfo, fieldInfo.FieldType) { }

    protected BlueprintField(FieldInfo fieldInfo, Type referenceType) : base(fieldInfo)
    {
      BlueprintType = GetBlueprintTypeFromReferenceType(referenceType);
    }

    public override string GetParamComment()
    {
      return $"<param name=\"{Info.Name}\"><see cref=\"{BlueprintType.Name}\"/></param>";
    }

    public override string GetParamDeclaration()
    {
      return $"string {Info.Name}";
    }

    public override string GetAssignment()
    {
      return $"{Info.Name} = BlueprintTool.GetRef<{CodeGenerator.GetTypeName(Info.FieldType)}>({Info.Name});";
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

  public class EnumerableBlueprintField : BlueprintField
  {
    private readonly Type ReferenceType;

    public EnumerableBlueprintField(FieldInfo fieldInfo, Type referenceType) : base(fieldInfo, referenceType)
    {
      ReferenceType = referenceType;
    }

    public override string GetParamDeclaration()
    {
      return $"string[] {Info.Name}";
    }

    public override string GetAssignment()
    {
      var toEnumerable = IsList(Info.FieldType) ? "ToList()" : "ToArray()";
      return $"{Info.Name} = {Info.Name}.Select(bp => BlueprintTool.GetRef<{CodeGenerator.GetTypeName(ReferenceType)}>(bp)).{toEnumerable};";
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
  }
}
