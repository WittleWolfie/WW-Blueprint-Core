using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintRegion blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class RegionRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintRegion>> Region01 = "f77b533b72bb47a2951384f61e44de52";
    public static readonly Blueprint<BlueprintReference<BlueprintRegion>> Region02 = "9ae3645130774f61a9ef847b33254a18";
    public static readonly Blueprint<BlueprintReference<BlueprintRegion>> Region03 = "1f4f5d4ffb6c4ddb8b6387ec9b91cd80";
    public static readonly Blueprint<BlueprintReference<BlueprintRegion>> Region04 = "7714545d0a72439bb88ae6d14bc4baea";
    public static readonly Blueprint<BlueprintReference<BlueprintRegion>> Region05 = "27a8e198d8284cc4ab947f5575c13ae3";
    public static readonly Blueprint<BlueprintReference<BlueprintRegion>> Region06 = "2a5f009c48d042fd8dee4764631f17b4";
    public static readonly Blueprint<BlueprintReference<BlueprintRegion>> Region07 = "8e68f5130a9845549a75141b906c0a31";
    public static readonly Blueprint<BlueprintReference<BlueprintRegion>> Region08 = "e936028b62444c5ea3656686728394a9";
    public static readonly Blueprint<BlueprintReference<BlueprintRegion>> Region09 = "98dee6e47af9413fb30962306f3c8c1d";
    public static readonly Blueprint<BlueprintReference<BlueprintRegion>> Region10 = "a2c96f4b17864c0bad38901f726ae345";

    public static readonly List<Blueprint<BlueprintReference<BlueprintRegion>>> All =
      new()
      {
          Region01,
          Region02,
          Region03,
          Region04,
          Region05,
          Region06,
          Region07,
          Region08,
          Region09,
          Region10,
      };
  }
}
