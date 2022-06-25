using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Armies.TacticalCombat.Blueprints;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintTacticalCombatRoot blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class TacticalCombatRootRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintTacticalCombatRoot>> TacticalCombatRoot = "7be62f97e9de9f741a60d9924b934b64";
  }
}
