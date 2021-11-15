using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.QA.Clockwork;
using System.Linq;

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
    /// Modifies <see cref="BlueprintClockworkScenarioPart.RetrySkillChecks"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioPartConfigurator AddToRetrySkillChecks(params EntityReference[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.RetrySkillChecks.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenarioPart.RetrySkillChecks"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioPartConfigurator RemoveFromRetrySkillChecks(params EntityReference[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.RetrySkillChecks = bp.RetrySkillChecks.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenarioPart.HighPriorityAnswers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAnswer"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator AddToHighPriorityAnswers(params string[] values)
    {
      return OnConfigureInternal(bp => bp.HighPriorityAnswers.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenarioPart.HighPriorityAnswers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAnswer"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator RemoveFromHighPriorityAnswers(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name));
            bp.HighPriorityAnswers =
                bp.HighPriorityAnswers
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenarioPart.DoNotSellItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintItem"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator AddToDoNotSellItems(params string[] values)
    {
      return OnConfigureInternal(bp => bp.DoNotSellItems.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenarioPart.DoNotSellItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintItem"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator RemoveFromDoNotSellItems(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name));
            bp.DoNotSellItems =
                bp.DoNotSellItems
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenarioPart.DoNotInterract"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioPartConfigurator AddToDoNotInterract(params ClockworkEntityReference[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.DoNotInterract.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenarioPart.DoNotInterract"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioPartConfigurator RemoveFromDoNotInterract(params ClockworkEntityReference[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.DoNotInterract = bp.DoNotInterract.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenarioPart.DoNotInterractUnits"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnit"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator AddToDoNotInterractUnits(params string[] values)
    {
      return OnConfigureInternal(bp => bp.DoNotInterractUnits.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenarioPart.DoNotInterractUnits"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnit"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator RemoveFromDoNotInterractUnits(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name));
            bp.DoNotInterractUnits =
                bp.DoNotInterractUnits
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenarioPart.DoNotUseAnswer"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAnswer"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator AddToDoNotUseAnswer(params string[] values)
    {
      return OnConfigureInternal(bp => bp.DoNotUseAnswer.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenarioPart.DoNotUseAnswer"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAnswer"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator RemoveFromDoNotUseAnswer(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name));
            bp.DoNotUseAnswer =
                bp.DoNotUseAnswer
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenarioPart.DoNotEnterAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintArea"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator AddToDoNotEnterAreas(params string[] values)
    {
      return OnConfigureInternal(bp => bp.DoNotEnterAreas.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenarioPart.DoNotEnterAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintArea"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator RemoveFromDoNotEnterAreas(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name));
            bp.DoNotEnterAreas =
                bp.DoNotEnterAreas
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
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
