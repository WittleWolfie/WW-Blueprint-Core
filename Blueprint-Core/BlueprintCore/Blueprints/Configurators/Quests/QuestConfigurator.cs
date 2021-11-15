using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Experience;
using Kingmaker.Blueprints.Quests;
using Kingmaker.Blueprints.Quests.Logic;
using Kingmaker.Blueprints.Quests.Logic.CrusadeQuests;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Localization;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Quests
{
  /// <summary>Configurator for <see cref="BlueprintQuest"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintQuest))]
  public class QuestConfigurator : BaseFactConfigurator<BlueprintQuest, QuestConfigurator>
  {
     private QuestConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static QuestConfigurator For(string name)
    {
      return new QuestConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static QuestConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintQuest>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static QuestConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintQuest>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuest.Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestConfigurator SetDescription(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Description = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuest.Title"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestConfigurator SetTitle(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Title = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuest.CompletionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestConfigurator SetCompletionText(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.CompletionText = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuest.m_Group"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestConfigurator SetGroup(QuestGroupId value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_Group = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuest.m_DescriptionPriority"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestConfigurator SetDescriptionPriority(int value)
    {
      return OnConfigureInternal(bp => bp.m_DescriptionPriority = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuest.m_Type"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestConfigurator SetType(QuestType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_Type = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuest.m_LastChapter"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestConfigurator SetLastChapter(int value)
    {
      return OnConfigureInternal(bp => bp.m_LastChapter = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuest.m_Objectives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintQuestObjective"/></param>
    [Generated]
    public QuestConfigurator AddToObjectives(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Objectives.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuest.m_Objectives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintQuestObjective"/></param>
    [Generated]
    public QuestConfigurator RemoveFromObjectives(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name));
            bp.m_Objectives =
                bp.m_Objectives
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Adds <see cref="QuestRelatesToCompanionStory"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Companion"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(QuestRelatesToCompanionStory))]
    public QuestConfigurator AddQuestRelatesToCompanionStory(
        string m_Companion)
    {
      
      var component =  new QuestRelatesToCompanionStory();
      component.m_Companion = BlueprintTool.GetRef<BlueprintUnitReference>(m_Companion);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CrusadeMissionComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CrusadeMissionComponent))]
    public QuestConfigurator AddCrusadeMissionComponent(
        int Chapter)
    {
      
      var component =  new CrusadeMissionComponent();
      component.Chapter = Chapter;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NobilityArmyRequestComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NobilityArmyRequestComponent))]
    public QuestConfigurator AddNobilityArmyRequestComponent()
    {
      return AddComponent(new NobilityArmyRequestComponent());
    }

    /// <summary>
    /// Adds <see cref="NobilityBuildingsRequestComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NobilityBuildingsRequestComponent))]
    public QuestConfigurator AddNobilityBuildingsRequestComponent()
    {
      return AddComponent(new NobilityBuildingsRequestComponent());
    }

    /// <summary>
    /// Adds <see cref="NobilityIncomeRequestComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NobilityIncomeRequestComponent))]
    public QuestConfigurator AddNobilityIncomeRequestComponent()
    {
      return AddComponent(new NobilityIncomeRequestComponent());
    }

    /// <summary>
    /// Adds <see cref="NobilitySettlementsRequestComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NobilitySettlementsRequestComponent))]
    public QuestConfigurator AddNobilitySettlementsRequestComponent()
    {
      return AddComponent(new NobilitySettlementsRequestComponent());
    }

    /// <summary>
    /// Adds <see cref="RoyalCourtLeaderRequestComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RoyalCourtLeaderRequestComponent))]
    public QuestConfigurator AddRoyalCourtLeaderRequestComponent()
    {
      return AddComponent(new RoyalCourtLeaderRequestComponent());
    }

    /// <summary>
    /// Adds <see cref="RoyalCourtMissionsRequestComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RoyalCourtMissionsRequestComponent))]
    public QuestConfigurator AddRoyalCourtMissionsRequestComponent()
    {
      return AddComponent(new RoyalCourtMissionsRequestComponent());
    }

    /// <summary>
    /// Adds <see cref="RoyalCourtRanksRequestComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RoyalCourtRanksRequestComponent))]
    public QuestConfigurator AddRoyalCourtRanksRequestComponent()
    {
      return AddComponent(new RoyalCourtRanksRequestComponent());
    }

    /// <summary>
    /// Adds <see cref="RoyalCourtVictoryRequestComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RoyalCourtVictoryRequestComponent))]
    public QuestConfigurator AddRoyalCourtVictoryRequestComponent()
    {
      return AddComponent(new RoyalCourtVictoryRequestComponent());
    }

    /// <summary>
    /// Adds <see cref="Experience"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Experience))]
    public QuestConfigurator AddExperience(
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
  }
}
