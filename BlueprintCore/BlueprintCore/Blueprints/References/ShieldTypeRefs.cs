using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintShieldType blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class ShieldTypeRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintShieldType>> BucklerType = "26fcc43f7d20374498d2e1643381d345";
    public static readonly Blueprint<BlueprintReference<BlueprintShieldType>> HeavyShieldType = "d1b05b901bab9524388ebfa0435902a6";
    public static readonly Blueprint<BlueprintReference<BlueprintShieldType>> LightShieldType = "d38e8ea23ce653c4582eb3e002555483";
    public static readonly Blueprint<BlueprintReference<BlueprintShieldType>> TowerShieldType = "5f0f4b6e480e7054b8592b5a8b55854a";

    public static readonly List<Blueprint<BlueprintReference<BlueprintShieldType>>> All =
      new()
      {
          BucklerType,
          HeavyShieldType,
          LightShieldType,
          TowerShieldType,
      };
  }
}
