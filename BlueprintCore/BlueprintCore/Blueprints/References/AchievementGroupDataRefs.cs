using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Achievements.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to AchievementGroupData blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class AchievementGroupDataRefs
  {
    public static readonly Blueprint<BlueprintReference<AchievementGroupData>> DLC1TrophyGroup = "ec6d0a0309454bf69cab35dad885b379";
    public static readonly Blueprint<BlueprintReference<AchievementGroupData>> DLC2TrophyGroup = "a8f6d201adbc4c04add094be4c582b26";
    public static readonly Blueprint<BlueprintReference<AchievementGroupData>> DLC2TrophyGroupPack2 = "cdca168d7796436eb1d8a261a65b4361";
    public static readonly Blueprint<BlueprintReference<AchievementGroupData>> DLC3TrophyGroup = "ce6303e03b2d402e89679e1c08a05ed6";
    public static readonly Blueprint<BlueprintReference<AchievementGroupData>> DLC3TrophyGroupPack2 = "795b318629e24abf960c2974a9a8a6db";
    public static readonly Blueprint<BlueprintReference<AchievementGroupData>> DLC3TrophyGroupPack3 = "a2236cf26a054da58719e954319b0fdc";
    public static readonly Blueprint<BlueprintReference<AchievementGroupData>> DLC4TrophyGroup = "b48c1ea43bcc4ce0a20d9df9b6c4775d";
    public static readonly Blueprint<BlueprintReference<AchievementGroupData>> DLC5TrophyGroup = "27c0b768644543c7886b2b0e202c95fe";
    public static readonly Blueprint<BlueprintReference<AchievementGroupData>> DLC5TrophyGroupPack2 = "e785daba3e254a6ab4cb8fcbc8c70787";
    public static readonly Blueprint<BlueprintReference<AchievementGroupData>> DLC6TrophyGroup = "2e7923f30d15407f8d5f5ceaa2a4a48c";

    public static readonly List<Blueprint<BlueprintReference<AchievementGroupData>>> All =
      new()
      {
          DLC1TrophyGroup,
          DLC2TrophyGroup,
          DLC2TrophyGroupPack2,
          DLC3TrophyGroup,
          DLC3TrophyGroupPack2,
          DLC3TrophyGroupPack3,
          DLC4TrophyGroup,
          DLC5TrophyGroup,
          DLC5TrophyGroupPack2,
          DLC6TrophyGroup,
      };
  }
}
