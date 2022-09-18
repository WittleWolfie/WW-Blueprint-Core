using BlueprintCore.Utils.Localization;
using HarmonyLib;
using Kingmaker.Localization;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

#nullable enable
namespace BlueprintCore.Utils
{
  /// <summary>
  /// Utilities for working with <see cref="LocalizedString"/>.
  /// </summary>
  /// 
  /// <remarks>
  /// By default it assumes your mod's local strings are contained in the file LocalizedStrings.json in the same
  /// directory as the assembly. If you keep it in a different location you can call
  /// <see cref="LoadLocalizationPack(string)"/>.
  /// </remarks>
  public class LocalizationTool
  {
    private static readonly LogWrapper Logger = LogWrapper.GetInternal("LocalizationTool");
    private static MultiLocalizationPack LocalizationPack
    {
      get
      {
        if (localizationPack is null)
        {
          var dir = Path.GetDirectoryName(Assembly.GetAssembly(typeof(LocalizationTool)).Location);
          LoadLocalizationPacks(Directory.GetFiles(dir, "*Strings.json"));
        }
        return localizationPack!;
      }
    }
    private static MultiLocalizationPack? localizationPack;

    /// <summary>
    /// Loads localized strings from a JSON file.
    /// </summary>
    /// 
    /// <remarks></remarks>
    /// 
    /// <param name="localizedStringsFile">JSON file with an array of <see cref="MultiLocaleString"/> values</param>
    public static void LoadLocalizationPack(string localizedStringsFile)
    {
      LoadLocalizationPacks(localizedStringsFile);
    }

    /// <summary>
    /// Loads localized strings from an array of JSON files.
    /// </summary>
    /// 
    /// <remarks>
    /// Use only this or <see cref="LoadEmbeddedLocalizationPacks(string[])"/>. Using both will result in errors. By
    /// default all files ending in "Strings.json" in the assembly directory are loaded.
    /// </remarks>
    /// 
    /// <param name="stringFiles">
    /// Array of file paths, each of which is a JSON file with an array of <see cref="MultiLocaleString"/> values
    /// </param>
    public static void LoadLocalizationPacks(params string[] stringFiles)
    {
      localizationPack = new();
      foreach (var file in stringFiles)
      {
        if (!File.Exists(file))
          Logger.Warn($"File does not exist: {file}");

        JArray array = JArray.Parse(File.ReadAllText(file));
        localizationPack!.AddStrings(array.ToObject<List<MultiLocaleString>>());
        Logger.Info($"Localized strings loaded from file: {file}");
      }

      // This registers the strings with the game library.
      LocalizationManager.CurrentPack.AddStrings(localizationPack.GetCurrentPack());
    }

    /// <summary>
    /// Loads localized strings from an array of embedded JSON files.
    /// </summary>
    /// 
    /// <remarks>
    /// It is recommended to only use this or <see cref="LoadLocalizationPack(string)"/>. Load performance is improved
    /// using this method. Using both will result in errors. By default all files ending in "Strings.json" in the
    /// assembly directory are loaded.
    /// </remarks>
    /// 
    /// <param name="resourceNames">
    /// Array of resource names, each of which is a JSON file with an array of <see cref="MultiLocaleString"/> values
    /// </param>
    public static void LoadEmbeddedLocalizationPacks(params string[] resourceNames)
    {
      localizationPack = new();
      var assembly = Assembly.GetExecutingAssembly();
      foreach (var resource in resourceNames)
      {
        using (var stream = assembly.GetManifestResourceStream(resource))
        {
          if (stream is null)
          {
            Logger.Warn($"Resource does not exist: {resource}");
            continue;
          }
          using (var reader = new StreamReader(stream))
          {
            JArray array = JArray.Parse(reader.ReadToEnd());
            localizationPack!.AddStrings(array.ToObject<List<MultiLocaleString>>());
            Logger.Info($"Localized strings loaded from resource: {resource}");
          }
        }
      }

      // This registers the strings with the game library.
      LocalizationManager.CurrentPack.AddStrings(localizationPack.GetCurrentPack());
    }

    /// <summary>
    /// Returns a localized string with the provided <c>key</c> and <c>value</c>.
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    /// Use of this method is discouraged. Prefer definining a localization pack. See TODO: LINK TO DOCS for more
    /// details.
    /// </para>
    /// 
    /// <para>
    /// Calls <see cref="EncyclopediaTool.TagEncyclopediaEntries(string)"/> on <c>value</c> by default. Override
    /// <paramref name="tagEncyclopediaEntries"/> if this is not desired.
    /// </para>
    /// </remarks>
    public static LocalizedString CreateString(string key, string value, bool tagEncyclopediaEntries = true)
    {
      var taggedValue =
          tagEncyclopediaEntries ? EncyclopediaTool.TagEncyclopediaEntries(value) : value;
      if (LocalizationPack.Strings.ContainsKey(key))
      {
        var localString = LocalizationPack.Strings[key];
        if (!localString.StringEntry(LocalizationManager.CurrentPack.Locale).Equals(taggedValue))
        {
          throw new InvalidOperationException($"String with key {key} already exists with a different value.");
        }
        return localString.LocalizedString;
      }

      var localizedString = new LocalizedString() { m_Key = key };
      var currentString = LocalizationManager.CurrentPack.GetText(key, reportUnknown: false);
      if (!string.IsNullOrEmpty(currentString))
      {
        if (currentString.Equals(taggedValue))
        {
          Logger.Info($"Localized string already exists with key {key} and matching value.");
        }
        else
        {
          throw new InvalidOperationException($"String with key {key} already exists with a different value.");
        }
      }
      else
      {
        LocalizationManager.CurrentPack.PutString(key, taggedValue);
      }

      return localizedString;
    }

    /// <summary>
    /// Returns the localized string matching the current key.
    /// </summary>
    public static LocalizedString GetString(string key)
    {
      if (LocalizationPack.Strings.ContainsKey(key)) { return LocalizationPack.Strings[key].LocalizedString; }

      var localizedString = LocalizationManager.CurrentPack.GetText(key, reportUnknown: false);
      if (string.IsNullOrEmpty(localizedString))
      {
        throw new InvalidOperationException($"No string exists with key {key}");
      }
      return new() { m_Key = key };
    }

    [HarmonyPatch(typeof(LocalizationManager))]
    static class LocalizationManager_Patch
    {
      [HarmonyPatch(nameof(LocalizationManager.OnLocaleChanged)), HarmonyPostfix]
      static void Postfix()
      {
        try
        {
          LocalizationManager.CurrentPack.AddStrings(LocalizationPack.GetCurrentPack());
        }
        catch (Exception e)
        {
          Logger.Error("Failed handle locale change.", e);
        }
      }
    }
  }

  /// <summary>
  /// Wrapper around <see cref="Kingmaker.Localization.LocalizedString"/> for implicit casts.
  /// </summary>
  public class LocalString
  {
    public readonly LocalizedString LocalizedString;

    private LocalString(string key)
    {
      LocalizedString = new LocalizedString() { m_Key = key };
    }

    private LocalString(LocalizedString localizedString)
    {
      LocalizedString = localizedString;
    }

    public static implicit operator LocalString(string key)
    {
      return new(key);
    }

    public static implicit operator LocalString(LocalizedString localizedString)
    {
      return new(localizedString);
    }
  }
}
