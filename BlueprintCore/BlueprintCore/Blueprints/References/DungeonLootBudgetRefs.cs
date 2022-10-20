using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintDungeonLootBudget blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class DungeonLootBudgetRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLootBudget>> DungeonLootBudgetCookingRecipes = "ce6647b74e9748c1a73a1a83554b1ac8";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLootBudget>> DungeonLootBudgetPortionsAndScrolls = "ff15335473b9493ba6051aa1ecc24caa";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLootBudget>> DungeonLootBudgetRare = "e8780c70cf944807b72e4add642e89df";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLootBudget>> DungeonLootBudgetRareAndMagic = "fbb31e252bf64169b17ca2886765e833";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonLootBudget>> DungeonLootBudgetWands = "c2c67a4c6d264cd8a3b48f4553681df5";

    public static readonly List<Blueprint<BlueprintReference<BlueprintDungeonLootBudget>>> All =
      new()
      {
          DungeonLootBudgetCookingRecipes,
          DungeonLootBudgetPortionsAndScrolls,
          DungeonLootBudgetRare,
          DungeonLootBudgetRareAndMagic,
          DungeonLootBudgetWands,
      };
  }
}
