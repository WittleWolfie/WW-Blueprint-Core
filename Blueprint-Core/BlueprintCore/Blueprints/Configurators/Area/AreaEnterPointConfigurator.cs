using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Localization;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>Configurator for <see cref="BlueprintAreaEnterPoint"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAreaEnterPoint))]
  public class AreaEnterPointConfigurator : BaseBlueprintConfigurator<BlueprintAreaEnterPoint, AreaEnterPointConfigurator>
  {
     private AreaEnterPointConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AreaEnterPointConfigurator For(string name)
    {
      return new AreaEnterPointConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AreaEnterPointConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintAreaEnterPoint>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AreaEnterPointConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintAreaEnterPoint>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEnterPoint.m_Area"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintArea"/></param>
    [Generated]
    public AreaEnterPointConfigurator SetArea(string value)
    {
      return OnConfigureInternal(bp => bp.m_Area = BlueprintTool.GetRef<BlueprintAreaReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEnterPoint.m_AreaPart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintAreaPart"/></param>
    [Generated]
    public AreaEnterPointConfigurator SetAreaPart(string value)
    {
      return OnConfigureInternal(bp => bp.m_AreaPart = BlueprintTool.GetRef<BlueprintAreaPartReference>(value));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaEnterPoint.m_TooltipList"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEnterPointConfigurator AddToTooltipList(params LocalizedString[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_TooltipList.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaEnterPoint.m_TooltipList"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEnterPointConfigurator RemoveFromTooltipList(params LocalizedString[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_TooltipList = bp.m_TooltipList.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEnterPoint.m_Tooltip"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEnterPointConfigurator SetTooltip(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_Tooltip = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEnterPoint.m_CanBeOutsideNavmesh"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEnterPointConfigurator SetCanBeOutsideNavmesh(bool value)
    {
      return OnConfigureInternal(bp => bp.m_CanBeOutsideNavmesh = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEnterPoint.Icon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEnterPointConfigurator SetIcon(Sprite value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Icon = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEnterPoint.HoverIcon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEnterPointConfigurator SetHoverIcon(Sprite value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.HoverIcon = value);
    }
  }
}
