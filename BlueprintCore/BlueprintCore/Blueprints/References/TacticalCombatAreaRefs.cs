using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Armies.TacticalCombat.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintTacticalCombatArea blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class TacticalCombatAreaRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintTacticalCombatArea>> TacticalCombatAutumnForest = "997dcf12373adc1488926cd025a4ac0b";
    public static readonly Blueprint<BlueprintReference<BlueprintTacticalCombatArea>> TacticalCombatKarelia = "19704596d00ce8b41bce3ff42865bb43";
    public static readonly Blueprint<BlueprintReference<BlueprintTacticalCombatArea>> TacticalCombatWinterForest = "aa2ecea770ad1f84a86c59668f36ec1b";
    public static readonly Blueprint<BlueprintReference<BlueprintTacticalCombatArea>> TacticalCombatWorldWound01 = "03c2cda4d3b155841a0be9acb3048909";
    public static readonly Blueprint<BlueprintReference<BlueprintTacticalCombatArea>> TacticalCombatWorldWound02 = "be7a48a724d4ed441be74c47c2ccda76";
    public static readonly Blueprint<BlueprintReference<BlueprintTacticalCombatArea>> TestTacticalCombatArea = "46b8248a7204c1347a087d85c8a2439c";

    public static readonly List<Blueprint<BlueprintReference<BlueprintTacticalCombatArea>>> All =
      new()
      {
          TacticalCombatAutumnForest,
          TacticalCombatKarelia,
          TacticalCombatWinterForest,
          TacticalCombatWorldWound01,
          TacticalCombatWorldWound02,
          TestTacticalCombatArea,
      };
  }
}
