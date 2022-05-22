//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="Consideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseConsiderationConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : Consideration
    where TBuilder : BaseConsiderationConfigurator<T, TBuilder>
  {
    protected BaseConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="Consideration.BaseScoreModifier"/>
    /// </summary>
    public TBuilder SetBaseScoreModifier(float baseScoreModifier)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BaseScoreModifier = baseScoreModifier;
        });
    }

    /// <summary>
    /// Modifies <see cref="Consideration.BaseScoreModifier"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBaseScoreModifier(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.BaseScoreModifier);
        });
    }
  }
}
