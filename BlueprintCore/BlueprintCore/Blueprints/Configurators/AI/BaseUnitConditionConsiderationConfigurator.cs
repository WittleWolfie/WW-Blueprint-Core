//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
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
  /// Implements common fields and components for blueprints inheriting from <see cref="UnitConditionConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseUnitConditionConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : UnitConditionConsideration
    where TBuilder : BaseUnitConditionConsiderationConfigurator<T, TBuilder>
  {
    protected BaseUnitConditionConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<UnitConditionConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Conditions = copyFrom.Conditions;
          bp.HasCondition = copyFrom.HasCondition;
          bp.NoCondition = copyFrom.NoCondition;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<UnitConditionConsideration>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Conditions = copyFrom.Conditions;
          bp.HasCondition = copyFrom.HasCondition;
          bp.NoCondition = copyFrom.NoCondition;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitConditionConsideration.Conditions"/>
    /// </summary>
    public TBuilder SetConditions(params UnitCondition[] conditions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Conditions = conditions;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="UnitConditionConsideration.Conditions"/>
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
    /// Removes elements from <see cref="UnitConditionConsideration.Conditions"/>
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
    /// Removes elements from <see cref="UnitConditionConsideration.Conditions"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromConditions(Func<UnitCondition, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Conditions is null) { return; }
          bp.Conditions = bp.Conditions.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="UnitConditionConsideration.Conditions"/>
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
    /// Modifies <see cref="UnitConditionConsideration.Conditions"/> by invoking the provided action on each element.
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
    /// Sets the value of <see cref="UnitConditionConsideration.HasCondition"/>
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
    /// Sets the value of <see cref="UnitConditionConsideration.NoCondition"/>
    /// </summary>
    public TBuilder SetNoCondition(float noCondition)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NoCondition = noCondition;
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Conditions is null)
      {
        Blueprint.Conditions = new UnitCondition[0];
      }
    }
  }
}
