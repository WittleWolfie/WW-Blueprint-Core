//using BlueprintCore.Utils;
//using Kingmaker.Blueprints;
//using Kingmaker.ElementsSystem;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace BlueprintCoreGen.CodeGen
//{

//  public class OldMethodFactory
//  {

//    /// <summary>
//    /// Creates methods for modifying blueprint fields.
//    /// </summary>
//    public static List<IMethod> CreateForBlueprintField(Type blueprintType, IField field, string returnType)
//    {
//      var blueprintTypeName = TypeTool.GetName(blueprintType);
//      List<IMethod> methods = new() { GetSetField(field, returnType, blueprintTypeName) };
//      if (field is IEnumerableField)
//      {
//        var enumerableField = field as IEnumerableField;
//        methods.Add(GetModifyField(enumerableField!, returnType, blueprintTypeName, addTo: true));
//        methods.Add(GetModifyField(enumerableField!, returnType, blueprintTypeName));
//      }
//      return methods;
//    }

//    private static IMethod GetSetField(IField field, string returnType, string blueprintType, bool isEnumerable = false)
//    {
//      var method = new Method();
//      method.AddImports(field.Imports.ToList());

//      AddComments(method, "Sets", $"{blueprintType}.{field.Name}", field.Comment);
//      AddAttributes(method);

//      method.AddLine($"public {returnType} {GetMethodName("Set", field.MethodName)}({field.TypeName} {field.ParamName})");
//      method.AddLine($"{{");

//      if (field.ShouldValidate)
//      {
//        AddValidation(method, field, ConfiguratorValidationMethod);
//        method.AddLine("");
//      }

//      AddOnConfigure(method, field.GetAssignment("bp"));
//      method.AddLine($"}}");
//      return method;
//    }

//    private static IMethod GetModifyField(
//        IEnumerableField field, string returnType, string blueprintType, bool addTo = false)
//    {
//      var method = new Method();
//      method.AddImports(field.Imports.ToList());

//      AddComments(method, addTo ? "Adds to" : "Removes from", $"{blueprintType}.{field.Name}", field.Comment);
//      AddAttributes(method);

//      var methodName = GetMethodName(addTo ? "AddTo" : "RemoveFrom", field.MethodName);
//      method.AddLine($"public {returnType} {methodName}(params {field.EnumerableTypeName}[] {field.ParamName})");
//      method.AddLine($"{{");

//      if (field.ShouldValidate)
//      {
//        AddValidation(method, field, ConfiguratorValidationMethod);
//      }

//      AddOnConfigure(method, addTo ? field.GetAddTo("bp") : field.GetRemoveFrom("bp"));
//      method.AddLine($"}}");
//      return method;
//    }

//    private static readonly List<string> empty = new();
//    private static void AddComments(Method method, string actionType, string targetType, string paramComment)
//    {
//      AddComments(method, actionType, targetType, paramComment is null ? empty : new() { paramComment });
//    } 

//    private static void AddComments(
//        Method method, string actionType, string targetType, List<string> paramComments)
//    {
//      method.AddLine($"/// <summary>");
//      method.AddLine($"/// {actionType} <see cref=\"{targetType}\"/> (Auto Generated)");
//      method.AddLine($"/// </summary>");

//      if (paramComments.Any())
//      {
//        method.AddLine($"///");
//        paramComments.ForEach(comment => method.AddLine($"/// {comment}"));
//      }
//    }

//    private static void AddAttributes(Method method, string? implementedType = null)
//    {
//      method.AddLine($"");
//      if (implementedType is not null)
//      {
//        method.AddLine($"");
//      }
//    }

//    private static string GetMethodName(string prefix, string typeName)
//    {
//      if (typeName.StartsWith(prefix))
//      {
//        return typeName;
//      }
//      return $"{prefix}{typeName}";
//    }

//    private static void AddValidation(Method method, List<IField> fields, string validationMethod)
//    {
//      bool hasValidation = false;
//      fields.ForEach(
//          field =>
//          {
//            if (field.ShouldValidate)
//            {
//              hasValidation = true;
//              AddValidation(method, field, validationMethod);
//            }
//          });
//      if (hasValidation) { method.AddLine(""); }
//    }

//    private static void AddValidation(Method method, IField field, string validateFunction)
//    {
//      method.AddLine($"  {validateFunction}({field.ParamName});");
//    }

//    private static void AddOnConfigure(Method method, List<string> onConfigureBody)
//    {
//      method.AddLine($"  return OnConfigureInternal(");
//      method.AddLine($"      bp =>");
//      method.AddLine($"      {{");
//      onConfigureBody.ForEach(line => method.AddLine($"        {line}"));
//      method.AddLine($"      }});");
//    }

//    private class Method : IMethod
//    {
//      private readonly HashSet<string> Imports = new();
//      private readonly List<string> Text = new();

//      public List<string> GetImports()
//      {
//        return Imports.ToList();
//      }

//      public List<string> GetText()
//      {
//        return Text;
//      }

//      public void AddImports(List<Type> imports)
//      {
//        imports.ForEach(import => AddImport(import.Namespace));
//      }

//      public void AddImport(Type import)
//      {
//        AddImport(import.Namespace);
//      }

//      private void AddImport(string? typeNamespace)
//      {
//        // Skip type defined in the global namespace
//        if (!string.IsNullOrEmpty(typeNamespace))
//        {
//          Imports.Add($"using {typeNamespace};");
//        }
//      }

//      public void AddLine(string line)
//      {
//        Text.Add(line);
//      }
//    }
//  }
//}
