//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="TargetMainCharacter"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTargetMainCharacterConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : TargetMainCharacter
    where TBuilder : BaseTargetMainCharacterConfigurator<T, TBuilder>
  {
    protected BaseTargetMainCharacterConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<TargetMainCharacter>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.IsMainCharacterScore = copyFrom.IsMainCharacterScore;
          bp.OthersScore = copyFrom.OthersScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="TargetMainCharacter.IsMainCharacterScore"/>
    /// </summary>
    public TBuilder SetIsMainCharacterScore(float isMainCharacterScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsMainCharacterScore = isMainCharacterScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="TargetMainCharacter.OthersScore"/>
    /// </summary>
    public TBuilder SetOthersScore(float othersScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OthersScore = othersScore;
        });
    }
  }
}
