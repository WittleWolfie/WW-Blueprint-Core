using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintDungeonIslandRewardObject blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class DungeonIslandRewardObjectRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandRewardObject>> RewardObject_CorruptionCleanse = "3dbf788309074705b6f01169dc3c5e17";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandRewardObject>> RewardObject_ExperienceBonus = "b0b74637f3bb4d6da96c5bd5d125dfa2";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandRewardObject>> RewardObject_LegacyExp = "88e90db7f9c94630ac504661db7ce46b";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandRewardObject>> RewardObject_LegacyExp_close = "36158ab6a3f54e75bdbb462453871efa";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandRewardObject>> RewardObject_PermanentACBuff = "7b9cedafa82b432f8e797c3cb3f5b245";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandRewardObject>> RewardObject_PermanentBonusHitPointsBuff_Tier1only = "4f1255167ca840e087e038a2202364af";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandRewardObject>> RewardObject_PermanentRandomBuff = "fca6bbeceef64c2c9146ea56abe6b013";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandRewardObject>> RewardObject_PermanentRandomOneAtributeUpBuff = "48ac57b560b94a439af41ceec9fe1c50";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandRewardObject>> RewardObject_PermanentSaveBuff = "cb0b9ce7911544f294cde26f0d7723cc";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonIslandRewardObject>> RewardObject_RandomFeat = "1f14ad28076b41af928b0a47b167b4b1";

    public static readonly List<Blueprint<BlueprintReference<BlueprintDungeonIslandRewardObject>>> All =
      new()
      {
          RewardObject_CorruptionCleanse,
          RewardObject_ExperienceBonus,
          RewardObject_LegacyExp,
          RewardObject_LegacyExp_close,
          RewardObject_PermanentACBuff,
          RewardObject_PermanentBonusHitPointsBuff_Tier1only,
          RewardObject_PermanentRandomBuff,
          RewardObject_PermanentRandomOneAtributeUpBuff,
          RewardObject_PermanentSaveBuff,
          RewardObject_RandomFeat,
      };
  }
}
