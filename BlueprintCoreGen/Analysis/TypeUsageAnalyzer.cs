using BlueprintCoreGen.CodeGen.Methods;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlueprintCoreGen.Analysis
{
  public static class TypeUsageAnalyzer
  {
    private static readonly Dictionary<string, Blueprint> BlueprintsByGuid = new();

    private static readonly Dictionary<Type, HashSet<Blueprint>> ExamplesByType = new();

    public static void Analyze(Type[] gameTypes)
    {
      ProcessDB();

      ProcessUnusedTypes(typeof(GameAction), gameTypes);
      ProcessUnusedTypes(typeof(Condition), gameTypes);
      ProcessUnusedTypes(typeof(BlueprintScriptableObject), gameTypes);
      ProcessUnusedTypes(typeof(BlueprintComponent), gameTypes);


    }

    private static void ProcessUnusedTypes(Type baseType, Type[] gameTypes)
    {
      StringBuilder unusedTypes = new();
      gameTypes.Where(t => t.IsSubclassOf(baseType) && !ExamplesByType.ContainsKey(t))
        .ToList()
        .ForEach(t => unusedTypes.AppendLine($"        typeof({t.Name}),"));
      File.WriteAllText($"{Program.AnalysisDir}/unused_{baseType.Name}.txt", unusedTypes.ToString());
    }

    // Populates BlueprintsByGuid and ExamplesByType
    private static void ProcessDB()
    {
      using var bpDump = ZipFile.OpenRead(Environment.ExpandEnvironmentVariables("%WrathPath%/blueprints.zip"));

      foreach (var entry in bpDump.Entries)
      {
        if (!entry.Name.EndsWith(".jbp")) { continue; }

        var stream =
          entry!
            .GetType()
            .GetMethod("OpenInReadMode", BindingFlags.NonPublic | BindingFlags.Instance)!
            .Invoke(entry, new object[] { false }) as Stream;
        var bp = JsonConvert.DeserializeObject<JObject>(new StreamReader(stream!).ReadToEnd());

        var guid = bp.Value<string>("AssetId");
        var data = bp.GetValue("Data");
        var bpType = GetType(data);
        // Skip, library only supports BlueprintScriptableObject types
        if (!bpType.IsSubclassOf(typeof(BlueprintScriptableObject))) { continue; }

        // Fetch / create the Blueprint
        if (!BlueprintsByGuid.TryGetValue(guid, out Blueprint blueprint))
        {
          var name = entry.Name[0..^4];
          blueprint = new Blueprint(name, guid);
          BlueprintsByGuid.Add(guid, blueprint);
        }

        // Add as an example blueprint type
        if (!ExamplesByType.TryGetValue(bpType, out HashSet<Blueprint> blueprintExamples))
        {
          blueprintExamples = new();
          ExamplesByType.Add(bpType, blueprintExamples);
        }
        blueprintExamples.Add(blueprint);

        List<Type> referencedTypes = GetTypes(data);

        // Add as an example for the referenced action types
        var actionTypes = referencedTypes.Where(type => type.IsSubclassOf(typeof(GameAction)));
        foreach (var actionType in actionTypes)
        {
          if (!ExamplesByType.TryGetValue(actionType, out HashSet<Blueprint> actionExamples))
          {
            actionExamples = new();
            ExamplesByType.Add(actionType, actionExamples);
          }
          actionExamples.Add(blueprint);
        }

        // Add as an example for the referenced condition types
        var conditionTypes = referencedTypes.Where(type => type.IsSubclassOf(typeof(Condition)));
        foreach (var conditionType in conditionTypes)
        {
          if (!ExamplesByType.TryGetValue(conditionType, out HashSet<Blueprint> conditionExamples))
          {
            conditionExamples = new();
            ExamplesByType.Add(conditionType, conditionExamples);
          }
          conditionExamples.Add(blueprint);
        }

        // Add as an example for the referenced components types
        var componentTypes = referencedTypes.Where(type => type.IsSubclassOf(typeof(BlueprintComponent)));
        foreach (var componentType in componentTypes)
        {
          if (!ExamplesByType.TryGetValue(componentType, out HashSet<Blueprint> componentExamples))
          {
            componentExamples = new();
            ExamplesByType.Add(componentType, componentExamples);
          }
          componentExamples.Add(blueprint);
        }
      }
    }

    private static Type GetType(JToken data)
    {
      var typeString = data.Value<string>("$type");
      var typeName = typeString[typeString.IndexOf(" ")..].Trim();
      return GetType(typeName);
    }

    private static Type GetType(string typeName)
    {
      var type = AccessTools.TypeByName(typeName);
      if (type == null) { throw new NullReferenceException($"Couldn't find type: {typeName}"); }
      return type;
    }

    private static readonly Regex TypeMatcher =
      new(@"\""\$type\"": \""[\w\d]*, (\w*)\""", RegexOptions.Compiled);

    private static List<Type> GetTypes(JToken data)
    {
      var stringData = data.ToString();
      List<Type> types = new();
      foreach (Match match in TypeMatcher.Matches(stringData))
      {
        foreach (var typeName in match.Groups)
        {
          // The first matching group is the full regex capture, not the type name.
          if (typeName.ToString() == match.Value) { continue; }
          types.Add(GetType(typeName.ToString()!));
        }
      }
      return types;
    }
  }
}
