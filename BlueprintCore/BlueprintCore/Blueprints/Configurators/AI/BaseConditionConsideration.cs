//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="ConditionConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseConditionConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : ConditionConsideration
    where TBuilder : BaseConditionConsiderationConfigurator<T, TBuilder>
  {
    protected BaseConditionConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="ConditionConsideration.Conditions"/>
    /// </summary>
    public TBuilder SetConditions(UnitCondition[] conditions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Conditions = conditions;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="ConditionConsideration.Conditions"/>
    /// </summary>
    public TBuilder AddToConditions(params UnitCondition[] conditions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Conditions = bp.Conditions ?? new UnitCondition[0];
          bp.Conditions = CommonTool.Append(bp.Conditions, conditions);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="ConditionConsideration.Conditions"/>
    /// </summary>
    public TBuilder RemoveFromConditions(params UnitCondition[] conditions)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Conditions is null) { return; }
          bp.Conditions = bp.Conditions.Where(val => !conditions.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="ConditionConsideration.Conditions"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromConditions(Func<UnitCondition, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Conditions is null) { return; }
          bp.Conditions = bp.Conditions.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="ConditionConsideration.Conditions"/>
    /// </summary>
    public TBuilder ClearConditions()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Conditions = new UnitCondition[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="ConditionConsideration.Conditions"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyConditions(Action<UnitCondition> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Conditions is null) { return; }
          bp.Conditions.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ConditionConsideration.HasCondition"/>
    /// </summary>
    public TBuilder SetHasCondition(float hasCondition)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasCondition = hasCondition;
        });
    }

    /// <summary>
    /// Modifies <see cref="ConditionConsideration.HasCondition"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHasCondition(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.HasCondition);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ConditionConsideration.NoCondition"/>
    /// </summary>
    public TBuilder SetNoCondition(float noCondition)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NoCondition = noCondition;
        });
    }

    /// <summary>
    /// Modifies <see cref="ConditionConsideration.NoCondition"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNoCondition(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.NoCondition);
        });
    }
  }
}
