//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="TargetSelfConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTargetSelfConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : TargetSelfConsideration
    where TBuilder : BaseTargetSelfConsiderationConfigurator<T, TBuilder>
  {
    protected BaseTargetSelfConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<TargetSelfConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.SelfScore = copyFrom.SelfScore;
          bp.OthersScore = copyFrom.OthersScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="TargetSelfConsideration.SelfScore"/>
    /// </summary>
    public TBuilder SetSelfScore(float selfScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SelfScore = selfScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="TargetSelfConsideration.OthersScore"/>
    /// </summary>
    public TBuilder SetOthersScore(float othersScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OthersScore = othersScore;
        });
    }
  }
}
