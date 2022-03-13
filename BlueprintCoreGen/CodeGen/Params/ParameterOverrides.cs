using BlueprintCoreGen.CodeGen.Override;
using System;
using System.Collections.Generic;
using System.Linq;
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
}
