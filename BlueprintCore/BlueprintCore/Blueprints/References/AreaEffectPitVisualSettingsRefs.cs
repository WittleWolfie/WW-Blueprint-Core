using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintAreaEffectPitVisualSettings blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class AreaEffectPitVisualSettingsRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintAreaEffectPitVisualSettings>> BlackHole_Settings = "12c1cf9d3d674cf47ae748ea3caf4d38";
    public static readonly Blueprint<BlueprintReference<BlueprintAreaEffectPitVisualSettings>> CreatePit_Settings = "98f7571740ad43648b63e6137b6988ef";
    public static readonly Blueprint<BlueprintReference<BlueprintAreaEffectPitVisualSettings>> DLC3_Nahyndri_Golemlike_Single_AnchorSlam_CustomPitSettings = "afb3023bf5d6456a84522ed3b42457f0";

    public static readonly List<Blueprint<BlueprintReference<BlueprintAreaEffectPitVisualSettings>>> All =
      new()
      {
          BlackHole_Settings,
          CreatePit_Settings,
          DLC3_Nahyndri_Golemlike_Single_AnchorSlam_CustomPitSettings,
      };
  }
}
