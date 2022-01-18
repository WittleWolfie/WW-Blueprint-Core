using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Mechanics;
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
  public interface INewField
  {
    /// <summary>
    /// Processed type name.
    /// </summary>
    string TypeName { get; }

    /// <summary>
    /// Name of the field's method parameter.
    /// </summary>
    /// 
    /// <remarks>If this is null it should be assigned last, as it may rely on other fields being configured.</remarks>
    string ParamName { get; }

    /// <summary>
    /// Optional parameter comment.
    /// </summary>
    string? Comment { get; }

    /// <summary>
    /// Optional default parameter value.
    /// </summary>
    string? DefaultValue { get; }

    /// <summary>
    /// Returns a complete statement which validates the field's contents.
    /// </summary>
    /// 
    /// <param name="validateFunction">The validate function to call.</param>
    List<string> GetValidation(string validateFunction);

    /// <summary>
    /// Returns a complete statement which sets the field's contents.
    /// </summary>
    /// 
    /// <param name="objectName">The variable name of the object containing the field.</param>
    List<string> GetAssignment(string objectName);

    /// <summary>
    /// List of types to import.
    /// </summary>
    List<Type> Imports { get; }
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
    public static IField? Create(FieldInfo info, Type sourceType)
    {
      return CreateInternal(info, sourceType);
      //IField field = CreateInternal(info, sourceType);
      //if (field is null) { return null; }
      //return FieldOverrides.GetFor(field, sourceType);
    }

    private static IField? CreateInternal(FieldInfo info, Type sourceType)
    {
      var enumerableType = GetEnumerableType(info.FieldType);
      if (enumerableType is not null && !IsIgnoredEnumerableType(info.FieldType))
      {
        if (enumerableType.IsSubclassOf(typeof(BlueprintReferenceBase)))
        {
          return new EnumerableBlueprintField(info, enumerableType);
        }
        return new EnumerableField(info, enumerableType);
      }
    }

    private class EnumerableField : Field, IEnumerableField
    {
      public string EnumerableTypeName { get; private set; }
      private readonly bool IsArray;
      private readonly string ToEnumerable;
      private readonly string InternalTypeName;

      public EnumerableField(FieldInfo info, Type enumerableType) : base(info)
      {
        InternalTypeName = TypeTool.GetName(info.FieldType);
        EnumerableTypeName = TypeTool.GetName(enumerableType);
        IsArray = info.FieldType.IsArray;
        ToEnumerable = IsArray ? "ToArray()" : "ToList()";

        DefaultValue = "null";

        ShouldValidate = GetShouldValidate(enumerableType);

        Imports.Add(typeof(Enumerable));
        Imports.Add(typeof(CommonTool));
      }

      protected override bool IsNullable()
      {
        return true;
      }

      public List<string> GetAddTo(string objectName)
      {
        return
            new()
            {
              IsArray
                  ? $"{objectName}.{Name} = CommonTool.Append({objectName}.{Name}, {ParamName} ?? new {EnumerableTypeName}[0]);"
                  : $"{objectName}.{Name}.AddRange({ParamName}.ToList() ?? new {InternalTypeName}());"
            };
      }

      public List<string> GetRemoveFrom(string objectName)
      {
        return
            new()
            {
              $"{objectName}.{Name} = {objectName}.{Name}.Where(item => !{ParamName}.Contains(item)).{ToEnumerable};"
            };
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
        TypeName = "string[]?";
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
