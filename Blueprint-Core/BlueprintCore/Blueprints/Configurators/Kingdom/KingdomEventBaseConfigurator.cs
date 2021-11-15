using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Localization;
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
    /// Sets <see cref="BlueprintKingdomEventBase.InfoType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetInfoType(KingomEventInfoType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.InfoType = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.LocalizedName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetLocalizedName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.LocalizedName = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.LocalizedDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetLocalizedDescription(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.LocalizedDescription = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.TriggerCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetTriggerCondition(ConditionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.TriggerCondition = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.ResolutionTime"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetResolutionTime(int value)
    {
      return OnConfigureInternal(bp => bp.ResolutionTime = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.ResolveAutomatically"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetResolveAutomatically(bool value)
    {
      return OnConfigureInternal(bp => bp.ResolveAutomatically = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.NeedToVisitTheThroneRoom"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetNeedToVisitTheThroneRoom(bool value)
    {
      return OnConfigureInternal(bp => bp.NeedToVisitTheThroneRoom = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.AICanCheat"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetAICanCheat(bool value)
    {
      return OnConfigureInternal(bp => bp.AICanCheat = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.SkipRoll"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetSkipRoll(bool value)
    {
      return OnConfigureInternal(bp => bp.SkipRoll = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.ResolutionDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetResolutionDC(int value)
    {
      return OnConfigureInternal(bp => bp.ResolutionDC = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.AutoResolveResult"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetAutoResolveResult(EventResult.MarginType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.AutoResolveResult = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.Solutions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetSolutions(PossibleEventSolutions value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Solutions = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.DefaultResolutionType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDefaultResolutionType(LeaderType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.DefaultResolutionType = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.DefaultResolutionDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDefaultResolutionDescription(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.DefaultResolutionDescription = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.AIStopping"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetAIStopping(bool value)
    {
      return OnConfigureInternal(bp => bp.AIStopping = value);
    }

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
