using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.QA.Clockwork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.QA.Clockwork
{
  /// <summary>Configurator for <see cref="BlueprintClockworkScenario"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintClockworkScenario))]
  public class ClockworkScenarioConfigurator : BaseBlueprintConfigurator<BlueprintClockworkScenario, ClockworkScenarioConfigurator>
  {
     private ClockworkScenarioConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ClockworkScenarioConfigurator For(string name)
    {
      return new ClockworkScenarioConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ClockworkScenarioConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintClockworkScenario>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ClockworkScenarioConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintClockworkScenario>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="AreaTest"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="Area"><see cref="BlueprintArea"/></param>
    /// <param name="AreaPart"><see cref="BlueprintAreaPart"/></param>
    [Generated]
    [Implements(typeof(AreaTest))]
    public ClockworkScenarioConfigurator AddAreaTest(
        string Area,
        string AreaPart,
        bool EveryVisit,
        Condition Condition,
        ClockworkCommandList CommandList)
    {
      ValidateParam(Condition);
      ValidateParam(CommandList);
      
      var component =  new AreaTest();
      component.Area = BlueprintTool.GetRef<BlueprintAreaReference>(Area);
      component.AreaPart = BlueprintTool.GetRef<BlueprintAreaPartReference>(AreaPart);
      component.EveryVisit = EveryVisit;
      component.Condition = Condition;
      component.CommandList = CommandList;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConditionalCommandList"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ConditionalCommandList))]
    public ClockworkScenarioConfigurator AddConditionalCommandList(
        Condition Condition,
        ClockworkCommandList CommandList)
    {
      ValidateParam(Condition);
      ValidateParam(CommandList);
      
      var component =  new ConditionalCommandList();
      component.Condition = Condition;
      component.CommandList = CommandList;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ExploreFlyingIsles"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="Areas"><see cref="BlueprintArea"/></param>
    [Generated]
    [Implements(typeof(ExploreFlyingIsles))]
    public ClockworkScenarioConfigurator AddExploreFlyingIsles(
        bool JustIgnoreWalls,
        float WaitTimeAfterCamRotation,
        string[] Areas)
    {
      
      var component =  new ExploreFlyingIsles();
      component.JustIgnoreWalls = JustIgnoreWalls;
      component.WaitTimeAfterCamRotation = WaitTimeAfterCamRotation;
      component.Areas = Areas.Select(bp => BlueprintTool.GetRef<BlueprintAreaReference>(bp)).ToList();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MythicLevelUpPlan"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="BeginnerMythic"><see cref="BlueprintFeature"/></param>
    /// <param name="EarlyMythic"><see cref="BlueprintFeature"/></param>
    /// <param name="LateMythic"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(MythicLevelUpPlan))]
    public ClockworkScenarioConfigurator AddMythicLevelUpPlan(
        string BeginnerMythic,
        string EarlyMythic,
        string LateMythic)
    {
      
      var component =  new MythicLevelUpPlan();
      component.BeginnerMythic = BlueprintTool.GetRef<BlueprintFeatureReference>(BeginnerMythic);
      component.EarlyMythic = BlueprintTool.GetRef<BlueprintFeatureReference>(EarlyMythic);
      component.LateMythic = BlueprintTool.GetRef<BlueprintFeatureReference>(LateMythic);
      return AddComponent(component);
    }
  }
}
