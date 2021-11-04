using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BlueprintCoreGen
{
  /// <summary>
  /// Processes *.cs files in the Templates folder and converts them into classes for use in BlueprintCore.
  /// </summary>
  /// 
  /// <remarks>
  /// <para>
  /// Attributes are used to convert template classes with additional logic to customize the output.
  /// </para>
  /// <list type="bullet">
  /// <listheader>Attributes</listheader>
  /// <item>
  ///   <term><see cref="ImplementsAttribute"/></term>
  ///   <description>
  ///   Use on methods that implement a game type such as a <see cref="Kingmaker.ElementsSystem.GameAction"/> or
  ///   <see cref="Kingmaker.ElementsSystem.Condition"/>. This is used to determine which types need automatically
  ///   generated methods. e.g. <c>[Implements(typeof(Conditional))]</c>
  ///   </description>
  /// </item>
  /// <item>
  ///   <term>Replace</term>
  ///   <description>
  ///   A simple tag instructing the processor to run <see cref="string.Replace(string, string?)"/> on the next line.
  ///   Implemented using a comment because attributes in C# cannot be applied to arbitrary lines of code. e.g.
  ///   <c>// [Replace("Original", "Replacement")]</c> would replace occurrences of the text Original on the next line
  ///   with Replacement. Cannot be used before the namespace declaration.
  ///   </description>
  /// </item>
  /// <item>
  ///   <term>Generate</term>
  ///   <description>
  ///   Generate tags indicate where in the template to insert generated types.
  ///   e.g. <c>// [Generate(typeof(Conditional))]</c> is automatically replaced a method for the Conditional action.
  ///   </description>
  /// </item>
  /// </list>
  /// </remarks>
  public static class TemplateProcessor
  {
    private static readonly Regex Replace = new(@"\s*// \[Replace\(""(.*)"", ""(.*)""\)\]", RegexOptions.Compiled);
    private static readonly Regex Generate = new(@"\s*// \[Generate\((.*)\)\]", RegexOptions.Compiled);
    private static readonly Regex Namespace = new(@"namespace [\w\.]+", RegexOptions.Compiled);
    private static readonly Regex MethodAttribute = new(@"\s+\[Implements\(typeof\((\w+)\)\)\]", RegexOptions.Compiled);

    public static readonly List<Template> ActionTemplates = new();

    public static void Run()
    {
      var templatesRoot = Path.Combine(Directory.GetCurrentDirectory(), "Templates");
      var actionsBuilderRoot = Path.Combine(templatesRoot, "ActionsBuilder");
      foreach (string file in Directory.GetFiles(actionsBuilderRoot, "*.cs", SearchOption.AllDirectories))
      {
        ActionTemplates.Add(ProcessTemplateFile(file, Path.GetRelativePath(templatesRoot, file)));
      }
    }

    private static Template ProcessTemplateFile(string file, string relativePath)
    {
      var template = new Template(relativePath);

      (string Old, string New)? replacement = null;
      foreach (var line in File.ReadAllLines(file))
      {
        if (Replace.IsMatch(line))
        {
          Match match = Replace.Match(line);
          replacement = (match.Groups[1].Value, match.Groups[2].Value);
          continue;
        }

        if (replacement != null)
        {
          template.AddLine(line.Replace(replacement?.Old, replacement?.New));
          replacement = null;
          continue;
        }

        if (Generate.IsMatch(line))
        {
          var type = AccessTools.TypeByName(Generate.Match(line).Groups[1].Value);
          template.AddMethod(CodeGenerator.CreateMethod(type));
          template.AddType(type);
          continue;
        }

        if (Namespace.IsMatch(line))
        {
          // Convert the namespace for BlueprintCore
          template.AddLine(line.Replace("BlueprintCoreGen", "BlueprintCore"));
          continue;
        }
         
        if (MethodAttribute.IsMatch(line))
        {
          template.AddType(AccessTools.TypeByName(MethodAttribute.Match(line).Groups[1].Value));
        }
        template.AddLine(line);
      }
      return template;
    }
  }

  public class Template
  {
    public readonly string RelativePath;
    private readonly StringBuilder ClassText = new();
    private readonly HashSet<Type> ImplementedTypes = new();

    public Template(string filePath)
    {
      RelativePath = filePath;
    }

    public void AddLine(string line) { ClassText.AppendLine(line); }
    public void AddMethod(string method) { ClassText.Append(method); }

    public void AddType(Type type)
    {
      if (!ImplementedTypes.Contains(type)) { ImplementedTypes.Add(type); }
    }

    public string GetClassText() { return ClassText.ToString(); }

    public List<Type> GetImplementedTypes() { return ImplementedTypes.ToList(); }
  }
}
