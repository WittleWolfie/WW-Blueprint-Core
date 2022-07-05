using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Interaction;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintInteractionRoot blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class InteractionRootRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintInteractionRoot>> InteractionRoot = "1a14f0e76dc1d4746bb26d473b50a76f";
  }
}
