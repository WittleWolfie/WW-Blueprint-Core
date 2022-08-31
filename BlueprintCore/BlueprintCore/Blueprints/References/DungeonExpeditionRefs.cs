using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintDungeonExpedition blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class DungeonExpeditionRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonExpedition>> Expedition1 = "431d71f2f8ba4b848d9d308fc44262a9";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonExpedition>> Expedition2 = "0e538c2622564e14a7adacdf5c6984d8";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonExpedition>> Finalboss_exp = "c33fc453b3e344a18471f371111b9e8f";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonExpedition>> Tier1_exp_1 = "10aa5f5c98c14ef8b0ac2973605e544e";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonExpedition>> Tier1_exp_2 = "fa15cb4875fd4c21b128eefcbd166be6";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonExpedition>> Tier1_exp_3 = "4bb689c33f9342cfa88ea78f9e33ee7a";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonExpedition>> Tier1_exp_4 = "2b5fcbeb82a74344aa539687a6e5ea07";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonExpedition>> Tier1_exp_5 = "d8723717965b4e958f8d797c78b60d85";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonExpedition>> Tier2_exp_1 = "e1958c1a2986471d8a475cac07f9b436";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonExpedition>> Tier2_exp_2 = "10a66fdcbedd4e0189cf7efbf076f22c";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonExpedition>> Tier2_exp_3 = "dbded315e74f440f9d27e62877bcea4e";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonExpedition>> Tier2_exp_4 = "c1396f42cfd74dd6ba47a4275c7d12a9";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonExpedition>> Tier2_exp_6 = "f288565c6bbe49bdaa3d3ae53e3edb57";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonExpedition>> Tier3_exp_1 = "db59efc9b6844da98cd4025a3cf77ecf";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonExpedition>> Tier3_exp_2 = "97d68b6315494f2f97262cc1df0280b5";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonExpedition>> Tier3_exp_3 = "4bfb547730164855b9f406a0f78b8c1a";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonExpedition>> Tier3_exp_4 = "bdee64ee24344430ba24b5c1d13a0672";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonExpedition>> Tier3_exp_5 = "c7eccdb236854e7fbc5348dacef9abaa";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonExpedition>> Tier4_exp_1 = "300c9b0da271466292b8b8888cf4792a";

    public static readonly List<Blueprint<BlueprintReference<BlueprintDungeonExpedition>>> All =
      new()
      {
          Expedition1,
          Expedition2,
          Finalboss_exp,
          Tier1_exp_1,
          Tier1_exp_2,
          Tier1_exp_3,
          Tier1_exp_4,
          Tier1_exp_5,
          Tier2_exp_1,
          Tier2_exp_2,
          Tier2_exp_3,
          Tier2_exp_4,
          Tier2_exp_6,
          Tier3_exp_1,
          Tier3_exp_2,
          Tier3_exp_3,
          Tier3_exp_4,
          Tier3_exp_5,
          Tier4_exp_1,
      };
  }
}
