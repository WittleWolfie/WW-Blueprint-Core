using System;
using System.Collections.Generic;
using System.Text;

namespace BlueprintCoreGen.CodeGen
{
  public interface IMethod
  {
    List<string> GetImports();

    string GetText();
  }

  /// <summary>
  /// Represents a generated method. Stores a list of imports needed and the method text, including comments.
  /// </summary>
  public class MethodTemplate : IMethod
  {
    protected readonly List<string> Imports = new();
    protected readonly StringBuilder Comment = new();
    protected readonly StringBuilder Attributes = new();
    protected readonly StringBuilder Declaration = new();
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
      return $"{Comment}{Attributes}{Declaration}{BaseIndent}{{\n{Body}{BaseIndent}}}\n";
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
      // Skip type defined in the global namespace
      if (!string.IsNullOrEmpty(type.Namespace))
      {
        Imports.Add($"using {type.Namespace};");
      }
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

  /// <summary>
  /// Used when processing component template methods which are built on text representations rather than dynamic code.
  /// </summary>
  public class RawMethodTemplate : IMethod
  {
    private readonly List<string> Imports;
    private readonly StringBuilder Text = new();

    public RawMethodTemplate(List<string> imports)
    {
      Imports = imports;
    }

    public List<string> GetImports()
    {
      return Imports;
    }

    public string GetText()
    {
      return Text.ToString();
    }

    public void AddLine(string line)
    {
      Text.AppendLine(line);
    }
  }
}
