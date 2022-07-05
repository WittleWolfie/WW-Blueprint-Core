//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="CanMakeFullAttackConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCanMakeFullAttackConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : CanMakeFullAttackConsideration
    where TBuilder : BaseCanMakeFullAttackConsiderationConfigurator<T, TBuilder>
  {
    protected BaseCanMakeFullAttackConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="CanMakeFullAttackConsideration.SuccessScore"/>
    /// </summary>
    public TBuilder SetSuccessScore(float successScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SuccessScore = successScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="CanMakeFullAttackConsideration.FailScore"/>
    /// </summary>
    public TBuilder SetFailScore(float failScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FailScore = failScore;
        });
    }
  }
}
