using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Flags;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintKingdomMoraleFlag blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class KingdomMoraleFlagRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintKingdomMoraleFlag>> KingdomMoraleFlagChapter2 = "6195e82164ff47d3a67ff5fd0d74d5e3";
    public static readonly Blueprint<BlueprintReference<BlueprintKingdomMoraleFlag>> KingdomMoraleFlagChapter2ToDrezen = "09874ec957514a6b9a8ad26a26c2d638";
    public static readonly Blueprint<BlueprintReference<BlueprintKingdomMoraleFlag>> KingdomMoraleFlagChapter3 = "244ac0d9e51646a485443bc3bc9a0df4";
    public static readonly Blueprint<BlueprintReference<BlueprintKingdomMoraleFlag>> KingdomMoraleFlagChapter3Regions = "d04ff8f15c034f56bcfbad952a74bdb3";
    public static readonly Blueprint<BlueprintReference<BlueprintKingdomMoraleFlag>> KingdomMoraleFlagChapter3Siege = "0b405fd736f54c05b65aaee855ad585e";
    public static readonly Blueprint<BlueprintReference<BlueprintKingdomMoraleFlag>> KingdomMoraleFlagChapter5 = "feb5d6bf90404f41b573f096a9f5d93a";
    public static readonly Blueprint<BlueprintReference<BlueprintKingdomMoraleFlag>> KingdomMoraleFlagChapter5Regions = "b01624ee06444738964b678259f31a20";
    public static readonly Blueprint<BlueprintReference<BlueprintKingdomMoraleFlag>> KingdomMoraleFlagChapter5Siege = "97f654fb595348b4a492ef17baf2af04";
    public static readonly Blueprint<BlueprintReference<BlueprintKingdomMoraleFlag>> TestKingdomMoraleFlag1 = "68eb911a507f4d4cb013b686692faf92";
    public static readonly Blueprint<BlueprintReference<BlueprintKingdomMoraleFlag>> TestKingdomMoraleFlag2 = "d06cada97da44b438fb6e35d1f7bc743";
    public static readonly Blueprint<BlueprintReference<BlueprintKingdomMoraleFlag>> TestKingdomMoraleFlag3 = "1711a55113a843ce8032dfaa513be9fd";

    public static readonly List<Blueprint<BlueprintReference<BlueprintKingdomMoraleFlag>>> All =
      new()
      {
          KingdomMoraleFlagChapter2,
          KingdomMoraleFlagChapter2ToDrezen,
          KingdomMoraleFlagChapter3,
          KingdomMoraleFlagChapter3Regions,
          KingdomMoraleFlagChapter3Siege,
          KingdomMoraleFlagChapter5,
          KingdomMoraleFlagChapter5Regions,
          KingdomMoraleFlagChapter5Siege,
          TestKingdomMoraleFlag1,
          TestKingdomMoraleFlag2,
          TestKingdomMoraleFlag3,
      };
  }
}
