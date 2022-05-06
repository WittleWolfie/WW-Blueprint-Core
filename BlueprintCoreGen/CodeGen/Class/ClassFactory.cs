using BlueprintCoreGen.CodeGen.Methods;
using BlueprintCoreGen.CodeGen.Overrides.Ignored;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueprintCoreGen.CodeGen.Class
{
  public interface IClassFile
  {
    /// <summary>
    /// Relative file path for the output class
    /// </summary>
    string FilePath { get; }

    /// <summary>
    /// Returns the full class text
    /// </summary>
    string GetText();

    /// <summary>
    /// Returns the types implemented in the class
    /// </summary>
    List<Type> GetHandledTypes();
  }

  // TODO: CreateConfigurator
  public static class ClassFactory
  {
    public static IClassFile CreateBuilderExtension(IBuilderExtension builderExtension)
    {
      var extensionClass = new ClassImpl(builderExtension.FilePath);

      // Namespace
      extensionClass.AddLine($"namespace {builderExtension.Namespace}");
      extensionClass.AddLine(@"{");

      // Class declaration
      extensionClass.AddLine($"  /// <summary>");
      extensionClass.AddLine($"  /// {builderExtension.Summary}");
      extensionClass.AddLine($"  /// </summary>");
      extensionClass.AddLine($"  /// <inheritdoc cref=\"{builderExtension.ParentType}\"/>");
      extensionClass.AddLine($"  public static class {builderExtension.ClassName}");
      extensionClass.AddLine(@"  {");

      // Methods
      builderExtension.Methods.ForEach(
          builderMethod =>
          {
            Type type = TypeTool.TypeByName(builderMethod.TypeName)!;
            extensionClass.AddHandledType(type);

            if (!Ignored.ShouldIgnore(type))
            {
              MethodFactory.CreateForBuilder(type, builderMethod).ForEach(
                  method =>
                  {
                    method.GetImports().ForEach(import => extensionClass.AddImport(import));
                    extensionClass.AddLine("");
                    method.GetLines().ForEach(line => extensionClass.AddLine($"    {line}"));
                  });
            }
          });

      // Close out class and namespace
      extensionClass.AddLine(@"  }");
      extensionClass.AddLine(@"}");
      return extensionClass;
    }

    public static IClassFile CreateConfigurator(IConfigurator configurator) {
      var configuratorClass = new ClassImpl(configurator.FilePath);

      // Namespace
      configuratorClass.AddLine($"namespace {configurator.Namespace}");
      configuratorClass.AddLine(@"{");

      // Comments
      configuratorClass.AddLine($"  /// <summary>");
      if (configurator.IsAbstract)
      {
        configuratorClass.AddLine(
          $"  /// Implements common fields and components for blueprints inheriting from <see cref=\"{configurator.TypeName}\"/>.");
      }
      else
      {
        configuratorClass.AddLine($"  /// Configurator for <see cref=\"{configurator.TypeName}\"/>.");
      }
      configuratorClass.AddLine($"  /// </summary>");
      // TODO: Use config to create root BlueprintConfigurator remarks
      if (!configurator.IsRoot)
      {
        configuratorClass.AddLine($"  /// <inheritdoc/>");
      }

      // Class declaration
      if (configurator.IsAbstract)
      {
        configuratorClass.AddLine($"  public abstract class {configurator.ClassName}<T, TBuilder>");
        configuratorClass.AddLine($"    : {configurator.ParentClassName}<T, TBuilder>");
        configuratorClass.AddLine($"    where T : {configurator.TypeName}");
        configuratorClass.AddLine($"    where TBuilder : {configurator.ClassName}<T, TBuilder>");
        configuratorClass.AddLine($"  {{");
        configuratorClass.AddLine($"    protected {configurator.ClassName}(string name) : base(name) {{ }}");
      }
      else
      {
        configuratorClass.AddLine($"  public class {configurator.ClassName}");
        configuratorClass.AddLine($"    : {configurator.ParentClassName}<{configurator.TypeName}, {configurator.ClassName}>");
        configuratorClass.AddLine($"  {{");
        configuratorClass.AddLine($"    private {configurator.ClassName}(string name) : base(name) {{ }}");
      }

      // New Methods
      // TODO

      // Field Methods
      // TODO

      // Component Methods
      configurator.ComponentMethods.ForEach(
        componentMethod =>
        {
          Type type = TypeTool.TypeByName(componentMethod.TypeName)!;
          if (!Ignored.ShouldIgnore(type))
          {
            MethodFactory.CreateForComponent(
                type, componentMethod, configurator.IsAbstract ? "TBuilder" : configurator.ClassName)
              .ForEach(
                method =>
                {
                  method.GetImports().ForEach(import => configuratorClass.AddImport(import));
                  configuratorClass.AddLine("");
                  method.GetLines().ForEach(line => configuratorClass.AddLine($"    {line}"));
                });
          }
        });

      configuratorClass.AddLine($"  }}");
      configuratorClass.AddLine($"}}");
      return configuratorClass;
    }

    private class ClassImpl : IClassFile
    {
      public string FilePath { get; private set; }

      private readonly StringBuilder Text = new();
      private readonly HashSet<Type> HandledTypes = new();

      private readonly HashSet<string> Imports = new() { "using BlueprintCore.Utils;" };

      public ClassImpl(string filePath)
      {
        FilePath = filePath;

      }

      public List<Type> GetHandledTypes()
      {
        return HandledTypes.ToList();
      }

      public string GetText()
      {

        var sortedImports = Imports.ToList();
        sortedImports.Sort();
        Text.Insert(0, string.Join('\n', sortedImports) + "\n\n");
        Text.Insert(0, "//***** AUTO-GENERATED - DO NOT EDIT *****//\n\n");

        return Text.ToString();
      }

      public void AddImport(Type type)
      {
        string? import = TypeTool.GetImport(type);
        if (import != null) { Imports.Add(import); }
      }

      public void AddLine(string line)
      {
        Text.AppendLine(line);
      }

      public void AddHandledType(Type type)
      {
        HandledTypes.Add(type);
      }
    }
  }
}
