using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Armies;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintLeaderProgression blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class LeaderProgressionRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintLeaderProgression>> WarlordMageProgression = "33b8bf9e76d698d41a23a14720917ecb";
    public static readonly Blueprint<BlueprintReference<BlueprintLeaderProgression>> WarlordRangerProgression = "51b612805a0a4b709c54881c1c575c28";
    public static readonly Blueprint<BlueprintReference<BlueprintLeaderProgression>> WarlordWarriorProgression = "e644dc6971424504aaad9ca02705bad2";

    public static readonly List<Blueprint<BlueprintReference<BlueprintLeaderProgression>>> All =
      new()
      {
          WarlordMageProgression,
          WarlordRangerProgression,
          WarlordWarriorProgression,
      };
  }
}
