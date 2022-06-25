using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Formations;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintPartyFormation blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class PartyFormationRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintPartyFormation>> Formation_Auto = "1528ed7057903244f98c2d3c2851b3ec";
    public static readonly Blueprint<BlueprintReference<BlueprintPartyFormation>> Formation_Custom_01 = "bb3d357f04e7e7b439ddd36c2b123877";
    public static readonly Blueprint<BlueprintReference<BlueprintPartyFormation>> Formation_Custom_02 = "cdb4a0c6f7c2faf4f9bfb142ca4caee5";
    public static readonly Blueprint<BlueprintReference<BlueprintPartyFormation>> Formation_Custom_03 = "a38b14ca3fb0c05409c5c8e45fb5687c";
    public static readonly Blueprint<BlueprintReference<BlueprintPartyFormation>> Formation_Custom_04 = "71bb427a43932424a803f68253d57197";
    public static readonly Blueprint<BlueprintReference<BlueprintPartyFormation>> Formation_Custom_05 = "16bee6581f72d8f4b8028d5307f67d8d";

    public static readonly List<Blueprint<BlueprintReference<BlueprintPartyFormation>>> All =
      new()
      {
          Formation_Auto,
          Formation_Custom_01,
          Formation_Custom_02,
          Formation_Custom_03,
          Formation_Custom_04,
          Formation_Custom_05,
      };
  }
}
