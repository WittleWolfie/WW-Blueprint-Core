using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintStatProgression blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class StatProgressionRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> ArmyXPTable = "72cc67d1699657147aa5c9af03098b66";
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> BABFull = "b3057560ffff3514299e8b93e7648a9d";
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> BABLow = "0538081888b2d8c41893d25d098dee99";
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> BABMedium = "4c936de4249b61e419a3fb775b9f2581";
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> BaseCRTable = "c0bed557c59c0394498253d90489bc27";
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> Chapter2MissionProgression = "a15bf866386394b4ca7898df1f58f555";
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> Chapter2TravellingArmyProgression = "13ecf78900ff252409fbe4b20578b73b";
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> Chapter3MissionProgression = "9580bdd51cf471e41b6b25ccccff2648";
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> Chapter3TravellingArmyProgression = "43f2c8bb3dc12944b827dd11eb7514ef";
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> Chapter5TravellingArmyProgression = "845ce59d1d5049d5bd94122948ab0322";
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> CRTable = "19b09eaa18b203645b6f1d5f2edcb1e4";
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> DCtoCRTable = "674a4e0eb86cc89478119de258f602a5";
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> LegendXPTable = "11c77f6853ac46aa8e2d004d6dca5f9f";
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> SavesHigh = "ff4662bde9e75f145853417313842751";
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> SavesLow = "dc0c7c1aba755c54f96c089cdf7d14a3";
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> SavesPrestigeHigh = "1f309006cd2855e4e91a6c3707f3f700";
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> SavesPrestigeLow = "dc5257e1100ad0d48b8f3b9798421c72";
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> WeekArmyRatingProgression = "d205afa1da356264a9eb6a909c819703";
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> WeekBuildingsProgression = "8607b170c0fa47e449cb8344a7e57ae5";
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> WeekIncomeSourceProgression = "3462a870a2d466a4db78f57821285521";
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> WeekLeaderLevelProgression = "b00fceabf8dde9a48bfe5d9ae60fb82f";
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> WeekRanksProgression = "fa4fe61eb7ae6334ca19035780123b6e";
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> WeekSettlementProgression = "e6d9752cd28963b4a8bbb340e1f9589b";
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> XPTable = "87c24ce6bcf1a994296f3c582c1a632b";
    public static readonly Blueprint<BlueprintReference<BlueprintStatProgression>> ZeroProgression = "059c61483910c77408d0473b11d1b922";

    public static readonly List<Blueprint<BlueprintReference<BlueprintStatProgression>>> All =
      new()
      {
          ArmyXPTable,
          BABFull,
          BABLow,
          BABMedium,
          BaseCRTable,
          Chapter2MissionProgression,
          Chapter2TravellingArmyProgression,
          Chapter3MissionProgression,
          Chapter3TravellingArmyProgression,
          Chapter5TravellingArmyProgression,
          CRTable,
          DCtoCRTable,
          LegendXPTable,
          SavesHigh,
          SavesLow,
          SavesPrestigeHigh,
          SavesPrestigeLow,
          WeekArmyRatingProgression,
          WeekBuildingsProgression,
          WeekIncomeSourceProgression,
          WeekLeaderLevelProgression,
          WeekRanksProgression,
          WeekSettlementProgression,
          XPTable,
          ZeroProgression,
      };
  }
}
