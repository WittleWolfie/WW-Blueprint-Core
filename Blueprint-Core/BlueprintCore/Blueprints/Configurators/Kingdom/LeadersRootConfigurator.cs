using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Localization;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>Configurator for <see cref="LeadersRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(LeadersRoot))]
  public class LeadersRootConfigurator : BaseBlueprintConfigurator<LeadersRoot, LeadersRootConfigurator>
  {
     private LeadersRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static LeadersRootConfigurator For(string name)
    {
      return new LeadersRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static LeadersRootConfigurator New(string name)
    {
      BlueprintTool.Create<LeadersRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static LeadersRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<LeadersRoot>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.m_ExpTable"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintStatProgression"/></param>
    [Generated]
    public LeadersRootConfigurator SetExpTable(string value)
    {
      return OnConfigureInternal(bp => bp.m_ExpTable = BlueprintTool.GetRef<BlueprintStatProgressionReference>(value));
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.m_Leaders"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintArmyLeader"/></param>
    [Generated]
    public LeadersRootConfigurator AddToLeaders(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Leaders = CommonTool.Append(bp.m_Leaders, values.Select(name => BlueprintTool.GetRef<BlueprintArmyLeaderReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.m_Leaders"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintArmyLeader"/></param>
    [Generated]
    public LeadersRootConfigurator RemoveFromLeaders(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintArmyLeaderReference>(name));
            bp.m_Leaders =
                bp.m_Leaders
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.m_AttackLeaderFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintFeature"/></param>
    [Generated]
    public LeadersRootConfigurator SetAttackLeaderFeature(string value)
    {
      return OnConfigureInternal(bp => bp.m_AttackLeaderFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(value));
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.m_DeffenceLeaderFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintFeature"/></param>
    [Generated]
    public LeadersRootConfigurator SetDeffenceLeaderFeature(string value)
    {
      return OnConfigureInternal(bp => bp.m_DeffenceLeaderFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(value));
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.m_BaseManaRegen"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeadersRootConfigurator SetBaseManaRegen(int value)
    {
      return OnConfigureInternal(bp => bp.m_BaseManaRegen = value);
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.FirstLeadCost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeadersRootConfigurator SetFirstLeadCost(int value)
    {
      return OnConfigureInternal(bp => bp.FirstLeadCost = value);
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.ReducedLeadCost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeadersRootConfigurator SetReducedLeadCost(int value)
    {
      return OnConfigureInternal(bp => bp.ReducedLeadCost = value);
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.LeadCostMultiply"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeadersRootConfigurator SetLeadCostMultiply(float value)
    {
      return OnConfigureInternal(bp => bp.LeadCostMultiply = value);
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.m_ArmyLeaderAssignmentCooldownDays"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeadersRootConfigurator SetArmyLeaderAssignmentCooldownDays(int value)
    {
      return OnConfigureInternal(bp => bp.m_ArmyLeaderAssignmentCooldownDays = value);
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.m_CheaperLeadersProject"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintKingdomProject"/></param>
    [Generated]
    public LeadersRootConfigurator SetCheaperLeadersProject(string value)
    {
      return OnConfigureInternal(bp => bp.m_CheaperLeadersProject = BlueprintTool.GetRef<BlueprintKingdomProjectReference>(value));
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.m_TalentedLeadersProject"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintKingdomProject"/></param>
    [Generated]
    public LeadersRootConfigurator SetTalentedLeadersProject(string value)
    {
      return OnConfigureInternal(bp => bp.m_TalentedLeadersProject = BlueprintTool.GetRef<BlueprintKingdomProjectReference>(value));
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.m_ExperiencedLeadersProject"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintKingdomProject"/></param>
    [Generated]
    public LeadersRootConfigurator SetExperiencedLeadersProject(string value)
    {
      return OnConfigureInternal(bp => bp.m_ExperiencedLeadersProject = BlueprintTool.GetRef<BlueprintKingdomProjectReference>(value));
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.m_ExcellentLeadersProject"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintKingdomProject"/></param>
    [Generated]
    public LeadersRootConfigurator SetExcellentLeadersProject(string value)
    {
      return OnConfigureInternal(bp => bp.m_ExcellentLeadersProject = BlueprintTool.GetRef<BlueprintKingdomProjectReference>(value));
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.SkillsListName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeadersRootConfigurator SetSkillsListName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.SkillsListName = value);
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.ManaName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeadersRootConfigurator SetManaName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ManaName = value);
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.AttackBonusName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeadersRootConfigurator SetAttackBonusName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.AttackBonusName = value);
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.DeffBonusName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeadersRootConfigurator SetDeffBonusName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.DeffBonusName = value);
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.SpellStrengthName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeadersRootConfigurator SetSpellStrengthName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.SpellStrengthName = value);
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.LeaderHireText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeadersRootConfigurator SetLeaderHireText(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.LeaderHireText = value);
    }
  }
}
