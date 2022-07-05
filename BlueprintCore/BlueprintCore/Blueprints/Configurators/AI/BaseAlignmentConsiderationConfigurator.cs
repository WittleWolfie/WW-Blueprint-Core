//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.Enums;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="AlignmentConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAlignmentConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : AlignmentConsideration
    where TBuilder : BaseAlignmentConsiderationConfigurator<T, TBuilder>
  {
    protected BaseAlignmentConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="AlignmentConsideration.Alignment"/>
    /// </summary>
    public TBuilder SetAlignment(AlignmentComponent alignment)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Alignment = alignment;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AlignmentConsideration.SpecifiedAlignmentScore"/>
    /// </summary>
    public TBuilder SetSpecifiedAlignmentScore(float specifiedAlignmentScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SpecifiedAlignmentScore = specifiedAlignmentScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AlignmentConsideration.OtherAlignmentScore"/>
    /// </summary>
    public TBuilder SetOtherAlignmentScore(float otherAlignmentScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OtherAlignmentScore = otherAlignmentScore;
        });
    }
  }
}
