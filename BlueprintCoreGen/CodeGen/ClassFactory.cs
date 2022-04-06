using BlueprintCoreGen.CodeGen.Builders;
using BlueprintCoreGen.CodeGen.Methods;
using BlueprintCoreGen.CodeGen.Overrides;
using BlueprintCoreGen.CodeGen.Overrides.Ignored;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueprintCoreGen.CodeGen
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
            Type type = AccessTools.TypeByName(builderMethod.TypeName)!;
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
