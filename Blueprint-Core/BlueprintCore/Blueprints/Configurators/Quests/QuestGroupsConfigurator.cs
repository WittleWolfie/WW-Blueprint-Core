using BlueprintCore.Utils;
using Kingmaker.Blueprints.Quests;

namespace BlueprintCore.Blueprints.Configurators.Quests
{
  /// <summary>Configurator for <see cref="BlueprintQuestGroups"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintQuestGroups))]
  public class QuestGroupsConfigurator : BaseBlueprintConfigurator<BlueprintQuestGroups, QuestGroupsConfigurator>
  {
     private QuestGroupsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static QuestGroupsConfigurator For(string name)
    {
      return new QuestGroupsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static QuestGroupsConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintQuestGroups>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static QuestGroupsConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintQuestGroups>(name, assetId);
      return For(name);
    }
  }
}
