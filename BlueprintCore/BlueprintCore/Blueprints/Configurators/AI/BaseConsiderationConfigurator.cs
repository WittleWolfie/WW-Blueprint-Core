//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="Consideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseConsiderationConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : Consideration
    where TBuilder : BaseConsiderationConfigurator<T, TBuilder>
  {
    protected BaseConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<Consideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.BaseScoreModifier = copyFrom.BaseScoreModifier;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="Consideration.BaseScoreModifier"/>
    /// </summary>
    public TBuilder SetBaseScoreModifier(float baseScoreModifier)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BaseScoreModifier = baseScoreModifier;
        });
    }
  }
}
