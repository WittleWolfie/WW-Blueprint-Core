using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintTrap blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class TrapRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintTrap>> Blueprints_NOTUSED_ = "e6713f4a0bde49648b43e93bf372b0d2";
    public static readonly Blueprint<BlueprintReference<BlueprintTrap>> DLC1_StorytellerFlavorTrap = "e5272fddd95945bba815df56d56a7a19";
    public static readonly Blueprint<BlueprintReference<BlueprintTrap>> FakeBannerTrap = "9f306abf6791a3f44bdb824fbc81caf5";
    public static readonly Blueprint<BlueprintReference<BlueprintTrap>> FinneanlabFlavorTrap = "3797ac0b3c46d3f43a19a39fa34c5c2c";
    public static readonly Blueprint<BlueprintReference<BlueprintTrap>> GGTrap = "a810353e65dc1d741a0466b41d629d80";
    public static readonly Blueprint<BlueprintReference<BlueprintTrap>> GiantTrap = "53752f5116c0a5c4e94aef07cc29e4c7";
    public static readonly Blueprint<BlueprintReference<BlueprintTrap>> Lvl7_DraftFireballTrap = "3a9e14a3d6727f14ab684f395c2d722b";
    public static readonly Blueprint<BlueprintReference<BlueprintTrap>> Tesla_Trap = "e89bdac65b28ebe44b70145c03a29850";
    public static readonly Blueprint<BlueprintReference<BlueprintTrap>> Tesla_Trap2 = "c2efa4f3bb9a8e0439c63c7d1ec3efc0";
    public static readonly Blueprint<BlueprintReference<BlueprintTrap>> Tesla_Trap3 = "bcadc3b1c7b041ddbb0418a1e92de7cd";
    public static readonly Blueprint<BlueprintReference<BlueprintTrap>> Tesla_Trap4 = "0347ff16257c478c8b15b20b4bcfa37c";
    public static readonly Blueprint<BlueprintReference<BlueprintTrap>> TestAreaTrap = "65424b306ab8049439f2ee0090b790c7";
    public static readonly Blueprint<BlueprintReference<BlueprintTrap>> TestTrap = "42e2e9b03f91f824eb1ff8200a6b17de";

    public static readonly List<Blueprint<BlueprintReference<BlueprintTrap>>> All =
      new()
      {
          Blueprints_NOTUSED_,
          DLC1_StorytellerFlavorTrap,
          FakeBannerTrap,
          FinneanlabFlavorTrap,
          GGTrap,
          GiantTrap,
          Lvl7_DraftFireballTrap,
          Tesla_Trap,
          Tesla_Trap2,
          Tesla_Trap3,
          Tesla_Trap4,
          TestAreaTrap,
          TestTrap,
      };
  }
}
