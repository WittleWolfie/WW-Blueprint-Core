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
  /// Implements common fields and components for blueprints inheriting from <see cref="DirectionConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDirectionConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : DirectionConsideration
    where TBuilder : BaseDirectionConsiderationConfigurator<T, TBuilder>
  {
    protected BaseDirectionConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<DirectionConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Angle = copyFrom.Angle;
          bp.Spread = copyFrom.Spread;
          bp.HasUnitsInDirectionScore = copyFrom.HasUnitsInDirectionScore;
          bp.NoUnitsInDirectionScore = copyFrom.NoUnitsInDirectionScore;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<DirectionConsideration>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Angle = copyFrom.Angle;
          bp.Spread = copyFrom.Spread;
          bp.HasUnitsInDirectionScore = copyFrom.HasUnitsInDirectionScore;
          bp.NoUnitsInDirectionScore = copyFrom.NoUnitsInDirectionScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="DirectionConsideration.Angle"/>
    /// </summary>
    ///
    /// <param name="angle">
    /// <para>
    /// Tooltip: Sector direction relative to the front.
    /// </para>
    /// </param>
    public TBuilder SetAngle(float angle)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Angle = angle;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="DirectionConsideration.Spread"/>
    /// </summary>
    ///
    /// <param name="spread">
    /// <para>
    /// Tooltip: Sector radius in degrees.
    /// </para>
    /// </param>
    public TBuilder SetSpread(float spread)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Spread = spread;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="DirectionConsideration.HasUnitsInDirectionScore"/>
    /// </summary>
    public TBuilder SetHasUnitsInDirectionScore(float hasUnitsInDirectionScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasUnitsInDirectionScore = hasUnitsInDirectionScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="DirectionConsideration.NoUnitsInDirectionScore"/>
    /// </summary>
    public TBuilder SetNoUnitsInDirectionScore(float noUnitsInDirectionScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NoUnitsInDirectionScore = noUnitsInDirectionScore;
        });
    }
  }
}
