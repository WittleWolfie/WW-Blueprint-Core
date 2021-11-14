using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Experience;
using Kingmaker.Blueprints.Quests;
using Kingmaker.Blueprints.Quests.Logic;
using Kingmaker.Blueprints.Quests.Logic.CrusadeQuests;
using Kingmaker.ElementsSystem;

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
