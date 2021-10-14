using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Newtonsoft.Json;

namespace BlueprintCore.Features
{
  public static class FeatureSelection
  {
    private static readonly LogWrapper Logger = LogWrapper.GetInternal("FeatureSelection");
    private const string CONFIG_PATH = @"Config\FeatureSelections.json";
    private static FeatureSelectionConfig Config { get; set; }

    public static void Load(string modPath)
    {
      var path = Path.Combine(modPath, CONFIG_PATH);
      Logger.Info($"Loading FeatureSelectionConfig: {path}");
      try
      {
        using StreamReader file = File.OpenText(path);
        var serializer = new JsonSerializer();
        Config =
            (FeatureSelectionConfig)serializer.Deserialize(file, typeof(FeatureSelectionConfig));
      }
      catch (Exception e)
      {
        Logger.Error("Failed to load FeatureSelectionConfig.", e);
      }
    }

    public static void Init()
    {
      Logger.Info("Initalizing FeatureSelections");
      foreach (FeatureSelectionPatch patch in Config.Patches)
      {
        Logger.Verbose($"Initializing {patch.FeatureSelection}");
        var selection = BlueprintTool.Get<BlueprintFeatureSelection>(patch.FeatureSelection);
        if (selection == null)
        {
          Logger.Error(
              $"Failed to configure {patch.FeatureSelection}"
              + $" - {Guids.Get(patch.FeatureSelection)}");
          return;
        }

        foreach (string feature in patch.Features)
        {
          var featureRef = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
          Logger.Verbose($"Adding {feature}");
          if (featureRef != null && !selection.m_AllFeatures.Contains(featureRef))
          {
            selection.m_AllFeatures = selection.m_AllFeatures.AppendToArray(featureRef);
          }
          else
          {
            Logger.Error($"Failed to add {feature} - {Guids.Get(feature)}");
          }
        }
      }
    }

    private class FeatureSelectionConfig
    {
      [JsonProperty]
      public List<FeatureSelectionPatch> Patches;
    }

    private class FeatureSelectionPatch
    {
      [JsonProperty]
      public string FeatureSelection;

      [JsonProperty]
      public List<string> Features;
    }
  }
}