using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.RandomEncounters.Settings;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintSpawnableObject blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class SpawnableObjectRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintSpawnableObject>> SpawnableObject_Box_02 = "63a9056736123084aa1c2128eb881794";
    public static readonly Blueprint<BlueprintReference<BlueprintSpawnableObject>> SpawnableObject_Box_03_Open = "4c8b6aa634cc1f947855cd5aff7988b8";
    public static readonly Blueprint<BlueprintReference<BlueprintSpawnableObject>> SpawnableObject_StumpKarelia = "8100cc2df19bf614cbec48f94ac4d4d5";
    public static readonly Blueprint<BlueprintReference<BlueprintSpawnableObject>> SpawnableObject_StumpSnow = "84db35b80c642e5499feb122f6914d85";

    public static readonly List<Blueprint<BlueprintReference<BlueprintSpawnableObject>>> All =
      new()
      {
          SpawnableObject_Box_02,
          SpawnableObject_Box_03_Open,
          SpawnableObject_StumpKarelia,
          SpawnableObject_StumpSnow,
      };
  }
}
