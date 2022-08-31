using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintDungeonTheme blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class DungeonThemeRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonTheme>> DungeonThemeCold = "08c1a8adc7484ecf87d137b7d3988aab";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonTheme>> DungeonThemeHot = "e67f751590404ba195c0931a4e8712f8";

    public static readonly List<Blueprint<BlueprintReference<BlueprintDungeonTheme>>> All =
      new()
      {
          DungeonThemeCold,
          DungeonThemeHot,
      };
  }
}
