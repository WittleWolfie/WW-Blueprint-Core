using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BlueprintCore.Utils;
using BlueprintCore.Internal;
using System.Resources;

namespace BlueprintCore.Utils;

// Based on TabletopTweaks.Utilities.DescriptionTools by Vek17 - https://github.com/Vek17/WrathMods-TabletopTweaks/
public static class EncyclopediaTool
{
  private static readonly LogWrapper Logger = LogWrapper.GetInternal("EncyclopediaTool");

  private static Lazy<EncyclopediaEntry[]> encyclopediaEntries = new Lazy<EncyclopediaEntry[]>(() =>
  {
    try
    {
      var assembly = typeof(EncyclopediaTool).Assembly;
      var resourceName = "BlueprintCore.resources.encyclopedia.json";

      using (Stream stream = assembly.GetManifestResourceStream(resourceName))
      using (StreamReader reader = new StreamReader(stream))
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

  public static string UntagEncyclopediaEntries(string text)
  {
    foreach (var entry in EncyclopediaEntries)
    {
      text = entry.UntagEntry(text);
    }

    return text;
  }

  internal class EncyclopediaEntry
  {
    public string Entry { get; }
    public List<string> Patterns { get; }

    public Regex EntryPattern { get; }
    public EncyclopediaEntry(string entry, List<string> patterns)
    {
      Entry = entry;
      Patterns = patterns;
      EntryPattern = new Regex($@"{{g\|Encyclopedia:{Entry}}}(?<text>.*?){{/g}}");
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
            var context = new MatchContext(match, text);

            if (!context.IsMatchStandaloneWord() || IsAlreadyTagged(context))
            {
              continue;
            }

            text = context.Preceding + this.WrapTextInEntryTag(match.Value) + context.Following;
            return text; // return after tagging first entry
          }
        }
      }

      return text;
    }

    public string UntagEntry(string text)
    {
      return EntryPattern.Replace(text, m => m.Groups["text"].Value);
    }

    private string WrapTextInEntryTag(string text)
    {
      return $"{{g|Encyclopedia:{Entry}}}{text}{{/g}}";
    }

    public static bool IsAlreadyTagged(MatchContext context)
    {
      return Regex.IsMatch(context.Preceding, @"{g\|Encyclopedia:[\w_]*}?\Z") || context.Following.StartsWith("{/g}");
    }
  }
}
