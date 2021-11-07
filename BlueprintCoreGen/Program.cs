using BlueprintCoreGen.CodeGen;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.TextTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BlueprintCoreGen
{
  class Program
  {
    static void Main()
    {
      // Since the code doesn't reference assemblies, force load them for reflection
      var gameTypes = AccessTools.GetTypesFromAssembly(Assembly.Load("Assembly-CSharp"));
      Assembly.Load("Blueprint-Core");

      TemplateProcessor.Run(gameTypes);

      StringBuilder missingTypes = new();

      List<Type> actionsToGenerate = ProcessActions(gameTypes);
      missingTypes.AppendLine("Missing Action Types:");
      actionsToGenerate.ForEach(actionType => missingTypes.AppendLine($"// [Generate({actionType})]"));

      List<Type> conditionsToGenerate = ProcessConditions(gameTypes);
      missingTypes.AppendLine();
      missingTypes.AppendLine("Missing Condition Types:");
      conditionsToGenerate.ForEach(conditionType => missingTypes.AppendLine($"// [Generate({conditionType})]"));

      File.WriteAllText("missing_types.txt", missingTypes.ToString());
    }

    private static List<Type> ProcessActions(Type[] gameTypes)
    {
      HashSet<Type> implementedActionTypes = new();
      foreach (Template template in TemplateProcessor.ActionTemplates)
      {
        WriteTemplateToFile(template);
        implementedActionTypes.UnionWith(template.GetImplementedTypes());
      }
      return GetMissingTypes(typeof(GameAction), implementedActionTypes, gameTypes);
    }

    private static List<Type> ProcessConditions(Type[] gameTypes)
    {
      HashSet<Type> implementedConditionTypes = new();
      foreach (Template template in TemplateProcessor.ConditionTemplates)
      {
        WriteTemplateToFile(template);
        implementedConditionTypes.UnionWith(template.GetImplementedTypes());
      }
      return GetMissingTypes(typeof(Condition), implementedConditionTypes, gameTypes);
    }

    private static List<Type> GetMissingTypes(Type baseType, HashSet<Type> implementedTypes, Type[] gameTypes)
    {
      List<Type> missingTypes = new();
      foreach (Type type in gameTypes.Where(t => t.IsSubclassOf(baseType)))
      {
        if (!type.IsAbstract && !implementedTypes.Contains(type))
        {
          missingTypes.Add(type);
        }
      }
      return missingTypes;
    }

    private static void WriteTemplateToFile(Template template)
    {
      // Create the directories if necessary
      FileInfo result = new FileInfo(template.RelativePath);
      result.Directory.Create();

      File.WriteAllText(template.RelativePath, template.GetClassText());
    }
  }
}
