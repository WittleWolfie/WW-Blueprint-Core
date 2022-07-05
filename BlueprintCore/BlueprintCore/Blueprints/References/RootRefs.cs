using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintRoot blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class RootRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintRoot>> BlueprintRoot = "2d77316c72b9ed44f888ceefc2a131f6";
  }
}
