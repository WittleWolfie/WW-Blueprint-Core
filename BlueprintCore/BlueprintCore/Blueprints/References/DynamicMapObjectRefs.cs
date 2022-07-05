using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintDynamicMapObject blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class DynamicMapObjectRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> CorpseInteractionBlueprint = "75588478e5cc80742838c901d41a586d";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> FinneanCampObjectBlueprint = "83b33d1fd75b5d8409cc491463175dbb";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> InactiveCamp_Dungeon = "e99b07b19d5acf843bdedd5e11e67ff7";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> InactiveCamp_Outdoor = "ae9b10be1bccaf84f9b0220fc20d3e7d";

    public static readonly List<Blueprint<BlueprintReference<BlueprintDynamicMapObject>>> All =
      new()
      {
          CorpseInteractionBlueprint,
          FinneanCampObjectBlueprint,
          InactiveCamp_Dungeon,
          InactiveCamp_Outdoor,
      };
  }
}
