using BlueprintCore.Utils;
using Kingmaker.Blueprints.Quests;
using System.Linq;

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

    /// <summary>
    /// Modifies <see cref="BlueprintQuestGroups.Groups"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestGroupsConfigurator AddToGroups(params QuestGroup[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Groups = CommonTool.Append(bp.Groups, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestGroups.Groups"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestGroupsConfigurator RemoveFromGroups(params QuestGroup[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Groups = bp.Groups.Where(item => !values.Contains(item)).ToArray());
    }
  }
}
