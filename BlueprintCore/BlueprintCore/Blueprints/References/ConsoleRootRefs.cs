using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to ConsoleRoot blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class ConsoleRootRefs
  {
    public static readonly Blueprint<BlueprintReference<ConsoleRoot>> ConsoleRoot = "d9ba3d03221949347bb0c5bd57912f24";
  }
}
