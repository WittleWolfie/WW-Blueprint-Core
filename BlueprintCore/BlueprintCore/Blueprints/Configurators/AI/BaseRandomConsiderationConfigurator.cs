//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="RandomConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseRandomConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : RandomConsideration
    where TBuilder : BaseRandomConsiderationConfigurator<T, TBuilder>
  {
    protected BaseRandomConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="RandomConsideration.MinScore"/>
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
    /// Modifies <see cref="RandomConsideration.MinScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMinScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MinScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="RandomConsideration.MaxScore"/>
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
    /// Modifies <see cref="RandomConsideration.MaxScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMaxScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MaxScore);
        });
    }
  }
}
