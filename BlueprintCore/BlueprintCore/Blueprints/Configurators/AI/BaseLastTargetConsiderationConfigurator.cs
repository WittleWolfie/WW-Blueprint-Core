//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="LastTargetConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseLastTargetConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : LastTargetConsideration
    where TBuilder : BaseLastTargetConsiderationConfigurator<T, TBuilder>
  {
    protected BaseLastTargetConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<LastTargetConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.SameLastTargetScore = copyFrom.SameLastTargetScore;
          bp.OtherLastTargetScore = copyFrom.OtherLastTargetScore;
          bp.NoLastTargetScore = copyFrom.NoLastTargetScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LastTargetConsideration.SameLastTargetScore"/>
    /// </summary>
    public TBuilder SetSameLastTargetScore(float sameLastTargetScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SameLastTargetScore = sameLastTargetScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LastTargetConsideration.OtherLastTargetScore"/>
    /// </summary>
    public TBuilder SetOtherLastTargetScore(float otherLastTargetScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OtherLastTargetScore = otherLastTargetScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LastTargetConsideration.NoLastTargetScore"/>
    /// </summary>
    public TBuilder SetNoLastTargetScore(float noLastTargetScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NoLastTargetScore = noLastTargetScore;
        });
    }
  }
}
