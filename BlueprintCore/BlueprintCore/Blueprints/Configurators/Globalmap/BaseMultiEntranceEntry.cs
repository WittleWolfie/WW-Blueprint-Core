//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Localization;
using System;

namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintMultiEntranceEntry"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseMultiEntranceEntryConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintMultiEntranceEntry
    where TBuilder : BaseMultiEntranceEntryConfigurator<T, TBuilder>
  {
    protected BaseMultiEntranceEntryConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintMultiEntranceEntry.Name"/>
    /// </summary>
    public TBuilder SetName(LocalizedString name)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Name = name;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintMultiEntranceEntry.Name"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Name is null) { return; }
          action.Invoke(bp.Name);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintMultiEntranceEntry.m_Condition"/>
    /// </summary>
    public TBuilder SetCondition(ConditionsBuilder condition)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Condition = condition?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintMultiEntranceEntry.m_Condition"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCondition(Action<ConditionsChecker> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Condition is null) { return; }
          action.Invoke(bp.m_Condition);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintMultiEntranceEntry.m_Actions"/>
    /// </summary>
    public TBuilder SetActions(ActionsBuilder actions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Actions = actions?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintMultiEntranceEntry.m_Actions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyActions(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Actions is null) { return; }
          action.Invoke(bp.m_Actions);
        });
    }

    protected override void SetDefaults()
    {
      base.SetDefaults();
    
      if (Blueprint.Name is null)
      {
        Blueprint.Name = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_Condition is null)
      {
        Blueprint.m_Condition = Utils.Constants.Empty.Conditions;
      }
      if (Blueprint.m_Actions is null)
      {
        Blueprint.m_Actions = Utils.Constants.Empty.Actions;
      }
    }
  }
}
