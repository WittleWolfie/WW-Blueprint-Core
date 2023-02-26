using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintDynamicMapObject blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class DynamicMapObjectRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> CorpseInteractionBlueprint = "75588478e5cc80742838c901d41a586d";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> CorpseInteractionBlueprint_DLC4 = "2b37acb32cf146d083fa90f390b24743";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> CorpseInteractionBlueprint_DLC4_Worm = "828cfcdec5e24079aafc3e12668bd869";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> DLC3_LootContainer = "7cc4a05acaf44ea59357843c8161b081";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> DLC3_LootContainer_2 = "a3f0ed9a361b4e5eb84e1ab8abd77a67";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> DLC3_LootContainer_3 = "1ccbdc2361534a8d99e4043b8b345e72";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> DungeonRewardChest = "12faa3cb6c83432d93d09f85dd19a170";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> FinneanCampObjectBlueprint = "83b33d1fd75b5d8409cc491463175dbb";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> InactiveCamp_Dungeon = "e99b07b19d5acf843bdedd5e11e67ff7";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> InactiveCamp_Outdoor = "ae9b10be1bccaf84f9b0220fc20d3e7d";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> RewardObject_CorruptionCleanse_DynamicMapObject = "cfeee716dedf40eeadb94b666ea556a5";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> RewardObject_ExperienceBonus_DynamicMapObject = "05f327c1e4f54215887086d30e15603f";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> RewardObject_LegacyExp_DynamicMapObject = "f0efc1cb480241c890e4e5d4949cad17";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> RewardObject_PermanentACBuff_DynamicMapObject = "03e6c7336e60404282b1ae7f9b3160ef";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> RewardObject_PermanentBonusHitPointsBuff_Tier1only_DynamicMapObject = "87e1dd9d5b5943d5a106089e2cb9f787";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> RewardObject_PermanentRandomBuff_DynamicMapObject = "0c6ed452f60849469b01b09a08019564";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> RewardObject_PermanentRandomOneAtributeUpBuff_DynamicMapObject = "ed51b0c95c8a4af282582e4435ab9775";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> RewardObject_PermanentSaveBuff_DynamicMapObject = "3895c74f7643407284f416a774978106";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> RewardObject_RandomFeat_DynamicMapObject = "d73818ffd5a84dd591b5346a1082da30";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> UnusedDynamicMapObject_1 = "e58e8b0696094f44a3a0b89877532b78";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> UnusedDynamicMapObject_2 = "0da2289717234461b6b5ec50cec3db58";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> UnusedDynamicMapObject_3 = "0ad489cbf54d4c1288cceefd1b793312";
    public static readonly Blueprint<BlueprintReference<BlueprintDynamicMapObject>> UnusedDynamicMapObject_4 = "816627dd533c45e5b8c7a52fc5e75c8c";

    public static readonly List<Blueprint<BlueprintReference<BlueprintDynamicMapObject>>> All =
      new()
      {
          CorpseInteractionBlueprint,
          CorpseInteractionBlueprint_DLC4,
          CorpseInteractionBlueprint_DLC4_Worm,
          DLC3_LootContainer,
          DLC3_LootContainer_2,
          DLC3_LootContainer_3,
          DungeonRewardChest,
          FinneanCampObjectBlueprint,
          InactiveCamp_Dungeon,
          InactiveCamp_Outdoor,
          RewardObject_CorruptionCleanse_DynamicMapObject,
          RewardObject_ExperienceBonus_DynamicMapObject,
          RewardObject_LegacyExp_DynamicMapObject,
          RewardObject_PermanentACBuff_DynamicMapObject,
          RewardObject_PermanentBonusHitPointsBuff_Tier1only_DynamicMapObject,
          RewardObject_PermanentRandomBuff_DynamicMapObject,
          RewardObject_PermanentRandomOneAtributeUpBuff_DynamicMapObject,
          RewardObject_PermanentSaveBuff_DynamicMapObject,
          RewardObject_RandomFeat_DynamicMapObject,
          UnusedDynamicMapObject_1,
          UnusedDynamicMapObject_2,
          UnusedDynamicMapObject_3,
          UnusedDynamicMapObject_4,
      };
  }
}
