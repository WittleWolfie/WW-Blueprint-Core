using BlueprintCore.Utils;
using Kingmaker.ElementsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BlueprintCoreGen.CodeGen
{
  public static class FieldFactory
  {
  }

  public interface IField
  {
    /// <summary>
    /// Name of the field in source.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Processed type name.
    /// </summary>
    string TypeName { get; }

    /// <summary>
    /// Name of the field's method parameter.
    /// </summary>
    string ParamName { get; }

    /// <summary>
    /// Optional parameter comment.
    /// </summary>
    string Comment { get; }

    /// <summary>
    /// Optional default parameter value.
    /// </summary>
    string DefaultValue { get; }

    /// <summary>
    /// Indicates if a field can be validated.
    /// </summary>
    bool ShouldValidate { get; }

    /// <summary>
    /// Returns a complete statement which sets the field's contents.
    /// </summary>
    /// <param name="objectName">The variable name of the object containing the field.</param>
    List<string> GetAssignment(string objectName);

    /// <summary>
    /// List of types to import.
    /// </summary>
    List<Type> Imports { get; }
  }

  public interface IEnumerableField
  {
    /// <summary>
    /// Processed type name of the field's enumerable type.
    /// </summary>
    string EnumerableTypeName { get; }

    /// <summary>
    /// Returns a complete statement which adds to the field's contents.
    /// </summary>
    /// <param name="objectName">The variable name of the object containing the field.</param>
    List<string> GetAddTo(string objectName);

    /// <summary>
    /// Returns a complete statement which removes from the field's contents.
    /// </summary>
    /// <param name="objectName">The variable name of the object containing the field.</param>
    List<string> GetRemoveFrom(string objectName);
  }

  public class Field : IField
  {
    public string Name { get; private set; }
    public string TypeName { get; private set; }
    public string ParamName { get; private set; }
    public string Comment { get; private set; }
    public string DefaultValue { get; private set; }
    public bool ShouldValidate { get; private set; }
    public List<Type> Imports { get; private set; }

    public Field(FieldInfo info)
    {
      Name = info.Name;
      TypeName = GetTypeName(info.FieldType);
      ParamName = GetParamName(Name);
      ShouldValidate = !info.FieldType.IsPrimitive;
      Imports = new();
      PopulateImports(info.FieldType, Imports);
    }

    public virtual List<string> GetAssignment(string objectName)
    {
      return new() { $"{objectName}.{Name} = {ParamName};" };
    }

    private void PopulateImports(Type type, List<Type> imports)
    {
      imports.Add(type);
      if (!type.IsGenericType)
      {
        return;
      }
      type.GetGenericArguments().ToList().ForEach(t => PopulateImports(t, imports));
    }

    private static string GetParamName(string fieldName)
    {
      StringBuilder paramName = new(fieldName);
      if (paramName[0] == 'm' && paramName[1] == '_')
      {
        paramName.Remove(0, 2);
      }
      paramName[0] = char.ToLower(paramName[0]);
      return paramName.ToString();
    }

    private static readonly Dictionary<Type, string> TypeNameOverrides =
        new()
        {
          { typeof(Kingmaker.UnitLogic.Mechanics.ValueType), "Kingmaker.UnitLogic.Mechanics.ValueType" },
          { typeof(Kingmaker.UnitLogic.Abilities.Components.TargetType), "Kingmaker.UnitLogic.Abilities.Components.TargetType" },
          { typeof(Kingmaker.AI.Blueprints.TargetType), "Kingmaker.AI.Blueprints.TargetType" },
          { typeof(bool), "bool" },
          { typeof(bool?), "bool?" },
          { typeof(byte), "byte" },
          { typeof(byte), "byte?" },
          { typeof(sbyte), "sbyte" },
          { typeof(sbyte?), "sbyte?" },
          { typeof(ushort), "ushort" },
          { typeof(ushort?), "ushort?" },
          { typeof(int), "int" },
          { typeof(int?), "int?" },
          { typeof(uint), "uint" },
          { typeof(uint?), "uint?" },
          { typeof(long), "long" },
          { typeof(long?), "long?" },
          { typeof(ulong), "ulong" },
          { typeof(ulong?), "ulong?" },
          { typeof(char), "char" },
          { typeof(char?), "char?" },
          { typeof(double), "double" },
          { typeof(double?), "double?" },
          { typeof(float), "float" },
          { typeof(float?), "float?" },
          { typeof(string), "string" },
        };

    /// <summary>
    /// Recursive function which generates the correct type name for generic types.
    /// </summary>
    protected static string GetTypeName(Type type)
    {
      if (TypeNameOverrides.ContainsKey(type))
      {
        return TypeNameOverrides[type];
      }
      
      if (type.HasElementType && type.BaseType == typeof(Array))
      {
        return $"{GetTypeName(type.GetElementType())}[]";
      }

      if (!type.IsGenericType)
      {
        var name = GetSimpleTypeName(type);
        return type.DeclaringType is null ? name : $"{GetSimpleTypeName(type.DeclaringType)}.{name}";
      }

      string typeName = GetSimpleTypeName(type.GetGenericTypeDefinition());
      typeName = typeName.Substring(0, typeName.IndexOf('`'));
      string typeArguments =
          string.Join(",", type.GetGenericArguments().Select(typeArg => GetTypeName(typeArg)).ToArray());
      return typeName + "<" + typeArguments + ">";
    }

    private static string GetSimpleTypeName(Type type)
    {
      if (string.IsNullOrEmpty(type.Namespace))
      {
        return $"global::{type.Name}";
      }
      return type.Name;
    }
  }

  public class EnumerableField : Field, IEnumerableField
  {
    public string EnumerableTypeName { get; private set; }
    private readonly bool IsArray;
    private readonly string ToEnumerable;

    public EnumerableField(FieldInfo info, Type enumerableType) : base(info)
    {
      EnumerableTypeName = GetTypeName(enumerableType);
      IsArray = info.FieldType.IsArray;
      ToEnumerable = IsArray ? "ToArray()" : "ToList()";
      Imports.Add(typeof(IEnumerable<>));
      Imports.Add(typeof(CommonTool));
    }

    public List<string> GetAddTo(string objectName)
    {
      return
          new()
          {
            IsArray
                ? $"{objectName}.{Name} = CommonTool.Append({objectName}.{Name}, {ParamName});"
                : $"{objectName}.{Name}.AddRange({ParamName});"
          };
    }

    public List<string> GetRemoveFrom(string objectName)
    {
      return
          new()
          {
            $"{objectName}.{Name} = {objectName}.{Name}.Where(item => !{ParamName}.Contains(item)).{ToEnumerable}"
          };
    }
  }
}
