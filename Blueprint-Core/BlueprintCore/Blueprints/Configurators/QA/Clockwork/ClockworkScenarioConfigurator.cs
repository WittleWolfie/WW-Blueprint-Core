using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.ElementsSystem;
using Kingmaker.QA.Clockwork;
using Kingmaker.Settings.Difficulty;
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
    /// Sets <see cref="BlueprintClockworkScenario.m_ScenarioName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetScenarioName(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_ScenarioName = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.ScenarioAuthor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetScenarioAuthor(BlueprintClockworkScenario.ScenarioQA value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ScenarioAuthor = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.TestMode"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetTestMode(BlueprintClockworkScenario.ClockworkTestMode value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.TestMode = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.startMode"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetstartMode(BlueprintClockworkScenario.StartMode value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.startMode = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.Preset"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintAreaPreset"/></param>
    [Generated]
    public ClockworkScenarioConfigurator SetPreset(string value)
    {
      return OnConfigureInternal(bp => bp.Preset = BlueprintTool.GetRef<BlueprintAreaPresetReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.Save"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetSave(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Save = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.RemoteSave"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetRemoteSave(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.RemoteSave = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.BlueprintPlayerUnit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintUnit"/></param>
    [Generated]
    public ClockworkScenarioConfigurator SetBlueprintPlayerUnit(string value)
    {
      return OnConfigureInternal(bp => bp.BlueprintPlayerUnit = BlueprintTool.GetRef<BlueprintUnitReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.OverridePresetDifficulty"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetOverridePresetDifficulty(DifficultyPresetAsset value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.OverridePresetDifficulty = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.OnAreaEnterDelay"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetOnAreaEnterDelay(float value)
    {
      return OnConfigureInternal(bp => bp.OnAreaEnterDelay = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.AreaTimeout"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetAreaTimeout(float value)
    {
      return OnConfigureInternal(bp => bp.AreaTimeout = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.CutsceneTimeout"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetCutsceneTimeout(float value)
    {
      return OnConfigureInternal(bp => bp.CutsceneTimeout = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.TaskTimeout"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetTaskTimeout(float value)
    {
      return OnConfigureInternal(bp => bp.TaskTimeout = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.TaskMaxAttempts"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetTaskMaxAttempts(int value)
    {
      return OnConfigureInternal(bp => bp.TaskMaxAttempts = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.AreaGameOverLimit"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetAreaGameOverLimit(int value)
    {
      return OnConfigureInternal(bp => bp.AreaGameOverLimit = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.AutoLevelUp"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetAutoLevelUp(bool value)
    {
      return OnConfigureInternal(bp => bp.AutoLevelUp = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.AutoUseRest"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetAutoUseRest(bool value)
    {
      return OnConfigureInternal(bp => bp.AutoUseRest = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.CheaterCombat"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetCheaterCombat(bool value)
    {
      return OnConfigureInternal(bp => bp.CheaterCombat = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.CheaterTacticalCombat"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetCheaterTacticalCombat(bool value)
    {
      return OnConfigureInternal(bp => bp.CheaterTacticalCombat = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.SellTrashOnly"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetSellTrashOnly(bool value)
    {
      return OnConfigureInternal(bp => bp.SellTrashOnly = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.SaveLoadSmokeTest"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetSaveLoadSmokeTest(bool value)
    {
      return OnConfigureInternal(bp => bp.SaveLoadSmokeTest = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.UploadSavesToSavesStorage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetUploadSavesToSavesStorage(bool value)
    {
      return OnConfigureInternal(bp => bp.UploadSavesToSavesStorage = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.ScenarioParts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintClockworkScenarioPart"/></param>
    [Generated]
    public ClockworkScenarioConfigurator AddToScenarioParts(params string[] values)
    {
      return OnConfigureInternal(bp => bp.ScenarioParts.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintClockworkScenarioPartReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.ScenarioParts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintClockworkScenarioPart"/></param>
    [Generated]
    public ClockworkScenarioConfigurator RemoveFromScenarioParts(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintClockworkScenarioPartReference>(name));
            bp.ScenarioParts =
                bp.ScenarioParts
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.RetrySkillChecks"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator AddToRetrySkillChecks(params EntityReference[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.RetrySkillChecks.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.RetrySkillChecks"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator RemoveFromRetrySkillChecks(params EntityReference[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.RetrySkillChecks = bp.RetrySkillChecks.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.HighPriorityAnswers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAnswer"/></param>
    [Generated]
    public ClockworkScenarioConfigurator AddToHighPriorityAnswers(params string[] values)
    {
      return OnConfigureInternal(bp => bp.HighPriorityAnswers.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.HighPriorityAnswers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAnswer"/></param>
    [Generated]
    public ClockworkScenarioConfigurator RemoveFromHighPriorityAnswers(params string[] values)
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
    /// Modifies <see cref="BlueprintClockworkScenario.DoNotSellItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintItem"/></param>
    [Generated]
    public ClockworkScenarioConfigurator AddToDoNotSellItems(params string[] values)
    {
      return OnConfigureInternal(bp => bp.DoNotSellItems.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.DoNotSellItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintItem"/></param>
    [Generated]
    public ClockworkScenarioConfigurator RemoveFromDoNotSellItems(params string[] values)
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
    /// Modifies <see cref="BlueprintClockworkScenario.DoNotInterract"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator AddToDoNotInterract(params ClockworkEntityReference[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.DoNotInterract.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.DoNotInterract"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator RemoveFromDoNotInterract(params ClockworkEntityReference[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.DoNotInterract = bp.DoNotInterract.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.DoNotInterractUnits"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnit"/></param>
    [Generated]
    public ClockworkScenarioConfigurator AddToDoNotInterractUnits(params string[] values)
    {
      return OnConfigureInternal(bp => bp.DoNotInterractUnits.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.DoNotInterractUnits"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnit"/></param>
    [Generated]
    public ClockworkScenarioConfigurator RemoveFromDoNotInterractUnits(params string[] values)
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
    /// Modifies <see cref="BlueprintClockworkScenario.DoNotUseAnswer"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAnswer"/></param>
    [Generated]
    public ClockworkScenarioConfigurator AddToDoNotUseAnswer(params string[] values)
    {
      return OnConfigureInternal(bp => bp.DoNotUseAnswer.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.DoNotUseAnswer"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAnswer"/></param>
    [Generated]
    public ClockworkScenarioConfigurator RemoveFromDoNotUseAnswer(params string[] values)
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
    /// Modifies <see cref="BlueprintClockworkScenario.DoNotEnterAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintArea"/></param>
    [Generated]
    public ClockworkScenarioConfigurator AddToDoNotEnterAreas(params string[] values)
    {
      return OnConfigureInternal(bp => bp.DoNotEnterAreas.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.DoNotEnterAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintArea"/></param>
    [Generated]
    public ClockworkScenarioConfigurator RemoveFromDoNotEnterAreas(params string[] values)
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
    /// Sets <see cref="BlueprintClockworkScenario.m_AreaTests"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetAreaTests(Dictionary<BlueprintArea,List<AreaTest>> value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_AreaTests = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.m_ConditionalCommandLists"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator AddToConditionalCommandLists(params ConditionalCommandList[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_ConditionalCommandLists.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.m_ConditionalCommandLists"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator RemoveFromConditionalCommandLists(params ConditionalCommandList[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_ConditionalCommandLists = bp.m_ConditionalCommandLists.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.m_ComponentId"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetComponentId(Dictionary<string,int> value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_ComponentId = value);
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
