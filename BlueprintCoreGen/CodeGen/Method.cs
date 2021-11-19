using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.ElementsSystem;
using System;
using System.Collections.Generic;
using System.Linq;

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
    List<string> GetImports();

    /// <summary>
    /// Returns the method implementation as text.
    /// </summary>
    List<string> GetText();
  }

  /// <summary>
  /// Represents a method constructed from text in a template file.
  /// </summary>
  public class RawMethod : IMethod
  {
    private readonly List<string> Imports;
    private readonly List<string> Text = new();

    public RawMethod(List<string> imports)
    {
      Imports = imports;
    }

    public void AddLine(string line)
    {
      Text.Add(line);
    }

    public List<string> GetImports()
    {
      return Imports;
    }

    public List<string> GetText()
    {
      return Text;
    }
  }

  public class MethodFactory
  {
    private enum BuilderType
    {
      ActionsBuilder,
      ConditionsBuilder
    }

    private static readonly string BuilderValidationMethod = "builder.Validate";
    private static readonly string ConfiguratorValidationMethod = "ValidateParam";

    /// <summary>
    /// Creates a method for adding an Element to a Builder
    /// </summary>
    public static IMethod CreateForBuilder(Type elementType)
    {
      var builderType =
          elementType.IsSubclassOf(typeof(GameAction)) ? BuilderType.ActionsBuilder : BuilderType.ConditionsBuilder; 
      var elementTypeName = TypeTool.GetName(elementType);
      var fields =
          elementType.GetFields()
              .Select(field => FieldFactory.Create(field, builderType == BuilderType.ConditionsBuilder))
              .Where(field => field is not null)
              .ToList();

      var method = new Method();
      method.AddImport(elementType);
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
        method.AddLine($"public static {builderType} {elementTypeName}(this {builderType} builder)");
        method.AddLine($"{{");
        method.AddLine($"  return builder.Add(ElementTool.Create<{elementTypeName}>());");
        method.AddLine($"}}");
        return method;
      }

      method.AddLine($"public static {builderType} {elementTypeName}(");
      method.AddLine($"    this {builderType} builder,");

      AddParamDeclarations(method, fields);
      method.AddLine($"{{");

      AddValidation(method, fields, BuilderValidationMethod);

      method.AddLine($"  var element = ElementTool.Create<{elementTypeName}>();");
      fields.ForEach(field => field.GetAssignment("element").ForEach(assignment => method.AddLine($"  {assignment}")));

      method.AddLine($"  return builder.Add(element);");
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

    /// <summary>
    /// Creates a method for adding a blueprint component.
    /// </summary>
    public static IMethod CreateForBlueprintComponent(Type componentType)
    {
      var componentTypeName = TypeTool.GetName(componentType);
      var fields =
          componentType.GetFields()
              .Select(field => FieldFactory.Create(field))
              .Where(field => field is not null)
              .ToList();

      var method = new Method();
      method.AddImport(componentType);
      fields.ForEach(field => method.AddImports(field.Imports.ToList()));

      AddComments(
          method,
          "Adds",
          componentTypeName,
          fields.Select(field => field.Comment).Where(comment => comment is not null).ToList());
      AddAttributes(method, componentTypeName);

      if (!fields.Any())
      {
        method.AddLine($"public TBuilder {GetMethodName("Add", componentTypeName)}()");
        method.AddLine($"{{");
        method.AddLine($"  return AddComponent(new {componentTypeName}());");
        method.AddLine($"}}");
        return method;
      }

      method.AddLine($"public TBuilder {GetMethodName("Add", componentTypeName)}(");
      AddParamDeclarations(method, fields);
      method.AddLine($"{{");

      AddValidation(method, fields, ConfiguratorValidationMethod);

      method.AddLine($"  var component = new {componentTypeName}();");
      fields.ForEach(field => field.GetAssignment("component").ForEach(assignment => method.AddLine($"  {assignment}")));

      method.AddLine($"  return AddComponent(component);");
      method.AddLine($"}}");
      return method;
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
        AddValidation(method, field, ConfiguratorValidationMethod);
        method.AddLine("");
      }

      AddOnConfigure(method, field.GetAssignment("bp"));
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
        AddValidation(method, field, ConfiguratorValidationMethod);
      }

      AddOnConfigure(method, addTo ? field.GetAddTo("bp") : field.GetRemoveFrom("bp"));
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

    private static string GetMethodName(string prefix, string typeName)
    {
      if (typeName.StartsWith(prefix))
      {
        return typeName;
      }
      return $"{prefix}{typeName}";
    }

    private static void AddValidation(Method method, List<IField> fields, string validationMethod)
    {
      bool hasValidation = false;
      fields.ForEach(
          field =>
          {
            if (field.ShouldValidate)
            {
              hasValidation = true;
              AddValidation(method, field, validationMethod);
            }
          });
      if (hasValidation) { method.AddLine(""); }
    }

    private static void AddValidation(Method method, IField field, string validateFunction)
    {
      method.AddLine($"  {validateFunction}({field.ParamName});");
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
      private readonly HashSet<string> Imports = new();
      private readonly List<string> Text = new();

      public List<string> GetImports()
      {
        return Imports.ToList();
      }

      public List<string> GetText()
      {
        return Text;
      }

      public void AddImports(List<Type> imports)
      {
        imports.ForEach(import => AddImport(import.Namespace));
      }

      public void AddImport(Type import)
      {
        AddImport(import.Namespace);
      }

      private void AddImport(string typeNamespace)
      {
        // Skip type defined in the global namespace
        if (!string.IsNullOrEmpty(typeNamespace))
        {
          Imports.Add($"using {typeNamespace};");
        }
      }

      public void AddLine(string line)
      {
        Text.Add(line);
      }
    }
  }
}
