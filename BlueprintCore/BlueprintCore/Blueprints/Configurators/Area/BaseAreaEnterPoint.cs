//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
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
    public TBuilder SetTooltipList(params LocalizedString[] tooltipList)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in tooltipList) { Validate(item); }
          bp.m_TooltipList = tooltipList.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAreaEnterPoint.m_TooltipList"/>
    /// </summary>
    public TBuilder AddToTooltipList(params LocalizedString[] tooltipList)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TooltipList = bp.m_TooltipList ?? new();
          bp.m_TooltipList.AddRange(tooltipList);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaEnterPoint.m_TooltipList"/>
    /// </summary>
    public TBuilder RemoveFromTooltipList(params LocalizedString[] tooltipList)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TooltipList is null) { return; }
          bp.m_TooltipList = bp.m_TooltipList.Where(val => !tooltipList.Contains(val)).ToList();
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
          bp.m_TooltipList = bp.m_TooltipList.Where(predicate).ToList();
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
    public TBuilder SetTooltip(LocalizedString tooltip)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Tooltip = tooltip;
          if (bp.m_Tooltip is null)
          {
            bp.m_Tooltip = Utils.Constants.Empty.String;
          }
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
    /// Modifies <see cref="BlueprintAreaEnterPoint.m_CanBeOutsideNavmesh"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCanBeOutsideNavmesh(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_CanBeOutsideNavmesh);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaEnterPoint.Icon"/>
    /// </summary>
    public TBuilder SetIcon(Sprite icon)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(icon);
          bp.Icon = icon;
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
    public TBuilder SetHoverIcon(Sprite hoverIcon)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(hoverIcon);
          bp.HoverIcon = hoverIcon;
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
    public TBuilder AddAllowOnZoneSettings(
        GlobalMapZone[]? allowedNaturalSettings = null)
    {
      var component = new AllowOnZoneSettings();
      component.m_AllowedNaturalSettings = allowedNaturalSettings ?? component.m_AllowedNaturalSettings;
      if (component.m_AllowedNaturalSettings is null)
      {
        component.m_AllowedNaturalSettings = new GlobalMapZone[0];
      }
      return AddComponent(component);
    }
  }
}
