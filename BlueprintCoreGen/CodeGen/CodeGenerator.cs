using Kingmaker.ElementsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueprintCoreGen.CodeGen
{
  public static class CodeGenerator
  {
    public static Method CreateMethod(Type type)
    {
      if (type.IsSubclassOf(typeof(GameAction)))
      {
        return CreateBuilderMethod("ActionsBuilder", type);
      }
      return new(2);
    }

    private static Method CreateBuilderMethod(string builderType, Type type)
    {
      // Filter fields which are usually not required for instantiation.
      var fields =
          type.GetFields()
              .Where(field => !field.Name.Contains("__BackingField") && field.Name != "name")
              .Select(field => FieldProcessor.Process(field));

      Method method = new(2);
      method.AddImport(type);
      method.AddCommentSummary($"Adds <see cref=\"{type.Name}\"/> (Auto Generated)");
      method.AddAttribute($"[Generated]");
      method.AddAttribute($"[Implements(typeof({type.Name}))]");

      if (fields.Any())
      {
        method.AddDeclaration($"public static {builderType} Add{type.Name}(");
        method.AddParamDeclaration($"this {builderType} builder");

        foreach (var field in fields)
        {
          field.GetImports().ForEach(import => method.AddImport(import));

          method.AddComment(field.GetParamComment());
          method.AddParamDeclaration(field.GetParamDeclaration());

          field.GetValidation().ForEach(line => method.AddBodyLine($"{line}"));
        }
        method.CloseDeclaration();

        method.AddBodyLine("");
        method.AddBodyLine($"var element = ElementTool.Create<{type.Name}>();");
        foreach (var field in fields)
        {
          method.AddBodyLine($"element.{field.GetAssignment()}");
        }
        method.AddBodyLine($"return builder.Add(element);");
      }
      else
      {
        method.AddDeclaration($"public static {builderType} Add{type.Name}(this {builderType} builder)");
        method.AddBodyLine($"return builder.Add(ElementTool.Create<{type.Name}>());");
      }

      return method;
    }
  }

  /// <summary>
  /// Represents a generated method. Stores a list of imports needed and the method text, including comments.
  /// </summary>
  public class Method
  {
    private readonly List<string> Imports = new();
    private readonly StringBuilder Comment = new();
    private readonly StringBuilder Attributes = new();
    private readonly StringBuilder Declaration = new();
    private readonly StringBuilder Body = new();

    private readonly string BaseIndent;
    private bool HasRemark = false;
    private bool HasParam = false;

    public Method(int baseIndent)
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
