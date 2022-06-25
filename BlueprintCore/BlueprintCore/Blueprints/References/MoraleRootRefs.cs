using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Armies.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to MoraleRoot blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class MoraleRootRefs
  {
    public static readonly Blueprint<BlueprintReference<MoraleRoot>> MoraleRoot = "d320ebdcfd2aac44e94a18f3d3879f4c";
  }
}
