using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintKingdomEventTimeline blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class KingdomEventTimelineRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintKingdomEventTimeline>> Kingdom_Event_Timeline = "32138d56e3e0fa14a9471b5fee6629a9";
    public static readonly Blueprint<BlueprintReference<BlueprintKingdomEventTimeline>> KingdomEventTimeline = "621b55521be137247b13913dc9fd4c52";

    public static readonly List<Blueprint<BlueprintReference<BlueprintKingdomEventTimeline>>> All =
      new()
      {
          Kingdom_Event_Timeline,
          KingdomEventTimeline,
      };
  }
}
