using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Quests;
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

  }
}
