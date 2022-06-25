using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintHiddenItem blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class HiddenItemRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintHiddenItem>> FinneanBaseItem = "95c126deb99ba054aa5b84710520c035";
    public static readonly Blueprint<BlueprintReference<BlueprintHiddenItem>> TestFinneanItem = "508d135c08de4661ba32b27e424e6a4c";

    public static readonly List<Blueprint<BlueprintReference<BlueprintHiddenItem>>> All =
      new()
      {
          FinneanBaseItem,
          TestFinneanItem,
      };
  }
}
