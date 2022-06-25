using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintFeatureSelectMythicSpellbook blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class FeatureSelectMythicSpellbookRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintFeatureSelectMythicSpellbook>> AngelIncorporateSpellbook = "e1fbb0e0e610a3a4d91e5e5284587939";
    public static readonly Blueprint<BlueprintReference<BlueprintFeatureSelectMythicSpellbook>> LichIncorporateSpellbookFeature = "3f16e9caf7c683c40884c7c455ed26af";

    public static readonly List<Blueprint<BlueprintReference<BlueprintFeatureSelectMythicSpellbook>>> All =
      new()
      {
          AngelIncorporateSpellbook,
          LichIncorporateSpellbookFeature,
      };
  }
}
