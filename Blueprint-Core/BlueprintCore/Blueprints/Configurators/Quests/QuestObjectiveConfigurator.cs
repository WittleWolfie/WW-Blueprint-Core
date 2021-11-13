using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Quests;
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

  }
}
