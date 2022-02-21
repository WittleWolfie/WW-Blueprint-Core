using BlueprintCore.Utils;
using BlueprintCoreGen.CodeGen.Override;
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
    List<Type> GetImports();

    /// <summary>
    /// Returns the method implementation as lines of text.
    /// </summary>
    List<string> GetLines();
  }

  public static class MethodFactory
  {
    public static List<IMethod> CreateForBuilder(Type elementType)
    {
      List<IMethod> methods = new();
      var builderType = elementType is Condition ? "ConditionsBuilder" : "ActionsBuilder";

      if (MethodOverrides.BuilderMethods.ContainsKey(elementType))
      {
        var methodOverrides = MethodOverrides.BuilderMethods[elementType];
        methodOverrides.Methods.ForEach(
            methodOverride => methods.Add(CreateForBuilder(elementType, builderType, methodOverride)));

        if (methodOverrides.ReplaceDefault) { return methods; }
      }
      
      methods.Add(CreateForBuilder(elementType, builderType));
      return methods;
    }

    private static IMethod CreateForBuilder(
        Type elementType, string builderType, MethodOverride? methodOverride = null)
    {
      var method = new MethodImpl();
      var elementTypeName = TypeTool.GetName(elementType);
      var fields = FieldFactory.CreateFieldParameters(elementType, methodOverride?.FieldOverridesByName);

      // Imports
      method.AddImport(elementType);
      method.AddImport(typeof(ElementTool));
      fields.ForEach(field => field.Imports.ForEach(import => method.AddImport(import)));
      if (methodOverride is not null) { methodOverride.Imports.ForEach(import => method.AddImport(import)); }

      // Comment summary
      method.AddLine($"/// <summary>");
      method.AddLine($"/// Adds <see cref=\"{elementTypeName}\"/>");
      method.AddLine($"/// </summary>");

      // Remarks
      if(methodOverride is not null && methodOverride.Remarks.Any())
      {
        method.AddLine($"///");
        methodOverride.Remarks.ForEach(line => method.AddLine(line));
      }

      // Parameter comments
      var paramComments =
          fields.Select(field => field.Comment).Where(comment => comment is not null && comment.Any()).ToList();
      if (paramComments.Any())
      {
        paramComments.ForEach(
            comment =>
            {
              method.AddLine($"///");
              comment.ForEach(line => method.AddLine($"/// {line}"));
            });
      }

      var methodName = methodOverride?.Name ?? GetMethodName(elementTypeName);
      if (!fields.Any())
      {
        method.AddLine($"public static {builderType} {methodName}(this {builderType} builder)");
        method.AddLine($"{{");
        method.AddLine($"  return builder.Add(ElementTool.Create<{elementTypeName}>());");
        method.AddLine($"}}");
        return method;
      }

      // Declarations
      var declarations =
          fields.Select(field => field.Declaration).Where(declaration => !string.IsNullOrEmpty(declaration));
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
      method.AddLine($"  var element = ElementTool.Create<{elementTypeName}>();");
      fields.SelectMany(field => field.GetAssignment("element", "builder.Validate"))
        .ToList()
        .ForEach(line => method.AddLine($"  {line}"));

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
