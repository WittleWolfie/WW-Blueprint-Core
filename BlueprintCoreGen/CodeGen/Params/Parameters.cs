using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

namespace BlueprintCoreGen.CodeGen.Params
{
  /// <summary>
  /// Represents a method input parameter in a constructor method. i.e. Parameters in builder methods and configurator
  /// component methods.
  /// </summary>
  public interface IParameter
  {
    /// <summary>
    /// List of types to import.
    /// </summary>
    List<Type> Imports { get; }

    /// <summary>
    /// Parameter comment
    /// </summary>
    List<string> Comment { get; }

    /// <summary>
    /// Parameter declaration, e.g. <c>string name</c>
    /// </summary>
    string Declaration { get; }

    /// <summary>
    /// Returns a statement which uses the parameter to operate on the object. Typically this is assigning the 
    /// parameter value to a field in the object. The provided validation function is called on the parameter before
    /// assignment.
    /// </summary>
    List<string> GetOperation(string objectName, string validateFunction);
  }

  /// <summary>
  /// Internal representation of a parameter used in ParametersFactory.
  /// </summary>
  public interface IParameterInternal : IParameter
  {
    /// <summary>
    /// If true the parameter is required and should be included in method parameter lists before optional parameters.
    /// </summary>
    bool Required { get; }

    /// <summary>
    /// Name of the parameter
    /// </summary>
    string ParamName { get; }
  }


  /// <summary>
  /// Internal representation of a parameter used to specify a field value.
  /// </summary>
  public class FieldParameter : IParameterInternal
  {
    /// <summary>
    /// If true the field should be ignored in method parameters.
    /// </summary>
    public bool Ignore { get; private set; } = false;

    public List<Type> Imports { get; }

    /// <summary>
    /// If true the declaration should be left out
    /// </summary>
    private bool SkipDeclaration = false;

    /// <summary>
    /// If true appends `?` to the type name
    /// </summary>
    private bool IsNullable = true;

    public List<string> Comment => GetComment();
    public string Declaration => GetDeclaration();

    private string FieldName { get; }
    public string ParamName { get; private set; }
    private string TypeName { get; set; }

    /// <summary>
    /// Comment format string where {0} is the parameter name
    /// </summary>
    private List<string> CommentFmt { get; set; }

    /// <summary>
    /// Default value for optional parameters
    /// </summary>
    private string? DefaultValue { get; set; }

    public bool Required => string.IsNullOrEmpty(DefaultValue);

    /// <summary>
    /// Validation format string where {0} is the validation function and {1} is the parameter name
    /// </summary>
    private List<string> ValidationFmt { get; set; }

    /// <summary>
    /// Assignment format string for the right hand side of an assignment statement, where {0} is the parameter name
    /// </summary>
    private string AssignmentFmtRhs { get; set; }

    /// <summary>
    /// Assignment string for the right hand side of an assignment statement if the field is null
    /// </summary>
    private string? AssignmentIfNullRhs { get; set; }

    /// <summary>
    /// Assignment format strings for additional lines of code after the assignment statement, where {0} is the
    /// object name and {1} is the parameter name
    /// </summary>
    private List<string> ExtraAssignmentFmtLines { get; set; }

    public FieldParameter(
        string fieldName,
        string paramName,
        string typeName,
        List<Type> imports,
        List<string> commentFmt,
        string defaultValue,
        string validationFmt,
        string assignmentRhsFmt,
        string assignmentIfNullRhs)
    {
      FieldName = fieldName;
      ParamName = paramName;
      TypeName = typeName;

      Imports = imports;
      CommentFmt = commentFmt;
      DefaultValue = defaultValue;

      ValidationFmt = new() { validationFmt };
      AssignmentFmtRhs = assignmentRhsFmt;
      AssignmentIfNullRhs = assignmentIfNullRhs;
      ExtraAssignmentFmtLines = new();
    }

    public void SetTypeName(string typeName)
    {
      TypeName = typeName;
    }

    public void SetIsNullable(bool isNullable)
    {
      IsNullable = isNullable;
    }

    public void MakeRequired()
    {
      IsNullable = false;
      DefaultValue = string.Empty;
      AssignmentIfNullRhs = string.Empty;
    }

    public void MakeIgnored()
    {
      Ignore = true;
    }

    public void SkipValidation()
    {
      ValidationFmt.Clear();
    }

    public void SetAssignmentFmtRhs(string assignmentFmtRhs)
    {
      AssignmentFmtRhs = assignmentFmtRhs;
    }

    public void SetAssignmentIfNullRhs(string assignmentIfNullRhs)
    {
      AssignmentIfNullRhs = assignmentIfNullRhs;
    }

    public void SetConstantValue(string value)
    {
      IsNullable = false;
      SkipDeclaration = true;
      AssignmentFmtRhs = value;
      AssignmentIfNullRhs = string.Empty;
    }

    public void SetDefaultValue(string value)
    {
      IsNullable = false;
      DefaultValue = value;
    }

    public void SetParamName(string paramName)
    {
      ParamName = paramName;
    }

    public void SetExtraAssignmentFmtLines(List<string> extraAssignmentFmtLines)
    {
      ExtraAssignmentFmtLines = extraAssignmentFmtLines;
    }

