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
    protected BaseMultiEntranceEntryConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintMultiEntranceEntry.Name"/>
    /// </summary>
    public TBuilder SetName(LocalizedString name)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Name = name;
          if (bp.Name is null)
          {
            bp.Name = Utils.Constants.Empty.String;
          }
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
          if (bp.m_Condition is null)
          {
            bp.m_Condition = Utils.Constants.Empty.Conditions;
          }
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
          if (bp.m_Actions is null)
          {
            bp.m_Actions = Utils.Constants.Empty.Actions;
          }
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
  }
}
