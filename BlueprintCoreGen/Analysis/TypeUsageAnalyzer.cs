using BlueprintCoreGen.CodeGen.Methods;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueprintCoreGen.Analysis
{
  public static class TypeUsageAnalyzer
  {
    // When set to a positive number, limits the number of blueprints processed to allow for quicker iteration.
    private static readonly int DebugLimit = -1;
    // How many blueprints to process before reporting on progress & speed
    private static readonly int ReportThreshold = 5000;

    private static readonly ConcurrentDictionary<string, Blueprint> BlueprintsByGuid = new();
    private static readonly ConcurrentDictionary<Type, ConcurrentBag<Blueprint>> ExamplesByType = new();

    public static void Analyze(Type[] gameTypes)
    {
      ProcessDB();

      ProcessUnusedTypes(typeof(GameAction), gameTypes);
      ProcessUnusedTypes(typeof(Condition), gameTypes);
      ProcessUnusedTypes(typeof(BlueprintScriptableObject), gameTypes);
      ProcessUnusedTypes(typeof(BlueprintComponent), gameTypes);

      ProcessExamples(typeof(GameAction));
      ProcessExamples(typeof(Condition));
      ProcessExamples(typeof(BlueprintScriptableObject));
      ProcessExamples(typeof(BlueprintComponent));
    }

    private static void ProcessUnusedTypes(Type baseType, Type[] gameTypes)
    {
      StringBuilder unusedTypes = new();
      gameTypes.Where(t => t.IsSubclassOf(baseType) && !ExamplesByType.ContainsKey(t))
        .ToList()
        .ForEach(t => unusedTypes.AppendLine($"        typeof({t.Name}),"));
      File.WriteAllText($"{Program.AnalysisDir}/unused_{baseType.Name}.txt", unusedTypes.ToString());
    }

    private static void ProcessExamples(Type baseType)
    {
      StringBuilder examples = new();
      var entries = ExamplesByType.Where(entry => entry.Key.IsSubclassOf(baseType));
      foreach (var entry in entries)
      {
        var sortedExamples = entry.Value.OrderBy(ex => ex.BlueprintName).ToList();
        List<Blueprint> exampleBlueprints = new();
        if (exampleBlueprints.Count > 3)
        {
          // Use the first, last, and middle blueprints as examples. This should keep things relatively stable between
          // game patches and avoid biasing towards the first three entries alphabetically.
          exampleBlueprints.Add(sortedExamples.First());
          exampleBlueprints.Add(sortedExamples[sortedExamples.Count / 2]);
          exampleBlueprints.Add(sortedExamples.Last());
        }
        else
        {
          exampleBlueprints.AddRange(sortedExamples);
        }

        examples.AppendLine("");
        examples.AppendLine(@"        {");
        examples.AppendLine($"          typeof({entry.Key.Name}),");
        examples.AppendLine($"          new()");
        examples.AppendLine(@"          {");
        exampleBlueprints.ForEach(
          ex => examples.AppendLine($"            new Blueprint(\"{ex.BlueprintName}\", \"{ex.BlueprintGuid}\"),"));
        examples.AppendLine(@"          },");
        examples.AppendLine(@"        },");
      }
      File.WriteAllText($"{Program.AnalysisDir}/examples_{baseType.Name}.txt", examples.ToString());
    }

    // Populates BlueprintsByGuid and ExamplesByType
    private static void ProcessDB()
    {
      // Note: Need to manually unpack the blueprints.zip file (be sure to delete the existing blueprints directory).
      // Issues w/ .NET library are preventing programmatic unpacking.
      string[] bpFiles =
        Directory.GetFiles(
          Environment.ExpandEnvironmentVariables("%WrathPath%/blueprints"), "*.*", SearchOption.AllDirectories);
      var quarterIndex = bpFiles.Length / 4;
      var halfIndex = quarterIndex * 2;
      var threeQuarterIndex = quarterIndex * 3;
      Parallel.Invoke(
        () => ProcessBpFiles(bpFiles[0..quarterIndex], 1),
        () => ProcessBpFiles(bpFiles[quarterIndex..halfIndex], 2),
        () => ProcessBpFiles(bpFiles[halfIndex..threeQuarterIndex], 3),
        () => ProcessBpFiles(bpFiles[threeQuarterIndex..], 4));

      //ProcessBpZip();
    }

    // Thread safe processor of blueprints files.
    private static int ProcessedCount = 0;
    private static void ProcessBpFiles(string[] bpFiles, int threadNum)
    {
      var processed = 0;
      Stopwatch stopwatch = Stopwatch.StartNew();
      foreach (string file in bpFiles)
      {
        if (!file.EndsWith(".jbp")) { continue; }

        var bp = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(file));

        var guid = bp.Value<string>("AssetId");
        var data = bp.GetValue("Data");
        var bpType = GetType(data);
        // Skip, library only supports BlueprintScriptableObject types
        if (bpType is null || !bpType.IsSubclassOf(typeof(BlueprintScriptableObject))) { continue; }

        // Fetch / create the Blueprint
        if (!BlueprintsByGuid.TryGetValue(guid, out Blueprint blueprint))
        {
          var name = Path.GetFileNameWithoutExtension(file);
          blueprint = new Blueprint(name, guid);
          BlueprintsByGuid.TryAdd(guid, blueprint);
        }

        // Add as an example blueprint type
        if (!ExamplesByType.TryGetValue(bpType, out ConcurrentBag<Blueprint> blueprintExamples))
        {
          blueprintExamples = new();
          ExamplesByType.TryAdd(bpType, blueprintExamples);
        }
        blueprintExamples.Add(blueprint);

        List<Type> referencedTypes = new();
        GetTypes(data, referencedTypes);

        // Add as an example for the referenced action types
        var actionTypes = referencedTypes.Where(type => type.IsSubclassOf(typeof(GameAction)));
        foreach (var actionType in actionTypes)
        {
          if (!ExamplesByType.TryGetValue(actionType, out ConcurrentBag<Blueprint> actionExamples))
          {
            actionExamples = new();
            ExamplesByType.TryAdd(actionType, actionExamples);
          }
          actionExamples.Add(blueprint);
        }

        // Add as an example for the referenced condition types
        var conditionTypes = referencedTypes.Where(type => type.IsSubclassOf(typeof(Condition)));
        foreach (var conditionType in conditionTypes)
        {
          if (!ExamplesByType.TryGetValue(conditionType, out ConcurrentBag<Blueprint> conditionExamples))
          {
            conditionExamples = new();
            ExamplesByType.TryAdd(conditionType, conditionExamples);
          }
          conditionExamples.Add(blueprint);
        }

        // Add as an example for the referenced components types
        var componentTypes = referencedTypes.Where(type => type.IsSubclassOf(typeof(BlueprintComponent)));
        foreach (var componentType in componentTypes)
        {
          if (!ExamplesByType.TryGetValue(componentType, out ConcurrentBag<Blueprint> componentExamples))
          {
            componentExamples = new();
            ExamplesByType.TryAdd(componentType, componentExamples);
          }
          componentExamples.Add(blueprint);
        }

        processed++;
        Interlocked.Increment(ref ProcessedCount);
        if (DebugLimit > 0 && ProcessedCount > DebugLimit) { return; }
        if (processed % ReportThreshold == 0)
        {
          float progress = processed / (float)bpFiles.Length;
          long averageProcessTime = stopwatch.ElapsedMilliseconds / processed;
          Console.WriteLine(
            string.Format("Thread {0} Progress: {1:P2}, {2:D}ms/blueprint", threadNum, progress, averageProcessTime));
        }
      }
    }

    private static Type? GetType(JToken data)
    {
      var typeString = data.Value<string>("$type");
      if (typeString is not null)
      {
        var type = AccessTools.TypeByName(typeString[typeString.IndexOf(" ")..].Trim());
        if (type == null) { Console.WriteLine($"Couldn't find type: {typeString}"); }
        return type;
      }
      return null;
    }

    // Recursively search the JToken to find all referenced types
    private static void GetTypes(JToken data, List<Type> types)
    {
      if (data.Type == JTokenType.Object)
      {
        // Only object types can have a property
        var type = GetType(data);
        if (type is not null) { types.Add(type); }
      }

      // No matter what kind of token, foreach loop will get all children
      foreach (var token in data)
      {
        GetTypes(token, types);
      }
    }

    // Method Bubbles used process the database. In testing this is 10-50% slower and cannot be executed in parallel.
    //private static void ProcessBpZip()
    //{
    //  using var bpDump = ZipFile.OpenRead(Environment.ExpandEnvironmentVariables("%WrathPath%/blueprints.zip"));
    //  var processed = 0;
    //  Stopwatch stopwatch = Stopwatch.StartNew();
    //  foreach (var entry in bpDump.Entries)
    //  {
    //    if (!entry.Name.EndsWith(".jbp")) { continue; }

    //    var stream =
    //      entry
    //        .GetType()
    //        .GetMethod("OpenInReadMode", BindingFlags.NonPublic | BindingFlags.Instance)!
    //        .Invoke(entry, new object[] { false }) as Stream;
    //    var bp = JsonConvert.DeserializeObject<JObject>(new StreamReader(stream!).ReadToEnd());

    //    var guid = bp.Value<string>("AssetId");
    //    var data = bp.GetValue("Data");
    //    var bpType = GetType(data);
    //    // Skip, library only supports BlueprintScriptableObject types
    //    if (bpType is null || !bpType.IsSubclassOf(typeof(BlueprintScriptableObject))) { continue; }

    //    // Fetch / create the Blueprint
    //    if (!BlueprintsByGuid.TryGetValue(guid, out Blueprint blueprint))
    //    {
    //      var name = entry.Name[0..^4];
    //      blueprint = new Blueprint(name, guid);
    //      BlueprintsByGuid.Add(guid, blueprint);
    //    }

    //    // Add as an example blueprint type
    //    if (!ExamplesByType.TryGetValue(bpType, out HashSet<Blueprint> blueprintExamples))
    //    {
    //      blueprintExamples = new();
    //      ExamplesByType.Add(bpType, blueprintExamples);
    //    }
    //    blueprintExamples.Add(blueprint);

    //    List<Type> referencedTypes = new();
    //    GetTypes(data, referencedTypes);

    //    // Add as an example for the referenced action types
    //    var actionTypes = referencedTypes.Where(type => type.IsSubclassOf(typeof(GameAction)));
    //    foreach (var actionType in actionTypes)
    //    {
    //      if (!ExamplesByType.TryGetValue(actionType, out HashSet<Blueprint> actionExamples))
    //      {
    //        actionExamples = new();
    //        ExamplesByType.Add(actionType, actionExamples);
    //      }
    //      actionExamples.Add(blueprint);
    //    }

    //    // Add as an example for the referenced condition types
    //    var conditionTypes = referencedTypes.Where(type => type.IsSubclassOf(typeof(Condition)));
    //    foreach (var conditionType in conditionTypes)
    //    {
    //      if (!ExamplesByType.TryGetValue(conditionType, out HashSet<Blueprint> conditionExamples))
    //      {
    //        conditionExamples = new();
    //        ExamplesByType.Add(conditionType, conditionExamples);
    //      }
    //      conditionExamples.Add(blueprint);
    //    }

    //    // Add as an example for the referenced components types
    //    var componentTypes = referencedTypes.Where(type => type.IsSubclassOf(typeof(BlueprintComponent)));
    //    foreach (var componentType in componentTypes)
    //    {
    //      if (!ExamplesByType.TryGetValue(componentType, out HashSet<Blueprint> componentExamples))
    //      {
    //        componentExamples = new();
    //        ExamplesByType.Add(componentType, componentExamples);
    //      }
    //      componentExamples.Add(blueprint);
    //    }

    //    processed++;
    //    Interlocked.Increment(ref ProcessedCount);
    //    if (DebugLimit > 0 && ProcessedCount > DebugLimit) { return; }
    //    if (processed % 100 == 0)
    //    {
    //      float progress = processed / (float)bpDump.Entries.Count;
    //      long averageProcessTime = stopwatch.ElapsedMilliseconds / processed;
    //      Console.WriteLine(
    //        string.Format("Progress: {0:P2}, {1:D}ms/blueprint", progress, averageProcessTime));
    //    }
    //  }
    //}
  }
}
