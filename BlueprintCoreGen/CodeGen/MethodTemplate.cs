using System;
using System.Collections.Generic;
using System.Text;

namespace BlueprintCoreGen.CodeGen
{
  /// <summary>
  /// Represents a generated method. Stores a list of imports needed and the method text, including comments.
  /// </summary>
  public class MethodTemplate
  {
    private readonly List<string> Imports = new();
    private readonly StringBuilder Comment = new();
    private readonly StringBuilder Attributes = new();
    private readonly StringBuilder Declaration = new();
    private readonly StringBuilder Body = new();

    private readonly string BaseIndent;
    private bool HasRemark = false;
    private bool HasParam = false;

    public MethodTemplate(int baseIndent)
    {
      BaseIndent = Tab(baseIndent);
    }

    public List<string> GetImports()
    {
      return Imports;
    }

    public string GetText()
    {
      return $"\n{Comment}{Attributes}{Declaration}{BaseIndent}{{\n{Body}{BaseIndent}}}";
    }

    public void AddCommentSummary(string summary)
    {
      Comment.AppendLine($"{BaseIndent}/// <summary>");
      Comment.AppendLine($"{BaseIndent}/// {summary}");
      Comment.AppendLine($"{BaseIndent}/// </summary>");
    }

    public void AddComment(string comment)
    {
      if (comment == null) return;
      if (!HasRemark)
      {
        Comment.AppendLine($"{BaseIndent}///");
        HasRemark = true;
      }
      Comment.AppendLine($"{BaseIndent}/// {comment}");
    }

    public void AddAttribute(string attribute)
    {
      Attributes.AppendLine($"{BaseIndent}{attribute}");
    }

    public void AddDeclaration(string declaration)
    {
      Declaration.AppendLine($"{BaseIndent}{declaration}");
    }

    public void AddParamDeclaration(string declaration)
    {
      if (!HasParam)
      {
        Declaration.Append($"{BaseIndent}    {declaration}");
        HasParam = true;
      }
      else
      {
        Declaration.Append($",\n{BaseIndent}    {declaration}");
      }
    }

    public void CloseDeclaration()
    {
      Declaration.AppendLine(")");
    }

    public void AddImport(Type type)
    {
      Imports.Add($"using {type.Namespace};");
    }

    public void AddBodyLine(string line)
    {
      Body.AppendLine($"{BaseIndent}  {line}");
    }

    private static string Tab(int indent)
    {
      return new string(' ', 2 * indent);
    }
  }
}
