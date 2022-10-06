//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="HasAutoCastConsideraion"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseHasAutoCastConsideraionConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : HasAutoCastConsideraion
    where TBuilder : BaseHasAutoCastConsideraionConfigurator<T, TBuilder>
  {
    protected BaseHasAutoCastConsideraionConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<HasAutoCastConsideraion>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.NoAutoCastScore = copyFrom.NoAutoCastScore;
          bp.HasAutoCastScore = copyFrom.HasAutoCastScore;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<HasAutoCastConsideraion>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.NoAutoCastScore = copyFrom.NoAutoCastScore;
          bp.HasAutoCastScore = copyFrom.HasAutoCastScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HasAutoCastConsideraion.NoAutoCastScore"/>
    /// </summary>
    public TBuilder SetNoAutoCastScore(float noAutoCastScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NoAutoCastScore = noAutoCastScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HasAutoCastConsideraion.HasAutoCastScore"/>
    /// </summary>
    public TBuilder SetHasAutoCastScore(float hasAutoCastScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasAutoCastScore = hasAutoCastScore;
        });
    }
  }
}
