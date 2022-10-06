//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
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

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintDialogExperienceModifierTable>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.MultiplierLow = copyFrom.MultiplierLow;
          bp.MultiplierNormal = copyFrom.MultiplierNormal;
          bp.MultiplierHigh = copyFrom.MultiplierHigh;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintDialogExperienceModifierTable>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.MultiplierLow = copyFrom.MultiplierLow;
          bp.MultiplierNormal = copyFrom.MultiplierNormal;
          bp.MultiplierHigh = copyFrom.MultiplierHigh;
        });
    }

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
  }
}
