using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.AI.Blueprints.Considerations;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to DirectionConsideration blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class DirectionConsiderationRefs
  {
    public static readonly Blueprint<BlueprintReference<DirectionConsideration>> DLC3_DirectionConsideration = "767d23f6e78a4dd1957a7d7171895eeb";
    public static readonly Blueprint<BlueprintReference<DirectionConsideration>> DLC3_DirectionConsideration_Behind = "708c6379091e4d96aa6ba590c47f4f1e";
    public static readonly Blueprint<BlueprintReference<DirectionConsideration>> DLC3_DirectionConsideration_Front_180 = "d4e643e1f7404ca8846f0a48d91a2e51";
    public static readonly Blueprint<BlueprintReference<DirectionConsideration>> DLC3_DirectionConsideration_Front_90 = "3a9b259e38d94243a3e621c7c237f053";
    public static readonly Blueprint<BlueprintReference<DirectionConsideration>> DLC3_DirectionConsideration_Front_90_Clear = "5e6f5dc2f4f14f67b842c0a97dbfa66b";
    public static readonly Blueprint<BlueprintReference<DirectionConsideration>> RuinsRaidGalluBossCorpseBlastDirectionConsideration = "e2313fe6a14f4d3a8f5583695afb806c";

    public static readonly List<Blueprint<BlueprintReference<DirectionConsideration>>> All =
      new()
      {
          DLC3_DirectionConsideration,
          DLC3_DirectionConsideration_Behind,
          DLC3_DirectionConsideration_Front_180,
          DLC3_DirectionConsideration_Front_90,
          DLC3_DirectionConsideration_Front_90_Clear,
          RuinsRaidGalluBossCorpseBlastDirectionConsideration,
      };
  }
}
