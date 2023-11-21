using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DLC;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintDlcRewardCampaign blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class DlcRewardCampaignRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintDlcRewardCampaign>> Dlc1RewardCampaign = "313fb87e4c0143bd84b3fc997c3c2266";
    public static readonly Blueprint<BlueprintReference<BlueprintDlcRewardCampaign>> Dlc2RewardCampaign = "3380030f72954976a775c2e9a1e9ae07";
    public static readonly Blueprint<BlueprintReference<BlueprintDlcRewardCampaign>> Dlc3RewardCampaign = "04b3bf450b1e44438854f25ba1290a98";
    public static readonly Blueprint<BlueprintReference<BlueprintDlcRewardCampaign>> Dlc5RewardCampaign = "1c893fd3059d4b09bd37d089aff7866e";

    public static readonly List<Blueprint<BlueprintReference<BlueprintDlcRewardCampaign>>> All =
      new()
      {
          Dlc1RewardCampaign,
          Dlc2RewardCampaign,
          Dlc3RewardCampaign,
          Dlc5RewardCampaign,
      };
  }
}
