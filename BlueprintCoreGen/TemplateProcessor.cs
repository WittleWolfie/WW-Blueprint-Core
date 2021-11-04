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
  /// Two annotations are used to convert the classes as well as special logic to convert the namespace from
  /// BlueprintCoreGen to BlueprintCore. The reason for using BlueprintCoreGen in the first place is to prevent
  /// namespace conflicts while allowing the code to compile so it can be validated with intellisense.
  /// </para>
  /// <list type="bullet">
  /// <listheader>Attributes</listheader>
  /// <item>
  ///   <term><see cref="Templates.ImplementsAttribute"/></term>
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
  /// </list>
  /// </remarks>
  public static class TemplateProcessor
  {
    private static readonly Regex Replace = new(@"\s+// \[Replace\(""(.*)"", ""(.*)""\)\]", RegexOptions.Compiled);
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

    private static Template ProcessTemplateFile(string file)
    {
      var template = new Template(Path.GetFileNameWithoutExtension(file));

      bool foundNamespace = false;
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

        // Technically this could all be one big if/else but I found the continue easier to read at a glance.
        if (!foundNamespace)
        {
          if (Namespace.IsMatch(line))
          {
            // Convert the namespace for BlueprintCore
            template.AddLine(line.Replace("BlueprintCoreGen", "BlueprintCore"));
            foundNamespace = true;
          }
          else if (!line.Contains("BlueprintCoreGen"))
          {
            // Skip BlueprintCoreGen imports
            template.AddLine(line);
          }
        }
        else
        {
          if (MethodAttribute.IsMatch(line))
          {
            // The attribute is a processor directive; don't add the line to the output
            template.AddType(AccessTools.TypeByName(MethodAttribute.Match(line).Groups[1].Value));
          }
          else
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
