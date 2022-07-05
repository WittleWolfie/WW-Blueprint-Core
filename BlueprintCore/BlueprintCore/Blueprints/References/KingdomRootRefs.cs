using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to KingdomRoot blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class KingdomRootRefs
  {
    public static readonly Blueprint<BlueprintReference<KingdomRoot>> KingdomRoot = "f6bd33651fb0ad64d8fa659d3df6e7df";
  }
}
