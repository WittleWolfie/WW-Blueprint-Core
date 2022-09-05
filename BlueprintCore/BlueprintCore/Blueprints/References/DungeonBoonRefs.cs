using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintDungeonBoon blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class DungeonBoonRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_Acid = "30d5a9af67c844eaba0a9eccd0e10c39";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_Aoe = "5424ec0ee1ef4c06be0b2a847ca77c16";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_ArcaneArmor = "e27cec242d6b4f8299126c9abe62505e";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_BarbarianHP = "6fb93a3229404fe2896b94fe116c82e2";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_BardsStack = "5e67ffd5253146bca900dd8dfc4e9268";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_Bludgeoning = "05815e81fa7e490584165e2ebb835134";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_BonusDmgBows = "088003e6159b40a09a05233603ac5d15";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_Cold = "7f2e836a40a94833ba75a82415712d17";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_DivineBless = "b2e614ff8817468198708f7dca5d28f8";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_Dwarven = "16e92f99e49143b3afde282bb8b94a7a";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_Electric = "c955ab1f11c646fc8bbb00248040024f";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_ElementalDamage = "a5fc3e5f63194cc490340ad4fd07c0bc";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_Elven = "dbb242c6be10406799fd659feb40d266";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_Exotic = "89987c26492844a2a07afc2715474b1b";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_Fire = "7e155f0848db47e89bb76dce6d4e0939";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_Gnome = "3c86efed41f7426292148ae079d881a6";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_Halfling = "906937229ce94aabb49b140ba7db12aa";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_HPRegain = "c80f02b4bb9a47eb951cbb7fe18b8668";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_Kinetic = "9ad3e006cce74b6dbf63611bcf7974c0";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_Kitsune = "b6c280cf93a7412eb1f2312388b066f8";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_Metamagic = "e8c9809811214863a5aaf4e60ce548ea";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_MixedMagic = "9ba760c24cd8458a9e408462972bff12";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_RangedSpellCrit = "9444ecc224f945ef8564daeab06a48cf";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_Rogues = "2e28b57ab98b47ddb92c17df62725863";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_Shieldbuff = "e0a3d1009fd549fe97c57683b0e6cfe8";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_Slashing = "3aeef1ddb73f4f12937c42eb046f90d3";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_Sonic = "57dbbe89c45a48c9a19196e206064273";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_SpellsAttack = "ea2ce7c8a2de4f85adfbe858c013be2e";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_SpellSave = "815b607e2daf49198c6ae6bd5ea96982";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_Summon = "00d5637ea85648df8dc2abde2ef60a58";
    public static readonly Blueprint<BlueprintReference<BlueprintDungeonBoon>> DungeonBoon_UnarmedStrikes = "5c7a5a0220e84b3fa5d78d427d10bf6b";

    public static readonly List<Blueprint<BlueprintReference<BlueprintDungeonBoon>>> All =
      new()
      {
          DungeonBoon_Acid,
          DungeonBoon_Aoe,
          DungeonBoon_ArcaneArmor,
          DungeonBoon_BarbarianHP,
          DungeonBoon_BardsStack,
          DungeonBoon_Bludgeoning,
          DungeonBoon_BonusDmgBows,
          DungeonBoon_Cold,
          DungeonBoon_DivineBless,
          DungeonBoon_Dwarven,
          DungeonBoon_Electric,
          DungeonBoon_ElementalDamage,
          DungeonBoon_Elven,
          DungeonBoon_Exotic,
          DungeonBoon_Fire,
          DungeonBoon_Gnome,
          DungeonBoon_Halfling,
          DungeonBoon_HPRegain,
          DungeonBoon_Kinetic,
          DungeonBoon_Kitsune,
          DungeonBoon_Metamagic,
          DungeonBoon_MixedMagic,
          DungeonBoon_RangedSpellCrit,
          DungeonBoon_Rogues,
          DungeonBoon_Shieldbuff,
          DungeonBoon_Slashing,
          DungeonBoon_Sonic,
          DungeonBoon_SpellsAttack,
          DungeonBoon_SpellSave,
          DungeonBoon_Summon,
          DungeonBoon_UnarmedStrikes,
      };
  }
}
