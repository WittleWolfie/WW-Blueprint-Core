//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="InRangeConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseInRangeConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : InRangeConsideration
    where TBuilder : BaseInRangeConsiderationConfigurator<T, TBuilder>
  {
    protected BaseInRangeConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="InRangeConsideration.InRangeScore"/>
    /// </summary>
    public TBuilder SetInRangeScore(float inRangeScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.InRangeScore = inRangeScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="InRangeConsideration.OutOfRangeScore"/>
    /// </summary>
    public TBuilder SetOutOfRangeScore(float outOfRangeScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OutOfRangeScore = outOfRangeScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="InRangeConsideration.OnlyIfThreated"/>
    /// </summary>
    public TBuilder SetOnlyIfThreated(bool onlyIfThreated = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OnlyIfThreated = onlyIfThreated;
        });
    }
  }
}
