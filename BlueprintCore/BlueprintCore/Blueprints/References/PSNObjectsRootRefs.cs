using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Console.PS5.PSNObjects;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintPSNObjectsRoot blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class PSNObjectsRootRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintPSNObjectsRoot>> BlueprintPSNObjectsRoot = "21164fb754e54a998496e20a21e42420";
  }
}
