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
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Localization;
using System.Linq;

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
    /// Modifies <see cref="BlueprintQuestObjective.m_Addendums"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintQuestObjective"/></param>
    [Generated]
    public QuestObjectiveConfigurator AddToAddendums(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Addendums.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestObjective.m_Addendums"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintQuestObjective"/></param>
    [Generated]
    public QuestObjectiveConfigurator RemoveFromAddendums(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name));
            bp.m_Addendums =
                bp.m_Addendums
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestObjective.m_Areas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintArea"/></param>
    [Generated]
    public QuestObjectiveConfigurator AddToAreas(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Areas.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestObjective.m_Areas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintArea"/></param>
    [Generated]
    public QuestObjectiveConfigurator RemoveFromAreas(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name));
            bp.m_Areas =
                bp.m_Areas
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuestObjective.Title"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestObjectiveConfigurator SetTitle(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Title = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestObjective.Locations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintGlobalMapPoint"/></param>
    [Generated]
    public QuestObjectiveConfigurator AddToLocations(params string[] values)
    {
      return OnConfigureInternal(bp => bp.Locations.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestObjective.Locations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintGlobalMapPoint"/></param>
    [Generated]
    public QuestObjectiveConfigurator RemoveFromLocations(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(name));
            bp.Locations =
                bp.Locations
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestObjective.MultiEntranceEntries"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintMultiEntranceEntry"/></param>
    [Generated]
    public QuestObjectiveConfigurator AddToMultiEntranceEntries(params string[] values)
    {
      return OnConfigureInternal(bp => bp.MultiEntranceEntries.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintMultiEntranceEntry.Reference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestObjective.MultiEntranceEntries"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintMultiEntranceEntry"/></param>
    [Generated]
    public QuestObjectiveConfigurator RemoveFromMultiEntranceEntries(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintMultiEntranceEntry.Reference>(name));
            bp.MultiEntranceEntries =
                bp.MultiEntranceEntries
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuestObjective.Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestObjectiveConfigurator SetDescription(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Description = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuestObjective.AutoFailDays"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestObjectiveConfigurator SetAutoFailDays(int value)
    {
      return OnConfigureInternal(bp => bp.AutoFailDays = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuestObjective.IsFakeFail"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestObjectiveConfigurator SetIsFakeFail(bool value)
    {
      return OnConfigureInternal(bp => bp.IsFakeFail = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuestObjective.StartOnKingdomTime"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestObjectiveConfigurator SetStartOnKingdomTime(bool value)
    {
      return OnConfigureInternal(bp => bp.StartOnKingdomTime = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuestObjective.m_FinishParent"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestObjectiveConfigurator SetFinishParent(bool value)
    {
      return OnConfigureInternal(bp => bp.m_FinishParent = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuestObjective.m_Hidden"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestObjectiveConfigurator SetHidden(bool value)
    {
      return OnConfigureInternal(bp => bp.m_Hidden = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestObjective.m_NextObjectives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintQuestObjective"/></param>
    [Generated]
    public QuestObjectiveConfigurator AddToNextObjectives(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_NextObjectives.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestObjective.m_NextObjectives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintQuestObjective"/></param>
    [Generated]
    public QuestObjectiveConfigurator RemoveFromNextObjectives(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name));
            bp.m_NextObjectives =
                bp.m_NextObjectives
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuestObjective.m_Quest"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintQuest"/></param>
    [Generated]
    public QuestObjectiveConfigurator SetQuest(string value)
    {
      return OnConfigureInternal(bp => bp.m_Quest = BlueprintTool.GetRef<BlueprintQuestReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuestObjective.m_Type"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestObjectiveConfigurator SetType(BlueprintQuestObjective.Type value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_Type = value);
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
