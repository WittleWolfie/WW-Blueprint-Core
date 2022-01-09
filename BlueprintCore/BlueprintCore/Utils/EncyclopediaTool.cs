using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BlueprintCore.Utils;

namespace BlueprintCore.BlueprintCore.Utils;

public static class EncyclopediaTool
{

  private static readonly LogWrapper Logger = LogWrapper.GetInternal("EncyclopediaTool");

  private static Lazy<EncyclopediaEntry[]> encyclopediaEntries = new Lazy<EncyclopediaEntry[]>(() =>
  {
    try
    {
      using (FileStream stream = new FileStream("/resources/encyclopedia.json", FileMode.Open, FileAccess.Read))
      {
        return JsonSerializer.Deserialize<EncyclopediaEntry[]>(stream)!;
      }

    }
    catch (FileNotFoundException ex)
    {
      Logger.Error($"Couldn't read file with Encyclopedia Entries! Message: {ex.Message}");
      throw ex;
    }
  });
  private static EncyclopediaEntry[] EncyclopediaEntries => encyclopediaEntries.Value;

  public static string TagEncyclopediaEntries(string description)
  {
    var result = description;
    result = result.StripHTML();
    foreach (var entry in EncyclopediaEntries)
    {
      foreach (var pattern in entry.Patterns)
      {
        result = result.ApplyTags(pattern, entry);
      }
    }
    return result;
  }

  private class EncyclopediaEntry
  {
    public string Entry = "";
    public List<string> Patterns = new List<string>();

    public string Tag(string keyword)
    {
      return $"{{g|Encyclopedia:{Entry}}}{keyword}{{/g}}";
    }
  }

  private static string ApplyTags(this string str, string from, EncyclopediaEntry entry)
  {
    var pattern = from.EnforceSolo().ExcludeTagged();
    var matches = Regex.Matches(str, pattern, RegexOptions.IgnoreCase)
        .OfType<Match>()
        .Select(m => m.Value)
        .Distinct();
    foreach (string match in matches)
    {
      str = Regex.Replace(str, Regex.Escape(match).EnforceSolo().ExcludeTagged(), entry.Tag(match), RegexOptions.IgnoreCase);
    }
    return str;
  }
  public static string StripHTML(this string str)
  {
    return Regex.Replace(str, "<.*?>", string.Empty);
  }
  public static string StripEncyclopediaTags(this string str)
  {
    return Regex.Replace(str, "{.*?}", string.Empty);
  }
  private static string ExcludeTagged(this string str)
  {
    return $"{@"(?<!{g\|Encyclopedia:\w+}[^}]*)"}{str}{@"(?![^{]*{\/g})"}";
  }
  private static string EnforceSolo(this string str)
  {
    return $"{@"(?<![\w>]+)"}{str}{@"(?![^\s\.,""'<)]+)"}";
  }
}
