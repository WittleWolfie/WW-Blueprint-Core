using BlueprintCore.Utils.Localization;
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
          LoadLocalizationPack(
            Path.Combine(
              Path.GetDirectoryName(Assembly.GetAssembly(typeof(LocalizationTool)).Location),
              "LocalizedStrings.json"));
        }
        return localizationPack!;
      }
    }
    private static MultiLocalizationPack? localizationPack;

    /// <summary>
    /// Loads localized strings from a JSON file.
    /// </summary>
    /// 
    /// <remarks>
    /// Only a single file will be loaded at once; you shouldn't need to call this multiple times.
    /// </remarks>
    /// 
    /// <param name="localizedStringsFile">JSON file with an array of <see cref="MultiLocaleString"/> values</param>
    public static void LoadLocalizationPack(string localizedStringsFile)
    {
      JArray array = JArray.Parse(localizedStringsFile);
      localizationPack = new(array.ToObject<List<MultiLocaleString>>());
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
  }
}
