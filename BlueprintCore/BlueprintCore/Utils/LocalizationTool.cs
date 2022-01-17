using Kingmaker.Localization;
using System.Collections.Generic;
using System;

#nullable enable
namespace BlueprintCore.Utils
{
  // TODO: Improve this tool. Consider using TTT's localization.

  /// <summary>
  /// Utilities for working with <see cref="LocalizedString"/>.
  /// </summary>
  /// 
  /// <remarks>Based on code from <see href="https://github.com/Vek17/WrathMods-TabletopTweaks"/>TabletopTweaks</remarks>
  public class LocalizationTool
  {
    private static readonly LogWrapper Logger = LogWrapper.GetInternal("LocalizationTool");
    private static readonly Dictionary<string, LocalString> keyToLocalString = new();

    /// <summary>
    /// Returns a localized string with the provided <c>key</c> and <c>value</c>.
    /// </summary>
    /// 
    /// <remarks>
    /// Calls <see cref="EncyclopediaTool.TagEncyclopediaEntries(string)"/> on <c>value</c> by default. Override
    /// <paramref name="tagEncyclopediaEntries"/> if this is not desired.
    /// </remarks>
    public static LocalizedString CreateString(string key, string value, bool tagEncyclopediaEntries = true)
    {
      var taggedValue =
          tagEncyclopediaEntries ? EncyclopediaTool.TagEncyclopediaEntries(value) : value;
      if (keyToLocalString.ContainsKey(key))
      {
        var localString = keyToLocalString[key];
        if (!localString.Value.Equals(taggedValue))
        {
          throw new InvalidOperationException($"String with key {key} already exists with a different value.");
        }
        return localString.KmLocalString;
      }

      var localizedString = new LocalizedString() { m_Key = key };
      var stringsPack = LocalizationManager.CurrentPack.Strings;
      if (stringsPack.ContainsKey(key))
      {
        if (stringsPack[key].Equals(taggedValue))
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
        stringsPack.Add(key, taggedValue);
      }

      keyToLocalString.Add(key, new(localizedString, taggedValue));
      return localizedString;
    }

    /// <summary>
    /// Returns the localized string created using <see cref="CreateString(string, string, bool)"/> with the specified
    /// <c>key</c>.
    /// </summary>
    public static LocalizedString GetString(string key)
    {
      if (keyToLocalString.ContainsKey(key))
      {
        return keyToLocalString[key].KmLocalString;
      }
      throw new InvalidOperationException($"No string exists with key {key}");
    }

    private class LocalString
    {
      public readonly LocalizedString KmLocalString;
      public readonly string Value;

      public LocalString(LocalizedString kmLocalString, string value)
      {
        KmLocalString = kmLocalString;
        Value = value;
      }
    }
  }
}
