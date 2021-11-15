using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Localization;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintKingdomProject"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomProject))]
  public abstract class BaseKingdomProjectConfigurator<T, TBuilder>
      : BaseKingdomEventBaseConfigurator<T, TBuilder>
      where T : BlueprintKingdomProject
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseKingdomProjectConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.ProjectType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetProjectType(KingdomProjectType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ProjectType = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.ProjectStartCost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetProjectStartCost(KingdomResourcesAmount value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ProjectStartCost = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.m_MechanicalDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetMechanicalDescription(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_MechanicalDescription = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.SpendRulerTimeDays"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetSpendRulerTimeDays(int value)
    {
      return OnConfigureInternal(bp => bp.SpendRulerTimeDays = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.Repeatable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetRepeatable(bool value)
    {
      return OnConfigureInternal(bp => bp.Repeatable = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.Cooldown"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCooldown(int value)
    {
      return OnConfigureInternal(bp => bp.Cooldown = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.IsRankUpProject"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIsRankUpProject(bool value)
    {
      return OnConfigureInternal(bp => bp.IsRankUpProject = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.RankupProjectFor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetRankupProjectFor(KingdomStats.Type value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.RankupProjectFor = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.AIPriority"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetAIPriority(int value)
    {
      return OnConfigureInternal(bp => bp.AIPriority = value);
    }

    /// <summary>
    /// Adds <see cref="EventItemCost"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Items"><see cref="BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(EventItemCost))]
    public TBuilder AddEventItemCost(
        string[] m_Items,
        int Amount)
    {
      
      var component =  new EventItemCost();
      component.m_Items = m_Items.Select(bp => BlueprintTool.GetRef<BlueprintItemReference>(bp)).ToArray();
      component.Amount = Amount;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ExclusiveProjects"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Projects"><see cref="BlueprintKingdomProject"/></param>
    [Generated]
    [Implements(typeof(ExclusiveProjects))]
    public TBuilder AddExclusiveProjects(
        string[] m_Projects)
    {
      
      var component =  new ExclusiveProjects();
      component.m_Projects = m_Projects.Select(bp => BlueprintTool.GetRef<BlueprintKingdomProjectReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FinishObjectiveOnTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Objective"><see cref="BlueprintQuestObjective"/></param>
    [Generated]
    [Implements(typeof(FinishObjectiveOnTrigger))]
    public TBuilder AddFinishObjectiveOnTrigger(
        string m_Objective)
    {
      
      var component =  new FinishObjectiveOnTrigger();
      component.m_Objective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(m_Objective);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MarkAsCrusadeProject"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MarkAsCrusadeProject))]
    public TBuilder AddMarkAsCrusadeProject()
    {
      return AddComponent(new MarkAsCrusadeProject());
    }
  }

  /// <summary>Configurator for <see cref="BlueprintKingdomProject"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomProject))]
  public class KingdomProjectConfigurator : BaseKingdomEventBaseConfigurator<BlueprintKingdomProject, KingdomProjectConfigurator>
  {
     private KingdomProjectConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomProjectConfigurator For(string name)
    {
      return new KingdomProjectConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static KingdomProjectConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintKingdomProject>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomProjectConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintKingdomProject>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.ProjectType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomProjectConfigurator SetProjectType(KingdomProjectType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ProjectType = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.ProjectStartCost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomProjectConfigurator SetProjectStartCost(KingdomResourcesAmount value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ProjectStartCost = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.m_MechanicalDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomProjectConfigurator SetMechanicalDescription(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_MechanicalDescription = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.SpendRulerTimeDays"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomProjectConfigurator SetSpendRulerTimeDays(int value)
    {
      return OnConfigureInternal(bp => bp.SpendRulerTimeDays = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.Repeatable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomProjectConfigurator SetRepeatable(bool value)
    {
      return OnConfigureInternal(bp => bp.Repeatable = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.Cooldown"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomProjectConfigurator SetCooldown(int value)
    {
      return OnConfigureInternal(bp => bp.Cooldown = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.IsRankUpProject"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomProjectConfigurator SetIsRankUpProject(bool value)
    {
      return OnConfigureInternal(bp => bp.IsRankUpProject = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.RankupProjectFor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomProjectConfigurator SetRankupProjectFor(KingdomStats.Type value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.RankupProjectFor = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.AIPriority"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomProjectConfigurator SetAIPriority(int value)
    {
      return OnConfigureInternal(bp => bp.AIPriority = value);
    }

    /// <summary>
    /// Adds <see cref="EventItemCost"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Items"><see cref="BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(EventItemCost))]
    public KingdomProjectConfigurator AddEventItemCost(
        string[] m_Items,
        int Amount)
    {
      
      var component =  new EventItemCost();
      component.m_Items = m_Items.Select(bp => BlueprintTool.GetRef<BlueprintItemReference>(bp)).ToArray();
      component.Amount = Amount;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ExclusiveProjects"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Projects"><see cref="BlueprintKingdomProject"/></param>
    [Generated]
    [Implements(typeof(ExclusiveProjects))]
    public KingdomProjectConfigurator AddExclusiveProjects(
        string[] m_Projects)
    {
      
      var component =  new ExclusiveProjects();
      component.m_Projects = m_Projects.Select(bp => BlueprintTool.GetRef<BlueprintKingdomProjectReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FinishObjectiveOnTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Objective"><see cref="BlueprintQuestObjective"/></param>
    [Generated]
    [Implements(typeof(FinishObjectiveOnTrigger))]
    public KingdomProjectConfigurator AddFinishObjectiveOnTrigger(
        string m_Objective)
    {
      
      var component =  new FinishObjectiveOnTrigger();
      component.m_Objective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(m_Objective);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MarkAsCrusadeProject"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MarkAsCrusadeProject))]
    public KingdomProjectConfigurator AddMarkAsCrusadeProject()
    {
      return AddComponent(new MarkAsCrusadeProject());
    }
  }
}
