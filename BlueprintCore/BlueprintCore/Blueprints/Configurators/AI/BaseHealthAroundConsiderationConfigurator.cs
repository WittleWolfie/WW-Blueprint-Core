//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;

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
