using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintDungeonIslandReward blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class DungeonIslandRewardRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandReward>> Reward1 = "c3323b1c1cc94a59a5df85692baaf227";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandReward>> Reward2 = "c66fd9d6710342a192c1c4326c5072e3";

    public static readonly List<Blueprint<BlueprintReference<BlueprintDungeonIslandReward>>> All =
      new()
      {
          Reward1,
          Reward2,
      };
  }
}
