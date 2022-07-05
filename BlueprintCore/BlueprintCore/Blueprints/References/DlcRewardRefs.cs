using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DLC;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintDlcReward blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class DlcRewardRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintDlcReward>> DlcCommanderPackReward = "52e2a91ac53442a594a413007c302d83";
    public static readonly Blueprint<BlueprintReference<BlueprintDlcReward>> DlcKickstarterPremiumReward = "62b96baa0fdc46a186bb58cd23cf92d6";
    public static readonly Blueprint<BlueprintReference<BlueprintDlcReward>> DlcKickstarterReward = "546913f3c89f43f9af2d4a41c99d4f3a";
    public static readonly Blueprint<BlueprintReference<BlueprintDlcReward>> DlcPreorderReward = "9c7455d14c814b149e929401af9f6a14";
    public static readonly Blueprint<BlueprintReference<BlueprintDlcReward>> FreeDlc1Reward = "60d87338684842c0bae702ea6592d800";
    public static readonly Blueprint<BlueprintReference<BlueprintDlcReward>> FreeDlc2Reward = "0b1a6e5516154dbaa132604675117e15";
    public static readonly Blueprint<BlueprintReference<BlueprintDlcReward>> FreeDlc3Reward = "b75d56812b63445882687383426d0357";
    public static readonly Blueprint<BlueprintReference<BlueprintDlcReward>> FreeDlc4Reward = "89e5119ac73f4e32a0906b66482539cf";

    public static readonly List<Blueprint<BlueprintReference<BlueprintDlcReward>>> All =
      new()
      {
          DlcCommanderPackReward,
          DlcKickstarterPremiumReward,
          DlcKickstarterReward,
          DlcPreorderReward,
          FreeDlc1Reward,
          FreeDlc2Reward,
          FreeDlc3Reward,
          FreeDlc4Reward,
      };
  }
}
