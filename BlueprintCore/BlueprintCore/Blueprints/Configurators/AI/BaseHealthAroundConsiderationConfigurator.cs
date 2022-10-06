//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="HealthAroundConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseHealthAroundConsiderationConfigurator<T, TBuilder>
    : BaseUnitsAroundConsiderationConfigurator<T, TBuilder>
    where T : HealthAroundConsideration
    where TBuilder : BaseHealthAroundConsiderationConfigurator<T, TBuilder>
  {
    protected BaseHealthAroundConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<HealthAroundConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.RequiredMissingHealth = copyFrom.RequiredMissingHealth;
          bp.RequiredHealthLeft = copyFrom.RequiredHealthLeft;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<HealthAroundConsideration>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.RequiredMissingHealth = copyFrom.RequiredMissingHealth;
          bp.RequiredHealthLeft = copyFrom.RequiredHealthLeft;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HealthAroundConsideration.RequiredMissingHealth"/>
    /// </summary>
    public TBuilder SetRequiredMissingHealth(int requiredMissingHealth)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RequiredMissingHealth = requiredMissingHealth;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HealthAroundConsideration.RequiredHealthLeft"/>
    /// </summary>
    public TBuilder SetRequiredHealthLeft(int requiredHealthLeft)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RequiredHealthLeft = requiredHealthLeft;
        });
    }
  }
}
