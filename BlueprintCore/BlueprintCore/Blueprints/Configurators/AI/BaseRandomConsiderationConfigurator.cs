//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="RandomConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseRandomConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : RandomConsideration
    where TBuilder : BaseRandomConsiderationConfigurator<T, TBuilder>
  {
    protected BaseRandomConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<RandomConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.MinScore = copyFrom.MinScore;
          bp.MaxScore = copyFrom.MaxScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="RandomConsideration.MinScore"/>
    /// </summary>
    public TBuilder SetMinScore(float minScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinScore = minScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="RandomConsideration.MaxScore"/>
    /// </summary>
    public TBuilder SetMaxScore(float maxScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaxScore = maxScore;
        });
    }
  }
}
