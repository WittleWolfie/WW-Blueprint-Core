//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="CasterClassConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCasterClassConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : CasterClassConsideration
    where TBuilder : BaseCasterClassConsiderationConfigurator<T, TBuilder>
  {
    protected BaseCasterClassConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="CasterClassConsideration.NotCasterScore"/>
    /// </summary>
    public TBuilder SetNotCasterScore(float notCasterScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NotCasterScore = notCasterScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="CasterClassConsideration.NotCasterScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNotCasterScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.NotCasterScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="CasterClassConsideration.ArcaneCasterScore"/>
    /// </summary>
    public TBuilder SetArcaneCasterScore(float arcaneCasterScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ArcaneCasterScore = arcaneCasterScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="CasterClassConsideration.ArcaneCasterScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyArcaneCasterScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ArcaneCasterScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="CasterClassConsideration.DivineCasterScore"/>
    /// </summary>
    public TBuilder SetDivineCasterScore(float divineCasterScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DivineCasterScore = divineCasterScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="CasterClassConsideration.DivineCasterScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDivineCasterScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.DivineCasterScore);
        });
    }
  }
}
