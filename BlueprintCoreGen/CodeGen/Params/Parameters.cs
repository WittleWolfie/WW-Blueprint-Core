using System;
using System.Collections.Generic;
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
  /// Extension of IParameter to support blueprint field parameters which may have Add and Remove operations.
  /// </summary>
  public interface IBlueprintParameter : IParameter
  {
    /// <summary>
    /// Parameter declaration when defined using params, e.g. params string[] names
    /// </summary>
    string ParamsDeclaration { get; }

    /// <summary>
    /// Comment summary for the set operation.
    /// </summary>
    string SetComment { get; }

    /// <summary>
    /// Comment summary for the add operation.
    /// </summary>
    string AddComment { get; }

    /// <summary>
    /// Returns a statement which uses the parameter to add values to a field on the object. The provided validation
    /// function is called on the parameter before use.
    /// </summary>
    List<string> GetAddOperation(string objectName, string validateFunction);

    /// <summary>
    /// Comment summary for the remove operation.
    /// </summary>
    string RemoveComment { get; }

    /// <summary>
    /// Returns a statement which uses the parameter to remove values from a field on the object. The provided
    /// validation function is called on the parameter before use.
    /// </summary>
    List<string> GetRemoveOperation(string objectName);

    /// <summary>
    /// Comment summary for the RemovePredicate operation.
    /// </summary>
    string RemovePredicateComment { get; }

    /// <summary>
    /// Returns a statement which uses the parameter to remove values matching a predicate from a field on the object.
    /// </summary>
    List<string> GetRemovePredicateOperation(string objectName, string predicateName);

    /// <summary>
    /// Comment summary for the Clear operation.
    /// </summary>
    string ClearComment { get; }

    /// <summary>
    /// Returns a statement which clears a field on the object.
    /// </summary>
    List<string> GetClearOperation(string objectName);

    /// <summary>
    /// Comment summary for the Modify operation.
    /// </summary>
    string ModifyComment { get; }

    /// <summary>
    /// Returns a statement which executes an action on all values in a field on the object.
    /// </summary>
    List<string> GetModifyOperation(string objectName, string actionName);
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
    protected string TypeName { get; set; }

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
    private List<string> ValidationFmt { get; set; } = new();

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

      if (!string.IsNullOrEmpty(validationFmt)) { ValidationFmt.Add(validationFmt); }
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
          .Select(line => line.Replace(@"{0}", ParamName))
          .ToList();
      }
      return CommentFmt;
    }

    protected virtual string GetDeclaration()
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
  public class BlueprintFieldParameter : FieldParameter, IBlueprintParameter
  {
    /// <summary>
    /// Type name used for ParamsDeclaration
    /// </summary>
    private string ParamsTypeName { get; }
    public string ParamsDeclaration => GetParamsDeclaration();

    public string SetComment { get; }

    public string AddComment { get; }

    /// <summary>
    /// Format string lines for adding content to the blueprint field where {0} is the object name and {1} is the
    /// parameter name.
    /// </summary>
    private List<string> AddOperationFmt { get; }

    public string RemoveComment { get; }

    /// <summary>
    /// Format string lines for removing content from the blueprint field where {0} is the object name and {1} is the
    /// parameter name.
    /// </summary>
    private List<string> RemoveOperationFmt { get; }

    public string RemovePredicateComment { get; }

    /// <summary>
    /// Format string lines for removing content from the blueprint field where {0} is the object name and {1} is the
    /// predicate name.
    /// </summary>
    private List<string> RemovePredicateOperationFmt { get; }

    public string ClearComment { get; }

    /// <summary>
    /// Format string lines for removing all content from the blueprint field where {0} is the object name.
    /// </summary>
    private List<string> ClearOperationFmt { get; }

    public string ModifyComment { get; }

    /// <summary>
    /// Format string lines for modifying content in the blueprint field where {0} is the object name, {1} is action
    /// name.
    /// </summary>
    private List<string> ModifyOperationFmt { get; }

    public BlueprintFieldParameter(
        string fieldName,
        string paramName,
        string typeName,
        string paramsTypeName,
        List<Type> imports,
        List<string> commentFmt,
        string defaultValue,
        string validationFmt,
        string setComment,
        string assignmentRhsFmt,
        string addComment,
        List<string> addOperationFmt,
        string removeComment,
        List<string> removeOperationFmt,
        string removePredicateComment,
        List<string> removePredicateOperationFmt,
        string clearComment,
        List<string> clearOperationFmt,
        string modifyComment,
        List<string> modifyOperationFmt)
      : base(
        fieldName,
        paramName,
        typeName,
        imports,
        commentFmt,
        defaultValue,
        validationFmt,
        assignmentRhsFmt,
        /* assignmentIfNullRhs= */string.Empty)
    {
      ParamsTypeName = paramsTypeName;
      SetComment = setComment;
      AddComment = addComment;
      AddOperationFmt = addOperationFmt;
      RemoveComment = removeComment;
      RemoveOperationFmt = removeOperationFmt;
      RemovePredicateComment = removePredicateComment;
      RemovePredicateOperationFmt = removePredicateOperationFmt;
      ClearComment = clearComment;
      ClearOperationFmt = clearOperationFmt;
      ModifyComment = modifyComment;
      ModifyOperationFmt = modifyOperationFmt;
      SetIsNullable(false);
    }

    private string GetParamsDeclaration()
    {
      return $"params {ParamsTypeName}[] {ParamName}";
    }

    public List<string> GetAddOperation(string objectName, string validateFunction)
    {
      return AddOperationFmt.Select(line => string.Format(line, objectName, ParamName)).ToList();
    }

    public List<string> GetRemoveOperation(string objectName)
    {
      return RemoveOperationFmt.Select(line => string.Format(line, objectName, ParamName)).ToList();
    }

    public List<string> GetRemovePredicateOperation(string objectName, string predicateName)
    {
      return RemovePredicateOperationFmt.Select(line => string.Format(line, objectName, predicateName)).ToList();
    }

    public List<string> GetClearOperation(string objectName)
    {
      return ClearOperationFmt.Select(line => string.Format(line, objectName)).ToList();
    }

    public List<string> GetModifyOperation(string objectName, string actionName)
    {
      return ModifyOperationFmt.Select(line => string.Format(line, objectName, actionName)).ToList();
    }
  }
}
