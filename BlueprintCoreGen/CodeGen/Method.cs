using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlueprintCoreGen.CodeGen
{
  /// <summary>
  /// Represents a method for code generation.
  /// </summary>
  public interface IMethod
  {
    /// <summary>
    /// A list of types that need to be imported for the method.
    /// </summary>
    List<Type> GetImports();

    /// <summary>
    /// Returns the method implementation as text.
    /// </summary>
    List<string> GetText();
  }

  public class MethodFactory
  {
    /// <summary>
    /// Creates methods for modifying blueprint fields.
    /// </summary>
    public static List<IMethod> CreateMethodsForField(IField field, string returnType)
    {
      List<IMethod> methods = new() { GetSetField(field, returnType) };
      if (field is IEnumerableField)
      {
        var enumerableField = field as IEnumerableField;
        methods.Add(GetModifyField(enumerableField, returnType, addTo: true));
        methods.Add(GetModifyField(enumerableField, returnType));
      }
      return methods;
    }

    private static IMethod GetSetField(IField field, string returnType, bool isEnumerable = false)
    {
      var method = new Method();
      method.AddImports(field.Imports.ToList());

      AddComments(method, field);
      AddFieldMethodAttributes(method);

      method.AddLine($"public {returnType} Set{field.MethodName}({field.TypeName} {field.ParamName})");
      method.AddLine($"{{");

      AddValidation(method, field, isEnumerable);
      AddOnConfigure(method, field.GetAssignment("bp"));

      method.AddLine($"  return Self;");
      method.AddLine($"}}");

      return method;
    }

    private static IMethod GetModifyField(IEnumerableField field, string returnType, bool addTo = false)
    {
      var method = new Method();
      method.AddImports(field.Imports.ToList());

      AddComments(method, field);
      AddFieldMethodAttributes(method);

      var prefix = addTo ? "AddTo" : "RemoveFrom";
      method.AddLine($"public {returnType} {prefix}{field.MethodName}(params {field.EnumerableTypeName}[] {field.ParamName})");
      method.AddLine($"{{");

      AddValidation(method, field, isEnumerable: true);
      AddOnConfigure(method, addTo ? field.GetAddTo("bp") : field.GetRemoveFrom("bp"));

      method.AddLine($"  return Self;");
      method.AddLine($"}}");

      return method;
    }

    private static void AddComments(Method method, IField field)
    {
      method.AddLine($"/// <summary>");
      method.AddLine($"/// Sets <see cref=\"\"/> (Auto Generated)");
      method.AddLine($"/// </summary>");

      if (field.Comment is not null)
      {
        method.AddLine($"///");
        method.AddLine($"/// {field.Comment}");
      }
    }

    private static void AddFieldMethodAttributes(Method method)
    {
      method.AddLine($"[Generated]");
    }

    private static void AddValidation(Method method, IField field, bool isEnumerable)
    {
      if (field.ShouldValidate)
      {
        if (isEnumerable)
        {
          method.AddLine($"  foreach (var item in {field.ParamName}) {{ ValidateParam(item); }}");
        }
        else
        {
          method.AddLine($"  ValidateParam({field.ParamName});");
        }
        method.AddLine("");
      }
    }

    private static void AddOnConfigure(Method method, List<string> onConfigureBody)
    {
      method.AddLine($"  return OnConfigureInternal(");
      method.AddLine($"      bp =>");
      method.AddLine($"      {{");
      onConfigureBody.ForEach(line => method.AddLine($"        {line}"));
      method.AddLine($"      }});");
    }

    private class Method : IMethod
    {
      private readonly HashSet<Type> Imports = new();
      private readonly List<string> Text = new();

      public List<Type> GetImports()
      {
        return Imports.ToList();
      }

      public List<string> GetText()
      {
        return Text;
      }

      public void AddImports(List<Type> imports)
      {
        imports.ForEach(import => Imports.Add(import));
      }

      public void AddLine(string line)
      {
        Text.Add(line);
      }
    }
  }
}
