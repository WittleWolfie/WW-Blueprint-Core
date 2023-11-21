using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintDungeonModificator blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class DungeonModificatorRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonModificator>> DungeonModificatorArcane = "4328c8b0356b4e21b13400fbf14412a2";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonModificator>> DungeonModificatorBesmarites = "14edcd6f662c453183aa9c1295306a2b";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonModificator>> DungeonModificatorDevilRage = "15a1186ed09c4ea9848d125d61403428";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonModificator>> DungeonModificatorElemental_Air = "bb64ce9b7c4f4d608418864dc1a6c007";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonModificator>> DungeonModificatorElemental_Earth = "a7df703c961e410e9c24269631370f51";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonModificator>> DungeonModificatorElemental_Fire = "01a70753a5f34e198b7b3bd97e8c9b0a";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonModificator>> DungeonModificatorElemental_Water = "62768248d0b8453f8f83915c3f76fee6";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonModificator>> DungeonModificatorElementalLocust = "44ff5ead17a0419ba15b5ad2b01f200f";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonModificator>> DungeonModificatorGigantic = "bbf7bbb3544942018b949e5b2a5814cf";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonModificator>> DungeonModificatorHot = "488374c585394717a689354c714b1fa9";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonModificator>> DungeonModificatorIllnessAndCannibalism = "a507161dd0724e5cb6fb16caa0003556";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonModificator>> DungeonModificatorIllusionary = "60169e75789d4c93acc21d851d29965c";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonModificator>> DungeonModificatorMindControl = "d65481ede93c4826b98b78cb585ea0f7";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonModificator>> DungeonModificatorNegativeEnergy = "461523b537f04734805802d4c91b5e1c";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonModificator>> DungeonModificatorShadowPlaneMagic = "c193257819294a9ca5a717f5fd7b5daf";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonModificator>> DungeonModificatorShadowVeil = "37bfaab150f24acf8481c1519e273cf4";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonModificator>> DungeonModificatorTemporalAnomalies = "1ecda3378b5f4435b9cfa974b68a52e9";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonModificator>> DungeonModificatorUncotrollableRage = "da74c014108547599047f6dca1937df4";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonModificator>> DungeonModificatorWildMagic = "9106be5b6d5d4423bbd538be3dfe6464";

    public static readonly List<Blueprint<BlueprintReference<BlueprintDungeonModificator>>> All =
      new()
      {
          DungeonModificatorArcane,
          DungeonModificatorBesmarites,
          DungeonModificatorDevilRage,
          DungeonModificatorElemental_Air,
          DungeonModificatorElemental_Earth,
          DungeonModificatorElemental_Fire,
          DungeonModificatorElemental_Water,
          DungeonModificatorElementalLocust,
          DungeonModificatorGigantic,
          DungeonModificatorHot,
          DungeonModificatorIllnessAndCannibalism,
          DungeonModificatorIllusionary,
          DungeonModificatorMindControl,
          DungeonModificatorNegativeEnergy,
          DungeonModificatorShadowPlaneMagic,
          DungeonModificatorShadowVeil,
          DungeonModificatorTemporalAnomalies,
          DungeonModificatorUncotrollableRage,
          DungeonModificatorWildMagic,
      };
  }
}
