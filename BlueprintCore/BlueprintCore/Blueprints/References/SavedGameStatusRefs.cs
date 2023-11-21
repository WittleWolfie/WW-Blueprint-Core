using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintSavedGameStatus blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class SavedGameStatusRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintSavedGameStatus>> DLC5_StatusInImportedSave = "912f14b23e054badbe7550bf896162ae";
  }
}
