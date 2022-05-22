//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAiFollow"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAiFollowConfigurator<T, TBuilder>
    : BaseAiActionConfigurator<T, TBuilder>
    where T : BlueprintAiFollow
    where TBuilder : BaseAiFollowConfigurator<T, TBuilder>
  {
    protected BaseAiFollowConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiFollow.TargetType"/>
    /// </summary>
    public TBuilder SetTargetType(Kingmaker.AI.Blueprints.TargetType targetType)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TargetType = targetType;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiFollow.TargetType"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTargetType(Action<Kingmaker.AI.Blueprints.TargetType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.TargetType);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiFollow.ApproachRange"/>
    /// </summary>
    public TBuilder SetApproachRange(Feet approachRange)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ApproachRange = approachRange;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiFollow.ApproachRange"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyApproachRange(Action<Feet> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ApproachRange);
        });
    }
  }
}
