using HarmonyLib;
using Kingmaker.ElementsSystem;
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

      TemplateProcessor.Run();

      HashSet<Type> implementedActionTypes = new();
      foreach (Template template in TemplateProcessor.ActionTemplates)
      {
        // Create the directories if necessary
        FileInfo result = new FileInfo(template.RelativePath);
        result.Directory.Create();

        File.WriteAllText(template.RelativePath, template.GetClassText());
        implementedActionTypes.UnionWith(template.GetImplementedTypes());
      }

      List<Type> actionsToGenerate = new();
      foreach (Type actionType in gameTypes.Where(t => t.IsSubclassOf(typeof(GameAction))))
      {
        if (!actionType.IsAbstract && !implementedActionTypes.Contains(actionType))
        {
          Console.WriteLine(actionType);
          actionsToGenerate.Add(actionType);
        }
      }

      StringBuilder missingTypes = new();
      missingTypes.AppendLine("Missing Action Types:");
      actionsToGenerate.ForEach(actionType => missingTypes.AppendLine($"// [Generate({actionType})]"));

      File.WriteAllText("missing_types.txt", missingTypes.ToString());
    }
  }
}
