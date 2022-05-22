//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDialogExperienceModifierTable"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDialogExperienceModifierTableConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintDialogExperienceModifierTable
    where TBuilder : BaseDialogExperienceModifierTableConfigurator<T, TBuilder>
  {
    protected BaseDialogExperienceModifierTableConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDialogExperienceModifierTable.MultiplierLow"/>
    /// </summary>
    public TBuilder SetMultiplierLow(float multiplierLow)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MultiplierLow = multiplierLow;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDialogExperienceModifierTable.MultiplierLow"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMultiplierLow(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MultiplierLow);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDialogExperienceModifierTable.MultiplierNormal"/>
    /// </summary>
    public TBuilder SetMultiplierNormal(float multiplierNormal)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MultiplierNormal = multiplierNormal;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDialogExperienceModifierTable.MultiplierNormal"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMultiplierNormal(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MultiplierNormal);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDialogExperienceModifierTable.MultiplierHigh"/>
    /// </summary>
    public TBuilder SetMultiplierHigh(float multiplierHigh)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MultiplierHigh = multiplierHigh;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDialogExperienceModifierTable.MultiplierHigh"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMultiplierHigh(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MultiplierHigh);
        });
    }
  }
}
