using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>Configurator for <see cref="BlueprintGlobalMapPoint"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintGlobalMapPoint))]
  public class GlobalMapPointConfigurator : BaseBlueprintConfigurator<BlueprintGlobalMapPoint, GlobalMapPointConfigurator>
  {
     private GlobalMapPointConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static GlobalMapPointConfigurator For(string name)
    {
      return new GlobalMapPointConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static GlobalMapPointConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintGlobalMapPoint>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static GlobalMapPointConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintGlobalMapPoint>(name, assetId);
      return For(name);
    }


    /// <summary>
    /// Adds <see cref="LocationRadiusBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(LocationRadiusBuff))]
    public GlobalMapPointConfigurator AddLocationRadiusBuff(
        float Radius,
        string m_Buff)
    {
      
      var component =  new LocationRadiusBuff();
      component.Radius = Radius;
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LocationRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="RequiredCompanions"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(LocationRestriction))]
    public GlobalMapPointConfigurator AddLocationRestriction(
        ConditionsBuilder IgnoreCondition,
        ConditionsBuilder AllowedCondition,
        string[] RequiredCompanions,
        LocalizedString Description)
    {
      ValidateParam(Description);
      
      var component =  new LocationRestriction();
      component.IgnoreCondition = IgnoreCondition.Build();
      component.AllowedCondition = AllowedCondition.Build();
      component.RequiredCompanions = RequiredCompanions.Select(bp => BlueprintTool.GetRef<BlueprintUnitReference>(bp)).ToList();
      component.Description = Description;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LocationRevealedTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LocationRevealedTrigger))]
    public GlobalMapPointConfigurator AddLocationRevealedTrigger(
        bool OnlyOnce,
        ActionsBuilder OnReveal)
    {
      
      var component =  new LocationRevealedTrigger();
      component.OnlyOnce = OnlyOnce;
      component.OnReveal = OnReveal.Build();
      return AddComponent(component);
    }
  }
}
