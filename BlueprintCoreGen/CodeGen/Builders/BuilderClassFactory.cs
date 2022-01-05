using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BlueprintCoreGen.CodeGen.Builders
{
  /// <summary>
  /// Generates builder classes.
  /// </summary>
  public static class BuilderClassFactory
  {
    private static readonly Regex Replace = new(@"^\s*// \[Replace\(""(.*)"", ""(.*)""\)\]", RegexOptions.Compiled);
    private static readonly Regex Implements = new(@"^\s+\[Implements\(typeof\((\w+)\)\)\]", RegexOptions.Compiled);

    public static List<IClass> CreateActionsBuilders(string actionsBuilderFile)
    {
      List<IClass> builders = new();
      builders.Add(CreateBaseClass(actionsBuilderFile, "ActionsBuilder"));
      builders.AddRange(
        BuilderExtensions.Get(BuilderExtensions.BuilderType.Action).Select(ext => CreateExtensionClass(ext)));
      return builders;
    }

    private static IClass CreateBaseClass(string templateFile, string directory)
    {
      var builderClass = new BuilderClass(directory);

      string currentLine;
      (string Old, string New)? replacement = null;
      foreach (var line in File.ReadAllLines(templateFile))
      {
        currentLine = line;

        if (Replace.IsMatch(currentLine))
        {
          Match match = Replace.Match(currentLine);
          replacement = (match.Groups[1].Value, match.Groups[2].Value);
          continue;
        }

        if (replacement != null)
        {
          currentLine = currentLine.Replace(replacement?.Old, replacement?.New);
          replacement = null;
        }

        if (currentLine.Contains("BlueprintCoreGen"))
        {
          // Update to refer to BlueprintCore
          currentLine = currentLine.Replace("BlueprintCoreGen", "BlueprintCore");
        }

        if (Implements.IsMatch(currentLine))
        {
          builderClass.AddImplementedType(AccessTools.TypeByName(Implements.Match(currentLine).Groups[1].Value));
        }

        builderClass.AddLine(currentLine);
      }

      return builderClass;
    }

    private static IClass CreateExtensionClass(IBuilderExtension builderExtension)
    {
      return null;
    }

    private class BuilderClass : IClass
    {
      public string RelativePath { get; private set; }

      private readonly StringBuilder Text = new();
      private readonly HashSet<Type> ImplementedTypes = new();

      private readonly HashSet<string> Imports = new() { "using BlueprintCore.Utils;" };

      public BuilderClass(string filePath)
      {
        RelativePath = filePath;
      }

      public string GetText()
      {
        var sortedImports = Imports.ToList();
        sortedImports.Sort();
        Text.Insert(0, string.Join('\n', sortedImports) + "\n");

        return Text.ToString();
      }

      public List<Type> GetImplementedTypes()
      {
        return ImplementedTypes.ToList();
      }

      public void AddImport(string import)
      {
        Imports.Add(import);
      }

      public void AddImport(Type type)
      {
        // Skip type defined in the global namespace
        if (!string.IsNullOrEmpty(type.Namespace))
        {
          AddImport($"using {type.Namespace};");
        }
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
