using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Blueprints;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>Configurator for <see cref="BlueprintLeaderSkillsList"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintLeaderSkillsList))]
  public class LeaderSkillsListConfigurator : BaseBlueprintConfigurator<BlueprintLeaderSkillsList, LeaderSkillsListConfigurator>
  {
     private LeaderSkillsListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static LeaderSkillsListConfigurator For(string name)
    {
      return new LeaderSkillsListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static LeaderSkillsListConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintLeaderSkillsList>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static LeaderSkillsListConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintLeaderSkillsList>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintLeaderSkillsList.m_Skills"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintLeaderSkill"/></param>
    [Generated]
    public LeaderSkillsListConfigurator AddToSkills(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Skills = CommonTool.Append(bp.m_Skills, values.Select(name => BlueprintTool.GetRef<BlueprintLeaderSkillReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintLeaderSkillsList.m_Skills"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintLeaderSkill"/></param>
    [Generated]
    public LeaderSkillsListConfigurator RemoveFromSkills(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintLeaderSkillReference>(name));
            bp.m_Skills =
                bp.m_Skills
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}
