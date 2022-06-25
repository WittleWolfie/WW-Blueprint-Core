using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to RandomConsideration blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class RandomConsiderationRefs
  {
    public static readonly Blueprint<BlueprintReference<RandomConsideration>> ChaoticBehaviour = "aad346ba597e8aa45bb4b589d9f9d0ea";
  }
}
