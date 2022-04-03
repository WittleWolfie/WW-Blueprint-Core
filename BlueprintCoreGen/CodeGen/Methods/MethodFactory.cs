using BlueprintCore.Utils;
using BlueprintCoreGen.CodeGen.Overrides;
using BlueprintCoreGen.CodeGen.Params;
using HarmonyLib;
using Kingmaker.ElementsSystem;
using System;
using System.Collections.Generic;
using System.Linq;

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
    public static List<IMethod> CreateForBuilder(Type elementType, BuilderMethod builderMethod)
    {
      List<IMethod> methods = new();
      var builderType = elementType.IsSubclassOf(typeof(Condition)) ? "ConditionsBuilder" : "ActionsBuilder";

      if (!builderMethod.Methods.Any())
      {
        methods.Add(CreateForBuilder(elementType, builderType, builderMethod, builderMethod));
        return methods;
      }

      foreach (var methodOverride in builderMethod.Methods)
      {
        methods.Add(
          CreateForBuilder(
            elementType, builderType, MethodOverride.Merge(builderMethod, methodOverride), builderMethod));
      }
      return methods;
    }

    private static IMethod CreateForBuilder(
      Type elementType, string builderType, MethodOverride methodOverride, BuilderMethod builderMethod)
    {
      var method = new MethodImpl();
      var elementTypeName = TypeTool.GetName(elementType);
      var parameters = ParametersFactory.CreateForConstructor(elementType, methodOverride);

      // Imports
      method.AddImport(elementType);
      method.AddImport(typeof(ElementTool));
      parameters.ForEach(param => param.Imports.ForEach(import => method.AddImport(import)));
      methodOverride.Imports.ForEach(import => method.AddImport(AccessTools.TypeByName(import)!));

      // Comment summary
      method.AddLine($"/// <summary>");
      method.AddLine($"/// Adds <see cref=\"{elementTypeName}\"/>");
      method.AddLine($"/// </summary>");

      // Remarks & Examples
      method.AddLine($"///");
      method.AddLine($"/// <remarks>");
      methodOverride.Remarks.ForEach(line => method.AddLine($"/// {line}"));
      method.AddLine($"///");

      Examples.BuilderExamples.TryGetValue(elementType, out var examples);
      method.AddLine($"/// <list type=\"bullet\">");
      method.AddLine($"/// <listheader>Used by</listheader>");
      methodOverride.Examples.ForEach(
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

    /// <summary>
    /// Removes unnecessary method name prefixes, e.g. ActionGoDeeperIntoDungeon > GoDeeperIntoDungeon.
    /// </summary>
    private static readonly List<string> IgnoreMethodNamePrefixes = new() { "Action", "ContextAction" };
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
