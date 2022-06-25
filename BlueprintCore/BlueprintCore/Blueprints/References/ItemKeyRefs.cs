using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintItemKey blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class ItemKeyRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintItemKey>> CircuarRoomKey = "64c8fa8c22473654294dff1cc6d1f1a9";
    public static readonly Blueprint<BlueprintReference<BlueprintItemKey>> ColyphyrCellKey = "d0492a26bbdedbc4086fd58dcbac8968";
    public static readonly Blueprint<BlueprintReference<BlueprintItemKey>> DLC1_IZ_RemoteController = "f801a1e70d8444568d8c40693e2f4f9c";
    public static readonly Blueprint<BlueprintReference<BlueprintItemKey>> EchoLairKey = "dac32e88810a20941a53a5960e581b3d";
    public static readonly Blueprint<BlueprintReference<BlueprintItemKey>> InevitableDarkness_Item_ChestKey = "f45cec13f3e647c4be4ee3d83ef9e2f0";
    public static readonly Blueprint<BlueprintReference<BlueprintItemKey>> LetterFromVellexia = "eb90e06d98b9f4a4186e8c5145c2625b";

    public static readonly List<Blueprint<BlueprintReference<BlueprintItemKey>>> All =
      new()
      {
          CircuarRoomKey,
          ColyphyrCellKey,
          DLC1_IZ_RemoteController,
          EchoLairKey,
          InevitableDarkness_Item_ChestKey,
          LetterFromVellexia,
      };
  }
}
