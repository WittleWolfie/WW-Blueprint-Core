using BlueprintCoreGen.Templates;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlueprintCoreGen
{
  public static class TemplateProcessor
  {
    private enum Stage
    {
      Import,
      Namespace,
      ClassAttribute,
      ClassDeclaration,
      MethodComment,
      MethodAttribute,
      MethodDeclaration,
      MethodBody
    }

    private static readonly Regex Import = new(@"using [\w\.]+;", RegexOptions.Compiled);
    private static readonly Regex Namespace = new(@"namespace [\w\.]+", RegexOptions.Compiled);
    private static readonly Regex ClassAttribute = new(@"\s+\[Template\(TemplateType\.(\w+)\)\]", RegexOptions.Compiled);
    private static readonly Regex ClassDeclaration = new(@"[\s\w]*class \w+", RegexOptions.Compiled);
    private static readonly Regex MethodComment = new(@"\s+/// .*", RegexOptions.Compiled);
    private static readonly Regex MethodAttribute = new(@"\s+\[Implements\(typeof\((\w+)\)\)\]", RegexOptions.Compiled);
    private static readonly Regex MethodDeclaration = new(@"\s+public .*", RegexOptions.Compiled);
    private static readonly Regex MethodBody = new(@"\s+\{", RegexOptions.Compiled);

    public static readonly List<Template> Templates = new();

    public static void Run()
    {
      var directory = Path.Combine(Directory.GetCurrentDirectory(), "Templates");
      foreach (string file in Directory.GetFiles(directory, "*.cs", SearchOption.AllDirectories))
      {
        Templates.Add(ProcessTemplateFile(file));
      }
    }

    private static Template ProcessTemplateFile(string file)
    {
      var template = new Template();

      var stage = Stage.Import;
      StringBuilder method = new();
      Type methodType = null;
      var braceDepth = 0;
      foreach (var line in File.ReadAllLines(file))
      {
        switch (stage)
        {
          case Stage.Import:
            if (Import.IsMatch(line))
            {
              template.AddImport(line);
            }
            else if (Namespace.IsMatch(line))
            {
              stage = Stage.Namespace;
            }
            break;
          case Stage.Namespace:
            if (ClassAttribute.IsMatch(line))
            {
              template.Type = Enum.Parse<TemplateType>(ClassAttribute.Match(line).Groups[1].Value);
              stage = Stage.ClassAttribute;
            }
            break;
          case Stage.ClassAttribute:
            if (ClassDeclaration.IsMatch(line))
            {
              stage = Stage.ClassDeclaration;
            }
            break;
          case Stage.ClassDeclaration:
            if (MethodComment.IsMatch(line))
            {
              method.AppendLine(line);
              stage = Stage.MethodComment;
            }
            break;
          case Stage.MethodComment:
            if (MethodAttribute.IsMatch(line))
            {
              methodType = AccessTools.TypeByName(MethodAttribute.Match(line).Groups[1].Value);
              stage = Stage.MethodAttribute;
            }
            else { method.AppendLine(line); }
            break;
          case Stage.MethodAttribute:
            if (MethodDeclaration.IsMatch(line))
            {
              method.AppendLine(line);
              stage = Stage.MethodDeclaration;
            }
            break;
          case Stage.MethodDeclaration:
            method.AppendLine(line);
            if (MethodBody.IsMatch(line))
            {
              stage = Stage.MethodBody;
              braceDepth = 1;
            }
            break;
          case Stage.MethodBody:
            method.AppendLine(line);
            braceDepth += line.Count(c => c == '{');
            braceDepth -= line.Count(c => c == '}');
            if (braceDepth == 0)
            {
              template.AddMethod(methodType, method.ToString());
              method.Clear();
              stage = Stage.ClassDeclaration;
            }
            break;
          default:
            throw new InvalidOperationException($"Unrecognized stage: {stage}");
        }
      }

      return template;
    }
  }

  public class Template
  {
    public TemplateType Type;
    private readonly List<string> Imports = new();
    private readonly Dictionary<Type, List<string>> Methods = new();

    public void AddImport(string import) { Imports.Add(import); }

    public string GetImports() { return string.Join('\n', Imports); }

    public void AddMethod(Type type, string method)
    {
      if (!Methods.ContainsKey(type)) { Methods.Add(type, new List<string> { method }); }
      else { Methods[type].Add(method); }
    }

    public string GetAllMethods()
    {
      StringBuilder allMethods = new();
      foreach (Type type in Methods.Keys)
      {
        allMethods.AppendLine(GetMethods(type));
      }
      return allMethods.ToString();
    }

    public string GetMethods(Type type)
    {
      if (!Methods.ContainsKey(type)) { return null; }
      return string.Join("\n\n", Methods[type]);
    }
  }
}
