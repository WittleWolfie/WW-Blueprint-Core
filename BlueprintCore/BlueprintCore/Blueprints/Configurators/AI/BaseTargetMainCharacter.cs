//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;

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
    protected BaseTargetMainCharacterConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
