using Kingmaker.Localization;
using Kingmaker.Localization.Shared;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BlueprintCore.Utils.Localization
{
  /// <summary>
  /// Contains and manages localization for all available langauges.
  /// </summary>
  /// 
  /// <remarks>Based on code from <see href="https://github.com/Vek17/TabletopTweaks-Core"/>TabletopTweaks-Core</remarks>
  internal class MultiLocalizationPack
  {
    /// <summary>
    /// Dictionary of existing MultiLocaleStrings by Key.
    /// </summary>
    internal readonly Dictionary<string, MultiLocaleString> Strings = new();

    internal MultiLocalizationPack(List<MultiLocaleString> strings)
    {
      foreach (var entry in strings)
      {
        Strings.Add(entry.Key, entry);
      }
    }

    /// <summary>
    /// Generates a new LocalizationPack based on the contents of the MultiLocalizationPack.
    /// </summary>
    internal LocalizationPack GetCurrentPack()
    {
      var pack = new LocalizationPack
      {
        Locale = LocalizationManager.CurrentPack.Locale,
        m_Strings = new Dictionary<string, LocalizationPack.StringEntry>()
      };

      foreach (var entry in Strings)
      {
        pack.m_Strings[entry.Key] = entry.Value.StringEntry(pack.Locale);
      }
      return pack;
    }
  }

  /// <summary>
  /// Contains key used for LocalizedString as well as localized text for all supported lanagues.
  /// </summary>
  [JsonObject(MemberSerialization.OptIn)]
  public class MultiLocaleString
  {
    /// <summary>
    /// Key used to reference the string. Must be unique.
    /// </summary>
    [JsonProperty]
    public readonly string Key = "";

    /// <summary>
    /// Determines if the text will be passed though the tagging system before being added to the current LocalizationPack.
    /// </summary>
    [JsonProperty]
    private readonly bool ProcessTemplates = true;

    /// <summary>
    /// English Text.
    /// </summary>
    [JsonProperty]
    private readonly string enGB = "";

    /// <summary>
    /// Russian Text.
    /// </summary>
    [JsonProperty]
    private readonly string ruRU = "";

    /// <summary>
    /// German Text.
    /// </summary>
    [JsonProperty]
    private readonly string deDE = "";

    /// <summary>
    /// French Text.
    /// </summary>
    [JsonProperty]
    private readonly string frFR = "";

    /// <summary>
    /// Chinese Text.
    /// </summary>
    [JsonProperty]
    private readonly string zhCN = "";

    /// <summary>
    /// Spanish Text.
    /// </summary>
    [JsonProperty]
    private readonly string esES = "";

    /// <summary>
    /// The LocalizedString representation of the the MultiLocaleString.
    /// </summary>
    internal LocalizedString LocalizedString
    {
      get
      {
        m_LocalizedString ??= new LocalizedString
        {
          m_Key = Key,
          m_ShouldProcess = ProcessTemplates
        };
        return m_LocalizedString;
      }
    }
    private LocalizedString? m_LocalizedString;

    /// <summary>
    /// Generates a new StringEntry of the supplied locale.
    /// </summary>
    /// <param name="locale">
    /// Locale to use the text of.
    /// </param>
    /// <returns>
    /// StringEntry containing the text present in specified locale, or Locale.enGB if the text in the specified locale is null.
    /// </returns>
    internal LocalizationPack.StringEntry StringEntry(Locale locale = Locale.enGB)
    {
      string result;
      switch (locale)
      {
        case Locale.enGB:
          result = enGB;
          break;
        case Locale.ruRU:
          result = ruRU;
          break;
        case Locale.deDE:
          result = deDE;
          break;
        case Locale.frFR:
          result = frFR;
          break;
        case Locale.zhCN:
          result = zhCN;
          break;
        case Locale.esES:
          result = esES;
          break;
        default:
          result = enGB;
          break;
      }
      if (string.IsNullOrEmpty(result))
      {
        result = enGB;
      }

      return new LocalizationPack.StringEntry
      {
        Text = ProcessTemplates ? EncyclopediaTool.TagEncyclopediaEntries(result) : result
      };
    }

    public override string ToString()
    {
      return StringEntry(LocalizationManager.CurrentLocale).Text;
    }

    public override int GetHashCode()
    {
      return Key.GetHashCode() ^ enGB.GetHashCode();
    }
  }
}
