//***** AUTO-GENERATED - DO NOT EDIT *****//

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
    /// Modifies <see cref="TargetMainCharacter.IsMainCharacterScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIsMainCharacterScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.IsMainCharacterScore);
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

    /// <summary>
    /// Modifies <see cref="TargetMainCharacter.OthersScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOthersScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.OthersScore);
        });
    }
  }
}
