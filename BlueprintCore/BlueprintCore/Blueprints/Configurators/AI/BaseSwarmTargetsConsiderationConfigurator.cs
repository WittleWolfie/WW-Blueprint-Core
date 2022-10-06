//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="SwarmTargetsConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseSwarmTargetsConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : SwarmTargetsConsideration
    where TBuilder : BaseSwarmTargetsConsiderationConfigurator<T, TBuilder>
  {
    protected BaseSwarmTargetsConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<SwarmTargetsConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.HasEnemiesScore = copyFrom.HasEnemiesScore;
          bp.NoEnemiesScore = copyFrom.NoEnemiesScore;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<SwarmTargetsConsideration>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.HasEnemiesScore = copyFrom.HasEnemiesScore;
          bp.NoEnemiesScore = copyFrom.NoEnemiesScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="SwarmTargetsConsideration.HasEnemiesScore"/>
    /// </summary>
    public TBuilder SetHasEnemiesScore(float hasEnemiesScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasEnemiesScore = hasEnemiesScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="SwarmTargetsConsideration.NoEnemiesScore"/>
    /// </summary>
    public TBuilder SetNoEnemiesScore(float noEnemiesScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NoEnemiesScore = noEnemiesScore;
        });
    }
  }
}
