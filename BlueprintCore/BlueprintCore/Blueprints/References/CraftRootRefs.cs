using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Craft;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to CraftRoot blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class CraftRootRefs
  {
    public static readonly Blueprint<BlueprintReference<CraftRoot>> CraftRoot = "ecf0bbd052e4d7f44892dfd0601c812e";
  }
}
