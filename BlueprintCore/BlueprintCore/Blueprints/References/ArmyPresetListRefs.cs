using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintArmyPresetList blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class ArmyPresetListRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintArmyPresetList>> Chapter2TravellingArmyList = "e24237d36f6972246b27a78141370bb2";
    public static readonly Blueprint<BlueprintReference<BlueprintArmyPresetList>> Chapter3TravellingArmyList = "11ad5b669d1caf243acd84bcf4fca80d";
    public static readonly Blueprint<BlueprintReference<BlueprintArmyPresetList>> Chapter5TravellingArmyList = "735e7b05503c440992b3c90804cdcb7c";

    public static readonly List<Blueprint<BlueprintReference<BlueprintArmyPresetList>>> All =
      new()
      {
          Chapter2TravellingArmyList,
          Chapter3TravellingArmyList,
          Chapter5TravellingArmyList,
      };
  }
}
