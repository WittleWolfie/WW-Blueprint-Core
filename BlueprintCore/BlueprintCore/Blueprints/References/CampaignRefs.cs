using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintCampaign blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class CampaignRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintCampaign>> Dlc1Campaign = "d79943b9b59b446ea5bfc14fa4005b26";
    public static readonly Blueprint<BlueprintReference<BlueprintCampaign>> Dlc2Campaign = "e6fdda2539274c1e89d236be69f5a984";
    public static readonly Blueprint<BlueprintReference<BlueprintCampaign>> Dlc3Campaign = "e1bde745d6ad47c0bc9fb8e479b29153";
    public static readonly Blueprint<BlueprintReference<BlueprintCampaign>> MainCampaign = "fd2e11ebb8a14d6599450fc27f03486a";

    public static readonly List<Blueprint<BlueprintReference<BlueprintCampaign>>> All =
      new()
      {
          Dlc1Campaign,
          Dlc2Campaign,
          Dlc3Campaign,
          MainCampaign,
      };
  }
}
