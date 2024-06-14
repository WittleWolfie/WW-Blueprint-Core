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
  /// Implements common fields and components for blueprints inheriting from <see cref="HasManualTargetConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseHasManualTargetConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : HasManualTargetConsideration
    where TBuilder : BaseHasManualTargetConsiderationConfigurator<T, TBuilder>
  {
    protected BaseHasManualTargetConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<HasManualTargetConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.HasManualTargetScore = copyFrom.HasManualTargetScore;
          bp.NoManualTargetScore = copyFrom.NoManualTargetScore;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<HasManualTargetConsideration>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.HasManualTargetScore = copyFrom.HasManualTargetScore;
          bp.NoManualTargetScore = copyFrom.NoManualTargetScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HasManualTargetConsideration.HasManualTargetScore"/>
    /// </summary>
    public TBuilder SetHasManualTargetScore(float hasManualTargetScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasManualTargetScore = hasManualTargetScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HasManualTargetConsideration.NoManualTargetScore"/>
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
