using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintDungeonLoot blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class DungeonLootRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLoot>> DungeonLoot_VendorRare_Grade1 = "ce33d49bbdb546579c2f43fd67d3f5bc";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLoot>> DungeonLoot_VendorRare_Grade2 = "b10aa83dd4844f1cb20ec3c646c1f409";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLoot>> DungeonLoot_VendorRare_Grade3 = "5f5c5e59b80e41ebad6ee71009470302";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLoot>> DungeonLoot_VendorRare_Grade4 = "30e11f5f5f504cd5852a20ad560bcf1f";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLoot>> DungeonLoot_VendorRare_Grade5 = "db284da806f843379ac69ba226b9962b";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLoot>> DungeonLoot_VendorRare_Grade6 = "c0823ada2b5f40dba329128d957a7b04";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLoot>> DungeonLoot_VendorRare_Grade7 = "1bf07fca80184b5087878ad5ee817ee6";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLoot>> DungeonLoot_VendorRare_Grade8 = "b4aeda355ed54cc49b39c10bb0c182d5";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLoot>> DungeonLoot_VendorRare_Grade9 = "2ef81ddf34c340e8b36fc0594866fa31";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLoot>> DungeonLootAlchemyIngredients = "3a841cf0bcd34bf8a911fca0b7fc62d3";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLoot>> DungeonLootCookingIngredients = "825d5caabc38420bacf0abc0e157f90f";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLoot>> DungeonLootCookingRecipes = "8a50117aa43d454cbd3ca1ac63e2646f";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLoot>> DungeonLootExclude = "86ad23ddcc074a878e350d822d980c30";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLoot>> DungeonLootJunk = "f5e28a9101804bff9d13fdd9b7382727";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLoot>> DungeonLootMagic = "24e7b8fe37484e06bc88738c9f032da2";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLoot>> DungeonLootPotions = "4b61f0c1f3644c55a0e639b6d884bb7f";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLoot>> DungeonLootPotionsAndScrolls = "73cc179f447d49409fd3668b1b919fc8";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLoot>> DungeonLootRare = "afe1a911df6b4fcabeb827077f004678";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLoot>> DungeonLootScrolls = "d05cd35429ee4c0f8a10d486fbcbcd67";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLoot>> DungeonLootScrollsAndWands = "60fb12414558484194b8ce057e43683f";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLoot>> DungeonLootTrash = "176de6037d524b1ab68b3eb2b47185bd";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLoot>> DungeonLootVendorExclude = "3e0e18c7484e469e857885f038ab8467";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLoot>> DungeonLootWands = "b097f1875abe4004bd6b04bdec279590";

    public static readonly List<Blueprint<BlueprintReference<BlueprintDungeonLoot>>> All =
      new()
      {
          DungeonLoot_VendorRare_Grade1,
          DungeonLoot_VendorRare_Grade2,
          DungeonLoot_VendorRare_Grade3,
          DungeonLoot_VendorRare_Grade4,
          DungeonLoot_VendorRare_Grade5,
          DungeonLoot_VendorRare_Grade6,
          DungeonLoot_VendorRare_Grade7,
          DungeonLoot_VendorRare_Grade8,
          DungeonLoot_VendorRare_Grade9,
          DungeonLootAlchemyIngredients,
          DungeonLootCookingIngredients,
          DungeonLootCookingRecipes,
          DungeonLootExclude,
          DungeonLootJunk,
          DungeonLootMagic,
          DungeonLootPotions,
          DungeonLootPotionsAndScrolls,
          DungeonLootRare,
          DungeonLootScrolls,
          DungeonLootScrollsAndWands,
          DungeonLootTrash,
          DungeonLootVendorExclude,
          DungeonLootWands,
      };
  }
}
