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
  /// Implements common fields and components for blueprints inheriting from <see cref="ManualTargetConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseManualTargetConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : ManualTargetConsideration
    where TBuilder : BaseManualTargetConsiderationConfigurator<T, TBuilder>
  {
    protected BaseManualTargetConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<ManualTargetConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.IsManualTargetScore = copyFrom.IsManualTargetScore;
          bp.NotManualTargetScore = copyFrom.NotManualTargetScore;
          bp.NoManualTargetScore = copyFrom.NoManualTargetScore;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<ManualTargetConsideration>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.IsManualTargetScore = copyFrom.IsManualTargetScore;
          bp.NotManualTargetScore = copyFrom.NotManualTargetScore;
          bp.NoManualTargetScore = copyFrom.NoManualTargetScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ManualTargetConsideration.IsManualTargetScore"/>
    /// </summary>
    public TBuilder SetIsManualTargetScore(float isManualTargetScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsManualTargetScore = isManualTargetScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ManualTargetConsideration.NotManualTargetScore"/>
    /// </summary>
    public TBuilder SetNotManualTargetScore(float notManualTargetScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NotManualTargetScore = notManualTargetScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ManualTargetConsideration.NoManualTargetScore"/>
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
