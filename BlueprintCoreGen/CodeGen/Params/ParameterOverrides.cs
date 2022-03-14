using BlueprintCoreGen.CodeGen.Override;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static BlueprintCoreGen.CodeGen.Params.ParametersFactory;

namespace BlueprintCoreGen.CodeGen.Params
{
  /// <summary>
  /// Base class for overriding the behavior of a field parameter.
  /// </summary>
  public abstract class FieldParameterOverride
  {
    /// <summary>
    /// Name of the field.
    /// </summary>
    public string FieldName { get; } = string.Empty;

    /// <summary>
    /// Applies the override to the provided FieldParameter.
    /// </summary>
    public abstract void ApplyTo(FieldParameter param);
  }

  /// <summary>
  /// Represents a field with a specific default value.
  /// </summary>
  public class DefaultField : FieldParameterOverride
  {
    /// <summary>
    /// The default value of the field.
    /// </summary>
    public string Value { get; } = string.Empty;

    public override void ApplyTo(FieldParameter param)
    {
      param.SetDefaultValue(Value);
    }
  }

  /// <summary>
  /// Represents a field with a constant value.
  /// </summary>
  public class ConstantField : FieldParameterOverride
  {
    /// <summary>
    /// The constant value of the field.
    /// </summary>
    public string Value { get; } = string.Empty;

    public override void ApplyTo(FieldParameter param)
    {
      param.SetConstantValue(Value);
    }
  }

  /// <summary>
  /// Custom field override with support for a variety of parameters.
  /// </summary>
  public class CustomField : FieldParameterOverride
  {
    /// <summary>
    /// Indicates whether the field is required when building the action.
    /// </summary>
    public bool Required { get; }

    /// <summary>
    /// Name of the field when provided as a function parameter.
    /// </summary>
    public string ParamName { get; } = string.Empty;

    /// <summary>
    /// Additional lines of code added after assigning the field's value.
    /// </summary>
    public List<string> ExtraAssignmentFmtLines { get; } = new();

    public override void ApplyTo(FieldParameter fieldParameter)
    {
      if (Required) { fieldParameter.MakeRequired(); }

      if (!string.IsNullOrEmpty(ParamName)) { fieldParameter.SetParamName(ParamName); }

      if (ExtraAssignmentFmtLines.Any()) { fieldParameter.SetExtraAssignmentFmtLines(ExtraAssignmentFmtLines); }
    }
  }

  /// <summary>
  /// Field parameter overrides applied by field type.
  /// </summary>
  public class FieldTypeOverride : FieldParameterOverride
  {
    /// <summary>
    /// The type name to which the overrides apply.
    /// </summary>
    public string TypeName { get; } = string.Empty;

    /// <summary>
    /// If set, replaces the type name for the parameter. Used when utility classes wrap an input parameter,
    /// e.g. ActionsBuilder in place of ActionList.
    /// </summary>
    public string TypeNameOverride { get; } = string.Empty;

    /// <summary>
    /// If true, skips parameter validation.
    /// </summary>
    public bool SkipValidation { get; } = true;

    /// <summary>
    /// Additional types to import (by name).
    /// </summary>
    public List<string> Imports { get; } = new();

    /// <summary>
    /// Overrides the right hand side of the assignment format statement.
    /// </summary>
    public string AssignmentFmtRhs { get; } = string.Empty;

    /// <summary>
    /// Overrides the right hand side of the assignment format statement used when null.
    /// </summary>
    public string AssignmentIfNullRhs { get; } = string.Empty;

    public override void ApplyTo(FieldParameter param)
    {
      if (!string.IsNullOrEmpty(TypeNameOverride)) { param.SetTypeName(TypeNameOverride); }
      if (SkipValidation) { param.SkipValidation(); }
      param.Imports.AddRange(Imports.Select(type => Type.GetType(type)!));
      if (!string.IsNullOrEmpty(AssignmentFmtRhs)) { param.SetAssignmentFmtRhs(AssignmentFmtRhs); }
      if (!string.IsNullOrEmpty(AssignmentIfNullRhs)) { param.SetAssignmentFmtRhs(AssignmentIfNullRhs); }
    }
  }

  /// <summary>
  /// Field parameter overrides applied to specific fields.
  /// </summary>
  public class FieldOverride : FieldParameterOverride
  {
    /// <summary>
    /// The type name of the object containing the field.
    /// </summary>
    public string SourceTypeName { get; } = string.Empty;

    /// <summary>
    /// Specifies whether the field is nullable.
    /// </summary>
    public bool IsNullable { get; } = false;

    /// <summary>
    /// Overrides the name of the parameter.
    /// </summary>
    public string ParamName { get; } = string.Empty;

    /// <summary>
    /// Overrides the default value of the parameter.
    /// </summary>
    public string DefaultValue { get; } = string.Empty;

    public override void ApplyTo(FieldParameter param)
    {
      param.SetIsNullable(IsNullable);
      if (!string.IsNullOrEmpty(ParamName)) { param.SetParamName(ParamName); }
      if (!string.IsNullOrEmpty(DefaultValue)) { param.SetDefaultValue(DefaultValue); }
    }
  }
}
