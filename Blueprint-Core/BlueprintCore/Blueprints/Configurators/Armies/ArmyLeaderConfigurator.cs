using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>Configurator for <see cref="BlueprintArmyLeader"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArmyLeader))]
  public class ArmyLeaderConfigurator : BaseBlueprintConfigurator<BlueprintArmyLeader, ArmyLeaderConfigurator>
  {
     private ArmyLeaderConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArmyLeaderConfigurator For(string name)
    {
      return new ArmyLeaderConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ArmyLeaderConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintArmyLeader>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArmyLeaderConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintArmyLeader>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmyLeader.m_LeaderName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyLeaderConfigurator SetLeaderName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_LeaderName = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmyLeader.m_Portrait"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintPortrait"/></param>
    [Generated]
    public ArmyLeaderConfigurator SetPortrait(string value)
    {
      return OnConfigureInternal(bp => bp.m_Portrait = BlueprintTool.GetRef<BlueprintPortraitReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmyLeader.m_StartingLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyLeaderConfigurator SetStartingLevel(int value)
    {
      return OnConfigureInternal(bp => bp.m_StartingLevel = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmyLeader.m_LeaderProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintLeaderProgression"/></param>
    [Generated]
    public ArmyLeaderConfigurator SetLeaderProgression(string value)
    {
      return OnConfigureInternal(bp => bp.m_LeaderProgression = BlueprintTool.GetRef<BlueprintLeaderProgression.Reference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmyLeader.m_Unit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintUnit"/></param>
    [Generated]
    public ArmyLeaderConfigurator SetUnit(string value)
    {
      return OnConfigureInternal(bp => bp.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(value));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmyLeader.m_baseSkills"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintLeaderSkill"/></param>
    [Generated]
    public ArmyLeaderConfigurator AddTobaseSkills(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_baseSkills = CommonTool.Append(bp.m_baseSkills, values.Select(name => BlueprintTool.GetRef<BlueprintLeaderSkillReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmyLeader.m_baseSkills"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintLeaderSkill"/></param>
    [Generated]
    public ArmyLeaderConfigurator RemoveFrombaseSkills(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintLeaderSkillReference>(name));
            bp.m_baseSkills =
                bp.m_baseSkills
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}
