//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;
using System;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCueBase"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCueBaseConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintCueBase
    where TBuilder : BaseCueBaseConfigurator<T, TBuilder>
  {
    protected BaseCueBaseConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintCueBase>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.ShowOnce = copyFrom.ShowOnce;
          bp.ShowOnceCurrentDialog = copyFrom.ShowOnceCurrentDialog;
          bp.Conditions = copyFrom.Conditions;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintCueBase>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.ShowOnce = copyFrom.ShowOnce;
          bp.ShowOnceCurrentDialog = copyFrom.ShowOnceCurrentDialog;
          bp.Conditions = copyFrom.Conditions;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCueBase.ShowOnce"/>
    /// </summary>
    public TBuilder SetShowOnce(bool showOnce = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ShowOnce = showOnce;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCueBase.ShowOnceCurrentDialog"/>
    /// </summary>
    public TBuilder SetShowOnceCurrentDialog(bool showOnceCurrentDialog = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ShowOnceCurrentDialog = showOnceCurrentDialog;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCueBase.Conditions"/>
    /// </summary>
    public TBuilder SetConditions(ConditionsBuilder conditions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Conditions = conditions?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCueBase.Conditions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyConditions(Action<ConditionsChecker> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Conditions is null) { return; }
          action.Invoke(bp.Conditions);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Conditions is null)
      {
        Blueprint.Conditions = Utils.Constants.Empty.Conditions;
      }
    }
  }
}
