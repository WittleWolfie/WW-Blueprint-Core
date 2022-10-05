//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

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

    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<ManualTargetConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.IsManualTargetScore = copyFrom.IsManualTargetScore;
          bp.NotManualTargetScore = copyFrom.NotManualTargetScore;
          bp.NoManualTargetScore = copyFrom.NoManualTargetScore;
        });
    }

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
