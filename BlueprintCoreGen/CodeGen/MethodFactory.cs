using BlueprintCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCoreGen.CodeGen
{
  public static class NewMethodFactory
  {
    public static List<INewMethod> CreateForBuilder(Type elementType, string builderType)
    {
      var elementTypeName = TypeTool.GetName(elementType);
      var fields = FieldFactory.CreateFieldParameters(elementType);

      var method = new MethodImpl();
      method.AddImport(elementType);
      method.AddImport(typeof(ElementTool));
      fields.ForEach(field => field.Imports.ForEach(import => method.AddImport(import)));

      // Comments
      method.AddLine($"/// <summary>");
      method.AddLine($"/// Adds <see cref=\"{elementTypeName}\"/>");
      method.AddLine($"/// </summary>");
      // TODO: Remarks

      var paramComments = fields.Select(field => field.Comment).Where(comment => comment is not null).ToList();
      if (paramComments.Any())
      {
        method.AddLine($"///");
        paramComments.ForEach(comment => method.AddLine($"/// {comment}"));
      }

      if (!fields.Any())
      {
        method.AddLine($"public static {builderType} {elementTypeName}(this {builderType} builder)");
        method.AddLine($"{{");
        method.AddLine($"  return builder.Add(ElementTool.Create<{elementTypeName}>());");
        method.AddLine($"}}");
        return new() { method };
      }

      // Declaration
      method.AddLine($"public static {builderType} {elementTypeName}(");
      method.AddLine($"    this {builderType} builder,");

      var paramDeclarations =
          fields
              .Where(field => field.DefaultValue is null)
              .Select(field => $"{field.TypeName} {field.ParamName}")
              .Concat(
                  // Optional params
                  fields
                      .Where(field => field.DefaultValue is not null)
                      .Select(field => $"{field.TypeName} {field.ParamName} = {field.DefaultValue}"));
      paramDeclarations.SkipLast(1).ToList().ForEach(declaration => method.AddLine($"    {declaration},"));
      method.AddLine($"    {paramDeclarations.Last()})");
      method.AddLine($"{{");

      var paramValidations =
          fields.Select(field => field.GetValidation("builder.Validate")).Where(validation => validation.Any());
      paramValidations.ToList().ForEach(validation => validation.ForEach(line => method.AddLine($"  {validation}")));
      if (paramValidations.Any()) { method.AddLine($""); }

      // Constructor & assignment
      method.AddLine($"  var element = ElementTool.Create<{elementTypeName}>();");
      fields.ForEach(field => field.GetAssignment("element").ForEach(line => method.AddLine($"  {line}")));

      // Return
      method.AddLine($"  return builder.Add(element);");
      method.AddLine($"}}");

      return new() { method };
    }

    private class MethodImpl : INewMethod
    {
      private readonly List<Type> Imports = new();
      private readonly List<string> Lines = new();

      public List<Type> GetImports()
      {
        return Imports;
      }

      public List<string> GetLines()
      {
        return Lines;
      }

      public void AddImport(Type type)
      {
        Imports.Add(type);
      }

      public void AddLine(string line)
      {
        Lines.Add(line);
      }
    }
  }
}
