//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
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

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintAiFollow>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.TargetType = copyFrom.TargetType;
          bp.ApproachRange = copyFrom.ApproachRange;
        });
    }

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
