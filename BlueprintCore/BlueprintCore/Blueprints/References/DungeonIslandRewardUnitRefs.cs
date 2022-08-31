using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintDungeonIslandRewardUnit blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class DungeonIslandRewardUnitRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandRewardUnit>> RewardTrader_Mercenary = "68fe5bbe916741af97b12a2a55026660";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandRewardUnit>> RewardTrader_Mercenary_def = "dcf127e7e0f64bdf865ff6780d81d169";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandRewardUnit>> RewardTrader_Tier1 = "eafdfd0604324a439b92b19e99d8bb51";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandRewardUnit>> RewardTrader_Tier2 = "803540e81bd84540a8b552bbd04ef2de";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandRewardUnit>> RewardTrader_Tier3 = "b92e487220524c0f945a36436994d2f8";

    public static readonly List<Blueprint<BlueprintReference<BlueprintDungeonIslandRewardUnit>>> All =
      new()
      {
          RewardTrader_Mercenary,
          RewardTrader_Mercenary_def,
          RewardTrader_Tier1,
          RewardTrader_Tier2,
          RewardTrader_Tier3,
      };
  }
}
