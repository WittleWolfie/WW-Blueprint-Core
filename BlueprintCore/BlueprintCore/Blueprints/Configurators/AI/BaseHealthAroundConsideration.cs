//***** AUTO-GENERATED - DO NOT EDIT *****//

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
    protected BaseHealthAroundConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

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
    /// Modifies <see cref="HealthAroundConsideration.RequiredMissingHealth"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRequiredMissingHealth(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.RequiredMissingHealth);
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

    /// <summary>
    /// Modifies <see cref="HealthAroundConsideration.RequiredHealthLeft"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRequiredHealthLeft(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.RequiredHealthLeft);
        });
    }
  }
}
