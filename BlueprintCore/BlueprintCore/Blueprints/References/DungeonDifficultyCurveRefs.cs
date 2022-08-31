using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintDungeonDifficultyCurve blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class DungeonDifficultyCurveRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonDifficultyCurve>> DungeonDifficultyCurveEasy = "0fc74ba15c184243a1f8c8f1275b8897";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonDifficultyCurve>> DungeonDifficultyCurveHard = "bfd32e7156b14d4fb8cda8b28cf706e6";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonDifficultyCurve>> DungeonDifficultyCurveNormal = "b66706d82b8d4154a259d0fac8d40185";

    public static readonly List<Blueprint<BlueprintReference<BlueprintDungeonDifficultyCurve>>> All =
      new()
      {
          DungeonDifficultyCurveEasy,
          DungeonDifficultyCurveHard,
          DungeonDifficultyCurveNormal,
      };
  }
}
