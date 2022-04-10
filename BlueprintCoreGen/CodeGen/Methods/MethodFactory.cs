using BlueprintCore.Utils;
using BlueprintCoreGen.CodeGen.Overrides.Examples;
using BlueprintCoreGen.CodeGen.Params;
using HarmonyLib;
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

  public static class MethodFactory
  {
    public static List<IMethod> CreateForComponent(
      Type componentType, ConstructorMethod constructorMethod, string returnType)
    {
      List<IMethod> methods = new();

      if (!constructorMethod.Methods.Any())
      {
        methods.Add(CreateForComponent(componentType, constructorMethod, returnType, constructorMethod));
        return methods;
      }

      foreach (var methodOverride in constructorMethod.Methods)
      {
        methods.Add(
          CreateForComponent(
            componentType, constructorMethod, returnType, MethodOverride.Merge(constructorMethod, methodOverride)));
      }

      return methods;
    }

    private static IMethod CreateForComponent(
      Type componentType, ConstructorMethod constructorMethod, string returnType, MethodOverride methodOverride)
    {
      var isUnique = componentType.GetCustomAttribute<AllowMultipleComponentsAttribute>() is not null;
      var parameters =
        isUnique
          ? ParametersFactory.CreateForUniqueComponentConstructor(componentType, methodOverride)
          : ParametersFactory.CreateForConstructor(componentType, methodOverride);



      return null;
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
      parameters.ForEach(param => param.Imports.ForEach(import => method.AddImport(import)));
      methodOverride.Imports.ForEach(import => method.AddImport(TypeTool.TypeByName(import)!));

      // Comment summary
      method.AddLine($"/// <summary>");
      method.AddLine($"/// Adds <see cref=\"{elementTypeName}\"/>");
      method.AddLine($"/// </summary>");

      // Remarks & Examples
      method.AddLine($"///");
      method.AddLine($"/// <remarks>");
      methodOverride.Remarks.ForEach(paragraph => AddRemark(method, paragraph));
      method.AddLine($"///");
      var componentNameAttr = elementType.GetCustomAttribute<ComponentNameAttribute>();
      if (componentNameAttr is not null)
      {
        AddRemark(method, $"ComponentName: {componentNameAttr.Name}");
        method.AddLine($"///");
      }
      method.AddLine($"/// <list type=\"bullet\">");
      method.AddLine($"/// <listheader>Used by</listheader>");
      Examples.GetFor(elementType).ForEach(
        example =>
          method.AddLine(
            $"/// <item><term>{example.BlueprintName}</term><description>{example.BlueprintGuid}</description></item>"));
      method.AddLine($"/// </list>");
      method.AddLine($"/// </remarks>");

      // Parameter comments
      var paramComments =
          parameters.Select(field => field.Comment).Where(comment => comment is not null && comment.Any()).ToList();
      if (paramComments.Any())
      {
        method.AddLine($"///");
        paramComments.ForEach(
            comment =>
            {
              comment.ForEach(line => method.AddLine($"/// {line}"));
            });
      }

      var methodName =
        string.IsNullOrEmpty(methodOverride.MethodName) ? GetMethodName(elementTypeName) : methodOverride.MethodName;
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

    private static void AddRemark(MethodImpl method, string paragraph)
    {
      method.AddLine(@"<para>");
      method.AddLine($"/// {paragraph}");
      method.AddLine(@"</para>");
    }

    /// <summary>
    /// Removes unnecessary method name prefixes, e.g. ActionGoDeeperIntoDungeon > GoDeeperIntoDungeon.
    /// </summary>
    private static readonly List<string> IgnoreMethodNamePrefixes =
      new() { "Action", "ContextAction", "Condition", "ContextCondition" };
    private static string GetMethodName(string elementTypeName)
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
    }
  }
}
