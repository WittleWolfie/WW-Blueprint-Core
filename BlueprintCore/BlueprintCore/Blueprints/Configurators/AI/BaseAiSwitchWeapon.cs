//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAiSwitchWeapon"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAiSwitchWeaponConfigurator<T, TBuilder>
    : BaseAiActionConfigurator<T, TBuilder>
    where T : BlueprintAiSwitchWeapon
    where TBuilder : BaseAiSwitchWeaponConfigurator<T, TBuilder>
  {
    protected BaseAiSwitchWeaponConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
