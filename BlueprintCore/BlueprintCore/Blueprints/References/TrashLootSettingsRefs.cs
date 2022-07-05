using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Loot;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to TrashLootSettings blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class TrashLootSettingsRefs
  {
    public static readonly Blueprint<BlueprintReference<TrashLootSettings>> RE_TrashLootSettings = "daf5872cc909705428f4a092d05351d1";
    public static readonly Blueprint<BlueprintReference<TrashLootSettings>> TrashLootSettings = "b2554a2be56f1c6478c14a442b0f64f3";
    public static readonly Blueprint<BlueprintReference<TrashLootSettings>> TrashLootSettings_DLC3 = "77fe4de4c707e51439971ee480e94efc";

    public static readonly List<Blueprint<BlueprintReference<TrashLootSettings>>> All =
      new()
      {
          RE_TrashLootSettings,
          TrashLootSettings,
          TrashLootSettings_DLC3,
      };
  }
}
