using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Footrprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintFootprintType blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class FootprintTypeRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintFootprintType>> AnimalHoof_Footprint_Type = "13ec22b395ee448bbe9227cf9b3bf29c";
    public static readonly Blueprint<BlueprintReference<BlueprintFootprintType>> AnimalPaw_Footprint_Type = "7644d89f154047ca8b0d61cd85245b44";
    public static readonly Blueprint<BlueprintReference<BlueprintFootprintType>> Humanoid_Footprint_Type = "c1a1b28f9848437bb97dc8b53cb4a68a";

    public static readonly List<Blueprint<BlueprintReference<BlueprintFootprintType>>> All =
      new()
      {
          AnimalHoof_Footprint_Type,
          AnimalPaw_Footprint_Type,
          Humanoid_Footprint_Type,
      };
  }
}
