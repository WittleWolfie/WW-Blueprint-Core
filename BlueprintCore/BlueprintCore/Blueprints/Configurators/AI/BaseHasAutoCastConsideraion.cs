//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="HasAutoCastConsideraion"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseHasAutoCastConsideraionConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : HasAutoCastConsideraion
    where TBuilder : BaseHasAutoCastConsideraionConfigurator<T, TBuilder>
  {
    protected BaseHasAutoCastConsideraionConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="HasAutoCastConsideraion.NoAutoCastScore"/>
    /// </summary>
    public TBuilder SetNoAutoCastScore(float noAutoCastScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NoAutoCastScore = noAutoCastScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="HasAutoCastConsideraion.NoAutoCastScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNoAutoCastScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.NoAutoCastScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HasAutoCastConsideraion.HasAutoCastScore"/>
    /// </summary>
    public TBuilder SetHasAutoCastScore(float hasAutoCastScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasAutoCastScore = hasAutoCastScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="HasAutoCastConsideraion.HasAutoCastScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHasAutoCastScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.HasAutoCastScore);
        });
    }
  }
}
