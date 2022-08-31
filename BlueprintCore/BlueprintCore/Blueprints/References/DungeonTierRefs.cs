using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintDungeonTier blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class DungeonTierRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonTier>> DungeonTier1 = "d68be5d8f98948948733a36430c80583";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonTier>> DungeonTier2 = "c0741b8adfb44444a9778b6df2401841";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonTier>> DungeonTier3 = "d56fca8053974a30bf53a8b4004add71";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonTier>> DungeonTier4 = "503d0d4a270c435cbd3cc59f828c447a";

    public static readonly List<Blueprint<BlueprintReference<BlueprintDungeonTier>>> All =
      new()
      {
          DungeonTier1,
          DungeonTier2,
          DungeonTier3,
          DungeonTier4,
      };
  }
}
