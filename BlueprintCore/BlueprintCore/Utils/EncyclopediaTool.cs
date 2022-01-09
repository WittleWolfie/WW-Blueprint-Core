using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BlueprintCore.Utils;
using BlueprintCore.BlueprintCore.Extensions;

namespace BlueprintCore.BlueprintCore.Utils;
public static class EncyclopediaTool
{
  private static readonly LogWrapper Logger = LogWrapper.GetInternal("EncyclopediaTool");

  // TODO: Add this file to NuGet Spec.
  private static Lazy<EncyclopediaEntry[]> encyclopediaEntries = new Lazy<EncyclopediaEntry[]>(() =>
  {
    try
    {
      using (FileStream stream = new FileStream("resources/encyclopedia.json", FileMode.Open, FileAccess.Read))
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
  internal static EncyclopediaEntry[] EncyclopediaEntries => encyclopediaEntries.Value;


  public static string TagEncyclopediaEntries(string text)
  {
    foreach (var entry in EncyclopediaEntries)
    {
      text = entry.TagEntry(text);
    }

    return text;
  }

  public static string UntagEncyclopediaEntry(string text)
  {
    foreach (var entry in EncyclopediaEntries)
    {
      text = entry.UntagEntry(text);
    }

    return text;
  }

  internal class EncyclopediaEntry
  {
    public string Entry { get; set; }
    public List<string> Patterns { get; set; }

    public Regex EntryPattern { get; }
    public EncyclopediaEntry(string entry, List<string> patterns)
    {
      Entry = entry;
      Patterns = patterns;
      EntryPattern = new Regex($@"{{g|Encyclopedia:{Entry}}}(?<text>.*?){{/g}}");
    }

    public string TagEntry(string text)
    {
      foreach (var pattern in this.Patterns)
      {
        // Changed from Vek implementation because it seems that vanilla game only tags each entry once in a description
        var matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);
        foreach (Match match in matches)
        {
          if (match.Success)
          {
            string preceding = text.Substring(0, match.Index);
            string following = text.Substring(match.GetEnd());

            // TODO: break into seperate methods

            // check if is standalone word
            bool precedingOk = preceding.Length > 0 ? char.IsWhiteSpace(preceding.Last()) || char.IsPunctuation(preceding.Last()) : true;
            bool followingOk = following.Length > 0 ? char.IsWhiteSpace(following.First()) || char.IsPunctuation(following.First()) : true;

            if (!precedingOk || !followingOk)
            {
              continue;
            }

            // check if is already tagged
            if (Regex.IsMatch(preceding, @"{g\|Encyclopedia:[\w_]*}?\Z") || following.StartsWith("{/g}"))
            {
              continue;
            }


            text = preceding + this.WrapTextInEntryTag(match.Value) + following;
            return text; // return after tagging first entry
          }
        }
      }

      return text;
    }

    public string UntagEntry(string text)
    {
      foreach (var pattern in Patterns)
      {
        text = Regex.Replace(text, pattern, m => m.Groups["text"].Value);
      }

      return text;
    }

    private string WrapTextInEntryTag(string text)
    {
      return $"{{g|Encyclopedia:{Entry}}}{text}{{/g}}";
    }
  }
}
