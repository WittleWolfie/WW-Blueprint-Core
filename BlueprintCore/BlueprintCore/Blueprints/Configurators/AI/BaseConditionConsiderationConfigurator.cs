//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
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
    protected BaseConditionConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<ConditionConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Condition = copyFrom.Condition;
          bp.ConditionTrueScore = copyFrom.ConditionTrueScore;
          bp.ConditionFlaseScore = copyFrom.ConditionFlaseScore;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<ConditionConsideration>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Condition = copyFrom.Condition;
          bp.ConditionTrueScore = copyFrom.ConditionTrueScore;
          bp.ConditionFlaseScore = copyFrom.ConditionFlaseScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ConditionConsideration.Condition"/>
    /// </summary>
    public TBuilder SetCondition(ConditionsBuilder condition)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Condition = condition?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="ConditionConsideration.Condition"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCondition(Action<ConditionsChecker> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Condition is null) { return; }
          action.Invoke(bp.Condition);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ConditionConsideration.ConditionTrueScore"/>
    /// </summary>
    public TBuilder SetConditionTrueScore(float conditionTrueScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ConditionTrueScore = conditionTrueScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ConditionConsideration.ConditionFlaseScore"/>
    /// </summary>
    public TBuilder SetConditionFlaseScore(float conditionFlaseScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ConditionFlaseScore = conditionFlaseScore;
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Condition is null)
      {
        Blueprint.Condition = Utils.Constants.Empty.Conditions;
      }
    }
  }
}
