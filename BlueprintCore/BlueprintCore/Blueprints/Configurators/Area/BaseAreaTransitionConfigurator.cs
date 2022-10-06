//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAreaTransition"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAreaTransitionConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintAreaTransition
    where TBuilder : BaseAreaTransitionConfigurator<T, TBuilder>
  {
    protected BaseAreaTransitionConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintAreaTransition>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Actions = copyFrom.m_Actions;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintAreaTransition>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Actions = copyFrom.m_Actions;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaTransition.m_Actions"/>
    /// </summary>
    public TBuilder SetActions(params ConditionAction[] actions)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(actions);
          bp.m_Actions = actions;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAreaTransition.m_Actions"/>
    /// </summary>
    public TBuilder AddToActions(params ConditionAction[] actions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Actions = bp.m_Actions ?? new ConditionAction[0];
          bp.m_Actions = CommonTool.Append(bp.m_Actions, actions);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaTransition.m_Actions"/>
    /// </summary>
    public TBuilder RemoveFromActions(params ConditionAction[] actions)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Actions is null) { return; }
          bp.m_Actions = bp.m_Actions.Where(val => !actions.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaTransition.m_Actions"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromActions(Func<ConditionAction, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Actions is null) { return; }
          bp.m_Actions = bp.m_Actions.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAreaTransition.m_Actions"/>
    /// </summary>
    public TBuilder ClearActions()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Actions = new ConditionAction[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaTransition.m_Actions"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyActions(Action<ConditionAction> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Actions is null) { return; }
          bp.m_Actions.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Actions is null)
      {
        Blueprint.m_Actions = new ConditionAction[0];
      }
    }
  }
}
