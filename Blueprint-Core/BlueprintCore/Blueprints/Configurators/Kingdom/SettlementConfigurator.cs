using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Settlements;
using Kingmaker.Localization;
using System;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>Configurator for <see cref="BlueprintSettlement"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintSettlement))]
  public class SettlementConfigurator : BaseBlueprintConfigurator<BlueprintSettlement, SettlementConfigurator>
  {
     private SettlementConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SettlementConfigurator For(string name)
    {
      return new SettlementConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static SettlementConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintSettlement>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SettlementConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintSettlement>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlement.m_StartLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementConfigurator SetStartLevel(SettlementState.LevelType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_StartLevel = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlement.m_MaxSettlementLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementConfigurator SetMaxSettlementLevel(SettlementState.LevelType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_MaxSettlementLevel = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlement.m_HasWaterSlot"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementConfigurator SetHasWaterSlot(bool value)
    {
      return OnConfigureInternal(bp => bp.m_HasWaterSlot = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlement.m_DefaultSettlementName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementConfigurator SetDefaultSettlementName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_DefaultSettlementName = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlement.m_SettlementBuildArea"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintAreaEnterPoint"/></param>
    [Generated]
    public SettlementConfigurator SetSettlementBuildArea(string value)
    {
      return OnConfigureInternal(bp => bp.m_SettlementBuildArea = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlement.m_SettlementBuildAreaWithWater"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintAreaEnterPoint"/></param>
    [Generated]
    public SettlementConfigurator SetSettlementBuildAreaWithWater(string value)
    {
      return OnConfigureInternal(bp => bp.m_SettlementBuildAreaWithWater = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlement.m_CustomSettlementEntrance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementConfigurator SetCustomSettlementEntrance(bool value)
    {
      return OnConfigureInternal(bp => bp.m_CustomSettlementEntrance = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlement.m_SettlementIsPrebuilt"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementConfigurator SetSettlementIsPrebuilt(bool value)
    {
      return OnConfigureInternal(bp => bp.m_SettlementIsPrebuilt = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlement.m_SettlementEntrance"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintAreaEnterPoint"/></param>
    [Generated]
    public SettlementConfigurator SetSettlementEntrance(string value)
    {
      return OnConfigureInternal(bp => bp.m_SettlementEntrance = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlement.m_SettlementEntrances"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintMultiEntrance"/></param>
    [Generated]
    public SettlementConfigurator SetSettlementEntrances(string value)
    {
      return OnConfigureInternal(bp => bp.m_SettlementEntrances = BlueprintTool.GetRef<BlueprintMultiEntrance.Reference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlement.m_CustomSiegeDurationDays"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementConfigurator SetCustomSiegeDurationDays(Nullable<int> value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_CustomSiegeDurationDays = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlement.m_NeedOwnMarker"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementConfigurator SetNeedOwnMarker(bool value)
    {
      return OnConfigureInternal(bp => bp.m_NeedOwnMarker = value);
    }
  }
}
