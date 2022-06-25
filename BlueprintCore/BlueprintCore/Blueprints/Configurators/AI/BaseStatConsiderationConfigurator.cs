//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="StatConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseStatConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : StatConsideration
    where TBuilder : BaseStatConsiderationConfigurator<T, TBuilder>
  {
    protected BaseStatConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="StatConsideration.Stat"/>
    /// </summary>
    public TBuilder SetStat(StatType stat)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Stat = stat;
        });
    }

    /// <summary>
    /// Modifies <see cref="StatConsideration.Stat"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyStat(Action<StatType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Stat);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="StatConsideration.Value"/>
    /// </summary>
    public TBuilder SetValue(int value)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Value = value;
        });
    }

    /// <summary>
    /// Modifies <see cref="StatConsideration.Value"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyValue(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Value);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="StatConsideration.GreaterThanValue"/>
    /// </summary>
    public TBuilder SetGreaterThanValue(float greaterThanValue)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.GreaterThanValue = greaterThanValue;
        });
    }

    /// <summary>
    /// Modifies <see cref="StatConsideration.GreaterThanValue"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyGreaterThanValue(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.GreaterThanValue);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="StatConsideration.LesserThanValue"/>
    /// </summary>
    public TBuilder SetLesserThanValue(float lesserThanValue)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LesserThanValue = lesserThanValue;
        });
    }

    /// <summary>
    /// Modifies <see cref="StatConsideration.LesserThanValue"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLesserThanValue(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.LesserThanValue);
        });
    }
  }
}
