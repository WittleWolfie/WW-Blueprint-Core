//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
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

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<StatConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Stat = copyFrom.Stat;
          bp.Value = copyFrom.Value;
          bp.GreaterThanValue = copyFrom.GreaterThanValue;
          bp.LesserThanValue = copyFrom.LesserThanValue;
        });
    }

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
  }
}
