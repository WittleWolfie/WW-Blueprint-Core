using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Visual.LightSelector;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintTimeOfDaySettings blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class TimeOfDaySettingsRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintTimeOfDaySettings>> Camp_Bonfire00 = "40c05daf1bdf17243b7941475010e5d2";
    public static readonly Blueprint<BlueprintReference<BlueprintTimeOfDaySettings>> TorchLightSelection = "ea94b4cbda7a63441896c37ac4ba01fb";

    public static readonly List<Blueprint<BlueprintReference<BlueprintTimeOfDaySettings>>> All =
      new()
      {
          Camp_Bonfire00,
          TorchLightSelection,
      };
  }
}
