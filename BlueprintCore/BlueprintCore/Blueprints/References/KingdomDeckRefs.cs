using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintKingdomDeck blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class KingdomDeckRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintKingdomDeck>> KingdomDeck = "5f62fd51df12c83498b2f93e966c7d18";
  }
}
