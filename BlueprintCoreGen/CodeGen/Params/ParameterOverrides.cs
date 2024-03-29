﻿using Kingmaker.Blueprints;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

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
    [JsonProperty]
    public string FieldName { get; private set; } = string.Empty;

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
    [JsonProperty]
    public string Value { get; private set; } = string.Empty;

    public override void ApplyTo(FieldParameter param)
    {
      param.SetDefaultValue(Value);
      param.SetIsNullable(false);
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
    [JsonProperty]
    public string Value { get; private set; } = string.Empty;

    public override void ApplyTo(FieldParameter param)
    {
      param.SetConstantValue(Value);
      param.AddCommentFmt(new());
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
    [JsonProperty]
    public bool Required { get; private set; }

    /// <summary>
    /// Indicates whether the field is nullable.
    /// </summary>
    [JsonProperty]
    public bool? IsNullable { get; private set; }

    /// <summary>
    /// Type of the field when provided as a function parameter.
    /// </summary>
    [JsonProperty]
    public string TypeName { get; private set; } = string.Empty;

    /// <summary>
    /// Name of the field when provided as a function parameter.
    /// </summary>
    [JsonProperty]
    public string ParamName { get; private set; } = string.Empty;

    /// <summary>
    /// Default value of the field when provided as a function parameter.
    /// </summary>
    [JsonProperty]
    public string DefaultValue { get; private set; } = string.Empty;

    /// <summary>
    /// Format string where {0} is the param name.
    /// </summary>
    [JsonProperty]
    public string CommentFmt { get; private set; } = string.Empty;

    /// <summary>
    /// Assignment format string for the right hand side of an assignment statement, where {0} is the parameter name
    /// </summary>
    [JsonProperty]
    public string AssignmentFmtRhs { get; private set; } = string.Empty;

    /// <summary>
    /// Additional lines of code added after assigning the field's value.
    /// </summary>
    public List<string> ExtraAssignmentFmtLines { get; } = new();

    public override void ApplyTo(FieldParameter fieldParameter)
    {
      if (Required) { fieldParameter.MakeRequired(); }

      if (IsNullable is not null) { fieldParameter.SetIsNullable(IsNullable.Value); }

      if (!string.IsNullOrEmpty(TypeName))
      {
        fieldParameter.SetTypeName(TypeName);
        fieldParameter.SetParamsTypeName(TypeName);
      }

      if (!string.IsNullOrEmpty(ParamName)) { fieldParameter.SetParamName(ParamName); }

      if (!string.IsNullOrEmpty(DefaultValue)) { fieldParameter.SetDefaultValue(DefaultValue); }

      if (!string.IsNullOrEmpty(CommentFmt))
      {
        fieldParameter.AddCommentFmt(
          new()
          {
            "<para>",
            CommentFmt,
            "</para>"
          });
      }

      if (!string.IsNullOrEmpty(AssignmentFmtRhs))
      {
        fieldParameter.SetAssignmentFmtRhs(AssignmentFmtRhs);
        fieldParameter.SetParamsAssignmentFmtRhs(AssignmentFmtRhs);
      }

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
    [JsonProperty]
    public string TypeName { get; private set; } = string.Empty;

    /// <summary>
    /// If set, replaces the type name for the parameter. Used when utility classes wrap an input parameter,
    /// e.g. ActionsBuilder in place of ActionList.
    /// </summary>
    [JsonProperty]
    public string TypeNameOverride { get; private set; } = string.Empty;

    /// <summary>
    /// If true, skips parameter validation.
    /// </summary>
    [JsonProperty]
    public bool SkipValidation { get; private set; } = true;

    /// <summary>
    /// Additional types to import (by name).
    /// </summary>
    public List<string> Imports { get; } = new();

    /// <summary>
    /// Parameter comment lines explaining usage of the type.
    /// </summary>
    public List<string> Comment { get; } = new();

    /// <summary>
    /// Overrides the right hand side of the assignment format statement.
    /// </summary>
    [JsonProperty]
    public string AssignmentFmtRhs { get; private set; } = string.Empty;

    /// <summary>
    /// Overrides the right hand side of the assignment format statement used when null.
    /// </summary>
    [JsonProperty]
    public string AssignmentIfNullRhs { get; private set; } = string.Empty;

    public override void ApplyTo(FieldParameter param)
    {
      ApplyTo(param, null, false);
    }

    public void ApplyTo(FieldParameter param, Type? enumerableType, bool isArray)
    {
      if (!string.IsNullOrEmpty(TypeNameOverride))
      {
        param.SetTypeName(TypeNameOverride);
        if (enumerableType is not null)
        {
          param.SetParamsTypeName(TypeNameOverride);
        }
      }
      if (SkipValidation) { param.SkipValidation(); }
      param.Imports.AddRange(Imports.Select(type => TypeTool.TypeByName(type)!));
      if (Comment.Any()) { param.AddCommentFmt(Comment); }
      if (!string.IsNullOrEmpty(AssignmentFmtRhs))
      {
        if (enumerableType is not null)
        {
          var assignment = $"{{0}}?.Select(entry => {string.Format(AssignmentFmtRhs, "entry")})";
          if (isArray)
          {
            assignment = $"{assignment}?.ToArray()";
          }
          else
          {
            assignment = $"{assignment}?.ToList()";
          }
          param.SetAssignmentFmtRhs(assignment);
          param.SetParamsAssignmentFmtRhs(assignment);
        }
        else
        {
          param.SetAssignmentFmtRhs(AssignmentFmtRhs);
        }
      }
      if (!string.IsNullOrEmpty(AssignmentIfNullRhs) && enumerableType is null)
      {
        param.SetAssignmentIfNullRhs(AssignmentIfNullRhs);
      }
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
    [JsonProperty]
    public string SourceTypeName { get; private set; } = string.Empty;

    /// <summary>
    /// Specifies whether the field is nullable.
    /// </summary>
    [JsonProperty]
    public bool IsNullable { get; private set; } = false;

    /// <summary>
    /// Overrides the name of the parameter.
    /// </summary>
    [JsonProperty]
    public string ParamName { get; private set; } = string.Empty;

    /// <summary>
    /// Overrides the default value of the parameter.
    /// </summary>
    [JsonProperty]
    public string DefaultValue { get; private set; } = string.Empty;

    public override void ApplyTo(FieldParameter param)
    {
      param.SetIsNullable(IsNullable);
      if (!string.IsNullOrEmpty(ParamName)) { param.SetParamName(ParamName); }
      if (!string.IsNullOrEmpty(DefaultValue)) { param.SetDefaultValue(DefaultValue); }
    }
  }

  /// <summary>
  /// Represents ComponentMerge parameter for unique components.
  /// </summary>
  public class ComponentMergeParameter : IParameterInternal
  {
    public bool Required { get; } = false;

    public string ParamName { get; } = "mergeBehavior";

    public List<Type> Imports { get; } = new();

    public List<string> Comment { get; } =
      new()
      {
        "<param name=\"mergeBehavior\">",
        "Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.",
        "</param>"
      };

    public string Declaration { get; } = "ComponentMerge mergeBehavior = ComponentMerge.Fail";

    public string ParamsDeclaration => throw new NotImplementedException();

    public List<string> GetOperation(string objectName, string validateFunction)
    {
      return new();
    }

    public List<string> GetParamsOperation(string objectName, string validateFunction)
    {
      throw new NotImplementedException();
    }
  }

  /// <summary>
  /// Represents merge lambda parameter for unique components.
  /// </summary>
  public class MergeParameter : IParameterInternal
  {
    public bool Required { get; } = false;

    public string ParamName { get; } = "merge";

    public List<Type> Imports { get; } = new() { typeof(Action), typeof(BlueprintComponent) };

    public List<string> Comment { get; } =
    new ()
      {
        "<param name=\"merge\">",
        "If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.",
        "</param>"
      };

    public string Declaration { get; } = "Action<BlueprintComponent, BlueprintComponent>? merge = null";

    public string ParamsDeclaration => throw new NotImplementedException();

    public List<string> GetOperation(string objectName, string validateFunction)
    {
      return new();
    }

    public List<string> GetParamsOperation(string objectName, string validateFunction)
    {
      throw new NotImplementedException();
    }
  }

  /// <summary>
  /// Represents an extra parameter applied to a method as an override.
  /// </summary>
  public class ExtraParameter : IParameterInternal
  {
    public List<Type> Imports => new();

    public List<string> Comment => GetComment();

    public string Declaration => Required ? $"{TypeName} {ParamName}" : $"{TypeName} {ParamName} = {DefaultValue}";

    public bool Required => string.IsNullOrEmpty(DefaultValue);

    [JsonProperty]
    public string ParamName { get; private set; } = string.Empty;

    public string ParamsDeclaration => throw new NotImplementedException();

    [JsonProperty]
    private readonly string? DefaultValue = string.Empty;

    [JsonProperty]
    private readonly string TypeName = string.Empty;

    /// <summary>
    /// Format string where {0} is the param name.
    /// </summary>
    [JsonProperty]
    private readonly string CommentFmt = string.Empty;

    /// <summary>
    /// Operation format string where {0} is the object name and {1} is the parameter name, and {2} is the
    /// validation function.
    /// </summary>
    [JsonProperty]
    private readonly List<string> OperationFmt = new();

    public List<string> GetOperation(string objectName, string validateFunction)
    {
      return OperationFmt.Select(line => string.Format(line, objectName, ParamName, validateFunction)).ToList();
    }

    private List<string> GetComment()
    {
      if (!string.IsNullOrEmpty(CommentFmt))
      {
        return new List<string>()
          .Append("<param name=\"{0}\">")
          .Append(CommentFmt)
          .Append("</param>")
          .Select(line => string.Format(line, ParamName))
          .ToList();
      }

      return new();
    }

    public List<string> GetParamsOperation(string objectName, string validateFunction)
    {
      throw new NotImplementedException();
    }
  }
}
