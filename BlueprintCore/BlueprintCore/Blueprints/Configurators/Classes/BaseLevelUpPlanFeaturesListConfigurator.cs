//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintLevelUpPlanFeaturesList"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseLevelUpPlanFeaturesListConfigurator<T, TBuilder>
    : BaseFeatureConfigurator<T, TBuilder>
    where T : BlueprintLevelUpPlanFeaturesList
    where TBuilder : BaseLevelUpPlanFeaturesListConfigurator<T, TBuilder>
  {
    protected BaseLevelUpPlanFeaturesListConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintLevelUpPlanFeaturesList>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Features = copyFrom.Features;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintLevelUpPlanFeaturesList>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Features = copyFrom.Features;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintLevelUpPlanFeaturesList.Features"/>
    /// </summary>
    public TBuilder SetFeatures(params BlueprintLevelUpPlanFeaturesList.FeatureWrapper[] features)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(features);
          bp.Features = features;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintLevelUpPlanFeaturesList.Features"/>
    /// </summary>
    public TBuilder AddToFeatures(params BlueprintLevelUpPlanFeaturesList.FeatureWrapper[] features)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Features = bp.Features ?? new BlueprintLevelUpPlanFeaturesList.FeatureWrapper[0];
          bp.Features = CommonTool.Append(bp.Features, features);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintLevelUpPlanFeaturesList.Features"/>
    /// </summary>
    public TBuilder RemoveFromFeatures(params BlueprintLevelUpPlanFeaturesList.FeatureWrapper[] features)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Features is null) { return; }
          bp.Features = bp.Features.Where(val => !features.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintLevelUpPlanFeaturesList.Features"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromFeatures(Func<BlueprintLevelUpPlanFeaturesList.FeatureWrapper, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Features is null) { return; }
          bp.Features = bp.Features.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintLevelUpPlanFeaturesList.Features"/>
    /// </summary>
    public TBuilder ClearFeatures()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Features = new BlueprintLevelUpPlanFeaturesList.FeatureWrapper[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintLevelUpPlanFeaturesList.Features"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyFeatures(Action<BlueprintLevelUpPlanFeaturesList.FeatureWrapper> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Features is null) { return; }
          bp.Features.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Features is null)
      {
        Blueprint.Features = new BlueprintLevelUpPlanFeaturesList.FeatureWrapper[0];
      }
    }
  }
}
