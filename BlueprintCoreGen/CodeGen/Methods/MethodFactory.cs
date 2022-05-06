using BlueprintCore.Utils;
using BlueprintCoreGen.CodeGen.Class;
using BlueprintCoreGen.CodeGen.Overrides.Examples;
using BlueprintCoreGen.CodeGen.Params;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BlueprintCoreGen.CodeGen.Methods
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
    /// Returns the method implementation as lines of text.
    /// </summary>
    List<string> GetLines();
  }

  // TODO: Create Blueprint field methods
  // TODO: Add config overrides for components & fields
  public static class MethodFactory
  {
    public static List<IMethod> CreateForField(FieldInfo field, FieldMethod fieldMethod, string returnType)
    {
      List<IMethod> methods = new List<IMethod>();

      if (!fieldMethod.Methods.Any())
      {
        methods.Add(null);
        return methods;
      }

      foreach (var methodOverride in fieldMethod.Methods)
      {
        methods.Add(null);
      }
      return methods;
    }

    public static List<IMethod> CreateForComponent(
      Type componentType, ConstructorMethod componentMethod, string returnType)
    {
      List<IMethod> methods = new();

      if (!componentMethod.Methods.Any())
      {
        methods.Add(CreateForComponent(componentType, componentMethod, returnType, componentMethod));
        return methods;
      }

      foreach (var methodOverride in componentMethod.Methods)
      {
        methods.Add(
          CreateForComponent(
            componentType, componentMethod, returnType, MethodOverride.Merge(componentMethod, methodOverride)));
      }
      return methods;
    }

    private static readonly ComponentMergeParameter ComponentMergeParam = new();
    private static readonly MergeParameter MergeParam = new();
    private static IMethod CreateForComponent(
      Type componentType, ConstructorMethod componentMethod, string returnType, MethodOverride methodOverride)
    {
      var method = new MethodImpl();
      var componentTypeName = TypeTool.GetName(componentType);
      var isUnique = componentType.GetCustomAttribute<AllowMultipleComponentsAttribute>() is not null;
      var parameters =
        isUnique
          ? ParametersFactory.CreateForConstructor(componentType, methodOverride, ComponentMergeParam, MergeParam)
          : ParametersFactory.CreateForConstructor(componentType, methodOverride);

      // Imports
      method.AddImport(componentType);
      method.AddParameterImports(parameters);
      method.AddTypeNameImports(methodOverride.Imports);

      // Comment summary
      method.AddCommentSummary($"Adds <see cref=\"{componentTypeName}\"/>");

      // Remarks & Examples
      method.AddRemarks(componentType, methodOverride.Remarks);

      // Parameter comments
      method.AddParameterComments(parameters);

      var methodName =
        string.IsNullOrEmpty(methodOverride.MethodName)
          ? GetComponentMethodName(componentTypeName)
          : methodOverride.MethodName;
      if (!parameters.Any())
      {
        method.AddLine($"public {returnType} {methodName}()");
        method.AddLine(@"{");
        if (isUnique)
        {
          method.AddLine($"  return AddUniqueComponent(new {componentTypeName}(), mergeBehavior, merge);");
        }
        else
        {
          method.AddLine($"  return AddComponent(new {componentTypeName}());");
        }
        method.AddLine(@"}");
        return method;
      }

      // Declarations
      var declarations =
          parameters.Select(field => field.Declaration).Where(declaration => !string.IsNullOrEmpty(declaration));
      if (!declarations.Any())
      {
        method.AddLine($"public {returnType} {methodName}()");
      }
      else
      {
        method.AddLine($"public {returnType} {methodName}(");
        declarations.SkipLast(1).ToList().ForEach(declaration => method.AddLine($"    {declaration},"));
        method.AddLine($"    {declarations.Last()})");
      }
      method.AddLine(@"{");

      // Constructor & assignment
      if (string.IsNullOrEmpty(componentMethod.ConstructorRhs))
      {
        method.AddLine($"  var component = new {componentTypeName}();");
      }
      else
      {
        method.AddLine($"  var component = {componentMethod.ConstructorRhs};");
      }
      parameters.SelectMany(field => field.GetOperation("component", "Validate"))
        .Where(line => !string.IsNullOrEmpty(line))
        .ToList()
        .ForEach(line => method.AddLine($"  {line}"));

      // Extra lines from override
      methodOverride.ExtraFmtLines.ForEach(line => method.AddLine($"  {string.Format(line, "component")}"));

      // Return
      if (isUnique)
      {
        method.AddLine($"  return AddUniqueComponent(component, mergeBehavior, merge);");
      }
      else
      {
        method.AddLine($"  return AddComponent(component);");
      }
      method.AddLine(@"}");

      return method;
    }

    public static List<IMethod> CreateForBuilder(Type elementType, ConstructorMethod constructorMethod)
    {
      List<IMethod> methods = new();
      var builderType = elementType.IsSubclassOf(typeof(Condition)) ? "ConditionsBuilder" : "ActionsBuilder";

      if (!constructorMethod.Methods.Any())
      {
        methods.Add(CreateForBuilder(elementType, constructorMethod, builderType, constructorMethod));
        return methods;
      }

      foreach (var methodOverride in constructorMethod.Methods)
      {
        methods.Add(
          CreateForBuilder(
            elementType, constructorMethod, builderType, MethodOverride.Merge(constructorMethod, methodOverride)));
      }
      return methods;
    }

    private static IMethod CreateForBuilder(
      Type elementType, ConstructorMethod builderMethod, string builderType, MethodOverride methodOverride)
    {
      var method = new MethodImpl();
      var elementTypeName = TypeTool.GetName(elementType);
      var parameters = ParametersFactory.CreateForConstructor(elementType, methodOverride);

      // Imports
      method.AddImport(elementType);
      method.AddImport(typeof(ElementTool));
      method.AddParameterImports(parameters);
      method.AddTypeNameImports(methodOverride.Imports);

      // Comment summary
      method.AddCommentSummary($"Adds <see cref=\"{elementTypeName}\"/>");

      // Remarks & Examples
      method.AddRemarks(elementType, methodOverride.Remarks);

      // Parameter comments
      method.AddParameterComments(parameters);

      var methodName =
        string.IsNullOrEmpty(methodOverride.MethodName)
          ? GetBuilderMethodName(elementTypeName)
          : methodOverride.MethodName;
      if (!parameters.Any())
      {
        method.AddLine($"public static {builderType} {methodName}(this {builderType} builder)");
        method.AddLine($"{{");
        method.AddLine($"  return builder.Add(ElementTool.Create<{elementTypeName}>());");
        method.AddLine($"}}");
        return method;
      }

      // Declarations
      var declarations =
          parameters.Select(field => field.Declaration).Where(declaration => !string.IsNullOrEmpty(declaration));
      if (!declarations.Any())
      {
        method.AddLine($"public static {builderType} {methodName}(this {builderType} builder)");
      }
      else
      {
        method.AddLine($"public static {builderType} {methodName}(");
        method.AddLine($"    this {builderType} builder,");
        declarations.SkipLast(1).ToList().ForEach(declaration => method.AddLine($"    {declaration},"));
        method.AddLine($"    {declarations.Last()})");
      }
      method.AddLine($"{{");

      // Constructor & assignment
      if (string.IsNullOrEmpty(builderMethod.ConstructorRhs))
      {
        method.AddLine($"  var element = ElementTool.Create<{elementTypeName}>();");
      }
      else
      {
        method.AddLine($"  var element = {builderMethod.ConstructorRhs};");
      }
      parameters.SelectMany(field => field.GetOperation("element", "builder.Validate"))
        .ToList()
        .ForEach(line => method.AddLine($"  {line}"));

      // Extra lines from override
      methodOverride.ExtraFmtLines.ForEach(line => method.AddLine($"  {string.Format(line, "element")}"));

      // Return
      method.AddLine($"  return builder.Add(element);");
      method.AddLine($"}}");

      return method;
    }

    /// <summary>
    /// Removes unnecessary method name prefixes, e.g. ActionGoDeeperIntoDungeon > GoDeeperIntoDungeon.
    /// </summary>
    private static readonly List<string> IgnoreMethodNamePrefixes =
      new() { "Action", "ContextAction", "Condition", "ContextCondition" };
    private static string GetBuilderMethodName(string elementTypeName)
    {
      var methodName = elementTypeName;
      foreach (var prefix in IgnoreMethodNamePrefixes)
      {
        if (methodName.StartsWith(prefix))
        {
          return methodName.Remove(0, prefix.Length);
        }
      }
      return methodName;
    }

    /// <summary>
    /// Prefixes the name w/ Add unless it's redundant
    /// </summary>
    private static string GetComponentMethodName(string componentTypeName)
    {
      if (componentTypeName.StartsWith("Add"))
      {
        return componentTypeName;
      }
      return $"Add{componentTypeName}";
    }

    private class MethodImpl : IMethod
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

      public void AddParameterImports(List<IParameter> parameters)
      {
        parameters.ForEach(param => param.Imports.ForEach(import => AddImport(import)));
      }

      public void AddTypeNameImports(List<string> typeNames)
      {
        typeNames.ForEach(import => AddImport(TypeTool.TypeByName(import)));
      }

      public void AddCommentSummary(string summary)
      {
        AddLine(@"/// <summary>");
        AddLine($"/// {summary}");
        AddLine(@"/// </summary>");
        AddLine(@"///");
      }

      public void AddRemarks(Type constructedType, List<string> remarks)
      {
        AddLine(@"/// <remarks>");
        remarks.ForEach(paragraph => AddRemark(paragraph));
        AddLine(@"///");
        var componentNameAttr = constructedType.GetCustomAttribute<ComponentNameAttribute>();
        if (componentNameAttr is not null)
        {
          AddRemark($"ComponentName: {componentNameAttr.Name}");
          AddLine(@"///");
        }
        AddLine($"/// <list type=\"bullet\">");
        AddLine(@"/// <listheader>Used by</listheader>");
        Examples.GetFor(constructedType).ForEach(
          example =>
            AddLine(
              $"/// <item><term>{example.BlueprintName}</term>" +
              $"<description>{example.BlueprintGuid}</description></item>"));
        AddLine($"/// </list>");
        AddLine($"/// </remarks>");
      }

      public void AddParameterComments(List<IParameter> parameters)
      {
        var paramComments =
          parameters.Select(field => field.Comment).Where(comment => comment is not null && comment.Any()).ToList();
        if (paramComments.Any())
        {
          AddLine(@"///");
          paramComments.ForEach(
              comment =>
              {
                comment.ForEach(line => AddLine($"/// {line}"));
              });
        }
      }

      private void AddRemark(string paragraph)
      {
        AddLine(@"<para>");
        AddLine($"/// {paragraph}");
        AddLine(@"</para>");
      }
    }
  }
}
