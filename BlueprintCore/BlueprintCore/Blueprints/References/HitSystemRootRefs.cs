using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Visual.HitSystem;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to HitSystemRoot blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class HitSystemRootRefs
  {
    public static readonly Blueprint<BlueprintReference<HitSystemRoot>> HitSystem = "b13820523d5b98e4fafdc868e8fb27df";
  }
}
