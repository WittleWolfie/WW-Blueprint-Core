//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.ElementsSystem;
using System;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintScriptZone"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseScriptZoneConfigurator<T, TBuilder>
    : BaseMapObjectConfigurator<T, TBuilder>
    where T : BlueprintScriptZone
    where TBuilder : BaseScriptZoneConfigurator<T, TBuilder>
  {
    protected BaseScriptZoneConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintScriptZone.TriggerConditions"/>
    /// </summary>
    public TBuilder SetTriggerConditions(ConditionsBuilder triggerConditions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TriggerConditions = triggerConditions?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintScriptZone.TriggerConditions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTriggerConditions(Action<ConditionsChecker> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.TriggerConditions is null) { return; }
          action.Invoke(bp.TriggerConditions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintScriptZone.EnterActions"/>
    /// </summary>
    public TBuilder SetEnterActions(ActionsBuilder enterActions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.EnterActions = enterActions?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintScriptZone.EnterActions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyEnterActions(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.EnterActions is null) { return; }
          action.Invoke(bp.EnterActions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintScriptZone.ExitActions"/>
    /// </summary>
    public TBuilder SetExitActions(ActionsBuilder exitActions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ExitActions = exitActions?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintScriptZone.ExitActions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyExitActions(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ExitActions is null) { return; }
          action.Invoke(bp.ExitActions);
        });
    }

    protected override void SetDefaults()
    {
      base.SetDefaults();
    
      if (Blueprint.TriggerConditions is null)
      {
        Blueprint.TriggerConditions = Utils.Constants.Empty.Conditions;
      }
      if (Blueprint.EnterActions is null)
      {
        Blueprint.EnterActions = Utils.Constants.Empty.Actions;
      }
      if (Blueprint.ExitActions is null)
      {
        Blueprint.ExitActions = Utils.Constants.Empty.Actions;
      }
    }
  }
}
