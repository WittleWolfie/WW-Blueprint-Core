//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Enums;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAnswerBase"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAnswerBaseConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintAnswerBase
    where TBuilder : BaseAnswerBaseConfigurator<T, TBuilder>
  {
    protected BaseAnswerBaseConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintAnswerBase>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.MythicRequirement = copyFrom.MythicRequirement;
          bp.AlignmentRequirement = copyFrom.AlignmentRequirement;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintAnswerBase>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.MythicRequirement = copyFrom.MythicRequirement;
          bp.AlignmentRequirement = copyFrom.AlignmentRequirement;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAnswerBase.MythicRequirement"/>
    /// </summary>
    public TBuilder SetMythicRequirement(Mythic mythicRequirement)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MythicRequirement = mythicRequirement;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAnswerBase.AlignmentRequirement"/>
    /// </summary>
    public TBuilder SetAlignmentRequirement(AlignmentComponent alignmentRequirement)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AlignmentRequirement = alignmentRequirement;
        });
    }
  }
}
