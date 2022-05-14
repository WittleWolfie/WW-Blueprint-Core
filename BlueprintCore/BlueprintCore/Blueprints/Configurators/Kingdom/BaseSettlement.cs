//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Settlements;
using Kingmaker.Localization;
using System;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintSettlement"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseSettlementConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintSettlement
    where TBuilder : BaseSettlementConfigurator<T, TBuilder>
  {
    protected BaseSettlementConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSettlement.m_StartLevel"/>
    /// </summary>
    public TBuilder SetStartLevel(SettlementState.LevelType startLevel)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StartLevel = startLevel;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSettlement.m_StartLevel"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyStartLevel(Action<SettlementState.LevelType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_StartLevel);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSettlement.m_MaxSettlementLevel"/>
    /// </summary>
    public TBuilder SetMaxSettlementLevel(SettlementState.LevelType maxSettlementLevel)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MaxSettlementLevel = maxSettlementLevel;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSettlement.m_MaxSettlementLevel"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMaxSettlementLevel(Action<SettlementState.LevelType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_MaxSettlementLevel);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSettlement.m_HasWaterSlot"/>
    /// </summary>
    public TBuilder SetHasWaterSlot(bool hasWaterSlot = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_HasWaterSlot = hasWaterSlot;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSettlement.m_HasWaterSlot"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHasWaterSlot(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_HasWaterSlot);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSettlement.m_DefaultSettlementName"/>
    /// </summary>
    public TBuilder SetDefaultSettlementName(LocalizedString defaultSettlementName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DefaultSettlementName = defaultSettlementName;
          if (bp.m_DefaultSettlementName is null)
          {
            bp.m_DefaultSettlementName = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSettlement.m_DefaultSettlementName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDefaultSettlementName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DefaultSettlementName is null) { return; }
          action.Invoke(bp.m_DefaultSettlementName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSettlement.m_SettlementBuildArea"/>
    /// </summary>
    ///
    /// <param name="settlementBuildArea">
    /// <para>
    /// InfoBox: This Area will be used for settlement management
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSettlementBuildArea(Blueprint<BlueprintAreaEnterPoint, BlueprintAreaEnterPointReference> settlementBuildArea)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SettlementBuildArea = settlementBuildArea?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSettlement.m_SettlementBuildArea"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="settlementBuildArea">
    /// <para>
    /// InfoBox: This Area will be used for settlement management
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifySettlementBuildArea(Action<BlueprintAreaEnterPointReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SettlementBuildArea is null) { return; }
          action.Invoke(bp.m_SettlementBuildArea);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSettlement.m_SettlementBuildAreaWithWater"/>
    /// </summary>
    ///
    /// <param name="settlementBuildAreaWithWater">
    /// <para>
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSettlementBuildAreaWithWater(Blueprint<BlueprintAreaEnterPoint, BlueprintAreaEnterPointReference> settlementBuildAreaWithWater)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SettlementBuildAreaWithWater = settlementBuildAreaWithWater?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSettlement.m_SettlementBuildAreaWithWater"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="settlementBuildAreaWithWater">
    /// <para>
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifySettlementBuildAreaWithWater(Action<BlueprintAreaEnterPointReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SettlementBuildAreaWithWater is null) { return; }
          action.Invoke(bp.m_SettlementBuildAreaWithWater);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSettlement.m_CustomSettlementEntrance"/>
    /// </summary>
    public TBuilder SetCustomSettlementEntrance(bool customSettlementEntrance = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CustomSettlementEntrance = customSettlementEntrance;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSettlement.m_CustomSettlementEntrance"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCustomSettlementEntrance(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_CustomSettlementEntrance);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSettlement.m_SettlementIsPrebuilt"/>
    /// </summary>
    public TBuilder SetSettlementIsPrebuilt(bool settlementIsPrebuilt = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SettlementIsPrebuilt = settlementIsPrebuilt;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSettlement.m_SettlementIsPrebuilt"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySettlementIsPrebuilt(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_SettlementIsPrebuilt);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSettlement.m_SettlementEntrance"/>
    /// </summary>
    ///
    /// <param name="settlementEntrance">
    /// <para>
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSettlementEntrance(Blueprint<BlueprintAreaEnterPoint, BlueprintAreaEnterPointReference> settlementEntrance)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SettlementEntrance = settlementEntrance?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSettlement.m_SettlementEntrance"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="settlementEntrance">
    /// <para>
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifySettlementEntrance(Action<BlueprintAreaEnterPointReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SettlementEntrance is null) { return; }
          action.Invoke(bp.m_SettlementEntrance);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSettlement.m_SettlementEntrances"/>
    /// </summary>
    ///
    /// <param name="settlementEntrances">
    /// <para>
    /// Blueprint of type BlueprintMultiEntrance. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSettlementEntrances(Blueprint<BlueprintMultiEntrance, BlueprintMultiEntrance.Reference> settlementEntrances)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SettlementEntrances = settlementEntrances?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSettlement.m_SettlementEntrances"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="settlementEntrances">
    /// <para>
    /// Blueprint of type BlueprintMultiEntrance. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifySettlementEntrances(Action<BlueprintMultiEntrance.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SettlementEntrances is null) { return; }
          action.Invoke(bp.m_SettlementEntrances);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSettlement.m_CustomSiegeDurationDays"/>
    /// </summary>
    ///
    /// <param name="customSiegeDurationDays">
    /// <para>
    /// InfoBox: If set, settings from KingdomRoot about siege duration will be ignored
    /// </para>
    /// </param>
    public TBuilder SetCustomSiegeDurationDays(int customSiegeDurationDays)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CustomSiegeDurationDays = customSiegeDurationDays;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSettlement.m_CustomSiegeDurationDays"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="customSiegeDurationDays">
    /// <para>
    /// InfoBox: If set, settings from KingdomRoot about siege duration will be ignored
    /// </para>
    /// </param>
    public TBuilder ModifyCustomSiegeDurationDays(Action<int?> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_CustomSiegeDurationDays);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSettlement.m_NeedOwnMarker"/>
    /// </summary>
    ///
    /// <param name="needOwnMarker">
    /// <para>
    /// InfoBox: If false, settlement marker won't be spawn, location marker will be used instead
    /// </para>
    /// </param>
    public TBuilder SetNeedOwnMarker(bool needOwnMarker = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_NeedOwnMarker = needOwnMarker;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSettlement.m_NeedOwnMarker"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="needOwnMarker">
    /// <para>
    /// InfoBox: If false, settlement marker won't be spawn, location marker will be used instead
    /// </para>
    /// </param>
    public TBuilder ModifyNeedOwnMarker(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_NeedOwnMarker);
        });
    }
  }
}