    public void AddCommentFmt(List<string> commentFmt)
    {
      CommentFmt.AddRange(commentFmt);
    }

    private List<string> GetComment()
    {
      if (CommentFmt.Any())
      {
        return CommentFmt.Prepend("<param name=\"{0}\">")
          .Append("</param>")
          .Select(line => string.Format(line, ParamName))
          .ToList();
      }
      return CommentFmt;
    }

    private string GetDeclaration()
    {
      if (SkipDeclaration) { return ""; }

      var declaration = IsNullable ? $"{TypeName}? {ParamName}" : $"{TypeName} {ParamName}";
      return string.IsNullOrEmpty(DefaultValue)
          ? declaration
          : $"{declaration} = {DefaultValue}";
    }

    public List<string> GetOperation(string objectName, string validateFunction)
    {
      List<string> assignment = new();
      assignment.AddRange(ValidationFmt.Select(line => string.Format(line, validateFunction, ParamName)));

      if (IsNullable)
      {
        assignment.Add(
            string.Format($"{objectName}.{FieldName} = {AssignmentFmtRhs} ?? {objectName}.{FieldName};", ParamName));
      }
      else
      {
        assignment.Add(string.Format($"{objectName}.{FieldName} = {AssignmentFmtRhs};", ParamName));
      }

      return assignment.Concat(GetExtraAssignmentLines(objectName)).Concat(GetAssignmentIfNull(objectName)).ToList();
    }

    private List<string> GetExtraAssignmentLines(string objectName)
    {
      if (!ExtraAssignmentFmtLines.Any())
      {
        return new();
      }

      return ExtraAssignmentFmtLines.Select(line => string.Format($"{line}", objectName, ParamName)).ToList();
    }

    private List<string> GetAssignmentIfNull(string objectName)
    {
      if (string.IsNullOrEmpty(AssignmentIfNullRhs))
      {
        return new();
      }

      List<string> assignmentIfNull = new();
      assignmentIfNull.Add($"if ({objectName}.{FieldName} is null)");
      assignmentIfNull.Add($"{{");
      assignmentIfNull.Add($"  {objectName}.{FieldName} = {AssignmentIfNullRhs};");
      assignmentIfNull.Add($"}}");
      return assignmentIfNull;
    }
  }

  /// <summary>
  /// Internal representation of a parameter used for a blueprint configurator field method.
  /// </summary>
  public class BlueprintFieldParameter : IParameterInternal
  {
    public List<Type> Imports { get; }

    /// <summary>
    /// Comment format string where {0} is the parameter name
    /// </summary>
    private List<string> CommentFmt { get; set; }
    public List<string> Comment => GetComment();

    /// <summary>
    /// If set, the parameter is declared using "params"
    /// </summary>
    private bool UseParams { get; set; }
    public string Declaration => GetDeclaration();

    /// <summary>
    /// Default value for optional parameters
    /// </summary>
    private string? DefaultValue { get; set; }
    public bool Required => string.IsNullOrEmpty(DefaultValue);

    public string ParamName { get; private set; }
    private string TypeName { get; set; }

    /// <summary>
    /// Operation format string where {0} is the object name and {1} is the parameter name 
    /// </summary>
    private string OperationFmt { get; set; }

    /// <summary>
    /// Validation format string where {0} is the validation function and {1} is the parameter name
    /// </summary>
    private string ValidationFmt { get; set; }

    /// <summary>
    /// Operation format strings for additional lines of code after the assignment statement, where {0} is the
    /// object name and {1} is the parameter name
    /// </summary>
    private List<string> ExtraOperationFmt { get; set; }

    public BlueprintFieldParameter(
      string paramName,
      string typeName,
      bool useParams,
      List<Type> imports,
      List<string> commentFmt,
      string defaultValue,
      string validationFmt,
      string operationFmt)
    {
      ParamName = paramName;
      TypeName = typeName;
      UseParams = useParams;

      Imports = imports;
      CommentFmt = commentFmt;
      DefaultValue = defaultValue;

      ValidationFmt = validationFmt;
      OperationFmt = operationFmt;
      ExtraOperationFmt = new();
    }

    private List<string> GetComment()
    {
      if (CommentFmt.Any())
      {
        return CommentFmt.Prepend("<param name=\"{0}\">")
          .Append("</param>")
          .Select(line => string.Format(line, ParamName))
          .ToList();
      }
      return CommentFmt;
    }

    private string GetDeclaration()
    {
      if (UseParams)
      {
        return $"params {TypeName}[] {ParamName}";
      }

      var declaration = $"{TypeName} {ParamName}";
      return string.IsNullOrEmpty(DefaultValue)
          ? declaration
          : $"{declaration} = {DefaultValue}";
    }

    public List<string> GetOperation(string objectName, string validateFunction)
    {
      List<string> operation = new();
      operation.Add(string.Format(ValidationFmt, validateFunction, ParamName));
      operation.Add(string.Format(OperationFmt, objectName, ParamName));
      operation.AddRange(ExtraOperationFmt.Select(line => string.Format(line, objectName, ParamName)));
      return operation;
    }
  }
}
