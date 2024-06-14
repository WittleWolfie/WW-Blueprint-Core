//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.Enums;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="AlignmentConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAlignmentConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : AlignmentConsideration
    where TBuilder : BaseAlignmentConsiderationConfigurator<T, TBuilder>
  {
    protected BaseAlignmentConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<AlignmentConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Alignment = copyFrom.Alignment;
          bp.SpecifiedAlignmentScore = copyFrom.SpecifiedAlignmentScore;
          bp.OtherAlignmentScore = copyFrom.OtherAlignmentScore;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<AlignmentConsideration>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Alignment = copyFrom.Alignment;
          bp.SpecifiedAlignmentScore = copyFrom.SpecifiedAlignmentScore;
          bp.OtherAlignmentScore = copyFrom.OtherAlignmentScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AlignmentConsideration.Alignment"/>
    /// </summary>
    public TBuilder SetAlignment(AlignmentComponent alignment)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Alignment = alignment;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AlignmentConsideration.SpecifiedAlignmentScore"/>
    /// </summary>
    public TBuilder SetSpecifiedAlignmentScore(float specifiedAlignmentScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SpecifiedAlignmentScore = specifiedAlignmentScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AlignmentConsideration.OtherAlignmentScore"/>
    /// </summary>
    public TBuilder SetOtherAlignmentScore(float otherAlignmentScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OtherAlignmentScore = otherAlignmentScore;
        });
    }
  }
}
