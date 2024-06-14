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
  /// Implements common fields and components for blueprints inheriting from <see cref="CasterClassConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCasterClassConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : CasterClassConsideration
    where TBuilder : BaseCasterClassConsiderationConfigurator<T, TBuilder>
  {
    protected BaseCasterClassConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<CasterClassConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.NotCasterScore = copyFrom.NotCasterScore;
          bp.ArcaneCasterScore = copyFrom.ArcaneCasterScore;
          bp.DivineCasterScore = copyFrom.DivineCasterScore;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<CasterClassConsideration>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.NotCasterScore = copyFrom.NotCasterScore;
          bp.ArcaneCasterScore = copyFrom.ArcaneCasterScore;
          bp.DivineCasterScore = copyFrom.DivineCasterScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="CasterClassConsideration.NotCasterScore"/>
    /// </summary>
    public TBuilder SetNotCasterScore(float notCasterScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NotCasterScore = notCasterScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="CasterClassConsideration.ArcaneCasterScore"/>
    /// </summary>
    public TBuilder SetArcaneCasterScore(float arcaneCasterScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ArcaneCasterScore = arcaneCasterScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="CasterClassConsideration.DivineCasterScore"/>
    /// </summary>
    public TBuilder SetDivineCasterScore(float divineCasterScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DivineCasterScore = divineCasterScore;
        });
    }
  }
}
