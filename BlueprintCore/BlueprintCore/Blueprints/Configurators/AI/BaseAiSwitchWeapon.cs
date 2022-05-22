//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints;
using System;

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

    /// <summary>
    /// Modifies <see cref="BlueprintAiSwitchWeapon.SwitchTo"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySwitchTo(Action<SwitchMode> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.SwitchTo);
        });
    }
  }
}
