using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Area;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.AI;
using Kingmaker.Kingdom.Buffs;
using Kingmaker.RandomEncounters.Settings;
using System;
namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintArea"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArea))]
  public abstract class BaseAreaConfigurator<T, TBuilder>
      : BaseAreaPartConfigurator<T, TBuilder>
      where T : BlueprintArea
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseAreaConfigurator(string name) : base(name) { }


    /// <summary>
    /// Adds <see cref="CombatRandomEncounterAreaSettings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_DefaultEnterPoint"><see cref="BlueprintAreaEnterPoint"/></param>
    /// <param name="m_GoodAvoidanceEnterPoint"><see cref="BlueprintAreaEnterPoint"/></param>
    [Generated]
    [Implements(typeof(CombatRandomEncounterAreaSettings))]
    public TBuilder AddCombatRandomEncounterAreaSettings(
        string m_DefaultEnterPoint,
        string m_GoodAvoidanceEnterPoint,
        GlobalMapZone[] AllowedNaturalSettings,
        CombatRandomEncounterAreaSettings.Formation[] Formations)
    {
      foreach (var item in AllowedNaturalSettings)
      {
        ValidateParam(item);
      }
      foreach (var item in Formations)
      {
        ValidateParam(item);
      }
      
      var component =  new CombatRandomEncounterAreaSettings();
      component.m_DefaultEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(m_DefaultEnterPoint);
      component.m_GoodAvoidanceEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(m_GoodAvoidanceEnterPoint);
      component.AllowedNaturalSettings = AllowedNaturalSettings;
      component.Formations = Formations;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AreaSettlementLink"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="SettlementRef"><see cref="BlueprintSettlement"/></param>
    [Generated]
    [Implements(typeof(AreaSettlementLink))]
    public TBuilder AddAreaSettlementLink(
        string SettlementRef)
    {
      
      var component =  new AreaSettlementLink();
      component.SettlementRef = BlueprintTool.GetRef<BlueprintSettlement.Reference>(SettlementRef);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OverrideCampingAction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OverrideCampingAction))]
    public TBuilder AddOverrideCampingAction(
        ActionsBuilder OnRestActions,
        bool SkipRest)
    {
      
      var component =  new OverrideCampingAction();
      component.OnRestActions = OnRestActions.Build();
      component.SkipRest = SkipRest;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BirthdayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BirthdayTrigger))]
    public TBuilder AddBirthdayTrigger(
        ConditionsBuilder Condition,
        ActionsBuilder Actions)
    {
      
      var component =  new BirthdayTrigger();
      component.Condition = Condition.Build();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryDayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EveryDayTrigger))]
    public TBuilder AddEveryDayTrigger(
        ConditionsBuilder Condition,
        ActionsBuilder Actions,
        int SkipDays)
    {
      
      var component =  new EveryDayTrigger();
      component.Condition = Condition.Build();
      component.Actions = Actions.Build();
      component.SkipDays = SkipDays;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryWeekTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EveryWeekTrigger))]
    public TBuilder AddEveryWeekTrigger(
        ConditionsBuilder Condition,
        ActionsBuilder Actions,
        int SkipWeeks)
    {
      
      var component =  new EveryWeekTrigger();
      component.Condition = Condition.Build();
      component.Actions = Actions.Build();
      component.SkipWeeks = SkipWeeks;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SettlementAISettings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_AIBuildListVillage"><see cref="SettlementBuildList"/></param>
    /// <param name="m_AIBuildListTown"><see cref="SettlementBuildList"/></param>
    /// <param name="m_AIBuildListCity"><see cref="SettlementBuildList"/></param>
    [Generated]
    [Implements(typeof(SettlementAISettings))]
    public TBuilder AddSettlementAISettings(
        string m_AIBuildListVillage,
        string m_AIBuildListTown,
        string m_AIBuildListCity)
    {
      
      var component =  new SettlementAISettings();
      component.m_AIBuildListVillage = BlueprintTool.GetRef<SettlementBuildListReference>(m_AIBuildListVillage);
      component.m_AIBuildListTown = BlueprintTool.GetRef<SettlementBuildListReference>(m_AIBuildListTown);
      component.m_AIBuildListCity = BlueprintTool.GetRef<SettlementBuildListReference>(m_AIBuildListCity);
      return AddComponent(component);
    }
  }

  /// <summary>Configurator for <see cref="BlueprintArea"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArea))]
  public class AreaConfigurator : BaseAreaPartConfigurator<BlueprintArea, AreaConfigurator>
  {
     private AreaConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AreaConfigurator For(string name)
    {
      return new AreaConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AreaConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintArea>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AreaConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintArea>(name, assetId);
      return For(name);
    }


    /// <summary>
    /// Adds <see cref="CombatRandomEncounterAreaSettings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_DefaultEnterPoint"><see cref="BlueprintAreaEnterPoint"/></param>
    /// <param name="m_GoodAvoidanceEnterPoint"><see cref="BlueprintAreaEnterPoint"/></param>
    [Generated]
    [Implements(typeof(CombatRandomEncounterAreaSettings))]
    public AreaConfigurator AddCombatRandomEncounterAreaSettings(
        string m_DefaultEnterPoint,
        string m_GoodAvoidanceEnterPoint,
        GlobalMapZone[] AllowedNaturalSettings,
        CombatRandomEncounterAreaSettings.Formation[] Formations)
    {
      foreach (var item in AllowedNaturalSettings)
      {
        ValidateParam(item);
      }
      foreach (var item in Formations)
      {
        ValidateParam(item);
      }
      
      var component =  new CombatRandomEncounterAreaSettings();
      component.m_DefaultEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(m_DefaultEnterPoint);
      component.m_GoodAvoidanceEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(m_GoodAvoidanceEnterPoint);
      component.AllowedNaturalSettings = AllowedNaturalSettings;
      component.Formations = Formations;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AreaSettlementLink"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="SettlementRef"><see cref="BlueprintSettlement"/></param>
    [Generated]
    [Implements(typeof(AreaSettlementLink))]
    public AreaConfigurator AddAreaSettlementLink(
        string SettlementRef)
    {
      
      var component =  new AreaSettlementLink();
      component.SettlementRef = BlueprintTool.GetRef<BlueprintSettlement.Reference>(SettlementRef);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OverrideCampingAction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OverrideCampingAction))]
    public AreaConfigurator AddOverrideCampingAction(
        ActionsBuilder OnRestActions,
        bool SkipRest)
    {
      
      var component =  new OverrideCampingAction();
      component.OnRestActions = OnRestActions.Build();
      component.SkipRest = SkipRest;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BirthdayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BirthdayTrigger))]
    public AreaConfigurator AddBirthdayTrigger(
        ConditionsBuilder Condition,
        ActionsBuilder Actions)
    {
      
      var component =  new BirthdayTrigger();
      component.Condition = Condition.Build();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryDayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EveryDayTrigger))]
    public AreaConfigurator AddEveryDayTrigger(
        ConditionsBuilder Condition,
        ActionsBuilder Actions,
        int SkipDays)
    {
      
      var component =  new EveryDayTrigger();
      component.Condition = Condition.Build();
      component.Actions = Actions.Build();
      component.SkipDays = SkipDays;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryWeekTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EveryWeekTrigger))]
    public AreaConfigurator AddEveryWeekTrigger(
        ConditionsBuilder Condition,
        ActionsBuilder Actions,
        int SkipWeeks)
    {
      
      var component =  new EveryWeekTrigger();
      component.Condition = Condition.Build();
      component.Actions = Actions.Build();
      component.SkipWeeks = SkipWeeks;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SettlementAISettings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_AIBuildListVillage"><see cref="SettlementBuildList"/></param>
    /// <param name="m_AIBuildListTown"><see cref="SettlementBuildList"/></param>
    /// <param name="m_AIBuildListCity"><see cref="SettlementBuildList"/></param>
    [Generated]
    [Implements(typeof(SettlementAISettings))]
    public AreaConfigurator AddSettlementAISettings(
        string m_AIBuildListVillage,
        string m_AIBuildListTown,
        string m_AIBuildListCity)
    {
      
      var component =  new SettlementAISettings();
      component.m_AIBuildListVillage = BlueprintTool.GetRef<SettlementBuildListReference>(m_AIBuildListVillage);
      component.m_AIBuildListTown = BlueprintTool.GetRef<SettlementBuildListReference>(m_AIBuildListTown);
      component.m_AIBuildListCity = BlueprintTool.GetRef<SettlementBuildListReference>(m_AIBuildListCity);
      return AddComponent(component);
    }
  }
}
