using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Footrprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintFootprint blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class FootprintRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintFootprint>> AnimalHoof_Footprint_Dust = "0d4fe54080db43c0b30fc635faa21c95";
    public static readonly Blueprint<BlueprintReference<BlueprintFootprint>> AnimalHoof_Footprint_Generic = "27f2f112f95941b5880d8099f5771697";
    public static readonly Blueprint<BlueprintReference<BlueprintFootprint>> AnimalHoof_Footprint_Snow = "bc6e182a14284090aa7fcf9f2d17c75d";
    public static readonly Blueprint<BlueprintReference<BlueprintFootprint>> AnimalPaw_Footprint_Dust = "9cc9b7b53698416c9919b8af6031136a";
    public static readonly Blueprint<BlueprintReference<BlueprintFootprint>> AnimalPaw_Footprint_Generic = "18a723039a9e46eb93b609f21def28bd";
    public static readonly Blueprint<BlueprintReference<BlueprintFootprint>> AnimalPaw_Footprint_Snow = "eb8dc8a143b24092bbcaa7a675e8528f";
    public static readonly Blueprint<BlueprintReference<BlueprintFootprint>> Humanoid_Footprint_Dust = "1fd6180047104fd89759ee5e87aa9da5";
    public static readonly Blueprint<BlueprintReference<BlueprintFootprint>> Humanoid_Footprint_Generic = "533f76760325460a9238a5d78f7b7763";
    public static readonly Blueprint<BlueprintReference<BlueprintFootprint>> Humanoid_Footprint_Snow = "d1d8741286684caca5f0160b7c74f933";

    public static readonly List<Blueprint<BlueprintReference<BlueprintFootprint>>> All =
      new()
      {
          AnimalHoof_Footprint_Dust,
          AnimalHoof_Footprint_Generic,
          AnimalHoof_Footprint_Snow,
          AnimalPaw_Footprint_Dust,
          AnimalPaw_Footprint_Generic,
          AnimalPaw_Footprint_Snow,
          Humanoid_Footprint_Dust,
          Humanoid_Footprint_Generic,
          Humanoid_Footprint_Snow,
      };
  }
}
