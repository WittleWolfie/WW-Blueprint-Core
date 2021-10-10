using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Newtonsoft.Json;

namespace BlueprintCore.Features
{
  public static class Progression
  {
    private static readonly LogWrapper Logger = LogWrapper.Get("Progression");
    private const string CONFIG_PATH = @"Config\Progression.json";
    private static ProgressionConfig Config { get; set; }

    public static void Load(string modPath)
    {
      var path = Path.Combine(modPath, CONFIG_PATH);
      Logger.Info($"Loading ProgressionConfig: {path}");
      try
      {
        using StreamReader file = File.OpenText(path);
        var serializer = new JsonSerializer();
        Config = (ProgressionConfig)serializer.Deserialize(file, typeof(ProgressionConfig));
      }
      catch (Exception e)
      {
        Logger.Error("Failed to load ProgressionConfig", e);
      }
    }

    public static void Init()
    {
      Logger.Info("Initializing Progressions");
      foreach (ProgressionPatch patch in Config.Patches)
      {
        Logger.Verbose($"Patching {patch.Progression}");
        var progression = BlueprintTool.Get<BlueprintProgression>(patch.Progression);
        if (progression == null)
        {
          Logger.Error($"Failed to configure {patch.Progression} - {Guids.Get(patch.Progression)}");
          return;
        }

        var newLevelEntries = new List<LevelEntry>();
        foreach (ProgressionLevel level in patch.Levels)
        {
          Logger.Verbose($"Adding Level Entry {level.Level}");
          var levelEntry =
              progression.LevelEntries.FirstOrDefault(entry => entry.Level == level.Level);
          if (levelEntry == null)
          {
            Logger.Verbose("Creating new level entry");
            levelEntry = new LevelEntry();
            newLevelEntries.Add(levelEntry);
          }

          List<BlueprintFeatureBase> baseFeatures = levelEntry.Features.ToList();
          foreach (string baseFeature in level.BaseFeatures)
          {
            Logger.Verbose($"Adding {baseFeature}");
            baseFeatures.Add(BlueprintTool.Get<BlueprintFeatureBase>(baseFeature));
          }
          levelEntry.SetFeatures(baseFeatures);
        }

        progression.LevelEntries =
            progression.LevelEntries.AppendToArray(newLevelEntries.ToArray());
      }
    }

    private class ProgressionConfig
    {
      [JsonProperty]
      public List<ProgressionPatch> Patches;
    }

    private class ProgressionPatch
    {
      [JsonProperty]
      public string Progression;

      [JsonProperty]
      public List<ProgressionLevel> Levels = new();
    }

    private class ProgressionLevel
    {
      [JsonProperty]
      public int Level;

      [JsonProperty]
      public List<string> BaseFeatures = new();
    }
  }
}