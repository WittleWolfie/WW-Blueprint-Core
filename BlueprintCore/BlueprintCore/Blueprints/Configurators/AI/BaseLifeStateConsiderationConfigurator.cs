//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="LifeStateConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseLifeStateConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : LifeStateConsideration
    where TBuilder : BaseLifeStateConsiderationConfigurator<T, TBuilder>
  {
    protected BaseLifeStateConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="LifeStateConsideration.AliveScore"/>
    /// </summary>
    public TBuilder SetAliveScore(float aliveScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AliveScore = aliveScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LifeStateConsideration.DeadScore"/>
    /// </summary>
    public TBuilder SetDeadScore(float deadScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DeadScore = deadScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LifeStateConsideration.UnconsciousScore"/>
    /// </summary>
    public TBuilder SetUnconsciousScore(float unconsciousScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UnconsciousScore = unconsciousScore;
        });
    }
  }
}
