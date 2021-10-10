using System;
using System.Collections.Generic;
using System.IO;
using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.EntitySystem.Stats;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlueprintCore.Features
{
  public static class FeaturePrerequisite
  {
    private static readonly LogWrapper Logger = LogWrapper.Get("FeaturePrerequisite");
    private const string CONFIG_PATH = @"Config\FeaturePrerequisites.json";
    private static FeaturePrerequisiteConfig Config { get; set; }

    public static void Load(string modPath)
    {
      var path = Path.Combine(modPath, CONFIG_PATH);
      Logger.Info($"Loading FeaturePrerequisiteConfig: {path}");
      try
      {
        using StreamReader file = File.OpenText(path);
        var serializer = new JsonSerializer();
        Config =
            (FeaturePrerequisiteConfig)serializer.Deserialize(
                file, typeof(FeaturePrerequisiteConfig));
      }
      catch (Exception e)
      {
        Logger.Error("Failed to load FeaturePrerequisiteConfig", e);
      }
    }

    public static void Init()
    {
      Logger.Info("Initializing FeaturePrerequisites");
      foreach (FeaturePatch patch in Config.Patches)
      {
        Logger.Verbose($"Patching {patch.Feature}");
        var feature = BlueprintTool.Get<BlueprintFeature>(patch.Feature);
        if (feature == null)
        {
          Logger.Error($"Failed to configure {patch.Feature} - {Guids.Get(patch.Feature)}");
          return;
        }

        var prerequisiteComponents = new List<BlueprintComponent>();
        if (patch.CharacterLevel > 0)
        {
          Logger.Verbose($"Adding Prerequisite Level: {patch.CharacterLevel}");
          prerequisiteComponents.Add(PrerequisiteCharacterLevel(patch.CharacterLevel));
        }

        foreach (string featureName in patch.PrerequisiteFeatures)
        {
          Logger.Verbose($"Adding Prequisite Feature: {featureName}");
          var prerequisiteFeature = BlueprintTool.Get<BlueprintFeature>(featureName);
          prerequisiteFeature.AddIsPrerequisiteFor(feature);
          prerequisiteComponents.Add(PrerequisiteFeature(prerequisiteFeature));
        }

        foreach (StatPrerequisite stat in patch.PrerequisiteStats)
        {
          Logger.Verbose("Adding Prerequisite Stat: " + stat);
          prerequisiteComponents.Add(PrerequisiteStat(stat));
        }

        feature.AddComponents(prerequisiteComponents.ToArray());
      }
    }

    private static PrerequisiteFeature PrerequisiteFeature(BlueprintFeature feature)
    {
      var prerequisite =
          new PrerequisiteFeature { m_Feature = feature.ToReference<BlueprintFeatureReference>() };
      return prerequisite;
    }

    private static PrerequisiteStatValue PrerequisiteStat(StatPrerequisite stat)
    {
      var prerequisite = new PrerequisiteStatValue { Stat = stat.Type, Value = stat.Value };
      return prerequisite;
    }

    private static PrerequisiteCharacterLevel PrerequisiteCharacterLevel(int level)
    {
      var prerequisite = new PrerequisiteCharacterLevel { Level = level };
      return prerequisite;
    }

    private class FeaturePrerequisiteConfig
    {
      [JsonProperty]
      public List<FeaturePatch> Patches;
    }

    private class FeaturePatch
    {
      [JsonProperty]
      public string Feature;

      [JsonProperty]
      public int CharacterLevel;

      [JsonProperty]
      public List<string> PrerequisiteFeatures = new();

      [JsonProperty]
      public List<StatPrerequisite> PrerequisiteStats = new();
    }

    private class StatPrerequisite
    {
      [JsonProperty]
      [JsonConverter(typeof(StringEnumConverter))]
      public StatType Type;

      [JsonProperty]
      public int Value;

      public override string ToString()
      {
        return $"Type: {Type}, Value: {Value}";
      }
    }
  }
}