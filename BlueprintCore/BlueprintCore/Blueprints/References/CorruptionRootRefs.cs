using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Corruption;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintCorruptionRoot blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class CorruptionRootRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintCorruptionRoot>> CorruptionRoot = "048628b2f365c8b429ec05a4bf5363f7";
  }
}
