using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.QA.Clockwork;

namespace BlueprintCore.Blueprints.Configurators.QA.Clockwork
{
  /// <summary>Configurator for <see cref="BlueprintClockworkScenarioPart"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintClockworkScenarioPart))]
  public class ClockworkScenarioPartConfigurator : BaseBlueprintConfigurator<BlueprintClockworkScenarioPart, ClockworkScenarioPartConfigurator>
  {
     private ClockworkScenarioPartConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ClockworkScenarioPartConfigurator For(string name)
    {
      return new ClockworkScenarioPartConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ClockworkScenarioPartConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintClockworkScenarioPart>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ClockworkScenarioPartConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintClockworkScenarioPart>(name, assetId);
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
    public ClockworkScenarioPartConfigurator AddAreaTest(
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
    public ClockworkScenarioPartConfigurator AddConditionalCommandList(
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
    /// Adds <see cref="MythicLevelUpPlan"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="BeginnerMythic"><see cref="BlueprintFeature"/></param>
    /// <param name="EarlyMythic"><see cref="BlueprintFeature"/></param>
    /// <param name="LateMythic"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(MythicLevelUpPlan))]
    public ClockworkScenarioPartConfigurator AddMythicLevelUpPlan(
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
