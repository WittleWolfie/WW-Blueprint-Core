using BlueprintCoreGen.Analysis;
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
    // Run this once after each patch to re-generate ignored types and usage examples. Skips code gen.
    private static readonly bool RunTypeUsageAnalysis = false;

    public static readonly string AnalysisDir = "Analysis";

    static void Main()
    {
      // Since the code doesn't reference assemblies, force load them for reflection
      var gameTypes = AccessTools.GetTypesFromAssembly(Assembly.Load("Assembly-CSharp"));
      var blueprintCoreTypes = AccessTools.GetTypesFromAssembly(Assembly.Load("BlueprintCore"));

      if (RunTypeUsageAnalysis)
      {
        TypeUsageAnalyzer.Analyze(gameTypes);
        return;
      }

      TypeTool.InitTypesByName(gameTypes, blueprintCoreTypes);
      TemplateProcessor.Run(gameTypes);

      StringBuilder unhandledTypes = new();

      List<Type> unhandledActions = ProcessActions(gameTypes);
      unhandledTypes.AppendLine("Unhandled Action Types:");
      unhandledActions.ForEach(actionType => unhandledTypes.AppendLine(actionType.ToString()));
      unhandledTypes.AppendLine();

      List<Type> unhandledConditions = ProcessConditions(gameTypes);
      unhandledTypes.AppendLine("Unhandled Condition Types:");
      unhandledConditions.ForEach(conditionType => unhandledTypes.AppendLine(conditionType.ToString()));

      Directory.CreateDirectory(AnalysisDir);
      File.WriteAllText($"{AnalysisDir}/unhandled_types.txt", unhandledTypes.ToString());

      TemplateProcessor.ConfiguratorClasses.ForEach(configuratorClass => WriteClassToFile(configuratorClass));
    }

    /// <summary>
    /// Generates ActionsBuilder extension classes, then returns a list of unhandled Action types.
    /// </summary>
    private static List<Type> ProcessActions(Type[] gameTypes)
    {
      HashSet<Type> implementedActionTypes = new();
      foreach (IClassFile actionClass in TemplateProcessor.ActionClasses)
      {
        WriteClassToFile(actionClass);
        implementedActionTypes.UnionWith(actionClass.GetHandledTypes());
      }
      return TemplateProcessor.GetUnhandledTypes(typeof(GameAction), implementedActionTypes, gameTypes);
    }

    /// <summary>
    /// Generates ConditionsBuilder extension classes, then returns a list of unhandled Condition types.
    /// </summary>
    private static List<Type> ProcessConditions(Type[] gameTypes)
    {
      HashSet<Type> implementedConditionTypes = new();
      foreach (IClassFile conditionClass in TemplateProcessor.ConditionClasses)
      {
        WriteClassToFile(conditionClass);
        implementedConditionTypes.UnionWith(conditionClass.GetHandledTypes());
      }
      return TemplateProcessor.GetUnhandledTypes(typeof(Condition), implementedConditionTypes, gameTypes);
    }

    private static void WriteClassToFile(IClassFile classToWrite)
    {
      // Create the directories if necessary
      FileInfo result = new FileInfo(classToWrite.FilePath);
      result.Directory!.Create();

      File.WriteAllText(classToWrite.FilePath, classToWrite.GetText());
    }
  }
}
