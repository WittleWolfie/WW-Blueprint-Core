//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="ManualTargetConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseManualTargetConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : ManualTargetConsideration
    where TBuilder : BaseManualTargetConsiderationConfigurator<T, TBuilder>
  {
    protected BaseManualTargetConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="ManualTargetConsideration.IsManualTargetScore"/>
    /// </summary>
    public TBuilder SetIsManualTargetScore(float isManualTargetScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsManualTargetScore = isManualTargetScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ManualTargetConsideration.NotManualTargetScore"/>
    /// </summary>
    public TBuilder SetNotManualTargetScore(float notManualTargetScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NotManualTargetScore = notManualTargetScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ManualTargetConsideration.NoManualTargetScore"/>
    /// </summary>
    public TBuilder SetNoManualTargetScore(float noManualTargetScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NoManualTargetScore = noManualTargetScore;
        });
    }
  }
}
