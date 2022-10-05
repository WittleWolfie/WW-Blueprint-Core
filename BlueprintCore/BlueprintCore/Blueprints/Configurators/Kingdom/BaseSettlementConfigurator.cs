//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
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
    protected BaseSettlementConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintSettlement>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_StartLevel = copyFrom.m_StartLevel;
          bp.m_MaxSettlementLevel = copyFrom.m_MaxSettlementLevel;
          bp.m_HasWaterSlot = copyFrom.m_HasWaterSlot;
          bp.m_DefaultSettlementName = copyFrom.m_DefaultSettlementName;
          bp.m_SettlementBuildArea = copyFrom.m_SettlementBuildArea;
          bp.m_SettlementBuildAreaWithWater = copyFrom.m_SettlementBuildAreaWithWater;
          bp.m_CustomSettlementEntrance = copyFrom.m_CustomSettlementEntrance;
          bp.m_SettlementIsPrebuilt = copyFrom.m_SettlementIsPrebuilt;
          bp.m_SettlementEntrance = copyFrom.m_SettlementEntrance;
          bp.m_SettlementEntrances = copyFrom.m_SettlementEntrances;
          bp.m_CustomSiegeDurationDays = copyFrom.m_CustomSiegeDurationDays;
          bp.m_NeedOwnMarker = copyFrom.m_NeedOwnMarker;
        });
    }

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
    /// Sets the value of <see cref="BlueprintSettlement.m_DefaultSettlementName"/>
    /// </summary>
    ///
    /// <param name="defaultSettlementName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetDefaultSettlementName(LocalString defaultSettlementName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DefaultSettlementName = defaultSettlementName?.LocalizedString;
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSettlementBuildArea(Blueprint<BlueprintAreaEnterPointReference> settlementBuildArea)
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSettlementBuildAreaWithWater(Blueprint<BlueprintAreaEnterPointReference> settlementBuildAreaWithWater)
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSettlementEntrance(Blueprint<BlueprintAreaEnterPointReference> settlementEntrance)
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSettlementEntrances(Blueprint<BlueprintMultiEntrance.Reference> settlementEntrances)
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
    /// InfoBox: If false, settlement marker won&amp;apos;t be spawn, location marker will be used instead
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

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_DefaultSettlementName is null)
      {
        Blueprint.m_DefaultSettlementName = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_SettlementBuildArea is null)
      {
        Blueprint.m_SettlementBuildArea = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(null);
      }
      if (Blueprint.m_SettlementBuildAreaWithWater is null)
      {
        Blueprint.m_SettlementBuildAreaWithWater = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(null);
      }
      if (Blueprint.m_SettlementEntrance is null)
      {
        Blueprint.m_SettlementEntrance = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(null);
      }
      if (Blueprint.m_SettlementEntrances is null)
      {
        Blueprint.m_SettlementEntrances = BlueprintTool.GetRef<BlueprintMultiEntrance.Reference>(null);
      }
    }
  }
}
