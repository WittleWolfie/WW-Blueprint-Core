using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Blueprints;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintKingdomEventBase"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomEventBase))]
  public abstract class BaseKingdomEventBaseConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintKingdomEventBase
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseKingdomEventBaseConfigurator(string name) : base(name) { }

    /// <summary>
    /// Adds <see cref="EventDynamicCostFeast"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Blueprint"><see cref="BlueprintKingdomEventBase"/></param>
    [Generated]
    [Implements(typeof(global::EventDynamicCostFeast))]
    public TBuilder AddEventDynamicCostFeast(
        string m_Blueprint,
        KingdomResourcesAmount CostPerUse)
    {
      ValidateParam(CostPerUse);
      
      var component =  new global::EventDynamicCostFeast();
      component.m_Blueprint = BlueprintTool.GetRef<BlueprintKingdomEventBaseReference>(m_Blueprint);
      component.CostPerUse = CostPerUse;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EventAISolution"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Dialog"><see cref="BlueprintDialog"/></param>
    /// <param name="m_Answers"><see cref="BlueprintAnswer"/></param>
    [Generated]
    [Implements(typeof(EventAISolution))]
    public TBuilder AddEventAISolution(
        ConditionsBuilder Condition,
        string m_Dialog,
        string[] m_Answers,
        ActionsBuilder AdditionalActions)
    {
      
      var component =  new EventAISolution();
      component.Condition = Condition.Build();
      component.m_Dialog = BlueprintTool.GetRef<BlueprintDialogReference>(m_Dialog);
      component.m_Answers = m_Answers.Select(bp => BlueprintTool.GetRef<BlueprintAnswerReference>(bp)).ToArray();
      component.AdditionalActions = AdditionalActions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EventFinalResults"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EventFinalResults))]
    public TBuilder AddEventFinalResults(
        EventResult[] Results)
    {
      foreach (var item in Results)
      {
        ValidateParam(item);
      }
      
      var component =  new EventFinalResults();
      component.Results = Results;
      return AddComponent(component);
    }
  }
}
