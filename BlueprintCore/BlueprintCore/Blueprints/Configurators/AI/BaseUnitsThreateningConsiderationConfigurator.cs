//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="UnitsThreateningConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseUnitsThreateningConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : UnitsThreateningConsideration
    where TBuilder : BaseUnitsThreateningConsiderationConfigurator<T, TBuilder>
  {
    protected BaseUnitsThreateningConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="UnitsThreateningConsideration.MinCount"/>
    /// </summary>
    public TBuilder SetMinCount(int minCount)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinCount = minCount;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitsThreateningConsideration.MaxCount"/>
    /// </summary>
    public TBuilder SetMaxCount(int maxCount)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaxCount = maxCount;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitsThreateningConsideration.BelowMinScore"/>
    /// </summary>
    public TBuilder SetBelowMinScore(float belowMinScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BelowMinScore = belowMinScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitsThreateningConsideration.MinScore"/>
    /// </summary>
    public TBuilder SetMinScore(float minScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinScore = minScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitsThreateningConsideration.MaxScore"/>
    /// </summary>
    public TBuilder SetMaxScore(float maxScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaxScore = maxScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitsThreateningConsideration.ExtraTargetScore"/>
    /// </summary>
    public TBuilder SetExtraTargetScore(float extraTargetScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ExtraTargetScore = extraTargetScore;
        });
    }
  }
}
