using BlueprintCoreGen.CodeGen;
using HarmonyLib;
using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BlueprintCoreGen.CodeGen
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
  ///   with Replacement.
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
    private static readonly Regex Replace = new(@"^\s*// \[Replace\(""(.*)"", ""(.*)""\)\]", RegexOptions.Compiled);
    private static readonly Regex Import = new(@"^using [\w\.]+;", RegexOptions.Compiled);
    private static readonly Regex Namespace = new(@"^namespace [\w\.]+", RegexOptions.Compiled);
    private static readonly Regex Generate = new(@"^\s*// \[Generate\((.*)\)\]", RegexOptions.Compiled);
    private static readonly Regex MethodAttribute =
        new(@"^\s+\[Implements\(typeof\((\w+)\)\)\]", RegexOptions.Compiled);

    public static readonly List<Template> ActionTemplates = new();
    public static readonly List<Template> ConditionTemplates = new();
    public static readonly List<Template> ConfiguratorTemplates = new();

    public static void Run(Type[] gameTypes)
    {
      var templatesRoot = Path.Combine(Directory.GetCurrentDirectory(), "Templates");

      var actionsBuilderRoot = Path.Combine(templatesRoot, "ActionsBuilder");
      foreach (string file in Directory.GetFiles(actionsBuilderRoot, "*.cs", SearchOption.AllDirectories))
      {
        ActionTemplates.Add(ProcessBuilderTemplate(file, Path.GetRelativePath(templatesRoot, file)));
      }

      var conditionsBuilderRoot = Path.Combine(templatesRoot, "ConditionsBuilder");
      foreach (string file in Directory.GetFiles(conditionsBuilderRoot, "*.cs", SearchOption.AllDirectories))
      {
        ConditionTemplates.Add(ProcessBuilderTemplate(file, Path.GetRelativePath(templatesRoot, file)));
      }

      ProcessBlueprintTemplates(templatesRoot, gameTypes);
    }

    private static Template ProcessBuilderTemplate(string file, string relativePath)
    {
      var template = new Template(relativePath);

      string currentLine;
      (string Old, string New)? replacement = null;
      foreach (var line in File.ReadAllLines(file))
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

        if (Import.IsMatch(currentLine))
        {
          template.AddImport(currentLine);
          continue;
        }

        if (Namespace.IsMatch(currentLine))
        {
          // Convert the namespace for BlueprintCore
          template.AddLine(currentLine.Replace("BlueprintCoreGen", "BlueprintCore"));
          continue;
        }

        if (Generate.IsMatch(currentLine))
        {
          var type = AccessTools.TypeByName(Generate.Match(currentLine).Groups[1].Value);
          template.AddMethod(CodeGenerator.CreateMethod(type));
          template.AddType(type);
          continue;
        }
         
        if (MethodAttribute.IsMatch(currentLine))
        {
          template.AddType(AccessTools.TypeByName(MethodAttribute.Match(currentLine).Groups[1].Value));
        }
        template.AddLine(currentLine);
      }
      return template;
    }

    private static void ProcessBlueprintTemplates(string templatesRoot, Type[] gameTypes)
    {
      // Plan:
      // 1. Iterate over ComponentTemplates to create: Dictionary<BlueprintType, List<Method>>()
      // 2. Iterate over game types and generate missing components then update the Dictionary.
      // 3. Generate BlueprintConfigurator classes using Dictionary
      
      //var root = new TypeTreeNode(typeof(BlueprintScriptableObject));
      //var curr = root;

      //Queue<TypeTreeNode> queue = new();
      //queue.Enqueue(root);
      //while (queue.Count > 0)
      //{
      //  curr = queue.Dequeue();
      //  GetDirectChildren(curr.Type, gameTypes).ForEach(
      //    type =>
      //    {
      //      var child = new TypeTreeNode(type);
      //      curr.Children.Add(child);
      //      queue.Enqueue(child);
      //    });
      //}

      //StringBuilder tree = new();
      //curr = root;
      //Stack<TypeTreeNode> stack = new();
      //while (curr is not null)
      //{
      //  if (!curr.Visit)
      //  {
      //    tree.AppendLine($"{new string(' ', stack.Count)}{curr.Type.Name}");
      //    curr.Visit = true;
      //  }
      //  var next = curr.Children.Where(node => !node.Visit).FirstOrDefault();

      //  if (next == null)
      //  {
      //    if (stack.Count == 0)
      //    {
      //      break;
      //    }
      //    curr = stack.Pop();
      //  }
      //  else
      //  {
      //    stack.Push(curr);
      //    curr = next;
      //  }
      //}
    }

    //private static List<Type> GetDirectChildren(Type type, Type[] gameTypes)
    //{
    //  return gameTypes.Where(gameType => gameType.BaseType == type).ToList();
    //}

    //private class TypeTreeNode
    //{
    //  public Type Type;
    //  public List<TypeTreeNode> Children = new();

    //  public TypeTreeNode(Type type)
    //  {
    //    Type = type;
    //  }
    //}
  }
}
