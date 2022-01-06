using BlueprintCoreGen.CodeGen.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueprintCoreGen.CodeGen
{
  public static class NewClassFactory
  {
    public static IClass CreateBuilderExtension(IBuilderExtension builderExtension)
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
      extensionClass.AddLine(@"{");

      // Methods
      builderExtension.ElementTypes.ForEach(
          type =>
          {
            extensionClass.AddImplementedType(type);
            NewMethodFactory.CreateForBuilder(type).ForEach(
                method =>
                {
                  method.GetImports().ForEach(import => extensionClass.AddImport(import));
                  extensionClass.AddLine("");
                  method.GetLines().ForEach(line => extensionClass.AddLine($"    {line}"));
                });
          });

      // Close out class and namespace
      extensionClass.AddLine(@"  }");
      extensionClass.AddLine(@"}");
      return extensionClass;
    }

    private class ClassImpl : IClass
    {
      public string FilePath { get; private set; }

      private readonly StringBuilder Text = new();
      private readonly HashSet<Type> ImplementedTypes = new();

      private readonly HashSet<string> Imports = new() { "using BlueprintCore.Utils;" };

      public ClassImpl(string filePath)
      {
        FilePath = filePath;
      }

      public List<Type> GetImplementedTypes()
      {
        return ImplementedTypes.ToList();
      }

      public string GetText()
      {
        var sortedImports = Imports.ToList();
        sortedImports.Sort();
        Text.Insert(0, string.Join('\n', sortedImports) + "\n");

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

      public void AddImplementedType(Type type)
      {
        ImplementedTypes.Add(type);
      }
    }
  }
}
