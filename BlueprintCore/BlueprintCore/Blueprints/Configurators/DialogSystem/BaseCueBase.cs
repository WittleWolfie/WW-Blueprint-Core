//***** AUTO-GENERATED - DO NOT EDIT *****//

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
    /// Modifies <see cref="BlueprintCueBase.ShowOnce"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyShowOnce(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ShowOnce);
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
    /// Modifies <see cref="BlueprintCueBase.ShowOnceCurrentDialog"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyShowOnceCurrentDialog(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ShowOnceCurrentDialog);
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
          if (bp.Conditions is null)
          {
            bp.Conditions = Utils.Constants.Empty.Conditions;
          }
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
  }
}
