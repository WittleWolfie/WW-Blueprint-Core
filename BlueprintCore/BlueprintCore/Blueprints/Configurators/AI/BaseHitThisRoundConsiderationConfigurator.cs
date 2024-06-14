//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="HitThisRoundConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseHitThisRoundConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : HitThisRoundConsideration
    where TBuilder : BaseHitThisRoundConsiderationConfigurator<T, TBuilder>
  {
    protected BaseHitThisRoundConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<HitThisRoundConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.HitScore = copyFrom.HitScore;
          bp.NoHitScore = copyFrom.NoHitScore;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<HitThisRoundConsideration>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.HitScore = copyFrom.HitScore;
          bp.NoHitScore = copyFrom.NoHitScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HitThisRoundConsideration.HitScore"/>
    /// </summary>
    public TBuilder SetHitScore(float hitScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HitScore = hitScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HitThisRoundConsideration.NoHitScore"/>
    /// </summary>
    public TBuilder SetNoHitScore(float noHitScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NoHitScore = noHitScore;
        });
    }
  }
}
