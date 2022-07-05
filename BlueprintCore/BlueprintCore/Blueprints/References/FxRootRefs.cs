using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root.Fx;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to FxRoot blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class FxRootRefs
  {
    public static readonly Blueprint<BlueprintReference<FxRoot>> FxRoot = "c5adca94da7c1bd48947a5cfb3a92c9a";
  }
}
