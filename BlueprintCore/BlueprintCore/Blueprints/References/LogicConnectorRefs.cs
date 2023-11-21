using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintLogicConnector blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class LogicConnectorRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintLogicConnector>> AltarDamage_Actions = "35995aa895b843ab9c2d75d3a158487e";
    public static readonly Blueprint<BlueprintReference<BlueprintLogicConnector>> Area52Button = "fdf004a019ae85741bcee792d46900e8";
    public static readonly Blueprint<BlueprintReference<BlueprintLogicConnector>> Barrel_explosion = "8fdc96985bf749dfb5f8bd9085d4aeda";
    public static readonly Blueprint<BlueprintReference<BlueprintLogicConnector>> DLC5_GoblinsPartyInTheTower_DispelMagic_Actions = "6a7a9ade5a3c4a928eee1c0649d7a4da";
    public static readonly Blueprint<BlueprintReference<BlueprintLogicConnector>> DLC5_GoblinsPartyInTheTower_FireDamage_Actions = "b5d07682ed2a43f0a66ba50a09efabd5";
    public static readonly Blueprint<BlueprintReference<BlueprintLogicConnector>> FireDamage_Actions = "209d33847e7d4a33a894f9de8350a9c1";
    public static readonly Blueprint<BlueprintReference<BlueprintLogicConnector>> GateBLeverLogicConnector = "cd5489028f264804fa7118bef9d1f505";
    public static readonly Blueprint<BlueprintReference<BlueprintLogicConnector>> GateCLeverLogicConnector = "717d88bb7760d6046a9957e59ae637a8";
    public static readonly Blueprint<BlueprintReference<BlueprintLogicConnector>> GateDLeverLogicConnector = "40ec21a61892adc429b43667f5b497bc";
    public static readonly Blueprint<BlueprintReference<BlueprintLogicConnector>> GateELeverLogicConnector = "9857723925455c34590c1a5eab67d19e";
    public static readonly Blueprint<BlueprintReference<BlueprintLogicConnector>> GateFLeverLogicConnector = "83b8311bbfcded340948d1675efa58ad";
    public static readonly Blueprint<BlueprintReference<BlueprintLogicConnector>> MachineDamage_Actions = "3e522e59d3514dea90c56c7ecd6685a0";
    public static readonly Blueprint<BlueprintReference<BlueprintLogicConnector>> ObeliskDamage_Actions = "c60c445428024f7d8a1f1193cfd1f5b3";
    public static readonly Blueprint<BlueprintReference<BlueprintLogicConnector>> TestDamagedMapobject = "149d05c335f0cd24ca4a8866e968bb1d";

    public static readonly List<Blueprint<BlueprintReference<BlueprintLogicConnector>>> All =
      new()
      {
          AltarDamage_Actions,
          Area52Button,
          Barrel_explosion,
          DLC5_GoblinsPartyInTheTower_DispelMagic_Actions,
          DLC5_GoblinsPartyInTheTower_FireDamage_Actions,
          FireDamage_Actions,
          GateBLeverLogicConnector,
          GateCLeverLogicConnector,
          GateDLeverLogicConnector,
          GateELeverLogicConnector,
          GateFLeverLogicConnector,
          MachineDamage_Actions,
          ObeliskDamage_Actions,
          TestDamagedMapobject,
      };
  }
}
