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

    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintAiSwitchWeapon>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.SwitchTo = copyFrom.SwitchTo;
        });
    }

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
