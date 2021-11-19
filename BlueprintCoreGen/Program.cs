using BlueprintCoreGen.CodeGen;
using HarmonyLib;
using Kingmaker.ElementsSystem;
using System;
using System.Collections.Generic;
using System.IO;
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

      TemplateProcessor.ConfiguratorClasses.ForEach(configuratorClass => WriteClasstoFile(configuratorClass));
    }

    private static List<Type> ProcessActions(Type[] gameTypes)
    {
      HashSet<Type> implementedActionTypes = new();
      foreach (IClass actionClass in TemplateProcessor.ActionClasses)
      {
        WriteClasstoFile(actionClass);
        implementedActionTypes.UnionWith(actionClass.GetImplementedTypes());
      }
      return TemplateProcessor.GetMissingTypes(typeof(GameAction), implementedActionTypes, gameTypes);
    }

    private static List<Type> ProcessConditions(Type[] gameTypes)
    {
      HashSet<Type> implementedConditionTypes = new();
      foreach (IClass conditionClass in TemplateProcessor.ConditionClasses)
      {
        WriteClasstoFile(conditionClass);
        implementedConditionTypes.UnionWith(conditionClass.GetImplementedTypes());
      }
      return TemplateProcessor.GetMissingTypes(typeof(Condition), implementedConditionTypes, gameTypes);
    }

    private static void WriteClasstoFile(IClass classtoWrite)
    {
      // Create the directories if necessary
      FileInfo result = new FileInfo(classtoWrite.RelativePath);
      result.Directory.Create();

      File.WriteAllText(classtoWrite.RelativePath, classtoWrite.GetText());
    }
  }
}
