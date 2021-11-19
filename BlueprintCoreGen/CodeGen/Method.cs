using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
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
    /// Creates a method for adding an Action to an ActionsBuilder
    /// </summary>
    public static IMethod CreateForActionsBuilder(Type elementType)
    {
      var elementTypeName = TypeTool.GetName(elementType);
      var fields =
          elementType.GetFields()
              .Select(field => FieldFactory.Create(field))
              .Where(field => field is not null)
              .ToList();

      var method = new Method();
      method.AddImport(typeof(ActionsBuilder));
      method.AddImport(typeof(ElementTool));
      fields.ForEach(field => method.AddImports(field.Imports.ToList()));

      AddComments(
          method,
          "Adds",
          elementTypeName,
          fields.Select(field => field.Comment).Where(comment => comment is not null).ToList());
      AddAttributes(method, elementTypeName);

      if (!fields.Any())
      {
        method.AddLine($"public static ActionsBuilder {GetMethodName("Add", elementTypeName)}(this ActionsBuilder builder)");
        method.AddLine($"{{");
        method.AddLine($"  return builder.Add(ElementTool.Create<{elementTypeName}>();");
        method.AddLine($"}}");
        return method;
      }

      method.AddLine($"public static ActionsBuilder {GetMethodName("Add", elementTypeName)}(");
      method.AddLine($"    this ActionsBuilder builder,");

      AddParamDeclarations(method, fields);
      method.AddLine($"{{");

      AddValidation(method, fields);

      method.AddLine($"  var action = ElementTool.Create<{elementTypeName}>();");

      fields.ForEach(field => field.GetAssignment("action").ForEach(assignment => method.AddLine($"  {assignment}")));

      method.AddLine($"  return builder.Add(action);");
      method.AddLine($"}}");
      return method;
    }

    private static void AddParamDeclarations(Method method, List<IField> fields)
    {
      List<string> declarations =
          fields
              .Where(field => field.DefaultValue is null)
              .Select(field => $"{field.TypeName} {field.ParamName}")
              .Concat(
                  // Optional fields are last
                  fields
                      .Where(field => field.DefaultValue is not null)
                      .Select(field => $"{field.TypeName} {field.ParamName} = {field.DefaultValue}"))
              .ToList();
      declarations.SkipLast(1).ToList().ForEach(decl => method.AddLine($"    {decl},"));
      method.AddLine($"    {declarations.Last()})");
    }

    private static void AddValidation(Method method, List<IField> fields)
    {
      bool hasValidation = false;
      fields.ForEach(
          field =>
          {
            if (field.ShouldValidate)
            {
              hasValidation = true;
              AddValidation(method, field, field is IEnumerableField);
            }
          });
      if (hasValidation) { method.AddLine(""); }
    }

    /// <summary>
    /// Creates methods for modifying blueprint fields.
    /// </summary>
    public static List<IMethod> CreateForBlueprintField(Type blueprintType, IField field, string returnType)
    {
      var blueprintTypeName = TypeTool.GetName(blueprintType);
      List<IMethod> methods = new() { GetSetField(field, returnType, blueprintTypeName) };
      if (field is IEnumerableField)
      {
        var enumerableField = field as IEnumerableField;
        methods.Add(GetModifyField(enumerableField, returnType, blueprintTypeName, addTo: true));
        methods.Add(GetModifyField(enumerableField, returnType, blueprintTypeName));
      }
      return methods;
    }

    private static IMethod GetSetField(IField field, string returnType, string blueprintType, bool isEnumerable = false)
    {
      var method = new Method();
      method.AddImports(field.Imports.ToList());

      AddComments(method, "Sets", $"{blueprintType}.{field.Name}", field.Comment);
      AddAttributes(method);

      method.AddLine($"public {returnType} {GetMethodName("Set", field.MethodName)}({field.TypeName} {field.ParamName})");
      method.AddLine($"{{");

      if (field.ShouldValidate)
      {
        AddValidation(method, field, isEnumerable);
        method.AddLine("");
      }

      AddOnConfigure(method, field.GetAssignment("bp"));

      method.AddLine($"  return Self;");
      method.AddLine($"}}");
      return method;
    }

    private static IMethod GetModifyField(
        IEnumerableField field, string returnType, string blueprintType, bool addTo = false)
    {
      var method = new Method();
      method.AddImports(field.Imports.ToList());

      AddComments(method, addTo ? "Adds to" : "Removes from", $"{blueprintType}.{field.Name}", field.Comment);
      AddAttributes(method);

      var methodName = GetMethodName(addTo ? "AddTo" : "RemoveFrom", field.MethodName);
      method.AddLine($"public {returnType} {methodName}(params {field.EnumerableTypeName}[] {field.ParamName})");
      method.AddLine($"{{");

      if (field.ShouldValidate)
      {
        AddValidation(method, field, isEnumerable: true);
      }

      AddOnConfigure(method, addTo ? field.GetAddTo("bp") : field.GetRemoveFrom("bp"));

      method.AddLine($"  return Self;");
      method.AddLine($"}}");

      return method;
    }

    private static readonly List<string> empty = new();
    private static void AddComments(Method method, string actionType, string targetType, string paramComment)
    {
      AddComments(method, actionType, targetType, paramComment is null ? empty : new() { paramComment });
    } 

    private static void AddComments(
        Method method, string actionType, string targetType, List<string> paramComments)
    {
      method.AddLine($"/// <summary>");
      method.AddLine($"/// {actionType} <see cref=\"{targetType}\"/> (Auto Generated)");
      method.AddLine($"/// </summary>");

      if (paramComments.Any())
      {
        method.AddLine($"///");
        paramComments.ForEach(comment => method.AddLine($"/// {comment}"));
      }
    }

    private static void AddAttributes(Method method, string implementedType = null)
    {
      method.AddLine($"[Generated]");
      if (implementedType is not null)
      {
        method.AddLine($"[Implements(typeof({implementedType}))]");
      }
    }

    private static string GetMethodName(string prefix, string methodName)
    {
      if (methodName.StartsWith(prefix))
      {
        return methodName.Remove(0, prefix.Length);
      }
      return methodName;
    }

    private static void AddValidation(Method method, IField field, bool isEnumerable)
    {
      if (isEnumerable)
      {
        method.AddLine($"  foreach (var item in {field.ParamName}) {{ ValidateParam(item); }}");
      }
      else
      {
        method.AddLine($"  ValidateParam({field.ParamName});");
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

      public void AddImport(Type import)
      {
        Imports.Add(import);
      }

      public void AddLine(string line)
      {
        Text.Add(line);
      }
    }
  }
}
