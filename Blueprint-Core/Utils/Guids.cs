using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace BlueprintCore.Utils
{
  public static class Guids
  {
    private static readonly LogWrapper Logger = LogWrapper.GetInternal("Guids");
    private const string CONFIG_PATH = @"Config\Guids.json";
    private static GuidsConfig Config { get; set; }

    public static void Load(string modPath)
    {
      var path = Path.Combine(modPath, CONFIG_PATH);
      Logger.Info($"Loading Guids: {path}");
      try
      {
        using StreamReader file = File.OpenText(path);
        var serializer = new JsonSerializer();
        Config = (GuidsConfig)serializer.Deserialize(file, typeof(GuidsConfig));
      }
      catch (Exception e)
      {
        Logger.Error("Failed to load Guids", e);
      }
    }

    public static string Get(string name)
    {
      if (!Config.GuidByName.ContainsKey(name))
      {
        Logger.Error($"Guid not found: {name}");
        return null;
      }
      return Config.GuidByName[name];
    }

    private class GuidsConfig
    {
      [JsonProperty]
      public Dictionary<string, string> GuidByName;
    }
  }
}