//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.RandomEncounters.Settings;
using Kingmaker.Utility;
using System;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAreaEnterPoint"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAreaEnterPointConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintAreaEnterPoint
    where TBuilder : BaseAreaEnterPointConfigurator<T, TBuilder>
  {
    protected BaseAreaEnterPointConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintAreaEnterPoint>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Area = copyFrom.m_Area;
          bp.m_AreaPart = copyFrom.m_AreaPart;
          bp.m_TooltipList = copyFrom.m_TooltipList;
          bp.m_Tooltip = copyFrom.m_Tooltip;
          bp.m_CanBeOutsideNavmesh = copyFrom.m_CanBeOutsideNavmesh;
          bp.Icon = copyFrom.Icon;
          bp.HoverIcon = copyFrom.HoverIcon;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintAreaEnterPoint>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Area = copyFrom.m_Area;
          bp.m_AreaPart = copyFrom.m_AreaPart;
          bp.m_TooltipList = copyFrom.m_TooltipList;
          bp.m_Tooltip = copyFrom.m_Tooltip;
          bp.m_CanBeOutsideNavmesh = copyFrom.m_CanBeOutsideNavmesh;
          bp.Icon = copyFrom.Icon;
          bp.HoverIcon = copyFrom.HoverIcon;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaEnterPoint.m_Area"/>
    /// </summary>
    ///
    /// <param name="area">
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetArea(Blueprint<BlueprintAreaReference> area)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Area = area?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaEnterPoint.m_Area"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyArea(Action<BlueprintAreaReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Area is null) { return; }
          action.Invoke(bp.m_Area);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaEnterPoint.m_AreaPart"/>
    /// </summary>
    ///
    /// <param name="areaPart">
    /// <para>
    /// Blueprint of type BlueprintAreaPart. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAreaPart(Blueprint<BlueprintAreaPartReference> areaPart)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AreaPart = areaPart?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaEnterPoint.m_AreaPart"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAreaPart(Action<BlueprintAreaPartReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AreaPart is null) { return; }
          action.Invoke(bp.m_AreaPart);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaEnterPoint.m_TooltipList"/>
    /// </summary>
    ///
    /// <param name="tooltipList">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetTooltipList(params LocalString[] tooltipList)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TooltipList = tooltipList?.Select(entry => entry?.LocalizedString)?.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAreaEnterPoint.m_TooltipList"/>
    /// </summary>
    ///
    /// <param name="tooltipList">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder AddToTooltipList(params LocalString[] tooltipList)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TooltipList = bp.m_TooltipList ?? new();
          bp.m_TooltipList.AddRange(tooltipList?.Select(entry => entry?.LocalizedString));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaEnterPoint.m_TooltipList"/>
    /// </summary>
    ///
    /// <param name="tooltipList">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder RemoveFromTooltipList(params LocalString[] tooltipList)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TooltipList is null) { return; }
          var convertedParams = tooltipList.Select(entry => entry?.LocalizedString);
          bp.m_TooltipList = bp.m_TooltipList.Where(val => !convertedParams.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaEnterPoint.m_TooltipList"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromTooltipList(Func<LocalizedString, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TooltipList is null) { return; }
          bp.m_TooltipList = bp.m_TooltipList.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAreaEnterPoint.m_TooltipList"/>
    /// </summary>
    public TBuilder ClearTooltipList()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TooltipList = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaEnterPoint.m_TooltipList"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyTooltipList(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TooltipList is null) { return; }
          bp.m_TooltipList.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaEnterPoint.m_Tooltip"/>
    /// </summary>
    ///
    /// <param name="tooltip">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetTooltip(LocalString tooltip)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Tooltip = tooltip?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaEnterPoint.m_Tooltip"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTooltip(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Tooltip is null) { return; }
          action.Invoke(bp.m_Tooltip);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaEnterPoint.m_CanBeOutsideNavmesh"/>
    /// </summary>
    ///
    /// <param name="canBeOutsideNavmesh">
    /// <para>
    /// Tooltip: If true, party can teleport to this point even if it&amp;apos;s not on the navmesh. See PF-329173
    /// </para>
    /// </param>
    public TBuilder SetCanBeOutsideNavmesh(bool canBeOutsideNavmesh = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CanBeOutsideNavmesh = canBeOutsideNavmesh;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaEnterPoint.Icon"/>
    /// </summary>
    ///
    /// <param name="icon">
    /// You can pass in the animation using a Sprite or it's AssetId.
    /// </param>
    public TBuilder SetIcon(Asset<Sprite> icon)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Icon = icon?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaEnterPoint.Icon"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIcon(Action<Sprite> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Icon is null) { return; }
          action.Invoke(bp.Icon);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaEnterPoint.HoverIcon"/>
    /// </summary>
    ///
    /// <param name="hoverIcon">
    /// You can pass in the animation using a Sprite or it's AssetId.
    /// </param>
    public TBuilder SetHoverIcon(Asset<Sprite> hoverIcon)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HoverIcon = hoverIcon?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaEnterPoint.HoverIcon"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHoverIcon(Action<Sprite> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.HoverIcon is null) { return; }
          action.Invoke(bp.HoverIcon);
        });
    }

    /// <summary>
    /// Adds <see cref="AllowOnZoneSettings"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Trader_Desert</term><description>fbe119150585526469ae85a3aff8094d</description></item>
    /// <item><term>Trader_Karelia</term><description>70e1898c5d62e2b47bba99330f447660</description></item>
    /// <item><term>Trader_Winter</term><description>ac97038913a452d4789e11f4c3eedc66</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAllowOnZoneSettings(
        GlobalMapZone[]? allowedNaturalSettings = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AllowOnZoneSettings();
      component.m_AllowedNaturalSettings = allowedNaturalSettings ?? component.m_AllowedNaturalSettings;
      if (component.m_AllowedNaturalSettings is null)
      {
        component.m_AllowedNaturalSettings = new GlobalMapZone[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Area is null)
      {
        Blueprint.m_Area = BlueprintTool.GetRef<BlueprintAreaReference>(null);
      }
      if (Blueprint.m_AreaPart is null)
      {
        Blueprint.m_AreaPart = BlueprintTool.GetRef<BlueprintAreaPartReference>(null);
      }
      if (Blueprint.m_TooltipList is null)
      {
        Blueprint.m_TooltipList = new();
      }
      if (Blueprint.m_Tooltip is null)
      {
        Blueprint.m_Tooltip = Utils.Constants.Empty.String;
      }
    }
  }
}
