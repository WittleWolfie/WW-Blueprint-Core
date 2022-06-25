//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Localization;
using System;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintKingdomEventBase"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseKingdomEventBaseConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintKingdomEventBase
    where TBuilder : BaseKingdomEventBaseConfigurator<T, TBuilder>
  {
    protected BaseKingdomEventBaseConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEventBase.InfoType"/>
    /// </summary>
    public TBuilder SetInfoType(KingomEventInfoType infoType)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.InfoType = infoType;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomEventBase.InfoType"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyInfoType(Action<KingomEventInfoType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.InfoType);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEventBase.LocalizedName"/>
    /// </summary>
    ///
    /// <param name="localizedName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetLocalizedName(LocalString localizedName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LocalizedName = localizedName?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomEventBase.LocalizedName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLocalizedName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LocalizedName is null) { return; }
          action.Invoke(bp.LocalizedName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEventBase.LocalizedDescription"/>
    /// </summary>
    ///
    /// <param name="localizedDescription">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetLocalizedDescription(LocalString localizedDescription)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LocalizedDescription = localizedDescription?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomEventBase.LocalizedDescription"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLocalizedDescription(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LocalizedDescription is null) { return; }
          action.Invoke(bp.LocalizedDescription);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEventBase.TriggerCondition"/>
    /// </summary>
    public TBuilder SetTriggerCondition(ConditionsBuilder triggerCondition)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TriggerCondition = triggerCondition?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomEventBase.TriggerCondition"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTriggerCondition(Action<ConditionsChecker> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.TriggerCondition is null) { return; }
          action.Invoke(bp.TriggerCondition);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEventBase.ResolutionTime"/>
    /// </summary>
    public TBuilder SetResolutionTime(int resolutionTime)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ResolutionTime = resolutionTime;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomEventBase.ResolutionTime"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyResolutionTime(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ResolutionTime);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEventBase.ResolveAutomatically"/>
    /// </summary>
    public TBuilder SetResolveAutomatically(bool resolveAutomatically = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ResolveAutomatically = resolveAutomatically;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomEventBase.ResolveAutomatically"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyResolveAutomatically(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ResolveAutomatically);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEventBase.NeedToVisitTheThroneRoom"/>
    /// </summary>
    public TBuilder SetNeedToVisitTheThroneRoom(bool needToVisitTheThroneRoom = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NeedToVisitTheThroneRoom = needToVisitTheThroneRoom;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomEventBase.NeedToVisitTheThroneRoom"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNeedToVisitTheThroneRoom(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.NeedToVisitTheThroneRoom);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEventBase.AICanCheat"/>
    /// </summary>
    public TBuilder SetAICanCheat(bool aICanCheat = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AICanCheat = aICanCheat;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomEventBase.AICanCheat"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAICanCheat(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AICanCheat);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEventBase.SkipRoll"/>
    /// </summary>
    public TBuilder SetSkipRoll(bool skipRoll = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SkipRoll = skipRoll;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomEventBase.SkipRoll"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySkipRoll(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.SkipRoll);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEventBase.ResolutionDC"/>
    /// </summary>
    public TBuilder SetResolutionDC(int resolutionDC)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ResolutionDC = resolutionDC;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomEventBase.ResolutionDC"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyResolutionDC(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ResolutionDC);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEventBase.AutoResolveResult"/>
    /// </summary>
    public TBuilder SetAutoResolveResult(EventResult.MarginType autoResolveResult)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AutoResolveResult = autoResolveResult;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomEventBase.AutoResolveResult"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAutoResolveResult(Action<EventResult.MarginType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AutoResolveResult);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEventBase.Solutions"/>
    /// </summary>
    public TBuilder SetSolutions(PossibleEventSolutions solutions)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(solutions);
          bp.Solutions = solutions;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomEventBase.Solutions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySolutions(Action<PossibleEventSolutions> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Solutions is null) { return; }
          action.Invoke(bp.Solutions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEventBase.DefaultResolutionType"/>
    /// </summary>
    public TBuilder SetDefaultResolutionType(LeaderType defaultResolutionType)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DefaultResolutionType = defaultResolutionType;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomEventBase.DefaultResolutionType"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDefaultResolutionType(Action<LeaderType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.DefaultResolutionType);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEventBase.DefaultResolutionDescription"/>
    /// </summary>
    ///
    /// <param name="defaultResolutionDescription">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetDefaultResolutionDescription(LocalString defaultResolutionDescription)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DefaultResolutionDescription = defaultResolutionDescription?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomEventBase.DefaultResolutionDescription"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDefaultResolutionDescription(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DefaultResolutionDescription is null) { return; }
          action.Invoke(bp.DefaultResolutionDescription);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEventBase.AIStopping"/>
    /// </summary>
    ///
    /// <param name="aIStopping">
    /// <para>
    /// Tooltip: If true, this event would stop AI when it is resolved, or its recurrence ticks
    /// </para>
    /// </param>
    public TBuilder SetAIStopping(bool aIStopping = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AIStopping = aIStopping;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomEventBase.AIStopping"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAIStopping(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AIStopping);
        });
    }

    /// <summary>
    /// Adds <see cref="EventFinalResults"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonQ10_StartKTC</term><description>9b7fdf9a6d722d942879c7922daa507f</description></item>
    /// <item><term>KTC_ElyankaComing</term><description>b631d3337a4d5134f8f1f163c6d9f59a</description></item>
    /// <item><term>WenduagKTC_WenduagComeNeathholm</term><description>b0281d9068d670845927a1827be6e7bb</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddEventFinalResults(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        EventResult[]? results = null)
    {
      var component = new EventFinalResults();
      Validate(results);
      component.Results = results ?? component.Results;
      if (component.Results is null)
      {
        component.Results = new EventResult[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.LocalizedName is null)
      {
        Blueprint.LocalizedName = Utils.Constants.Empty.String;
      }
      if (Blueprint.LocalizedDescription is null)
      {
        Blueprint.LocalizedDescription = Utils.Constants.Empty.String;
      }
      if (Blueprint.TriggerCondition is null)
      {
        Blueprint.TriggerCondition = Utils.Constants.Empty.Conditions;
      }
      if (Blueprint.DefaultResolutionDescription is null)
      {
        Blueprint.DefaultResolutionDescription = Utils.Constants.Empty.String;
      }
    }
  }
}
