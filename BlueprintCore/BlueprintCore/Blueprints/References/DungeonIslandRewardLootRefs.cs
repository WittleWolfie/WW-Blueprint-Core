using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintDungeonIslandRewardLoot blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class DungeonIslandRewardLootRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandRewardLoot>> RewardLoot_BesmaraBoss = "bc8bf25e3038475e9a2cc9cfddfc1ee6";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandRewardLoot>> RewardLoot_BesmaraMap = "79f67f580f39443680006d19cac9d448";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandRewardLoot>> RewardLoot_ConsumablePotion_Tier1 = "e3668297e1854021b5ede80085fa6fb5";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandRewardLoot>> RewardLoot_ConsumablePotion_Tier1_close = "f96a1f37fcd6427d81c85cf0cd7ba92b";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandRewardLoot>> RewardLoot_ConsumablePotion_Tier2 = "31e85f3a88834eb2a5d408d7dee0f591";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandRewardLoot>> RewardLoot_ConsumablePotion_Tier3 = "fe9a293a97f9465cbbc6617f679c5b78";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandRewardLoot>> RewardLoot_ConsumableScroll = "95cc950f13dc464da7b9b855b87afd54";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandRewardLoot>> RewardLoot_Mythic = "d22faf6d11b64cbc97c075bbe2428204";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandRewardLoot>> RewardLoot_UnqiueRanomItem = "5f64801c22e34752a7854f03b20e2494";

    public static readonly List<Blueprint<BlueprintReference<BlueprintDungeonIslandRewardLoot>>> All =
      new()
      {
          RewardLoot_BesmaraBoss,
          RewardLoot_BesmaraMap,
          RewardLoot_ConsumablePotion_Tier1,
          RewardLoot_ConsumablePotion_Tier1_close,
          RewardLoot_ConsumablePotion_Tier2,
          RewardLoot_ConsumablePotion_Tier3,
          RewardLoot_ConsumableScroll,
          RewardLoot_Mythic,
          RewardLoot_UnqiueRanomItem,
      };
  }
}
