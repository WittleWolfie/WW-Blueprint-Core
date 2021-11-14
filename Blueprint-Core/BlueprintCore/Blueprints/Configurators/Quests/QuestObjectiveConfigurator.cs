using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.QuestSystem;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Experience;
using Kingmaker.Blueprints.Quests;
using Kingmaker.Blueprints.Quests.Logic;
using Kingmaker.Designers.EventConditionActionSystem.ObjectiveEvents;
using Kingmaker.Designers.Quests.Common;
using Kingmaker.ElementsSystem;
using System;

namespace BlueprintCore.Blueprints.Configurators.Quests
{
  /// <summary>Configurator for <see cref="BlueprintQuestObjective"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintQuestObjective))]
  public class QuestObjectiveConfigurator : BaseFactConfigurator<BlueprintQuestObjective, QuestObjectiveConfigurator>
  {
     private QuestObjectiveConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static QuestObjectiveConfigurator For(string name)
    {
      return new QuestObjectiveConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static QuestObjectiveConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintQuestObjective>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static QuestObjectiveConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintQuestObjective>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="QuestObjectiveCallback"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(QuestObjectiveCallback))]
    public QuestObjectiveConfigurator AddQuestObjectiveCallback(
        ActionsBuilder m_OnComplete,
        ActionsBuilder m_OnFail)
    {
      
      var component =  new QuestObjectiveCallback();
      component.m_OnComplete = m_OnComplete.Build();
      component.m_OnFail = m_OnFail.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TimedObjectiveTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TimedObjectiveTrigger))]
    public QuestObjectiveConfigurator AddTimedObjectiveTrigger(
        int DaysTillTrigger,
        ActionsBuilder Action)
    {
      
      var component =  new TimedObjectiveTrigger();
      component.DaysTillTrigger = DaysTillTrigger;
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Experience"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Experience))]
    public QuestObjectiveConfigurator AddExperience(
        EncounterType Encounter,
        int CR,
        float Modifier,
        IntEvaluator Count,
        bool Dummy)
    {
      ValidateParam(Encounter);
      ValidateParam(Count);
      
      var component =  new Experience();
      component.Encounter = Encounter;
      component.CR = CR;
      component.Modifier = Modifier;
      component.Count = Count;
      component.Dummy = Dummy;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeObjectiveOnUnlockTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_targetObjective"><see cref="BlueprintQuestObjective"/></param>
    /// <param name="m_unlock"><see cref="BlueprintUnlockableFlag"/></param>
    [Generated]
    [Implements(typeof(ChangeObjectiveOnUnlockTrigger))]
    public QuestObjectiveConfigurator AddChangeObjectiveOnUnlockTrigger(
        bool checkUnlockStatusOnStart,
        ChangeObjectiveOnUnlockTrigger.ObjectiveStatus setStatus,
        string m_targetObjective,
        string m_unlock,
        ChangeObjectiveOnUnlockTrigger.UnlockStatus unlockStatus)
    {
      ValidateParam(setStatus);
      ValidateParam(unlockStatus);
      
      var component =  new ChangeObjectiveOnUnlockTrigger();
      component.checkUnlockStatusOnStart = checkUnlockStatusOnStart;
      component.setStatus = setStatus;
      component.m_targetObjective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(m_targetObjective);
      component.m_unlock = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(m_unlock);
      component.unlockStatus = unlockStatus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="GiveUnlockOnObjectiveTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_unlock"><see cref="BlueprintUnlockableFlag"/></param>
    [Generated]
    [Implements(typeof(GiveUnlockOnObjectiveTrigger))]
    public QuestObjectiveConfigurator AddGiveUnlockOnObjectiveTrigger(
        QuestObjectiveState objectiveState,
        string m_unlock)
    {
      ValidateParam(objectiveState);
      
      var component =  new GiveUnlockOnObjectiveTrigger();
      component.objectiveState = objectiveState;
      component.m_unlock = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(m_unlock);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SummonPoolCountTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_summonPool"><see cref="BlueprintSummonPool"/></param>
    [Generated]
    [Implements(typeof(SummonPoolCountTrigger))]
    public QuestObjectiveConfigurator AddSummonPoolCountTrigger(
        int count,
        SummonPoolCountTrigger.ObjectiveStatus setStatus,
        string m_summonPool)
    {
      ValidateParam(setStatus);
      
      var component =  new SummonPoolCountTrigger();
      component.count = count;
      component.setStatus = setStatus;
      component.m_summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(m_summonPool);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ObjectiveStatusTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ObjectiveStatusTrigger))]
    public QuestObjectiveConfigurator AddObjectiveStatusTrigger(
        QuestObjectiveState objectiveState,
        ConditionsBuilder Conditions,
        ActionsBuilder Actions)
    {
      ValidateParam(objectiveState);
      
      var component =  new ObjectiveStatusTrigger();
      component.objectiveState = objectiveState;
      component.Conditions = Conditions.Build();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }
  }
}
