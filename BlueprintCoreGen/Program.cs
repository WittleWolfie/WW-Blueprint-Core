using BlueprintCoreGen.Analysis;
using BlueprintCoreGen.CodeGen;
using BlueprintCoreGen.CodeGen.Class;
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
    private static readonly string ActionsDir = "Actions";
    private static readonly string ConditionsDir = "Conditions";
    private static readonly string ConfiguratorsDir = "Configurators";

    static void Main()
    {
      // Clean output directories
      if (Directory.Exists(AnalysisDir)) { Directory.Delete(AnalysisDir, true); }
      if (Directory.Exists(ActionsDir)) { Directory.Delete(ActionsDir, true); }
      if (Directory.Exists(ConditionsDir)) { Directory.Delete(ConditionsDir, true); }
      if (Directory.Exists(ConfiguratorsDir)) { Directory.Delete(ConfiguratorsDir, true); }

      // Since the code doesn't reference assemblies, force load them for reflection
      var gameTypes = AccessTools.GetTypesFromAssembly(Assembly.Load("Assembly-CSharp"));
      var bpCoreTypes = AccessTools.GetTypesFromAssembly(Assembly.Load("BlueprintCore"));

      if (RunTypeUsageAnalysis)
      {
        TypeUsageAnalyzer.Analyze(gameTypes);
        return;
      }

      TypeTool.InitTypesByName(gameTypes, bpCoreTypes);
      ClassProcessor.Run(gameTypes);

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

      ClassProcessor.ConfiguratorClasses.ForEach(configuratorClass => WriteClassToFile(configuratorClass));
    }

    /// <summary>
    /// Generates ActionsBuilder extension classes, then returns a list of unhandled Action types.
    /// </summary>
    private static List<Type> ProcessActions(Type[] gameTypes)
    {
      HashSet<Type> implementedActionTypes = new();
      foreach (IClassFile actionClass in ClassProcessor.ActionClasses)
      {
        WriteClassToFile(actionClass);
        implementedActionTypes.UnionWith(actionClass.GetHandledTypes());
      }
      return ClassProcessor.GetUnhandledTypes(typeof(GameAction), implementedActionTypes, gameTypes);
    }

    /// <summary>
    /// Generates ConditionsBuilder extension classes, then returns a list of unhandled Condition types.
    /// </summary>
    private static List<Type> ProcessConditions(Type[] gameTypes)
    {
      HashSet<Type> implementedConditionTypes = new();
      foreach (IClassFile conditionClass in ClassProcessor.ConditionClasses)
      {
        WriteClassToFile(conditionClass);
        implementedConditionTypes.UnionWith(conditionClass.GetHandledTypes());
      }
      return ClassProcessor.GetUnhandledTypes(typeof(Condition), implementedConditionTypes, gameTypes);
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
