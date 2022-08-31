using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintRace blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class RaceRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> AasimarRace = "b7f02ba92b363064fb873963bec275ee";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> AscendingSuccubus = "5e464d1d5fd0e7a4380b6ce60ef2c83b";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> BralaniRace = "0064126dfc9a45cbb4667ccef0030f15";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> CambionRace = "980bed7f6d9e4c33a86b95d199eb4934";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> ColoxusRace = "82acc85f3fdb48e29f68dc1ace6c1a6e";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> DhampirRace = "64e8b7d5f1ae91d45bbf1e56a3fdff01";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> DLC3_HalflingBuffedRace = "ee9a6061370b4db2b28e489664b0acb4";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> DuergarRace = "cd40ff5a556bcf3419bf7479616cd2ad";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> DuergarTyrantRace = "315a604df7e8cb34098ed2a3b7e3d068";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> DwarfRace = "c4faf439f0e70bd40b5e36ee80d06be7";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> ElfRace = "25a5878d125338244896ebd3238226c8";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> ErinyesRace = "24cccae43dd64f0ebf674d229ad217d0";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> GhoulRace = "00632bfe4d3449a08b0141dd526ab7fc";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> GhoulRaceSmall = "36b9974a5f9249a08e0aacab25b4a523";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> GnomeRace = "ef35a22c9a27da345a4528f0d5889157";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> GoblinRace = "9d168ca7100e9314385ce66852385451";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> HalfElfRace = "b3646842ffbd01643ab4dac7479b20b0";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> HalflingRace = "b0c3ef2729c498f47970bb50fa1acd30";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> HalfOrcRace = "1dc20e195581a804890ddc74218bfd8e";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> HumanRace = "0a5d473ead98b0646b94495af250fdc4";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> HumanThinRace = "e7080750d0a84d3da46a7faac93dbd0e";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> KitsuneRace = "fd188bb7bb0002e49863aec93bfb9d99";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> MongrelmanRace = "daca06a3f3355664bba1e87e67f3b5b3";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> OreadRace = "4d4555326b9b7144f93be1ea61337cd7";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> SarcorianChildRace = "dac8d342ca2148cab066b822506c14a2";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> SarcorianRace = "5447d6c2d3aa44ed89f02348f91393df";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> SkeletonRace = "4774ee5a5711433c8c8e008dd3734e56";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> SuccubusIncubusRace = "74bd4b4e5d3c4c2e86cc447d19c3ecc0";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> SuccubusRace = "56f58bf7ee0f4bbb951f98045c6b6d8f";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> TieflingRace = "5c4e42124dc2b4647af6e36cf2590500";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> WildHuntRace_Fake = "f414c5b12f2296c41901e71b889ef436";
    public static readonly Blueprint<BlueprintReference<BlueprintRace>> ZombiesRace = "b9668860eed943eca2419fd8c371f481";

    public static readonly List<Blueprint<BlueprintReference<BlueprintRace>>> All =
      new()
      {
          AasimarRace,
          AscendingSuccubus,
          BralaniRace,
          CambionRace,
          ColoxusRace,
          DhampirRace,
          DLC3_HalflingBuffedRace,
          DuergarRace,
          DuergarTyrantRace,
          DwarfRace,
          ElfRace,
          ErinyesRace,
          GhoulRace,
          GhoulRaceSmall,
          GnomeRace,
          GoblinRace,
          HalfElfRace,
          HalflingRace,
          HalfOrcRace,
          HumanRace,
          HumanThinRace,
          KitsuneRace,
          MongrelmanRace,
          OreadRace,
          SarcorianChildRace,
          SarcorianRace,
          SkeletonRace,
          SuccubusIncubusRace,
          SuccubusRace,
          TieflingRace,
          WildHuntRace_Fake,
          ZombiesRace,
      };
  }
}
