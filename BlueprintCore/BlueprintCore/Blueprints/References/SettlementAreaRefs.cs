using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Crusade;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to SettlementBlueprintArea blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class SettlementAreaRefs
  {
    public static readonly Blueprint<BlueprintReference<SettlementBlueprintArea>> Capital = "69a8a5d331f0d7f4c983a1de63b925b0";
    public static readonly Blueprint<BlueprintReference<SettlementBlueprintArea>> Settlement_AutumnForest = "685de96a73b84f00a1b31385097d158f";
    public static readonly Blueprint<BlueprintReference<SettlementBlueprintArea>> Settlement_Desert = "4bfa8c2e92704ae7b7296dd5b62e0209";
    public static readonly Blueprint<BlueprintReference<SettlementBlueprintArea>> Settlement_Drezen = "a8f1b3c4a1fc45bd92f57a1b3c70f5fe";
    public static readonly Blueprint<BlueprintReference<SettlementBlueprintArea>> Settlement_Karelia = "ca8a37cf09d8406cbd02a24790da972f";
    public static readonly Blueprint<BlueprintReference<SettlementBlueprintArea>> Settlement_WinterForest = "0f8354e867b24b6399491e74c4f93a2f";

    public static readonly List<Blueprint<BlueprintReference<SettlementBlueprintArea>>> All =
      new()
      {
          Capital,
          Settlement_AutumnForest,
          Settlement_Desert,
          Settlement_Drezen,
          Settlement_Karelia,
          Settlement_WinterForest,
      };
  }
}
