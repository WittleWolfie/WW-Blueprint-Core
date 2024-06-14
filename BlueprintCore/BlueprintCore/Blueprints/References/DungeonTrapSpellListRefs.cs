using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintDungeonTrapSpellList blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class DungeonTrapSpellListRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonTrapSpellList>> TrapSpellsDefault = "2b699ae45b7c4d04b3c2a99e09e25ccd";
  }
}
