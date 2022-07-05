//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="TargetSelfConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTargetSelfConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : TargetSelfConsideration
    where TBuilder : BaseTargetSelfConsiderationConfigurator<T, TBuilder>
  {
    protected BaseTargetSelfConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="TargetSelfConsideration.SelfScore"/>
    /// </summary>
    public TBuilder SetSelfScore(float selfScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SelfScore = selfScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="TargetSelfConsideration.OthersScore"/>
    /// </summary>
    public TBuilder SetOthersScore(float othersScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OthersScore = othersScore;
        });
    }
  }
}
