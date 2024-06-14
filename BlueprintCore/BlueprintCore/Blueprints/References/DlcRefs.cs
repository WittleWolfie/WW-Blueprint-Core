using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DLC;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintDlc blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class DlcRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintDlc>> Dlc1 = "8576a633c8fe4ce78530b55c1f0d14e5";
    public static readonly Blueprint<BlueprintReference<BlueprintDlc>> Dlc2 = "4f7ae2d1e6e74a0c807b4020e9e99354";
    public static readonly Blueprint<BlueprintReference<BlueprintDlc>> Dlc3 = "962e8c01fd834805b3ddf93134f77d44";
    public static readonly Blueprint<BlueprintReference<BlueprintDlc>> Dlc4 = "35b89606cfe9405085a35b02cf15017f";
    public static readonly Blueprint<BlueprintReference<BlueprintDlc>> Dlc5 = "95a25ca16bd54ce3b3ea56f83538fa0d";
    public static readonly Blueprint<BlueprintReference<BlueprintDlc>> Dlc6 = "c2340df3fdaf403baffe824ae7a0a547";
    public static readonly Blueprint<BlueprintReference<BlueprintDlc>> DlcCommanderPack = "d2f0852710c5497eac91979c71131c90";
    public static readonly Blueprint<BlueprintReference<BlueprintDlc>> DlcKickstarter = "1bd03396427542699c4cfe4e17961191";
    public static readonly Blueprint<BlueprintReference<BlueprintDlc>> DlcKickstarterPremium = "1cf79baad3874b3aaf700b6187c7f0e1";
    public static readonly Blueprint<BlueprintReference<BlueprintDlc>> DlcPreorder = "cce1376687d1452c9f451b0d921bcd4e";
    public static readonly Blueprint<BlueprintReference<BlueprintDlc>> DlcPreorderAndCommanderPack = "566f5b21c1c147debc88578ea6092a6f";
    public static readonly Blueprint<BlueprintReference<BlueprintDlc>> DlcSeasonPass = "974fec2051194cf4a39d8b43b71c124d";
    public static readonly Blueprint<BlueprintReference<BlueprintDlc>> FreeDlc1 = "d185af74fc5b4c198600e0202ca11de8";
    public static readonly Blueprint<BlueprintReference<BlueprintDlc>> FreeDlc2 = "470dbced885b41488aa619ce58adec42";
    public static readonly Blueprint<BlueprintReference<BlueprintDlc>> FreeDlc3 = "aa65dbd3c0bb44b49343b020c9a4c8a3";
    public static readonly Blueprint<BlueprintReference<BlueprintDlc>> FreeDlc4 = "a9262dad08654d3dbad64476978c0f95";

    public static readonly List<Blueprint<BlueprintReference<BlueprintDlc>>> All =
      new()
      {
          Dlc1,
          Dlc2,
          Dlc3,
          Dlc4,
          Dlc5,
          Dlc6,
          DlcCommanderPack,
          DlcKickstarter,
          DlcKickstarterPremium,
          DlcPreorder,
          DlcPreorderAndCommanderPack,
          DlcSeasonPass,
          FreeDlc1,
          FreeDlc2,
          FreeDlc3,
          FreeDlc4,
      };
  }
}
