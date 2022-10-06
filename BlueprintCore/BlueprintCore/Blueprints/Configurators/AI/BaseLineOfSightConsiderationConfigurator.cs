//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="LineOfSightConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseLineOfSightConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : LineOfSightConsideration
    where TBuilder : BaseLineOfSightConsiderationConfigurator<T, TBuilder>
  {
    protected BaseLineOfSightConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<LineOfSightConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.HasNoLosScore = copyFrom.HasNoLosScore;
          bp.HasLosScore = copyFrom.HasLosScore;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<LineOfSightConsideration>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.HasNoLosScore = copyFrom.HasNoLosScore;
          bp.HasLosScore = copyFrom.HasLosScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LineOfSightConsideration.HasNoLosScore"/>
    /// </summary>
    public TBuilder SetHasNoLosScore(float hasNoLosScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasNoLosScore = hasNoLosScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LineOfSightConsideration.HasLosScore"/>
    /// </summary>
    public TBuilder SetHasLosScore(float hasLosScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasLosScore = hasLosScore;
        });
    }
  }
}
