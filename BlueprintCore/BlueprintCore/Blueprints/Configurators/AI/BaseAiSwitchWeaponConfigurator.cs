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
    protected BaseAiSwitchWeaponConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiSwitchWeapon.SwitchTo"/>
    /// </summary>
    public TBuilder SetSwitchTo(SwitchMode switchTo)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SwitchTo = switchTo;
        });
    }
  }
}
