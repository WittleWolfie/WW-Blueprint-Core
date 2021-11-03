using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BlueprintCoreGen
{
  public static class TemplateProcessor
  {
    private static readonly Regex Namespace = new(@"namespace [\w\.]+", RegexOptions.Compiled);
    private static readonly Regex MethodAttribute = new(@"\s+\[Implements\(typeof\((\w+)\)\)\]", RegexOptions.Compiled);

    public static readonly List<Template> Templates = new();

    public static void Run()
    {
      var directory = Path.Combine(Directory.GetCurrentDirectory(), "Templates");
      foreach (string file in Directory.GetFiles(directory, "*.cs", SearchOption.AllDirectories))
      {
        Templates.Add(ProcessTemplateFile(file));
      }
    }

    // TODO: Support [Replace] annotation
    private static Template ProcessTemplateFile(string file)
    {
      var template = new Template(Path.GetFileNameWithoutExtension(file));

      bool foundNamespace = false;
      foreach (var line in File.ReadAllLines(file))
      {
        if (foundNamespace)
        {
          if (MethodAttribute.IsMatch(line))
          {
            template.AddType(AccessTools.TypeByName(MethodAttribute.Match(line).Groups[1].Value));
          }
          else
          {
            template.AddLine(line);
          }
        }
        else
        {
          if (Namespace.IsMatch(line))
          {
            template.AddLine(line.Replace("BlueprintCoreGen", "BlueprintCore"));
            foundNamespace = true;
          }
          else if (!line.Contains("BlueprintCoreGen"))
          {
            template.AddLine(line);
          }
        }
      }
      return template;
    }
  }

  public class Template
  {
    public readonly string ClassName;
    private readonly StringBuilder ClassText = new();
    private readonly HashSet<Type> ImplementedTypes = new();

    public Template(string className) { ClassName = className; }

    public void AddLine(string line) { ClassText.AppendLine(line); }

    public void AddType(Type type)
    {
      if (!ImplementedTypes.Contains(type)) { ImplementedTypes.Add(type); }
    }

    public string GetClassText() { return ClassText.ToString(); }

    public List<Type> GetImplementedTypes() { return ImplementedTypes.ToList(); }
  }
}
