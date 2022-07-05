using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Utils.Types
{
  /// <summary>
  /// Builder utility for <see cref="LevelEntry"/> arrays.
  /// </summary>
  public class LevelEntryBuilder
  {
    private static readonly List<LevelEntry> LevelEntries = new();

    public static LevelEntryBuilder New()
    {
      return new();
    }

    /// <summary>
    /// Adds a new <see cref="LevelEntry"/> for the given level.
    /// </summary>
    public LevelEntryBuilder AddEntry(int level, params Blueprint<BlueprintFeatureBaseReference>[] features)
    {
      LevelEntries.Add(
        new()
        {
          Level = level,
          m_Features = features.Select(f => f.Reference).ToList()
        });
      return this;
    }

    /// <summary>
    /// Returns a <see cref="UIGroup"/> array.
    /// </summary>
    public LevelEntry[] GetEntries()
    {
      return LevelEntries.ToArray();
    }
  }
}
