using BlueprintCore.Blueprints.Configurators.Kingdom;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;
using System;
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
