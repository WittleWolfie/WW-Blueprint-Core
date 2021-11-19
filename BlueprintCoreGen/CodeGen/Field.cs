using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Quests;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BlueprintCoreGen.CodeGen
{

  /// <summary>
  /// Represents a field modified in a generated method.
  /// </summary>
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
    /// Name of the field for use in method name.
    /// </summary>
    string MethodName { get; }

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
    HashSet<Type> Imports { get; }
  }

  public interface IEnumerableField : IField
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

  public static class FieldFactory
  {
    public static IField Create(FieldInfo info)
    {
      if (IsIgnoredField(info)) { return null; }

      var enumerableType = GetEnumerableType(info.FieldType);
      if (enumerableType is not null && !IsIgnoredEnumerableType(info.FieldType))
      {
        if (enumerableType.IsSubclassOf(typeof(BlueprintReferenceBase)))
        {
          return new EnumerableBlueprintField(info, enumerableType);
        }
        return new EnumerableField(info, enumerableType);
      }
      if (info.FieldType.IsSubclassOf(typeof(BlueprintReferenceBase)))
      {
        return new BlueprintField(info, info.FieldType);
      }
      if (info.FieldType == typeof(ActionsBuilder))
      {
        return new BuilderField(info, BuilderField.BuilderType.Actions);
      }
      if (info.FieldType == typeof(ConditionsChecker))
      {
        return new BuilderField(info, BuilderField.BuilderType.Conditions);
      }
      return new Field(info);
    }

    private static readonly Dictionary<Type, List<string>> IgnoredFieldNameByType =
        new()
        {
          { typeof(AbilityDeliverProjectile), new() { "m_HasIsAllyEffectRunConditions" } },
          { typeof(BlueprintQuestObjective), new() { "m_NextObjectivesProxy", "m_AddendumsProxy", "m_AreasProxy" } }
        };
    private static bool IsIgnoredField(FieldInfo field)
    {
      return field.Name.Contains("__BackingField") // Compiler generated field
          || field.Name == "name" // Common field that shouldn't be modified
          // Skip constant, static, and read-only
          || field.IsLiteral
          || field.IsStatic
          || field.IsInitOnly
          || (IgnoredFieldNameByType.ContainsKey(field.DeclaringType)
              && IgnoredFieldNameByType[field.DeclaringType].Contains(field.Name));
    }

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

    private static Type GetEnumerableType(Type type)
    {
      return type.GetInterfaces()
          .FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
          ?.GetGenericArguments()[0];
    }

    private class Field : IField
    {
      public string Name { get; private set; }
      public string TypeName { get; protected set; }
      public string MethodName { get; private set; }
      public string ParamName { get; private set; }
      public string Comment { get; protected set; }
      public string DefaultValue { get; protected set; }
      public bool ShouldValidate { get; protected set; }
      public HashSet<Type> Imports { get; private set; }

      public Field(FieldInfo info)
      {
        Name = info.Name;
        TypeName = TypeTool.GetName(info.FieldType);
        ParamName = GetFriendlyName(Name, lowercase: true);
        MethodName = GetFriendlyName(Name, lowercase: false);

        ShouldValidate = !info.FieldType.IsPrimitive && info.FieldType != typeof(string);
        DefaultValue = GetDefaultValue(info.FieldType);

        Imports = new();
        PopulateImports(info.FieldType, Imports);
      }

      public virtual List<string> GetAssignment(string objectName)
      {
        return new() { $"{objectName}.{Name} = {ParamName};" };
      }

      protected static bool GetShouldValidate(Type type)
      {
        if (type.IsPrimitive)
        {
          return false;
        }
        if (type == typeof(string))
        {
          return false;
        }
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
          return false;
        }
        return true;
      }

      private static void PopulateImports(Type type, HashSet<Type> imports)
      {
        imports.Add(type);
        if (!type.IsGenericType)
        {
          return;
        }
        type.GetGenericArguments().ToList().ForEach(t => PopulateImports(t, imports));
      }
      
      // TODO: Use a dictionary -- set default values based on Constants? Requires imports too...
      private static string GetDefaultValue(Type type)
      {
        if (type.IsPrimitive) { return "default"; }
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>)) { return "null"; }
        return null;
      }

      private static string GetFriendlyName(string fieldName, bool lowercase)
      {
        StringBuilder paramName = new(fieldName);
        if (paramName[0] == 'm' && paramName[1] == '_')
        {
          paramName.Remove(0, 2);
        }
        paramName[0] = lowercase ? char.ToLower(paramName[0]) : char.ToUpper(paramName[0]);
        return paramName.ToString();
      }
    }

    private class BuilderField : Field
    {
      public enum BuilderType
      {
        Actions,
        Conditions
      }
      private readonly BuilderType Type;

      public BuilderField(FieldInfo info, BuilderType builderType) : base(info)
      {
        Type = builderType;
        TypeName = GetBuilderTypeName(Type);

        ShouldValidate = false;

        Imports.Add(typeof(Constants));
        switch (Type)
        {
          case BuilderType.Actions:
            TypeName = "ActionsBuilder";
            Imports.Add(typeof(ActionsBuilder));
            break;
          case BuilderType.Conditions:
            TypeName = "ConditionsBuilder";
            Imports.Add(typeof(ConditionsChecker));
            break;
          default:
            throw new InvalidOperationException("Unsupported builder type: " + info.FieldType.Name);
        }
      }

      public override List<string> GetAssignment(string objectName)
      {
        return new() { $"{objectName}.{Name} = {ParamName}?.Build() ?? Constants.Empty.{Type};" };
      }

      private static string GetBuilderTypeName(BuilderType type)
      {
        switch (type)
        {
          case BuilderType.Actions:
            return "ActionsBuilder";
          case BuilderType.Conditions:
            return "ConditionsBuilder";
          default:
            break;
        }
        throw new InvalidOperationException("Unexpected builder type: " + type);
      }
    }

    private class EnumerableField : Field, IEnumerableField
    {
      public string EnumerableTypeName { get; private set; }
      private readonly bool IsArray;
      private readonly string ToEnumerable;

      public EnumerableField(FieldInfo info, Type enumerableType) : base(info)
      {
        EnumerableTypeName = TypeTool.GetName(enumerableType);
        IsArray = info.FieldType.IsArray;
        ToEnumerable = IsArray ? "ToArray()" : "ToList()";

        ShouldValidate = GetShouldValidate(enumerableType);

        Imports.Add(typeof(Enumerable));
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

    private class BlueprintField : Field
    {
      protected readonly string ReferenceTypeName;

      public BlueprintField(FieldInfo info, Type referenceType) : base(info)
      {
        TypeName = "string";
        ReferenceTypeName = TypeTool.GetName(referenceType);

        var blueprintTypeName = TypeTool.GetName(GetBlueprintTypeFromReferenceType(referenceType));
        Comment = $"<param name=\"{ParamName}\"><see cref=\"{blueprintTypeName}\"/></param>";

        DefaultValue = "null";

        ShouldValidate = false;
        Imports.Add(typeof(BlueprintTool));
      }

      public override List<string> GetAssignment(string objectName)
      {
        return new() { $"{objectName}.{Name} = BlueprintTool.GetRef<{ReferenceTypeName}>({ParamName});" };
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

    private class EnumerableBlueprintField : BlueprintField, IEnumerableField
    {
      public string EnumerableTypeName { get; private set; }
      private readonly bool IsArray;
      private readonly string ToEnumerable;
      private readonly string ReferenceConversion;

      public EnumerableBlueprintField(FieldInfo info, Type referenceType) : base(info, referenceType)
      {
        TypeName = "string[]";
        EnumerableTypeName = "string";

        IsArray = info.FieldType.IsArray;
        ToEnumerable = IsArray ? "ToArray()" : "ToList()";
        ReferenceConversion = $"{ParamName}.Select(name => BlueprintTool.GetRef<{ReferenceTypeName}>(name))";

        Imports.Add(typeof(Enumerable));
        Imports.Add(typeof(CommonTool));
      }

      public override List<string> GetAssignment(string objectName)
      {
        return new() { $"{objectName}.{Name} = {ReferenceConversion}.{ToEnumerable};" };
      }

      public List<string> GetAddTo(string objectName)
      {
        return
            new()
            {
              IsArray
                  ? $"{objectName}.{Name} = CommonTool.Append({objectName}.{Name}, {ReferenceConversion}.ToArray());"
                  : $"{objectName}.{Name}.AddRange({ReferenceConversion});"
            };
      }

      public List<string> GetRemoveFrom(string objectName)
      {
        return
            new()
            {
              $"var excludeRefs = {ReferenceConversion};",
              $"{objectName}.{Name} =",
              $"    {objectName}.{Name}",
              $"        .Where(",
              $"            bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))",
              $"        .{ToEnumerable};"
            };
      }
    }
  }
}
