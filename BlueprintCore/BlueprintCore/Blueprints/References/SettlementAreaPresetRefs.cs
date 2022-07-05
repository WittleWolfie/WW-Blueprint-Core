using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintSettlementAreaPreset blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class SettlementAreaPresetRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintSettlementAreaPreset>> AutumnForestSettlement_Preset = "95bc434cb33b4d8b9579314a14b5c851";
    public static readonly Blueprint<BlueprintReference<BlueprintSettlementAreaPreset>> Capital_Settlement_Preset = "dc83df1f92c31824389593d6a86f1dcd";
    public static readonly Blueprint<BlueprintReference<BlueprintSettlementAreaPreset>> DesertSettlement_Preset = "2651c6f5ba7f4f73af2ea7f437a32332";
    public static readonly Blueprint<BlueprintReference<BlueprintSettlementAreaPreset>> DrezenSettlement_Preset = "4d5a7ced794d4e7cbe85aa27e474e219";
    public static readonly Blueprint<BlueprintReference<BlueprintSettlementAreaPreset>> KareliaSettlement_Preset = "ba62e7698ae74add962f6242bcf09acb";
    public static readonly Blueprint<BlueprintReference<BlueprintSettlementAreaPreset>> WinterForestSettlement_Preset = "7137d71f66394c05a59dc9e5bf8842de";

    public static readonly List<Blueprint<BlueprintReference<BlueprintSettlementAreaPreset>>> All =
      new()
      {
          AutumnForestSettlement_Preset,
          Capital_Settlement_Preset,
          DesertSettlement_Preset,
          DrezenSettlement_Preset,
          KareliaSettlement_Preset,
          WinterForestSettlement_Preset,
      };
  }
}
